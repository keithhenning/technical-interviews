// Parse-only front end for the C# syntax gate. Built and driven by tools/csharp_gate.py.
//
// WHY A PARSER AND NOT A COMPILER, which is the whole design decision in this file.
//
// The obvious way to check 278 book snippets is to hand them all to csc. That was tried and it
// does not work, and the way it fails is worth writing down because it looks like success:
// compiling the whole set reports 46 errors, all CS0106, and nothing else. That reads as "the
// only problem is the known book convention". It is not. Roslyn stops after those declaration
// errors, so everything downstream is never reported. Remove the 42 files carrying CS0106 and
// recompile the remaining 236 and 464 errors appear: 111 CS0101 duplicate types, 122 CS0111
// duplicate members, 49 CS0246 missing types, and more. Independent snippets from a book share
// class names and reference types the prose defines, so a whole-set compile is meaningless.
//
// Compiling them one at a time does not rescue it either: each file alone still references types
// the book defines elsewhere, which is the same reason C++ and Java are not gateable this way.
//
// So this asks the only question a syntax gate should ask: DOES THE FILE PARSE?
// `CSharpSyntaxTree.ParseText(...).GetDiagnostics()` returns the diagnostics the PARSER produced,
// by construction rather than by filtering. There is no numeric range to guess at and no message
// to pattern-match. That matters: "CS1xxx means a parse error" is a tempting rule and it is false
// -- CS1061 is semantic -- so a gate built on that range would be reading through a slit it chose
// for itself.
//
// THE ONE EXCLUSION, AND IT IS PROVED PER FILE RATHER THAN ASSUMED.
//
// 42 files are bare methods with no enclosing class, which is a deliberate book convention for
// showing one routine. The parser reports CS0106, "the modifier 'public' is not valid for this
// item", 46 times across those 42 files.
//
// So a file whose only errors are CS0106 is not excused, it is RE-PARSED wrapped in a class. If
// the wrapped form is clean, the convention is what produced the diagnostic and this run proved
// it for that file rather than crediting it. If the wrapped form still has errors, the file is
// broken. The wrap is built from the syntax tree rather than by text munging, because a using
// directive cannot sit inside a class and a third of these files open with one.
//
// HONEST LIMIT OF THAT ARGUMENT, because the first version of this comment overstated it. The
// wrap was justified here as closing a hole: a stray brace ends a class early, the following
// members land at top level, and CS0106 is the only symptom, so a blanket exemption would swallow
// a real defect. THAT CASE COULD NOT BE CONSTRUCTED. Roslyn emits CS8803, "top-level statements
// must precede namespace and type declarations", alongside the CS0106 whenever a bare member
// follows a type declaration, so the ordinary branch catches it and the wrap never sees it. Every
// attempt to build a genuinely broken file whose sole diagnostic is CS0106 produced a second
// diagnostic as well.
//
// The wrap is therefore belt and braces rather than a demonstrated hole being closed, and it is
// kept for two reasons that are still worth its weight: it turns "42 files are the book
// convention, proved by wrapping one of them once" into a proof carried out on all 42 on every
// run, and it covers the case nobody thought of. It is live rather than decorative -- making
// Wrap() return its input unchanged reports all 46 diagnostics, which is how that was checked.
//
// Output is one TSV line per finding on stdout, and a "parsed N" line on stderr so the caller can
// verify the run read what it claimed to read.
//
//   path <TAB> line <TAB> id <TAB> stage <TAB> message
//
// stage is `parse` for a plain failure and `wrapped` for one that survived the class wrapper,
// which tells the reader whether they are looking at a broken snippet or a broken convention.
using System;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

static class CSharpParseGate
{
    // The bare-method convention. Not an allowlist of files: an allowlist of ONE diagnostic, and
    // every file it applies to still has to pass the wrap below.
    const string BareMemberDiagnostic = "CS0106";

    static int Main(string[] argv)
    {
        if (argv.Length != 1)
        {
            Console.Error.WriteLine("usage: ParseOnly <file-containing-one-path-per-line>");
            return 2;
        }

        int parsed = 0;
        foreach (var path in File.ReadAllLines(argv[0]))
        {
            if (path.Length == 0) continue;
            parsed++;

            var source = File.ReadAllText(path);
            var errors = ErrorsOf(CSharpSyntaxTree.ParseText(source, path: path));

            if (errors.Length == 0) continue;

            if (errors.All(d => d.Id == BareMemberDiagnostic))
            {
                // The convention, checked rather than credited. If wrapping in a class makes it
                // clean, CS0106 was the book's layout and not a defect.
                var wrapped = ErrorsOf(CSharpSyntaxTree.ParseText(Wrap(source), path: path));
                if (wrapped.Length == 0) continue;
                foreach (var d in wrapped) Report(path, d, "wrapped");
                continue;
            }

            foreach (var d in errors) Report(path, d, "parse");
        }

        Console.Error.WriteLine($"parsed {parsed}");
        return 0;
    }

    static Diagnostic[] ErrorsOf(SyntaxTree tree) =>
        tree.GetDiagnostics().Where(d => d.Severity == DiagnosticSeverity.Error).ToArray();

    static void Report(string path, Diagnostic d, string stage)
    {
        var line = d.Location.GetLineSpan().StartLinePosition.Line + 1;
        // Tabs separate the fields, so anything the message contains cannot be mistaken for one.
        var message = d.GetMessage().Replace('\t', ' ').Replace('\n', ' ').Replace('\r', ' ');
        Console.WriteLine($"{path}\t{line}\t{d.Id}\t{stage}\t{message}");
    }

    /// <summary>
    /// Put everything that is not a using directive inside a class, so a file that is a bare method
    /// becomes a legal compilation unit.
    ///
    /// The split point comes from the parsed tree rather than from a regex over the text. A using
    /// directive is illegal inside a type declaration, so a naive whole-file wrap would turn a
    /// clean file into a broken one and this check would then "prove" a defect it created itself.
    /// </summary>
    static string Wrap(string source)
    {
        var root = CSharpSyntaxTree.ParseText(source).GetCompilationUnitRoot();
        // End of the last using, or the start of the file when there are none. Using FullSpan.End
        // keeps the trivia (comments, blank lines) with the part it was written against.
        int split = root.Usings.Count > 0 ? root.Usings.Last().FullSpan.End : 0;
        return source.Substring(0, split)
             + "\nclass __GateWrapper {\n"
             + source.Substring(split)
             + "\n}\n";
    }
}

public interface IDocument
{
    void Open();
}

public class PDFDocument : IDocument
{
    public void Open() { /* PDF specific logic */ }
}

public class DocumentFactory
{
    public IDocument CreateDocument(string type)
    {
        if (type == "pdf")
        {
            return new PDFDocument();
        }
        // Add other document types
        return null;
    }
}

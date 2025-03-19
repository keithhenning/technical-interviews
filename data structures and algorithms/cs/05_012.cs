try {
    Deque<string> stack = new Deque<string>();
    stack.RemoveFirst();  // Throws InvalidOperationException
} catch (InvalidOperationException e) {
    Console.WriteLine("Handle empty stack!");
}

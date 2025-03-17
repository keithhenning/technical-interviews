try {
    Deque<String> stack = new ArrayDeque<>();
    stack.pop();  // Throws NoSuchElementException
} catch (NoSuchElementException e) {
    System.out.println("Handle empty stack!");
}
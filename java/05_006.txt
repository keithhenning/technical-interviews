/**
   * Returns the top element without removing it
   */
  public Object peek(Stack<Object> stack) {
     // Check for empty stack to prevent EmptyStackException
     if (stack.isEmpty()) {
        throw new EmptyStackException();
     }
     return stack.peek();
  }
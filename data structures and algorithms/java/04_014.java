public class Computer {
    private Computer(Builder builder) {
        // Build computer with specifications
    }
    
    public static class Builder {
        private String cpu;
        private String ram;
        
        public Builder setCPU(String cpu) {
            this.cpu = cpu;
            return this;
        }
        
        public Computer build() {
            return new Computer(this);
        }
    }
}
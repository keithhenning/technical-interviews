public class Computer
{
    private Computer(Builder builder)
    {
        // Build computer with specifications
    }

    public class Builder
    {
        private string cpu;
        private string ram;

        public Builder SetCPU(string cpu)
        {
            this.cpu = cpu;
            return this;
        }

        public Computer Build()
        {
            return new Computer(this);
        }
    }
}

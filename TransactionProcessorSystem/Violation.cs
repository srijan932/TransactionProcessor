namespace TransactionProcessorSystem
{
    public class Violation
    {
        public int order;
        public string property;
        public string description;

        public Violation(int order, string property, string description)
        {
            this.order = order;
            this.property = property;
            this.description = description;
        }
    }
}
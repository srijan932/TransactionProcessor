namespace TransactionProcessorSystem
{
    public class Transaction
    {
        public char type;
        public float amount;
        public string narration;

        public Transaction(char type, float amount, string narration)
        {
            this.type = type;
            this.amount = amount;
            this.narration = narration;
        }
    }
}
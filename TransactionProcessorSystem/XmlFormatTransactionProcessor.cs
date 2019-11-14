using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TransactionProcessorSystem
{
    class XmlFormatTransactionProcessor : ITransactionProcessor
    {
        List<Transaction> transactions = new List<Transaction>();
        List<Violation> violations1 = new List<Violation>();

        public void importTransactions(String filename)
        {

            XmlTextReader reader = new XmlTextReader(filename);
            while (reader.Read())
            {
                if (reader.Name.Equals("Transaction"))
                {
                    Transaction transaction = new Transaction(
                            reader.GetAttribute("type")[0],
                            float.Parse(reader.GetAttribute("amount")),
                            reader.GetAttribute("narration")
                        );
                    transactions.Add(transaction);
                }
            }
        }

        public List<Transaction> getImportedTransactions()
        {
            return transactions;
        }

        public List<Violation> validate()
        {
            foreach (Transaction transaction in transactions)
            {
                if (transaction.amount == 0 || transaction.amount == ' ')
                {
                    Violation violation = new Violation((new System.Diagnostics.StackFrame(0, true))
                        .GetFileLineNumber(), "Amount", transaction.narration);
                    violations1.Add(violation);
                }
                if (((transaction.type != 'D') || (transaction.type == 'C'))
                    && ((transaction.type == 'D') || (transaction.type != 'C')))
                {
                    Violation violation = new Violation((new System.Diagnostics.StackFrame(0, true))
                        .GetFileLineNumber(), "Type", transaction.narration);
                    violations1.Add(violation);
                }

            }
            return violations1;

        }

        public bool isBalanced()
        {
            float sumofdebit = 0;
            float sumofcredit = 0;
            foreach (Transaction transaction in transactions)
            {
                if (transaction.type == 'D')
                {
                    sumofdebit += transaction.amount;
                }
                else if (transaction.type == 'C')
                {
                    sumofcredit += transaction.amount;
                }


            }
            if (sumofdebit == sumofcredit)
            {
                Console.WriteLine("The Sum of Credit and Debit Transactions are equal.");
                return true;
            }
            else
            {
                Console.WriteLine("The Sum of Credit and Debit Transactions are not equal.");
                return false;
            }

        }
    }
}

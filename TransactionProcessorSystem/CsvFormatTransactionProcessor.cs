using System;
using System.Collections.Generic;
using System.IO;

namespace TransactionProcessorSystem
{
    class CsvFormatTransactionProcessor : ITransactionProcessor
    {

        List<Transaction> transactions = new List<Transaction>();
        List<Violation> violations = new List<Violation>();
        public void importTransactions(String filename)
        {
            StreamReader reader = new StreamReader(filename);
            while (!reader.EndOfStream)
            {
                String line = reader.ReadLine();
                String[] values = line.Split(',');
                String type = values[0];
                String amount = values[1];
                String narration = values[2];

                Transaction transaction = new Transaction(type[0], float.Parse(amount), narration);

                transactions.Add(transaction);
            }

 
            reader.Close();
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
                        .GetFileLineNumber(), "Amount",transaction.narration);
                    violations.Add(violation);
                }
                if (((transaction.type != 'D') || (transaction.type == 'C')) 
                    && ((transaction.type == 'D') || (transaction.type != 'C')))
                {
                    Violation violation = new Violation((new System.Diagnostics.StackFrame(0, true))
                        .GetFileLineNumber(), "Type", transaction.narration);
                    violations.Add(violation);
                }

            }
            return violations;

        }

        public bool isBalanced()
        {
            float sumofdebit = 0;
            float sumofcredit = 0;
            foreach (Transaction transaction in transactions)
            {
                if(transaction.type == 'D')
                { 
                    sumofdebit += transaction.amount;
                }
                else if(transaction.type == 'C')
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


using System;
using System.Collections.Generic;

namespace TransactionProcessorSystem
{
    interface ITransactionProcessor
    {
        void importTransactions(String filename);

        List<Transaction> getImportedTransactions();

        List<Violation> validate();

        bool isBalanced();
    }
}

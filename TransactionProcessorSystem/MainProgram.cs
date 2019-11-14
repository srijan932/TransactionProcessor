using System;
using System.Collections.Generic;

namespace TransactionProcessorSystem
{

    class MainProgram
    {
        static void Main(string[] args)
        {
            //Csv Format Transactions

            CsvFormatTransactionProcessor c1 = new CsvFormatTransactionProcessor();
            c1.importTransactions(@"C:\Test.csv");

            Console.WriteLine("Csv Format Transactions:");
            Console.WriteLine("---------------------------");
            List<Violation> violations = c1.validate();
            foreach (Violation violation in violations)
            {
                Console.WriteLine("Violation FileLineNumber:"+violation.order);
                Console.WriteLine("Violation FieldName:"+violation.property);
                Console.WriteLine("Violation Description:"+violation.description);
            }
            c1.isBalanced();
            Console.WriteLine("****************************************************************");

            //Xml Format Transactions

            XmlFormatTransactionProcessor a1 = new XmlFormatTransactionProcessor();
            a1.importTransactions(@"D:\book.xml");

            Console.WriteLine("Xml Format Transactions:");
            Console.WriteLine("-----------------------------");
            List<Violation> violations1 = a1.validate();
            foreach (Violation violation in violations1)
            {
                Console.WriteLine("Violation FileLineNumber:" + violation.order);
                Console.WriteLine("Violation FieldName:" + violation.property);
                Console.WriteLine("Violation Description:" + violation.description);
            }
            a1.isBalanced();
            Console.WriteLine("*****************************************************************");
            Console.ReadKey();
        }
    }
}

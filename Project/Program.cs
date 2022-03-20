using System;
using System.Globalization;
using Project.Entities;
using Project.Interfaces;
using Project.Services;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Enter contract data");

            try
            {
                System.Console.Write("Number: ");
                int number = int.Parse(Console.ReadLine());

                System.Console.Write("Date (dd/MM/yyyy): ");
                DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

                System.Console.Write("Contract value: ");
                double totalValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                System.Console.Write("Enter number of installments: ");
                int months = int.Parse(Console.ReadLine());

                Contract contract = new Contract(number, date, totalValue);

                ContractService contractService = new ContractService(new PayPalPaymentService());

                contractService.ProcessContract(contract, months);

                System.Console.WriteLine();
                System.Console.WriteLine("Installments:");
                foreach (Installment installment in contract.installments)
                {
                    System.Console.WriteLine(installment);
                }
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine("Unexpected Error: " + e);
            }
        }
    }
}
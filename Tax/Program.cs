using System;
using System.Collections.Generic;
using System.Globalization;

namespace Tax
{
    class Program
    {
        static void Main()
        {
            decimal totalTaxes = 0;
            int rPayers;
            string payers;            
            List<Contribuinte> contribuintes = new List<Contribuinte>();            

            do
            {
                Console.Write("Enter the number of tax payers: ");
                Console.ForegroundColor = ConsoleColor.Red;
                payers = Console.ReadLine();
                Console.ResetColor();
            } while (!int.TryParse(payers, out rPayers));          
           
            for (int i = 1; i <= rPayers; i++)
            {
                Contribuinte contribuinte;

                Console.WriteLine("Tax payer #" + i + " data:");

                char rType;
                string type;
                do
                {
                    Console.Write("Individual or company (i/c)? ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    type = Console.ReadLine();
                    Console.ResetColor();
                } while ((!char.TryParse(type, out rType) && (rType != 'c') && (rType != 'i')));

                string name;
                do
                {
                    Console.Write("Name: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    name = Console.ReadLine();
                    Console.ResetColor();
                } while (name.Trim() == "");

                decimal dAnualIncome;
                string anualIncome;
                do
                {
                    Console.Write("Anual income: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    anualIncome = Console.ReadLine();
                    Console.ResetColor();
                } while (!decimal.TryParse(anualIncome, out decimal result));
                dAnualIncome = decimal.Parse(anualIncome, CultureInfo.InvariantCulture);

                if (rType == 'c')
                {
                    int rNumberEmployees;
                    string numberEmployess;
                    do
                    {
                        Console.Write("Number of employees: ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        numberEmployess = Console.ReadLine();
                        Console.ResetColor();

                    } while (!int.TryParse(numberEmployess, out rNumberEmployees));

                    contribuinte = new PessoaJuridica(name, dAnualIncome, rNumberEmployees);
                }
                else
                {
                    decimal dHealthExpend;
                    string HealthExpend;
                    do
                    {
                        Console.Write("Health expenditures: ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        HealthExpend = Console.ReadLine();
                        Console.ResetColor();
                    } while (!decimal.TryParse(HealthExpend, out decimal result));
                    dHealthExpend = decimal.Parse(HealthExpend, CultureInfo.InvariantCulture);

                    contribuinte = new PessaoFisica(name, dAnualIncome, dHealthExpend);
                }
                contribuintes.Add(contribuinte);
            }

            Console.WriteLine();
            Console.WriteLine("TAXES PAID:");
            
            foreach (var contribuinte in contribuintes)
            {
                decimal tax = contribuinte.CalcImposto();
                totalTaxes += tax;
                Console.WriteLine(contribuinte.PrintTaxesPaid(tax));                
            }

            Console.WriteLine();
            Console.WriteLine("TOTAL TAXES: $ " + totalTaxes.ToString("F2", CultureInfo.InvariantCulture));
            Console.ReadLine();
        }
    }
}

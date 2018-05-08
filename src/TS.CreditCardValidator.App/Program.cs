using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.CreditCardValidator.Core.Models;

namespace TS.CreditCardValidator.App
{
    class Program
    {
        static void Main(string[] args)
        {
            List<CreditCard> creditCards = new List<CreditCard>()
            {
                new CreditCard("4111111111111111"),
                new CreditCard("4111111111111"),
                new CreditCard("4012888888881881"),
                new CreditCard("378282246310005"),
                new CreditCard("6011111111111117"),
                new CreditCard("5105105105105100"),
                new CreditCard("5105 1051 0510 5106"),
                new CreditCard("9111111111111111")
            };

            foreach (var creditCard in creditCards)
            {
                string message = creditCard.IsValid ? "válido" : "inválido";
                Console.WriteLine($"{creditCard.Type}: {creditCard.Number} ({message})");
            }

            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS.CreditCardValidator.Core.Utils
{
    public class CreditCardNumberValidation
    {
        public bool Result { get; private set; }

        public CreditCardNumberValidation(string Number)
        {
            this.runNumberValidation(Number);
        }
        
        private void runNumberValidation(string Number)
        {
            /*
            TIPOS DE CARTÃO PRÉ-DEFINIDOS: TS.CreditCardValidator.Core.Enums.CreditCardType

            TODOS ESSES TIPOS DE CARTÃO PODEM SER VALIDADOS PELO ALGORITMO LUHN. AS ETAPAS DE VERIFICAÇÃO SÃO:
                1. Tome uma sequência de números inteiros positivos e a inverta.
                2. Começando pelo segundo número, dobre o valor de cada número de forma alternada ("24145... = "28185...).
                3. Para dígitos maiores que 9 será necessário que some cada dígito ("10", 1 + 0 = 1) ou subtraia por 9 ("10", 10 - 9 = 1).
                4. Some todos os números da sequência.
                5. Se o total for múltiplo de 10, o número é válido.
            */

            var numbers = new int[Number.Length];

            // 1. Inversão dos Números do Cartão de Crédito;
            var aux = Number.Reverse();

            int total = 0;

            foreach (var item in aux.Select((item, i) => new { index = i, number = item.ToString() }))
            {
                // Converter o número do item para um numero inteiro;
                var number = Convert.ToInt32(item.number);

                // 2. Dobra de cada número de forma alternada: (index MOD 2 diferente de ZERO);
                number = (item.index % 2 == 0) ? number : number * 2;

                // 3. Se o número for maior que 9, deve-se subtrair 9;
                number = (number > 9) ? (number - 9) : number;

                // 4. Soma dos números da sequencia;
                total += number;
            }

            this.Result = (total % 10 == 0);
        }
    }
}

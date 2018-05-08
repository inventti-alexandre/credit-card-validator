using System;
using TS.CreditCardValidator.Core.Enums;

namespace TS.CreditCardValidator.Core.Utils
{
    public class CreditCardTypeVerification
    {
        public CreditCardType Result { get; private set; }

        public CreditCardTypeVerification(string Number)
        {
            this.runTypeVerification(Number);
        }


        private void runTypeVerification(string Number)
        {
            /*
            -------------------------------------------------------------
            |   TIPO DE CARTÃO  |   COMEÇA COM  |   NÚMERO COMPRIMENTO  |
            -------------------------------------------------------------
            |   AMEX 	        |   34 ou 37 	|   15                  |
            |   Discover 	    |   6011 	    |   16                  |
            |   MasterCard 	    |   51-55 	    |   16                  |
            |   Visa 	        |   4 	        |   13 ou 16            |
            ------------------------------------------------------------- 
            */
            
            long test_number_only;
            if (!long.TryParse(Number, out test_number_only))
                throw new Exception("The Credit Card Number is Invalid..");


            if ((Number.StartsWith("34") || Number.StartsWith("37")) && Number.Length.Equals(15))
                this.Result = CreditCardType.AMEX;

            else if (Number.StartsWith("6011") && Number.Length.Equals(16))
                this.Result = CreditCardType.Discover;

            else if (Number.StartsWith("4") && (Number.Length.Equals(13) || Number.Length.Equals(16)))
                this.Result = CreditCardType.VISA;

            else
            {
                int prefix;
                string s_prefix = Number.Substring(0, 2);

                bool isNumber = int.TryParse(s_prefix, out prefix);

                if (prefix >= 51 && prefix <= 55)
                {
                    this.Result = CreditCardType.MasterCard;
                }
                else
                {
                    if (!isNumber)
                        throw new Exception("The Credit Card Number has an Invalid Prefix.");

                    this.Result = CreditCardType.Undefined;
                }
            }
        }
    }
}

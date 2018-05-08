using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.CreditCardValidator.Core.Enums;
using TS.CreditCardValidator.Core.Utils;

namespace TS.CreditCardValidator.Core.Models
{
    public class CreditCard
    {
        public CreditCard(string Number)
        {
            this.Number = (Number != null) ? Number.Replace(" ", string.Empty) : string.Empty;
        }

        public string Number { get; private set; }

        public CreditCardType Type
        {
            get { return new CreditCardTypeVerification(this.Number).Result; }
        }

        public bool IsValid
        {
            get { return new CreditCardNumberValidation(this.Number).Result; }
        }
    }
}

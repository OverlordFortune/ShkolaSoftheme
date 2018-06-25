using System;
using System.Collections.Generic;

namespace _18._1
{
    class MobileAccount
    {
        protected readonly string number;
        protected static Dictionary<string, MobileAccount> accounts = new Dictionary<string, MobileAccount>();

        public MobileAccount(string Number)
        {
            this.number = Number;
            MobileAccount.accounts.Add(Number, this);
        }

        public string PhoneNumber
        {
            get
            {
                return number;
            }
        }

        public void SendMail(string Number)
        {
            Console.WriteLine("Send mail from{0} to {1}", this.PhoneNumber, Number);
            MobileAccount account;
            if (MobileAccount.accounts.TryGetValue(Number, out account))
            {
                account.GetMail();
            }
        }

        public void SendMail(MobileAccount account)
        {
            SendMail(account.PhoneNumber);
        }

        public void Call(string Number)
        {
            Console.WriteLine("Call from{0} to {1}", this.PhoneNumber, Number);
            MobileAccount account;
            if (MobileAccount.accounts.TryGetValue(Number, out account))
            {
                account.GetCall();
            }
        }

        public void Call(MobileAccount account)
        {
            Call(account.PhoneNumber);
        }

        public void GetMail()
        {
            Console.WriteLine("Get mail {0}", this.PhoneNumber);
        }

        public void GetCall()
        {
            Console.WriteLine("Get call {0}", this.PhoneNumber);
        }
    }
}

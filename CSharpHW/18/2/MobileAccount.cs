using System;
using System.Collections.Generic;

namespace _18._2
{
    class MobileAccount
    {
        protected readonly string number;
        protected static Dictionary<string, MobileAccount> accounts = new Dictionary<string, MobileAccount>();
        protected AccountBook accountBook = new AccountBook();

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
            Console.WriteLine("Send mail from {0} to {1}", this.PhoneNumber, Number);
            MobileAccount account;
            if (MobileAccount.accounts.TryGetValue(Number, out account))
            {
                account.GetMail(this.PhoneNumber);
            }
        }

        public void SendMail(MobileAccount account)
        {
            SendMail(account.PhoneNumber);
        }

        public void Call(string Number)
        {
            Console.WriteLine("Call from {0} to {1}", this.PhoneNumber, Number);
            MobileAccount account;
            if (MobileAccount.accounts.TryGetValue(Number, out account))
            {
                account.GetCall(this.PhoneNumber);
            }
        }

        public void Call(MobileAccount account)
        {
            Call(account.PhoneNumber);
        }

        public void GetMail(string FromNumber)
        {
            Console.WriteLine("Get mail {0} from {1}", this.PhoneNumber, FromNumber);
            Account account;
            if (accountBook.TryGetValue(FromNumber, out account))
            {
                Console.WriteLine("Get Mail from {0}", account.Name);
            }
        }

        public void GetCall(string FromNumber)
        {
            Console.WriteLine("Get call {0} from {1}", this.PhoneNumber, FromNumber);
            Account account;
            if(accountBook.TryGetValue(FromNumber,out account))
            {
                Console.WriteLine("Get Call from {0}", account.Name);
            }
        }

        public void GetMail()
        {
            Console.WriteLine("Get mail {0} from not identified number", this.PhoneNumber);
        }

        public void GetCall()
        {
            Console.WriteLine("Get call {0} from not identified number", this.PhoneNumber);
        }

        public void AddAccount(string Number, Account account)
        {
            accountBook.Add(Number, account);
        }
    }
}

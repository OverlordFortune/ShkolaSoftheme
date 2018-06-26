using System;
using System.Collections.Generic;

namespace _18._2._1
{
    delegate void CallNumber(string FromNumber);
    delegate void MailNumber(string FromNumber);
    class MobileAccount
    {
        protected readonly string number;
        protected AccountBook accountBook = new AccountBook();
        protected static Dictionary<string, MobileAccount> accounts = new Dictionary<string, MobileAccount>();

        protected static Dictionary<MobileAccount, CallNumber> accountDelegateCall = new Dictionary<MobileAccount, CallNumber>();
        protected static Dictionary<MobileAccount, MailNumber> accountDelegateMail = new Dictionary<MobileAccount, MailNumber>();

        public MobileAccount(string Number)
        {
            this.number = Number;
            MobileAccount.accounts.Add(Number, this);
            MobileAccount.accountDelegateCall.Add(this, this.GetCall);
            MobileAccount.accountDelegateMail.Add(this, this.GetMail);
        }

        public string PhoneNumber
        {
            get
            {
                return number;
            }
        }

        public override int GetHashCode()
        {
            return this.PhoneNumber.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.PhoneNumber == ((MobileAccount)obj).PhoneNumber;
        }

        public void SendMail(string Number)
        {
            Console.WriteLine("Send mail from{0} to {1}", this.PhoneNumber, Number);
            accountDelegateMail[accounts[Number]].Invoke(this.PhoneNumber);
        }

        public void SendMail(MobileAccount account)
        {
            SendMail(account.PhoneNumber);
        }

        public void Call(string Number)
        {
            Console.WriteLine("Call from{0} to {1}", this.PhoneNumber, Number);
            accountDelegateCall[accounts[Number]].Invoke(this.PhoneNumber);
        }

        public void Call(MobileAccount account)
        {
            Call(account.PhoneNumber);
        }

        private void GetMail(string FromNumber)
        {
            Console.WriteLine("Get mail {0} from {1}", this.PhoneNumber, FromNumber);
            Account account;
            if (accountBook.TryGetValue(FromNumber, out account))
            {
                Console.WriteLine("Get Mail from {0}", account.Name);
            }
        }

        private void GetCall(string FromNumber)
        {
            Console.WriteLine("Get call {0} from {1}", this.PhoneNumber, FromNumber);
            Account account;
            if (accountBook.TryGetValue(FromNumber, out account))
            {
                Console.WriteLine("Get Call from {0}", account.Name);
            }
        }

        public void AddAccount(string Number, Account account)
        {
            accountBook.Add(Number, account);
        }
    }
}

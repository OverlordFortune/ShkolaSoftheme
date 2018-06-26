using System;
using System.Collections.Generic;

namespace _18._2._2
{
    delegate void CallNumberFromTo(string FromNumber, string ToNumber);
    delegate void MailNumberFromTo(string FromNumber, string ToNumber);
    delegate void MethodToCalledNumber(string FromNumber);

    delegate void MailNumber(string FromNumber);
    class MobileAccount
    {
        protected readonly string number;
        protected AccountBook accountBook = new AccountBook();
        public event CallNumberFromTo callevent;
        public event MailNumberFromTo mailevent;

        public MobileAccount(string Number)
        {
            this.number = Number;
            //callevent += GetCall;
            MobileOperator.AddNewMobileAcount(this, GetCall, GetMail);
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
            return Equals(((MobileAccount)obj).PhoneNumber);
        }

        public bool Equals(string obj)
        {
            return this.PhoneNumber == obj;
        }

        public void SendMail(string ToNumber)
        {
            Console.WriteLine("Send mail from{0} to {1}", this.PhoneNumber, ToNumber);
            if (callevent != null)
            {
                mailevent(this.PhoneNumber, ToNumber);
            }
        }

        public void SendMail(MobileAccount account)
        {
            SendMail(account.PhoneNumber);
        }

        public void Call(string ToNumber)
        {
            Console.WriteLine("Call from{0} to {1}", this.PhoneNumber, ToNumber);
            if(callevent != null)
            {
                callevent(this.PhoneNumber, ToNumber);
            }
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

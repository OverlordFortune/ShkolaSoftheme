using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;

namespace _21._1
{
    public delegate void CallNumberFromTo(string FromNumber, string ToNumber);
    public delegate void MailNumberFromTo(string FromNumber, string ToNumber);
    public delegate void MethodToCalledNumber(string FromNumber);

    [DataContract]
    [Serializable]
    public class MobileAccount : IValidatableObject
    {
        [DataMember]
        public string Number { get; set;}
        [DataMember]
        public string Email { get;  set; }
        [DataMember]
        public  string Name { get; set; }
        [DataMember]
        public  string LastName { get;  set; }
        [DataMember]
        public  DateTime BirthDate { get; set; }
        [DataMember]
        public AccountBook accountBook = new AccountBook();
        public event CallNumberFromTo CallEvent;
        public event MailNumberFromTo MailEvent;

        public MobileAccount (string Name, string LastName, string Email, DateTime BirthDate)
        {
            this.BirthDate = BirthDate;
            this.LastName = LastName;
            this.Email = Email;
            this.Name = Name;
            this.Number = MobileOperator.AddNewMobileAcount(this, GetCall, GetMail);
        }
        public MobileAccount()
        {

        }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            if (string.IsNullOrWhiteSpace(this.Name))
                errors.Add(new ValidationResult("Name is not entered"));
            if (string.IsNullOrWhiteSpace(this.LastName))
                errors.Add(new ValidationResult("Last name is not entered"));
            if (this.BirthDate > DateTime.Now&& this.BirthDate> DateTime.MinValue)
                errors.Add(new ValidationResult("Incorrect birth date"));
            if (!this.Email.Contains('@'))
                errors.Add(new ValidationResult("Email is not entered"));

            return errors;
        }

        public bool Validate()
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(this);
            if (!Validator.TryValidateObject(this, context, results, true))
            {
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return false;
            }
            return true;
        }

        public bool Equals(string obj)
        {
            return this.Number == obj;
        }

        public void SendMail(string ToNumber)
        {
            Console.WriteLine("Send mail from{0} to {1}", this.Number, ToNumber);
            if (CallEvent != null)
            {
                MailEvent(this.Number, ToNumber);
            }
        }

        public void SendMail(MobileAccount account)
        {
            SendMail(account.Number);
        }

        public void Call(string ToNumber)
        {
            Console.WriteLine("Call from{0} to {1}", this.Number, ToNumber);
            if(CallEvent != null)
            {
                CallEvent(this.Number, ToNumber);
            }
        }

        public void Call(MobileAccount account)
        {
            Call(account.Number);
        }

        private void GetMail(string FromNumber)
        {
            Console.WriteLine("Get mail {0} from {1}", this.Number, FromNumber);
            var FromName = from account in accountBook
                           where account.PhoneNumber == FromNumber
                           select account.Name;
            if (FromName != null && FromName.ToArray().Length!=0)
            Console.WriteLine("Get mail {0} from {1}", this.Number, FromName.ToArray()[0]);
        
        }

        private void GetCall(string FromNumber)
        {
            Console.WriteLine("Get call {0} from {1}", this.Number, FromNumber);
            var FromName = from account in accountBook
                           where account.PhoneNumber == FromNumber
                           select account.Name;
            if (FromName != null && FromName.ToArray().Length != 0)
                Console.WriteLine("Get call {0} from {1}", this.Number, FromName.ToArray()[0]);
        }

        public void AddAccount(Account account)
        {
            Account ac = accountBook.GetAccountByNumber(account.PhoneNumber);
            if(ac==null)
            accountBook.Add(account);
        }
    }
}

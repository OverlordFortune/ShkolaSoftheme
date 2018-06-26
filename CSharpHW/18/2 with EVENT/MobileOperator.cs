using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18._2._2
{
    class MobileOperator
    {
        private static Dictionary<MobileAccount, MethodToCalledNumber> callDelegate = new Dictionary<MobileAccount, MethodToCalledNumber>();
        private static Dictionary<MobileAccount, MethodToCalledNumber> mailDelegate = new Dictionary<MobileAccount, MethodToCalledNumber>();
        private static Dictionary<string, MobileAccount> accounts = new Dictionary<string, MobileAccount>();

        public static void AddNewMobileAcount(MobileAccount mobileAccount, MethodToCalledNumber CallNumberMethod, 
            MethodToCalledNumber MailNumberMethod)
        {
            callDelegate.Add(mobileAccount, CallNumberMethod);
            mailDelegate.Add(mobileAccount, MailNumberMethod);

            mobileAccount.callevent += MobileAccount_callevent;
            mobileAccount.mailevent += MobileAccount_mailevent;

            accounts.Add(mobileAccount.PhoneNumber, mobileAccount);
        }

        private static void MobileAccount_mailevent(string FromNumber, string ToNumber)
        {
            mailDelegate[accounts[ToNumber]].Invoke(FromNumber);
        }

        private static void MobileAccount_callevent(string FromNumber, string ToNumber)
        {
            callDelegate[accounts[ToNumber]].Invoke(FromNumber);
        }
    }
}

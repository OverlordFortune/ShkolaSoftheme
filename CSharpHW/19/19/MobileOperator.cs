using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19._1
{
    static class MobileOperator
    {
        private static Dictionary<MobileAccount, MethodToCalledNumber> callDelegate = new Dictionary<MobileAccount, MethodToCalledNumber>();
        private static Dictionary<MobileAccount, MethodToCalledNumber> mailDelegate = new Dictionary<MobileAccount, MethodToCalledNumber>();
        private static Dictionary<string, MobileAccount> accounts = new Dictionary<string, MobileAccount>();
        private static List<Routing> routings = new List<Routing>();
        

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
            try
            {
                mailDelegate[accounts[ToNumber]].Invoke(FromNumber);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("The number {0} does not exist", ToNumber);
            }
            catch (Exception e)
            {

            }           
            routings.Add(new Routing(FromNumber,ToNumber, RoutingType.Mail));
        }

        private static void MobileAccount_callevent(string FromNumber, string ToNumber)
        {
            try
            {
                callDelegate[accounts[ToNumber]].Invoke(FromNumber);
            }
            catch(KeyNotFoundException)
            {
                Console.WriteLine("The number {0} does not exist", ToNumber);
            }
            catch(Exception e )
            {
                
            }            
            routings.Add(new Routing(FromNumber, ToNumber, RoutingType.Call));
        }

        public static List<Routing> GetRoutings()
        {
            return routings.ToList();
        }       
    }
}

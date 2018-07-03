using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21._1
{
    static class MobileOperator
    {
        private static Dictionary<MobileAccount, MethodToCalledNumber> callDelegate = new Dictionary<MobileAccount, MethodToCalledNumber>();
        private static Dictionary<MobileAccount, MethodToCalledNumber> mailDelegate = new Dictionary<MobileAccount, MethodToCalledNumber>();

        private static List<MobileAccount> accounts = new List<MobileAccount>();
        private static List<Routing> routings = new List<Routing>();
        

        public static string AddNewMobileAcount(MobileAccount mobileAccount, MethodToCalledNumber CallNumberMethod, 
            MethodToCalledNumber MailNumberMethod)
        {
            if (mobileAccount.Validate())
            {
                callDelegate.Add(mobileAccount, CallNumberMethod);
                mailDelegate.Add(mobileAccount, MailNumberMethod);

                mobileAccount.CallEvent += MobileAccount_callevent;
                mobileAccount.MailEvent += MobileAccount_mailevent;

                string number = GenerateNewNumber();
                accounts.Add(mobileAccount);

                
                return number;
            }
             return "";
        }

        private static string GenerateNewNumber()
        {
            string code = "+380";
            string number;
            Random rand = new Random();
            while(true)
            {
                number = code + rand.Next(999999999);
                if (accounts.Find(x=>x.Number==number) == null)
                    break;
            }
            return number;
        }

        private static void MobileAccount_mailevent(string FromNumber, string ToNumber)
        {
            try
            {
                mailDelegate[accounts.Find(x=> x.Number == ToNumber)].Invoke(FromNumber);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("The number {0} does not exist", ToNumber);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("The number {0} does not exist", ToNumber);
            }
            catch (Exception)
            {

            }           
            routings.Add(new Routing(FromNumber,ToNumber, RoutingType.Mail));
        }

        private static void MobileAccount_callevent(string FromNumber, string ToNumber)
        {
            try
            {
                callDelegate[accounts.Find(x => x.Number == ToNumber)].Invoke(FromNumber);
            }
            catch(ArgumentNullException)
            {
                Console.WriteLine("The number {0} does not exist", ToNumber);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("The number {0} does not exist", ToNumber);
            }
            
            catch(Exception)
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

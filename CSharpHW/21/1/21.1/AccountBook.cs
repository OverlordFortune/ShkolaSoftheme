using System;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace _21._1
{
    [Serializable]
    public class AccountBook : List<Account>
    {
        
        public Account GetAccountByNumber(string Number)
        {
            foreach(var num in this)
            {
                if (num.PhoneNumber == Number) return num;
            }
            return null;
        }
    }
    
}

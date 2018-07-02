using System.Collections;
using System.Collections.Generic;


namespace _19._1
{
    class AccountBook : List<Account>
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

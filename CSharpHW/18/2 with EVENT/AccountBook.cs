using System.Collections.Generic;


namespace _18._2._2
{
    class AccountBook
    {
        Dictionary<string, Account> pairs = new Dictionary<string, Account>();
        public bool TryGetValue(string Number, out Account account)
        {
            return pairs.TryGetValue(Number, out account);
        }
        public void Add(string Number, Account account)
        {
            pairs.Add(Number, account);
        }

    }
}

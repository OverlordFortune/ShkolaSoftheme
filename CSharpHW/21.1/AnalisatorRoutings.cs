using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21._1
{
    static class AnalisatorRoutings
    {
        public static void BestToNumber(int count = 5, double weightCall = 1, double weightMail = 0.5)
        {
            var routings = MobileOperator.GetRoutings();

            var bestRoutings = routings.GroupBy(rout => rout.ToNumber)
                .Select(ToNumberGroup => new {
                    ToNumber = ToNumberGroup.Key,
                    CountMail = ToNumberGroup.Count(x => x.Type == RoutingType.Mail),
                    CountCall = ToNumberGroup.Count(x => x.Type == RoutingType.Call)
                })
                .OrderByDescending(number => number.CountCall * weightCall + number.CountMail * weightMail).Take(count);

            foreach (var item in bestRoutings)
                Console.WriteLine("Best ToNumber is {0}. Mail - {1}. Call - {2}.",
                    item.ToNumber, item.CountMail, item.CountCall);
        }

        public static void BestFromNumber(int count = 5, double weightCall = 1, double weightMail = 0.5)
        {
            var routings = MobileOperator.GetRoutings();

            var bestRoutings = routings.GroupBy(rout => rout.FromNumber)
                .Select(FromNumberGroup => new {
                    FromNumber = FromNumberGroup.Key,
                    CountMail = FromNumberGroup.Count(x => x.Type == RoutingType.Mail),
                    CountCall = FromNumberGroup.Count(x => x.Type == RoutingType.Call)
                })
                .OrderByDescending(number => number.CountCall * weightCall + number.CountMail * weightMail).Take(count);

            foreach (var item in bestRoutings)
                Console.WriteLine("Best FromNumber is {0}. Mail - {1}. Call - {2}. ", item.FromNumber, item.CountMail, item.CountCall);
        }
    }
}

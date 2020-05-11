using System;

namespace lesson4.Services
{
    public class MonthList : IList
    {
        public string[] GetList()
        {
            var enums = Enum.GetValues(typeof(MonthOfYear));

            string[] result = new string[enums.Length];

            int i = 0;

            foreach (var item in enums)
            {
                result[i] = item.ToString();
                i++;
            }

            return result;
        }
    }
}

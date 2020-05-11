using System;
using System.Linq;

namespace lesson4.Services
{
    public class DaysList : IList
    {
        public string[] GetList()
        {
            var enums = Enum.GetValues(typeof(CustomDayOfWeek));

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

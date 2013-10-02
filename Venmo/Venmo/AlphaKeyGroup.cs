using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.Phone.Globalization;

namespace Venmo
{
    class AlphaKeyGroup<T>: List<T>
    {
        public delegate string GetKeyDelegate(T item);

        //First-letter keys
        public string Key { get; private set; }

        public AlphaKeyGroup(String key)
        {
            Key = key;
        }

        private static List<AlphaKeyGroup<T>> CreateGroups(SortedLocaleGrouping slg)
        {
            List<AlphaKeyGroup<T>> list = new List<AlphaKeyGroup<T>>();

            foreach (string key in slg.GroupDisplayNames)
            {
                list.Add(new AlphaKeyGroup<T>(key));
            }
            return list;
        }

        public static List<AlphaKeyGroup<T>> CreateGroups(IEnumerable<T> items, CultureInfo ci, GetKeyDelegate getKey, bool sort)
        {
            SortedLocaleGrouping slg = new SortedLocaleGrouping(ci);
            List<AlphaKeyGroup<T>> list = CreateGroups(slg);

            foreach (T item in items)
            {
                int index = 0;
                if (slg.SupportsPhonetics)
                {
                    //CHECKKKKK IF IN THE DATABASE YAOOOO
                    //index = slg.GetGroupIndex(getKey(Yomiof(item)));
                }
                else
                {
                    index = slg.GetGroupIndex(getKey(item));
                }
                if (index >= 0 && index < list.Count)
                {
                    list[index].Add(item);
                }
            }

            if (sort)
            {
                foreach (AlphaKeyGroup<T> group in list)
                {
                    group.Sort((c0, c1) => { return ci.CompareInfo.Compare(getKey(c0), getKey(c1)); });
                }
            }
            return list;
        }
    }
}

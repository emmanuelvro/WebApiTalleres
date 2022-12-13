using System.Collections.Generic;

namespace System.Linq
{
    public static class IListExtend
    {
        public static void AddRange<T>(this IList<T> list, IList<T> collection)
        {
            if (collection == null || !collection.Any() || list == null)
                return;

            if (list.IsReadOnly)
                return;

            var listTemp = list as List<T>;
            listTemp.AddRange(collection);
        }

        public static void ForEach<T>(this IList<T> list, Action<T> action)
        {
            if (list == null || !list.Any())
                return;

            if (list.IsReadOnly)
                return;

            var listTemp = list as List<T>;
            listTemp.ForEach(action);
        }

       
    }
}
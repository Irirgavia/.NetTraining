namespace ATSLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HistoryManipulator
    {
        public static IEnumerable<History> SortHistoryByProperty<T>(IEnumerable<History> histories, Func<History, T> propertySelector)
        {
            return histories.OrderBy(propertySelector);
        }

        public static IEnumerable<History> SortHistoryByDate(List<History> histories)
        {
            return SortHistoryByProperty(
                histories,
                x => x.DateTime);
        }

        public static IEnumerable<History> SortHistoryByDuration(List<History> histories)
        {
            return SortHistoryByProperty(
                histories,
                x => x.CallTimer.Duration);
        }

        public static IEnumerable<History> SortHistoryByNumber(List<History> histories)
        {
            return SortHistoryByProperty(
                histories,
                x => x.CallTimer.Call.IncomingNumber);
        }
    }
}
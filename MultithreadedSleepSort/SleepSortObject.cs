using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadedSleepSort
{
    /* This object is used to pass in the unique numbers being sorted
     * and as a means of updating the final sorted List via object reference.
     */
    class SleepSortObject
    {
        public List<int> SortedItemsReference { get; set; }
        public int TimeToSort { get; set; }

        public SleepSortObject(List<int> sortedReference, int itemFromList)
        {
            SortedItemsReference = sortedReference;
            TimeToSort = itemFromList;
        }
    }

}

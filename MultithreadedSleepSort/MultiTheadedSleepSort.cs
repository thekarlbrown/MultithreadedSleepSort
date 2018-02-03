using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultithreadedSleepSort
{
    class MultiTheadedSleepSort
    {
        static void Main(string[] args)
        {
            // Initialize variables to be used throughout the Console Application
            var unsortedItems = new List<int>();
            var sortedItems = new List<int>();
            var randomIntGenerator = new Random();
            var numberOfThreads = 25;

            // Set the number of ThreadPool's available
            ThreadPool.SetMaxThreads(numberOfThreads, numberOfThreads);

            // Randomly generate ints between 1-100 to be sorted and create corresponding ThreadPools for each one
            for (var itemsToCreate = 0; itemsToCreate < numberOfThreads; itemsToCreate++)
            {
                var waitTime = randomIntGenerator.Next(1, 100);
                unsortedItems.Add(waitTime);
                ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProcess), new SleepSortObject(sortedItems, waitTime));
            }

            // Display the progress of the sort every 5 seconds
            while (sortedItems.Count < numberOfThreads)
            {
                Thread.Sleep(5000);
                for (int pos = 0; pos < sortedItems.Count; pos++)
                {
                    Console.Write($"{sortedItems.ElementAt(pos)}, ");
                }
                Console.WriteLine("\n-----------------");
            }

            // Inform the users of the final sorted list
            Console.WriteLine("\n *** Final Sorted List ***");
            for (int pos = 0; pos < sortedItems.Count; pos++)
            {
                Console.Write($"{sortedItems.ElementAt(pos)}, ");
            }
        }

        /* This process simply takes in the state info passed into the thread and
         * waits (8 * the number being sorted) seconds, then adds the number back to
         * the List in the object reference. Thus, each ThreadPool created for the SleepSort
         * finishes sleeping in order based on how big it's number being sorted is.
         * "Experts" consider SleepSort to be a very inefficient sort, although one
         * can optimize the sort by reducing the time multiplier that the sort waits
         * at the risk of reducing the accuracy of the sort.
         * 
         * As stated in the ReadMe, this is a joke Sorting algorithm but serves as a
         * basic illustration of ThreadPool's.
         */
        static void ThreadProcess (Object stateInfo)
        {
            var sleepSortObject = (SleepSortObject)stateInfo;
            Thread.Sleep(sleepSortObject.TimeToSort * 8000);
            sleepSortObject.SortedItemsReference.Add(sleepSortObject.TimeToSort);
        }
    }
}

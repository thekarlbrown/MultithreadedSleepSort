# MultithreadedSleepSort
Multi-threaded implementation of the parody sort Sleep Sort using Thread Pools and C#.

Keep in mind this is a joke and is only intended to serve as a basic implementation of ThreadPool's in C#.

Given the fact that Thread.Sleep is guaranteed to return no earlier than the time specified but potentially later and the fact that the Thread.Sleep is influenced by the .NET Scheduler which is influenced by the OS scheduler, this may occasionally be inaccurate.

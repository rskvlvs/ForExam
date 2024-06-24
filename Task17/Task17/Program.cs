object lockObject = new Object();
void MyInfinityMethod(object state)
{
    lock (lockObject)
    {
        Console.WriteLine("Тред = " + Thread.CurrentThread.ManagedThreadId);        while (true)
        {
            string key = Console.ReadLine();
            Console.WriteLine("ENTER нажат");
        }
    }   
}
while (true)
    ThreadPool.QueueUserWorkItem(MyInfinityMethod);


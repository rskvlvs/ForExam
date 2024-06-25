using System.Diagnostics;
using System.Linq;
using System.Numerics;
Random rand = new Random();
int n = rand.Next(10_000_000, 15_000_000);

Console.WriteLine("Введите x");
int x = Convert.ToInt32(Console.ReadLine());

long[] times = new long[10];
object lockObject = new object();
//Для пула
Semaphore semaphore = new Semaphore(1, 10); 
void func(int n, int x, out int count_x, ref int index)
{
    Stopwatch sw = Stopwatch.StartNew();
    Random random = new Random();
    int[] ints = new int[n];
    for (int i = 0; i < n; i++)
    {
        ints[i] = random.Next(0, 1001);
    }
    Array.Sort(ints);
    count_x = ints.Count(value => value == x);
    sw.Stop();
    var id = Thread.CurrentThread.ManagedThreadId;
    Console.WriteLine($"Время выполнения потока {id} = " + sw.Elapsed.TotalMilliseconds);
    //Для Пула
    semaphore.WaitOne();
    if (index < 10)
        times[index] = Convert.ToInt64(sw.Elapsed.TotalMilliseconds);
    //Через ПУЛ(прибавляю индекс)
    index++;
    semaphore.Release();
    //lock (lockObject)
    //{
    //    if(index < 10)
    //    times[index] = Convert.ToInt64(sw.Elapsed.TotalMilliseconds);
    //}
}



//Решение через пул
int count_pool = 0;
while(count_pool < 10)
{
    //Передаю ссылку, чтобы менять значение
    ThreadPool.QueueUserWorkItem(_ => func(n, x, out int count_of_x, ref count_pool));
}


//Решение через треды
//Thread[] thread = new Thread[10];
//for (int i = 0; i < 10; i++)
//{
//    thread[i] = new Thread(() => func(n, x, out int count_of_x, i));
//    thread[i].Start();
//Через треды
//foreach (var tr in thread)
//{
//    tr.Join();
//}

Console.WriteLine("Минимальное время = " + times.Min());
Console.WriteLine("Максимальное время = " + times.Max());
Console.WriteLine("Среднее время = " + times.Average());





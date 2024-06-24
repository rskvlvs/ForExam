using System.Diagnostics;
using System.Linq;
Random rand = new Random();
int n = rand.Next(10_000_000, 15_000_000);

Console.WriteLine("Введите x");
int x = Convert.ToInt32(Console.ReadLine());

long[] times = new long[10];
object lockObject = new object();
void func(int n, int x, out int count_x, int index)
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
    lock (lockObject)
    {
        if(index < 10)
        times[index] = Convert.ToInt64(sw.Elapsed.TotalMilliseconds);
    }
}


Thread[] thread = new Thread[10];
for (int i = 0; i < 10; i++)
{
    thread[i] = new Thread(()=>func(n, x, out int count_of_x, i));
    thread[i].Start();
    
}
foreach(var tr in thread)
{
    tr.Join();
}
Console.WriteLine("Минимальное время = " + times.Min());
Console.WriteLine("Максимальное время = " + times.Max());
Console.WriteLine("Среднее время = " + times.Average());





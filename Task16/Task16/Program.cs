
using System.Diagnostics;
using System.Linq;

long[] times = new long[10]; 
Random r = new Random();
int n = r.Next(10_000_000, 15_000_000);
Console.WriteLine("Введите X");
int X = Convert.ToInt32(Console.ReadLine());
object lockObj = new object();
void func(int x, int index)
{
    int[] mas = new int[n];
    for(int i = 0; i < n; i++)
    {
        mas[i] = r.Next(0, 1001); 
    }
    Array.Sort(mas);
    Stopwatch sw = Stopwatch.StartNew();
    Monitor.Enter(lockObj);
    sw.Stop();
    Console.WriteLine($"Время подключения потока {Thread.CurrentThread.ManagedThreadId} = " +  sw.ElapsedMilliseconds);
    if (index < 10)
        times[index] = Convert.ToInt64(sw.Elapsed.TotalMilliseconds);  
    int count_of_x = mas.Count(val => val == x); 
    Monitor.Exit(lockObj);
}

Thread[] threads = new Thread[10];
for(int i = 0; i < 10; i++)
{
    threads[i] = new Thread(() => func(X, i));
    threads[i].Start();
}

foreach (var val in threads)
    val.Join();


Console.WriteLine("Минимальное время: " + times.Min()); 
Console.WriteLine("Максимальное время: " + times.Max()); 
Console.WriteLine("Среднее время: " + times.Average()); 
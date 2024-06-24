Console.WriteLine("Введите размер массива"); 
int n = Convert.ToInt32(Console.ReadLine());
int[] mas = new int[n];
Random random = new Random();

for (int i =0 ; i < n; i++)
{
    mas[i] = random.Next(0, n+1);
}
Console.WriteLine(func(mas, n)); 


double func(int[] mas, int n)
{
    int sum = 0;
    foreach(int i in mas)
        sum += i;
    return (double)sum / n;
}
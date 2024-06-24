
int n;
Console.WriteLine("Введите количество элементов"); 
n = Int32.Parse(Console.ReadLine());
first[] mas = new first[n];
Random random = new Random();
for (int i = 0; i < n; i++)
{
    mas[i] = new first(new string('a', random.Next(1, 5)), random.Next(1, 100));


}
for(int i =0; i < n; i++)
{
    Console.WriteLine(mas[i].val1);
    Console.WriteLine(mas[i].val2);
    Console.WriteLine("----------");
}

public class first
{
    public string val1;
    public int val2;
    public first(string val_1, int val_2)
    {
        val1 = val_1;
        val2 = val_2; 
    }
}
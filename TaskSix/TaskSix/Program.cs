Myclass first = new Myclass(1, 4);
Myclass second = new Myclass(2, 2);
Console.WriteLine(first + second); 



public class Myclass
{
    public int val1 { get; set; }
    public int val2 { get; set; }

    public Myclass(int val_1, int val_2)
    {
        val1 = val_1;
        val2 = val_2;
    }

    public static int operator +(Myclass first, Myclass second)
    {
        return first.val1 + second.val1 + first.val2 + second.val2;
    }
}
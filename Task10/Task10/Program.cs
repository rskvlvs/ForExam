ICheck check = new Check();
check.firstMethod(5);
int count = check.secondMethod(new int[] { 0, 0, 0, 4 });
Console.WriteLine("Количество нулей = " + count);
Console.WriteLine(check.thirdMethod(true)); 

public interface ICheck
{
    public void firstMethod(int a); 
    public int secondMethod(int[] mas);

    public bool thirdMethod(bool value); 
}

public class Check : ICheck
{
    public void firstMethod(int a)
    {
        Console.WriteLine("Вы ввели " + a); 
    }

    public int secondMethod(int[] mas)
    {
        return mas.Count(x => x == 0); 
    }

    public bool thirdMethod(bool value)
    {
        return !value; 
    }
}
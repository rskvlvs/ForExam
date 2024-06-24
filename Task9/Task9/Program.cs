void FirstMethod(int a, string b, bool c)
{
    Console.WriteLine("Int = " + a);
    Console.WriteLine("Strig = " + b);
    Console.WriteLine("Bool = " + c); 
}

int SecondMethod(int[] mas, double value)
{
    if (mas.Length != 0)
        return Convert.ToInt16(mas[0] + value);
    else
        return 0;
}
MyFirstDelegate myFirstDelegate = new MyFirstDelegate(FirstMethod);
MySecondDelegate mySecondDelegate = new MySecondDelegate(SecondMethod);
myFirstDelegate(5, "smth", false);
int a = mySecondDelegate.Invoke(new int[] { 3, 2, 3 }, 15); 
Console.WriteLine(a);

delegate void MyFirstDelegate(int a, string b, bool c);
delegate int MySecondDelegate(int[] ints, double Double); 
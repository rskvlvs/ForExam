MyClass<int> myClass = new MyClass<int>();
myClass.method();


public class MyClass<T>
{
    public void method()
    {
        Console.WriteLine(typeof(T)); 
    }
}
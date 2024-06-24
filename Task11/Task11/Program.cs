int myFirstMethod(int val)
{
    Console.WriteLine("Первый метод");
    return val * 3; 
}
int mySecondMethod(int value)
{
    Console.WriteLine("Второй метод");
    return value - 10;
}

EventClass eventClass = new EventClass();
eventClass.MyEvent += myFirstMethod; 
eventClass.MyEvent += mySecondMethod;

eventClass.RaisEvent(3);

eventClass.MyEvent -= myFirstMethod;

eventClass.RaisEvent(3);

public class EventClass
{
    private event MyFutureEvent myEvent; 
    public event MyFutureEvent MyEvent
    {
        add
        {
            myEvent += value;
            Console.WriteLine("Подписка на метод произошла");
        }
        remove
        {
            myEvent -= value;
            Console.WriteLine("Произошла отписка от метода");
        }
    }

    public void RaisEvent(int x)
    {
        if (myEvent != null)
            myEvent(x); 
    }
}

public delegate int MyFutureEvent(int a); 
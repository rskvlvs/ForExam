
son Son = new son();
Son.virtualFunc(); 
Son.abstractFunc();


public abstract class father
{
    public virtual void virtualFunc()
    {
        Console.WriteLine("VIRTUAL"); 
    }
    public abstract void abstractFunc(); 
}
public class son : father
{
    public override void virtualFunc()
    {
        Console.WriteLine("OVERRIDE VIRTUAL");
    }
    public override void abstractFunc()
    {
        Console.WriteLine("OVERRIDE ABSTRACT"); 
    }
}
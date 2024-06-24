

public class Generic<T> where T : MyClass
{
    public MyClass myClass; 
    public Generic(T myClass)
    {
        this.myClass = myClass;
    }
}
public class MyClass
{
    public int value {  get; set; }
    public string val {  get; set; }
    public MyClass(int val1, string val2)
    {
        value = val1;
        val = val2;
    }
}
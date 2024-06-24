
using System.Reflection;

task myClass = new task(); 
Type type = typeof(task);
MethodInfo methodInfo = type.GetMethod("privateMethod", BindingFlags.NonPublic | BindingFlags.Instance);
object[] message = { "Hello" };
methodInfo.Invoke(myClass, message);

public class task
{
    private void privateMethod(string message)
    { 
        Console.WriteLine(message);
    }
}



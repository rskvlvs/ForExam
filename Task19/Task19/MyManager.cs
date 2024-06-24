namespace Task19
{
    public class MyManager: IMyDIinterface
    {
        public string method(string value)
        {
            return $"I hate {value}";
        }
    }
}

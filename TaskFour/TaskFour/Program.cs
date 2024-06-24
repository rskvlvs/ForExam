int n = Convert.ToInt16(Console.ReadLine()); 
son[] mas1 = new son[n];
son[] mas2 = new son[n];
Random random = new Random();
for(int i =0; i<n; i++)
{
    mas1[i] = new son("first", Convert.ToBoolean(random.Next(0, 2))); 
    mas2[i] = new son("second", Convert.ToBoolean(random.Next(0, 2))); 
}
if (mas1.Count(x => x.val_2 == false) > mas2.Count(x => x.val_2 == false))
    Console.WriteLine("First");
else if (mas1.Count(x => x.val_2 == false) < mas2.Count(x => x.val_2 == false))
    Console.WriteLine("Second");
else if(mas1.Count(x => x.val_2 == false) == mas2.Count(x => x.val_2 == false))
    Console.WriteLine("Equals");
else if(mas1.Count(x => x.val_2 == false)==0 && mas2.Count(x => x.val_2 == false) == 0)
    Console.WriteLine("No falses");

public class father
{
    public string val_1 {  get; set; }
    public bool val_2 { get; set; }
    public father(string val1, bool val2)
    {
        val_1 = val1;
        val_2 = val2;
    }
}
public class son : father
{
    public son(string val1, bool val2) : base(val1, val2) { }
}
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



using(DataContext context = new DataContext())
{
    Work work1 = new Work();
    work1.CompanyName = "Samsung";

    Work work2 = new Work();
    work2.CompanyName = "Xiaomi";

    context.works.AddRange(work1, work2);

    Worker worker1 = new Worker() { Name = "Sergey", work = work1 };
    Worker worker2 = new Worker() { Name = "Stas", work = work1 };

    Worker worker3 = new Worker() { Name = "Geor", work = work2 };
    Worker worker4 = new Worker() { Name = "Misha", work = work2 };


    context.workers.AddRange(worker1, worker2, worker3, worker4);
    context.SaveChanges();

    var newWork = context.works.FirstOrDefault(x => x.CompanyName == "Samsung");
    Console.WriteLine($"Company = {newWork.CompanyName}"); 
    foreach(var worker in newWork.Workers)
    {
        Console.WriteLine($"Работник {worker.Name} найден!");
    }

    var newWork2 = context.works.FirstOrDefault(x => x.CompanyName == "Xiaomi");
    Console.WriteLine($"Company = {newWork2.CompanyName}");
    foreach (var workerNew in newWork2.Workers)
    {
        Console.WriteLine($"Работник {workerNew.Name} найден!");
    }

    context.works.RemoveRange(work1, work2);
    context.SaveChanges(); 
}


public class Worker
{
    [Key]
    public int WorkerId {  get; set; }

    public string Name { get; set; }
    
    public virtual Work work { get; set; }
}

public class Work
{
    [Key]
    public int CompanyId { get; set; }

    public string CompanyName { get; set; }

    public virtual List<Worker> Workers { get; set; }
}

public class DataContext : DbContext
{
    public DbSet<Worker> workers { get; set; }

    public DbSet<Work> works { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;DataBase=CompanyDataBase;Trusted_Connection=true;TrustServerCertificate=true");
    }
}


using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

using (DataContext context = new DataContext())
{
    for (int i = 0; i < 100_000; i++)
        context.Add(new User { Name = $"User {i}" });
    context.SaveChanges();
    var timer1 = new Stopwatch(); 
    var timer2 = new Stopwatch();

    timer1.Start();
    for(int i = 0; i < 1000; i++)
    {
        var search = context.Users.FirstOrDefault(x => x.Id == i);
        if (search != null)
            Console.WriteLine($"Найде пользователь с Id {search.Id}");
    }
    timer1.Stop();
    Console.WriteLine($"Время, потраченное на поиск по ключу = {timer1.Elapsed.TotalSeconds} seconds");

    timer2.Start(); 
    for(int i = 0; i < 1000; i++)
    {
        var search = context.Users.FirstOrDefault(x => x.Name == $"User {i}");
        if (search != null)
            Console.WriteLine($"Найден пользователь {search.Name}");
    }
    timer2.Stop();
    Console.WriteLine($"Время на поиск по значению ={timer2.Elapsed.TotalSeconds} seconds"); 
}


public class User
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }
}

public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TaskDataBase;Trusted_Connection=True;TrustServerCertificate=true");
    }
}
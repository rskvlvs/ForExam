using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


using (DataContext context = new DataContext())
{
    User user = new User() {Name = "Vladimir" }; 
    context.Users.Add(user);
    context.SaveChanges();
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
        // Определение строки подключения
        // Server - адрес SQL сервера, localhost указывает на то, что сервер установлен на той же машине, на которой запускается программа
        // Database - наименование БД, к которой подключаемся
        // Trusted_Connection=True - для подключения к БД используется учетная запись Windows
        // TrustServerCertificate=true - доверять сертификату, установленному на сервере
        optionsBuilder
            //.UseLazyLoadingProxies() - для использования LazyLoading, все связанные свойства загружаются автоматически
            .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=myDataBase;Trusted_Connection=True;TrustServerCertificate=true");
    }
}
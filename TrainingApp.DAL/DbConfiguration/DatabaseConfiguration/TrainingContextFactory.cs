using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using TrainingApp.DAL.DbConfiguration.DatabaseConfiguration;

public class TrainingContextFactory : IDesignTimeDbContextFactory<TrainingContext>
{
    public TrainingContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TrainingContext>();
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TrainingDb;Trusted_Connection=True;");

        return new TrainingContext(optionsBuilder.Options);
    }
}
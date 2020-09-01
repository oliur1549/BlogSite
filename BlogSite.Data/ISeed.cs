using System.Threading.Tasks;

namespace BlogSite.Data
{
    public interface ISeed
    {
        Task MigrateAsync();
        Task SeedAsync();
    }
}


namespace RealtService.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(RealtServiceDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}

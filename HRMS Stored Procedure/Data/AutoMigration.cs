using Microsoft.EntityFrameworkCore;

namespace HRMS_Stored_Procedure.Data
{
    public static class AutoMigration
    {
        public static void Automigrate(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<HRMSDbContext>())
                {
                    try
                    {
                        appContext.Database.Migrate();
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
        }
    }
}

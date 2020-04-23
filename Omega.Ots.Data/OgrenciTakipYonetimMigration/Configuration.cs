using Omega.Ots.Data.Context;
using System.Data.Entity.Migrations;

namespace Omega.Ots.Data.OgrenciTakipYonetimMigration
{
    public class Configuration : DbMigrationsConfiguration<OgrenciTakipYonetimContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
    }
}

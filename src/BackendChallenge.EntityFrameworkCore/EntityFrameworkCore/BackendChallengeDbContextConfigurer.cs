using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace BackendChallenge.EntityFrameworkCore
{
    public static class BackendChallengeDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<BackendChallengeDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<BackendChallengeDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using BackendChallenge.Authorization.Roles;
using BackendChallenge.Authorization.Users;
using BackendChallenge.Entities;
using BackendChallenge.MultiTenancy;

namespace BackendChallenge.EntityFrameworkCore;

public class BackendChallengeDbContext : AbpZeroDbContext<Tenant, Role, User, BackendChallengeDbContext>
{
  /* Define a DbSet for each entity of the application */
  public DbSet<Movie> movies { get; set; }

  public BackendChallengeDbContext(DbContextOptions<BackendChallengeDbContext> options)
    : base(options)
  {
  }
}

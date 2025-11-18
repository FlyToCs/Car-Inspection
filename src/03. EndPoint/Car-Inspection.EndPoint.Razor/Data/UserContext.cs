using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Car_Inspection.EndPoint.Razor.Models;

namespace Car_Inspection.EndPoint.Razor.Data
{
  public class UserContext : DbContext
  {
    public UserContext(DbContextOptions<UserContext> options)
        : base(options)
    {
    }

    public DbSet<User> User { get; set; } = default!;
  }
}

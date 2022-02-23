using Microsoft.EntityFrameworkCore;
using EntitySample.Data.Entities;

namespace EntitySample.Data;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {

    }

    public virtual DbSet<Student>? Students{get;set;}
}

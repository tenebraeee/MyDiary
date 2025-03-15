using Core.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Db.Contexts
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {

        }

        public DbSet<Record> Records { get; set; }
        public DbSet<Setting> Settings { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source=diary.db"); //todo: вынести эту инфу
        }
    }
}

using ExprementProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ExprementProject.DataBase
{
    public class ExDbContext : DbContext
    {

        public ExDbContext(DbContextOptions<ExDbContext> options) : base(options) { }


        public DbSet<UserInfo> userInfos { get; set; }
        public DbSet<Post> posts { get; set; }
        public DbSet<FileTabel> FileTabel { get; set; }




    }
}

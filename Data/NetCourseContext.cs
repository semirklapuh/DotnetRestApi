using Microsoft.EntityFrameworkCore;
using netCoreCourse.Models;

namespace netCoreCourse.Data
{
    public class NetCoreCourseContext : DbContext
    {
        public NetCoreCourseContext(DbContextOptions<NetCoreCourseContext> opt) : base(opt)
        {
            
        }

        public DbSet<Command> Commands { get; set; }
    }
}
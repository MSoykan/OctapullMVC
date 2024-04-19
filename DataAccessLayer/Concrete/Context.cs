using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Document = EntityLayer.Concrete.Document;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext
    {
        public Context() { }

        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder )
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-27F5QUI\\SQLEXPRESS;" + // server to connect to
                "initial Catalog=OctapullMVCIdentityTest;" + // database to connect to
                "integrated Security=true;Trusted_Connection=True;TrustServerCertificate=True"); // . true indicates that Windows authentication (integrated security) is used.
        }
        //public OctapullMVCAuthDbContext(DbContextOptions<OctapullMVCAuthDbContext> options)
        //: base(options) {
        //    options.use
        //}

        //protected override void OnModelCreating(ModelBuilder builder) {
        //    base.OnModelCreating(builder);
        //    // Customize the ASP.NET Identity model and override the defaults if needed.
        //    // For example, you can rename the ASP.NET Identity table names and more.
        //    // Add your customizations after calling base.OnModelCreating(builder);
        //}



        public DbSet<Meeting> Meeting { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Document> Documents { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            var converter = new ValueConverter<int[], string>(
                v => string.Join(",", v),
                v => v.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(val => int.Parse(val)).ToArray());

            modelBuilder.Entity<Meeting>()
                .Property(e => e.ParticipantIds)
                .HasConversion(converter);

            modelBuilder.Entity<Meeting>()
                .HasMany(e => e.Documents)
                .WithOne(e => e.Meeting)
                .HasForeignKey(e => e.MeetingId)
                .IsRequired();
        }


    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_lesson_6_2_b
{
    class MyContext : DbContext 
    {
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Company> Companies { get; set; }
        public MyContext()
            : base("EF_lesson_6_2_b")
        { }
        static MyContext()
        {
            Database.SetInitializer(new MyContextInitializator());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .HasMany(p => p.Phones)
                .WithRequired(p => p.Company)
                .HasForeignKey(s => s.Manufacturer);
                //.WillCascadeOnDelete(false) 
            // при true в определении таблицы Phone:  CONSTRAINT [FK_dbo.Phones_dbo.Companies_Manufacturer] FOREIGN KEY ([Manufacturer]) REFERENCES [dbo].[Companies] ([Id]) ON DELETE CASCADE
            // при false в определении таблицы Phone: CONSTRAINT [FK_dbo.Phones_dbo.Companies_Manufacturer] FOREIGN KEY ([Manufacturer]) REFERENCES [dbo].[Companies] ([Id])
            // по умолчанию без .WillCascadeOnDelete() - тоже, что и при true
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            // при использовании modelBuilder.Conventions.Remove тоже, что и при .WillCascadeOnDelete(false):
            // CONSTRAINT [FK_dbo.Phones_dbo.Companies_Manufacturer] FOREIGN KEY ([Manufacturer]) REFERENCES [dbo].[Companies] ([Id])
        }
    }
}

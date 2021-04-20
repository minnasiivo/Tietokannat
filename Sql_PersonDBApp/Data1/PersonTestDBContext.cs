using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Sql_PersonDBApp.Models;

#nullable disable

namespace Sql_PersonDBApp.Data1
{
    public partial class PersonTestDBContext : DbContext
    {
        public PersonTestDBContext()
        {
        }

        public PersonTestDBContext(DbContextOptions<PersonTestDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ContactInfo> ContactInfos { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<Shoe> Shoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=PersonTestDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Finnish_Swedish_CI_AS");

            modelBuilder.Entity<ContactInfo>(entity =>
            {
                entity.ToTable("ContactInfo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ContactType)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Info)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.ContactInfos)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonId");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.EyeColor)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Sex)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.ToTable("phone");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Phonenumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Phones)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Person");
            });

            modelBuilder.Entity<Shoe>(entity =>
            {
                entity.ToTable("shoe");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Brand)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Model)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Shoes)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__shoe__PersonId__49C3F6B7");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

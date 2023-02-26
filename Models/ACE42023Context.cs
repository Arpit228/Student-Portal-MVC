using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Student_Register.Models
{
    public partial class ACE42023Context : DbContext
    {
        public ACE42023Context()
        {
        }

        public ACE42023Context(DbContextOptions<ACE42023Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminArpit> AdminArpits { get; set; }
        public virtual DbSet<CourseArpit> CourseArpits { get; set; }
        public virtual DbSet<StudentArpit> StudentArpits { get; set; }
        
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DEVSQL.corp.local;Database=ACE 4- 2023;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AdminArpit>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("PK__Admin_Ar__CBA1B2574D9736C4");

                entity.ToTable("Admin_Arpit");

                entity.Property(e => e.Userid)
                    .ValueGeneratedNever()
                    .HasColumnName("userid");

                entity.Property(e => e.Pwd)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("pwd");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });


            modelBuilder.Entity<CourseArpit>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("PK__Course_A__D837D05FD53A9C35");

                entity.ToTable("Course_Arpit");

                entity.Property(e => e.Cid)
                    .ValueGeneratedNever()
                    .HasColumnName("cid");

                entity.Property(e => e.Cname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cname");
            });

            

            modelBuilder.Entity<StudentArpit>(entity =>
            {
                entity.HasKey(e => e.Rollno)
                    .HasName("PK__Student___FABA8B5B9F5DA77E");

                entity.ToTable("Student_Arpit");

                entity.Property(e => e.Rollno)
                    .ValueGeneratedNever()
                    .HasColumnName("rollno");

                entity.Property(e => e.Cid).HasColumnName("cid");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.HasOne(d => d.CidNavigation)
                    .WithMany(p => p.StudentArpits)
                    .HasForeignKey(d => d.Cid)
                    .HasConstraintName("FK__Student_Arp__cid__23F3538A");
            });

            

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

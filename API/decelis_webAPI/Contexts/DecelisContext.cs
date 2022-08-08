using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using decelis_webAPI.Domains;

namespace decelis_webAPI.Contexts
{
    public partial class DecelisContext : DbContext
    {
        public DecelisContext()
        {
        }

        public DecelisContext(DbContextOptions<DecelisContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<SkillLevel> SkillLevels { get; set; }
        public virtual DbSet<StatusType> StatusTypes { get; set; }
        public virtual DbSet<TimeClass> TimeClasses { get; set; }
        public virtual DbSet<UserInfo> UserInfos { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=decelis.database.windows.net; initial catalog=decelis; user Id=decelis-adm; pwd=De123lis;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.IdClass)
                    .HasName("PK__class__17317A5AE2F53FF0");

                entity.ToTable("class");

                entity.Property(e => e.IdClass).HasColumnName("idClass");

                entity.Property(e => e.IdLevel).HasColumnName("idLevel");

                entity.Property(e => e.IdTime).HasColumnName("idTime");

                entity.Property(e => e.NameClass)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nameClass");

                entity.HasOne(d => d.IdLevelNavigation)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.IdLevel)
                    .HasConstraintName("FK__class__idLevel__656C112C");

                entity.HasOne(d => d.IdTimeNavigation)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.IdTime)
                    .HasConstraintName("FK__class__idTime__66603565");
            });

            modelBuilder.Entity<SkillLevel>(entity =>
            {
                entity.HasKey(e => e.IdLevel)
                    .HasName("PK__skillLev__995F5B342746B098");

                entity.ToTable("skillLevel");

                entity.Property(e => e.IdLevel).HasColumnName("idLevel");

                entity.Property(e => e.SkillLevel1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("skillLevel");
            });

            modelBuilder.Entity<StatusType>(entity =>
            {
                entity.HasKey(e => e.IdStatus)
                    .HasName("PK__statusTy__01936F7484E2AF3D");

                entity.ToTable("statusType");

                entity.Property(e => e.IdStatus).HasColumnName("idStatus");

                entity.Property(e => e.ActiveStatus).HasColumnName("activeStatus");
            });

            modelBuilder.Entity<TimeClass>(entity =>
            {
                entity.HasKey(e => e.IdTime)
                    .HasName("PK__timeClas__BDD0C78841A94959");

                entity.ToTable("timeClass");

                entity.Property(e => e.IdTime).HasColumnName("idTime");

                entity.Property(e => e.PeriodTime)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("periodTime");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__userInfo__3717C982D43D5768");

                entity.ToTable("userInfo");

                entity.Property(e => e.IdUser)
                    .HasColumnName("idUser")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdClass).HasColumnName("idClass");

                entity.Property(e => e.IdStatus).HasColumnName("idStatus");

                entity.Property(e => e.IdUserType).HasColumnName("idUserType");

                entity.Property(e => e.NameUser)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nameUser");

                entity.Property(e => e.PasswordUser)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("passwordUser");

                entity.Property(e => e.UserImage)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("userImage");

                entity.HasOne(d => d.IdClassNavigation)
                    .WithMany(p => p.UserInfos)
                    .HasForeignKey(d => d.IdClass)
                    .HasConstraintName("FK__userInfo__idClas__6C190EBB");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.UserInfos)
                    .HasForeignKey(d => d.IdStatus)
                    .HasConstraintName("FK__userInfo__idStat__6B24EA82");

                entity.HasOne(d => d.IdUserTypeNavigation)
                    .WithMany(p => p.UserInfos)
                    .HasForeignKey(d => d.IdUserType)
                    .HasConstraintName("FK__userInfo__idUser__6A30C649");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.HasKey(e => e.IdUserType)
                    .HasName("PK__userType__96375927E942E7CD");

                entity.ToTable("userType");

                entity.HasIndex(e => e.TitleUserType, "UQ__userType__190546075E760B83")
                    .IsUnique();

                entity.Property(e => e.IdUserType).HasColumnName("idUserType");

                entity.Property(e => e.TitleUserType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("titleUserType");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

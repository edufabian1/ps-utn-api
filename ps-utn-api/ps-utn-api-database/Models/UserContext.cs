using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ps_utn_api_database.Models
{
    public partial class UserContext : DbContext
    {
        public UserContext()
        {
        }

        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Contracts> Contracts { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Partners> Partners { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-K6F3JF2\\SQLEXPRESS;Initial Catalog=utn_ps;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cities>(entity =>
            {
                entity.HasKey(e => e.IdCity);

                entity.Property(e => e.IdCity)
                    .HasColumnName("id_city")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdCountry).HasColumnName("id_country");

                entity.HasOne(d => d.IdCountryNavigation)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.IdCountry)
                    .HasConstraintName("FK_Cities_Countries1");
            });

            modelBuilder.Entity<Contracts>(entity =>
            {
                entity.HasKey(e => e.IdContract);

                entity.Property(e => e.IdContract)
                    .HasColumnName("id_contract")
                    .ValueGeneratedNever();

                entity.Property(e => e.CashMonth)
                    .HasColumnName("cash_month")
                    .HasColumnType("money");

                entity.Property(e => e.CashTotal)
                    .HasColumnName("cash_total")
                    .HasColumnType("money");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cuit)
                    .HasColumnName("cuit")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FinalDate)
                    .HasColumnName("final_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdEmployee).HasColumnName("id_employee");

                entity.Property(e => e.InitDate)
                    .HasColumnName("init_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RefPartner)
                    .HasColumnName("ref_partner")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.IdEmployee)
                    .HasConstraintName("FK_Contracts_Employees1");
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.HasKey(e => e.IdCountry);

                entity.Property(e => e.IdCountry)
                    .HasColumnName("id_country")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.IdEmployee);

                entity.Property(e => e.IdEmployee)
                    .HasColumnName("id_employee")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address1)
                    .HasColumnName("address1")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasColumnName("address2")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BirthDate)
                    .HasColumnName("birth_date")
                    .HasColumnType("date");

                entity.Property(e => e.Dni)
                    .HasColumnName("dni")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdCity).HasColumnName("id_city");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .HasColumnName("surname")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCityNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdCity)
                    .HasConstraintName("FK_Employees_Cities1");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_Employees_Users1");
            });

            modelBuilder.Entity<Partners>(entity =>
            {
                entity.HasKey(e => e.IdPartner);

                entity.Property(e => e.IdPartner)
                    .HasColumnName("id_partner")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IdContract).HasColumnName("id_contract");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nickname)
                    .HasColumnName("nickname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UrlFacebook)
                    .HasColumnName("url_facebook")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UrlInstagram)
                    .HasColumnName("url_instagram")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UrlPage)
                    .HasColumnName("url_page")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UrlTwitter)
                    .HasColumnName("url_twitter")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdContractNavigation)
                    .WithMany(p => p.Partners)
                    .HasForeignKey(d => d.IdContract)
                    .HasConstraintName("FK_Partners_Contracts1");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.IntRole);

                entity.Property(e => e.IntRole)
                    .HasColumnName("int_role")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.Property(e => e.IdUser)
                    .HasColumnName("id_user")
                    .ValueGeneratedNever();

                entity.Property(e => e.BirthDate)
                    .HasColumnName("birth_date")
                    .HasColumnType("date");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdRole).HasColumnName("id_role");

                entity.Property(e => e.Mail)
                    .HasColumnName("mail")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nickname)
                    .HasColumnName("nickname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RestartPasword)
                    .HasColumnName("restart_pasword")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SecondMail)
                    .HasColumnName("second_mail")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUserNavigation)
                    .WithOne(p => p.Users)
                    .HasForeignKey<Users>(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Roles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

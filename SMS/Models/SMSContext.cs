using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SMS.Models
{
    public partial class SMSContext : DbContext
    {
        internal readonly object tbl_CustomerRegistration;

        public SMSContext()
        {
        }

        public SMSContext(DbContextOptions<SMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblCustomerRegistration> TblCustomerRegistration { get; set; }
        public virtual DbSet<TblLogin> TblLogin { get; set; }
        public virtual DbSet<TblPurchaseOrder> TblPurchaseOrder { get; set; }
        public virtual DbSet<TblVendor> TblVendor { get; set; }

     /*   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source= DESKTOP-OF7QM0G\\SQLEXPRESS; Initial Catalog=SMS; Integrated security=True");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblCustomerRegistration>(entity =>
            {
                entity.HasKey(e => e.CrId)
                    .HasName("PK__tbl_Cust__AD761DA4748E3812");

                entity.ToTable("tbl_CustomerRegistration");

                entity.Property(e => e.Address)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Lid).HasColumnName("LId");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.L)
                    .WithMany(p => p.TblCustomerRegistration)
                    .HasForeignKey(d => d.Lid)
                    .HasConstraintName("FK__tbl_Custome__LId__440B1D61");
            });

            modelBuilder.Entity<TblLogin>(entity =>
            {
                entity.HasKey(e => e.Lid)
                    .HasName("PK__tbl_Logi__C655574180C64A28");

                entity.ToTable("tbl_Login");

                entity.Property(e => e.Lid).HasColumnName("LId");

                entity.Property(e => e.Password)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblPurchaseOrder>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("PK__tbl_Purc__CB394B19B2917539");

                entity.ToTable("tbl_PurchaseOrder");

                entity.Property(e => e.Oid).HasColumnName("OId");

                entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

                entity.Property(e => e.ItemName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.PurchaseOrderNumber)
                    .HasColumnName("purchaseOrderNumber")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Quantity).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Status)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Vid).HasColumnName("VId");

                entity.HasOne(d => d.Cr)
                    .WithMany(p => p.TblPurchaseOrder)
                    .HasForeignKey(d => d.CrId)
                    .HasConstraintName("FK__tbl_Purcha__CrId__46E78A0C");

                entity.HasOne(d => d.V)
                    .WithMany(p => p.TblPurchaseOrder)
                    .HasForeignKey(d => d.Vid)
                    .HasConstraintName("FK__tbl_Purchas__VId__47DBAE45");
            });

            modelBuilder.Entity<TblVendor>(entity =>
            {
                entity.HasKey(e => e.Vid)
                    .HasName("PK__tbl_Vend__C5DF235B634B0633");

                entity.ToTable("tbl_Vendor");

                entity.Property(e => e.Vid).HasColumnName("VId");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VendorName)
                    .IsRequired()
                    .HasColumnName("vendorName")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using HPlusSports.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HPlusSports.DAL
{
    public partial class HPlusSportsContext : DbContext
    {
        public HPlusSportsContext(DbContextOptions<HPlusSportsContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("CustomerID");

                entity.HasIndex(e => e.LastName);

                entity.Property(e => e.Address);

                entity.Property(e => e.City);

                entity.Property(e => e.Email);

                entity.Property(e => e.FirstName);

                entity.Property(e => e.LastName);

                entity.Property(e => e.Phone);

                entity.Property(e => e.State);

                entity.Property(e => e.Zipcode);

                entity.Property(e => e.Deleted);

            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasIndex(e => e.OrderDate)
                    .HasName("IX_Order");

                entity.Property(e => e.Id).HasColumnName("OrderID");

                entity.Property(e => e.CreatedDate);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.OrderDate);

                entity.Property(e => e.SalespersonId).HasColumnName("SalespersonID");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("'none'");

                entity.Property(e => e.TotalDue).HasColumnType("money");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Order_Customer");

                entity.HasOne(d => d.Salesperson)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.SalespersonId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Order_Salesperson");

                entity.Property(e => e.Deleted);
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.Property(e => e.OrderItemId).HasColumnName("OrderItemID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductId)
                    .IsRequired()
                    .HasColumnName("ProductID")
                    .HasMaxLength(10);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_OrderItem_Order");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .HasPrincipalKey(p => p.ProductCode)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_OrderItem_Product1");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ProductId");

                entity.Property(e => e.ProductCode)
                    .HasColumnName("ProductCode")
                    .HasMaxLength(10);

                entity.HasDiscriminator<bool>("Perishable")
                .HasValue<Product>(false)
                .HasValue<PerishableProduct>(true);

                entity.Property<bool>("Perishable").HasDefaultValueSql("0");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ProductName).HasColumnType("varchar(50)");

                entity.Property(e => e.Status).HasColumnType("varchar(50)");

                entity.Property(e => e.Variety).HasColumnType("varchar(50)");

                entity.Property(e => e.Deleted);

            });

            modelBuilder.Entity<SalesGroup>(entity =>
            {
                entity.HasIndex(e => new { e.State, e.Type })
                    .HasName("IX_StateType")
                    .IsUnique();

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.HasMany(e => e.Salespeople)
                .WithOne(e => e.SalesGroup)
                .HasPrincipalKey(e => new { e.State, e.Type });

                entity.Property(e => e.Deleted);
            });

            modelBuilder.Entity<Salesperson>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("SalespersonID")
                    .ValueGeneratedOnAdd();

                entity.Property<string>("Address").HasColumnType("varchar(50)");

                entity.Property<string>("City").HasColumnType("varchar(50)");

                entity.Property(e => e.Email).HasColumnType("varchar(50)");

                entity.Property(e => e.FirstName).HasColumnType("varchar(50)");

                entity.Property(e => e.LastName).HasColumnType("varchar(50)");

                entity.Property(e => e.Phone).HasColumnType("varchar(50)");

                entity.Property(e => e.SalesGroupState)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasDefaultValue("CA");

                entity.Property(e => e.SalesGroupType).HasDefaultValue(1);

                entity.Property<string>("State").HasColumnType("varchar(50)");

                entity.Property<string>("Zipcode").HasColumnType("varchar(50)");

                entity.Property(e => e.Deleted);

                entity.Ignore(s => s.FullName);
            });
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<PerishableProduct> PerishableProduct { get; set; }
        public virtual DbSet<SalesGroup> SalesGroup { get; set; }
        public virtual DbSet<Salesperson> Salesperson { get; set; }
    }
}
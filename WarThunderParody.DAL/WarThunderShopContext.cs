using System.Data.Common;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;
using YandexDisk.Client;
using YandexDisk.Client.Clients;
using YandexDisk.Client.Http;


namespace WarThunderParody;

public partial class WarThunderShopContext : DbContext
{
    public WarThunderShopContext()
    {
    }

    public WarThunderShopContext(DbContextOptions<WarThunderShopContext> options)
        : base(options)
    {
    }

    public async Task BackupDatabase()
    {
        ProcessStartInfo info = new ProcessStartInfo();
        info.FileName = "C:\\Program Files\\PostgreSQL\\16\\bin\\pg_dump.exe";
        info.Arguments = "-U postgres -F c -b -v -f war_thunder_shop.exe";
        info.UseShellExecute = false;
        info.RedirectStandardOutput = true;

        Process process = new Process();
        process.StartInfo = info;
        process.Start();
        
        string output = process.StandardOutput.ReadToEnd();
        await process.WaitForExitAsync();
        
        string backupName = $"war_thunder_shop_{DateTime.Today.ToString("yyyy-MM-dd")}";
        await UploadSample("y0_AgAAAABqFvaLAAsE4AAAAAD1WX52J0ONqR-wSC-Fj8zLDPoK3O47geQ",backupName);
        
        if (File.Exists("war_thunder_shop.exe"))
        {
            File.Delete("war_thunder_shop.exe");
        }
    }
    
    
    async Task UploadSample(string token, string backupName)
    {
        string oauthToken = token;
    
        // Create a client instance
        IDiskApi diskApi = new DiskHttpApi(oauthToken);
    
        //Upload file from local
        await diskApi.Files.UploadFileAsync(path: $"BackupWarThunderParody/{backupName}",
            overwrite: true,
            localFile: @$"{backupName}",
            cancellationToken: CancellationToken.None);
    }
    
    public async Task<string> UploadFile(string filePath)
    {
        await UploadSample("y0_AgAAAABqFvaLAAsE4AAAAAD1WX52J0ONqR-wSC-Fj8zLDPoK3O47geQ", filePath);
        var url = await MakeFilePublic("y0_AgAAAABqFvaLAAsE4AAAAAD1WX52J0ONqR-wSC-Fj8zLDPoK3O47geQ",filePath);
        
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }

        return url;
    }
    
    public async Task<string> MakeFilePublic(string token, string fileName)
    {
        
        string url = $"https://cloud-api.yandex.net/v1/disk/resources/publish?path=BackupWarThunderParody/{fileName}";
        
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("OAuth", token);
            HttpResponseMessage response = await client.PutAsync(url, null);
            
            var responseContent = await response.Content.ReadAsStringAsync();
            
            var startIndex = responseContent.IndexOf(':') + 2;
            var endIndex = responseContent.IndexOf(',') - 1;
            var length = endIndex - startIndex;
            
            url = responseContent.Substring(startIndex, length);
            HttpResponseMessage r = await client.GetAsync(url);
            
            var rContent = await r.Content.ReadAsStringAsync();
            
            startIndex = rContent.IndexOf("public_url") + "public_url".Length + 3;
            endIndex = rContent.IndexOf("name") - 3;
            length = endIndex - startIndex;
            url = rContent.Substring(startIndex, length);
            
            response.EnsureSuccessStatusCode();
            r.EnsureSuccessStatusCode();
        }

        return url;
    }
    
    
    
   public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<History> Histories { get; set; }

    public virtual DbSet<Nation> Nations { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=war_thunder_shop;User Id=postgres;Password=postgres;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_account_pkey");

            entity.ToTable("account");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('user_account_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Balance)
                .HasColumnType("money")
                .HasColumnName("balance");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
            entity.Property(e => e.RegistrationDate).HasColumnName("registration_date");

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRole",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("user_role_role_id_fkey"),
                    l => l.HasOne<Account>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("user_role_user_id_fkey"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId").HasName("user_role_pkey");
                        j.ToTable("user_role");
                        j.IndexerProperty<int>("UserId").HasColumnName("user_id");
                        j.IndexerProperty<int>("RoleId").HasColumnName("role_id");
                    });
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("category_pkey");

            entity.ToTable("category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(256)
                .HasColumnName("name");
        });

        modelBuilder.Entity<History>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("history_pkey");

            entity.ToTable("history");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");

            entity.HasOne(d => d.Account).WithMany(p => p.Histories)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("history_account_id_fkey");

            entity.HasOne(d => d.Order).WithMany(p => p.Histories)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("history_order_id_fkey");
        });

        modelBuilder.Entity<Nation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("nation_pkey");

            entity.ToTable("nation");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(256)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("order_pkey");

            entity.ToTable("order");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Product).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("order_product_id_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("order_status_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("order_user_id_fkey");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("order_status_pkey");

            entity.ToTable("order_status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(256)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("product_pkey");

            entity.ToTable("product");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Description)
                .HasMaxLength(1024)
                .HasColumnName("description");
            entity.Property(e => e.Image)
                .HasMaxLength(256)
                .HasColumnName("image");
            entity.Property(e => e.Name)
                .HasMaxLength(256)
                .HasColumnName("name");
            entity.Property(e => e.NationId).HasColumnName("nation_id");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("product_category_fkey");

            entity.HasOne(d => d.Nation).WithMany(p => p.Products)
                .HasForeignKey(d => d.NationId)
                .HasConstraintName("product_nation_id_fkey");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("role_pkey");

            entity.ToTable("role");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(256)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

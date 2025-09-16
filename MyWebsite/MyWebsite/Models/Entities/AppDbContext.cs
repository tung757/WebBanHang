using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MyWebsite.Models.Entities;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Danhgium> Danhgia { get; set; }

    public virtual DbSet<Danhmuc> Danhmucs { get; set; }

    public virtual DbSet<Giamgium> Giamgia { get; set; }

    public virtual DbSet<Giohang> Giohangs { get; set; }

    public virtual DbSet<GiohangSanpham> GiohangSanphams { get; set; }

    public virtual DbSet<Hinhanhsp> Hinhanhsps { get; set; }

    public virtual DbSet<Khachhang> Khachhangs { get; set; }

    public virtual DbSet<Lichsumuahang> Lichsumuahangs { get; set; }

    public virtual DbSet<Phanloaisp> Phanloaisps { get; set; }

    public virtual DbSet<Sanpham> Sanphams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Admin-PC\\SQLEXPRESS;Database=DuLieuBanHangDataBase;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Danhgium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DANHGIA__3214EC2791C8D177");

            entity.ToTable("DANHGIA");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Content).HasMaxLength(200);
            entity.Property(e => e.MaKh).HasColumnName("MaKH");
            entity.Property(e => e.MaSp).HasColumnName("MaSP");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.Danhgia)
                .HasForeignKey(d => d.MaKh)
                .HasConstraintName("fk2");

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.Danhgia)
                .HasForeignKey(d => d.MaSp)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk1");
        });

        modelBuilder.Entity<Danhmuc>(entity =>
        {
            entity.HasKey(e => e.MaDm).HasName("PK__DANHMUC__2725866EAB548AB4");

            entity.ToTable("DANHMUC");

            entity.Property(e => e.MaDm).HasColumnName("MaDM");
            entity.Property(e => e.ImgDm)
                .HasMaxLength(20)
                .HasColumnName("Img_DM");
            entity.Property(e => e.TenDm)
                .HasMaxLength(45)
                .HasColumnName("TenDM");
        });

        modelBuilder.Entity<Giamgium>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("GIAMGIA");

            entity.Property(e => e.IdVoucher)
                .HasMaxLength(10)
                .HasColumnName("ID_Voucher");
            entity.Property(e => e.MaKh).HasColumnName("MaKH");

            entity.HasOne(d => d.MaKhNavigation).WithMany()
                .HasForeignKey(d => d.MaKh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk9");
        });

        modelBuilder.Entity<Giohang>(entity =>
        {
            entity.HasKey(e => e.IdGh).HasName("PK__GIOHANG__8B62CF0CF8D428E6");

            entity.ToTable("GIOHANG");

            entity.HasIndex(e => e.MaKh, "UQ__GIOHANG__2725CF1F2854083C").IsUnique();

            entity.Property(e => e.IdGh).HasColumnName("ID_GH");
            entity.Property(e => e.MaKh).HasColumnName("MaKH");

            entity.HasOne(d => d.MaKhNavigation).WithOne(p => p.Giohang)
                .HasForeignKey<Giohang>(d => d.MaKh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk5");
        });

        modelBuilder.Entity<GiohangSanpham>(entity =>
        {
            entity.HasKey(e => new { e.MaSp, e.IdGh }).HasName("pk");

            entity.ToTable("GIOHANG_SANPHAM");

            entity.Property(e => e.MaSp).HasColumnName("MaSP");
            entity.Property(e => e.IdGh).HasColumnName("ID_GH");

            entity.HasOne(d => d.IdGhNavigation).WithMany(p => p.GiohangSanphams)
                .HasForeignKey(d => d.IdGh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk7");

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.GiohangSanphams)
                .HasForeignKey(d => d.MaSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk6");
        });

        modelBuilder.Entity<Hinhanhsp>(entity =>
        {
            entity.HasKey(e => e.IdImg).HasName("PK__HINHANHS__247D29AA46F46CCB");

            entity.ToTable("HINHANHSP");

            entity.Property(e => e.IdImg).HasColumnName("ID_img");
            entity.Property(e => e.ImgAnh)
                .HasMaxLength(30)
                .HasColumnName("Img_anh");
            entity.Property(e => e.MaSp).HasColumnName("MaSP");

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.Hinhanhsps)
                .HasForeignKey(d => d.MaSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk3");
        });

        modelBuilder.Entity<Khachhang>(entity =>
        {
            entity.HasKey(e => e.MaKh).HasName("PK__KHACHHAN__2725CF1E9AC3BB4A");

            entity.ToTable("KHACHHANG");

            entity.Property(e => e.MaKh).HasColumnName("MaKH");
            entity.Property(e => e.DiaChi).HasMaxLength(45);
            entity.Property(e => e.Email).HasMaxLength(45);
            entity.Property(e => e.HoTen).HasMaxLength(45);
            entity.Property(e => e.ImgAvarta)
                .HasMaxLength(30)
                .HasColumnName("Img_avarta");
            entity.Property(e => e.Mk)
                .HasMaxLength(30)
                .HasColumnName("MK");
            entity.Property(e => e.Sdt)
                .HasMaxLength(10)
                .HasColumnName("SDT");
            entity.Property(e => e.Tk)
                .HasMaxLength(30)
                .HasColumnName("TK");
        });

        modelBuilder.Entity<Lichsumuahang>(entity =>
        {
            entity.HasKey(e => e.MaLs).HasName("PK__LICHSUMU__2725C7723C369EBC");

            entity.ToTable("LICHSUMUAHANG");

            entity.Property(e => e.MaLs).HasColumnName("MaLS");
            entity.Property(e => e.MaKh).HasColumnName("MaKH");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.Lichsumuahangs)
                .HasForeignKey(d => d.MaKh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk8");
        });

        modelBuilder.Entity<Phanloaisp>(entity =>
        {
            entity.HasKey(e => e.IdPl).HasName("PK__PHANLOAI__8B63902F43644F90");

            entity.ToTable("PHANLOAISP");

            entity.Property(e => e.IdPl).HasColumnName("ID_PL");
            entity.Property(e => e.MaSp).HasColumnName("MaSP");
            entity.Property(e => e.TenPl)
                .HasMaxLength(128)
                .HasColumnName("Ten_PL");

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.Phanloaisps)
                .HasForeignKey(d => d.MaSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk4");
        });

        modelBuilder.Entity<Sanpham>(entity =>
        {
            entity.HasKey(e => e.MaSp).HasName("PK__SANPHAM__2725081C734E129F");

            entity.ToTable("SANPHAM");

            entity.Property(e => e.MaSp).HasColumnName("MaSP");
            entity.Property(e => e.MaDm).HasColumnName("MaDM");
            entity.Property(e => e.TenSp)
                .HasMaxLength(10)
                .HasColumnName("TenSP");

            entity.HasOne(d => d.MaDmNavigation).WithMany(p => p.Sanphams)
                .HasForeignKey(d => d.MaDm)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

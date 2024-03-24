﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace fastnet_api.DBModels;

public partial class FastnetdbContext : DbContext
{
    public FastnetdbContext()
    {
    }

    public FastnetdbContext(DbContextOptions<FastnetdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attention> Attentions { get; set; }

    public virtual DbSet<Attentionstatus> Attentionstatuses { get; set; }

    public virtual DbSet<Attentiontype> Attentiontypes { get; set; }

    public virtual DbSet<Cash> Cashes { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<Device> Devices { get; set; }

    public virtual DbSet<Methodpayment> Methodpayments { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Statuscontract> Statuscontracts { get; set; }

    public virtual DbSet<Turn> Turns { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Usercash> Usercashes { get; set; }

    public virtual DbSet<Userstatus> Userstatuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-L9DERQU\\SQLEXPRESS;Database=fastnetdb;Trusted_Connection=True;TrustServerCertificate=true;Persist Security Info=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attention>(entity =>
        {
            entity.HasKey(e => e.Attentionid).HasName("PK__attentio__99FD3552D90331CE");

            entity.ToTable("attention");

            entity.Property(e => e.Attentionid).HasColumnName("attentionid");
            entity.Property(e => e.AttentionstatusStatusid).HasColumnName("attentionstatus_statusid");
            entity.Property(e => e.AttentiontypeAttentiontypeid).HasColumnName("attentiontype_attentiontypeid");
            entity.Property(e => e.ClientClientid).HasColumnName("client_clientid");
            entity.Property(e => e.TurnTurnid).HasColumnName("turn_turnid");

            entity.HasOne(d => d.AttentionstatusStatus).WithMany(p => p.Attentions)
                .HasForeignKey(d => d.AttentionstatusStatusid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__attention__atten__5441852A");

            entity.HasOne(d => d.AttentiontypeAttentiontype).WithMany(p => p.Attentions)
                .HasForeignKey(d => d.AttentiontypeAttentiontypeid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__attention__atten__534D60F1");

            entity.HasOne(d => d.ClientClient).WithMany(p => p.Attentions)
                .HasForeignKey(d => d.ClientClientid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__attention__clien__52593CB8");

            entity.HasOne(d => d.TurnTurn).WithMany(p => p.Attentions)
                .HasForeignKey(d => d.TurnTurnid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__attention__turn___5165187F");
        });

        modelBuilder.Entity<Attentionstatus>(entity =>
        {
            entity.HasKey(e => e.Statusid).HasName("PK__attentio__36247E300A2DA37A");

            entity.ToTable("attentionstatus");

            entity.Property(e => e.Statusid).HasColumnName("statusid");
            entity.Property(e => e.Description)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("description");
        });

        modelBuilder.Entity<Attentiontype>(entity =>
        {
            entity.HasKey(e => e.Attentiontypeid).HasName("PK__attentio__9D38AAA3BB80BEA8");

            entity.ToTable("attentiontype");

            entity.Property(e => e.Attentiontypeid).HasColumnName("attentiontypeid");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("description");
        });

        modelBuilder.Entity<Cash>(entity =>
        {
            entity.HasKey(e => e.Cashid).HasName("PK__cash__96014CBD9972A83E");

            entity.ToTable("cash");

            entity.Property(e => e.Cashid).HasColumnName("cashid");
            entity.Property(e => e.Active)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("active");
            entity.Property(e => e.Cashdescription)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cashdescription");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Clientid).HasName("PK__client__819DC7697FB805DE");

            entity.ToTable("client");

            entity.Property(e => e.Clientid).HasColumnName("clientid");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Identification)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("identification");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lastname");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("phonenumber");
            entity.Property(e => e.Referenceaddress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("referenceaddress");
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.Contracid).HasName("PK__contract__2ECBB3DBC7EF46FB");

            entity.ToTable("contract");

            entity.Property(e => e.Contracid).HasColumnName("contracid");
            entity.Property(e => e.ClientClientid).HasColumnName("client_clientid");
            entity.Property(e => e.Enddate)
                .HasColumnType("datetime")
                .HasColumnName("enddate");
            entity.Property(e => e.MethodpaymentMethodpaymentid).HasColumnName("methodpayment_methodpaymentid");
            entity.Property(e => e.ServiceServiceid).HasColumnName("service_serviceid");
            entity.Property(e => e.Startdate)
                .HasColumnType("datetime")
                .HasColumnName("startdate");
            entity.Property(e => e.StatuscontractStatusid).HasColumnName("statuscontract_statusid");

            entity.HasOne(d => d.ClientClient).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.ClientClientid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__contract__client__60A75C0F");

            entity.HasOne(d => d.MethodpaymentMethodpayment).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.MethodpaymentMethodpaymentid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__contract__method__619B8048");

            entity.HasOne(d => d.ServiceService).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.ServiceServiceid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__contract__servic__5EBF139D");

            entity.HasOne(d => d.StatuscontractStatus).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.StatuscontractStatusid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__contract__status__5FB337D6");
        });

        modelBuilder.Entity<Device>(entity =>
        {
            entity.HasKey(e => e.Deviceid).HasName("PK__device__84B9F7FF1B1849C0");

            entity.ToTable("device");

            entity.Property(e => e.Deviceid).HasColumnName("deviceid");
            entity.Property(e => e.Devicename)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("devicename");
            entity.Property(e => e.Serviceid).HasColumnName("serviceid");

            entity.HasOne(d => d.Service).WithMany(p => p.Devices)
                .HasForeignKey(d => d.Serviceid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__device__servicei__46E78A0C");
        });

        modelBuilder.Entity<Methodpayment>(entity =>
        {
            entity.HasKey(e => e.Methodpaymentid).HasName("PK__methodpa__633563A42858CAC2");

            entity.ToTable("methodpayment");

            entity.Property(e => e.Methodpaymentid).HasColumnName("methodpaymentid");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("description");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Paymentid).HasName("PK__payments__AF26EBEE1B27979A");

            entity.ToTable("payments");

            entity.Property(e => e.Paymentid).HasColumnName("paymentid");
            entity.Property(e => e.Clientid).HasColumnName("clientid");
            entity.Property(e => e.Paymentdate)
                .HasColumnType("datetime")
                .HasColumnName("paymentdate");

            entity.HasOne(d => d.Client).WithMany(p => p.Payments)
                .HasForeignKey(d => d.Clientid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__payments__client__4BAC3F29");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Rolid).HasName("PK__rol__5403326C53D1E437");

            entity.ToTable("rol");

            entity.Property(e => e.Rolid).HasColumnName("rolid");
            entity.Property(e => e.Rolname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("rolname");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Serviceid).HasName("PK__service__45516CA7B68F010B");

            entity.ToTable("service");

            entity.Property(e => e.Serviceid).HasColumnName("serviceid");
            entity.Property(e => e.Price)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("price");
            entity.Property(e => e.Servicedescription)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("servicedescription");
            entity.Property(e => e.Servicename)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("servicename");
        });

        modelBuilder.Entity<Statuscontract>(entity =>
        {
            entity.HasKey(e => e.Statusid).HasName("PK__statusco__36247E307EED56C2");

            entity.ToTable("statuscontract");

            entity.Property(e => e.Statusid).HasColumnName("statusid");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("description");
        });

        modelBuilder.Entity<Turn>(entity =>
        {
            entity.HasKey(e => e.Turnid).HasName("PK__turn__C2FE62224A33A403");

            entity.ToTable("turn");

            entity.Property(e => e.Turnid).HasColumnName("turnid");
            entity.Property(e => e.CashCashid).HasColumnName("cash_cashid");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.Description)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Usergestorid).HasColumnName("usergestorid");

            entity.HasOne(d => d.CashCash).WithMany(p => p.Turns)
                .HasForeignKey(d => d.CashCashid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__turn__cash_cashi__4E88ABD4");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("PK__users__CBA1B2571C1194EA");

            entity.ToTable("users");

            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Creationdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationdate");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.RolRolid).HasColumnName("rol_rolid");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
            entity.Property(e => e.UserstatusStatusid).HasColumnName("userstatus_statusid");

            entity.HasOne(d => d.RolRol).WithMany(p => p.Users)
                .HasForeignKey(d => d.RolRolid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__users__rol_rolid__571DF1D5");

            entity.HasOne(d => d.UserstatusStatus).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserstatusStatusid)
                .HasConstraintName("FK__users__userstatu__59063A47");
        });

        modelBuilder.Entity<Usercash>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("usercash");

            entity.Property(e => e.CashCashid).HasColumnName("cash_cashid");
            entity.Property(e => e.UserUserid).HasColumnName("user_userid");

            entity.HasOne(d => d.CashCash).WithMany()
                .HasForeignKey(d => d.CashCashid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__usercash__cash_c__5BE2A6F2");

            entity.HasOne(d => d.UserUser).WithMany()
                .HasForeignKey(d => d.UserUserid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__usercash__user_u__5AEE82B9");
        });

        modelBuilder.Entity<Userstatus>(entity =>
        {
            entity.HasKey(e => e.Statusid).HasName("PK__userstat__36247E30257CF209");

            entity.ToTable("userstatus");

            entity.Property(e => e.Statusid).HasColumnName("statusid");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("description");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
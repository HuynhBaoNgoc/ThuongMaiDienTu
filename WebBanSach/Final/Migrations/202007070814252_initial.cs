namespace Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DanhMucs",
                c => new
                    {
                        MaDanhMuc = c.Int(nullable: false, identity: true),
                        TenDanhMuc = c.String(),
                    })
                .PrimaryKey(t => t.MaDanhMuc);
            
            CreateTable(
                "dbo.Saches",
                c => new
                    {
                        MaSach = c.Int(nullable: false, identity: true),
                        TenSach = c.String(),
                        GiaBan = c.Int(nullable: false),
                        NgayXuatBan = c.String(),
                        LoaiBia = c.String(),
                        SoTrang = c.Int(nullable: false),
                        Hinh = c.String(),
                        MaDanhMuc = c.Int(),
                    })
                .PrimaryKey(t => t.MaSach)
                .ForeignKey("dbo.DanhMucs", t => t.MaDanhMuc)
                .Index(t => t.MaDanhMuc);
            
            CreateTable(
                "dbo.GioHangs",
                c => new
                    {
                        MaGioHang = c.Int(nullable: false, identity: true),
                        MaKH = c.Int(),
                        MaSach = c.Int(),
                        SoLuong = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaGioHang)
                .ForeignKey("dbo.KhachHangs", t => t.MaKH)
                .ForeignKey("dbo.Saches", t => t.MaSach)
                .Index(t => t.MaKH)
                .Index(t => t.MaSach);
            
            CreateTable(
                "dbo.KhachHangs",
                c => new
                    {
                        MaKH = c.Int(nullable: false, identity: true),
                        TenKH = c.String(),
                        DiaChi = c.String(),
                        SDT = c.String(),
                        UserName = c.String(nullable: false, maxLength: 25),
                        Password = c.String(nullable: false, maxLength: 30),
                        MaQuyen = c.Int(),
                    })
                .PrimaryKey(t => t.MaKH)
                .ForeignKey("dbo.Quyens", t => t.MaQuyen)
                .Index(t => t.MaQuyen);
            
            CreateTable(
                "dbo.Quyens",
                c => new
                    {
                        MaQuyen = c.Int(nullable: false, identity: true),
                        TenQuyen = c.String(),
                    })
                .PrimaryKey(t => t.MaQuyen);
            
            CreateTable(
                "dbo.LoginManages",
                c => new
                    {
                        LoginManageKey = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        TimeLogin = c.String(),
                        TimeLogout = c.String(),
                    })
                .PrimaryKey(t => t.LoginManageKey);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GioHangs", "MaSach", "dbo.Saches");
            DropForeignKey("dbo.KhachHangs", "MaQuyen", "dbo.Quyens");
            DropForeignKey("dbo.GioHangs", "MaKH", "dbo.KhachHangs");
            DropForeignKey("dbo.Saches", "MaDanhMuc", "dbo.DanhMucs");
            DropIndex("dbo.KhachHangs", new[] { "MaQuyen" });
            DropIndex("dbo.GioHangs", new[] { "MaSach" });
            DropIndex("dbo.GioHangs", new[] { "MaKH" });
            DropIndex("dbo.Saches", new[] { "MaDanhMuc" });
            DropTable("dbo.LoginManages");
            DropTable("dbo.Quyens");
            DropTable("dbo.KhachHangs");
            DropTable("dbo.GioHangs");
            DropTable("dbo.Saches");
            DropTable("dbo.DanhMucs");
        }
    }
}

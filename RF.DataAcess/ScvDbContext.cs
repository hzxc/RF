using Microsoft.EntityFrameworkCore;
using RF.Models;
using System;
using System.Collections.Generic;
using System.Text;
using RF.DataAcess.Configurations;

namespace RF.DataAcess
{
    public class ScvDbContext : DbContext
    {
        //由于依赖注入的关系，不加构造函数这里会出现警告，但不影响数据迁移文件的建立，更新数据库也没影响
        public ScvDbContext(DbContextOptions<ScvDbContext> options) : base(options)
        {
        }

        public ScvDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            //添加数据库连接字符串
            //builder.UseSqlServer(@"Server=.;User id=sa;Password=aO8pJIxjexX4X8tB;Database=SCV");
            builder.UseSqlServer(@"Server=10.10.10.6;User id=ttx;Password=ttx2011;Database=SCV");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration<OrderPartInfo>(new OrderPartInfoConfigurations());
        }
        //User相关表
        public DbSet<OrderPartInfo> OrderPartInfos { get; set; }
    }
}

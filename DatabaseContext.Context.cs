﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pr4
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Pr4Entities : DbContext
    {
        public Pr4Entities()
            : base("name=Pr4Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CATEGORY> CATEGORY { get; set; }
        public virtual DbSet<CUSTOMER> CUSTOMER { get; set; }
        public virtual DbSet<GENDER> GENDER { get; set; }
        public virtual DbSet<GOOD> GOOD { get; set; }
        public virtual DbSet<ORDER> ORDER { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<WORKER> WORKER { get; set; }
        public virtual DbSet<BASKET> BASKET { get; set; }
    }
}

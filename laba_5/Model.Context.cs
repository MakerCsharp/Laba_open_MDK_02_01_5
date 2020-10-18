﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace laba_5
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<User> User { get; set; }
    
        public virtual ObjectResult<vvod_max_min_Result> vvod_max_min(Nullable<decimal> price_max, string name, Nullable<decimal> price_min)
        {
            var price_maxParameter = price_max.HasValue ?
                new ObjectParameter("price_max", price_max) :
                new ObjectParameter("price_max", typeof(decimal));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var price_minParameter = price_min.HasValue ?
                new ObjectParameter("price_min", price_min) :
                new ObjectParameter("price_min", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<vvod_max_min_Result>("vvod_max_min", price_maxParameter, nameParameter, price_minParameter);
        }
    }
}

﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SomeeMVC_4.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class augblogsEntities : DbContext
    {
        public augblogsEntities()
            : base("name=augblogsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Option> Options { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<TermRelationship> TermRelationships { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<TermTaxonomy> TermTaxonomies { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
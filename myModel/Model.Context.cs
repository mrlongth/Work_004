﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace myModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class mjuBudgetEntities : DbContext
    {
        public mjuBudgetEntities()
            : base("name=mjuBudgetEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<Budget> Budgets { get; set; }
        public virtual DbSet<Budget_plan> Budget_plan { get; set; }
        public virtual DbSet<Config_item> Config_item { get; set; }
        public virtual DbSet<Director> Directors { get; set; }
        public virtual DbSet<Fund> Funds { get; set; }
        public virtual DbSet<General> Generals { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Item_detail> Item_detail { get; set; }
        public virtual DbSet<Item_group> Item_group { get; set; }
        public virtual DbSet<Item_group_detail> Item_group_detail { get; set; }
        public virtual DbSet<Level_position> Level_position { get; set; }
        public virtual DbSet<Lot> Lots { get; set; }
        public virtual DbSet<Major> Majors { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<New> News { get; set; }
        public virtual DbSet<Person_group> Person_group { get; set; }
        public virtual DbSet<Person_his> Person_his { get; set; }
        public virtual DbSet<Person_manage> Person_manage { get; set; }
        public virtual DbSet<Person_status> Person_status { get; set; }
        public virtual DbSet<Person_work> Person_work { get; set; }
        public virtual DbSet<Person_work_status> Person_work_status { get; set; }
        public virtual DbSet<Plan> Plans { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Produce> Produces { get; set; }
        public virtual DbSet<Title> Titles { get; set; }
        public virtual DbSet<Type_position> Type_position { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<User_group> User_group { get; set; }
        public virtual DbSet<User_group_menu> User_group_menu { get; set; }
        public virtual DbSet<Usermenu> Usermenus { get; set; }
        public virtual DbSet<Work> Works { get; set; }
        public virtual DbSet<view_Item_group> view_Item_group { get; set; }
        public virtual DbSet<view_Item_group_detail> view_Item_group_detail { get; set; }
        public virtual DbSet<view_Item> view_Item { get; set; }
    }
}

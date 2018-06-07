namespace ServerRPG.DAL
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using ServerRPG.Model;
    using ServerRPG.Model.Tokens;

    public class DBContext : DbContext
    {
        // Your context has been configured to use a 'DBContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ServerRPG.DAL.DBContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DBContext' 
        // connection string in the application configuration file.
        public DBContext()
            : base("name=DBContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Rumor> Rumors { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Adventure> Adventures { get; set; }
        public virtual DbSet<Enemy> Enemies { get; set; }
        public virtual DbSet<Trap> Traps { get; set; }
        public virtual DbSet<Token> Tokens { get; set; }
        public virtual DbSet<Attack> Attacks { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<Loot> Loots { get; set; }
        public virtual DbSet<NPC> NPC { get; set; }
        public virtual DbSet<Character> Character { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // configures one-to-many relationship
            modelBuilder.Entity<Character>()
                .HasRequired<User>(character => character.User)
                .WithMany(user => user.Characters)
                .HasForeignKey<int>(character => character.UserID);
        }


        public void deleteDatabase()
        {
            Database.Delete();
        }
    }




    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}
namespace CulturalCitiesService
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataModel : DbContext
    {
        public DataModel()
            : base("name=CultCitiesDataModel")
        {
        }

        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tblArtist> tblArtist { get; set; }
        public virtual DbSet<tblCity> tblCity { get; set; }
        public virtual DbSet<tblCountry> tblCountry { get; set; }
        public virtual DbSet<tblCulturalJobTasks> tblCulturalJobTasks { get; set; }
        public virtual DbSet<tblCustomer> tblCustomer { get; set; }
        public virtual DbSet<tblCustomerEvent> tblCustomerEvent { get; set; }
        public virtual DbSet<tblCustomerPreferences> tblCustomerPreferences { get; set; }
        public virtual DbSet<tblEvent> tblEvent { get; set; }
        public virtual DbSet<tblEventComment> tblEventComment { get; set; }
        public virtual DbSet<tblGenre> tblGenre { get; set; }
        public virtual DbSet<tblPreferenceValue> tblPreferenceValue { get; set; }
        public virtual DbSet<tblPublicity> tblPublicity { get; set; }
        public virtual DbSet<tblUser> tblUser { get; set; }
        public virtual DbSet<tblUserRole> tblUserRole { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblArtist>()
                .Property(e => e.stage_name)
                .IsUnicode(false);

            modelBuilder.Entity<tblArtist>()
                .Property(e => e.first_name)
                .IsUnicode(false);

            modelBuilder.Entity<tblArtist>()
                .Property(e => e.last_name)
                .IsUnicode(false);

            modelBuilder.Entity<tblArtist>()
                .Property(e => e.legal_representative)
                .IsUnicode(false);

            modelBuilder.Entity<tblArtist>()
                .Property(e => e.website)
                .IsUnicode(false);

            modelBuilder.Entity<tblArtist>()
                .Property(e => e.bussines_contact_number)
                .IsUnicode(false);

            modelBuilder.Entity<tblArtist>()
                .Property(e => e.official_mail_account)
                .IsUnicode(false);

            modelBuilder.Entity<tblArtist>()
                .HasMany(e => e.tblEvent)
                .WithMany(e => e.tblArtist)
                .Map(m => m.ToTable("tblArtistEvent").MapLeftKey("artist_id").MapRightKey("event_id"));

            modelBuilder.Entity<tblCity>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<tblCity>()
                .Property(e => e.geographical_location)
                .IsUnicode(false);

            modelBuilder.Entity<tblCity>()
                .HasMany(e => e.tblCustomer)
                .WithRequired(e => e.tblCity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblCity>()
                .HasMany(e => e.tblEvent)
                .WithRequired(e => e.tblCity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblCountry>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<tblCountry>()
                .HasMany(e => e.tblCity)
                .WithRequired(e => e.tblCountry)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblCulturalJobTasks>()
                .HasMany(e => e.tblEvent)
                .WithRequired(e => e.tblCulturalJobTasks)
                .HasForeignKey(e => e.culturaljob_task_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblCustomer>()
                .Property(e => e.first_name)
                .IsUnicode(false);

            modelBuilder.Entity<tblCustomer>()
                .Property(e => e.last_name)
                .IsUnicode(false);

            modelBuilder.Entity<tblCustomer>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<tblCustomer>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<tblCustomer>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<tblCustomer>()
                .HasMany(e => e.tblCustomerEvent)
                .WithRequired(e => e.tblCustomer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblCustomer>()
                .HasMany(e => e.tblCustomerPreferences)
                .WithRequired(e => e.tblCustomer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblCustomer>()
                .HasMany(e => e.tblEventComment)
                .WithRequired(e => e.tblCustomer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblCustomerPreferences>()
                .Property(e => e.preference_value)
                .IsUnicode(false);

            modelBuilder.Entity<tblEvent>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<tblEvent>()
                .Property(e => e.geographical_location)
                .IsUnicode(false);

            modelBuilder.Entity<tblEvent>()
                .Property(e => e.event_source_site_page)
                .IsUnicode(false);

            modelBuilder.Entity<tblEvent>()
                .Property(e => e.tags)
                .IsUnicode(false);

            modelBuilder.Entity<tblEvent>()
                .Property(e => e.EventImagePath)
                .IsUnicode(false);

            modelBuilder.Entity<tblEvent>()
                .HasMany(e => e.tblCustomerEvent)
                .WithRequired(e => e.tblEvent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblEvent>()
                .HasMany(e => e.tblEventComment)
                .WithRequired(e => e.tblEvent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblEvent>()
                .HasMany(e => e.tblPublicity)
                .WithRequired(e => e.tblEvent)
                .HasForeignKey(e => e.related_event)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblEvent>()
                .HasMany(e => e.tblGenre)
                .WithMany(e => e.tblEvent)
                .Map(m => m.ToTable("tblEventGenre").MapLeftKey("event_id").MapRightKey("genre_id"));

            modelBuilder.Entity<tblEventComment>()
                .Property(e => e.message_content)
                .IsUnicode(false);

            modelBuilder.Entity<tblEventComment>()
                .HasMany(e => e.tblEventComment1)
                .WithRequired(e => e.tblEventComment2)
                .HasForeignKey(e => e.in_reply_to_comment);

            modelBuilder.Entity<tblGenre>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<tblPreferenceValue>()
                .Property(e => e.preference_name)
                .IsUnicode(false);

            modelBuilder.Entity<tblPreferenceValue>()
                .HasMany(e => e.tblCustomerPreferences)
                .WithRequired(e => e.tblPreferenceValue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblPublicity>()
                .Property(e => e.ad_title)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.login)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.first_name)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.last_name)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .HasMany(e => e.tblEvent)
                .WithRequired(e => e.tblUser)
                .HasForeignKey(e => e.create_by)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblUserRole>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<tblUserRole>()
                .HasMany(e => e.tblUser)
                .WithRequired(e => e.tblUserRole)
                .WillCascadeOnDelete(false);
        }
    }
}

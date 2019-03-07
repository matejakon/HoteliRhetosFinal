// Reference: C:\Users\Mateja\Documents\Hoteli\dist\HoteliRhetosServer\bin\Autofac.dll
// Reference: C:\Users\Mateja\Documents\Hoteli\dist\HoteliRhetosServer\bin\Rhetos.Extensibility.Interfaces.dll
// Reference: C:\Users\Mateja\Documents\Hoteli\dist\HoteliRhetosServer\bin\Rhetos.Utilities.dll
// Reference: C:\Users\Mateja\Documents\Hoteli\dist\HoteliRhetosServer\bin\Rhetos.Security.Interfaces.dll
// Reference: C:\windows\Microsoft.Net\assembly\GAC_MSIL\System.ComponentModel.Composition\v4.0_4.0.0.0__b77a5c561934e089\System.ComponentModel.Composition.dll
// Reference: C:\Windows\Microsoft.NET\Framework64\v4.0.30319\mscorlib.dll
// Reference: C:\Users\Mateja\Documents\Hoteli\dist\HoteliRhetosServer\bin\Plugins\Rhetos.Dom.DefaultConcepts.dll
// Reference: C:\Users\Mateja\Documents\Hoteli\dist\HoteliRhetosServer\bin\Rhetos.Logging.Interfaces.dll
// Reference: C:\Users\Mateja\Documents\Hoteli\dist\HoteliRhetosServer\bin\EntityFramework.dll
// Reference: C:\Users\Mateja\Documents\Hoteli\dist\HoteliRhetosServer\bin\EntityFramework.SqlServer.dll
// Reference: C:\windows\Microsoft.Net\assembly\GAC_64\System.Data\v4.0_4.0.0.0__b77a5c561934e089\System.Data.dll
// Reference: C:\windows\Microsoft.Net\assembly\GAC_MSIL\System\v4.0_4.0.0.0__b77a5c561934e089\System.dll
// Reference: C:\Users\Mateja\Documents\Hoteli\dist\HoteliRhetosServer\bin\Rhetos.Persistence.Interfaces.dll
// Reference: C:\Users\Mateja\Documents\Hoteli\dist\HoteliRhetosServer\bin\Plugins\Rhetos.Processing.DefaultCommands.Interfaces.dll
// Reference: C:\Users\Mateja\Documents\Hoteli\dist\HoteliRhetosServer\bin\Rhetos.Processing.Interfaces.dll
// Reference: C:\windows\Microsoft.Net\assembly\GAC_MSIL\System.Core\v4.0_4.0.0.0__b77a5c561934e089\System.Core.dll
// Reference: C:\windows\Microsoft.Net\assembly\GAC_MSIL\Microsoft.CSharp\v4.0_4.0.0.0__b03f5f7f11d50a3a\Microsoft.CSharp.dll
// Reference: C:\windows\Microsoft.Net\assembly\GAC_MSIL\System.Data.DataSetExtensions\v4.0_4.0.0.0__b77a5c561934e089\System.Data.DataSetExtensions.dll
// Reference: C:\windows\Microsoft.Net\assembly\GAC_MSIL\System.Xml\v4.0_4.0.0.0__b77a5c561934e089\System.Xml.dll
// Reference: C:\windows\Microsoft.Net\assembly\GAC_MSIL\System.Xml.Linq\v4.0_4.0.0.0__b77a5c561934e089\System.Xml.Linq.dll
// Reference: C:\Users\Mateja\Documents\Hoteli\dist\HoteliRhetosServer\bin\Plugins\Rhetos.Dom.DefaultConcepts.Interfaces.dll
// Reference: C:\windows\Microsoft.Net\assembly\GAC_MSIL\System.Runtime.Serialization\v4.0_4.0.0.0__b77a5c561934e089\System.Runtime.Serialization.dll
// Reference: C:\Users\Mateja\Documents\Hoteli\dist\HoteliRhetosServer\bin\Generated\ServerDom.Model.dll
// CompilerOptions: "/optimize"

namespace Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;
    using Rhetos.Dom.DefaultConcepts;
    using Rhetos.Utilities;
    using Autofac;
    /*CommonUsing*/

    public class EntityFrameworkContext : System.Data.Entity.DbContext, Rhetos.Persistence.IPersistenceCache
    {
        private readonly Rhetos.Utilities.IConfiguration _configuration;

        public EntityFrameworkContext(
            Rhetos.Persistence.IPersistenceTransaction persistenceTransaction,
            Rhetos.Dom.DefaultConcepts.Persistence.EntityFrameworkMetadata metadata,
            EntityFrameworkConfiguration entityFrameworkConfiguration, // EntityFrameworkConfiguration is provided as an IoC dependency for EntityFrameworkContext in order to initialize the global DbConfiguration before using DbContext.
            Rhetos.Utilities.IConfiguration configuration)
            : base(new System.Data.Entity.Core.EntityClient.EntityConnection(metadata.MetadataWorkspace, persistenceTransaction.Connection), false)
        {
            _configuration = configuration;
            Initialize();
            Database.UseTransaction(persistenceTransaction.Transaction);
        }

        /// <summary>
        /// This constructor is used at deployment-time to create slow EntityFrameworkContext instance before the metadata files are generated.
        /// The instance is used by EntityFrameworkGenerateMetadataFiles to generate the metadata files.
        /// </summary>
        protected EntityFrameworkContext(
            System.Data.Common.DbConnection connection,
            EntityFrameworkConfiguration entityFrameworkConfiguration, // EntityFrameworkConfiguration is provided as an IoC dependency for EntityFrameworkContext in order to initialize the global DbConfiguration before using DbContext.
            Rhetos.Utilities.IConfiguration configuration)
            : base(connection, true)
        {
            _configuration = configuration;
            Initialize();
        }

        private void Initialize()
        {
            System.Data.Entity.Database.SetInitializer<EntityFrameworkContext>(null); // Prevent EF from creating database objects.

            this.Configuration.UseDatabaseNullSemantics = _configuration.GetBool("EntityFramework.UseDatabaseNullSemantics", false).Value;
            /*EntityFrameworkContextInitialize*/

            this.Database.CommandTimeout = Rhetos.Utilities.SqlUtility.SqlCommandTimeout;
        }

        public void ClearCache()
        {
            SetDetaching(true);
            try
            {
                Configuration.AutoDetectChangesEnabled = false;
                var trackedItems = ChangeTracker.Entries().ToList();
                foreach (var item in trackedItems)
                    Entry(item.Entity).State = System.Data.Entity.EntityState.Detached;
                Configuration.AutoDetectChangesEnabled = true;
            }
            finally
            {
                SetDetaching(false);
            }
        }

        private void SetDetaching(bool detaching)
        {
            foreach (var item in ChangeTracker.Entries().Select(entry => entry.Entity).OfType<IDetachOverride>())
                item.Detaching = detaching;
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<global::Hoteli.Hotel>();
            modelBuilder.Entity<Common.Queryable.Hoteli_Hotel>().Map(m => { m.MapInheritedProperties(); m.ToTable("Hotel", "Hoteli"); });
            modelBuilder.Ignore<global::Hoteli.Location>();
            modelBuilder.Entity<Common.Queryable.Hoteli_Location>().Map(m => { m.MapInheritedProperties(); m.ToTable("Location", "Hoteli"); });
            modelBuilder.Entity<Common.Queryable.Hoteli_Location>().HasRequired(t => t.Base).WithOptional(t => t.Extension_Location);
            modelBuilder.Ignore<global::Hoteli.RoomReservation>();
            modelBuilder.Entity<Common.Queryable.Hoteli_RoomReservation>().Map(m => { m.MapInheritedProperties(); m.ToTable("RoomReservation", "Hoteli"); });
            modelBuilder.Ignore<global::Hoteli.Reservation>();
            modelBuilder.Entity<Common.Queryable.Hoteli_Reservation>().Map(m => { m.MapInheritedProperties(); m.ToTable("Reservation", "Hoteli"); });
            modelBuilder.Entity<Common.Queryable.Hoteli_RoomReservation>()
                .HasOptional(t => t.ReservationHotel).WithMany()
                .HasForeignKey(t => t.ReservationHotelID);
            modelBuilder.Ignore<global::Hoteli.Rooms>();
            modelBuilder.Entity<Common.Queryable.Hoteli_Rooms>().Map(m => { m.MapInheritedProperties(); m.ToTable("Rooms", "Hoteli"); });
            modelBuilder.Entity<Common.Queryable.Hoteli_RoomReservation>()
                .HasOptional(t => t.ReservationRoom).WithMany()
                .HasForeignKey(t => t.ReservationRoomID);
            modelBuilder.Entity<Common.Queryable.Hoteli_Rooms>()
                .HasOptional(t => t.RoomOfHotel).WithMany()
                .HasForeignKey(t => t.RoomOfHotelID);
            modelBuilder.Ignore<global::Hoteli.Person>();
            modelBuilder.Entity<Common.Queryable.Hoteli_Person>().Map(m => { m.MapInheritedProperties(); m.ToTable("Person", "Hoteli"); });
            modelBuilder.Entity<Common.Queryable.Hoteli_Reservation>()
                .HasOptional(t => t.Guest).WithMany()
                .HasForeignKey(t => t.GuestID);
            modelBuilder.Ignore<global::Hoteli.SaloonPerson>();
            modelBuilder.Entity<Common.Queryable.Hoteli_SaloonPerson>().Map(m => { m.MapInheritedProperties(); m.ToTable("SaloonPerson", "Hoteli"); });
            modelBuilder.Entity<Common.Queryable.Hoteli_SaloonPerson>()
                .HasOptional(t => t.OwnerName).WithMany()
                .HasForeignKey(t => t.OwnerNameID);
            modelBuilder.Ignore<global::Hoteli.SaloonHotel>();
            modelBuilder.Entity<Common.Queryable.Hoteli_SaloonHotel>().Map(m => { m.MapInheritedProperties(); m.ToTable("SaloonHotel", "Hoteli"); });
            modelBuilder.Entity<Common.Queryable.Hoteli_SaloonHotel>()
                .HasOptional(t => t.OwnerName).WithMany()
                .HasForeignKey(t => t.OwnerNameID);
            modelBuilder.Ignore<global::Hoteli.Saloon>();
            modelBuilder.Entity<Common.Queryable.Hoteli_Saloon>().Map(m => { m.MapInheritedProperties(); m.ToTable("Saloon", "Hoteli"); });
            modelBuilder.Entity<Common.Queryable.Hoteli_SaloonPerson>()
                .HasOptional(t => t.Salon).WithMany()
                .HasForeignKey(t => t.SalonID);
            modelBuilder.Entity<Common.Queryable.Hoteli_SaloonHotel>()
                .HasOptional(t => t.Salon).WithMany()
                .HasForeignKey(t => t.SalonID);
            modelBuilder.Entity<Common.Queryable.Hoteli_Saloon>()
                .HasOptional(t => t.HotelSaloon).WithMany()
                .HasForeignKey(t => t.HotelSaloonID);
            modelBuilder.Ignore<global::Hoteli.ProductPerson>();
            modelBuilder.Entity<Common.Queryable.Hoteli_ProductPerson>().Map(m => { m.MapInheritedProperties(); m.ToTable("ProductPerson", "Hoteli"); });
            modelBuilder.Entity<Common.Queryable.Hoteli_ProductPerson>()
                .HasOptional(t => t.OwnerName).WithMany()
                .HasForeignKey(t => t.OwnerNameID);
            modelBuilder.Ignore<global::Hoteli.ProductHotel>();
            modelBuilder.Entity<Common.Queryable.Hoteli_ProductHotel>().Map(m => { m.MapInheritedProperties(); m.ToTable("ProductHotel", "Hoteli"); });
            modelBuilder.Entity<Common.Queryable.Hoteli_ProductHotel>()
                .HasOptional(t => t.OwnerName).WithMany()
                .HasForeignKey(t => t.OwnerNameID);
            modelBuilder.Ignore<global::Hoteli.Product>();
            modelBuilder.Entity<Common.Queryable.Hoteli_Product>().Map(m => { m.MapInheritedProperties(); m.ToTable("Product", "Hoteli"); });
            modelBuilder.Entity<Common.Queryable.Hoteli_ProductPerson>()
                .HasOptional(t => t.Product).WithMany()
                .HasForeignKey(t => t.ProductID);
            modelBuilder.Entity<Common.Queryable.Hoteli_ProductHotel>()
                .HasOptional(t => t.Product).WithMany()
                .HasForeignKey(t => t.ProductID);
            modelBuilder.Entity<Common.Queryable.Hoteli_Product>()
                .HasOptional(t => t.HotelSaloon).WithMany()
                .HasForeignKey(t => t.HotelSaloonID);
            modelBuilder.Ignore<global::Hoteli.ReservationInfo>();
            modelBuilder.Entity<Common.Queryable.Hoteli_ReservationInfo>().Map(m => { m.MapInheritedProperties(); m.ToTable("ReservationInfo", "Hoteli"); });
            modelBuilder.Entity<Common.Queryable.Hoteli_ReservationInfo>().HasRequired(t => t.Base).WithOptional(t => t.Extension_ReservationInfo);
            modelBuilder.Ignore<global::Common.AutoCodeCache>();
            modelBuilder.Entity<Common.Queryable.Common_AutoCodeCache>().Map(m => { m.MapInheritedProperties(); m.ToTable("AutoCodeCache", "Common"); });
            modelBuilder.Ignore<global::Common.FilterId>();
            modelBuilder.Entity<Common.Queryable.Common_FilterId>().Map(m => { m.MapInheritedProperties(); m.ToTable("FilterId", "Common"); });
            modelBuilder.Ignore<global::Common.KeepSynchronizedMetadata>();
            modelBuilder.Entity<Common.Queryable.Common_KeepSynchronizedMetadata>().Map(m => { m.MapInheritedProperties(); m.ToTable("KeepSynchronizedMetadata", "Common"); });
            modelBuilder.Ignore<global::Common.ExclusiveLock>();
            modelBuilder.Entity<Common.Queryable.Common_ExclusiveLock>().Map(m => { m.MapInheritedProperties(); m.ToTable("ExclusiveLock", "Common"); });
            modelBuilder.Ignore<global::Common.LogReader>();
            modelBuilder.Entity<Common.Queryable.Common_LogReader>().Map(m => { m.MapInheritedProperties(); m.ToTable("LogReader", "Common"); });
            modelBuilder.Ignore<global::Common.LogRelatedItemReader>();
            modelBuilder.Entity<Common.Queryable.Common_LogRelatedItemReader>().Map(m => { m.MapInheritedProperties(); m.ToTable("LogRelatedItemReader", "Common"); });
            modelBuilder.Ignore<global::Common.Log>();
            modelBuilder.Entity<Common.Queryable.Common_Log>().Map(m => { m.MapInheritedProperties(); m.ToTable("Log", "Common"); });
            modelBuilder.Ignore<global::Common.LogRelatedItem>();
            modelBuilder.Entity<Common.Queryable.Common_LogRelatedItem>().Map(m => { m.MapInheritedProperties(); m.ToTable("LogRelatedItem", "Common"); });
            modelBuilder.Entity<Common.Queryable.Common_LogRelatedItem>()
                .HasOptional(t => t.Log).WithMany()
                .HasForeignKey(t => t.LogID);
            modelBuilder.Ignore<global::Common.RelatedEventsSource>();
            modelBuilder.Entity<Common.Queryable.Common_RelatedEventsSource>().Map(m => { m.MapInheritedProperties(); m.ToTable("RelatedEventsSource", "Common"); });
            modelBuilder.Entity<Common.Queryable.Common_RelatedEventsSource>()
                .HasOptional(t => t.Log).WithMany()
                .HasForeignKey(t => t.LogID);
            modelBuilder.Ignore<global::Common.Claim>();
            modelBuilder.Entity<Common.Queryable.Common_Claim>().Map(m => { m.MapInheritedProperties(); m.ToTable("Claim", "Common"); });
            modelBuilder.Ignore<global::Common.Principal>();
            modelBuilder.Entity<Common.Queryable.Common_Principal>().Map(m => { m.MapInheritedProperties(); m.ToTable("Principal", "Common"); });
            modelBuilder.Ignore<global::Common.PrincipalHasRole>();
            modelBuilder.Entity<Common.Queryable.Common_PrincipalHasRole>().Map(m => { m.MapInheritedProperties(); m.ToTable("PrincipalHasRole", "Common"); });
            modelBuilder.Entity<Common.Queryable.Common_PrincipalHasRole>()
                .HasOptional(t => t.Principal).WithMany()
                .HasForeignKey(t => t.PrincipalID);
            modelBuilder.Ignore<global::Common.Role>();
            modelBuilder.Entity<Common.Queryable.Common_Role>().Map(m => { m.MapInheritedProperties(); m.ToTable("Role", "Common"); });
            modelBuilder.Entity<Common.Queryable.Common_PrincipalHasRole>()
                .HasOptional(t => t.Role).WithMany()
                .HasForeignKey(t => t.RoleID);
            modelBuilder.Ignore<global::Common.RoleInheritsRole>();
            modelBuilder.Entity<Common.Queryable.Common_RoleInheritsRole>().Map(m => { m.MapInheritedProperties(); m.ToTable("RoleInheritsRole", "Common"); });
            modelBuilder.Entity<Common.Queryable.Common_RoleInheritsRole>()
                .HasOptional(t => t.UsersFrom).WithMany()
                .HasForeignKey(t => t.UsersFromID);
            modelBuilder.Entity<Common.Queryable.Common_RoleInheritsRole>()
                .HasOptional(t => t.PermissionsFrom).WithMany()
                .HasForeignKey(t => t.PermissionsFromID);
            modelBuilder.Ignore<global::Common.PrincipalPermission>();
            modelBuilder.Entity<Common.Queryable.Common_PrincipalPermission>().Map(m => { m.MapInheritedProperties(); m.ToTable("PrincipalPermission", "Common"); });
            modelBuilder.Entity<Common.Queryable.Common_PrincipalPermission>()
                .HasOptional(t => t.Principal).WithMany()
                .HasForeignKey(t => t.PrincipalID);
            modelBuilder.Entity<Common.Queryable.Common_PrincipalPermission>()
                .HasOptional(t => t.Claim).WithMany()
                .HasForeignKey(t => t.ClaimID);
            modelBuilder.Ignore<global::Common.RolePermission>();
            modelBuilder.Entity<Common.Queryable.Common_RolePermission>().Map(m => { m.MapInheritedProperties(); m.ToTable("RolePermission", "Common"); });
            modelBuilder.Entity<Common.Queryable.Common_RolePermission>()
                .HasOptional(t => t.Role).WithMany()
                .HasForeignKey(t => t.RoleID);
            modelBuilder.Entity<Common.Queryable.Common_RolePermission>()
                .HasOptional(t => t.Claim).WithMany()
                .HasForeignKey(t => t.ClaimID);
            modelBuilder.Entity<Common.Queryable.Common_LogRelatedItemReader>()
                .HasOptional(t => t.Log).WithMany()
                .HasForeignKey(t => t.LogID);
            modelBuilder.Entity<Common.Queryable.Common_Claim>().Ignore(t => t.Extension_MyClaim);
            /*EntityFrameworkOnModelCreating*/
        }

        public System.Data.Entity.DbSet<Common.Queryable.Hoteli_Hotel> Hoteli_Hotel { get; set; }
        public System.Data.Entity.DbSet<Common.Queryable.Hoteli_Location> Hoteli_Location { get; set; }
        public System.Data.Entity.DbSet<Common.Queryable.Hoteli_RoomReservation> Hoteli_RoomReservation { get; set; }
        public System.Data.Entity.DbSet<Common.Queryable.Hoteli_Reservation> Hoteli_Reservation { get; set; }
        public System.Data.Entity.DbSet<Common.Queryable.Hoteli_Rooms> Hoteli_Rooms { get; set; }
        public System.Data.Entity.DbSet<Common.Queryable.Hoteli_Person> Hoteli_Person { get; set; }
        public System.Data.Entity.DbSet<Common.Queryable.Hoteli_SaloonPerson> Hoteli_SaloonPerson { get; set; }
        public System.Data.Entity.DbSet<Common.Queryable.Hoteli_SaloonHotel> Hoteli_SaloonHotel { get; set; }
        public System.Data.Entity.DbSet<Common.Queryable.Hoteli_Saloon> Hoteli_Saloon { get; set; }
        public System.Data.Entity.DbSet<Common.Queryable.Hoteli_ProductPerson> Hoteli_ProductPerson { get; set; }
        public System.Data.Entity.DbSet<Common.Queryable.Hoteli_ProductHotel> Hoteli_ProductHotel { get; set; }
        public System.Data.Entity.DbSet<Common.Queryable.Hoteli_Product> Hoteli_Product { get; set; }
        public System.Data.Entity.DbSet<Common.Queryable.Hoteli_ReservationInfo> Hoteli_ReservationInfo { get; set; }
        public System.Data.Entity.DbSet<Common.Queryable.Common_AutoCodeCache> Common_AutoCodeCache { get; set; }
        public System.Data.Entity.DbSet<Common.Queryable.Common_FilterId> Common_FilterId { get; set; }
        public System.Data.Entity.DbSet<Common.Queryable.Common_KeepSynchronizedMetadata> Common_KeepSynchronizedMetadata { get; set; }
        public System.Data.Entity.DbSet<Common.Queryable.Common_ExclusiveLock> Common_ExclusiveLock { get; set; }
        public System.Data.Entity.DbSet<Common.Queryable.Common_LogReader> Common_LogReader { get; set; }
        public System.Data.Entity.DbSet<Common.Queryable.Common_LogRelatedItemReader> Common_LogRelatedItemReader { get; set; }
        public System.Data.Entity.DbSet<Common.Queryable.Common_Log> Common_Log { get; set; }
        public System.Data.Entity.DbSet<Common.Queryable.Common_LogRelatedItem> Common_LogRelatedItem { get; set; }
        public System.Data.Entity.DbSet<Common.Queryable.Common_RelatedEventsSource> Common_RelatedEventsSource { get; set; }
        public System.Data.Entity.DbSet<Common.Queryable.Common_Claim> Common_Claim { get; set; }
        public System.Data.Entity.DbSet<Common.Queryable.Common_Principal> Common_Principal { get; set; }
        public System.Data.Entity.DbSet<Common.Queryable.Common_PrincipalHasRole> Common_PrincipalHasRole { get; set; }
        public System.Data.Entity.DbSet<Common.Queryable.Common_Role> Common_Role { get; set; }
        public System.Data.Entity.DbSet<Common.Queryable.Common_RoleInheritsRole> Common_RoleInheritsRole { get; set; }
        public System.Data.Entity.DbSet<Common.Queryable.Common_PrincipalPermission> Common_PrincipalPermission { get; set; }
        public System.Data.Entity.DbSet<Common.Queryable.Common_RolePermission> Common_RolePermission { get; set; }
        /*EntityFrameworkContextMembers*/
    }

    public class EntityFrameworkConfiguration : System.Data.Entity.DbConfiguration
    {
        public EntityFrameworkConfiguration()
        {
            SetProviderServices("System.Data.SqlClient", System.Data.Entity.SqlServer.SqlProviderServices.Instance);

            AddInterceptor(new Rhetos.Dom.DefaultConcepts.Persistence.FullTextSearchInterceptor());
            /*EntityFrameworkConfiguration*/

            System.Data.Entity.DbConfiguration.SetConfiguration(this);
        }
    }
}
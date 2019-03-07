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
// Reference: C:\Users\Mateja\Documents\Hoteli\dist\HoteliRhetosServer\bin\Generated\ServerDom.Orm.dll
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

    public class DomRepository
    {
        private readonly Rhetos.Extensibility.INamedPlugins<IRepository> _repositories;

        public DomRepository(Rhetos.Extensibility.INamedPlugins<IRepository> repositories)
        {
            _repositories = repositories;
        }

        private Hoteli._Helper._ModuleRepository _Hoteli;
        public Hoteli._Helper._ModuleRepository Hoteli { get { return _Hoteli ?? (_Hoteli = new Hoteli._Helper._ModuleRepository(_repositories)); } }

        private Common._Helper._ModuleRepository _Common;
        public Common._Helper._ModuleRepository Common { get { return _Common ?? (_Common = new Common._Helper._ModuleRepository(_repositories)); } }

        /*CommonDomRepositoryMembers*/
    }

    public static class Infrastructure
    {
        public static readonly RegisteredInterfaceImplementations RegisteredInterfaceImplementationName = new RegisteredInterfaceImplementations
        {
            { typeof(Rhetos.Dom.DefaultConcepts.ICommonFilterId), @"Common.FilterId" },
            { typeof(Rhetos.Dom.DefaultConcepts.IKeepSynchronizedMetadata), @"Common.KeepSynchronizedMetadata" },
            { typeof(Rhetos.Dom.DefaultConcepts.ICommonClaim), @"Common.Claim" },
            { typeof(Rhetos.Dom.DefaultConcepts.IPrincipal), @"Common.Principal" },
            { typeof(Rhetos.Dom.DefaultConcepts.IPrincipalHasRole), @"Common.PrincipalHasRole" },
            { typeof(Rhetos.Dom.DefaultConcepts.IRole), @"Common.Role" },
            { typeof(Rhetos.Dom.DefaultConcepts.IRoleInheritsRole), @"Common.RoleInheritsRole" },
            { typeof(Rhetos.Dom.DefaultConcepts.IPrincipalPermission), @"Common.PrincipalPermission" },
            { typeof(Rhetos.Dom.DefaultConcepts.IRolePermission), @"Common.RolePermission" },
            /*RegisteredInterfaceImplementationName*/
        };

        public static readonly ApplyFiltersOnClientRead ApplyFiltersOnClientRead = new ApplyFiltersOnClientRead
        {
            /*ApplyFiltersOnClientRead*/
        };

        public static readonly CurrentKeepSynchronizedMetadata CurrentKeepSynchronizedMetadata = new CurrentKeepSynchronizedMetadata
        {
            /*AddKeepSynchronizedMetadata*/
        };

        /*CommonInfrastructureMembers*/
    }

    public class ExecutionContext
    {
        protected Lazy<Rhetos.Persistence.IPersistenceTransaction> _persistenceTransaction;
        public Rhetos.Persistence.IPersistenceTransaction PersistenceTransaction { get { return _persistenceTransaction.Value; } }

        protected Lazy<Rhetos.Utilities.IUserInfo> _userInfo;
        public Rhetos.Utilities.IUserInfo UserInfo { get { return _userInfo.Value; } }

        protected Lazy<Rhetos.Utilities.ISqlExecuter> _sqlExecuter;
        public Rhetos.Utilities.ISqlExecuter SqlExecuter { get { return _sqlExecuter.Value; } }

        protected Lazy<Rhetos.Security.IAuthorizationManager> _authorizationManager;
        public Rhetos.Security.IAuthorizationManager AuthorizationManager { get { return _authorizationManager.Value; } }

        protected Lazy<Rhetos.Dom.DefaultConcepts.GenericRepositories> _genericRepositories;
        public Rhetos.Dom.DefaultConcepts.GenericRepositories GenericRepositories { get { return _genericRepositories.Value; } }

        public Rhetos.Dom.DefaultConcepts.GenericRepository<TEntity> GenericRepository<TEntity>() where TEntity : class, IEntity
        {
            return GenericRepositories.GetGenericRepository<TEntity>();
        }

        public Rhetos.Dom.DefaultConcepts.GenericRepository<TEntity> GenericRepository<TEntity>(string entityName) where TEntity : class, IEntity
        {
            return GenericRepositories.GetGenericRepository<TEntity>(entityName);
        }

        public Rhetos.Dom.DefaultConcepts.GenericRepository<IEntity> GenericRepository(string entityName)
        {
            return GenericRepositories.GetGenericRepository(entityName);
        }

        protected Lazy<Common.DomRepository> _repository;
        public Common.DomRepository Repository { get { return _repository.Value; } }

        public Rhetos.Logging.ILogProvider LogProvider { get; private set; }

        protected Lazy<Rhetos.Security.IWindowsSecurity> _windowsSecurity;
        public Rhetos.Security.IWindowsSecurity WindowsSecurity { get { return _windowsSecurity.Value; } }

        public EntityFrameworkContext EntityFrameworkContext { get; private set; }

        /*ExecutionContextMember*/

        // This constructor is used for automatic parameter injection with autofac.
        public ExecutionContext(
            Lazy<Rhetos.Persistence.IPersistenceTransaction> persistenceTransaction,
            Lazy<Rhetos.Utilities.IUserInfo> userInfo,
            Lazy<Rhetos.Utilities.ISqlExecuter> sqlExecuter,
            Lazy<Rhetos.Security.IAuthorizationManager> authorizationManager,
            Lazy<Rhetos.Dom.DefaultConcepts.GenericRepositories> genericRepositories,
            Lazy<Common.DomRepository> repository,
            Rhetos.Logging.ILogProvider logProvider,
            Lazy<Rhetos.Security.IWindowsSecurity> windowsSecurity/*ExecutionContextConstructorArgument*/,
            EntityFrameworkContext entityFrameworkContext)
        {
            _persistenceTransaction = persistenceTransaction;
            _userInfo = userInfo;
            _sqlExecuter = sqlExecuter;
            _authorizationManager = authorizationManager;
            _genericRepositories = genericRepositories;
            _repository = repository;
            LogProvider = logProvider;
            _windowsSecurity = windowsSecurity;
            EntityFrameworkContext = entityFrameworkContext;
            /*ExecutionContextConstructorAssignment*/
        }

        // This constructor is used for manual context creation (unit testing)
        public ExecutionContext()
        {
        }
    }

    [System.ComponentModel.Composition.Export(typeof(Autofac.Module))]
    public class AutofacModuleConfiguration : Autofac.Module
    {
        protected override void Load(Autofac.ContainerBuilder builder)
        {
            builder.RegisterType<DomRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EntityFrameworkConfiguration>().SingleInstance();
            builder.RegisterType<EntityFrameworkContext>()
                .As<EntityFrameworkContext>()
                .As<System.Data.Entity.DbContext>()
                .As<Rhetos.Persistence.IPersistenceCache>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ExecutionContext>().InstancePerLifetimeScope();
            builder.RegisterInstance(Infrastructure.RegisteredInterfaceImplementationName).ExternallyOwned();
            builder.RegisterInstance(Infrastructure.ApplyFiltersOnClientRead).ExternallyOwned();
            builder.RegisterInstance(Infrastructure.CurrentKeepSynchronizedMetadata).ExternallyOwned();
            builder.RegisterType<Hoteli._Helper.Hotel_Repository>().Keyed<IRepository>("Hoteli.Hotel").InstancePerLifetimeScope();
            builder.RegisterType<Hoteli._Helper.Location_Repository>().Keyed<IRepository>("Hoteli.Location").InstancePerLifetimeScope();
            builder.RegisterType<Hoteli._Helper.RoomReservation_Repository>().Keyed<IRepository>("Hoteli.RoomReservation").InstancePerLifetimeScope();
            builder.RegisterType<Hoteli._Helper.Reservation_Repository>().Keyed<IRepository>("Hoteli.Reservation").InstancePerLifetimeScope();
            builder.RegisterType<Hoteli._Helper.Rooms_Repository>().Keyed<IRepository>("Hoteli.Rooms").InstancePerLifetimeScope();
            builder.RegisterType<Hoteli._Helper.Person_Repository>().Keyed<IRepository>("Hoteli.Person").InstancePerLifetimeScope();
            builder.RegisterType<Hoteli._Helper.SaloonPerson_Repository>().Keyed<IRepository>("Hoteli.SaloonPerson").InstancePerLifetimeScope();
            builder.RegisterType<Hoteli._Helper.SaloonHotel_Repository>().Keyed<IRepository>("Hoteli.SaloonHotel").InstancePerLifetimeScope();
            builder.RegisterType<Hoteli._Helper.Saloon_Repository>().Keyed<IRepository>("Hoteli.Saloon").InstancePerLifetimeScope();
            builder.RegisterType<Hoteli._Helper.ProductPerson_Repository>().Keyed<IRepository>("Hoteli.ProductPerson").InstancePerLifetimeScope();
            builder.RegisterType<Hoteli._Helper.ProductHotel_Repository>().Keyed<IRepository>("Hoteli.ProductHotel").InstancePerLifetimeScope();
            builder.RegisterType<Hoteli._Helper.Product_Repository>().Keyed<IRepository>("Hoteli.Product").InstancePerLifetimeScope();
            builder.RegisterType<Hoteli._Helper.Insert5Hotels_Repository>().Keyed<IRepository>("Hoteli.Insert5Hotels").InstancePerLifetimeScope();
            builder.RegisterType<Hoteli._Helper.Insert5Hotels_Repository>().Keyed<IActionRepository>("Hoteli.Insert5Hotels").InstancePerLifetimeScope();
            builder.RegisterType<Hoteli._Helper.Insert5Rooms_Repository>().Keyed<IRepository>("Hoteli.Insert5Rooms").InstancePerLifetimeScope();
            builder.RegisterType<Hoteli._Helper.Insert5Rooms_Repository>().Keyed<IActionRepository>("Hoteli.Insert5Rooms").InstancePerLifetimeScope();
            builder.RegisterType<Hoteli._Helper.Insert6Rooms_Repository>().Keyed<IRepository>("Hoteli.Insert6Rooms").InstancePerLifetimeScope();
            builder.RegisterType<Hoteli._Helper.Insert6Rooms_Repository>().Keyed<IActionRepository>("Hoteli.Insert6Rooms").InstancePerLifetimeScope();
            builder.RegisterType<Hoteli._Helper.ReservationInfo_Repository>().Keyed<IRepository>("Hoteli.ReservationInfo").InstancePerLifetimeScope();
            builder.RegisterType<Common._Helper.AutoCodeCache_Repository>().Keyed<IRepository>("Common.AutoCodeCache").InstancePerLifetimeScope();
            builder.RegisterType<Common._Helper.FilterId_Repository>().Keyed<IRepository>("Common.FilterId").InstancePerLifetimeScope();
            builder.RegisterType<Common._Helper.KeepSynchronizedMetadata_Repository>().Keyed<IRepository>("Common.KeepSynchronizedMetadata").InstancePerLifetimeScope();
            builder.RegisterType<Common._Helper.ExclusiveLock_Repository>().Keyed<IRepository>("Common.ExclusiveLock").InstancePerLifetimeScope();
            builder.RegisterType<Common._Helper.SetLock_Repository>().Keyed<IRepository>("Common.SetLock").InstancePerLifetimeScope();
            builder.RegisterType<Common._Helper.SetLock_Repository>().Keyed<IActionRepository>("Common.SetLock").InstancePerLifetimeScope();
            builder.RegisterType<Common._Helper.ReleaseLock_Repository>().Keyed<IRepository>("Common.ReleaseLock").InstancePerLifetimeScope();
            builder.RegisterType<Common._Helper.ReleaseLock_Repository>().Keyed<IActionRepository>("Common.ReleaseLock").InstancePerLifetimeScope();
            builder.RegisterType<Common._Helper.LogReader_Repository>().Keyed<IRepository>("Common.LogReader").InstancePerLifetimeScope();
            builder.RegisterType<Common._Helper.LogRelatedItemReader_Repository>().Keyed<IRepository>("Common.LogRelatedItemReader").InstancePerLifetimeScope();
            builder.RegisterType<Common._Helper.Log_Repository>().Keyed<IRepository>("Common.Log").InstancePerLifetimeScope();
            builder.RegisterType<Common._Helper.AddToLog_Repository>().Keyed<IRepository>("Common.AddToLog").InstancePerLifetimeScope();
            builder.RegisterType<Common._Helper.AddToLog_Repository>().Keyed<IActionRepository>("Common.AddToLog").InstancePerLifetimeScope();
            builder.RegisterType<Common._Helper.LogRelatedItem_Repository>().Keyed<IRepository>("Common.LogRelatedItem").InstancePerLifetimeScope();
            builder.RegisterType<Common._Helper.RelatedEventsSource_Repository>().Keyed<IRepository>("Common.RelatedEventsSource").InstancePerLifetimeScope();
            builder.RegisterType<Common._Helper.Claim_Repository>().Keyed<IRepository>("Common.Claim").InstancePerLifetimeScope();
            builder.RegisterType<Common._Helper.MyClaim_Repository>().Keyed<IRepository>("Common.MyClaim").InstancePerLifetimeScope();
            builder.RegisterType<Common._Helper.Principal_Repository>().Keyed<IRepository>("Common.Principal").InstancePerLifetimeScope();
            builder.RegisterType<Common._Helper.PrincipalHasRole_Repository>().Keyed<IRepository>("Common.PrincipalHasRole").InstancePerLifetimeScope();
            builder.RegisterType<Common._Helper.Role_Repository>().Keyed<IRepository>("Common.Role").InstancePerLifetimeScope();
            builder.RegisterType<Common._Helper.RoleInheritsRole_Repository>().Keyed<IRepository>("Common.RoleInheritsRole").InstancePerLifetimeScope();
            builder.RegisterType<Common._Helper.PrincipalPermission_Repository>().Keyed<IRepository>("Common.PrincipalPermission").InstancePerLifetimeScope();
            builder.RegisterType<Common._Helper.RolePermission_Repository>().Keyed<IRepository>("Common.RolePermission").InstancePerLifetimeScope();
            builder.RegisterType<Common._Helper.FilterId_Repository>().As<IQueryableRepository<Rhetos.Dom.DefaultConcepts.ICommonFilterId>>().InstancePerLifetimeScope();
            builder.RegisterType<Common._Helper.KeepSynchronizedMetadata_Repository>().As<IQueryableRepository<Rhetos.Dom.DefaultConcepts.IKeepSynchronizedMetadata>>().InstancePerLifetimeScope();
            builder.RegisterType<Common._Helper.Claim_Repository>().As<IQueryableRepository<Rhetos.Dom.DefaultConcepts.ICommonClaim>>().InstancePerLifetimeScope();
            builder.RegisterType<Common._Helper.Principal_Repository>().As<IQueryableRepository<Rhetos.Dom.DefaultConcepts.IPrincipal>>().InstancePerLifetimeScope();
            builder.RegisterType<Common._Helper.PrincipalHasRole_Repository>().As<IQueryableRepository<Rhetos.Dom.DefaultConcepts.IPrincipalHasRole>>().InstancePerLifetimeScope();
            builder.RegisterType<Common._Helper.Role_Repository>().As<IQueryableRepository<Rhetos.Dom.DefaultConcepts.IRole>>().InstancePerLifetimeScope();
            builder.RegisterType<Common._Helper.RoleInheritsRole_Repository>().As<IQueryableRepository<Rhetos.Dom.DefaultConcepts.IRoleInheritsRole>>().InstancePerLifetimeScope();
            builder.RegisterType<Common._Helper.PrincipalPermission_Repository>().As<IQueryableRepository<Rhetos.Dom.DefaultConcepts.IPrincipalPermission>>().InstancePerLifetimeScope();
            builder.RegisterType<Common._Helper.RolePermission_Repository>().As<IQueryableRepository<Rhetos.Dom.DefaultConcepts.IRolePermission>>().InstancePerLifetimeScope();
            /*CommonAutofacConfigurationMembers*/

            base.Load(builder);
        }
    }

    public abstract class RepositoryBase : IRepository
    {
        protected Common.DomRepository _domRepository;
        protected Common.ExecutionContext _executionContext;
    }

    public abstract class ReadableRepositoryBase<TEntity> : RepositoryBase, IReadableRepository<TEntity>
        where TEntity : class, IEntity
    {
        public IEnumerable<TEntity> Load(object parameter, Type parameterType)
        {
            var items = _executionContext.GenericRepository(typeof(TEntity).FullName)
                .Load(parameter, parameterType);
            return (IEnumerable<TEntity>)items;
        }

        public IEnumerable<TEntity> Read(object parameter, Type parameterType, bool preferQuery)
        {
            var items = _executionContext.GenericRepository(typeof(TEntity).FullName)
                .Read(parameter, parameterType, preferQuery);
            return (IEnumerable<TEntity>)items;
        }

        [Obsolete("Use Load() or Query() method.")]
        public abstract TEntity[] All();

        [Obsolete("Use Load() or Query() method.")]
        public TEntity[] Filter(FilterAll filterAll)
        {
            return All();
        }
    }

    public abstract class QueryableRepositoryBase<TQueryableEntity, TEntity> : ReadableRepositoryBase<TEntity>, IQueryableRepository<TQueryableEntity, TEntity>
        where TEntity : class, IEntity
        where TQueryableEntity : class, IEntity, TEntity, IQueryableEntity<TEntity>
    {
        [Obsolete("Use Load(identifiers) or Query(identifiers) method.")]
        public TEntity[] Filter(IEnumerable<Guid> identifiers)
        {
            const int BufferSize = 500; // EF 6.1.3 LINQ query has O(n^2) time complexity. Batch size of 500 results with optimal total time on the test system.
            int n = identifiers.Count();
            var result = new List<TEntity>(n);
            for (int i = 0; i < (n + BufferSize - 1) / BufferSize; i++)
            {
                Guid[] idBuffer = identifiers.Skip(i * BufferSize).Take(BufferSize).ToArray();
                List<TEntity> itemBuffer;
                if (idBuffer.Count() == 1) // EF 6.1.3. does not use parametrized SQL query for Contains() function. The equality comparer is used instead, to reuse cached execution plans.
                {
                    Guid id = idBuffer.Single();
                    itemBuffer = Query().Where(item => item.ID == id).GenericToSimple<TEntity>().ToList();
                }
                else
                    itemBuffer = Query().Where(item => idBuffer.Contains(item.ID)).GenericToSimple<TEntity>().ToList();
                result.AddRange(itemBuffer);
            }
            return result.ToArray();
        }

        public abstract IQueryable<TQueryableEntity> Query();

        // LINQ to Entity does not support Query() method in subqueries.
        public IQueryable<TQueryableEntity> Subquery { get { return Query(); } }

        public IQueryable<TQueryableEntity> Query(object parameter, Type parameterType)
        {
            var query = _executionContext.GenericRepository(typeof(TEntity).FullName).Query(parameter, parameterType);
            return (IQueryable<TQueryableEntity>)query;
        }
    }

    public abstract class OrmRepositoryBase<TQueryableEntity, TEntity> : QueryableRepositoryBase<TQueryableEntity, TEntity>
        where TEntity : class, IEntity
        where TQueryableEntity : class, IEntity, TEntity, IQueryableEntity<TEntity>
    {
        public IQueryable<TQueryableEntity> Filter(IQueryable<TQueryableEntity> items, IEnumerable<Guid> ids)
        {
            if (!(ids is System.Collections.IList))
                ids = ids.ToList();

            if (ids.Count() == 1) // EF 6.1.3. does not use parametrized SQL query for Contains() function. The equality comparer is used instead, to reuse cached execution plans.
            {
                Guid id = ids.Single();
                return items.Where(item => item.ID == id);
            }
            else
            {
                // Depending on the ids count, this method will return the list of IDs, or insert the ids to the database and return an SQL query that selects the ids.
                var idsQuery = _domRepository.Common.FilterId.CreateQueryableFilterIds(ids);
                return items.Where(item => idsQuery.Contains(item.ID));
            }
        }
    }

    internal class DontTrackHistory<T> : List<T>
    {
    }
    /*CommonNamespaceMembers*/
}

namespace Hoteli._Helper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;
    using Rhetos.Dom.DefaultConcepts;
    using Rhetos.Utilities;

    /*ModuleInfo Using Hoteli*/

    public class _ModuleRepository
    {
        private readonly Rhetos.Extensibility.INamedPlugins<IRepository> _repositories;

        public _ModuleRepository(Rhetos.Extensibility.INamedPlugins<IRepository> repositories)
        {
            _repositories = repositories;
        }

        private Hotel_Repository _Hotel_Repository;
        public Hotel_Repository Hotel { get { return _Hotel_Repository ?? (_Hotel_Repository = (Hotel_Repository)Rhetos.Extensibility.NamedPluginsExtensions.GetPlugin(_repositories, @"Hoteli.Hotel")); } }

        private Location_Repository _Location_Repository;
        public Location_Repository Location { get { return _Location_Repository ?? (_Location_Repository = (Location_Repository)Rhetos.Extensibility.NamedPluginsExtensions.GetPlugin(_repositories, @"Hoteli.Location")); } }

        private RoomReservation_Repository _RoomReservation_Repository;
        public RoomReservation_Repository RoomReservation { get { return _RoomReservation_Repository ?? (_RoomReservation_Repository = (RoomReservation_Repository)Rhetos.Extensibility.NamedPluginsExtensions.GetPlugin(_repositories, @"Hoteli.RoomReservation")); } }

        private Reservation_Repository _Reservation_Repository;
        public Reservation_Repository Reservation { get { return _Reservation_Repository ?? (_Reservation_Repository = (Reservation_Repository)Rhetos.Extensibility.NamedPluginsExtensions.GetPlugin(_repositories, @"Hoteli.Reservation")); } }

        private Rooms_Repository _Rooms_Repository;
        public Rooms_Repository Rooms { get { return _Rooms_Repository ?? (_Rooms_Repository = (Rooms_Repository)Rhetos.Extensibility.NamedPluginsExtensions.GetPlugin(_repositories, @"Hoteli.Rooms")); } }

        private Person_Repository _Person_Repository;
        public Person_Repository Person { get { return _Person_Repository ?? (_Person_Repository = (Person_Repository)Rhetos.Extensibility.NamedPluginsExtensions.GetPlugin(_repositories, @"Hoteli.Person")); } }

        private SaloonPerson_Repository _SaloonPerson_Repository;
        public SaloonPerson_Repository SaloonPerson { get { return _SaloonPerson_Repository ?? (_SaloonPerson_Repository = (SaloonPerson_Repository)Rhetos.Extensibility.NamedPluginsExtensions.GetPlugin(_repositories, @"Hoteli.SaloonPerson")); } }

        private SaloonHotel_Repository _SaloonHotel_Repository;
        public SaloonHotel_Repository SaloonHotel { get { return _SaloonHotel_Repository ?? (_SaloonHotel_Repository = (SaloonHotel_Repository)Rhetos.Extensibility.NamedPluginsExtensions.GetPlugin(_repositories, @"Hoteli.SaloonHotel")); } }

        private Saloon_Repository _Saloon_Repository;
        public Saloon_Repository Saloon { get { return _Saloon_Repository ?? (_Saloon_Repository = (Saloon_Repository)Rhetos.Extensibility.NamedPluginsExtensions.GetPlugin(_repositories, @"Hoteli.Saloon")); } }

        private ProductPerson_Repository _ProductPerson_Repository;
        public ProductPerson_Repository ProductPerson { get { return _ProductPerson_Repository ?? (_ProductPerson_Repository = (ProductPerson_Repository)Rhetos.Extensibility.NamedPluginsExtensions.GetPlugin(_repositories, @"Hoteli.ProductPerson")); } }

        private ProductHotel_Repository _ProductHotel_Repository;
        public ProductHotel_Repository ProductHotel { get { return _ProductHotel_Repository ?? (_ProductHotel_Repository = (ProductHotel_Repository)Rhetos.Extensibility.NamedPluginsExtensions.GetPlugin(_repositories, @"Hoteli.ProductHotel")); } }

        private Product_Repository _Product_Repository;
        public Product_Repository Product { get { return _Product_Repository ?? (_Product_Repository = (Product_Repository)Rhetos.Extensibility.NamedPluginsExtensions.GetPlugin(_repositories, @"Hoteli.Product")); } }

        private Insert5Hotels_Repository _Insert5Hotels_Repository;
        public Insert5Hotels_Repository Insert5Hotels { get { return _Insert5Hotels_Repository ?? (_Insert5Hotels_Repository = (Insert5Hotels_Repository)Rhetos.Extensibility.NamedPluginsExtensions.GetPlugin(_repositories, @"Hoteli.Insert5Hotels")); } }

        private Insert5Rooms_Repository _Insert5Rooms_Repository;
        public Insert5Rooms_Repository Insert5Rooms { get { return _Insert5Rooms_Repository ?? (_Insert5Rooms_Repository = (Insert5Rooms_Repository)Rhetos.Extensibility.NamedPluginsExtensions.GetPlugin(_repositories, @"Hoteli.Insert5Rooms")); } }

        private Insert6Rooms_Repository _Insert6Rooms_Repository;
        public Insert6Rooms_Repository Insert6Rooms { get { return _Insert6Rooms_Repository ?? (_Insert6Rooms_Repository = (Insert6Rooms_Repository)Rhetos.Extensibility.NamedPluginsExtensions.GetPlugin(_repositories, @"Hoteli.Insert6Rooms")); } }

        private ReservationInfo_Repository _ReservationInfo_Repository;
        public ReservationInfo_Repository ReservationInfo { get { return _ReservationInfo_Repository ?? (_ReservationInfo_Repository = (ReservationInfo_Repository)Rhetos.Extensibility.NamedPluginsExtensions.GetPlugin(_repositories, @"Hoteli.ReservationInfo")); } }

        /*ModuleInfo RepositoryMembers Hoteli*/
    }

    /*DataStructureInfo RepositoryAttributes Hoteli.Hotel*/
    public class Hotel_Repository : /*DataStructureInfo OverrideBaseType Hoteli.Hotel*/ Common.OrmRepositoryBase<Common.Queryable.Hoteli_Hotel, Hoteli.Hotel> // Common.QueryableRepositoryBase<Common.Queryable.Hoteli_Hotel, Hoteli.Hotel> // Common.ReadableRepositoryBase<Hoteli.Hotel> // global::Common.RepositoryBase
        , IWritableRepository<Hoteli.Hotel>, IValidateRepository/*DataStructureInfo RepositoryInterface Hoteli.Hotel*/
    {
        private readonly Rhetos.Utilities.ISqlUtility _sqlUtility;
        /*DataStructureInfo RepositoryPrivateMembers Hoteli.Hotel*/

        public Hotel_Repository(Common.DomRepository domRepository, Common.ExecutionContext executionContext, Rhetos.Utilities.ISqlUtility _sqlUtility/*DataStructureInfo RepositoryConstructorArguments Hoteli.Hotel*/)
        {
            _domRepository = domRepository;
            _executionContext = executionContext;
            this._sqlUtility = _sqlUtility;
            /*DataStructureInfo RepositoryConstructorCode Hoteli.Hotel*/
        }

        [Obsolete("Use Load() or Query() method.")]
        public override global::Hoteli.Hotel[] All()
        {
            return Query().ToSimple().ToArray();
        }

        public override IQueryable<Common.Queryable.Hoteli_Hotel> Query()
        {
            /*DataStructureInfo RepositoryBeforeQuery Hoteli.Hotel*/
            return _executionContext.EntityFrameworkContext.Hoteli_Hotel.AsNoTracking();
        }

        public void Save(IEnumerable<Hoteli.Hotel> insertedNew, IEnumerable<Hoteli.Hotel> updatedNew, IEnumerable<Hoteli.Hotel> deletedIds, bool checkUserPermissions = false)
        {
            if (!DomHelper.CleanUpSaveMethodArguments(ref insertedNew, ref updatedNew, ref deletedIds))
                return;

            /*DataStructureInfo WritableOrm ClearContext Hoteli.Hotel*/

            {
                var invalidItem = insertedNew.Concat(updatedNew).Where(newItem => newItem.Code != null && newItem.Code.Length > 256).FirstOrDefault();
                if (invalidItem != null)
                    throw new Rhetos.UserException(
                        "Maximum length of property {0} is {1}.",
                        new[] { "Hotel.Code", "256" },
                        "DataStructure:Hoteli.Hotel,ID:" + invalidItem.ID.ToString() + ",Property:Code",
                        null);
            }
            {
                var invalidItem = insertedNew.Concat(updatedNew).Where(newItem => newItem.Name != null && newItem.Name.Length > 256).FirstOrDefault();
                if (invalidItem != null)
                    throw new Rhetos.UserException(
                        "Maximum length of property {0} is {1}.",
                        new[] { "Hotel.Name", "256" },
                        "DataStructure:Hoteli.Hotel,ID:" + invalidItem.ID.ToString() + ",Property:Name",
                        null);
            }
            /*DataStructureInfo WritableOrm ArgumentValidation Hoteli.Hotel*/

            /*DataStructureInfo WritableOrm Initialization Hoteli.Hotel*/

            // Using old data, including lazy loading of navigation properties:
            IEnumerable<Common.Queryable.Hoteli_Hotel> deleted = this.Query(deletedIds.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Hoteli_Hotel>)deleted, deletedIds.Select(item => item.ID), item => item.ID);
            IEnumerable<Common.Queryable.Hoteli_Hotel> updated = this.Query(updatedNew.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Hoteli_Hotel>)updated, updatedNew.Select(item => item.ID), item => item.ID);

            AutoCodeHelper.UpdateCodesWithoutCache(
                _executionContext.SqlExecuter, "Hoteli.Hotel", "Code",
                insertedNew.Select(item => AutoCodeItem.Create(item, item.Code/*AutoCodePropertyInfo Grouping Hoteli.Hotel.Code*/)).ToList(),
                (item, newCode) => item.Code = newCode/*AutoCodePropertyInfo GroupColumnMetadata Hoteli.Hotel.Code*/);

            if (deletedIds.Count() > 0)
            {
                List<Hoteli.Location> childItems = _executionContext.Repository.Hoteli.Location
                    .Query(deletedIds.Select(parent => parent.ID))
                    .Select(child => child.ID).ToList()
                    .Select(childId => new Hoteli.Location { ID = childId }).ToList();

                if (childItems.Count() > 0)
                    _domRepository.Hoteli.Location.Delete(childItems);
            }

            /*DataStructureInfo WritableOrm OldDataLoaded Hoteli.Hotel*/

            /*DataStructureInfo WritableOrm ProcessedOldData Hoteli.Hotel*/

            DomHelper.SaveOperation saveOperation = DomHelper.SaveOperation.None;
            try
            {
                if (deletedIds.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Delete;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in deletedIds.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (updatedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Update;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in updatedNew.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (insertedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Insert;
                    _executionContext.EntityFrameworkContext.Hoteli_Hotel.AddRange(insertedNew.Select(item => item.ToNavigation()));
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                saveOperation = DomHelper.SaveOperation.None;
                _executionContext.EntityFrameworkContext.ClearCache();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException saveException)
            {
                DomHelper.ThrowIfSavingNonexistentId(saveException, checkUserPermissions, saveOperation);
        		Rhetos.RhetosException interpretedException = _sqlUtility.InterpretSqlException(saveException);
        		if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnDelete(interpretedException, @"Hoteli.Location", @"ID", @"FK_Location_Hotel_ID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Hoteli.Location,Property:ID,Referenced:Hoteli.Hotel";
                if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnDelete(interpretedException, @"Hoteli.Rooms", @"RoomOfHotelID", @"FK_Rooms_Hotel_RoomOfHotelID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Hoteli.Rooms,Property:RoomOfHotelID,Referenced:Hoteli.Hotel";
                if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnDelete(interpretedException, @"Hoteli.SaloonHotel", @"OwnerNameID", @"FK_SaloonHotel_Hotel_OwnerNameID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Hoteli.SaloonHotel,Property:OwnerNameID,Referenced:Hoteli.Hotel";
                if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnDelete(interpretedException, @"Hoteli.Saloon", @"HotelSaloonID", @"FK_Saloon_Hotel_HotelSaloonID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Hoteli.Saloon,Property:HotelSaloonID,Referenced:Hoteli.Hotel";
                if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnDelete(interpretedException, @"Hoteli.ProductHotel", @"OwnerNameID", @"FK_ProductHotel_Hotel_OwnerNameID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Hoteli.ProductHotel,Property:OwnerNameID,Referenced:Hoteli.Hotel";
                if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnDelete(interpretedException, @"Hoteli.Product", @"HotelSaloonID", @"FK_Product_Hotel_HotelSaloonID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Hoteli.Product,Property:HotelSaloonID,Referenced:Hoteli.Hotel";
                if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsUniqueError(interpretedException, @"Hoteli.Hotel", @"IX_Hotel_Code"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Hoteli.Hotel,Property:Code";
                /*DataStructureInfo WritableOrm OnDatabaseError Hoteli.Hotel*/
                if (checkUserPermissions)
                    Rhetos.Utilities.MsSqlUtility.ThrowIfPrimaryKeyErrorOnInsert(interpretedException, "Hoteli.Hotel");

                if (interpretedException != null)
        			Rhetos.Utilities.ExceptionsUtility.Rethrow(interpretedException);
                var sqlException = _sqlUtility.ExtractSqlException(saveException);
                if (sqlException != null)
                    Rhetos.Utilities.ExceptionsUtility.Rethrow(sqlException);
                throw;
            }

            deleted = null;
            updated = this.Query(updatedNew.Select(item => item.ID));
            IEnumerable<Common.Queryable.Hoteli_Hotel> inserted = this.Query(insertedNew.Select(item => item.ID));

            bool allEffectsCompleted = false;
            try
            {
                /*DataStructureInfo WritableOrm OnSaveTag1 Hoteli.Hotel*/

                /*DataStructureInfo WritableOrm OnSaveTag2 Hoteli.Hotel*/

                Rhetos.Dom.DefaultConcepts.InvalidDataMessage.ValidateOnSave(insertedNew, updatedNew, this, "Hoteli.Hotel");

                /*DataStructureInfo WritableOrm AfterSave Hoteli.Hotel*/

                allEffectsCompleted = true;
            }
            finally
            {
                if (!allEffectsCompleted)
                    _executionContext.PersistenceTransaction.DiscardChanges();
            }
        }

        public IEnumerable<Rhetos.Dom.DefaultConcepts.InvalidDataMessage> Validate(IList<Guid> ids, bool onSave)
        {
            if (onSave)
            {
                var errorIds = this.Filter(this.Query(ids), new SystemRequiredCode()).Select(item => item.ID).ToArray();
                if (errorIds.Count() > 0)
                    foreach (var error in GetErrorMessage_SystemRequiredCode(errorIds))
                        yield return error;
            }
            /*DataStructureInfo WritableOrm OnSaveValidate Hoteli.Hotel*/
            yield break;
        }

        public IEnumerable<InvalidDataMessage> GetErrorMessage_SystemRequiredCode(IEnumerable<Guid> invalidData_Ids)
        {
            const string invalidData_Description = @"System required property {0} is not set.";
            IDictionary<string, object> metadata = new Dictionary<string, object>();
            metadata["Validation"] = @"SystemRequiredCode";
            metadata[@"Property"] = @"Code";
            /*InvalidDataInfo ErrorMetadata Hoteli.Hotel.SystemRequiredCode*/
            return invalidData_Ids.Select(id => new InvalidDataMessage
            {
                ID = id,
                Message = invalidData_Description,
                MessageParameters = new object[] { @"ShortString Hoteli.Hotel.Code" },
                Metadata = metadata
            });
            // /*InvalidDataInfo OverrideUserMessages Hoteli.Hotel.SystemRequiredCode*/ return invalidData_Ids.Select(id => new InvalidDataMessage { ID = id, Message = invalidData_Description, Metadata = metadata });
        }

        public IQueryable<Common.Queryable.Hoteli_Hotel> Filter(IQueryable<Common.Queryable.Hoteli_Hotel> localSource, Hoteli.SystemRequiredCode localParameter)
        {
            Func<IQueryable<Common.Queryable.Hoteli_Hotel>, Common.DomRepository, Hoteli.SystemRequiredCode/*ComposableFilterByInfo AdditionalParametersType Hoteli.Hotel.'Hoteli.SystemRequiredCode'*/, IQueryable<Common.Queryable.Hoteli_Hotel>> filterFunction =
            (source, repository, parameter) => source.Where(item => item.Code == null);

            /*ComposableFilterByInfo BeforeFilter Hoteli.Hotel.'Hoteli.SystemRequiredCode'*/
            return filterFunction(localSource, _domRepository, localParameter/*ComposableFilterByInfo AdditionalParametersArgument Hoteli.Hotel.'Hoteli.SystemRequiredCode'*/);
        }

        public global::Hoteli.Hotel[] Filter(Hoteli.SystemRequiredCode filter_Parameter)
        {
            Func<Common.DomRepository, Hoteli.SystemRequiredCode/*FilterByInfo AdditionalParametersType Hoteli.Hotel.'Hoteli.SystemRequiredCode'*/, Hoteli.Hotel[]> filter_Function =
                (repository, parameter) => repository.Hoteli.Hotel.Filter(repository.Hoteli.Hotel.Query(), parameter).ToArray();

            return filter_Function(_domRepository, filter_Parameter/*FilterByInfo AdditionalParametersArgument Hoteli.Hotel.'Hoteli.SystemRequiredCode'*/);
        }

        /*DataStructureInfo RepositoryMembers Hoteli.Hotel*/
    }

    /*DataStructureInfo RepositoryAttributes Hoteli.Location*/
    public class Location_Repository : /*DataStructureInfo OverrideBaseType Hoteli.Location*/ Common.OrmRepositoryBase<Common.Queryable.Hoteli_Location, Hoteli.Location> // Common.QueryableRepositoryBase<Common.Queryable.Hoteli_Location, Hoteli.Location> // Common.ReadableRepositoryBase<Hoteli.Location> // global::Common.RepositoryBase
        , IWritableRepository<Hoteli.Location>, IValidateRepository/*DataStructureInfo RepositoryInterface Hoteli.Location*/
    {
        private readonly Rhetos.Utilities.ISqlUtility _sqlUtility;
        /*DataStructureInfo RepositoryPrivateMembers Hoteli.Location*/

        public Location_Repository(Common.DomRepository domRepository, Common.ExecutionContext executionContext, Rhetos.Utilities.ISqlUtility _sqlUtility/*DataStructureInfo RepositoryConstructorArguments Hoteli.Location*/)
        {
            _domRepository = domRepository;
            _executionContext = executionContext;
            this._sqlUtility = _sqlUtility;
            /*DataStructureInfo RepositoryConstructorCode Hoteli.Location*/
        }

        [Obsolete("Use Load() or Query() method.")]
        public override global::Hoteli.Location[] All()
        {
            return Query().ToSimple().ToArray();
        }

        public override IQueryable<Common.Queryable.Hoteli_Location> Query()
        {
            /*DataStructureInfo RepositoryBeforeQuery Hoteli.Location*/
            return _executionContext.EntityFrameworkContext.Hoteli_Location.AsNoTracking();
        }

        public void Save(IEnumerable<Hoteli.Location> insertedNew, IEnumerable<Hoteli.Location> updatedNew, IEnumerable<Hoteli.Location> deletedIds, bool checkUserPermissions = false)
        {
            if (!DomHelper.CleanUpSaveMethodArguments(ref insertedNew, ref updatedNew, ref deletedIds))
                return;

            /*DataStructureInfo WritableOrm ClearContext Hoteli.Location*/

            {
                var invalidItem = insertedNew.Concat(updatedNew).Where(newItem => newItem.Code != null && newItem.Code.Length > 256).FirstOrDefault();
                if (invalidItem != null)
                    throw new Rhetos.UserException(
                        "Maximum length of property {0} is {1}.",
                        new[] { "Location.Code", "256" },
                        "DataStructure:Hoteli.Location,ID:" + invalidItem.ID.ToString() + ",Property:Code",
                        null);
            }
            {
                var invalidItem = insertedNew.Concat(updatedNew).Where(newItem => newItem.Country != null && newItem.Country.Length > 256).FirstOrDefault();
                if (invalidItem != null)
                    throw new Rhetos.UserException(
                        "Maximum length of property {0} is {1}.",
                        new[] { "Location.Country", "256" },
                        "DataStructure:Hoteli.Location,ID:" + invalidItem.ID.ToString() + ",Property:Country",
                        null);
            }
            {
                var invalidItem = insertedNew.Concat(updatedNew).Where(newItem => newItem.County != null && newItem.County.Length > 256).FirstOrDefault();
                if (invalidItem != null)
                    throw new Rhetos.UserException(
                        "Maximum length of property {0} is {1}.",
                        new[] { "Location.County", "256" },
                        "DataStructure:Hoteli.Location,ID:" + invalidItem.ID.ToString() + ",Property:County",
                        null);
            }
            {
                var invalidItem = insertedNew.Concat(updatedNew).Where(newItem => newItem.City != null && newItem.City.Length > 256).FirstOrDefault();
                if (invalidItem != null)
                    throw new Rhetos.UserException(
                        "Maximum length of property {0} is {1}.",
                        new[] { "Location.City", "256" },
                        "DataStructure:Hoteli.Location,ID:" + invalidItem.ID.ToString() + ",Property:City",
                        null);
            }
            {
                var invalidItem = insertedNew.Concat(updatedNew).Where(newItem => newItem.Area != null && newItem.Area.Length > 256).FirstOrDefault();
                if (invalidItem != null)
                    throw new Rhetos.UserException(
                        "Maximum length of property {0} is {1}.",
                        new[] { "Location.Area", "256" },
                        "DataStructure:Hoteli.Location,ID:" + invalidItem.ID.ToString() + ",Property:Area",
                        null);
            }
            /*DataStructureInfo WritableOrm ArgumentValidation Hoteli.Location*/

            /*DataStructureInfo WritableOrm Initialization Hoteli.Location*/

            // Using old data, including lazy loading of navigation properties:
            IEnumerable<Common.Queryable.Hoteli_Location> deleted = this.Query(deletedIds.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Hoteli_Location>)deleted, deletedIds.Select(item => item.ID), item => item.ID);
            IEnumerable<Common.Queryable.Hoteli_Location> updated = this.Query(updatedNew.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Hoteli_Location>)updated, updatedNew.Select(item => item.ID), item => item.ID);

            AutoCodeHelper.UpdateCodesWithoutCache(
                _executionContext.SqlExecuter, "Hoteli.Location", "Code",
                insertedNew.Select(item => AutoCodeItem.Create(item, item.Code/*AutoCodePropertyInfo Grouping Hoteli.Location.Code*/)).ToList(),
                (item, newCode) => item.Code = newCode/*AutoCodePropertyInfo GroupColumnMetadata Hoteli.Location.Code*/);

            /*DataStructureInfo WritableOrm OldDataLoaded Hoteli.Location*/

            /*DataStructureInfo WritableOrm ProcessedOldData Hoteli.Location*/

            DomHelper.SaveOperation saveOperation = DomHelper.SaveOperation.None;
            try
            {
                if (deletedIds.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Delete;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in deletedIds.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (updatedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Update;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in updatedNew.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (insertedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Insert;
                    _executionContext.EntityFrameworkContext.Hoteli_Location.AddRange(insertedNew.Select(item => item.ToNavigation()));
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                saveOperation = DomHelper.SaveOperation.None;
                _executionContext.EntityFrameworkContext.ClearCache();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException saveException)
            {
                DomHelper.ThrowIfSavingNonexistentId(saveException, checkUserPermissions, saveOperation);
        		Rhetos.RhetosException interpretedException = _sqlUtility.InterpretSqlException(saveException);
        		if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsUniqueError(interpretedException, @"Hoteli.Location", @"IX_Location_Code"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Hoteli.Location,Property:Code";
                /*DataStructureInfo WritableOrm OnDatabaseError Hoteli.Location*/
                if (checkUserPermissions)
                    Rhetos.Utilities.MsSqlUtility.ThrowIfPrimaryKeyErrorOnInsert(interpretedException, "Hoteli.Location");

                if (interpretedException != null)
        			Rhetos.Utilities.ExceptionsUtility.Rethrow(interpretedException);
                var sqlException = _sqlUtility.ExtractSqlException(saveException);
                if (sqlException != null)
                    Rhetos.Utilities.ExceptionsUtility.Rethrow(sqlException);
                throw;
            }

            deleted = null;
            updated = this.Query(updatedNew.Select(item => item.ID));
            IEnumerable<Common.Queryable.Hoteli_Location> inserted = this.Query(insertedNew.Select(item => item.ID));

            bool allEffectsCompleted = false;
            try
            {
                /*DataStructureInfo WritableOrm OnSaveTag1 Hoteli.Location*/

                /*DataStructureInfo WritableOrm OnSaveTag2 Hoteli.Location*/

                Rhetos.Dom.DefaultConcepts.InvalidDataMessage.ValidateOnSave(insertedNew, updatedNew, this, "Hoteli.Location");

                /*DataStructureInfo WritableOrm AfterSave Hoteli.Location*/

                allEffectsCompleted = true;
            }
            finally
            {
                if (!allEffectsCompleted)
                    _executionContext.PersistenceTransaction.DiscardChanges();
            }
        }

        public IEnumerable<Rhetos.Dom.DefaultConcepts.InvalidDataMessage> Validate(IList<Guid> ids, bool onSave)
        {
            if (onSave)
            {
                var errorIds = this.Filter(this.Query(ids), new SystemRequiredCode()).Select(item => item.ID).ToArray();
                if (errorIds.Count() > 0)
                    foreach (var error in GetErrorMessage_SystemRequiredCode(errorIds))
                        yield return error;
            }
            /*DataStructureInfo WritableOrm OnSaveValidate Hoteli.Location*/
            yield break;
        }

        public IEnumerable<InvalidDataMessage> GetErrorMessage_SystemRequiredCode(IEnumerable<Guid> invalidData_Ids)
        {
            const string invalidData_Description = @"System required property {0} is not set.";
            IDictionary<string, object> metadata = new Dictionary<string, object>();
            metadata["Validation"] = @"SystemRequiredCode";
            metadata[@"Property"] = @"Code";
            /*InvalidDataInfo ErrorMetadata Hoteli.Location.SystemRequiredCode*/
            return invalidData_Ids.Select(id => new InvalidDataMessage
            {
                ID = id,
                Message = invalidData_Description,
                MessageParameters = new object[] { @"ShortString Hoteli.Location.Code" },
                Metadata = metadata
            });
            // /*InvalidDataInfo OverrideUserMessages Hoteli.Location.SystemRequiredCode*/ return invalidData_Ids.Select(id => new InvalidDataMessage { ID = id, Message = invalidData_Description, Metadata = metadata });
        }

        public IQueryable<Common.Queryable.Hoteli_Location> Filter(IQueryable<Common.Queryable.Hoteli_Location> localSource, Hoteli.SystemRequiredCode localParameter)
        {
            Func<IQueryable<Common.Queryable.Hoteli_Location>, Common.DomRepository, Hoteli.SystemRequiredCode/*ComposableFilterByInfo AdditionalParametersType Hoteli.Location.'Hoteli.SystemRequiredCode'*/, IQueryable<Common.Queryable.Hoteli_Location>> filterFunction =
            (source, repository, parameter) => source.Where(item => item.Code == null);

            /*ComposableFilterByInfo BeforeFilter Hoteli.Location.'Hoteli.SystemRequiredCode'*/
            return filterFunction(localSource, _domRepository, localParameter/*ComposableFilterByInfo AdditionalParametersArgument Hoteli.Location.'Hoteli.SystemRequiredCode'*/);
        }

        public global::Hoteli.Location[] Filter(Hoteli.SystemRequiredCode filter_Parameter)
        {
            Func<Common.DomRepository, Hoteli.SystemRequiredCode/*FilterByInfo AdditionalParametersType Hoteli.Location.'Hoteli.SystemRequiredCode'*/, Hoteli.Location[]> filter_Function =
                (repository, parameter) => repository.Hoteli.Location.Filter(repository.Hoteli.Location.Query(), parameter).ToArray();

            return filter_Function(_domRepository, filter_Parameter/*FilterByInfo AdditionalParametersArgument Hoteli.Location.'Hoteli.SystemRequiredCode'*/);
        }

        /*DataStructureInfo RepositoryMembers Hoteli.Location*/
    }

    /*DataStructureInfo RepositoryAttributes Hoteli.RoomReservation*/
    public class RoomReservation_Repository : /*DataStructureInfo OverrideBaseType Hoteli.RoomReservation*/ Common.OrmRepositoryBase<Common.Queryable.Hoteli_RoomReservation, Hoteli.RoomReservation> // Common.QueryableRepositoryBase<Common.Queryable.Hoteli_RoomReservation, Hoteli.RoomReservation> // Common.ReadableRepositoryBase<Hoteli.RoomReservation> // global::Common.RepositoryBase
        , IWritableRepository<Hoteli.RoomReservation>, IValidateRepository/*DataStructureInfo RepositoryInterface Hoteli.RoomReservation*/
    {
        private readonly Rhetos.Utilities.ISqlUtility _sqlUtility;
        /*DataStructureInfo RepositoryPrivateMembers Hoteli.RoomReservation*/

        public RoomReservation_Repository(Common.DomRepository domRepository, Common.ExecutionContext executionContext, Rhetos.Utilities.ISqlUtility _sqlUtility/*DataStructureInfo RepositoryConstructorArguments Hoteli.RoomReservation*/)
        {
            _domRepository = domRepository;
            _executionContext = executionContext;
            this._sqlUtility = _sqlUtility;
            /*DataStructureInfo RepositoryConstructorCode Hoteli.RoomReservation*/
        }

        [Obsolete("Use Load() or Query() method.")]
        public override global::Hoteli.RoomReservation[] All()
        {
            return Query().ToSimple().ToArray();
        }

        public override IQueryable<Common.Queryable.Hoteli_RoomReservation> Query()
        {
            /*DataStructureInfo RepositoryBeforeQuery Hoteli.RoomReservation*/
            return _executionContext.EntityFrameworkContext.Hoteli_RoomReservation.AsNoTracking();
        }

        public void Save(IEnumerable<Hoteli.RoomReservation> insertedNew, IEnumerable<Hoteli.RoomReservation> updatedNew, IEnumerable<Hoteli.RoomReservation> deletedIds, bool checkUserPermissions = false)
        {
            if (!DomHelper.CleanUpSaveMethodArguments(ref insertedNew, ref updatedNew, ref deletedIds))
                return;

            /*DataStructureInfo WritableOrm ClearContext Hoteli.RoomReservation*/

            {
                var invalidItem = insertedNew.Concat(updatedNew).Where(newItem => newItem.Code != null && newItem.Code.Length > 256).FirstOrDefault();
                if (invalidItem != null)
                    throw new Rhetos.UserException(
                        "Maximum length of property {0} is {1}.",
                        new[] { "RoomReservation.Code", "256" },
                        "DataStructure:Hoteli.RoomReservation,ID:" + invalidItem.ID.ToString() + ",Property:Code",
                        null);
            }
            /*DataStructureInfo WritableOrm ArgumentValidation Hoteli.RoomReservation*/

            /*DataStructureInfo WritableOrm Initialization Hoteli.RoomReservation*/

            // Using old data, including lazy loading of navigation properties:
            IEnumerable<Common.Queryable.Hoteli_RoomReservation> deleted = this.Query(deletedIds.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Hoteli_RoomReservation>)deleted, deletedIds.Select(item => item.ID), item => item.ID);
            IEnumerable<Common.Queryable.Hoteli_RoomReservation> updated = this.Query(updatedNew.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Hoteli_RoomReservation>)updated, updatedNew.Select(item => item.ID), item => item.ID);

            AutoCodeHelper.UpdateCodesWithoutCache(
                _executionContext.SqlExecuter, "Hoteli.RoomReservation", "Code",
                insertedNew.Select(item => AutoCodeItem.Create(item, item.Code/*AutoCodePropertyInfo Grouping Hoteli.RoomReservation.Code*/)).ToList(),
                (item, newCode) => item.Code = newCode/*AutoCodePropertyInfo GroupColumnMetadata Hoteli.RoomReservation.Code*/);

            /*DataStructureInfo WritableOrm OldDataLoaded Hoteli.RoomReservation*/

            /*DataStructureInfo WritableOrm ProcessedOldData Hoteli.RoomReservation*/

            DomHelper.SaveOperation saveOperation = DomHelper.SaveOperation.None;
            try
            {
                if (deletedIds.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Delete;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in deletedIds.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (updatedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Update;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in updatedNew.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (insertedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Insert;
                    _executionContext.EntityFrameworkContext.Hoteli_RoomReservation.AddRange(insertedNew.Select(item => item.ToNavigation()));
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                saveOperation = DomHelper.SaveOperation.None;
                _executionContext.EntityFrameworkContext.ClearCache();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException saveException)
            {
                DomHelper.ThrowIfSavingNonexistentId(saveException, checkUserPermissions, saveOperation);
        		Rhetos.RhetosException interpretedException = _sqlUtility.InterpretSqlException(saveException);
        		if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnInsertUpdate(interpretedException, @"Hoteli.Reservation", @"ID", @"FK_RoomReservation_Reservation_ReservationHotelID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Hoteli.RoomReservation,Property:ReservationHotelID,Referenced:Hoteli.Reservation";
                if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnInsertUpdate(interpretedException, @"Hoteli.Rooms", @"ID", @"FK_RoomReservation_Rooms_ReservationRoomID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Hoteli.RoomReservation,Property:ReservationRoomID,Referenced:Hoteli.Rooms";
                if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsUniqueError(interpretedException, @"Hoteli.RoomReservation", @"IX_RoomReservation_Code"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Hoteli.RoomReservation,Property:Code";
                /*DataStructureInfo WritableOrm OnDatabaseError Hoteli.RoomReservation*/
                if (checkUserPermissions)
                    Rhetos.Utilities.MsSqlUtility.ThrowIfPrimaryKeyErrorOnInsert(interpretedException, "Hoteli.RoomReservation");

                if (interpretedException != null)
        			Rhetos.Utilities.ExceptionsUtility.Rethrow(interpretedException);
                var sqlException = _sqlUtility.ExtractSqlException(saveException);
                if (sqlException != null)
                    Rhetos.Utilities.ExceptionsUtility.Rethrow(sqlException);
                throw;
            }

            deleted = null;
            updated = this.Query(updatedNew.Select(item => item.ID));
            IEnumerable<Common.Queryable.Hoteli_RoomReservation> inserted = this.Query(insertedNew.Select(item => item.ID));

            bool allEffectsCompleted = false;
            try
            {
                /*DataStructureInfo WritableOrm OnSaveTag1 Hoteli.RoomReservation*/

                /*DataStructureInfo WritableOrm OnSaveTag2 Hoteli.RoomReservation*/

                Rhetos.Dom.DefaultConcepts.InvalidDataMessage.ValidateOnSave(insertedNew, updatedNew, this, "Hoteli.RoomReservation");

                /*DataStructureInfo WritableOrm AfterSave Hoteli.RoomReservation*/

                allEffectsCompleted = true;
            }
            finally
            {
                if (!allEffectsCompleted)
                    _executionContext.PersistenceTransaction.DiscardChanges();
            }
        }

        public IEnumerable<Rhetos.Dom.DefaultConcepts.InvalidDataMessage> Validate(IList<Guid> ids, bool onSave)
        {
            if (onSave)
            {
                var errorIds = this.Filter(this.Query(ids), new SystemRequiredCode()).Select(item => item.ID).ToArray();
                if (errorIds.Count() > 0)
                    foreach (var error in GetErrorMessage_SystemRequiredCode(errorIds))
                        yield return error;
            }
            /*DataStructureInfo WritableOrm OnSaveValidate Hoteli.RoomReservation*/
            yield break;
        }

        public IEnumerable<InvalidDataMessage> GetErrorMessage_SystemRequiredCode(IEnumerable<Guid> invalidData_Ids)
        {
            const string invalidData_Description = @"System required property {0} is not set.";
            IDictionary<string, object> metadata = new Dictionary<string, object>();
            metadata["Validation"] = @"SystemRequiredCode";
            metadata[@"Property"] = @"Code";
            /*InvalidDataInfo ErrorMetadata Hoteli.RoomReservation.SystemRequiredCode*/
            return invalidData_Ids.Select(id => new InvalidDataMessage
            {
                ID = id,
                Message = invalidData_Description,
                MessageParameters = new object[] { @"ShortString Hoteli.RoomReservation.Code" },
                Metadata = metadata
            });
            // /*InvalidDataInfo OverrideUserMessages Hoteli.RoomReservation.SystemRequiredCode*/ return invalidData_Ids.Select(id => new InvalidDataMessage { ID = id, Message = invalidData_Description, Metadata = metadata });
        }

        public IQueryable<Common.Queryable.Hoteli_RoomReservation> Filter(IQueryable<Common.Queryable.Hoteli_RoomReservation> localSource, Hoteli.SystemRequiredCode localParameter)
        {
            Func<IQueryable<Common.Queryable.Hoteli_RoomReservation>, Common.DomRepository, Hoteli.SystemRequiredCode/*ComposableFilterByInfo AdditionalParametersType Hoteli.RoomReservation.'Hoteli.SystemRequiredCode'*/, IQueryable<Common.Queryable.Hoteli_RoomReservation>> filterFunction =
            (source, repository, parameter) => source.Where(item => item.Code == null);

            /*ComposableFilterByInfo BeforeFilter Hoteli.RoomReservation.'Hoteli.SystemRequiredCode'*/
            return filterFunction(localSource, _domRepository, localParameter/*ComposableFilterByInfo AdditionalParametersArgument Hoteli.RoomReservation.'Hoteli.SystemRequiredCode'*/);
        }

        public global::Hoteli.RoomReservation[] Filter(Hoteli.SystemRequiredCode filter_Parameter)
        {
            Func<Common.DomRepository, Hoteli.SystemRequiredCode/*FilterByInfo AdditionalParametersType Hoteli.RoomReservation.'Hoteli.SystemRequiredCode'*/, Hoteli.RoomReservation[]> filter_Function =
                (repository, parameter) => repository.Hoteli.RoomReservation.Filter(repository.Hoteli.RoomReservation.Query(), parameter).ToArray();

            return filter_Function(_domRepository, filter_Parameter/*FilterByInfo AdditionalParametersArgument Hoteli.RoomReservation.'Hoteli.SystemRequiredCode'*/);
        }

        /*DataStructureInfo RepositoryMembers Hoteli.RoomReservation*/
    }

    /*DataStructureInfo RepositoryAttributes Hoteli.Reservation*/
    public class Reservation_Repository : /*DataStructureInfo OverrideBaseType Hoteli.Reservation*/ Common.OrmRepositoryBase<Common.Queryable.Hoteli_Reservation, Hoteli.Reservation> // Common.QueryableRepositoryBase<Common.Queryable.Hoteli_Reservation, Hoteli.Reservation> // Common.ReadableRepositoryBase<Hoteli.Reservation> // global::Common.RepositoryBase
        , IWritableRepository<Hoteli.Reservation>, IValidateRepository/*DataStructureInfo RepositoryInterface Hoteli.Reservation*/
    {
        private readonly Rhetos.Utilities.ISqlUtility _sqlUtility;
        /*DataStructureInfo RepositoryPrivateMembers Hoteli.Reservation*/

        public Reservation_Repository(Common.DomRepository domRepository, Common.ExecutionContext executionContext, Rhetos.Utilities.ISqlUtility _sqlUtility/*DataStructureInfo RepositoryConstructorArguments Hoteli.Reservation*/)
        {
            _domRepository = domRepository;
            _executionContext = executionContext;
            this._sqlUtility = _sqlUtility;
            /*DataStructureInfo RepositoryConstructorCode Hoteli.Reservation*/
        }

        [Obsolete("Use Load() or Query() method.")]
        public override global::Hoteli.Reservation[] All()
        {
            return Query().ToSimple().ToArray();
        }

        public override IQueryable<Common.Queryable.Hoteli_Reservation> Query()
        {
            /*DataStructureInfo RepositoryBeforeQuery Hoteli.Reservation*/
            return _executionContext.EntityFrameworkContext.Hoteli_Reservation.AsNoTracking();
        }

        public void Save(IEnumerable<Hoteli.Reservation> insertedNew, IEnumerable<Hoteli.Reservation> updatedNew, IEnumerable<Hoteli.Reservation> deletedIds, bool checkUserPermissions = false)
        {
            if (!DomHelper.CleanUpSaveMethodArguments(ref insertedNew, ref updatedNew, ref deletedIds))
                return;

            /*DataStructureInfo WritableOrm ClearContext Hoteli.Reservation*/

            {
                var invalidItem = insertedNew.Concat(updatedNew).Where(newItem => newItem.Code != null && newItem.Code.Length > 256).FirstOrDefault();
                if (invalidItem != null)
                    throw new Rhetos.UserException(
                        "Maximum length of property {0} is {1}.",
                        new[] { "Reservation.Code", "256" },
                        "DataStructure:Hoteli.Reservation,ID:" + invalidItem.ID.ToString() + ",Property:Code",
                        null);
            }
            /*DataStructureInfo WritableOrm ArgumentValidation Hoteli.Reservation*/

            /*DataStructureInfo WritableOrm Initialization Hoteli.Reservation*/

            // Using old data, including lazy loading of navigation properties:
            IEnumerable<Common.Queryable.Hoteli_Reservation> deleted = this.Query(deletedIds.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Hoteli_Reservation>)deleted, deletedIds.Select(item => item.ID), item => item.ID);
            IEnumerable<Common.Queryable.Hoteli_Reservation> updated = this.Query(updatedNew.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Hoteli_Reservation>)updated, updatedNew.Select(item => item.ID), item => item.ID);

            AutoCodeHelper.UpdateCodesWithoutCache(
                _executionContext.SqlExecuter, "Hoteli.Reservation", "Code",
                insertedNew.Select(item => AutoCodeItem.Create(item, item.Code/*AutoCodePropertyInfo Grouping Hoteli.Reservation.Code*/)).ToList(),
                (item, newCode) => item.Code = newCode/*AutoCodePropertyInfo GroupColumnMetadata Hoteli.Reservation.Code*/);

            if (updatedNew.Count() > 0 || deletedIds.Count() > 0)
            {
                Hoteli.Reservation[] changedItems = updated.Zip(updatedNew, (i, j) => (i.DateTo == null && j.DateTo != null || i.DateTo != null && !i.DateTo.Equals(j.DateTo))
                    ? i : null).Where(x => x != null).ToArray();

                if (changedItems != null && changedItems.Length > 0)
                {
                    var lockedItems = _domRepository.Hoteli.Reservation.Filter(this.Query(changedItems.Select(item => item.ID)), new Negative());
                    if (lockedItems.Count() > 0)
                        throw new Rhetos.UserException(@"Dates are negative impossible to insert", "DataStructure:Hoteli.Reservation,ID:" + lockedItems.First().ID.ToString() + ",Property:DateTo");
                }
            }
            /*DataStructureInfo WritableOrm OldDataLoaded Hoteli.Reservation*/

            /*DataStructureInfo WritableOrm ProcessedOldData Hoteli.Reservation*/

            DomHelper.SaveOperation saveOperation = DomHelper.SaveOperation.None;
            try
            {
                if (deletedIds.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Delete;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in deletedIds.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (updatedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Update;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in updatedNew.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (insertedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Insert;
                    _executionContext.EntityFrameworkContext.Hoteli_Reservation.AddRange(insertedNew.Select(item => item.ToNavigation()));
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                saveOperation = DomHelper.SaveOperation.None;
                _executionContext.EntityFrameworkContext.ClearCache();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException saveException)
            {
                DomHelper.ThrowIfSavingNonexistentId(saveException, checkUserPermissions, saveOperation);
        		Rhetos.RhetosException interpretedException = _sqlUtility.InterpretSqlException(saveException);
        		if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnDelete(interpretedException, @"Hoteli.RoomReservation", @"ReservationHotelID", @"FK_RoomReservation_Reservation_ReservationHotelID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Hoteli.RoomReservation,Property:ReservationHotelID,Referenced:Hoteli.Reservation";
                if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnInsertUpdate(interpretedException, @"Hoteli.Person", @"ID", @"FK_Reservation_Person_GuestID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Hoteli.Reservation,Property:GuestID,Referenced:Hoteli.Person";
                if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsUniqueError(interpretedException, @"Hoteli.Reservation", @"IX_Reservation_Code"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Hoteli.Reservation,Property:Code";
                /*DataStructureInfo WritableOrm OnDatabaseError Hoteli.Reservation*/
                if (checkUserPermissions)
                    Rhetos.Utilities.MsSqlUtility.ThrowIfPrimaryKeyErrorOnInsert(interpretedException, "Hoteli.Reservation");

                if (interpretedException != null)
        			Rhetos.Utilities.ExceptionsUtility.Rethrow(interpretedException);
                var sqlException = _sqlUtility.ExtractSqlException(saveException);
                if (sqlException != null)
                    Rhetos.Utilities.ExceptionsUtility.Rethrow(sqlException);
                throw;
            }

            deleted = null;
            updated = this.Query(updatedNew.Select(item => item.ID));
            IEnumerable<Common.Queryable.Hoteli_Reservation> inserted = this.Query(insertedNew.Select(item => item.ID));

            bool allEffectsCompleted = false;
            try
            {
                /*DataStructureInfo WritableOrm OnSaveTag1 Hoteli.Reservation*/

                /*DataStructureInfo WritableOrm OnSaveTag2 Hoteli.Reservation*/

                Rhetos.Dom.DefaultConcepts.InvalidDataMessage.ValidateOnSave(insertedNew, updatedNew, this, "Hoteli.Reservation");

                /*DataStructureInfo WritableOrm AfterSave Hoteli.Reservation*/

                allEffectsCompleted = true;
            }
            finally
            {
                if (!allEffectsCompleted)
                    _executionContext.PersistenceTransaction.DiscardChanges();
            }
        }

        public IEnumerable<Rhetos.Dom.DefaultConcepts.InvalidDataMessage> Validate(IList<Guid> ids, bool onSave)
        {
            if (onSave)
            {
                var errorIds = this.Filter(this.Query(ids), new SystemRequiredCode()).Select(item => item.ID).ToArray();
                if (errorIds.Count() > 0)
                    foreach (var error in GetErrorMessage_SystemRequiredCode(errorIds))
                        yield return error;
            }
            /*DataStructureInfo WritableOrm OnSaveValidate Hoteli.Reservation*/
            yield break;
        }

        public IEnumerable<InvalidDataMessage> GetErrorMessage_SystemRequiredCode(IEnumerable<Guid> invalidData_Ids)
        {
            const string invalidData_Description = @"System required property {0} is not set.";
            IDictionary<string, object> metadata = new Dictionary<string, object>();
            metadata["Validation"] = @"SystemRequiredCode";
            metadata[@"Property"] = @"Code";
            /*InvalidDataInfo ErrorMetadata Hoteli.Reservation.SystemRequiredCode*/
            return invalidData_Ids.Select(id => new InvalidDataMessage
            {
                ID = id,
                Message = invalidData_Description,
                MessageParameters = new object[] { @"ShortString Hoteli.Reservation.Code" },
                Metadata = metadata
            });
            // /*InvalidDataInfo OverrideUserMessages Hoteli.Reservation.SystemRequiredCode*/ return invalidData_Ids.Select(id => new InvalidDataMessage { ID = id, Message = invalidData_Description, Metadata = metadata });
        }

        public IQueryable<Common.Queryable.Hoteli_Reservation> Filter(IQueryable<Common.Queryable.Hoteli_Reservation> localSource, Hoteli.Negative localParameter)
        {
            Func<IQueryable<Common.Queryable.Hoteli_Reservation>, Common.DomRepository, Hoteli.Negative/*ComposableFilterByInfo AdditionalParametersType Hoteli.Reservation.'Hoteli.Negative'*/, IQueryable<Common.Queryable.Hoteli_Reservation>> filterFunction =
            (source, repository, parameter) => source.Where(item =>item.DateTo < DateTime.Now);

            /*ComposableFilterByInfo BeforeFilter Hoteli.Reservation.'Hoteli.Negative'*/
            return filterFunction(localSource, _domRepository, localParameter/*ComposableFilterByInfo AdditionalParametersArgument Hoteli.Reservation.'Hoteli.Negative'*/);
        }

        public IQueryable<Common.Queryable.Hoteli_Reservation> Filter(IQueryable<Common.Queryable.Hoteli_Reservation> localSource, Hoteli.SystemRequiredCode localParameter)
        {
            Func<IQueryable<Common.Queryable.Hoteli_Reservation>, Common.DomRepository, Hoteli.SystemRequiredCode/*ComposableFilterByInfo AdditionalParametersType Hoteli.Reservation.'Hoteli.SystemRequiredCode'*/, IQueryable<Common.Queryable.Hoteli_Reservation>> filterFunction =
            (source, repository, parameter) => source.Where(item => item.Code == null);

            /*ComposableFilterByInfo BeforeFilter Hoteli.Reservation.'Hoteli.SystemRequiredCode'*/
            return filterFunction(localSource, _domRepository, localParameter/*ComposableFilterByInfo AdditionalParametersArgument Hoteli.Reservation.'Hoteli.SystemRequiredCode'*/);
        }

        public global::Hoteli.Reservation[] Filter(Hoteli.Negative filter_Parameter)
        {
            Func<Common.DomRepository, Hoteli.Negative/*FilterByInfo AdditionalParametersType Hoteli.Reservation.'Hoteli.Negative'*/, Hoteli.Reservation[]> filter_Function =
                (repository, parameter) => repository.Hoteli.Reservation.Filter(repository.Hoteli.Reservation.Query(), parameter).ToArray();

            return filter_Function(_domRepository, filter_Parameter/*FilterByInfo AdditionalParametersArgument Hoteli.Reservation.'Hoteli.Negative'*/);
        }

        public global::Hoteli.Reservation[] Filter(Hoteli.SystemRequiredCode filter_Parameter)
        {
            Func<Common.DomRepository, Hoteli.SystemRequiredCode/*FilterByInfo AdditionalParametersType Hoteli.Reservation.'Hoteli.SystemRequiredCode'*/, Hoteli.Reservation[]> filter_Function =
                (repository, parameter) => repository.Hoteli.Reservation.Filter(repository.Hoteli.Reservation.Query(), parameter).ToArray();

            return filter_Function(_domRepository, filter_Parameter/*FilterByInfo AdditionalParametersArgument Hoteli.Reservation.'Hoteli.SystemRequiredCode'*/);
        }

        /*DataStructureInfo RepositoryMembers Hoteli.Reservation*/
    }

    /*DataStructureInfo RepositoryAttributes Hoteli.Rooms*/
    public class Rooms_Repository : /*DataStructureInfo OverrideBaseType Hoteli.Rooms*/ Common.OrmRepositoryBase<Common.Queryable.Hoteli_Rooms, Hoteli.Rooms> // Common.QueryableRepositoryBase<Common.Queryable.Hoteli_Rooms, Hoteli.Rooms> // Common.ReadableRepositoryBase<Hoteli.Rooms> // global::Common.RepositoryBase
        , IWritableRepository<Hoteli.Rooms>, IValidateRepository/*DataStructureInfo RepositoryInterface Hoteli.Rooms*/
    {
        private readonly Rhetos.Utilities.ISqlUtility _sqlUtility;
        /*DataStructureInfo RepositoryPrivateMembers Hoteli.Rooms*/

        public Rooms_Repository(Common.DomRepository domRepository, Common.ExecutionContext executionContext, Rhetos.Utilities.ISqlUtility _sqlUtility/*DataStructureInfo RepositoryConstructorArguments Hoteli.Rooms*/)
        {
            _domRepository = domRepository;
            _executionContext = executionContext;
            this._sqlUtility = _sqlUtility;
            /*DataStructureInfo RepositoryConstructorCode Hoteli.Rooms*/
        }

        [Obsolete("Use Load() or Query() method.")]
        public override global::Hoteli.Rooms[] All()
        {
            return Query().ToSimple().ToArray();
        }

        public override IQueryable<Common.Queryable.Hoteli_Rooms> Query()
        {
            /*DataStructureInfo RepositoryBeforeQuery Hoteli.Rooms*/
            return _executionContext.EntityFrameworkContext.Hoteli_Rooms.AsNoTracking();
        }

        public void Save(IEnumerable<Hoteli.Rooms> insertedNew, IEnumerable<Hoteli.Rooms> updatedNew, IEnumerable<Hoteli.Rooms> deletedIds, bool checkUserPermissions = false)
        {
            if (!DomHelper.CleanUpSaveMethodArguments(ref insertedNew, ref updatedNew, ref deletedIds))
                return;

            /*DataStructureInfo WritableOrm ClearContext Hoteli.Rooms*/

            {
                var invalidItem = insertedNew.Concat(updatedNew).Where(newItem => newItem.Code != null && newItem.Code.Length > 256).FirstOrDefault();
                if (invalidItem != null)
                    throw new Rhetos.UserException(
                        "Maximum length of property {0} is {1}.",
                        new[] { "Rooms.Code", "256" },
                        "DataStructure:Hoteli.Rooms,ID:" + invalidItem.ID.ToString() + ",Property:Code",
                        null);
            }
            {
                var invalidItem = insertedNew.Concat(updatedNew).Where(newItem => newItem.TypeOfRoom != null && newItem.TypeOfRoom.Length > 256).FirstOrDefault();
                if (invalidItem != null)
                    throw new Rhetos.UserException(
                        "Maximum length of property {0} is {1}.",
                        new[] { "Rooms.TypeOfRoom", "256" },
                        "DataStructure:Hoteli.Rooms,ID:" + invalidItem.ID.ToString() + ",Property:TypeOfRoom",
                        null);
            }
            /*DataStructureInfo WritableOrm ArgumentValidation Hoteli.Rooms*/

            /*DataStructureInfo WritableOrm Initialization Hoteli.Rooms*/

            // Using old data, including lazy loading of navigation properties:
            IEnumerable<Common.Queryable.Hoteli_Rooms> deleted = this.Query(deletedIds.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Hoteli_Rooms>)deleted, deletedIds.Select(item => item.ID), item => item.ID);
            IEnumerable<Common.Queryable.Hoteli_Rooms> updated = this.Query(updatedNew.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Hoteli_Rooms>)updated, updatedNew.Select(item => item.ID), item => item.ID);

            AutoCodeHelper.UpdateCodesWithoutCache(
                _executionContext.SqlExecuter, "Hoteli.Rooms", "Code",
                insertedNew.Select(item => AutoCodeItem.Create(item, item.Code/*AutoCodePropertyInfo Grouping Hoteli.Rooms.Code*/)).ToList(),
                (item, newCode) => item.Code = newCode/*AutoCodePropertyInfo GroupColumnMetadata Hoteli.Rooms.Code*/);

            /*DataStructureInfo WritableOrm OldDataLoaded Hoteli.Rooms*/

            /*DataStructureInfo WritableOrm ProcessedOldData Hoteli.Rooms*/

            DomHelper.SaveOperation saveOperation = DomHelper.SaveOperation.None;
            try
            {
                if (deletedIds.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Delete;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in deletedIds.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (updatedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Update;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in updatedNew.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (insertedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Insert;
                    _executionContext.EntityFrameworkContext.Hoteli_Rooms.AddRange(insertedNew.Select(item => item.ToNavigation()));
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                saveOperation = DomHelper.SaveOperation.None;
                _executionContext.EntityFrameworkContext.ClearCache();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException saveException)
            {
                DomHelper.ThrowIfSavingNonexistentId(saveException, checkUserPermissions, saveOperation);
        		Rhetos.RhetosException interpretedException = _sqlUtility.InterpretSqlException(saveException);
        		if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnDelete(interpretedException, @"Hoteli.RoomReservation", @"ReservationRoomID", @"FK_RoomReservation_Rooms_ReservationRoomID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Hoteli.RoomReservation,Property:ReservationRoomID,Referenced:Hoteli.Rooms";
                if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnInsertUpdate(interpretedException, @"Hoteli.Hotel", @"ID", @"FK_Rooms_Hotel_RoomOfHotelID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Hoteli.Rooms,Property:RoomOfHotelID,Referenced:Hoteli.Hotel";
                if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsUniqueError(interpretedException, @"Hoteli.Rooms", @"IX_Rooms_Code"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Hoteli.Rooms,Property:Code";
                /*DataStructureInfo WritableOrm OnDatabaseError Hoteli.Rooms*/
                if (checkUserPermissions)
                    Rhetos.Utilities.MsSqlUtility.ThrowIfPrimaryKeyErrorOnInsert(interpretedException, "Hoteli.Rooms");

                if (interpretedException != null)
        			Rhetos.Utilities.ExceptionsUtility.Rethrow(interpretedException);
                var sqlException = _sqlUtility.ExtractSqlException(saveException);
                if (sqlException != null)
                    Rhetos.Utilities.ExceptionsUtility.Rethrow(sqlException);
                throw;
            }

            deleted = null;
            updated = this.Query(updatedNew.Select(item => item.ID));
            IEnumerable<Common.Queryable.Hoteli_Rooms> inserted = this.Query(insertedNew.Select(item => item.ID));

            bool allEffectsCompleted = false;
            try
            {
                /*DataStructureInfo WritableOrm OnSaveTag1 Hoteli.Rooms*/

                /*DataStructureInfo WritableOrm OnSaveTag2 Hoteli.Rooms*/

                Rhetos.Dom.DefaultConcepts.InvalidDataMessage.ValidateOnSave(insertedNew, updatedNew, this, "Hoteli.Rooms");

                /*DataStructureInfo WritableOrm AfterSave Hoteli.Rooms*/

                allEffectsCompleted = true;
            }
            finally
            {
                if (!allEffectsCompleted)
                    _executionContext.PersistenceTransaction.DiscardChanges();
            }
        }

        public IEnumerable<Rhetos.Dom.DefaultConcepts.InvalidDataMessage> Validate(IList<Guid> ids, bool onSave)
        {
            if (onSave)
            {
                var errorIds = this.Filter(this.Query(ids), new SystemRequiredCode()).Select(item => item.ID).ToArray();
                if (errorIds.Count() > 0)
                    foreach (var error in GetErrorMessage_SystemRequiredCode(errorIds))
                        yield return error;
            }
            /*DataStructureInfo WritableOrm OnSaveValidate Hoteli.Rooms*/
            yield break;
        }

        public IEnumerable<InvalidDataMessage> GetErrorMessage_SystemRequiredCode(IEnumerable<Guid> invalidData_Ids)
        {
            const string invalidData_Description = @"System required property {0} is not set.";
            IDictionary<string, object> metadata = new Dictionary<string, object>();
            metadata["Validation"] = @"SystemRequiredCode";
            metadata[@"Property"] = @"Code";
            /*InvalidDataInfo ErrorMetadata Hoteli.Rooms.SystemRequiredCode*/
            return invalidData_Ids.Select(id => new InvalidDataMessage
            {
                ID = id,
                Message = invalidData_Description,
                MessageParameters = new object[] { @"ShortString Hoteli.Rooms.Code" },
                Metadata = metadata
            });
            // /*InvalidDataInfo OverrideUserMessages Hoteli.Rooms.SystemRequiredCode*/ return invalidData_Ids.Select(id => new InvalidDataMessage { ID = id, Message = invalidData_Description, Metadata = metadata });
        }

        public IQueryable<Common.Queryable.Hoteli_Rooms> Filter(IQueryable<Common.Queryable.Hoteli_Rooms> localSource, Hoteli.SystemRequiredCode localParameter)
        {
            Func<IQueryable<Common.Queryable.Hoteli_Rooms>, Common.DomRepository, Hoteli.SystemRequiredCode/*ComposableFilterByInfo AdditionalParametersType Hoteli.Rooms.'Hoteli.SystemRequiredCode'*/, IQueryable<Common.Queryable.Hoteli_Rooms>> filterFunction =
            (source, repository, parameter) => source.Where(item => item.Code == null);

            /*ComposableFilterByInfo BeforeFilter Hoteli.Rooms.'Hoteli.SystemRequiredCode'*/
            return filterFunction(localSource, _domRepository, localParameter/*ComposableFilterByInfo AdditionalParametersArgument Hoteli.Rooms.'Hoteli.SystemRequiredCode'*/);
        }

        public global::Hoteli.Rooms[] Filter(Hoteli.SystemRequiredCode filter_Parameter)
        {
            Func<Common.DomRepository, Hoteli.SystemRequiredCode/*FilterByInfo AdditionalParametersType Hoteli.Rooms.'Hoteli.SystemRequiredCode'*/, Hoteli.Rooms[]> filter_Function =
                (repository, parameter) => repository.Hoteli.Rooms.Filter(repository.Hoteli.Rooms.Query(), parameter).ToArray();

            return filter_Function(_domRepository, filter_Parameter/*FilterByInfo AdditionalParametersArgument Hoteli.Rooms.'Hoteli.SystemRequiredCode'*/);
        }

        /*DataStructureInfo RepositoryMembers Hoteli.Rooms*/
    }

    /*DataStructureInfo RepositoryAttributes Hoteli.Person*/
    public class Person_Repository : /*DataStructureInfo OverrideBaseType Hoteli.Person*/ Common.OrmRepositoryBase<Common.Queryable.Hoteli_Person, Hoteli.Person> // Common.QueryableRepositoryBase<Common.Queryable.Hoteli_Person, Hoteli.Person> // Common.ReadableRepositoryBase<Hoteli.Person> // global::Common.RepositoryBase
        , IWritableRepository<Hoteli.Person>, IValidateRepository/*DataStructureInfo RepositoryInterface Hoteli.Person*/
    {
        private readonly Rhetos.Utilities.ISqlUtility _sqlUtility;
        /*DataStructureInfo RepositoryPrivateMembers Hoteli.Person*/

        public Person_Repository(Common.DomRepository domRepository, Common.ExecutionContext executionContext, Rhetos.Utilities.ISqlUtility _sqlUtility/*DataStructureInfo RepositoryConstructorArguments Hoteli.Person*/)
        {
            _domRepository = domRepository;
            _executionContext = executionContext;
            this._sqlUtility = _sqlUtility;
            /*DataStructureInfo RepositoryConstructorCode Hoteli.Person*/
        }

        [Obsolete("Use Load() or Query() method.")]
        public override global::Hoteli.Person[] All()
        {
            return Query().ToSimple().ToArray();
        }

        public override IQueryable<Common.Queryable.Hoteli_Person> Query()
        {
            /*DataStructureInfo RepositoryBeforeQuery Hoteli.Person*/
            return _executionContext.EntityFrameworkContext.Hoteli_Person.AsNoTracking();
        }

        public void Save(IEnumerable<Hoteli.Person> insertedNew, IEnumerable<Hoteli.Person> updatedNew, IEnumerable<Hoteli.Person> deletedIds, bool checkUserPermissions = false)
        {
            if (!DomHelper.CleanUpSaveMethodArguments(ref insertedNew, ref updatedNew, ref deletedIds))
                return;

            /*DataStructureInfo WritableOrm ClearContext Hoteli.Person*/

            {
                var invalidItem = insertedNew.Concat(updatedNew).Where(newItem => newItem.Code != null && newItem.Code.Length > 256).FirstOrDefault();
                if (invalidItem != null)
                    throw new Rhetos.UserException(
                        "Maximum length of property {0} is {1}.",
                        new[] { "Person.Code", "256" },
                        "DataStructure:Hoteli.Person,ID:" + invalidItem.ID.ToString() + ",Property:Code",
                        null);
            }
            /*DataStructureInfo WritableOrm ArgumentValidation Hoteli.Person*/

            /*DataStructureInfo WritableOrm Initialization Hoteli.Person*/

            // Using old data, including lazy loading of navigation properties:
            IEnumerable<Common.Queryable.Hoteli_Person> deleted = this.Query(deletedIds.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Hoteli_Person>)deleted, deletedIds.Select(item => item.ID), item => item.ID);
            IEnumerable<Common.Queryable.Hoteli_Person> updated = this.Query(updatedNew.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Hoteli_Person>)updated, updatedNew.Select(item => item.ID), item => item.ID);

            AutoCodeHelper.UpdateCodesWithoutCache(
                _executionContext.SqlExecuter, "Hoteli.Person", "Code",
                insertedNew.Select(item => AutoCodeItem.Create(item, item.Code/*AutoCodePropertyInfo Grouping Hoteli.Person.Code*/)).ToList(),
                (item, newCode) => item.Code = newCode/*AutoCodePropertyInfo GroupColumnMetadata Hoteli.Person.Code*/);

            /*DataStructureInfo WritableOrm OldDataLoaded Hoteli.Person*/

            /*DataStructureInfo WritableOrm ProcessedOldData Hoteli.Person*/

            DomHelper.SaveOperation saveOperation = DomHelper.SaveOperation.None;
            try
            {
                if (deletedIds.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Delete;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in deletedIds.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (updatedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Update;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in updatedNew.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (insertedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Insert;
                    _executionContext.EntityFrameworkContext.Hoteli_Person.AddRange(insertedNew.Select(item => item.ToNavigation()));
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                saveOperation = DomHelper.SaveOperation.None;
                _executionContext.EntityFrameworkContext.ClearCache();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException saveException)
            {
                DomHelper.ThrowIfSavingNonexistentId(saveException, checkUserPermissions, saveOperation);
        		Rhetos.RhetosException interpretedException = _sqlUtility.InterpretSqlException(saveException);
        		if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnDelete(interpretedException, @"Hoteli.Reservation", @"GuestID", @"FK_Reservation_Person_GuestID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Hoteli.Reservation,Property:GuestID,Referenced:Hoteli.Person";
                if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnDelete(interpretedException, @"Hoteli.SaloonPerson", @"OwnerNameID", @"FK_SaloonPerson_Person_OwnerNameID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Hoteli.SaloonPerson,Property:OwnerNameID,Referenced:Hoteli.Person";
                if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnDelete(interpretedException, @"Hoteli.ProductPerson", @"OwnerNameID", @"FK_ProductPerson_Person_OwnerNameID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Hoteli.ProductPerson,Property:OwnerNameID,Referenced:Hoteli.Person";
                if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsUniqueError(interpretedException, @"Hoteli.Person", @"IX_Person_Code"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Hoteli.Person,Property:Code";
                /*DataStructureInfo WritableOrm OnDatabaseError Hoteli.Person*/
                if (checkUserPermissions)
                    Rhetos.Utilities.MsSqlUtility.ThrowIfPrimaryKeyErrorOnInsert(interpretedException, "Hoteli.Person");

                if (interpretedException != null)
        			Rhetos.Utilities.ExceptionsUtility.Rethrow(interpretedException);
                var sqlException = _sqlUtility.ExtractSqlException(saveException);
                if (sqlException != null)
                    Rhetos.Utilities.ExceptionsUtility.Rethrow(sqlException);
                throw;
            }

            deleted = null;
            updated = this.Query(updatedNew.Select(item => item.ID));
            IEnumerable<Common.Queryable.Hoteli_Person> inserted = this.Query(insertedNew.Select(item => item.ID));

            bool allEffectsCompleted = false;
            try
            {
                /*DataStructureInfo WritableOrm OnSaveTag1 Hoteli.Person*/

                /*DataStructureInfo WritableOrm OnSaveTag2 Hoteli.Person*/

                Rhetos.Dom.DefaultConcepts.InvalidDataMessage.ValidateOnSave(insertedNew, updatedNew, this, "Hoteli.Person");

                /*DataStructureInfo WritableOrm AfterSave Hoteli.Person*/

                allEffectsCompleted = true;
            }
            finally
            {
                if (!allEffectsCompleted)
                    _executionContext.PersistenceTransaction.DiscardChanges();
            }
        }

        public IEnumerable<Rhetos.Dom.DefaultConcepts.InvalidDataMessage> Validate(IList<Guid> ids, bool onSave)
        {
            if (onSave)
            {
                var errorIds = this.Filter(this.Query(ids), new SystemRequiredCode()).Select(item => item.ID).ToArray();
                if (errorIds.Count() > 0)
                    foreach (var error in GetErrorMessage_SystemRequiredCode(errorIds))
                        yield return error;
            }
            /*DataStructureInfo WritableOrm OnSaveValidate Hoteli.Person*/
            yield break;
        }

        public IEnumerable<InvalidDataMessage> GetErrorMessage_SystemRequiredCode(IEnumerable<Guid> invalidData_Ids)
        {
            const string invalidData_Description = @"System required property {0} is not set.";
            IDictionary<string, object> metadata = new Dictionary<string, object>();
            metadata["Validation"] = @"SystemRequiredCode";
            metadata[@"Property"] = @"Code";
            /*InvalidDataInfo ErrorMetadata Hoteli.Person.SystemRequiredCode*/
            return invalidData_Ids.Select(id => new InvalidDataMessage
            {
                ID = id,
                Message = invalidData_Description,
                MessageParameters = new object[] { @"ShortString Hoteli.Person.Code" },
                Metadata = metadata
            });
            // /*InvalidDataInfo OverrideUserMessages Hoteli.Person.SystemRequiredCode*/ return invalidData_Ids.Select(id => new InvalidDataMessage { ID = id, Message = invalidData_Description, Metadata = metadata });
        }

        public IQueryable<Common.Queryable.Hoteli_Person> Filter(IQueryable<Common.Queryable.Hoteli_Person> localSource, Hoteli.SystemRequiredCode localParameter)
        {
            Func<IQueryable<Common.Queryable.Hoteli_Person>, Common.DomRepository, Hoteli.SystemRequiredCode/*ComposableFilterByInfo AdditionalParametersType Hoteli.Person.'Hoteli.SystemRequiredCode'*/, IQueryable<Common.Queryable.Hoteli_Person>> filterFunction =
            (source, repository, parameter) => source.Where(item => item.Code == null);

            /*ComposableFilterByInfo BeforeFilter Hoteli.Person.'Hoteli.SystemRequiredCode'*/
            return filterFunction(localSource, _domRepository, localParameter/*ComposableFilterByInfo AdditionalParametersArgument Hoteli.Person.'Hoteli.SystemRequiredCode'*/);
        }

        public global::Hoteli.Person[] Filter(Hoteli.SystemRequiredCode filter_Parameter)
        {
            Func<Common.DomRepository, Hoteli.SystemRequiredCode/*FilterByInfo AdditionalParametersType Hoteli.Person.'Hoteli.SystemRequiredCode'*/, Hoteli.Person[]> filter_Function =
                (repository, parameter) => repository.Hoteli.Person.Filter(repository.Hoteli.Person.Query(), parameter).ToArray();

            return filter_Function(_domRepository, filter_Parameter/*FilterByInfo AdditionalParametersArgument Hoteli.Person.'Hoteli.SystemRequiredCode'*/);
        }

        /*DataStructureInfo RepositoryMembers Hoteli.Person*/
    }

    /*DataStructureInfo RepositoryAttributes Hoteli.SaloonPerson*/
    public class SaloonPerson_Repository : /*DataStructureInfo OverrideBaseType Hoteli.SaloonPerson*/ Common.OrmRepositoryBase<Common.Queryable.Hoteli_SaloonPerson, Hoteli.SaloonPerson> // Common.QueryableRepositoryBase<Common.Queryable.Hoteli_SaloonPerson, Hoteli.SaloonPerson> // Common.ReadableRepositoryBase<Hoteli.SaloonPerson> // global::Common.RepositoryBase
        , IWritableRepository<Hoteli.SaloonPerson>, IValidateRepository/*DataStructureInfo RepositoryInterface Hoteli.SaloonPerson*/
    {
        private readonly Rhetos.Utilities.ISqlUtility _sqlUtility;
        /*DataStructureInfo RepositoryPrivateMembers Hoteli.SaloonPerson*/

        public SaloonPerson_Repository(Common.DomRepository domRepository, Common.ExecutionContext executionContext, Rhetos.Utilities.ISqlUtility _sqlUtility/*DataStructureInfo RepositoryConstructorArguments Hoteli.SaloonPerson*/)
        {
            _domRepository = domRepository;
            _executionContext = executionContext;
            this._sqlUtility = _sqlUtility;
            /*DataStructureInfo RepositoryConstructorCode Hoteli.SaloonPerson*/
        }

        [Obsolete("Use Load() or Query() method.")]
        public override global::Hoteli.SaloonPerson[] All()
        {
            return Query().ToSimple().ToArray();
        }

        public override IQueryable<Common.Queryable.Hoteli_SaloonPerson> Query()
        {
            /*DataStructureInfo RepositoryBeforeQuery Hoteli.SaloonPerson*/
            return _executionContext.EntityFrameworkContext.Hoteli_SaloonPerson.AsNoTracking();
        }

        public void Save(IEnumerable<Hoteli.SaloonPerson> insertedNew, IEnumerable<Hoteli.SaloonPerson> updatedNew, IEnumerable<Hoteli.SaloonPerson> deletedIds, bool checkUserPermissions = false)
        {
            if (!DomHelper.CleanUpSaveMethodArguments(ref insertedNew, ref updatedNew, ref deletedIds))
                return;

            /*DataStructureInfo WritableOrm ClearContext Hoteli.SaloonPerson*/

            {
                var invalidItem = insertedNew.Concat(updatedNew).Where(newItem => newItem.Code != null && newItem.Code.Length > 256).FirstOrDefault();
                if (invalidItem != null)
                    throw new Rhetos.UserException(
                        "Maximum length of property {0} is {1}.",
                        new[] { "SaloonPerson.Code", "256" },
                        "DataStructure:Hoteli.SaloonPerson,ID:" + invalidItem.ID.ToString() + ",Property:Code",
                        null);
            }
            /*DataStructureInfo WritableOrm ArgumentValidation Hoteli.SaloonPerson*/

            /*DataStructureInfo WritableOrm Initialization Hoteli.SaloonPerson*/

            // Using old data, including lazy loading of navigation properties:
            IEnumerable<Common.Queryable.Hoteli_SaloonPerson> deleted = this.Query(deletedIds.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Hoteli_SaloonPerson>)deleted, deletedIds.Select(item => item.ID), item => item.ID);
            IEnumerable<Common.Queryable.Hoteli_SaloonPerson> updated = this.Query(updatedNew.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Hoteli_SaloonPerson>)updated, updatedNew.Select(item => item.ID), item => item.ID);

            AutoCodeHelper.UpdateCodesWithoutCache(
                _executionContext.SqlExecuter, "Hoteli.SaloonPerson", "Code",
                insertedNew.Select(item => AutoCodeItem.Create(item, item.Code/*AutoCodePropertyInfo Grouping Hoteli.SaloonPerson.Code*/)).ToList(),
                (item, newCode) => item.Code = newCode/*AutoCodePropertyInfo GroupColumnMetadata Hoteli.SaloonPerson.Code*/);

            /*DataStructureInfo WritableOrm OldDataLoaded Hoteli.SaloonPerson*/

            /*DataStructureInfo WritableOrm ProcessedOldData Hoteli.SaloonPerson*/

            DomHelper.SaveOperation saveOperation = DomHelper.SaveOperation.None;
            try
            {
                if (deletedIds.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Delete;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in deletedIds.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (updatedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Update;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in updatedNew.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (insertedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Insert;
                    _executionContext.EntityFrameworkContext.Hoteli_SaloonPerson.AddRange(insertedNew.Select(item => item.ToNavigation()));
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                saveOperation = DomHelper.SaveOperation.None;
                _executionContext.EntityFrameworkContext.ClearCache();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException saveException)
            {
                DomHelper.ThrowIfSavingNonexistentId(saveException, checkUserPermissions, saveOperation);
        		Rhetos.RhetosException interpretedException = _sqlUtility.InterpretSqlException(saveException);
        		if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnInsertUpdate(interpretedException, @"Hoteli.Person", @"ID", @"FK_SaloonPerson_Person_OwnerNameID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Hoteli.SaloonPerson,Property:OwnerNameID,Referenced:Hoteli.Person";
                if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnInsertUpdate(interpretedException, @"Hoteli.Saloon", @"ID", @"FK_SaloonPerson_Saloon_SalonID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Hoteli.SaloonPerson,Property:SalonID,Referenced:Hoteli.Saloon";
                if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsUniqueError(interpretedException, @"Hoteli.SaloonPerson", @"IX_SaloonPerson_Code"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Hoteli.SaloonPerson,Property:Code";
                /*DataStructureInfo WritableOrm OnDatabaseError Hoteli.SaloonPerson*/
                if (checkUserPermissions)
                    Rhetos.Utilities.MsSqlUtility.ThrowIfPrimaryKeyErrorOnInsert(interpretedException, "Hoteli.SaloonPerson");

                if (interpretedException != null)
        			Rhetos.Utilities.ExceptionsUtility.Rethrow(interpretedException);
                var sqlException = _sqlUtility.ExtractSqlException(saveException);
                if (sqlException != null)
                    Rhetos.Utilities.ExceptionsUtility.Rethrow(sqlException);
                throw;
            }

            deleted = null;
            updated = this.Query(updatedNew.Select(item => item.ID));
            IEnumerable<Common.Queryable.Hoteli_SaloonPerson> inserted = this.Query(insertedNew.Select(item => item.ID));

            bool allEffectsCompleted = false;
            try
            {
                /*DataStructureInfo WritableOrm OnSaveTag1 Hoteli.SaloonPerson*/

                /*DataStructureInfo WritableOrm OnSaveTag2 Hoteli.SaloonPerson*/

                Rhetos.Dom.DefaultConcepts.InvalidDataMessage.ValidateOnSave(insertedNew, updatedNew, this, "Hoteli.SaloonPerson");

                /*DataStructureInfo WritableOrm AfterSave Hoteli.SaloonPerson*/

                allEffectsCompleted = true;
            }
            finally
            {
                if (!allEffectsCompleted)
                    _executionContext.PersistenceTransaction.DiscardChanges();
            }
        }

        public IEnumerable<Rhetos.Dom.DefaultConcepts.InvalidDataMessage> Validate(IList<Guid> ids, bool onSave)
        {
            if (onSave)
            {
                var errorIds = this.Filter(this.Query(ids), new SystemRequiredCode()).Select(item => item.ID).ToArray();
                if (errorIds.Count() > 0)
                    foreach (var error in GetErrorMessage_SystemRequiredCode(errorIds))
                        yield return error;
            }
            /*DataStructureInfo WritableOrm OnSaveValidate Hoteli.SaloonPerson*/
            yield break;
        }

        public IEnumerable<InvalidDataMessage> GetErrorMessage_SystemRequiredCode(IEnumerable<Guid> invalidData_Ids)
        {
            const string invalidData_Description = @"System required property {0} is not set.";
            IDictionary<string, object> metadata = new Dictionary<string, object>();
            metadata["Validation"] = @"SystemRequiredCode";
            metadata[@"Property"] = @"Code";
            /*InvalidDataInfo ErrorMetadata Hoteli.SaloonPerson.SystemRequiredCode*/
            return invalidData_Ids.Select(id => new InvalidDataMessage
            {
                ID = id,
                Message = invalidData_Description,
                MessageParameters = new object[] { @"ShortString Hoteli.SaloonPerson.Code" },
                Metadata = metadata
            });
            // /*InvalidDataInfo OverrideUserMessages Hoteli.SaloonPerson.SystemRequiredCode*/ return invalidData_Ids.Select(id => new InvalidDataMessage { ID = id, Message = invalidData_Description, Metadata = metadata });
        }

        public IQueryable<Common.Queryable.Hoteli_SaloonPerson> Filter(IQueryable<Common.Queryable.Hoteli_SaloonPerson> localSource, Hoteli.SystemRequiredCode localParameter)
        {
            Func<IQueryable<Common.Queryable.Hoteli_SaloonPerson>, Common.DomRepository, Hoteli.SystemRequiredCode/*ComposableFilterByInfo AdditionalParametersType Hoteli.SaloonPerson.'Hoteli.SystemRequiredCode'*/, IQueryable<Common.Queryable.Hoteli_SaloonPerson>> filterFunction =
            (source, repository, parameter) => source.Where(item => item.Code == null);

            /*ComposableFilterByInfo BeforeFilter Hoteli.SaloonPerson.'Hoteli.SystemRequiredCode'*/
            return filterFunction(localSource, _domRepository, localParameter/*ComposableFilterByInfo AdditionalParametersArgument Hoteli.SaloonPerson.'Hoteli.SystemRequiredCode'*/);
        }

        public global::Hoteli.SaloonPerson[] Filter(Hoteli.SystemRequiredCode filter_Parameter)
        {
            Func<Common.DomRepository, Hoteli.SystemRequiredCode/*FilterByInfo AdditionalParametersType Hoteli.SaloonPerson.'Hoteli.SystemRequiredCode'*/, Hoteli.SaloonPerson[]> filter_Function =
                (repository, parameter) => repository.Hoteli.SaloonPerson.Filter(repository.Hoteli.SaloonPerson.Query(), parameter).ToArray();

            return filter_Function(_domRepository, filter_Parameter/*FilterByInfo AdditionalParametersArgument Hoteli.SaloonPerson.'Hoteli.SystemRequiredCode'*/);
        }

        /*DataStructureInfo RepositoryMembers Hoteli.SaloonPerson*/
    }

    /*DataStructureInfo RepositoryAttributes Hoteli.SaloonHotel*/
    public class SaloonHotel_Repository : /*DataStructureInfo OverrideBaseType Hoteli.SaloonHotel*/ Common.OrmRepositoryBase<Common.Queryable.Hoteli_SaloonHotel, Hoteli.SaloonHotel> // Common.QueryableRepositoryBase<Common.Queryable.Hoteli_SaloonHotel, Hoteli.SaloonHotel> // Common.ReadableRepositoryBase<Hoteli.SaloonHotel> // global::Common.RepositoryBase
        , IWritableRepository<Hoteli.SaloonHotel>, IValidateRepository/*DataStructureInfo RepositoryInterface Hoteli.SaloonHotel*/
    {
        private readonly Rhetos.Utilities.ISqlUtility _sqlUtility;
        /*DataStructureInfo RepositoryPrivateMembers Hoteli.SaloonHotel*/

        public SaloonHotel_Repository(Common.DomRepository domRepository, Common.ExecutionContext executionContext, Rhetos.Utilities.ISqlUtility _sqlUtility/*DataStructureInfo RepositoryConstructorArguments Hoteli.SaloonHotel*/)
        {
            _domRepository = domRepository;
            _executionContext = executionContext;
            this._sqlUtility = _sqlUtility;
            /*DataStructureInfo RepositoryConstructorCode Hoteli.SaloonHotel*/
        }

        [Obsolete("Use Load() or Query() method.")]
        public override global::Hoteli.SaloonHotel[] All()
        {
            return Query().ToSimple().ToArray();
        }

        public override IQueryable<Common.Queryable.Hoteli_SaloonHotel> Query()
        {
            /*DataStructureInfo RepositoryBeforeQuery Hoteli.SaloonHotel*/
            return _executionContext.EntityFrameworkContext.Hoteli_SaloonHotel.AsNoTracking();
        }

        public void Save(IEnumerable<Hoteli.SaloonHotel> insertedNew, IEnumerable<Hoteli.SaloonHotel> updatedNew, IEnumerable<Hoteli.SaloonHotel> deletedIds, bool checkUserPermissions = false)
        {
            if (!DomHelper.CleanUpSaveMethodArguments(ref insertedNew, ref updatedNew, ref deletedIds))
                return;

            /*DataStructureInfo WritableOrm ClearContext Hoteli.SaloonHotel*/

            {
                var invalidItem = insertedNew.Concat(updatedNew).Where(newItem => newItem.Code != null && newItem.Code.Length > 256).FirstOrDefault();
                if (invalidItem != null)
                    throw new Rhetos.UserException(
                        "Maximum length of property {0} is {1}.",
                        new[] { "SaloonHotel.Code", "256" },
                        "DataStructure:Hoteli.SaloonHotel,ID:" + invalidItem.ID.ToString() + ",Property:Code",
                        null);
            }
            /*DataStructureInfo WritableOrm ArgumentValidation Hoteli.SaloonHotel*/

            /*DataStructureInfo WritableOrm Initialization Hoteli.SaloonHotel*/

            // Using old data, including lazy loading of navigation properties:
            IEnumerable<Common.Queryable.Hoteli_SaloonHotel> deleted = this.Query(deletedIds.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Hoteli_SaloonHotel>)deleted, deletedIds.Select(item => item.ID), item => item.ID);
            IEnumerable<Common.Queryable.Hoteli_SaloonHotel> updated = this.Query(updatedNew.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Hoteli_SaloonHotel>)updated, updatedNew.Select(item => item.ID), item => item.ID);

            AutoCodeHelper.UpdateCodesWithoutCache(
                _executionContext.SqlExecuter, "Hoteli.SaloonHotel", "Code",
                insertedNew.Select(item => AutoCodeItem.Create(item, item.Code/*AutoCodePropertyInfo Grouping Hoteli.SaloonHotel.Code*/)).ToList(),
                (item, newCode) => item.Code = newCode/*AutoCodePropertyInfo GroupColumnMetadata Hoteli.SaloonHotel.Code*/);

            /*DataStructureInfo WritableOrm OldDataLoaded Hoteli.SaloonHotel*/

            /*DataStructureInfo WritableOrm ProcessedOldData Hoteli.SaloonHotel*/

            DomHelper.SaveOperation saveOperation = DomHelper.SaveOperation.None;
            try
            {
                if (deletedIds.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Delete;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in deletedIds.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (updatedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Update;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in updatedNew.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (insertedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Insert;
                    _executionContext.EntityFrameworkContext.Hoteli_SaloonHotel.AddRange(insertedNew.Select(item => item.ToNavigation()));
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                saveOperation = DomHelper.SaveOperation.None;
                _executionContext.EntityFrameworkContext.ClearCache();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException saveException)
            {
                DomHelper.ThrowIfSavingNonexistentId(saveException, checkUserPermissions, saveOperation);
        		Rhetos.RhetosException interpretedException = _sqlUtility.InterpretSqlException(saveException);
        		if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnInsertUpdate(interpretedException, @"Hoteli.Hotel", @"ID", @"FK_SaloonHotel_Hotel_OwnerNameID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Hoteli.SaloonHotel,Property:OwnerNameID,Referenced:Hoteli.Hotel";
                if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnInsertUpdate(interpretedException, @"Hoteli.Saloon", @"ID", @"FK_SaloonHotel_Saloon_SalonID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Hoteli.SaloonHotel,Property:SalonID,Referenced:Hoteli.Saloon";
                if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsUniqueError(interpretedException, @"Hoteli.SaloonHotel", @"IX_SaloonHotel_Code"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Hoteli.SaloonHotel,Property:Code";
                /*DataStructureInfo WritableOrm OnDatabaseError Hoteli.SaloonHotel*/
                if (checkUserPermissions)
                    Rhetos.Utilities.MsSqlUtility.ThrowIfPrimaryKeyErrorOnInsert(interpretedException, "Hoteli.SaloonHotel");

                if (interpretedException != null)
        			Rhetos.Utilities.ExceptionsUtility.Rethrow(interpretedException);
                var sqlException = _sqlUtility.ExtractSqlException(saveException);
                if (sqlException != null)
                    Rhetos.Utilities.ExceptionsUtility.Rethrow(sqlException);
                throw;
            }

            deleted = null;
            updated = this.Query(updatedNew.Select(item => item.ID));
            IEnumerable<Common.Queryable.Hoteli_SaloonHotel> inserted = this.Query(insertedNew.Select(item => item.ID));

            bool allEffectsCompleted = false;
            try
            {
                /*DataStructureInfo WritableOrm OnSaveTag1 Hoteli.SaloonHotel*/

                /*DataStructureInfo WritableOrm OnSaveTag2 Hoteli.SaloonHotel*/

                Rhetos.Dom.DefaultConcepts.InvalidDataMessage.ValidateOnSave(insertedNew, updatedNew, this, "Hoteli.SaloonHotel");

                /*DataStructureInfo WritableOrm AfterSave Hoteli.SaloonHotel*/

                allEffectsCompleted = true;
            }
            finally
            {
                if (!allEffectsCompleted)
                    _executionContext.PersistenceTransaction.DiscardChanges();
            }
        }

        public IEnumerable<Rhetos.Dom.DefaultConcepts.InvalidDataMessage> Validate(IList<Guid> ids, bool onSave)
        {
            if (onSave)
            {
                var errorIds = this.Filter(this.Query(ids), new SystemRequiredCode()).Select(item => item.ID).ToArray();
                if (errorIds.Count() > 0)
                    foreach (var error in GetErrorMessage_SystemRequiredCode(errorIds))
                        yield return error;
            }
            /*DataStructureInfo WritableOrm OnSaveValidate Hoteli.SaloonHotel*/
            yield break;
        }

        public IEnumerable<InvalidDataMessage> GetErrorMessage_SystemRequiredCode(IEnumerable<Guid> invalidData_Ids)
        {
            const string invalidData_Description = @"System required property {0} is not set.";
            IDictionary<string, object> metadata = new Dictionary<string, object>();
            metadata["Validation"] = @"SystemRequiredCode";
            metadata[@"Property"] = @"Code";
            /*InvalidDataInfo ErrorMetadata Hoteli.SaloonHotel.SystemRequiredCode*/
            return invalidData_Ids.Select(id => new InvalidDataMessage
            {
                ID = id,
                Message = invalidData_Description,
                MessageParameters = new object[] { @"ShortString Hoteli.SaloonHotel.Code" },
                Metadata = metadata
            });
            // /*InvalidDataInfo OverrideUserMessages Hoteli.SaloonHotel.SystemRequiredCode*/ return invalidData_Ids.Select(id => new InvalidDataMessage { ID = id, Message = invalidData_Description, Metadata = metadata });
        }

        public IQueryable<Common.Queryable.Hoteli_SaloonHotel> Filter(IQueryable<Common.Queryable.Hoteli_SaloonHotel> localSource, Hoteli.SystemRequiredCode localParameter)
        {
            Func<IQueryable<Common.Queryable.Hoteli_SaloonHotel>, Common.DomRepository, Hoteli.SystemRequiredCode/*ComposableFilterByInfo AdditionalParametersType Hoteli.SaloonHotel.'Hoteli.SystemRequiredCode'*/, IQueryable<Common.Queryable.Hoteli_SaloonHotel>> filterFunction =
            (source, repository, parameter) => source.Where(item => item.Code == null);

            /*ComposableFilterByInfo BeforeFilter Hoteli.SaloonHotel.'Hoteli.SystemRequiredCode'*/
            return filterFunction(localSource, _domRepository, localParameter/*ComposableFilterByInfo AdditionalParametersArgument Hoteli.SaloonHotel.'Hoteli.SystemRequiredCode'*/);
        }

        public global::Hoteli.SaloonHotel[] Filter(Hoteli.SystemRequiredCode filter_Parameter)
        {
            Func<Common.DomRepository, Hoteli.SystemRequiredCode/*FilterByInfo AdditionalParametersType Hoteli.SaloonHotel.'Hoteli.SystemRequiredCode'*/, Hoteli.SaloonHotel[]> filter_Function =
                (repository, parameter) => repository.Hoteli.SaloonHotel.Filter(repository.Hoteli.SaloonHotel.Query(), parameter).ToArray();

            return filter_Function(_domRepository, filter_Parameter/*FilterByInfo AdditionalParametersArgument Hoteli.SaloonHotel.'Hoteli.SystemRequiredCode'*/);
        }

        /*DataStructureInfo RepositoryMembers Hoteli.SaloonHotel*/
    }

    /*DataStructureInfo RepositoryAttributes Hoteli.Saloon*/
    public class Saloon_Repository : /*DataStructureInfo OverrideBaseType Hoteli.Saloon*/ Common.OrmRepositoryBase<Common.Queryable.Hoteli_Saloon, Hoteli.Saloon> // Common.QueryableRepositoryBase<Common.Queryable.Hoteli_Saloon, Hoteli.Saloon> // Common.ReadableRepositoryBase<Hoteli.Saloon> // global::Common.RepositoryBase
        , IWritableRepository<Hoteli.Saloon>, IValidateRepository/*DataStructureInfo RepositoryInterface Hoteli.Saloon*/
    {
        private readonly Rhetos.Utilities.ISqlUtility _sqlUtility;
        /*DataStructureInfo RepositoryPrivateMembers Hoteli.Saloon*/

        public Saloon_Repository(Common.DomRepository domRepository, Common.ExecutionContext executionContext, Rhetos.Utilities.ISqlUtility _sqlUtility/*DataStructureInfo RepositoryConstructorArguments Hoteli.Saloon*/)
        {
            _domRepository = domRepository;
            _executionContext = executionContext;
            this._sqlUtility = _sqlUtility;
            /*DataStructureInfo RepositoryConstructorCode Hoteli.Saloon*/
        }

        [Obsolete("Use Load() or Query() method.")]
        public override global::Hoteli.Saloon[] All()
        {
            return Query().ToSimple().ToArray();
        }

        public override IQueryable<Common.Queryable.Hoteli_Saloon> Query()
        {
            /*DataStructureInfo RepositoryBeforeQuery Hoteli.Saloon*/
            return _executionContext.EntityFrameworkContext.Hoteli_Saloon.AsNoTracking();
        }

        public void Save(IEnumerable<Hoteli.Saloon> insertedNew, IEnumerable<Hoteli.Saloon> updatedNew, IEnumerable<Hoteli.Saloon> deletedIds, bool checkUserPermissions = false)
        {
            if (!DomHelper.CleanUpSaveMethodArguments(ref insertedNew, ref updatedNew, ref deletedIds))
                return;

            /*DataStructureInfo WritableOrm ClearContext Hoteli.Saloon*/

            {
                var invalidItem = insertedNew.Concat(updatedNew).Where(newItem => newItem.Code != null && newItem.Code.Length > 256).FirstOrDefault();
                if (invalidItem != null)
                    throw new Rhetos.UserException(
                        "Maximum length of property {0} is {1}.",
                        new[] { "Saloon.Code", "256" },
                        "DataStructure:Hoteli.Saloon,ID:" + invalidItem.ID.ToString() + ",Property:Code",
                        null);
            }
            /*DataStructureInfo WritableOrm ArgumentValidation Hoteli.Saloon*/

            /*DataStructureInfo WritableOrm Initialization Hoteli.Saloon*/

            // Using old data, including lazy loading of navigation properties:
            IEnumerable<Common.Queryable.Hoteli_Saloon> deleted = this.Query(deletedIds.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Hoteli_Saloon>)deleted, deletedIds.Select(item => item.ID), item => item.ID);
            IEnumerable<Common.Queryable.Hoteli_Saloon> updated = this.Query(updatedNew.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Hoteli_Saloon>)updated, updatedNew.Select(item => item.ID), item => item.ID);

            AutoCodeHelper.UpdateCodesWithoutCache(
                _executionContext.SqlExecuter, "Hoteli.Saloon", "Code",
                insertedNew.Select(item => AutoCodeItem.Create(item, item.Code/*AutoCodePropertyInfo Grouping Hoteli.Saloon.Code*/)).ToList(),
                (item, newCode) => item.Code = newCode/*AutoCodePropertyInfo GroupColumnMetadata Hoteli.Saloon.Code*/);

            /*DataStructureInfo WritableOrm OldDataLoaded Hoteli.Saloon*/

            /*DataStructureInfo WritableOrm ProcessedOldData Hoteli.Saloon*/

            DomHelper.SaveOperation saveOperation = DomHelper.SaveOperation.None;
            try
            {
                if (deletedIds.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Delete;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in deletedIds.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (updatedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Update;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in updatedNew.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (insertedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Insert;
                    _executionContext.EntityFrameworkContext.Hoteli_Saloon.AddRange(insertedNew.Select(item => item.ToNavigation()));
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                saveOperation = DomHelper.SaveOperation.None;
                _executionContext.EntityFrameworkContext.ClearCache();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException saveException)
            {
                DomHelper.ThrowIfSavingNonexistentId(saveException, checkUserPermissions, saveOperation);
        		Rhetos.RhetosException interpretedException = _sqlUtility.InterpretSqlException(saveException);
        		if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnDelete(interpretedException, @"Hoteli.SaloonPerson", @"SalonID", @"FK_SaloonPerson_Saloon_SalonID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Hoteli.SaloonPerson,Property:SalonID,Referenced:Hoteli.Saloon";
                if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnDelete(interpretedException, @"Hoteli.SaloonHotel", @"SalonID", @"FK_SaloonHotel_Saloon_SalonID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Hoteli.SaloonHotel,Property:SalonID,Referenced:Hoteli.Saloon";
                if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnInsertUpdate(interpretedException, @"Hoteli.Hotel", @"ID", @"FK_Saloon_Hotel_HotelSaloonID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Hoteli.Saloon,Property:HotelSaloonID,Referenced:Hoteli.Hotel";
                if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsUniqueError(interpretedException, @"Hoteli.Saloon", @"IX_Saloon_Code"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Hoteli.Saloon,Property:Code";
                /*DataStructureInfo WritableOrm OnDatabaseError Hoteli.Saloon*/
                if (checkUserPermissions)
                    Rhetos.Utilities.MsSqlUtility.ThrowIfPrimaryKeyErrorOnInsert(interpretedException, "Hoteli.Saloon");

                if (interpretedException != null)
        			Rhetos.Utilities.ExceptionsUtility.Rethrow(interpretedException);
                var sqlException = _sqlUtility.ExtractSqlException(saveException);
                if (sqlException != null)
                    Rhetos.Utilities.ExceptionsUtility.Rethrow(sqlException);
                throw;
            }

            deleted = null;
            updated = this.Query(updatedNew.Select(item => item.ID));
            IEnumerable<Common.Queryable.Hoteli_Saloon> inserted = this.Query(insertedNew.Select(item => item.ID));

            bool allEffectsCompleted = false;
            try
            {
                /*DataStructureInfo WritableOrm OnSaveTag1 Hoteli.Saloon*/

                /*DataStructureInfo WritableOrm OnSaveTag2 Hoteli.Saloon*/

                Rhetos.Dom.DefaultConcepts.InvalidDataMessage.ValidateOnSave(insertedNew, updatedNew, this, "Hoteli.Saloon");

                /*DataStructureInfo WritableOrm AfterSave Hoteli.Saloon*/

                allEffectsCompleted = true;
            }
            finally
            {
                if (!allEffectsCompleted)
                    _executionContext.PersistenceTransaction.DiscardChanges();
            }
        }

        public IEnumerable<Rhetos.Dom.DefaultConcepts.InvalidDataMessage> Validate(IList<Guid> ids, bool onSave)
        {
            if (onSave)
            {
                var errorIds = this.Filter(this.Query(ids), new SystemRequiredCode()).Select(item => item.ID).ToArray();
                if (errorIds.Count() > 0)
                    foreach (var error in GetErrorMessage_SystemRequiredCode(errorIds))
                        yield return error;
            }
            /*DataStructureInfo WritableOrm OnSaveValidate Hoteli.Saloon*/
            yield break;
        }

        public IEnumerable<InvalidDataMessage> GetErrorMessage_SystemRequiredCode(IEnumerable<Guid> invalidData_Ids)
        {
            const string invalidData_Description = @"System required property {0} is not set.";
            IDictionary<string, object> metadata = new Dictionary<string, object>();
            metadata["Validation"] = @"SystemRequiredCode";
            metadata[@"Property"] = @"Code";
            /*InvalidDataInfo ErrorMetadata Hoteli.Saloon.SystemRequiredCode*/
            return invalidData_Ids.Select(id => new InvalidDataMessage
            {
                ID = id,
                Message = invalidData_Description,
                MessageParameters = new object[] { @"ShortString Hoteli.Saloon.Code" },
                Metadata = metadata
            });
            // /*InvalidDataInfo OverrideUserMessages Hoteli.Saloon.SystemRequiredCode*/ return invalidData_Ids.Select(id => new InvalidDataMessage { ID = id, Message = invalidData_Description, Metadata = metadata });
        }

        public IQueryable<Common.Queryable.Hoteli_Saloon> Filter(IQueryable<Common.Queryable.Hoteli_Saloon> localSource, Hoteli.SystemRequiredCode localParameter)
        {
            Func<IQueryable<Common.Queryable.Hoteli_Saloon>, Common.DomRepository, Hoteli.SystemRequiredCode/*ComposableFilterByInfo AdditionalParametersType Hoteli.Saloon.'Hoteli.SystemRequiredCode'*/, IQueryable<Common.Queryable.Hoteli_Saloon>> filterFunction =
            (source, repository, parameter) => source.Where(item => item.Code == null);

            /*ComposableFilterByInfo BeforeFilter Hoteli.Saloon.'Hoteli.SystemRequiredCode'*/
            return filterFunction(localSource, _domRepository, localParameter/*ComposableFilterByInfo AdditionalParametersArgument Hoteli.Saloon.'Hoteli.SystemRequiredCode'*/);
        }

        public global::Hoteli.Saloon[] Filter(Hoteli.SystemRequiredCode filter_Parameter)
        {
            Func<Common.DomRepository, Hoteli.SystemRequiredCode/*FilterByInfo AdditionalParametersType Hoteli.Saloon.'Hoteli.SystemRequiredCode'*/, Hoteli.Saloon[]> filter_Function =
                (repository, parameter) => repository.Hoteli.Saloon.Filter(repository.Hoteli.Saloon.Query(), parameter).ToArray();

            return filter_Function(_domRepository, filter_Parameter/*FilterByInfo AdditionalParametersArgument Hoteli.Saloon.'Hoteli.SystemRequiredCode'*/);
        }

        /*DataStructureInfo RepositoryMembers Hoteli.Saloon*/
    }

    /*DataStructureInfo RepositoryAttributes Hoteli.ProductPerson*/
    public class ProductPerson_Repository : /*DataStructureInfo OverrideBaseType Hoteli.ProductPerson*/ Common.OrmRepositoryBase<Common.Queryable.Hoteli_ProductPerson, Hoteli.ProductPerson> // Common.QueryableRepositoryBase<Common.Queryable.Hoteli_ProductPerson, Hoteli.ProductPerson> // Common.ReadableRepositoryBase<Hoteli.ProductPerson> // global::Common.RepositoryBase
        , IWritableRepository<Hoteli.ProductPerson>, IValidateRepository/*DataStructureInfo RepositoryInterface Hoteli.ProductPerson*/
    {
        private readonly Rhetos.Utilities.ISqlUtility _sqlUtility;
        /*DataStructureInfo RepositoryPrivateMembers Hoteli.ProductPerson*/

        public ProductPerson_Repository(Common.DomRepository domRepository, Common.ExecutionContext executionContext, Rhetos.Utilities.ISqlUtility _sqlUtility/*DataStructureInfo RepositoryConstructorArguments Hoteli.ProductPerson*/)
        {
            _domRepository = domRepository;
            _executionContext = executionContext;
            this._sqlUtility = _sqlUtility;
            /*DataStructureInfo RepositoryConstructorCode Hoteli.ProductPerson*/
        }

        [Obsolete("Use Load() or Query() method.")]
        public override global::Hoteli.ProductPerson[] All()
        {
            return Query().ToSimple().ToArray();
        }

        public override IQueryable<Common.Queryable.Hoteli_ProductPerson> Query()
        {
            /*DataStructureInfo RepositoryBeforeQuery Hoteli.ProductPerson*/
            return _executionContext.EntityFrameworkContext.Hoteli_ProductPerson.AsNoTracking();
        }

        public void Save(IEnumerable<Hoteli.ProductPerson> insertedNew, IEnumerable<Hoteli.ProductPerson> updatedNew, IEnumerable<Hoteli.ProductPerson> deletedIds, bool checkUserPermissions = false)
        {
            if (!DomHelper.CleanUpSaveMethodArguments(ref insertedNew, ref updatedNew, ref deletedIds))
                return;

            /*DataStructureInfo WritableOrm ClearContext Hoteli.ProductPerson*/

            {
                var invalidItem = insertedNew.Concat(updatedNew).Where(newItem => newItem.Code != null && newItem.Code.Length > 256).FirstOrDefault();
                if (invalidItem != null)
                    throw new Rhetos.UserException(
                        "Maximum length of property {0} is {1}.",
                        new[] { "ProductPerson.Code", "256" },
                        "DataStructure:Hoteli.ProductPerson,ID:" + invalidItem.ID.ToString() + ",Property:Code",
                        null);
            }
            /*DataStructureInfo WritableOrm ArgumentValidation Hoteli.ProductPerson*/

            /*DataStructureInfo WritableOrm Initialization Hoteli.ProductPerson*/

            // Using old data, including lazy loading of navigation properties:
            IEnumerable<Common.Queryable.Hoteli_ProductPerson> deleted = this.Query(deletedIds.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Hoteli_ProductPerson>)deleted, deletedIds.Select(item => item.ID), item => item.ID);
            IEnumerable<Common.Queryable.Hoteli_ProductPerson> updated = this.Query(updatedNew.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Hoteli_ProductPerson>)updated, updatedNew.Select(item => item.ID), item => item.ID);

            AutoCodeHelper.UpdateCodesWithoutCache(
                _executionContext.SqlExecuter, "Hoteli.ProductPerson", "Code",
                insertedNew.Select(item => AutoCodeItem.Create(item, item.Code/*AutoCodePropertyInfo Grouping Hoteli.ProductPerson.Code*/)).ToList(),
                (item, newCode) => item.Code = newCode/*AutoCodePropertyInfo GroupColumnMetadata Hoteli.ProductPerson.Code*/);

            /*DataStructureInfo WritableOrm OldDataLoaded Hoteli.ProductPerson*/

            /*DataStructureInfo WritableOrm ProcessedOldData Hoteli.ProductPerson*/

            DomHelper.SaveOperation saveOperation = DomHelper.SaveOperation.None;
            try
            {
                if (deletedIds.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Delete;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in deletedIds.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (updatedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Update;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in updatedNew.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (insertedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Insert;
                    _executionContext.EntityFrameworkContext.Hoteli_ProductPerson.AddRange(insertedNew.Select(item => item.ToNavigation()));
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                saveOperation = DomHelper.SaveOperation.None;
                _executionContext.EntityFrameworkContext.ClearCache();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException saveException)
            {
                DomHelper.ThrowIfSavingNonexistentId(saveException, checkUserPermissions, saveOperation);
        		Rhetos.RhetosException interpretedException = _sqlUtility.InterpretSqlException(saveException);
        		if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnInsertUpdate(interpretedException, @"Hoteli.Person", @"ID", @"FK_ProductPerson_Person_OwnerNameID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Hoteli.ProductPerson,Property:OwnerNameID,Referenced:Hoteli.Person";
                if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnInsertUpdate(interpretedException, @"Hoteli.Product", @"ID", @"FK_ProductPerson_Product_ProductID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Hoteli.ProductPerson,Property:ProductID,Referenced:Hoteli.Product";
                if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsUniqueError(interpretedException, @"Hoteli.ProductPerson", @"IX_ProductPerson_Code"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Hoteli.ProductPerson,Property:Code";
                /*DataStructureInfo WritableOrm OnDatabaseError Hoteli.ProductPerson*/
                if (checkUserPermissions)
                    Rhetos.Utilities.MsSqlUtility.ThrowIfPrimaryKeyErrorOnInsert(interpretedException, "Hoteli.ProductPerson");

                if (interpretedException != null)
        			Rhetos.Utilities.ExceptionsUtility.Rethrow(interpretedException);
                var sqlException = _sqlUtility.ExtractSqlException(saveException);
                if (sqlException != null)
                    Rhetos.Utilities.ExceptionsUtility.Rethrow(sqlException);
                throw;
            }

            deleted = null;
            updated = this.Query(updatedNew.Select(item => item.ID));
            IEnumerable<Common.Queryable.Hoteli_ProductPerson> inserted = this.Query(insertedNew.Select(item => item.ID));

            bool allEffectsCompleted = false;
            try
            {
                /*DataStructureInfo WritableOrm OnSaveTag1 Hoteli.ProductPerson*/

                /*DataStructureInfo WritableOrm OnSaveTag2 Hoteli.ProductPerson*/

                Rhetos.Dom.DefaultConcepts.InvalidDataMessage.ValidateOnSave(insertedNew, updatedNew, this, "Hoteli.ProductPerson");

                /*DataStructureInfo WritableOrm AfterSave Hoteli.ProductPerson*/

                allEffectsCompleted = true;
            }
            finally
            {
                if (!allEffectsCompleted)
                    _executionContext.PersistenceTransaction.DiscardChanges();
            }
        }

        public IEnumerable<Rhetos.Dom.DefaultConcepts.InvalidDataMessage> Validate(IList<Guid> ids, bool onSave)
        {
            if (onSave)
            {
                var errorIds = this.Filter(this.Query(ids), new SystemRequiredCode()).Select(item => item.ID).ToArray();
                if (errorIds.Count() > 0)
                    foreach (var error in GetErrorMessage_SystemRequiredCode(errorIds))
                        yield return error;
            }
            /*DataStructureInfo WritableOrm OnSaveValidate Hoteli.ProductPerson*/
            yield break;
        }

        public IEnumerable<InvalidDataMessage> GetErrorMessage_SystemRequiredCode(IEnumerable<Guid> invalidData_Ids)
        {
            const string invalidData_Description = @"System required property {0} is not set.";
            IDictionary<string, object> metadata = new Dictionary<string, object>();
            metadata["Validation"] = @"SystemRequiredCode";
            metadata[@"Property"] = @"Code";
            /*InvalidDataInfo ErrorMetadata Hoteli.ProductPerson.SystemRequiredCode*/
            return invalidData_Ids.Select(id => new InvalidDataMessage
            {
                ID = id,
                Message = invalidData_Description,
                MessageParameters = new object[] { @"ShortString Hoteli.ProductPerson.Code" },
                Metadata = metadata
            });
            // /*InvalidDataInfo OverrideUserMessages Hoteli.ProductPerson.SystemRequiredCode*/ return invalidData_Ids.Select(id => new InvalidDataMessage { ID = id, Message = invalidData_Description, Metadata = metadata });
        }

        public IQueryable<Common.Queryable.Hoteli_ProductPerson> Filter(IQueryable<Common.Queryable.Hoteli_ProductPerson> localSource, Hoteli.SystemRequiredCode localParameter)
        {
            Func<IQueryable<Common.Queryable.Hoteli_ProductPerson>, Common.DomRepository, Hoteli.SystemRequiredCode/*ComposableFilterByInfo AdditionalParametersType Hoteli.ProductPerson.'Hoteli.SystemRequiredCode'*/, IQueryable<Common.Queryable.Hoteli_ProductPerson>> filterFunction =
            (source, repository, parameter) => source.Where(item => item.Code == null);

            /*ComposableFilterByInfo BeforeFilter Hoteli.ProductPerson.'Hoteli.SystemRequiredCode'*/
            return filterFunction(localSource, _domRepository, localParameter/*ComposableFilterByInfo AdditionalParametersArgument Hoteli.ProductPerson.'Hoteli.SystemRequiredCode'*/);
        }

        public global::Hoteli.ProductPerson[] Filter(Hoteli.SystemRequiredCode filter_Parameter)
        {
            Func<Common.DomRepository, Hoteli.SystemRequiredCode/*FilterByInfo AdditionalParametersType Hoteli.ProductPerson.'Hoteli.SystemRequiredCode'*/, Hoteli.ProductPerson[]> filter_Function =
                (repository, parameter) => repository.Hoteli.ProductPerson.Filter(repository.Hoteli.ProductPerson.Query(), parameter).ToArray();

            return filter_Function(_domRepository, filter_Parameter/*FilterByInfo AdditionalParametersArgument Hoteli.ProductPerson.'Hoteli.SystemRequiredCode'*/);
        }

        /*DataStructureInfo RepositoryMembers Hoteli.ProductPerson*/
    }

    /*DataStructureInfo RepositoryAttributes Hoteli.ProductHotel*/
    public class ProductHotel_Repository : /*DataStructureInfo OverrideBaseType Hoteli.ProductHotel*/ Common.OrmRepositoryBase<Common.Queryable.Hoteli_ProductHotel, Hoteli.ProductHotel> // Common.QueryableRepositoryBase<Common.Queryable.Hoteli_ProductHotel, Hoteli.ProductHotel> // Common.ReadableRepositoryBase<Hoteli.ProductHotel> // global::Common.RepositoryBase
        , IWritableRepository<Hoteli.ProductHotel>, IValidateRepository/*DataStructureInfo RepositoryInterface Hoteli.ProductHotel*/
    {
        private readonly Rhetos.Utilities.ISqlUtility _sqlUtility;
        /*DataStructureInfo RepositoryPrivateMembers Hoteli.ProductHotel*/

        public ProductHotel_Repository(Common.DomRepository domRepository, Common.ExecutionContext executionContext, Rhetos.Utilities.ISqlUtility _sqlUtility/*DataStructureInfo RepositoryConstructorArguments Hoteli.ProductHotel*/)
        {
            _domRepository = domRepository;
            _executionContext = executionContext;
            this._sqlUtility = _sqlUtility;
            /*DataStructureInfo RepositoryConstructorCode Hoteli.ProductHotel*/
        }

        [Obsolete("Use Load() or Query() method.")]
        public override global::Hoteli.ProductHotel[] All()
        {
            return Query().ToSimple().ToArray();
        }

        public override IQueryable<Common.Queryable.Hoteli_ProductHotel> Query()
        {
            /*DataStructureInfo RepositoryBeforeQuery Hoteli.ProductHotel*/
            return _executionContext.EntityFrameworkContext.Hoteli_ProductHotel.AsNoTracking();
        }

        public void Save(IEnumerable<Hoteli.ProductHotel> insertedNew, IEnumerable<Hoteli.ProductHotel> updatedNew, IEnumerable<Hoteli.ProductHotel> deletedIds, bool checkUserPermissions = false)
        {
            if (!DomHelper.CleanUpSaveMethodArguments(ref insertedNew, ref updatedNew, ref deletedIds))
                return;

            /*DataStructureInfo WritableOrm ClearContext Hoteli.ProductHotel*/

            {
                var invalidItem = insertedNew.Concat(updatedNew).Where(newItem => newItem.Code != null && newItem.Code.Length > 256).FirstOrDefault();
                if (invalidItem != null)
                    throw new Rhetos.UserException(
                        "Maximum length of property {0} is {1}.",
                        new[] { "ProductHotel.Code", "256" },
                        "DataStructure:Hoteli.ProductHotel,ID:" + invalidItem.ID.ToString() + ",Property:Code",
                        null);
            }
            /*DataStructureInfo WritableOrm ArgumentValidation Hoteli.ProductHotel*/

            /*DataStructureInfo WritableOrm Initialization Hoteli.ProductHotel*/

            // Using old data, including lazy loading of navigation properties:
            IEnumerable<Common.Queryable.Hoteli_ProductHotel> deleted = this.Query(deletedIds.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Hoteli_ProductHotel>)deleted, deletedIds.Select(item => item.ID), item => item.ID);
            IEnumerable<Common.Queryable.Hoteli_ProductHotel> updated = this.Query(updatedNew.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Hoteli_ProductHotel>)updated, updatedNew.Select(item => item.ID), item => item.ID);

            AutoCodeHelper.UpdateCodesWithoutCache(
                _executionContext.SqlExecuter, "Hoteli.ProductHotel", "Code",
                insertedNew.Select(item => AutoCodeItem.Create(item, item.Code/*AutoCodePropertyInfo Grouping Hoteli.ProductHotel.Code*/)).ToList(),
                (item, newCode) => item.Code = newCode/*AutoCodePropertyInfo GroupColumnMetadata Hoteli.ProductHotel.Code*/);

            /*DataStructureInfo WritableOrm OldDataLoaded Hoteli.ProductHotel*/

            /*DataStructureInfo WritableOrm ProcessedOldData Hoteli.ProductHotel*/

            DomHelper.SaveOperation saveOperation = DomHelper.SaveOperation.None;
            try
            {
                if (deletedIds.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Delete;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in deletedIds.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (updatedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Update;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in updatedNew.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (insertedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Insert;
                    _executionContext.EntityFrameworkContext.Hoteli_ProductHotel.AddRange(insertedNew.Select(item => item.ToNavigation()));
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                saveOperation = DomHelper.SaveOperation.None;
                _executionContext.EntityFrameworkContext.ClearCache();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException saveException)
            {
                DomHelper.ThrowIfSavingNonexistentId(saveException, checkUserPermissions, saveOperation);
        		Rhetos.RhetosException interpretedException = _sqlUtility.InterpretSqlException(saveException);
        		if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnInsertUpdate(interpretedException, @"Hoteli.Hotel", @"ID", @"FK_ProductHotel_Hotel_OwnerNameID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Hoteli.ProductHotel,Property:OwnerNameID,Referenced:Hoteli.Hotel";
                if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnInsertUpdate(interpretedException, @"Hoteli.Product", @"ID", @"FK_ProductHotel_Product_ProductID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Hoteli.ProductHotel,Property:ProductID,Referenced:Hoteli.Product";
                if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsUniqueError(interpretedException, @"Hoteli.ProductHotel", @"IX_ProductHotel_Code"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Hoteli.ProductHotel,Property:Code";
                /*DataStructureInfo WritableOrm OnDatabaseError Hoteli.ProductHotel*/
                if (checkUserPermissions)
                    Rhetos.Utilities.MsSqlUtility.ThrowIfPrimaryKeyErrorOnInsert(interpretedException, "Hoteli.ProductHotel");

                if (interpretedException != null)
        			Rhetos.Utilities.ExceptionsUtility.Rethrow(interpretedException);
                var sqlException = _sqlUtility.ExtractSqlException(saveException);
                if (sqlException != null)
                    Rhetos.Utilities.ExceptionsUtility.Rethrow(sqlException);
                throw;
            }

            deleted = null;
            updated = this.Query(updatedNew.Select(item => item.ID));
            IEnumerable<Common.Queryable.Hoteli_ProductHotel> inserted = this.Query(insertedNew.Select(item => item.ID));

            bool allEffectsCompleted = false;
            try
            {
                /*DataStructureInfo WritableOrm OnSaveTag1 Hoteli.ProductHotel*/

                /*DataStructureInfo WritableOrm OnSaveTag2 Hoteli.ProductHotel*/

                Rhetos.Dom.DefaultConcepts.InvalidDataMessage.ValidateOnSave(insertedNew, updatedNew, this, "Hoteli.ProductHotel");

                /*DataStructureInfo WritableOrm AfterSave Hoteli.ProductHotel*/

                allEffectsCompleted = true;
            }
            finally
            {
                if (!allEffectsCompleted)
                    _executionContext.PersistenceTransaction.DiscardChanges();
            }
        }

        public IEnumerable<Rhetos.Dom.DefaultConcepts.InvalidDataMessage> Validate(IList<Guid> ids, bool onSave)
        {
            if (onSave)
            {
                var errorIds = this.Filter(this.Query(ids), new SystemRequiredCode()).Select(item => item.ID).ToArray();
                if (errorIds.Count() > 0)
                    foreach (var error in GetErrorMessage_SystemRequiredCode(errorIds))
                        yield return error;
            }
            /*DataStructureInfo WritableOrm OnSaveValidate Hoteli.ProductHotel*/
            yield break;
        }

        public IEnumerable<InvalidDataMessage> GetErrorMessage_SystemRequiredCode(IEnumerable<Guid> invalidData_Ids)
        {
            const string invalidData_Description = @"System required property {0} is not set.";
            IDictionary<string, object> metadata = new Dictionary<string, object>();
            metadata["Validation"] = @"SystemRequiredCode";
            metadata[@"Property"] = @"Code";
            /*InvalidDataInfo ErrorMetadata Hoteli.ProductHotel.SystemRequiredCode*/
            return invalidData_Ids.Select(id => new InvalidDataMessage
            {
                ID = id,
                Message = invalidData_Description,
                MessageParameters = new object[] { @"ShortString Hoteli.ProductHotel.Code" },
                Metadata = metadata
            });
            // /*InvalidDataInfo OverrideUserMessages Hoteli.ProductHotel.SystemRequiredCode*/ return invalidData_Ids.Select(id => new InvalidDataMessage { ID = id, Message = invalidData_Description, Metadata = metadata });
        }

        public IQueryable<Common.Queryable.Hoteli_ProductHotel> Filter(IQueryable<Common.Queryable.Hoteli_ProductHotel> localSource, Hoteli.SystemRequiredCode localParameter)
        {
            Func<IQueryable<Common.Queryable.Hoteli_ProductHotel>, Common.DomRepository, Hoteli.SystemRequiredCode/*ComposableFilterByInfo AdditionalParametersType Hoteli.ProductHotel.'Hoteli.SystemRequiredCode'*/, IQueryable<Common.Queryable.Hoteli_ProductHotel>> filterFunction =
            (source, repository, parameter) => source.Where(item => item.Code == null);

            /*ComposableFilterByInfo BeforeFilter Hoteli.ProductHotel.'Hoteli.SystemRequiredCode'*/
            return filterFunction(localSource, _domRepository, localParameter/*ComposableFilterByInfo AdditionalParametersArgument Hoteli.ProductHotel.'Hoteli.SystemRequiredCode'*/);
        }

        public global::Hoteli.ProductHotel[] Filter(Hoteli.SystemRequiredCode filter_Parameter)
        {
            Func<Common.DomRepository, Hoteli.SystemRequiredCode/*FilterByInfo AdditionalParametersType Hoteli.ProductHotel.'Hoteli.SystemRequiredCode'*/, Hoteli.ProductHotel[]> filter_Function =
                (repository, parameter) => repository.Hoteli.ProductHotel.Filter(repository.Hoteli.ProductHotel.Query(), parameter).ToArray();

            return filter_Function(_domRepository, filter_Parameter/*FilterByInfo AdditionalParametersArgument Hoteli.ProductHotel.'Hoteli.SystemRequiredCode'*/);
        }

        /*DataStructureInfo RepositoryMembers Hoteli.ProductHotel*/
    }

    /*DataStructureInfo RepositoryAttributes Hoteli.Product*/
    public class Product_Repository : /*DataStructureInfo OverrideBaseType Hoteli.Product*/ Common.OrmRepositoryBase<Common.Queryable.Hoteli_Product, Hoteli.Product> // Common.QueryableRepositoryBase<Common.Queryable.Hoteli_Product, Hoteli.Product> // Common.ReadableRepositoryBase<Hoteli.Product> // global::Common.RepositoryBase
        , IWritableRepository<Hoteli.Product>, IValidateRepository/*DataStructureInfo RepositoryInterface Hoteli.Product*/
    {
        private readonly Rhetos.Utilities.ISqlUtility _sqlUtility;
        /*DataStructureInfo RepositoryPrivateMembers Hoteli.Product*/

        public Product_Repository(Common.DomRepository domRepository, Common.ExecutionContext executionContext, Rhetos.Utilities.ISqlUtility _sqlUtility/*DataStructureInfo RepositoryConstructorArguments Hoteli.Product*/)
        {
            _domRepository = domRepository;
            _executionContext = executionContext;
            this._sqlUtility = _sqlUtility;
            /*DataStructureInfo RepositoryConstructorCode Hoteli.Product*/
        }

        [Obsolete("Use Load() or Query() method.")]
        public override global::Hoteli.Product[] All()
        {
            return Query().ToSimple().ToArray();
        }

        public override IQueryable<Common.Queryable.Hoteli_Product> Query()
        {
            /*DataStructureInfo RepositoryBeforeQuery Hoteli.Product*/
            return _executionContext.EntityFrameworkContext.Hoteli_Product.AsNoTracking();
        }

        public void Save(IEnumerable<Hoteli.Product> insertedNew, IEnumerable<Hoteli.Product> updatedNew, IEnumerable<Hoteli.Product> deletedIds, bool checkUserPermissions = false)
        {
            if (!DomHelper.CleanUpSaveMethodArguments(ref insertedNew, ref updatedNew, ref deletedIds))
                return;

            /*DataStructureInfo WritableOrm ClearContext Hoteli.Product*/

            {
                var invalidItem = insertedNew.Concat(updatedNew).Where(newItem => newItem.Code != null && newItem.Code.Length > 256).FirstOrDefault();
                if (invalidItem != null)
                    throw new Rhetos.UserException(
                        "Maximum length of property {0} is {1}.",
                        new[] { "Product.Code", "256" },
                        "DataStructure:Hoteli.Product,ID:" + invalidItem.ID.ToString() + ",Property:Code",
                        null);
            }
            /*DataStructureInfo WritableOrm ArgumentValidation Hoteli.Product*/

            /*DataStructureInfo WritableOrm Initialization Hoteli.Product*/

            // Using old data, including lazy loading of navigation properties:
            IEnumerable<Common.Queryable.Hoteli_Product> deleted = this.Query(deletedIds.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Hoteli_Product>)deleted, deletedIds.Select(item => item.ID), item => item.ID);
            IEnumerable<Common.Queryable.Hoteli_Product> updated = this.Query(updatedNew.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Hoteli_Product>)updated, updatedNew.Select(item => item.ID), item => item.ID);

            AutoCodeHelper.UpdateCodesWithoutCache(
                _executionContext.SqlExecuter, "Hoteli.Product", "Code",
                insertedNew.Select(item => AutoCodeItem.Create(item, item.Code/*AutoCodePropertyInfo Grouping Hoteli.Product.Code*/)).ToList(),
                (item, newCode) => item.Code = newCode/*AutoCodePropertyInfo GroupColumnMetadata Hoteli.Product.Code*/);

            /*DataStructureInfo WritableOrm OldDataLoaded Hoteli.Product*/

            /*DataStructureInfo WritableOrm ProcessedOldData Hoteli.Product*/

            DomHelper.SaveOperation saveOperation = DomHelper.SaveOperation.None;
            try
            {
                if (deletedIds.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Delete;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in deletedIds.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (updatedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Update;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in updatedNew.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (insertedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Insert;
                    _executionContext.EntityFrameworkContext.Hoteli_Product.AddRange(insertedNew.Select(item => item.ToNavigation()));
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                saveOperation = DomHelper.SaveOperation.None;
                _executionContext.EntityFrameworkContext.ClearCache();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException saveException)
            {
                DomHelper.ThrowIfSavingNonexistentId(saveException, checkUserPermissions, saveOperation);
        		Rhetos.RhetosException interpretedException = _sqlUtility.InterpretSqlException(saveException);
        		if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnDelete(interpretedException, @"Hoteli.ProductPerson", @"ProductID", @"FK_ProductPerson_Product_ProductID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Hoteli.ProductPerson,Property:ProductID,Referenced:Hoteli.Product";
                if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnDelete(interpretedException, @"Hoteli.ProductHotel", @"ProductID", @"FK_ProductHotel_Product_ProductID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Hoteli.ProductHotel,Property:ProductID,Referenced:Hoteli.Product";
                if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnInsertUpdate(interpretedException, @"Hoteli.Hotel", @"ID", @"FK_Product_Hotel_HotelSaloonID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Hoteli.Product,Property:HotelSaloonID,Referenced:Hoteli.Hotel";
                if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsUniqueError(interpretedException, @"Hoteli.Product", @"IX_Product_Code"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Hoteli.Product,Property:Code";
                /*DataStructureInfo WritableOrm OnDatabaseError Hoteli.Product*/
                if (checkUserPermissions)
                    Rhetos.Utilities.MsSqlUtility.ThrowIfPrimaryKeyErrorOnInsert(interpretedException, "Hoteli.Product");

                if (interpretedException != null)
        			Rhetos.Utilities.ExceptionsUtility.Rethrow(interpretedException);
                var sqlException = _sqlUtility.ExtractSqlException(saveException);
                if (sqlException != null)
                    Rhetos.Utilities.ExceptionsUtility.Rethrow(sqlException);
                throw;
            }

            deleted = null;
            updated = this.Query(updatedNew.Select(item => item.ID));
            IEnumerable<Common.Queryable.Hoteli_Product> inserted = this.Query(insertedNew.Select(item => item.ID));

            bool allEffectsCompleted = false;
            try
            {
                /*DataStructureInfo WritableOrm OnSaveTag1 Hoteli.Product*/

                /*DataStructureInfo WritableOrm OnSaveTag2 Hoteli.Product*/

                Rhetos.Dom.DefaultConcepts.InvalidDataMessage.ValidateOnSave(insertedNew, updatedNew, this, "Hoteli.Product");

                /*DataStructureInfo WritableOrm AfterSave Hoteli.Product*/

                allEffectsCompleted = true;
            }
            finally
            {
                if (!allEffectsCompleted)
                    _executionContext.PersistenceTransaction.DiscardChanges();
            }
        }

        public IEnumerable<Rhetos.Dom.DefaultConcepts.InvalidDataMessage> Validate(IList<Guid> ids, bool onSave)
        {
            if (onSave)
            {
                var errorIds = this.Filter(this.Query(ids), new SystemRequiredCode()).Select(item => item.ID).ToArray();
                if (errorIds.Count() > 0)
                    foreach (var error in GetErrorMessage_SystemRequiredCode(errorIds))
                        yield return error;
            }
            /*DataStructureInfo WritableOrm OnSaveValidate Hoteli.Product*/
            yield break;
        }

        public IEnumerable<InvalidDataMessage> GetErrorMessage_SystemRequiredCode(IEnumerable<Guid> invalidData_Ids)
        {
            const string invalidData_Description = @"System required property {0} is not set.";
            IDictionary<string, object> metadata = new Dictionary<string, object>();
            metadata["Validation"] = @"SystemRequiredCode";
            metadata[@"Property"] = @"Code";
            /*InvalidDataInfo ErrorMetadata Hoteli.Product.SystemRequiredCode*/
            return invalidData_Ids.Select(id => new InvalidDataMessage
            {
                ID = id,
                Message = invalidData_Description,
                MessageParameters = new object[] { @"ShortString Hoteli.Product.Code" },
                Metadata = metadata
            });
            // /*InvalidDataInfo OverrideUserMessages Hoteli.Product.SystemRequiredCode*/ return invalidData_Ids.Select(id => new InvalidDataMessage { ID = id, Message = invalidData_Description, Metadata = metadata });
        }

        public IQueryable<Common.Queryable.Hoteli_Product> Filter(IQueryable<Common.Queryable.Hoteli_Product> localSource, Hoteli.SystemRequiredCode localParameter)
        {
            Func<IQueryable<Common.Queryable.Hoteli_Product>, Common.DomRepository, Hoteli.SystemRequiredCode/*ComposableFilterByInfo AdditionalParametersType Hoteli.Product.'Hoteli.SystemRequiredCode'*/, IQueryable<Common.Queryable.Hoteli_Product>> filterFunction =
            (source, repository, parameter) => source.Where(item => item.Code == null);

            /*ComposableFilterByInfo BeforeFilter Hoteli.Product.'Hoteli.SystemRequiredCode'*/
            return filterFunction(localSource, _domRepository, localParameter/*ComposableFilterByInfo AdditionalParametersArgument Hoteli.Product.'Hoteli.SystemRequiredCode'*/);
        }

        public global::Hoteli.Product[] Filter(Hoteli.SystemRequiredCode filter_Parameter)
        {
            Func<Common.DomRepository, Hoteli.SystemRequiredCode/*FilterByInfo AdditionalParametersType Hoteli.Product.'Hoteli.SystemRequiredCode'*/, Hoteli.Product[]> filter_Function =
                (repository, parameter) => repository.Hoteli.Product.Filter(repository.Hoteli.Product.Query(), parameter).ToArray();

            return filter_Function(_domRepository, filter_Parameter/*FilterByInfo AdditionalParametersArgument Hoteli.Product.'Hoteli.SystemRequiredCode'*/);
        }

        /*DataStructureInfo RepositoryMembers Hoteli.Product*/
    }

    /*DataStructureInfo RepositoryAttributes Hoteli.Insert5Hotels*/
    public class Insert5Hotels_Repository : /*DataStructureInfo OverrideBaseType Hoteli.Insert5Hotels*/ global::Common.RepositoryBase
        , IActionRepository/*DataStructureInfo RepositoryInterface Hoteli.Insert5Hotels*/
    {
        /*DataStructureInfo RepositoryPrivateMembers Hoteli.Insert5Hotels*/

        public Insert5Hotels_Repository(Common.DomRepository domRepository, Common.ExecutionContext executionContext/*DataStructureInfo RepositoryConstructorArguments Hoteli.Insert5Hotels*/)
        {
            _domRepository = domRepository;
            _executionContext = executionContext;
            /*DataStructureInfo RepositoryConstructorCode Hoteli.Insert5Hotels*/
        }

        public void Execute(Hoteli.Insert5Hotels actionParameter)
        {
            Action<Hoteli.Insert5Hotels, Common.DomRepository, IUserInfo/*DataStructureInfo AdditionalParametersType Hoteli.Insert5Hotels*/> action_Object = ( parametar ,repository, userInfo ) => 
     {
         for(int i=0;i<5;i++) {
         var noviHotel = new Hoteli.Hotel { Code="+++", Name="A" };
         repository.Hoteli.Hotel.Insert( noviHotel );
         }
     }
    ;

            bool allEffectsCompleted = false;
            try
            {
                /*ActionInfo BeforeAction Hoteli.Insert5Hotels*/
                action_Object(actionParameter, _domRepository, _executionContext.UserInfo/*DataStructureInfo AdditionalParametersArgument Hoteli.Insert5Hotels*/);
                /*ActionInfo AfterAction Hoteli.Insert5Hotels*/
                allEffectsCompleted = true;
            }
            finally
            {
                if (!allEffectsCompleted)
                    _executionContext.PersistenceTransaction.DiscardChanges();
            }
        }

        void IActionRepository.Execute(object actionParameter)
        {
            Execute((Hoteli.Insert5Hotels) actionParameter);
        }

        /*DataStructureInfo RepositoryMembers Hoteli.Insert5Hotels*/
    }

    /*DataStructureInfo RepositoryAttributes Hoteli.Insert5Rooms*/
    public class Insert5Rooms_Repository : /*DataStructureInfo OverrideBaseType Hoteli.Insert5Rooms*/ global::Common.RepositoryBase
        , IActionRepository/*DataStructureInfo RepositoryInterface Hoteli.Insert5Rooms*/
    {
        /*DataStructureInfo RepositoryPrivateMembers Hoteli.Insert5Rooms*/

        public Insert5Rooms_Repository(Common.DomRepository domRepository, Common.ExecutionContext executionContext/*DataStructureInfo RepositoryConstructorArguments Hoteli.Insert5Rooms*/)
        {
            _domRepository = domRepository;
            _executionContext = executionContext;
            /*DataStructureInfo RepositoryConstructorCode Hoteli.Insert5Rooms*/
        }

        public void Execute(Hoteli.Insert5Rooms actionParameter)
        {
            Action<Hoteli.Insert5Rooms, Common.DomRepository, IUserInfo/*DataStructureInfo AdditionalParametersType Hoteli.Insert5Rooms*/> action_Object = ( parametar ,repository, userInfo ) => 
     {
         for(int i=0;i<5;i++) {
         var noviHotel = new Hoteli.Hotel { Code="+++", Name="A" };
         repository.Hoteli.Hotel.Insert( noviHotel );
         }
     }
    ;

            bool allEffectsCompleted = false;
            try
            {
                /*ActionInfo BeforeAction Hoteli.Insert5Rooms*/
                action_Object(actionParameter, _domRepository, _executionContext.UserInfo/*DataStructureInfo AdditionalParametersArgument Hoteli.Insert5Rooms*/);
                /*ActionInfo AfterAction Hoteli.Insert5Rooms*/
                allEffectsCompleted = true;
            }
            finally
            {
                if (!allEffectsCompleted)
                    _executionContext.PersistenceTransaction.DiscardChanges();
            }
        }

        void IActionRepository.Execute(object actionParameter)
        {
            Execute((Hoteli.Insert5Rooms) actionParameter);
        }

        /*DataStructureInfo RepositoryMembers Hoteli.Insert5Rooms*/
    }

    /*DataStructureInfo RepositoryAttributes Hoteli.Insert6Rooms*/
    public class Insert6Rooms_Repository : /*DataStructureInfo OverrideBaseType Hoteli.Insert6Rooms*/ global::Common.RepositoryBase
        , IActionRepository/*DataStructureInfo RepositoryInterface Hoteli.Insert6Rooms*/
    {
        /*DataStructureInfo RepositoryPrivateMembers Hoteli.Insert6Rooms*/

        public Insert6Rooms_Repository(Common.DomRepository domRepository, Common.ExecutionContext executionContext/*DataStructureInfo RepositoryConstructorArguments Hoteli.Insert6Rooms*/)
        {
            _domRepository = domRepository;
            _executionContext = executionContext;
            /*DataStructureInfo RepositoryConstructorCode Hoteli.Insert6Rooms*/
        }

        public void Execute(Hoteli.Insert6Rooms actionParameter)
        {
            Action<Hoteli.Insert6Rooms, Common.DomRepository, IUserInfo/*DataStructureInfo AdditionalParametersType Hoteli.Insert6Rooms*/> action_Object = ( parametar ,repository, userInfo ) => 
     {
         for(int i=0;i<6;i++) {
         var noviHotel = new Hoteli.Hotel { Code="+++", Name="A" };
         repository.Hoteli.Hotel.Insert( noviHotel );
         }
     }
    ;

            bool allEffectsCompleted = false;
            try
            {
                /*ActionInfo BeforeAction Hoteli.Insert6Rooms*/
                action_Object(actionParameter, _domRepository, _executionContext.UserInfo/*DataStructureInfo AdditionalParametersArgument Hoteli.Insert6Rooms*/);
                /*ActionInfo AfterAction Hoteli.Insert6Rooms*/
                allEffectsCompleted = true;
            }
            finally
            {
                if (!allEffectsCompleted)
                    _executionContext.PersistenceTransaction.DiscardChanges();
            }
        }

        void IActionRepository.Execute(object actionParameter)
        {
            Execute((Hoteli.Insert6Rooms) actionParameter);
        }

        /*DataStructureInfo RepositoryMembers Hoteli.Insert6Rooms*/
    }

    /*DataStructureInfo RepositoryAttributes Hoteli.ReservationInfo*/
    public class ReservationInfo_Repository : /*DataStructureInfo OverrideBaseType Hoteli.ReservationInfo*/ Common.OrmRepositoryBase<Common.Queryable.Hoteli_ReservationInfo, Hoteli.ReservationInfo> // Common.QueryableRepositoryBase<Common.Queryable.Hoteli_ReservationInfo, Hoteli.ReservationInfo> // Common.ReadableRepositoryBase<Hoteli.ReservationInfo> // global::Common.RepositoryBase
        /*DataStructureInfo RepositoryInterface Hoteli.ReservationInfo*/
    {
        /*DataStructureInfo RepositoryPrivateMembers Hoteli.ReservationInfo*/

        public ReservationInfo_Repository(Common.DomRepository domRepository, Common.ExecutionContext executionContext/*DataStructureInfo RepositoryConstructorArguments Hoteli.ReservationInfo*/)
        {
            _domRepository = domRepository;
            _executionContext = executionContext;
            /*DataStructureInfo RepositoryConstructorCode Hoteli.ReservationInfo*/
        }

        [Obsolete("Use Load() or Query() method.")]
        public override global::Hoteli.ReservationInfo[] All()
        {
            return Query().ToSimple().ToArray();
        }

        public override IQueryable<Common.Queryable.Hoteli_ReservationInfo> Query()
        {
            /*DataStructureInfo RepositoryBeforeQuery Hoteli.ReservationInfo*/
            return _executionContext.EntityFrameworkContext.Hoteli_ReservationInfo.AsNoTracking();
        }

        /*DataStructureInfo RepositoryMembers Hoteli.ReservationInfo*/
    }

    /*ModuleInfo HelperNamespaceMembers Hoteli*/
}

namespace Common._Helper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;
    using Rhetos.Dom.DefaultConcepts;
    using Rhetos.Utilities;

    /*ModuleInfo Using Common*/

    public class _ModuleRepository
    {
        private readonly Rhetos.Extensibility.INamedPlugins<IRepository> _repositories;

        public _ModuleRepository(Rhetos.Extensibility.INamedPlugins<IRepository> repositories)
        {
            _repositories = repositories;
        }

        private AutoCodeCache_Repository _AutoCodeCache_Repository;
        public AutoCodeCache_Repository AutoCodeCache { get { return _AutoCodeCache_Repository ?? (_AutoCodeCache_Repository = (AutoCodeCache_Repository)Rhetos.Extensibility.NamedPluginsExtensions.GetPlugin(_repositories, @"Common.AutoCodeCache")); } }

        private FilterId_Repository _FilterId_Repository;
        public FilterId_Repository FilterId { get { return _FilterId_Repository ?? (_FilterId_Repository = (FilterId_Repository)Rhetos.Extensibility.NamedPluginsExtensions.GetPlugin(_repositories, @"Common.FilterId")); } }

        private KeepSynchronizedMetadata_Repository _KeepSynchronizedMetadata_Repository;
        public KeepSynchronizedMetadata_Repository KeepSynchronizedMetadata { get { return _KeepSynchronizedMetadata_Repository ?? (_KeepSynchronizedMetadata_Repository = (KeepSynchronizedMetadata_Repository)Rhetos.Extensibility.NamedPluginsExtensions.GetPlugin(_repositories, @"Common.KeepSynchronizedMetadata")); } }

        private ExclusiveLock_Repository _ExclusiveLock_Repository;
        public ExclusiveLock_Repository ExclusiveLock { get { return _ExclusiveLock_Repository ?? (_ExclusiveLock_Repository = (ExclusiveLock_Repository)Rhetos.Extensibility.NamedPluginsExtensions.GetPlugin(_repositories, @"Common.ExclusiveLock")); } }

        private SetLock_Repository _SetLock_Repository;
        public SetLock_Repository SetLock { get { return _SetLock_Repository ?? (_SetLock_Repository = (SetLock_Repository)Rhetos.Extensibility.NamedPluginsExtensions.GetPlugin(_repositories, @"Common.SetLock")); } }

        private ReleaseLock_Repository _ReleaseLock_Repository;
        public ReleaseLock_Repository ReleaseLock { get { return _ReleaseLock_Repository ?? (_ReleaseLock_Repository = (ReleaseLock_Repository)Rhetos.Extensibility.NamedPluginsExtensions.GetPlugin(_repositories, @"Common.ReleaseLock")); } }

        private LogReader_Repository _LogReader_Repository;
        public LogReader_Repository LogReader { get { return _LogReader_Repository ?? (_LogReader_Repository = (LogReader_Repository)Rhetos.Extensibility.NamedPluginsExtensions.GetPlugin(_repositories, @"Common.LogReader")); } }

        private LogRelatedItemReader_Repository _LogRelatedItemReader_Repository;
        public LogRelatedItemReader_Repository LogRelatedItemReader { get { return _LogRelatedItemReader_Repository ?? (_LogRelatedItemReader_Repository = (LogRelatedItemReader_Repository)Rhetos.Extensibility.NamedPluginsExtensions.GetPlugin(_repositories, @"Common.LogRelatedItemReader")); } }

        private Log_Repository _Log_Repository;
        public Log_Repository Log { get { return _Log_Repository ?? (_Log_Repository = (Log_Repository)Rhetos.Extensibility.NamedPluginsExtensions.GetPlugin(_repositories, @"Common.Log")); } }

        private AddToLog_Repository _AddToLog_Repository;
        public AddToLog_Repository AddToLog { get { return _AddToLog_Repository ?? (_AddToLog_Repository = (AddToLog_Repository)Rhetos.Extensibility.NamedPluginsExtensions.GetPlugin(_repositories, @"Common.AddToLog")); } }

        private LogRelatedItem_Repository _LogRelatedItem_Repository;
        public LogRelatedItem_Repository LogRelatedItem { get { return _LogRelatedItem_Repository ?? (_LogRelatedItem_Repository = (LogRelatedItem_Repository)Rhetos.Extensibility.NamedPluginsExtensions.GetPlugin(_repositories, @"Common.LogRelatedItem")); } }

        private RelatedEventsSource_Repository _RelatedEventsSource_Repository;
        public RelatedEventsSource_Repository RelatedEventsSource { get { return _RelatedEventsSource_Repository ?? (_RelatedEventsSource_Repository = (RelatedEventsSource_Repository)Rhetos.Extensibility.NamedPluginsExtensions.GetPlugin(_repositories, @"Common.RelatedEventsSource")); } }

        private Claim_Repository _Claim_Repository;
        public Claim_Repository Claim { get { return _Claim_Repository ?? (_Claim_Repository = (Claim_Repository)Rhetos.Extensibility.NamedPluginsExtensions.GetPlugin(_repositories, @"Common.Claim")); } }

        private MyClaim_Repository _MyClaim_Repository;
        public MyClaim_Repository MyClaim { get { return _MyClaim_Repository ?? (_MyClaim_Repository = (MyClaim_Repository)Rhetos.Extensibility.NamedPluginsExtensions.GetPlugin(_repositories, @"Common.MyClaim")); } }

        private Principal_Repository _Principal_Repository;
        public Principal_Repository Principal { get { return _Principal_Repository ?? (_Principal_Repository = (Principal_Repository)Rhetos.Extensibility.NamedPluginsExtensions.GetPlugin(_repositories, @"Common.Principal")); } }

        private PrincipalHasRole_Repository _PrincipalHasRole_Repository;
        public PrincipalHasRole_Repository PrincipalHasRole { get { return _PrincipalHasRole_Repository ?? (_PrincipalHasRole_Repository = (PrincipalHasRole_Repository)Rhetos.Extensibility.NamedPluginsExtensions.GetPlugin(_repositories, @"Common.PrincipalHasRole")); } }

        private Role_Repository _Role_Repository;
        public Role_Repository Role { get { return _Role_Repository ?? (_Role_Repository = (Role_Repository)Rhetos.Extensibility.NamedPluginsExtensions.GetPlugin(_repositories, @"Common.Role")); } }

        private RoleInheritsRole_Repository _RoleInheritsRole_Repository;
        public RoleInheritsRole_Repository RoleInheritsRole { get { return _RoleInheritsRole_Repository ?? (_RoleInheritsRole_Repository = (RoleInheritsRole_Repository)Rhetos.Extensibility.NamedPluginsExtensions.GetPlugin(_repositories, @"Common.RoleInheritsRole")); } }

        private PrincipalPermission_Repository _PrincipalPermission_Repository;
        public PrincipalPermission_Repository PrincipalPermission { get { return _PrincipalPermission_Repository ?? (_PrincipalPermission_Repository = (PrincipalPermission_Repository)Rhetos.Extensibility.NamedPluginsExtensions.GetPlugin(_repositories, @"Common.PrincipalPermission")); } }

        private RolePermission_Repository _RolePermission_Repository;
        public RolePermission_Repository RolePermission { get { return _RolePermission_Repository ?? (_RolePermission_Repository = (RolePermission_Repository)Rhetos.Extensibility.NamedPluginsExtensions.GetPlugin(_repositories, @"Common.RolePermission")); } }

        /*ModuleInfo RepositoryMembers Common*/
    }

    /*DataStructureInfo RepositoryAttributes Common.AutoCodeCache*/
    public class AutoCodeCache_Repository : /*DataStructureInfo OverrideBaseType Common.AutoCodeCache*/ Common.OrmRepositoryBase<Common.Queryable.Common_AutoCodeCache, Common.AutoCodeCache> // Common.QueryableRepositoryBase<Common.Queryable.Common_AutoCodeCache, Common.AutoCodeCache> // Common.ReadableRepositoryBase<Common.AutoCodeCache> // global::Common.RepositoryBase
        , IWritableRepository<Common.AutoCodeCache>, IValidateRepository/*DataStructureInfo RepositoryInterface Common.AutoCodeCache*/
    {
        private readonly Rhetos.Utilities.ISqlUtility _sqlUtility;
        /*DataStructureInfo RepositoryPrivateMembers Common.AutoCodeCache*/

        public AutoCodeCache_Repository(Common.DomRepository domRepository, Common.ExecutionContext executionContext, Rhetos.Utilities.ISqlUtility _sqlUtility/*DataStructureInfo RepositoryConstructorArguments Common.AutoCodeCache*/)
        {
            _domRepository = domRepository;
            _executionContext = executionContext;
            this._sqlUtility = _sqlUtility;
            /*DataStructureInfo RepositoryConstructorCode Common.AutoCodeCache*/
        }

        [Obsolete("Use Load() or Query() method.")]
        public override global::Common.AutoCodeCache[] All()
        {
            return Query().ToSimple().ToArray();
        }

        public override IQueryable<Common.Queryable.Common_AutoCodeCache> Query()
        {
            /*DataStructureInfo RepositoryBeforeQuery Common.AutoCodeCache*/
            return _executionContext.EntityFrameworkContext.Common_AutoCodeCache.AsNoTracking();
        }

        public void Save(IEnumerable<Common.AutoCodeCache> insertedNew, IEnumerable<Common.AutoCodeCache> updatedNew, IEnumerable<Common.AutoCodeCache> deletedIds, bool checkUserPermissions = false)
        {
            if (!DomHelper.CleanUpSaveMethodArguments(ref insertedNew, ref updatedNew, ref deletedIds))
                return;

            /*DataStructureInfo WritableOrm ClearContext Common.AutoCodeCache*/

            {
                var invalidItem = insertedNew.Concat(updatedNew).Where(newItem => newItem.Entity != null && newItem.Entity.Length > 256).FirstOrDefault();
                if (invalidItem != null)
                    throw new Rhetos.UserException(
                        "Maximum length of property {0} is {1}.",
                        new[] { "AutoCodeCache.Entity", "256" },
                        "DataStructure:Common.AutoCodeCache,ID:" + invalidItem.ID.ToString() + ",Property:Entity",
                        null);
            }
            {
                var invalidItem = insertedNew.Concat(updatedNew).Where(newItem => newItem.Property != null && newItem.Property.Length > 256).FirstOrDefault();
                if (invalidItem != null)
                    throw new Rhetos.UserException(
                        "Maximum length of property {0} is {1}.",
                        new[] { "AutoCodeCache.Property", "256" },
                        "DataStructure:Common.AutoCodeCache,ID:" + invalidItem.ID.ToString() + ",Property:Property",
                        null);
            }
            {
                var invalidItem = insertedNew.Concat(updatedNew).Where(newItem => newItem.Grouping != null && newItem.Grouping.Length > 256).FirstOrDefault();
                if (invalidItem != null)
                    throw new Rhetos.UserException(
                        "Maximum length of property {0} is {1}.",
                        new[] { "AutoCodeCache.Grouping", "256" },
                        "DataStructure:Common.AutoCodeCache,ID:" + invalidItem.ID.ToString() + ",Property:Grouping",
                        null);
            }
            {
                var invalidItem = insertedNew.Concat(updatedNew).Where(newItem => newItem.Prefix != null && newItem.Prefix.Length > 256).FirstOrDefault();
                if (invalidItem != null)
                    throw new Rhetos.UserException(
                        "Maximum length of property {0} is {1}.",
                        new[] { "AutoCodeCache.Prefix", "256" },
                        "DataStructure:Common.AutoCodeCache,ID:" + invalidItem.ID.ToString() + ",Property:Prefix",
                        null);
            }
            /*DataStructureInfo WritableOrm ArgumentValidation Common.AutoCodeCache*/

            /*DataStructureInfo WritableOrm Initialization Common.AutoCodeCache*/

            // Using old data, including lazy loading of navigation properties:
            IEnumerable<Common.Queryable.Common_AutoCodeCache> deleted = this.Query(deletedIds.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Common_AutoCodeCache>)deleted, deletedIds.Select(item => item.ID), item => item.ID);
            IEnumerable<Common.Queryable.Common_AutoCodeCache> updated = this.Query(updatedNew.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Common_AutoCodeCache>)updated, updatedNew.Select(item => item.ID), item => item.ID);

            /*DataStructureInfo WritableOrm OldDataLoaded Common.AutoCodeCache*/

            /*DataStructureInfo WritableOrm ProcessedOldData Common.AutoCodeCache*/

            DomHelper.SaveOperation saveOperation = DomHelper.SaveOperation.None;
            try
            {
                if (deletedIds.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Delete;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in deletedIds.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (updatedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Update;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in updatedNew.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (insertedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Insert;
                    _executionContext.EntityFrameworkContext.Common_AutoCodeCache.AddRange(insertedNew.Select(item => item.ToNavigation()));
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                saveOperation = DomHelper.SaveOperation.None;
                _executionContext.EntityFrameworkContext.ClearCache();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException saveException)
            {
                DomHelper.ThrowIfSavingNonexistentId(saveException, checkUserPermissions, saveOperation);
        		Rhetos.RhetosException interpretedException = _sqlUtility.InterpretSqlException(saveException);
        		if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsUniqueError(interpretedException, @"Common.AutoCodeCache", @"IX_AutoCodeCache_Entity_Property_Grouping_Prefix"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Common.AutoCodeCache,Property:Entity Property Grouping Prefix";
                /*DataStructureInfo WritableOrm OnDatabaseError Common.AutoCodeCache*/
                if (checkUserPermissions)
                    Rhetos.Utilities.MsSqlUtility.ThrowIfPrimaryKeyErrorOnInsert(interpretedException, "Common.AutoCodeCache");

                if (interpretedException != null)
        			Rhetos.Utilities.ExceptionsUtility.Rethrow(interpretedException);
                var sqlException = _sqlUtility.ExtractSqlException(saveException);
                if (sqlException != null)
                    Rhetos.Utilities.ExceptionsUtility.Rethrow(sqlException);
                throw;
            }

            deleted = null;
            updated = this.Query(updatedNew.Select(item => item.ID));
            IEnumerable<Common.Queryable.Common_AutoCodeCache> inserted = this.Query(insertedNew.Select(item => item.ID));

            bool allEffectsCompleted = false;
            try
            {
                /*DataStructureInfo WritableOrm OnSaveTag1 Common.AutoCodeCache*/

                /*DataStructureInfo WritableOrm OnSaveTag2 Common.AutoCodeCache*/

                Rhetos.Dom.DefaultConcepts.InvalidDataMessage.ValidateOnSave(insertedNew, updatedNew, this, "Common.AutoCodeCache");

                /*DataStructureInfo WritableOrm AfterSave Common.AutoCodeCache*/

                allEffectsCompleted = true;
            }
            finally
            {
                if (!allEffectsCompleted)
                    _executionContext.PersistenceTransaction.DiscardChanges();
            }
        }

        public IEnumerable<Rhetos.Dom.DefaultConcepts.InvalidDataMessage> Validate(IList<Guid> ids, bool onSave)
        {
            /*DataStructureInfo WritableOrm OnSaveValidate Common.AutoCodeCache*/
            yield break;
        }

        /*DataStructureInfo RepositoryMembers Common.AutoCodeCache*/
    }

    /*DataStructureInfo RepositoryAttributes Common.FilterId*/
    public class FilterId_Repository : /*DataStructureInfo OverrideBaseType Common.FilterId*/ Common.OrmRepositoryBase<Common.Queryable.Common_FilterId, Common.FilterId> // Common.QueryableRepositoryBase<Common.Queryable.Common_FilterId, Common.FilterId> // Common.ReadableRepositoryBase<Common.FilterId> // global::Common.RepositoryBase
        , IWritableRepository<Common.FilterId>, IValidateRepository/*DataStructureInfo RepositoryInterface Common.FilterId*/
    {
        private readonly Rhetos.Utilities.ISqlUtility _sqlUtility;
        /*DataStructureInfo RepositoryPrivateMembers Common.FilterId*/

        public FilterId_Repository(Common.DomRepository domRepository, Common.ExecutionContext executionContext, Rhetos.Utilities.ISqlUtility _sqlUtility/*DataStructureInfo RepositoryConstructorArguments Common.FilterId*/)
        {
            _domRepository = domRepository;
            _executionContext = executionContext;
            this._sqlUtility = _sqlUtility;
            /*DataStructureInfo RepositoryConstructorCode Common.FilterId*/
        }

        [Obsolete("Use Load() or Query() method.")]
        public override global::Common.FilterId[] All()
        {
            return Query().ToSimple().ToArray();
        }

        public override IQueryable<Common.Queryable.Common_FilterId> Query()
        {
            /*DataStructureInfo RepositoryBeforeQuery Common.FilterId*/
            return _executionContext.EntityFrameworkContext.Common_FilterId.AsNoTracking();
        }

        public void Save(IEnumerable<Common.FilterId> insertedNew, IEnumerable<Common.FilterId> updatedNew, IEnumerable<Common.FilterId> deletedIds, bool checkUserPermissions = false)
        {
            if (!DomHelper.CleanUpSaveMethodArguments(ref insertedNew, ref updatedNew, ref deletedIds))
                return;

            /*DataStructureInfo WritableOrm ClearContext Common.FilterId*/

            /*DataStructureInfo WritableOrm ArgumentValidation Common.FilterId*/

            /*DataStructureInfo WritableOrm Initialization Common.FilterId*/

            // Using old data, including lazy loading of navigation properties:
            IEnumerable<Common.Queryable.Common_FilterId> deleted = this.Query(deletedIds.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Common_FilterId>)deleted, deletedIds.Select(item => item.ID), item => item.ID);
            IEnumerable<Common.Queryable.Common_FilterId> updated = this.Query(updatedNew.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Common_FilterId>)updated, updatedNew.Select(item => item.ID), item => item.ID);

            /*DataStructureInfo WritableOrm OldDataLoaded Common.FilterId*/

            /*DataStructureInfo WritableOrm ProcessedOldData Common.FilterId*/

            DomHelper.SaveOperation saveOperation = DomHelper.SaveOperation.None;
            try
            {
                if (deletedIds.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Delete;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in deletedIds.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (updatedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Update;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in updatedNew.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (insertedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Insert;
                    _executionContext.EntityFrameworkContext.Common_FilterId.AddRange(insertedNew.Select(item => item.ToNavigation()));
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                saveOperation = DomHelper.SaveOperation.None;
                _executionContext.EntityFrameworkContext.ClearCache();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException saveException)
            {
                DomHelper.ThrowIfSavingNonexistentId(saveException, checkUserPermissions, saveOperation);
        		Rhetos.RhetosException interpretedException = _sqlUtility.InterpretSqlException(saveException);
        		/*DataStructureInfo WritableOrm OnDatabaseError Common.FilterId*/
                if (checkUserPermissions)
                    Rhetos.Utilities.MsSqlUtility.ThrowIfPrimaryKeyErrorOnInsert(interpretedException, "Common.FilterId");

                if (interpretedException != null)
        			Rhetos.Utilities.ExceptionsUtility.Rethrow(interpretedException);
                var sqlException = _sqlUtility.ExtractSqlException(saveException);
                if (sqlException != null)
                    Rhetos.Utilities.ExceptionsUtility.Rethrow(sqlException);
                throw;
            }

            deleted = null;
            updated = this.Query(updatedNew.Select(item => item.ID));
            IEnumerable<Common.Queryable.Common_FilterId> inserted = this.Query(insertedNew.Select(item => item.ID));

            bool allEffectsCompleted = false;
            try
            {
                /*DataStructureInfo WritableOrm OnSaveTag1 Common.FilterId*/

                /*DataStructureInfo WritableOrm OnSaveTag2 Common.FilterId*/

                Rhetos.Dom.DefaultConcepts.InvalidDataMessage.ValidateOnSave(insertedNew, updatedNew, this, "Common.FilterId");

                /*DataStructureInfo WritableOrm AfterSave Common.FilterId*/

                allEffectsCompleted = true;
            }
            finally
            {
                if (!allEffectsCompleted)
                    _executionContext.PersistenceTransaction.DiscardChanges();
            }
        }

        public IEnumerable<Rhetos.Dom.DefaultConcepts.InvalidDataMessage> Validate(IList<Guid> ids, bool onSave)
        {
            /*DataStructureInfo WritableOrm OnSaveValidate Common.FilterId*/
            yield break;
        }

        /// <summary>
        /// Depending on the ids count, this method will return the list of IDs, or insert the ids to the database and return an SQL query that selects the ids.
        /// EF 6.1.3 has performance issues on Contains function with large lists. It seems to have O(n^2) time complexity.
        /// </summary>
        public IEnumerable<Guid> CreateQueryableFilterIds(IEnumerable<Guid> ids)
        {
            Rhetos.Utilities.CsUtility.Materialize(ref ids);

            if (ids.Count() < 200)
                return ids;

            var handle = Guid.NewGuid();
            string sqlInsertIdFormat = "INSERT INTO Common.FilterId (Handle, Value) VALUES ('" + SqlUtility.GuidToString(handle) + "', '{0}');";

            const int chunkSize = 1000; // Keeping a moderate SQL script size.
            for (int start = 0; start < ids.Count(); start += chunkSize)
            {
                string sqlInsertIds = string.Join("\r\n", ids.Skip(start).Take(chunkSize)
                        .Select(id => string.Format(sqlInsertIdFormat, SqlUtility.GuidToString(id))));
                _executionContext.SqlExecuter.ExecuteSql(sqlInsertIds);
            }

            // Delete temporary data when closing the connection. The data must remain in the database until the returned query is used.
            string deleteFilterIds = "DELETE FROM Common.FilterId WHERE Handle = " + SqlUtility.QuoteGuid(handle);
            _executionContext.PersistenceTransaction.BeforeClose += () =>
                {
                    try
                    {
                        _executionContext.SqlExecuter.ExecuteSql(deleteFilterIds);
                    }
                    catch
                    {
                        // Cleanup error may be ignored. The temporary data may be deleted on regular maintenance.
                    }
                };

            return Query().Where(filterId => filterId.Handle == handle).Select(filterId => filterId.Value.Value);
        }

        /*DataStructureInfo RepositoryMembers Common.FilterId*/
    }

    /*DataStructureInfo RepositoryAttributes Common.KeepSynchronizedMetadata*/
    public class KeepSynchronizedMetadata_Repository : /*DataStructureInfo OverrideBaseType Common.KeepSynchronizedMetadata*/ Common.OrmRepositoryBase<Common.Queryable.Common_KeepSynchronizedMetadata, Common.KeepSynchronizedMetadata> // Common.QueryableRepositoryBase<Common.Queryable.Common_KeepSynchronizedMetadata, Common.KeepSynchronizedMetadata> // Common.ReadableRepositoryBase<Common.KeepSynchronizedMetadata> // global::Common.RepositoryBase
        , IWritableRepository<Common.KeepSynchronizedMetadata>, IValidateRepository/*DataStructureInfo RepositoryInterface Common.KeepSynchronizedMetadata*/
    {
        private readonly Rhetos.Utilities.ISqlUtility _sqlUtility;
        /*DataStructureInfo RepositoryPrivateMembers Common.KeepSynchronizedMetadata*/

        public KeepSynchronizedMetadata_Repository(Common.DomRepository domRepository, Common.ExecutionContext executionContext, Rhetos.Utilities.ISqlUtility _sqlUtility/*DataStructureInfo RepositoryConstructorArguments Common.KeepSynchronizedMetadata*/)
        {
            _domRepository = domRepository;
            _executionContext = executionContext;
            this._sqlUtility = _sqlUtility;
            /*DataStructureInfo RepositoryConstructorCode Common.KeepSynchronizedMetadata*/
        }

        [Obsolete("Use Load() or Query() method.")]
        public override global::Common.KeepSynchronizedMetadata[] All()
        {
            return Query().ToSimple().ToArray();
        }

        public override IQueryable<Common.Queryable.Common_KeepSynchronizedMetadata> Query()
        {
            /*DataStructureInfo RepositoryBeforeQuery Common.KeepSynchronizedMetadata*/
            return _executionContext.EntityFrameworkContext.Common_KeepSynchronizedMetadata.AsNoTracking();
        }

        public void Save(IEnumerable<Common.KeepSynchronizedMetadata> insertedNew, IEnumerable<Common.KeepSynchronizedMetadata> updatedNew, IEnumerable<Common.KeepSynchronizedMetadata> deletedIds, bool checkUserPermissions = false)
        {
            if (!DomHelper.CleanUpSaveMethodArguments(ref insertedNew, ref updatedNew, ref deletedIds))
                return;

            /*DataStructureInfo WritableOrm ClearContext Common.KeepSynchronizedMetadata*/

            {
                var invalidItem = insertedNew.Concat(updatedNew).Where(newItem => newItem.Target != null && newItem.Target.Length > 256).FirstOrDefault();
                if (invalidItem != null)
                    throw new Rhetos.UserException(
                        "Maximum length of property {0} is {1}.",
                        new[] { "KeepSynchronizedMetadata.Target", "256" },
                        "DataStructure:Common.KeepSynchronizedMetadata,ID:" + invalidItem.ID.ToString() + ",Property:Target",
                        null);
            }
            {
                var invalidItem = insertedNew.Concat(updatedNew).Where(newItem => newItem.Source != null && newItem.Source.Length > 256).FirstOrDefault();
                if (invalidItem != null)
                    throw new Rhetos.UserException(
                        "Maximum length of property {0} is {1}.",
                        new[] { "KeepSynchronizedMetadata.Source", "256" },
                        "DataStructure:Common.KeepSynchronizedMetadata,ID:" + invalidItem.ID.ToString() + ",Property:Source",
                        null);
            }
            /*DataStructureInfo WritableOrm ArgumentValidation Common.KeepSynchronizedMetadata*/

            /*DataStructureInfo WritableOrm Initialization Common.KeepSynchronizedMetadata*/

            // Using old data, including lazy loading of navigation properties:
            IEnumerable<Common.Queryable.Common_KeepSynchronizedMetadata> deleted = this.Query(deletedIds.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Common_KeepSynchronizedMetadata>)deleted, deletedIds.Select(item => item.ID), item => item.ID);
            IEnumerable<Common.Queryable.Common_KeepSynchronizedMetadata> updated = this.Query(updatedNew.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Common_KeepSynchronizedMetadata>)updated, updatedNew.Select(item => item.ID), item => item.ID);

            /*DataStructureInfo WritableOrm OldDataLoaded Common.KeepSynchronizedMetadata*/

            /*DataStructureInfo WritableOrm ProcessedOldData Common.KeepSynchronizedMetadata*/

            DomHelper.SaveOperation saveOperation = DomHelper.SaveOperation.None;
            try
            {
                if (deletedIds.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Delete;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in deletedIds.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (updatedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Update;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in updatedNew.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (insertedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Insert;
                    _executionContext.EntityFrameworkContext.Common_KeepSynchronizedMetadata.AddRange(insertedNew.Select(item => item.ToNavigation()));
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                saveOperation = DomHelper.SaveOperation.None;
                _executionContext.EntityFrameworkContext.ClearCache();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException saveException)
            {
                DomHelper.ThrowIfSavingNonexistentId(saveException, checkUserPermissions, saveOperation);
        		Rhetos.RhetosException interpretedException = _sqlUtility.InterpretSqlException(saveException);
        		/*DataStructureInfo WritableOrm OnDatabaseError Common.KeepSynchronizedMetadata*/
                if (checkUserPermissions)
                    Rhetos.Utilities.MsSqlUtility.ThrowIfPrimaryKeyErrorOnInsert(interpretedException, "Common.KeepSynchronizedMetadata");

                if (interpretedException != null)
        			Rhetos.Utilities.ExceptionsUtility.Rethrow(interpretedException);
                var sqlException = _sqlUtility.ExtractSqlException(saveException);
                if (sqlException != null)
                    Rhetos.Utilities.ExceptionsUtility.Rethrow(sqlException);
                throw;
            }

            deleted = null;
            updated = this.Query(updatedNew.Select(item => item.ID));
            IEnumerable<Common.Queryable.Common_KeepSynchronizedMetadata> inserted = this.Query(insertedNew.Select(item => item.ID));

            bool allEffectsCompleted = false;
            try
            {
                /*DataStructureInfo WritableOrm OnSaveTag1 Common.KeepSynchronizedMetadata*/

                /*DataStructureInfo WritableOrm OnSaveTag2 Common.KeepSynchronizedMetadata*/

                Rhetos.Dom.DefaultConcepts.InvalidDataMessage.ValidateOnSave(insertedNew, updatedNew, this, "Common.KeepSynchronizedMetadata");

                /*DataStructureInfo WritableOrm AfterSave Common.KeepSynchronizedMetadata*/

                allEffectsCompleted = true;
            }
            finally
            {
                if (!allEffectsCompleted)
                    _executionContext.PersistenceTransaction.DiscardChanges();
            }
        }

        public IEnumerable<Rhetos.Dom.DefaultConcepts.InvalidDataMessage> Validate(IList<Guid> ids, bool onSave)
        {
            /*DataStructureInfo WritableOrm OnSaveValidate Common.KeepSynchronizedMetadata*/
            yield break;
        }

        /*DataStructureInfo RepositoryMembers Common.KeepSynchronizedMetadata*/
    }

    /*DataStructureInfo RepositoryAttributes Common.ExclusiveLock*/
    public class ExclusiveLock_Repository : /*DataStructureInfo OverrideBaseType Common.ExclusiveLock*/ Common.OrmRepositoryBase<Common.Queryable.Common_ExclusiveLock, Common.ExclusiveLock> // Common.QueryableRepositoryBase<Common.Queryable.Common_ExclusiveLock, Common.ExclusiveLock> // Common.ReadableRepositoryBase<Common.ExclusiveLock> // global::Common.RepositoryBase
        , IWritableRepository<Common.ExclusiveLock>, IValidateRepository/*DataStructureInfo RepositoryInterface Common.ExclusiveLock*/
    {
        private readonly Rhetos.Utilities.ISqlUtility _sqlUtility;
        /*DataStructureInfo RepositoryPrivateMembers Common.ExclusiveLock*/

        public ExclusiveLock_Repository(Common.DomRepository domRepository, Common.ExecutionContext executionContext, Rhetos.Utilities.ISqlUtility _sqlUtility/*DataStructureInfo RepositoryConstructorArguments Common.ExclusiveLock*/)
        {
            _domRepository = domRepository;
            _executionContext = executionContext;
            this._sqlUtility = _sqlUtility;
            /*DataStructureInfo RepositoryConstructorCode Common.ExclusiveLock*/
        }

        [Obsolete("Use Load() or Query() method.")]
        public override global::Common.ExclusiveLock[] All()
        {
            return Query().ToSimple().ToArray();
        }

        public override IQueryable<Common.Queryable.Common_ExclusiveLock> Query()
        {
            /*DataStructureInfo RepositoryBeforeQuery Common.ExclusiveLock*/
            return _executionContext.EntityFrameworkContext.Common_ExclusiveLock.AsNoTracking();
        }

        public void Save(IEnumerable<Common.ExclusiveLock> insertedNew, IEnumerable<Common.ExclusiveLock> updatedNew, IEnumerable<Common.ExclusiveLock> deletedIds, bool checkUserPermissions = false)
        {
            if (!DomHelper.CleanUpSaveMethodArguments(ref insertedNew, ref updatedNew, ref deletedIds))
                return;

            /*DataStructureInfo WritableOrm ClearContext Common.ExclusiveLock*/

            {
                var invalidItem = insertedNew.Concat(updatedNew).Where(newItem => newItem.ResourceType != null && newItem.ResourceType.Length > 256).FirstOrDefault();
                if (invalidItem != null)
                    throw new Rhetos.UserException(
                        "Maximum length of property {0} is {1}.",
                        new[] { "ExclusiveLock.ResourceType", "256" },
                        "DataStructure:Common.ExclusiveLock,ID:" + invalidItem.ID.ToString() + ",Property:ResourceType",
                        null);
            }
            {
                var invalidItem = insertedNew.Concat(updatedNew).Where(newItem => newItem.UserName != null && newItem.UserName.Length > 256).FirstOrDefault();
                if (invalidItem != null)
                    throw new Rhetos.UserException(
                        "Maximum length of property {0} is {1}.",
                        new[] { "ExclusiveLock.UserName", "256" },
                        "DataStructure:Common.ExclusiveLock,ID:" + invalidItem.ID.ToString() + ",Property:UserName",
                        null);
            }
            {
                var invalidItem = insertedNew.Concat(updatedNew).Where(newItem => newItem.Workstation != null && newItem.Workstation.Length > 256).FirstOrDefault();
                if (invalidItem != null)
                    throw new Rhetos.UserException(
                        "Maximum length of property {0} is {1}.",
                        new[] { "ExclusiveLock.Workstation", "256" },
                        "DataStructure:Common.ExclusiveLock,ID:" + invalidItem.ID.ToString() + ",Property:Workstation",
                        null);
            }
            /*DataStructureInfo WritableOrm ArgumentValidation Common.ExclusiveLock*/

            /*DataStructureInfo WritableOrm Initialization Common.ExclusiveLock*/

            // Using old data, including lazy loading of navigation properties:
            IEnumerable<Common.Queryable.Common_ExclusiveLock> deleted = this.Query(deletedIds.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Common_ExclusiveLock>)deleted, deletedIds.Select(item => item.ID), item => item.ID);
            IEnumerable<Common.Queryable.Common_ExclusiveLock> updated = this.Query(updatedNew.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Common_ExclusiveLock>)updated, updatedNew.Select(item => item.ID), item => item.ID);

            /*DataStructureInfo WritableOrm OldDataLoaded Common.ExclusiveLock*/

            {
                var invalid = insertedNew.Concat(updatedNew).FirstOrDefault(item => item.ResourceType == null || string.IsNullOrWhiteSpace(item.ResourceType) /*RequiredPropertyInfo OrCondition Common.ExclusiveLock.ResourceType*/);
                if (invalid != null)
                    throw new Rhetos.UserException("It is not allowed to enter {0} because the required property {1} is not set.",
                        new[] { "Common.ExclusiveLock", "ResourceType" },
                        "DataStructure:Common.ExclusiveLock,ID:" + invalid.ID.ToString() + ",Property:ResourceType", null);
            }
            {
                var invalid = insertedNew.Concat(updatedNew).FirstOrDefault(item => item.ResourceID == null /*RequiredPropertyInfo OrCondition Common.ExclusiveLock.ResourceID*/);
                if (invalid != null)
                    throw new Rhetos.UserException("It is not allowed to enter {0} because the required property {1} is not set.",
                        new[] { "Common.ExclusiveLock", "ResourceID" },
                        "DataStructure:Common.ExclusiveLock,ID:" + invalid.ID.ToString() + ",Property:ResourceID", null);
            }
            {
                var invalid = insertedNew.Concat(updatedNew).FirstOrDefault(item => item.UserName == null || string.IsNullOrWhiteSpace(item.UserName) /*RequiredPropertyInfo OrCondition Common.ExclusiveLock.UserName*/);
                if (invalid != null)
                    throw new Rhetos.UserException("It is not allowed to enter {0} because the required property {1} is not set.",
                        new[] { "Common.ExclusiveLock", "UserName" },
                        "DataStructure:Common.ExclusiveLock,ID:" + invalid.ID.ToString() + ",Property:UserName", null);
            }
            {
                var invalid = insertedNew.Concat(updatedNew).FirstOrDefault(item => item.Workstation == null || string.IsNullOrWhiteSpace(item.Workstation) /*RequiredPropertyInfo OrCondition Common.ExclusiveLock.Workstation*/);
                if (invalid != null)
                    throw new Rhetos.UserException("It is not allowed to enter {0} because the required property {1} is not set.",
                        new[] { "Common.ExclusiveLock", "Workstation" },
                        "DataStructure:Common.ExclusiveLock,ID:" + invalid.ID.ToString() + ",Property:Workstation", null);
            }
            {
                var invalid = insertedNew.Concat(updatedNew).FirstOrDefault(item => item.LockStart == null /*RequiredPropertyInfo OrCondition Common.ExclusiveLock.LockStart*/);
                if (invalid != null)
                    throw new Rhetos.UserException("It is not allowed to enter {0} because the required property {1} is not set.",
                        new[] { "Common.ExclusiveLock", "LockStart" },
                        "DataStructure:Common.ExclusiveLock,ID:" + invalid.ID.ToString() + ",Property:LockStart", null);
            }
            {
                var invalid = insertedNew.Concat(updatedNew).FirstOrDefault(item => item.LockFinish == null /*RequiredPropertyInfo OrCondition Common.ExclusiveLock.LockFinish*/);
                if (invalid != null)
                    throw new Rhetos.UserException("It is not allowed to enter {0} because the required property {1} is not set.",
                        new[] { "Common.ExclusiveLock", "LockFinish" },
                        "DataStructure:Common.ExclusiveLock,ID:" + invalid.ID.ToString() + ",Property:LockFinish", null);
            }
            /*DataStructureInfo WritableOrm ProcessedOldData Common.ExclusiveLock*/

            DomHelper.SaveOperation saveOperation = DomHelper.SaveOperation.None;
            try
            {
                if (deletedIds.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Delete;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in deletedIds.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (updatedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Update;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in updatedNew.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (insertedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Insert;
                    _executionContext.EntityFrameworkContext.Common_ExclusiveLock.AddRange(insertedNew.Select(item => item.ToNavigation()));
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                saveOperation = DomHelper.SaveOperation.None;
                _executionContext.EntityFrameworkContext.ClearCache();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException saveException)
            {
                DomHelper.ThrowIfSavingNonexistentId(saveException, checkUserPermissions, saveOperation);
        		Rhetos.RhetosException interpretedException = _sqlUtility.InterpretSqlException(saveException);
        		if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsUniqueError(interpretedException, @"Common.ExclusiveLock", @"IX_ExclusiveLock_ResourceID_ResourceType"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Common.ExclusiveLock,Property:ResourceID ResourceType";
                /*DataStructureInfo WritableOrm OnDatabaseError Common.ExclusiveLock*/
                if (checkUserPermissions)
                    Rhetos.Utilities.MsSqlUtility.ThrowIfPrimaryKeyErrorOnInsert(interpretedException, "Common.ExclusiveLock");

                if (interpretedException != null)
        			Rhetos.Utilities.ExceptionsUtility.Rethrow(interpretedException);
                var sqlException = _sqlUtility.ExtractSqlException(saveException);
                if (sqlException != null)
                    Rhetos.Utilities.ExceptionsUtility.Rethrow(sqlException);
                throw;
            }

            deleted = null;
            updated = this.Query(updatedNew.Select(item => item.ID));
            IEnumerable<Common.Queryable.Common_ExclusiveLock> inserted = this.Query(insertedNew.Select(item => item.ID));

            bool allEffectsCompleted = false;
            try
            {
                /*DataStructureInfo WritableOrm OnSaveTag1 Common.ExclusiveLock*/

                /*DataStructureInfo WritableOrm OnSaveTag2 Common.ExclusiveLock*/

                Rhetos.Dom.DefaultConcepts.InvalidDataMessage.ValidateOnSave(insertedNew, updatedNew, this, "Common.ExclusiveLock");

                /*DataStructureInfo WritableOrm AfterSave Common.ExclusiveLock*/

                allEffectsCompleted = true;
            }
            finally
            {
                if (!allEffectsCompleted)
                    _executionContext.PersistenceTransaction.DiscardChanges();
            }
        }

        public IEnumerable<Rhetos.Dom.DefaultConcepts.InvalidDataMessage> Validate(IList<Guid> ids, bool onSave)
        {
            /*DataStructureInfo WritableOrm OnSaveValidate Common.ExclusiveLock*/
            yield break;
        }

        /*DataStructureInfo RepositoryMembers Common.ExclusiveLock*/
    }

    /*DataStructureInfo RepositoryAttributes Common.SetLock*/
    public class SetLock_Repository : /*DataStructureInfo OverrideBaseType Common.SetLock*/ global::Common.RepositoryBase
        , IActionRepository/*DataStructureInfo RepositoryInterface Common.SetLock*/
    {
        private readonly Rhetos.Utilities.ILocalizer _localizer;
        /*DataStructureInfo RepositoryPrivateMembers Common.SetLock*/

        public SetLock_Repository(Common.DomRepository domRepository, Common.ExecutionContext executionContext, Rhetos.Utilities.ILocalizer _localizer/*DataStructureInfo RepositoryConstructorArguments Common.SetLock*/)
        {
            _domRepository = domRepository;
            _executionContext = executionContext;
            this._localizer = _localizer;
            /*DataStructureInfo RepositoryConstructorCode Common.SetLock*/
        }

        public void Execute(Common.SetLock actionParameter)
        {
            Action<Common.SetLock, Common.DomRepository, IUserInfo/*DataStructureInfo AdditionalParametersType Common.SetLock*/> action_Object = (parameters, repository, userInfo) =>
        {
            var now = SqlUtility.GetDatabaseTime(_executionContext.SqlExecuter);

            var oldLock = repository.Common.ExclusiveLock.Query()
                .Where(itemLock =>
                    itemLock.ResourceType == parameters.ResourceType
                    && itemLock.ResourceID == parameters.ResourceID)
                .FirstOrDefault();
            
            if (oldLock == null)
                repository.Common.ExclusiveLock.Insert(new[] { new Common.ExclusiveLock
                    {
                        UserName = userInfo.UserName,
                        Workstation = userInfo.Workstation,
                        ResourceType = parameters.ResourceType,
                        ResourceID = parameters.ResourceID,
                        LockStart = now,
                        LockFinish = now.AddMinutes(15)
                    }});
            else if (oldLock.UserName == userInfo.UserName
                && oldLock.Workstation == userInfo.Workstation
                || oldLock.LockFinish < now)
                repository.Common.ExclusiveLock.Update(new[] { new Common.ExclusiveLock
                    {
                        ID = oldLock.ID,
                        UserName = userInfo.UserName,
                        Workstation = userInfo.Workstation,
                        ResourceType = parameters.ResourceType,
                        ResourceID = parameters.ResourceID,
                        LockStart = now,
                        LockFinish = now.AddMinutes(15)
                    }});
             else
             {
                string lockInfo = _localizer["Locked record {0}, ID {1}.", oldLock.ResourceType, oldLock.ResourceID];

                string errorInfo;
                if (oldLock.UserName.Equals(userInfo.UserName, StringComparison.InvariantCultureIgnoreCase))
                    errorInfo = _localizer["It is not allowed to enter the record at client workstation '{0}' because the data entry is in progress at workstation '{1}'.",
                        userInfo.Workstation, oldLock.Workstation];
                else
                    errorInfo = _localizer["It is not allowed to enter the record because the data entry is in progress by user '{0}'.",
                        oldLock.UserName];
                
                string localizedMessage = errorInfo + "\r\n" + lockInfo;
                throw new Rhetos.UserException(localizedMessage);
             }
        };

            bool allEffectsCompleted = false;
            try
            {
                /*ActionInfo BeforeAction Common.SetLock*/
                action_Object(actionParameter, _domRepository, _executionContext.UserInfo/*DataStructureInfo AdditionalParametersArgument Common.SetLock*/);
                /*ActionInfo AfterAction Common.SetLock*/
                allEffectsCompleted = true;
            }
            finally
            {
                if (!allEffectsCompleted)
                    _executionContext.PersistenceTransaction.DiscardChanges();
            }
        }

        void IActionRepository.Execute(object actionParameter)
        {
            Execute((Common.SetLock) actionParameter);
        }

        /*DataStructureInfo RepositoryMembers Common.SetLock*/
    }

    /*DataStructureInfo RepositoryAttributes Common.ReleaseLock*/
    public class ReleaseLock_Repository : /*DataStructureInfo OverrideBaseType Common.ReleaseLock*/ global::Common.RepositoryBase
        , IActionRepository/*DataStructureInfo RepositoryInterface Common.ReleaseLock*/
    {
        /*DataStructureInfo RepositoryPrivateMembers Common.ReleaseLock*/

        public ReleaseLock_Repository(Common.DomRepository domRepository, Common.ExecutionContext executionContext/*DataStructureInfo RepositoryConstructorArguments Common.ReleaseLock*/)
        {
            _domRepository = domRepository;
            _executionContext = executionContext;
            /*DataStructureInfo RepositoryConstructorCode Common.ReleaseLock*/
        }

        public void Execute(Common.ReleaseLock actionParameter)
        {
            Action<Common.ReleaseLock, Common.DomRepository, IUserInfo/*DataStructureInfo AdditionalParametersType Common.ReleaseLock*/> action_Object = (parameters, repository, userInfo) =>
        {
            var myLock = repository.Common.ExclusiveLock.Query()
                .Where(itemLock =>
                    itemLock.ResourceType == parameters.ResourceType
                    && itemLock.ResourceID == parameters.ResourceID
                    && itemLock.UserName == userInfo.UserName
                    && itemLock.Workstation == userInfo.Workstation)
                .FirstOrDefault();

            if (myLock != null)
                repository.Common.ExclusiveLock.Delete(new[] { myLock });
        };

            bool allEffectsCompleted = false;
            try
            {
                /*ActionInfo BeforeAction Common.ReleaseLock*/
                action_Object(actionParameter, _domRepository, _executionContext.UserInfo/*DataStructureInfo AdditionalParametersArgument Common.ReleaseLock*/);
                /*ActionInfo AfterAction Common.ReleaseLock*/
                allEffectsCompleted = true;
            }
            finally
            {
                if (!allEffectsCompleted)
                    _executionContext.PersistenceTransaction.DiscardChanges();
            }
        }

        void IActionRepository.Execute(object actionParameter)
        {
            Execute((Common.ReleaseLock) actionParameter);
        }

        /*DataStructureInfo RepositoryMembers Common.ReleaseLock*/
    }

    /*DataStructureInfo RepositoryAttributes Common.LogReader*/
    public class LogReader_Repository : /*DataStructureInfo OverrideBaseType Common.LogReader*/ Common.OrmRepositoryBase<Common.Queryable.Common_LogReader, Common.LogReader> // Common.QueryableRepositoryBase<Common.Queryable.Common_LogReader, Common.LogReader> // Common.ReadableRepositoryBase<Common.LogReader> // global::Common.RepositoryBase
        /*DataStructureInfo RepositoryInterface Common.LogReader*/
    {
        /*DataStructureInfo RepositoryPrivateMembers Common.LogReader*/

        public LogReader_Repository(Common.DomRepository domRepository, Common.ExecutionContext executionContext/*DataStructureInfo RepositoryConstructorArguments Common.LogReader*/)
        {
            _domRepository = domRepository;
            _executionContext = executionContext;
            /*DataStructureInfo RepositoryConstructorCode Common.LogReader*/
        }

        [Obsolete("Use Load() or Query() method.")]
        public override global::Common.LogReader[] All()
        {
            return Query().ToSimple().ToArray();
        }

        public override IQueryable<Common.Queryable.Common_LogReader> Query()
        {
            /*DataStructureInfo RepositoryBeforeQuery Common.LogReader*/
            return _executionContext.EntityFrameworkContext.Common_LogReader.AsNoTracking();
        }

        /*DataStructureInfo RepositoryMembers Common.LogReader*/
    }

    /*DataStructureInfo RepositoryAttributes Common.LogRelatedItemReader*/
    public class LogRelatedItemReader_Repository : /*DataStructureInfo OverrideBaseType Common.LogRelatedItemReader*/ Common.OrmRepositoryBase<Common.Queryable.Common_LogRelatedItemReader, Common.LogRelatedItemReader> // Common.QueryableRepositoryBase<Common.Queryable.Common_LogRelatedItemReader, Common.LogRelatedItemReader> // Common.ReadableRepositoryBase<Common.LogRelatedItemReader> // global::Common.RepositoryBase
        /*DataStructureInfo RepositoryInterface Common.LogRelatedItemReader*/
    {
        /*DataStructureInfo RepositoryPrivateMembers Common.LogRelatedItemReader*/

        public LogRelatedItemReader_Repository(Common.DomRepository domRepository, Common.ExecutionContext executionContext/*DataStructureInfo RepositoryConstructorArguments Common.LogRelatedItemReader*/)
        {
            _domRepository = domRepository;
            _executionContext = executionContext;
            /*DataStructureInfo RepositoryConstructorCode Common.LogRelatedItemReader*/
        }

        [Obsolete("Use Load() or Query() method.")]
        public override global::Common.LogRelatedItemReader[] All()
        {
            return Query().ToSimple().ToArray();
        }

        public override IQueryable<Common.Queryable.Common_LogRelatedItemReader> Query()
        {
            /*DataStructureInfo RepositoryBeforeQuery Common.LogRelatedItemReader*/
            return _executionContext.EntityFrameworkContext.Common_LogRelatedItemReader.AsNoTracking();
        }

        /*DataStructureInfo RepositoryMembers Common.LogRelatedItemReader*/
    }

    /*DataStructureInfo RepositoryAttributes Common.Log*/
    public class Log_Repository : /*DataStructureInfo OverrideBaseType Common.Log*/ Common.OrmRepositoryBase<Common.Queryable.Common_Log, Common.Log> // Common.QueryableRepositoryBase<Common.Queryable.Common_Log, Common.Log> // Common.ReadableRepositoryBase<Common.Log> // global::Common.RepositoryBase
        , IWritableRepository<Common.Log>, IValidateRepository/*DataStructureInfo RepositoryInterface Common.Log*/
    {
        private readonly Rhetos.Utilities.ISqlUtility _sqlUtility;
        /*DataStructureInfo RepositoryPrivateMembers Common.Log*/

        public Log_Repository(Common.DomRepository domRepository, Common.ExecutionContext executionContext, Rhetos.Utilities.ISqlUtility _sqlUtility/*DataStructureInfo RepositoryConstructorArguments Common.Log*/)
        {
            _domRepository = domRepository;
            _executionContext = executionContext;
            this._sqlUtility = _sqlUtility;
            /*DataStructureInfo RepositoryConstructorCode Common.Log*/
        }

        [Obsolete("Use Load() or Query() method.")]
        public override global::Common.Log[] All()
        {
            return Query().ToSimple().ToArray();
        }

        public override IQueryable<Common.Queryable.Common_Log> Query()
        {
            /*DataStructureInfo RepositoryBeforeQuery Common.Log*/
            return _executionContext.EntityFrameworkContext.Common_Log.AsNoTracking();
        }

        public void Save(IEnumerable<Common.Log> insertedNew, IEnumerable<Common.Log> updatedNew, IEnumerable<Common.Log> deletedIds, bool checkUserPermissions = false)
        {
            if (!DomHelper.CleanUpSaveMethodArguments(ref insertedNew, ref updatedNew, ref deletedIds))
                return;

            /*DataStructureInfo WritableOrm ClearContext Common.Log*/

            {
                var invalidItem = insertedNew.Concat(updatedNew).Where(newItem => newItem.UserName != null && newItem.UserName.Length > 256).FirstOrDefault();
                if (invalidItem != null)
                    throw new Rhetos.UserException(
                        "Maximum length of property {0} is {1}.",
                        new[] { "Log.UserName", "256" },
                        "DataStructure:Common.Log,ID:" + invalidItem.ID.ToString() + ",Property:UserName",
                        null);
            }
            {
                var invalidItem = insertedNew.Concat(updatedNew).Where(newItem => newItem.Workstation != null && newItem.Workstation.Length > 256).FirstOrDefault();
                if (invalidItem != null)
                    throw new Rhetos.UserException(
                        "Maximum length of property {0} is {1}.",
                        new[] { "Log.Workstation", "256" },
                        "DataStructure:Common.Log,ID:" + invalidItem.ID.ToString() + ",Property:Workstation",
                        null);
            }
            {
                var invalidItem = insertedNew.Concat(updatedNew).Where(newItem => newItem.ContextInfo != null && newItem.ContextInfo.Length > 256).FirstOrDefault();
                if (invalidItem != null)
                    throw new Rhetos.UserException(
                        "Maximum length of property {0} is {1}.",
                        new[] { "Log.ContextInfo", "256" },
                        "DataStructure:Common.Log,ID:" + invalidItem.ID.ToString() + ",Property:ContextInfo",
                        null);
            }
            {
                var invalidItem = insertedNew.Concat(updatedNew).Where(newItem => newItem.Action != null && newItem.Action.Length > 256).FirstOrDefault();
                if (invalidItem != null)
                    throw new Rhetos.UserException(
                        "Maximum length of property {0} is {1}.",
                        new[] { "Log.Action", "256" },
                        "DataStructure:Common.Log,ID:" + invalidItem.ID.ToString() + ",Property:Action",
                        null);
            }
            {
                var invalidItem = insertedNew.Concat(updatedNew).Where(newItem => newItem.TableName != null && newItem.TableName.Length > 256).FirstOrDefault();
                if (invalidItem != null)
                    throw new Rhetos.UserException(
                        "Maximum length of property {0} is {1}.",
                        new[] { "Log.TableName", "256" },
                        "DataStructure:Common.Log,ID:" + invalidItem.ID.ToString() + ",Property:TableName",
                        null);
            }
            if (checkUserPermissions)
                throw new Rhetos.UserException(
                    "It is not allowed to directly modify {0}.", new[] { "Common.Log" }, null, null);
            /*DataStructureInfo WritableOrm ArgumentValidation Common.Log*/

            /*DataStructureInfo WritableOrm Initialization Common.Log*/

            // Using old data, including lazy loading of navigation properties:
            IEnumerable<Common.Queryable.Common_Log> deleted = this.Query(deletedIds.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Common_Log>)deleted, deletedIds.Select(item => item.ID), item => item.ID);
            IEnumerable<Common.Queryable.Common_Log> updated = this.Query(updatedNew.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Common_Log>)updated, updatedNew.Select(item => item.ID), item => item.ID);

            if (deletedIds.Count() > 0)
            {
                List<Common.LogRelatedItem> childItems = deletedIds
                    .SelectMany(parent => _executionContext.Repository.Common.LogRelatedItem.Query()
                        .Where(child => child.LogID == parent.ID)
                        .Select(child => child.ID)
                        .ToList())
                    .Select(childId => new Common.LogRelatedItem { ID = childId })
                    .ToList();

                if (childItems.Count() > 0)
                    _domRepository.Common.LogRelatedItem.Delete(childItems);
            }

            /*DataStructureInfo WritableOrm OldDataLoaded Common.Log*/

            {
                var invalid = insertedNew.Concat(updatedNew).FirstOrDefault(item => item.Created == null /*RequiredPropertyInfo OrCondition Common.Log.Created*/);
                if (invalid != null)
                    throw new Rhetos.UserException("It is not allowed to enter {0} because the required property {1} is not set.",
                        new[] { "Common.Log", "Created" },
                        "DataStructure:Common.Log,ID:" + invalid.ID.ToString() + ",Property:Created", null);
            }
            {
                var invalid = insertedNew.Concat(updatedNew).FirstOrDefault(item => item.UserName == null || string.IsNullOrWhiteSpace(item.UserName) /*RequiredPropertyInfo OrCondition Common.Log.UserName*/);
                if (invalid != null)
                    throw new Rhetos.UserException("It is not allowed to enter {0} because the required property {1} is not set.",
                        new[] { "Common.Log", "UserName" },
                        "DataStructure:Common.Log,ID:" + invalid.ID.ToString() + ",Property:UserName", null);
            }
            {
                var invalid = insertedNew.Concat(updatedNew).FirstOrDefault(item => item.Workstation == null || string.IsNullOrWhiteSpace(item.Workstation) /*RequiredPropertyInfo OrCondition Common.Log.Workstation*/);
                if (invalid != null)
                    throw new Rhetos.UserException("It is not allowed to enter {0} because the required property {1} is not set.",
                        new[] { "Common.Log", "Workstation" },
                        "DataStructure:Common.Log,ID:" + invalid.ID.ToString() + ",Property:Workstation", null);
            }
            {
                var invalid = insertedNew.Concat(updatedNew).FirstOrDefault(item => item.Action == null || string.IsNullOrWhiteSpace(item.Action) /*RequiredPropertyInfo OrCondition Common.Log.Action*/);
                if (invalid != null)
                    throw new Rhetos.UserException("It is not allowed to enter {0} because the required property {1} is not set.",
                        new[] { "Common.Log", "Action" },
                        "DataStructure:Common.Log,ID:" + invalid.ID.ToString() + ",Property:Action", null);
            }
            /*DataStructureInfo WritableOrm ProcessedOldData Common.Log*/

            DomHelper.SaveOperation saveOperation = DomHelper.SaveOperation.None;
            try
            {
                if (deletedIds.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Delete;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in deletedIds.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (updatedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Update;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in updatedNew.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (insertedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Insert;
                    _executionContext.EntityFrameworkContext.Common_Log.AddRange(insertedNew.Select(item => item.ToNavigation()));
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                saveOperation = DomHelper.SaveOperation.None;
                _executionContext.EntityFrameworkContext.ClearCache();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException saveException)
            {
                DomHelper.ThrowIfSavingNonexistentId(saveException, checkUserPermissions, saveOperation);
        		Rhetos.RhetosException interpretedException = _sqlUtility.InterpretSqlException(saveException);
        		if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnDelete(interpretedException, @"Common.LogRelatedItem", @"LogID", @"FK_LogRelatedItem_Log_LogID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Common.LogRelatedItem,Property:LogID,Referenced:Common.Log";
                /*DataStructureInfo WritableOrm OnDatabaseError Common.Log*/
                if (checkUserPermissions)
                    Rhetos.Utilities.MsSqlUtility.ThrowIfPrimaryKeyErrorOnInsert(interpretedException, "Common.Log");

                if (interpretedException != null)
        			Rhetos.Utilities.ExceptionsUtility.Rethrow(interpretedException);
                var sqlException = _sqlUtility.ExtractSqlException(saveException);
                if (sqlException != null)
                    Rhetos.Utilities.ExceptionsUtility.Rethrow(sqlException);
                throw;
            }

            deleted = null;
            updated = this.Query(updatedNew.Select(item => item.ID));
            IEnumerable<Common.Queryable.Common_Log> inserted = this.Query(insertedNew.Select(item => item.ID));

            bool allEffectsCompleted = false;
            try
            {
                /*DataStructureInfo WritableOrm OnSaveTag1 Common.Log*/

                /*DataStructureInfo WritableOrm OnSaveTag2 Common.Log*/

                Rhetos.Dom.DefaultConcepts.InvalidDataMessage.ValidateOnSave(insertedNew, updatedNew, this, "Common.Log");

                /*DataStructureInfo WritableOrm AfterSave Common.Log*/

                allEffectsCompleted = true;
            }
            finally
            {
                if (!allEffectsCompleted)
                    _executionContext.PersistenceTransaction.DiscardChanges();
            }
        }

        public IEnumerable<Rhetos.Dom.DefaultConcepts.InvalidDataMessage> Validate(IList<Guid> ids, bool onSave)
        {
            /*DataStructureInfo WritableOrm OnSaveValidate Common.Log*/
            yield break;
        }

        /*DataStructureInfo RepositoryMembers Common.Log*/
    }

    /*DataStructureInfo RepositoryAttributes Common.AddToLog*/
    public class AddToLog_Repository : /*DataStructureInfo OverrideBaseType Common.AddToLog*/ global::Common.RepositoryBase
        , IActionRepository/*DataStructureInfo RepositoryInterface Common.AddToLog*/
    {
        /*DataStructureInfo RepositoryPrivateMembers Common.AddToLog*/

        public AddToLog_Repository(Common.DomRepository domRepository, Common.ExecutionContext executionContext/*DataStructureInfo RepositoryConstructorArguments Common.AddToLog*/)
        {
            _domRepository = domRepository;
            _executionContext = executionContext;
            /*DataStructureInfo RepositoryConstructorCode Common.AddToLog*/
        }

        public void Execute(Common.AddToLog actionParameter)
        {
            Action<Common.AddToLog, Common.DomRepository, IUserInfo, Common.ExecutionContext/*DataStructureInfo AdditionalParametersType Common.AddToLog*/> action_Object = (parameter, repository, userInfo, context) =>
		{
			if (parameter.Action == null)
				throw new Rhetos.UserException("Parameter Action is required.");
			string sql = @"INSERT INTO Common.Log (Action, TableName, ItemId, Description)
                SELECT @p0, @p1, @p2, @p3";
			context.EntityFrameworkContext.Database.ExecuteSqlCommand(sql,
				parameter.Action,
				parameter.TableName,
				parameter.ItemId,
				parameter.Description);
		};

            bool allEffectsCompleted = false;
            try
            {
                /*ActionInfo BeforeAction Common.AddToLog*/
                action_Object(actionParameter, _domRepository, _executionContext.UserInfo, _executionContext/*DataStructureInfo AdditionalParametersArgument Common.AddToLog*/);
                /*ActionInfo AfterAction Common.AddToLog*/
                allEffectsCompleted = true;
            }
            finally
            {
                if (!allEffectsCompleted)
                    _executionContext.PersistenceTransaction.DiscardChanges();
            }
        }

        void IActionRepository.Execute(object actionParameter)
        {
            Execute((Common.AddToLog) actionParameter);
        }

        /*DataStructureInfo RepositoryMembers Common.AddToLog*/
    }

    /*DataStructureInfo RepositoryAttributes Common.LogRelatedItem*/
    public class LogRelatedItem_Repository : /*DataStructureInfo OverrideBaseType Common.LogRelatedItem*/ Common.OrmRepositoryBase<Common.Queryable.Common_LogRelatedItem, Common.LogRelatedItem> // Common.QueryableRepositoryBase<Common.Queryable.Common_LogRelatedItem, Common.LogRelatedItem> // Common.ReadableRepositoryBase<Common.LogRelatedItem> // global::Common.RepositoryBase
        , IWritableRepository<Common.LogRelatedItem>, IValidateRepository/*DataStructureInfo RepositoryInterface Common.LogRelatedItem*/
    {
        private readonly Rhetos.Utilities.ISqlUtility _sqlUtility;
        /*DataStructureInfo RepositoryPrivateMembers Common.LogRelatedItem*/

        public LogRelatedItem_Repository(Common.DomRepository domRepository, Common.ExecutionContext executionContext, Rhetos.Utilities.ISqlUtility _sqlUtility/*DataStructureInfo RepositoryConstructorArguments Common.LogRelatedItem*/)
        {
            _domRepository = domRepository;
            _executionContext = executionContext;
            this._sqlUtility = _sqlUtility;
            /*DataStructureInfo RepositoryConstructorCode Common.LogRelatedItem*/
        }

        [Obsolete("Use Load() or Query() method.")]
        public override global::Common.LogRelatedItem[] All()
        {
            return Query().ToSimple().ToArray();
        }

        public override IQueryable<Common.Queryable.Common_LogRelatedItem> Query()
        {
            /*DataStructureInfo RepositoryBeforeQuery Common.LogRelatedItem*/
            return _executionContext.EntityFrameworkContext.Common_LogRelatedItem.AsNoTracking();
        }

        public void Save(IEnumerable<Common.LogRelatedItem> insertedNew, IEnumerable<Common.LogRelatedItem> updatedNew, IEnumerable<Common.LogRelatedItem> deletedIds, bool checkUserPermissions = false)
        {
            if (!DomHelper.CleanUpSaveMethodArguments(ref insertedNew, ref updatedNew, ref deletedIds))
                return;

            /*DataStructureInfo WritableOrm ClearContext Common.LogRelatedItem*/

            {
                var invalidItem = insertedNew.Concat(updatedNew).Where(newItem => newItem.TableName != null && newItem.TableName.Length > 256).FirstOrDefault();
                if (invalidItem != null)
                    throw new Rhetos.UserException(
                        "Maximum length of property {0} is {1}.",
                        new[] { "LogRelatedItem.TableName", "256" },
                        "DataStructure:Common.LogRelatedItem,ID:" + invalidItem.ID.ToString() + ",Property:TableName",
                        null);
            }
            {
                var invalidItem = insertedNew.Concat(updatedNew).Where(newItem => newItem.Relation != null && newItem.Relation.Length > 256).FirstOrDefault();
                if (invalidItem != null)
                    throw new Rhetos.UserException(
                        "Maximum length of property {0} is {1}.",
                        new[] { "LogRelatedItem.Relation", "256" },
                        "DataStructure:Common.LogRelatedItem,ID:" + invalidItem.ID.ToString() + ",Property:Relation",
                        null);
            }
            if (checkUserPermissions)
                throw new Rhetos.UserException(
                    "It is not allowed to directly modify {0}.", new[] { "Common.LogRelatedItem" }, null, null);
            /*DataStructureInfo WritableOrm ArgumentValidation Common.LogRelatedItem*/

            /*DataStructureInfo WritableOrm Initialization Common.LogRelatedItem*/

            // Using old data, including lazy loading of navigation properties:
            IEnumerable<Common.Queryable.Common_LogRelatedItem> deleted = this.Query(deletedIds.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Common_LogRelatedItem>)deleted, deletedIds.Select(item => item.ID), item => item.ID);
            IEnumerable<Common.Queryable.Common_LogRelatedItem> updated = this.Query(updatedNew.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Common_LogRelatedItem>)updated, updatedNew.Select(item => item.ID), item => item.ID);

            /*DataStructureInfo WritableOrm OldDataLoaded Common.LogRelatedItem*/

            {
                var invalid = insertedNew.Concat(updatedNew).FirstOrDefault(item => item.LogID == null /*RequiredPropertyInfo OrCondition Common.LogRelatedItem.Log*/);
                if (invalid != null)
                    throw new Rhetos.UserException("It is not allowed to enter {0} because the required property {1} is not set.",
                        new[] { "Common.LogRelatedItem", "Log" },
                        "DataStructure:Common.LogRelatedItem,ID:" + invalid.ID.ToString() + ",Property:LogID", null);
            }
            /*DataStructureInfo WritableOrm ProcessedOldData Common.LogRelatedItem*/

            DomHelper.SaveOperation saveOperation = DomHelper.SaveOperation.None;
            try
            {
                if (deletedIds.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Delete;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in deletedIds.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (updatedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Update;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in updatedNew.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (insertedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Insert;
                    _executionContext.EntityFrameworkContext.Common_LogRelatedItem.AddRange(insertedNew.Select(item => item.ToNavigation()));
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                saveOperation = DomHelper.SaveOperation.None;
                _executionContext.EntityFrameworkContext.ClearCache();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException saveException)
            {
                DomHelper.ThrowIfSavingNonexistentId(saveException, checkUserPermissions, saveOperation);
        		Rhetos.RhetosException interpretedException = _sqlUtility.InterpretSqlException(saveException);
        		if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnInsertUpdate(interpretedException, @"Common.Log", @"ID", @"FK_LogRelatedItem_Log_LogID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Common.LogRelatedItem,Property:LogID,Referenced:Common.Log";
                /*DataStructureInfo WritableOrm OnDatabaseError Common.LogRelatedItem*/
                if (checkUserPermissions)
                    Rhetos.Utilities.MsSqlUtility.ThrowIfPrimaryKeyErrorOnInsert(interpretedException, "Common.LogRelatedItem");

                if (interpretedException != null)
        			Rhetos.Utilities.ExceptionsUtility.Rethrow(interpretedException);
                var sqlException = _sqlUtility.ExtractSqlException(saveException);
                if (sqlException != null)
                    Rhetos.Utilities.ExceptionsUtility.Rethrow(sqlException);
                throw;
            }

            deleted = null;
            updated = this.Query(updatedNew.Select(item => item.ID));
            IEnumerable<Common.Queryable.Common_LogRelatedItem> inserted = this.Query(insertedNew.Select(item => item.ID));

            bool allEffectsCompleted = false;
            try
            {
                /*DataStructureInfo WritableOrm OnSaveTag1 Common.LogRelatedItem*/

                /*DataStructureInfo WritableOrm OnSaveTag2 Common.LogRelatedItem*/

                Rhetos.Dom.DefaultConcepts.InvalidDataMessage.ValidateOnSave(insertedNew, updatedNew, this, "Common.LogRelatedItem");

                /*DataStructureInfo WritableOrm AfterSave Common.LogRelatedItem*/

                allEffectsCompleted = true;
            }
            finally
            {
                if (!allEffectsCompleted)
                    _executionContext.PersistenceTransaction.DiscardChanges();
            }
        }

        public IEnumerable<Rhetos.Dom.DefaultConcepts.InvalidDataMessage> Validate(IList<Guid> ids, bool onSave)
        {
            if (onSave)
            {
                var errorIds = this.Filter(this.Query(ids), new SystemRequiredLog()).Select(item => item.ID).ToArray();
                if (errorIds.Count() > 0)
                    foreach (var error in GetErrorMessage_SystemRequiredLog(errorIds))
                        yield return error;
            }
            /*DataStructureInfo WritableOrm OnSaveValidate Common.LogRelatedItem*/
            yield break;
        }

        public IEnumerable<InvalidDataMessage> GetErrorMessage_SystemRequiredLog(IEnumerable<Guid> invalidData_Ids)
        {
            const string invalidData_Description = @"System required property {0} is not set.";
            IDictionary<string, object> metadata = new Dictionary<string, object>();
            metadata["Validation"] = @"SystemRequiredLog";
            metadata[@"Property"] = @"Log";
            /*InvalidDataInfo ErrorMetadata Common.LogRelatedItem.SystemRequiredLog*/
            return invalidData_Ids.Select(id => new InvalidDataMessage
            {
                ID = id,
                Message = invalidData_Description,
                MessageParameters = new object[] { @"Reference Common.LogRelatedItem.Log" },
                Metadata = metadata
            });
            // /*InvalidDataInfo OverrideUserMessages Common.LogRelatedItem.SystemRequiredLog*/ return invalidData_Ids.Select(id => new InvalidDataMessage { ID = id, Message = invalidData_Description, Metadata = metadata });
        }

        public IQueryable<Common.Queryable.Common_LogRelatedItem> Filter(IQueryable<Common.Queryable.Common_LogRelatedItem> localSource, Common.SystemRequiredLog localParameter)
        {
            Func<IQueryable<Common.Queryable.Common_LogRelatedItem>, Common.DomRepository, Common.SystemRequiredLog/*ComposableFilterByInfo AdditionalParametersType Common.LogRelatedItem.'Common.SystemRequiredLog'*/, IQueryable<Common.Queryable.Common_LogRelatedItem>> filterFunction =
            (source, repository, parameter) => source.Where(item => item.Log == null);

            /*ComposableFilterByInfo BeforeFilter Common.LogRelatedItem.'Common.SystemRequiredLog'*/
            return filterFunction(localSource, _domRepository, localParameter/*ComposableFilterByInfo AdditionalParametersArgument Common.LogRelatedItem.'Common.SystemRequiredLog'*/);
        }

        public global::Common.LogRelatedItem[] Filter(Common.SystemRequiredLog filter_Parameter)
        {
            Func<Common.DomRepository, Common.SystemRequiredLog/*FilterByInfo AdditionalParametersType Common.LogRelatedItem.'Common.SystemRequiredLog'*/, Common.LogRelatedItem[]> filter_Function =
                (repository, parameter) => repository.Common.LogRelatedItem.Filter(repository.Common.LogRelatedItem.Query(), parameter).ToArray();

            return filter_Function(_domRepository, filter_Parameter/*FilterByInfo AdditionalParametersArgument Common.LogRelatedItem.'Common.SystemRequiredLog'*/);
        }

        /*DataStructureInfo RepositoryMembers Common.LogRelatedItem*/
    }

    /*DataStructureInfo RepositoryAttributes Common.RelatedEventsSource*/
    public class RelatedEventsSource_Repository : /*DataStructureInfo OverrideBaseType Common.RelatedEventsSource*/ Common.OrmRepositoryBase<Common.Queryable.Common_RelatedEventsSource, Common.RelatedEventsSource> // Common.QueryableRepositoryBase<Common.Queryable.Common_RelatedEventsSource, Common.RelatedEventsSource> // Common.ReadableRepositoryBase<Common.RelatedEventsSource> // global::Common.RepositoryBase
        /*DataStructureInfo RepositoryInterface Common.RelatedEventsSource*/
    {
        /*DataStructureInfo RepositoryPrivateMembers Common.RelatedEventsSource*/

        public RelatedEventsSource_Repository(Common.DomRepository domRepository, Common.ExecutionContext executionContext/*DataStructureInfo RepositoryConstructorArguments Common.RelatedEventsSource*/)
        {
            _domRepository = domRepository;
            _executionContext = executionContext;
            /*DataStructureInfo RepositoryConstructorCode Common.RelatedEventsSource*/
        }

        [Obsolete("Use Load() or Query() method.")]
        public override global::Common.RelatedEventsSource[] All()
        {
            return Query().ToSimple().ToArray();
        }

        public override IQueryable<Common.Queryable.Common_RelatedEventsSource> Query()
        {
            /*DataStructureInfo RepositoryBeforeQuery Common.RelatedEventsSource*/
            return _executionContext.EntityFrameworkContext.Common_RelatedEventsSource.AsNoTracking();
        }

        /*DataStructureInfo RepositoryMembers Common.RelatedEventsSource*/
    }

    /*DataStructureInfo RepositoryAttributes Common.Claim*/
    public class Claim_Repository : /*DataStructureInfo OverrideBaseType Common.Claim*/ Common.OrmRepositoryBase<Common.Queryable.Common_Claim, Common.Claim> // Common.QueryableRepositoryBase<Common.Queryable.Common_Claim, Common.Claim> // Common.ReadableRepositoryBase<Common.Claim> // global::Common.RepositoryBase
        , IWritableRepository<Common.Claim>, IValidateRepository/*DataStructureInfo RepositoryInterface Common.Claim*/
    {
        private readonly Rhetos.Utilities.ISqlUtility _sqlUtility;
        /*DataStructureInfo RepositoryPrivateMembers Common.Claim*/

        public Claim_Repository(Common.DomRepository domRepository, Common.ExecutionContext executionContext, Rhetos.Utilities.ISqlUtility _sqlUtility/*DataStructureInfo RepositoryConstructorArguments Common.Claim*/)
        {
            _domRepository = domRepository;
            _executionContext = executionContext;
            this._sqlUtility = _sqlUtility;
            /*DataStructureInfo RepositoryConstructorCode Common.Claim*/
        }

        [Obsolete("Use Load() or Query() method.")]
        public override global::Common.Claim[] All()
        {
            return Query().ToSimple().ToArray();
        }

        public override IQueryable<Common.Queryable.Common_Claim> Query()
        {
            /*DataStructureInfo RepositoryBeforeQuery Common.Claim*/
            return _executionContext.EntityFrameworkContext.Common_Claim.AsNoTracking();
        }

        public void Save(IEnumerable<Common.Claim> insertedNew, IEnumerable<Common.Claim> updatedNew, IEnumerable<Common.Claim> deletedIds, bool checkUserPermissions = false)
        {
            if (!DomHelper.CleanUpSaveMethodArguments(ref insertedNew, ref updatedNew, ref deletedIds))
                return;

            /*DataStructureInfo WritableOrm ClearContext Common.Claim*/

            {
                var invalidItem = insertedNew.Concat(updatedNew).Where(newItem => newItem.ClaimResource != null && newItem.ClaimResource.Length > 256).FirstOrDefault();
                if (invalidItem != null)
                    throw new Rhetos.UserException(
                        "Maximum length of property {0} is {1}.",
                        new[] { "Claim.ClaimResource", "256" },
                        "DataStructure:Common.Claim,ID:" + invalidItem.ID.ToString() + ",Property:ClaimResource",
                        null);
            }
            {
                var invalidItem = insertedNew.Concat(updatedNew).Where(newItem => newItem.ClaimRight != null && newItem.ClaimRight.Length > 256).FirstOrDefault();
                if (invalidItem != null)
                    throw new Rhetos.UserException(
                        "Maximum length of property {0} is {1}.",
                        new[] { "Claim.ClaimRight", "256" },
                        "DataStructure:Common.Claim,ID:" + invalidItem.ID.ToString() + ",Property:ClaimRight",
                        null);
            }
            /*DataStructureInfo WritableOrm ArgumentValidation Common.Claim*/

            /*DataStructureInfo WritableOrm Initialization Common.Claim*/

            // Using old data, including lazy loading of navigation properties:
            IEnumerable<Common.Queryable.Common_Claim> deleted = this.Query(deletedIds.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Common_Claim>)deleted, deletedIds.Select(item => item.ID), item => item.ID);
            IEnumerable<Common.Queryable.Common_Claim> updated = this.Query(updatedNew.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Common_Claim>)updated, updatedNew.Select(item => item.ID), item => item.ID);

            foreach (var newItem in insertedNew)
                if (newItem.Active == null)
                    newItem.Active = true;

            foreach (var change in updatedNew.Zip(updated, (newItem, oldItem) => new { newItem, oldItem }))
                if (change.newItem.Active == null)
                    change.newItem.Active = change.oldItem.Active ?? true;

            if (deletedIds.Count() > 0)
            {
                List<Common.PrincipalPermission> childItems = deletedIds
                    .SelectMany(parent => _executionContext.Repository.Common.PrincipalPermission.Query()
                        .Where(child => child.ClaimID == parent.ID)
                        .Select(child => child.ID)
                        .ToList())
                    .Select(childId => new Common.PrincipalPermission { ID = childId })
                    .ToList();

                if (childItems.Count() > 0)
                    _domRepository.Common.PrincipalPermission.Delete(childItems);
            }

            if (deletedIds.Count() > 0)
            {
                List<Common.RolePermission> childItems = deletedIds
                    .SelectMany(parent => _executionContext.Repository.Common.RolePermission.Query()
                        .Where(child => child.ClaimID == parent.ID)
                        .Select(child => child.ID)
                        .ToList())
                    .Select(childId => new Common.RolePermission { ID = childId })
                    .ToList();

                if (childItems.Count() > 0)
                    _domRepository.Common.RolePermission.Delete(childItems);
            }

            /*DataStructureInfo WritableOrm OldDataLoaded Common.Claim*/

            {
                var invalid = insertedNew.Concat(updatedNew).FirstOrDefault(item => item.ClaimResource == null || string.IsNullOrWhiteSpace(item.ClaimResource) /*RequiredPropertyInfo OrCondition Common.Claim.ClaimResource*/);
                if (invalid != null)
                    throw new Rhetos.UserException("It is not allowed to enter {0} because the required property {1} is not set.",
                        new[] { "Common.Claim", "ClaimResource" },
                        "DataStructure:Common.Claim,ID:" + invalid.ID.ToString() + ",Property:ClaimResource", null);
            }
            {
                var invalid = insertedNew.Concat(updatedNew).FirstOrDefault(item => item.ClaimRight == null || string.IsNullOrWhiteSpace(item.ClaimRight) /*RequiredPropertyInfo OrCondition Common.Claim.ClaimRight*/);
                if (invalid != null)
                    throw new Rhetos.UserException("It is not allowed to enter {0} because the required property {1} is not set.",
                        new[] { "Common.Claim", "ClaimRight" },
                        "DataStructure:Common.Claim,ID:" + invalid.ID.ToString() + ",Property:ClaimRight", null);
            }
            /*DataStructureInfo WritableOrm ProcessedOldData Common.Claim*/

            DomHelper.SaveOperation saveOperation = DomHelper.SaveOperation.None;
            try
            {
                if (deletedIds.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Delete;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in deletedIds.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (updatedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Update;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in updatedNew.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (insertedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Insert;
                    _executionContext.EntityFrameworkContext.Common_Claim.AddRange(insertedNew.Select(item => item.ToNavigation()));
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                saveOperation = DomHelper.SaveOperation.None;
                _executionContext.EntityFrameworkContext.ClearCache();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException saveException)
            {
                DomHelper.ThrowIfSavingNonexistentId(saveException, checkUserPermissions, saveOperation);
        		Rhetos.RhetosException interpretedException = _sqlUtility.InterpretSqlException(saveException);
        		if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnDelete(interpretedException, @"Common.PrincipalPermission", @"ClaimID", @"FK_PrincipalPermission_Claim_ClaimID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Common.PrincipalPermission,Property:ClaimID,Referenced:Common.Claim";
                if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnDelete(interpretedException, @"Common.RolePermission", @"ClaimID", @"FK_RolePermission_Claim_ClaimID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Common.RolePermission,Property:ClaimID,Referenced:Common.Claim";
                if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsUniqueError(interpretedException, @"Common.Claim", @"IX_Claim_ClaimResource_ClaimRight"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Common.Claim,Property:ClaimResource ClaimRight";
                /*DataStructureInfo WritableOrm OnDatabaseError Common.Claim*/
                if (checkUserPermissions)
                    Rhetos.Utilities.MsSqlUtility.ThrowIfPrimaryKeyErrorOnInsert(interpretedException, "Common.Claim");

                if (interpretedException != null)
        			Rhetos.Utilities.ExceptionsUtility.Rethrow(interpretedException);
                var sqlException = _sqlUtility.ExtractSqlException(saveException);
                if (sqlException != null)
                    Rhetos.Utilities.ExceptionsUtility.Rethrow(sqlException);
                throw;
            }

            deleted = null;
            updated = this.Query(updatedNew.Select(item => item.ID));
            IEnumerable<Common.Queryable.Common_Claim> inserted = this.Query(insertedNew.Select(item => item.ID));

            bool allEffectsCompleted = false;
            try
            {
                /*DataStructureInfo WritableOrm OnSaveTag1 Common.Claim*/

                /*DataStructureInfo WritableOrm OnSaveTag2 Common.Claim*/

                Rhetos.Dom.DefaultConcepts.InvalidDataMessage.ValidateOnSave(insertedNew, updatedNew, this, "Common.Claim");

                /*DataStructureInfo WritableOrm AfterSave Common.Claim*/

                allEffectsCompleted = true;
            }
            finally
            {
                if (!allEffectsCompleted)
                    _executionContext.PersistenceTransaction.DiscardChanges();
            }
        }

        public IEnumerable<Rhetos.Dom.DefaultConcepts.InvalidDataMessage> Validate(IList<Guid> ids, bool onSave)
        {
            if (onSave)
            {
                var errorIds = this.Filter(this.Query(ids), new SystemRequiredActive()).Select(item => item.ID).ToArray();
                if (errorIds.Count() > 0)
                    foreach (var error in GetErrorMessage_SystemRequiredActive(errorIds))
                        yield return error;
            }
            /*DataStructureInfo WritableOrm OnSaveValidate Common.Claim*/
            yield break;
        }

        // Claims in use should be deactivated instead of deleted.
        public IEnumerable<Claim> Filter(IEnumerable<Claim> deleted, Rhetos.Dom.DefaultConcepts.DeactivateInsteadOfDelete parameter)
        {
            var deactivateClaimsId = new List<Guid>();
            var deletedClaimsId = new Lazy<List<Guid>>(() => deleted.Select(c => c.ID).ToList());

            {
                // Don't delete claims that are referenced from RolePermission:

                var permissionsQuery = _domRepository.Common.RolePermission.Query();

                List<Guid> deletedIds = deletedClaimsId.Value;
                if (deletedIds.Count < 1000) // If more than 1000 claims are deleted, it could be faster to load all permissions from database.
                    permissionsQuery = permissionsQuery.Where(p => deletedIds.Contains(p.Claim.ID));

                List<Guid> usedIds = permissionsQuery.Select(p => p.Claim.ID).Distinct().ToList();
                deactivateClaimsId.AddRange(usedIds);
            }
            
            {
                // Don't delete claims that are referenced from PrincipalPermission:

                var permissionsQuery = _domRepository.Common.PrincipalPermission.Query();

                List<Guid> deletedIds = deletedClaimsId.Value;
                if (deletedIds.Count < 1000) // If more than 1000 claims are deleted, it could be faster to load all permissions from database.
                    permissionsQuery = permissionsQuery.Where(p => deletedIds.Contains(p.Claim.ID));

                List<Guid> usedIds = permissionsQuery.Select(p => p.Claim.ID).Distinct().ToList();
                deactivateClaimsId.AddRange(usedIds);
            }
            /*DataStructureInfo DeactivateInsteadOfDelete Common.Claim*/

            var deactivateClaimsIdIndex = new HashSet<Guid>(deactivateClaimsId);
            return deleted.Where(item => deactivateClaimsIdIndex.Contains(item.ID)).ToList();
        }

        public IQueryable<Common.Queryable.Common_Claim> Filter(IQueryable<Common.Queryable.Common_Claim> localSource, Rhetos.Dom.DefaultConcepts.ActiveItems localParameter)
        {
            Func<IQueryable<Common.Queryable.Common_Claim>, Common.DomRepository, Rhetos.Dom.DefaultConcepts.ActiveItems/*ComposableFilterByInfo AdditionalParametersType Common.Claim.'Rhetos.Dom.DefaultConcepts.ActiveItems'*/, IQueryable<Common.Queryable.Common_Claim>> filterFunction =
            (items, repository, parameter) =>
                    {
                        if (parameter != null && parameter.ItemID.HasValue)
                            return items.Where(item => item.Active == null || item.Active.Value || item.ID == parameter.ItemID.Value);
                        else
                            return items.Where(item => item.Active == null || item.Active.Value);
                    };

            /*ComposableFilterByInfo BeforeFilter Common.Claim.'Rhetos.Dom.DefaultConcepts.ActiveItems'*/
            return filterFunction(localSource, _domRepository, localParameter/*ComposableFilterByInfo AdditionalParametersArgument Common.Claim.'Rhetos.Dom.DefaultConcepts.ActiveItems'*/);
        }

        public IEnumerable<InvalidDataMessage> GetErrorMessage_SystemRequiredActive(IEnumerable<Guid> invalidData_Ids)
        {
            const string invalidData_Description = @"System required property {0} is not set.";
            IDictionary<string, object> metadata = new Dictionary<string, object>();
            metadata["Validation"] = @"SystemRequiredActive";
            metadata[@"Property"] = @"Active";
            /*InvalidDataInfo ErrorMetadata Common.Claim.SystemRequiredActive*/
            return invalidData_Ids.Select(id => new InvalidDataMessage
            {
                ID = id,
                Message = invalidData_Description,
                MessageParameters = new object[] { @"Bool Common.Claim.Active" },
                Metadata = metadata
            });
            // /*InvalidDataInfo OverrideUserMessages Common.Claim.SystemRequiredActive*/ return invalidData_Ids.Select(id => new InvalidDataMessage { ID = id, Message = invalidData_Description, Metadata = metadata });
        }

        public IQueryable<Common.Queryable.Common_Claim> Filter(IQueryable<Common.Queryable.Common_Claim> localSource, Common.SystemRequiredActive localParameter)
        {
            Func<IQueryable<Common.Queryable.Common_Claim>, Common.DomRepository, Common.SystemRequiredActive/*ComposableFilterByInfo AdditionalParametersType Common.Claim.'Common.SystemRequiredActive'*/, IQueryable<Common.Queryable.Common_Claim>> filterFunction =
            (source, repository, parameter) => source.Where(item => item.Active == null);

            /*ComposableFilterByInfo BeforeFilter Common.Claim.'Common.SystemRequiredActive'*/
            return filterFunction(localSource, _domRepository, localParameter/*ComposableFilterByInfo AdditionalParametersArgument Common.Claim.'Common.SystemRequiredActive'*/);
        }

        public global::Common.Claim[] Filter(Rhetos.Dom.DefaultConcepts.ActiveItems filter_Parameter)
        {
            Func<Common.DomRepository, Rhetos.Dom.DefaultConcepts.ActiveItems/*FilterByInfo AdditionalParametersType Common.Claim.'Rhetos.Dom.DefaultConcepts.ActiveItems'*/, Common.Claim[]> filter_Function =
                (repository, parameter) => repository.Common.Claim.Filter(repository.Common.Claim.Query(), parameter).ToArray();

            return filter_Function(_domRepository, filter_Parameter/*FilterByInfo AdditionalParametersArgument Common.Claim.'Rhetos.Dom.DefaultConcepts.ActiveItems'*/);
        }

        public global::Common.Claim[] Filter(Common.SystemRequiredActive filter_Parameter)
        {
            Func<Common.DomRepository, Common.SystemRequiredActive/*FilterByInfo AdditionalParametersType Common.Claim.'Common.SystemRequiredActive'*/, Common.Claim[]> filter_Function =
                (repository, parameter) => repository.Common.Claim.Filter(repository.Common.Claim.Query(), parameter).ToArray();

            return filter_Function(_domRepository, filter_Parameter/*FilterByInfo AdditionalParametersArgument Common.Claim.'Common.SystemRequiredActive'*/);
        }

        /*DataStructureInfo RepositoryMembers Common.Claim*/
    }

    /*DataStructureInfo RepositoryAttributes Common.MyClaim*/
    public class MyClaim_Repository : /*DataStructureInfo OverrideBaseType Common.MyClaim*/ Common.QueryableRepositoryBase<Common.Queryable.Common_MyClaim, Common.MyClaim> // Common.ReadableRepositoryBase<Common.MyClaim> // global::Common.RepositoryBase
        /*DataStructureInfo RepositoryInterface Common.MyClaim*/
    {
        /*DataStructureInfo RepositoryPrivateMembers Common.MyClaim*/

        public MyClaim_Repository(Common.DomRepository domRepository, Common.ExecutionContext executionContext/*DataStructureInfo RepositoryConstructorArguments Common.MyClaim*/)
        {
            _domRepository = domRepository;
            _executionContext = executionContext;
            /*DataStructureInfo RepositoryConstructorCode Common.MyClaim*/
        }

        [Obsolete("Use Load() or Query() method.")]
        public override global::Common.MyClaim[] All()
        {
            return Query().ToSimple().ToArray();
        }

        public override IQueryable<Common.Queryable.Common_MyClaim> Query()
        {
            /*DataStructureInfo RepositoryBeforeQuery Common.MyClaim*/
            return Compute(_domRepository.Common.Claim.Query(), _domRepository/*DataStructureInfo AdditionalParametersArgument Common.MyClaim*/);
        }

        public readonly Func<IQueryable<Common.Queryable.Common_Claim>, Common.DomRepository/*DataStructureInfo AdditionalParametersType Common.MyClaim*/, IQueryable<Common.Queryable.Common_MyClaim>> Compute =
            (query, repository) =>
		{ throw new Rhetos.UserException("Reading Common.MyClaim without filter is not permitted. Use filter by Common.Claim or Common.Claim[]."); };

        public global::Common.MyClaim[] Filter(Common.Claim filter_Parameter)
        {
            Func<Common.DomRepository, Common.Claim, Common.ExecutionContext/*FilterByInfo AdditionalParametersType Common.MyClaim.'Common.Claim'*/, Common.MyClaim[]> filter_Function =
                (repository, parameter, executionContext) =>
			{
				var claim = repository.Common.Claim.Query().Where(item => item.ClaimResource == parameter.ClaimResource && item.ClaimRight == parameter.ClaimRight).SingleOrDefault();
				if (claim == null)
					throw new Rhetos.UserException("Claim {0}-{1} does not exist.",
						new[] { parameter.ClaimResource, parameter.ClaimRight }, null, null);
				
				return repository.Common.MyClaim.Filter(new[] { claim });
			};

            return filter_Function(_domRepository, filter_Parameter, _executionContext/*FilterByInfo AdditionalParametersArgument Common.MyClaim.'Common.Claim'*/);
        }

        public global::Common.MyClaim[] Filter(IEnumerable<Common.Claim> filter_Parameter)
        {
            Func<Common.DomRepository, IEnumerable<Common.Claim>, Common.ExecutionContext/*FilterByInfo AdditionalParametersType Common.MyClaim.'IEnumerable<Common.Claim>'*/, Common.MyClaim[]> filter_Function =
                (repository, claims, executionContext) =>
			{
                var securityClaims = claims.Select(c => new Rhetos.Security.Claim(c.ClaimResource, c.ClaimRight)).ToList();
                var authorizations = executionContext.AuthorizationManager.GetAuthorizations(securityClaims);
			
                return claims.Zip(authorizations, (claim, authorized) => new Common.MyClaim {
                        ID = claim.ID,
                        Applies = authorized
                    }).ToArray();
             };

            return filter_Function(_domRepository, filter_Parameter, _executionContext/*FilterByInfo AdditionalParametersArgument Common.MyClaim.'IEnumerable<Common.Claim>'*/);
        }

        /*DataStructureInfo RepositoryMembers Common.MyClaim*/
    }

    /*DataStructureInfo RepositoryAttributes Common.Principal*/
    public class Principal_Repository : /*DataStructureInfo OverrideBaseType Common.Principal*/ Common.OrmRepositoryBase<Common.Queryable.Common_Principal, Common.Principal> // Common.QueryableRepositoryBase<Common.Queryable.Common_Principal, Common.Principal> // Common.ReadableRepositoryBase<Common.Principal> // global::Common.RepositoryBase
        , IWritableRepository<Common.Principal>, IValidateRepository/*DataStructureInfo RepositoryInterface Common.Principal*/
    {
        private readonly Rhetos.Dom.DefaultConcepts.AuthorizationDataCache _authorizationDataCache;
        private readonly Rhetos.Utilities.ISqlUtility _sqlUtility;
        /*DataStructureInfo RepositoryPrivateMembers Common.Principal*/

        public Principal_Repository(Common.DomRepository domRepository, Common.ExecutionContext executionContext, Rhetos.Dom.DefaultConcepts.AuthorizationDataCache _authorizationDataCache, Rhetos.Utilities.ISqlUtility _sqlUtility/*DataStructureInfo RepositoryConstructorArguments Common.Principal*/)
        {
            _domRepository = domRepository;
            _executionContext = executionContext;
            this._authorizationDataCache = _authorizationDataCache;
            this._sqlUtility = _sqlUtility;
            /*DataStructureInfo RepositoryConstructorCode Common.Principal*/
        }

        [Obsolete("Use Load() or Query() method.")]
        public override global::Common.Principal[] All()
        {
            return Query().ToSimple().ToArray();
        }

        public override IQueryable<Common.Queryable.Common_Principal> Query()
        {
            /*DataStructureInfo RepositoryBeforeQuery Common.Principal*/
            return _executionContext.EntityFrameworkContext.Common_Principal.AsNoTracking();
        }

        public void Save(IEnumerable<Common.Principal> insertedNew, IEnumerable<Common.Principal> updatedNew, IEnumerable<Common.Principal> deletedIds, bool checkUserPermissions = false)
        {
            if (!DomHelper.CleanUpSaveMethodArguments(ref insertedNew, ref updatedNew, ref deletedIds))
                return;

            /*DataStructureInfo WritableOrm ClearContext Common.Principal*/

            {
                var invalidItem = insertedNew.Concat(updatedNew).Where(newItem => newItem.Name != null && newItem.Name.Length > 256).FirstOrDefault();
                if (invalidItem != null)
                    throw new Rhetos.UserException(
                        "Maximum length of property {0} is {1}.",
                        new[] { "Principal.Name", "256" },
                        "DataStructure:Common.Principal,ID:" + invalidItem.ID.ToString() + ",Property:Name",
                        null);
            }
            /*DataStructureInfo WritableOrm ArgumentValidation Common.Principal*/

            var updatedIdsList = updatedNew.Select(item => item.ID).ToList();
            var deletedIdsList = deletedIds.Select(item => item.ID).ToList();
            var updatedOld = Filter(Query(), updatedIdsList).Select(item => new { item.ID,
                Name = item.Name/*LoadOldItemsInfo SelectProperties Common.Principal*/ }).ToList();
            var deletedOld = Filter(Query(), deletedIdsList).Select(item => new { item.ID,
                Name = item.Name/*LoadOldItemsInfo SelectProperties Common.Principal*/ }).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder(updatedOld, updatedIdsList, item => item.ID);
            Rhetos.Utilities.Graph.SortByGivenOrder(deletedOld, deletedIdsList, item => item.ID);

            /*DataStructureInfo WritableOrm Initialization Common.Principal*/

            // Using old data, including lazy loading of navigation properties:
            IEnumerable<Common.Queryable.Common_Principal> deleted = this.Query(deletedIds.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Common_Principal>)deleted, deletedIds.Select(item => item.ID), item => item.ID);
            IEnumerable<Common.Queryable.Common_Principal> updated = this.Query(updatedNew.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Common_Principal>)updated, updatedNew.Select(item => item.ID), item => item.ID);

            if (deletedIds.Count() > 0)
            {
                List<Common.PrincipalHasRole> childItems = deletedIds
                    .SelectMany(parent => _executionContext.Repository.Common.PrincipalHasRole.Query()
                        .Where(child => child.PrincipalID == parent.ID)
                        .Select(child => child.ID)
                        .ToList())
                    .Select(childId => new Common.PrincipalHasRole { ID = childId })
                    .ToList();

                if (childItems.Count() > 0)
                    _domRepository.Common.PrincipalHasRole.Delete(childItems);
            }

            if (deletedIds.Count() > 0)
            {
                List<Common.PrincipalPermission> childItems = deletedIds
                    .SelectMany(parent => _executionContext.Repository.Common.PrincipalPermission.Query()
                        .Where(child => child.PrincipalID == parent.ID)
                        .Select(child => child.ID)
                        .ToList())
                    .Select(childId => new Common.PrincipalPermission { ID = childId })
                    .ToList();

                if (childItems.Count() > 0)
                    _domRepository.Common.PrincipalPermission.Delete(childItems);
            }

            /*DataStructureInfo WritableOrm OldDataLoaded Common.Principal*/

            {
                var invalid = insertedNew.Concat(updatedNew).FirstOrDefault(item => item.Name == null || string.IsNullOrWhiteSpace(item.Name) /*RequiredPropertyInfo OrCondition Common.Principal.Name*/);
                if (invalid != null)
                    throw new Rhetos.UserException("It is not allowed to enter {0} because the required property {1} is not set.",
                        new[] { "Common.Principal", "Name" },
                        "DataStructure:Common.Principal,ID:" + invalid.ID.ToString() + ",Property:Name", null);
            }
            /*DataStructureInfo WritableOrm ProcessedOldData Common.Principal*/

            DomHelper.SaveOperation saveOperation = DomHelper.SaveOperation.None;
            try
            {
                if (deletedIds.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Delete;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in deletedIds.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (updatedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Update;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in updatedNew.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (insertedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Insert;
                    _executionContext.EntityFrameworkContext.Common_Principal.AddRange(insertedNew.Select(item => item.ToNavigation()));
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                saveOperation = DomHelper.SaveOperation.None;
                _executionContext.EntityFrameworkContext.ClearCache();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException saveException)
            {
                DomHelper.ThrowIfSavingNonexistentId(saveException, checkUserPermissions, saveOperation);
        		Rhetos.RhetosException interpretedException = _sqlUtility.InterpretSqlException(saveException);
        		if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnDelete(interpretedException, @"Common.PrincipalHasRole", @"PrincipalID", @"FK_PrincipalHasRole_Principal_PrincipalID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Common.PrincipalHasRole,Property:PrincipalID,Referenced:Common.Principal";
                if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnDelete(interpretedException, @"Common.PrincipalPermission", @"PrincipalID", @"FK_PrincipalPermission_Principal_PrincipalID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Common.PrincipalPermission,Property:PrincipalID,Referenced:Common.Principal";
                if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsUniqueError(interpretedException, @"Common.Principal", @"IX_Principal_Name"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Common.Principal,Property:Name";
                /*DataStructureInfo WritableOrm OnDatabaseError Common.Principal*/
                if (checkUserPermissions)
                    Rhetos.Utilities.MsSqlUtility.ThrowIfPrimaryKeyErrorOnInsert(interpretedException, "Common.Principal");

                if (interpretedException != null)
        			Rhetos.Utilities.ExceptionsUtility.Rethrow(interpretedException);
                var sqlException = _sqlUtility.ExtractSqlException(saveException);
                if (sqlException != null)
                    Rhetos.Utilities.ExceptionsUtility.Rethrow(sqlException);
                throw;
            }

            deleted = null;
            updated = this.Query(updatedNew.Select(item => item.ID));
            IEnumerable<Common.Queryable.Common_Principal> inserted = this.Query(insertedNew.Select(item => item.ID));

            bool allEffectsCompleted = false;
            try
            {
                { // ClearAuthenticationCache
                    var principalInfos = ((IEnumerable<Rhetos.Dom.DefaultConcepts.IPrincipal>)insertedNew).Concat(updatedNew)
                    .Concat(updatedOld.Select(p => new Rhetos.Dom.DefaultConcepts.PrincipalInfo { ID = p.ID, Name = p.Name }))
                    .Concat(deletedOld.Select(p => new Rhetos.Dom.DefaultConcepts.PrincipalInfo { ID = p.ID, Name = p.Name }));
                    _authorizationDataCache.ClearCachePrincipals(principalInfos);
                }

                /*DataStructureInfo WritableOrm OnSaveTag1 Common.Principal*/

                /*DataStructureInfo WritableOrm OnSaveTag2 Common.Principal*/

                Rhetos.Dom.DefaultConcepts.InvalidDataMessage.ValidateOnSave(insertedNew, updatedNew, this, "Common.Principal");

                /*DataStructureInfo WritableOrm AfterSave Common.Principal*/

                allEffectsCompleted = true;
            }
            finally
            {
                if (!allEffectsCompleted)
                    _executionContext.PersistenceTransaction.DiscardChanges();
            }
        }

        public IEnumerable<Rhetos.Dom.DefaultConcepts.InvalidDataMessage> Validate(IList<Guid> ids, bool onSave)
        {
            /*DataStructureInfo WritableOrm OnSaveValidate Common.Principal*/
            yield break;
        }

        /*DataStructureInfo RepositoryMembers Common.Principal*/
    }

    /*DataStructureInfo RepositoryAttributes Common.PrincipalHasRole*/
    public class PrincipalHasRole_Repository : /*DataStructureInfo OverrideBaseType Common.PrincipalHasRole*/ Common.OrmRepositoryBase<Common.Queryable.Common_PrincipalHasRole, Common.PrincipalHasRole> // Common.QueryableRepositoryBase<Common.Queryable.Common_PrincipalHasRole, Common.PrincipalHasRole> // Common.ReadableRepositoryBase<Common.PrincipalHasRole> // global::Common.RepositoryBase
        , IWritableRepository<Common.PrincipalHasRole>, IValidateRepository/*DataStructureInfo RepositoryInterface Common.PrincipalHasRole*/
    {
        private readonly Rhetos.Dom.DefaultConcepts.AuthorizationDataCache _authorizationDataCache;
        private readonly Rhetos.Utilities.ISqlUtility _sqlUtility;
        /*DataStructureInfo RepositoryPrivateMembers Common.PrincipalHasRole*/

        public PrincipalHasRole_Repository(Common.DomRepository domRepository, Common.ExecutionContext executionContext, Rhetos.Dom.DefaultConcepts.AuthorizationDataCache _authorizationDataCache, Rhetos.Utilities.ISqlUtility _sqlUtility/*DataStructureInfo RepositoryConstructorArguments Common.PrincipalHasRole*/)
        {
            _domRepository = domRepository;
            _executionContext = executionContext;
            this._authorizationDataCache = _authorizationDataCache;
            this._sqlUtility = _sqlUtility;
            /*DataStructureInfo RepositoryConstructorCode Common.PrincipalHasRole*/
        }

        [Obsolete("Use Load() or Query() method.")]
        public override global::Common.PrincipalHasRole[] All()
        {
            return Query().ToSimple().ToArray();
        }

        public override IQueryable<Common.Queryable.Common_PrincipalHasRole> Query()
        {
            /*DataStructureInfo RepositoryBeforeQuery Common.PrincipalHasRole*/
            return _executionContext.EntityFrameworkContext.Common_PrincipalHasRole.AsNoTracking();
        }

        public void Save(IEnumerable<Common.PrincipalHasRole> insertedNew, IEnumerable<Common.PrincipalHasRole> updatedNew, IEnumerable<Common.PrincipalHasRole> deletedIds, bool checkUserPermissions = false)
        {
            if (!DomHelper.CleanUpSaveMethodArguments(ref insertedNew, ref updatedNew, ref deletedIds))
                return;

            /*DataStructureInfo WritableOrm ClearContext Common.PrincipalHasRole*/

            /*DataStructureInfo WritableOrm ArgumentValidation Common.PrincipalHasRole*/

            var updatedIdsList = updatedNew.Select(item => item.ID).ToList();
            var deletedIdsList = deletedIds.Select(item => item.ID).ToList();
            var updatedOld = Filter(Query(), updatedIdsList).Select(item => new { item.ID,
                PrincipalID = item.PrincipalID/*LoadOldItemsInfo SelectProperties Common.PrincipalHasRole*/ }).ToList();
            var deletedOld = Filter(Query(), deletedIdsList).Select(item => new { item.ID,
                PrincipalID = item.PrincipalID/*LoadOldItemsInfo SelectProperties Common.PrincipalHasRole*/ }).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder(updatedOld, updatedIdsList, item => item.ID);
            Rhetos.Utilities.Graph.SortByGivenOrder(deletedOld, deletedIdsList, item => item.ID);

            /*DataStructureInfo WritableOrm Initialization Common.PrincipalHasRole*/

            // Using old data, including lazy loading of navigation properties:
            IEnumerable<Common.Queryable.Common_PrincipalHasRole> deleted = this.Query(deletedIds.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Common_PrincipalHasRole>)deleted, deletedIds.Select(item => item.ID), item => item.ID);
            IEnumerable<Common.Queryable.Common_PrincipalHasRole> updated = this.Query(updatedNew.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Common_PrincipalHasRole>)updated, updatedNew.Select(item => item.ID), item => item.ID);

            /*DataStructureInfo WritableOrm OldDataLoaded Common.PrincipalHasRole*/

            {
                var invalid = insertedNew.Concat(updatedNew).FirstOrDefault(item => item.PrincipalID == null /*RequiredPropertyInfo OrCondition Common.PrincipalHasRole.Principal*/);
                if (invalid != null)
                    throw new Rhetos.UserException("It is not allowed to enter {0} because the required property {1} is not set.",
                        new[] { "Common.PrincipalHasRole", "Principal" },
                        "DataStructure:Common.PrincipalHasRole,ID:" + invalid.ID.ToString() + ",Property:PrincipalID", null);
            }
            {
                var invalid = insertedNew.Concat(updatedNew).FirstOrDefault(item => item.RoleID == null /*RequiredPropertyInfo OrCondition Common.PrincipalHasRole.Role*/);
                if (invalid != null)
                    throw new Rhetos.UserException("It is not allowed to enter {0} because the required property {1} is not set.",
                        new[] { "Common.PrincipalHasRole", "Role" },
                        "DataStructure:Common.PrincipalHasRole,ID:" + invalid.ID.ToString() + ",Property:RoleID", null);
            }
            /*DataStructureInfo WritableOrm ProcessedOldData Common.PrincipalHasRole*/

            DomHelper.SaveOperation saveOperation = DomHelper.SaveOperation.None;
            try
            {
                if (deletedIds.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Delete;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in deletedIds.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (updatedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Update;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in updatedNew.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (insertedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Insert;
                    _executionContext.EntityFrameworkContext.Common_PrincipalHasRole.AddRange(insertedNew.Select(item => item.ToNavigation()));
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                saveOperation = DomHelper.SaveOperation.None;
                _executionContext.EntityFrameworkContext.ClearCache();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException saveException)
            {
                DomHelper.ThrowIfSavingNonexistentId(saveException, checkUserPermissions, saveOperation);
        		Rhetos.RhetosException interpretedException = _sqlUtility.InterpretSqlException(saveException);
        		if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnInsertUpdate(interpretedException, @"Common.Principal", @"ID", @"FK_PrincipalHasRole_Principal_PrincipalID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Common.PrincipalHasRole,Property:PrincipalID,Referenced:Common.Principal";
                if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsUniqueError(interpretedException, @"Common.PrincipalHasRole", @"IX_PrincipalHasRole_Principal_Role"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Common.PrincipalHasRole,Property:Principal Role";
                if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnInsertUpdate(interpretedException, @"Common.Role", @"ID", @"FK_PrincipalHasRole_Role_RoleID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Common.PrincipalHasRole,Property:RoleID,Referenced:Common.Role";
                /*DataStructureInfo WritableOrm OnDatabaseError Common.PrincipalHasRole*/
                if (checkUserPermissions)
                    Rhetos.Utilities.MsSqlUtility.ThrowIfPrimaryKeyErrorOnInsert(interpretedException, "Common.PrincipalHasRole");

                if (interpretedException != null)
        			Rhetos.Utilities.ExceptionsUtility.Rethrow(interpretedException);
                var sqlException = _sqlUtility.ExtractSqlException(saveException);
                if (sqlException != null)
                    Rhetos.Utilities.ExceptionsUtility.Rethrow(sqlException);
                throw;
            }

            deleted = null;
            updated = this.Query(updatedNew.Select(item => item.ID));
            IEnumerable<Common.Queryable.Common_PrincipalHasRole> inserted = this.Query(insertedNew.Select(item => item.ID));

            bool allEffectsCompleted = false;
            try
            {
                { // ClearAuthenticationCache
                    var principalIds = insertedNew.Concat(updatedNew).Select(item => item.PrincipalID)
                        .Concat(updatedOld.Select(item => item.PrincipalID))
                        .Concat(deletedOld.Select(item => item.PrincipalID))
                        .Where(pid => pid != null).Select(pid => pid.Value)
                        .Distinct().ToList();
                    var principalInfos = _domRepository.Common.Principal.Query(principalIds)
                        .Select(p => new Rhetos.Dom.DefaultConcepts.PrincipalInfo { ID = p.ID, Name = p.Name });
                    _authorizationDataCache.ClearCachePrincipals(principalInfos);
                }

                /*DataStructureInfo WritableOrm OnSaveTag1 Common.PrincipalHasRole*/

                /*DataStructureInfo WritableOrm OnSaveTag2 Common.PrincipalHasRole*/

                Rhetos.Dom.DefaultConcepts.InvalidDataMessage.ValidateOnSave(insertedNew, updatedNew, this, "Common.PrincipalHasRole");

                /*DataStructureInfo WritableOrm AfterSave Common.PrincipalHasRole*/

                allEffectsCompleted = true;
            }
            finally
            {
                if (!allEffectsCompleted)
                    _executionContext.PersistenceTransaction.DiscardChanges();
            }
        }

        public IEnumerable<Rhetos.Dom.DefaultConcepts.InvalidDataMessage> Validate(IList<Guid> ids, bool onSave)
        {
            if (onSave)
            {
                var errorIds = this.Filter(this.Query(ids), new SystemRequiredPrincipal()).Select(item => item.ID).ToArray();
                if (errorIds.Count() > 0)
                    foreach (var error in GetErrorMessage_SystemRequiredPrincipal(errorIds))
                        yield return error;
            }
            /*DataStructureInfo WritableOrm OnSaveValidate Common.PrincipalHasRole*/
            yield break;
        }

        public IQueryable<Common.Queryable.Common_PrincipalHasRole> Query(Rhetos.Dom.DefaultConcepts.IPrincipal queryParameter)
        {
            /*QueryWithParameterInfo BeforeQuery Common.PrincipalHasRole.'Rhetos.Dom.DefaultConcepts.IPrincipal'*/
            Func<Rhetos.Dom.DefaultConcepts.IPrincipal, IQueryable<Common.Queryable.Common_PrincipalHasRole>> queryFunction = parameter => Query().Where(item => item.Principal.ID == parameter.ID);
            var queryResult = queryFunction(queryParameter);
            /*QueryWithParameterInfo AfterQuery Common.PrincipalHasRole.'Rhetos.Dom.DefaultConcepts.IPrincipal'*/
            return queryResult;
        }

        public IEnumerable<InvalidDataMessage> GetErrorMessage_SystemRequiredPrincipal(IEnumerable<Guid> invalidData_Ids)
        {
            const string invalidData_Description = @"System required property {0} is not set.";
            IDictionary<string, object> metadata = new Dictionary<string, object>();
            metadata["Validation"] = @"SystemRequiredPrincipal";
            metadata[@"Property"] = @"Principal";
            /*InvalidDataInfo ErrorMetadata Common.PrincipalHasRole.SystemRequiredPrincipal*/
            return invalidData_Ids.Select(id => new InvalidDataMessage
            {
                ID = id,
                Message = invalidData_Description,
                MessageParameters = new object[] { @"Reference Common.PrincipalHasRole.Principal" },
                Metadata = metadata
            });
            // /*InvalidDataInfo OverrideUserMessages Common.PrincipalHasRole.SystemRequiredPrincipal*/ return invalidData_Ids.Select(id => new InvalidDataMessage { ID = id, Message = invalidData_Description, Metadata = metadata });
        }

        public IQueryable<Common.Queryable.Common_PrincipalHasRole> Filter(IQueryable<Common.Queryable.Common_PrincipalHasRole> localSource, Common.SystemRequiredPrincipal localParameter)
        {
            Func<IQueryable<Common.Queryable.Common_PrincipalHasRole>, Common.DomRepository, Common.SystemRequiredPrincipal/*ComposableFilterByInfo AdditionalParametersType Common.PrincipalHasRole.'Common.SystemRequiredPrincipal'*/, IQueryable<Common.Queryable.Common_PrincipalHasRole>> filterFunction =
            (source, repository, parameter) => source.Where(item => item.Principal == null);

            /*ComposableFilterByInfo BeforeFilter Common.PrincipalHasRole.'Common.SystemRequiredPrincipal'*/
            return filterFunction(localSource, _domRepository, localParameter/*ComposableFilterByInfo AdditionalParametersArgument Common.PrincipalHasRole.'Common.SystemRequiredPrincipal'*/);
        }

        public global::Common.PrincipalHasRole[] Filter(Common.SystemRequiredPrincipal filter_Parameter)
        {
            Func<Common.DomRepository, Common.SystemRequiredPrincipal/*FilterByInfo AdditionalParametersType Common.PrincipalHasRole.'Common.SystemRequiredPrincipal'*/, Common.PrincipalHasRole[]> filter_Function =
                (repository, parameter) => repository.Common.PrincipalHasRole.Filter(repository.Common.PrincipalHasRole.Query(), parameter).ToArray();

            return filter_Function(_domRepository, filter_Parameter/*FilterByInfo AdditionalParametersArgument Common.PrincipalHasRole.'Common.SystemRequiredPrincipal'*/);
        }

        /*DataStructureInfo RepositoryMembers Common.PrincipalHasRole*/
    }

    /*DataStructureInfo RepositoryAttributes Common.Role*/
    public class Role_Repository : /*DataStructureInfo OverrideBaseType Common.Role*/ Common.OrmRepositoryBase<Common.Queryable.Common_Role, Common.Role> // Common.QueryableRepositoryBase<Common.Queryable.Common_Role, Common.Role> // Common.ReadableRepositoryBase<Common.Role> // global::Common.RepositoryBase
        , IWritableRepository<Common.Role>, IValidateRepository/*DataStructureInfo RepositoryInterface Common.Role*/
    {
        private readonly Rhetos.Dom.DefaultConcepts.AuthorizationDataCache _authorizationDataCache;
        private readonly Rhetos.Utilities.ISqlUtility _sqlUtility;
        /*DataStructureInfo RepositoryPrivateMembers Common.Role*/

        public Role_Repository(Common.DomRepository domRepository, Common.ExecutionContext executionContext, Rhetos.Dom.DefaultConcepts.AuthorizationDataCache _authorizationDataCache, Rhetos.Utilities.ISqlUtility _sqlUtility/*DataStructureInfo RepositoryConstructorArguments Common.Role*/)
        {
            _domRepository = domRepository;
            _executionContext = executionContext;
            this._authorizationDataCache = _authorizationDataCache;
            this._sqlUtility = _sqlUtility;
            /*DataStructureInfo RepositoryConstructorCode Common.Role*/
        }

        [Obsolete("Use Load() or Query() method.")]
        public override global::Common.Role[] All()
        {
            return Query().ToSimple().ToArray();
        }

        public override IQueryable<Common.Queryable.Common_Role> Query()
        {
            /*DataStructureInfo RepositoryBeforeQuery Common.Role*/
            return _executionContext.EntityFrameworkContext.Common_Role.AsNoTracking();
        }

        public void Save(IEnumerable<Common.Role> insertedNew, IEnumerable<Common.Role> updatedNew, IEnumerable<Common.Role> deletedIds, bool checkUserPermissions = false)
        {
            if (!DomHelper.CleanUpSaveMethodArguments(ref insertedNew, ref updatedNew, ref deletedIds))
                return;

            /*DataStructureInfo WritableOrm ClearContext Common.Role*/

            {
                var invalidItem = insertedNew.Concat(updatedNew).Where(newItem => newItem.Name != null && newItem.Name.Length > 256).FirstOrDefault();
                if (invalidItem != null)
                    throw new Rhetos.UserException(
                        "Maximum length of property {0} is {1}.",
                        new[] { "Role.Name", "256" },
                        "DataStructure:Common.Role,ID:" + invalidItem.ID.ToString() + ",Property:Name",
                        null);
            }
            /*DataStructureInfo WritableOrm ArgumentValidation Common.Role*/

            /*DataStructureInfo WritableOrm Initialization Common.Role*/

            // Using old data, including lazy loading of navigation properties:
            IEnumerable<Common.Queryable.Common_Role> deleted = this.Query(deletedIds.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Common_Role>)deleted, deletedIds.Select(item => item.ID), item => item.ID);
            IEnumerable<Common.Queryable.Common_Role> updated = this.Query(updatedNew.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Common_Role>)updated, updatedNew.Select(item => item.ID), item => item.ID);

            if (deletedIds.Count() > 0)
            {
                List<Common.RoleInheritsRole> childItems = deletedIds
                    .SelectMany(parent => _executionContext.Repository.Common.RoleInheritsRole.Query()
                        .Where(child => child.UsersFromID == parent.ID)
                        .Select(child => child.ID)
                        .ToList())
                    .Select(childId => new Common.RoleInheritsRole { ID = childId })
                    .ToList();

                if (childItems.Count() > 0)
                    _domRepository.Common.RoleInheritsRole.Delete(childItems);
            }

            if (deletedIds.Count() > 0)
            {
                List<Common.RolePermission> childItems = deletedIds
                    .SelectMany(parent => _executionContext.Repository.Common.RolePermission.Query()
                        .Where(child => child.RoleID == parent.ID)
                        .Select(child => child.ID)
                        .ToList())
                    .Select(childId => new Common.RolePermission { ID = childId })
                    .ToList();

                if (childItems.Count() > 0)
                    _domRepository.Common.RolePermission.Delete(childItems);
            }

            /*DataStructureInfo WritableOrm OldDataLoaded Common.Role*/

            {
                var invalid = insertedNew.Concat(updatedNew).FirstOrDefault(item => item.Name == null || string.IsNullOrWhiteSpace(item.Name) /*RequiredPropertyInfo OrCondition Common.Role.Name*/);
                if (invalid != null)
                    throw new Rhetos.UserException("It is not allowed to enter {0} because the required property {1} is not set.",
                        new[] { "Common.Role", "Name" },
                        "DataStructure:Common.Role,ID:" + invalid.ID.ToString() + ",Property:Name", null);
            }
            /*DataStructureInfo WritableOrm ProcessedOldData Common.Role*/

            DomHelper.SaveOperation saveOperation = DomHelper.SaveOperation.None;
            try
            {
                if (deletedIds.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Delete;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in deletedIds.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (updatedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Update;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in updatedNew.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (insertedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Insert;
                    _executionContext.EntityFrameworkContext.Common_Role.AddRange(insertedNew.Select(item => item.ToNavigation()));
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                saveOperation = DomHelper.SaveOperation.None;
                _executionContext.EntityFrameworkContext.ClearCache();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException saveException)
            {
                DomHelper.ThrowIfSavingNonexistentId(saveException, checkUserPermissions, saveOperation);
        		Rhetos.RhetosException interpretedException = _sqlUtility.InterpretSqlException(saveException);
        		if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnDelete(interpretedException, @"Common.PrincipalHasRole", @"RoleID", @"FK_PrincipalHasRole_Role_RoleID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Common.PrincipalHasRole,Property:RoleID,Referenced:Common.Role";
                if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnDelete(interpretedException, @"Common.RoleInheritsRole", @"UsersFromID", @"FK_RoleInheritsRole_Role_UsersFromID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Common.RoleInheritsRole,Property:UsersFromID,Referenced:Common.Role";
                if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnDelete(interpretedException, @"Common.RoleInheritsRole", @"PermissionsFromID", @"FK_RoleInheritsRole_Role_PermissionsFromID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Common.RoleInheritsRole,Property:PermissionsFromID,Referenced:Common.Role";
                if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnDelete(interpretedException, @"Common.RolePermission", @"RoleID", @"FK_RolePermission_Role_RoleID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Common.RolePermission,Property:RoleID,Referenced:Common.Role";
                if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsUniqueError(interpretedException, @"Common.Role", @"IX_Role_Name"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Common.Role,Property:Name";
                /*DataStructureInfo WritableOrm OnDatabaseError Common.Role*/
                if (checkUserPermissions)
                    Rhetos.Utilities.MsSqlUtility.ThrowIfPrimaryKeyErrorOnInsert(interpretedException, "Common.Role");

                if (interpretedException != null)
        			Rhetos.Utilities.ExceptionsUtility.Rethrow(interpretedException);
                var sqlException = _sqlUtility.ExtractSqlException(saveException);
                if (sqlException != null)
                    Rhetos.Utilities.ExceptionsUtility.Rethrow(sqlException);
                throw;
            }

            deleted = null;
            updated = this.Query(updatedNew.Select(item => item.ID));
            IEnumerable<Common.Queryable.Common_Role> inserted = this.Query(insertedNew.Select(item => item.ID));

            bool allEffectsCompleted = false;
            try
            {
                { // ClearAuthenticationCache
                    var roleIds = insertedNew.Concat(updatedNew).Concat(deletedIds).Select(r => r.ID);
                    _authorizationDataCache.ClearCacheRoles(roleIds);
                }

                /*DataStructureInfo WritableOrm OnSaveTag1 Common.Role*/

                /*DataStructureInfo WritableOrm OnSaveTag2 Common.Role*/

                Rhetos.Dom.DefaultConcepts.InvalidDataMessage.ValidateOnSave(insertedNew, updatedNew, this, "Common.Role");

                /*DataStructureInfo WritableOrm AfterSave Common.Role*/

                allEffectsCompleted = true;
            }
            finally
            {
                if (!allEffectsCompleted)
                    _executionContext.PersistenceTransaction.DiscardChanges();
            }
        }

        public IEnumerable<Rhetos.Dom.DefaultConcepts.InvalidDataMessage> Validate(IList<Guid> ids, bool onSave)
        {
            /*DataStructureInfo WritableOrm OnSaveValidate Common.Role*/
            yield break;
        }

        /*DataStructureInfo RepositoryMembers Common.Role*/
    }

    /*DataStructureInfo RepositoryAttributes Common.RoleInheritsRole*/
    public class RoleInheritsRole_Repository : /*DataStructureInfo OverrideBaseType Common.RoleInheritsRole*/ Common.OrmRepositoryBase<Common.Queryable.Common_RoleInheritsRole, Common.RoleInheritsRole> // Common.QueryableRepositoryBase<Common.Queryable.Common_RoleInheritsRole, Common.RoleInheritsRole> // Common.ReadableRepositoryBase<Common.RoleInheritsRole> // global::Common.RepositoryBase
        , IWritableRepository<Common.RoleInheritsRole>, IValidateRepository/*DataStructureInfo RepositoryInterface Common.RoleInheritsRole*/
    {
        private readonly Rhetos.Dom.DefaultConcepts.AuthorizationDataCache _authorizationDataCache;
        private readonly Rhetos.Utilities.ISqlUtility _sqlUtility;
        /*DataStructureInfo RepositoryPrivateMembers Common.RoleInheritsRole*/

        public RoleInheritsRole_Repository(Common.DomRepository domRepository, Common.ExecutionContext executionContext, Rhetos.Dom.DefaultConcepts.AuthorizationDataCache _authorizationDataCache, Rhetos.Utilities.ISqlUtility _sqlUtility/*DataStructureInfo RepositoryConstructorArguments Common.RoleInheritsRole*/)
        {
            _domRepository = domRepository;
            _executionContext = executionContext;
            this._authorizationDataCache = _authorizationDataCache;
            this._sqlUtility = _sqlUtility;
            /*DataStructureInfo RepositoryConstructorCode Common.RoleInheritsRole*/
        }

        [Obsolete("Use Load() or Query() method.")]
        public override global::Common.RoleInheritsRole[] All()
        {
            return Query().ToSimple().ToArray();
        }

        public override IQueryable<Common.Queryable.Common_RoleInheritsRole> Query()
        {
            /*DataStructureInfo RepositoryBeforeQuery Common.RoleInheritsRole*/
            return _executionContext.EntityFrameworkContext.Common_RoleInheritsRole.AsNoTracking();
        }

        public void Save(IEnumerable<Common.RoleInheritsRole> insertedNew, IEnumerable<Common.RoleInheritsRole> updatedNew, IEnumerable<Common.RoleInheritsRole> deletedIds, bool checkUserPermissions = false)
        {
            if (!DomHelper.CleanUpSaveMethodArguments(ref insertedNew, ref updatedNew, ref deletedIds))
                return;

            /*DataStructureInfo WritableOrm ClearContext Common.RoleInheritsRole*/

            /*DataStructureInfo WritableOrm ArgumentValidation Common.RoleInheritsRole*/

            var updatedIdsList = updatedNew.Select(item => item.ID).ToList();
            var deletedIdsList = deletedIds.Select(item => item.ID).ToList();
            var updatedOld = Filter(Query(), updatedIdsList).Select(item => new { item.ID,
                UsersFromID = item.UsersFromID/*LoadOldItemsInfo SelectProperties Common.RoleInheritsRole*/ }).ToList();
            var deletedOld = Filter(Query(), deletedIdsList).Select(item => new { item.ID,
                UsersFromID = item.UsersFromID/*LoadOldItemsInfo SelectProperties Common.RoleInheritsRole*/ }).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder(updatedOld, updatedIdsList, item => item.ID);
            Rhetos.Utilities.Graph.SortByGivenOrder(deletedOld, deletedIdsList, item => item.ID);

            /*DataStructureInfo WritableOrm Initialization Common.RoleInheritsRole*/

            // Using old data, including lazy loading of navigation properties:
            IEnumerable<Common.Queryable.Common_RoleInheritsRole> deleted = this.Query(deletedIds.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Common_RoleInheritsRole>)deleted, deletedIds.Select(item => item.ID), item => item.ID);
            IEnumerable<Common.Queryable.Common_RoleInheritsRole> updated = this.Query(updatedNew.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Common_RoleInheritsRole>)updated, updatedNew.Select(item => item.ID), item => item.ID);

            /*DataStructureInfo WritableOrm OldDataLoaded Common.RoleInheritsRole*/

            {
                var invalid = insertedNew.Concat(updatedNew).FirstOrDefault(item => item.UsersFromID == null /*RequiredPropertyInfo OrCondition Common.RoleInheritsRole.UsersFrom*/);
                if (invalid != null)
                    throw new Rhetos.UserException("It is not allowed to enter {0} because the required property {1} is not set.",
                        new[] { "Common.RoleInheritsRole", "UsersFrom" },
                        "DataStructure:Common.RoleInheritsRole,ID:" + invalid.ID.ToString() + ",Property:UsersFromID", null);
            }
            {
                var invalid = insertedNew.Concat(updatedNew).FirstOrDefault(item => item.PermissionsFromID == null /*RequiredPropertyInfo OrCondition Common.RoleInheritsRole.PermissionsFrom*/);
                if (invalid != null)
                    throw new Rhetos.UserException("It is not allowed to enter {0} because the required property {1} is not set.",
                        new[] { "Common.RoleInheritsRole", "PermissionsFrom" },
                        "DataStructure:Common.RoleInheritsRole,ID:" + invalid.ID.ToString() + ",Property:PermissionsFromID", null);
            }
            /*DataStructureInfo WritableOrm ProcessedOldData Common.RoleInheritsRole*/

            DomHelper.SaveOperation saveOperation = DomHelper.SaveOperation.None;
            try
            {
                if (deletedIds.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Delete;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in deletedIds.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (updatedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Update;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in updatedNew.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (insertedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Insert;
                    _executionContext.EntityFrameworkContext.Common_RoleInheritsRole.AddRange(insertedNew.Select(item => item.ToNavigation()));
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                saveOperation = DomHelper.SaveOperation.None;
                _executionContext.EntityFrameworkContext.ClearCache();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException saveException)
            {
                DomHelper.ThrowIfSavingNonexistentId(saveException, checkUserPermissions, saveOperation);
        		Rhetos.RhetosException interpretedException = _sqlUtility.InterpretSqlException(saveException);
        		if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnInsertUpdate(interpretedException, @"Common.Role", @"ID", @"FK_RoleInheritsRole_Role_UsersFromID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Common.RoleInheritsRole,Property:UsersFromID,Referenced:Common.Role";
                if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnInsertUpdate(interpretedException, @"Common.Role", @"ID", @"FK_RoleInheritsRole_Role_PermissionsFromID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Common.RoleInheritsRole,Property:PermissionsFromID,Referenced:Common.Role";
                if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsUniqueError(interpretedException, @"Common.RoleInheritsRole", @"IX_RoleInheritsRole_UsersFrom_PermissionsFrom"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Common.RoleInheritsRole,Property:UsersFrom PermissionsFrom";
                /*DataStructureInfo WritableOrm OnDatabaseError Common.RoleInheritsRole*/
                if (checkUserPermissions)
                    Rhetos.Utilities.MsSqlUtility.ThrowIfPrimaryKeyErrorOnInsert(interpretedException, "Common.RoleInheritsRole");

                if (interpretedException != null)
        			Rhetos.Utilities.ExceptionsUtility.Rethrow(interpretedException);
                var sqlException = _sqlUtility.ExtractSqlException(saveException);
                if (sqlException != null)
                    Rhetos.Utilities.ExceptionsUtility.Rethrow(sqlException);
                throw;
            }

            deleted = null;
            updated = this.Query(updatedNew.Select(item => item.ID));
            IEnumerable<Common.Queryable.Common_RoleInheritsRole> inserted = this.Query(insertedNew.Select(item => item.ID));

            bool allEffectsCompleted = false;
            try
            {
                { // ClearAuthenticationCache
                    var roleIds = insertedNew.Concat(updatedNew).Select(item => item.UsersFromID)
                        .Concat(updatedOld.Select(item => item.UsersFromID))
                        .Concat(deletedOld.Select(item => item.UsersFromID))
                        .Where(rid => rid != null).Select(rid => rid.Value);
                    _authorizationDataCache.ClearCacheRoles(roleIds);
                }

                /*DataStructureInfo WritableOrm OnSaveTag1 Common.RoleInheritsRole*/

                /*DataStructureInfo WritableOrm OnSaveTag2 Common.RoleInheritsRole*/

                Rhetos.Dom.DefaultConcepts.InvalidDataMessage.ValidateOnSave(insertedNew, updatedNew, this, "Common.RoleInheritsRole");

                /*DataStructureInfo WritableOrm AfterSave Common.RoleInheritsRole*/

                allEffectsCompleted = true;
            }
            finally
            {
                if (!allEffectsCompleted)
                    _executionContext.PersistenceTransaction.DiscardChanges();
            }
        }

        public IEnumerable<Rhetos.Dom.DefaultConcepts.InvalidDataMessage> Validate(IList<Guid> ids, bool onSave)
        {
            if (onSave)
            {
                var errorIds = this.Filter(this.Query(ids), new SystemRequiredUsersFrom()).Select(item => item.ID).ToArray();
                if (errorIds.Count() > 0)
                    foreach (var error in GetErrorMessage_SystemRequiredUsersFrom(errorIds))
                        yield return error;
            }
            /*DataStructureInfo WritableOrm OnSaveValidate Common.RoleInheritsRole*/
            yield break;
        }

        public IEnumerable<InvalidDataMessage> GetErrorMessage_SystemRequiredUsersFrom(IEnumerable<Guid> invalidData_Ids)
        {
            const string invalidData_Description = @"System required property {0} is not set.";
            IDictionary<string, object> metadata = new Dictionary<string, object>();
            metadata["Validation"] = @"SystemRequiredUsersFrom";
            metadata[@"Property"] = @"UsersFrom";
            /*InvalidDataInfo ErrorMetadata Common.RoleInheritsRole.SystemRequiredUsersFrom*/
            return invalidData_Ids.Select(id => new InvalidDataMessage
            {
                ID = id,
                Message = invalidData_Description,
                MessageParameters = new object[] { @"Reference Common.RoleInheritsRole.UsersFrom" },
                Metadata = metadata
            });
            // /*InvalidDataInfo OverrideUserMessages Common.RoleInheritsRole.SystemRequiredUsersFrom*/ return invalidData_Ids.Select(id => new InvalidDataMessage { ID = id, Message = invalidData_Description, Metadata = metadata });
        }

        public IQueryable<Common.Queryable.Common_RoleInheritsRole> Filter(IQueryable<Common.Queryable.Common_RoleInheritsRole> localSource, Common.SystemRequiredUsersFrom localParameter)
        {
            Func<IQueryable<Common.Queryable.Common_RoleInheritsRole>, Common.DomRepository, Common.SystemRequiredUsersFrom/*ComposableFilterByInfo AdditionalParametersType Common.RoleInheritsRole.'Common.SystemRequiredUsersFrom'*/, IQueryable<Common.Queryable.Common_RoleInheritsRole>> filterFunction =
            (source, repository, parameter) => source.Where(item => item.UsersFrom == null);

            /*ComposableFilterByInfo BeforeFilter Common.RoleInheritsRole.'Common.SystemRequiredUsersFrom'*/
            return filterFunction(localSource, _domRepository, localParameter/*ComposableFilterByInfo AdditionalParametersArgument Common.RoleInheritsRole.'Common.SystemRequiredUsersFrom'*/);
        }

        public global::Common.RoleInheritsRole[] Filter(Common.SystemRequiredUsersFrom filter_Parameter)
        {
            Func<Common.DomRepository, Common.SystemRequiredUsersFrom/*FilterByInfo AdditionalParametersType Common.RoleInheritsRole.'Common.SystemRequiredUsersFrom'*/, Common.RoleInheritsRole[]> filter_Function =
                (repository, parameter) => repository.Common.RoleInheritsRole.Filter(repository.Common.RoleInheritsRole.Query(), parameter).ToArray();

            return filter_Function(_domRepository, filter_Parameter/*FilterByInfo AdditionalParametersArgument Common.RoleInheritsRole.'Common.SystemRequiredUsersFrom'*/);
        }

        /*DataStructureInfo RepositoryMembers Common.RoleInheritsRole*/
    }

    /*DataStructureInfo RepositoryAttributes Common.PrincipalPermission*/
    public class PrincipalPermission_Repository : /*DataStructureInfo OverrideBaseType Common.PrincipalPermission*/ Common.OrmRepositoryBase<Common.Queryable.Common_PrincipalPermission, Common.PrincipalPermission> // Common.QueryableRepositoryBase<Common.Queryable.Common_PrincipalPermission, Common.PrincipalPermission> // Common.ReadableRepositoryBase<Common.PrincipalPermission> // global::Common.RepositoryBase
        , IWritableRepository<Common.PrincipalPermission>, IValidateRepository/*DataStructureInfo RepositoryInterface Common.PrincipalPermission*/
    {
        private readonly Rhetos.Dom.DefaultConcepts.AuthorizationDataCache _authorizationDataCache;
        private readonly Rhetos.Utilities.ISqlUtility _sqlUtility;
        /*DataStructureInfo RepositoryPrivateMembers Common.PrincipalPermission*/

        public PrincipalPermission_Repository(Common.DomRepository domRepository, Common.ExecutionContext executionContext, Rhetos.Dom.DefaultConcepts.AuthorizationDataCache _authorizationDataCache, Rhetos.Utilities.ISqlUtility _sqlUtility/*DataStructureInfo RepositoryConstructorArguments Common.PrincipalPermission*/)
        {
            _domRepository = domRepository;
            _executionContext = executionContext;
            this._authorizationDataCache = _authorizationDataCache;
            this._sqlUtility = _sqlUtility;
            /*DataStructureInfo RepositoryConstructorCode Common.PrincipalPermission*/
        }

        [Obsolete("Use Load() or Query() method.")]
        public override global::Common.PrincipalPermission[] All()
        {
            return Query().ToSimple().ToArray();
        }

        public override IQueryable<Common.Queryable.Common_PrincipalPermission> Query()
        {
            /*DataStructureInfo RepositoryBeforeQuery Common.PrincipalPermission*/
            return _executionContext.EntityFrameworkContext.Common_PrincipalPermission.AsNoTracking();
        }

        public void Save(IEnumerable<Common.PrincipalPermission> insertedNew, IEnumerable<Common.PrincipalPermission> updatedNew, IEnumerable<Common.PrincipalPermission> deletedIds, bool checkUserPermissions = false)
        {
            if (!DomHelper.CleanUpSaveMethodArguments(ref insertedNew, ref updatedNew, ref deletedIds))
                return;

            /*DataStructureInfo WritableOrm ClearContext Common.PrincipalPermission*/

            /*DataStructureInfo WritableOrm ArgumentValidation Common.PrincipalPermission*/

            var updatedIdsList = updatedNew.Select(item => item.ID).ToList();
            var deletedIdsList = deletedIds.Select(item => item.ID).ToList();
            var updatedOld = Filter(Query(), updatedIdsList).Select(item => new { item.ID,
                PrincipalID = item.PrincipalID/*LoadOldItemsInfo SelectProperties Common.PrincipalPermission*/ }).ToList();
            var deletedOld = Filter(Query(), deletedIdsList).Select(item => new { item.ID,
                PrincipalID = item.PrincipalID/*LoadOldItemsInfo SelectProperties Common.PrincipalPermission*/ }).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder(updatedOld, updatedIdsList, item => item.ID);
            Rhetos.Utilities.Graph.SortByGivenOrder(deletedOld, deletedIdsList, item => item.ID);

            /*DataStructureInfo WritableOrm Initialization Common.PrincipalPermission*/

            // Using old data, including lazy loading of navigation properties:
            IEnumerable<Common.Queryable.Common_PrincipalPermission> deleted = this.Query(deletedIds.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Common_PrincipalPermission>)deleted, deletedIds.Select(item => item.ID), item => item.ID);
            IEnumerable<Common.Queryable.Common_PrincipalPermission> updated = this.Query(updatedNew.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Common_PrincipalPermission>)updated, updatedNew.Select(item => item.ID), item => item.ID);

            /*DataStructureInfo WritableOrm OldDataLoaded Common.PrincipalPermission*/

            {
                var invalid = insertedNew.Concat(updatedNew).FirstOrDefault(item => item.PrincipalID == null /*RequiredPropertyInfo OrCondition Common.PrincipalPermission.Principal*/);
                if (invalid != null)
                    throw new Rhetos.UserException("It is not allowed to enter {0} because the required property {1} is not set.",
                        new[] { "Common.PrincipalPermission", "Principal" },
                        "DataStructure:Common.PrincipalPermission,ID:" + invalid.ID.ToString() + ",Property:PrincipalID", null);
            }
            {
                var invalid = insertedNew.Concat(updatedNew).FirstOrDefault(item => item.ClaimID == null /*RequiredPropertyInfo OrCondition Common.PrincipalPermission.Claim*/);
                if (invalid != null)
                    throw new Rhetos.UserException("It is not allowed to enter {0} because the required property {1} is not set.",
                        new[] { "Common.PrincipalPermission", "Claim" },
                        "DataStructure:Common.PrincipalPermission,ID:" + invalid.ID.ToString() + ",Property:ClaimID", null);
            }
            {
                var invalid = insertedNew.Concat(updatedNew).FirstOrDefault(item => item.IsAuthorized == null /*RequiredPropertyInfo OrCondition Common.PrincipalPermission.IsAuthorized*/);
                if (invalid != null)
                    throw new Rhetos.UserException("It is not allowed to enter {0} because the required property {1} is not set.",
                        new[] { "Common.PrincipalPermission", "IsAuthorized" },
                        "DataStructure:Common.PrincipalPermission,ID:" + invalid.ID.ToString() + ",Property:IsAuthorized", null);
            }
            /*DataStructureInfo WritableOrm ProcessedOldData Common.PrincipalPermission*/

            DomHelper.SaveOperation saveOperation = DomHelper.SaveOperation.None;
            try
            {
                if (deletedIds.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Delete;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in deletedIds.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (updatedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Update;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in updatedNew.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (insertedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Insert;
                    _executionContext.EntityFrameworkContext.Common_PrincipalPermission.AddRange(insertedNew.Select(item => item.ToNavigation()));
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                saveOperation = DomHelper.SaveOperation.None;
                _executionContext.EntityFrameworkContext.ClearCache();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException saveException)
            {
                DomHelper.ThrowIfSavingNonexistentId(saveException, checkUserPermissions, saveOperation);
        		Rhetos.RhetosException interpretedException = _sqlUtility.InterpretSqlException(saveException);
        		if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnInsertUpdate(interpretedException, @"Common.Principal", @"ID", @"FK_PrincipalPermission_Principal_PrincipalID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Common.PrincipalPermission,Property:PrincipalID,Referenced:Common.Principal";
                if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnInsertUpdate(interpretedException, @"Common.Claim", @"ID", @"FK_PrincipalPermission_Claim_ClaimID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Common.PrincipalPermission,Property:ClaimID,Referenced:Common.Claim";
                if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsUniqueError(interpretedException, @"Common.PrincipalPermission", @"IX_PrincipalPermission_Principal_Claim"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Common.PrincipalPermission,Property:Principal Claim";
                /*DataStructureInfo WritableOrm OnDatabaseError Common.PrincipalPermission*/
                if (checkUserPermissions)
                    Rhetos.Utilities.MsSqlUtility.ThrowIfPrimaryKeyErrorOnInsert(interpretedException, "Common.PrincipalPermission");

                if (interpretedException != null)
        			Rhetos.Utilities.ExceptionsUtility.Rethrow(interpretedException);
                var sqlException = _sqlUtility.ExtractSqlException(saveException);
                if (sqlException != null)
                    Rhetos.Utilities.ExceptionsUtility.Rethrow(sqlException);
                throw;
            }

            deleted = null;
            updated = this.Query(updatedNew.Select(item => item.ID));
            IEnumerable<Common.Queryable.Common_PrincipalPermission> inserted = this.Query(insertedNew.Select(item => item.ID));

            bool allEffectsCompleted = false;
            try
            {
                { // ClearAuthenticationCache
                    var principalIds = insertedNew.Concat(updatedNew).Select(item => item.PrincipalID)
                        .Concat(updatedOld.Select(item => item.PrincipalID))
                        .Concat(deletedOld.Select(item => item.PrincipalID))
                        .Where(pid => pid != null).Select(pid => pid.Value)
                        .Distinct().ToList();
                    var principalInfos = _domRepository.Common.Principal.Query(principalIds)
                        .Select(p => new Rhetos.Dom.DefaultConcepts.PrincipalInfo { ID = p.ID, Name = p.Name });
                    _authorizationDataCache.ClearCachePrincipals(principalInfos);
                }

                /*DataStructureInfo WritableOrm OnSaveTag1 Common.PrincipalPermission*/

                /*DataStructureInfo WritableOrm OnSaveTag2 Common.PrincipalPermission*/

                Rhetos.Dom.DefaultConcepts.InvalidDataMessage.ValidateOnSave(insertedNew, updatedNew, this, "Common.PrincipalPermission");

                /*DataStructureInfo WritableOrm AfterSave Common.PrincipalPermission*/

                allEffectsCompleted = true;
            }
            finally
            {
                if (!allEffectsCompleted)
                    _executionContext.PersistenceTransaction.DiscardChanges();
            }
        }

        public IEnumerable<Rhetos.Dom.DefaultConcepts.InvalidDataMessage> Validate(IList<Guid> ids, bool onSave)
        {
            if (onSave)
            {
                var errorIds = this.Filter(this.Query(ids), new SystemRequiredPrincipal()).Select(item => item.ID).ToArray();
                if (errorIds.Count() > 0)
                    foreach (var error in GetErrorMessage_SystemRequiredPrincipal(errorIds))
                        yield return error;
            }
            if (onSave)
            {
                var errorIds = this.Filter(this.Query(ids), new SystemRequiredClaim()).Select(item => item.ID).ToArray();
                if (errorIds.Count() > 0)
                    foreach (var error in GetErrorMessage_SystemRequiredClaim(errorIds))
                        yield return error;
            }
            /*DataStructureInfo WritableOrm OnSaveValidate Common.PrincipalPermission*/
            yield break;
        }

        public IEnumerable<InvalidDataMessage> GetErrorMessage_SystemRequiredPrincipal(IEnumerable<Guid> invalidData_Ids)
        {
            const string invalidData_Description = @"System required property {0} is not set.";
            IDictionary<string, object> metadata = new Dictionary<string, object>();
            metadata["Validation"] = @"SystemRequiredPrincipal";
            metadata[@"Property"] = @"Principal";
            /*InvalidDataInfo ErrorMetadata Common.PrincipalPermission.SystemRequiredPrincipal*/
            return invalidData_Ids.Select(id => new InvalidDataMessage
            {
                ID = id,
                Message = invalidData_Description,
                MessageParameters = new object[] { @"Reference Common.PrincipalPermission.Principal" },
                Metadata = metadata
            });
            // /*InvalidDataInfo OverrideUserMessages Common.PrincipalPermission.SystemRequiredPrincipal*/ return invalidData_Ids.Select(id => new InvalidDataMessage { ID = id, Message = invalidData_Description, Metadata = metadata });
        }

        public IEnumerable<InvalidDataMessage> GetErrorMessage_SystemRequiredClaim(IEnumerable<Guid> invalidData_Ids)
        {
            const string invalidData_Description = @"System required property {0} is not set.";
            IDictionary<string, object> metadata = new Dictionary<string, object>();
            metadata["Validation"] = @"SystemRequiredClaim";
            metadata[@"Property"] = @"Claim";
            /*InvalidDataInfo ErrorMetadata Common.PrincipalPermission.SystemRequiredClaim*/
            return invalidData_Ids.Select(id => new InvalidDataMessage
            {
                ID = id,
                Message = invalidData_Description,
                MessageParameters = new object[] { @"Reference Common.PrincipalPermission.Claim" },
                Metadata = metadata
            });
            // /*InvalidDataInfo OverrideUserMessages Common.PrincipalPermission.SystemRequiredClaim*/ return invalidData_Ids.Select(id => new InvalidDataMessage { ID = id, Message = invalidData_Description, Metadata = metadata });
        }

        public IQueryable<Common.Queryable.Common_PrincipalPermission> Filter(IQueryable<Common.Queryable.Common_PrincipalPermission> localSource, Common.SystemRequiredPrincipal localParameter)
        {
            Func<IQueryable<Common.Queryable.Common_PrincipalPermission>, Common.DomRepository, Common.SystemRequiredPrincipal/*ComposableFilterByInfo AdditionalParametersType Common.PrincipalPermission.'Common.SystemRequiredPrincipal'*/, IQueryable<Common.Queryable.Common_PrincipalPermission>> filterFunction =
            (source, repository, parameter) => source.Where(item => item.Principal == null);

            /*ComposableFilterByInfo BeforeFilter Common.PrincipalPermission.'Common.SystemRequiredPrincipal'*/
            return filterFunction(localSource, _domRepository, localParameter/*ComposableFilterByInfo AdditionalParametersArgument Common.PrincipalPermission.'Common.SystemRequiredPrincipal'*/);
        }

        public IQueryable<Common.Queryable.Common_PrincipalPermission> Filter(IQueryable<Common.Queryable.Common_PrincipalPermission> localSource, Common.SystemRequiredClaim localParameter)
        {
            Func<IQueryable<Common.Queryable.Common_PrincipalPermission>, Common.DomRepository, Common.SystemRequiredClaim/*ComposableFilterByInfo AdditionalParametersType Common.PrincipalPermission.'Common.SystemRequiredClaim'*/, IQueryable<Common.Queryable.Common_PrincipalPermission>> filterFunction =
            (source, repository, parameter) => source.Where(item => item.Claim == null);

            /*ComposableFilterByInfo BeforeFilter Common.PrincipalPermission.'Common.SystemRequiredClaim'*/
            return filterFunction(localSource, _domRepository, localParameter/*ComposableFilterByInfo AdditionalParametersArgument Common.PrincipalPermission.'Common.SystemRequiredClaim'*/);
        }

        public global::Common.PrincipalPermission[] Filter(Common.SystemRequiredPrincipal filter_Parameter)
        {
            Func<Common.DomRepository, Common.SystemRequiredPrincipal/*FilterByInfo AdditionalParametersType Common.PrincipalPermission.'Common.SystemRequiredPrincipal'*/, Common.PrincipalPermission[]> filter_Function =
                (repository, parameter) => repository.Common.PrincipalPermission.Filter(repository.Common.PrincipalPermission.Query(), parameter).ToArray();

            return filter_Function(_domRepository, filter_Parameter/*FilterByInfo AdditionalParametersArgument Common.PrincipalPermission.'Common.SystemRequiredPrincipal'*/);
        }

        public global::Common.PrincipalPermission[] Filter(Common.SystemRequiredClaim filter_Parameter)
        {
            Func<Common.DomRepository, Common.SystemRequiredClaim/*FilterByInfo AdditionalParametersType Common.PrincipalPermission.'Common.SystemRequiredClaim'*/, Common.PrincipalPermission[]> filter_Function =
                (repository, parameter) => repository.Common.PrincipalPermission.Filter(repository.Common.PrincipalPermission.Query(), parameter).ToArray();

            return filter_Function(_domRepository, filter_Parameter/*FilterByInfo AdditionalParametersArgument Common.PrincipalPermission.'Common.SystemRequiredClaim'*/);
        }

        /*DataStructureInfo RepositoryMembers Common.PrincipalPermission*/
    }

    /*DataStructureInfo RepositoryAttributes Common.RolePermission*/
    public class RolePermission_Repository : /*DataStructureInfo OverrideBaseType Common.RolePermission*/ Common.OrmRepositoryBase<Common.Queryable.Common_RolePermission, Common.RolePermission> // Common.QueryableRepositoryBase<Common.Queryable.Common_RolePermission, Common.RolePermission> // Common.ReadableRepositoryBase<Common.RolePermission> // global::Common.RepositoryBase
        , IWritableRepository<Common.RolePermission>, IValidateRepository/*DataStructureInfo RepositoryInterface Common.RolePermission*/
    {
        private readonly Rhetos.Dom.DefaultConcepts.AuthorizationDataCache _authorizationDataCache;
        private readonly Rhetos.Utilities.ISqlUtility _sqlUtility;
        /*DataStructureInfo RepositoryPrivateMembers Common.RolePermission*/

        public RolePermission_Repository(Common.DomRepository domRepository, Common.ExecutionContext executionContext, Rhetos.Dom.DefaultConcepts.AuthorizationDataCache _authorizationDataCache, Rhetos.Utilities.ISqlUtility _sqlUtility/*DataStructureInfo RepositoryConstructorArguments Common.RolePermission*/)
        {
            _domRepository = domRepository;
            _executionContext = executionContext;
            this._authorizationDataCache = _authorizationDataCache;
            this._sqlUtility = _sqlUtility;
            /*DataStructureInfo RepositoryConstructorCode Common.RolePermission*/
        }

        [Obsolete("Use Load() or Query() method.")]
        public override global::Common.RolePermission[] All()
        {
            return Query().ToSimple().ToArray();
        }

        public override IQueryable<Common.Queryable.Common_RolePermission> Query()
        {
            /*DataStructureInfo RepositoryBeforeQuery Common.RolePermission*/
            return _executionContext.EntityFrameworkContext.Common_RolePermission.AsNoTracking();
        }

        public void Save(IEnumerable<Common.RolePermission> insertedNew, IEnumerable<Common.RolePermission> updatedNew, IEnumerable<Common.RolePermission> deletedIds, bool checkUserPermissions = false)
        {
            if (!DomHelper.CleanUpSaveMethodArguments(ref insertedNew, ref updatedNew, ref deletedIds))
                return;

            /*DataStructureInfo WritableOrm ClearContext Common.RolePermission*/

            /*DataStructureInfo WritableOrm ArgumentValidation Common.RolePermission*/

            var updatedIdsList = updatedNew.Select(item => item.ID).ToList();
            var deletedIdsList = deletedIds.Select(item => item.ID).ToList();
            var updatedOld = Filter(Query(), updatedIdsList).Select(item => new { item.ID,
                RoleID = item.RoleID/*LoadOldItemsInfo SelectProperties Common.RolePermission*/ }).ToList();
            var deletedOld = Filter(Query(), deletedIdsList).Select(item => new { item.ID,
                RoleID = item.RoleID/*LoadOldItemsInfo SelectProperties Common.RolePermission*/ }).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder(updatedOld, updatedIdsList, item => item.ID);
            Rhetos.Utilities.Graph.SortByGivenOrder(deletedOld, deletedIdsList, item => item.ID);

            /*DataStructureInfo WritableOrm Initialization Common.RolePermission*/

            // Using old data, including lazy loading of navigation properties:
            IEnumerable<Common.Queryable.Common_RolePermission> deleted = this.Query(deletedIds.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Common_RolePermission>)deleted, deletedIds.Select(item => item.ID), item => item.ID);
            IEnumerable<Common.Queryable.Common_RolePermission> updated = this.Query(updatedNew.Select(item => item.ID)).ToList();
            Rhetos.Utilities.Graph.SortByGivenOrder((List<Common.Queryable.Common_RolePermission>)updated, updatedNew.Select(item => item.ID), item => item.ID);

            /*DataStructureInfo WritableOrm OldDataLoaded Common.RolePermission*/

            {
                var invalid = insertedNew.Concat(updatedNew).FirstOrDefault(item => item.RoleID == null /*RequiredPropertyInfo OrCondition Common.RolePermission.Role*/);
                if (invalid != null)
                    throw new Rhetos.UserException("It is not allowed to enter {0} because the required property {1} is not set.",
                        new[] { "Common.RolePermission", "Role" },
                        "DataStructure:Common.RolePermission,ID:" + invalid.ID.ToString() + ",Property:RoleID", null);
            }
            {
                var invalid = insertedNew.Concat(updatedNew).FirstOrDefault(item => item.ClaimID == null /*RequiredPropertyInfo OrCondition Common.RolePermission.Claim*/);
                if (invalid != null)
                    throw new Rhetos.UserException("It is not allowed to enter {0} because the required property {1} is not set.",
                        new[] { "Common.RolePermission", "Claim" },
                        "DataStructure:Common.RolePermission,ID:" + invalid.ID.ToString() + ",Property:ClaimID", null);
            }
            {
                var invalid = insertedNew.Concat(updatedNew).FirstOrDefault(item => item.IsAuthorized == null /*RequiredPropertyInfo OrCondition Common.RolePermission.IsAuthorized*/);
                if (invalid != null)
                    throw new Rhetos.UserException("It is not allowed to enter {0} because the required property {1} is not set.",
                        new[] { "Common.RolePermission", "IsAuthorized" },
                        "DataStructure:Common.RolePermission,ID:" + invalid.ID.ToString() + ",Property:IsAuthorized", null);
            }
            /*DataStructureInfo WritableOrm ProcessedOldData Common.RolePermission*/

            DomHelper.SaveOperation saveOperation = DomHelper.SaveOperation.None;
            try
            {
                if (deletedIds.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Delete;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in deletedIds.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (updatedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Update;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var item in updatedNew.Select(item => item.ToNavigation()))
                        _executionContext.EntityFrameworkContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    _executionContext.EntityFrameworkContext.Configuration.AutoDetectChangesEnabled = true;
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                if (insertedNew.Count() > 0)
                {
                    saveOperation = DomHelper.SaveOperation.Insert;
                    _executionContext.EntityFrameworkContext.Common_RolePermission.AddRange(insertedNew.Select(item => item.ToNavigation()));
                    _executionContext.EntityFrameworkContext.SaveChanges();
                }

                saveOperation = DomHelper.SaveOperation.None;
                _executionContext.EntityFrameworkContext.ClearCache();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException saveException)
            {
                DomHelper.ThrowIfSavingNonexistentId(saveException, checkUserPermissions, saveOperation);
        		Rhetos.RhetosException interpretedException = _sqlUtility.InterpretSqlException(saveException);
        		if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnInsertUpdate(interpretedException, @"Common.Role", @"ID", @"FK_RolePermission_Role_RoleID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Common.RolePermission,Property:RoleID,Referenced:Common.Role";
                if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsReferenceErrorOnInsertUpdate(interpretedException, @"Common.Claim", @"ID", @"FK_RolePermission_Claim_ClaimID"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Common.RolePermission,Property:ClaimID,Referenced:Common.Claim";
                if (interpretedException is Rhetos.UserException && Rhetos.Utilities.MsSqlUtility.IsUniqueError(interpretedException, @"Common.RolePermission", @"IX_RolePermission_Role_Claim"))
                    ((Rhetos.UserException)interpretedException).SystemMessage = @"DataStructure:Common.RolePermission,Property:Role Claim";
                /*DataStructureInfo WritableOrm OnDatabaseError Common.RolePermission*/
                if (checkUserPermissions)
                    Rhetos.Utilities.MsSqlUtility.ThrowIfPrimaryKeyErrorOnInsert(interpretedException, "Common.RolePermission");

                if (interpretedException != null)
        			Rhetos.Utilities.ExceptionsUtility.Rethrow(interpretedException);
                var sqlException = _sqlUtility.ExtractSqlException(saveException);
                if (sqlException != null)
                    Rhetos.Utilities.ExceptionsUtility.Rethrow(sqlException);
                throw;
            }

            deleted = null;
            updated = this.Query(updatedNew.Select(item => item.ID));
            IEnumerable<Common.Queryable.Common_RolePermission> inserted = this.Query(insertedNew.Select(item => item.ID));

            bool allEffectsCompleted = false;
            try
            {
                { // ClearAuthenticationCache
                    var roleIds = insertedNew.Concat(updatedNew).Select(item => item.RoleID)
                        .Concat(updatedOld.Select(item => item.RoleID))
                        .Concat(deletedOld.Select(item => item.RoleID))
                        .Where(rid => rid != null).Select(rid => rid.Value);
                    _authorizationDataCache.ClearCacheRoles(roleIds);
                }

                /*DataStructureInfo WritableOrm OnSaveTag1 Common.RolePermission*/

                /*DataStructureInfo WritableOrm OnSaveTag2 Common.RolePermission*/

                Rhetos.Dom.DefaultConcepts.InvalidDataMessage.ValidateOnSave(insertedNew, updatedNew, this, "Common.RolePermission");

                /*DataStructureInfo WritableOrm AfterSave Common.RolePermission*/

                allEffectsCompleted = true;
            }
            finally
            {
                if (!allEffectsCompleted)
                    _executionContext.PersistenceTransaction.DiscardChanges();
            }
        }

        public IEnumerable<Rhetos.Dom.DefaultConcepts.InvalidDataMessage> Validate(IList<Guid> ids, bool onSave)
        {
            if (onSave)
            {
                var errorIds = this.Filter(this.Query(ids), new SystemRequiredRole()).Select(item => item.ID).ToArray();
                if (errorIds.Count() > 0)
                    foreach (var error in GetErrorMessage_SystemRequiredRole(errorIds))
                        yield return error;
            }
            if (onSave)
            {
                var errorIds = this.Filter(this.Query(ids), new SystemRequiredClaim()).Select(item => item.ID).ToArray();
                if (errorIds.Count() > 0)
                    foreach (var error in GetErrorMessage_SystemRequiredClaim(errorIds))
                        yield return error;
            }
            /*DataStructureInfo WritableOrm OnSaveValidate Common.RolePermission*/
            yield break;
        }

        public IEnumerable<InvalidDataMessage> GetErrorMessage_SystemRequiredRole(IEnumerable<Guid> invalidData_Ids)
        {
            const string invalidData_Description = @"System required property {0} is not set.";
            IDictionary<string, object> metadata = new Dictionary<string, object>();
            metadata["Validation"] = @"SystemRequiredRole";
            metadata[@"Property"] = @"Role";
            /*InvalidDataInfo ErrorMetadata Common.RolePermission.SystemRequiredRole*/
            return invalidData_Ids.Select(id => new InvalidDataMessage
            {
                ID = id,
                Message = invalidData_Description,
                MessageParameters = new object[] { @"Reference Common.RolePermission.Role" },
                Metadata = metadata
            });
            // /*InvalidDataInfo OverrideUserMessages Common.RolePermission.SystemRequiredRole*/ return invalidData_Ids.Select(id => new InvalidDataMessage { ID = id, Message = invalidData_Description, Metadata = metadata });
        }

        public IEnumerable<InvalidDataMessage> GetErrorMessage_SystemRequiredClaim(IEnumerable<Guid> invalidData_Ids)
        {
            const string invalidData_Description = @"System required property {0} is not set.";
            IDictionary<string, object> metadata = new Dictionary<string, object>();
            metadata["Validation"] = @"SystemRequiredClaim";
            metadata[@"Property"] = @"Claim";
            /*InvalidDataInfo ErrorMetadata Common.RolePermission.SystemRequiredClaim*/
            return invalidData_Ids.Select(id => new InvalidDataMessage
            {
                ID = id,
                Message = invalidData_Description,
                MessageParameters = new object[] { @"Reference Common.RolePermission.Claim" },
                Metadata = metadata
            });
            // /*InvalidDataInfo OverrideUserMessages Common.RolePermission.SystemRequiredClaim*/ return invalidData_Ids.Select(id => new InvalidDataMessage { ID = id, Message = invalidData_Description, Metadata = metadata });
        }

        public IQueryable<Common.Queryable.Common_RolePermission> Filter(IQueryable<Common.Queryable.Common_RolePermission> localSource, Common.SystemRequiredRole localParameter)
        {
            Func<IQueryable<Common.Queryable.Common_RolePermission>, Common.DomRepository, Common.SystemRequiredRole/*ComposableFilterByInfo AdditionalParametersType Common.RolePermission.'Common.SystemRequiredRole'*/, IQueryable<Common.Queryable.Common_RolePermission>> filterFunction =
            (source, repository, parameter) => source.Where(item => item.Role == null);

            /*ComposableFilterByInfo BeforeFilter Common.RolePermission.'Common.SystemRequiredRole'*/
            return filterFunction(localSource, _domRepository, localParameter/*ComposableFilterByInfo AdditionalParametersArgument Common.RolePermission.'Common.SystemRequiredRole'*/);
        }

        public IQueryable<Common.Queryable.Common_RolePermission> Filter(IQueryable<Common.Queryable.Common_RolePermission> localSource, Common.SystemRequiredClaim localParameter)
        {
            Func<IQueryable<Common.Queryable.Common_RolePermission>, Common.DomRepository, Common.SystemRequiredClaim/*ComposableFilterByInfo AdditionalParametersType Common.RolePermission.'Common.SystemRequiredClaim'*/, IQueryable<Common.Queryable.Common_RolePermission>> filterFunction =
            (source, repository, parameter) => source.Where(item => item.Claim == null);

            /*ComposableFilterByInfo BeforeFilter Common.RolePermission.'Common.SystemRequiredClaim'*/
            return filterFunction(localSource, _domRepository, localParameter/*ComposableFilterByInfo AdditionalParametersArgument Common.RolePermission.'Common.SystemRequiredClaim'*/);
        }

        public global::Common.RolePermission[] Filter(Common.SystemRequiredRole filter_Parameter)
        {
            Func<Common.DomRepository, Common.SystemRequiredRole/*FilterByInfo AdditionalParametersType Common.RolePermission.'Common.SystemRequiredRole'*/, Common.RolePermission[]> filter_Function =
                (repository, parameter) => repository.Common.RolePermission.Filter(repository.Common.RolePermission.Query(), parameter).ToArray();

            return filter_Function(_domRepository, filter_Parameter/*FilterByInfo AdditionalParametersArgument Common.RolePermission.'Common.SystemRequiredRole'*/);
        }

        public global::Common.RolePermission[] Filter(Common.SystemRequiredClaim filter_Parameter)
        {
            Func<Common.DomRepository, Common.SystemRequiredClaim/*FilterByInfo AdditionalParametersType Common.RolePermission.'Common.SystemRequiredClaim'*/, Common.RolePermission[]> filter_Function =
                (repository, parameter) => repository.Common.RolePermission.Filter(repository.Common.RolePermission.Query(), parameter).ToArray();

            return filter_Function(_domRepository, filter_Parameter/*FilterByInfo AdditionalParametersArgument Common.RolePermission.'Common.SystemRequiredClaim'*/);
        }

        /*DataStructureInfo RepositoryMembers Common.RolePermission*/
    }

    /*ModuleInfo HelperNamespaceMembers Common*/
}

/*RepositoryClasses*/
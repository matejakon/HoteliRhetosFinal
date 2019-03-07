// Reference: C:\Windows\Microsoft.NET\Framework64\v4.0.30319\mscorlib.dll
// Reference: C:\windows\Microsoft.Net\assembly\GAC_MSIL\System.Core\v4.0_4.0.0.0__b77a5c561934e089\System.Core.dll
// Reference: C:\windows\Microsoft.Net\assembly\GAC_MSIL\System.Configuration\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Configuration.dll
// Reference: C:\windows\Microsoft.Net\assembly\GAC_MSIL\System\v4.0_4.0.0.0__b77a5c561934e089\System.dll
// Reference: C:\windows\Microsoft.Net\assembly\GAC_MSIL\System.Xml\v4.0_4.0.0.0__b77a5c561934e089\System.Xml.dll
// Reference: C:\windows\Microsoft.Net\assembly\GAC_MSIL\System.ComponentModel.Composition\v4.0_4.0.0.0__b77a5c561934e089\System.ComponentModel.Composition.dll
// Reference: C:\Users\Mateja\Documents\Hoteli\dist\HoteliRhetosServer\bin\Autofac.Integration.Wcf.dll
// Reference: C:\windows\Microsoft.Net\assembly\GAC_MSIL\System.ServiceModel.Activation\v4.0_4.0.0.0__31bf3856ad364e35\System.ServiceModel.Activation.dll
// Reference: C:\windows\Microsoft.Net\assembly\GAC_MSIL\System.ServiceModel\v4.0_4.0.0.0__b77a5c561934e089\System.ServiceModel.dll
// Reference: C:\windows\Microsoft.Net\assembly\GAC_MSIL\System.ServiceModel.Web\v4.0_4.0.0.0__31bf3856ad364e35\System.ServiceModel.Web.dll
// Reference: C:\windows\Microsoft.Net\assembly\GAC_64\System.Web\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Web.dll
// Reference: C:\Users\Mateja\Documents\Hoteli\dist\HoteliRhetosServer\bin\Rhetos.Interfaces.dll
// Reference: C:\Users\Mateja\Documents\Hoteli\dist\HoteliRhetosServer\bin\Plugins\Rhetos.Dom.DefaultConcepts.Interfaces.dll
// Reference: C:\Users\Mateja\Documents\Hoteli\dist\HoteliRhetosServer\bin\Rhetos.Logging.Interfaces.dll
// Reference: C:\Users\Mateja\Documents\Hoteli\dist\HoteliRhetosServer\bin\Rhetos.Processing.Interfaces.dll
// Reference: C:\Users\Mateja\Documents\Hoteli\dist\HoteliRhetosServer\bin\Rhetos.Utilities.dll
// Reference: C:\Users\Mateja\Documents\Hoteli\dist\HoteliRhetosServer\bin\Rhetos.XmlSerialization.dll
// Reference: C:\Users\Mateja\Documents\Hoteli\dist\HoteliRhetosServer\bin\Rhetos.Web.dll
// Reference: C:\Users\Mateja\Documents\Hoteli\dist\HoteliRhetosServer\bin\Plugins\Rhetos.RestGenerator.dll
// Reference: C:\Users\Mateja\Documents\Hoteli\dist\HoteliRhetosServer\bin\Generated\ServerDom.Model.dll
// Reference: C:\Users\Mateja\Documents\Hoteli\dist\HoteliRhetosServer\bin\Generated\ServerDom.Orm.dll
// Reference: C:\Users\Mateja\Documents\Hoteli\dist\HoteliRhetosServer\bin\Generated\ServerDom.Repositories.dll
// Reference: C:\Users\Mateja\Documents\Hoteli\dist\HoteliRhetosServer\bin\Autofac.dll
// Reference: C:\Users\Mateja\Documents\Hoteli\dist\HoteliRhetosServer\bin\Plugins\Rhetos.Processing.DefaultCommands.Interfaces.dll
// Reference: C:\Users\Mateja\Documents\Hoteli\dist\HoteliRhetosServer\bin\Newtonsoft.Json.dll
// Reference: C:\Users\Mateja\Documents\Hoteli\dist\HoteliRhetosServer\bin\Plugins\Rhetos.Dom.DefaultConcepts.dll
// CompilerOptions: ""


using Autofac;
using Module = Autofac.Module;
using Rhetos.Dom.DefaultConcepts;
using Rhetos.RestGenerator.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;
using System.Web;
using System.Net;
using System.IO;
using System.Text;
using System.Web.Routing;

namespace Rhetos.Rest
{
    public class RestServiceHostFactory : Autofac.Integration.Wcf.AutofacServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            RestServiceHost host = new RestServiceHost(serviceType, baseAddresses);

            return host;
        }
    }

    public class RestServiceHost : ServiceHost
    {
        private Type _serviceType;

        public RestServiceHost(Type serviceType, Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
            _serviceType = serviceType;
        }

        protected override void OnOpening()
        {
            base.OnOpening();
            this.AddServiceEndpoint(_serviceType, new WebHttpBinding("rhetosWebHttpBinding"), string.Empty);
            this.AddServiceEndpoint(_serviceType, new BasicHttpBinding("rhetosBasicHttpBinding"), "SOAP");

            ((ServiceEndpoint)(Description.Endpoints.Where(e => e.Binding is WebHttpBinding).Single())).Behaviors.Add(new WebHttpBehavior()); 
            if (Description.Behaviors.Find<Rhetos.Web.JsonErrorServiceBehavior>() == null)
                Description.Behaviors.Add(new Rhetos.Web.JsonErrorServiceBehavior());
        }
    }

    [System.ComponentModel.Composition.Export(typeof(Module))]
    public class RestServiceModuleConfiguration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ServiceUtility>().InstancePerLifetimeScope();
            builder.RegisterType<RestServiceHoteliHotel>().InstancePerLifetimeScope();
            builder.RegisterType<RestServiceHoteliLocation>().InstancePerLifetimeScope();
            builder.RegisterType<RestServiceHoteliRoomReservation>().InstancePerLifetimeScope();
            builder.RegisterType<RestServiceHoteliReservation>().InstancePerLifetimeScope();
            builder.RegisterType<RestServiceHoteliRooms>().InstancePerLifetimeScope();
            builder.RegisterType<RestServiceHoteliPerson>().InstancePerLifetimeScope();
            builder.RegisterType<RestServiceHoteliSaloonPerson>().InstancePerLifetimeScope();
            builder.RegisterType<RestServiceHoteliSaloonHotel>().InstancePerLifetimeScope();
            builder.RegisterType<RestServiceHoteliSaloon>().InstancePerLifetimeScope();
            builder.RegisterType<RestServiceHoteliProductPerson>().InstancePerLifetimeScope();
            builder.RegisterType<RestServiceHoteliProductHotel>().InstancePerLifetimeScope();
            builder.RegisterType<RestServiceHoteliProduct>().InstancePerLifetimeScope();
            builder.RegisterType<RestServiceHoteliInsert5Hotels>().InstancePerLifetimeScope();
            builder.RegisterType<RestServiceHoteliInsert5Rooms>().InstancePerLifetimeScope();
            builder.RegisterType<RestServiceHoteliInsert6Rooms>().InstancePerLifetimeScope();
            builder.RegisterType<RestServiceHoteliReservationInfo>().InstancePerLifetimeScope();
            builder.RegisterType<RestServiceCommonAutoCodeCache>().InstancePerLifetimeScope();
            builder.RegisterType<RestServiceCommonFilterId>().InstancePerLifetimeScope();
            builder.RegisterType<RestServiceCommonKeepSynchronizedMetadata>().InstancePerLifetimeScope();
            builder.RegisterType<RestServiceCommonExclusiveLock>().InstancePerLifetimeScope();
            builder.RegisterType<RestServiceCommonSetLock>().InstancePerLifetimeScope();
            builder.RegisterType<RestServiceCommonReleaseLock>().InstancePerLifetimeScope();
            builder.RegisterType<RestServiceCommonLogReader>().InstancePerLifetimeScope();
            builder.RegisterType<RestServiceCommonLogRelatedItemReader>().InstancePerLifetimeScope();
            builder.RegisterType<RestServiceCommonLog>().InstancePerLifetimeScope();
            builder.RegisterType<RestServiceCommonAddToLog>().InstancePerLifetimeScope();
            builder.RegisterType<RestServiceCommonLogRelatedItem>().InstancePerLifetimeScope();
            builder.RegisterType<RestServiceCommonRelatedEventsSource>().InstancePerLifetimeScope();
            builder.RegisterType<RestServiceCommonClaim>().InstancePerLifetimeScope();
            builder.RegisterType<RestServiceCommonMyClaim>().InstancePerLifetimeScope();
            builder.RegisterType<RestServiceCommonPrincipal>().InstancePerLifetimeScope();
            builder.RegisterType<RestServiceCommonPrincipalHasRole>().InstancePerLifetimeScope();
            builder.RegisterType<RestServiceCommonRole>().InstancePerLifetimeScope();
            builder.RegisterType<RestServiceCommonRoleInheritsRole>().InstancePerLifetimeScope();
            builder.RegisterType<RestServiceCommonPrincipalPermission>().InstancePerLifetimeScope();
            builder.RegisterType<RestServiceCommonRolePermission>().InstancePerLifetimeScope();
            /*InitialCodeGenerator.ServiceRegistrationTag*/
            base.Load(builder);
        }
    }

    [System.ComponentModel.Composition.Export(typeof(Rhetos.IService))]
    public class RestServiceInitializer : Rhetos.IService
    {
        public void Initialize()
        {
            System.Web.Routing.RouteTable.Routes.Add(new System.ServiceModel.Activation.ServiceRoute("Rest/Hoteli/Hotel", 
                new RestServiceHostFactory(), typeof(RestServiceHoteliHotel)));
            System.Web.Routing.RouteTable.Routes.Add(new System.ServiceModel.Activation.ServiceRoute("Rest/Hoteli/Location", 
                new RestServiceHostFactory(), typeof(RestServiceHoteliLocation)));
            System.Web.Routing.RouteTable.Routes.Add(new System.ServiceModel.Activation.ServiceRoute("Rest/Hoteli/RoomReservation", 
                new RestServiceHostFactory(), typeof(RestServiceHoteliRoomReservation)));
            System.Web.Routing.RouteTable.Routes.Add(new System.ServiceModel.Activation.ServiceRoute("Rest/Hoteli/Reservation", 
                new RestServiceHostFactory(), typeof(RestServiceHoteliReservation)));
            System.Web.Routing.RouteTable.Routes.Add(new System.ServiceModel.Activation.ServiceRoute("Rest/Hoteli/Rooms", 
                new RestServiceHostFactory(), typeof(RestServiceHoteliRooms)));
            System.Web.Routing.RouteTable.Routes.Add(new System.ServiceModel.Activation.ServiceRoute("Rest/Hoteli/Person", 
                new RestServiceHostFactory(), typeof(RestServiceHoteliPerson)));
            System.Web.Routing.RouteTable.Routes.Add(new System.ServiceModel.Activation.ServiceRoute("Rest/Hoteli/SaloonPerson", 
                new RestServiceHostFactory(), typeof(RestServiceHoteliSaloonPerson)));
            System.Web.Routing.RouteTable.Routes.Add(new System.ServiceModel.Activation.ServiceRoute("Rest/Hoteli/SaloonHotel", 
                new RestServiceHostFactory(), typeof(RestServiceHoteliSaloonHotel)));
            System.Web.Routing.RouteTable.Routes.Add(new System.ServiceModel.Activation.ServiceRoute("Rest/Hoteli/Saloon", 
                new RestServiceHostFactory(), typeof(RestServiceHoteliSaloon)));
            System.Web.Routing.RouteTable.Routes.Add(new System.ServiceModel.Activation.ServiceRoute("Rest/Hoteli/ProductPerson", 
                new RestServiceHostFactory(), typeof(RestServiceHoteliProductPerson)));
            System.Web.Routing.RouteTable.Routes.Add(new System.ServiceModel.Activation.ServiceRoute("Rest/Hoteli/ProductHotel", 
                new RestServiceHostFactory(), typeof(RestServiceHoteliProductHotel)));
            System.Web.Routing.RouteTable.Routes.Add(new System.ServiceModel.Activation.ServiceRoute("Rest/Hoteli/Product", 
                new RestServiceHostFactory(), typeof(RestServiceHoteliProduct)));
            System.Web.Routing.RouteTable.Routes.Add(new System.ServiceModel.Activation.ServiceRoute("Rest/Hoteli/Insert5Hotels", 
                new RestServiceHostFactory(), typeof(RestServiceHoteliInsert5Hotels)));
            System.Web.Routing.RouteTable.Routes.Add(new System.ServiceModel.Activation.ServiceRoute("Rest/Hoteli/Insert5Rooms", 
                new RestServiceHostFactory(), typeof(RestServiceHoteliInsert5Rooms)));
            System.Web.Routing.RouteTable.Routes.Add(new System.ServiceModel.Activation.ServiceRoute("Rest/Hoteli/Insert6Rooms", 
                new RestServiceHostFactory(), typeof(RestServiceHoteliInsert6Rooms)));
            System.Web.Routing.RouteTable.Routes.Add(new System.ServiceModel.Activation.ServiceRoute("Rest/Hoteli/ReservationInfo", 
                new RestServiceHostFactory(), typeof(RestServiceHoteliReservationInfo)));
            System.Web.Routing.RouteTable.Routes.Add(new System.ServiceModel.Activation.ServiceRoute("Rest/Common/AutoCodeCache", 
                new RestServiceHostFactory(), typeof(RestServiceCommonAutoCodeCache)));
            System.Web.Routing.RouteTable.Routes.Add(new System.ServiceModel.Activation.ServiceRoute("Rest/Common/FilterId", 
                new RestServiceHostFactory(), typeof(RestServiceCommonFilterId)));
            System.Web.Routing.RouteTable.Routes.Add(new System.ServiceModel.Activation.ServiceRoute("Rest/Common/KeepSynchronizedMetadata", 
                new RestServiceHostFactory(), typeof(RestServiceCommonKeepSynchronizedMetadata)));
            System.Web.Routing.RouteTable.Routes.Add(new System.ServiceModel.Activation.ServiceRoute("Rest/Common/ExclusiveLock", 
                new RestServiceHostFactory(), typeof(RestServiceCommonExclusiveLock)));
            System.Web.Routing.RouteTable.Routes.Add(new System.ServiceModel.Activation.ServiceRoute("Rest/Common/SetLock", 
                new RestServiceHostFactory(), typeof(RestServiceCommonSetLock)));
            System.Web.Routing.RouteTable.Routes.Add(new System.ServiceModel.Activation.ServiceRoute("Rest/Common/ReleaseLock", 
                new RestServiceHostFactory(), typeof(RestServiceCommonReleaseLock)));
            System.Web.Routing.RouteTable.Routes.Add(new System.ServiceModel.Activation.ServiceRoute("Rest/Common/LogReader", 
                new RestServiceHostFactory(), typeof(RestServiceCommonLogReader)));
            System.Web.Routing.RouteTable.Routes.Add(new System.ServiceModel.Activation.ServiceRoute("Rest/Common/LogRelatedItemReader", 
                new RestServiceHostFactory(), typeof(RestServiceCommonLogRelatedItemReader)));
            System.Web.Routing.RouteTable.Routes.Add(new System.ServiceModel.Activation.ServiceRoute("Rest/Common/Log", 
                new RestServiceHostFactory(), typeof(RestServiceCommonLog)));
            System.Web.Routing.RouteTable.Routes.Add(new System.ServiceModel.Activation.ServiceRoute("Rest/Common/AddToLog", 
                new RestServiceHostFactory(), typeof(RestServiceCommonAddToLog)));
            System.Web.Routing.RouteTable.Routes.Add(new System.ServiceModel.Activation.ServiceRoute("Rest/Common/LogRelatedItem", 
                new RestServiceHostFactory(), typeof(RestServiceCommonLogRelatedItem)));
            System.Web.Routing.RouteTable.Routes.Add(new System.ServiceModel.Activation.ServiceRoute("Rest/Common/RelatedEventsSource", 
                new RestServiceHostFactory(), typeof(RestServiceCommonRelatedEventsSource)));
            System.Web.Routing.RouteTable.Routes.Add(new System.ServiceModel.Activation.ServiceRoute("Rest/Common/Claim", 
                new RestServiceHostFactory(), typeof(RestServiceCommonClaim)));
            System.Web.Routing.RouteTable.Routes.Add(new System.ServiceModel.Activation.ServiceRoute("Rest/Common/MyClaim", 
                new RestServiceHostFactory(), typeof(RestServiceCommonMyClaim)));
            System.Web.Routing.RouteTable.Routes.Add(new System.ServiceModel.Activation.ServiceRoute("Rest/Common/Principal", 
                new RestServiceHostFactory(), typeof(RestServiceCommonPrincipal)));
            System.Web.Routing.RouteTable.Routes.Add(new System.ServiceModel.Activation.ServiceRoute("Rest/Common/PrincipalHasRole", 
                new RestServiceHostFactory(), typeof(RestServiceCommonPrincipalHasRole)));
            System.Web.Routing.RouteTable.Routes.Add(new System.ServiceModel.Activation.ServiceRoute("Rest/Common/Role", 
                new RestServiceHostFactory(), typeof(RestServiceCommonRole)));
            System.Web.Routing.RouteTable.Routes.Add(new System.ServiceModel.Activation.ServiceRoute("Rest/Common/RoleInheritsRole", 
                new RestServiceHostFactory(), typeof(RestServiceCommonRoleInheritsRole)));
            System.Web.Routing.RouteTable.Routes.Add(new System.ServiceModel.Activation.ServiceRoute("Rest/Common/PrincipalPermission", 
                new RestServiceHostFactory(), typeof(RestServiceCommonPrincipalPermission)));
            System.Web.Routing.RouteTable.Routes.Add(new System.ServiceModel.Activation.ServiceRoute("Rest/Common/RolePermission", 
                new RestServiceHostFactory(), typeof(RestServiceCommonRolePermission)));
            /*InitialCodeGenerator.ServiceInitializationTag*/
        }

        public void InitializeApplicationInstance(System.Web.HttpApplication context)
        {
        }
    }


    [System.ServiceModel.ServiceContract]
    [System.ServiceModel.Activation.AspNetCompatibilityRequirements(RequirementsMode = System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestServiceHoteliHotel
    {
        private ServiceUtility _serviceUtility;
        /*DataStructureInfo AdditionalPropertyInitialization Hoteli.Hotel*/

        public RestServiceHoteliHotel(ServiceUtility serviceUtility/*DataStructureInfo AdditionalPropertyConstructorParameter Hoteli.Hotel*/)
        {
            _serviceUtility = serviceUtility;
            /*DataStructureInfo AdditionalPropertyConstructorSetProperties Hoteli.Hotel*/
        }
    
        public static readonly IDictionary<string, Type[]> FilterTypes = new List<Tuple<string, Type>>
            {
                Tuple.Create("Hoteli.SystemRequiredCode", typeof(Hoteli.SystemRequiredCode)),
                Tuple.Create("SystemRequiredCode", typeof(Hoteli.SystemRequiredCode)),
                /*DataStructureInfo FilterTypes Hoteli.Hotel*/
            }
            .GroupBy(typeName => typeName.Item1)
            .ToDictionary(g => g.Key, g => g.Select(typeName => typeName.Item2).Distinct().ToArray());

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsResult<Hoteli.Hotel> Get(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            var data = _serviceUtility.GetData<Hoteli.Hotel>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: false);
            return new RecordsResult<Hoteli.Hotel> { Records = data.Records };
        }

        [Obsolete]
        [OperationContract]
        [WebGet(UriTemplate = "/Count?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public CountResult GetCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Hoteli.Hotel>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new CountResult { TotalRecords = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters).
        [OperationContract]
        [WebGet(UriTemplate = "/TotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public TotalCountResult GetTotalCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Hoteli.Hotel>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new TotalCountResult { TotalCount = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/RecordsAndTotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsAndTotalCountResult<Hoteli.Hotel> GetRecordsAndTotalCount(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            return _serviceUtility.GetData<Hoteli.Hotel>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: true);
        }

        [OperationContract]
        [WebGet(UriTemplate = "/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Hoteli.Hotel GetById(string id)
        {
            var result = _serviceUtility.GetDataById<Hoteli.Hotel>(id);
            if (result == null)
                throw new Rhetos.LegacyClientException("There is no resource of this type with a given ID.") { HttpStatusCode = HttpStatusCode.NotFound, Severe = false };
            return result;
        }

        
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public InsertDataResult InsertHoteliHotel(Hoteli.Hotel entity)
        {
            if (Guid.Empty == entity.ID)
                entity.ID = Guid.NewGuid();

            var result = _serviceUtility.InsertData(entity);
            return new InsertDataResult { ID = entity.ID };
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void UpdateHoteliHotel(string id, Hoteli.Hotel entity)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            if (Guid.Empty == entity.ID)
                entity.ID = guid;
            if (guid != entity.ID)
                throw new Rhetos.LegacyClientException("Given entity ID is not equal to resource ID from URI.");

            _serviceUtility.UpdateData(entity);
        }

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void DeleteHoteliHotel(string id)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            var entity = new Hoteli.Hotel { ID = guid };

            _serviceUtility.DeleteData(entity);
        }

/*DataStructureInfo AdditionalOperations Hoteli.Hotel*/
    }
    
    [System.ServiceModel.ServiceContract]
    [System.ServiceModel.Activation.AspNetCompatibilityRequirements(RequirementsMode = System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestServiceHoteliLocation
    {
        private ServiceUtility _serviceUtility;
        /*DataStructureInfo AdditionalPropertyInitialization Hoteli.Location*/

        public RestServiceHoteliLocation(ServiceUtility serviceUtility/*DataStructureInfo AdditionalPropertyConstructorParameter Hoteli.Location*/)
        {
            _serviceUtility = serviceUtility;
            /*DataStructureInfo AdditionalPropertyConstructorSetProperties Hoteli.Location*/
        }
    
        public static readonly IDictionary<string, Type[]> FilterTypes = new List<Tuple<string, Type>>
            {
                Tuple.Create("Hoteli.SystemRequiredCode", typeof(Hoteli.SystemRequiredCode)),
                Tuple.Create("SystemRequiredCode", typeof(Hoteli.SystemRequiredCode)),
                /*DataStructureInfo FilterTypes Hoteli.Location*/
            }
            .GroupBy(typeName => typeName.Item1)
            .ToDictionary(g => g.Key, g => g.Select(typeName => typeName.Item2).Distinct().ToArray());

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsResult<Hoteli.Location> Get(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            var data = _serviceUtility.GetData<Hoteli.Location>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: false);
            return new RecordsResult<Hoteli.Location> { Records = data.Records };
        }

        [Obsolete]
        [OperationContract]
        [WebGet(UriTemplate = "/Count?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public CountResult GetCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Hoteli.Location>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new CountResult { TotalRecords = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters).
        [OperationContract]
        [WebGet(UriTemplate = "/TotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public TotalCountResult GetTotalCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Hoteli.Location>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new TotalCountResult { TotalCount = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/RecordsAndTotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsAndTotalCountResult<Hoteli.Location> GetRecordsAndTotalCount(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            return _serviceUtility.GetData<Hoteli.Location>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: true);
        }

        [OperationContract]
        [WebGet(UriTemplate = "/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Hoteli.Location GetById(string id)
        {
            var result = _serviceUtility.GetDataById<Hoteli.Location>(id);
            if (result == null)
                throw new Rhetos.LegacyClientException("There is no resource of this type with a given ID.") { HttpStatusCode = HttpStatusCode.NotFound, Severe = false };
            return result;
        }

        
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public InsertDataResult InsertHoteliLocation(Hoteli.Location entity)
        {
            if (Guid.Empty == entity.ID)
                entity.ID = Guid.NewGuid();

            var result = _serviceUtility.InsertData(entity);
            return new InsertDataResult { ID = entity.ID };
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void UpdateHoteliLocation(string id, Hoteli.Location entity)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            if (Guid.Empty == entity.ID)
                entity.ID = guid;
            if (guid != entity.ID)
                throw new Rhetos.LegacyClientException("Given entity ID is not equal to resource ID from URI.");

            _serviceUtility.UpdateData(entity);
        }

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void DeleteHoteliLocation(string id)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            var entity = new Hoteli.Location { ID = guid };

            _serviceUtility.DeleteData(entity);
        }

/*DataStructureInfo AdditionalOperations Hoteli.Location*/
    }
    
    [System.ServiceModel.ServiceContract]
    [System.ServiceModel.Activation.AspNetCompatibilityRequirements(RequirementsMode = System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestServiceHoteliRoomReservation
    {
        private ServiceUtility _serviceUtility;
        /*DataStructureInfo AdditionalPropertyInitialization Hoteli.RoomReservation*/

        public RestServiceHoteliRoomReservation(ServiceUtility serviceUtility/*DataStructureInfo AdditionalPropertyConstructorParameter Hoteli.RoomReservation*/)
        {
            _serviceUtility = serviceUtility;
            /*DataStructureInfo AdditionalPropertyConstructorSetProperties Hoteli.RoomReservation*/
        }
    
        public static readonly IDictionary<string, Type[]> FilterTypes = new List<Tuple<string, Type>>
            {
                Tuple.Create("Hoteli.SystemRequiredCode", typeof(Hoteli.SystemRequiredCode)),
                Tuple.Create("SystemRequiredCode", typeof(Hoteli.SystemRequiredCode)),
                /*DataStructureInfo FilterTypes Hoteli.RoomReservation*/
            }
            .GroupBy(typeName => typeName.Item1)
            .ToDictionary(g => g.Key, g => g.Select(typeName => typeName.Item2).Distinct().ToArray());

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsResult<Hoteli.RoomReservation> Get(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            var data = _serviceUtility.GetData<Hoteli.RoomReservation>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: false);
            return new RecordsResult<Hoteli.RoomReservation> { Records = data.Records };
        }

        [Obsolete]
        [OperationContract]
        [WebGet(UriTemplate = "/Count?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public CountResult GetCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Hoteli.RoomReservation>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new CountResult { TotalRecords = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters).
        [OperationContract]
        [WebGet(UriTemplate = "/TotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public TotalCountResult GetTotalCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Hoteli.RoomReservation>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new TotalCountResult { TotalCount = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/RecordsAndTotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsAndTotalCountResult<Hoteli.RoomReservation> GetRecordsAndTotalCount(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            return _serviceUtility.GetData<Hoteli.RoomReservation>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: true);
        }

        [OperationContract]
        [WebGet(UriTemplate = "/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Hoteli.RoomReservation GetById(string id)
        {
            var result = _serviceUtility.GetDataById<Hoteli.RoomReservation>(id);
            if (result == null)
                throw new Rhetos.LegacyClientException("There is no resource of this type with a given ID.") { HttpStatusCode = HttpStatusCode.NotFound, Severe = false };
            return result;
        }

        
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public InsertDataResult InsertHoteliRoomReservation(Hoteli.RoomReservation entity)
        {
            if (Guid.Empty == entity.ID)
                entity.ID = Guid.NewGuid();

            var result = _serviceUtility.InsertData(entity);
            return new InsertDataResult { ID = entity.ID };
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void UpdateHoteliRoomReservation(string id, Hoteli.RoomReservation entity)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            if (Guid.Empty == entity.ID)
                entity.ID = guid;
            if (guid != entity.ID)
                throw new Rhetos.LegacyClientException("Given entity ID is not equal to resource ID from URI.");

            _serviceUtility.UpdateData(entity);
        }

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void DeleteHoteliRoomReservation(string id)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            var entity = new Hoteli.RoomReservation { ID = guid };

            _serviceUtility.DeleteData(entity);
        }

/*DataStructureInfo AdditionalOperations Hoteli.RoomReservation*/
    }
    
    [System.ServiceModel.ServiceContract]
    [System.ServiceModel.Activation.AspNetCompatibilityRequirements(RequirementsMode = System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestServiceHoteliReservation
    {
        private ServiceUtility _serviceUtility;
        /*DataStructureInfo AdditionalPropertyInitialization Hoteli.Reservation*/

        public RestServiceHoteliReservation(ServiceUtility serviceUtility/*DataStructureInfo AdditionalPropertyConstructorParameter Hoteli.Reservation*/)
        {
            _serviceUtility = serviceUtility;
            /*DataStructureInfo AdditionalPropertyConstructorSetProperties Hoteli.Reservation*/
        }
    
        public static readonly IDictionary<string, Type[]> FilterTypes = new List<Tuple<string, Type>>
            {
                Tuple.Create("Hoteli.Negative", typeof(Hoteli.Negative)),
                Tuple.Create("Negative", typeof(Hoteli.Negative)),
                Tuple.Create("Hoteli.SystemRequiredCode", typeof(Hoteli.SystemRequiredCode)),
                Tuple.Create("SystemRequiredCode", typeof(Hoteli.SystemRequiredCode)),
                /*DataStructureInfo FilterTypes Hoteli.Reservation*/
            }
            .GroupBy(typeName => typeName.Item1)
            .ToDictionary(g => g.Key, g => g.Select(typeName => typeName.Item2).Distinct().ToArray());

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsResult<Hoteli.Reservation> Get(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            var data = _serviceUtility.GetData<Hoteli.Reservation>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: false);
            return new RecordsResult<Hoteli.Reservation> { Records = data.Records };
        }

        [Obsolete]
        [OperationContract]
        [WebGet(UriTemplate = "/Count?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public CountResult GetCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Hoteli.Reservation>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new CountResult { TotalRecords = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters).
        [OperationContract]
        [WebGet(UriTemplate = "/TotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public TotalCountResult GetTotalCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Hoteli.Reservation>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new TotalCountResult { TotalCount = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/RecordsAndTotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsAndTotalCountResult<Hoteli.Reservation> GetRecordsAndTotalCount(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            return _serviceUtility.GetData<Hoteli.Reservation>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: true);
        }

        [OperationContract]
        [WebGet(UriTemplate = "/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Hoteli.Reservation GetById(string id)
        {
            var result = _serviceUtility.GetDataById<Hoteli.Reservation>(id);
            if (result == null)
                throw new Rhetos.LegacyClientException("There is no resource of this type with a given ID.") { HttpStatusCode = HttpStatusCode.NotFound, Severe = false };
            return result;
        }

        
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public InsertDataResult InsertHoteliReservation(Hoteli.Reservation entity)
        {
            if (Guid.Empty == entity.ID)
                entity.ID = Guid.NewGuid();

            var result = _serviceUtility.InsertData(entity);
            return new InsertDataResult { ID = entity.ID };
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void UpdateHoteliReservation(string id, Hoteli.Reservation entity)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            if (Guid.Empty == entity.ID)
                entity.ID = guid;
            if (guid != entity.ID)
                throw new Rhetos.LegacyClientException("Given entity ID is not equal to resource ID from URI.");

            _serviceUtility.UpdateData(entity);
        }

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void DeleteHoteliReservation(string id)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            var entity = new Hoteli.Reservation { ID = guid };

            _serviceUtility.DeleteData(entity);
        }

/*DataStructureInfo AdditionalOperations Hoteli.Reservation*/
    }
    
    [System.ServiceModel.ServiceContract]
    [System.ServiceModel.Activation.AspNetCompatibilityRequirements(RequirementsMode = System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestServiceHoteliRooms
    {
        private ServiceUtility _serviceUtility;
        /*DataStructureInfo AdditionalPropertyInitialization Hoteli.Rooms*/

        public RestServiceHoteliRooms(ServiceUtility serviceUtility/*DataStructureInfo AdditionalPropertyConstructorParameter Hoteli.Rooms*/)
        {
            _serviceUtility = serviceUtility;
            /*DataStructureInfo AdditionalPropertyConstructorSetProperties Hoteli.Rooms*/
        }
    
        public static readonly IDictionary<string, Type[]> FilterTypes = new List<Tuple<string, Type>>
            {
                Tuple.Create("Hoteli.SystemRequiredCode", typeof(Hoteli.SystemRequiredCode)),
                Tuple.Create("SystemRequiredCode", typeof(Hoteli.SystemRequiredCode)),
                /*DataStructureInfo FilterTypes Hoteli.Rooms*/
            }
            .GroupBy(typeName => typeName.Item1)
            .ToDictionary(g => g.Key, g => g.Select(typeName => typeName.Item2).Distinct().ToArray());

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsResult<Hoteli.Rooms> Get(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            var data = _serviceUtility.GetData<Hoteli.Rooms>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: false);
            return new RecordsResult<Hoteli.Rooms> { Records = data.Records };
        }

        [Obsolete]
        [OperationContract]
        [WebGet(UriTemplate = "/Count?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public CountResult GetCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Hoteli.Rooms>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new CountResult { TotalRecords = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters).
        [OperationContract]
        [WebGet(UriTemplate = "/TotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public TotalCountResult GetTotalCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Hoteli.Rooms>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new TotalCountResult { TotalCount = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/RecordsAndTotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsAndTotalCountResult<Hoteli.Rooms> GetRecordsAndTotalCount(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            return _serviceUtility.GetData<Hoteli.Rooms>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: true);
        }

        [OperationContract]
        [WebGet(UriTemplate = "/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Hoteli.Rooms GetById(string id)
        {
            var result = _serviceUtility.GetDataById<Hoteli.Rooms>(id);
            if (result == null)
                throw new Rhetos.LegacyClientException("There is no resource of this type with a given ID.") { HttpStatusCode = HttpStatusCode.NotFound, Severe = false };
            return result;
        }

        
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public InsertDataResult InsertHoteliRooms(Hoteli.Rooms entity)
        {
            if (Guid.Empty == entity.ID)
                entity.ID = Guid.NewGuid();

            var result = _serviceUtility.InsertData(entity);
            return new InsertDataResult { ID = entity.ID };
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void UpdateHoteliRooms(string id, Hoteli.Rooms entity)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            if (Guid.Empty == entity.ID)
                entity.ID = guid;
            if (guid != entity.ID)
                throw new Rhetos.LegacyClientException("Given entity ID is not equal to resource ID from URI.");

            _serviceUtility.UpdateData(entity);
        }

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void DeleteHoteliRooms(string id)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            var entity = new Hoteli.Rooms { ID = guid };

            _serviceUtility.DeleteData(entity);
        }

/*DataStructureInfo AdditionalOperations Hoteli.Rooms*/
    }
    
    [System.ServiceModel.ServiceContract]
    [System.ServiceModel.Activation.AspNetCompatibilityRequirements(RequirementsMode = System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestServiceHoteliPerson
    {
        private ServiceUtility _serviceUtility;
        /*DataStructureInfo AdditionalPropertyInitialization Hoteli.Person*/

        public RestServiceHoteliPerson(ServiceUtility serviceUtility/*DataStructureInfo AdditionalPropertyConstructorParameter Hoteli.Person*/)
        {
            _serviceUtility = serviceUtility;
            /*DataStructureInfo AdditionalPropertyConstructorSetProperties Hoteli.Person*/
        }
    
        public static readonly IDictionary<string, Type[]> FilterTypes = new List<Tuple<string, Type>>
            {
                Tuple.Create("Hoteli.SystemRequiredCode", typeof(Hoteli.SystemRequiredCode)),
                Tuple.Create("SystemRequiredCode", typeof(Hoteli.SystemRequiredCode)),
                /*DataStructureInfo FilterTypes Hoteli.Person*/
            }
            .GroupBy(typeName => typeName.Item1)
            .ToDictionary(g => g.Key, g => g.Select(typeName => typeName.Item2).Distinct().ToArray());

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsResult<Hoteli.Person> Get(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            var data = _serviceUtility.GetData<Hoteli.Person>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: false);
            return new RecordsResult<Hoteli.Person> { Records = data.Records };
        }

        [Obsolete]
        [OperationContract]
        [WebGet(UriTemplate = "/Count?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public CountResult GetCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Hoteli.Person>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new CountResult { TotalRecords = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters).
        [OperationContract]
        [WebGet(UriTemplate = "/TotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public TotalCountResult GetTotalCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Hoteli.Person>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new TotalCountResult { TotalCount = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/RecordsAndTotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsAndTotalCountResult<Hoteli.Person> GetRecordsAndTotalCount(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            return _serviceUtility.GetData<Hoteli.Person>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: true);
        }

        [OperationContract]
        [WebGet(UriTemplate = "/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Hoteli.Person GetById(string id)
        {
            var result = _serviceUtility.GetDataById<Hoteli.Person>(id);
            if (result == null)
                throw new Rhetos.LegacyClientException("There is no resource of this type with a given ID.") { HttpStatusCode = HttpStatusCode.NotFound, Severe = false };
            return result;
        }

        
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public InsertDataResult InsertHoteliPerson(Hoteli.Person entity)
        {
            if (Guid.Empty == entity.ID)
                entity.ID = Guid.NewGuid();

            var result = _serviceUtility.InsertData(entity);
            return new InsertDataResult { ID = entity.ID };
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void UpdateHoteliPerson(string id, Hoteli.Person entity)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            if (Guid.Empty == entity.ID)
                entity.ID = guid;
            if (guid != entity.ID)
                throw new Rhetos.LegacyClientException("Given entity ID is not equal to resource ID from URI.");

            _serviceUtility.UpdateData(entity);
        }

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void DeleteHoteliPerson(string id)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            var entity = new Hoteli.Person { ID = guid };

            _serviceUtility.DeleteData(entity);
        }

/*DataStructureInfo AdditionalOperations Hoteli.Person*/
    }
    
    [System.ServiceModel.ServiceContract]
    [System.ServiceModel.Activation.AspNetCompatibilityRequirements(RequirementsMode = System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestServiceHoteliSaloonPerson
    {
        private ServiceUtility _serviceUtility;
        /*DataStructureInfo AdditionalPropertyInitialization Hoteli.SaloonPerson*/

        public RestServiceHoteliSaloonPerson(ServiceUtility serviceUtility/*DataStructureInfo AdditionalPropertyConstructorParameter Hoteli.SaloonPerson*/)
        {
            _serviceUtility = serviceUtility;
            /*DataStructureInfo AdditionalPropertyConstructorSetProperties Hoteli.SaloonPerson*/
        }
    
        public static readonly IDictionary<string, Type[]> FilterTypes = new List<Tuple<string, Type>>
            {
                Tuple.Create("Hoteli.SystemRequiredCode", typeof(Hoteli.SystemRequiredCode)),
                Tuple.Create("SystemRequiredCode", typeof(Hoteli.SystemRequiredCode)),
                /*DataStructureInfo FilterTypes Hoteli.SaloonPerson*/
            }
            .GroupBy(typeName => typeName.Item1)
            .ToDictionary(g => g.Key, g => g.Select(typeName => typeName.Item2).Distinct().ToArray());

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsResult<Hoteli.SaloonPerson> Get(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            var data = _serviceUtility.GetData<Hoteli.SaloonPerson>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: false);
            return new RecordsResult<Hoteli.SaloonPerson> { Records = data.Records };
        }

        [Obsolete]
        [OperationContract]
        [WebGet(UriTemplate = "/Count?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public CountResult GetCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Hoteli.SaloonPerson>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new CountResult { TotalRecords = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters).
        [OperationContract]
        [WebGet(UriTemplate = "/TotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public TotalCountResult GetTotalCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Hoteli.SaloonPerson>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new TotalCountResult { TotalCount = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/RecordsAndTotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsAndTotalCountResult<Hoteli.SaloonPerson> GetRecordsAndTotalCount(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            return _serviceUtility.GetData<Hoteli.SaloonPerson>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: true);
        }

        [OperationContract]
        [WebGet(UriTemplate = "/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Hoteli.SaloonPerson GetById(string id)
        {
            var result = _serviceUtility.GetDataById<Hoteli.SaloonPerson>(id);
            if (result == null)
                throw new Rhetos.LegacyClientException("There is no resource of this type with a given ID.") { HttpStatusCode = HttpStatusCode.NotFound, Severe = false };
            return result;
        }

        
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public InsertDataResult InsertHoteliSaloonPerson(Hoteli.SaloonPerson entity)
        {
            if (Guid.Empty == entity.ID)
                entity.ID = Guid.NewGuid();

            var result = _serviceUtility.InsertData(entity);
            return new InsertDataResult { ID = entity.ID };
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void UpdateHoteliSaloonPerson(string id, Hoteli.SaloonPerson entity)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            if (Guid.Empty == entity.ID)
                entity.ID = guid;
            if (guid != entity.ID)
                throw new Rhetos.LegacyClientException("Given entity ID is not equal to resource ID from URI.");

            _serviceUtility.UpdateData(entity);
        }

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void DeleteHoteliSaloonPerson(string id)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            var entity = new Hoteli.SaloonPerson { ID = guid };

            _serviceUtility.DeleteData(entity);
        }

/*DataStructureInfo AdditionalOperations Hoteli.SaloonPerson*/
    }
    
    [System.ServiceModel.ServiceContract]
    [System.ServiceModel.Activation.AspNetCompatibilityRequirements(RequirementsMode = System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestServiceHoteliSaloonHotel
    {
        private ServiceUtility _serviceUtility;
        /*DataStructureInfo AdditionalPropertyInitialization Hoteli.SaloonHotel*/

        public RestServiceHoteliSaloonHotel(ServiceUtility serviceUtility/*DataStructureInfo AdditionalPropertyConstructorParameter Hoteli.SaloonHotel*/)
        {
            _serviceUtility = serviceUtility;
            /*DataStructureInfo AdditionalPropertyConstructorSetProperties Hoteli.SaloonHotel*/
        }
    
        public static readonly IDictionary<string, Type[]> FilterTypes = new List<Tuple<string, Type>>
            {
                Tuple.Create("Hoteli.SystemRequiredCode", typeof(Hoteli.SystemRequiredCode)),
                Tuple.Create("SystemRequiredCode", typeof(Hoteli.SystemRequiredCode)),
                /*DataStructureInfo FilterTypes Hoteli.SaloonHotel*/
            }
            .GroupBy(typeName => typeName.Item1)
            .ToDictionary(g => g.Key, g => g.Select(typeName => typeName.Item2).Distinct().ToArray());

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsResult<Hoteli.SaloonHotel> Get(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            var data = _serviceUtility.GetData<Hoteli.SaloonHotel>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: false);
            return new RecordsResult<Hoteli.SaloonHotel> { Records = data.Records };
        }

        [Obsolete]
        [OperationContract]
        [WebGet(UriTemplate = "/Count?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public CountResult GetCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Hoteli.SaloonHotel>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new CountResult { TotalRecords = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters).
        [OperationContract]
        [WebGet(UriTemplate = "/TotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public TotalCountResult GetTotalCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Hoteli.SaloonHotel>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new TotalCountResult { TotalCount = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/RecordsAndTotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsAndTotalCountResult<Hoteli.SaloonHotel> GetRecordsAndTotalCount(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            return _serviceUtility.GetData<Hoteli.SaloonHotel>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: true);
        }

        [OperationContract]
        [WebGet(UriTemplate = "/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Hoteli.SaloonHotel GetById(string id)
        {
            var result = _serviceUtility.GetDataById<Hoteli.SaloonHotel>(id);
            if (result == null)
                throw new Rhetos.LegacyClientException("There is no resource of this type with a given ID.") { HttpStatusCode = HttpStatusCode.NotFound, Severe = false };
            return result;
        }

        
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public InsertDataResult InsertHoteliSaloonHotel(Hoteli.SaloonHotel entity)
        {
            if (Guid.Empty == entity.ID)
                entity.ID = Guid.NewGuid();

            var result = _serviceUtility.InsertData(entity);
            return new InsertDataResult { ID = entity.ID };
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void UpdateHoteliSaloonHotel(string id, Hoteli.SaloonHotel entity)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            if (Guid.Empty == entity.ID)
                entity.ID = guid;
            if (guid != entity.ID)
                throw new Rhetos.LegacyClientException("Given entity ID is not equal to resource ID from URI.");

            _serviceUtility.UpdateData(entity);
        }

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void DeleteHoteliSaloonHotel(string id)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            var entity = new Hoteli.SaloonHotel { ID = guid };

            _serviceUtility.DeleteData(entity);
        }

/*DataStructureInfo AdditionalOperations Hoteli.SaloonHotel*/
    }
    
    [System.ServiceModel.ServiceContract]
    [System.ServiceModel.Activation.AspNetCompatibilityRequirements(RequirementsMode = System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestServiceHoteliSaloon
    {
        private ServiceUtility _serviceUtility;
        /*DataStructureInfo AdditionalPropertyInitialization Hoteli.Saloon*/

        public RestServiceHoteliSaloon(ServiceUtility serviceUtility/*DataStructureInfo AdditionalPropertyConstructorParameter Hoteli.Saloon*/)
        {
            _serviceUtility = serviceUtility;
            /*DataStructureInfo AdditionalPropertyConstructorSetProperties Hoteli.Saloon*/
        }
    
        public static readonly IDictionary<string, Type[]> FilterTypes = new List<Tuple<string, Type>>
            {
                Tuple.Create("Hoteli.SystemRequiredCode", typeof(Hoteli.SystemRequiredCode)),
                Tuple.Create("SystemRequiredCode", typeof(Hoteli.SystemRequiredCode)),
                /*DataStructureInfo FilterTypes Hoteli.Saloon*/
            }
            .GroupBy(typeName => typeName.Item1)
            .ToDictionary(g => g.Key, g => g.Select(typeName => typeName.Item2).Distinct().ToArray());

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsResult<Hoteli.Saloon> Get(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            var data = _serviceUtility.GetData<Hoteli.Saloon>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: false);
            return new RecordsResult<Hoteli.Saloon> { Records = data.Records };
        }

        [Obsolete]
        [OperationContract]
        [WebGet(UriTemplate = "/Count?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public CountResult GetCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Hoteli.Saloon>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new CountResult { TotalRecords = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters).
        [OperationContract]
        [WebGet(UriTemplate = "/TotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public TotalCountResult GetTotalCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Hoteli.Saloon>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new TotalCountResult { TotalCount = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/RecordsAndTotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsAndTotalCountResult<Hoteli.Saloon> GetRecordsAndTotalCount(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            return _serviceUtility.GetData<Hoteli.Saloon>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: true);
        }

        [OperationContract]
        [WebGet(UriTemplate = "/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Hoteli.Saloon GetById(string id)
        {
            var result = _serviceUtility.GetDataById<Hoteli.Saloon>(id);
            if (result == null)
                throw new Rhetos.LegacyClientException("There is no resource of this type with a given ID.") { HttpStatusCode = HttpStatusCode.NotFound, Severe = false };
            return result;
        }

        
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public InsertDataResult InsertHoteliSaloon(Hoteli.Saloon entity)
        {
            if (Guid.Empty == entity.ID)
                entity.ID = Guid.NewGuid();

            var result = _serviceUtility.InsertData(entity);
            return new InsertDataResult { ID = entity.ID };
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void UpdateHoteliSaloon(string id, Hoteli.Saloon entity)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            if (Guid.Empty == entity.ID)
                entity.ID = guid;
            if (guid != entity.ID)
                throw new Rhetos.LegacyClientException("Given entity ID is not equal to resource ID from URI.");

            _serviceUtility.UpdateData(entity);
        }

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void DeleteHoteliSaloon(string id)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            var entity = new Hoteli.Saloon { ID = guid };

            _serviceUtility.DeleteData(entity);
        }

/*DataStructureInfo AdditionalOperations Hoteli.Saloon*/
    }
    
    [System.ServiceModel.ServiceContract]
    [System.ServiceModel.Activation.AspNetCompatibilityRequirements(RequirementsMode = System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestServiceHoteliProductPerson
    {
        private ServiceUtility _serviceUtility;
        /*DataStructureInfo AdditionalPropertyInitialization Hoteli.ProductPerson*/

        public RestServiceHoteliProductPerson(ServiceUtility serviceUtility/*DataStructureInfo AdditionalPropertyConstructorParameter Hoteli.ProductPerson*/)
        {
            _serviceUtility = serviceUtility;
            /*DataStructureInfo AdditionalPropertyConstructorSetProperties Hoteli.ProductPerson*/
        }
    
        public static readonly IDictionary<string, Type[]> FilterTypes = new List<Tuple<string, Type>>
            {
                Tuple.Create("Hoteli.SystemRequiredCode", typeof(Hoteli.SystemRequiredCode)),
                Tuple.Create("SystemRequiredCode", typeof(Hoteli.SystemRequiredCode)),
                /*DataStructureInfo FilterTypes Hoteli.ProductPerson*/
            }
            .GroupBy(typeName => typeName.Item1)
            .ToDictionary(g => g.Key, g => g.Select(typeName => typeName.Item2).Distinct().ToArray());

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsResult<Hoteli.ProductPerson> Get(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            var data = _serviceUtility.GetData<Hoteli.ProductPerson>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: false);
            return new RecordsResult<Hoteli.ProductPerson> { Records = data.Records };
        }

        [Obsolete]
        [OperationContract]
        [WebGet(UriTemplate = "/Count?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public CountResult GetCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Hoteli.ProductPerson>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new CountResult { TotalRecords = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters).
        [OperationContract]
        [WebGet(UriTemplate = "/TotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public TotalCountResult GetTotalCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Hoteli.ProductPerson>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new TotalCountResult { TotalCount = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/RecordsAndTotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsAndTotalCountResult<Hoteli.ProductPerson> GetRecordsAndTotalCount(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            return _serviceUtility.GetData<Hoteli.ProductPerson>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: true);
        }

        [OperationContract]
        [WebGet(UriTemplate = "/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Hoteli.ProductPerson GetById(string id)
        {
            var result = _serviceUtility.GetDataById<Hoteli.ProductPerson>(id);
            if (result == null)
                throw new Rhetos.LegacyClientException("There is no resource of this type with a given ID.") { HttpStatusCode = HttpStatusCode.NotFound, Severe = false };
            return result;
        }

        
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public InsertDataResult InsertHoteliProductPerson(Hoteli.ProductPerson entity)
        {
            if (Guid.Empty == entity.ID)
                entity.ID = Guid.NewGuid();

            var result = _serviceUtility.InsertData(entity);
            return new InsertDataResult { ID = entity.ID };
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void UpdateHoteliProductPerson(string id, Hoteli.ProductPerson entity)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            if (Guid.Empty == entity.ID)
                entity.ID = guid;
            if (guid != entity.ID)
                throw new Rhetos.LegacyClientException("Given entity ID is not equal to resource ID from URI.");

            _serviceUtility.UpdateData(entity);
        }

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void DeleteHoteliProductPerson(string id)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            var entity = new Hoteli.ProductPerson { ID = guid };

            _serviceUtility.DeleteData(entity);
        }

/*DataStructureInfo AdditionalOperations Hoteli.ProductPerson*/
    }
    
    [System.ServiceModel.ServiceContract]
    [System.ServiceModel.Activation.AspNetCompatibilityRequirements(RequirementsMode = System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestServiceHoteliProductHotel
    {
        private ServiceUtility _serviceUtility;
        /*DataStructureInfo AdditionalPropertyInitialization Hoteli.ProductHotel*/

        public RestServiceHoteliProductHotel(ServiceUtility serviceUtility/*DataStructureInfo AdditionalPropertyConstructorParameter Hoteli.ProductHotel*/)
        {
            _serviceUtility = serviceUtility;
            /*DataStructureInfo AdditionalPropertyConstructorSetProperties Hoteli.ProductHotel*/
        }
    
        public static readonly IDictionary<string, Type[]> FilterTypes = new List<Tuple<string, Type>>
            {
                Tuple.Create("Hoteli.SystemRequiredCode", typeof(Hoteli.SystemRequiredCode)),
                Tuple.Create("SystemRequiredCode", typeof(Hoteli.SystemRequiredCode)),
                /*DataStructureInfo FilterTypes Hoteli.ProductHotel*/
            }
            .GroupBy(typeName => typeName.Item1)
            .ToDictionary(g => g.Key, g => g.Select(typeName => typeName.Item2).Distinct().ToArray());

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsResult<Hoteli.ProductHotel> Get(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            var data = _serviceUtility.GetData<Hoteli.ProductHotel>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: false);
            return new RecordsResult<Hoteli.ProductHotel> { Records = data.Records };
        }

        [Obsolete]
        [OperationContract]
        [WebGet(UriTemplate = "/Count?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public CountResult GetCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Hoteli.ProductHotel>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new CountResult { TotalRecords = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters).
        [OperationContract]
        [WebGet(UriTemplate = "/TotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public TotalCountResult GetTotalCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Hoteli.ProductHotel>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new TotalCountResult { TotalCount = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/RecordsAndTotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsAndTotalCountResult<Hoteli.ProductHotel> GetRecordsAndTotalCount(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            return _serviceUtility.GetData<Hoteli.ProductHotel>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: true);
        }

        [OperationContract]
        [WebGet(UriTemplate = "/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Hoteli.ProductHotel GetById(string id)
        {
            var result = _serviceUtility.GetDataById<Hoteli.ProductHotel>(id);
            if (result == null)
                throw new Rhetos.LegacyClientException("There is no resource of this type with a given ID.") { HttpStatusCode = HttpStatusCode.NotFound, Severe = false };
            return result;
        }

        
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public InsertDataResult InsertHoteliProductHotel(Hoteli.ProductHotel entity)
        {
            if (Guid.Empty == entity.ID)
                entity.ID = Guid.NewGuid();

            var result = _serviceUtility.InsertData(entity);
            return new InsertDataResult { ID = entity.ID };
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void UpdateHoteliProductHotel(string id, Hoteli.ProductHotel entity)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            if (Guid.Empty == entity.ID)
                entity.ID = guid;
            if (guid != entity.ID)
                throw new Rhetos.LegacyClientException("Given entity ID is not equal to resource ID from URI.");

            _serviceUtility.UpdateData(entity);
        }

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void DeleteHoteliProductHotel(string id)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            var entity = new Hoteli.ProductHotel { ID = guid };

            _serviceUtility.DeleteData(entity);
        }

/*DataStructureInfo AdditionalOperations Hoteli.ProductHotel*/
    }
    
    [System.ServiceModel.ServiceContract]
    [System.ServiceModel.Activation.AspNetCompatibilityRequirements(RequirementsMode = System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestServiceHoteliProduct
    {
        private ServiceUtility _serviceUtility;
        /*DataStructureInfo AdditionalPropertyInitialization Hoteli.Product*/

        public RestServiceHoteliProduct(ServiceUtility serviceUtility/*DataStructureInfo AdditionalPropertyConstructorParameter Hoteli.Product*/)
        {
            _serviceUtility = serviceUtility;
            /*DataStructureInfo AdditionalPropertyConstructorSetProperties Hoteli.Product*/
        }
    
        public static readonly IDictionary<string, Type[]> FilterTypes = new List<Tuple<string, Type>>
            {
                Tuple.Create("Hoteli.SystemRequiredCode", typeof(Hoteli.SystemRequiredCode)),
                Tuple.Create("SystemRequiredCode", typeof(Hoteli.SystemRequiredCode)),
                /*DataStructureInfo FilterTypes Hoteli.Product*/
            }
            .GroupBy(typeName => typeName.Item1)
            .ToDictionary(g => g.Key, g => g.Select(typeName => typeName.Item2).Distinct().ToArray());

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsResult<Hoteli.Product> Get(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            var data = _serviceUtility.GetData<Hoteli.Product>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: false);
            return new RecordsResult<Hoteli.Product> { Records = data.Records };
        }

        [Obsolete]
        [OperationContract]
        [WebGet(UriTemplate = "/Count?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public CountResult GetCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Hoteli.Product>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new CountResult { TotalRecords = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters).
        [OperationContract]
        [WebGet(UriTemplate = "/TotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public TotalCountResult GetTotalCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Hoteli.Product>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new TotalCountResult { TotalCount = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/RecordsAndTotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsAndTotalCountResult<Hoteli.Product> GetRecordsAndTotalCount(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            return _serviceUtility.GetData<Hoteli.Product>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: true);
        }

        [OperationContract]
        [WebGet(UriTemplate = "/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Hoteli.Product GetById(string id)
        {
            var result = _serviceUtility.GetDataById<Hoteli.Product>(id);
            if (result == null)
                throw new Rhetos.LegacyClientException("There is no resource of this type with a given ID.") { HttpStatusCode = HttpStatusCode.NotFound, Severe = false };
            return result;
        }

        
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public InsertDataResult InsertHoteliProduct(Hoteli.Product entity)
        {
            if (Guid.Empty == entity.ID)
                entity.ID = Guid.NewGuid();

            var result = _serviceUtility.InsertData(entity);
            return new InsertDataResult { ID = entity.ID };
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void UpdateHoteliProduct(string id, Hoteli.Product entity)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            if (Guid.Empty == entity.ID)
                entity.ID = guid;
            if (guid != entity.ID)
                throw new Rhetos.LegacyClientException("Given entity ID is not equal to resource ID from URI.");

            _serviceUtility.UpdateData(entity);
        }

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void DeleteHoteliProduct(string id)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            var entity = new Hoteli.Product { ID = guid };

            _serviceUtility.DeleteData(entity);
        }

/*DataStructureInfo AdditionalOperations Hoteli.Product*/
    }
    
    [System.ServiceModel.ServiceContract]
    [System.ServiceModel.Activation.AspNetCompatibilityRequirements(RequirementsMode = System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestServiceHoteliInsert5Hotels
    {
        private ServiceUtility _serviceUtility;

        public RestServiceHoteliInsert5Hotels(ServiceUtility serviceUtility) 
        {
            _serviceUtility = serviceUtility;
        }

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void ExecuteHoteliInsert5Hotels(Hoteli.Insert5Hotels action)
        {
            _serviceUtility.Execute<Hoteli.Insert5Hotels>(action);
        }
    }


    [System.ServiceModel.ServiceContract]
    [System.ServiceModel.Activation.AspNetCompatibilityRequirements(RequirementsMode = System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestServiceHoteliInsert5Rooms
    {
        private ServiceUtility _serviceUtility;

        public RestServiceHoteliInsert5Rooms(ServiceUtility serviceUtility) 
        {
            _serviceUtility = serviceUtility;
        }

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void ExecuteHoteliInsert5Rooms(Hoteli.Insert5Rooms action)
        {
            _serviceUtility.Execute<Hoteli.Insert5Rooms>(action);
        }
    }


    [System.ServiceModel.ServiceContract]
    [System.ServiceModel.Activation.AspNetCompatibilityRequirements(RequirementsMode = System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestServiceHoteliInsert6Rooms
    {
        private ServiceUtility _serviceUtility;

        public RestServiceHoteliInsert6Rooms(ServiceUtility serviceUtility) 
        {
            _serviceUtility = serviceUtility;
        }

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void ExecuteHoteliInsert6Rooms(Hoteli.Insert6Rooms action)
        {
            _serviceUtility.Execute<Hoteli.Insert6Rooms>(action);
        }
    }


    [System.ServiceModel.ServiceContract]
    [System.ServiceModel.Activation.AspNetCompatibilityRequirements(RequirementsMode = System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestServiceHoteliReservationInfo
    {
        private ServiceUtility _serviceUtility;
        /*DataStructureInfo AdditionalPropertyInitialization Hoteli.ReservationInfo*/

        public RestServiceHoteliReservationInfo(ServiceUtility serviceUtility/*DataStructureInfo AdditionalPropertyConstructorParameter Hoteli.ReservationInfo*/)
        {
            _serviceUtility = serviceUtility;
            /*DataStructureInfo AdditionalPropertyConstructorSetProperties Hoteli.ReservationInfo*/
        }
    
        public static readonly IDictionary<string, Type[]> FilterTypes = new List<Tuple<string, Type>>
            {
                /*DataStructureInfo FilterTypes Hoteli.ReservationInfo*/
            }
            .GroupBy(typeName => typeName.Item1)
            .ToDictionary(g => g.Key, g => g.Select(typeName => typeName.Item2).Distinct().ToArray());

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsResult<Hoteli.ReservationInfo> Get(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            var data = _serviceUtility.GetData<Hoteli.ReservationInfo>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: false);
            return new RecordsResult<Hoteli.ReservationInfo> { Records = data.Records };
        }

        [Obsolete]
        [OperationContract]
        [WebGet(UriTemplate = "/Count?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public CountResult GetCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Hoteli.ReservationInfo>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new CountResult { TotalRecords = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters).
        [OperationContract]
        [WebGet(UriTemplate = "/TotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public TotalCountResult GetTotalCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Hoteli.ReservationInfo>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new TotalCountResult { TotalCount = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/RecordsAndTotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsAndTotalCountResult<Hoteli.ReservationInfo> GetRecordsAndTotalCount(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            return _serviceUtility.GetData<Hoteli.ReservationInfo>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: true);
        }

        [OperationContract]
        [WebGet(UriTemplate = "/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Hoteli.ReservationInfo GetById(string id)
        {
            var result = _serviceUtility.GetDataById<Hoteli.ReservationInfo>(id);
            if (result == null)
                throw new Rhetos.LegacyClientException("There is no resource of this type with a given ID.") { HttpStatusCode = HttpStatusCode.NotFound, Severe = false };
            return result;
        }

        /*DataStructureInfo AdditionalOperations Hoteli.ReservationInfo*/
    }
    
    [System.ServiceModel.ServiceContract]
    [System.ServiceModel.Activation.AspNetCompatibilityRequirements(RequirementsMode = System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestServiceCommonAutoCodeCache
    {
        private ServiceUtility _serviceUtility;
        /*DataStructureInfo AdditionalPropertyInitialization Common.AutoCodeCache*/

        public RestServiceCommonAutoCodeCache(ServiceUtility serviceUtility/*DataStructureInfo AdditionalPropertyConstructorParameter Common.AutoCodeCache*/)
        {
            _serviceUtility = serviceUtility;
            /*DataStructureInfo AdditionalPropertyConstructorSetProperties Common.AutoCodeCache*/
        }
    
        public static readonly IDictionary<string, Type[]> FilterTypes = new List<Tuple<string, Type>>
            {
                /*DataStructureInfo FilterTypes Common.AutoCodeCache*/
            }
            .GroupBy(typeName => typeName.Item1)
            .ToDictionary(g => g.Key, g => g.Select(typeName => typeName.Item2).Distinct().ToArray());

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsResult<Common.AutoCodeCache> Get(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            var data = _serviceUtility.GetData<Common.AutoCodeCache>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: false);
            return new RecordsResult<Common.AutoCodeCache> { Records = data.Records };
        }

        [Obsolete]
        [OperationContract]
        [WebGet(UriTemplate = "/Count?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public CountResult GetCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Common.AutoCodeCache>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new CountResult { TotalRecords = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters).
        [OperationContract]
        [WebGet(UriTemplate = "/TotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public TotalCountResult GetTotalCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Common.AutoCodeCache>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new TotalCountResult { TotalCount = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/RecordsAndTotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsAndTotalCountResult<Common.AutoCodeCache> GetRecordsAndTotalCount(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            return _serviceUtility.GetData<Common.AutoCodeCache>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: true);
        }

        [OperationContract]
        [WebGet(UriTemplate = "/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Common.AutoCodeCache GetById(string id)
        {
            var result = _serviceUtility.GetDataById<Common.AutoCodeCache>(id);
            if (result == null)
                throw new Rhetos.LegacyClientException("There is no resource of this type with a given ID.") { HttpStatusCode = HttpStatusCode.NotFound, Severe = false };
            return result;
        }

        
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public InsertDataResult InsertCommonAutoCodeCache(Common.AutoCodeCache entity)
        {
            if (Guid.Empty == entity.ID)
                entity.ID = Guid.NewGuid();

            var result = _serviceUtility.InsertData(entity);
            return new InsertDataResult { ID = entity.ID };
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void UpdateCommonAutoCodeCache(string id, Common.AutoCodeCache entity)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            if (Guid.Empty == entity.ID)
                entity.ID = guid;
            if (guid != entity.ID)
                throw new Rhetos.LegacyClientException("Given entity ID is not equal to resource ID from URI.");

            _serviceUtility.UpdateData(entity);
        }

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void DeleteCommonAutoCodeCache(string id)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            var entity = new Common.AutoCodeCache { ID = guid };

            _serviceUtility.DeleteData(entity);
        }

/*DataStructureInfo AdditionalOperations Common.AutoCodeCache*/
    }
    
    [System.ServiceModel.ServiceContract]
    [System.ServiceModel.Activation.AspNetCompatibilityRequirements(RequirementsMode = System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestServiceCommonFilterId
    {
        private ServiceUtility _serviceUtility;
        /*DataStructureInfo AdditionalPropertyInitialization Common.FilterId*/

        public RestServiceCommonFilterId(ServiceUtility serviceUtility/*DataStructureInfo AdditionalPropertyConstructorParameter Common.FilterId*/)
        {
            _serviceUtility = serviceUtility;
            /*DataStructureInfo AdditionalPropertyConstructorSetProperties Common.FilterId*/
        }
    
        public static readonly IDictionary<string, Type[]> FilterTypes = new List<Tuple<string, Type>>
            {
                /*DataStructureInfo FilterTypes Common.FilterId*/
            }
            .GroupBy(typeName => typeName.Item1)
            .ToDictionary(g => g.Key, g => g.Select(typeName => typeName.Item2).Distinct().ToArray());

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsResult<Common.FilterId> Get(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            var data = _serviceUtility.GetData<Common.FilterId>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: false);
            return new RecordsResult<Common.FilterId> { Records = data.Records };
        }

        [Obsolete]
        [OperationContract]
        [WebGet(UriTemplate = "/Count?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public CountResult GetCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Common.FilterId>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new CountResult { TotalRecords = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters).
        [OperationContract]
        [WebGet(UriTemplate = "/TotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public TotalCountResult GetTotalCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Common.FilterId>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new TotalCountResult { TotalCount = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/RecordsAndTotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsAndTotalCountResult<Common.FilterId> GetRecordsAndTotalCount(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            return _serviceUtility.GetData<Common.FilterId>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: true);
        }

        [OperationContract]
        [WebGet(UriTemplate = "/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Common.FilterId GetById(string id)
        {
            var result = _serviceUtility.GetDataById<Common.FilterId>(id);
            if (result == null)
                throw new Rhetos.LegacyClientException("There is no resource of this type with a given ID.") { HttpStatusCode = HttpStatusCode.NotFound, Severe = false };
            return result;
        }

        
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public InsertDataResult InsertCommonFilterId(Common.FilterId entity)
        {
            if (Guid.Empty == entity.ID)
                entity.ID = Guid.NewGuid();

            var result = _serviceUtility.InsertData(entity);
            return new InsertDataResult { ID = entity.ID };
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void UpdateCommonFilterId(string id, Common.FilterId entity)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            if (Guid.Empty == entity.ID)
                entity.ID = guid;
            if (guid != entity.ID)
                throw new Rhetos.LegacyClientException("Given entity ID is not equal to resource ID from URI.");

            _serviceUtility.UpdateData(entity);
        }

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void DeleteCommonFilterId(string id)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            var entity = new Common.FilterId { ID = guid };

            _serviceUtility.DeleteData(entity);
        }

/*DataStructureInfo AdditionalOperations Common.FilterId*/
    }
    
    [System.ServiceModel.ServiceContract]
    [System.ServiceModel.Activation.AspNetCompatibilityRequirements(RequirementsMode = System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestServiceCommonKeepSynchronizedMetadata
    {
        private ServiceUtility _serviceUtility;
        /*DataStructureInfo AdditionalPropertyInitialization Common.KeepSynchronizedMetadata*/

        public RestServiceCommonKeepSynchronizedMetadata(ServiceUtility serviceUtility/*DataStructureInfo AdditionalPropertyConstructorParameter Common.KeepSynchronizedMetadata*/)
        {
            _serviceUtility = serviceUtility;
            /*DataStructureInfo AdditionalPropertyConstructorSetProperties Common.KeepSynchronizedMetadata*/
        }
    
        public static readonly IDictionary<string, Type[]> FilterTypes = new List<Tuple<string, Type>>
            {
                /*DataStructureInfo FilterTypes Common.KeepSynchronizedMetadata*/
            }
            .GroupBy(typeName => typeName.Item1)
            .ToDictionary(g => g.Key, g => g.Select(typeName => typeName.Item2).Distinct().ToArray());

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsResult<Common.KeepSynchronizedMetadata> Get(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            var data = _serviceUtility.GetData<Common.KeepSynchronizedMetadata>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: false);
            return new RecordsResult<Common.KeepSynchronizedMetadata> { Records = data.Records };
        }

        [Obsolete]
        [OperationContract]
        [WebGet(UriTemplate = "/Count?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public CountResult GetCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Common.KeepSynchronizedMetadata>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new CountResult { TotalRecords = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters).
        [OperationContract]
        [WebGet(UriTemplate = "/TotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public TotalCountResult GetTotalCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Common.KeepSynchronizedMetadata>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new TotalCountResult { TotalCount = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/RecordsAndTotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsAndTotalCountResult<Common.KeepSynchronizedMetadata> GetRecordsAndTotalCount(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            return _serviceUtility.GetData<Common.KeepSynchronizedMetadata>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: true);
        }

        [OperationContract]
        [WebGet(UriTemplate = "/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Common.KeepSynchronizedMetadata GetById(string id)
        {
            var result = _serviceUtility.GetDataById<Common.KeepSynchronizedMetadata>(id);
            if (result == null)
                throw new Rhetos.LegacyClientException("There is no resource of this type with a given ID.") { HttpStatusCode = HttpStatusCode.NotFound, Severe = false };
            return result;
        }

        
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public InsertDataResult InsertCommonKeepSynchronizedMetadata(Common.KeepSynchronizedMetadata entity)
        {
            if (Guid.Empty == entity.ID)
                entity.ID = Guid.NewGuid();

            var result = _serviceUtility.InsertData(entity);
            return new InsertDataResult { ID = entity.ID };
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void UpdateCommonKeepSynchronizedMetadata(string id, Common.KeepSynchronizedMetadata entity)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            if (Guid.Empty == entity.ID)
                entity.ID = guid;
            if (guid != entity.ID)
                throw new Rhetos.LegacyClientException("Given entity ID is not equal to resource ID from URI.");

            _serviceUtility.UpdateData(entity);
        }

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void DeleteCommonKeepSynchronizedMetadata(string id)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            var entity = new Common.KeepSynchronizedMetadata { ID = guid };

            _serviceUtility.DeleteData(entity);
        }

/*DataStructureInfo AdditionalOperations Common.KeepSynchronizedMetadata*/
    }
    
    [System.ServiceModel.ServiceContract]
    [System.ServiceModel.Activation.AspNetCompatibilityRequirements(RequirementsMode = System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestServiceCommonExclusiveLock
    {
        private ServiceUtility _serviceUtility;
        /*DataStructureInfo AdditionalPropertyInitialization Common.ExclusiveLock*/

        public RestServiceCommonExclusiveLock(ServiceUtility serviceUtility/*DataStructureInfo AdditionalPropertyConstructorParameter Common.ExclusiveLock*/)
        {
            _serviceUtility = serviceUtility;
            /*DataStructureInfo AdditionalPropertyConstructorSetProperties Common.ExclusiveLock*/
        }
    
        public static readonly IDictionary<string, Type[]> FilterTypes = new List<Tuple<string, Type>>
            {
                /*DataStructureInfo FilterTypes Common.ExclusiveLock*/
            }
            .GroupBy(typeName => typeName.Item1)
            .ToDictionary(g => g.Key, g => g.Select(typeName => typeName.Item2).Distinct().ToArray());

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsResult<Common.ExclusiveLock> Get(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            var data = _serviceUtility.GetData<Common.ExclusiveLock>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: false);
            return new RecordsResult<Common.ExclusiveLock> { Records = data.Records };
        }

        [Obsolete]
        [OperationContract]
        [WebGet(UriTemplate = "/Count?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public CountResult GetCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Common.ExclusiveLock>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new CountResult { TotalRecords = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters).
        [OperationContract]
        [WebGet(UriTemplate = "/TotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public TotalCountResult GetTotalCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Common.ExclusiveLock>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new TotalCountResult { TotalCount = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/RecordsAndTotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsAndTotalCountResult<Common.ExclusiveLock> GetRecordsAndTotalCount(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            return _serviceUtility.GetData<Common.ExclusiveLock>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: true);
        }

        [OperationContract]
        [WebGet(UriTemplate = "/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Common.ExclusiveLock GetById(string id)
        {
            var result = _serviceUtility.GetDataById<Common.ExclusiveLock>(id);
            if (result == null)
                throw new Rhetos.LegacyClientException("There is no resource of this type with a given ID.") { HttpStatusCode = HttpStatusCode.NotFound, Severe = false };
            return result;
        }

        
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public InsertDataResult InsertCommonExclusiveLock(Common.ExclusiveLock entity)
        {
            if (Guid.Empty == entity.ID)
                entity.ID = Guid.NewGuid();

            var result = _serviceUtility.InsertData(entity);
            return new InsertDataResult { ID = entity.ID };
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void UpdateCommonExclusiveLock(string id, Common.ExclusiveLock entity)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            if (Guid.Empty == entity.ID)
                entity.ID = guid;
            if (guid != entity.ID)
                throw new Rhetos.LegacyClientException("Given entity ID is not equal to resource ID from URI.");

            _serviceUtility.UpdateData(entity);
        }

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void DeleteCommonExclusiveLock(string id)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            var entity = new Common.ExclusiveLock { ID = guid };

            _serviceUtility.DeleteData(entity);
        }

/*DataStructureInfo AdditionalOperations Common.ExclusiveLock*/
    }
    
    [System.ServiceModel.ServiceContract]
    [System.ServiceModel.Activation.AspNetCompatibilityRequirements(RequirementsMode = System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestServiceCommonSetLock
    {
        private ServiceUtility _serviceUtility;

        public RestServiceCommonSetLock(ServiceUtility serviceUtility) 
        {
            _serviceUtility = serviceUtility;
        }

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void ExecuteCommonSetLock(Common.SetLock action)
        {
            _serviceUtility.Execute<Common.SetLock>(action);
        }
    }


    [System.ServiceModel.ServiceContract]
    [System.ServiceModel.Activation.AspNetCompatibilityRequirements(RequirementsMode = System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestServiceCommonReleaseLock
    {
        private ServiceUtility _serviceUtility;

        public RestServiceCommonReleaseLock(ServiceUtility serviceUtility) 
        {
            _serviceUtility = serviceUtility;
        }

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void ExecuteCommonReleaseLock(Common.ReleaseLock action)
        {
            _serviceUtility.Execute<Common.ReleaseLock>(action);
        }
    }


    [System.ServiceModel.ServiceContract]
    [System.ServiceModel.Activation.AspNetCompatibilityRequirements(RequirementsMode = System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestServiceCommonLogReader
    {
        private ServiceUtility _serviceUtility;
        /*DataStructureInfo AdditionalPropertyInitialization Common.LogReader*/

        public RestServiceCommonLogReader(ServiceUtility serviceUtility/*DataStructureInfo AdditionalPropertyConstructorParameter Common.LogReader*/)
        {
            _serviceUtility = serviceUtility;
            /*DataStructureInfo AdditionalPropertyConstructorSetProperties Common.LogReader*/
        }
    
        public static readonly IDictionary<string, Type[]> FilterTypes = new List<Tuple<string, Type>>
            {
                /*DataStructureInfo FilterTypes Common.LogReader*/
            }
            .GroupBy(typeName => typeName.Item1)
            .ToDictionary(g => g.Key, g => g.Select(typeName => typeName.Item2).Distinct().ToArray());

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsResult<Common.LogReader> Get(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            var data = _serviceUtility.GetData<Common.LogReader>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: false);
            return new RecordsResult<Common.LogReader> { Records = data.Records };
        }

        [Obsolete]
        [OperationContract]
        [WebGet(UriTemplate = "/Count?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public CountResult GetCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Common.LogReader>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new CountResult { TotalRecords = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters).
        [OperationContract]
        [WebGet(UriTemplate = "/TotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public TotalCountResult GetTotalCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Common.LogReader>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new TotalCountResult { TotalCount = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/RecordsAndTotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsAndTotalCountResult<Common.LogReader> GetRecordsAndTotalCount(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            return _serviceUtility.GetData<Common.LogReader>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: true);
        }

        [OperationContract]
        [WebGet(UriTemplate = "/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Common.LogReader GetById(string id)
        {
            var result = _serviceUtility.GetDataById<Common.LogReader>(id);
            if (result == null)
                throw new Rhetos.LegacyClientException("There is no resource of this type with a given ID.") { HttpStatusCode = HttpStatusCode.NotFound, Severe = false };
            return result;
        }

        /*DataStructureInfo AdditionalOperations Common.LogReader*/
    }
    
    [System.ServiceModel.ServiceContract]
    [System.ServiceModel.Activation.AspNetCompatibilityRequirements(RequirementsMode = System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestServiceCommonLogRelatedItemReader
    {
        private ServiceUtility _serviceUtility;
        /*DataStructureInfo AdditionalPropertyInitialization Common.LogRelatedItemReader*/

        public RestServiceCommonLogRelatedItemReader(ServiceUtility serviceUtility/*DataStructureInfo AdditionalPropertyConstructorParameter Common.LogRelatedItemReader*/)
        {
            _serviceUtility = serviceUtility;
            /*DataStructureInfo AdditionalPropertyConstructorSetProperties Common.LogRelatedItemReader*/
        }
    
        public static readonly IDictionary<string, Type[]> FilterTypes = new List<Tuple<string, Type>>
            {
                /*DataStructureInfo FilterTypes Common.LogRelatedItemReader*/
            }
            .GroupBy(typeName => typeName.Item1)
            .ToDictionary(g => g.Key, g => g.Select(typeName => typeName.Item2).Distinct().ToArray());

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsResult<Common.LogRelatedItemReader> Get(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            var data = _serviceUtility.GetData<Common.LogRelatedItemReader>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: false);
            return new RecordsResult<Common.LogRelatedItemReader> { Records = data.Records };
        }

        [Obsolete]
        [OperationContract]
        [WebGet(UriTemplate = "/Count?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public CountResult GetCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Common.LogRelatedItemReader>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new CountResult { TotalRecords = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters).
        [OperationContract]
        [WebGet(UriTemplate = "/TotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public TotalCountResult GetTotalCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Common.LogRelatedItemReader>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new TotalCountResult { TotalCount = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/RecordsAndTotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsAndTotalCountResult<Common.LogRelatedItemReader> GetRecordsAndTotalCount(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            return _serviceUtility.GetData<Common.LogRelatedItemReader>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: true);
        }

        [OperationContract]
        [WebGet(UriTemplate = "/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Common.LogRelatedItemReader GetById(string id)
        {
            var result = _serviceUtility.GetDataById<Common.LogRelatedItemReader>(id);
            if (result == null)
                throw new Rhetos.LegacyClientException("There is no resource of this type with a given ID.") { HttpStatusCode = HttpStatusCode.NotFound, Severe = false };
            return result;
        }

        /*DataStructureInfo AdditionalOperations Common.LogRelatedItemReader*/
    }
    
    [System.ServiceModel.ServiceContract]
    [System.ServiceModel.Activation.AspNetCompatibilityRequirements(RequirementsMode = System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestServiceCommonLog
    {
        private ServiceUtility _serviceUtility;
        /*DataStructureInfo AdditionalPropertyInitialization Common.Log*/

        public RestServiceCommonLog(ServiceUtility serviceUtility/*DataStructureInfo AdditionalPropertyConstructorParameter Common.Log*/)
        {
            _serviceUtility = serviceUtility;
            /*DataStructureInfo AdditionalPropertyConstructorSetProperties Common.Log*/
        }
    
        public static readonly IDictionary<string, Type[]> FilterTypes = new List<Tuple<string, Type>>
            {
                /*DataStructureInfo FilterTypes Common.Log*/
            }
            .GroupBy(typeName => typeName.Item1)
            .ToDictionary(g => g.Key, g => g.Select(typeName => typeName.Item2).Distinct().ToArray());

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsResult<Common.Log> Get(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            var data = _serviceUtility.GetData<Common.Log>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: false);
            return new RecordsResult<Common.Log> { Records = data.Records };
        }

        [Obsolete]
        [OperationContract]
        [WebGet(UriTemplate = "/Count?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public CountResult GetCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Common.Log>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new CountResult { TotalRecords = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters).
        [OperationContract]
        [WebGet(UriTemplate = "/TotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public TotalCountResult GetTotalCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Common.Log>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new TotalCountResult { TotalCount = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/RecordsAndTotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsAndTotalCountResult<Common.Log> GetRecordsAndTotalCount(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            return _serviceUtility.GetData<Common.Log>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: true);
        }

        [OperationContract]
        [WebGet(UriTemplate = "/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Common.Log GetById(string id)
        {
            var result = _serviceUtility.GetDataById<Common.Log>(id);
            if (result == null)
                throw new Rhetos.LegacyClientException("There is no resource of this type with a given ID.") { HttpStatusCode = HttpStatusCode.NotFound, Severe = false };
            return result;
        }

        
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public InsertDataResult InsertCommonLog(Common.Log entity)
        {
            if (Guid.Empty == entity.ID)
                entity.ID = Guid.NewGuid();

            var result = _serviceUtility.InsertData(entity);
            return new InsertDataResult { ID = entity.ID };
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void UpdateCommonLog(string id, Common.Log entity)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            if (Guid.Empty == entity.ID)
                entity.ID = guid;
            if (guid != entity.ID)
                throw new Rhetos.LegacyClientException("Given entity ID is not equal to resource ID from URI.");

            _serviceUtility.UpdateData(entity);
        }

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void DeleteCommonLog(string id)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            var entity = new Common.Log { ID = guid };

            _serviceUtility.DeleteData(entity);
        }

/*DataStructureInfo AdditionalOperations Common.Log*/
    }
    
    [System.ServiceModel.ServiceContract]
    [System.ServiceModel.Activation.AspNetCompatibilityRequirements(RequirementsMode = System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestServiceCommonAddToLog
    {
        private ServiceUtility _serviceUtility;

        public RestServiceCommonAddToLog(ServiceUtility serviceUtility) 
        {
            _serviceUtility = serviceUtility;
        }

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void ExecuteCommonAddToLog(Common.AddToLog action)
        {
            _serviceUtility.Execute<Common.AddToLog>(action);
        }
    }


    [System.ServiceModel.ServiceContract]
    [System.ServiceModel.Activation.AspNetCompatibilityRequirements(RequirementsMode = System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestServiceCommonLogRelatedItem
    {
        private ServiceUtility _serviceUtility;
        /*DataStructureInfo AdditionalPropertyInitialization Common.LogRelatedItem*/

        public RestServiceCommonLogRelatedItem(ServiceUtility serviceUtility/*DataStructureInfo AdditionalPropertyConstructorParameter Common.LogRelatedItem*/)
        {
            _serviceUtility = serviceUtility;
            /*DataStructureInfo AdditionalPropertyConstructorSetProperties Common.LogRelatedItem*/
        }
    
        public static readonly IDictionary<string, Type[]> FilterTypes = new List<Tuple<string, Type>>
            {
                Tuple.Create("Common.SystemRequiredLog", typeof(Common.SystemRequiredLog)),
                Tuple.Create("SystemRequiredLog", typeof(Common.SystemRequiredLog)),
                /*DataStructureInfo FilterTypes Common.LogRelatedItem*/
            }
            .GroupBy(typeName => typeName.Item1)
            .ToDictionary(g => g.Key, g => g.Select(typeName => typeName.Item2).Distinct().ToArray());

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsResult<Common.LogRelatedItem> Get(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            var data = _serviceUtility.GetData<Common.LogRelatedItem>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: false);
            return new RecordsResult<Common.LogRelatedItem> { Records = data.Records };
        }

        [Obsolete]
        [OperationContract]
        [WebGet(UriTemplate = "/Count?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public CountResult GetCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Common.LogRelatedItem>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new CountResult { TotalRecords = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters).
        [OperationContract]
        [WebGet(UriTemplate = "/TotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public TotalCountResult GetTotalCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Common.LogRelatedItem>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new TotalCountResult { TotalCount = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/RecordsAndTotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsAndTotalCountResult<Common.LogRelatedItem> GetRecordsAndTotalCount(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            return _serviceUtility.GetData<Common.LogRelatedItem>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: true);
        }

        [OperationContract]
        [WebGet(UriTemplate = "/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Common.LogRelatedItem GetById(string id)
        {
            var result = _serviceUtility.GetDataById<Common.LogRelatedItem>(id);
            if (result == null)
                throw new Rhetos.LegacyClientException("There is no resource of this type with a given ID.") { HttpStatusCode = HttpStatusCode.NotFound, Severe = false };
            return result;
        }

        
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public InsertDataResult InsertCommonLogRelatedItem(Common.LogRelatedItem entity)
        {
            if (Guid.Empty == entity.ID)
                entity.ID = Guid.NewGuid();

            var result = _serviceUtility.InsertData(entity);
            return new InsertDataResult { ID = entity.ID };
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void UpdateCommonLogRelatedItem(string id, Common.LogRelatedItem entity)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            if (Guid.Empty == entity.ID)
                entity.ID = guid;
            if (guid != entity.ID)
                throw new Rhetos.LegacyClientException("Given entity ID is not equal to resource ID from URI.");

            _serviceUtility.UpdateData(entity);
        }

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void DeleteCommonLogRelatedItem(string id)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            var entity = new Common.LogRelatedItem { ID = guid };

            _serviceUtility.DeleteData(entity);
        }

/*DataStructureInfo AdditionalOperations Common.LogRelatedItem*/
    }
    
    [System.ServiceModel.ServiceContract]
    [System.ServiceModel.Activation.AspNetCompatibilityRequirements(RequirementsMode = System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestServiceCommonRelatedEventsSource
    {
        private ServiceUtility _serviceUtility;
        /*DataStructureInfo AdditionalPropertyInitialization Common.RelatedEventsSource*/

        public RestServiceCommonRelatedEventsSource(ServiceUtility serviceUtility/*DataStructureInfo AdditionalPropertyConstructorParameter Common.RelatedEventsSource*/)
        {
            _serviceUtility = serviceUtility;
            /*DataStructureInfo AdditionalPropertyConstructorSetProperties Common.RelatedEventsSource*/
        }
    
        public static readonly IDictionary<string, Type[]> FilterTypes = new List<Tuple<string, Type>>
            {
                /*DataStructureInfo FilterTypes Common.RelatedEventsSource*/
            }
            .GroupBy(typeName => typeName.Item1)
            .ToDictionary(g => g.Key, g => g.Select(typeName => typeName.Item2).Distinct().ToArray());

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsResult<Common.RelatedEventsSource> Get(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            var data = _serviceUtility.GetData<Common.RelatedEventsSource>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: false);
            return new RecordsResult<Common.RelatedEventsSource> { Records = data.Records };
        }

        [Obsolete]
        [OperationContract]
        [WebGet(UriTemplate = "/Count?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public CountResult GetCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Common.RelatedEventsSource>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new CountResult { TotalRecords = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters).
        [OperationContract]
        [WebGet(UriTemplate = "/TotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public TotalCountResult GetTotalCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Common.RelatedEventsSource>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new TotalCountResult { TotalCount = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/RecordsAndTotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsAndTotalCountResult<Common.RelatedEventsSource> GetRecordsAndTotalCount(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            return _serviceUtility.GetData<Common.RelatedEventsSource>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: true);
        }

        [OperationContract]
        [WebGet(UriTemplate = "/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Common.RelatedEventsSource GetById(string id)
        {
            var result = _serviceUtility.GetDataById<Common.RelatedEventsSource>(id);
            if (result == null)
                throw new Rhetos.LegacyClientException("There is no resource of this type with a given ID.") { HttpStatusCode = HttpStatusCode.NotFound, Severe = false };
            return result;
        }

        /*DataStructureInfo AdditionalOperations Common.RelatedEventsSource*/
    }
    
    [System.ServiceModel.ServiceContract]
    [System.ServiceModel.Activation.AspNetCompatibilityRequirements(RequirementsMode = System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestServiceCommonClaim
    {
        private ServiceUtility _serviceUtility;
        /*DataStructureInfo AdditionalPropertyInitialization Common.Claim*/

        public RestServiceCommonClaim(ServiceUtility serviceUtility/*DataStructureInfo AdditionalPropertyConstructorParameter Common.Claim*/)
        {
            _serviceUtility = serviceUtility;
            /*DataStructureInfo AdditionalPropertyConstructorSetProperties Common.Claim*/
        }
    
        public static readonly IDictionary<string, Type[]> FilterTypes = new List<Tuple<string, Type>>
            {
                Tuple.Create("Rhetos.Dom.DefaultConcepts.ActiveItems", typeof(Rhetos.Dom.DefaultConcepts.ActiveItems)),
                Tuple.Create("ActiveItems", typeof(Rhetos.Dom.DefaultConcepts.ActiveItems)),
                Tuple.Create("Common.SystemRequiredActive", typeof(Common.SystemRequiredActive)),
                Tuple.Create("SystemRequiredActive", typeof(Common.SystemRequiredActive)),
                /*DataStructureInfo FilterTypes Common.Claim*/
            }
            .GroupBy(typeName => typeName.Item1)
            .ToDictionary(g => g.Key, g => g.Select(typeName => typeName.Item2).Distinct().ToArray());

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsResult<Common.Claim> Get(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            var data = _serviceUtility.GetData<Common.Claim>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: false);
            return new RecordsResult<Common.Claim> { Records = data.Records };
        }

        [Obsolete]
        [OperationContract]
        [WebGet(UriTemplate = "/Count?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public CountResult GetCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Common.Claim>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new CountResult { TotalRecords = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters).
        [OperationContract]
        [WebGet(UriTemplate = "/TotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public TotalCountResult GetTotalCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Common.Claim>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new TotalCountResult { TotalCount = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/RecordsAndTotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsAndTotalCountResult<Common.Claim> GetRecordsAndTotalCount(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            return _serviceUtility.GetData<Common.Claim>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: true);
        }

        [OperationContract]
        [WebGet(UriTemplate = "/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Common.Claim GetById(string id)
        {
            var result = _serviceUtility.GetDataById<Common.Claim>(id);
            if (result == null)
                throw new Rhetos.LegacyClientException("There is no resource of this type with a given ID.") { HttpStatusCode = HttpStatusCode.NotFound, Severe = false };
            return result;
        }

        
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public InsertDataResult InsertCommonClaim(Common.Claim entity)
        {
            if (Guid.Empty == entity.ID)
                entity.ID = Guid.NewGuid();

            var result = _serviceUtility.InsertData(entity);
            return new InsertDataResult { ID = entity.ID };
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void UpdateCommonClaim(string id, Common.Claim entity)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            if (Guid.Empty == entity.ID)
                entity.ID = guid;
            if (guid != entity.ID)
                throw new Rhetos.LegacyClientException("Given entity ID is not equal to resource ID from URI.");

            _serviceUtility.UpdateData(entity);
        }

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void DeleteCommonClaim(string id)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            var entity = new Common.Claim { ID = guid };

            _serviceUtility.DeleteData(entity);
        }

/*DataStructureInfo AdditionalOperations Common.Claim*/
    }
    
    [System.ServiceModel.ServiceContract]
    [System.ServiceModel.Activation.AspNetCompatibilityRequirements(RequirementsMode = System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestServiceCommonMyClaim
    {
        private ServiceUtility _serviceUtility;
        /*DataStructureInfo AdditionalPropertyInitialization Common.MyClaim*/

        public RestServiceCommonMyClaim(ServiceUtility serviceUtility/*DataStructureInfo AdditionalPropertyConstructorParameter Common.MyClaim*/)
        {
            _serviceUtility = serviceUtility;
            /*DataStructureInfo AdditionalPropertyConstructorSetProperties Common.MyClaim*/
        }
    
        public static readonly IDictionary<string, Type[]> FilterTypes = new List<Tuple<string, Type>>
            {
                Tuple.Create("Common.Claim", typeof(Common.Claim)),
                Tuple.Create("Claim", typeof(Common.Claim)),
                Tuple.Create("IEnumerable<Common.Claim>", typeof(IEnumerable<Common.Claim>)),
                /*DataStructureInfo FilterTypes Common.MyClaim*/
            }
            .GroupBy(typeName => typeName.Item1)
            .ToDictionary(g => g.Key, g => g.Select(typeName => typeName.Item2).Distinct().ToArray());

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsResult<Common.MyClaim> Get(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            var data = _serviceUtility.GetData<Common.MyClaim>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: false);
            return new RecordsResult<Common.MyClaim> { Records = data.Records };
        }

        [Obsolete]
        [OperationContract]
        [WebGet(UriTemplate = "/Count?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public CountResult GetCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Common.MyClaim>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new CountResult { TotalRecords = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters).
        [OperationContract]
        [WebGet(UriTemplate = "/TotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public TotalCountResult GetTotalCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Common.MyClaim>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new TotalCountResult { TotalCount = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/RecordsAndTotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsAndTotalCountResult<Common.MyClaim> GetRecordsAndTotalCount(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            return _serviceUtility.GetData<Common.MyClaim>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: true);
        }

        [OperationContract]
        [WebGet(UriTemplate = "/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Common.MyClaim GetById(string id)
        {
            var result = _serviceUtility.GetDataById<Common.MyClaim>(id);
            if (result == null)
                throw new Rhetos.LegacyClientException("There is no resource of this type with a given ID.") { HttpStatusCode = HttpStatusCode.NotFound, Severe = false };
            return result;
        }

        /*DataStructureInfo AdditionalOperations Common.MyClaim*/
    }
    
    [System.ServiceModel.ServiceContract]
    [System.ServiceModel.Activation.AspNetCompatibilityRequirements(RequirementsMode = System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestServiceCommonPrincipal
    {
        private ServiceUtility _serviceUtility;
        /*DataStructureInfo AdditionalPropertyInitialization Common.Principal*/

        public RestServiceCommonPrincipal(ServiceUtility serviceUtility/*DataStructureInfo AdditionalPropertyConstructorParameter Common.Principal*/)
        {
            _serviceUtility = serviceUtility;
            /*DataStructureInfo AdditionalPropertyConstructorSetProperties Common.Principal*/
        }
    
        public static readonly IDictionary<string, Type[]> FilterTypes = new List<Tuple<string, Type>>
            {
                /*DataStructureInfo FilterTypes Common.Principal*/
            }
            .GroupBy(typeName => typeName.Item1)
            .ToDictionary(g => g.Key, g => g.Select(typeName => typeName.Item2).Distinct().ToArray());

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsResult<Common.Principal> Get(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            var data = _serviceUtility.GetData<Common.Principal>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: false);
            return new RecordsResult<Common.Principal> { Records = data.Records };
        }

        [Obsolete]
        [OperationContract]
        [WebGet(UriTemplate = "/Count?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public CountResult GetCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Common.Principal>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new CountResult { TotalRecords = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters).
        [OperationContract]
        [WebGet(UriTemplate = "/TotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public TotalCountResult GetTotalCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Common.Principal>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new TotalCountResult { TotalCount = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/RecordsAndTotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsAndTotalCountResult<Common.Principal> GetRecordsAndTotalCount(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            return _serviceUtility.GetData<Common.Principal>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: true);
        }

        [OperationContract]
        [WebGet(UriTemplate = "/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Common.Principal GetById(string id)
        {
            var result = _serviceUtility.GetDataById<Common.Principal>(id);
            if (result == null)
                throw new Rhetos.LegacyClientException("There is no resource of this type with a given ID.") { HttpStatusCode = HttpStatusCode.NotFound, Severe = false };
            return result;
        }

        
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public InsertDataResult InsertCommonPrincipal(Common.Principal entity)
        {
            if (Guid.Empty == entity.ID)
                entity.ID = Guid.NewGuid();

            var result = _serviceUtility.InsertData(entity);
            return new InsertDataResult { ID = entity.ID };
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void UpdateCommonPrincipal(string id, Common.Principal entity)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            if (Guid.Empty == entity.ID)
                entity.ID = guid;
            if (guid != entity.ID)
                throw new Rhetos.LegacyClientException("Given entity ID is not equal to resource ID from URI.");

            _serviceUtility.UpdateData(entity);
        }

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void DeleteCommonPrincipal(string id)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            var entity = new Common.Principal { ID = guid };

            _serviceUtility.DeleteData(entity);
        }

/*DataStructureInfo AdditionalOperations Common.Principal*/
    }
    
    [System.ServiceModel.ServiceContract]
    [System.ServiceModel.Activation.AspNetCompatibilityRequirements(RequirementsMode = System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestServiceCommonPrincipalHasRole
    {
        private ServiceUtility _serviceUtility;
        /*DataStructureInfo AdditionalPropertyInitialization Common.PrincipalHasRole*/

        public RestServiceCommonPrincipalHasRole(ServiceUtility serviceUtility/*DataStructureInfo AdditionalPropertyConstructorParameter Common.PrincipalHasRole*/)
        {
            _serviceUtility = serviceUtility;
            /*DataStructureInfo AdditionalPropertyConstructorSetProperties Common.PrincipalHasRole*/
        }
    
        public static readonly IDictionary<string, Type[]> FilterTypes = new List<Tuple<string, Type>>
            {
                Tuple.Create("Common.SystemRequiredPrincipal", typeof(Common.SystemRequiredPrincipal)),
                Tuple.Create("SystemRequiredPrincipal", typeof(Common.SystemRequiredPrincipal)),
                /*DataStructureInfo FilterTypes Common.PrincipalHasRole*/
            }
            .GroupBy(typeName => typeName.Item1)
            .ToDictionary(g => g.Key, g => g.Select(typeName => typeName.Item2).Distinct().ToArray());

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsResult<Common.PrincipalHasRole> Get(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            var data = _serviceUtility.GetData<Common.PrincipalHasRole>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: false);
            return new RecordsResult<Common.PrincipalHasRole> { Records = data.Records };
        }

        [Obsolete]
        [OperationContract]
        [WebGet(UriTemplate = "/Count?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public CountResult GetCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Common.PrincipalHasRole>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new CountResult { TotalRecords = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters).
        [OperationContract]
        [WebGet(UriTemplate = "/TotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public TotalCountResult GetTotalCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Common.PrincipalHasRole>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new TotalCountResult { TotalCount = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/RecordsAndTotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsAndTotalCountResult<Common.PrincipalHasRole> GetRecordsAndTotalCount(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            return _serviceUtility.GetData<Common.PrincipalHasRole>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: true);
        }

        [OperationContract]
        [WebGet(UriTemplate = "/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Common.PrincipalHasRole GetById(string id)
        {
            var result = _serviceUtility.GetDataById<Common.PrincipalHasRole>(id);
            if (result == null)
                throw new Rhetos.LegacyClientException("There is no resource of this type with a given ID.") { HttpStatusCode = HttpStatusCode.NotFound, Severe = false };
            return result;
        }

        
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public InsertDataResult InsertCommonPrincipalHasRole(Common.PrincipalHasRole entity)
        {
            if (Guid.Empty == entity.ID)
                entity.ID = Guid.NewGuid();

            var result = _serviceUtility.InsertData(entity);
            return new InsertDataResult { ID = entity.ID };
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void UpdateCommonPrincipalHasRole(string id, Common.PrincipalHasRole entity)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            if (Guid.Empty == entity.ID)
                entity.ID = guid;
            if (guid != entity.ID)
                throw new Rhetos.LegacyClientException("Given entity ID is not equal to resource ID from URI.");

            _serviceUtility.UpdateData(entity);
        }

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void DeleteCommonPrincipalHasRole(string id)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            var entity = new Common.PrincipalHasRole { ID = guid };

            _serviceUtility.DeleteData(entity);
        }

/*DataStructureInfo AdditionalOperations Common.PrincipalHasRole*/
    }
    
    [System.ServiceModel.ServiceContract]
    [System.ServiceModel.Activation.AspNetCompatibilityRequirements(RequirementsMode = System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestServiceCommonRole
    {
        private ServiceUtility _serviceUtility;
        /*DataStructureInfo AdditionalPropertyInitialization Common.Role*/

        public RestServiceCommonRole(ServiceUtility serviceUtility/*DataStructureInfo AdditionalPropertyConstructorParameter Common.Role*/)
        {
            _serviceUtility = serviceUtility;
            /*DataStructureInfo AdditionalPropertyConstructorSetProperties Common.Role*/
        }
    
        public static readonly IDictionary<string, Type[]> FilterTypes = new List<Tuple<string, Type>>
            {
                /*DataStructureInfo FilterTypes Common.Role*/
            }
            .GroupBy(typeName => typeName.Item1)
            .ToDictionary(g => g.Key, g => g.Select(typeName => typeName.Item2).Distinct().ToArray());

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsResult<Common.Role> Get(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            var data = _serviceUtility.GetData<Common.Role>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: false);
            return new RecordsResult<Common.Role> { Records = data.Records };
        }

        [Obsolete]
        [OperationContract]
        [WebGet(UriTemplate = "/Count?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public CountResult GetCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Common.Role>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new CountResult { TotalRecords = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters).
        [OperationContract]
        [WebGet(UriTemplate = "/TotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public TotalCountResult GetTotalCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Common.Role>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new TotalCountResult { TotalCount = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/RecordsAndTotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsAndTotalCountResult<Common.Role> GetRecordsAndTotalCount(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            return _serviceUtility.GetData<Common.Role>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: true);
        }

        [OperationContract]
        [WebGet(UriTemplate = "/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Common.Role GetById(string id)
        {
            var result = _serviceUtility.GetDataById<Common.Role>(id);
            if (result == null)
                throw new Rhetos.LegacyClientException("There is no resource of this type with a given ID.") { HttpStatusCode = HttpStatusCode.NotFound, Severe = false };
            return result;
        }

        
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public InsertDataResult InsertCommonRole(Common.Role entity)
        {
            if (Guid.Empty == entity.ID)
                entity.ID = Guid.NewGuid();

            var result = _serviceUtility.InsertData(entity);
            return new InsertDataResult { ID = entity.ID };
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void UpdateCommonRole(string id, Common.Role entity)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            if (Guid.Empty == entity.ID)
                entity.ID = guid;
            if (guid != entity.ID)
                throw new Rhetos.LegacyClientException("Given entity ID is not equal to resource ID from URI.");

            _serviceUtility.UpdateData(entity);
        }

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void DeleteCommonRole(string id)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            var entity = new Common.Role { ID = guid };

            _serviceUtility.DeleteData(entity);
        }

/*DataStructureInfo AdditionalOperations Common.Role*/
    }
    
    [System.ServiceModel.ServiceContract]
    [System.ServiceModel.Activation.AspNetCompatibilityRequirements(RequirementsMode = System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestServiceCommonRoleInheritsRole
    {
        private ServiceUtility _serviceUtility;
        /*DataStructureInfo AdditionalPropertyInitialization Common.RoleInheritsRole*/

        public RestServiceCommonRoleInheritsRole(ServiceUtility serviceUtility/*DataStructureInfo AdditionalPropertyConstructorParameter Common.RoleInheritsRole*/)
        {
            _serviceUtility = serviceUtility;
            /*DataStructureInfo AdditionalPropertyConstructorSetProperties Common.RoleInheritsRole*/
        }
    
        public static readonly IDictionary<string, Type[]> FilterTypes = new List<Tuple<string, Type>>
            {
                Tuple.Create("Common.SystemRequiredUsersFrom", typeof(Common.SystemRequiredUsersFrom)),
                Tuple.Create("SystemRequiredUsersFrom", typeof(Common.SystemRequiredUsersFrom)),
                /*DataStructureInfo FilterTypes Common.RoleInheritsRole*/
            }
            .GroupBy(typeName => typeName.Item1)
            .ToDictionary(g => g.Key, g => g.Select(typeName => typeName.Item2).Distinct().ToArray());

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsResult<Common.RoleInheritsRole> Get(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            var data = _serviceUtility.GetData<Common.RoleInheritsRole>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: false);
            return new RecordsResult<Common.RoleInheritsRole> { Records = data.Records };
        }

        [Obsolete]
        [OperationContract]
        [WebGet(UriTemplate = "/Count?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public CountResult GetCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Common.RoleInheritsRole>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new CountResult { TotalRecords = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters).
        [OperationContract]
        [WebGet(UriTemplate = "/TotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public TotalCountResult GetTotalCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Common.RoleInheritsRole>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new TotalCountResult { TotalCount = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/RecordsAndTotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsAndTotalCountResult<Common.RoleInheritsRole> GetRecordsAndTotalCount(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            return _serviceUtility.GetData<Common.RoleInheritsRole>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: true);
        }

        [OperationContract]
        [WebGet(UriTemplate = "/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Common.RoleInheritsRole GetById(string id)
        {
            var result = _serviceUtility.GetDataById<Common.RoleInheritsRole>(id);
            if (result == null)
                throw new Rhetos.LegacyClientException("There is no resource of this type with a given ID.") { HttpStatusCode = HttpStatusCode.NotFound, Severe = false };
            return result;
        }

        
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public InsertDataResult InsertCommonRoleInheritsRole(Common.RoleInheritsRole entity)
        {
            if (Guid.Empty == entity.ID)
                entity.ID = Guid.NewGuid();

            var result = _serviceUtility.InsertData(entity);
            return new InsertDataResult { ID = entity.ID };
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void UpdateCommonRoleInheritsRole(string id, Common.RoleInheritsRole entity)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            if (Guid.Empty == entity.ID)
                entity.ID = guid;
            if (guid != entity.ID)
                throw new Rhetos.LegacyClientException("Given entity ID is not equal to resource ID from URI.");

            _serviceUtility.UpdateData(entity);
        }

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void DeleteCommonRoleInheritsRole(string id)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            var entity = new Common.RoleInheritsRole { ID = guid };

            _serviceUtility.DeleteData(entity);
        }

/*DataStructureInfo AdditionalOperations Common.RoleInheritsRole*/
    }
    
    [System.ServiceModel.ServiceContract]
    [System.ServiceModel.Activation.AspNetCompatibilityRequirements(RequirementsMode = System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestServiceCommonPrincipalPermission
    {
        private ServiceUtility _serviceUtility;
        /*DataStructureInfo AdditionalPropertyInitialization Common.PrincipalPermission*/

        public RestServiceCommonPrincipalPermission(ServiceUtility serviceUtility/*DataStructureInfo AdditionalPropertyConstructorParameter Common.PrincipalPermission*/)
        {
            _serviceUtility = serviceUtility;
            /*DataStructureInfo AdditionalPropertyConstructorSetProperties Common.PrincipalPermission*/
        }
    
        public static readonly IDictionary<string, Type[]> FilterTypes = new List<Tuple<string, Type>>
            {
                Tuple.Create("Common.SystemRequiredPrincipal", typeof(Common.SystemRequiredPrincipal)),
                Tuple.Create("SystemRequiredPrincipal", typeof(Common.SystemRequiredPrincipal)),
                Tuple.Create("Common.SystemRequiredClaim", typeof(Common.SystemRequiredClaim)),
                Tuple.Create("SystemRequiredClaim", typeof(Common.SystemRequiredClaim)),
                /*DataStructureInfo FilterTypes Common.PrincipalPermission*/
            }
            .GroupBy(typeName => typeName.Item1)
            .ToDictionary(g => g.Key, g => g.Select(typeName => typeName.Item2).Distinct().ToArray());

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsResult<Common.PrincipalPermission> Get(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            var data = _serviceUtility.GetData<Common.PrincipalPermission>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: false);
            return new RecordsResult<Common.PrincipalPermission> { Records = data.Records };
        }

        [Obsolete]
        [OperationContract]
        [WebGet(UriTemplate = "/Count?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public CountResult GetCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Common.PrincipalPermission>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new CountResult { TotalRecords = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters).
        [OperationContract]
        [WebGet(UriTemplate = "/TotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public TotalCountResult GetTotalCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Common.PrincipalPermission>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new TotalCountResult { TotalCount = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/RecordsAndTotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsAndTotalCountResult<Common.PrincipalPermission> GetRecordsAndTotalCount(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            return _serviceUtility.GetData<Common.PrincipalPermission>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: true);
        }

        [OperationContract]
        [WebGet(UriTemplate = "/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Common.PrincipalPermission GetById(string id)
        {
            var result = _serviceUtility.GetDataById<Common.PrincipalPermission>(id);
            if (result == null)
                throw new Rhetos.LegacyClientException("There is no resource of this type with a given ID.") { HttpStatusCode = HttpStatusCode.NotFound, Severe = false };
            return result;
        }

        
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public InsertDataResult InsertCommonPrincipalPermission(Common.PrincipalPermission entity)
        {
            if (Guid.Empty == entity.ID)
                entity.ID = Guid.NewGuid();

            var result = _serviceUtility.InsertData(entity);
            return new InsertDataResult { ID = entity.ID };
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void UpdateCommonPrincipalPermission(string id, Common.PrincipalPermission entity)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            if (Guid.Empty == entity.ID)
                entity.ID = guid;
            if (guid != entity.ID)
                throw new Rhetos.LegacyClientException("Given entity ID is not equal to resource ID from URI.");

            _serviceUtility.UpdateData(entity);
        }

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void DeleteCommonPrincipalPermission(string id)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            var entity = new Common.PrincipalPermission { ID = guid };

            _serviceUtility.DeleteData(entity);
        }

/*DataStructureInfo AdditionalOperations Common.PrincipalPermission*/
    }
    
    [System.ServiceModel.ServiceContract]
    [System.ServiceModel.Activation.AspNetCompatibilityRequirements(RequirementsMode = System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestServiceCommonRolePermission
    {
        private ServiceUtility _serviceUtility;
        /*DataStructureInfo AdditionalPropertyInitialization Common.RolePermission*/

        public RestServiceCommonRolePermission(ServiceUtility serviceUtility/*DataStructureInfo AdditionalPropertyConstructorParameter Common.RolePermission*/)
        {
            _serviceUtility = serviceUtility;
            /*DataStructureInfo AdditionalPropertyConstructorSetProperties Common.RolePermission*/
        }
    
        public static readonly IDictionary<string, Type[]> FilterTypes = new List<Tuple<string, Type>>
            {
                Tuple.Create("Common.SystemRequiredRole", typeof(Common.SystemRequiredRole)),
                Tuple.Create("SystemRequiredRole", typeof(Common.SystemRequiredRole)),
                Tuple.Create("Common.SystemRequiredClaim", typeof(Common.SystemRequiredClaim)),
                Tuple.Create("SystemRequiredClaim", typeof(Common.SystemRequiredClaim)),
                /*DataStructureInfo FilterTypes Common.RolePermission*/
            }
            .GroupBy(typeName => typeName.Item1)
            .ToDictionary(g => g.Key, g => g.Select(typeName => typeName.Item2).Distinct().ToArray());

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsResult<Common.RolePermission> Get(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            var data = _serviceUtility.GetData<Common.RolePermission>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: false);
            return new RecordsResult<Common.RolePermission> { Records = data.Records };
        }

        [Obsolete]
        [OperationContract]
        [WebGet(UriTemplate = "/Count?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public CountResult GetCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Common.RolePermission>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new CountResult { TotalRecords = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters).
        [OperationContract]
        [WebGet(UriTemplate = "/TotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public TotalCountResult GetTotalCount(string filter, string fparam, string genericfilter, string filters, string sort)
        {
            var data = _serviceUtility.GetData<Common.RolePermission>(filter, fparam, genericfilter, filters, FilterTypes, 0, 0, 0, 0, sort,
                readRecords: false, readTotalCount: true);
            return new TotalCountResult { TotalCount = data.TotalCount };
        }

        // [Obsolete] parameters: filter, fparam, genericfilter (use filters), page, psize (use top and skip).
        [OperationContract]
        [WebGet(UriTemplate = "/RecordsAndTotalCount?filter={filter}&fparam={fparam}&genericfilter={genericfilter}&filters={filters}&top={top}&skip={skip}&page={page}&psize={psize}&sort={sort}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecordsAndTotalCountResult<Common.RolePermission> GetRecordsAndTotalCount(string filter, string fparam, string genericfilter, string filters, int top, int skip, int page, int psize, string sort)
        {
            return _serviceUtility.GetData<Common.RolePermission>(filter, fparam, genericfilter, filters, FilterTypes, top, skip, page, psize, sort,
                readRecords: true, readTotalCount: true);
        }

        [OperationContract]
        [WebGet(UriTemplate = "/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Common.RolePermission GetById(string id)
        {
            var result = _serviceUtility.GetDataById<Common.RolePermission>(id);
            if (result == null)
                throw new Rhetos.LegacyClientException("There is no resource of this type with a given ID.") { HttpStatusCode = HttpStatusCode.NotFound, Severe = false };
            return result;
        }

        
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public InsertDataResult InsertCommonRolePermission(Common.RolePermission entity)
        {
            if (Guid.Empty == entity.ID)
                entity.ID = Guid.NewGuid();

            var result = _serviceUtility.InsertData(entity);
            return new InsertDataResult { ID = entity.ID };
        }

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void UpdateCommonRolePermission(string id, Common.RolePermission entity)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            if (Guid.Empty == entity.ID)
                entity.ID = guid;
            if (guid != entity.ID)
                throw new Rhetos.LegacyClientException("Given entity ID is not equal to resource ID from URI.");

            _serviceUtility.UpdateData(entity);
        }

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "{id}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void DeleteCommonRolePermission(string id)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                throw new Rhetos.LegacyClientException("Invalid format of GUID parametar 'ID'.");
            var entity = new Common.RolePermission { ID = guid };

            _serviceUtility.DeleteData(entity);
        }

/*DataStructureInfo AdditionalOperations Common.RolePermission*/
    }
    /*InitialCodeGenerator.RhetosRestClassesTag*/

}


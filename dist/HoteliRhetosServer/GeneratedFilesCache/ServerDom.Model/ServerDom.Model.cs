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
// CompilerOptions: "/optimize"

namespace Hoteli
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

    [DataContract]/*DataStructureInfo ClassAttributes Hoteli.Hotel*/
    public class Hotel : EntityBase<Hoteli.Hotel>/*Next DataStructureInfo ClassInterace Hoteli.Hotel*/
    {
        /// <summary>Converts the simple object to a navigation object, and copies its simple properties. Navigation properties are set to null.</summary>
        public Common.Queryable.Hoteli_Hotel ToNavigation()
        {
            var item = this;
            return new Common.Queryable.Hoteli_Hotel
            {
                ID = item.ID,
                Code = item.Code,
                Name = item.Name,
                Address = item.Address/*DataStructureInfo AssignSimpleProperty Hoteli.Hotel*/
            };
        }

        [DataMember]/*PropertyInfo Attribute Hoteli.Hotel.Code*/
        public string Code { get; set; }
        [DataMember]/*PropertyInfo Attribute Hoteli.Hotel.Name*/
        public string Name { get; set; }
        [DataMember]/*PropertyInfo Attribute Hoteli.Hotel.Address*/
        public string Address { get; set; }
        /*DataStructureInfo ClassBody Hoteli.Hotel*/
    }

    [DataContract]/*DataStructureInfo ClassAttributes Hoteli.Location*/
    public class Location : EntityBase<Hoteli.Location>/*Next DataStructureInfo ClassInterace Hoteli.Location*/
    {
        /// <summary>Converts the simple object to a navigation object, and copies its simple properties. Navigation properties are set to null.</summary>
        public Common.Queryable.Hoteli_Location ToNavigation()
        {
            var item = this;
            return new Common.Queryable.Hoteli_Location
            {
                ID = item.ID,
                Code = item.Code,
                Country = item.Country,
                County = item.County,
                City = item.City,
                Area = item.Area/*DataStructureInfo AssignSimpleProperty Hoteli.Location*/
            };
        }

        [DataMember]/*PropertyInfo Attribute Hoteli.Location.Code*/
        public string Code { get; set; }
        [DataMember]/*PropertyInfo Attribute Hoteli.Location.Country*/
        public string Country { get; set; }
        [DataMember]/*PropertyInfo Attribute Hoteli.Location.County*/
        public string County { get; set; }
        [DataMember]/*PropertyInfo Attribute Hoteli.Location.City*/
        public string City { get; set; }
        [DataMember]/*PropertyInfo Attribute Hoteli.Location.Area*/
        public string Area { get; set; }
        /*DataStructureInfo ClassBody Hoteli.Location*/
    }

    [DataContract]/*DataStructureInfo ClassAttributes Hoteli.RoomReservation*/
    public class RoomReservation : EntityBase<Hoteli.RoomReservation>/*Next DataStructureInfo ClassInterace Hoteli.RoomReservation*/
    {
        /// <summary>Converts the simple object to a navigation object, and copies its simple properties. Navigation properties are set to null.</summary>
        public Common.Queryable.Hoteli_RoomReservation ToNavigation()
        {
            var item = this;
            return new Common.Queryable.Hoteli_RoomReservation
            {
                ID = item.ID,
                Code = item.Code,
                ReservationHotelID = item.ReservationHotelID,
                ReservationRoomID = item.ReservationRoomID/*DataStructureInfo AssignSimpleProperty Hoteli.RoomReservation*/
            };
        }

        [DataMember]/*PropertyInfo Attribute Hoteli.RoomReservation.Code*/
        public string Code { get; set; }
        [DataMember]/*PropertyInfo Attribute Hoteli.RoomReservation.ReservationHotelID*/
        public Guid? ReservationHotelID { get; set; }
        [DataMember]/*PropertyInfo Attribute Hoteli.RoomReservation.ReservationRoomID*/
        public Guid? ReservationRoomID { get; set; }
        /*DataStructureInfo ClassBody Hoteli.RoomReservation*/
    }

    [DataContract]/*DataStructureInfo ClassAttributes Hoteli.Reservation*/
    public class Reservation : EntityBase<Hoteli.Reservation>/*Next DataStructureInfo ClassInterace Hoteli.Reservation*/
    {
        /// <summary>Converts the simple object to a navigation object, and copies its simple properties. Navigation properties are set to null.</summary>
        public Common.Queryable.Hoteli_Reservation ToNavigation()
        {
            var item = this;
            return new Common.Queryable.Hoteli_Reservation
            {
                ID = item.ID,
                Code = item.Code,
                DateFrom = item.DateFrom,
                DateTo = item.DateTo,
                NumberOfPeople = item.NumberOfPeople,
                GuestID = item.GuestID/*DataStructureInfo AssignSimpleProperty Hoteli.Reservation*/
            };
        }

        [DataMember]/*PropertyInfo Attribute Hoteli.Reservation.Code*/
        public string Code { get; set; }
        [DataMember]/*PropertyInfo Attribute Hoteli.Reservation.DateFrom*/
        public DateTime? DateFrom { get; set; }
        [DataMember]/*PropertyInfo Attribute Hoteli.Reservation.DateTo*/
        public DateTime? DateTo { get; set; }
        [DataMember]/*PropertyInfo Attribute Hoteli.Reservation.NumberOfPeople*/
        public int? NumberOfPeople { get; set; }
        [DataMember]/*PropertyInfo Attribute Hoteli.Reservation.GuestID*/
        public Guid? GuestID { get; set; }
        /*DataStructureInfo ClassBody Hoteli.Reservation*/
    }

    [DataContract]/*DataStructureInfo ClassAttributes Hoteli.Rooms*/
    public class Rooms : EntityBase<Hoteli.Rooms>/*Next DataStructureInfo ClassInterace Hoteli.Rooms*/
    {
        /// <summary>Converts the simple object to a navigation object, and copies its simple properties. Navigation properties are set to null.</summary>
        public Common.Queryable.Hoteli_Rooms ToNavigation()
        {
            var item = this;
            return new Common.Queryable.Hoteli_Rooms
            {
                ID = item.ID,
                Code = item.Code,
                NumberOfPeople = item.NumberOfPeople,
                RoomOfHotelID = item.RoomOfHotelID,
                TypeOfRoom = item.TypeOfRoom/*DataStructureInfo AssignSimpleProperty Hoteli.Rooms*/
            };
        }

        [DataMember]/*PropertyInfo Attribute Hoteli.Rooms.Code*/
        public string Code { get; set; }
        [DataMember]/*PropertyInfo Attribute Hoteli.Rooms.NumberOfPeople*/
        public int? NumberOfPeople { get; set; }
        [DataMember]/*PropertyInfo Attribute Hoteli.Rooms.RoomOfHotelID*/
        public Guid? RoomOfHotelID { get; set; }
        [DataMember]/*PropertyInfo Attribute Hoteli.Rooms.TypeOfRoom*/
        public string TypeOfRoom { get; set; }
        /*DataStructureInfo ClassBody Hoteli.Rooms*/
    }

    [DataContract]/*DataStructureInfo ClassAttributes Hoteli.Person*/
    public class Person : EntityBase<Hoteli.Person>/*Next DataStructureInfo ClassInterace Hoteli.Person*/
    {
        /// <summary>Converts the simple object to a navigation object, and copies its simple properties. Navigation properties are set to null.</summary>
        public Common.Queryable.Hoteli_Person ToNavigation()
        {
            var item = this;
            return new Common.Queryable.Hoteli_Person
            {
                ID = item.ID,
                Code = item.Code,
                Identifier = item.Identifier,
                Name = item.Name,
                Surname = item.Surname,
                Address = item.Address,
                isGuest = item.isGuest,
                isEmployee = item.isEmployee,
                isOwner = item.isOwner,
                Discount = item.Discount/*DataStructureInfo AssignSimpleProperty Hoteli.Person*/
            };
        }

        [DataMember]/*PropertyInfo Attribute Hoteli.Person.Code*/
        public string Code { get; set; }
        [DataMember]/*PropertyInfo Attribute Hoteli.Person.Identifier*/
        public string Identifier { get; set; }
        [DataMember]/*PropertyInfo Attribute Hoteli.Person.Name*/
        public string Name { get; set; }
        [DataMember]/*PropertyInfo Attribute Hoteli.Person.Surname*/
        public string Surname { get; set; }
        [DataMember]/*PropertyInfo Attribute Hoteli.Person.Address*/
        public string Address { get; set; }
        [DataMember]/*PropertyInfo Attribute Hoteli.Person.isGuest*/
        public bool? isGuest { get; set; }
        [DataMember]/*PropertyInfo Attribute Hoteli.Person.isEmployee*/
        public bool? isEmployee { get; set; }
        [DataMember]/*PropertyInfo Attribute Hoteli.Person.isOwner*/
        public bool? isOwner { get; set; }
        [DataMember]/*PropertyInfo Attribute Hoteli.Person.Discount*/
        public int? Discount { get; set; }
        /*DataStructureInfo ClassBody Hoteli.Person*/
    }

    [DataContract]/*DataStructureInfo ClassAttributes Hoteli.SaloonPerson*/
    public class SaloonPerson : EntityBase<Hoteli.SaloonPerson>/*Next DataStructureInfo ClassInterace Hoteli.SaloonPerson*/
    {
        /// <summary>Converts the simple object to a navigation object, and copies its simple properties. Navigation properties are set to null.</summary>
        public Common.Queryable.Hoteli_SaloonPerson ToNavigation()
        {
            var item = this;
            return new Common.Queryable.Hoteli_SaloonPerson
            {
                ID = item.ID,
                Code = item.Code,
                OwnerNameID = item.OwnerNameID,
                SalonID = item.SalonID/*DataStructureInfo AssignSimpleProperty Hoteli.SaloonPerson*/
            };
        }

        [DataMember]/*PropertyInfo Attribute Hoteli.SaloonPerson.Code*/
        public string Code { get; set; }
        [DataMember]/*PropertyInfo Attribute Hoteli.SaloonPerson.OwnerNameID*/
        public Guid? OwnerNameID { get; set; }
        [DataMember]/*PropertyInfo Attribute Hoteli.SaloonPerson.SalonID*/
        public Guid? SalonID { get; set; }
        /*DataStructureInfo ClassBody Hoteli.SaloonPerson*/
    }

    [DataContract]/*DataStructureInfo ClassAttributes Hoteli.SaloonHotel*/
    public class SaloonHotel : EntityBase<Hoteli.SaloonHotel>/*Next DataStructureInfo ClassInterace Hoteli.SaloonHotel*/
    {
        /// <summary>Converts the simple object to a navigation object, and copies its simple properties. Navigation properties are set to null.</summary>
        public Common.Queryable.Hoteli_SaloonHotel ToNavigation()
        {
            var item = this;
            return new Common.Queryable.Hoteli_SaloonHotel
            {
                ID = item.ID,
                Code = item.Code,
                OwnerNameID = item.OwnerNameID,
                SalonID = item.SalonID/*DataStructureInfo AssignSimpleProperty Hoteli.SaloonHotel*/
            };
        }

        [DataMember]/*PropertyInfo Attribute Hoteli.SaloonHotel.Code*/
        public string Code { get; set; }
        [DataMember]/*PropertyInfo Attribute Hoteli.SaloonHotel.OwnerNameID*/
        public Guid? OwnerNameID { get; set; }
        [DataMember]/*PropertyInfo Attribute Hoteli.SaloonHotel.SalonID*/
        public Guid? SalonID { get; set; }
        /*DataStructureInfo ClassBody Hoteli.SaloonHotel*/
    }

    [DataContract]/*DataStructureInfo ClassAttributes Hoteli.Saloon*/
    public class Saloon : EntityBase<Hoteli.Saloon>/*Next DataStructureInfo ClassInterace Hoteli.Saloon*/
    {
        /// <summary>Converts the simple object to a navigation object, and copies its simple properties. Navigation properties are set to null.</summary>
        public Common.Queryable.Hoteli_Saloon ToNavigation()
        {
            var item = this;
            return new Common.Queryable.Hoteli_Saloon
            {
                ID = item.ID,
                Code = item.Code,
                Name = item.Name,
                HotelSaloonID = item.HotelSaloonID/*DataStructureInfo AssignSimpleProperty Hoteli.Saloon*/
            };
        }

        [DataMember]/*PropertyInfo Attribute Hoteli.Saloon.Code*/
        public string Code { get; set; }
        [DataMember]/*PropertyInfo Attribute Hoteli.Saloon.Name*/
        public string Name { get; set; }
        [DataMember]/*PropertyInfo Attribute Hoteli.Saloon.HotelSaloonID*/
        public Guid? HotelSaloonID { get; set; }
        /*DataStructureInfo ClassBody Hoteli.Saloon*/
    }

    [DataContract]/*DataStructureInfo ClassAttributes Hoteli.ProductPerson*/
    public class ProductPerson : EntityBase<Hoteli.ProductPerson>/*Next DataStructureInfo ClassInterace Hoteli.ProductPerson*/
    {
        /// <summary>Converts the simple object to a navigation object, and copies its simple properties. Navigation properties are set to null.</summary>
        public Common.Queryable.Hoteli_ProductPerson ToNavigation()
        {
            var item = this;
            return new Common.Queryable.Hoteli_ProductPerson
            {
                ID = item.ID,
                Code = item.Code,
                OwnerNameID = item.OwnerNameID,
                ProductID = item.ProductID/*DataStructureInfo AssignSimpleProperty Hoteli.ProductPerson*/
            };
        }

        [DataMember]/*PropertyInfo Attribute Hoteli.ProductPerson.Code*/
        public string Code { get; set; }
        [DataMember]/*PropertyInfo Attribute Hoteli.ProductPerson.OwnerNameID*/
        public Guid? OwnerNameID { get; set; }
        [DataMember]/*PropertyInfo Attribute Hoteli.ProductPerson.ProductID*/
        public Guid? ProductID { get; set; }
        /*DataStructureInfo ClassBody Hoteli.ProductPerson*/
    }

    [DataContract]/*DataStructureInfo ClassAttributes Hoteli.ProductHotel*/
    public class ProductHotel : EntityBase<Hoteli.ProductHotel>/*Next DataStructureInfo ClassInterace Hoteli.ProductHotel*/
    {
        /// <summary>Converts the simple object to a navigation object, and copies its simple properties. Navigation properties are set to null.</summary>
        public Common.Queryable.Hoteli_ProductHotel ToNavigation()
        {
            var item = this;
            return new Common.Queryable.Hoteli_ProductHotel
            {
                ID = item.ID,
                Code = item.Code,
                OwnerNameID = item.OwnerNameID,
                ProductID = item.ProductID/*DataStructureInfo AssignSimpleProperty Hoteli.ProductHotel*/
            };
        }

        [DataMember]/*PropertyInfo Attribute Hoteli.ProductHotel.Code*/
        public string Code { get; set; }
        [DataMember]/*PropertyInfo Attribute Hoteli.ProductHotel.OwnerNameID*/
        public Guid? OwnerNameID { get; set; }
        [DataMember]/*PropertyInfo Attribute Hoteli.ProductHotel.ProductID*/
        public Guid? ProductID { get; set; }
        /*DataStructureInfo ClassBody Hoteli.ProductHotel*/
    }

    [DataContract]/*DataStructureInfo ClassAttributes Hoteli.Product*/
    public class Product : EntityBase<Hoteli.Product>/*Next DataStructureInfo ClassInterace Hoteli.Product*/
    {
        /// <summary>Converts the simple object to a navigation object, and copies its simple properties. Navigation properties are set to null.</summary>
        public Common.Queryable.Hoteli_Product ToNavigation()
        {
            var item = this;
            return new Common.Queryable.Hoteli_Product
            {
                ID = item.ID,
                Code = item.Code,
                Title = item.Title,
                HotelSaloonID = item.HotelSaloonID/*DataStructureInfo AssignSimpleProperty Hoteli.Product*/
            };
        }

        [DataMember]/*PropertyInfo Attribute Hoteli.Product.Code*/
        public string Code { get; set; }
        [DataMember]/*PropertyInfo Attribute Hoteli.Product.Title*/
        public string Title { get; set; }
        [DataMember]/*PropertyInfo Attribute Hoteli.Product.HotelSaloonID*/
        public Guid? HotelSaloonID { get; set; }
        /*DataStructureInfo ClassBody Hoteli.Product*/
    }

    [DataContract]/*DataStructureInfo ClassAttributes Hoteli.Insert5Hotels*/
    public class Insert5Hotels/*DataStructureInfo ClassInterace Hoteli.Insert5Hotels*/
    {
        /*DataStructureInfo ClassBody Hoteli.Insert5Hotels*/
    }

    [DataContract]/*DataStructureInfo ClassAttributes Hoteli.Insert5Rooms*/
    public class Insert5Rooms/*DataStructureInfo ClassInterace Hoteli.Insert5Rooms*/
    {
        /*DataStructureInfo ClassBody Hoteli.Insert5Rooms*/
    }

    [DataContract]/*DataStructureInfo ClassAttributes Hoteli.Insert6Rooms*/
    public class Insert6Rooms/*DataStructureInfo ClassInterace Hoteli.Insert6Rooms*/
    {
        /*DataStructureInfo ClassBody Hoteli.Insert6Rooms*/
    }

    [DataContract]/*DataStructureInfo ClassAttributes Hoteli.ReservationInfo*/
    public class ReservationInfo : EntityBase<Hoteli.ReservationInfo>/*Next DataStructureInfo ClassInterace Hoteli.ReservationInfo*/
    {
        /// <summary>Converts the simple object to a navigation object, and copies its simple properties. Navigation properties are set to null.</summary>
        public Common.Queryable.Hoteli_ReservationInfo ToNavigation()
        {
            var item = this;
            return new Common.Queryable.Hoteli_ReservationInfo
            {
                ID = item.ID,
                NumberOfRooms = item.NumberOfRooms/*DataStructureInfo AssignSimpleProperty Hoteli.ReservationInfo*/
            };
        }

        [DataMember]/*PropertyInfo Attribute Hoteli.ReservationInfo.NumberOfRooms*/
        public int? NumberOfRooms { get; set; }
        /*DataStructureInfo ClassBody Hoteli.ReservationInfo*/
    }

    [DataContract]/*DataStructureInfo ClassAttributes Hoteli.Negative*/
    public class Negative/*DataStructureInfo ClassInterace Hoteli.Negative*/
    {
        /*DataStructureInfo ClassBody Hoteli.Negative*/
    }

    [DataContract]/*DataStructureInfo ClassAttributes Hoteli.SystemRequiredCode*/
    public class SystemRequiredCode/*DataStructureInfo ClassInterace Hoteli.SystemRequiredCode*/
    {
        /*DataStructureInfo ClassBody Hoteli.SystemRequiredCode*/
    }

    /*ModuleInfo Body Hoteli*/
}

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

    /*ModuleInfo Using Common*/

    [DataContract]/*DataStructureInfo ClassAttributes Common.AutoCodeCache*/
    public class AutoCodeCache : EntityBase<Common.AutoCodeCache>/*Next DataStructureInfo ClassInterace Common.AutoCodeCache*/
    {
        /// <summary>Converts the simple object to a navigation object, and copies its simple properties. Navigation properties are set to null.</summary>
        public Common.Queryable.Common_AutoCodeCache ToNavigation()
        {
            var item = this;
            return new Common.Queryable.Common_AutoCodeCache
            {
                ID = item.ID,
                Entity = item.Entity,
                Property = item.Property,
                Grouping = item.Grouping,
                Prefix = item.Prefix,
                MinDigits = item.MinDigits,
                LastCode = item.LastCode/*DataStructureInfo AssignSimpleProperty Common.AutoCodeCache*/
            };
        }

        [DataMember]/*PropertyInfo Attribute Common.AutoCodeCache.Entity*/
        public string Entity { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.AutoCodeCache.Property*/
        public string Property { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.AutoCodeCache.Grouping*/
        public string Grouping { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.AutoCodeCache.Prefix*/
        public string Prefix { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.AutoCodeCache.MinDigits*/
        public int? MinDigits { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.AutoCodeCache.LastCode*/
        public int? LastCode { get; set; }
        /*DataStructureInfo ClassBody Common.AutoCodeCache*/
    }

    [DataContract]/*DataStructureInfo ClassAttributes Common.FilterId*/
    public class FilterId : EntityBase<Common.FilterId>, Rhetos.Dom.DefaultConcepts.ICommonFilterId/*Next DataStructureInfo ClassInterace Common.FilterId*/
    {
        /// <summary>Converts the simple object to a navigation object, and copies its simple properties. Navigation properties are set to null.</summary>
        public Common.Queryable.Common_FilterId ToNavigation()
        {
            var item = this;
            return new Common.Queryable.Common_FilterId
            {
                ID = item.ID,
                Handle = item.Handle,
                Value = item.Value/*DataStructureInfo AssignSimpleProperty Common.FilterId*/
            };
        }

        [DataMember]/*PropertyInfo Attribute Common.FilterId.Handle*/
        public Guid? Handle { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.FilterId.Value*/
        public Guid? Value { get; set; }
        /*DataStructureInfo ClassBody Common.FilterId*/
    }

    [DataContract]/*DataStructureInfo ClassAttributes Common.KeepSynchronizedMetadata*/
    public class KeepSynchronizedMetadata : EntityBase<Common.KeepSynchronizedMetadata>, Rhetos.Dom.DefaultConcepts.IKeepSynchronizedMetadata/*Next DataStructureInfo ClassInterace Common.KeepSynchronizedMetadata*/
    {
        /// <summary>Converts the simple object to a navigation object, and copies its simple properties. Navigation properties are set to null.</summary>
        public Common.Queryable.Common_KeepSynchronizedMetadata ToNavigation()
        {
            var item = this;
            return new Common.Queryable.Common_KeepSynchronizedMetadata
            {
                ID = item.ID,
                Target = item.Target,
                Source = item.Source,
                Context = item.Context/*DataStructureInfo AssignSimpleProperty Common.KeepSynchronizedMetadata*/
            };
        }

        [DataMember]/*PropertyInfo Attribute Common.KeepSynchronizedMetadata.Target*/
        public string Target { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.KeepSynchronizedMetadata.Source*/
        public string Source { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.KeepSynchronizedMetadata.Context*/
        public string Context { get; set; }
        /*DataStructureInfo ClassBody Common.KeepSynchronizedMetadata*/
    }

    [DataContract]/*DataStructureInfo ClassAttributes Common.ExclusiveLock*/
    public class ExclusiveLock : EntityBase<Common.ExclusiveLock>/*Next DataStructureInfo ClassInterace Common.ExclusiveLock*/
    {
        /// <summary>Converts the simple object to a navigation object, and copies its simple properties. Navigation properties are set to null.</summary>
        public Common.Queryable.Common_ExclusiveLock ToNavigation()
        {
            var item = this;
            return new Common.Queryable.Common_ExclusiveLock
            {
                ID = item.ID,
                ResourceType = item.ResourceType,
                ResourceID = item.ResourceID,
                UserName = item.UserName,
                Workstation = item.Workstation,
                LockStart = item.LockStart,
                LockFinish = item.LockFinish/*DataStructureInfo AssignSimpleProperty Common.ExclusiveLock*/
            };
        }

        [DataMember]/*PropertyInfo Attribute Common.ExclusiveLock.ResourceType*/
        public string ResourceType { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.ExclusiveLock.ResourceID*/
        public Guid? ResourceID { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.ExclusiveLock.UserName*/
        public string UserName { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.ExclusiveLock.Workstation*/
        public string Workstation { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.ExclusiveLock.LockStart*/
        public DateTime? LockStart { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.ExclusiveLock.LockFinish*/
        public DateTime? LockFinish { get; set; }
        /*DataStructureInfo ClassBody Common.ExclusiveLock*/
    }

    [DataContract]/*DataStructureInfo ClassAttributes Common.SetLock*/
    public class SetLock/*DataStructureInfo ClassInterace Common.SetLock*/
    {
        [DataMember]/*PropertyInfo Attribute Common.SetLock.ResourceType*/
        public string ResourceType { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.SetLock.ResourceID*/
        public Guid? ResourceID { get; set; }
        /*DataStructureInfo ClassBody Common.SetLock*/
    }

    [DataContract]/*DataStructureInfo ClassAttributes Common.ReleaseLock*/
    public class ReleaseLock/*DataStructureInfo ClassInterace Common.ReleaseLock*/
    {
        [DataMember]/*PropertyInfo Attribute Common.ReleaseLock.ResourceType*/
        public string ResourceType { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.ReleaseLock.ResourceID*/
        public Guid? ResourceID { get; set; }
        /*DataStructureInfo ClassBody Common.ReleaseLock*/
    }

    [DataContract]/*DataStructureInfo ClassAttributes Common.LogReader*/
    public class LogReader : EntityBase<Common.LogReader>/*Next DataStructureInfo ClassInterace Common.LogReader*/
    {
        /// <summary>Converts the simple object to a navigation object, and copies its simple properties. Navigation properties are set to null.</summary>
        public Common.Queryable.Common_LogReader ToNavigation()
        {
            var item = this;
            return new Common.Queryable.Common_LogReader
            {
                ID = item.ID,
                UserName = item.UserName,
                Workstation = item.Workstation,
                ContextInfo = item.ContextInfo,
                Action = item.Action,
                TableName = item.TableName,
                Description = item.Description,
                ItemId = item.ItemId,
                Created = item.Created/*DataStructureInfo AssignSimpleProperty Common.LogReader*/
            };
        }

        [DataMember]/*PropertyInfo Attribute Common.LogReader.UserName*/
        public string UserName { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.LogReader.Workstation*/
        public string Workstation { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.LogReader.ContextInfo*/
        public string ContextInfo { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.LogReader.Action*/
        public string Action { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.LogReader.TableName*/
        public string TableName { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.LogReader.Description*/
        public string Description { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.LogReader.ItemId*/
        public Guid? ItemId { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.LogReader.Created*/
        public DateTime? Created { get; set; }
        /*DataStructureInfo ClassBody Common.LogReader*/
    }

    [DataContract]/*DataStructureInfo ClassAttributes Common.LogRelatedItemReader*/
    public class LogRelatedItemReader : EntityBase<Common.LogRelatedItemReader>/*Next DataStructureInfo ClassInterace Common.LogRelatedItemReader*/
    {
        /// <summary>Converts the simple object to a navigation object, and copies its simple properties. Navigation properties are set to null.</summary>
        public Common.Queryable.Common_LogRelatedItemReader ToNavigation()
        {
            var item = this;
            return new Common.Queryable.Common_LogRelatedItemReader
            {
                ID = item.ID,
                TableName = item.TableName,
                Relation = item.Relation,
                ItemId = item.ItemId,
                LogID = item.LogID/*DataStructureInfo AssignSimpleProperty Common.LogRelatedItemReader*/
            };
        }

        [DataMember]/*PropertyInfo Attribute Common.LogRelatedItemReader.TableName*/
        public string TableName { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.LogRelatedItemReader.Relation*/
        public string Relation { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.LogRelatedItemReader.ItemId*/
        public Guid? ItemId { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.LogRelatedItemReader.LogID*/
        public Guid? LogID { get; set; }
        /*DataStructureInfo ClassBody Common.LogRelatedItemReader*/
    }

    [DataContract]/*DataStructureInfo ClassAttributes Common.Log*/
    public class Log : EntityBase<Common.Log>/*Next DataStructureInfo ClassInterace Common.Log*/
    {
        /// <summary>Converts the simple object to a navigation object, and copies its simple properties. Navigation properties are set to null.</summary>
        public Common.Queryable.Common_Log ToNavigation()
        {
            var item = this;
            return new Common.Queryable.Common_Log
            {
                ID = item.ID,
                Created = item.Created,
                UserName = item.UserName,
                Workstation = item.Workstation,
                ContextInfo = item.ContextInfo,
                Action = item.Action,
                TableName = item.TableName,
                ItemId = item.ItemId,
                Description = item.Description/*DataStructureInfo AssignSimpleProperty Common.Log*/
            };
        }

        [DataMember]/*PropertyInfo Attribute Common.Log.Created*/
        public DateTime? Created { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.Log.UserName*/
        public string UserName { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.Log.Workstation*/
        public string Workstation { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.Log.ContextInfo*/
        public string ContextInfo { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.Log.Action*/
        public string Action { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.Log.TableName*/
        public string TableName { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.Log.ItemId*/
        public Guid? ItemId { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.Log.Description*/
        public string Description { get; set; }
        /*DataStructureInfo ClassBody Common.Log*/
    }

    [DataContract]/*DataStructureInfo ClassAttributes Common.AddToLog*/
    public class AddToLog/*DataStructureInfo ClassInterace Common.AddToLog*/
    {
        [DataMember]/*PropertyInfo Attribute Common.AddToLog.Action*/
        public string Action { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.AddToLog.TableName*/
        public string TableName { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.AddToLog.ItemId*/
        public Guid? ItemId { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.AddToLog.Description*/
        public string Description { get; set; }
        /*DataStructureInfo ClassBody Common.AddToLog*/
    }

    [DataContract]/*DataStructureInfo ClassAttributes Common.LogRelatedItem*/
    public class LogRelatedItem : EntityBase<Common.LogRelatedItem>/*Next DataStructureInfo ClassInterace Common.LogRelatedItem*/
    {
        /// <summary>Converts the simple object to a navigation object, and copies its simple properties. Navigation properties are set to null.</summary>
        public Common.Queryable.Common_LogRelatedItem ToNavigation()
        {
            var item = this;
            return new Common.Queryable.Common_LogRelatedItem
            {
                ID = item.ID,
                LogID = item.LogID,
                TableName = item.TableName,
                ItemId = item.ItemId,
                Relation = item.Relation/*DataStructureInfo AssignSimpleProperty Common.LogRelatedItem*/
            };
        }

        [DataMember]/*PropertyInfo Attribute Common.LogRelatedItem.LogID*/
        public Guid? LogID { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.LogRelatedItem.TableName*/
        public string TableName { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.LogRelatedItem.ItemId*/
        public Guid? ItemId { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.LogRelatedItem.Relation*/
        public string Relation { get; set; }
        /*DataStructureInfo ClassBody Common.LogRelatedItem*/
    }

    [DataContract]/*DataStructureInfo ClassAttributes Common.RelatedEventsSource*/
    public class RelatedEventsSource : EntityBase<Common.RelatedEventsSource>/*Next DataStructureInfo ClassInterace Common.RelatedEventsSource*/
    {
        /// <summary>Converts the simple object to a navigation object, and copies its simple properties. Navigation properties are set to null.</summary>
        public Common.Queryable.Common_RelatedEventsSource ToNavigation()
        {
            var item = this;
            return new Common.Queryable.Common_RelatedEventsSource
            {
                ID = item.ID,
                LogID = item.LogID,
                Relation = item.Relation,
                RelatedToTable = item.RelatedToTable,
                RelatedToItem = item.RelatedToItem,
                UserName = item.UserName,
                Workstation = item.Workstation,
                ContextInfo = item.ContextInfo,
                Action = item.Action,
                TableName = item.TableName,
                Description = item.Description,
                ItemId = item.ItemId,
                Created = item.Created/*DataStructureInfo AssignSimpleProperty Common.RelatedEventsSource*/
            };
        }

        [DataMember]/*PropertyInfo Attribute Common.RelatedEventsSource.LogID*/
        public Guid? LogID { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.RelatedEventsSource.Relation*/
        public string Relation { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.RelatedEventsSource.RelatedToTable*/
        public string RelatedToTable { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.RelatedEventsSource.RelatedToItem*/
        public Guid? RelatedToItem { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.RelatedEventsSource.UserName*/
        public string UserName { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.RelatedEventsSource.Workstation*/
        public string Workstation { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.RelatedEventsSource.ContextInfo*/
        public string ContextInfo { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.RelatedEventsSource.Action*/
        public string Action { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.RelatedEventsSource.TableName*/
        public string TableName { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.RelatedEventsSource.Description*/
        public string Description { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.RelatedEventsSource.ItemId*/
        public Guid? ItemId { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.RelatedEventsSource.Created*/
        public DateTime? Created { get; set; }
        /*DataStructureInfo ClassBody Common.RelatedEventsSource*/
    }

    [DataContract]/*DataStructureInfo ClassAttributes Common.Claim*/
    public class Claim : EntityBase<Common.Claim>, Rhetos.Dom.DefaultConcepts.IDeactivatable, Rhetos.Dom.DefaultConcepts.ICommonClaim/*Next DataStructureInfo ClassInterace Common.Claim*/
    {
        /// <summary>Converts the simple object to a navigation object, and copies its simple properties. Navigation properties are set to null.</summary>
        public Common.Queryable.Common_Claim ToNavigation()
        {
            var item = this;
            return new Common.Queryable.Common_Claim
            {
                ID = item.ID,
                ClaimResource = item.ClaimResource,
                ClaimRight = item.ClaimRight,
                Active = item.Active/*DataStructureInfo AssignSimpleProperty Common.Claim*/
            };
        }

        [DataMember]/*PropertyInfo Attribute Common.Claim.ClaimResource*/
        public string ClaimResource { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.Claim.ClaimRight*/
        public string ClaimRight { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.Claim.Active*/
        public bool? Active { get; set; }
        /*DataStructureInfo ClassBody Common.Claim*/
    }

    [DataContract]/*DataStructureInfo ClassAttributes Common.MyClaim*/
    public class MyClaim : EntityBase<Common.MyClaim>/*Next DataStructureInfo ClassInterace Common.MyClaim*/
    {
        /// <summary>Converts the simple object to a navigation object, and copies its simple properties. Navigation properties are set to null.</summary>
        public Common.Queryable.Common_MyClaim ToNavigation()
        {
            var item = this;
            return new Common.Queryable.Common_MyClaim
            {
                ID = item.ID,
                Applies = item.Applies/*DataStructureInfo AssignSimpleProperty Common.MyClaim*/
            };
        }

        [DataMember]/*PropertyInfo Attribute Common.MyClaim.Applies*/
        public bool? Applies { get; set; }
        /*DataStructureInfo ClassBody Common.MyClaim*/
    }

    [DataContract]/*DataStructureInfo ClassAttributes Common.Principal*/
    public class Principal : EntityBase<Common.Principal>, Rhetos.Dom.DefaultConcepts.IPrincipal/*Next DataStructureInfo ClassInterace Common.Principal*/
    {
        /// <summary>Converts the simple object to a navigation object, and copies its simple properties. Navigation properties are set to null.</summary>
        public Common.Queryable.Common_Principal ToNavigation()
        {
            var item = this;
            return new Common.Queryable.Common_Principal
            {
                ID = item.ID,
                Name = item.Name/*DataStructureInfo AssignSimpleProperty Common.Principal*/
            };
        }

        [DataMember]/*PropertyInfo Attribute Common.Principal.Name*/
        public string Name { get; set; }
        /*DataStructureInfo ClassBody Common.Principal*/
    }

    [DataContract]/*DataStructureInfo ClassAttributes Common.PrincipalHasRole*/
    public class PrincipalHasRole : EntityBase<Common.PrincipalHasRole>, Rhetos.Dom.DefaultConcepts.IPrincipalHasRole/*Next DataStructureInfo ClassInterace Common.PrincipalHasRole*/
    {
        /// <summary>Converts the simple object to a navigation object, and copies its simple properties. Navigation properties are set to null.</summary>
        public Common.Queryable.Common_PrincipalHasRole ToNavigation()
        {
            var item = this;
            return new Common.Queryable.Common_PrincipalHasRole
            {
                ID = item.ID,
                PrincipalID = item.PrincipalID,
                RoleID = item.RoleID/*DataStructureInfo AssignSimpleProperty Common.PrincipalHasRole*/
            };
        }

        [DataMember]/*PropertyInfo Attribute Common.PrincipalHasRole.PrincipalID*/
        public Guid? PrincipalID { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.PrincipalHasRole.RoleID*/
        public Guid? RoleID { get; set; }
        /*DataStructureInfo ClassBody Common.PrincipalHasRole*/
    }

    [DataContract]/*DataStructureInfo ClassAttributes Common.Role*/
    public class Role : EntityBase<Common.Role>, Rhetos.Dom.DefaultConcepts.IRole/*Next DataStructureInfo ClassInterace Common.Role*/
    {
        /// <summary>Converts the simple object to a navigation object, and copies its simple properties. Navigation properties are set to null.</summary>
        public Common.Queryable.Common_Role ToNavigation()
        {
            var item = this;
            return new Common.Queryable.Common_Role
            {
                ID = item.ID,
                Name = item.Name/*DataStructureInfo AssignSimpleProperty Common.Role*/
            };
        }

        [DataMember]/*PropertyInfo Attribute Common.Role.Name*/
        public string Name { get; set; }
        /*DataStructureInfo ClassBody Common.Role*/
    }

    [DataContract]/*DataStructureInfo ClassAttributes Common.RoleInheritsRole*/
    public class RoleInheritsRole : EntityBase<Common.RoleInheritsRole>, Rhetos.Dom.DefaultConcepts.IRoleInheritsRole/*Next DataStructureInfo ClassInterace Common.RoleInheritsRole*/
    {
        /// <summary>Converts the simple object to a navigation object, and copies its simple properties. Navigation properties are set to null.</summary>
        public Common.Queryable.Common_RoleInheritsRole ToNavigation()
        {
            var item = this;
            return new Common.Queryable.Common_RoleInheritsRole
            {
                ID = item.ID,
                UsersFromID = item.UsersFromID,
                PermissionsFromID = item.PermissionsFromID/*DataStructureInfo AssignSimpleProperty Common.RoleInheritsRole*/
            };
        }

        [DataMember]/*PropertyInfo Attribute Common.RoleInheritsRole.UsersFromID*/
        public Guid? UsersFromID { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.RoleInheritsRole.PermissionsFromID*/
        public Guid? PermissionsFromID { get; set; }
        /*DataStructureInfo ClassBody Common.RoleInheritsRole*/
    }

    [DataContract]/*DataStructureInfo ClassAttributes Common.PrincipalPermission*/
    public class PrincipalPermission : EntityBase<Common.PrincipalPermission>, Rhetos.Dom.DefaultConcepts.IPrincipalPermission/*Next DataStructureInfo ClassInterace Common.PrincipalPermission*/
    {
        /// <summary>Converts the simple object to a navigation object, and copies its simple properties. Navigation properties are set to null.</summary>
        public Common.Queryable.Common_PrincipalPermission ToNavigation()
        {
            var item = this;
            return new Common.Queryable.Common_PrincipalPermission
            {
                ID = item.ID,
                PrincipalID = item.PrincipalID,
                ClaimID = item.ClaimID,
                IsAuthorized = item.IsAuthorized/*DataStructureInfo AssignSimpleProperty Common.PrincipalPermission*/
            };
        }

        [DataMember]/*PropertyInfo Attribute Common.PrincipalPermission.PrincipalID*/
        public Guid? PrincipalID { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.PrincipalPermission.ClaimID*/
        public Guid? ClaimID { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.PrincipalPermission.IsAuthorized*/
        public bool? IsAuthorized { get; set; }
        /*DataStructureInfo ClassBody Common.PrincipalPermission*/
    }

    [DataContract]/*DataStructureInfo ClassAttributes Common.RolePermission*/
    public class RolePermission : EntityBase<Common.RolePermission>, Rhetos.Dom.DefaultConcepts.IRolePermission/*Next DataStructureInfo ClassInterace Common.RolePermission*/
    {
        /// <summary>Converts the simple object to a navigation object, and copies its simple properties. Navigation properties are set to null.</summary>
        public Common.Queryable.Common_RolePermission ToNavigation()
        {
            var item = this;
            return new Common.Queryable.Common_RolePermission
            {
                ID = item.ID,
                RoleID = item.RoleID,
                ClaimID = item.ClaimID,
                IsAuthorized = item.IsAuthorized/*DataStructureInfo AssignSimpleProperty Common.RolePermission*/
            };
        }

        [DataMember]/*PropertyInfo Attribute Common.RolePermission.RoleID*/
        public Guid? RoleID { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.RolePermission.ClaimID*/
        public Guid? ClaimID { get; set; }
        [DataMember]/*PropertyInfo Attribute Common.RolePermission.IsAuthorized*/
        public bool? IsAuthorized { get; set; }
        /*DataStructureInfo ClassBody Common.RolePermission*/
    }

    [DataContract]/*DataStructureInfo ClassAttributes Common.RowPermissionsReadItems*/
    public class RowPermissionsReadItems/*DataStructureInfo ClassInterace Common.RowPermissionsReadItems*/
    {
        /*DataStructureInfo ClassBody Common.RowPermissionsReadItems*/
    }

    [DataContract]/*DataStructureInfo ClassAttributes Common.RowPermissionsWriteItems*/
    public class RowPermissionsWriteItems/*DataStructureInfo ClassInterace Common.RowPermissionsWriteItems*/
    {
        /*DataStructureInfo ClassBody Common.RowPermissionsWriteItems*/
    }

    [DataContract]/*DataStructureInfo ClassAttributes Common.SystemRequiredActive*/
    public class SystemRequiredActive/*DataStructureInfo ClassInterace Common.SystemRequiredActive*/
    {
        /*DataStructureInfo ClassBody Common.SystemRequiredActive*/
    }

    [DataContract]/*DataStructureInfo ClassAttributes Common.SystemRequiredLog*/
    public class SystemRequiredLog/*DataStructureInfo ClassInterace Common.SystemRequiredLog*/
    {
        /*DataStructureInfo ClassBody Common.SystemRequiredLog*/
    }

    [DataContract]/*DataStructureInfo ClassAttributes Common.SystemRequiredPrincipal*/
    public class SystemRequiredPrincipal/*DataStructureInfo ClassInterace Common.SystemRequiredPrincipal*/
    {
        /*DataStructureInfo ClassBody Common.SystemRequiredPrincipal*/
    }

    [DataContract]/*DataStructureInfo ClassAttributes Common.SystemRequiredUsersFrom*/
    public class SystemRequiredUsersFrom/*DataStructureInfo ClassInterace Common.SystemRequiredUsersFrom*/
    {
        /*DataStructureInfo ClassBody Common.SystemRequiredUsersFrom*/
    }

    [DataContract]/*DataStructureInfo ClassAttributes Common.SystemRequiredClaim*/
    public class SystemRequiredClaim/*DataStructureInfo ClassInterace Common.SystemRequiredClaim*/
    {
        /*DataStructureInfo ClassBody Common.SystemRequiredClaim*/
    }

    [DataContract]/*DataStructureInfo ClassAttributes Common.SystemRequiredRole*/
    public class SystemRequiredRole/*DataStructureInfo ClassInterace Common.SystemRequiredRole*/
    {
        /*DataStructureInfo ClassBody Common.SystemRequiredRole*/
    }

    /*ModuleInfo Body Common*/
}

/*SimpleClasses*/

namespace Common.Queryable
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;
    using Rhetos.Dom.DefaultConcepts;
    using Rhetos.Utilities;

    /*DataStructureInfo QueryableClassAttributes Hoteli.Hotel*/
    public class Hoteli_Hotel : global::Hoteli.Hotel, IQueryableEntity<Hoteli.Hotel>, System.IEquatable<Hoteli_Hotel>, IDetachOverride/*DataStructureInfo QueryableClassInterace Hoteli.Hotel*/
    {
        bool IDetachOverride.Detaching { get; set; }

        /// <summary>Converts the object with navigation properties to a simple object with primitive properties.</summary>
        public Hoteli.Hotel ToSimple()
        {
            var item = this;
            return new Hoteli.Hotel
            {
                ID = item.ID,
                Code = item.Code,
                Name = item.Name,
                Address = item.Address/*DataStructureInfo AssignSimpleProperty Hoteli.Hotel*/
            };
        }

        private Common.Queryable.Hoteli_Location _extension_Location;

        /*DataStructureQueryable PropertyAttribute Hoteli.Hotel.Extension_Location*/
        public virtual Common.Queryable.Hoteli_Location Extension_Location
        {
            get
            {
                /*DataStructureQueryable Getter Hoteli.Hotel.Extension_Location*/
                return _extension_Location;
            }
            set
            {
                if (((IDetachOverride)this).Detaching) return;
                /*DataStructureQueryable Setter Hoteli.Hotel.Extension_Location*/
                _extension_Location = value;
            }
        }

        /*DataStructureInfo QueryableClassMembers Hoteli.Hotel*/

        public bool Equals(Hoteli_Hotel other)
        {
            return other != null && other.ID == ID;
        }
    }

    /*DataStructureInfo QueryableClassAttributes Hoteli.Location*/
    public class Hoteli_Location : global::Hoteli.Location, IQueryableEntity<Hoteli.Location>, System.IEquatable<Hoteli_Location>, IDetachOverride/*DataStructureInfo QueryableClassInterace Hoteli.Location*/
    {
        bool IDetachOverride.Detaching { get; set; }

        /// <summary>Converts the object with navigation properties to a simple object with primitive properties.</summary>
        public Hoteli.Location ToSimple()
        {
            var item = this;
            return new Hoteli.Location
            {
                ID = item.ID,
                Code = item.Code,
                Country = item.Country,
                County = item.County,
                City = item.City,
                Area = item.Area/*DataStructureInfo AssignSimpleProperty Hoteli.Location*/
            };
        }

        private Common.Queryable.Hoteli_Hotel _base;

        /*DataStructureQueryable PropertyAttribute Hoteli.Location.Base*/
        public virtual Common.Queryable.Hoteli_Hotel Base
        {
            get
            {
                /*DataStructureQueryable Getter Hoteli.Location.Base*/
                return _base;
            }
            set
            {
                if (((IDetachOverride)this).Detaching) return;
                /*DataStructureQueryable Setter Hoteli.Location.Base*/
                _base = value;
                ID = value != null ? value.ID : Guid.Empty;
            }
        }

        /*DataStructureInfo QueryableClassMembers Hoteli.Location*/

        public bool Equals(Hoteli_Location other)
        {
            return other != null && other.ID == ID;
        }
    }

    /*DataStructureInfo QueryableClassAttributes Hoteli.RoomReservation*/
    public class Hoteli_RoomReservation : global::Hoteli.RoomReservation, IQueryableEntity<Hoteli.RoomReservation>, System.IEquatable<Hoteli_RoomReservation>, IDetachOverride/*DataStructureInfo QueryableClassInterace Hoteli.RoomReservation*/
    {
        bool IDetachOverride.Detaching { get; set; }

        /// <summary>Converts the object with navigation properties to a simple object with primitive properties.</summary>
        public Hoteli.RoomReservation ToSimple()
        {
            var item = this;
            return new Hoteli.RoomReservation
            {
                ID = item.ID,
                Code = item.Code,
                ReservationHotelID = item.ReservationHotelID,
                ReservationRoomID = item.ReservationRoomID/*DataStructureInfo AssignSimpleProperty Hoteli.RoomReservation*/
            };
        }

        private Common.Queryable.Hoteli_Reservation _reservationHotel;

        /*DataStructureQueryable PropertyAttribute Hoteli.RoomReservation.ReservationHotel*/
        public virtual Common.Queryable.Hoteli_Reservation ReservationHotel
        {
            get
            {
                /*DataStructureQueryable Getter Hoteli.RoomReservation.ReservationHotel*/
                return _reservationHotel;
            }
            set
            {
                if (((IDetachOverride)this).Detaching) return;
                /*DataStructureQueryable Setter Hoteli.RoomReservation.ReservationHotel*/
                _reservationHotel = value;
                ReservationHotelID = value != null ? (Guid?)value.ID : null;
            }
        }

        private Common.Queryable.Hoteli_Rooms _reservationRoom;

        /*DataStructureQueryable PropertyAttribute Hoteli.RoomReservation.ReservationRoom*/
        public virtual Common.Queryable.Hoteli_Rooms ReservationRoom
        {
            get
            {
                /*DataStructureQueryable Getter Hoteli.RoomReservation.ReservationRoom*/
                return _reservationRoom;
            }
            set
            {
                if (((IDetachOverride)this).Detaching) return;
                /*DataStructureQueryable Setter Hoteli.RoomReservation.ReservationRoom*/
                _reservationRoom = value;
                ReservationRoomID = value != null ? (Guid?)value.ID : null;
            }
        }

        /*DataStructureInfo QueryableClassMembers Hoteli.RoomReservation*/

        public bool Equals(Hoteli_RoomReservation other)
        {
            return other != null && other.ID == ID;
        }
    }

    /*DataStructureInfo QueryableClassAttributes Hoteli.Reservation*/
    public class Hoteli_Reservation : global::Hoteli.Reservation, IQueryableEntity<Hoteli.Reservation>, System.IEquatable<Hoteli_Reservation>, IDetachOverride/*DataStructureInfo QueryableClassInterace Hoteli.Reservation*/
    {
        bool IDetachOverride.Detaching { get; set; }

        /// <summary>Converts the object with navigation properties to a simple object with primitive properties.</summary>
        public Hoteli.Reservation ToSimple()
        {
            var item = this;
            return new Hoteli.Reservation
            {
                ID = item.ID,
                Code = item.Code,
                DateFrom = item.DateFrom,
                DateTo = item.DateTo,
                NumberOfPeople = item.NumberOfPeople,
                GuestID = item.GuestID/*DataStructureInfo AssignSimpleProperty Hoteli.Reservation*/
            };
        }

        private Common.Queryable.Hoteli_Person _guest;

        /*DataStructureQueryable PropertyAttribute Hoteli.Reservation.Guest*/
        public virtual Common.Queryable.Hoteli_Person Guest
        {
            get
            {
                /*DataStructureQueryable Getter Hoteli.Reservation.Guest*/
                return _guest;
            }
            set
            {
                if (((IDetachOverride)this).Detaching) return;
                /*DataStructureQueryable Setter Hoteli.Reservation.Guest*/
                _guest = value;
                GuestID = value != null ? (Guid?)value.ID : null;
            }
        }

        /*DataStructureInfo QueryableClassMembers Hoteli.Reservation*/

        public bool Equals(Hoteli_Reservation other)
        {
            return other != null && other.ID == ID;
        }
    }

    /*DataStructureInfo QueryableClassAttributes Hoteli.Rooms*/
    public class Hoteli_Rooms : global::Hoteli.Rooms, IQueryableEntity<Hoteli.Rooms>, System.IEquatable<Hoteli_Rooms>, IDetachOverride/*DataStructureInfo QueryableClassInterace Hoteli.Rooms*/
    {
        bool IDetachOverride.Detaching { get; set; }

        /// <summary>Converts the object with navigation properties to a simple object with primitive properties.</summary>
        public Hoteli.Rooms ToSimple()
        {
            var item = this;
            return new Hoteli.Rooms
            {
                ID = item.ID,
                Code = item.Code,
                NumberOfPeople = item.NumberOfPeople,
                RoomOfHotelID = item.RoomOfHotelID,
                TypeOfRoom = item.TypeOfRoom/*DataStructureInfo AssignSimpleProperty Hoteli.Rooms*/
            };
        }

        private Common.Queryable.Hoteli_Hotel _roomOfHotel;

        /*DataStructureQueryable PropertyAttribute Hoteli.Rooms.RoomOfHotel*/
        public virtual Common.Queryable.Hoteli_Hotel RoomOfHotel
        {
            get
            {
                /*DataStructureQueryable Getter Hoteli.Rooms.RoomOfHotel*/
                return _roomOfHotel;
            }
            set
            {
                if (((IDetachOverride)this).Detaching) return;
                /*DataStructureQueryable Setter Hoteli.Rooms.RoomOfHotel*/
                _roomOfHotel = value;
                RoomOfHotelID = value != null ? (Guid?)value.ID : null;
            }
        }

        private Common.Queryable.Hoteli_ReservationInfo _extension_ReservationInfo;

        /*DataStructureQueryable PropertyAttribute Hoteli.Rooms.Extension_ReservationInfo*/
        public virtual Common.Queryable.Hoteli_ReservationInfo Extension_ReservationInfo
        {
            get
            {
                /*DataStructureQueryable Getter Hoteli.Rooms.Extension_ReservationInfo*/
                return _extension_ReservationInfo;
            }
            set
            {
                if (((IDetachOverride)this).Detaching) return;
                /*DataStructureQueryable Setter Hoteli.Rooms.Extension_ReservationInfo*/
                _extension_ReservationInfo = value;
            }
        }

        /*DataStructureInfo QueryableClassMembers Hoteli.Rooms*/

        public bool Equals(Hoteli_Rooms other)
        {
            return other != null && other.ID == ID;
        }
    }

    /*DataStructureInfo QueryableClassAttributes Hoteli.Person*/
    public class Hoteli_Person : global::Hoteli.Person, IQueryableEntity<Hoteli.Person>, System.IEquatable<Hoteli_Person>, IDetachOverride/*DataStructureInfo QueryableClassInterace Hoteli.Person*/
    {
        bool IDetachOverride.Detaching { get; set; }

        /// <summary>Converts the object with navigation properties to a simple object with primitive properties.</summary>
        public Hoteli.Person ToSimple()
        {
            var item = this;
            return new Hoteli.Person
            {
                ID = item.ID,
                Code = item.Code,
                Identifier = item.Identifier,
                Name = item.Name,
                Surname = item.Surname,
                Address = item.Address,
                isGuest = item.isGuest,
                isEmployee = item.isEmployee,
                isOwner = item.isOwner,
                Discount = item.Discount/*DataStructureInfo AssignSimpleProperty Hoteli.Person*/
            };
        }

        /*DataStructureInfo QueryableClassMembers Hoteli.Person*/

        public bool Equals(Hoteli_Person other)
        {
            return other != null && other.ID == ID;
        }
    }

    /*DataStructureInfo QueryableClassAttributes Hoteli.SaloonPerson*/
    public class Hoteli_SaloonPerson : global::Hoteli.SaloonPerson, IQueryableEntity<Hoteli.SaloonPerson>, System.IEquatable<Hoteli_SaloonPerson>, IDetachOverride/*DataStructureInfo QueryableClassInterace Hoteli.SaloonPerson*/
    {
        bool IDetachOverride.Detaching { get; set; }

        /// <summary>Converts the object with navigation properties to a simple object with primitive properties.</summary>
        public Hoteli.SaloonPerson ToSimple()
        {
            var item = this;
            return new Hoteli.SaloonPerson
            {
                ID = item.ID,
                Code = item.Code,
                OwnerNameID = item.OwnerNameID,
                SalonID = item.SalonID/*DataStructureInfo AssignSimpleProperty Hoteli.SaloonPerson*/
            };
        }

        private Common.Queryable.Hoteli_Person _ownerName;

        /*DataStructureQueryable PropertyAttribute Hoteli.SaloonPerson.OwnerName*/
        public virtual Common.Queryable.Hoteli_Person OwnerName
        {
            get
            {
                /*DataStructureQueryable Getter Hoteli.SaloonPerson.OwnerName*/
                return _ownerName;
            }
            set
            {
                if (((IDetachOverride)this).Detaching) return;
                /*DataStructureQueryable Setter Hoteli.SaloonPerson.OwnerName*/
                _ownerName = value;
                OwnerNameID = value != null ? (Guid?)value.ID : null;
            }
        }

        private Common.Queryable.Hoteli_Saloon _salon;

        /*DataStructureQueryable PropertyAttribute Hoteli.SaloonPerson.Salon*/
        public virtual Common.Queryable.Hoteli_Saloon Salon
        {
            get
            {
                /*DataStructureQueryable Getter Hoteli.SaloonPerson.Salon*/
                return _salon;
            }
            set
            {
                if (((IDetachOverride)this).Detaching) return;
                /*DataStructureQueryable Setter Hoteli.SaloonPerson.Salon*/
                _salon = value;
                SalonID = value != null ? (Guid?)value.ID : null;
            }
        }

        /*DataStructureInfo QueryableClassMembers Hoteli.SaloonPerson*/

        public bool Equals(Hoteli_SaloonPerson other)
        {
            return other != null && other.ID == ID;
        }
    }

    /*DataStructureInfo QueryableClassAttributes Hoteli.SaloonHotel*/
    public class Hoteli_SaloonHotel : global::Hoteli.SaloonHotel, IQueryableEntity<Hoteli.SaloonHotel>, System.IEquatable<Hoteli_SaloonHotel>, IDetachOverride/*DataStructureInfo QueryableClassInterace Hoteli.SaloonHotel*/
    {
        bool IDetachOverride.Detaching { get; set; }

        /// <summary>Converts the object with navigation properties to a simple object with primitive properties.</summary>
        public Hoteli.SaloonHotel ToSimple()
        {
            var item = this;
            return new Hoteli.SaloonHotel
            {
                ID = item.ID,
                Code = item.Code,
                OwnerNameID = item.OwnerNameID,
                SalonID = item.SalonID/*DataStructureInfo AssignSimpleProperty Hoteli.SaloonHotel*/
            };
        }

        private Common.Queryable.Hoteli_Hotel _ownerName;

        /*DataStructureQueryable PropertyAttribute Hoteli.SaloonHotel.OwnerName*/
        public virtual Common.Queryable.Hoteli_Hotel OwnerName
        {
            get
            {
                /*DataStructureQueryable Getter Hoteli.SaloonHotel.OwnerName*/
                return _ownerName;
            }
            set
            {
                if (((IDetachOverride)this).Detaching) return;
                /*DataStructureQueryable Setter Hoteli.SaloonHotel.OwnerName*/
                _ownerName = value;
                OwnerNameID = value != null ? (Guid?)value.ID : null;
            }
        }

        private Common.Queryable.Hoteli_Saloon _salon;

        /*DataStructureQueryable PropertyAttribute Hoteli.SaloonHotel.Salon*/
        public virtual Common.Queryable.Hoteli_Saloon Salon
        {
            get
            {
                /*DataStructureQueryable Getter Hoteli.SaloonHotel.Salon*/
                return _salon;
            }
            set
            {
                if (((IDetachOverride)this).Detaching) return;
                /*DataStructureQueryable Setter Hoteli.SaloonHotel.Salon*/
                _salon = value;
                SalonID = value != null ? (Guid?)value.ID : null;
            }
        }

        /*DataStructureInfo QueryableClassMembers Hoteli.SaloonHotel*/

        public bool Equals(Hoteli_SaloonHotel other)
        {
            return other != null && other.ID == ID;
        }
    }

    /*DataStructureInfo QueryableClassAttributes Hoteli.Saloon*/
    public class Hoteli_Saloon : global::Hoteli.Saloon, IQueryableEntity<Hoteli.Saloon>, System.IEquatable<Hoteli_Saloon>, IDetachOverride/*DataStructureInfo QueryableClassInterace Hoteli.Saloon*/
    {
        bool IDetachOverride.Detaching { get; set; }

        /// <summary>Converts the object with navigation properties to a simple object with primitive properties.</summary>
        public Hoteli.Saloon ToSimple()
        {
            var item = this;
            return new Hoteli.Saloon
            {
                ID = item.ID,
                Code = item.Code,
                Name = item.Name,
                HotelSaloonID = item.HotelSaloonID/*DataStructureInfo AssignSimpleProperty Hoteli.Saloon*/
            };
        }

        private Common.Queryable.Hoteli_Hotel _hotelSaloon;

        /*DataStructureQueryable PropertyAttribute Hoteli.Saloon.HotelSaloon*/
        public virtual Common.Queryable.Hoteli_Hotel HotelSaloon
        {
            get
            {
                /*DataStructureQueryable Getter Hoteli.Saloon.HotelSaloon*/
                return _hotelSaloon;
            }
            set
            {
                if (((IDetachOverride)this).Detaching) return;
                /*DataStructureQueryable Setter Hoteli.Saloon.HotelSaloon*/
                _hotelSaloon = value;
                HotelSaloonID = value != null ? (Guid?)value.ID : null;
            }
        }

        /*DataStructureInfo QueryableClassMembers Hoteli.Saloon*/

        public bool Equals(Hoteli_Saloon other)
        {
            return other != null && other.ID == ID;
        }
    }

    /*DataStructureInfo QueryableClassAttributes Hoteli.ProductPerson*/
    public class Hoteli_ProductPerson : global::Hoteli.ProductPerson, IQueryableEntity<Hoteli.ProductPerson>, System.IEquatable<Hoteli_ProductPerson>, IDetachOverride/*DataStructureInfo QueryableClassInterace Hoteli.ProductPerson*/
    {
        bool IDetachOverride.Detaching { get; set; }

        /// <summary>Converts the object with navigation properties to a simple object with primitive properties.</summary>
        public Hoteli.ProductPerson ToSimple()
        {
            var item = this;
            return new Hoteli.ProductPerson
            {
                ID = item.ID,
                Code = item.Code,
                OwnerNameID = item.OwnerNameID,
                ProductID = item.ProductID/*DataStructureInfo AssignSimpleProperty Hoteli.ProductPerson*/
            };
        }

        private Common.Queryable.Hoteli_Person _ownerName;

        /*DataStructureQueryable PropertyAttribute Hoteli.ProductPerson.OwnerName*/
        public virtual Common.Queryable.Hoteli_Person OwnerName
        {
            get
            {
                /*DataStructureQueryable Getter Hoteli.ProductPerson.OwnerName*/
                return _ownerName;
            }
            set
            {
                if (((IDetachOverride)this).Detaching) return;
                /*DataStructureQueryable Setter Hoteli.ProductPerson.OwnerName*/
                _ownerName = value;
                OwnerNameID = value != null ? (Guid?)value.ID : null;
            }
        }

        private Common.Queryable.Hoteli_Product _product;

        /*DataStructureQueryable PropertyAttribute Hoteli.ProductPerson.Product*/
        public virtual Common.Queryable.Hoteli_Product Product
        {
            get
            {
                /*DataStructureQueryable Getter Hoteli.ProductPerson.Product*/
                return _product;
            }
            set
            {
                if (((IDetachOverride)this).Detaching) return;
                /*DataStructureQueryable Setter Hoteli.ProductPerson.Product*/
                _product = value;
                ProductID = value != null ? (Guid?)value.ID : null;
            }
        }

        /*DataStructureInfo QueryableClassMembers Hoteli.ProductPerson*/

        public bool Equals(Hoteli_ProductPerson other)
        {
            return other != null && other.ID == ID;
        }
    }

    /*DataStructureInfo QueryableClassAttributes Hoteli.ProductHotel*/
    public class Hoteli_ProductHotel : global::Hoteli.ProductHotel, IQueryableEntity<Hoteli.ProductHotel>, System.IEquatable<Hoteli_ProductHotel>, IDetachOverride/*DataStructureInfo QueryableClassInterace Hoteli.ProductHotel*/
    {
        bool IDetachOverride.Detaching { get; set; }

        /// <summary>Converts the object with navigation properties to a simple object with primitive properties.</summary>
        public Hoteli.ProductHotel ToSimple()
        {
            var item = this;
            return new Hoteli.ProductHotel
            {
                ID = item.ID,
                Code = item.Code,
                OwnerNameID = item.OwnerNameID,
                ProductID = item.ProductID/*DataStructureInfo AssignSimpleProperty Hoteli.ProductHotel*/
            };
        }

        private Common.Queryable.Hoteli_Hotel _ownerName;

        /*DataStructureQueryable PropertyAttribute Hoteli.ProductHotel.OwnerName*/
        public virtual Common.Queryable.Hoteli_Hotel OwnerName
        {
            get
            {
                /*DataStructureQueryable Getter Hoteli.ProductHotel.OwnerName*/
                return _ownerName;
            }
            set
            {
                if (((IDetachOverride)this).Detaching) return;
                /*DataStructureQueryable Setter Hoteli.ProductHotel.OwnerName*/
                _ownerName = value;
                OwnerNameID = value != null ? (Guid?)value.ID : null;
            }
        }

        private Common.Queryable.Hoteli_Product _product;

        /*DataStructureQueryable PropertyAttribute Hoteli.ProductHotel.Product*/
        public virtual Common.Queryable.Hoteli_Product Product
        {
            get
            {
                /*DataStructureQueryable Getter Hoteli.ProductHotel.Product*/
                return _product;
            }
            set
            {
                if (((IDetachOverride)this).Detaching) return;
                /*DataStructureQueryable Setter Hoteli.ProductHotel.Product*/
                _product = value;
                ProductID = value != null ? (Guid?)value.ID : null;
            }
        }

        /*DataStructureInfo QueryableClassMembers Hoteli.ProductHotel*/

        public bool Equals(Hoteli_ProductHotel other)
        {
            return other != null && other.ID == ID;
        }
    }

    /*DataStructureInfo QueryableClassAttributes Hoteli.Product*/
    public class Hoteli_Product : global::Hoteli.Product, IQueryableEntity<Hoteli.Product>, System.IEquatable<Hoteli_Product>, IDetachOverride/*DataStructureInfo QueryableClassInterace Hoteli.Product*/
    {
        bool IDetachOverride.Detaching { get; set; }

        /// <summary>Converts the object with navigation properties to a simple object with primitive properties.</summary>
        public Hoteli.Product ToSimple()
        {
            var item = this;
            return new Hoteli.Product
            {
                ID = item.ID,
                Code = item.Code,
                Title = item.Title,
                HotelSaloonID = item.HotelSaloonID/*DataStructureInfo AssignSimpleProperty Hoteli.Product*/
            };
        }

        private Common.Queryable.Hoteli_Hotel _hotelSaloon;

        /*DataStructureQueryable PropertyAttribute Hoteli.Product.HotelSaloon*/
        public virtual Common.Queryable.Hoteli_Hotel HotelSaloon
        {
            get
            {
                /*DataStructureQueryable Getter Hoteli.Product.HotelSaloon*/
                return _hotelSaloon;
            }
            set
            {
                if (((IDetachOverride)this).Detaching) return;
                /*DataStructureQueryable Setter Hoteli.Product.HotelSaloon*/
                _hotelSaloon = value;
                HotelSaloonID = value != null ? (Guid?)value.ID : null;
            }
        }

        /*DataStructureInfo QueryableClassMembers Hoteli.Product*/

        public bool Equals(Hoteli_Product other)
        {
            return other != null && other.ID == ID;
        }
    }

    /*DataStructureInfo QueryableClassAttributes Hoteli.ReservationInfo*/
    public class Hoteli_ReservationInfo : global::Hoteli.ReservationInfo, IQueryableEntity<Hoteli.ReservationInfo>, System.IEquatable<Hoteli_ReservationInfo>, IDetachOverride/*DataStructureInfo QueryableClassInterace Hoteli.ReservationInfo*/
    {
        bool IDetachOverride.Detaching { get; set; }

        /// <summary>Converts the object with navigation properties to a simple object with primitive properties.</summary>
        public Hoteli.ReservationInfo ToSimple()
        {
            var item = this;
            return new Hoteli.ReservationInfo
            {
                ID = item.ID,
                NumberOfRooms = item.NumberOfRooms/*DataStructureInfo AssignSimpleProperty Hoteli.ReservationInfo*/
            };
        }

        private Common.Queryable.Hoteli_Rooms _base;

        /*DataStructureQueryable PropertyAttribute Hoteli.ReservationInfo.Base*/
        public virtual Common.Queryable.Hoteli_Rooms Base
        {
            get
            {
                /*DataStructureQueryable Getter Hoteli.ReservationInfo.Base*/
                return _base;
            }
            set
            {
                if (((IDetachOverride)this).Detaching) return;
                /*DataStructureQueryable Setter Hoteli.ReservationInfo.Base*/
                _base = value;
                ID = value != null ? value.ID : Guid.Empty;
            }
        }

        /*DataStructureInfo QueryableClassMembers Hoteli.ReservationInfo*/

        public bool Equals(Hoteli_ReservationInfo other)
        {
            return other != null && other.ID == ID;
        }
    }

    /*DataStructureInfo QueryableClassAttributes Common.AutoCodeCache*/
    public class Common_AutoCodeCache : global::Common.AutoCodeCache, IQueryableEntity<Common.AutoCodeCache>, System.IEquatable<Common_AutoCodeCache>, IDetachOverride/*DataStructureInfo QueryableClassInterace Common.AutoCodeCache*/
    {
        bool IDetachOverride.Detaching { get; set; }

        /// <summary>Converts the object with navigation properties to a simple object with primitive properties.</summary>
        public Common.AutoCodeCache ToSimple()
        {
            var item = this;
            return new Common.AutoCodeCache
            {
                ID = item.ID,
                Entity = item.Entity,
                Property = item.Property,
                Grouping = item.Grouping,
                Prefix = item.Prefix,
                MinDigits = item.MinDigits,
                LastCode = item.LastCode/*DataStructureInfo AssignSimpleProperty Common.AutoCodeCache*/
            };
        }

        /*DataStructureInfo QueryableClassMembers Common.AutoCodeCache*/

        public bool Equals(Common_AutoCodeCache other)
        {
            return other != null && other.ID == ID;
        }
    }

    /*DataStructureInfo QueryableClassAttributes Common.FilterId*/
    public class Common_FilterId : global::Common.FilterId, IQueryableEntity<Common.FilterId>, System.IEquatable<Common_FilterId>, IDetachOverride/*DataStructureInfo QueryableClassInterace Common.FilterId*/
    {
        bool IDetachOverride.Detaching { get; set; }

        /// <summary>Converts the object with navigation properties to a simple object with primitive properties.</summary>
        public Common.FilterId ToSimple()
        {
            var item = this;
            return new Common.FilterId
            {
                ID = item.ID,
                Handle = item.Handle,
                Value = item.Value/*DataStructureInfo AssignSimpleProperty Common.FilterId*/
            };
        }

        /*DataStructureInfo QueryableClassMembers Common.FilterId*/

        public bool Equals(Common_FilterId other)
        {
            return other != null && other.ID == ID;
        }
    }

    /*DataStructureInfo QueryableClassAttributes Common.KeepSynchronizedMetadata*/
    public class Common_KeepSynchronizedMetadata : global::Common.KeepSynchronizedMetadata, IQueryableEntity<Common.KeepSynchronizedMetadata>, System.IEquatable<Common_KeepSynchronizedMetadata>, IDetachOverride/*DataStructureInfo QueryableClassInterace Common.KeepSynchronizedMetadata*/
    {
        bool IDetachOverride.Detaching { get; set; }

        /// <summary>Converts the object with navigation properties to a simple object with primitive properties.</summary>
        public Common.KeepSynchronizedMetadata ToSimple()
        {
            var item = this;
            return new Common.KeepSynchronizedMetadata
            {
                ID = item.ID,
                Target = item.Target,
                Source = item.Source,
                Context = item.Context/*DataStructureInfo AssignSimpleProperty Common.KeepSynchronizedMetadata*/
            };
        }

        /*DataStructureInfo QueryableClassMembers Common.KeepSynchronizedMetadata*/

        public bool Equals(Common_KeepSynchronizedMetadata other)
        {
            return other != null && other.ID == ID;
        }
    }

    /*DataStructureInfo QueryableClassAttributes Common.ExclusiveLock*/
    public class Common_ExclusiveLock : global::Common.ExclusiveLock, IQueryableEntity<Common.ExclusiveLock>, System.IEquatable<Common_ExclusiveLock>, IDetachOverride/*DataStructureInfo QueryableClassInterace Common.ExclusiveLock*/
    {
        bool IDetachOverride.Detaching { get; set; }

        /// <summary>Converts the object with navigation properties to a simple object with primitive properties.</summary>
        public Common.ExclusiveLock ToSimple()
        {
            var item = this;
            return new Common.ExclusiveLock
            {
                ID = item.ID,
                ResourceType = item.ResourceType,
                ResourceID = item.ResourceID,
                UserName = item.UserName,
                Workstation = item.Workstation,
                LockStart = item.LockStart,
                LockFinish = item.LockFinish/*DataStructureInfo AssignSimpleProperty Common.ExclusiveLock*/
            };
        }

        /*DataStructureInfo QueryableClassMembers Common.ExclusiveLock*/

        public bool Equals(Common_ExclusiveLock other)
        {
            return other != null && other.ID == ID;
        }
    }

    /*DataStructureInfo QueryableClassAttributes Common.LogReader*/
    public class Common_LogReader : global::Common.LogReader, IQueryableEntity<Common.LogReader>, System.IEquatable<Common_LogReader>, IDetachOverride/*DataStructureInfo QueryableClassInterace Common.LogReader*/
    {
        bool IDetachOverride.Detaching { get; set; }

        /// <summary>Converts the object with navigation properties to a simple object with primitive properties.</summary>
        public Common.LogReader ToSimple()
        {
            var item = this;
            return new Common.LogReader
            {
                ID = item.ID,
                UserName = item.UserName,
                Workstation = item.Workstation,
                ContextInfo = item.ContextInfo,
                Action = item.Action,
                TableName = item.TableName,
                Description = item.Description,
                ItemId = item.ItemId,
                Created = item.Created/*DataStructureInfo AssignSimpleProperty Common.LogReader*/
            };
        }

        /*DataStructureInfo QueryableClassMembers Common.LogReader*/

        public bool Equals(Common_LogReader other)
        {
            return other != null && other.ID == ID;
        }
    }

    /*DataStructureInfo QueryableClassAttributes Common.LogRelatedItemReader*/
    public class Common_LogRelatedItemReader : global::Common.LogRelatedItemReader, IQueryableEntity<Common.LogRelatedItemReader>, System.IEquatable<Common_LogRelatedItemReader>, IDetachOverride/*DataStructureInfo QueryableClassInterace Common.LogRelatedItemReader*/
    {
        bool IDetachOverride.Detaching { get; set; }

        /// <summary>Converts the object with navigation properties to a simple object with primitive properties.</summary>
        public Common.LogRelatedItemReader ToSimple()
        {
            var item = this;
            return new Common.LogRelatedItemReader
            {
                ID = item.ID,
                TableName = item.TableName,
                Relation = item.Relation,
                ItemId = item.ItemId,
                LogID = item.LogID/*DataStructureInfo AssignSimpleProperty Common.LogRelatedItemReader*/
            };
        }

        private Common.Queryable.Common_Log _log;

        /*DataStructureQueryable PropertyAttribute Common.LogRelatedItemReader.Log*/
        public virtual Common.Queryable.Common_Log Log
        {
            get
            {
                /*DataStructureQueryable Getter Common.LogRelatedItemReader.Log*/
                return _log;
            }
            set
            {
                if (((IDetachOverride)this).Detaching) return;
                /*DataStructureQueryable Setter Common.LogRelatedItemReader.Log*/
                _log = value;
                LogID = value != null ? (Guid?)value.ID : null;
            }
        }

        /*DataStructureInfo QueryableClassMembers Common.LogRelatedItemReader*/

        public bool Equals(Common_LogRelatedItemReader other)
        {
            return other != null && other.ID == ID;
        }
    }

    /*DataStructureInfo QueryableClassAttributes Common.Log*/
    public class Common_Log : global::Common.Log, IQueryableEntity<Common.Log>, System.IEquatable<Common_Log>, IDetachOverride/*DataStructureInfo QueryableClassInterace Common.Log*/
    {
        bool IDetachOverride.Detaching { get; set; }

        /// <summary>Converts the object with navigation properties to a simple object with primitive properties.</summary>
        public Common.Log ToSimple()
        {
            var item = this;
            return new Common.Log
            {
                ID = item.ID,
                Created = item.Created,
                UserName = item.UserName,
                Workstation = item.Workstation,
                ContextInfo = item.ContextInfo,
                Action = item.Action,
                TableName = item.TableName,
                ItemId = item.ItemId,
                Description = item.Description/*DataStructureInfo AssignSimpleProperty Common.Log*/
            };
        }

        /*DataStructureInfo QueryableClassMembers Common.Log*/

        public bool Equals(Common_Log other)
        {
            return other != null && other.ID == ID;
        }
    }

    /*DataStructureInfo QueryableClassAttributes Common.LogRelatedItem*/
    public class Common_LogRelatedItem : global::Common.LogRelatedItem, IQueryableEntity<Common.LogRelatedItem>, System.IEquatable<Common_LogRelatedItem>, IDetachOverride/*DataStructureInfo QueryableClassInterace Common.LogRelatedItem*/
    {
        bool IDetachOverride.Detaching { get; set; }

        /// <summary>Converts the object with navigation properties to a simple object with primitive properties.</summary>
        public Common.LogRelatedItem ToSimple()
        {
            var item = this;
            return new Common.LogRelatedItem
            {
                ID = item.ID,
                LogID = item.LogID,
                TableName = item.TableName,
                ItemId = item.ItemId,
                Relation = item.Relation/*DataStructureInfo AssignSimpleProperty Common.LogRelatedItem*/
            };
        }

        private Common.Queryable.Common_Log _log;

        /*DataStructureQueryable PropertyAttribute Common.LogRelatedItem.Log*/
        public virtual Common.Queryable.Common_Log Log
        {
            get
            {
                /*DataStructureQueryable Getter Common.LogRelatedItem.Log*/
                return _log;
            }
            set
            {
                if (((IDetachOverride)this).Detaching) return;
                /*DataStructureQueryable Setter Common.LogRelatedItem.Log*/
                _log = value;
                LogID = value != null ? (Guid?)value.ID : null;
            }
        }

        /*DataStructureInfo QueryableClassMembers Common.LogRelatedItem*/

        public bool Equals(Common_LogRelatedItem other)
        {
            return other != null && other.ID == ID;
        }
    }

    /*DataStructureInfo QueryableClassAttributes Common.RelatedEventsSource*/
    public class Common_RelatedEventsSource : global::Common.RelatedEventsSource, IQueryableEntity<Common.RelatedEventsSource>, System.IEquatable<Common_RelatedEventsSource>, IDetachOverride/*DataStructureInfo QueryableClassInterace Common.RelatedEventsSource*/
    {
        bool IDetachOverride.Detaching { get; set; }

        /// <summary>Converts the object with navigation properties to a simple object with primitive properties.</summary>
        public Common.RelatedEventsSource ToSimple()
        {
            var item = this;
            return new Common.RelatedEventsSource
            {
                ID = item.ID,
                LogID = item.LogID,
                Relation = item.Relation,
                RelatedToTable = item.RelatedToTable,
                RelatedToItem = item.RelatedToItem,
                UserName = item.UserName,
                Workstation = item.Workstation,
                ContextInfo = item.ContextInfo,
                Action = item.Action,
                TableName = item.TableName,
                Description = item.Description,
                ItemId = item.ItemId,
                Created = item.Created/*DataStructureInfo AssignSimpleProperty Common.RelatedEventsSource*/
            };
        }

        private Common.Queryable.Common_LogReader _log;

        /*DataStructureQueryable PropertyAttribute Common.RelatedEventsSource.Log*/
        public virtual Common.Queryable.Common_LogReader Log
        {
            get
            {
                /*DataStructureQueryable Getter Common.RelatedEventsSource.Log*/
                return _log;
            }
            set
            {
                if (((IDetachOverride)this).Detaching) return;
                /*DataStructureQueryable Setter Common.RelatedEventsSource.Log*/
                _log = value;
                LogID = value != null ? (Guid?)value.ID : null;
            }
        }

        /*DataStructureInfo QueryableClassMembers Common.RelatedEventsSource*/

        public bool Equals(Common_RelatedEventsSource other)
        {
            return other != null && other.ID == ID;
        }
    }

    /*DataStructureInfo QueryableClassAttributes Common.Claim*/
    public class Common_Claim : global::Common.Claim, IQueryableEntity<Common.Claim>, System.IEquatable<Common_Claim>, IDetachOverride/*DataStructureInfo QueryableClassInterace Common.Claim*/
    {
        bool IDetachOverride.Detaching { get; set; }

        /// <summary>Converts the object with navigation properties to a simple object with primitive properties.</summary>
        public Common.Claim ToSimple()
        {
            var item = this;
            return new Common.Claim
            {
                ID = item.ID,
                ClaimResource = item.ClaimResource,
                ClaimRight = item.ClaimRight,
                Active = item.Active/*DataStructureInfo AssignSimpleProperty Common.Claim*/
            };
        }

        private Common.Queryable.Common_MyClaim _extension_MyClaim;

        /*DataStructureQueryable PropertyAttribute Common.Claim.Extension_MyClaim*/
        public virtual Common.Queryable.Common_MyClaim Extension_MyClaim
        {
            get
            {
                /*DataStructureQueryable Getter Common.Claim.Extension_MyClaim*/
                return _extension_MyClaim;
            }
            set
            {
                if (((IDetachOverride)this).Detaching) return;
                /*DataStructureQueryable Setter Common.Claim.Extension_MyClaim*/
                _extension_MyClaim = value;
            }
        }

        /*DataStructureInfo QueryableClassMembers Common.Claim*/

        public bool Equals(Common_Claim other)
        {
            return other != null && other.ID == ID;
        }
    }

    /*DataStructureInfo QueryableClassAttributes Common.MyClaim*/
    public class Common_MyClaim : global::Common.MyClaim, IQueryableEntity<Common.MyClaim>, System.IEquatable<Common_MyClaim>, IDetachOverride/*DataStructureInfo QueryableClassInterace Common.MyClaim*/
    {
        bool IDetachOverride.Detaching { get; set; }

        /// <summary>Converts the object with navigation properties to a simple object with primitive properties.</summary>
        public Common.MyClaim ToSimple()
        {
            var item = this;
            return new Common.MyClaim
            {
                ID = item.ID,
                Applies = item.Applies/*DataStructureInfo AssignSimpleProperty Common.MyClaim*/
            };
        }

        private Common.Queryable.Common_Claim _base;

        /*DataStructureQueryable PropertyAttribute Common.MyClaim.Base*/
        public virtual Common.Queryable.Common_Claim Base
        {
            get
            {
                /*DataStructureQueryable Getter Common.MyClaim.Base*/
                return _base;
            }
            set
            {
                if (((IDetachOverride)this).Detaching) return;
                /*DataStructureQueryable Setter Common.MyClaim.Base*/
                _base = value;
                ID = value != null ? value.ID : Guid.Empty;
            }
        }

        /*DataStructureInfo QueryableClassMembers Common.MyClaim*/

        public bool Equals(Common_MyClaim other)
        {
            return other != null && other.ID == ID;
        }
    }

    /*DataStructureInfo QueryableClassAttributes Common.Principal*/
    public class Common_Principal : global::Common.Principal, IQueryableEntity<Common.Principal>, System.IEquatable<Common_Principal>, IDetachOverride/*DataStructureInfo QueryableClassInterace Common.Principal*/
    {
        bool IDetachOverride.Detaching { get; set; }

        /// <summary>Converts the object with navigation properties to a simple object with primitive properties.</summary>
        public Common.Principal ToSimple()
        {
            var item = this;
            return new Common.Principal
            {
                ID = item.ID,
                Name = item.Name/*DataStructureInfo AssignSimpleProperty Common.Principal*/
            };
        }

        /*DataStructureInfo QueryableClassMembers Common.Principal*/

        public bool Equals(Common_Principal other)
        {
            return other != null && other.ID == ID;
        }
    }

    /*DataStructureInfo QueryableClassAttributes Common.PrincipalHasRole*/
    public class Common_PrincipalHasRole : global::Common.PrincipalHasRole, IQueryableEntity<Common.PrincipalHasRole>, System.IEquatable<Common_PrincipalHasRole>, IDetachOverride/*DataStructureInfo QueryableClassInterace Common.PrincipalHasRole*/
    {
        bool IDetachOverride.Detaching { get; set; }

        /// <summary>Converts the object with navigation properties to a simple object with primitive properties.</summary>
        public Common.PrincipalHasRole ToSimple()
        {
            var item = this;
            return new Common.PrincipalHasRole
            {
                ID = item.ID,
                PrincipalID = item.PrincipalID,
                RoleID = item.RoleID/*DataStructureInfo AssignSimpleProperty Common.PrincipalHasRole*/
            };
        }

        private Common.Queryable.Common_Principal _principal;

        /*DataStructureQueryable PropertyAttribute Common.PrincipalHasRole.Principal*/
        public virtual Common.Queryable.Common_Principal Principal
        {
            get
            {
                /*DataStructureQueryable Getter Common.PrincipalHasRole.Principal*/
                return _principal;
            }
            set
            {
                if (((IDetachOverride)this).Detaching) return;
                /*DataStructureQueryable Setter Common.PrincipalHasRole.Principal*/
                _principal = value;
                PrincipalID = value != null ? (Guid?)value.ID : null;
            }
        }

        private Common.Queryable.Common_Role _role;

        /*DataStructureQueryable PropertyAttribute Common.PrincipalHasRole.Role*/
        public virtual Common.Queryable.Common_Role Role
        {
            get
            {
                /*DataStructureQueryable Getter Common.PrincipalHasRole.Role*/
                return _role;
            }
            set
            {
                if (((IDetachOverride)this).Detaching) return;
                /*DataStructureQueryable Setter Common.PrincipalHasRole.Role*/
                _role = value;
                RoleID = value != null ? (Guid?)value.ID : null;
            }
        }

        /*DataStructureInfo QueryableClassMembers Common.PrincipalHasRole*/

        public bool Equals(Common_PrincipalHasRole other)
        {
            return other != null && other.ID == ID;
        }
    }

    /*DataStructureInfo QueryableClassAttributes Common.Role*/
    public class Common_Role : global::Common.Role, IQueryableEntity<Common.Role>, System.IEquatable<Common_Role>, IDetachOverride/*DataStructureInfo QueryableClassInterace Common.Role*/
    {
        bool IDetachOverride.Detaching { get; set; }

        /// <summary>Converts the object with navigation properties to a simple object with primitive properties.</summary>
        public Common.Role ToSimple()
        {
            var item = this;
            return new Common.Role
            {
                ID = item.ID,
                Name = item.Name/*DataStructureInfo AssignSimpleProperty Common.Role*/
            };
        }

        /*DataStructureInfo QueryableClassMembers Common.Role*/

        public bool Equals(Common_Role other)
        {
            return other != null && other.ID == ID;
        }
    }

    /*DataStructureInfo QueryableClassAttributes Common.RoleInheritsRole*/
    public class Common_RoleInheritsRole : global::Common.RoleInheritsRole, IQueryableEntity<Common.RoleInheritsRole>, System.IEquatable<Common_RoleInheritsRole>, IDetachOverride/*DataStructureInfo QueryableClassInterace Common.RoleInheritsRole*/
    {
        bool IDetachOverride.Detaching { get; set; }

        /// <summary>Converts the object with navigation properties to a simple object with primitive properties.</summary>
        public Common.RoleInheritsRole ToSimple()
        {
            var item = this;
            return new Common.RoleInheritsRole
            {
                ID = item.ID,
                UsersFromID = item.UsersFromID,
                PermissionsFromID = item.PermissionsFromID/*DataStructureInfo AssignSimpleProperty Common.RoleInheritsRole*/
            };
        }

        private Common.Queryable.Common_Role _usersFrom;

        /*DataStructureQueryable PropertyAttribute Common.RoleInheritsRole.UsersFrom*/
        public virtual Common.Queryable.Common_Role UsersFrom
        {
            get
            {
                /*DataStructureQueryable Getter Common.RoleInheritsRole.UsersFrom*/
                return _usersFrom;
            }
            set
            {
                if (((IDetachOverride)this).Detaching) return;
                /*DataStructureQueryable Setter Common.RoleInheritsRole.UsersFrom*/
                _usersFrom = value;
                UsersFromID = value != null ? (Guid?)value.ID : null;
            }
        }

        private Common.Queryable.Common_Role _permissionsFrom;

        /*DataStructureQueryable PropertyAttribute Common.RoleInheritsRole.PermissionsFrom*/
        public virtual Common.Queryable.Common_Role PermissionsFrom
        {
            get
            {
                /*DataStructureQueryable Getter Common.RoleInheritsRole.PermissionsFrom*/
                return _permissionsFrom;
            }
            set
            {
                if (((IDetachOverride)this).Detaching) return;
                /*DataStructureQueryable Setter Common.RoleInheritsRole.PermissionsFrom*/
                _permissionsFrom = value;
                PermissionsFromID = value != null ? (Guid?)value.ID : null;
            }
        }

        /*DataStructureInfo QueryableClassMembers Common.RoleInheritsRole*/

        public bool Equals(Common_RoleInheritsRole other)
        {
            return other != null && other.ID == ID;
        }
    }

    /*DataStructureInfo QueryableClassAttributes Common.PrincipalPermission*/
    public class Common_PrincipalPermission : global::Common.PrincipalPermission, IQueryableEntity<Common.PrincipalPermission>, System.IEquatable<Common_PrincipalPermission>, IDetachOverride/*DataStructureInfo QueryableClassInterace Common.PrincipalPermission*/
    {
        bool IDetachOverride.Detaching { get; set; }

        /// <summary>Converts the object with navigation properties to a simple object with primitive properties.</summary>
        public Common.PrincipalPermission ToSimple()
        {
            var item = this;
            return new Common.PrincipalPermission
            {
                ID = item.ID,
                PrincipalID = item.PrincipalID,
                ClaimID = item.ClaimID,
                IsAuthorized = item.IsAuthorized/*DataStructureInfo AssignSimpleProperty Common.PrincipalPermission*/
            };
        }

        private Common.Queryable.Common_Principal _principal;

        /*DataStructureQueryable PropertyAttribute Common.PrincipalPermission.Principal*/
        public virtual Common.Queryable.Common_Principal Principal
        {
            get
            {
                /*DataStructureQueryable Getter Common.PrincipalPermission.Principal*/
                return _principal;
            }
            set
            {
                if (((IDetachOverride)this).Detaching) return;
                /*DataStructureQueryable Setter Common.PrincipalPermission.Principal*/
                _principal = value;
                PrincipalID = value != null ? (Guid?)value.ID : null;
            }
        }

        private Common.Queryable.Common_Claim _claim;

        /*DataStructureQueryable PropertyAttribute Common.PrincipalPermission.Claim*/
        public virtual Common.Queryable.Common_Claim Claim
        {
            get
            {
                /*DataStructureQueryable Getter Common.PrincipalPermission.Claim*/
                return _claim;
            }
            set
            {
                if (((IDetachOverride)this).Detaching) return;
                /*DataStructureQueryable Setter Common.PrincipalPermission.Claim*/
                _claim = value;
                ClaimID = value != null ? (Guid?)value.ID : null;
            }
        }

        /*DataStructureInfo QueryableClassMembers Common.PrincipalPermission*/

        public bool Equals(Common_PrincipalPermission other)
        {
            return other != null && other.ID == ID;
        }
    }

    /*DataStructureInfo QueryableClassAttributes Common.RolePermission*/
    public class Common_RolePermission : global::Common.RolePermission, IQueryableEntity<Common.RolePermission>, System.IEquatable<Common_RolePermission>, IDetachOverride/*DataStructureInfo QueryableClassInterace Common.RolePermission*/
    {
        bool IDetachOverride.Detaching { get; set; }

        /// <summary>Converts the object with navigation properties to a simple object with primitive properties.</summary>
        public Common.RolePermission ToSimple()
        {
            var item = this;
            return new Common.RolePermission
            {
                ID = item.ID,
                RoleID = item.RoleID,
                ClaimID = item.ClaimID,
                IsAuthorized = item.IsAuthorized/*DataStructureInfo AssignSimpleProperty Common.RolePermission*/
            };
        }

        private Common.Queryable.Common_Role _role;

        /*DataStructureQueryable PropertyAttribute Common.RolePermission.Role*/
        public virtual Common.Queryable.Common_Role Role
        {
            get
            {
                /*DataStructureQueryable Getter Common.RolePermission.Role*/
                return _role;
            }
            set
            {
                if (((IDetachOverride)this).Detaching) return;
                /*DataStructureQueryable Setter Common.RolePermission.Role*/
                _role = value;
                RoleID = value != null ? (Guid?)value.ID : null;
            }
        }

        private Common.Queryable.Common_Claim _claim;

        /*DataStructureQueryable PropertyAttribute Common.RolePermission.Claim*/
        public virtual Common.Queryable.Common_Claim Claim
        {
            get
            {
                /*DataStructureQueryable Getter Common.RolePermission.Claim*/
                return _claim;
            }
            set
            {
                if (((IDetachOverride)this).Detaching) return;
                /*DataStructureQueryable Setter Common.RolePermission.Claim*/
                _claim = value;
                ClaimID = value != null ? (Guid?)value.ID : null;
            }
        }

        /*DataStructureInfo QueryableClassMembers Common.RolePermission*/

        public bool Equals(Common_RolePermission other)
        {
            return other != null && other.ID == ID;
        }
    }

    /*CommonQueryableMemebers*/
}

namespace Rhetos.Dom.DefaultConcepts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;
    using Rhetos.Dom.DefaultConcepts;
    using Rhetos.Utilities;

    public static class QueryExtensions
    {
        /// <summary>Converts the objects with navigation properties to simple objects with primitive properties.</summary>
        public static IQueryable<Hoteli.Hotel> ToSimple(this IQueryable<Common.Queryable.Hoteli_Hotel> query)
        {
            return query.Select(item => new Hoteli.Hotel
            {
                ID = item.ID,
                Code = item.Code,
                Name = item.Name,
                Address = item.Address/*DataStructureInfo AssignSimpleProperty Hoteli.Hotel*/
            });
        }
        /// <summary>Converts the objects with navigation properties to simple objects with primitive properties.</summary>
        public static IQueryable<Hoteli.Location> ToSimple(this IQueryable<Common.Queryable.Hoteli_Location> query)
        {
            return query.Select(item => new Hoteli.Location
            {
                ID = item.ID,
                Code = item.Code,
                Country = item.Country,
                County = item.County,
                City = item.City,
                Area = item.Area/*DataStructureInfo AssignSimpleProperty Hoteli.Location*/
            });
        }
        /// <summary>Converts the objects with navigation properties to simple objects with primitive properties.</summary>
        public static IQueryable<Hoteli.RoomReservation> ToSimple(this IQueryable<Common.Queryable.Hoteli_RoomReservation> query)
        {
            return query.Select(item => new Hoteli.RoomReservation
            {
                ID = item.ID,
                Code = item.Code,
                ReservationHotelID = item.ReservationHotelID,
                ReservationRoomID = item.ReservationRoomID/*DataStructureInfo AssignSimpleProperty Hoteli.RoomReservation*/
            });
        }
        /// <summary>Converts the objects with navigation properties to simple objects with primitive properties.</summary>
        public static IQueryable<Hoteli.Reservation> ToSimple(this IQueryable<Common.Queryable.Hoteli_Reservation> query)
        {
            return query.Select(item => new Hoteli.Reservation
            {
                ID = item.ID,
                Code = item.Code,
                DateFrom = item.DateFrom,
                DateTo = item.DateTo,
                NumberOfPeople = item.NumberOfPeople,
                GuestID = item.GuestID/*DataStructureInfo AssignSimpleProperty Hoteli.Reservation*/
            });
        }
        /// <summary>Converts the objects with navigation properties to simple objects with primitive properties.</summary>
        public static IQueryable<Hoteli.Rooms> ToSimple(this IQueryable<Common.Queryable.Hoteli_Rooms> query)
        {
            return query.Select(item => new Hoteli.Rooms
            {
                ID = item.ID,
                Code = item.Code,
                NumberOfPeople = item.NumberOfPeople,
                RoomOfHotelID = item.RoomOfHotelID,
                TypeOfRoom = item.TypeOfRoom/*DataStructureInfo AssignSimpleProperty Hoteli.Rooms*/
            });
        }
        /// <summary>Converts the objects with navigation properties to simple objects with primitive properties.</summary>
        public static IQueryable<Hoteli.Person> ToSimple(this IQueryable<Common.Queryable.Hoteli_Person> query)
        {
            return query.Select(item => new Hoteli.Person
            {
                ID = item.ID,
                Code = item.Code,
                Identifier = item.Identifier,
                Name = item.Name,
                Surname = item.Surname,
                Address = item.Address,
                isGuest = item.isGuest,
                isEmployee = item.isEmployee,
                isOwner = item.isOwner,
                Discount = item.Discount/*DataStructureInfo AssignSimpleProperty Hoteli.Person*/
            });
        }
        /// <summary>Converts the objects with navigation properties to simple objects with primitive properties.</summary>
        public static IQueryable<Hoteli.SaloonPerson> ToSimple(this IQueryable<Common.Queryable.Hoteli_SaloonPerson> query)
        {
            return query.Select(item => new Hoteli.SaloonPerson
            {
                ID = item.ID,
                Code = item.Code,
                OwnerNameID = item.OwnerNameID,
                SalonID = item.SalonID/*DataStructureInfo AssignSimpleProperty Hoteli.SaloonPerson*/
            });
        }
        /// <summary>Converts the objects with navigation properties to simple objects with primitive properties.</summary>
        public static IQueryable<Hoteli.SaloonHotel> ToSimple(this IQueryable<Common.Queryable.Hoteli_SaloonHotel> query)
        {
            return query.Select(item => new Hoteli.SaloonHotel
            {
                ID = item.ID,
                Code = item.Code,
                OwnerNameID = item.OwnerNameID,
                SalonID = item.SalonID/*DataStructureInfo AssignSimpleProperty Hoteli.SaloonHotel*/
            });
        }
        /// <summary>Converts the objects with navigation properties to simple objects with primitive properties.</summary>
        public static IQueryable<Hoteli.Saloon> ToSimple(this IQueryable<Common.Queryable.Hoteli_Saloon> query)
        {
            return query.Select(item => new Hoteli.Saloon
            {
                ID = item.ID,
                Code = item.Code,
                Name = item.Name,
                HotelSaloonID = item.HotelSaloonID/*DataStructureInfo AssignSimpleProperty Hoteli.Saloon*/
            });
        }
        /// <summary>Converts the objects with navigation properties to simple objects with primitive properties.</summary>
        public static IQueryable<Hoteli.ProductPerson> ToSimple(this IQueryable<Common.Queryable.Hoteli_ProductPerson> query)
        {
            return query.Select(item => new Hoteli.ProductPerson
            {
                ID = item.ID,
                Code = item.Code,
                OwnerNameID = item.OwnerNameID,
                ProductID = item.ProductID/*DataStructureInfo AssignSimpleProperty Hoteli.ProductPerson*/
            });
        }
        /// <summary>Converts the objects with navigation properties to simple objects with primitive properties.</summary>
        public static IQueryable<Hoteli.ProductHotel> ToSimple(this IQueryable<Common.Queryable.Hoteli_ProductHotel> query)
        {
            return query.Select(item => new Hoteli.ProductHotel
            {
                ID = item.ID,
                Code = item.Code,
                OwnerNameID = item.OwnerNameID,
                ProductID = item.ProductID/*DataStructureInfo AssignSimpleProperty Hoteli.ProductHotel*/
            });
        }
        /// <summary>Converts the objects with navigation properties to simple objects with primitive properties.</summary>
        public static IQueryable<Hoteli.Product> ToSimple(this IQueryable<Common.Queryable.Hoteli_Product> query)
        {
            return query.Select(item => new Hoteli.Product
            {
                ID = item.ID,
                Code = item.Code,
                Title = item.Title,
                HotelSaloonID = item.HotelSaloonID/*DataStructureInfo AssignSimpleProperty Hoteli.Product*/
            });
        }
        /// <summary>Converts the objects with navigation properties to simple objects with primitive properties.</summary>
        public static IQueryable<Hoteli.ReservationInfo> ToSimple(this IQueryable<Common.Queryable.Hoteli_ReservationInfo> query)
        {
            return query.Select(item => new Hoteli.ReservationInfo
            {
                ID = item.ID,
                NumberOfRooms = item.NumberOfRooms/*DataStructureInfo AssignSimpleProperty Hoteli.ReservationInfo*/
            });
        }
        /// <summary>Converts the objects with navigation properties to simple objects with primitive properties.</summary>
        public static IQueryable<Common.AutoCodeCache> ToSimple(this IQueryable<Common.Queryable.Common_AutoCodeCache> query)
        {
            return query.Select(item => new Common.AutoCodeCache
            {
                ID = item.ID,
                Entity = item.Entity,
                Property = item.Property,
                Grouping = item.Grouping,
                Prefix = item.Prefix,
                MinDigits = item.MinDigits,
                LastCode = item.LastCode/*DataStructureInfo AssignSimpleProperty Common.AutoCodeCache*/
            });
        }
        /// <summary>Converts the objects with navigation properties to simple objects with primitive properties.</summary>
        public static IQueryable<Common.FilterId> ToSimple(this IQueryable<Common.Queryable.Common_FilterId> query)
        {
            return query.Select(item => new Common.FilterId
            {
                ID = item.ID,
                Handle = item.Handle,
                Value = item.Value/*DataStructureInfo AssignSimpleProperty Common.FilterId*/
            });
        }
        /// <summary>Converts the objects with navigation properties to simple objects with primitive properties.</summary>
        public static IQueryable<Common.KeepSynchronizedMetadata> ToSimple(this IQueryable<Common.Queryable.Common_KeepSynchronizedMetadata> query)
        {
            return query.Select(item => new Common.KeepSynchronizedMetadata
            {
                ID = item.ID,
                Target = item.Target,
                Source = item.Source,
                Context = item.Context/*DataStructureInfo AssignSimpleProperty Common.KeepSynchronizedMetadata*/
            });
        }
        /// <summary>Converts the objects with navigation properties to simple objects with primitive properties.</summary>
        public static IQueryable<Common.ExclusiveLock> ToSimple(this IQueryable<Common.Queryable.Common_ExclusiveLock> query)
        {
            return query.Select(item => new Common.ExclusiveLock
            {
                ID = item.ID,
                ResourceType = item.ResourceType,
                ResourceID = item.ResourceID,
                UserName = item.UserName,
                Workstation = item.Workstation,
                LockStart = item.LockStart,
                LockFinish = item.LockFinish/*DataStructureInfo AssignSimpleProperty Common.ExclusiveLock*/
            });
        }
        /// <summary>Converts the objects with navigation properties to simple objects with primitive properties.</summary>
        public static IQueryable<Common.LogReader> ToSimple(this IQueryable<Common.Queryable.Common_LogReader> query)
        {
            return query.Select(item => new Common.LogReader
            {
                ID = item.ID,
                UserName = item.UserName,
                Workstation = item.Workstation,
                ContextInfo = item.ContextInfo,
                Action = item.Action,
                TableName = item.TableName,
                Description = item.Description,
                ItemId = item.ItemId,
                Created = item.Created/*DataStructureInfo AssignSimpleProperty Common.LogReader*/
            });
        }
        /// <summary>Converts the objects with navigation properties to simple objects with primitive properties.</summary>
        public static IQueryable<Common.LogRelatedItemReader> ToSimple(this IQueryable<Common.Queryable.Common_LogRelatedItemReader> query)
        {
            return query.Select(item => new Common.LogRelatedItemReader
            {
                ID = item.ID,
                TableName = item.TableName,
                Relation = item.Relation,
                ItemId = item.ItemId,
                LogID = item.LogID/*DataStructureInfo AssignSimpleProperty Common.LogRelatedItemReader*/
            });
        }
        /// <summary>Converts the objects with navigation properties to simple objects with primitive properties.</summary>
        public static IQueryable<Common.Log> ToSimple(this IQueryable<Common.Queryable.Common_Log> query)
        {
            return query.Select(item => new Common.Log
            {
                ID = item.ID,
                Created = item.Created,
                UserName = item.UserName,
                Workstation = item.Workstation,
                ContextInfo = item.ContextInfo,
                Action = item.Action,
                TableName = item.TableName,
                ItemId = item.ItemId,
                Description = item.Description/*DataStructureInfo AssignSimpleProperty Common.Log*/
            });
        }
        /// <summary>Converts the objects with navigation properties to simple objects with primitive properties.</summary>
        public static IQueryable<Common.LogRelatedItem> ToSimple(this IQueryable<Common.Queryable.Common_LogRelatedItem> query)
        {
            return query.Select(item => new Common.LogRelatedItem
            {
                ID = item.ID,
                LogID = item.LogID,
                TableName = item.TableName,
                ItemId = item.ItemId,
                Relation = item.Relation/*DataStructureInfo AssignSimpleProperty Common.LogRelatedItem*/
            });
        }
        /// <summary>Converts the objects with navigation properties to simple objects with primitive properties.</summary>
        public static IQueryable<Common.RelatedEventsSource> ToSimple(this IQueryable<Common.Queryable.Common_RelatedEventsSource> query)
        {
            return query.Select(item => new Common.RelatedEventsSource
            {
                ID = item.ID,
                LogID = item.LogID,
                Relation = item.Relation,
                RelatedToTable = item.RelatedToTable,
                RelatedToItem = item.RelatedToItem,
                UserName = item.UserName,
                Workstation = item.Workstation,
                ContextInfo = item.ContextInfo,
                Action = item.Action,
                TableName = item.TableName,
                Description = item.Description,
                ItemId = item.ItemId,
                Created = item.Created/*DataStructureInfo AssignSimpleProperty Common.RelatedEventsSource*/
            });
        }
        /// <summary>Converts the objects with navigation properties to simple objects with primitive properties.</summary>
        public static IQueryable<Common.Claim> ToSimple(this IQueryable<Common.Queryable.Common_Claim> query)
        {
            return query.Select(item => new Common.Claim
            {
                ID = item.ID,
                ClaimResource = item.ClaimResource,
                ClaimRight = item.ClaimRight,
                Active = item.Active/*DataStructureInfo AssignSimpleProperty Common.Claim*/
            });
        }
        /// <summary>Converts the objects with navigation properties to simple objects with primitive properties.</summary>
        public static IQueryable<Common.MyClaim> ToSimple(this IQueryable<Common.Queryable.Common_MyClaim> query)
        {
            return query.Select(item => new Common.MyClaim
            {
                ID = item.ID,
                Applies = item.Applies/*DataStructureInfo AssignSimpleProperty Common.MyClaim*/
            });
        }
        /// <summary>Converts the objects with navigation properties to simple objects with primitive properties.</summary>
        public static IQueryable<Common.Principal> ToSimple(this IQueryable<Common.Queryable.Common_Principal> query)
        {
            return query.Select(item => new Common.Principal
            {
                ID = item.ID,
                Name = item.Name/*DataStructureInfo AssignSimpleProperty Common.Principal*/
            });
        }
        /// <summary>Converts the objects with navigation properties to simple objects with primitive properties.</summary>
        public static IQueryable<Common.PrincipalHasRole> ToSimple(this IQueryable<Common.Queryable.Common_PrincipalHasRole> query)
        {
            return query.Select(item => new Common.PrincipalHasRole
            {
                ID = item.ID,
                PrincipalID = item.PrincipalID,
                RoleID = item.RoleID/*DataStructureInfo AssignSimpleProperty Common.PrincipalHasRole*/
            });
        }
        /// <summary>Converts the objects with navigation properties to simple objects with primitive properties.</summary>
        public static IQueryable<Common.Role> ToSimple(this IQueryable<Common.Queryable.Common_Role> query)
        {
            return query.Select(item => new Common.Role
            {
                ID = item.ID,
                Name = item.Name/*DataStructureInfo AssignSimpleProperty Common.Role*/
            });
        }
        /// <summary>Converts the objects with navigation properties to simple objects with primitive properties.</summary>
        public static IQueryable<Common.RoleInheritsRole> ToSimple(this IQueryable<Common.Queryable.Common_RoleInheritsRole> query)
        {
            return query.Select(item => new Common.RoleInheritsRole
            {
                ID = item.ID,
                UsersFromID = item.UsersFromID,
                PermissionsFromID = item.PermissionsFromID/*DataStructureInfo AssignSimpleProperty Common.RoleInheritsRole*/
            });
        }
        /// <summary>Converts the objects with navigation properties to simple objects with primitive properties.</summary>
        public static IQueryable<Common.PrincipalPermission> ToSimple(this IQueryable<Common.Queryable.Common_PrincipalPermission> query)
        {
            return query.Select(item => new Common.PrincipalPermission
            {
                ID = item.ID,
                PrincipalID = item.PrincipalID,
                ClaimID = item.ClaimID,
                IsAuthorized = item.IsAuthorized/*DataStructureInfo AssignSimpleProperty Common.PrincipalPermission*/
            });
        }
        /// <summary>Converts the objects with navigation properties to simple objects with primitive properties.</summary>
        public static IQueryable<Common.RolePermission> ToSimple(this IQueryable<Common.Queryable.Common_RolePermission> query)
        {
            return query.Select(item => new Common.RolePermission
            {
                ID = item.ID,
                RoleID = item.RoleID,
                ClaimID = item.ClaimID,
                IsAuthorized = item.IsAuthorized/*DataStructureInfo AssignSimpleProperty Common.RolePermission*/
            });
        }
        /*QueryExtensionsMembers*/

        /// <summary>
        /// A specific overload of the 'ToSimple' method cannot be targeted from a generic method using generic type.
        /// This method uses reflection instead to find the specific 'ToSimple' method.
        /// </summary>
        public static IQueryable<TEntity> GenericToSimple<TEntity>(this IQueryable<IEntity> i)
            where TEntity : class, IEntity
	    {
            var method = typeof(QueryExtensions).GetMethod("ToSimple", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public, null, new Type[] { i.GetType() }, null);
            if (method == null)
                throw new Rhetos.FrameworkException("Cannot find 'ToSimple' method for argument type '" + i.GetType().ToString() + "'.");
            return (IQueryable<TEntity>)Rhetos.Utilities.ExceptionsUtility.InvokeEx(method, null, new object[] { i });
        }

        /// <summary>Converts the objects to simple object and the IEnumerable to List or Array, if not already.</summary>
        public static void LoadSimpleObjects<TEntity>(ref IEnumerable<TEntity> items)
            where TEntity: class, IEntity
        {
            var query = items as IQueryable<IQueryableEntity<TEntity>>;
            var navigationItems = items as IEnumerable<IQueryableEntity<TEntity>>;

            if (query != null)
                items = query.GenericToSimple<TEntity>().ToList(); // The IQueryable function allows ORM optimizations.
            else if (navigationItems != null)
                items = navigationItems.Select(item => item.ToSimple()).ToList();
            else
            {
                Rhetos.Utilities.CsUtility.Materialize(ref items);
                var itemsList = (IList<TEntity>)items;
                for (int i = 0; i < itemsList.Count(); i++)
                {
                    var navigationItem = itemsList[i] as IQueryableEntity<TEntity>;
                    if (navigationItem != null)
                        itemsList[i] = navigationItem.ToSimple();
                }
            }
        }
    }
}
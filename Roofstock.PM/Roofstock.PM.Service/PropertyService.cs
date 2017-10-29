using Roofstock.PM.Context;
using Roofstock.PM.Domain;
using Roofstock.PM.Domain.DTO;
using Roofstock.PM.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roofstock.PM.Service
{
    public class PropertyService : BaseService<Property>
    {
        private readonly IUnitOfWork uow;

        BaseRepository<Property> repository;
        public PropertyService(IUnitOfWork uow) : base(uow)
        {
            repository = new BaseRepository<Property>(uow);
            this.uow = uow;
        }

        public void AddProperty(PropertyInfo propertyInfo)
        {
            BaseRepository<Property> repository = new BaseRepository<Property>(uow);
            if (repository.FindAll(x => x.PropertyId == propertyInfo.PropertyId).Count() > 0)
            {
                throw new Exception("This Property already saved.");
            }
            Property prop = new Property();
            prop.PropertyId = propertyInfo.PropertyId;
            prop.Address1 = propertyInfo.Address.Address1;
            prop.Address2 = propertyInfo.Address.Address2;
            prop.City = propertyInfo.Address.City;
            prop.Country = propertyInfo.Address.Country;
            prop.County = propertyInfo.Address.County;
            prop.District = propertyInfo.Address.District;
            prop.ListPrice = propertyInfo.ListPrice;
            prop.YearBuilt = propertyInfo.YearBuilt;
            prop.MonthlyRent = propertyInfo.MonthlyRent;
            prop.GrossYield = propertyInfo.GrossYield;
            prop.ZipCode = propertyInfo.Address.ZipCode;
            prop.ZipPlus4 = propertyInfo.Address.ZipPlus4;
            prop.State = propertyInfo.Address.State;
            prop.CreatedDate = System.DateTime.Now;
            repository.AddOrUpdate(prop);
        }

        public bool isPropertyAdded(long propertyId)
        {
            var test = repository.GetById(propertyId);
            return test == null ? false : true;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using BikeInventory.Application.Common.Entities;
using BikeInventory.Models;

namespace BikeInventory.Application.MappingProfiles
{
    public class DefaultMappingProfile : Profile
    {
        public DefaultMappingProfile()
        {
            RecognizePrefixes("N_");

            CreateMap<tbl_User, User>()
                .ForMember(a => a.Roles, a => a.MapFrom(b => b.N_UserRoles.Select(r => r.Role)));

            CreateMap<tbl_Bike, Bike>()
                .ForMember(a => a.Rate, a => a.MapFrom(b => b.N_BikeRates.FirstOrDefault(r => r.IsActive)));

            CreateMap<tbl_BikeModel, BikeModel>();
            CreateMap<tbl_BikeRate, BikeRate>();
            CreateMap<tbl_PaymentHandler, PaymentHandler>();
            CreateMap<tbl_Customer, Customer>();
            CreateMap<tbl_RentalTransaction, RentalTransaction>();
            CreateMap<tbl_PaymentHandler, PaymentHandler>();
        }
    }
}

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

            CreateMap<tbl_Bike, Bike>();
            CreateMap<tbl_BikeModel, BikeModel>();
        }
    }
}

using AutoMapper;
using CarWashApp.DTOs;
using CarWashApp.DTOs.ReservationDTOs;
using CarWashApp.DTOs.ServiceDTOs;
using CarWashApp.DTOs.ShopDTOs;
using CarWashApp.DTOs.UserDTOs;
using CarWashApp.Entities;
using Microsoft.AspNetCore.Identity;

namespace CarWashApp.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {   
            CreateMap<Shop, ShopDTO>();

            CreateMap<ShopCreationDTO, Shop>()
                .ForMember(x => x.ShopId, opt => opt.Ignore())
                .ForMember(x => x.OwnerId, opt => opt.Ignore())
                .ForMember(x => x.Owner, opt => opt.Ignore())
                .ForMember(x => x.Reservations, opt => opt.Ignore())
                .ForMember(x => x.ShopServices, opt => opt.Ignore());

            CreateMap<GeneralUser, UserDTO>()
                .ForMember(x => x.FirstName, options => options.MapFrom(x => x.FirstName))
                .ForMember(x => x.LastName, options => options.MapFrom(x => x.LastName))
                .ForMember(x => x.EmailAddress, options => options.MapFrom(x => x.Email))
                .ForMember(x => x.UserId, options => options.MapFrom(x => x.Id));

            CreateMap<Service, ServiceDTO>();

            CreateMap<ServiceCreationDTO, Service>()
                .ForMember(x => x.ServiceId, opt => opt.Ignore())
                .ForMember(x => x.Reservations, opt => opt.Ignore())
                .ForMember(x => x.ShopServices, opt => opt.Ignore());
            CreateMap<Reservation, ReservationDTO>();

            CreateMap<ReservationCreationDTO, Reservation>()
                .ForMember(x => x.ReservationId, opt => opt.Ignore())
                .ForMember(x => x.Status, opt => opt.Ignore())
                .ForMember(x => x.ConsumerId, opt => opt.Ignore())
                .ForMember(x => x.Consumer, opt => opt.Ignore())
                .ForMember(x => x.Shop, opt => opt.Ignore())
                .ForMember(x => x.Service, opt => opt.Ignore());

            CreateMap<Shop, ShopRevenueDTO>().
                ForMember(x => x.TotalRevenue, options => options.MapFrom(SumTotalRevenue));
        }
        
        private float SumTotalRevenue(Shop entity, ShopRevenueDTO shopRevenueDTO)
        {
            float totalRevenue = 0;

            foreach(var reservation in entity.Reservations)
            {
                if(!reservation.Status)
                {
                    totalRevenue += reservation.Service.Price;
                }
            }
            return totalRevenue;
        }
    }
}


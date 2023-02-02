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
            CreateMap<ShopCreationDTO, Shop>();
            CreateMap<GeneralUser, UserDTO>()
                .ForMember(x => x.FirstName, options => options.MapFrom(x => x.FirstName))
                .ForMember(x => x.LastName, options => options.MapFrom(x => x.LastName))
                .ForMember(x => x.EmailAddress, options => options.MapFrom(x => x.Email))
                .ForMember(x => x.UserId, options => options.MapFrom(x => x.Id));
            CreateMap<Service, ServiceDTO>();
            CreateMap<ServiceCreationDTO, Service>();
            CreateMap<Reservation, ReservationDTO>();
            CreateMap<ReservationCreationDTO, Reservation>();
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


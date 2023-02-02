using AutoMapper;
using CarWashApp.DTOs.FilterDTO;
using CarWashApp.DTOs.PaginationDTO;
using CarWashApp.DTOs.ReservationDTOs;
using CarWashApp.Entities;
using CarWashApp.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarWashApp.Controllers
{
    [Route("api/reservation")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly UserManager<GeneralUser> userManager;

        public ReservationController(ApplicationDbContext context, IMapper mapper, UserManager<GeneralUser> userManager)
        {
            this.context = context;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        // Konzumer izlistava sve svoje rezervacije, PAGINACIJA
        [HttpGet("getAllReservationsFromConsumer")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Consumer")]
        public async Task<ActionResult<List<ReservationDTO>>> GetGeneralUserReservations([FromQuery] PaginationDTO paginationDTO)
        {            
            var currentConsumer = await userManager.FindByNameAsync(User.Identity.Name); 
            var consumerReservations = context.Reservations.Where(r => r.ConsumerId == currentConsumer.Id && r.Status).AsQueryable();

            if (consumerReservations == null || !consumerReservations.Any())
            {
                return BadRequest("You don't have any reservations!");
            }

            await HttpContext.InsertPaginationParametersInResponse(consumerReservations, paginationDTO.RecordsPerPage);
            var reservations = await consumerReservations.Paginate(paginationDTO).ToListAsync();
            var reservationsDTOs = mapper.Map<List<ReservationDTO>>(reservations);

            return reservationsDTOs;
        }

        // Konzumer hoce da pogleda svoju rezervaciju po ID-ju
        [HttpGet("getReservationByIdFromConsumer/{reservationId:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Consumer")]
        public async Task<ActionResult<ReservationDTO>> Get(int reservationId)
        {
            var currentConsumer = await userManager.FindByNameAsync(User.Identity.Name);
            var reservation = await context.Reservations.FirstOrDefaultAsync(x => x.ReservationId == reservationId && x.ConsumerId == currentConsumer.Id);

            if (reservation == null)
            {
                return NotFound("Reservation with that number ID doesn't exist! Please try again!");
            }

            var reservationDTO = mapper.Map<ReservationDTO>(reservation);

            return reservationDTO;
        }

        //Konzumer hoce da filtrira slobodne termine po odredjenom ShopId-ju,   FILTER
        [HttpGet("GetAllFilteredReservationsByShopIdFromConsumer/{shopId:Int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Consumer")]
        public async Task<ActionResult<FilterDTO>> GetFilter(int shopId)
        {
            var top = 9;
            var today = DateTime.Today;
            var upcomingDayReservations = await context.Reservations
                .Where(x => x.ReservationDateTime.Date > today && x.ShopId == shopId)
                .OrderBy(x => x.ReservationDateTime)
                .Take(top)
                .ToListAsync();
            var currentDayReservations = await context.Reservations
                .Where(x => x.ReservationDateTime == DateTime.Now && x.ShopId == shopId)
                .Take(top)
                .ToListAsync();


            var result = new FilterDTO();
            result.UpcomingDayReservations = mapper.Map<List<ReservationDTO>>(upcomingDayReservations);
            result.CurrentDayReservations = mapper.Map<List<ReservationDTO>>(currentDayReservations);
            
            return result;
        }

        // Owner hoce da izlista sve rezervacije vezane za odredjen shop po shopID-ju, PAGINACIJA
        [HttpGet("getAllReservationsByShopIdFromOwner")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Owner")]
        public async Task<ActionResult<List<ReservationDTO>>> GetGeneralUserReservationsByShop(int shopId, [FromQuery] PaginationDTO paginationDTO)
        {
            var currentUser = await userManager.FindByNameAsync(User.Identity.Name);
            var queryReservations = context.Reservations
                .Include(x => x.Shop)
                .Where(x => x.ShopId == shopId && x.Shop.OwnerId == currentUser.Id)
                .AsQueryable();

            if (!queryReservations.Any())
                return NotFound("Shop with this number ID doesn't exist! Please try again!");

            await HttpContext.InsertPaginationParametersInResponse(queryReservations, paginationDTO.RecordsPerPage);
            var reservations = await queryReservations.Paginate(paginationDTO).ToListAsync();
            var reservationsDTOs = mapper.Map<List<ReservationDTO>>(reservations);

            return reservationsDTOs;
        }

        // Owner hoce da pogleda odredjenu rezervaciju po reservationID-ju
        [HttpGet("getReservationByIdFromOwner/{reservationId:int}", Name = "getReservation")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Owner")]
        public async Task<ActionResult<ReservationDTO>> GetReservationByOwner(int reservationId)
        {
            var currentUser = await userManager.FindByNameAsync(User.Identity.Name);
            var reservation = await context.Reservations
                .Include(x => x.Shop)
                .FirstOrDefaultAsync(x => x.ReservationId == reservationId && x.Shop.OwnerId == currentUser.Id);

            if (reservation == null)
                return NotFound("Reservation with this number ID is no longer active!");

            return mapper.Map<ReservationDTO>(reservation);
        }

        [HttpPost("createReservationFromConsumer")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Consumer")]
        public async Task<ActionResult> Post([FromBody] ReservationCreationDTO reservationCreationDTO)
        {

            var shop = await context.Shops
                .Include(x => x.Reservations)
                .FirstOrDefaultAsync(x => x.ShopId == reservationCreationDTO.ShopId);

            if (shop == null) 
            { 
            return NotFound("You must fill all the fields!");
            }

            bool shopIsOpen = reservationCreationDTO.ReservationDateTime.Hour >= shop.OpeningTime && reservationCreationDTO.ReservationDateTime.Hour < shop.ClosingTime;
            bool falseReservationTime = shop.Reservations.Any(x => x.ReservationDateTime == reservationCreationDTO.ReservationDateTime);
            bool falseReservationDate = reservationCreationDTO.ReservationDateTime <= DateTime.Now;

            if (!shopIsOpen)
            {
                return BadRequest("Shop is closed! Working hours are from 8AM-18PM every day. Every wash duration is 1 hour, so the latest reservation must be in 17PM.");
            }
            else if (falseReservationDate)
            {
                return BadRequest("You entered a wrong date or time! Your reservation can not be applied! Please try again!");
            }
            else if (falseReservationTime)
            {
                return BadRequest("This reservation time is already taken! Please try again!");
            }
            else
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);
                var reservation = mapper.Map<Reservation>(reservationCreationDTO);
                reservation.ConsumerId = user.Id;
                context.Add(reservation);
                await context.SaveChangesAsync();
                var reservationDTO = mapper.Map<ReservationDTO>(reservation);
                return new CreatedAtRouteResult("getReservation", reservationDTO);
            }
        }

        [HttpDelete("deleteReservationByIdFromOwner/{reservationId:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Owner")]    
        public async Task<ActionResult> DeleteReservationFromOwner(int reservationId)
        {
            var reservationToDelete = await context.Reservations.FirstOrDefaultAsync(x => x.ReservationId == reservationId);
            if (reservationToDelete != null && reservationToDelete.ReservationDateTime > DateTime.Now.AddHours(1))
            {
                context.Remove(reservationToDelete);
                await context.SaveChangesAsync();
            }
            else
            {
                return BadRequest("Reservation with this number ID is no longer active!");
            }
            return NoContent();
        }

        [HttpDelete("deleteReservationByIdFromConsumer/{reservationId:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Consumer")]
        public async Task<ActionResult> DeleteReservationFromConsumer(int reservationId)
        {
            var reservationToDelete = await context.Reservations.FirstOrDefaultAsync(x => x.ReservationId == reservationId);
            if (reservationToDelete != null && reservationToDelete.ReservationDateTime > DateTime.Now.AddMinutes(15))
            {
                context.Remove(reservationToDelete);
                await context.SaveChangesAsync();
            }
            else
            {
                return BadRequest("Delete reservation failed! Reservation must be canceled 15 minutes before the reservated time!");
            }
            return NoContent();
        }
    }
}

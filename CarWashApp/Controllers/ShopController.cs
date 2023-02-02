using AutoMapper;
using CarWashApp.DTOs;
using CarWashApp.DTOs.PaginationDTO;
using CarWashApp.DTOs.ReservationDTOs;
using CarWashApp.Entities;
using CarWashApp.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarWashApp.Controllers
{
    [Route("api/shop")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly UserManager<GeneralUser> userManager;

        public ShopController(ApplicationDbContext context, IMapper mapper, UserManager<GeneralUser> userManager)
        {
            this.context = context;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        // PAGINACIJA
        [HttpGet("getAllShopsFromOwnerOrConsumer")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "UserPolicy")]
        public async Task<ActionResult<List<ShopDTO>>> Get([FromQuery] PaginationDTO paginationDTO)
        {         
            var currentUser = await userManager.FindByNameAsync(User.Identity.Name);
            bool isOwner = User.IsInRole("Owner");

            IQueryable<Shop> queryable;

            if (isOwner)
            {
                queryable = context.Shops.Where(x => x.OwnerId == currentUser.Id).AsQueryable();
            }
            else
            {
                queryable = context.Shops.AsQueryable();
            }

            await HttpContext.InsertPaginationParametersInResponse(queryable, paginationDTO.RecordsPerPage);
            var shops = await queryable.Paginate(paginationDTO).ToListAsync();
            var shopsDTOs = mapper.Map<List<ShopDTO>>(shops);

            return shopsDTOs;
        }

        [HttpGet("getShopByIdFromOwnerOrConsumer/{shopId:int}", Name = "getShop")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "UserPolicy")]
        public async Task<ActionResult<ShopDTO>> Get(int shopId)
        {
            var shop = await context.Shops.FirstOrDefaultAsync(x => x.ShopId == shopId);
            var currentUser = await userManager.FindByNameAsync(User.Identity.Name);
            bool isOwner = User.IsInRole("Owner");

            if (shop == null || (isOwner && shop.OwnerId != currentUser.Id))
            {
                return NotFound("Shop with this number ID doesn't exist! Please try again!");
            }

            var shopDTO = mapper.Map<ShopDTO>(shop);

            return shopDTO;
        }

        [HttpPost("postShopFromOwner")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Owner")]
        public async Task<ActionResult> Post([FromBody] ShopCreationDTO shopCreationDTO)
        {
            var ownerId = await userManager.FindByNameAsync(User.Identity.Name);
            var shop = mapper.Map<Shop>(shopCreationDTO);
            shop.OwnerId = ownerId.Id;
            context.Add(shop);
            await context.SaveChangesAsync();
            var shopDTO = mapper.Map<ShopDTO>(shop);

            return new CreatedAtRouteResult("getShop", shopDTO);
        }

        [HttpPut("putShopByIdFromOwner/{shopId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "UserPolicy")]
        public async Task<ActionResult> Put(int shopId, [FromBody] ShopCreationDTO shopCreationDTO)
        {
            var shop = await context.Shops.FirstOrDefaultAsync(x => x.ShopId == shopId);
            if (shop == null)
            {
                return NotFound("Service with this number ID doesn't exist! Please try again!");
            }

            if (shop.OwnerId == userManager.GetUserId(HttpContext.User))
            {
                shop = mapper.Map(shopCreationDTO, shop);
                await context.SaveChangesAsync();
                return NoContent();
            }
            else
            {
                return BadRequest("You don't have permition to access or modify!");
            }
        }

        [HttpDelete("deleteShopByIdFromOwner/{shopId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Owner")]
        public async Task<ActionResult> Delete(int shopId)
        {
            var exists = await context.Shops.AnyAsync(x => x.ShopId == shopId);
            if (!exists)
            {
                return NotFound();
            }

            context.Remove(new Shop() { ShopId = shopId });
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}

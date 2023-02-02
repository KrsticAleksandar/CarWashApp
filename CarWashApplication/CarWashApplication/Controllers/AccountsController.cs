using AutoMapper;
using CarWashApp.DTOs.PaginationDTO;
using CarWashApp.DTOs.ShopDTOs;
using CarWashApp.DTOs.UserDTOs;
using CarWashApp.Entities;
using CarWashApp.Helpers;
using CarWashApp.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CarWashApp.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountsController : Controller
    {
        private readonly UserManager<GeneralUser> _userManager;
        private readonly SignInManager<GeneralUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public AccountsController(
            UserManager<GeneralUser> userManager,
            SignInManager<GeneralUser> signInManager,
            IConfiguration configuration,
            ApplicationDbContext context,
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            this.context = context;
            this.mapper = mapper;
        }


        [HttpPost("createAccountFromOwnerOrConsumer")]
        public async Task<ActionResult<UserToken>> CreateUser([FromBody] UserInfo model)
        {
            var user = new GeneralUser { UserName = model.EmailAddress, Email = model.EmailAddress, FirstName = model.FirstName, LastName = model.LastName };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, model.IsOwner ? "Owner" : "Consumer"));
                return await BuildToken(model);
            }
            else
            {
                return BadRequest(result.Errors);
            }


        }

        private async Task<UserToken> BuildToken(UserInfo userInfo)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, userInfo.EmailAddress),
                new Claim(ClaimTypes.Email, userInfo.EmailAddress),
            };

            var identityUser = await _userManager.FindByEmailAsync(userInfo.EmailAddress);
            var claimsDB = await _userManager.GetClaimsAsync(identityUser);

            claims.AddRange(claimsDB);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddYears(1);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expiration,
                signingCredentials: creds
                );

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }

        [HttpPost("loginIntoAccountFromOwnerOrConsumer")]
        public async Task<ActionResult<UserToken>> Login([FromBody] UserLogInDTO model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.EmailAddress, model.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return await BuildToken(new UserInfo() { EmailAddress = model.EmailAddress, Password = model.Password });

            }
            else
            {
                return BadRequest("Invalid login attempt! Check that you are filled all correct and try again!");
            }
        }

        [HttpGet("getShopRevenueByShopIdFromOwner/{shopId:Int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Owner")]
        public async Task<ActionResult<ShopRevenueDTO>> GetRevenue(int shopId)
        {
            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);

            var shop = await context.Shops
                .Include(x => x.Reservations)
                .ThenInclude(x => x.Service)
                .FirstOrDefaultAsync(x => x.ShopId == shopId);

            if (shop == null || shop.OwnerId != currentUser.Id)
            {
                return BadRequest("Shop with this number ID doesn't exist! Please try again!");
            }

            var shopRevenue = mapper.Map<ShopRevenueDTO>(shop);
            return (shopRevenue);
        }
    }
}





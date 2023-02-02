using AutoMapper;
using CarWashApp.DTOs.ServiceDTOs;
using CarWashApp.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarWashApp.Controllers
{

        [Route("api/service")]
        [ApiController]
        public class ServiceController : ControllerBase
        {
            private readonly ApplicationDbContext context;
            private readonly IMapper mapper;

            public ServiceController(ApplicationDbContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }

            [HttpGet("getAllServicesFromOwnerOrConsumer")]
            [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
            public async Task<ActionResult<List<ServiceDTO>>> Get()
            {
                var services = await context.Services.AsNoTracking().ToListAsync();
                var servicesDTOs = mapper.Map<List<ServiceDTO>>(services);
                return servicesDTOs;
            }

            [HttpGet("getServiceByIdFromOwnerOrConsumer{serviceId:int}", Name = "getService")]
            [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
            public async Task<ActionResult<ServiceDTO>> Get(int serviceId)
            {
                var service = await context.Services.FirstOrDefaultAsync(x => x.ServiceId == serviceId);

                if (service == null)
                {
                    return NotFound("Service with this number ID doesn't exist! Please try again!");
            }

                var serviceDTO = mapper.Map<ServiceDTO>(service);

                return serviceDTO;
            }

            [HttpPost("postServiceFromOwner")]
            [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Owner")]
            public async Task<ActionResult> Post([FromBody] ServiceCreationDTO serviceCreationDTO)
            {
                var service = mapper.Map<Service>(serviceCreationDTO);
                context.Add(service);
                await context.SaveChangesAsync();
                var serviceDTO = mapper.Map<ServiceDTO>(service);

                return new CreatedAtRouteResult("getService", serviceDTO);
            }

            [HttpPut("putServiceByIdFromOwner{serviceId:int}")]
            [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Owner")]
            public async Task<ActionResult<ServiceDTO>> Put(int serviceId, [FromBody] ServiceCreationDTO serviceCreationDTO)
            {
                var service = await context.Services.FirstOrDefaultAsync(x => x.ServiceId == serviceId);
                if (service == null)
                {
                    return NotFound("Service with this number ID doesn't exist! Please try again!");
                }
                service = mapper.Map(serviceCreationDTO, service);

                context.Entry(service).State = EntityState.Modified;
                await context.SaveChangesAsync();

                var serviceDTO = mapper.Map<ServiceDTO>(service);
                return serviceDTO;
            }

            [HttpDelete("deleteServiceByIdFromOwner/{serviceId:int}")]
            [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Owner")]
            public async Task<ActionResult> Delete(int serviceId)
            {
                var exists = await context.Services.AnyAsync(x => x.ServiceId == serviceId);
                if (!exists)
                {
                    return NotFound("Service with this number ID doesn't exist! Please try again!");
                }

                context.Remove(new Service() { ServiceId = serviceId });
                await context.SaveChangesAsync();
                return NoContent();
            }
        }
}

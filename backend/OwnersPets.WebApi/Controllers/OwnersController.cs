using OwnersPets.Core.DTOs;
using OwnersPets.Core.Interfaces;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace OwnersPets.WebApi.Controllers
{
    public class OwnersController : ApiController
    {
        private IOwnerService ownerService;

        public OwnersController(IOwnerService ownerService)
        {
            this.ownerService = ownerService;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetAll()
        {
            var result = await ownerService.GetAllAsync();

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            var result = ownerService.GetById(id);

            if (result == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            else
                return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        public HttpResponseMessage CreateOwner([FromBody] OwnerDTO owner)
        {
            if (owner == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                ownerService.Create(owner);
                return Request.CreateResponse(HttpStatusCode.Created);
            }
        }

        [HttpPut]
        public HttpResponseMessage UpdateOwner([FromBody] OwnerDTO owner)
        {
            if (owner == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                ownerService.Update(owner);
                
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }

        [HttpDelete]
        public HttpResponseMessage DeleteOwner(int id)
        {
            var owner = ownerService.GetById(id);
            if (owner == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                ownerService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }
    }
}

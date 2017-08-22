using OwnersPets.Core.DTOs;
using OwnersPets.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace OwnersPets.WebApi.Controllers
{
    public class PetsController : ApiController
    {
        private IPetService petsService;

        public PetsController(IPetService petsService)
        {
            this.petsService = petsService;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetAll()
        {
            var result = await petsService.GetAllAsync();

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            var result = petsService.GetById(id);

            if (result == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            else
                return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        public HttpResponseMessage CreatePet([FromBody] PetDTO pet)
        {
            if (pet == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                petsService.Create(pet);
                return Request.CreateResponse(HttpStatusCode.Created);
            }
        }

        [HttpPut]
        public HttpResponseMessage UpdatePet([FromBody] PetDTO pet)
        {
            if (pet == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                petsService.Update(pet);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }

        [HttpDelete]
        public HttpResponseMessage DeletePet(int id)
        {
            var pet = petsService.GetById(id);
            if (pet == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                petsService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }
    }
}

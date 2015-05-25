using PensioenSysteem.Domain.Deelnemer.Commands;
using PensioenSysteem.Infrastructure;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PensioenSysteem.Application.Deelnemer.Controllers
{
    public class DeelnemerController : ApiController
    {
        /// <summary>
        /// POST /api/deelnemer
        /// </summary>
        /// <param name="command">Het command om een deelnemer te registreren.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/deelnemer")]
        public HttpResponseMessage Create([FromBody] RegistreerDeelnemerCommand command)
        {
            var deelnemer = new PensioenSysteem.Domain.Deelnemer.Deelnemer();
            deelnemer.Registreer(command);

            var repo = new EventSourcedAggregateRepository<PensioenSysteem.Domain.Deelnemer.Deelnemer>(
                new FileEventStore(new RabbitMQEventPublisher()));
            repo.Save(deelnemer, -1);

            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        /// <summary>
        /// PUT /api/deelnemer/{id}/verhuis
        /// </summary>
        /// <param name="command">Het command om een deelnemer te verhuizen.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/deelnemer/{id}/verhuis")]
        public HttpResponseMessage Verhuis(Guid id, [FromBody] VerhuisDeelnemerCommand command)
        {
            var repo = new EventSourcedAggregateRepository<PensioenSysteem.Domain.Deelnemer.Deelnemer>(
                new FileEventStore(new RabbitMQEventPublisher()));

            Domain.Deelnemer.Deelnemer deelnemer;
            try
            {
                deelnemer = repo.GetById(id);
            }
            catch (AggregateNotFoundException ex)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            deelnemer.Verhuis(command);
            
            repo.Save(deelnemer, command.Version);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        /// <summary>
        /// GET /api/deelnemer/{id}
        /// </summary>
        [HttpGet]
        [Route("api/deelnemer/{id}")]
        public Domain.Deelnemer.Deelnemer Get(Guid id)
        {
            var repo = new EventSourcedAggregateRepository<PensioenSysteem.Domain.Deelnemer.Deelnemer>(
                new FileEventStore(new RabbitMQEventPublisher()));
            var deelnemer = repo.GetById(id);
            return deelnemer;
        }
    }
}

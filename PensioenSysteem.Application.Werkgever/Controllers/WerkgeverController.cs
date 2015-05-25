using PensioenSysteem.Domain.Werkgever.Commands;
using PensioenSysteem.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PensioenSysteem.Application.Deelnemer.Controllers
{
    public class WerkgeverController : ApiController
    {
        /// <summary>
        /// POST /api/werkgever
        /// </summary>
        /// <param name="command">Het command om een werkgever te registreren.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/werkgever")]
        public HttpResponseMessage Create([FromBody] RegistreerWerkgeverCommand command)
        {
            var werkgever = new PensioenSysteem.Domain.Werkgever.Werkgever();
            werkgever.Registreer(command);

            var repo = new EventSourcedAggregateRepository<PensioenSysteem.Domain.Werkgever.Werkgever>(
                new FileEventStore(new RabbitMQEventPublisher()));
            repo.Save(werkgever, -1);

            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        /// <summary>
        /// GET /api/werkgever/{id}
        /// </summary>
        [HttpGet]
        [Route("api/werkgever/{id}")]
        public Domain.Werkgever.Werkgever Get(Guid id)
        {
            var repo = new EventSourcedAggregateRepository<PensioenSysteem.Domain.Werkgever.Werkgever>(
                new FileEventStore(new RabbitMQEventPublisher()));
            var werkgever = repo.GetById(id);
            return werkgever;
        }
    }
}

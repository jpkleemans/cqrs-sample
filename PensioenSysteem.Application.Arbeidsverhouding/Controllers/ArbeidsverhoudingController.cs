using PensioenSysteem.Domain.Arbeidsverhouding.Commands;
using PensioenSysteem.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PensioenSysteem.Application.Deelnemer.Controllers
{
    public class ArbeidsverhoudingController : ApiController
    {
        /// <summary>
        /// POST /api/arbeidsverhouding
        /// </summary>
        /// <param name="command">Het command om een arbeidsverhouding te registreren.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/arbeidsverhouding")]
        public HttpResponseMessage Create([FromBody] RegistreerArbeidsverhoudingCommand command)
        {
            var arbeidsverhouding = new PensioenSysteem.Domain.Arbeidsverhouding.Arbeidsverhouding();
            arbeidsverhouding.Registreer(command);

            var repo = new EventSourcedAggregateRepository<PensioenSysteem.Domain.Arbeidsverhouding.Arbeidsverhouding>(
                new FileEventStore(new RabbitMQEventPublisher()));
            repo.Save(arbeidsverhouding, -1);

            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        /// <summary>
        /// GET /api/arbeidsverhouding/{id}
        /// </summary>
        /// <param name="command">Het command om een arbeidsverhouding te registreren.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/arbeidsverhouding/{id}")]
        public Domain.Arbeidsverhouding.Arbeidsverhouding Get(Guid id)
        {
            var repo = new EventSourcedAggregateRepository<PensioenSysteem.Domain.Arbeidsverhouding.Arbeidsverhouding>(
                new FileEventStore(new RabbitMQEventPublisher()));
            var arbeidsverhouding = repo.GetById(id);
            return arbeidsverhouding;
        }
    }
}

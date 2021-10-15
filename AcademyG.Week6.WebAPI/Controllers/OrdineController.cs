using AcademyG.Week6.Core.Interfaces;
using AcademyG.Week6.Core.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyG.Week6.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdineController : ControllerBase
    {
        private readonly IOrdineBL mainBusinessLayer;

        public OrdineController(IOrdineBL mainBusinessLayer)
        {
            this.mainBusinessLayer = mainBusinessLayer;
        }

        // GET: api/<OrdineController>
        [HttpGet]
        public ActionResult GetOrders()
        {
            var result = mainBusinessLayer.FetchOrdini();
            return Ok(result.ToList());
        }

        // GET api/<OrdineController>/5
        [HttpGet("{id}")]
        public ActionResult GetOrderBy(int id)
        {
            if (id <= 0)
                return BadRequest("ID Non valido");

            var result = mainBusinessLayer
                .FetchOrdini(o => o.Id == id)
                .FirstOrDefault();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // POST api/<OrdineController>
        [HttpPost]
        public ActionResult PostOrder([FromBody] Ordine ordine)
        {
            if (ordine == null)
                return BadRequest("Errore. Ordine non valido");

            var result = mainBusinessLayer
                .CreaOrdine(ordine);

            if (!result)
                return BadRequest();

            return CreatedAtAction(
                "OrdinePerId",
                new { id = ordine.Id },
                ordine);
        }

        // PUT api/<OrdineController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Ordine ordine)
        {
            if (ordine == null || id != ordine.Id)
                return BadRequest("Errore. Ordine non valido");

            var result = mainBusinessLayer
                .ModificaOrdine(ordine);

            if (!result)
                return BadRequest();

            return Ok(ordine);
        }

        // DELETE api/<OrdineController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Id non valido");

            var order = mainBusinessLayer
                .FetchOrdini(o => o.Id == id)
                .FirstOrDefault();

            if (order == null)
                return NotFound("Ordine non trovato");

            var result = mainBusinessLayer
                .CancellaOrdine(order);

            if (!result)
                return BadRequest();

            return Ok();
        }

        
        [HttpGet("anno")]
        public ActionResult OrdiniPerAnno()
        {
            var result = mainBusinessLayer
                .FetchOrdini()
                .GroupBy(
                    o => o.DataOrdine.Year,
                    (key, grp) => new {
                        Anno = key,
                        Numero = grp.Count(),
                        TotalAmount = grp.Sum(o => o.Importo)
                    }
                 );

            return Ok(result);
        }

        [HttpGet("cliente/{clienteId}")]
        public ActionResult OrdiniPerCliente(int clienteId)
        {
            if (clienteId <= 0)
                return BadRequest("Id non valido");

            var result = mainBusinessLayer
                .FetchOrdini(o => o.Cliente.Id == clienteId);

            return Ok(result);
        }

    }
}

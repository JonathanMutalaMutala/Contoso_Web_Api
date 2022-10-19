using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ContosoPizza_Api.Services;
using ContosoPizza_Api.Models; 
namespace ContosoPizza_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {

        // [HttpGet]
        //public IActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();

        /// <summary>
        /// Permet de recuperer les pizza
        /// </summary>
        /// <returns>Return pizza object</returns>
        [HttpGet]
        public IActionResult GetAllPizza()
        {
            return Ok(PizzaService.GetAll());
        }

        [HttpGet]
        [Route("id")]
        public IActionResult GetSinglePizza(int id)
        {
            return Ok(PizzaService.Get(id));
        }

        [HttpPost]
        public IActionResult CreatePizza(Pizza pizza)
        {
             PizzaService.Add(pizza);
            //return CreatedAtAction(nameof(CreatePizza), new { id = pizza.Id }, pizza);
             return Ok();    
        }

        [HttpPut]
        public IActionResult UpdatePizza(int id, Pizza pizza)
        {
            if (id != pizza.Id)
                return BadRequest();

            var existingPizza = PizzaService.Get(id);
            if (existingPizza is null)
                return NotFound();

            PizzaService.Update(pizza);

            return NoContent();
            
        }


        [HttpDelete]
        public IActionResult DeletePizza(int id)
        {
            var pizza = PizzaService.Get(id);

            if (pizza is null)
                return NotFound();

            PizzaService.Delete(id);

            return NoContent();
        }

    }
}

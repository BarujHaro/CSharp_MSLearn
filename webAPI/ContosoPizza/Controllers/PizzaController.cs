using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    public PizzaController()
    {
    }


/*The first REST verb that you need to implement is GET, where a client can get all pizzas from the API. You can use the built-in [HttpGet] attribute to define a method that returns the pizzas from our service.

Replace the // GET all action comment in Controllers/PizzaController.cs with the following code:*/
    [HttpGet]
    public ActionResult<List<Pizza>> GetAll() =>
        PizzaService.GetAll();

    // GET by Id action
/*Retrieve a single pizza
The client might also want to request information about a specific pizza instead of the entire list. You can implement another GET action that requires an id parameter.*/
    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        var pizza = PizzaService.Get(id);

        if(pizza == null)
            return NotFound();

        return pizza;
    }

    // POST action
/*Add a pizza
Let's enable a pizza to be added through the web API by using a POST method.

Replace the // POST action comment in Controllers/PizzaController.cs with the following code:*/
    [HttpPost]
    public IActionResult Create(Pizza pizza)
    {            
        PizzaService.Add(pizza);
        return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
    }

    // PUT action
/*Modify a pizza
Now, let's enable a pizza to be updated through the web API by using a PUT method.

Replace the // PUT action comment in Controllers/PizzaController.cs with the following code:*/
    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        if (id != pizza.Id)
            return BadRequest();
            
        var existingPizza = PizzaService.Get(id);
        if(existingPizza is null)
            return NotFound();
    
        PizzaService.Update(pizza);           
    
        return NoContent();
    }


    // DELETE action
    /*Remove a pizza
Finally, let's enable a pizza to be removed through the web API by using a DELETE method.

Replace the // DELETE action comment in Controllers/PizzaController.cs with the following code:*/

[HttpDelete("{id}")]
public IActionResult Delete(int id)
{
    var pizza = PizzaService.Get(id);
   
    if (pizza is null)
        return NotFound();
       
    PizzaService.Delete(id);
   
    return NoContent();
}

}
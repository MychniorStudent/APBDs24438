using AnimalManager.DTOs;
using AnimalManager.Interfaces;
using AnimalManager.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
namespace AnimalManager.Controllers;

[ApiController]
[Route("api")]
//[Route("api/animals")]
public class AnimalController : ControllerBase
{
    IAnimalRepository _animalRepository;
    public AnimalController(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }

    [HttpGet("animals/{orderBy?}")]
    public ActionResult GetAnimal(string? orderBy = "")//([FromQuery(Name = "orderBy")] string orderBy)
    {
        return Ok(_animalRepository.getAnimalsOrdered(orderBy));
    }

    [HttpPost("animals")]
    public ActionResult AddAnimal([FromBody] AnimalDTO animal)
    {
        Animal newAnimal = new Animal();
        newAnimal.Name = animal.Name;
        newAnimal.Description = animal.Description;
        newAnimal.Area = animal.Area;
        newAnimal.Category = animal.Category;
        if(_animalRepository.AddAnimal(newAnimal))
            return Ok();
        else 
            return BadRequest();
    }

    [HttpPut("animals")]
    public ActionResult EditAnimal([FromBody] AnimalDTO animal, [FromQuery] int animalId) 
    {
        Animal newAnimal = new Animal();
        newAnimal.Name = animal.Name;
        newAnimal.Description = animal.Description;
        newAnimal.Area = animal.Area;
        newAnimal.Category = animal.Category;
        if (_animalRepository.EditAnimal(animalId, newAnimal))
            return Ok();
        else
            return BadRequest();
    }

    [HttpDelete("animals/{animalId}")]
    public ActionResult DeleteAnimal(int animalId)
    {
        if(_animalRepository.DeleteAnimal(animalId))
            return Ok();
        else 
            return BadRequest();
    }
}
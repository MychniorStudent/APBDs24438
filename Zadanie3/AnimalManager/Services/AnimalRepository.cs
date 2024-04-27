using AnimalManager.Interfaces;
using AnimalManager.Models;

namespace AnimalManager.Services;

public class AnimalRepository : IAnimalRepository
{
    private IDBRepository _dbRepository;
    public AnimalRepository(IDBRepository dbRepository)
    {
        _dbRepository = dbRepository;
    }
    public bool AddAnimal(Animal animal)
    {
        return _dbRepository.AddAnimal(animal);
    }

    public bool DeleteAnimal(int animalId)
    {
        Animal oldAnimal = _dbRepository.GetAnimalById(animalId);
        if (oldAnimal == null)
        {
            return false;
        }
       return _dbRepository.DeleteAnimal(animalId);
    }

    public bool EditAnimal(int animalId, Animal newAnimal)
    {
        Animal oldAnimal = _dbRepository.GetAnimalById(animalId);
        if (oldAnimal == null)
        {
            return false;
        }
      return _dbRepository.UpdateAnimal(animalId, newAnimal,oldAnimal);
    }

    public List<Animal> getAnimalsOrdered(string orderBy)
    {
        if(orderBy.ToLower() == "name" || orderBy == null)
            return _dbRepository.GetAllAnimals().OrderBy(x=>x.Name).ToList();
        else if (orderBy.ToLower() == "name")
            return _dbRepository.GetAllAnimals().OrderBy(x => x.Description).ToList();
        else if (orderBy.ToLower() == "category")
            return _dbRepository.GetAllAnimals().OrderBy(x => x.Category).ToList();
        else if (orderBy.ToLower() == "area")
            return _dbRepository.GetAllAnimals().OrderBy(x => x.Area).ToList();
        else
            throw new Exception(String.Format("Nie można posortować po polu \"{0}\"",orderBy));

    }
}
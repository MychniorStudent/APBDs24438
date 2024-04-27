using AnimalManager.Models;

namespace AnimalManager.Interfaces;

public interface IAnimalRepository
{
    List<Animal> getAnimalsOrdered(string orderBy);
    bool AddAnimal(Animal animal);

    bool EditAnimal(int animalId, Animal newAnimal);
    bool DeleteAnimal(int animalId);
}
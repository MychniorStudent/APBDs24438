using AnimalManager.Models;

namespace AnimalManager.Interfaces
{
    public interface IDBRepository
    {
        List<Animal> GetAllAnimals();
        Animal GetAnimalById(int id);
        public bool UpdateAnimal(int id, Animal animal, Animal oldAnimal);
        public bool DeleteAnimal(int id);
        public bool AddAnimal(Animal animal);
    }
}

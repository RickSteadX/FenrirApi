namespace FenrirApi.Entities
{
    public interface IPersonRepository
    {
        Person GetById(Guid id);
        IEnumerable<Person> GetAll();
        void Add(Person person);
        void Update(Person person);
        void Delete(Person person);
        void SaveChanges();
    }
    public class PersonRepository : IPersonRepository
    {
        private readonly FenrirDbContext _dbContext;

        public PersonRepository(FenrirDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Person person)
        {
            _dbContext.Persons.Add(person);
        }

        public void Delete(Person person)
        {
            _dbContext.Persons.Remove(person);
        }

        public IEnumerable<Person> GetAll()
        {
            return _dbContext.Persons.ToList();
        }

        public Person GetById(Guid id)
        {
            return _dbContext.Persons.SingleOrDefault(x => x.Id == id);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Update(Person person)
        {
            _dbContext.Persons.Update(person);
        }
    }
}

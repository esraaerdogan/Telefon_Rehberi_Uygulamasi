using Microsoft.EntityFrameworkCore;
using TelRehAPI.Data;
using TelRehAPI.Models.Domain;
using TelRehAPI.Repositories.Interface;

namespace TelRehAPI.Repositories.Implementation{
    public class PersonRepository : IPersonRepository{
        private readonly TelDbContext dbContext;
        public PersonRepository(TelDbContext dbContext){
            this.dbContext = dbContext;
        }
        public async Task<Contact> CreateAsync(Contact person){
            
            await dbContext.Contact.AddAsync(person);
            await dbContext.SaveChangesAsync();

            return person;
        }
        public async Task<IEnumerable<Contact>> GetAllAsync(){
            return await dbContext.Contact.ToListAsync();
        }
        public async Task<Contact?> GetById(Guid id){
            return await dbContext.Contact.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Contact?> UpdateAsync(Contact person){
            var existingPerson = await dbContext.Contact.FirstOrDefaultAsync(x => x.Id == person.Id);
            if (existingPerson != null){
                dbContext.Entry(existingPerson).CurrentValues.SetValues(person);
                await dbContext.SaveChangesAsync();
                return person;
            }
            return null;
        }
        public async Task<Contact?> DeleteAsync(Guid id){
            var existingPerson = await dbContext.Contact.FirstOrDefaultAsync(x => x.Id == id);
            if (existingPerson is null){
                return null;
            }

            dbContext.Contact.Remove(existingPerson);
            await dbContext.SaveChangesAsync();
            return existingPerson;
        }
        public async Task<Contact?> GetByFirstNameAndLastNameAsync(string firstName, string lastName)
        {
        return await dbContext.Contact
          .Where(p => p.FirstName == firstName && p.LastName == lastName)
          .FirstOrDefaultAsync();
        }

    }
}

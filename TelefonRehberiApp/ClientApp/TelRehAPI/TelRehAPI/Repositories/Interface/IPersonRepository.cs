using TelRehAPI.Models.Domain;
namespace TelRehAPI.Repositories.Interface
{
    public interface IPersonRepository
    {
        Task<Contact> CreateAsync(Contact Person);

        Task<IEnumerable<Contact>> GetAllAsync();

        Task<Contact?> GetById(Guid id);

        Task<Contact?> UpdateAsync(Contact Person);

        Task<Contact?> DeleteAsync(Guid id);
        Task<Contact?> GetByFirstNameAndLastNameAsync(string firstName, string lastName);


    }
}

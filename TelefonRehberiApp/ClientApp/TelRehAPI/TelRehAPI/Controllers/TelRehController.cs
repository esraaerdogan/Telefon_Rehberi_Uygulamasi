using Microsoft.AspNetCore.Mvc;
using TelRehAPI.Models.Domain;
using TelRehAPI.Models.DTO;
using TelRehAPI.Repositories.Implementation;
using TelRehAPI.Repositories.Interface;
using TelRehAPI.Services; 

namespace TelRehAPI.Controllers{

  [Route("api/[controller]")]
  [ApiController]
  public class TelRehController : ControllerBase{
    private readonly IPersonRepository personRepository;
    private readonly ILoggingService _loggingService;

    public TelRehController(IPersonRepository personRepository, ILoggingService loggingService){
      this.personRepository = personRepository;
      this._loggingService = loggingService;
    }

    [HttpPost] 
    public async Task<IActionResult> CreatePerson([FromBody] CreatePersonRequestDto request){
      try{
        var existingPerson = await personRepository.GetByFirstNameAndLastNameAsync(request.FirstName, request.LastName);
        if (existingPerson != null){
           await _loggingService.LogWarningAsync("Bu isimle zaten bir kişi kayıtlı: " + request.FirstName + " " + request.LastName);
           return BadRequest("Bu isimle zaten bir kişi kayıtlı.");
        }

        var person = new Contact{
          FirstName = request.FirstName,
          LastName = request.LastName,
          PhoneNumber = request.PhoneNumber,
          Email = request.Email
        };

        await personRepository.CreateAsync(person);
        await _loggingService.LogInfoAsync("Yeni kişi eklendi: " + person.FirstName + " " + person.LastName);

        var response = new PersonDto{
          Id = person.Id,
          FirstName = person.FirstName,
          LastName = person.LastName,
          PhoneNumber = person.PhoneNumber,
          Email = person.Email
        };

        return Ok(response);
      }
      catch (Exception ex) { 
        await _loggingService.LogErrorAsync("Kişi eklenirken bir hata oluştu.", ex);
        return StatusCode(500, "An error occurred while creating the person.");
      }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPerson(){
      try{
        var Contact = await personRepository.GetAllAsync();

        var response = Contact.Select(person => new PersonDto{
          Id = person.Id,
          FirstName = person.FirstName,
          LastName = person.LastName,
          PhoneNumber = person.PhoneNumber,
          Email = person.Email
        }).ToList();

        await _loggingService.LogInfoAsync("Tüm kişiler getirildi.");
        return Ok(response);
      }
      catch (Exception ex){
        await _loggingService.LogErrorAsync("Kişiler getirilirken bir hata oluştu.", ex);
        return StatusCode(500, "Kişiler alınırken bir hata oluştu.");
      }
    }
      

    [HttpGet]
    [Route("{id:Guid}")]
    public async Task<IActionResult> GetPersonById([FromRoute] Guid id){
      try{
        var existingPerson = await personRepository.GetById(id);
        if (existingPerson is null){
          await _loggingService.LogWarningAsync($"Kişi bulunamadı: ID = {id}");
          return NotFound();
        }

        var response = new PersonDto{
          Id = existingPerson.Id,
          FirstName = existingPerson.FirstName,
          LastName = existingPerson.LastName,
          PhoneNumber = existingPerson.PhoneNumber,
          Email = existingPerson.Email
        };

        await _loggingService.LogInfoAsync("Kişi getirildi: " + existingPerson.FirstName + " " + existingPerson.LastName);
        return Ok(response);
      }
      catch (Exception ex){
        await _loggingService.LogErrorAsync("Kişi getirilirken bir hata oluştu.", ex);
        return StatusCode(500, "Kişiler alınırken bir hata oluştu");
      }
    }

    [HttpPut]
    [Route("{id:Guid}")]
    public async Task<IActionResult> EditPerson([FromRoute] Guid id, UpdatePersonRequestDto request){
      try{
        var person = new Contact{
          Id = id,
          FirstName = request.FirstName,
          LastName = request.LastName,
          PhoneNumber = request.PhoneNumber,
          Email = request.Email
        };

        person = await personRepository.UpdateAsync(person);
        if (person == null){
          await _loggingService.LogWarningAsync($"Güncelleme için kişi bulunamadı: ID = {id}");
          return NotFound();
        }

        var response = new PersonDto{
          Id = person.Id,
          FirstName = person.FirstName,
          LastName = person.LastName,
          PhoneNumber = person.PhoneNumber,
          Email = person.Email
        };

        await _loggingService.LogInfoAsync("Kişi güncellendi: " + person.FirstName + " " + person.LastName);
        return Ok(response);
      }
      catch (Exception ex){
        await _loggingService.LogErrorAsync("Kişi güncellenirken bir hata oluştu.", ex);
        return StatusCode(500, "Kişiler alınırken bir hata oluştu.");
      }
    }

    [HttpDelete]
    [Route("{id:Guid}")]
    public async Task<IActionResult> DeletePerson([FromRoute] Guid id){
      try{
        var person = await personRepository.DeleteAsync(id);
        if (person is null){
          await _loggingService.LogWarningAsync($"Silinecek kişi bulunamadı: ID = {id}");
          return NotFound();
        }

        var response = new PersonDto{
          Id = person.Id,
          FirstName = person.FirstName,
          LastName = person.LastName,
          PhoneNumber = person.PhoneNumber,
          Email = person.Email
        };

        await _loggingService.LogInfoAsync("Kişi silindi: " + person.FirstName + " " + person.LastName);
        return Ok(response);
      }
      catch (Exception ex){
        await _loggingService.LogErrorAsync("Kişi silinirken bir hata oluştu.", ex);
        return StatusCode(500, "Kişiler alınırken bir hata oluştu.");
      }
    }  
  }
}

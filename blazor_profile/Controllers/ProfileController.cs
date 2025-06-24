using Microsoft.AspNetCore.Mvc;
using blazor_profile.Domain;
using blazor_profile.Repositories; 
namespace blazor_profile.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProfileController : ControllerBase
{
        private readonly ProfileImplementation _repository;

        public ProfileController(ProfileImplementation repository)
        {
            _repository = repository;
        }
        [HttpPost]

    public  ActionResult CreateProfile(Profile profile)
        {

            try
            {
                _repository.InputProfile(profile);
                Console.WriteLine("First name " + profile.FirstName + " Last Name " + profile.LastName + " Phone Number " + profile.PhoneNumber + " Email " + profile.Email);
                return Ok("The profile was created!");
            }

            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                return Conflict(ex.Message);
            }

        }

    [HttpPut]

    public  ActionResult UpdateProfile(Profile profile)
        {
            try
            {
                _repository.ChangeProfile(profile);
                Console.WriteLine("First name " + profile.FirstName + " Last Name " + profile.LastName + " Phone Number " + profile.PhoneNumber + " Email " + profile.Email);

                return Ok("The profile was updated!");
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return NotFound(ex.Message);
            }
        }
 
}
}

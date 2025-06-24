
using blazor_profile.Domain;
using blazor_profile.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
namespace blazor_profile.Repositories
{
    public class ProfileImplementation
    {
        public Profile InputProfile(Profile profile)
        {
            var existingProfile = DataStructure.profiles.FirstOrDefault(p => p.Id == profile.Id);

            if (existingProfile != null)
            {

                throw new InvalidOperationException("Profile ID exists. Please enter a new ID for creation.");

            }
            DataStructure.profiles.Add(profile);
            return profile;
        }

        public Profile ChangeProfile(Profile profile)
        {

            var existingProfile = DataStructure.profiles.FirstOrDefault(p  => p.Id == profile.Id);

            if (existingProfile == null)
            {

                throw new KeyNotFoundException("Profile Id not Found");

            }


            existingProfile.PhoneNumber = profile.PhoneNumber;
            existingProfile.FirstName = profile.FirstName;
            existingProfile.LastName = profile.LastName;
            existingProfile.Email = profile.Email;
              
           
            
            return profile;
        }
    }
}

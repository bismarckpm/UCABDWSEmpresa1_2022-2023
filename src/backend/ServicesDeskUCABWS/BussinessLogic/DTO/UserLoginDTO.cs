using System.ComponentModel.DataAnnotations;

namespace ServicesDeskUCABWS.BussinessLogic.DTO
{
    public class UserLoginDTO
    {

        [Required,EmailAddress]
        public string? Email {get; set;}

        [Required]
        public string? Password {get; set;}
    }
}
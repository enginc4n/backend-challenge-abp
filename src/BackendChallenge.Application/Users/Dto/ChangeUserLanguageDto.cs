using System.ComponentModel.DataAnnotations;

namespace BackendChallenge.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
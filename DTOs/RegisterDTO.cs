using System.ComponentModel.DataAnnotations;

namespace MyApp.DTOs
{
    public class RegisterDTO
    {
        [Required] public string UserName { get; set; }
        [Required] public string UserEmail{ get; set; }
        [Required] public string fotoTitle{ get; set; }
        public string UserSubject { get; set; }
    }
}
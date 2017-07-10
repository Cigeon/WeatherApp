using System.ComponentModel.DataAnnotations;

namespace WeatherApp.Models
{
    public class SelectedCity
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]        
        public string Text { get; set; }
        public string Value { get; set; }
    }
}
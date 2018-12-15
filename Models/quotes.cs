using System.ComponentModel.DataAnnotations;
namespace quotingdojo.Models
{
    public class Post
    {
        [Required]
        [MinLength(3)]
        [Display(Name = "Name:")]
        public string Name{get; set;}


        [Required]
        [MinLength(3)]
        [MaxLength(255)]
        [Display(Name = "Your Quote:")]
        public string Quote{get;set;}
    }
}
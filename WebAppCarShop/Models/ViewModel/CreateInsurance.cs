using System.ComponentModel.DataAnnotations;

namespace WebAppCarShop.Models.ViewModel
{
    public class CreateInsurance
    {
        [Required]
        [StringLength(120, MinimumLength = 2)]
        public string Name { get; set; }

        public CreateInsurance() //Model binding in controller needs a Zero constructor to be present
        {

        }
    }
}
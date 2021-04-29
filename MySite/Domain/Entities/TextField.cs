using System.ComponentModel.DataAnnotations;

namespace MySite.Domain.Entities
{
    public class TextField : EntityBase
    {
        [Required]
        public string CodeWord { get; set; }

        [Display(Name = "Title (heading)")]
        public override string Title { get; set; } = "Info page";

        [Display(Name = "Page content")] 
        public override string Text { get; set; } = "Content can only be filled by admin";
    }
}

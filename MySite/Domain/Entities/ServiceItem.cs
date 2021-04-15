using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySite.Domain.Entities
{
    public class ServiceItem : EntityBase
    {
        [Required(ErrorMessage = "Fill the service name field")]
        [Display(Name = "Service name")]
        public override string Title { get; set; }

        [Display(Name = "Service short description")]
        public override string Subtitle { get; set; }

        [Display(Name = "Service full description")]
        public override string Text { get; set; }
    }
}

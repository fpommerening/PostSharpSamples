using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FP.PostSharpSamples.UI.Business
{
    [ErrorHandlerAspect]
    public class TestViewModel : BaseErrorViewModel
    {
        [Required(AllowEmptyStrings = false)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DisplayName("Vorname")]
        public string FirstName { get; set; }


        [DisplayName("E-Mail Adresse")]
        [EmailAddress]
        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; }
    }
}

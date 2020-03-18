using Dentist.Entities.Model;
using System.Collections.Generic;

namespace Dentist.Entities.Dto
{
    public class FooterViewModel
    {
        public string Address { get; set; }
        public string Phone { get; set; }
        public string FaceIconAddress { get; set; }
        public string GoogleIconAddress { get; set; }
        public string LinkedinIconAddress { get; set; }
        public string TwitterIconAddress { get; set; }

        public List<Global> contactModel { get; set; }
        public List<Global> workingHourModel { get; set; }

    }
}

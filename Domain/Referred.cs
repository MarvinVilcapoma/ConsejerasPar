using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class Referred
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReferredId { get; set; }
        public int NutritionistId { get; set; }
        public Nutritionist Nutritionist { get; set; }
        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; }
        public DateTime CreatedOn { get; set; }
        [DefaultValue("true")]
        public bool Enabled { get; set; }
    }
}

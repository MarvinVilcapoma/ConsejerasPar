using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Response
{
    public class ReferredResponseV1
    {
        public int ReferredId { get; set; }
        public int NutritionistId { get; set; }
        public NutritionistResponseV1 Nutritionist { get; set; }
        public int AssignmentId { get; set; }
        public AssignmentResponseV1 Assignment { get; set; }

        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool Enabled { get; set; }
    }
}

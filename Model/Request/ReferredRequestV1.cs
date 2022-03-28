using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Request
{
    public class ReferredRequestV1
    {
        public int ReferredId { get; set; }
        public int ParticipantId { get; set; }
        public int NutritionistId { get; set; }
        public string Description { get; set; }

    }
}

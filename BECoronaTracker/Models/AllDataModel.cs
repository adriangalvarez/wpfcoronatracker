using System;
using System.Collections.Generic;
using System.Text;

namespace BECoronaTracker.Models
{
    public class AllDataModel
    {
        /// <summary>
        /// Property holding full timeline.
        /// </summary>
        public List<EachDataModel> Data { get; set; }
    }
}

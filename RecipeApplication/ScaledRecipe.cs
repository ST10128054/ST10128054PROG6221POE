using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10128054PROG6221POE
{
    public class ScaledRecipe
    {
        public string SRecName { get; set; }
        public string SIngrInfo { get; set; }
        public string SInstructions { get; set; }

        public ScaledRecipe(string sRecName, string sIngrInfo, string sInstructions)
        {
            SRecName = sRecName;
            SIngrInfo = sIngrInfo;
            SInstructions = sInstructions;
        }
    }
}

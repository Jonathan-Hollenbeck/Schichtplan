using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schichtplan.model
{
    [Serializable]
    public class Settings
    {
        public Dictionary<Person, Color> personColors { get; set; }

        public Dictionary<string, Color> shiftTypeColors { get; set; }

        public string googleSheetsId { get; set; }
        public string googleKeyPath { get; set; }

        public Settings()
        {
            personColors = new Dictionary<Person, Color>();
            shiftTypeColors = new Dictionary<string, Color>();
            googleSheetsId = "";
            googleKeyPath = "";
        }
    }
}

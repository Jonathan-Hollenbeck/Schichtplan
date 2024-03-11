using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schichtplan.model
{
    public class ControlColorSave {

        public Control control { get; set; }

        public Color originalBackColor { get; set; }
        public Color originalForeColor { get; set; }

        public ControlColorSave(Control control, Color originalBackColor, Color originalForeColor)
        {
            this.control = control;
            this.originalBackColor = originalBackColor;
            this.originalForeColor = originalForeColor;
        }
    }
}

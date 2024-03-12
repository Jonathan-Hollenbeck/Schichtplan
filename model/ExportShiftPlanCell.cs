﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schichtplan.model
{
    public class ExportShiftPlanCell
    {
        public Color backColor { get; set; }
        public Color foreColor { get; set; }

        public string text { get; set; }

        public ExportShiftPlanCell(Color backColor, Color foreColor, string text)
        {
            this.backColor = backColor;
            this.foreColor = foreColor;
            this.text = text;
        }
    }
}

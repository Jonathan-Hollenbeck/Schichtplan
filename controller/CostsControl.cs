using Schichtplan.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schichtplan.controller
{
    public class CostsControl : ViewControl
    {
        public CostsControl(ModelControl modelControl) : base(modelControl)
        {
        }

        /// <summary>
        /// saves the data given as parameter into the fixCosts of the currentMonth
        /// </summary>
        /// <param name="data">data to be saved</param>
        public void setFixCostsFromStringArray(string[,] data)
        {
            modelControl.currentWorkmonth.fixCosts.Clear();

            for (int r = 0; r < data.GetLength(0); r++)
            {
                int day = Util.parseInt(data[r, 0], "Bitte nur Zahlen in das Bezahl Tag Textfeld eintragen. \n Am besten den Tag an dem der Betrag gezahlt wird als Zahl.");
                if (day == -1)
                {
                    return;
                }
                float amount = Util.parseFloat(data[r, 3], "Bitte nur Zahlen in das Betrag Textfeld eintragen.");
                modelControl.currentWorkmonth.fixCosts.Add(new Cost(day, data[r, 1], data[r, 2], amount));
            }
        }

        /// <summary>
        /// saves the data given as parameter into the variableCosts of the currentMonth
        /// </summary>
        /// <param name="data">data to be saved</param>
        public void setVariableCostsFromStringArray(string[,] data)
        {
            modelControl.currentWorkmonth.variableCosts.Clear();

            for (int r = 0; r < data.GetLength(0); r++)
            {
                int day = Util.parseInt(data[r, 0], "Bitte nur Zahlen in das Bezahl Tag Textfeld eintragen. \n Am besten den Tag an dem der Betrag gezahlt wird als Zahl.");
                if (day == -1)
                {
                    return;
                }
                float amount = Util.parseFloat(data[r, 3], "Bitte nur Zahlen in das Betrag Textfeld eintragen.");
                modelControl.currentWorkmonth.variableCosts.Add(new Cost(day, data[r, 1], data[r, 2], amount));
            }
        }

    }
}

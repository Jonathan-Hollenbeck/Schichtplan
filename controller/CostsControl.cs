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
        /// saves the data given as parameter into the given costs
        /// </summary>
        /// <param name="data">data to be saved</param>
        /// <param name="costs">list of costs to set</param>
        public void setCostsFromStringArray(string[,] data, List<Cost> costs)
        {
            costs.Clear();

            for (int r = 0; r < data.GetLength(0); r++)
            {
                int day = Util.parseInt(data[r, 0], "Bitte nur Zahlen in das Bezahl Tag Textfeld eintragen. \n Am besten den Tag an dem der Betrag gezahlt wird als Zahl.");
                float amount = Util.parseFloat(data[r, 3], "Bitte nur Zahlen in das Betrag Textfeld eintragen.");
                if (day == -1 || amount == -1)
                {
                    return;
                }
                costs.Add(new Cost(day, data[r, 1], data[r, 2], amount));
            }
        }

        /// <summary>
        /// loads the fixcosts for the currentMonth from a differnt month
        /// </summary>
        /// <param name="workmonth">the workmonth to load from</param>
        public void loadFixCostsFromDifferentMonth(Workmonth workmonth)
        {
            modelControl.currentWorkmonth.fixCosts = workmonth.fixCosts;
        }
    }
}

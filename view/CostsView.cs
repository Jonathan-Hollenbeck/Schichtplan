using Schichtplan.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schichtplan
{
    public partial class window : Form
    {

        /// <summary>
        /// saves the variable costs in the fixCostsDataGridView into the currentMonth
        /// </summary>
        private void saveFixCosts()
        {
            string[,] data = getDataFromDataGridViewAsStringArray(fixCostsDataGridView);

            modelControl.setFixCostsFromStringArray(data);

            setFixCostsData();
        }

        /// <summary>
        /// saves the variable costs in the variableCostsDataGridView into the currentMonth
        /// </summary>
        private void saveVariableCosts()
        {
            string[,] data = getDataFromDataGridViewAsStringArray(variableCostsDataGridView);

            modelControl.setVariableCostsFromStringArray(data);

            setVariableCostsData();
        }

        /// <summary>
        /// sets the data in the fix costs datagridview
        /// </summary>
        private void setFixCostsData()
        {
            //clear shiftedit view
            fixCostsDataGridView.Rows.Clear();

            //load shifts from the currend Workday
            foreach (Cost cost in modelControl.currentWorkmonth.fixCosts)
            {
                fixCostsDataGridView.Rows.Add(cost.ToStringArray());
            }
        }

        /// <summary>
        /// sets the data in the variable costs datagridview
        /// </summary>
        private void setVariableCostsData()
        {
            //clear shiftedit view
            variableCostsDataGridView.Rows.Clear();

            //load shifts from the currend Workday
            foreach (Cost cost in modelControl.currentWorkmonth.fixCosts)
            {
                variableCostsDataGridView.Rows.Add(cost.ToStringArray());
            }
        }

        /// <summary>
        /// resets the ui for the cost tab view
        /// </summary>
        private void resetCostsTab()
        {
            setFixCostsData();
            setVariableCostsData();
        }

        //------------generated----------------

        /// <summary>
        /// handels the click event for the fixCostsSaveButton button
        /// saves the costs from the fixCostsDatagridView into the currentMonth
        /// </summary>
        /// <param name="sender">the button control</param>
        /// <param name="e">event details</param>
        private void fixCostsSaveButton_Click(object sender, EventArgs e)
        {
            saveFixCosts();
        }

        /// <summary>
        /// handels the click event for the variableCostsSaveButton button
        /// saves the costs from the variableCostsDatagridView into the currentMonth
        /// </summary>
        /// <param name="sender">the button control</param>
        /// <param name="e">event details</param>
        private void variableCostsSaveButton_Click(object sender, EventArgs e)
        {
            saveVariableCosts();
        }
    }
}

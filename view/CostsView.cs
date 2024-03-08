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
        #region my functions

        /// <summary>
        /// saves the variable costs in the given costsDataGridView into the currentMonth
        /// </summary>
        private void saveCosts(DataGridView costsDataGridView, List<Cost> costs)
        {
            string[,] data = getDataFromDataGridViewAsStringArray(costsDataGridView);

            costsControl.setCostsFromStringArray(data, costs);

            setCostsData(costsDataGridView, costs);

            resetCostsView();
            resetGeneralInfoView();
        }

        /// <summary>
        /// sets the data in the given costs datagridview
        /// </summary>
        private void setCostsData(DataGridView costsDataGridView, List<Cost> costs)
        {
            //clear shiftedit view
            costsDataGridView.Rows.Clear();

            //load shifts from the currend Workday
            foreach (Cost cost in costs)
            {
                costsDataGridView.Rows.Add(cost.ToStringArray());
            }
        }

        /// <summary>
        /// resets the ui for the cost tab view
        /// </summary>
        private void resetCostsView()
        {
            setCostsData(fixCostsDataGridView, modelControl.currentWorkmonth.fixCosts);
            setCostsData(variableCostsDataGridView, modelControl.currentWorkmonth.variableCosts);
        }

        #endregion

        #region generated UI functions

        /// <summary>
        /// handels the click event for the fixCostsSaveButton button
        /// saves the costs from the fixCostsDatagridView into the currentMonth
        /// </summary>
        /// <param name="sender">the button control</param>
        /// <param name="e">event details</param>
        private void fixCostsSaveButton_Click(object sender, EventArgs e)
        {
            saveCosts(fixCostsDataGridView, modelControl.currentWorkmonth.fixCosts);
        }

        /// <summary>
        /// handels the click event for the variableCostsSaveButton button
        /// saves the costs from the variableCostsDatagridView into the currentMonth
        /// </summary>
        /// <param name="sender">the button control</param>
        /// <param name="e">event details</param>
        private void variableCostsSaveButton_Click(object sender, EventArgs e)
        {
            saveCosts(variableCostsDataGridView, modelControl.currentWorkmonth.variableCosts);
        }

        /// <summary>
        /// handels the click event for the fixCostsLoadFromOtherMonth button
        /// loads the fixcosts from a different month
        /// </summary>
        /// <param name="sender">the button control</param>
        /// <param name="e">event details</param>
        private void fixCostsLoadFromOtherMonthButton_Click(object sender, EventArgs e)
        {
            //create openfiledialog with the save folder open
            OpenFileDialog openFileDialog = createOpenFileDialog(Serializer.Instance().BASE_DICT + "" + Serializer.SAVE_FOLDER);

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Workmonth workmonth = (Workmonth)Serializer.Instance().loadObject(openFileDialog.FileName);
                costsControl.loadFixCostsFromDifferentMonth(workmonth);
                resetCostsView();
                resetGeneralInfoView();
            }
        }

        #endregion
    }
}

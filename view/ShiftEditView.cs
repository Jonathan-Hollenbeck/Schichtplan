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
        /// Sets the labels texts of the weektemplate
        /// </summary>
        private void setWeekTemplate()
        {
            Dictionary<int, Workday> weekTemplate = modelControl.currentWorkmonth.weekTemplate;

            weekTemplateMondayContentLabel.Text = weekTemplate[0].ToString();
            weekTemplateTuesdayContentLabel.Text = weekTemplate[1].ToString();
            weekTemplateWednesdayContentLabel.Text = weekTemplate[2].ToString();
            weekTemplateThursdayContentLabel.Text = weekTemplate[3].ToString();
            weekTemplateFridayContentLabel.Text = weekTemplate[4].ToString();
            weekTemplateSaturdayContentLabel.Text = weekTemplate[5].ToString();
            weekTemplateSundayContentLabel.Text = weekTemplate[6].ToString();

            weekTemplateMondayContentLabel.BackColor = getColorForWeekDay(weekTemplate[0].weekday);
            weekTemplateTuesdayContentLabel.BackColor = getColorForWeekDay(weekTemplate[1].weekday);
            weekTemplateWednesdayContentLabel.BackColor = getColorForWeekDay(weekTemplate[2].weekday);
            weekTemplateThursdayContentLabel.BackColor = getColorForWeekDay(weekTemplate[3].weekday);
            weekTemplateFridayContentLabel.BackColor = getColorForWeekDay(weekTemplate[4].weekday);
            weekTemplateSaturdayContentLabel.BackColor = getColorForWeekDay(weekTemplate[5].weekday);
            weekTemplateSundayContentLabel.BackColor = getColorForWeekDay(weekTemplate[6].weekday);

            weekTemplateMondayLabel.BackColor = getColorForWeekDay(weekTemplate[0].weekday);
            weekTemplateTuesdayLabel.BackColor = getColorForWeekDay(weekTemplate[1].weekday);
            weekTemplateWednesdayLabel.BackColor = getColorForWeekDay(weekTemplate[2].weekday);
            weekTemplateThursdayLabel.BackColor = getColorForWeekDay(weekTemplate[3].weekday);
            weekTemplateFridayLabel.BackColor = getColorForWeekDay(weekTemplate[4].weekday);
            weekTemplateSaturdayLabel.BackColor = getColorForWeekDay(weekTemplate[5].weekday);
            weekTemplateSundayLabel.BackColor = getColorForWeekDay(weekTemplate[6].weekday);

        }

        /// <summary>
        /// Fills the monthViewTable with the workdays of the currentWorkmonth in the manager
        /// </summary>
        private void setMonthViewTable()
        {
            monthViewTable.Visible = false;
            monthViewTable.SuspendLayout();
            monthViewTable.Controls.Clear();

            int row = 0;
            foreach (Workday workday in modelControl.currentWorkmonth.workdays)
            {
                Color workdayColor = getColorForWeekDay(workday.weekday);
                Color infoColor = workday.shifts.Count == 0 ? transparent : dayColor;

                Label labelDay = createMonthViewLabel(workday.day.ToString() + " (" + workday.weekday + ")", workdayColor);
                Label labelInfo = createMonthViewLabel(workday.ToString(), infoColor);

                monthViewTable.Controls.Add(labelDay, 0, row);
                monthViewTable.Controls.Add(labelInfo, 1, row);

                row++;
            }

            monthViewTable.RowCount = row;

            monthViewTable.ResumeLayout();
            monthViewTable.Visible = true;
        }

        /// <summary>
        /// sets the data from the currentDayInShiftEdit into the shiftEditDataGridView
        /// </summary>
        private void setShiftEdit()
        {
            //clear shiftedit view
            shiftEditDataGridView.Rows.Clear();

            //load shifts from the currend Workday
            foreach (Workshift workshift in shiftEditControl.currentWorkdayInShiftEdit.shifts)
            {
                shiftEditDataGridView.Rows.Add(workshift.ToStringArray());
            }
        }

        /// <summary>
        /// resets the shiftEdit
        /// </summary>
        private void resetShiftEditView()
        {
            shiftEditLabel.Text = "Schichtbearbeitung";
            shiftEditDataGridView.Rows.Clear();
        }

        /// <summary>
        /// resets the shiftTab. Sets the Weektemplate, the monthViewTable and the shiftEdit
        /// </summary>
        private void resetShiftEditTab()
        {
            setWeekTemplate();
            setMonthViewTable();
            resetShiftEditView();
            setShiftPlanShiftTypeColorComboBoxItems();
        }

        /// <summary>
        /// creates a new Label for the monthViewTable with a given text and backgroundcolor.
        /// adds the Eventhandlers for the monthViewTable.
        /// </summary>
        /// <param name="Text">text for the label</param>
        /// <param name="backColor">backgroundcolor for the label</param>
        /// <returns>Label for the monthViewTable</returns>
        private Label createMonthViewLabel(string Text, Color backColor)
        {
            Label label = createTableLabel(monthViewTable.Width, tableLabelHeight, Text, backColor);
            label.MouseEnter += new EventHandler(monthViewTableLabel_MouseEnter);
            label.Click += new EventHandler(monthViewTableLabel_Click);
            return label;
        }

        #endregion

        #region generated UI functions

        /// <summary>
        /// handels the mouseEnter Event for the weekTemplate labels
        /// </summary>
        /// <param name="sender">the label, where the mouse entered</param>
        /// <param name="e">event details</param>
        private void weekTemplateTabelLabel_MouseEnter(object sender, EventArgs e)
        {
            int row = weekTemplateTable.GetRow((Control)sender);
            setHoveredControlsColors(getControlsInTableRow(weekTemplateTable, row), hoverColor, hoverFontColor);
        }

        /// <summary>
        /// handels the mouseEnter Event for the monthView labels
        /// </summary>
        /// <param name="sender">the label, where the mouse entered</param>
        /// <param name="e">event details</param>
        private void monthViewTableLabel_MouseEnter(object sender, EventArgs e)
        {
            int row = monthViewTable.GetRow((Control)sender);
            setHoveredControlsColors(getControlsInTableRow(monthViewTable, row), hoverColor, hoverFontColor);
        }

        /// <summary>
        /// handels the mouseClick Event for the weekTemplate labels
        /// sets the currentDayInShiftEdit to the clicked day
        /// </summary>
        /// <param name="sender">the label, which was clicked</param>
        /// <param name="e">event details</param>
        private void weekTemplateTableLabel_Click(object sender, EventArgs e)
        {
            int row = weekTemplateTable.GetRow((Control)sender);
            //set the currentDayInShiftEdit to the clicked day from the weektemplate
            shiftEditControl.setCurrentDayInShiftEditFromWeekTemplate(row);
            //reset the shiftedit
            resetShiftEditView();
            //set the shiftEditLabel text
            shiftEditLabel.Text = "Schichtbearbeitung: Wochenvorlage(" + shiftEditControl.currentWorkdayInShiftEdit.weekday + ")";
            //set the data into the shiftEdit
            setShiftEdit();

            //reset the currently clicked rows in weektemplate and monthview
            setClickedControlsColors(getControlsInTableRow(weekTemplateTable, row), clickColor, clickFontColor);
        }

        /// <summary>
        /// handels the mouseClick Event for the monthView labels
        /// sets the currentDayInShiftEdit to the clicked day
        /// </summary>
        /// <param name="sender">the label, which was clicked</param>
        /// <param name="e">event details</param>
        private void monthViewTableLabel_Click(object sender, EventArgs e)
        {
            int row = monthViewTable.GetRow((Control)sender);
            //set currentDayInShiftEdit to the one clicked in monthview
            shiftEditControl.setCurrentDayInShiftEditFromWorkdays(row);
            //reset the shiftedit
            resetShiftEditView();
            //set the shiftEditLabel text
            shiftEditLabel.Text = "Schichtbearbeitung: "
                + shiftEditControl.currentWorkdayInShiftEdit.day + " ("
                + shiftEditControl.currentWorkdayInShiftEdit.weekday + ")";
            //set the workshifts from the currentday in shiftEdit to the shiftEdit dgv
            setShiftEdit();

            //reset the currently clicked rows in weektemplate and monthview
            setClickedControlsColors(getControlsInTableRow(monthViewTable, row), clickColor, clickFontColor);
        }

        /// <summary>
        /// handels the click event for the saveCurrentShift button
        /// saves the workshifts desclared in the shiftEdit into the currentDayInShiftEdit
        /// </summary>
        /// <param name="sender">the button control</param>
        /// <param name="e">event details</param>
        private void saveCurrentShift_Click(object sender, EventArgs e)
        {
            //check if current day to edit is not empty
            if (shiftEditControl.currentWorkdayInShiftEdit == null)
            {
                MessageBox.Show("Bitte erst Tag zum bearbeiten auswaehlen.");
                return;
            }
            //get data from the shiftEdit dgv
            string[,] data = getDataFromDataGridViewAsStringArray(shiftEditDataGridView);
            //save the retrieved data into the workday
            shiftEditControl.saveWorkshiftsIntoCurrentDayInShiftEdit(data);
            //reset the shiftEdit tab to show the changes in the UI
            resetShiftEditTab();
        }

        /// <summary>
        /// handels the click event for the useOnHoleMonth button
        /// sets the weektemplate on the hole month
        /// </summary>
        /// <param name="sender">the button</param>
        /// <param name="e">event details</param>
        private void useOnHoleMonth_Click(object sender, EventArgs e)
        {
            //dialog to show the user, that all workshifts are beeing replaced and potential connections in the persons unavailable dict are deleted
            DialogResult dialogResult = MessageBox.Show("Alle aktuellen Schichten werden gelöscht und mit dem Template neu erstellt.\n" +
                "Es kann zu unvorhersehbarem Verhalten in den anderen Tabs kommen. Bitte nur bei neuaufsetzen eines Monats verwenden.\n\n" +
                "Willst du fortfahren?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //use the weektemplate on the hole month
                shiftEditControl.setWeekTemplateOnMonth();
                //reset the shiftEdit to update the ui
                resetShiftEditTab();
            }
        }

        /// <summary>
        /// handels the click event for the loadFromOtherMonth button
        /// loads the weekTemplate of another month, which is selected with a OpenFileDialog
        /// </summary>
        /// <param name="sender">the button</param>
        /// <param name="e">event details</param>
        private void loadFromOtherMonthButton_Click(object sender, EventArgs e)
        {
            //create openfiledialog with the save folder open
            OpenFileDialog openFileDialog = createOpenFileDialog(Serializer.Instance().BASE_DICT + "" + Serializer.SAVE_DIRECTORY);

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Workmonth workmonth = (Workmonth)Serializer.Instance().loadObject(openFileDialog.FileName);
                shiftEditControl.setWeekTemplateFromOtherMonth(workmonth);
                resetShiftEditTab();
            }
        }

        #endregion
    }
}

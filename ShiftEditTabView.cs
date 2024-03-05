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
        /// save backgroundcolors for the Controls in the monthViewTable
        /// </summary>
        private Dictionary<Control, Color> monthViewControlColors = new Dictionary<Control, Color>();

        /// <summary>
        /// save backgroundcolors for the Controls in the monthViewTable
        /// </summary>
        private Dictionary<Control, Color> weekTemplateControlColors = new Dictionary<Control, Color>();

        /// <summary>
        /// save the currently clicked row
        /// </summary>
        private int currentClickedRowWeekTemplate = -1;
        private int currentClickedRowMonthView = -1;

        /// <summary>
        /// Sets the labels texts of the weektemplate
        /// </summary>
        private void setWeekTemplate()
        {
            Dictionary<int, Workday> weekTemplate = manager.currentWorkmonth.weekTemplate;

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
            monthViewControlColors.Clear();

            monthViewTable.Visible = false;
            monthViewTable.SuspendLayout();
            monthViewTable.Controls.Clear();

            int row = 0;
            foreach (Workday workday in manager.currentWorkmonth.workdays)
            {
                Color workdayColor = getColorForWeekDay(workday.weekday);
                Color infoColor = workday.shifts.Count == 0 ? transparent : dayColor;

                Label labelDay = createMonthViewLabel(workday.day.ToString() + " (" + workday.weekday + ")", workdayColor);
                Label labelInfo = createMonthViewLabel(workday.ToString(), infoColor);

                monthViewTable.Controls.Add(labelDay, 0, row);
                monthViewTable.Controls.Add(labelInfo, 1, row);

                row++;
            }

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
            foreach (Workshift workshift in manager.currentWorkdayInShiftEdit.shifts)
            {
                shiftEditDataGridView.Rows.Add(workshift.ToStringArray());
            }
        }

        /// <summary>
        /// resets the shiftTab. Sets the Weektemplate, the monthViewTable and the shiftEdit
        /// </summary>
        private void resetShiftEditTab()
        {
            setWeekTemplate();
            setMonthViewTable();
            resetShiftEdit();
            setShiftPlanShiftTypeColorComboBoxItems();
        }

        /// <summary>
        /// resets the shiftEdit
        /// </summary>
        private void resetShiftEdit()
        {
            shiftEditLabel.Text = "Schichtbearbeitung";
            shiftEditDataGridView.Rows.Clear();
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
            Label label = new Label();
            label.Text = Text;
            label.Margin = new Padding(0);
            label.Size = new Size(monthViewTable.Width, 28);
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.MouseEnter += new EventHandler(monthViewTableLabel_MouseEnter);
            label.MouseLeave += new EventHandler(monthViewTableLabel_MouseLeave);
            label.Click += new EventHandler(monthViewTableLabel_Click);
            label.BackColor = backColor;
            monthViewControlColors.Add(label, backColor);
            return label;
        }


        //-------------------generated---------------------


        /// <summary>
        /// handels the mouseEnter Event for the weekTemplate labels
        /// </summary>
        /// <param name="sender">the label, where the mouse entered</param>
        /// <param name="e">event details</param>
        private void weekTemplateTabelLabel_MouseEnter(object sender, EventArgs e)
        {
            int row = weekTemplateTable.GetRow((Control)sender);
            setTableControlColor(weekTemplateTable, row, hoverColor);
        }

        /// <summary>
        /// handels the mouseLeave Event for the weekTemplate labels
        /// </summary>
        /// <param name="sender">the label, where the mouse left</param>
        /// <param name="e">event details</param>
        private void weekTemplateTabelLabel_MouseLeave(object sender, EventArgs e)
        {
            Control control = sender as Control;
            int row = weekTemplateTable.GetRow(control);
            if(row != currentClickedRowWeekTemplate)
            {
                resetTableControlColor(weekTemplateTable, weekTemplateControlColors, row);
            }
        }

        /// <summary>
        /// handels the mouseEnter Event for the monthView labels
        /// </summary>
        /// <param name="sender">the label, where the mouse entered</param>
        /// <param name="e">event details</param>
        private void monthViewTableLabel_MouseEnter(object sender, EventArgs e)
        {
            int row = monthViewTable.GetRow((Control)sender);
            setTableControlColor(monthViewTable, row, hoverColor);
        }

        /// <summary>
        /// handels the mouseLeave Event for the monthView labels
        /// </summary>
        /// <param name="sender">the label, where the mouse left</param>
        /// <param name="e">event details</param>
        private void monthViewTableLabel_MouseLeave(object sender, EventArgs e)
        {
            Control control = sender as Control;
            int row = monthViewTable.GetRow(control);
            if(row != currentClickedRowMonthView)
            {
                resetTableControlColor(monthViewTable, monthViewControlColors, row);
            }
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
            manager.setCurrentDayInShiftEditFromWeekTemplate(row);
            shiftEditLabel.Text = "Schichtbearbeitung: Wochenvorlage(" + manager.currentWorkdayInShiftEdit.weekday + ")";

            //clear shiftedit view
            shiftEditDataGridView.Rows.Clear();

            setShiftEdit();

            if (currentClickedRowWeekTemplate != -1)
            {
                resetTableControlColor(weekTemplateTable, weekTemplateControlColors, currentClickedRowWeekTemplate);
            }
            if(currentClickedRowMonthView != -1)
            {
                resetTableControlColor(monthViewTable, monthViewControlColors, currentClickedRowMonthView);
                currentClickedRowMonthView = -1;
            }
            currentClickedRowWeekTemplate = row;
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
            manager.setCurrentDayInShiftEditFromWorkdays(row);
            shiftEditLabel.Text = "Schichtbearbeitung: "
                + manager.currentWorkdayInShiftEdit.day + " ("
                + manager.currentWorkdayInShiftEdit.weekday + ")";

            setShiftEdit();

            if (currentClickedRowWeekTemplate != -1)
            {
                resetTableControlColor(weekTemplateTable, weekTemplateControlColors, currentClickedRowWeekTemplate);
                currentClickedRowWeekTemplate = -1;
            }
            if (currentClickedRowMonthView != -1)
            {
                resetTableControlColor(monthViewTable, monthViewControlColors, currentClickedRowMonthView);
            }
            currentClickedRowMonthView = row;
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
            if (manager.currentWorkdayInShiftEdit == null)
            {
                MessageBox.Show("Bitte erst Tag zum bearbeiten auswaehlen.");
                return;
            }
            //check if there is an entry in every cell
            string[,] rows = new string[shiftEditDataGridView.RowCount - 1, shiftEditDataGridView.ColumnCount];
            for (int r = 0; r < shiftEditDataGridView.Rows.Count - 1; r++)
            {
                for (int c = 0; c < shiftEditDataGridView.Rows[r].Cells.Count; c++)
                {
                    string value = (string)shiftEditDataGridView.Rows[r].Cells[c].Value;
                    if (value == null)
                    {
                        MessageBox.Show("Bitte in jede Zelle etwas eintragen.");
                        return;
                    }
                    else
                    {
                        rows[r, c] = value;
                    }
                }
            }

            manager.saveWorkshiftsIntoCurrentDayInShiftEdit(rows);

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
            DialogResult dialogResult = MessageBox.Show("Alle aktuellen Schichten werden gelöscht und mit dem Template neu erstellt.\n" +
                "Es kann zu unvorhersehbarem Verhalten in den anderen Tabs kommen. Bitte nur bei neuaufsetzen eines Monats verwenden.\n\n" +
                "Willst du fortfahren?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                manager.setWeekTemplateOnMonth();
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
            OpenFileDialog openFileDialog = createOpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Workmonth workmonth = (Workmonth)Serializer.Instance().loadObject(openFileDialog.FileName);
                manager.currentWorkmonth.weekTemplate = workmonth.weekTemplate;
                resetShiftEditTab();
            }
        }
    }
}

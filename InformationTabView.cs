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
        /// current day selected in the info general tab
        /// </summary>
        private int currentInfoWorkdayIndex = -1;

        /// <summary>
        /// current week selected in the info general tab, represented as a List of its workdays
        /// </summary>
        private int currentInfoWeekIndex = -1;

        /// <summary>
        /// pointer from the string in the daysInDayComboBox to the actual workday
        /// </summary>
        private List<Workday> daysInDayComboBox = new List<Workday>();

        /// <summary>
        /// pointer from the string in the weekInWeekComboBox to the actual week as a list of workdays
        /// </summary>
        private List<List<Workday>> weeksInWeekComboBox = new List<List<Workday>>();

        //---------------Person----------------

        /// <summary>
        /// fills the infoPersonTable in the infoPersonTab with the infos to the persons in the currentMonth
        /// </summary>
        public void setInfoPersonTable()
        {
            infoPersonTable.Visible = false;

            infoPersonTable.Controls.Clear();
            infoPersonTable.SuspendLayout();

            int row = 0;

            infoPersonTable.Controls.Add(createInfoPersonLabel("Gehalt pro Stunde", dayColor), 1, row);
            infoPersonTable.Controls.Add(createInfoPersonLabel("Stunden gearbeitet", dayColor), 2, row);
            infoPersonTable.Controls.Add(createInfoPersonLabel("Monatsgehalt (davon vom letzten Monat)", dayColor), 3, row);
            infoPersonTable.Controls.Add(createInfoPersonLabel("Tage nicht im gearbeitet", dayColor), 4, row);
            infoPersonTable.Controls.Add(createInfoPersonLabel("Anzahl Schichten", dayColor), 5, row);

            row++;

            foreach(Person person in manager.currentWorkmonth.persons)
            {

                Color backColor = transparent;
                if (manager.currentWorkmonth.settings.personColors.ContainsKey(person)){
                    backColor = manager.currentWorkmonth.settings.personColors[person];
                }

                infoPersonTable.Controls.Add(createInfoPersonLabel(person.name, dayColor), 0, row);

                //set infos
                float worktimeInMonth = manager.getWorktimeForPersonInWorkdays(person, manager.currentWorkmonth.workdays, manager.currentWorkmonth.shiftplan);
                float carryOver = manager.getPersonCarryOver(person, manager.currentWorkmonth.hourCarryOverLastMonth);

                infoPersonTable.Controls.Add(createInfoPersonLabel(person.saleryPerHour + "€", backColor), 1, row);
                infoPersonTable.Controls.Add(createInfoPersonLabel(worktimeInMonth + "h (+" + carryOver + "h) [" + person.minWorkHours + "h, " + person.maxWorkHours + "h]", backColor), 2, row);
                infoPersonTable.Controls.Add(createInfoPersonLabel((carryOver + worktimeInMonth) * person.saleryPerHour + "€ (" + (carryOver * person.saleryPerHour + "€)"), backColor), 3, row);
                infoPersonTable.Controls.Add(createInfoPersonLabel(
                    manager.getDaysNotWorkingForPersonInWorkdaysCount(person, manager.currentWorkmonth.workdays, manager.currentWorkmonth.shiftplan)
                    + "/" + manager.getWorkingDaysCounter(manager.currentWorkmonth.workdays)
                    , backColor), 4, row);

                Dictionary<string, int> workshiftAmounts = manager.getWorkedShiftsForPersonInWorkdaysByShiftTypeCount(person, manager.currentWorkmonth.workdays, manager.currentWorkmonth.shiftplan);

                string workshiftAmountsString = "";

                foreach (KeyValuePair<string, int> kvp in workshiftAmounts)
                {
                    workshiftAmountsString += kvp.Key + ": " + kvp.Value + "; ";
                }

                if(workshiftAmountsString.Length > 0)
                {
                    infoPersonTable.Controls.Add(createInfoPersonLabel(workshiftAmountsString.Substring(0, workshiftAmountsString.Length - 2), backColor), 5, row);
                }

                row++;
            }
            
            infoPersonTable.ResumeLayout();
            infoPersonTable.Visible = true;
        }

        /// <summary>
        /// creates a new Label for the infoPersonTable with a given text and backgroundcolor.
        /// </summary>
        /// <param name="Text">text for the label</param>
        /// <param name="backColor">backgroundcolor for the label</param>
        /// <returns>Label for the infoPersonTable</returns>
        private Label createInfoPersonLabel(string Text, Color backColor)
        {
            Label label = new Label();
            label.Text = Text;
            label.Margin = new Padding(0);
            label.Size = new Size(infoPersonTable.Width, 28);
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.BackColor = backColor;
            return label;
        }

        //--------------General----------------

        /// <summary>
        /// sets the items for the infoDayCombobox to the days with workshifts of the currentMonth
        /// </summary>
        public void setInfoDayComboBox()
        {
            infoDayComboBox.Items.Clear();
            daysInDayComboBox.Clear();
            foreach (Workday workday in manager.currentWorkmonth.workdays)
            {
                if(workday.shifts.Count > 0)
                {
                    string comboBoxEntry = workday.day + ", " + workday.weekday;
                    daysInDayComboBox.Add(workday);
                    infoDayComboBox.Items.Add(comboBoxEntry);
                }
            }
            infoDayComboBox.SelectedIndex = infoDayComboBox.Items.Count - 1;
        }

        /// <summary>
        /// sets the items for the infoWeekComboBox to the weeks of the currentMonth
        /// </summary>
        public void setInfoWeekComboBox()
        {
            infoWeekComboBox.Items.Clear();
            weeksInWeekComboBox.Clear();

            List<List<Workday>> weeks = manager.getWeeksInWorkdays(manager.currentWorkmonth.workdays);

            for(int weekCounter = 0; weekCounter < weeks.Count; weekCounter++)
            {
                string comboBoxEntry = "Woche " + weekCounter + ", " + manager.getFirstAndLastDayInWorkdaysAsString(weeks[weekCounter]);
                weeksInWeekComboBox.Add(weeks[weekCounter]);
                infoWeekComboBox.Items.Add(comboBoxEntry);
            }
            infoWeekComboBox.SelectedIndex = infoWeekComboBox.Items.Count - 1;
        }

        /// <summary>
        /// sets the info for the currentMonth in the general info tab
        /// </summary>
        public void setGeneralInfoMonth()
        {
            float carryOverSalerySum = 0.0f;
            float salarySum = 0.0f;
            foreach (Person person in manager.currentWorkmonth.persons)
            {
                carryOverSalerySum += manager.getPersonCarryOver(person, manager.currentWorkmonth.hourCarryOverLastMonth) * person.saleryPerHour;
                salarySum += manager.getWorktimeForPersonInWorkdays(person, manager.currentWorkmonth.workdays, manager.currentWorkmonth.shiftplan) * person.saleryPerHour;
                salarySum += carryOverSalerySum;
            }
            infoMonthSalerySumContent.Text = Util.clampToDecimalpoints(salarySum, 2) + "€ (" + carryOverSalerySum + "€)";

            Dictionary<string, int> workshiftsByShiftType = manager.getShiftCountInWorkdaysByShiftType(manager.currentWorkmonth.workdays);
            int workshiftSum = 0;
            string workshiftsByShiftTypeString = "";
            foreach(KeyValuePair<string, int> kvp in workshiftsByShiftType)
            {
                workshiftsByShiftTypeString += kvp.Key + ": " + kvp.Value + "; ";
                workshiftSum += kvp.Value;
            }

            infoMonthShiftSumContent.Text = workshiftsByShiftTypeString.Length > 1 ?
                workshiftSum + " (" + workshiftsByShiftTypeString.Substring(0, workshiftsByShiftTypeString.Length - 2) + ")"
                : "";

            infoMonthHoursSumContent.Text = manager.getWorktimeInWorkdays(manager.currentWorkmonth.workdays) + "h";

            if(manager.currentWorkmonth.turnoverMonth != 0.0f)
            {
                infoMonthTurnoverTextBox.Text = "" + manager.currentWorkmonth.turnoverMonth;
                setGeneralTurnoverInfoMonth();
            }
            else
            {
                infoMonthTurnoverTextBox.Text = "0";
            }
        }

        /// <summary>
        /// sets the turnover info for the currentMonth in the general info tab
        /// </summary>
        public void setGeneralTurnoverInfoMonth()
        {
            if (infoMonthTurnoverTextBox.Text == "")
            {
                MessageBox.Show("Bitte Umsatz in Textfeld eingeben.");
            }
            else
            {
                float turnover = Util.parseFloat(infoMonthTurnoverTextBox.Text, "Bitte nur Zahlen in das Textfeld eingeben.");
                if (turnover != -1)
                {
                    manager.currentWorkmonth.turnoverMonth = turnover;

                    float carryOverSalerySum = 0.0f;
                    float salarySum = 0.0f;
                    foreach (Person person in manager.currentWorkmonth.persons)
                    {
                        carryOverSalerySum += manager.getPersonCarryOver(person, manager.currentWorkmonth.hourCarryOverLastMonth) * person.saleryPerHour;
                        salarySum += manager.getWorktimeForPersonInWorkdays(person, manager.currentWorkmonth.workdays, manager.currentWorkmonth.shiftplan) * person.saleryPerHour;
                        salarySum += carryOverSalerySum;
                    }

                    infoMonthTurnoverAfterSaleriesContent.Text = Util.clampToDecimalpoints(turnover - salarySum, 2) + "€ (" + carryOverSalerySum + "€)";
                    infoMonthAverageTurnoverHourContent.Text = Util.clampToDecimalpoints(turnover / manager.getWorktimeInWorkdays(manager.currentWorkmonth.workdays), 2) + "€";
                    infoMonthAverageTurnoverDayContent.Text = Util.clampToDecimalpoints(turnover / manager.getWorkingDaysCounter(manager.currentWorkmonth.workdays), 2) + "€";
                }
            }
        }

        /// <summary>
        /// sets the info for the selected week in the general info tab
        /// </summary>
        public void setGeneralInfoWeek()
        {
            if (currentInfoWeekIndex != -1)
            {
                List<Workday> currentWeek = weeksInWeekComboBox[currentInfoWeekIndex];

                float salarySum = 0.0f;
                foreach (Person person in manager.currentWorkmonth.persons)
                {
                    salarySum += manager.getWorktimeForPersonInWorkdays(person, currentWeek, manager.currentWorkmonth.shiftplan) * person.saleryPerHour;
                }
                infoWeekSalerySumContent.Text = Util.clampToDecimalpoints(salarySum, 2) + "€";

                Dictionary<string, int> workshiftsByShiftType = manager.getShiftCountInWorkdaysByShiftType(currentWeek);
                int workshiftSum = 0;
                string workshiftsByShiftTypeString = "";
                foreach (KeyValuePair<string, int> kvp in workshiftsByShiftType)
                {
                    workshiftsByShiftTypeString += kvp.Key + ": " + kvp.Value + "; ";
                    workshiftSum += kvp.Value;
                }

                infoWeekShiftSumContent.Text = workshiftsByShiftTypeString.Length > 1 ?
                    workshiftSum + " (" + workshiftsByShiftTypeString.Substring(0, workshiftsByShiftTypeString.Length - 2) + ")"
                    : "";

                infoWeekHoursSumContent.Text = manager.getWorktimeInWorkdays(currentWeek) + "h";

                if (manager.currentWorkmonth.turnoverWeeks.ContainsKey(currentInfoWeekIndex))
                {
                    infoWeekTurnoverTextBox.Text = "" + manager.currentWorkmonth.turnoverWeeks[currentInfoWeekIndex];
                    setGeneralTurnoverInfoWeek();
                }
                else
                {
                    infoWeekTurnoverTextBox.Text = "0";
                }
            }
        }

        /// <summary>
        /// sets the turnover info for the selected week in the general info tab
        /// </summary>
        public void setGeneralTurnoverInfoWeek()
        {
            if (infoWeekTurnoverTextBox.Text == "")
            {
                MessageBox.Show("Bitte Umsatz in Textfeld eingeben.");
            }
            else
            {
                List<Workday> currentWeek = weeksInWeekComboBox[currentInfoWeekIndex];

                float turnover = Util.parseFloat(infoWeekTurnoverTextBox.Text, "Bitte nur Zahlen in das Textfeld eingeben.");
                if (turnover != -1)
                {
                    if (!manager.currentWorkmonth.turnoverWeeks.ContainsKey(currentInfoWeekIndex)){
                        manager.currentWorkmonth.turnoverWeeks.Add(currentInfoWeekIndex, 0.0f);
                    }
                    manager.currentWorkmonth.turnoverWeeks[currentInfoWeekIndex] = turnover;

                    float salarySum = 0.0f;
                    foreach (Person person in manager.currentWorkmonth.persons)
                    {
                        salarySum += manager.getWorktimeForPersonInWorkdays(person, currentWeek, manager.currentWorkmonth.shiftplan) * person.saleryPerHour;
                    }

                    infoWeekTurnoverAfterSaleriesContent.Text = Util.clampToDecimalpoints(turnover - salarySum, 2) + "€";
                    infoWeekAverageTurnoverHourContent.Text = Util.clampToDecimalpoints(turnover / manager.getWorktimeInWorkdays(currentWeek), 2) + "€";
                    infoWeekAverageTurnoverDayContent.Text = Util.clampToDecimalpoints(turnover / manager.getWorkingDaysCounter(currentWeek), 2) + "€";
                }
            }
        }

        /// <summary>
        /// sets the info for the selected day in the general info tab
        /// </summary>
        public void setGeneralInfoDay()
        {
            if(currentInfoWorkdayIndex != -1)
            {
                Workday currentWorkday = daysInDayComboBox[currentInfoWorkdayIndex];

                float salarySum = 0.0f;
                foreach (Person person in manager.currentWorkmonth.persons)
                {
                    salarySum += manager.getWorktimeForPersonInWorkday(person, currentWorkday, manager.currentWorkmonth.shiftplan) * person.saleryPerHour;
                }
                infoDaySalerySumContent.Text = Util.clampToDecimalpoints(salarySum, 2) + "€";

                Dictionary<string, int> workshiftsByShiftType = manager.getShiftCountInWorkdayByShiftType(currentWorkday);
                int workshiftSum = 0;
                string workshiftsByShiftTypeString = "";
                foreach (KeyValuePair<string, int> kvp in workshiftsByShiftType)
                {
                    workshiftsByShiftTypeString += kvp.Key + ": " + kvp.Value + "; ";
                    workshiftSum += kvp.Value;
                }

                infoDayShiftSumContent.Text = workshiftsByShiftTypeString.Length > 1 ?
                    workshiftSum + " (" + workshiftsByShiftTypeString.Substring(0, workshiftsByShiftTypeString.Length - 2) + ")"
                    : "";

                infoDayHoursSumContent.Text = manager.getWorktimeInWorkday(currentWorkday) + "h";

                if (manager.currentWorkmonth.turnoverWorkdays.ContainsKey(currentWorkday))
                {
                    infoDayTurnoverTextBox.Text = "" + manager.currentWorkmonth.turnoverWorkdays[currentWorkday];
                    setGeneralTurnoverInfoDay();
                }
                else
                {
                    infoDayTurnoverTextBox.Text = "0";
                }
            }
        }

        /// <summary>
        /// sets the turnover info for the selected day in the general info tab
        /// </summary>
        public void setGeneralTurnoverInfoDay()
        {
            if (infoDayTurnoverTextBox.Text == "")
            {
                MessageBox.Show("Bitte Umsatz in Textfeld eingeben.");
            }
            else
            {
                Workday currentWorkday = daysInDayComboBox[currentInfoWorkdayIndex];

                float turnover = Util.parseFloat(infoDayTurnoverTextBox.Text, "Bitte nur Zahlen in das Textfeld eingeben.");
                if (turnover != -1)
                {
                    if (!manager.currentWorkmonth.turnoverWorkdays.ContainsKey(currentWorkday)){
                        manager.currentWorkmonth.turnoverWorkdays.Add(currentWorkday, 0.0f);
                    }
                    manager.currentWorkmonth.turnoverWorkdays[currentWorkday] = turnover;

                    float salarySum = 0.0f;
                    foreach (Person person in manager.currentWorkmonth.persons)
                    {
                        salarySum += manager.getWorktimeForPersonInWorkday(person, currentWorkday, manager.currentWorkmonth.shiftplan) * person.saleryPerHour;
                    }

                    infoDayTurnoverAfterSaleriesContent.Text = Util.clampToDecimalpoints(turnover - salarySum, 2) + "€";
                    infoDayAverageTurnoverHourContent.Text = Util.clampToDecimalpoints(turnover / manager.getWorktimeInWorkday(currentWorkday), 2) + "€";
                }
            }
        }

        /// <summary>
        /// resets all general info
        /// </summary>
        public void resetGeneralInfo()
        {
            setInfoDayComboBox();
            setInfoWeekComboBox();
            setGeneralInfoMonth();
            setGeneralInfoWeek();
            setGeneralInfoDay();
        }


        //-------------------generated---------------------

        /// <summary>
        /// handels the click event for the infoDayCalculateButton button
        /// sets the turnover data for the day
        /// </summary>
        /// <param name="sender">the button control</param>
        /// <param name="e">event details</param>
        private void infoDayCalculateButton_Click(object sender, EventArgs e)
        {
            setGeneralTurnoverInfoDay();
        }

        /// <summary>
        /// handels the click event for the infoWeekCalculateButton button
        /// sets the turnover data for the week
        /// </summary>
        /// <param name="sender">the button control</param>
        /// <param name="e">event details</param>
        private void infoWeekCalculateButton_Click(object sender, EventArgs e)
        {
            setGeneralTurnoverInfoWeek();
        }

        /// <summary>
        /// handels the click event for the infoMonthCalculateButton button
        /// sets the turnover data for the currentMonth
        /// </summary>
        /// <param name="sender">the button control</param>
        /// <param name="e">event details</param>
        private void infoMonthCalculateButton_Click(object sender, EventArgs e)
        {
            setGeneralTurnoverInfoMonth();
        }

        /// <summary>
        /// handels the selectedIndexChanged event for the infoWeekComboBox combobox
        /// sets the currentInfoWeek and loads the new general data for the week
        /// </summary>
        /// <param name="sender">week combobox</param>
        /// <param name="e">event details</param>
        private void infoWeekComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentInfoWeekIndex = infoWeekComboBox.SelectedIndex;
            setGeneralInfoWeek();
        }

        /// <summary>
        /// handels the selectedIndexChanged event for the infoDayComboBox combobox
        /// sets the currentInfoDay and loads the new general data for the day
        /// </summary>
        /// <param name="sender">day combobox</param>
        /// <param name="e">event details</param>
        private void infoDayComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentInfoWorkdayIndex = infoDayComboBox.SelectedIndex;
            setGeneralInfoDay();
        }
    }
}

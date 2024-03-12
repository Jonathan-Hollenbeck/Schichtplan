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

        #region my functions

        #region persons

        /// <summary>
        /// fills the infoPersonTable in the infoPersonTab with the infos to the persons in the currentMonth
        /// </summary>
        public void setInfoPersonTable()
        {
            infoPersonTable.Visible = false;

            infoPersonTable.Controls.Clear();
            infoPersonTable.SuspendLayout();

            int row = 0;

            infoPersonTable.Controls.Add(createTableLabel(infoPersonTable.Width, tableLabelHeight, "Gehalt pro Stunde", infoPersonHeaderColor), 1, row);
            infoPersonTable.Controls.Add(createTableLabel(infoPersonTable.Width, tableLabelHeight, "Stunden gearbeitet", infoPersonHeaderColor), 2, row);
            infoPersonTable.Controls.Add(createTableLabel(infoPersonTable.Width, tableLabelHeight, "Monatsgehalt (davon vom letzten Monat)", infoPersonHeaderColor), 3, row);
            infoPersonTable.Controls.Add(createTableLabel(infoPersonTable.Width, tableLabelHeight, "Tage nicht im gearbeitet", infoPersonHeaderColor), 4, row);
            infoPersonTable.Controls.Add(createTableLabel(infoPersonTable.Width, tableLabelHeight, "Anzahl Schichten", infoPersonHeaderColor), 5, row);

            row++;

            foreach(Person person in modelControl.currentWorkmonth.persons)
            {
                Color backColor = transparent;
                if (modelControl.currentWorkmonth.settings.personColors.ContainsKey(person))
                {
                    backColor = modelControl.currentWorkmonth.settings.personColors[person];
                }

                infoPersonTable.Controls.Add(createTableLabel(infoPersonTable.Width, tableLabelHeight, person.name, infoPersonHeaderColor), 0, row);

                //set infos
                float worktimeInMonth = modelControl.getWorktimeForPersonInWorkdays(person, modelControl.currentWorkmonth.workdays, modelControl.currentWorkmonth.shiftplan);
                float carryOver = modelControl.getPersonCarryOver(person, modelControl.currentWorkmonth.hourCarryOverLastMonth);
                float effictiveWorktime = worktimeInMonth + carryOver;

                //backcolor for worktime, if min workhour not reached or maxworkhour exceeded red. green otherwise
                Color workedHoursBackColor = backColor;
                if (person.minWorkHours > effictiveWorktime || effictiveWorktime > person.maxWorkHours)
                {
                    workedHoursBackColor = Color.Red;
                }

                infoPersonTable.Controls.Add(createTableLabel(infoPersonTable.Width, tableLabelHeight, person.saleryPerHour + "€", backColor), 1, row);
                infoPersonTable.Controls.Add(createTableLabel(infoPersonTable.Width, tableLabelHeight, worktimeInMonth + "h (+" + carryOver + "h) [" + person.minWorkHours + "h, " + person.maxWorkHours + "h]", workedHoursBackColor), 2, row);
                infoPersonTable.Controls.Add(createTableLabel(infoPersonTable.Width, tableLabelHeight, effictiveWorktime * person.saleryPerHour + "€ (" + (carryOver * person.saleryPerHour + "€)"), backColor), 3, row);
                infoPersonTable.Controls.Add(createTableLabel(infoPersonTable.Width, tableLabelHeight,
                    modelControl.getDaysNotWorkingForPersonInWorkdaysCount(person, modelControl.currentWorkmonth.workdays, modelControl.currentWorkmonth.shiftplan)
                    + "/" + modelControl.getWorkingDaysCounter(modelControl.currentWorkmonth.workdays)
                    , backColor), 4, row);

                Dictionary<string, int> workshiftAmounts = modelControl.getWorkedShiftsForPersonInWorkdaysByShiftTypeCount(person, modelControl.currentWorkmonth.workdays, modelControl.currentWorkmonth.shiftplan);

                string workshiftAmountsString = "";

                foreach (KeyValuePair<string, int> kvp in workshiftAmounts)
                {
                    workshiftAmountsString += kvp.Key + ": " + kvp.Value + "; ";
                }

                if(workshiftAmountsString.Length > 0)
                {
                    infoPersonTable.Controls.Add(createTableLabel(infoPersonTable.Width, tableLabelHeight, workshiftAmountsString.Substring(0, workshiftAmountsString.Length - 2), backColor), 5, row);
                }

                row++;
            }
            
            infoPersonTable.ResumeLayout();
            infoPersonTable.Visible = true;
        }

        #endregion

        #region general

        /// <summary>
        /// sets the items for the infoDayCombobox to the days with workshifts of the currentMonth
        /// </summary>
        public void setInfoDayComboBox()
        {
            infoDayComboBox.Items.Clear();
            daysInDayComboBox.Clear();
            foreach (Workday workday in modelControl.currentWorkmonth.workdays)
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

            List<List<Workday>> weeks = modelControl.getWeeksInWorkdays(modelControl.currentWorkmonth.workdays);

            for(int weekCounter = 0; weekCounter < weeks.Count; weekCounter++)
            {
                string comboBoxEntry = "Woche " + weekCounter + ", " + modelControl.getFirstAndLastDayInWorkdaysAsString(weeks[weekCounter]);
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
            foreach (Person person in modelControl.currentWorkmonth.persons)
            {
                carryOverSalerySum += modelControl.getPersonCarryOver(person, modelControl.currentWorkmonth.hourCarryOverLastMonth) * person.saleryPerHour;
                salarySum += modelControl.getWorktimeForPersonInWorkdays(person, modelControl.currentWorkmonth.workdays, modelControl.currentWorkmonth.shiftplan) * person.saleryPerHour;
                salarySum += carryOverSalerySum;
            }
            infoMonthSalerySumContent.Text = Util.clampToDecimalpoints(salarySum, 2) + "€ (" + carryOverSalerySum + "€)";

            Dictionary<string, int> workshiftsByShiftType = modelControl.getShiftCountInWorkdaysByShiftType(modelControl.currentWorkmonth.workdays);
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

            infoMonthHoursSumContent.Text = modelControl.getWorktimeInWorkdays(modelControl.currentWorkmonth.workdays) + "h";

            //costs
            float fixCostsAmountSum = modelControl.getCostsAmountSum(modelControl.currentWorkmonth.fixCosts);
            float variableCostsAmountSum = modelControl.getCostsAmountSum(modelControl.currentWorkmonth.variableCosts);

            infoMonthFixCostsSumContent.Text = fixCostsAmountSum + "€";
            infoMonthVariableCostsSumContent.Text = variableCostsAmountSum + "€";
            infoMonthCostsSumContent.Text = (fixCostsAmountSum + variableCostsAmountSum) + "€";

            //turnover
            if (modelControl.currentWorkmonth.turnoverMonth != 0.0f)
            {
                infoMonthTurnoverTextBox.Text = "" + modelControl.currentWorkmonth.turnoverMonth;
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
                    modelControl.currentWorkmonth.turnoverMonth = turnover;

                    float carryOverSalerySum = 0.0f;
                    float salarySum = 0.0f;
                    foreach (Person person in modelControl.currentWorkmonth.persons)
                    {
                        carryOverSalerySum += modelControl.getPersonCarryOver(person, modelControl.currentWorkmonth.hourCarryOverLastMonth) * person.saleryPerHour;
                        salarySum += modelControl.getWorktimeForPersonInWorkdays(person, modelControl.currentWorkmonth.workdays, modelControl.currentWorkmonth.shiftplan) * person.saleryPerHour;
                        salarySum += carryOverSalerySum;
                    }

                    infoMonthAverageTurnoverHourContent.Text = Util.clampToDecimalpoints(turnover / modelControl.getWorktimeInWorkdays(modelControl.currentWorkmonth.workdays), 2) + "€";
                    infoMonthAverageTurnoverDayContent.Text = Util.clampToDecimalpoints(turnover / modelControl.getWorkingDaysCounter(modelControl.currentWorkmonth.workdays), 2) + "€";

                    float profit = turnover - salarySum - modelControl.getCostsAmountSum(modelControl.currentWorkmonth.fixCosts) - modelControl.getCostsAmountSum(modelControl.currentWorkmonth.variableCosts);

                    infoMonthProfitAfterSaleriesCostsContent.Text = Util.clampToDecimalpoints(profit, 2) + "€ (" + carryOverSalerySum + "€)";
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
                foreach (Person person in modelControl.currentWorkmonth.persons)
                {
                    salarySum += modelControl.getWorktimeForPersonInWorkdays(person, currentWeek, modelControl.currentWorkmonth.shiftplan) * person.saleryPerHour;
                }
                infoWeekSalerySumContent.Text = Util.clampToDecimalpoints(salarySum, 2) + "€";

                Dictionary<string, int> workshiftsByShiftType = modelControl.getShiftCountInWorkdaysByShiftType(currentWeek);
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

                infoWeekHoursSumContent.Text = modelControl.getWorktimeInWorkdays(currentWeek) + "h";

                if (modelControl.currentWorkmonth.turnoverWeeks.ContainsKey(currentInfoWeekIndex))
                {
                    infoWeekTurnoverTextBox.Text = "" + modelControl.currentWorkmonth.turnoverWeeks[currentInfoWeekIndex];
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
                    if (!modelControl.currentWorkmonth.turnoverWeeks.ContainsKey(currentInfoWeekIndex)){
                        modelControl.currentWorkmonth.turnoverWeeks.Add(currentInfoWeekIndex, 0.0f);
                    }
                    modelControl.currentWorkmonth.turnoverWeeks[currentInfoWeekIndex] = turnover;

                    float salarySum = 0.0f;
                    foreach (Person person in modelControl.currentWorkmonth.persons)
                    {
                        salarySum += modelControl.getWorktimeForPersonInWorkdays(person, currentWeek, modelControl.currentWorkmonth.shiftplan) * person.saleryPerHour;
                    }

                    infoWeekTurnoverAfterSaleriesContent.Text = Util.clampToDecimalpoints(turnover - salarySum, 2) + "€";
                    infoWeekAverageTurnoverHourContent.Text = Util.clampToDecimalpoints(turnover / modelControl.getWorktimeInWorkdays(currentWeek), 2) + "€";
                    infoWeekAverageTurnoverDayContent.Text = Util.clampToDecimalpoints(turnover / modelControl.getWorkingDaysCounter(currentWeek), 2) + "€";
                }
            }
        }

        /// <summary>
        /// sets the info for the selected day in the general info tab
        /// </summary>
        public void setGeneralInfoDay()
        {
            if(currentInfoWorkdayIndex != -1 && daysInDayComboBox.Count > currentInfoWorkdayIndex)
            {
                Workday currentWorkday = daysInDayComboBox[currentInfoWorkdayIndex];

                float salarySum = 0.0f;
                foreach (Person person in modelControl.currentWorkmonth.persons)
                {
                    salarySum += modelControl.getWorktimeForPersonInWorkday(person, currentWorkday, modelControl.currentWorkmonth.shiftplan) * person.saleryPerHour;
                }
                infoDaySalerySumContent.Text = Util.clampToDecimalpoints(salarySum, 2) + "€";

                Dictionary<string, int> workshiftsByShiftType = modelControl.getShiftCountInWorkdayByShiftType(currentWorkday);
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

                infoDayHoursSumContent.Text = modelControl.getWorktimeInWorkday(currentWorkday) + "h";

                if (modelControl.currentWorkmonth.turnoverWorkdays.ContainsKey(currentWorkday))
                {
                    infoDayTurnoverTextBox.Text = "" + modelControl.currentWorkmonth.turnoverWorkdays[currentWorkday];
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
                    if (!modelControl.currentWorkmonth.turnoverWorkdays.ContainsKey(currentWorkday)){
                        modelControl.currentWorkmonth.turnoverWorkdays.Add(currentWorkday, 0.0f);
                    }
                    modelControl.currentWorkmonth.turnoverWorkdays[currentWorkday] = turnover;

                    float salarySum = 0.0f;
                    foreach (Person person in modelControl.currentWorkmonth.persons)
                    {
                        salarySum += modelControl.getWorktimeForPersonInWorkday(person, currentWorkday, modelControl.currentWorkmonth.shiftplan) * person.saleryPerHour;
                    }

                    infoDayTurnoverAfterSaleriesContent.Text = Util.clampToDecimalpoints(turnover - salarySum, 2) + "€";
                    infoDayAverageTurnoverHourContent.Text = Util.clampToDecimalpoints(turnover / modelControl.getWorktimeInWorkday(currentWorkday), 2) + "€";
                }
            }
        }

        /// <summary>
        /// resets all general info
        /// </summary>
        public void resetGeneralInfoView()
        {
            setInfoDayComboBox();
            setInfoWeekComboBox();
            setGeneralInfoMonth();
            setGeneralInfoWeek();
            setGeneralInfoDay();
        }

        #endregion

        #endregion

        #region generated UI functions

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

        #endregion
    }
}

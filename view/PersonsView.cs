using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Schichtplan
{
    public partial class window : Form
    {
        /// <summary>
        /// save backgroundcolors for the Controls in the personTable
        /// </summary>
        private Dictionary<Control, Color> personsControlColors = new Dictionary<Control, Color>();

        /// <summary>
        /// save the currently clicked row
        /// </summary>
        private int currentClickedRowPerson = -1;

        #region my functions

        /// <summary>
        /// fills the personTable with the persons of the currentMonth
        /// </summary>
        private void setPersonTable()
        {
            personsControlColors.Clear();

            personTable.Visible = false;
            personTable.SuspendLayout();
            personTable.Controls.Clear();

            int row = 0;

            //sort persons with the current sort value
            List<Person> persons = modelControl.currentWorkmonth.persons;

            foreach (Person person in persons)
            {
                //set person color depending its set color or transparent if not set
                Color color = transparent;
                if (modelControl.currentWorkmonth.settings.personColors.ContainsKey(person))
                {
                    color = modelControl.currentWorkmonth.settings.personColors[person];
                }

                //set person info into table labels
                string[] personArray = person.ToStringArray();
                for (int i = 0; i < personArray.Length - 1; i++)
                {
                    Label label = createPersonLabel(personArray[i], color);
                    personTable.Controls.Add(label, i, row);
                }

                //add carryover from last month
                string carryOverString = "" + modelControl.getPersonCarryOver(person, modelControl.currentWorkmonth.hourCarryOverLastMonth);
                Label carryOverLabel = createPersonLabel(carryOverString, color);
                personTable.Controls.Add(carryOverLabel, 6, row);

                //add possible shifts not available manually
                Dictionary<string, int> posibleShiftsDict = modelControl.getShiftCountByShiftTypesInWorkdays(person.shiftTypes, modelControl.currentWorkmonth.workdays);
                int posibleShifts = 0;
                foreach(KeyValuePair<string, int> posibleShift in posibleShiftsDict)
                {
                    posibleShifts += posibleShift.Value;
                }
                Label possibleShiftsLabel = createPersonLabel(person.unavailability.Count + "/" + posibleShifts, color);
                personTable.Controls.Add(possibleShiftsLabel, 7, row);

                row++;
            }

            personTable.ResumeLayout();
            personTable.Visible = true;
        }

        /// <summary>
        /// resets the personTab
        /// </summary>
        private void resetPersonView()
        {
            setPersonTable();
            setInfoPersonTable();
            setPersonUnavailableShiftSelector();
        }

        /// <summary>
        /// sets the data of the currentPerson into the unavailableShiftSelector
        /// </summary>
        private void setPersonUnavailableShiftSelector()
        {
            personUnavailableshiftSelectDataGridView.Rows.Clear();

            //add shifts in shiftselector
            if (personsControl.currentPersonInEdit != null)
            {
                List<Workshift> posibleWorkshifts = modelControl.getPossibleWorkshiftsForPersonInWorkdays(personsControl.currentPersonInEdit, modelControl.currentWorkmonth.workdays);
                //load shifts from the currend Workday
                foreach (Workday workday in modelControl.currentWorkmonth.workdays)
                {
                    foreach (Workshift workshift in workday.shifts)
                    {
                        //only load possibleWorkshifts
                        if (posibleWorkshifts.Contains(workshift))
                        {
                            string shiftInfo = workday.weekday + ", " + workday.day + " " + modelControl.currentWorkmonth.monthName + ": " + workshift.ToString();
                            bool unavailable = personsControl.currentPersonInEdit.unavailability.Contains(workshift);
                            bool onlyOneAvailable = modelControl.isPersonOnlyOneAvailableForWorkshift(personsControl.currentPersonInEdit,
                                modelControl.currentWorkmonth.persons, workshift, modelControl.currentWorkmonth.workdays);
                            int row = personUnavailableshiftSelectDataGridView.Rows.Add();
                            personUnavailableshiftSelectDataGridView.Rows[row].Cells[0].Value = shiftInfo;
                            personUnavailableshiftSelectDataGridView.Rows[row].Cells[1].Value = unavailable;
                            personUnavailableshiftSelectDataGridView.Rows[row].Cells[2].Value = onlyOneAvailable;
                            Color color = getColorForWeekDay(workday.weekday);
                            personUnavailableshiftSelectDataGridView.Rows[row].DefaultCellStyle.BackColor = color;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// sets unavailibilities for the currentPerson based on a commant.
        /// the commant can be structured as follows:
        /// <list type="bullet">
        /// <item>
        /// <description>&lt;Hour (&lt;17) sets all workshifts before that hour or which happen during this hour as unavailable</description>
        /// </item>
        /// <item>
        /// <description>>Hour (>17) sets all workshifts before that hour or which happen during this hour as unavailable</description>
        /// </item>
        /// <item>
        /// <description>Weekdayname (Mittwoch) sets all workshifts from all days with this weekdayname as unavailable</description>
        /// </item>
        /// <item>
        /// <description>Day (14) sets all workshifts from this day as unavailable</description>
        /// </item>
        /// <item>
        /// <description>Day-Day (14-17) sets all workshifts from the first day to the second day as unavailable</description>
        /// </item>
        /// </list>
        /// these comments can be seperated by a , to allow for more then one to be activated at a time
        /// they can be linked together with a &
        /// if the lead with a *, the person is se to be the only one for the workshifts and all other persons are set to be unavailable
        /// </summary>
        /// <param name="commant">the commant which will set the unavailibilities</param>
        private void setPersonUnavailabilitiesFromCommant(string commant)
        {
            // Define individual patterns for each expression type
            string numberPattern = @"^\d+$";
            string numberRangePattern = @"^\d+-\d+$";
            string lessThanPattern = @"^<\d+$";
            string greaterThanPattern = @"^>\d+$";
            string stringPattern = @"^[a-zA-Z]+$";

            // Create Regex objects for each pattern
            Regex numberRegex = new Regex(numberPattern);
            Regex numberRangeRegex = new Regex(numberRangePattern);
            Regex lessThanRegex = new Regex(lessThanPattern);
            Regex greaterThanRegex = new Regex(greaterThanPattern);
            Regex stringRegex = new Regex(stringPattern);

            //string array, were all combinations have their own index. Combinations are bundled expressions with a & symbol
            string[] combinations = commant.Split(',');

            //list with all workshifts, which are unavailable for the person
            List<int> workshiftIndexes = new List<int>();

            //list with all workshifts, where the person is the only one for the shift
            List<int> workshiftIndexesOnlyOne = new List<int>();

            foreach (string combination in combinations)
            {
                string combo = combination;
                //list with all workshiftsIndexes, which are found in the combos
                List<int> comboList = null;

                //if set to true, the extracted workshifts are made unavailable for all other persons except the currentPerson
                bool onlyOne = false;

                if (combo[0] == '*')
                {
                    onlyOne = true;
                    combo = combo.Substring(1);
                }

                //string array, were all expressions have their own index
                string[] expressions = combo.Split('&');

                foreach (string expression in expressions)
                {
                    //list with all workshiftsIndexes, which are found in the expression
                    List<int> expressionList = new List<int>();

                    //get workshiftindexes for expression
                    if (numberRegex.IsMatch(expression))
                    {
                        int day = Util.parseInt(expression,
                            "Bitte nur positive Zahlen verwenden, die auch in dem Monat vorkommen.");
                        expressionList.AddRange(modelControl.getWorkshiftIndexesForWorkdayIndexForPersonInWorkdays(day, personsControl.currentPersonInEdit, modelControl.currentWorkmonth.workdays));
                    }
                    else if (numberRangeRegex.IsMatch(expression))
                    {
                        string[] split = expression.Split('-');
                        int from = Util.parseInt(split[0], "Bitte nur positive Zahlen verwenden, die auch in dem Monat vorkommen.");
                        int to = Util.parseInt(split[1], "Bitte nur positive Zahlen verwenden, die auch in dem Monat vorkommen.");
                        for (int day = from; day <= to; day++)
                        {
                            expressionList.AddRange(modelControl.getWorkshiftIndexesForWorkdayIndexForPersonInWorkdays(day, personsControl.currentPersonInEdit, modelControl.currentWorkmonth.workdays));
                        }
                    }
                    else if (lessThanRegex.IsMatch(expression))
                    {
                        int hour = Util.parseInt(expression.Substring(1), "Bitte nur positive Zahlen für eine gewählte Stunde verwenden.");

                        foreach (Workday workday in modelControl.currentWorkmonth.workdays)
                        {
                            foreach (Workshift workshift in workday.shifts)
                            {
                                if (workshift.startHour < hour && workshift.endHour >= hour || workshift.endHour < hour)
                                {
                                    expressionList.Add(modelControl.getWorkshiftIndexForWorkshiftForPersonInWorkdays(workshift, personsControl.currentPersonInEdit, modelControl.currentWorkmonth.workdays));
                                }
                            }
                        }
                    }
                    else if (greaterThanRegex.IsMatch(expression))
                    {
                        int hour = Util.parseInt(expression.Substring(1), "Bitte nur positive Zahlen für eine gewählte Stunde verwenden.");

                        foreach (Workday workday in modelControl.currentWorkmonth.workdays)
                        {
                            foreach (Workshift workshift in workday.shifts)
                            {
                                if (workshift.startHour < hour && workshift.endHour > hour || workshift.startHour >= hour)
                                {
                                    expressionList.Add(modelControl.getWorkshiftIndexForWorkshiftForPersonInWorkdays(workshift, personsControl.currentPersonInEdit, modelControl.currentWorkmonth.workdays));
                                }
                            }
                        }
                    }
                    else if (stringRegex.IsMatch(expression))
                    {
                        List<Workshift> posibleWorkshifts = modelControl.getPossibleWorkshiftsForPersonInWorkdays(personsControl.currentPersonInEdit, modelControl.currentWorkmonth.workdays);

                        foreach (Workday workday in modelControl.currentWorkmonth.workdays)
                        {
                            if (workday.weekday == expression)
                            {
                                expressionList.AddRange(modelControl.getWorkshiftIndexesForWorkdayIndexForPersonInWorkdays(workday.day, personsControl.currentPersonInEdit, modelControl.currentWorkmonth.workdays));
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bitte nur folgende Formate im Nicht verfügbarkeits Textfeld nutzen:\n" +
                            "<Uhrzeit; >Uhrzeit; Wochentag; Tag; Tag-Tag\n\n" +
                            "diese Ausdrücke können durch ein Kommata getrennt beliebig verschachtelt werden und durch ein & kombiniert.");
                    }

                    //first workshifts found are set as the baseline
                    if (comboList == null)
                    {
                        comboList = expressionList;
                    }
                    else
                    {
                        //only add indexes to the combo list if they are in both lists
                        List<int> temp = new List<int>();
                        foreach (int workshiftIndex in comboList)
                        {
                            if (expressionList.Contains(workshiftIndex))
                            {
                                temp.Add(workshiftIndex);
                            }
                        }
                        comboList = temp;
                    }
                }

                //add workshiftsIndexes to one of the lists depending on the onlyOne boolean
                if(onlyOne == true)
                {
                    foreach (int workshiftIndex in comboList)
                    {
                        if (!workshiftIndexesOnlyOne.Contains(workshiftIndex))
                        {
                            workshiftIndexesOnlyOne.Add(workshiftIndex);
                        }
                    }
                }
                else
                {
                    foreach (int workshiftIndex in comboList)
                    {
                        if (!workshiftIndexes.Contains(workshiftIndex))
                        {
                            workshiftIndexes.Add(workshiftIndex);
                        }
                    }
                }
            }

            foreach (int workshiftIndex in workshiftIndexes)
            {
                if(workshiftIndex != -1)
                {
                    personUnavailableshiftSelectDataGridView.Rows[workshiftIndex].Cells[1].Value = true;
                }
            }
            foreach (int workshiftIndex in workshiftIndexesOnlyOne)
            {
                if (workshiftIndex != -1)
                {
                    personUnavailableshiftSelectDataGridView.Rows[workshiftIndex].Cells[2].Value = true;
                }
            }
        }

        /// <summary>
        /// creates a new Label for the personTable with a given text and backgroundcolor.
        /// adds the Eventhandlers for the personTable.
        /// </summary>
        /// <param name="Text">text for the label</param>
        /// <param name="backColor">backgroundcolor for the label</param>
        /// <returns>Label for the personTable</returns>
        private Label createPersonLabel(string Text, Color backColor)
        {
            Label label = createTableLabel(personsControlColors, personTable.Width, tableLabelHeight, Text, backColor);
            label.MouseEnter += new EventHandler(personTableLabel_MouseEnter);
            label.MouseLeave += new EventHandler(personTableLabel_MouseLeave);
            label.Click += new EventHandler(personTableLabel_Click);
            return label;
        }

        /// <summary>
        /// gets the information in the person textboxes in a string array format
        /// </summary>
        /// <returns>the information of the person textboxes as a string array</returns>
        private string[] getPersonInfoFromTextBoxes()
        {
            //check if there is an entry in every TextBox
            if (personNameTextBox.Text == ""
                || personSaleryTextBox.Text == ""
                || personMinWorkHoursTextBox.Text == ""
                || personMaxWorkHoursTextBox.Text == ""
                || personShifttypesTextBox.Text == ""
                || personDescriptionTextBox.Text == ""
                || personCarryOverTextBox.Text == "")
            {
                MessageBox.Show("Bitte in jedes Textfeld etwas eintragen.");
                return new string[0];
            }
            //fill array with data from datagridview
            string[] personData = {
                personNameTextBox.Text,
                personSaleryTextBox.Text,
                personMinWorkHoursTextBox.Text,
                personMaxWorkHoursTextBox.Text,
                personShifttypesTextBox.Text,
                personDescriptionTextBox.Text,
                personCarryOverTextBox.Text
            };
            return personData;
        }

        /// <summary>
        /// gets the unavailable workshifts from the personUnavailableshiftSelectDataGridView and puts them in a boolean array format
        /// </summary>
        /// <returns>
        /// the unavailable workshifts from the personUnavailableshiftSelectDataGridView as a boolean array.
        /// the index for each workshift is the order in the dataGridView.
        /// <paramref name="checkBoxColumn">the column for which to search the checkbox values</param>
        /// </returns>
        private bool[] getPersonUnavailabilityCheckBoxValue(int checkBoxColumn)
        {
            bool[] result = new bool[modelControl.getPossibleWorkshiftsForPersonInWorkdays(personsControl.currentPersonInEdit, modelControl.currentWorkmonth.workdays).Count];

            for (int i = 0; i < personUnavailableshiftSelectDataGridView.RowCount; i++)
            {
                result[i] = (bool)personUnavailableshiftSelectDataGridView.Rows[i].Cells[checkBoxColumn].Value;
            }

            return result;
        }

        /// <summary>
        /// sorts the persons in the currentWorkmonth and sets the person tables accordingly
        /// </summary>
        /// <param name="personTableSort">sort string</param>
        private void sortPersons(string personTableSort)
        {
            modelControl.getPersonsSortedBy(personTableSort, modelControl.currentWorkmonth.persons);
            setPersonTable();
            setInfoPersonTable();
        }

        /// <summary>
        /// sets the person, which was clicked as the currentPersonInEdit and sets all its data into the textboxes and loads its unavailablilities
        /// </summary>
        /// <param name="row"></param>
        private void setSelectedPerson(int row)
        {
            personsControl.setCurrentPersonInEdit(row);

            //set person TextBoxes to info
            personNameTextBox.Text = personsControl.currentPersonInEdit.name;
            personSaleryTextBox.Text = "" + personsControl.currentPersonInEdit.saleryPerHour;
            personMinWorkHoursTextBox.Text = "" + personsControl.currentPersonInEdit.minWorkHours;
            personMaxWorkHoursTextBox.Text = "" + personsControl.currentPersonInEdit.maxWorkHours;
            personShifttypesTextBox.Text = personsControl.currentPersonInEdit.shiftTypesToString();
            personDescriptionTextBox.Text = personsControl.currentPersonInEdit.description;
            personCarryOverTextBox.Text = modelControl.getPersonCarryOver(personsControl.currentPersonInEdit, modelControl.currentWorkmonth.hourCarryOverLastMonth) + "";

            personColorButton.BackColor = transparent;
            if (modelControl.currentWorkmonth.settings.personColors.ContainsKey(personsControl.currentPersonInEdit))
            {
                personColorButton.BackColor = modelControl.currentWorkmonth.settings.personColors[personsControl.currentPersonInEdit];
            }

            //load shiftUnavaialbeSelector
            setPersonUnavailableShiftSelector();

            if (currentClickedRowPerson != -1)
            {
                resetTableControlColor(personTable, personsControlColors, currentClickedRowPerson);
            }
            currentClickedRowPerson = row;
        }

        #endregion

        #region generated UI functions

        /// <summary>
        /// handels the click event for the personColorButton button
        /// sets the current Color for the current person in edit
        /// </summary>
        /// <param name="sender">the button control</param>
        /// <param name="e">event details</param>
        private void personColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                personColorButton.BackColor = colorDialog.Color;
            }
        }

        /// <summary>
        /// handels the click event for the personResetAllUnavailabilitiesButton button
        /// resets the unavailabilities from all persons
        /// </summary>
        /// <param name="sender">the button control</param>
        /// <param name="e">event details</param>
        private void personResetAllUnavailabilitiesButton_Click(object sender, EventArgs e)
        {
            //dialog to tell the user, that all unavailablilities are beeing rest with this button
            DialogResult dialogResult = MessageBox.Show("Hierdurch werden alle nicht verfügbarkeiten von allen Personen gelöscht.\n\n" +
                "Willst du fortfahren?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //reset all unavailablilities and reload the persons view
                personsControl.resetUnavailabilities(modelControl.currentWorkmonth.persons);
                resetPersonView();
            }
        }

        /// <summary>
        /// handels the click event for the personAddButton button
        /// adds a person to the persons in the currentMonth with the entries in the person textBoxes
        /// </summary>
        /// <param name="sender">the button control</param>
        /// <param name="e">event details</param>
        private void personAddButton_Click(object sender, EventArgs e)
        {
            string[] data = getPersonInfoFromTextBoxes();
            if (data.Length > 0)
            {
                personsControl.addPerson(getPersonInfoFromTextBoxes(), personColorButton.BackColor);
                resetTableControlColor(personTable, personsControlColors, currentClickedRowPerson);
                resetPersonView();
                currentClickedRowPerson = modelControl.currentWorkmonth.persons.Count - 1;
                setTableControlColor(personTable, currentClickedRowPerson, hoverColor);
            }
        }

        /// <summary>
        /// handels the click event for the personDeleteButton button
        /// deletes the currentPerson from the persons list in the currentMonth
        /// </summary>
        /// <param name="sender">the button control</param>
        /// <param name="e">event details</param>
        private void personDeleteButton_Click(object sender, EventArgs e)
        {
            if(personsControl.currentPersonInEdit != null)
            {
                personsControl.deleteCurrentPerson();
                resetTableControlColor(personTable, personsControlColors, currentClickedRowPerson);
                currentClickedRowPerson = -1;
                resetPersonView();
            }
        }

        /// <summary>
        /// handels the click event for the personSaveEditButton button
        /// edits the currentPerson with the information in the person textBoxes
        /// </summary>
        /// <param name="sender">the button control</param>
        /// <param name="e">event details</param>
        private void personSaveEditButton_Click(object sender, EventArgs e)
        {
            if(personsControl.currentPersonInEdit == null)
            {
                MessageBox.Show("Bitte erst Person zum editieren auswählen.");
                return;
            }
            string[] personData = getPersonInfoFromTextBoxes();
            if (personData.Length > 0)
            {
                personsControl.editCurrentPerson(personData, getPersonUnavailabilityCheckBoxValue(1), getPersonUnavailabilityCheckBoxValue(2), personColorButton.BackColor);
                resetPersonView();
                setTableControlColor(personTable, currentClickedRowPerson, hoverColor);
                resetShiftPlanView();
            }
        }

        /// <summary>
        /// sets all unavailable checkBoxes in the personUnvailabilityDataGridView to its value
        /// </summary>
        /// <param name="sender">the checkBox</param>
        /// <param name="e">event details</param>
        private void personSetAll_CheckedChanged(object sender, EventArgs e)
        {
            bool check = personSetAllUnavailabilitiesCheckBox.Checked;
            foreach (DataGridViewRow row in personUnavailableshiftSelectDataGridView.Rows)
            {
                row.Cells[1].Value = check;
            }
        }

        /// <summary>
        /// handels the click event for the personSetDaysUnavailableButton button
        /// calls the setPersonUnavailabilitiesFromCommant function with the text in the personSetDaysUnavailableTextBox
        /// </summary>
        /// <param name="sender">the button control</param>
        /// <param name="e">event details</param>
        private void personSetDaysUnavailableButton_Click(object sender, EventArgs e)
        {
            setPersonUnavailabilitiesFromCommant(personSetDaysUnavailableTextBox.Text);
        }

        /// <summary>
        /// handels the mouseEnter Event for the personTable labels
        /// </summary>
        /// <param name="sender">the label, where the mouse entered</param>
        /// <param name="e">event details</param>
        private void personTableLabel_MouseEnter(object sender, EventArgs e)
        {
            int row = personTable.GetRow((Control)sender);
            setTableControlColor(personTable, row, hoverColor);
        }

        /// <summary>
        /// handels the mouseLeave Event for the personTable labels
        /// </summary>
        /// <param name="sender">the label, where the mouse left</param>
        /// <param name="e">event details</param>
        private void personTableLabel_MouseLeave(object sender, EventArgs e)
        {
            Control control = sender as Control;
            int row = personTable.GetRow(control);
            if (row != currentClickedRowPerson)
            {
                resetTableControlColor(personTable, personsControlColors, row);
            }
        }

        /// <summary>
        /// handels the mouseClick Event for the personTable labels
        /// sets the currentPerson to the clicked person
        /// </summary>
        /// <param name="sender">the label, which was clicked</param>
        /// <param name="e">event details</param>
        private void personTableLabel_Click(object sender, EventArgs e)
        {
            int row = personTable.GetRow((Control)sender);
            setSelectedPerson(row);
        }

        /// <summary>
        /// handels the click event for the personLoadFromDifferentMonthButton button
        /// loads the persons of another month, which is selected with a OpenFileDialog
        /// </summary>
        /// <param name="sender">the button</param>
        /// <param name="e">event details</param>
        private void personLoadFromDifferentMonthButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Mit dem laden anderer Personen wird der aktuelle Schichtplan gelöscht.\n\n" +
                "Willst du fortfahren?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                OpenFileDialog openFileDialog = createOpenFileDialog(Serializer.Instance().BASE_DICT + "" + Serializer.SAVE_FOLDER);

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Workmonth workMonth = (Workmonth)Serializer.Instance().loadObject(openFileDialog.FileName);

                    personsControl.setPersonsFromOtherMonth(workMonth);

                    currentClickedRowPerson = -1;

                    resetPersonView();
                    resetShiftPlanView();
                }
            }
        }

        #endregion
    }
}

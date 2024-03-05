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
        /// save backgroundcolors for the Controls in the shiftPlanTable
        /// </summary>
        private Dictionary<Control, Color> shiftplanControlColors = new Dictionary<Control, Color>();

        /// <summary>
        /// saves the row in the shiftPlanTable to a corresponding workshift
        /// </summary>
        private Dictionary<int, Workshift> shiftPlanRowToWorkshift = new Dictionary<int, Workshift>();

        /// <summary>
        /// row the Mouse pressed down on
        /// </summary>
        int mouseDownRow = -1;

        /// <summary>
        /// save the currently clicked row
        /// </summary>
        int currentClickedRowShiftPlan = -1;

        /// <summary>
        /// fills the shiftPlanTable with the workshifts and its corresponding persons in the shiftPlan
        /// </summary>
        private void setShiftPlan()
        {
            shiftplanControlColors.Clear();

            shiftPlanTable.Visible = false;
            shiftPlanTable.SuspendLayout();
            shiftPlanTable.Controls.Clear();

            List<List<Workday>> weeks = modelControl.getWeeksInWorkdays(modelControl.currentWorkmonth.workdays);

            int row = 0;

            for (int weekCounter = 0; weekCounter < weeks.Count; weekCounter++)
            {
                List<Workday> week = weeks[weekCounter];

                //create Week Information
                Label weekLabel = createShiftPlanLabel("Woche " + weekCounter + ", " + modelControl.getFirstAndLastDayInWorkdaysAsString(week), weekColor);
                weekLabel.ForeColor = weekFontColor;
                weekLabel.Font = new Font(weekLabel.Font.FontFamily, weekFontSize, FontStyle.Bold);
                weekLabel.Height = weekLabelHeight;

                string worktimesByShiftTypeString = "";

                Dictionary<string, float> worktimesByShifttype = modelControl.getWorktimesForShiftTypesInWorkdays(week);

                foreach (KeyValuePair<string, float> worktime in worktimesByShifttype)
                {
                    worktimesByShiftTypeString += worktime.Key + ": " + Util.clampToDecimalpoints(worktime.Value, 2) + "h; ";
                }
                float totalWorktime = modelControl.getWorktimeInWorkdays(week);
                worktimesByShiftTypeString += "Gesamt: " + Util.clampToDecimalpoints(totalWorktime, 2) + "h";

                Label weekInfo = createShiftPlanLabel(worktimesByShiftTypeString, weekColor);
                weekInfo.ForeColor = weekFontColor;
                weekInfo.Font = new Font(weekInfo.Font.FontFamily, weekFontSize, FontStyle.Bold);
                weekInfo.Height = weekLabelHeight;

                Label weekDescription = createShiftPlanLabel("Beschreibung", weekColor);
                weekDescription.ForeColor = weekFontColor;
                weekDescription.Font = new Font(weekDescription.Font.FontFamily, weekFontSize, FontStyle.Bold);
                weekDescription.Height = weekLabelHeight;

                shiftPlanTable.Controls.Add(weekLabel, 0, row);
                shiftPlanTable.Controls.Add(weekInfo, 1, row);
                shiftPlanTable.Controls.Add(weekDescription, 2, row);
                row++;

                foreach(Workday workday in week)
                {
                    if (workday.shifts.Count > 0)
                    {
                        //create Day Information
                        Label day = createShiftPlanLabel(workday.weekday + ", " + workday.day + " " + modelControl.currentWorkmonth.monthName,
                            dayColor);
                        day.ForeColor = dayFontColor;
                        day.Font = new Font(day.Font.FontFamily, dayFontSize, FontStyle.Bold);
                        day.Height = dayLabelHeight;

                        Dictionary<string, float> worktimesByShifttypeDay = modelControl.getWorktimesForShiftTypesInWorkday(workday);

                        string worktimesByShiftTypeDayString = "";

                        foreach (KeyValuePair<string, float> worktime in worktimesByShifttypeDay)
                        {
                            worktimesByShiftTypeDayString += worktime.Key + ": " + Util.clampToDecimalpoints(worktime.Value, 2) + "h; ";
                        }
                        float totalWorktimeDay = modelControl.getWorktimeInWorkday(workday);
                        worktimesByShiftTypeDayString += "Gesamt: " + Util.clampToDecimalpoints(totalWorktimeDay, 2) + "h";

                        Label dayInfo = createShiftPlanLabel(worktimesByShiftTypeDayString, dayColor);
                        dayInfo.ForeColor = dayFontColor;
                        dayInfo.Font = new Font(dayInfo.Font.FontFamily, dayFontSize, FontStyle.Bold);
                        dayInfo.Height = dayLabelHeight;

                        Label dayEmpty = createShiftPlanLabel("", dayColor);
                        dayEmpty.ForeColor = dayFontColor;
                        dayEmpty.Font = new Font(dayInfo.Font.FontFamily, dayFontSize, FontStyle.Bold);
                        dayEmpty.Height = dayLabelHeight;

                        shiftPlanTable.Controls.Add(day, 0, row);
                        shiftPlanTable.Controls.Add(dayInfo, 1, row);
                        shiftPlanTable.Controls.Add(dayEmpty, 2, row);
                        row++;

                        //create Shift Information
                        foreach (Workshift workshift in workday.shifts)
                        {
                            if (modelControl.currentWorkmonth.shiftplan.ContainsKey(workshift))
                            {
                                Person person = modelControl.currentWorkmonth.shiftplan[workshift];

                                Color workshiftColor = transparent;
                                if (modelControl.currentWorkmonth.settings.shiftTypeColors.ContainsKey(workshift.shiftType)){
                                    workshiftColor = modelControl.currentWorkmonth.settings.shiftTypeColors[workshift.shiftType];
                                }

                                Color personColor = transparent;
                                if (modelControl.currentWorkmonth.settings.personColors.ContainsKey(person)){
                                    personColor = modelControl.currentWorkmonth.settings.personColors[person];
                                }

                                float carryOver = modelControl.currentWorkmonth.hourCarryOverLastMonth.ContainsKey(person) ? modelControl.currentWorkmonth.hourCarryOverLastMonth[person] : 0;

                                string personString = person.name;
                                personString += " (" + Util.clampToDecimalpoints(modelControl.getWorktimeForPersonInWorkdays(person, week, modelControl.currentWorkmonth.shiftplan), 2) + ", "
                                    + modelControl.getDaysNotWorkingForPersonInWorkdaysCount(person, week, modelControl.currentWorkmonth.shiftplan) + ")";
                                personString += " [" + Util.clampToDecimalpoints(modelControl.getWorktimeForPersonInWorkdays(person, modelControl.currentWorkmonth.workdays, modelControl.currentWorkmonth.shiftplan), 2) + "+" + carryOver + ", "
                                    + modelControl.getDaysNotWorkingForPersonInWorkdaysCount(person, modelControl.currentWorkmonth.workdays, modelControl.currentWorkmonth.shiftplan) + "]";

                                Label name = createShiftPlanLabel(personString, personColor);
                                Label shift = createShiftPlanLabel(workshift.ToString() + " (" + Util.clampToDecimalpoints(modelControl.getWorktimeInWorkshift(workshift), 2) + ")", workshiftColor);
                                Label description = createShiftPlanLabel(workshift.description, transparent);

                                shiftPlanTable.Controls.Add(name, 0, row);
                                shiftPlanTable.Controls.Add(shift, 1, row);
                                shiftPlanTable.Controls.Add(description, 2, row);
                            }
                            else
                            {
                                Color backColor = Color.Purple;
                                Color workshiftColor = transparent;
                                if (modelControl.currentWorkmonth.settings.shiftTypeColors.ContainsKey(workshift.shiftType))
                                {
                                    workshiftColor = modelControl.currentWorkmonth.settings.shiftTypeColors[workshift.shiftType];
                                }

                                Label name = createShiftPlanLabel("KEINE PERSON GEFUNDEN", backColor);
                                Label shift = createShiftPlanLabel(workshift.ToString() + " (" + Util.clampToDecimalpoints(modelControl.getWorktimeInWorkshift(workshift), 2) + ")", workshiftColor);
                                Label description = createShiftPlanLabel(workshift.description, transparent);

                                shiftPlanTable.Controls.Add(name, 0, row);
                                shiftPlanTable.Controls.Add(shift, 1, row);
                                shiftPlanTable.Controls.Add(description, 2, row);

                            }

                            //add workshift to rowToWorkshift
                            shiftPlanRowToWorkshift[row] = workshift;
                            row++;
                        }
                        Label emtpy0 = createShiftPlanLabel("", Color.White);
                        Label emtpy1 = createShiftPlanLabel("", Color.White);
                        Label emtpy2 = createShiftPlanLabel("", Color.White);
                        shiftPlanTable.Controls.Add(emtpy0, 0, row);
                        shiftPlanTable.Controls.Add(emtpy1, 1, row);
                        shiftPlanTable.Controls.Add(emtpy2, 2, row);
                        row++;
                    }
                }
            }

            shiftPlanTable.ResumeLayout();
            shiftPlanTable.Visible = true;
        }

        /// <summary>
        /// creates a new Label for the shiftPlanTable with a given text and backgroundcolor.
        /// adds the Eventhandlers for the personTable.
        /// </summary>
        /// <param name="Text">text for the label</param>
        /// <param name="backColor">backgroundcolor for the label</param>
        /// <returns>Label for the shiftPlanTable</returns>
        private Label createShiftPlanLabel(string Text, Color backColor)
        {
            Label label = new Label();
            label.Text = Text;
            label.Margin = new Padding(0);
            label.Size = new Size(shiftPlanTable.Width, 20);
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.BackColor = backColor;
            label.AllowDrop = true;
            //EventHandlers
            label.MouseEnter += new EventHandler(shiftPlanLabel_MouseEnter);
            label.MouseLeave += new EventHandler(shiftPlanLabel_MouseLeave);
            label.MouseDown += new MouseEventHandler(shiftPlanLabel_MouseDown);
            label.DragEnter += new DragEventHandler(shiftPlanLabel_DragEnter);
            label.DragDrop += new DragEventHandler(shiftPlanLabel_DragDrop);
            label.MouseUp += new MouseEventHandler(shiftPlanLabel_MouseUp);
            shiftplanControlColors.Add(label, backColor);
            return label;
        }

        /// <summary>
        /// sets the ShiftEditPersonsComboBox items with the name of the persons of the currentMonth
        /// also writes the worked hours of the person to them and
        /// add a * if they are theoretically not available for this workshift
        /// </summary>
        private void setShiftEditPersonsComboBoxItems(Workshift workshift)
        {
            if(workshift != null)
            {
                shiftPlanPersonComboBox.Items.Clear();
                shiftPlanPersonComboBox.Text = "";

                List<Person> availablePersons = modelControl.getAvailablePersonsInWorkshift(workshift, modelControl.currentWorkmonth.persons);

                //Fill content
                int counter = 0;
                foreach (Person person in modelControl.currentWorkmonth.persons)
                {
                    float carryOver = modelControl.currentWorkmonth.hourCarryOverLastMonth.ContainsKey(person) ? modelControl.currentWorkmonth.hourCarryOverLastMonth[person] : 0;

                    string content = availablePersons.Contains(person) ? "" : "*";
                    content += person.name + "; " + modelControl.getWorktimeForPersonInWorkdays(person, modelControl.currentWorkmonth.workdays, modelControl.currentWorkmonth.shiftplan) + "h (+" + carryOver + "h)";
                    shiftPlanPersonComboBox.Items.Add(content);

                    if (modelControl.currentWorkmonth.shiftplan.ContainsKey(workshift)
                        && modelControl.currentWorkmonth.shiftplan[workshift] == person)
                    {
                        shiftPlanPersonComboBox.SelectedIndex = counter;
                    }
                    counter++;
                }
            }
            else
            {
                shiftPlanPersonComboBox.Items.Clear();
                shiftPlanPersonComboBox.Text = "";
            }
        }

        /// <summary>
        /// checks if there are persons with unsatisfied Worktimes and creates an alert with a list of them
        /// </summary>
        private void checkPersonsWithUnsatisfiedWorktimes()
        {
            List<Person> minPersons = modelControl.getPersonsWithLessThanMinWorkhours(modelControl.currentWorkmonth.persons, modelControl.currentWorkmonth.workdays, modelControl.currentWorkmonth.shiftplan, modelControl.currentWorkmonth.hourCarryOverLastMonth);
            List<Person> maxPersons = modelControl.getPersonsWithMoreThanMaxWorkhours(modelControl.currentWorkmonth.persons, modelControl.currentWorkmonth.workdays, modelControl.currentWorkmonth.shiftplan, modelControl.currentWorkmonth.hourCarryOverLastMonth);

            if(minPersons.Count > 0 || maxPersons.Count > 0)
            {
                string minPersonString = "";
                string maxPersonString = "";

                if (minPersons.Count > 0)
                {
                    foreach (Person person in minPersons)
                    {
                        minPersonString += person.name + "\n";
                    }
                    minPersonString += "erreicht/erreichen ihre Mindest Arbeitsstunden im Monat nicht.\n\n";
                }

                if (maxPersons.Count > 0)
                {
                    foreach (Person person in maxPersons)
                    {
                        maxPersonString += person.name + "\n";
                    }
                    maxPersonString += "hat/haben zuviele Arbeitsstunden als ihr Maximum im Monat zulässt.";
                }

                MessageBox.Show(minPersonString + maxPersonString);
            }
        }
        
        /// <summary>
        /// gets the information in the workshift textboxes in a string array format
        /// </summary>
        /// <returns>the information of the person textboxes as a string array</returns>
        private string[] getWorkshiftInfoFromTextBoxes()
        {
            //check if there is an entry in every TextBox
            if (shiftPlanShiftStartTextBox.Text == ""
                || shiftPlanShiftEndTextBox.Text == ""
                || shiftPlanShiftTypeTextBox.Text == ""
                || shiftPlanDescriptionTextBox.Text == "")
            {
                MessageBox.Show("Bitte in jedes Textfeld etwas eintragen.");
                return new string[0];
            }
            //fill array with data from datagridview
            string[] row = {
                shiftPlanShiftStartTextBox.Text,
                shiftPlanShiftEndTextBox.Text,
                shiftPlanShiftTypeTextBox.Text,
                shiftPlanDescriptionTextBox.Text
            };
            return row;
        }

        /// <summary>
        /// sets the items for the shiftType color selector in the shiftPlanTab
        /// </summary>
        private void setShiftPlanShiftTypeColorComboBoxItems()
        {
            shiftPlanShiftTypeColorComboBox.Items.Clear();
            foreach(string shiftType in modelControl.getShiftTypesInWorkdays(modelControl.currentWorkmonth.workdays))
            {
                shiftPlanShiftTypeColorComboBox.Items.Add(shiftType);
            }
        }

        /// <summary>
        /// resets the shiftPlanView
        /// </summary>
        public void resetShiftPlanTab()
        {
            checkPersonsWithUnsatisfiedWorktimes();
            setShiftPlan();
            resetGeneralInfo();
            setInfoPersonTable();
            setShiftPlanShiftTypeColorComboBoxItems();
            setShiftsNotSetLabel();
        }

        /// <summary>
        /// shows all shifts, which are not set in a messagebox
        /// </summary>
        private void showShiftsNotSet()
        {
            List<Workshift> emtpyWorkshifts = modelControl.getEmtpyWorkshiftsInWorkdays(modelControl.currentWorkmonth.workdays, modelControl.currentWorkmonth.shiftplan);
            if (emtpyWorkshifts.Count > 0)
            {
                string errorMessage = "";
                foreach (Workshift workshift in emtpyWorkshifts)
                {
                    errorMessage += modelControl.getWorkdayFromWorkshiftInWorkdays(workshift, modelControl.currentWorkmonth.workdays).day + ": " + workshift.ToString() + "\n";
                }
                MessageBox.Show("Keine Person für Schicht(en): \n\n" + errorMessage + "\n gefunden");
            }
        }

        /// <summary>
        /// sets the text for the label, which shows the amount of shifts that are not set
        /// </summary>
        private void setShiftsNotSetLabel()
        {
            List<Workshift> emtpyWorkshifts = modelControl.getEmtpyWorkshiftsInWorkdays(modelControl.currentWorkmonth.workdays, modelControl.currentWorkmonth.shiftplan);
            int workshiftsCount = modelControl.getWorkShiftsCountInWorkdays(modelControl.currentWorkmonth.workdays);

            shiftPlanShiftsNotSetLabel.Text = "Nicht gesetzte Schichten: " + emtpyWorkshifts.Count + "/" + workshiftsCount;
            shiftPlanShiftsNotSetLabel.BackColor = emtpyWorkshifts.Count == 0 ? Color.Green : Color.Red;
        }

        /// <summary>
        /// sets the comboboxitems and textboxes to the given workshift
        /// </summary>
        private void setWorkshiftInShiftEdit(Workshift workshift)
        {
            //set ComboBox Values
            setShiftEditPersonsComboBoxItems(workshift);
            if (workshift != null)
            {
                //set other data in Textboxes
                shiftPlanShiftStartTextBox.Text = workshift.getStartTimeAsString();
                shiftPlanShiftEndTextBox.Text = workshift.getEndTimeAsString();
                shiftPlanShiftTypeTextBox.Text = workshift.shiftType;
                shiftPlanDescriptionTextBox.Text = workshift.description;
            }
            else
            {
                shiftPlanShiftStartTextBox.Text = "";
                shiftPlanShiftEndTextBox.Text = "";
                shiftPlanShiftTypeTextBox.Text = "";
                shiftPlanDescriptionTextBox.Text = "";
            }
        }

        //-------------------generated---------------------

        /// <summary>
        /// handels the SelectedIndex Event in the shiftPlanShiftTypeColorComboBox
        /// sets the button color of the color chooser shiftPlanShiftTypeColorButton
        /// </summary>
        /// <param name="sender">the combobox</param>
        /// <param name="e">event details</param>
        private void shiftPlanShiftTypeColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modelControl.currentWorkmonth.settings.shiftTypeColors.ContainsKey(shiftPlanShiftTypeColorComboBox.Text))
            {
                shiftPlanShiftTypeColorButton.BackColor = modelControl.currentWorkmonth.settings.shiftTypeColors[shiftPlanShiftTypeColorComboBox.Text];
            }
            else{
                MessageBox.Show("Schicht nicht im Verzeichnis gefunden.");
            }
        }

        /// <summary>
        /// handels the click event for the shiftPlanShiftTypeColorButton button
        /// sets the Color for the currentShiftType
        /// </summary>
        /// <param name="sender">the button control</param>
        /// <param name="e">event details</param>
        private void shiftPlanShiftTypeColorButton_Click(object sender, EventArgs e)
        {
            if(!Util.stringArrayContains(modelControl.getShiftTypesInWorkdays(modelControl.currentWorkmonth.workdays), shiftPlanShiftTypeColorComboBox.Text))
            {
                MessageBox.Show("Bitte erst Schicht Typ zum Farbe setzten auswählen.");
            }
            else
            {
                ColorDialog colorDialog = new ColorDialog();
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    shiftPlanShiftTypeColorButton.BackColor = colorDialog.Color;
                    modelControl.currentWorkmonth.settings.shiftTypeColors[shiftPlanShiftTypeColorComboBox.Text] = colorDialog.Color;
                    resetShiftPlanTab();
                }
            }
        }

        /// <summary>
        /// handels the click event for the createShiftPlan button
        /// creates the shiftPlan
        /// </summary>
        /// <param name="sender">the button control</param>
        /// <param name="e">event details</param>
        private void createShiftPlan_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Falls bereits ein Schichtplan erstellt wurde, wird dieser nun überschrieben.\n\n" +
                "Willst du fortfahren?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                modelControl.createShiftPlan(shiftPlanAlgorithmComboBox.SelectedIndex);
                resetShiftPlanTab();
                showShiftsNotSet();
                setShiftsNotSetLabel();
            }
        }

        /// <summary>
        /// handels the mouseEnter Event for the shiftPlanTable labels
        /// </summary>
        /// <param name="sender">the label, where the mouse entered</param>
        /// <param name="e">event details</param>
        private void shiftPlanLabel_MouseEnter(object sender, EventArgs e)
        {
            int row = shiftPlanTable.GetRow((Control)sender);
            if (shiftPlanRowToWorkshift.ContainsKey(row))
            {
                setTableControlColor(shiftPlanTable, row, hoverColor);
            }
        }

        /// <summary>
        /// handels the mouseLeave Event for the shiftPlanTable labels
        /// </summary>
        /// <param name="sender">the label, where the mouse left</param>
        /// <param name="e">event details</param>
        private void shiftPlanLabel_MouseLeave(object sender, EventArgs e)
        {
            Control control = sender as Control;
            int row = shiftPlanTable.GetRow(control);
            if (row != currentClickedRowShiftPlan)
            {
                resetTableControlColor(shiftPlanTable, shiftplanControlColors, row);
            }
        }

        /// <summary>
        /// handels the mouseClick Event for the shiftPlanTable labels
        /// sets the currentWorkshiftInShiftEdit to the clicked workshift
        /// </summary>
        /// <param name="sender">the label, which was clicked</param>
        /// <param name="e">event details</param>
        private void shiftPlanLabel_MouseUp(object sender, MouseEventArgs e)
        {
            int row = shiftPlanTable.GetRow((Control)sender);
            //set current workshift in edit
            if (shiftPlanRowToWorkshift.ContainsKey(row))
            {
                modelControl.setCurrentWorkshiftInShiftPlanEdit(shiftPlanRowToWorkshift[row]);

                setWorkshiftInShiftEdit(modelControl.currentWorkshiftInShiftPlanEdit);

                Workday workday = modelControl.getWorkdayFromWorkshiftInWorkdays(shiftPlanRowToWorkshift[row], modelControl.currentWorkmonth.workdays);

                if(workday != null)
                {
                    shiftPlanDayContent.Text = workday.weekday + ", " + workday.day + " " + modelControl.currentWorkmonth.monthName;
                }

                if (currentClickedRowShiftPlan != -1)
                {
                    resetTableControlColor(shiftPlanTable, shiftplanControlColors, currentClickedRowShiftPlan);
                }
                currentClickedRowShiftPlan = row;
            }
            else
            {
                MessageBox.Show("Nur Arbeitsschichten können in die Bearbeitung geladen werden.");
            }
        }

        /// <summary>
        /// handles the dragLeave event for a label of the shiftPlantable
        /// </summary>
        /// <param name="sender">label</param>
        /// <param name="e">event details</param>
        private void shiftPlanLabel_MouseDown(object sender, MouseEventArgs e)
        {
            // Start the drag operation when the mouse button is pressed
            Label label = sender as Label;
            if (e.Button == MouseButtons.Right)
            {
                int row = shiftPlanTable.GetRow((Control)sender);
                mouseDownRow = row;

                if (shiftPlanRowToWorkshift.ContainsKey(row))
                {
                    label.DoDragDrop(row, DragDropEffects.Copy);
                }
            }
        }

        /// <summary>
        /// handles the dragEnter event for a label of the shiftPlantable
        /// </summary>
        /// <param name="sender">label</param>
        /// <param name="e">event details</param>
        private void shiftPlanLabel_DragEnter(object sender, DragEventArgs e)
        {
            int row = shiftPlanTable.GetRow((Control)sender);
            // Check if the dragged data is of the expected type
            if (e.Data.GetDataPresent(typeof(int)) && row != mouseDownRow)
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// handles the dragEnter event for a label of the shiftPlantable
        /// </summary>
        /// <param name="sender">label</param>
        /// <param name="e">event details</param>
        private void shiftPlanLabel_DragDrop(object sender, DragEventArgs e)
        {
            int row = shiftPlanTable.GetRow((Control)sender);
            //set current workshift in edit
            if (shiftPlanRowToWorkshift.ContainsKey(row))
            {
                // Retrieve the dragged data and perform actions
                if (e.Data.GetDataPresent(typeof(int)))
                {
                    int draggedRow = (int)e.Data.GetData(typeof(int));
                    if (shiftPlanRowToWorkshift.ContainsKey(draggedRow))
                    {
                        if(currentClickedRowShiftPlan != -1)
                        {
                            resetTableControlColor(shiftPlanTable, shiftplanControlColors, currentClickedRowShiftPlan);
                            currentClickedRowShiftPlan = -1;
                        }

                        Workshift workshift1 = shiftPlanRowToWorkshift[row];
                        Workshift workshift2 = shiftPlanRowToWorkshift[draggedRow];

                        modelControl.swapPersonsInWorkshifts(workshift1, workshift2);

                        modelControl.setCurrentWorkshiftInShiftPlanEdit(null);

                        setWorkshiftInShiftEdit(modelControl.currentWorkshiftInShiftPlanEdit);
                        resetShiftPlanTab();
                    }
                }
            }
        }

        /// <summary>
        /// handels the click event for the shiftplanSaveChangesButton button
        /// saves the currentWorkshiftInShiftEdit with all the information in the textBoxes
        /// </summary>
        /// <param name="sender">the button control</param>
        /// <param name="e">event details</param>
        private void shiftplanSaveChangesButton_Click(object sender, EventArgs e)
        {
            if(modelControl.currentWorkshiftInShiftPlanEdit == null)
            {
                MessageBox.Show("Bitte erst Arbeitsschicht in die Bearbeitung laden.");
            }
            else
            {
                if(shiftPlanPersonComboBox.SelectedIndex != -1)
                {
                    string[] workshiftInfo = getWorkshiftInfoFromTextBoxes();
                    modelControl.editWorkshiftInWorkshiftEdit(modelControl.currentWorkmonth.persons[shiftPlanPersonComboBox.SelectedIndex], workshiftInfo);

                    resetShiftPlanTab();
                    setTableControlColor(shiftPlanTable, currentClickedRowShiftPlan, hoverColor);
                    setShiftEditPersonsComboBoxItems(modelControl.currentWorkshiftInShiftPlanEdit);
                }
                else
                {
                    MessageBox.Show("Bitte Person auswählen vor dem speichern.");
                }
            }
        }

        /// <summary>
        /// handels the click event for the shiftPlanDeleteShiftButton button
        /// deletes the currentWorkshiftInShiftEdit
        /// </summary>
        /// <param name="sender">the button control</param>
        /// <param name="e">event details</param>
        private void shiftPlanDeleteShiftButton_Click(object sender, EventArgs e)
        {
            if (modelControl.currentWorkshiftInShiftPlanEdit == null)
            {
                MessageBox.Show("Bitte erst Arbeitsschicht in die Bearbeitung laden.");
            }
            else
            {
                resetTableControlColor(shiftPlanTable, shiftplanControlColors, currentClickedRowShiftPlan);
                currentClickedRowShiftPlan = -1;

                modelControl.deleteCurrentWorkshiftInShiftEdit();
                shiftPlanPersonComboBox.Items.Clear();
                shiftPlanPersonComboBox.Text = "";

                shiftPlanDayContent.Text = "Wochentag, Tag Monat";

                shiftPlanShiftStartTextBox.Text = "";
                shiftPlanShiftEndTextBox.Text = "";
                shiftPlanShiftTypeTextBox.Text = "";
                shiftPlanDescriptionTextBox.Text = "";

                resetEverything();
            }
        }

        /// <summary>
        /// handels the click event for the shiftPlanAddShiftButton button
        /// adds a workshift in the current day
        /// </summary>
        /// <param name="sender">the button control</param>
        /// <param name="e">event details</param>
        private void shiftPlanAddShiftButton_Click(object sender, EventArgs e)
        {
            if (modelControl.currentWorkshiftInShiftPlanEdit == null)
            {
                MessageBox.Show("Bitte erst Arbeitsschicht in die Bearbeitung laden.");
            }
            else
            {
                resetTableControlColor(shiftPlanTable, shiftplanControlColors, currentClickedRowShiftPlan);
                currentClickedRowShiftPlan = -1;

                string[] workshiftInfo = getWorkshiftInfoFromTextBoxes();
                modelControl.addWorkshift(modelControl.currentWorkmonth.persons[shiftPlanPersonComboBox.SelectedIndex], workshiftInfo);

                modelControl.setCurrentWorkshiftInShiftPlanEdit(null);

                resetEverything();
                setWorkshiftInShiftEdit(modelControl.currentWorkshiftInShiftPlanEdit);
            }
        }

        /// <summary>
        /// handels the click event for the showShiftsNotSetButton button
        /// shows a messagebow with all the shifts, which are not set
        /// </summary>
        /// <param name="sender">the button control</param>
        /// <param name="e">event details</param>
        private void showShiftsNotSetButton_Click(object sender, EventArgs e)
        {
            showShiftsNotSet();
        }
    }
}

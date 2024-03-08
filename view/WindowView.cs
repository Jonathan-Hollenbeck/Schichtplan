using Schichtplan.controller;
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
        /// saves the current date
        /// </summary>
        private DateTime currentDate = new DateTime();

        /// <summary>
        /// modelControl object
        /// </summary>
        private ModelControl modelControl;

        /// <summary>
        /// shiftEdit object
        /// </summary>
        private ShiftEditControl shiftEditControl;

        /// <summary>
        /// personsControl object
        /// </summary>
        private PersonsControl personsControl;

        /// <summary>
        /// shiftPlanControl object
        /// </summary>
        private ShiftPlanControl shiftPlanControl;

        /// <summary>
        /// costsControl object
        /// </summary>
        private CostsControl costsControl;

        /// <summary>
        /// informationsControl object
        /// </summary>
        private MenuControl menuControl;

        /// <summary>
        /// sets a few colors to use
        /// </summary>
        public static Color
            hoverColor = Color.Blue,
            transparent = Color.Transparent,
            dayColor = Color.LightGray,
            dayFontColor = Color.Black,
            weekColor = Color.Black,
            weekFontColor = Color.White,
            mondayColor = Color.FromArgb(255, 252, 203, 193),
            tuesdayColor = Color.FromArgb(255, 252, 236, 193),
            wednesdayColor = Color.FromArgb(255, 212, 252, 193),
            thursdayColor = Color.FromArgb(255, 193, 252, 231),
            fridayColor = Color.FromArgb(255, 193, 232, 252),
            saturdayColor = Color.FromArgb(255, 200, 192, 255),
            sundayColor = Color.FromArgb(255, 254, 226, 255);

        public static float
            dayFontSize = 11.0f,
            weekFontSize = 11.0f;

        public static int
            dayLabelHeight = 30,
            weekLabelHeight = 30,
            tableLabelHeight = 28;

        /// <summary>
        /// constructor, which sets up the application
        /// </summary>
        public window()
        {
            currentDate = DateTime.Today;
            //set current Month to next month. Because planing the shifts for the current month is kinda over
            currentDate = currentDate.AddMonths(1);

            modelControl = new ModelControl();
            shiftEditControl = new ShiftEditControl(modelControl);
            personsControl = new PersonsControl(modelControl);
            shiftPlanControl = new ShiftPlanControl(modelControl);
            costsControl = new CostsControl(modelControl);
            menuControl = new MenuControl(modelControl);

            //create Folders for save files
            Serializer.Instance().createDir(Serializer.Instance().BASE_DICT + "" + Serializer.SAVE_FOLDER);
            Serializer.Instance().createDir(Serializer.Instance().BASE_DICT + "" + Serializer.CSV_FOLDER);
            Serializer.Instance().createDir(Serializer.Instance().BASE_DICT + "" + Serializer.ICS_FOLDER);
            Serializer.Instance().createDir(Serializer.Instance().BASE_DICT + "" + Serializer.HTML_FOLDER);

            InitializeComponent();


            //enter current year and month into textbox
            yearTextBox.Text = currentDate.Year.ToString();
            monthTextBox.Text = currentDate.Month.ToString();

            string filePath = Serializer.Instance().BASE_DICT + "" + Serializer.SAVE_FOLDER + "" + currentDate.Year + "_" + currentDate.Month + "-" + modelControl.getMonthNameFromMonthNumber(currentDate.Month) + ".save";

            //check if there is a file for the current month and year
            if (Serializer.Instance().fileExists(filePath))
            {
                //if yes load that file
                menuControl.open(filePath);
                resetEverything();
            }
            else
            {
                //select current year and month
                createYearMonth(yearTextBox.Text, monthTextBox.Text);
            }

            //give each label in the weekTemplateTable mousefunctions
            for(int row = 0; row < weekTemplateTable.RowCount; row++)
            {
                for(int col = 0; col < weekTemplateTable.ColumnCount; col++)
                {
                    Control control = weekTemplateTable.GetControlFromPosition(col, row);
                    control.MouseEnter += new EventHandler(this.weekTemplateTabelLabel_MouseEnter);
                    control.MouseLeave += new EventHandler(this.weekTemplateTabelLabel_MouseLeave);
                    control.Click += new EventHandler(this.weekTemplateTableLabel_Click);

                    weekTemplateControlColors.Add(control, getColorForWeekDay(modelControl.currentWorkmonth.weekTemplate[row].weekday));
                }
            }

            //select first item in shiftPlanAlgorithmCombobox
            shiftPlanAlgorithmComboBox.SelectedIndex = 0;
        }

        #region my Functions

        /// <summary>
        /// creates a new currentMonth with the year and month in the textfields
        /// </summary>
        private void createYearMonth(string yearString, string monthString)
        {
            int year = Util.parseInt(yearString, "Bitte nur Zahlen in dem Jahres Textfeld benutzen");
            int month = Util.parseInt(monthString, "Bitte nur Zahlen in dem Monats Textfeld benutzen.\n" +
                "Also Januar = 1, Februar = 2 usw.");
            modelControl.createYearMonth(year, month);
            resetEverything();
        }

        /// <summary>
        /// resets all frontends
        /// </summary>
        private void resetEverything()
        {
            resetShiftEditTab();
            resetPersonView();
            resetShiftPlanView();
            resetGeneralInfoView();
            resetCostsView();
        }

        /// <summary>
        /// gets a given color as a html rgb color string
        /// </summary>
        /// <param name="color">color to transform into html color string</param>
        /// <returns>transformed color into html color string</returns>
        public static string getHTMLColor(Color color)
        {
            return "rgb(" + color.R + "," + color.G + "," + color.B + ")";
        }

        /// <summary>
        /// resets the control color in a given table with the color stored in a dict <Control, Color> in a specific row
        /// </summary>
        /// <param name="table">table to search for the controls</param>
        /// <param name="controlColor">Control Color dict to get the color</param>
        /// <param name="row">row with the controls</param>
        private void resetTableControlColor(TableLayoutPanel table, Dictionary<Control, Color> controlColor, int row)
        {
            for (int i = 0; i < table.ColumnCount; i++)
            {
                Control control = table.GetControlFromPosition(i, row);
                if (control != null && controlColor.ContainsKey(control))
                {
                    Color color = controlColor[control];
                    control.BackColor = color;
                }
            }
        }

        /// <summary>
        /// resets the control color in a given table with the color stored in a dict <Control, Color> in a specific row
        /// </summary>
        /// <param name="table">table to search for the controls</param>
        /// <param name="controlColor">Control Color dict to get the color</param>
        /// <param name="row">row with the controls</param>
        private void setTableControlColor(TableLayoutPanel table, int row, Color color)
        {
            for (int i = 0; i < table.ColumnCount; i++)
            {
                Control control = table.GetControlFromPosition(i, row);
                if (control != null)
                {
                    control.BackColor = color;
                }
            }
        }

        /// <summary>
        /// gets the data in a given datagridview and returns its content in a 2 dimensional string array
        /// </summary>
        /// <param name="dataGridView">the datagridview to get the data from</param>
        /// <returns>the data in the given datagridview as a 2D string array</returns>
        private string[,] getDataFromDataGridViewAsStringArray(DataGridView dataGridView)
        {
            //check if there is an entry in every cell and puts the data from the datagridview into the 2d array
            string[,] data = new string[dataGridView.RowCount - 1, dataGridView.ColumnCount];
            for (int r = 0; r < dataGridView.Rows.Count - 1; r++)
            {
                for (int c = 0; c < dataGridView.Rows[r].Cells.Count; c++)
                {
                    string value = (string)dataGridView.Rows[r].Cells[c].Value;
                    if (value == null)
                    {
                        MessageBox.Show("Bitte in jede Zelle etwas eintragen.");
                        return null;
                    }
                    else
                    {
                        data[r, c] = value;
                    }
                }
            }

            return data;
        }

        /// <summary>
        /// creates a Label for a Table
        /// </summary>
        /// <param name="width">label width</param>
        /// <param name="height">label height</param>
        /// <param name="controlColor">dictionary, the label and color are added to</param>
        /// <param name="backColor">label backgtround color</param>
        /// <param name="Text">label text</param>
        /// <returns></returns>
        private Label createTableLabel(Dictionary<Control, Color> controlColor, int width, int height, string Text, Color backColor)
        {
            Label label = new Label();
            label.Text = Text;
            label.Margin = new Padding(0);
            label.Size = new Size(width, height);
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.BackColor = backColor;
            if(controlColor != null)
            {
                controlColor.Add(label, backColor);
            }
            return label;
        }

        /// <summary>
        /// creates a OpenFileDialog with an initial directory
        /// </summary>
        /// <returns>OpenFileDialog</returns>
        private OpenFileDialog createOpenFileDialog(string initialDirectory)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = initialDirectory;
            openFileDialog.Title = "Bitte gewuenschte Speicherdatei auswaehlen.";
            openFileDialog.DefaultExt = "save";
            openFileDialog.Filter = "save files (*.save)|*.save|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 0;
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            return openFileDialog;
        }

        #endregion

        #region generated Functions

        /// <summary>
        /// event when the window is closing. Asks if the user wants to save the current Month
        /// </summary>
        /// <param name="sender">the window</param>
        /// <param name="e">event details</param>
        private void window_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Willst du noch vor dem Schließen speichern?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                menuControl.save();
            }
        }

        /// <summary>
        /// handels the click event for the selectCreateYearMonthButton button
        /// calls the createYearMonth() function
        /// </summary>
        /// <param name="sender">the button control</param>
        /// <param name="e">event details</param>
        private void selectCreateYearMonthButton_Click(object sender, EventArgs e)
        {
            createYearMonth(yearTextBox.Text, monthTextBox.Text);
        }

        /// <summary>
        /// sets the text of the monthTextBox to the month of the currentDate, if it was left empty
        /// </summary>
        /// <param name="sender">monthTextBox</param>
        /// <param name="e">event details</param>
        private void monthTextBox_Leave(object sender, EventArgs e)
        {
            if (monthTextBox.Text.Length == 0)
            {
                monthTextBox.Text = currentDate.Month.ToString();
            }
        }

        /// <summary>
        /// sets the text of the yearTextBox to the month of the currentDate, if it was left empty
        /// </summary>
        /// <param name="sender">yearTextBox</param>
        /// <param name="e">event details</param>
        private void yearTextBox_Leave(object sender, EventArgs e)
        {
            if (yearTextBox.Text.Length == 0)
            {
                yearTextBox.Text = currentDate.Year.ToString();
            }
        }

        /// <summary>
        /// gets the color for each weekday by weekdayname
        /// </summary>
        /// <param name="weekday">the weekdayname</param>
        /// <returns>the color for the given weekdayname</returns>
        private Color getColorForWeekDay(string weekday)
        {
            if (weekday == "Montag")
            {
                return mondayColor;
            }
            else if (weekday == "Dienstag")
            {
                return tuesdayColor;
            }
            else if (weekday == "Mittwoch")
            {
                return wednesdayColor;
            }
            else if (weekday == "Donnerstag")
            {
                return thursdayColor;
            }
            else if (weekday == "Freitag")
            {
                return fridayColor;
            }
            else if (weekday == "Samstag")
            {
                return saturdayColor;
            }
            else if (weekday == "Sonntag")
            {
                return sundayColor;
            }
            return Color.White;
        }

        #region Control size changed

        /// <summary>
        /// sets up the actions to take, when the shiftPlanTabPage is resized
        /// </summary>
        /// <param name="sender">shiftPlanTabPage</param>
        /// <param name="e">event details</param>
        private void shiftPlanTabPage_SizeChanged(object sender, EventArgs e)
        {
            shiftPlanTable.Visible = false;
            shiftPlanTable.SuspendLayout();
            shiftPlanTable.MaximumSize = new Size(0, shiftPlanTabPage.Height - 80);
            shiftPlanTable.ResumeLayout();
            shiftPlanTable.Visible = true;
        }

        /// <summary>
        /// sets up the actions to take, when the shiftTabPage is resized
        /// </summary>
        /// <param name="sender">shiftTabPage</param>
        /// <param name="e">event details</param>
        private void shiftTabPage_SizeChanged(object sender, EventArgs e)
        {
            monthViewPanel.Size = new Size((infoSettingsTabPage.Width / 2) - 15, infoSettingsTabPage.Height);
            monthViewTable.MaximumSize = new Size(monthViewPanel.Width, monthViewPanel.Height - 60);

            weekTemplateShiftEditPanel.Size = new Size(infoSettingsTabPage.Width / 2, infoSettingsTabPage.Height);
            shiftEditPanel.Size = new Size(weekTemplateShiftEditPanel.Width, weekTemplateShiftEditPanel.Height - weekTemplatePanel.Height);
            shiftEditDataGridView.Size = new Size(shiftEditPanel.Width - 10, shiftEditPanel.Height - 40);

            resetShiftEditTab();
        }

        /// <summary>
        /// sets up the actions to take, when the personsTabPage is resized
        /// </summary>
        /// <param name="sender">personsTabPage</param>
        /// <param name="e">event details</param>
        private void personsTabPage_SizeChanged(object sender, EventArgs e)
        {
            personContentPanel.Size = new Size(infoSettingsTabPage.Width, infoSettingsTabPage.Height);
            personTable.Size = new Size(personContentPanel.Width / 2, personShiftSelectPanel.Height - personDataPanel.Height - 33);
            personTable.MaximumSize = new Size(personContentPanel.Width / 2, personShiftSelectPanel.Height - personDataPanel.Height - 33);

            personShiftSelectPanel.Size = new Size((infoSettingsTabPage.Width / 2) - 15, infoSettingsTabPage.Height);
            personUnavailableshiftSelectDataGridView.Size = new Size(personShiftSelectPanel.Width - 20, personShiftSelectPanel.Height - personDataPanel.Height - 65);

            personLoadFromDifferentMonthButton.Location = new Point(personContentPanel.Width - personLoadFromDifferentMonthButton.Width - 5, personLoadFromDifferentMonthButton.Location.Y);

            resetPersonView();
        }

        /// <summary>
        /// sets up the actions to take, when the infoGeneralTabPage is resized
        /// </summary>
        /// <param name="sender">infoGeneralTabPage</param>
        /// <param name="e">event details</param>
        private void infoGeneralTabPage_SizeChanged(object sender, EventArgs e)
        {
            infoGeneralMonthPanel.Size = new Size(infoGeneralTabPage.Width / 3, infoGeneralTabPage.Height);
            infoGeneralWeekPanel.Size = new Size(infoGeneralTabPage.Width / 3, infoGeneralTabPage.Height);
            infoGeneralDayPanel.Size = new Size(infoGeneralTabPage.Width / 3, infoGeneralTabPage.Height);
        }

        /// <summary>
        /// sets up the actions to take, when the infoPersonTabPage is resized
        /// </summary>
        /// <param name="sender">infoPersonTabPage</param>
        /// <param name="e">event details</param>
        private void infoPersonTabPage_SizeChanged(object sender, EventArgs e)
        {
            infoPersonTable.Visible = false;
            infoPersonTable.SuspendLayout();
            infoPersonTable.Size = new Size(personContentPanel.Width / 2, personContentPanel.Height);

            setInfoPersonTable();
            infoPersonTable.ResumeLayout();
            infoPersonTable.Visible = true;
        }

        /// <summary>
        /// sets up the actions to take, when the costsTabPage is resized
        /// </summary>
        /// <param name="sender">infoPersonTabPage</param>
        /// <param name="e">event details</param>
        private void costsTabPage_Resize(object sender, EventArgs e)
        {
            fixCostsPanel.Size = new Size((costsTabPage.Width / 2) - 10, costsTabPage.Height);
            variableCostsPanel.Size = new Size((costsTabPage.Width / 2) - 10, costsTabPage.Height);

            fixCostsDataGridView.Size = new Size(fixCostsPanel.Width, fixCostsPanel.Height - 35);
            variableCostsDataGridView.Size = new Size(fixCostsPanel.Width, fixCostsPanel.Height - 35);
        }

        #endregion

        #endregion
    }
}

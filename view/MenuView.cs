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
        /// calls save() function in the manager
        /// </summary>
        /// <param name="sender">saveToolStripMenuItem</param>
        /// <param name="e">event details</param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuControl.save();
        }

        /// <summary>
        /// calls open() function in the manager with a selected filename from a OpenFileDialog
        /// </summary>
        /// <param name="sender">saveToolStripMenuItem</param>
        /// <param name="e">event details</param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = createOpenFileDialog(Serializer.Instance().BASE_DICT + "" + Serializer.SAVE_DIRECTORY);

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                menuControl.open(openFileDialog.FileName);
                resetEverything();

                yearTextBox.Text = modelControl.currentWorkmonth.year + "";
                monthTextBox.Text = modelControl.currentWorkmonth.month + "";
            }
        }

        /// <summary>
        /// calls exportCSVFiles() function in the manager
        /// </summary>
        /// <param name="sender">exportAsCSVToolStripMenuItem</param>
        /// <param name="e">event details</param>
        private void exportAsCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuControl.exportCSVFiles();
        }

        /// <summary>
        /// calls exportCalenderFiles() function in the manager
        /// </summary>
        /// <param name="sender">kalenderDateienExportierenToolStripMenuItem</param>
        /// <param name="e">event details</param>
        private void kalenderDateienExportierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuControl.exportCalenderFiles();
        }

        /// <summary>
        /// calls exportHTMLFiles() function in the manager
        /// </summary>
        /// <param name="sender">hTMLDateienExportierenToolStripMenuItem</param>
        /// <param name="e">event details</param>
        private void hTMLDateienExportierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuControl.exportHTMLFiles();
        }

        private void googleTabelleExportierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form googleSettingsForm = new Form();
            googleSettingsForm.Size = new Size(300, 200);
            googleSettingsForm.Text = "Google API Settings";

            TextBox spreadSheetIdTextBox = new TextBox();
            spreadSheetIdTextBox.Location = new Point(10, 10);
            spreadSheetIdTextBox.Size = new Size(270, 30);
            spreadSheetIdTextBox.Text = modelControl.currentWorkmonth.settings.googleSheetsId;

            TextBox keyPathTextBox = new TextBox();
            keyPathTextBox.Location = new Point(10, 50);
            keyPathTextBox.Size = new Size(270, 30);
            keyPathTextBox.Text = modelControl.currentWorkmonth.settings.googleKeyPath;

            Button selectKeyPathButton = new Button();
            selectKeyPathButton.Location = new Point(10, 70);
            selectKeyPathButton.Size = new Size(270, 30);
            selectKeyPathButton.Text = "Google API Schlüssel wählen";
            selectKeyPathButton.Click += (s, ev) =>
            {
                OpenFileDialog openFileDialog = createOpenFileDialog(Serializer.Instance().BASE_DICT);

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    modelControl.currentWorkmonth.settings.googleKeyPath = openFileDialog.FileName;
                    keyPathTextBox.Text = modelControl.currentWorkmonth.settings.googleKeyPath;
                }
            };

            Button uploadToGoogleSheetsButton = new Button();
            uploadToGoogleSheetsButton.Location = new Point(10, 120);
            uploadToGoogleSheetsButton.Size = new Size(270, 30);
            uploadToGoogleSheetsButton.Text = "hochladen";
            uploadToGoogleSheetsButton.Click += (s, ev) =>
            {
                modelControl.currentWorkmonth.settings.googleSheetsId = spreadSheetIdTextBox.Text;

                menuControl.uploadToGoogleTableAsync(
                    modelControl.currentWorkmonth.settings.googleSheetsId,
                    modelControl.currentWorkmonth.settings.googleKeyPath
                    );
            };

            googleSettingsForm.Controls.Add(spreadSheetIdTextBox);
            googleSettingsForm.Controls.Add(keyPathTextBox);
            googleSettingsForm.Controls.Add(selectKeyPathButton);
            googleSettingsForm.Controls.Add(uploadToGoogleSheetsButton);
            googleSettingsForm.ShowDialog();
        }

        #region persons sort menu items

        /// <summary>
        /// sets the personTableSort variable to name and reloads the personTable
        /// </summary>
        /// <param name="sender">the clicked menu item</param>
        /// <param name="e">event details</param>
        private void namenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sortPersons("name");
        }

        /// <summary>
        /// sets the personTableSort variable to saleryPerHour and reloads the personTable
        /// </summary>
        /// <param name="sender">the clicked menu item</param>
        /// <param name="e">event details</param>
        private void gehaltProStundeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sortPersons("saleryPerHour");
        }

        /// <summary>
        /// sets the personTableSort variable to minWorkHours and reloads the personTable
        /// </summary>
        /// <param name="sender">the clicked menu item</param>
        /// <param name="e">event details</param>
        private void minArbeitsstundenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sortPersons("minWorkHours");
        }

        /// <summary>
        /// sets the personTableSort variable to maxWorkHours and reloads the personTable
        /// </summary>
        /// <param name="sender">the clicked menu item</param>
        /// <param name="e">event details</param>
        private void maxArbeitsstundenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sortPersons("maxWorkHours");
        }

        /// <summary>
        /// sets the personTableSort variable to shiftType and reloads the personTable
        /// </summary>
        /// <param name="sender">the clicked menu item</param>
        /// <param name="e">event details</param>
        private void schichtTypenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sortPersons("shiftTypes");
        }

        /// <summary>
        /// sets the personTableSort variable to description and reloads the personTable
        /// </summary>
        /// <param name="sender">the clicked menu item</param>
        /// <param name="e">event details</param>
        private void anmerkungenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sortPersons("description");
        }

        #endregion
    }
}

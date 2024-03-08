using System;

namespace Schichtplan
{
    partial class window
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(window));
            this.yearMonthSelectorPanel = new System.Windows.Forms.Panel();
            this.createYearMonthButton = new System.Windows.Forms.Button();
            this.monthTextBox = new System.Windows.Forms.TextBox();
            this.yearTextBox = new System.Windows.Forms.TextBox();
            this.monthLabel = new System.Windows.Forms.Label();
            this.yearLabel = new System.Windows.Forms.Label();
            this.infoSettingsTabPage = new System.Windows.Forms.TabControl();
            this.shiftTabPage = new System.Windows.Forms.TabPage();
            this.weekTemplateShiftEditPanel = new System.Windows.Forms.Panel();
            this.shiftEditPanel = new System.Windows.Forms.Panel();
            this.shiftEditDataGridView = new System.Windows.Forms.DataGridView();
            this.shiftEditStartColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shiftEditEndColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shiftEditTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shiftEditDescriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveCurrentShift = new System.Windows.Forms.Button();
            this.shiftEditLabel = new System.Windows.Forms.Label();
            this.weekTemplatePanel = new System.Windows.Forms.Panel();
            this.loadFromOtherMonthButton = new System.Windows.Forms.Button();
            this.weekTemplateTable = new System.Windows.Forms.TableLayoutPanel();
            this.weekTemplateWednesdayLabel = new System.Windows.Forms.Label();
            this.weekTemplateThursdayLabel = new System.Windows.Forms.Label();
            this.weekTemplateFridayLabel = new System.Windows.Forms.Label();
            this.weekTemplateSaturdayLabel = new System.Windows.Forms.Label();
            this.weekTemplateSundayLabel = new System.Windows.Forms.Label();
            this.weekTemplateMondayLabel = new System.Windows.Forms.Label();
            this.weekTemplateMondayContentLabel = new System.Windows.Forms.Label();
            this.weekTemplateWednesdayContentLabel = new System.Windows.Forms.Label();
            this.weekTemplateThursdayContentLabel = new System.Windows.Forms.Label();
            this.weekTemplateFridayContentLabel = new System.Windows.Forms.Label();
            this.weekTemplateSaturdayContentLabel = new System.Windows.Forms.Label();
            this.weekTemplateSundayContentLabel = new System.Windows.Forms.Label();
            this.weekTemplateTuesdayContentLabel = new System.Windows.Forms.Label();
            this.weekTemplateTuesdayLabel = new System.Windows.Forms.Label();
            this.useOnHoleMonth = new System.Windows.Forms.Button();
            this.weekTemplateLabel = new System.Windows.Forms.Label();
            this.monthViewPanel = new System.Windows.Forms.Panel();
            this.monthViewTable = new System.Windows.Forms.TableLayoutPanel();
            this.monthViewLabel = new System.Windows.Forms.Label();
            this.personsTabPage = new System.Windows.Forms.TabPage();
            this.personContentPanel = new System.Windows.Forms.Panel();
            this.personShiftSelectPanel = new System.Windows.Forms.Panel();
            this.personResetAllUnavailabilitiesButton = new System.Windows.Forms.Button();
            this.personSetAllUnavailabilitiesCheckBox = new System.Windows.Forms.CheckBox();
            this.personSetDaysUnavailableButton = new System.Windows.Forms.Button();
            this.personSetDaysUnavailableTextBox = new System.Windows.Forms.TextBox();
            this.personUnavailableshiftSelectDataGridView = new System.Windows.Forms.DataGridView();
            this.personShiftColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personShiftSelectColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.personOnlyShiftSelectColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.personTable = new System.Windows.Forms.TableLayoutPanel();
            this.personDataPanel = new System.Windows.Forms.Panel();
            this.personColorLabel = new System.Windows.Forms.Label();
            this.personColorButton = new System.Windows.Forms.Button();
            this.personCarryOverLabel = new System.Windows.Forms.Label();
            this.personCarryOverTextBox = new System.Windows.Forms.TextBox();
            this.personLoadFromDifferentMonthButton = new System.Windows.Forms.Button();
            this.personSaveEditButton = new System.Windows.Forms.Button();
            this.personDeleteButton = new System.Windows.Forms.Button();
            this.personAddButton = new System.Windows.Forms.Button();
            this.personDescriptionLabel = new System.Windows.Forms.Label();
            this.personShifttypesLabel = new System.Windows.Forms.Label();
            this.personMaxWorkHoursLabel = new System.Windows.Forms.Label();
            this.personMinWorkHoursLabel = new System.Windows.Forms.Label();
            this.personSalaryLabel = new System.Windows.Forms.Label();
            this.personShifttypesTextBox = new System.Windows.Forms.TextBox();
            this.personDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.personMaxWorkHoursTextBox = new System.Windows.Forms.TextBox();
            this.personMinWorkHoursTextBox = new System.Windows.Forms.TextBox();
            this.personSaleryTextBox = new System.Windows.Forms.TextBox();
            this.personNameTextBox = new System.Windows.Forms.TextBox();
            this.personNameLabel = new System.Windows.Forms.Label();
            this.shiftPlanTabPage = new System.Windows.Forms.TabPage();
            this.shiftPlanFilterPanel = new System.Windows.Forms.Panel();
            this.shiftPlanPersonsWithOutOfBoudsWorkhoursButton = new System.Windows.Forms.Button();
            this.shiftPlanPersonsWithOutOfBoudsWorkhoursLabel = new System.Windows.Forms.Label();
            this.shiftPlanShowShiftsNotSetButton = new System.Windows.Forms.Button();
            this.shiftPlanShiftsNotSetLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.shiftPlanShiftTypeColorButton = new System.Windows.Forms.Button();
            this.shiftPlanShiftTypeColorComboBox = new System.Windows.Forms.ComboBox();
            this.shiftPlanAlgorithmComboBox = new System.Windows.Forms.ComboBox();
            this.shiftPlanAddShiftButton = new System.Windows.Forms.Button();
            this.shiftPlanDayContent = new System.Windows.Forms.Label();
            this.shiftPlanDayLabel = new System.Windows.Forms.Label();
            this.shiftPlanShiftTypeLabel = new System.Windows.Forms.Label();
            this.shiftPlanShiftEndLabel = new System.Windows.Forms.Label();
            this.shiftPlanShiftStartLabel = new System.Windows.Forms.Label();
            this.shiftPlanShiftTypeTextBox = new System.Windows.Forms.TextBox();
            this.shiftPlanShiftEndTextBox = new System.Windows.Forms.TextBox();
            this.shiftPlanShiftStartTextBox = new System.Windows.Forms.TextBox();
            this.shiftPlanDeleteShiftButton = new System.Windows.Forms.Button();
            this.shiftPlanDescriptionLabel = new System.Windows.Forms.Label();
            this.shiftPlanPersonNameLabel = new System.Windows.Forms.Label();
            this.shiftPlanDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.shiftPlanPersonComboBox = new System.Windows.Forms.ComboBox();
            this.shiftplanSaveChangesButton = new System.Windows.Forms.Button();
            this.createShiftPlan = new System.Windows.Forms.Button();
            this.shiftPlanTable = new System.Windows.Forms.TableLayoutPanel();
            this.costsTabPage = new System.Windows.Forms.TabPage();
            this.variableCostsPanel = new System.Windows.Forms.Panel();
            this.variableCostsLabelButtonPanel = new System.Windows.Forms.Panel();
            this.variableCostsSaveButton = new System.Windows.Forms.Button();
            this.variableCostsLabel = new System.Windows.Forms.Label();
            this.variableCostsDataGridView = new System.Windows.Forms.DataGridView();
            this.variableCostsPaydayColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.variableCostsTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.variableCostsDescriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.variableCostsAmountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fixCostsPanel = new System.Windows.Forms.Panel();
            this.fixCostsLabelButtonPanel = new System.Windows.Forms.Panel();
            this.fixCostsLoadFromOtherMonthButton = new System.Windows.Forms.Button();
            this.fixCostsSaveButton = new System.Windows.Forms.Button();
            this.fixCostsLabel = new System.Windows.Forms.Label();
            this.fixCostsDataGridView = new System.Windows.Forms.DataGridView();
            this.fixCostsPaydayColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fixCostsTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fixCostsDescriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fixCostsAmountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.infoPersonTabPage = new System.Windows.Forms.TabPage();
            this.infoPersonTable = new System.Windows.Forms.TableLayoutPanel();
            this.infoGeneralTabPage = new System.Windows.Forms.TabPage();
            this.infoGeneralWeekPanel = new System.Windows.Forms.Panel();
            this.infoWeekComboBox = new System.Windows.Forms.ComboBox();
            this.infoWeekAverageTurnoverDayContent = new System.Windows.Forms.Label();
            this.infoWeekAverageTurnoverHourContent = new System.Windows.Forms.Label();
            this.infoWeekTurnoverAfterSaleriesContent = new System.Windows.Forms.Label();
            this.infoWeekHoursSumContent = new System.Windows.Forms.Label();
            this.infoWeekShiftSumContent = new System.Windows.Forms.Label();
            this.infoWeekAverageTurnoverDayLabel = new System.Windows.Forms.Label();
            this.infoWeekTurnoverAfterSaleriesLabel = new System.Windows.Forms.Label();
            this.infoWeekAverageTurnoverHourLabel = new System.Windows.Forms.Label();
            this.infoWeekCalculateButton = new System.Windows.Forms.Button();
            this.infoWeekTurnover = new System.Windows.Forms.Label();
            this.infoWeekTurnoverTextBox = new System.Windows.Forms.TextBox();
            this.infoWeekHoursSumLabel = new System.Windows.Forms.Label();
            this.infoWeekShiftSumLabel = new System.Windows.Forms.Label();
            this.infoWeekSalerySumLabel = new System.Windows.Forms.Label();
            this.infoWeekSalerySumContent = new System.Windows.Forms.Label();
            this.infoWeekLabel = new System.Windows.Forms.Label();
            this.infoGeneralDayPanel = new System.Windows.Forms.Panel();
            this.infoDayComboBox = new System.Windows.Forms.ComboBox();
            this.infoDayAverageTurnoverHourContent = new System.Windows.Forms.Label();
            this.infoDayTurnoverAfterSaleriesContent = new System.Windows.Forms.Label();
            this.infoDayHoursSumContent = new System.Windows.Forms.Label();
            this.infoDayShiftSumContent = new System.Windows.Forms.Label();
            this.infoDayTurnoverAfterSaleriesLabel = new System.Windows.Forms.Label();
            this.infoDayAverageTurnoverHourLabel = new System.Windows.Forms.Label();
            this.infoDayCalculateButton = new System.Windows.Forms.Button();
            this.infoDayTurnover = new System.Windows.Forms.Label();
            this.infoDayTurnoverTextBox = new System.Windows.Forms.TextBox();
            this.infoDayHoursSumLabel = new System.Windows.Forms.Label();
            this.infoDayShiftSumLabel = new System.Windows.Forms.Label();
            this.infoDaySalerySumLabel = new System.Windows.Forms.Label();
            this.infoDaySalerySumContent = new System.Windows.Forms.Label();
            this.infoDayLabel = new System.Windows.Forms.Label();
            this.infoGeneralMonthPanel = new System.Windows.Forms.Panel();
            this.infoMonthCostsSumContent = new System.Windows.Forms.Label();
            this.infoMonthVariableCostsSumContent = new System.Windows.Forms.Label();
            this.infoMonthFixCostsSumContent = new System.Windows.Forms.Label();
            this.infoMonthCostsSumLabel = new System.Windows.Forms.Label();
            this.infoMonthVariableCostsSumLabel = new System.Windows.Forms.Label();
            this.infoMonthFixCostsSumLabel = new System.Windows.Forms.Label();
            this.infoMonthAverageTurnoverDayContent = new System.Windows.Forms.Label();
            this.infoMonthAverageTurnoverHourContent = new System.Windows.Forms.Label();
            this.infoMonthProfitAfterSaleriesCostsContent = new System.Windows.Forms.Label();
            this.infoMonthHoursSumContent = new System.Windows.Forms.Label();
            this.infoMonthShiftSumContent = new System.Windows.Forms.Label();
            this.infoMonthAverageTurnoverDayLabel = new System.Windows.Forms.Label();
            this.infoMonthProfitAfterSaleriesCostsLabel = new System.Windows.Forms.Label();
            this.infoMonthAverageTurnoverHourLabel = new System.Windows.Forms.Label();
            this.infoMonthCalculateButton = new System.Windows.Forms.Button();
            this.infoMonthTurnover = new System.Windows.Forms.Label();
            this.infoMonthTurnoverTextBox = new System.Windows.Forms.TextBox();
            this.infoMonthHoursSumLabel = new System.Windows.Forms.Label();
            this.infoMonthShiftSumLabel = new System.Windows.Forms.Label();
            this.infoMonthLabel = new System.Windows.Forms.Label();
            this.infoMonthSalerySumLabel = new System.Windows.Forms.Label();
            this.infoMonthSalerySumContent = new System.Windows.Forms.Label();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kalenderDateienExportierenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAsCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hTMLDateienExportierenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personenSortierenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.namenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gehaltProStundeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minArbeitsstundenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maxArbeitsstundenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schichtTypenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anmerkungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yearMonthSelectorPanel.SuspendLayout();
            this.infoSettingsTabPage.SuspendLayout();
            this.shiftTabPage.SuspendLayout();
            this.weekTemplateShiftEditPanel.SuspendLayout();
            this.shiftEditPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shiftEditDataGridView)).BeginInit();
            this.weekTemplatePanel.SuspendLayout();
            this.weekTemplateTable.SuspendLayout();
            this.monthViewPanel.SuspendLayout();
            this.personsTabPage.SuspendLayout();
            this.personContentPanel.SuspendLayout();
            this.personShiftSelectPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.personUnavailableshiftSelectDataGridView)).BeginInit();
            this.personDataPanel.SuspendLayout();
            this.shiftPlanTabPage.SuspendLayout();
            this.shiftPlanFilterPanel.SuspendLayout();
            this.costsTabPage.SuspendLayout();
            this.variableCostsPanel.SuspendLayout();
            this.variableCostsLabelButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.variableCostsDataGridView)).BeginInit();
            this.fixCostsPanel.SuspendLayout();
            this.fixCostsLabelButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fixCostsDataGridView)).BeginInit();
            this.infoPersonTabPage.SuspendLayout();
            this.infoGeneralTabPage.SuspendLayout();
            this.infoGeneralWeekPanel.SuspendLayout();
            this.infoGeneralDayPanel.SuspendLayout();
            this.infoGeneralMonthPanel.SuspendLayout();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // yearMonthSelectorPanel
            // 
            this.yearMonthSelectorPanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.yearMonthSelectorPanel.Controls.Add(this.createYearMonthButton);
            this.yearMonthSelectorPanel.Controls.Add(this.monthTextBox);
            this.yearMonthSelectorPanel.Controls.Add(this.yearTextBox);
            this.yearMonthSelectorPanel.Controls.Add(this.monthLabel);
            this.yearMonthSelectorPanel.Controls.Add(this.yearLabel);
            this.yearMonthSelectorPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.yearMonthSelectorPanel.Location = new System.Drawing.Point(0, 24);
            this.yearMonthSelectorPanel.MaximumSize = new System.Drawing.Size(0, 42);
            this.yearMonthSelectorPanel.Name = "yearMonthSelectorPanel";
            this.yearMonthSelectorPanel.Size = new System.Drawing.Size(1246, 42);
            this.yearMonthSelectorPanel.TabIndex = 0;
            // 
            // createYearMonthButton
            // 
            this.createYearMonthButton.Location = new System.Drawing.Point(280, 13);
            this.createYearMonthButton.Name = "createYearMonthButton";
            this.createYearMonthButton.Size = new System.Drawing.Size(63, 23);
            this.createYearMonthButton.TabIndex = 4;
            this.createYearMonthButton.Text = "erstellen";
            this.createYearMonthButton.UseVisualStyleBackColor = true;
            this.createYearMonthButton.Click += new System.EventHandler(this.selectCreateYearMonthButton_Click);
            // 
            // monthTextBox
            // 
            this.monthTextBox.Location = new System.Drawing.Point(182, 13);
            this.monthTextBox.Name = "monthTextBox";
            this.monthTextBox.Size = new System.Drawing.Size(80, 20);
            this.monthTextBox.TabIndex = 3;
            this.monthTextBox.Text = "1";
            this.monthTextBox.Leave += new System.EventHandler(this.monthTextBox_Leave);
            // 
            // yearTextBox
            // 
            this.yearTextBox.Location = new System.Drawing.Point(55, 13);
            this.yearTextBox.Name = "yearTextBox";
            this.yearTextBox.Size = new System.Drawing.Size(80, 20);
            this.yearTextBox.TabIndex = 2;
            this.yearTextBox.Text = "2024";
            this.yearTextBox.Leave += new System.EventHandler(this.yearTextBox_Leave);
            // 
            // monthLabel
            // 
            this.monthLabel.AutoSize = true;
            this.monthLabel.Location = new System.Drawing.Point(141, 13);
            this.monthLabel.Name = "monthLabel";
            this.monthLabel.Size = new System.Drawing.Size(37, 13);
            this.monthLabel.TabIndex = 1;
            this.monthLabel.Text = "Monat";
            // 
            // yearLabel
            // 
            this.yearLabel.AutoSize = true;
            this.yearLabel.Location = new System.Drawing.Point(13, 13);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(27, 13);
            this.yearLabel.TabIndex = 0;
            this.yearLabel.Text = "Jahr";
            // 
            // infoSettingsTabPage
            // 
            this.infoSettingsTabPage.Controls.Add(this.shiftTabPage);
            this.infoSettingsTabPage.Controls.Add(this.personsTabPage);
            this.infoSettingsTabPage.Controls.Add(this.shiftPlanTabPage);
            this.infoSettingsTabPage.Controls.Add(this.costsTabPage);
            this.infoSettingsTabPage.Controls.Add(this.infoPersonTabPage);
            this.infoSettingsTabPage.Controls.Add(this.infoGeneralTabPage);
            this.infoSettingsTabPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoSettingsTabPage.Location = new System.Drawing.Point(0, 66);
            this.infoSettingsTabPage.Name = "infoSettingsTabPage";
            this.infoSettingsTabPage.SelectedIndex = 0;
            this.infoSettingsTabPage.Size = new System.Drawing.Size(1246, 557);
            this.infoSettingsTabPage.TabIndex = 1;
            // 
            // shiftTabPage
            // 
            this.shiftTabPage.Controls.Add(this.weekTemplateShiftEditPanel);
            this.shiftTabPage.Controls.Add(this.monthViewPanel);
            this.shiftTabPage.Location = new System.Drawing.Point(4, 22);
            this.shiftTabPage.Name = "shiftTabPage";
            this.shiftTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.shiftTabPage.Size = new System.Drawing.Size(1238, 531);
            this.shiftTabPage.TabIndex = 0;
            this.shiftTabPage.Text = "Schichten";
            this.shiftTabPage.UseVisualStyleBackColor = true;
            this.shiftTabPage.SizeChanged += new System.EventHandler(this.shiftTabPage_SizeChanged);
            // 
            // weekTemplateShiftEditPanel
            // 
            this.weekTemplateShiftEditPanel.Controls.Add(this.shiftEditPanel);
            this.weekTemplateShiftEditPanel.Controls.Add(this.weekTemplatePanel);
            this.weekTemplateShiftEditPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.weekTemplateShiftEditPanel.Location = new System.Drawing.Point(648, 3);
            this.weekTemplateShiftEditPanel.Name = "weekTemplateShiftEditPanel";
            this.weekTemplateShiftEditPanel.Size = new System.Drawing.Size(587, 525);
            this.weekTemplateShiftEditPanel.TabIndex = 2;
            // 
            // shiftEditPanel
            // 
            this.shiftEditPanel.BackColor = System.Drawing.Color.Transparent;
            this.shiftEditPanel.Controls.Add(this.shiftEditDataGridView);
            this.shiftEditPanel.Controls.Add(this.saveCurrentShift);
            this.shiftEditPanel.Controls.Add(this.shiftEditLabel);
            this.shiftEditPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.shiftEditPanel.Location = new System.Drawing.Point(0, 260);
            this.shiftEditPanel.Name = "shiftEditPanel";
            this.shiftEditPanel.Size = new System.Drawing.Size(587, 265);
            this.shiftEditPanel.TabIndex = 1;
            // 
            // shiftEditDataGridView
            // 
            this.shiftEditDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.shiftEditDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.shiftEditStartColumn,
            this.shiftEditEndColumn,
            this.shiftEditTypeColumn,
            this.shiftEditDescriptionColumn});
            this.shiftEditDataGridView.Location = new System.Drawing.Point(9, 33);
            this.shiftEditDataGridView.Name = "shiftEditDataGridView";
            this.shiftEditDataGridView.Size = new System.Drawing.Size(572, 227);
            this.shiftEditDataGridView.TabIndex = 4;
            // 
            // shiftEditStartColumn
            // 
            this.shiftEditStartColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.shiftEditStartColumn.HeaderText = "Schicht Start";
            this.shiftEditStartColumn.Name = "shiftEditStartColumn";
            // 
            // shiftEditEndColumn
            // 
            this.shiftEditEndColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.shiftEditEndColumn.HeaderText = "Schicht Ende";
            this.shiftEditEndColumn.Name = "shiftEditEndColumn";
            // 
            // shiftEditTypeColumn
            // 
            this.shiftEditTypeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.shiftEditTypeColumn.HeaderText = "Schicht Typ";
            this.shiftEditTypeColumn.Name = "shiftEditTypeColumn";
            this.shiftEditTypeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // shiftEditDescriptionColumn
            // 
            this.shiftEditDescriptionColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.shiftEditDescriptionColumn.HeaderText = "Beschreibung";
            this.shiftEditDescriptionColumn.Name = "shiftEditDescriptionColumn";
            // 
            // saveCurrentShift
            // 
            this.saveCurrentShift.Location = new System.Drawing.Point(9, 4);
            this.saveCurrentShift.Name = "saveCurrentShift";
            this.saveCurrentShift.Size = new System.Drawing.Size(75, 23);
            this.saveCurrentShift.TabIndex = 1;
            this.saveCurrentShift.Text = "speichern";
            this.saveCurrentShift.UseVisualStyleBackColor = true;
            this.saveCurrentShift.Click += new System.EventHandler(this.saveCurrentShift_Click);
            // 
            // shiftEditLabel
            // 
            this.shiftEditLabel.AutoSize = true;
            this.shiftEditLabel.Location = new System.Drawing.Point(90, 9);
            this.shiftEditLabel.Name = "shiftEditLabel";
            this.shiftEditLabel.Size = new System.Drawing.Size(99, 13);
            this.shiftEditLabel.TabIndex = 0;
            this.shiftEditLabel.Text = "Schichtbearbeitung";
            // 
            // weekTemplatePanel
            // 
            this.weekTemplatePanel.Controls.Add(this.loadFromOtherMonthButton);
            this.weekTemplatePanel.Controls.Add(this.weekTemplateTable);
            this.weekTemplatePanel.Controls.Add(this.useOnHoleMonth);
            this.weekTemplatePanel.Controls.Add(this.weekTemplateLabel);
            this.weekTemplatePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.weekTemplatePanel.Location = new System.Drawing.Point(0, 0);
            this.weekTemplatePanel.Name = "weekTemplatePanel";
            this.weekTemplatePanel.Size = new System.Drawing.Size(587, 257);
            this.weekTemplatePanel.TabIndex = 0;
            // 
            // loadFromOtherMonthButton
            // 
            this.loadFromOtherMonthButton.Location = new System.Drawing.Point(10, 231);
            this.loadFromOtherMonthButton.Name = "loadFromOtherMonthButton";
            this.loadFromOtherMonthButton.Size = new System.Drawing.Size(140, 23);
            this.loadFromOtherMonthButton.TabIndex = 3;
            this.loadFromOtherMonthButton.Text = "von anderem Monat laden";
            this.loadFromOtherMonthButton.UseVisualStyleBackColor = true;
            this.loadFromOtherMonthButton.Click += new System.EventHandler(this.loadFromOtherMonthButton_Click);
            // 
            // weekTemplateTable
            // 
            this.weekTemplateTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.weekTemplateTable.ColumnCount = 2;
            this.weekTemplateTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.weekTemplateTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.weekTemplateTable.Controls.Add(this.weekTemplateWednesdayLabel, 0, 2);
            this.weekTemplateTable.Controls.Add(this.weekTemplateThursdayLabel, 0, 3);
            this.weekTemplateTable.Controls.Add(this.weekTemplateFridayLabel, 0, 4);
            this.weekTemplateTable.Controls.Add(this.weekTemplateSaturdayLabel, 0, 5);
            this.weekTemplateTable.Controls.Add(this.weekTemplateSundayLabel, 0, 6);
            this.weekTemplateTable.Controls.Add(this.weekTemplateMondayLabel, 0, 0);
            this.weekTemplateTable.Controls.Add(this.weekTemplateMondayContentLabel, 1, 0);
            this.weekTemplateTable.Controls.Add(this.weekTemplateWednesdayContentLabel, 1, 2);
            this.weekTemplateTable.Controls.Add(this.weekTemplateThursdayContentLabel, 1, 3);
            this.weekTemplateTable.Controls.Add(this.weekTemplateFridayContentLabel, 1, 4);
            this.weekTemplateTable.Controls.Add(this.weekTemplateSaturdayContentLabel, 1, 5);
            this.weekTemplateTable.Controls.Add(this.weekTemplateSundayContentLabel, 1, 6);
            this.weekTemplateTable.Controls.Add(this.weekTemplateTuesdayContentLabel, 1, 1);
            this.weekTemplateTable.Controls.Add(this.weekTemplateTuesdayLabel, 0, 1);
            this.weekTemplateTable.Location = new System.Drawing.Point(10, 21);
            this.weekTemplateTable.Name = "weekTemplateTable";
            this.weekTemplateTable.RowCount = 7;
            this.weekTemplateTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.weekTemplateTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.weekTemplateTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.weekTemplateTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.weekTemplateTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.weekTemplateTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.weekTemplateTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.weekTemplateTable.Size = new System.Drawing.Size(572, 204);
            this.weekTemplateTable.TabIndex = 2;
            // 
            // weekTemplateWednesdayLabel
            // 
            this.weekTemplateWednesdayLabel.Location = new System.Drawing.Point(1, 59);
            this.weekTemplateWednesdayLabel.Margin = new System.Windows.Forms.Padding(0);
            this.weekTemplateWednesdayLabel.Name = "weekTemplateWednesdayLabel";
            this.weekTemplateWednesdayLabel.Size = new System.Drawing.Size(284, 28);
            this.weekTemplateWednesdayLabel.TabIndex = 2;
            this.weekTemplateWednesdayLabel.Text = "Mittwoch";
            this.weekTemplateWednesdayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // weekTemplateThursdayLabel
            // 
            this.weekTemplateThursdayLabel.Location = new System.Drawing.Point(1, 88);
            this.weekTemplateThursdayLabel.Margin = new System.Windows.Forms.Padding(0);
            this.weekTemplateThursdayLabel.Name = "weekTemplateThursdayLabel";
            this.weekTemplateThursdayLabel.Size = new System.Drawing.Size(284, 28);
            this.weekTemplateThursdayLabel.TabIndex = 3;
            this.weekTemplateThursdayLabel.Text = "Donnerstag";
            this.weekTemplateThursdayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // weekTemplateFridayLabel
            // 
            this.weekTemplateFridayLabel.Location = new System.Drawing.Point(1, 117);
            this.weekTemplateFridayLabel.Margin = new System.Windows.Forms.Padding(0);
            this.weekTemplateFridayLabel.Name = "weekTemplateFridayLabel";
            this.weekTemplateFridayLabel.Size = new System.Drawing.Size(284, 28);
            this.weekTemplateFridayLabel.TabIndex = 4;
            this.weekTemplateFridayLabel.Text = "Freitag";
            this.weekTemplateFridayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // weekTemplateSaturdayLabel
            // 
            this.weekTemplateSaturdayLabel.Location = new System.Drawing.Point(1, 146);
            this.weekTemplateSaturdayLabel.Margin = new System.Windows.Forms.Padding(0);
            this.weekTemplateSaturdayLabel.Name = "weekTemplateSaturdayLabel";
            this.weekTemplateSaturdayLabel.Size = new System.Drawing.Size(284, 28);
            this.weekTemplateSaturdayLabel.TabIndex = 5;
            this.weekTemplateSaturdayLabel.Text = "Samstag";
            this.weekTemplateSaturdayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // weekTemplateSundayLabel
            // 
            this.weekTemplateSundayLabel.Location = new System.Drawing.Point(1, 175);
            this.weekTemplateSundayLabel.Margin = new System.Windows.Forms.Padding(0);
            this.weekTemplateSundayLabel.Name = "weekTemplateSundayLabel";
            this.weekTemplateSundayLabel.Size = new System.Drawing.Size(284, 28);
            this.weekTemplateSundayLabel.TabIndex = 6;
            this.weekTemplateSundayLabel.Text = "Sonntag";
            this.weekTemplateSundayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // weekTemplateMondayLabel
            // 
            this.weekTemplateMondayLabel.Location = new System.Drawing.Point(1, 1);
            this.weekTemplateMondayLabel.Margin = new System.Windows.Forms.Padding(0);
            this.weekTemplateMondayLabel.Name = "weekTemplateMondayLabel";
            this.weekTemplateMondayLabel.Size = new System.Drawing.Size(284, 28);
            this.weekTemplateMondayLabel.TabIndex = 0;
            this.weekTemplateMondayLabel.Text = "Montag";
            this.weekTemplateMondayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // weekTemplateMondayContentLabel
            // 
            this.weekTemplateMondayContentLabel.Location = new System.Drawing.Point(286, 1);
            this.weekTemplateMondayContentLabel.Margin = new System.Windows.Forms.Padding(0);
            this.weekTemplateMondayContentLabel.Name = "weekTemplateMondayContentLabel";
            this.weekTemplateMondayContentLabel.Size = new System.Drawing.Size(285, 28);
            this.weekTemplateMondayContentLabel.TabIndex = 7;
            this.weekTemplateMondayContentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // weekTemplateWednesdayContentLabel
            // 
            this.weekTemplateWednesdayContentLabel.Location = new System.Drawing.Point(286, 59);
            this.weekTemplateWednesdayContentLabel.Margin = new System.Windows.Forms.Padding(0);
            this.weekTemplateWednesdayContentLabel.Name = "weekTemplateWednesdayContentLabel";
            this.weekTemplateWednesdayContentLabel.Size = new System.Drawing.Size(285, 28);
            this.weekTemplateWednesdayContentLabel.TabIndex = 9;
            this.weekTemplateWednesdayContentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // weekTemplateThursdayContentLabel
            // 
            this.weekTemplateThursdayContentLabel.Location = new System.Drawing.Point(286, 88);
            this.weekTemplateThursdayContentLabel.Margin = new System.Windows.Forms.Padding(0);
            this.weekTemplateThursdayContentLabel.Name = "weekTemplateThursdayContentLabel";
            this.weekTemplateThursdayContentLabel.Size = new System.Drawing.Size(285, 28);
            this.weekTemplateThursdayContentLabel.TabIndex = 10;
            this.weekTemplateThursdayContentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // weekTemplateFridayContentLabel
            // 
            this.weekTemplateFridayContentLabel.Location = new System.Drawing.Point(286, 117);
            this.weekTemplateFridayContentLabel.Margin = new System.Windows.Forms.Padding(0);
            this.weekTemplateFridayContentLabel.Name = "weekTemplateFridayContentLabel";
            this.weekTemplateFridayContentLabel.Size = new System.Drawing.Size(285, 28);
            this.weekTemplateFridayContentLabel.TabIndex = 11;
            this.weekTemplateFridayContentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // weekTemplateSaturdayContentLabel
            // 
            this.weekTemplateSaturdayContentLabel.Location = new System.Drawing.Point(286, 146);
            this.weekTemplateSaturdayContentLabel.Margin = new System.Windows.Forms.Padding(0);
            this.weekTemplateSaturdayContentLabel.Name = "weekTemplateSaturdayContentLabel";
            this.weekTemplateSaturdayContentLabel.Size = new System.Drawing.Size(285, 28);
            this.weekTemplateSaturdayContentLabel.TabIndex = 12;
            this.weekTemplateSaturdayContentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // weekTemplateSundayContentLabel
            // 
            this.weekTemplateSundayContentLabel.Location = new System.Drawing.Point(286, 175);
            this.weekTemplateSundayContentLabel.Margin = new System.Windows.Forms.Padding(0);
            this.weekTemplateSundayContentLabel.Name = "weekTemplateSundayContentLabel";
            this.weekTemplateSundayContentLabel.Size = new System.Drawing.Size(285, 28);
            this.weekTemplateSundayContentLabel.TabIndex = 13;
            this.weekTemplateSundayContentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // weekTemplateTuesdayContentLabel
            // 
            this.weekTemplateTuesdayContentLabel.Location = new System.Drawing.Point(286, 30);
            this.weekTemplateTuesdayContentLabel.Margin = new System.Windows.Forms.Padding(0);
            this.weekTemplateTuesdayContentLabel.Name = "weekTemplateTuesdayContentLabel";
            this.weekTemplateTuesdayContentLabel.Size = new System.Drawing.Size(285, 28);
            this.weekTemplateTuesdayContentLabel.TabIndex = 8;
            this.weekTemplateTuesdayContentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // weekTemplateTuesdayLabel
            // 
            this.weekTemplateTuesdayLabel.Location = new System.Drawing.Point(1, 30);
            this.weekTemplateTuesdayLabel.Margin = new System.Windows.Forms.Padding(0);
            this.weekTemplateTuesdayLabel.Name = "weekTemplateTuesdayLabel";
            this.weekTemplateTuesdayLabel.Size = new System.Drawing.Size(284, 28);
            this.weekTemplateTuesdayLabel.TabIndex = 1;
            this.weekTemplateTuesdayLabel.Text = "Dienstag";
            this.weekTemplateTuesdayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // useOnHoleMonth
            // 
            this.useOnHoleMonth.Location = new System.Drawing.Point(409, 231);
            this.useOnHoleMonth.Name = "useOnHoleMonth";
            this.useOnHoleMonth.Size = new System.Drawing.Size(173, 23);
            this.useOnHoleMonth.TabIndex = 1;
            this.useOnHoleMonth.Text = "auf ganzen Monat anwenden";
            this.useOnHoleMonth.UseVisualStyleBackColor = true;
            this.useOnHoleMonth.Click += new System.EventHandler(this.useOnHoleMonth_Click);
            // 
            // weekTemplateLabel
            // 
            this.weekTemplateLabel.AutoSize = true;
            this.weekTemplateLabel.Location = new System.Drawing.Point(7, 0);
            this.weekTemplateLabel.Name = "weekTemplateLabel";
            this.weekTemplateLabel.Size = new System.Drawing.Size(83, 13);
            this.weekTemplateLabel.TabIndex = 0;
            this.weekTemplateLabel.Text = "Wochenvorlage";
            // 
            // monthViewPanel
            // 
            this.monthViewPanel.BackColor = System.Drawing.Color.Transparent;
            this.monthViewPanel.Controls.Add(this.monthViewTable);
            this.monthViewPanel.Controls.Add(this.monthViewLabel);
            this.monthViewPanel.Location = new System.Drawing.Point(3, 3);
            this.monthViewPanel.Name = "monthViewPanel";
            this.monthViewPanel.Size = new System.Drawing.Size(639, 525);
            this.monthViewPanel.TabIndex = 0;
            // 
            // monthViewTable
            // 
            this.monthViewTable.AutoScroll = true;
            this.monthViewTable.AutoSize = true;
            this.monthViewTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.monthViewTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.monthViewTable.ColumnCount = 2;
            this.monthViewTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.99999F));
            this.monthViewTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
            this.monthViewTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.monthViewTable.Location = new System.Drawing.Point(0, 13);
            this.monthViewTable.MaximumSize = new System.Drawing.Size(0, 500);
            this.monthViewTable.MinimumSize = new System.Drawing.Size(0, 15);
            this.monthViewTable.Name = "monthViewTable";
            this.monthViewTable.RowCount = 1;
            this.monthViewTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.monthViewTable.Size = new System.Drawing.Size(639, 15);
            this.monthViewTable.TabIndex = 1;
            // 
            // monthViewLabel
            // 
            this.monthViewLabel.AutoSize = true;
            this.monthViewLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.monthViewLabel.Location = new System.Drawing.Point(0, 0);
            this.monthViewLabel.Name = "monthViewLabel";
            this.monthViewLabel.Size = new System.Drawing.Size(76, 13);
            this.monthViewLabel.TabIndex = 0;
            this.monthViewLabel.Text = "Monatsansicht";
            // 
            // personsTabPage
            // 
            this.personsTabPage.BackColor = System.Drawing.Color.Transparent;
            this.personsTabPage.Controls.Add(this.personContentPanel);
            this.personsTabPage.Controls.Add(this.personDataPanel);
            this.personsTabPage.Location = new System.Drawing.Point(4, 22);
            this.personsTabPage.Name = "personsTabPage";
            this.personsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.personsTabPage.Size = new System.Drawing.Size(1238, 531);
            this.personsTabPage.TabIndex = 1;
            this.personsTabPage.Text = "Personal";
            this.personsTabPage.SizeChanged += new System.EventHandler(this.personsTabPage_SizeChanged);
            // 
            // personContentPanel
            // 
            this.personContentPanel.BackColor = System.Drawing.Color.Transparent;
            this.personContentPanel.Controls.Add(this.personShiftSelectPanel);
            this.personContentPanel.Controls.Add(this.personTable);
            this.personContentPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.personContentPanel.Location = new System.Drawing.Point(3, 53);
            this.personContentPanel.Name = "personContentPanel";
            this.personContentPanel.Size = new System.Drawing.Size(1232, 475);
            this.personContentPanel.TabIndex = 3;
            // 
            // personShiftSelectPanel
            // 
            this.personShiftSelectPanel.BackColor = System.Drawing.Color.Transparent;
            this.personShiftSelectPanel.Controls.Add(this.personResetAllUnavailabilitiesButton);
            this.personShiftSelectPanel.Controls.Add(this.personSetAllUnavailabilitiesCheckBox);
            this.personShiftSelectPanel.Controls.Add(this.personSetDaysUnavailableButton);
            this.personShiftSelectPanel.Controls.Add(this.personSetDaysUnavailableTextBox);
            this.personShiftSelectPanel.Controls.Add(this.personUnavailableshiftSelectDataGridView);
            this.personShiftSelectPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.personShiftSelectPanel.Location = new System.Drawing.Point(608, 0);
            this.personShiftSelectPanel.Name = "personShiftSelectPanel";
            this.personShiftSelectPanel.Size = new System.Drawing.Size(624, 475);
            this.personShiftSelectPanel.TabIndex = 2;
            // 
            // personResetAllUnavailabilitiesButton
            // 
            this.personResetAllUnavailabilitiesButton.Location = new System.Drawing.Point(480, 5);
            this.personResetAllUnavailabilitiesButton.Name = "personResetAllUnavailabilitiesButton";
            this.personResetAllUnavailabilitiesButton.Size = new System.Drawing.Size(133, 23);
            this.personResetAllUnavailabilitiesButton.TabIndex = 4;
            this.personResetAllUnavailabilitiesButton.Text = "von allen zurücksetzen";
            this.personResetAllUnavailabilitiesButton.UseVisualStyleBackColor = true;
            this.personResetAllUnavailabilitiesButton.Click += new System.EventHandler(this.personResetAllUnavailabilitiesButton_Click);
            // 
            // personSetAllUnavailabilitiesCheckBox
            // 
            this.personSetAllUnavailabilitiesCheckBox.AutoSize = true;
            this.personSetAllUnavailabilitiesCheckBox.Location = new System.Drawing.Point(381, 10);
            this.personSetAllUnavailabilitiesCheckBox.Name = "personSetAllUnavailabilitiesCheckBox";
            this.personSetAllUnavailabilitiesCheckBox.Size = new System.Drawing.Size(99, 17);
            this.personSetAllUnavailabilitiesCheckBox.TabIndex = 3;
            this.personSetAllUnavailabilitiesCheckBox.Text = "Nicht verfügbar";
            this.personSetAllUnavailabilitiesCheckBox.UseVisualStyleBackColor = true;
            this.personSetAllUnavailabilitiesCheckBox.CheckedChanged += new System.EventHandler(this.personSetAll_CheckedChanged);
            // 
            // personSetDaysUnavailableButton
            // 
            this.personSetDaysUnavailableButton.Location = new System.Drawing.Point(235, 6);
            this.personSetDaysUnavailableButton.Name = "personSetDaysUnavailableButton";
            this.personSetDaysUnavailableButton.Size = new System.Drawing.Size(140, 23);
            this.personSetDaysUnavailableButton.TabIndex = 2;
            this.personSetDaysUnavailableButton.Text = "Als Nicht verfügbar setzen";
            this.personSetDaysUnavailableButton.UseVisualStyleBackColor = true;
            this.personSetDaysUnavailableButton.Click += new System.EventHandler(this.personSetDaysUnavailableButton_Click);
            // 
            // personSetDaysUnavailableTextBox
            // 
            this.personSetDaysUnavailableTextBox.Location = new System.Drawing.Point(3, 8);
            this.personSetDaysUnavailableTextBox.Name = "personSetDaysUnavailableTextBox";
            this.personSetDaysUnavailableTextBox.Size = new System.Drawing.Size(226, 20);
            this.personSetDaysUnavailableTextBox.TabIndex = 1;
            // 
            // personUnavailableshiftSelectDataGridView
            // 
            this.personUnavailableshiftSelectDataGridView.AllowUserToAddRows = false;
            this.personUnavailableshiftSelectDataGridView.AllowUserToDeleteRows = false;
            this.personUnavailableshiftSelectDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.personUnavailableshiftSelectDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.personShiftColumn,
            this.personShiftSelectColumn,
            this.personOnlyShiftSelectColumn});
            this.personUnavailableshiftSelectDataGridView.Location = new System.Drawing.Point(3, 33);
            this.personUnavailableshiftSelectDataGridView.Name = "personUnavailableshiftSelectDataGridView";
            this.personUnavailableshiftSelectDataGridView.Size = new System.Drawing.Size(616, 437);
            this.personUnavailableshiftSelectDataGridView.TabIndex = 0;
            // 
            // personShiftColumn
            // 
            this.personShiftColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.personShiftColumn.HeaderText = "Schichten";
            this.personShiftColumn.Name = "personShiftColumn";
            this.personShiftColumn.ReadOnly = true;
            // 
            // personShiftSelectColumn
            // 
            this.personShiftSelectColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.personShiftSelectColumn.HeaderText = "Nicht verfügbar";
            this.personShiftSelectColumn.Name = "personShiftSelectColumn";
            this.personShiftSelectColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.personShiftSelectColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // personOnlyShiftSelectColumn
            // 
            this.personOnlyShiftSelectColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.personOnlyShiftSelectColumn.HeaderText = "Einzige verfügbar";
            this.personOnlyShiftSelectColumn.Name = "personOnlyShiftSelectColumn";
            // 
            // personTable
            // 
            this.personTable.AutoScroll = true;
            this.personTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.personTable.BackColor = System.Drawing.Color.Transparent;
            this.personTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.personTable.ColumnCount = 8;
            this.personTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.personTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.personTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.personTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.personTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.personTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.personTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.personTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.personTable.Dock = System.Windows.Forms.DockStyle.Left;
            this.personTable.Location = new System.Drawing.Point(0, 0);
            this.personTable.Name = "personTable";
            this.personTable.RowCount = 1;
            this.personTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.personTable.Size = new System.Drawing.Size(602, 475);
            this.personTable.TabIndex = 1;
            // 
            // personDataPanel
            // 
            this.personDataPanel.Controls.Add(this.personColorLabel);
            this.personDataPanel.Controls.Add(this.personColorButton);
            this.personDataPanel.Controls.Add(this.personCarryOverLabel);
            this.personDataPanel.Controls.Add(this.personCarryOverTextBox);
            this.personDataPanel.Controls.Add(this.personLoadFromDifferentMonthButton);
            this.personDataPanel.Controls.Add(this.personSaveEditButton);
            this.personDataPanel.Controls.Add(this.personDeleteButton);
            this.personDataPanel.Controls.Add(this.personAddButton);
            this.personDataPanel.Controls.Add(this.personDescriptionLabel);
            this.personDataPanel.Controls.Add(this.personShifttypesLabel);
            this.personDataPanel.Controls.Add(this.personMaxWorkHoursLabel);
            this.personDataPanel.Controls.Add(this.personMinWorkHoursLabel);
            this.personDataPanel.Controls.Add(this.personSalaryLabel);
            this.personDataPanel.Controls.Add(this.personShifttypesTextBox);
            this.personDataPanel.Controls.Add(this.personDescriptionTextBox);
            this.personDataPanel.Controls.Add(this.personMaxWorkHoursTextBox);
            this.personDataPanel.Controls.Add(this.personMinWorkHoursTextBox);
            this.personDataPanel.Controls.Add(this.personSaleryTextBox);
            this.personDataPanel.Controls.Add(this.personNameTextBox);
            this.personDataPanel.Controls.Add(this.personNameLabel);
            this.personDataPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.personDataPanel.Location = new System.Drawing.Point(3, 3);
            this.personDataPanel.Name = "personDataPanel";
            this.personDataPanel.Size = new System.Drawing.Size(1232, 50);
            this.personDataPanel.TabIndex = 2;
            // 
            // personColorLabel
            // 
            this.personColorLabel.AutoSize = true;
            this.personColorLabel.Location = new System.Drawing.Point(632, 4);
            this.personColorLabel.Name = "personColorLabel";
            this.personColorLabel.Size = new System.Drawing.Size(34, 13);
            this.personColorLabel.TabIndex = 20;
            this.personColorLabel.Text = "Farbe";
            // 
            // personColorButton
            // 
            this.personColorButton.Location = new System.Drawing.Point(635, 19);
            this.personColorButton.Name = "personColorButton";
            this.personColorButton.Size = new System.Drawing.Size(31, 23);
            this.personColorButton.TabIndex = 19;
            this.personColorButton.UseVisualStyleBackColor = true;
            this.personColorButton.Click += new System.EventHandler(this.personColorButton_Click);
            // 
            // personCarryOverLabel
            // 
            this.personCarryOverLabel.AutoSize = true;
            this.personCarryOverLabel.Location = new System.Drawing.Point(340, 4);
            this.personCarryOverLabel.Name = "personCarryOverLabel";
            this.personCarryOverLabel.Size = new System.Drawing.Size(48, 13);
            this.personCarryOverLabel.TabIndex = 18;
            this.personCarryOverLabel.Text = "Übertrag";
            // 
            // personCarryOverTextBox
            // 
            this.personCarryOverTextBox.Location = new System.Drawing.Point(343, 21);
            this.personCarryOverTextBox.Name = "personCarryOverTextBox";
            this.personCarryOverTextBox.Size = new System.Drawing.Size(50, 20);
            this.personCarryOverTextBox.TabIndex = 17;
            // 
            // personLoadFromDifferentMonthButton
            // 
            this.personLoadFromDifferentMonthButton.Location = new System.Drawing.Point(1088, 4);
            this.personLoadFromDifferentMonthButton.Name = "personLoadFromDifferentMonthButton";
            this.personLoadFromDifferentMonthButton.Size = new System.Drawing.Size(139, 23);
            this.personLoadFromDifferentMonthButton.TabIndex = 15;
            this.personLoadFromDifferentMonthButton.Text = "von anderem Monat laden";
            this.personLoadFromDifferentMonthButton.UseVisualStyleBackColor = true;
            this.personLoadFromDifferentMonthButton.Click += new System.EventHandler(this.personLoadFromDifferentMonthButton_Click);
            // 
            // personSaveEditButton
            // 
            this.personSaveEditButton.Location = new System.Drawing.Point(836, 19);
            this.personSaveEditButton.Name = "personSaveEditButton";
            this.personSaveEditButton.Size = new System.Drawing.Size(75, 23);
            this.personSaveEditButton.TabIndex = 14;
            this.personSaveEditButton.Text = "speichern";
            this.personSaveEditButton.UseVisualStyleBackColor = true;
            this.personSaveEditButton.Click += new System.EventHandler(this.personSaveEditButton_Click);
            // 
            // personDeleteButton
            // 
            this.personDeleteButton.Location = new System.Drawing.Point(754, 19);
            this.personDeleteButton.Name = "personDeleteButton";
            this.personDeleteButton.Size = new System.Drawing.Size(75, 23);
            this.personDeleteButton.TabIndex = 13;
            this.personDeleteButton.Text = "löschen";
            this.personDeleteButton.UseVisualStyleBackColor = true;
            this.personDeleteButton.Click += new System.EventHandler(this.personDeleteButton_Click);
            // 
            // personAddButton
            // 
            this.personAddButton.Location = new System.Drawing.Point(672, 19);
            this.personAddButton.Name = "personAddButton";
            this.personAddButton.Size = new System.Drawing.Size(75, 23);
            this.personAddButton.TabIndex = 12;
            this.personAddButton.Text = "hinzufügen";
            this.personAddButton.UseVisualStyleBackColor = true;
            this.personAddButton.Click += new System.EventHandler(this.personAddButton_Click);
            // 
            // personDescriptionLabel
            // 
            this.personDescriptionLabel.AutoSize = true;
            this.personDescriptionLabel.Location = new System.Drawing.Point(526, 4);
            this.personDescriptionLabel.Name = "personDescriptionLabel";
            this.personDescriptionLabel.Size = new System.Drawing.Size(73, 13);
            this.personDescriptionLabel.TabIndex = 11;
            this.personDescriptionLabel.Text = "Anmerkungen";
            // 
            // personShifttypesLabel
            // 
            this.personShifttypesLabel.AutoSize = true;
            this.personShifttypesLabel.Location = new System.Drawing.Point(396, 4);
            this.personShifttypesLabel.Name = "personShifttypesLabel";
            this.personShifttypesLabel.Size = new System.Drawing.Size(76, 13);
            this.personShifttypesLabel.TabIndex = 10;
            this.personShifttypesLabel.Text = "Schicht Typen";
            // 
            // personMaxWorkHoursLabel
            // 
            this.personMaxWorkHoursLabel.AutoSize = true;
            this.personMaxWorkHoursLabel.Location = new System.Drawing.Point(284, 4);
            this.personMaxWorkHoursLabel.Name = "personMaxWorkHoursLabel";
            this.personMaxWorkHoursLabel.Size = new System.Drawing.Size(49, 13);
            this.personMaxWorkHoursLabel.TabIndex = 9;
            this.personMaxWorkHoursLabel.Text = "Max h/m";
            // 
            // personMinWorkHoursLabel
            // 
            this.personMinWorkHoursLabel.AutoSize = true;
            this.personMinWorkHoursLabel.Location = new System.Drawing.Point(228, 4);
            this.personMinWorkHoursLabel.Name = "personMinWorkHoursLabel";
            this.personMinWorkHoursLabel.Size = new System.Drawing.Size(46, 13);
            this.personMinWorkHoursLabel.TabIndex = 8;
            this.personMinWorkHoursLabel.Text = "Min h/m";
            // 
            // personSalaryLabel
            // 
            this.personSalaryLabel.AutoSize = true;
            this.personSalaryLabel.Location = new System.Drawing.Point(172, 4);
            this.personSalaryLabel.Name = "personSalaryLabel";
            this.personSalaryLabel.Size = new System.Drawing.Size(49, 13);
            this.personSalaryLabel.TabIndex = 7;
            this.personSalaryLabel.Text = "Gehalt/h";
            // 
            // personShifttypesTextBox
            // 
            this.personShifttypesTextBox.Location = new System.Drawing.Point(399, 21);
            this.personShifttypesTextBox.Name = "personShifttypesTextBox";
            this.personShifttypesTextBox.Size = new System.Drawing.Size(124, 20);
            this.personShifttypesTextBox.TabIndex = 16;
            // 
            // personDescriptionTextBox
            // 
            this.personDescriptionTextBox.Location = new System.Drawing.Point(529, 21);
            this.personDescriptionTextBox.Name = "personDescriptionTextBox";
            this.personDescriptionTextBox.Size = new System.Drawing.Size(100, 20);
            this.personDescriptionTextBox.TabIndex = 6;
            // 
            // personMaxWorkHoursTextBox
            // 
            this.personMaxWorkHoursTextBox.Location = new System.Drawing.Point(287, 21);
            this.personMaxWorkHoursTextBox.Name = "personMaxWorkHoursTextBox";
            this.personMaxWorkHoursTextBox.Size = new System.Drawing.Size(50, 20);
            this.personMaxWorkHoursTextBox.TabIndex = 4;
            // 
            // personMinWorkHoursTextBox
            // 
            this.personMinWorkHoursTextBox.Location = new System.Drawing.Point(231, 21);
            this.personMinWorkHoursTextBox.Name = "personMinWorkHoursTextBox";
            this.personMinWorkHoursTextBox.Size = new System.Drawing.Size(50, 20);
            this.personMinWorkHoursTextBox.TabIndex = 3;
            // 
            // personSaleryTextBox
            // 
            this.personSaleryTextBox.Location = new System.Drawing.Point(175, 21);
            this.personSaleryTextBox.Name = "personSaleryTextBox";
            this.personSaleryTextBox.Size = new System.Drawing.Size(50, 20);
            this.personSaleryTextBox.TabIndex = 2;
            // 
            // personNameTextBox
            // 
            this.personNameTextBox.Location = new System.Drawing.Point(9, 21);
            this.personNameTextBox.Name = "personNameTextBox";
            this.personNameTextBox.Size = new System.Drawing.Size(160, 20);
            this.personNameTextBox.TabIndex = 1;
            // 
            // personNameLabel
            // 
            this.personNameLabel.AutoSize = true;
            this.personNameLabel.Location = new System.Drawing.Point(6, 4);
            this.personNameLabel.Name = "personNameLabel";
            this.personNameLabel.Size = new System.Drawing.Size(35, 13);
            this.personNameLabel.TabIndex = 0;
            this.personNameLabel.Text = "Name";
            // 
            // shiftPlanTabPage
            // 
            this.shiftPlanTabPage.Controls.Add(this.shiftPlanFilterPanel);
            this.shiftPlanTabPage.Controls.Add(this.shiftPlanTable);
            this.shiftPlanTabPage.Location = new System.Drawing.Point(4, 22);
            this.shiftPlanTabPage.Name = "shiftPlanTabPage";
            this.shiftPlanTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.shiftPlanTabPage.Size = new System.Drawing.Size(1238, 531);
            this.shiftPlanTabPage.TabIndex = 2;
            this.shiftPlanTabPage.Text = "Schichtplan";
            this.shiftPlanTabPage.UseVisualStyleBackColor = true;
            this.shiftPlanTabPage.SizeChanged += new System.EventHandler(this.shiftPlanTabPage_SizeChanged);
            // 
            // shiftPlanFilterPanel
            // 
            this.shiftPlanFilterPanel.Controls.Add(this.shiftPlanPersonsWithOutOfBoudsWorkhoursButton);
            this.shiftPlanFilterPanel.Controls.Add(this.shiftPlanPersonsWithOutOfBoudsWorkhoursLabel);
            this.shiftPlanFilterPanel.Controls.Add(this.shiftPlanShowShiftsNotSetButton);
            this.shiftPlanFilterPanel.Controls.Add(this.shiftPlanShiftsNotSetLabel);
            this.shiftPlanFilterPanel.Controls.Add(this.label1);
            this.shiftPlanFilterPanel.Controls.Add(this.shiftPlanShiftTypeColorButton);
            this.shiftPlanFilterPanel.Controls.Add(this.shiftPlanShiftTypeColorComboBox);
            this.shiftPlanFilterPanel.Controls.Add(this.shiftPlanAlgorithmComboBox);
            this.shiftPlanFilterPanel.Controls.Add(this.shiftPlanAddShiftButton);
            this.shiftPlanFilterPanel.Controls.Add(this.shiftPlanDayContent);
            this.shiftPlanFilterPanel.Controls.Add(this.shiftPlanDayLabel);
            this.shiftPlanFilterPanel.Controls.Add(this.shiftPlanShiftTypeLabel);
            this.shiftPlanFilterPanel.Controls.Add(this.shiftPlanShiftEndLabel);
            this.shiftPlanFilterPanel.Controls.Add(this.shiftPlanShiftStartLabel);
            this.shiftPlanFilterPanel.Controls.Add(this.shiftPlanShiftTypeTextBox);
            this.shiftPlanFilterPanel.Controls.Add(this.shiftPlanShiftEndTextBox);
            this.shiftPlanFilterPanel.Controls.Add(this.shiftPlanShiftStartTextBox);
            this.shiftPlanFilterPanel.Controls.Add(this.shiftPlanDeleteShiftButton);
            this.shiftPlanFilterPanel.Controls.Add(this.shiftPlanDescriptionLabel);
            this.shiftPlanFilterPanel.Controls.Add(this.shiftPlanPersonNameLabel);
            this.shiftPlanFilterPanel.Controls.Add(this.shiftPlanDescriptionTextBox);
            this.shiftPlanFilterPanel.Controls.Add(this.shiftPlanPersonComboBox);
            this.shiftPlanFilterPanel.Controls.Add(this.shiftplanSaveChangesButton);
            this.shiftPlanFilterPanel.Controls.Add(this.createShiftPlan);
            this.shiftPlanFilterPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.shiftPlanFilterPanel.Location = new System.Drawing.Point(3, 3);
            this.shiftPlanFilterPanel.MaximumSize = new System.Drawing.Size(0, 74);
            this.shiftPlanFilterPanel.Name = "shiftPlanFilterPanel";
            this.shiftPlanFilterPanel.Size = new System.Drawing.Size(1232, 74);
            this.shiftPlanFilterPanel.TabIndex = 3;
            // 
            // shiftPlanPersonsWithOutOfBoudsWorkhoursButton
            // 
            this.shiftPlanPersonsWithOutOfBoudsWorkhoursButton.Location = new System.Drawing.Point(984, 2);
            this.shiftPlanPersonsWithOutOfBoudsWorkhoursButton.Name = "shiftPlanPersonsWithOutOfBoudsWorkhoursButton";
            this.shiftPlanPersonsWithOutOfBoudsWorkhoursButton.Size = new System.Drawing.Size(75, 23);
            this.shiftPlanPersonsWithOutOfBoudsWorkhoursButton.TabIndex = 25;
            this.shiftPlanPersonsWithOutOfBoudsWorkhoursButton.Text = "Anzeigen";
            this.shiftPlanPersonsWithOutOfBoudsWorkhoursButton.UseVisualStyleBackColor = true;
            this.shiftPlanPersonsWithOutOfBoudsWorkhoursButton.Click += new System.EventHandler(this.shiftPlanPersonsWithOutOfBoudsWorkhoursButton_Click);
            // 
            // shiftPlanPersonsWithOutOfBoudsWorkhoursLabel
            // 
            this.shiftPlanPersonsWithOutOfBoudsWorkhoursLabel.AutoSize = true;
            this.shiftPlanPersonsWithOutOfBoudsWorkhoursLabel.Location = new System.Drawing.Point(740, 5);
            this.shiftPlanPersonsWithOutOfBoudsWorkhoursLabel.Name = "shiftPlanPersonsWithOutOfBoudsWorkhoursLabel";
            this.shiftPlanPersonsWithOutOfBoudsWorkhoursLabel.Padding = new System.Windows.Forms.Padding(2);
            this.shiftPlanPersonsWithOutOfBoudsWorkhoursLabel.Size = new System.Drawing.Size(225, 17);
            this.shiftPlanPersonsWithOutOfBoudsWorkhoursLabel.TabIndex = 24;
            this.shiftPlanPersonsWithOutOfBoudsWorkhoursLabel.Text = "Personen mit zuviel/zuwenig Arbeitsstunden: ";
            // 
            // shiftPlanShowShiftsNotSetButton
            // 
            this.shiftPlanShowShiftsNotSetButton.Location = new System.Drawing.Point(659, 2);
            this.shiftPlanShowShiftsNotSetButton.Name = "shiftPlanShowShiftsNotSetButton";
            this.shiftPlanShowShiftsNotSetButton.Size = new System.Drawing.Size(75, 23);
            this.shiftPlanShowShiftsNotSetButton.TabIndex = 23;
            this.shiftPlanShowShiftsNotSetButton.Text = "Anzeigen";
            this.shiftPlanShowShiftsNotSetButton.UseVisualStyleBackColor = true;
            this.shiftPlanShowShiftsNotSetButton.Click += new System.EventHandler(this.showShiftsNotSetButton_Click);
            // 
            // shiftPlanShiftsNotSetLabel
            // 
            this.shiftPlanShiftsNotSetLabel.AutoSize = true;
            this.shiftPlanShiftsNotSetLabel.Location = new System.Drawing.Point(506, 7);
            this.shiftPlanShiftsNotSetLabel.Name = "shiftPlanShiftsNotSetLabel";
            this.shiftPlanShiftsNotSetLabel.Padding = new System.Windows.Forms.Padding(2);
            this.shiftPlanShiftsNotSetLabel.Size = new System.Drawing.Size(133, 17);
            this.shiftPlanShiftsNotSetLabel.TabIndex = 22;
            this.shiftPlanShiftsNotSetLabel.Text = "Nicht gesetzte Schichten:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(242, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Schicht Typ Farbe";
            // 
            // shiftPlanShiftTypeColorButton
            // 
            this.shiftPlanShiftTypeColorButton.Location = new System.Drawing.Point(469, 2);
            this.shiftPlanShiftTypeColorButton.Name = "shiftPlanShiftTypeColorButton";
            this.shiftPlanShiftTypeColorButton.Size = new System.Drawing.Size(31, 23);
            this.shiftPlanShiftTypeColorButton.TabIndex = 20;
            this.shiftPlanShiftTypeColorButton.UseVisualStyleBackColor = true;
            this.shiftPlanShiftTypeColorButton.Click += new System.EventHandler(this.shiftPlanShiftTypeColorButton_Click);
            // 
            // shiftPlanShiftTypeColorComboBox
            // 
            this.shiftPlanShiftTypeColorComboBox.FormattingEnabled = true;
            this.shiftPlanShiftTypeColorComboBox.Location = new System.Drawing.Point(342, 3);
            this.shiftPlanShiftTypeColorComboBox.Name = "shiftPlanShiftTypeColorComboBox";
            this.shiftPlanShiftTypeColorComboBox.Size = new System.Drawing.Size(121, 21);
            this.shiftPlanShiftTypeColorComboBox.TabIndex = 18;
            this.shiftPlanShiftTypeColorComboBox.SelectedIndexChanged += new System.EventHandler(this.shiftPlanShiftTypeColorComboBox_SelectedIndexChanged);
            // 
            // shiftPlanAlgorithmComboBox
            // 
            this.shiftPlanAlgorithmComboBox.FormattingEnabled = true;
            this.shiftPlanAlgorithmComboBox.Items.AddRange(new object[] {
            "Einfachen Schichtplan",
            "Verteilten Schichtplan"});
            this.shiftPlanAlgorithmComboBox.Location = new System.Drawing.Point(10, 3);
            this.shiftPlanAlgorithmComboBox.Name = "shiftPlanAlgorithmComboBox";
            this.shiftPlanAlgorithmComboBox.Size = new System.Drawing.Size(144, 21);
            this.shiftPlanAlgorithmComboBox.TabIndex = 17;
            // 
            // shiftPlanAddShiftButton
            // 
            this.shiftPlanAddShiftButton.Location = new System.Drawing.Point(821, 45);
            this.shiftPlanAddShiftButton.Name = "shiftPlanAddShiftButton";
            this.shiftPlanAddShiftButton.Size = new System.Drawing.Size(75, 23);
            this.shiftPlanAddShiftButton.TabIndex = 16;
            this.shiftPlanAddShiftButton.Text = "hinzufügen";
            this.shiftPlanAddShiftButton.UseVisualStyleBackColor = true;
            this.shiftPlanAddShiftButton.Click += new System.EventHandler(this.shiftPlanAddShiftButton_Click);
            // 
            // shiftPlanDayContent
            // 
            this.shiftPlanDayContent.AutoSize = true;
            this.shiftPlanDayContent.Location = new System.Drawing.Point(7, 50);
            this.shiftPlanDayContent.Name = "shiftPlanDayContent";
            this.shiftPlanDayContent.Size = new System.Drawing.Size(121, 13);
            this.shiftPlanDayContent.TabIndex = 15;
            this.shiftPlanDayContent.Text = "Wochentag, Tag Monat";
            // 
            // shiftPlanDayLabel
            // 
            this.shiftPlanDayLabel.AutoSize = true;
            this.shiftPlanDayLabel.Location = new System.Drawing.Point(7, 29);
            this.shiftPlanDayLabel.Name = "shiftPlanDayLabel";
            this.shiftPlanDayLabel.Size = new System.Drawing.Size(26, 13);
            this.shiftPlanDayLabel.TabIndex = 14;
            this.shiftPlanDayLabel.Text = "Tag";
            // 
            // shiftPlanShiftTypeLabel
            // 
            this.shiftPlanShiftTypeLabel.AutoSize = true;
            this.shiftPlanShiftTypeLabel.Location = new System.Drawing.Point(525, 28);
            this.shiftPlanShiftTypeLabel.Name = "shiftPlanShiftTypeLabel";
            this.shiftPlanShiftTypeLabel.Size = new System.Drawing.Size(64, 13);
            this.shiftPlanShiftTypeLabel.TabIndex = 13;
            this.shiftPlanShiftTypeLabel.Text = "Schicht Typ";
            // 
            // shiftPlanShiftEndLabel
            // 
            this.shiftPlanShiftEndLabel.AutoSize = true;
            this.shiftPlanShiftEndLabel.Location = new System.Drawing.Point(422, 28);
            this.shiftPlanShiftEndLabel.Name = "shiftPlanShiftEndLabel";
            this.shiftPlanShiftEndLabel.Size = new System.Drawing.Size(71, 13);
            this.shiftPlanShiftEndLabel.TabIndex = 12;
            this.shiftPlanShiftEndLabel.Text = "Schicht Ende";
            // 
            // shiftPlanShiftStartLabel
            // 
            this.shiftPlanShiftStartLabel.AutoSize = true;
            this.shiftPlanShiftStartLabel.Location = new System.Drawing.Point(315, 28);
            this.shiftPlanShiftStartLabel.Name = "shiftPlanShiftStartLabel";
            this.shiftPlanShiftStartLabel.Size = new System.Drawing.Size(68, 13);
            this.shiftPlanShiftStartLabel.TabIndex = 11;
            this.shiftPlanShiftStartLabel.Text = "Schicht Start";
            // 
            // shiftPlanShiftTypeTextBox
            // 
            this.shiftPlanShiftTypeTextBox.Location = new System.Drawing.Point(528, 47);
            this.shiftPlanShiftTypeTextBox.Name = "shiftPlanShiftTypeTextBox";
            this.shiftPlanShiftTypeTextBox.Size = new System.Drawing.Size(100, 20);
            this.shiftPlanShiftTypeTextBox.TabIndex = 10;
            // 
            // shiftPlanShiftEndTextBox
            // 
            this.shiftPlanShiftEndTextBox.Location = new System.Drawing.Point(422, 47);
            this.shiftPlanShiftEndTextBox.Name = "shiftPlanShiftEndTextBox";
            this.shiftPlanShiftEndTextBox.Size = new System.Drawing.Size(100, 20);
            this.shiftPlanShiftEndTextBox.TabIndex = 9;
            // 
            // shiftPlanShiftStartTextBox
            // 
            this.shiftPlanShiftStartTextBox.Location = new System.Drawing.Point(315, 47);
            this.shiftPlanShiftStartTextBox.Name = "shiftPlanShiftStartTextBox";
            this.shiftPlanShiftStartTextBox.Size = new System.Drawing.Size(100, 20);
            this.shiftPlanShiftStartTextBox.TabIndex = 8;
            // 
            // shiftPlanDeleteShiftButton
            // 
            this.shiftPlanDeleteShiftButton.Location = new System.Drawing.Point(902, 45);
            this.shiftPlanDeleteShiftButton.Name = "shiftPlanDeleteShiftButton";
            this.shiftPlanDeleteShiftButton.Size = new System.Drawing.Size(75, 23);
            this.shiftPlanDeleteShiftButton.TabIndex = 7;
            this.shiftPlanDeleteShiftButton.Text = "löschen";
            this.shiftPlanDeleteShiftButton.UseVisualStyleBackColor = true;
            this.shiftPlanDeleteShiftButton.Click += new System.EventHandler(this.shiftPlanDeleteShiftButton_Click);
            // 
            // shiftPlanDescriptionLabel
            // 
            this.shiftPlanDescriptionLabel.AutoSize = true;
            this.shiftPlanDescriptionLabel.Location = new System.Drawing.Point(631, 28);
            this.shiftPlanDescriptionLabel.Name = "shiftPlanDescriptionLabel";
            this.shiftPlanDescriptionLabel.Size = new System.Drawing.Size(72, 13);
            this.shiftPlanDescriptionLabel.TabIndex = 6;
            this.shiftPlanDescriptionLabel.Text = "Beschreibung";
            // 
            // shiftPlanPersonNameLabel
            // 
            this.shiftPlanPersonNameLabel.AutoSize = true;
            this.shiftPlanPersonNameLabel.Location = new System.Drawing.Point(131, 28);
            this.shiftPlanPersonNameLabel.Name = "shiftPlanPersonNameLabel";
            this.shiftPlanPersonNameLabel.Size = new System.Drawing.Size(40, 13);
            this.shiftPlanPersonNameLabel.TabIndex = 5;
            this.shiftPlanPersonNameLabel.Text = "Person";
            // 
            // shiftPlanDescriptionTextBox
            // 
            this.shiftPlanDescriptionTextBox.Location = new System.Drawing.Point(634, 47);
            this.shiftPlanDescriptionTextBox.Name = "shiftPlanDescriptionTextBox";
            this.shiftPlanDescriptionTextBox.Size = new System.Drawing.Size(100, 20);
            this.shiftPlanDescriptionTextBox.TabIndex = 4;
            // 
            // shiftPlanPersonComboBox
            // 
            this.shiftPlanPersonComboBox.FormattingEnabled = true;
            this.shiftPlanPersonComboBox.Location = new System.Drawing.Point(134, 47);
            this.shiftPlanPersonComboBox.Name = "shiftPlanPersonComboBox";
            this.shiftPlanPersonComboBox.Size = new System.Drawing.Size(174, 21);
            this.shiftPlanPersonComboBox.TabIndex = 3;
            // 
            // shiftplanSaveChangesButton
            // 
            this.shiftplanSaveChangesButton.Location = new System.Drawing.Point(740, 45);
            this.shiftplanSaveChangesButton.Name = "shiftplanSaveChangesButton";
            this.shiftplanSaveChangesButton.Size = new System.Drawing.Size(75, 23);
            this.shiftplanSaveChangesButton.TabIndex = 2;
            this.shiftplanSaveChangesButton.Text = "speichern";
            this.shiftplanSaveChangesButton.UseVisualStyleBackColor = true;
            this.shiftplanSaveChangesButton.Click += new System.EventHandler(this.shiftplanSaveChangesButton_Click);
            // 
            // createShiftPlan
            // 
            this.createShiftPlan.Location = new System.Drawing.Point(160, 2);
            this.createShiftPlan.Name = "createShiftPlan";
            this.createShiftPlan.Size = new System.Drawing.Size(75, 23);
            this.createShiftPlan.TabIndex = 1;
            this.createShiftPlan.Text = "erstellen";
            this.createShiftPlan.UseVisualStyleBackColor = true;
            this.createShiftPlan.Click += new System.EventHandler(this.createShiftPlan_Click);
            // 
            // shiftPlanTable
            // 
            this.shiftPlanTable.AutoScroll = true;
            this.shiftPlanTable.AutoSize = true;
            this.shiftPlanTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.shiftPlanTable.ColumnCount = 3;
            this.shiftPlanTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.shiftPlanTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.shiftPlanTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.shiftPlanTable.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.shiftPlanTable.Location = new System.Drawing.Point(3, 508);
            this.shiftPlanTable.Margin = new System.Windows.Forms.Padding(0);
            this.shiftPlanTable.MaximumSize = new System.Drawing.Size(0, 450);
            this.shiftPlanTable.MinimumSize = new System.Drawing.Size(100, 20);
            this.shiftPlanTable.Name = "shiftPlanTable";
            this.shiftPlanTable.RowCount = 1;
            this.shiftPlanTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.shiftPlanTable.Size = new System.Drawing.Size(1232, 20);
            this.shiftPlanTable.TabIndex = 0;
            // 
            // costsTabPage
            // 
            this.costsTabPage.Controls.Add(this.variableCostsPanel);
            this.costsTabPage.Controls.Add(this.fixCostsPanel);
            this.costsTabPage.Location = new System.Drawing.Point(4, 22);
            this.costsTabPage.Name = "costsTabPage";
            this.costsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.costsTabPage.Size = new System.Drawing.Size(1238, 531);
            this.costsTabPage.TabIndex = 5;
            this.costsTabPage.Text = "Kosten";
            this.costsTabPage.UseVisualStyleBackColor = true;
            this.costsTabPage.Resize += new System.EventHandler(this.costsTabPage_Resize);
            // 
            // variableCostsPanel
            // 
            this.variableCostsPanel.Controls.Add(this.variableCostsLabelButtonPanel);
            this.variableCostsPanel.Controls.Add(this.variableCostsDataGridView);
            this.variableCostsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.variableCostsPanel.Location = new System.Drawing.Point(625, 3);
            this.variableCostsPanel.Name = "variableCostsPanel";
            this.variableCostsPanel.Size = new System.Drawing.Size(610, 525);
            this.variableCostsPanel.TabIndex = 1;
            // 
            // variableCostsLabelButtonPanel
            // 
            this.variableCostsLabelButtonPanel.Controls.Add(this.variableCostsSaveButton);
            this.variableCostsLabelButtonPanel.Controls.Add(this.variableCostsLabel);
            this.variableCostsLabelButtonPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.variableCostsLabelButtonPanel.Location = new System.Drawing.Point(0, 0);
            this.variableCostsLabelButtonPanel.Name = "variableCostsLabelButtonPanel";
            this.variableCostsLabelButtonPanel.Size = new System.Drawing.Size(610, 29);
            this.variableCostsLabelButtonPanel.TabIndex = 1;
            // 
            // variableCostsSaveButton
            // 
            this.variableCostsSaveButton.Location = new System.Drawing.Point(138, 6);
            this.variableCostsSaveButton.Name = "variableCostsSaveButton";
            this.variableCostsSaveButton.Size = new System.Drawing.Size(75, 23);
            this.variableCostsSaveButton.TabIndex = 1;
            this.variableCostsSaveButton.Text = "Speichern";
            this.variableCostsSaveButton.UseVisualStyleBackColor = true;
            this.variableCostsSaveButton.Click += new System.EventHandler(this.variableCostsSaveButton_Click);
            // 
            // variableCostsLabel
            // 
            this.variableCostsLabel.AutoSize = true;
            this.variableCostsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.variableCostsLabel.Location = new System.Drawing.Point(5, 9);
            this.variableCostsLabel.Name = "variableCostsLabel";
            this.variableCostsLabel.Size = new System.Drawing.Size(127, 20);
            this.variableCostsLabel.TabIndex = 0;
            this.variableCostsLabel.Text = "Variable Kosten";
            // 
            // variableCostsDataGridView
            // 
            this.variableCostsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.variableCostsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.variableCostsPaydayColumn,
            this.variableCostsTypeColumn,
            this.variableCostsDescriptionColumn,
            this.variableCostsAmountColumn});
            this.variableCostsDataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.variableCostsDataGridView.Location = new System.Drawing.Point(0, 35);
            this.variableCostsDataGridView.Name = "variableCostsDataGridView";
            this.variableCostsDataGridView.Size = new System.Drawing.Size(610, 490);
            this.variableCostsDataGridView.TabIndex = 0;
            // 
            // variableCostsPaydayColumn
            // 
            this.variableCostsPaydayColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.variableCostsPaydayColumn.HeaderText = "Bezahl Tag";
            this.variableCostsPaydayColumn.Name = "variableCostsPaydayColumn";
            // 
            // variableCostsTypeColumn
            // 
            this.variableCostsTypeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.variableCostsTypeColumn.HeaderText = "Typ";
            this.variableCostsTypeColumn.Name = "variableCostsTypeColumn";
            // 
            // variableCostsDescriptionColumn
            // 
            this.variableCostsDescriptionColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.variableCostsDescriptionColumn.HeaderText = "Beschreibung";
            this.variableCostsDescriptionColumn.Name = "variableCostsDescriptionColumn";
            // 
            // variableCostsAmountColumn
            // 
            this.variableCostsAmountColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.variableCostsAmountColumn.HeaderText = "Betrag";
            this.variableCostsAmountColumn.Name = "variableCostsAmountColumn";
            // 
            // fixCostsPanel
            // 
            this.fixCostsPanel.BackColor = System.Drawing.Color.Transparent;
            this.fixCostsPanel.Controls.Add(this.fixCostsLabelButtonPanel);
            this.fixCostsPanel.Controls.Add(this.fixCostsDataGridView);
            this.fixCostsPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.fixCostsPanel.Location = new System.Drawing.Point(3, 3);
            this.fixCostsPanel.Name = "fixCostsPanel";
            this.fixCostsPanel.Size = new System.Drawing.Size(610, 525);
            this.fixCostsPanel.TabIndex = 0;
            // 
            // fixCostsLabelButtonPanel
            // 
            this.fixCostsLabelButtonPanel.Controls.Add(this.fixCostsLoadFromOtherMonthButton);
            this.fixCostsLabelButtonPanel.Controls.Add(this.fixCostsSaveButton);
            this.fixCostsLabelButtonPanel.Controls.Add(this.fixCostsLabel);
            this.fixCostsLabelButtonPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.fixCostsLabelButtonPanel.Location = new System.Drawing.Point(0, 0);
            this.fixCostsLabelButtonPanel.Name = "fixCostsLabelButtonPanel";
            this.fixCostsLabelButtonPanel.Size = new System.Drawing.Size(610, 29);
            this.fixCostsLabelButtonPanel.TabIndex = 1;
            // 
            // fixCostsLoadFromOtherMonthButton
            // 
            this.fixCostsLoadFromOtherMonthButton.Location = new System.Drawing.Point(180, 6);
            this.fixCostsLoadFromOtherMonthButton.Name = "fixCostsLoadFromOtherMonthButton";
            this.fixCostsLoadFromOtherMonthButton.Size = new System.Drawing.Size(144, 23);
            this.fixCostsLoadFromOtherMonthButton.TabIndex = 2;
            this.fixCostsLoadFromOtherMonthButton.Text = "von anderem Monat laden";
            this.fixCostsLoadFromOtherMonthButton.UseVisualStyleBackColor = true;
            this.fixCostsLoadFromOtherMonthButton.Click += new System.EventHandler(this.fixCostsLoadFromOtherMonthButton_Click);
            // 
            // fixCostsSaveButton
            // 
            this.fixCostsSaveButton.Location = new System.Drawing.Point(96, 6);
            this.fixCostsSaveButton.Name = "fixCostsSaveButton";
            this.fixCostsSaveButton.Size = new System.Drawing.Size(75, 23);
            this.fixCostsSaveButton.TabIndex = 1;
            this.fixCostsSaveButton.Text = "Speichern";
            this.fixCostsSaveButton.UseVisualStyleBackColor = true;
            this.fixCostsSaveButton.Click += new System.EventHandler(this.fixCostsSaveButton_Click);
            // 
            // fixCostsLabel
            // 
            this.fixCostsLabel.AutoSize = true;
            this.fixCostsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fixCostsLabel.Location = new System.Drawing.Point(3, 9);
            this.fixCostsLabel.Name = "fixCostsLabel";
            this.fixCostsLabel.Size = new System.Drawing.Size(88, 20);
            this.fixCostsLabel.TabIndex = 0;
            this.fixCostsLabel.Text = "Fix Kosten";
            // 
            // fixCostsDataGridView
            // 
            this.fixCostsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fixCostsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fixCostsPaydayColumn,
            this.fixCostsTypeColumn,
            this.fixCostsDescriptionColumn,
            this.fixCostsAmountColumn});
            this.fixCostsDataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.fixCostsDataGridView.Location = new System.Drawing.Point(0, 35);
            this.fixCostsDataGridView.Name = "fixCostsDataGridView";
            this.fixCostsDataGridView.Size = new System.Drawing.Size(610, 490);
            this.fixCostsDataGridView.TabIndex = 0;
            // 
            // fixCostsPaydayColumn
            // 
            this.fixCostsPaydayColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fixCostsPaydayColumn.HeaderText = "Bezahl Tag";
            this.fixCostsPaydayColumn.Name = "fixCostsPaydayColumn";
            // 
            // fixCostsTypeColumn
            // 
            this.fixCostsTypeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fixCostsTypeColumn.HeaderText = "Typ";
            this.fixCostsTypeColumn.Name = "fixCostsTypeColumn";
            // 
            // fixCostsDescriptionColumn
            // 
            this.fixCostsDescriptionColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fixCostsDescriptionColumn.HeaderText = "Beschreibung";
            this.fixCostsDescriptionColumn.Name = "fixCostsDescriptionColumn";
            // 
            // fixCostsAmountColumn
            // 
            this.fixCostsAmountColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fixCostsAmountColumn.HeaderText = "Betrag";
            this.fixCostsAmountColumn.Name = "fixCostsAmountColumn";
            // 
            // infoPersonTabPage
            // 
            this.infoPersonTabPage.Controls.Add(this.infoPersonTable);
            this.infoPersonTabPage.Location = new System.Drawing.Point(4, 22);
            this.infoPersonTabPage.Name = "infoPersonTabPage";
            this.infoPersonTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.infoPersonTabPage.Size = new System.Drawing.Size(1238, 531);
            this.infoPersonTabPage.TabIndex = 3;
            this.infoPersonTabPage.Text = "Information Person";
            this.infoPersonTabPage.UseVisualStyleBackColor = true;
            this.infoPersonTabPage.SizeChanged += new System.EventHandler(this.infoPersonTabPage_SizeChanged);
            // 
            // infoPersonTable
            // 
            this.infoPersonTable.AutoScroll = true;
            this.infoPersonTable.AutoSize = true;
            this.infoPersonTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.infoPersonTable.ColumnCount = 6;
            this.infoPersonTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.infoPersonTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.infoPersonTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.infoPersonTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.infoPersonTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.infoPersonTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.infoPersonTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.infoPersonTable.Location = new System.Drawing.Point(3, 3);
            this.infoPersonTable.MinimumSize = new System.Drawing.Size(100, 20);
            this.infoPersonTable.Name = "infoPersonTable";
            this.infoPersonTable.RowCount = 1;
            this.infoPersonTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.infoPersonTable.Size = new System.Drawing.Size(1232, 20);
            this.infoPersonTable.TabIndex = 11;
            // 
            // infoGeneralTabPage
            // 
            this.infoGeneralTabPage.Controls.Add(this.infoGeneralWeekPanel);
            this.infoGeneralTabPage.Controls.Add(this.infoGeneralDayPanel);
            this.infoGeneralTabPage.Controls.Add(this.infoGeneralMonthPanel);
            this.infoGeneralTabPage.Location = new System.Drawing.Point(4, 22);
            this.infoGeneralTabPage.Name = "infoGeneralTabPage";
            this.infoGeneralTabPage.Size = new System.Drawing.Size(1238, 531);
            this.infoGeneralTabPage.TabIndex = 4;
            this.infoGeneralTabPage.Text = "Information Generell";
            this.infoGeneralTabPage.UseVisualStyleBackColor = true;
            this.infoGeneralTabPage.SizeChanged += new System.EventHandler(this.infoGeneralTabPage_SizeChanged);
            // 
            // infoGeneralWeekPanel
            // 
            this.infoGeneralWeekPanel.BackColor = System.Drawing.Color.Silver;
            this.infoGeneralWeekPanel.Controls.Add(this.infoWeekComboBox);
            this.infoGeneralWeekPanel.Controls.Add(this.infoWeekAverageTurnoverDayContent);
            this.infoGeneralWeekPanel.Controls.Add(this.infoWeekAverageTurnoverHourContent);
            this.infoGeneralWeekPanel.Controls.Add(this.infoWeekTurnoverAfterSaleriesContent);
            this.infoGeneralWeekPanel.Controls.Add(this.infoWeekHoursSumContent);
            this.infoGeneralWeekPanel.Controls.Add(this.infoWeekShiftSumContent);
            this.infoGeneralWeekPanel.Controls.Add(this.infoWeekAverageTurnoverDayLabel);
            this.infoGeneralWeekPanel.Controls.Add(this.infoWeekTurnoverAfterSaleriesLabel);
            this.infoGeneralWeekPanel.Controls.Add(this.infoWeekAverageTurnoverHourLabel);
            this.infoGeneralWeekPanel.Controls.Add(this.infoWeekCalculateButton);
            this.infoGeneralWeekPanel.Controls.Add(this.infoWeekTurnover);
            this.infoGeneralWeekPanel.Controls.Add(this.infoWeekTurnoverTextBox);
            this.infoGeneralWeekPanel.Controls.Add(this.infoWeekHoursSumLabel);
            this.infoGeneralWeekPanel.Controls.Add(this.infoWeekShiftSumLabel);
            this.infoGeneralWeekPanel.Controls.Add(this.infoWeekSalerySumLabel);
            this.infoGeneralWeekPanel.Controls.Add(this.infoWeekSalerySumContent);
            this.infoGeneralWeekPanel.Controls.Add(this.infoWeekLabel);
            this.infoGeneralWeekPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoGeneralWeekPanel.Location = new System.Drawing.Point(410, 0);
            this.infoGeneralWeekPanel.Name = "infoGeneralWeekPanel";
            this.infoGeneralWeekPanel.Size = new System.Drawing.Size(418, 531);
            this.infoGeneralWeekPanel.TabIndex = 13;
            // 
            // infoWeekComboBox
            // 
            this.infoWeekComboBox.FormattingEnabled = true;
            this.infoWeekComboBox.Location = new System.Drawing.Point(10, 34);
            this.infoWeekComboBox.Name = "infoWeekComboBox";
            this.infoWeekComboBox.Size = new System.Drawing.Size(305, 21);
            this.infoWeekComboBox.TabIndex = 40;
            this.infoWeekComboBox.SelectedIndexChanged += new System.EventHandler(this.infoWeekComboBox_SelectedIndexChanged);
            // 
            // infoWeekAverageTurnoverDayContent
            // 
            this.infoWeekAverageTurnoverDayContent.AutoSize = true;
            this.infoWeekAverageTurnoverDayContent.Location = new System.Drawing.Point(237, 281);
            this.infoWeekAverageTurnoverDayContent.Name = "infoWeekAverageTurnoverDayContent";
            this.infoWeekAverageTurnoverDayContent.Size = new System.Drawing.Size(19, 13);
            this.infoWeekAverageTurnoverDayContent.TabIndex = 39;
            this.infoWeekAverageTurnoverDayContent.Text = "0€";
            // 
            // infoWeekAverageTurnoverHourContent
            // 
            this.infoWeekAverageTurnoverHourContent.AutoSize = true;
            this.infoWeekAverageTurnoverHourContent.Location = new System.Drawing.Point(237, 251);
            this.infoWeekAverageTurnoverHourContent.Name = "infoWeekAverageTurnoverHourContent";
            this.infoWeekAverageTurnoverHourContent.Size = new System.Drawing.Size(19, 13);
            this.infoWeekAverageTurnoverHourContent.TabIndex = 38;
            this.infoWeekAverageTurnoverHourContent.Text = "0€";
            // 
            // infoWeekTurnoverAfterSaleriesContent
            // 
            this.infoWeekTurnoverAfterSaleriesContent.AutoSize = true;
            this.infoWeekTurnoverAfterSaleriesContent.Location = new System.Drawing.Point(237, 218);
            this.infoWeekTurnoverAfterSaleriesContent.Name = "infoWeekTurnoverAfterSaleriesContent";
            this.infoWeekTurnoverAfterSaleriesContent.Size = new System.Drawing.Size(19, 13);
            this.infoWeekTurnoverAfterSaleriesContent.TabIndex = 37;
            this.infoWeekTurnoverAfterSaleriesContent.Text = "0€";
            // 
            // infoWeekHoursSumContent
            // 
            this.infoWeekHoursSumContent.AutoSize = true;
            this.infoWeekHoursSumContent.Location = new System.Drawing.Point(237, 129);
            this.infoWeekHoursSumContent.Name = "infoWeekHoursSumContent";
            this.infoWeekHoursSumContent.Size = new System.Drawing.Size(13, 13);
            this.infoWeekHoursSumContent.TabIndex = 36;
            this.infoWeekHoursSumContent.Text = "0";
            // 
            // infoWeekShiftSumContent
            // 
            this.infoWeekShiftSumContent.AutoSize = true;
            this.infoWeekShiftSumContent.Location = new System.Drawing.Point(237, 101);
            this.infoWeekShiftSumContent.Name = "infoWeekShiftSumContent";
            this.infoWeekShiftSumContent.Size = new System.Drawing.Size(13, 13);
            this.infoWeekShiftSumContent.TabIndex = 35;
            this.infoWeekShiftSumContent.Text = "0";
            // 
            // infoWeekAverageTurnoverDayLabel
            // 
            this.infoWeekAverageTurnoverDayLabel.AutoSize = true;
            this.infoWeekAverageTurnoverDayLabel.Location = new System.Drawing.Point(7, 281);
            this.infoWeekAverageTurnoverDayLabel.Name = "infoWeekAverageTurnoverDayLabel";
            this.infoWeekAverageTurnoverDayLabel.Size = new System.Drawing.Size(128, 13);
            this.infoWeekAverageTurnoverDayLabel.TabIndex = 34;
            this.infoWeekAverageTurnoverDayLabel.Text = "Durschn. Umsatz pro Tag";
            // 
            // infoWeekTurnoverAfterSaleriesLabel
            // 
            this.infoWeekTurnoverAfterSaleriesLabel.AutoSize = true;
            this.infoWeekTurnoverAfterSaleriesLabel.Location = new System.Drawing.Point(7, 218);
            this.infoWeekTurnoverAfterSaleriesLabel.Name = "infoWeekTurnoverAfterSaleriesLabel";
            this.infoWeekTurnoverAfterSaleriesLabel.Size = new System.Drawing.Size(145, 13);
            this.infoWeekTurnoverAfterSaleriesLabel.TabIndex = 33;
            this.infoWeekTurnoverAfterSaleriesLabel.Text = "Umsatz nach Abzug Gehälter";
            // 
            // infoWeekAverageTurnoverHourLabel
            // 
            this.infoWeekAverageTurnoverHourLabel.AutoSize = true;
            this.infoWeekAverageTurnoverHourLabel.Location = new System.Drawing.Point(7, 251);
            this.infoWeekAverageTurnoverHourLabel.Name = "infoWeekAverageTurnoverHourLabel";
            this.infoWeekAverageTurnoverHourLabel.Size = new System.Drawing.Size(143, 13);
            this.infoWeekAverageTurnoverHourLabel.TabIndex = 32;
            this.infoWeekAverageTurnoverHourLabel.Text = "Durschn. Umsatz pro Stunde";
            // 
            // infoWeekCalculateButton
            // 
            this.infoWeekCalculateButton.Location = new System.Drawing.Point(240, 175);
            this.infoWeekCalculateButton.Name = "infoWeekCalculateButton";
            this.infoWeekCalculateButton.Size = new System.Drawing.Size(75, 23);
            this.infoWeekCalculateButton.TabIndex = 31;
            this.infoWeekCalculateButton.Text = "berechnen";
            this.infoWeekCalculateButton.UseVisualStyleBackColor = true;
            this.infoWeekCalculateButton.Click += new System.EventHandler(this.infoWeekCalculateButton_Click);
            // 
            // infoWeekTurnover
            // 
            this.infoWeekTurnover.AutoSize = true;
            this.infoWeekTurnover.Location = new System.Drawing.Point(7, 159);
            this.infoWeekTurnover.Name = "infoWeekTurnover";
            this.infoWeekTurnover.Size = new System.Drawing.Size(81, 13);
            this.infoWeekTurnover.TabIndex = 30;
            this.infoWeekTurnover.Text = "Wochenumsatz";
            // 
            // infoWeekTurnoverTextBox
            // 
            this.infoWeekTurnoverTextBox.Location = new System.Drawing.Point(10, 178);
            this.infoWeekTurnoverTextBox.Name = "infoWeekTurnoverTextBox";
            this.infoWeekTurnoverTextBox.Size = new System.Drawing.Size(119, 20);
            this.infoWeekTurnoverTextBox.TabIndex = 29;
            // 
            // infoWeekHoursSumLabel
            // 
            this.infoWeekHoursSumLabel.AutoSize = true;
            this.infoWeekHoursSumLabel.Location = new System.Drawing.Point(7, 129);
            this.infoWeekHoursSumLabel.Name = "infoWeekHoursSumLabel";
            this.infoWeekHoursSumLabel.Size = new System.Drawing.Size(85, 13);
            this.infoWeekHoursSumLabel.TabIndex = 28;
            this.infoWeekHoursSumLabel.Text = "Summe Stunden";
            // 
            // infoWeekShiftSumLabel
            // 
            this.infoWeekShiftSumLabel.AutoSize = true;
            this.infoWeekShiftSumLabel.Location = new System.Drawing.Point(7, 101);
            this.infoWeekShiftSumLabel.Name = "infoWeekShiftSumLabel";
            this.infoWeekShiftSumLabel.Size = new System.Drawing.Size(93, 13);
            this.infoWeekShiftSumLabel.TabIndex = 27;
            this.infoWeekShiftSumLabel.Text = "Summe Schichten";
            // 
            // infoWeekSalerySumLabel
            // 
            this.infoWeekSalerySumLabel.AutoSize = true;
            this.infoWeekSalerySumLabel.Location = new System.Drawing.Point(7, 74);
            this.infoWeekSalerySumLabel.Name = "infoWeekSalerySumLabel";
            this.infoWeekSalerySumLabel.Size = new System.Drawing.Size(86, 13);
            this.infoWeekSalerySumLabel.TabIndex = 25;
            this.infoWeekSalerySumLabel.Text = "Gesamt Gehälter";
            // 
            // infoWeekSalerySumContent
            // 
            this.infoWeekSalerySumContent.AutoSize = true;
            this.infoWeekSalerySumContent.Location = new System.Drawing.Point(237, 74);
            this.infoWeekSalerySumContent.Name = "infoWeekSalerySumContent";
            this.infoWeekSalerySumContent.Size = new System.Drawing.Size(19, 13);
            this.infoWeekSalerySumContent.TabIndex = 26;
            this.infoWeekSalerySumContent.Text = "0€";
            // 
            // infoWeekLabel
            // 
            this.infoWeekLabel.AutoSize = true;
            this.infoWeekLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoWeekLabel.Location = new System.Drawing.Point(6, 10);
            this.infoWeekLabel.Name = "infoWeekLabel";
            this.infoWeekLabel.Size = new System.Drawing.Size(61, 20);
            this.infoWeekLabel.TabIndex = 12;
            this.infoWeekLabel.Text = "Woche";
            // 
            // infoGeneralDayPanel
            // 
            this.infoGeneralDayPanel.BackColor = System.Drawing.Color.LightGray;
            this.infoGeneralDayPanel.Controls.Add(this.infoDayComboBox);
            this.infoGeneralDayPanel.Controls.Add(this.infoDayAverageTurnoverHourContent);
            this.infoGeneralDayPanel.Controls.Add(this.infoDayTurnoverAfterSaleriesContent);
            this.infoGeneralDayPanel.Controls.Add(this.infoDayHoursSumContent);
            this.infoGeneralDayPanel.Controls.Add(this.infoDayShiftSumContent);
            this.infoGeneralDayPanel.Controls.Add(this.infoDayTurnoverAfterSaleriesLabel);
            this.infoGeneralDayPanel.Controls.Add(this.infoDayAverageTurnoverHourLabel);
            this.infoGeneralDayPanel.Controls.Add(this.infoDayCalculateButton);
            this.infoGeneralDayPanel.Controls.Add(this.infoDayTurnover);
            this.infoGeneralDayPanel.Controls.Add(this.infoDayTurnoverTextBox);
            this.infoGeneralDayPanel.Controls.Add(this.infoDayHoursSumLabel);
            this.infoGeneralDayPanel.Controls.Add(this.infoDayShiftSumLabel);
            this.infoGeneralDayPanel.Controls.Add(this.infoDaySalerySumLabel);
            this.infoGeneralDayPanel.Controls.Add(this.infoDaySalerySumContent);
            this.infoGeneralDayPanel.Controls.Add(this.infoDayLabel);
            this.infoGeneralDayPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.infoGeneralDayPanel.Location = new System.Drawing.Point(828, 0);
            this.infoGeneralDayPanel.Name = "infoGeneralDayPanel";
            this.infoGeneralDayPanel.Size = new System.Drawing.Size(410, 531);
            this.infoGeneralDayPanel.TabIndex = 12;
            // 
            // infoDayComboBox
            // 
            this.infoDayComboBox.FormattingEnabled = true;
            this.infoDayComboBox.Location = new System.Drawing.Point(10, 34);
            this.infoDayComboBox.Name = "infoDayComboBox";
            this.infoDayComboBox.Size = new System.Drawing.Size(121, 21);
            this.infoDayComboBox.TabIndex = 56;
            this.infoDayComboBox.SelectedIndexChanged += new System.EventHandler(this.infoDayComboBox_SelectedIndexChanged);
            // 
            // infoDayAverageTurnoverHourContent
            // 
            this.infoDayAverageTurnoverHourContent.AutoSize = true;
            this.infoDayAverageTurnoverHourContent.Location = new System.Drawing.Point(237, 251);
            this.infoDayAverageTurnoverHourContent.Name = "infoDayAverageTurnoverHourContent";
            this.infoDayAverageTurnoverHourContent.Size = new System.Drawing.Size(19, 13);
            this.infoDayAverageTurnoverHourContent.TabIndex = 54;
            this.infoDayAverageTurnoverHourContent.Text = "0€";
            // 
            // infoDayTurnoverAfterSaleriesContent
            // 
            this.infoDayTurnoverAfterSaleriesContent.AutoSize = true;
            this.infoDayTurnoverAfterSaleriesContent.Location = new System.Drawing.Point(237, 218);
            this.infoDayTurnoverAfterSaleriesContent.Name = "infoDayTurnoverAfterSaleriesContent";
            this.infoDayTurnoverAfterSaleriesContent.Size = new System.Drawing.Size(19, 13);
            this.infoDayTurnoverAfterSaleriesContent.TabIndex = 53;
            this.infoDayTurnoverAfterSaleriesContent.Text = "0€";
            // 
            // infoDayHoursSumContent
            // 
            this.infoDayHoursSumContent.AutoSize = true;
            this.infoDayHoursSumContent.Location = new System.Drawing.Point(237, 129);
            this.infoDayHoursSumContent.Name = "infoDayHoursSumContent";
            this.infoDayHoursSumContent.Size = new System.Drawing.Size(13, 13);
            this.infoDayHoursSumContent.TabIndex = 52;
            this.infoDayHoursSumContent.Text = "0";
            // 
            // infoDayShiftSumContent
            // 
            this.infoDayShiftSumContent.AutoSize = true;
            this.infoDayShiftSumContent.Location = new System.Drawing.Point(237, 101);
            this.infoDayShiftSumContent.Name = "infoDayShiftSumContent";
            this.infoDayShiftSumContent.Size = new System.Drawing.Size(13, 13);
            this.infoDayShiftSumContent.TabIndex = 51;
            this.infoDayShiftSumContent.Text = "0";
            // 
            // infoDayTurnoverAfterSaleriesLabel
            // 
            this.infoDayTurnoverAfterSaleriesLabel.AutoSize = true;
            this.infoDayTurnoverAfterSaleriesLabel.Location = new System.Drawing.Point(7, 218);
            this.infoDayTurnoverAfterSaleriesLabel.Name = "infoDayTurnoverAfterSaleriesLabel";
            this.infoDayTurnoverAfterSaleriesLabel.Size = new System.Drawing.Size(145, 13);
            this.infoDayTurnoverAfterSaleriesLabel.TabIndex = 49;
            this.infoDayTurnoverAfterSaleriesLabel.Text = "Umsatz nach Abzug Gehälter";
            // 
            // infoDayAverageTurnoverHourLabel
            // 
            this.infoDayAverageTurnoverHourLabel.AutoSize = true;
            this.infoDayAverageTurnoverHourLabel.Location = new System.Drawing.Point(7, 251);
            this.infoDayAverageTurnoverHourLabel.Name = "infoDayAverageTurnoverHourLabel";
            this.infoDayAverageTurnoverHourLabel.Size = new System.Drawing.Size(143, 13);
            this.infoDayAverageTurnoverHourLabel.TabIndex = 48;
            this.infoDayAverageTurnoverHourLabel.Text = "Durschn. Umsatz pro Stunde";
            // 
            // infoDayCalculateButton
            // 
            this.infoDayCalculateButton.Location = new System.Drawing.Point(240, 175);
            this.infoDayCalculateButton.Name = "infoDayCalculateButton";
            this.infoDayCalculateButton.Size = new System.Drawing.Size(75, 23);
            this.infoDayCalculateButton.TabIndex = 47;
            this.infoDayCalculateButton.Text = "berechnen";
            this.infoDayCalculateButton.UseVisualStyleBackColor = true;
            this.infoDayCalculateButton.Click += new System.EventHandler(this.infoDayCalculateButton_Click);
            // 
            // infoDayTurnover
            // 
            this.infoDayTurnover.AutoSize = true;
            this.infoDayTurnover.Location = new System.Drawing.Point(7, 159);
            this.infoDayTurnover.Name = "infoDayTurnover";
            this.infoDayTurnover.Size = new System.Drawing.Size(70, 13);
            this.infoDayTurnover.TabIndex = 46;
            this.infoDayTurnover.Text = "Tagesumsatz";
            // 
            // infoDayTurnoverTextBox
            // 
            this.infoDayTurnoverTextBox.Location = new System.Drawing.Point(10, 178);
            this.infoDayTurnoverTextBox.Name = "infoDayTurnoverTextBox";
            this.infoDayTurnoverTextBox.Size = new System.Drawing.Size(119, 20);
            this.infoDayTurnoverTextBox.TabIndex = 45;
            // 
            // infoDayHoursSumLabel
            // 
            this.infoDayHoursSumLabel.AutoSize = true;
            this.infoDayHoursSumLabel.Location = new System.Drawing.Point(7, 129);
            this.infoDayHoursSumLabel.Name = "infoDayHoursSumLabel";
            this.infoDayHoursSumLabel.Size = new System.Drawing.Size(85, 13);
            this.infoDayHoursSumLabel.TabIndex = 44;
            this.infoDayHoursSumLabel.Text = "Summe Stunden";
            // 
            // infoDayShiftSumLabel
            // 
            this.infoDayShiftSumLabel.AutoSize = true;
            this.infoDayShiftSumLabel.Location = new System.Drawing.Point(7, 101);
            this.infoDayShiftSumLabel.Name = "infoDayShiftSumLabel";
            this.infoDayShiftSumLabel.Size = new System.Drawing.Size(93, 13);
            this.infoDayShiftSumLabel.TabIndex = 43;
            this.infoDayShiftSumLabel.Text = "Summe Schichten";
            // 
            // infoDaySalerySumLabel
            // 
            this.infoDaySalerySumLabel.AutoSize = true;
            this.infoDaySalerySumLabel.Location = new System.Drawing.Point(7, 74);
            this.infoDaySalerySumLabel.Name = "infoDaySalerySumLabel";
            this.infoDaySalerySumLabel.Size = new System.Drawing.Size(86, 13);
            this.infoDaySalerySumLabel.TabIndex = 41;
            this.infoDaySalerySumLabel.Text = "Gesamt Gehälter";
            // 
            // infoDaySalerySumContent
            // 
            this.infoDaySalerySumContent.AutoSize = true;
            this.infoDaySalerySumContent.Location = new System.Drawing.Point(237, 74);
            this.infoDaySalerySumContent.Name = "infoDaySalerySumContent";
            this.infoDaySalerySumContent.Size = new System.Drawing.Size(19, 13);
            this.infoDaySalerySumContent.TabIndex = 42;
            this.infoDaySalerySumContent.Text = "0€";
            // 
            // infoDayLabel
            // 
            this.infoDayLabel.AutoSize = true;
            this.infoDayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoDayLabel.Location = new System.Drawing.Point(6, 10);
            this.infoDayLabel.Name = "infoDayLabel";
            this.infoDayLabel.Size = new System.Drawing.Size(37, 20);
            this.infoDayLabel.TabIndex = 13;
            this.infoDayLabel.Text = "Tag";
            // 
            // infoGeneralMonthPanel
            // 
            this.infoGeneralMonthPanel.BackColor = System.Drawing.Color.DarkGray;
            this.infoGeneralMonthPanel.Controls.Add(this.infoMonthCostsSumContent);
            this.infoGeneralMonthPanel.Controls.Add(this.infoMonthVariableCostsSumContent);
            this.infoGeneralMonthPanel.Controls.Add(this.infoMonthFixCostsSumContent);
            this.infoGeneralMonthPanel.Controls.Add(this.infoMonthCostsSumLabel);
            this.infoGeneralMonthPanel.Controls.Add(this.infoMonthVariableCostsSumLabel);
            this.infoGeneralMonthPanel.Controls.Add(this.infoMonthFixCostsSumLabel);
            this.infoGeneralMonthPanel.Controls.Add(this.infoMonthAverageTurnoverDayContent);
            this.infoGeneralMonthPanel.Controls.Add(this.infoMonthAverageTurnoverHourContent);
            this.infoGeneralMonthPanel.Controls.Add(this.infoMonthProfitAfterSaleriesCostsContent);
            this.infoGeneralMonthPanel.Controls.Add(this.infoMonthHoursSumContent);
            this.infoGeneralMonthPanel.Controls.Add(this.infoMonthShiftSumContent);
            this.infoGeneralMonthPanel.Controls.Add(this.infoMonthAverageTurnoverDayLabel);
            this.infoGeneralMonthPanel.Controls.Add(this.infoMonthProfitAfterSaleriesCostsLabel);
            this.infoGeneralMonthPanel.Controls.Add(this.infoMonthAverageTurnoverHourLabel);
            this.infoGeneralMonthPanel.Controls.Add(this.infoMonthCalculateButton);
            this.infoGeneralMonthPanel.Controls.Add(this.infoMonthTurnover);
            this.infoGeneralMonthPanel.Controls.Add(this.infoMonthTurnoverTextBox);
            this.infoGeneralMonthPanel.Controls.Add(this.infoMonthHoursSumLabel);
            this.infoGeneralMonthPanel.Controls.Add(this.infoMonthShiftSumLabel);
            this.infoGeneralMonthPanel.Controls.Add(this.infoMonthLabel);
            this.infoGeneralMonthPanel.Controls.Add(this.infoMonthSalerySumLabel);
            this.infoGeneralMonthPanel.Controls.Add(this.infoMonthSalerySumContent);
            this.infoGeneralMonthPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.infoGeneralMonthPanel.Location = new System.Drawing.Point(0, 0);
            this.infoGeneralMonthPanel.Name = "infoGeneralMonthPanel";
            this.infoGeneralMonthPanel.Size = new System.Drawing.Size(410, 531);
            this.infoGeneralMonthPanel.TabIndex = 11;
            // 
            // infoMonthCostsSumContent
            // 
            this.infoMonthCostsSumContent.AutoSize = true;
            this.infoMonthCostsSumContent.Location = new System.Drawing.Point(238, 209);
            this.infoMonthCostsSumContent.Name = "infoMonthCostsSumContent";
            this.infoMonthCostsSumContent.Size = new System.Drawing.Size(19, 13);
            this.infoMonthCostsSumContent.TabIndex = 30;
            this.infoMonthCostsSumContent.Text = "0€";
            // 
            // infoMonthVariableCostsSumContent
            // 
            this.infoMonthVariableCostsSumContent.AutoSize = true;
            this.infoMonthVariableCostsSumContent.Location = new System.Drawing.Point(238, 185);
            this.infoMonthVariableCostsSumContent.Name = "infoMonthVariableCostsSumContent";
            this.infoMonthVariableCostsSumContent.Size = new System.Drawing.Size(19, 13);
            this.infoMonthVariableCostsSumContent.TabIndex = 29;
            this.infoMonthVariableCostsSumContent.Text = "0€";
            // 
            // infoMonthFixCostsSumContent
            // 
            this.infoMonthFixCostsSumContent.AutoSize = true;
            this.infoMonthFixCostsSumContent.Location = new System.Drawing.Point(238, 159);
            this.infoMonthFixCostsSumContent.Name = "infoMonthFixCostsSumContent";
            this.infoMonthFixCostsSumContent.Size = new System.Drawing.Size(19, 13);
            this.infoMonthFixCostsSumContent.TabIndex = 28;
            this.infoMonthFixCostsSumContent.Text = "0€";
            // 
            // infoMonthCostsSumLabel
            // 
            this.infoMonthCostsSumLabel.AutoSize = true;
            this.infoMonthCostsSumLabel.Location = new System.Drawing.Point(8, 209);
            this.infoMonthCostsSumLabel.Name = "infoMonthCostsSumLabel";
            this.infoMonthCostsSumLabel.Size = new System.Drawing.Size(78, 13);
            this.infoMonthCostsSumLabel.TabIndex = 27;
            this.infoMonthCostsSumLabel.Text = "Summe Kosten";
            // 
            // infoMonthVariableCostsSumLabel
            // 
            this.infoMonthVariableCostsSumLabel.AutoSize = true;
            this.infoMonthVariableCostsSumLabel.Location = new System.Drawing.Point(8, 185);
            this.infoMonthVariableCostsSumLabel.Name = "infoMonthVariableCostsSumLabel";
            this.infoMonthVariableCostsSumLabel.Size = new System.Drawing.Size(119, 13);
            this.infoMonthVariableCostsSumLabel.TabIndex = 26;
            this.infoMonthVariableCostsSumLabel.Text = "Summe Variable Kosten";
            // 
            // infoMonthFixCostsSumLabel
            // 
            this.infoMonthFixCostsSumLabel.AutoSize = true;
            this.infoMonthFixCostsSumLabel.Location = new System.Drawing.Point(8, 159);
            this.infoMonthFixCostsSumLabel.Name = "infoMonthFixCostsSumLabel";
            this.infoMonthFixCostsSumLabel.Size = new System.Drawing.Size(94, 13);
            this.infoMonthFixCostsSumLabel.TabIndex = 25;
            this.infoMonthFixCostsSumLabel.Text = "Summe Fix Kosten";
            // 
            // infoMonthAverageTurnoverDayContent
            // 
            this.infoMonthAverageTurnoverDayContent.AutoSize = true;
            this.infoMonthAverageTurnoverDayContent.Location = new System.Drawing.Point(238, 330);
            this.infoMonthAverageTurnoverDayContent.Name = "infoMonthAverageTurnoverDayContent";
            this.infoMonthAverageTurnoverDayContent.Size = new System.Drawing.Size(19, 13);
            this.infoMonthAverageTurnoverDayContent.TabIndex = 24;
            this.infoMonthAverageTurnoverDayContent.Text = "0€";
            // 
            // infoMonthAverageTurnoverHourContent
            // 
            this.infoMonthAverageTurnoverHourContent.AutoSize = true;
            this.infoMonthAverageTurnoverHourContent.Location = new System.Drawing.Point(238, 300);
            this.infoMonthAverageTurnoverHourContent.Name = "infoMonthAverageTurnoverHourContent";
            this.infoMonthAverageTurnoverHourContent.Size = new System.Drawing.Size(19, 13);
            this.infoMonthAverageTurnoverHourContent.TabIndex = 23;
            this.infoMonthAverageTurnoverHourContent.Text = "0€";
            // 
            // infoMonthProfitAfterSaleriesCostsContent
            // 
            this.infoMonthProfitAfterSaleriesCostsContent.AutoSize = true;
            this.infoMonthProfitAfterSaleriesCostsContent.Location = new System.Drawing.Point(238, 359);
            this.infoMonthProfitAfterSaleriesCostsContent.Name = "infoMonthProfitAfterSaleriesCostsContent";
            this.infoMonthProfitAfterSaleriesCostsContent.Size = new System.Drawing.Size(19, 13);
            this.infoMonthProfitAfterSaleriesCostsContent.TabIndex = 22;
            this.infoMonthProfitAfterSaleriesCostsContent.Text = "0€";
            // 
            // infoMonthHoursSumContent
            // 
            this.infoMonthHoursSumContent.AutoSize = true;
            this.infoMonthHoursSumContent.Location = new System.Drawing.Point(238, 129);
            this.infoMonthHoursSumContent.Name = "infoMonthHoursSumContent";
            this.infoMonthHoursSumContent.Size = new System.Drawing.Size(13, 13);
            this.infoMonthHoursSumContent.TabIndex = 21;
            this.infoMonthHoursSumContent.Text = "0";
            // 
            // infoMonthShiftSumContent
            // 
            this.infoMonthShiftSumContent.AutoSize = true;
            this.infoMonthShiftSumContent.Location = new System.Drawing.Point(238, 101);
            this.infoMonthShiftSumContent.Name = "infoMonthShiftSumContent";
            this.infoMonthShiftSumContent.Size = new System.Drawing.Size(13, 13);
            this.infoMonthShiftSumContent.TabIndex = 20;
            this.infoMonthShiftSumContent.Text = "0";
            // 
            // infoMonthAverageTurnoverDayLabel
            // 
            this.infoMonthAverageTurnoverDayLabel.AutoSize = true;
            this.infoMonthAverageTurnoverDayLabel.Location = new System.Drawing.Point(8, 330);
            this.infoMonthAverageTurnoverDayLabel.Name = "infoMonthAverageTurnoverDayLabel";
            this.infoMonthAverageTurnoverDayLabel.Size = new System.Drawing.Size(128, 13);
            this.infoMonthAverageTurnoverDayLabel.TabIndex = 19;
            this.infoMonthAverageTurnoverDayLabel.Text = "Durschn. Umsatz pro Tag";
            // 
            // infoMonthProfitAfterSaleriesCostsLabel
            // 
            this.infoMonthProfitAfterSaleriesCostsLabel.AutoSize = true;
            this.infoMonthProfitAfterSaleriesCostsLabel.Location = new System.Drawing.Point(9, 359);
            this.infoMonthProfitAfterSaleriesCostsLabel.Name = "infoMonthProfitAfterSaleriesCostsLabel";
            this.infoMonthProfitAfterSaleriesCostsLabel.Size = new System.Drawing.Size(203, 13);
            this.infoMonthProfitAfterSaleriesCostsLabel.TabIndex = 18;
            this.infoMonthProfitAfterSaleriesCostsLabel.Text = "Gewinn nach Abzug Gehälter und Kosten";
            // 
            // infoMonthAverageTurnoverHourLabel
            // 
            this.infoMonthAverageTurnoverHourLabel.AutoSize = true;
            this.infoMonthAverageTurnoverHourLabel.Location = new System.Drawing.Point(8, 300);
            this.infoMonthAverageTurnoverHourLabel.Name = "infoMonthAverageTurnoverHourLabel";
            this.infoMonthAverageTurnoverHourLabel.Size = new System.Drawing.Size(143, 13);
            this.infoMonthAverageTurnoverHourLabel.TabIndex = 17;
            this.infoMonthAverageTurnoverHourLabel.Text = "Durschn. Umsatz pro Stunde";
            // 
            // infoMonthCalculateButton
            // 
            this.infoMonthCalculateButton.Location = new System.Drawing.Point(242, 257);
            this.infoMonthCalculateButton.Name = "infoMonthCalculateButton";
            this.infoMonthCalculateButton.Size = new System.Drawing.Size(75, 23);
            this.infoMonthCalculateButton.TabIndex = 16;
            this.infoMonthCalculateButton.Text = "berechnen";
            this.infoMonthCalculateButton.UseVisualStyleBackColor = true;
            this.infoMonthCalculateButton.Click += new System.EventHandler(this.infoMonthCalculateButton_Click);
            // 
            // infoMonthTurnover
            // 
            this.infoMonthTurnover.AutoSize = true;
            this.infoMonthTurnover.Location = new System.Drawing.Point(9, 241);
            this.infoMonthTurnover.Name = "infoMonthTurnover";
            this.infoMonthTurnover.Size = new System.Drawing.Size(75, 13);
            this.infoMonthTurnover.TabIndex = 15;
            this.infoMonthTurnover.Text = "Monatsumsatz";
            // 
            // infoMonthTurnoverTextBox
            // 
            this.infoMonthTurnoverTextBox.Location = new System.Drawing.Point(12, 260);
            this.infoMonthTurnoverTextBox.Name = "infoMonthTurnoverTextBox";
            this.infoMonthTurnoverTextBox.Size = new System.Drawing.Size(119, 20);
            this.infoMonthTurnoverTextBox.TabIndex = 14;
            // 
            // infoMonthHoursSumLabel
            // 
            this.infoMonthHoursSumLabel.AutoSize = true;
            this.infoMonthHoursSumLabel.Location = new System.Drawing.Point(8, 129);
            this.infoMonthHoursSumLabel.Name = "infoMonthHoursSumLabel";
            this.infoMonthHoursSumLabel.Size = new System.Drawing.Size(85, 13);
            this.infoMonthHoursSumLabel.TabIndex = 13;
            this.infoMonthHoursSumLabel.Text = "Summe Stunden";
            // 
            // infoMonthShiftSumLabel
            // 
            this.infoMonthShiftSumLabel.AutoSize = true;
            this.infoMonthShiftSumLabel.Location = new System.Drawing.Point(9, 101);
            this.infoMonthShiftSumLabel.Name = "infoMonthShiftSumLabel";
            this.infoMonthShiftSumLabel.Size = new System.Drawing.Size(93, 13);
            this.infoMonthShiftSumLabel.TabIndex = 12;
            this.infoMonthShiftSumLabel.Text = "Summe Schichten";
            // 
            // infoMonthLabel
            // 
            this.infoMonthLabel.AutoSize = true;
            this.infoMonthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoMonthLabel.Location = new System.Drawing.Point(8, 10);
            this.infoMonthLabel.Name = "infoMonthLabel";
            this.infoMonthLabel.Size = new System.Drawing.Size(55, 20);
            this.infoMonthLabel.TabIndex = 11;
            this.infoMonthLabel.Text = "Monat";
            // 
            // infoMonthSalerySumLabel
            // 
            this.infoMonthSalerySumLabel.AutoSize = true;
            this.infoMonthSalerySumLabel.Location = new System.Drawing.Point(9, 74);
            this.infoMonthSalerySumLabel.Name = "infoMonthSalerySumLabel";
            this.infoMonthSalerySumLabel.Size = new System.Drawing.Size(86, 13);
            this.infoMonthSalerySumLabel.TabIndex = 9;
            this.infoMonthSalerySumLabel.Text = "Gesamt Gehälter";
            // 
            // infoMonthSalerySumContent
            // 
            this.infoMonthSalerySumContent.AutoSize = true;
            this.infoMonthSalerySumContent.Location = new System.Drawing.Point(238, 74);
            this.infoMonthSalerySumContent.Name = "infoMonthSalerySumContent";
            this.infoMonthSalerySumContent.Size = new System.Drawing.Size(19, 13);
            this.infoMonthSalerySumContent.TabIndex = 10;
            this.infoMonthSalerySumContent.Text = "0€";
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.personenSortierenToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1246, 24);
            this.menu.TabIndex = 6;
            this.menu.Text = "menu";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.openToolStripMenuItem,
            this.kalenderDateienExportierenToolStripMenuItem,
            this.exportAsCSVToolStripMenuItem,
            this.hTMLDateienExportierenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.saveToolStripMenuItem.Text = "speichern";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.openToolStripMenuItem.Text = "öffnen";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // kalenderDateienExportierenToolStripMenuItem
            // 
            this.kalenderDateienExportierenToolStripMenuItem.Name = "kalenderDateienExportierenToolStripMenuItem";
            this.kalenderDateienExportierenToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.kalenderDateienExportierenToolStripMenuItem.Text = "Kalender Dateien exportieren";
            this.kalenderDateienExportierenToolStripMenuItem.Click += new System.EventHandler(this.kalenderDateienExportierenToolStripMenuItem_Click);
            // 
            // exportAsCSVToolStripMenuItem
            // 
            this.exportAsCSVToolStripMenuItem.Name = "exportAsCSVToolStripMenuItem";
            this.exportAsCSVToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.exportAsCSVToolStripMenuItem.Text = "CSV Dateien exportieren";
            this.exportAsCSVToolStripMenuItem.Click += new System.EventHandler(this.exportAsCSVToolStripMenuItem_Click);
            // 
            // hTMLDateienExportierenToolStripMenuItem
            // 
            this.hTMLDateienExportierenToolStripMenuItem.Name = "hTMLDateienExportierenToolStripMenuItem";
            this.hTMLDateienExportierenToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.hTMLDateienExportierenToolStripMenuItem.Text = "HTML Dateien exportieren";
            this.hTMLDateienExportierenToolStripMenuItem.Click += new System.EventHandler(this.hTMLDateienExportierenToolStripMenuItem_Click);
            // 
            // personenSortierenToolStripMenuItem
            // 
            this.personenSortierenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.namenToolStripMenuItem,
            this.gehaltProStundeToolStripMenuItem,
            this.minArbeitsstundenToolStripMenuItem,
            this.maxArbeitsstundenToolStripMenuItem,
            this.schichtTypenToolStripMenuItem,
            this.anmerkungenToolStripMenuItem});
            this.personenSortierenToolStripMenuItem.Name = "personenSortierenToolStripMenuItem";
            this.personenSortierenToolStripMenuItem.Size = new System.Drawing.Size(146, 20);
            this.personenSortierenToolStripMenuItem.Text = "Personen sortieren nach";
            // 
            // namenToolStripMenuItem
            // 
            this.namenToolStripMenuItem.Name = "namenToolStripMenuItem";
            this.namenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.namenToolStripMenuItem.Text = "Namen";
            this.namenToolStripMenuItem.Click += new System.EventHandler(this.namenToolStripMenuItem_Click);
            // 
            // gehaltProStundeToolStripMenuItem
            // 
            this.gehaltProStundeToolStripMenuItem.Name = "gehaltProStundeToolStripMenuItem";
            this.gehaltProStundeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.gehaltProStundeToolStripMenuItem.Text = "Gehalt pro Stunde";
            this.gehaltProStundeToolStripMenuItem.Click += new System.EventHandler(this.gehaltProStundeToolStripMenuItem_Click);
            // 
            // minArbeitsstundenToolStripMenuItem
            // 
            this.minArbeitsstundenToolStripMenuItem.Name = "minArbeitsstundenToolStripMenuItem";
            this.minArbeitsstundenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.minArbeitsstundenToolStripMenuItem.Text = "Min Arbeitsstunden";
            this.minArbeitsstundenToolStripMenuItem.Click += new System.EventHandler(this.minArbeitsstundenToolStripMenuItem_Click);
            // 
            // maxArbeitsstundenToolStripMenuItem
            // 
            this.maxArbeitsstundenToolStripMenuItem.Name = "maxArbeitsstundenToolStripMenuItem";
            this.maxArbeitsstundenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.maxArbeitsstundenToolStripMenuItem.Text = "Max Arbeitsstunden";
            this.maxArbeitsstundenToolStripMenuItem.Click += new System.EventHandler(this.maxArbeitsstundenToolStripMenuItem_Click);
            // 
            // schichtTypenToolStripMenuItem
            // 
            this.schichtTypenToolStripMenuItem.Name = "schichtTypenToolStripMenuItem";
            this.schichtTypenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.schichtTypenToolStripMenuItem.Text = "Schicht Typen";
            this.schichtTypenToolStripMenuItem.Click += new System.EventHandler(this.schichtTypenToolStripMenuItem_Click);
            // 
            // anmerkungenToolStripMenuItem
            // 
            this.anmerkungenToolStripMenuItem.Name = "anmerkungenToolStripMenuItem";
            this.anmerkungenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.anmerkungenToolStripMenuItem.Text = "Anmerkungen";
            this.anmerkungenToolStripMenuItem.Click += new System.EventHandler(this.anmerkungenToolStripMenuItem_Click);
            // 
            // window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 623);
            this.Controls.Add(this.infoSettingsTabPage);
            this.Controls.Add(this.yearMonthSelectorPanel);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.Name = "window";
            this.Text = "Schichtplan";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.window_FormClosing);
            this.yearMonthSelectorPanel.ResumeLayout(false);
            this.yearMonthSelectorPanel.PerformLayout();
            this.infoSettingsTabPage.ResumeLayout(false);
            this.shiftTabPage.ResumeLayout(false);
            this.weekTemplateShiftEditPanel.ResumeLayout(false);
            this.shiftEditPanel.ResumeLayout(false);
            this.shiftEditPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shiftEditDataGridView)).EndInit();
            this.weekTemplatePanel.ResumeLayout(false);
            this.weekTemplatePanel.PerformLayout();
            this.weekTemplateTable.ResumeLayout(false);
            this.monthViewPanel.ResumeLayout(false);
            this.monthViewPanel.PerformLayout();
            this.personsTabPage.ResumeLayout(false);
            this.personContentPanel.ResumeLayout(false);
            this.personShiftSelectPanel.ResumeLayout(false);
            this.personShiftSelectPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.personUnavailableshiftSelectDataGridView)).EndInit();
            this.personDataPanel.ResumeLayout(false);
            this.personDataPanel.PerformLayout();
            this.shiftPlanTabPage.ResumeLayout(false);
            this.shiftPlanTabPage.PerformLayout();
            this.shiftPlanFilterPanel.ResumeLayout(false);
            this.shiftPlanFilterPanel.PerformLayout();
            this.costsTabPage.ResumeLayout(false);
            this.variableCostsPanel.ResumeLayout(false);
            this.variableCostsLabelButtonPanel.ResumeLayout(false);
            this.variableCostsLabelButtonPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.variableCostsDataGridView)).EndInit();
            this.fixCostsPanel.ResumeLayout(false);
            this.fixCostsLabelButtonPanel.ResumeLayout(false);
            this.fixCostsLabelButtonPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fixCostsDataGridView)).EndInit();
            this.infoPersonTabPage.ResumeLayout(false);
            this.infoPersonTabPage.PerformLayout();
            this.infoGeneralTabPage.ResumeLayout(false);
            this.infoGeneralWeekPanel.ResumeLayout(false);
            this.infoGeneralWeekPanel.PerformLayout();
            this.infoGeneralDayPanel.ResumeLayout(false);
            this.infoGeneralDayPanel.PerformLayout();
            this.infoGeneralMonthPanel.ResumeLayout(false);
            this.infoGeneralMonthPanel.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel yearMonthSelectorPanel;
        private System.Windows.Forms.TextBox monthTextBox;
        private System.Windows.Forms.TextBox yearTextBox;
        private System.Windows.Forms.Label monthLabel;
        private System.Windows.Forms.Label yearLabel;
        private System.Windows.Forms.TabControl infoSettingsTabPage;
        private System.Windows.Forms.TabPage shiftTabPage;
        private System.Windows.Forms.Panel weekTemplateShiftEditPanel;
        private System.Windows.Forms.Panel shiftEditPanel;
        private System.Windows.Forms.Button saveCurrentShift;
        private System.Windows.Forms.Label shiftEditLabel;
        private System.Windows.Forms.Panel weekTemplatePanel;
        private System.Windows.Forms.Button useOnHoleMonth;
        private System.Windows.Forms.Label weekTemplateLabel;
        private System.Windows.Forms.Panel monthViewPanel;
        private System.Windows.Forms.Label monthViewLabel;
        private System.Windows.Forms.TabPage personsTabPage;
        private System.Windows.Forms.TabPage shiftPlanTabPage;
        private System.Windows.Forms.TableLayoutPanel weekTemplateTable;
        private System.Windows.Forms.DataGridView shiftEditDataGridView;
        private System.Windows.Forms.TableLayoutPanel monthViewTable;
        private System.Windows.Forms.TableLayoutPanel shiftPlanTable;
        private System.Windows.Forms.Button createYearMonthButton;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportAsCSVToolStripMenuItem;
        private System.Windows.Forms.Label weekTemplateTuesdayLabel;
        private System.Windows.Forms.Label weekTemplateWednesdayLabel;
        private System.Windows.Forms.Label weekTemplateThursdayLabel;
        private System.Windows.Forms.Label weekTemplateFridayLabel;
        private System.Windows.Forms.Label weekTemplateSaturdayLabel;
        private System.Windows.Forms.Label weekTemplateSundayLabel;
        private System.Windows.Forms.Label weekTemplateMondayLabel;
        private System.Windows.Forms.Label weekTemplateMondayContentLabel;
        private System.Windows.Forms.Label weekTemplateWednesdayContentLabel;
        private System.Windows.Forms.Label weekTemplateThursdayContentLabel;
        private System.Windows.Forms.Label weekTemplateFridayContentLabel;
        private System.Windows.Forms.Label weekTemplateSaturdayContentLabel;
        private System.Windows.Forms.Label weekTemplateSundayContentLabel;
        private System.Windows.Forms.Label weekTemplateTuesdayContentLabel;
        private System.Windows.Forms.Button loadFromOtherMonthButton;
        private System.Windows.Forms.Button createShiftPlan;
        private System.Windows.Forms.Panel shiftPlanFilterPanel;
        private System.Windows.Forms.Panel personDataPanel;
        private System.Windows.Forms.TextBox personDescriptionTextBox;
        private System.Windows.Forms.TextBox personMaxWorkHoursTextBox;
        private System.Windows.Forms.TextBox personMinWorkHoursTextBox;
        private System.Windows.Forms.TextBox personSaleryTextBox;
        private System.Windows.Forms.TextBox personShifttypesTextBox;
        private System.Windows.Forms.TextBox personNameTextBox;
        private System.Windows.Forms.Label personNameLabel;
        private System.Windows.Forms.Panel personContentPanel;
        private System.Windows.Forms.TableLayoutPanel personTable;
        private System.Windows.Forms.DataGridView personUnavailableshiftSelectDataGridView;
        private System.Windows.Forms.Label personDescriptionLabel;
        private System.Windows.Forms.Label personShifttypesLabel;
        private System.Windows.Forms.Label personMaxWorkHoursLabel;
        private System.Windows.Forms.Label personMinWorkHoursLabel;
        private System.Windows.Forms.Label personSalaryLabel;
        private System.Windows.Forms.Button personSaveEditButton;
        private System.Windows.Forms.Button personDeleteButton;
        private System.Windows.Forms.Button personAddButton;
        private System.Windows.Forms.TabPage infoPersonTabPage;
        private System.Windows.Forms.Panel personShiftSelectPanel;
        private System.Windows.Forms.CheckBox personSetAllUnavailabilitiesCheckBox;
        private System.Windows.Forms.Button personSetDaysUnavailableButton;
        private System.Windows.Forms.TextBox personSetDaysUnavailableTextBox;
        private System.Windows.Forms.Button personLoadFromDifferentMonthButton;
        private System.Windows.Forms.Label shiftPlanDescriptionLabel;
        private System.Windows.Forms.Label shiftPlanPersonNameLabel;
        private System.Windows.Forms.TextBox shiftPlanDescriptionTextBox;
        private System.Windows.Forms.ComboBox shiftPlanPersonComboBox;
        private System.Windows.Forms.Button shiftplanSaveChangesButton;
        private System.Windows.Forms.TabPage infoGeneralTabPage;
        private System.Windows.Forms.Label infoMonthSalerySumContent;
        private System.Windows.Forms.Label infoMonthSalerySumLabel;
        private System.Windows.Forms.ToolStripMenuItem kalenderDateienExportierenToolStripMenuItem;
        private System.Windows.Forms.Panel infoGeneralWeekPanel;
        private System.Windows.Forms.Panel infoGeneralDayPanel;
        private System.Windows.Forms.Panel infoGeneralMonthPanel;
        private System.Windows.Forms.Label infoMonthLabel;
        private System.Windows.Forms.Label infoWeekLabel;
        private System.Windows.Forms.Label infoMonthShiftSumLabel;
        private System.Windows.Forms.Label infoDayLabel;
        private System.Windows.Forms.Button infoMonthCalculateButton;
        private System.Windows.Forms.Label infoMonthTurnover;
        private System.Windows.Forms.TextBox infoMonthTurnoverTextBox;
        private System.Windows.Forms.Label infoMonthHoursSumLabel;
        private System.Windows.Forms.Label infoMonthAverageTurnoverDayLabel;
        private System.Windows.Forms.Label infoMonthProfitAfterSaleriesCostsLabel;
        private System.Windows.Forms.Label infoMonthAverageTurnoverHourLabel;
        private System.Windows.Forms.ComboBox infoWeekComboBox;
        private System.Windows.Forms.Label infoWeekAverageTurnoverDayContent;
        private System.Windows.Forms.Label infoWeekAverageTurnoverHourContent;
        private System.Windows.Forms.Label infoWeekTurnoverAfterSaleriesContent;
        private System.Windows.Forms.Label infoWeekHoursSumContent;
        private System.Windows.Forms.Label infoWeekShiftSumContent;
        private System.Windows.Forms.Label infoWeekAverageTurnoverDayLabel;
        private System.Windows.Forms.Label infoWeekTurnoverAfterSaleriesLabel;
        private System.Windows.Forms.Label infoWeekAverageTurnoverHourLabel;
        private System.Windows.Forms.Button infoWeekCalculateButton;
        private System.Windows.Forms.Label infoWeekTurnover;
        private System.Windows.Forms.TextBox infoWeekTurnoverTextBox;
        private System.Windows.Forms.Label infoWeekHoursSumLabel;
        private System.Windows.Forms.Label infoWeekShiftSumLabel;
        private System.Windows.Forms.Label infoWeekSalerySumLabel;
        private System.Windows.Forms.Label infoWeekSalerySumContent;
        private System.Windows.Forms.ComboBox infoDayComboBox;
        private System.Windows.Forms.Label infoDayAverageTurnoverHourContent;
        private System.Windows.Forms.Label infoDayTurnoverAfterSaleriesContent;
        private System.Windows.Forms.Label infoDayHoursSumContent;
        private System.Windows.Forms.Label infoDayShiftSumContent;
        private System.Windows.Forms.Label infoDayTurnoverAfterSaleriesLabel;
        private System.Windows.Forms.Label infoDayAverageTurnoverHourLabel;
        private System.Windows.Forms.Button infoDayCalculateButton;
        private System.Windows.Forms.Label infoDayTurnover;
        private System.Windows.Forms.TextBox infoDayTurnoverTextBox;
        private System.Windows.Forms.Label infoDayHoursSumLabel;
        private System.Windows.Forms.Label infoDayShiftSumLabel;
        private System.Windows.Forms.Label infoDaySalerySumLabel;
        private System.Windows.Forms.Label infoDaySalerySumContent;
        private System.Windows.Forms.Label infoMonthAverageTurnoverDayContent;
        private System.Windows.Forms.Label infoMonthAverageTurnoverHourContent;
        private System.Windows.Forms.Label infoMonthProfitAfterSaleriesCostsContent;
        private System.Windows.Forms.Label infoMonthHoursSumContent;
        private System.Windows.Forms.Label infoMonthShiftSumContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn shiftEditStartColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shiftEditEndColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shiftEditTypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shiftEditDescriptionColumn;
        private System.Windows.Forms.ToolStripMenuItem hTMLDateienExportierenToolStripMenuItem;
        private System.Windows.Forms.Button shiftPlanDeleteShiftButton;
        private System.Windows.Forms.Label shiftPlanShiftTypeLabel;
        private System.Windows.Forms.Label shiftPlanShiftEndLabel;
        private System.Windows.Forms.Label shiftPlanShiftStartLabel;
        private System.Windows.Forms.TextBox shiftPlanShiftTypeTextBox;
        private System.Windows.Forms.TextBox shiftPlanShiftEndTextBox;
        private System.Windows.Forms.TextBox shiftPlanShiftStartTextBox;
        private System.Windows.Forms.Label shiftPlanDayContent;
        private System.Windows.Forms.Label shiftPlanDayLabel;
        private System.Windows.Forms.TableLayoutPanel infoPersonTable;
        private System.Windows.Forms.ToolStripMenuItem personenSortierenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem namenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gehaltProStundeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minArbeitsstundenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maxArbeitsstundenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem schichtTypenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem anmerkungenToolStripMenuItem;
        private System.Windows.Forms.Button shiftPlanAddShiftButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn personShiftColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn personShiftSelectColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn personOnlyShiftSelectColumn;
        private System.Windows.Forms.Label personCarryOverLabel;
        private System.Windows.Forms.TextBox personCarryOverTextBox;
        private System.Windows.Forms.Button personResetAllUnavailabilitiesButton;
        private System.Windows.Forms.Label personColorLabel;
        private System.Windows.Forms.Button personColorButton;
        private System.Windows.Forms.ComboBox shiftPlanAlgorithmComboBox;
        private System.Windows.Forms.Button shiftPlanShiftTypeColorButton;
        private System.Windows.Forms.ComboBox shiftPlanShiftTypeColorComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button shiftPlanShowShiftsNotSetButton;
        private System.Windows.Forms.Label shiftPlanShiftsNotSetLabel;
        private System.Windows.Forms.TabPage costsTabPage;
        private System.Windows.Forms.Panel variableCostsPanel;
        private System.Windows.Forms.Panel variableCostsLabelButtonPanel;
        private System.Windows.Forms.Button variableCostsSaveButton;
        private System.Windows.Forms.Label variableCostsLabel;
        private System.Windows.Forms.DataGridView variableCostsDataGridView;
        private System.Windows.Forms.Panel fixCostsPanel;
        private System.Windows.Forms.Panel fixCostsLabelButtonPanel;
        private System.Windows.Forms.Button fixCostsSaveButton;
        private System.Windows.Forms.Label fixCostsLabel;
        private System.Windows.Forms.DataGridView fixCostsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn variableCostsPaydayColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn variableCostsTypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn variableCostsDescriptionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn variableCostsAmountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fixCostsPaydayColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fixCostsTypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fixCostsDescriptionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fixCostsAmountColumn;
        private System.Windows.Forms.Label infoMonthFixCostsSumLabel;
        private System.Windows.Forms.Label infoMonthVariableCostsSumLabel;
        private System.Windows.Forms.Label infoMonthCostsSumContent;
        private System.Windows.Forms.Label infoMonthVariableCostsSumContent;
        private System.Windows.Forms.Label infoMonthFixCostsSumContent;
        private System.Windows.Forms.Label infoMonthCostsSumLabel;
        private System.Windows.Forms.Button fixCostsLoadFromOtherMonthButton;
        private System.Windows.Forms.Button shiftPlanPersonsWithOutOfBoudsWorkhoursButton;
        private System.Windows.Forms.Label shiftPlanPersonsWithOutOfBoudsWorkhoursLabel;
    }
}


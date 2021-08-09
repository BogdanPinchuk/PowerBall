
namespace Powerball
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.newGameMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.statusMain = new System.Windows.Forms.StatusStrip();
            this.groupBoxBR = new System.Windows.Forms.GroupBox();
            this.groupBoxBegin = new System.Windows.Forms.GroupBox();
            this.buttonBG = new System.Windows.Forms.Button();
            this.groupBoxMoney = new System.Windows.Forms.GroupBox();
            this.textBoxJ = new System.Windows.Forms.TextBox();
            this.labelM = new System.Windows.Forms.Label();
            this.labelJ = new System.Windows.Forms.Label();
            this.textBoxM = new System.Windows.Forms.TextBox();
            this.groupBoxLR = new System.Windows.Forms.GroupBox();
            this.groupBoxPP = new System.Windows.Forms.GroupBox();
            this.textBoxPP1 = new System.Windows.Forms.TextBox();
            this.groupBoxPBR = new System.Windows.Forms.GroupBox();
            this.textBoxPBR1 = new System.Windows.Forms.TextBox();
            this.groupBoxPBW = new System.Windows.Forms.GroupBox();
            this.textBoxPBW5 = new System.Windows.Forms.TextBox();
            this.textBoxPBW4 = new System.Windows.Forms.TextBox();
            this.textBoxPBW3 = new System.Windows.Forms.TextBox();
            this.textBoxPBW2 = new System.Windows.Forms.TextBox();
            this.textBoxPBW1 = new System.Windows.Forms.TextBox();
            this.groupBoxRT = new System.Windows.Forms.GroupBox();
            this.groupBoxT = new System.Windows.Forms.GroupBox();
            this.comboBoxPBW1 = new System.Windows.Forms.ComboBox();
            this.comboBoxPBW2 = new System.Windows.Forms.ComboBox();
            this.comboBoxPBW3 = new System.Windows.Forms.ComboBox();
            this.comboBoxPBW4 = new System.Windows.Forms.ComboBox();
            this.comboBoxPBW5 = new System.Windows.Forms.ComboBox();
            this.comboBoxPBR1 = new System.Windows.Forms.ComboBox();
            this.checkBoxPP1 = new System.Windows.Forms.CheckBox();
            this.textBoxCost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuMain.SuspendLayout();
            this.groupBoxBR.SuspendLayout();
            this.groupBoxBegin.SuspendLayout();
            this.groupBoxMoney.SuspendLayout();
            this.groupBoxLR.SuspendLayout();
            this.groupBoxPP.SuspendLayout();
            this.groupBoxPBR.SuspendLayout();
            this.groupBoxPBW.SuspendLayout();
            this.groupBoxRT.SuspendLayout();
            this.groupBoxT.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameMenu});
            this.menuMain.Location = new System.Drawing.Point(3, 3);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(686, 24);
            this.menuMain.TabIndex = 0;
            this.menuMain.Text = "menuStrip1";
            // 
            // newGameMenu
            // 
            this.newGameMenu.Name = "newGameMenu";
            this.newGameMenu.Size = new System.Drawing.Size(77, 20);
            this.newGameMenu.Text = "New Game";
            this.newGameMenu.Click += new System.EventHandler(this.NewGameMenu_Click);
            // 
            // statusMain
            // 
            this.statusMain.Location = new System.Drawing.Point(3, 508);
            this.statusMain.Name = "statusMain";
            this.statusMain.Size = new System.Drawing.Size(686, 22);
            this.statusMain.TabIndex = 1;
            this.statusMain.Text = "statusStrip1";
            // 
            // groupBoxBR
            // 
            this.groupBoxBR.AutoSize = true;
            this.groupBoxBR.Controls.Add(this.groupBoxBegin);
            this.groupBoxBR.Controls.Add(this.groupBoxMoney);
            this.groupBoxBR.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxBR.Location = new System.Drawing.Point(3, 27);
            this.groupBoxBR.Name = "groupBoxBR";
            this.groupBoxBR.Size = new System.Drawing.Size(686, 125);
            this.groupBoxBR.TabIndex = 2;
            this.groupBoxBR.TabStop = false;
            this.groupBoxBR.Text = "Base resources";
            // 
            // groupBoxBegin
            // 
            this.groupBoxBegin.AutoSize = true;
            this.groupBoxBegin.Controls.Add(this.buttonBG);
            this.groupBoxBegin.Location = new System.Drawing.Point(274, 23);
            this.groupBoxBegin.Name = "groupBoxBegin";
            this.groupBoxBegin.Size = new System.Drawing.Size(112, 80);
            this.groupBoxBegin.TabIndex = 5;
            this.groupBoxBegin.TabStop = false;
            // 
            // buttonBG
            // 
            this.buttonBG.Location = new System.Drawing.Point(6, 22);
            this.buttonBG.Name = "buttonBG";
            this.buttonBG.Size = new System.Drawing.Size(100, 23);
            this.buttonBG.TabIndex = 0;
            this.buttonBG.Text = "Begin Game";
            this.buttonBG.UseVisualStyleBackColor = true;
            this.buttonBG.Click += new System.EventHandler(this.ButtonBG_Click);
            // 
            // groupBoxMoney
            // 
            this.groupBoxMoney.Controls.Add(this.textBoxJ);
            this.groupBoxMoney.Controls.Add(this.labelM);
            this.groupBoxMoney.Controls.Add(this.labelJ);
            this.groupBoxMoney.Controls.Add(this.textBoxM);
            this.groupBoxMoney.Location = new System.Drawing.Point(6, 22);
            this.groupBoxMoney.Name = "groupBoxMoney";
            this.groupBoxMoney.Size = new System.Drawing.Size(261, 81);
            this.groupBoxMoney.TabIndex = 4;
            this.groupBoxMoney.TabStop = false;
            this.groupBoxMoney.Text = "Money";
            // 
            // textBoxJ
            // 
            this.textBoxJ.Location = new System.Drawing.Point(6, 22);
            this.textBoxJ.Name = "textBoxJ";
            this.textBoxJ.Size = new System.Drawing.Size(150, 23);
            this.textBoxJ.TabIndex = 0;
            this.textBoxJ.Text = "20000000";
            this.textBoxJ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelM
            // 
            this.labelM.AutoSize = true;
            this.labelM.Location = new System.Drawing.Point(163, 55);
            this.labelM.Name = "labelM";
            this.labelM.Size = new System.Drawing.Size(71, 15);
            this.labelM.TabIndex = 3;
            this.labelM.Text = "Your money";
            // 
            // labelJ
            // 
            this.labelJ.AutoSize = true;
            this.labelJ.Location = new System.Drawing.Point(163, 26);
            this.labelJ.Name = "labelJ";
            this.labelJ.Size = new System.Drawing.Size(47, 15);
            this.labelJ.TabIndex = 1;
            this.labelJ.Text = "Jackpot";
            // 
            // textBoxM
            // 
            this.textBoxM.Location = new System.Drawing.Point(6, 51);
            this.textBoxM.Name = "textBoxM";
            this.textBoxM.Size = new System.Drawing.Size(150, 23);
            this.textBoxM.TabIndex = 2;
            this.textBoxM.Text = "1000";
            this.textBoxM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBoxLR
            // 
            this.groupBoxLR.AutoSize = true;
            this.groupBoxLR.Controls.Add(this.groupBoxPP);
            this.groupBoxLR.Controls.Add(this.groupBoxPBR);
            this.groupBoxLR.Controls.Add(this.groupBoxPBW);
            this.groupBoxLR.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxLR.Location = new System.Drawing.Point(3, 152);
            this.groupBoxLR.Name = "groupBoxLR";
            this.groupBoxLR.Size = new System.Drawing.Size(686, 142);
            this.groupBoxLR.TabIndex = 3;
            this.groupBoxLR.TabStop = false;
            this.groupBoxLR.Text = "Lottery results";
            // 
            // groupBoxPP
            // 
            this.groupBoxPP.AutoSize = true;
            this.groupBoxPP.Controls.Add(this.textBoxPP1);
            this.groupBoxPP.Location = new System.Drawing.Point(435, 23);
            this.groupBoxPP.Name = "groupBoxPP";
            this.groupBoxPP.Size = new System.Drawing.Size(144, 97);
            this.groupBoxPP.TabIndex = 2;
            this.groupBoxPP.TabStop = false;
            this.groupBoxPP.Text = "Power Play (multiplier)";
            // 
            // textBoxPP1
            // 
            this.textBoxPP1.BackColor = System.Drawing.Color.Aqua;
            this.textBoxPP1.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxPP1.Location = new System.Drawing.Point(6, 23);
            this.textBoxPP1.Name = "textBoxPP1";
            this.textBoxPP1.ReadOnly = true;
            this.textBoxPP1.Size = new System.Drawing.Size(55, 52);
            this.textBoxPP1.TabIndex = 5;
            this.textBoxPP1.Text = "10";
            this.textBoxPP1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBoxPBR
            // 
            this.groupBoxPBR.AutoSize = true;
            this.groupBoxPBR.Controls.Add(this.textBoxPBR1);
            this.groupBoxPBR.Location = new System.Drawing.Point(325, 23);
            this.groupBoxPBR.Name = "groupBoxPBR";
            this.groupBoxPBR.Size = new System.Drawing.Size(104, 97);
            this.groupBoxPBR.TabIndex = 1;
            this.groupBoxPBR.TabStop = false;
            this.groupBoxPBR.Text = "Power Ball (red)";
            // 
            // textBoxPBR1
            // 
            this.textBoxPBR1.BackColor = System.Drawing.Color.Red;
            this.textBoxPBR1.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxPBR1.Location = new System.Drawing.Point(6, 23);
            this.textBoxPBR1.Name = "textBoxPBR1";
            this.textBoxPBR1.ReadOnly = true;
            this.textBoxPBR1.Size = new System.Drawing.Size(55, 52);
            this.textBoxPBR1.TabIndex = 1;
            this.textBoxPBR1.Text = "26";
            this.textBoxPBR1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBoxPBW
            // 
            this.groupBoxPBW.AutoSize = true;
            this.groupBoxPBW.Controls.Add(this.textBoxPBW5);
            this.groupBoxPBW.Controls.Add(this.textBoxPBW4);
            this.groupBoxPBW.Controls.Add(this.textBoxPBW3);
            this.groupBoxPBW.Controls.Add(this.textBoxPBW2);
            this.groupBoxPBW.Controls.Add(this.textBoxPBW1);
            this.groupBoxPBW.Location = new System.Drawing.Point(7, 23);
            this.groupBoxPBW.Name = "groupBoxPBW";
            this.groupBoxPBW.Size = new System.Drawing.Size(312, 97);
            this.groupBoxPBW.TabIndex = 0;
            this.groupBoxPBW.TabStop = false;
            this.groupBoxPBW.Text = "Power Ball (white)";
            // 
            // textBoxPBW5
            // 
            this.textBoxPBW5.BackColor = System.Drawing.Color.White;
            this.textBoxPBW5.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxPBW5.Location = new System.Drawing.Point(251, 23);
            this.textBoxPBW5.Name = "textBoxPBW5";
            this.textBoxPBW5.ReadOnly = true;
            this.textBoxPBW5.Size = new System.Drawing.Size(55, 52);
            this.textBoxPBW5.TabIndex = 4;
            this.textBoxPBW5.Text = "69";
            this.textBoxPBW5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxPBW4
            // 
            this.textBoxPBW4.BackColor = System.Drawing.Color.White;
            this.textBoxPBW4.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxPBW4.Location = new System.Drawing.Point(190, 23);
            this.textBoxPBW4.Name = "textBoxPBW4";
            this.textBoxPBW4.ReadOnly = true;
            this.textBoxPBW4.Size = new System.Drawing.Size(55, 52);
            this.textBoxPBW4.TabIndex = 3;
            this.textBoxPBW4.Text = "68";
            this.textBoxPBW4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxPBW3
            // 
            this.textBoxPBW3.BackColor = System.Drawing.Color.White;
            this.textBoxPBW3.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxPBW3.Location = new System.Drawing.Point(129, 23);
            this.textBoxPBW3.Name = "textBoxPBW3";
            this.textBoxPBW3.ReadOnly = true;
            this.textBoxPBW3.Size = new System.Drawing.Size(55, 52);
            this.textBoxPBW3.TabIndex = 2;
            this.textBoxPBW3.Text = "67";
            this.textBoxPBW3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxPBW2
            // 
            this.textBoxPBW2.BackColor = System.Drawing.Color.White;
            this.textBoxPBW2.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxPBW2.Location = new System.Drawing.Point(68, 23);
            this.textBoxPBW2.Name = "textBoxPBW2";
            this.textBoxPBW2.ReadOnly = true;
            this.textBoxPBW2.Size = new System.Drawing.Size(55, 52);
            this.textBoxPBW2.TabIndex = 1;
            this.textBoxPBW2.Text = "66";
            this.textBoxPBW2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxPBW1
            // 
            this.textBoxPBW1.BackColor = System.Drawing.Color.White;
            this.textBoxPBW1.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxPBW1.Location = new System.Drawing.Point(7, 23);
            this.textBoxPBW1.Name = "textBoxPBW1";
            this.textBoxPBW1.ReadOnly = true;
            this.textBoxPBW1.Size = new System.Drawing.Size(55, 52);
            this.textBoxPBW1.TabIndex = 0;
            this.textBoxPBW1.Text = "65";
            this.textBoxPBW1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBoxRT
            // 
            this.groupBoxRT.Controls.Add(this.groupBoxT);
            this.groupBoxRT.Location = new System.Drawing.Point(7, 301);
            this.groupBoxRT.Name = "groupBoxRT";
            this.groupBoxRT.Size = new System.Drawing.Size(601, 204);
            this.groupBoxRT.TabIndex = 4;
            this.groupBoxRT.TabStop = false;
            this.groupBoxRT.Text = "Register tickets";
            // 
            // groupBoxT
            // 
            this.groupBoxT.AutoSize = true;
            this.groupBoxT.Controls.Add(this.label1);
            this.groupBoxT.Controls.Add(this.textBoxCost);
            this.groupBoxT.Controls.Add(this.checkBoxPP1);
            this.groupBoxT.Controls.Add(this.comboBoxPBR1);
            this.groupBoxT.Controls.Add(this.comboBoxPBW5);
            this.groupBoxT.Controls.Add(this.comboBoxPBW4);
            this.groupBoxT.Controls.Add(this.comboBoxPBW3);
            this.groupBoxT.Controls.Add(this.comboBoxPBW2);
            this.groupBoxT.Controls.Add(this.comboBoxPBW1);
            this.groupBoxT.Location = new System.Drawing.Point(7, 23);
            this.groupBoxT.Name = "groupBoxT";
            this.groupBoxT.Size = new System.Drawing.Size(349, 154);
            this.groupBoxT.TabIndex = 0;
            this.groupBoxT.TabStop = false;
            this.groupBoxT.Text = "Ticket";
            // 
            // comboBoxPBW1
            // 
            this.comboBoxPBW1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxPBW1.FormattingEnabled = true;
            this.comboBoxPBW1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69"});
            this.comboBoxPBW1.Location = new System.Drawing.Point(7, 22);
            this.comboBoxPBW1.Name = "comboBoxPBW1";
            this.comboBoxPBW1.Size = new System.Drawing.Size(51, 36);
            this.comboBoxPBW1.TabIndex = 0;
            this.comboBoxPBW1.Text = "65";
            // 
            // comboBoxPBW2
            // 
            this.comboBoxPBW2.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxPBW2.FormattingEnabled = true;
            this.comboBoxPBW2.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69"});
            this.comboBoxPBW2.Location = new System.Drawing.Point(64, 22);
            this.comboBoxPBW2.Name = "comboBoxPBW2";
            this.comboBoxPBW2.Size = new System.Drawing.Size(51, 36);
            this.comboBoxPBW2.TabIndex = 1;
            this.comboBoxPBW2.Text = "66";
            // 
            // comboBoxPBW3
            // 
            this.comboBoxPBW3.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxPBW3.FormattingEnabled = true;
            this.comboBoxPBW3.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69"});
            this.comboBoxPBW3.Location = new System.Drawing.Point(121, 22);
            this.comboBoxPBW3.Name = "comboBoxPBW3";
            this.comboBoxPBW3.Size = new System.Drawing.Size(51, 36);
            this.comboBoxPBW3.TabIndex = 2;
            this.comboBoxPBW3.Text = "67";
            // 
            // comboBoxPBW4
            // 
            this.comboBoxPBW4.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxPBW4.FormattingEnabled = true;
            this.comboBoxPBW4.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69"});
            this.comboBoxPBW4.Location = new System.Drawing.Point(178, 22);
            this.comboBoxPBW4.Name = "comboBoxPBW4";
            this.comboBoxPBW4.Size = new System.Drawing.Size(51, 36);
            this.comboBoxPBW4.TabIndex = 3;
            this.comboBoxPBW4.Text = "68";
            // 
            // comboBoxPBW5
            // 
            this.comboBoxPBW5.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxPBW5.FormattingEnabled = true;
            this.comboBoxPBW5.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69"});
            this.comboBoxPBW5.Location = new System.Drawing.Point(235, 22);
            this.comboBoxPBW5.Name = "comboBoxPBW5";
            this.comboBoxPBW5.Size = new System.Drawing.Size(51, 36);
            this.comboBoxPBW5.TabIndex = 4;
            this.comboBoxPBW5.Text = "69";
            // 
            // comboBoxPBR1
            // 
            this.comboBoxPBR1.BackColor = System.Drawing.Color.Red;
            this.comboBoxPBR1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxPBR1.FormattingEnabled = true;
            this.comboBoxPBR1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26"});
            this.comboBoxPBR1.Location = new System.Drawing.Point(292, 22);
            this.comboBoxPBR1.Name = "comboBoxPBR1";
            this.comboBoxPBR1.Size = new System.Drawing.Size(51, 36);
            this.comboBoxPBR1.TabIndex = 5;
            this.comboBoxPBR1.Text = "26";
            // 
            // checkBoxPP1
            // 
            this.checkBoxPP1.AutoSize = true;
            this.checkBoxPP1.BackColor = System.Drawing.Color.Aqua;
            this.checkBoxPP1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxPP1.Location = new System.Drawing.Point(7, 65);
            this.checkBoxPP1.Name = "checkBoxPP1";
            this.checkBoxPP1.Size = new System.Drawing.Size(125, 32);
            this.checkBoxPP1.TabIndex = 6;
            this.checkBoxPP1.Text = "Power Play";
            this.checkBoxPP1.UseVisualStyleBackColor = false;
            // 
            // textBoxCost
            // 
            this.textBoxCost.BackColor = System.Drawing.Color.White;
            this.textBoxCost.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxCost.Location = new System.Drawing.Point(6, 103);
            this.textBoxCost.Name = "textBoxCost";
            this.textBoxCost.ReadOnly = true;
            this.textBoxCost.Size = new System.Drawing.Size(30, 29);
            this.textBoxCost.TabIndex = 7;
            this.textBoxCost.Text = "2";
            this.textBoxCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(43, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "The price of this ticket";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 533);
            this.Controls.Add(this.groupBoxRT);
            this.Controls.Add(this.groupBoxLR);
            this.Controls.Add(this.groupBoxBR);
            this.Controls.Add(this.statusMain);
            this.Controls.Add(this.menuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuMain;
            this.Name = "FormMain";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "PowerBall";
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.groupBoxBR.ResumeLayout(false);
            this.groupBoxBR.PerformLayout();
            this.groupBoxBegin.ResumeLayout(false);
            this.groupBoxMoney.ResumeLayout(false);
            this.groupBoxMoney.PerformLayout();
            this.groupBoxLR.ResumeLayout(false);
            this.groupBoxLR.PerformLayout();
            this.groupBoxPP.ResumeLayout(false);
            this.groupBoxPP.PerformLayout();
            this.groupBoxPBR.ResumeLayout(false);
            this.groupBoxPBR.PerformLayout();
            this.groupBoxPBW.ResumeLayout(false);
            this.groupBoxPBW.PerformLayout();
            this.groupBoxRT.ResumeLayout(false);
            this.groupBoxRT.PerformLayout();
            this.groupBoxT.ResumeLayout(false);
            this.groupBoxT.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem newGameMenu;
        private System.Windows.Forms.StatusStrip statusMain;
        private System.Windows.Forms.GroupBox groupBoxBR;
        private System.Windows.Forms.Label labelM;
        private System.Windows.Forms.TextBox textBoxM;
        private System.Windows.Forms.Label labelJ;
        private System.Windows.Forms.TextBox textBoxJ;
        private System.Windows.Forms.GroupBox groupBoxBegin;
        private System.Windows.Forms.Button buttonBG;
        private System.Windows.Forms.GroupBox groupBoxMoney;
        private System.Windows.Forms.GroupBox groupBoxLR;
        private System.Windows.Forms.GroupBox groupBoxPP;
        private System.Windows.Forms.GroupBox groupBoxPBR;
        private System.Windows.Forms.GroupBox groupBoxPBW;
        private System.Windows.Forms.TextBox textBoxPBW2;
        private System.Windows.Forms.TextBox textBoxPBW1;
        private System.Windows.Forms.TextBox textBoxPP1;
        private System.Windows.Forms.TextBox textBoxPBR1;
        private System.Windows.Forms.TextBox textBoxPBW5;
        private System.Windows.Forms.TextBox textBoxPBW4;
        private System.Windows.Forms.TextBox textBoxPBW3;
        private System.Windows.Forms.GroupBox groupBoxRT;
        private System.Windows.Forms.GroupBox groupBoxT;
        private System.Windows.Forms.CheckBox checkBoxPP1;
        private System.Windows.Forms.ComboBox comboBoxPBR1;
        private System.Windows.Forms.ComboBox comboBoxPBW5;
        private System.Windows.Forms.ComboBox comboBoxPBW4;
        private System.Windows.Forms.ComboBox comboBoxPBW3;
        private System.Windows.Forms.ComboBox comboBoxPBW2;
        private System.Windows.Forms.ComboBox comboBoxPBW1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCost;
    }
}


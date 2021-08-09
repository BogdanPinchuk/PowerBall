
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
            this.groupBoxPBW = new System.Windows.Forms.GroupBox();
            this.groupBoxPBR = new System.Windows.Forms.GroupBox();
            this.groupBoxPP = new System.Windows.Forms.GroupBox();
            this.textBoxPBW1 = new System.Windows.Forms.TextBox();
            this.textBoxPBW2 = new System.Windows.Forms.TextBox();
            this.textBoxPBW3 = new System.Windows.Forms.TextBox();
            this.textBoxPBW4 = new System.Windows.Forms.TextBox();
            this.textBoxPBW5 = new System.Windows.Forms.TextBox();
            this.textBoxPBR1 = new System.Windows.Forms.TextBox();
            this.textBoxPP1 = new System.Windows.Forms.TextBox();
            this.menuMain.SuspendLayout();
            this.groupBoxBR.SuspendLayout();
            this.groupBoxBegin.SuspendLayout();
            this.groupBoxMoney.SuspendLayout();
            this.groupBoxLR.SuspendLayout();
            this.groupBoxPBW.SuspendLayout();
            this.groupBoxPBR.SuspendLayout();
            this.groupBoxPP.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameMenu});
            this.menuMain.Location = new System.Drawing.Point(3, 3);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(622, 24);
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
            this.statusMain.Location = new System.Drawing.Point(3, 425);
            this.statusMain.Name = "statusMain";
            this.statusMain.Size = new System.Drawing.Size(622, 22);
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
            this.groupBoxBR.Size = new System.Drawing.Size(622, 125);
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
            this.groupBoxLR.Size = new System.Drawing.Size(622, 142);
            this.groupBoxLR.TabIndex = 3;
            this.groupBoxLR.TabStop = false;
            this.groupBoxLR.Text = "Lottery results";
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
            // groupBoxPBR
            // 
            this.groupBoxPBR.AutoSize = true;
            this.groupBoxPBR.Controls.Add(this.textBoxPBR1);
            this.groupBoxPBR.Location = new System.Drawing.Point(325, 23);
            this.groupBoxPBR.Name = "groupBoxPBR";
            this.groupBoxPBR.Size = new System.Drawing.Size(104, 96);
            this.groupBoxPBR.TabIndex = 1;
            this.groupBoxPBR.TabStop = false;
            this.groupBoxPBR.Text = "Power Ball (red)";
            // 
            // groupBoxPP
            // 
            this.groupBoxPP.AutoSize = true;
            this.groupBoxPP.Controls.Add(this.textBoxPP1);
            this.groupBoxPP.Location = new System.Drawing.Point(435, 23);
            this.groupBoxPP.Name = "groupBoxPP";
            this.groupBoxPP.Size = new System.Drawing.Size(144, 96);
            this.groupBoxPP.TabIndex = 2;
            this.groupBoxPP.TabStop = false;
            this.groupBoxPP.Text = "Power Play (multiplier)";
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
            this.textBoxPBW1.Text = "69";
            this.textBoxPBW1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.textBoxPBW2.Text = "69";
            this.textBoxPBW2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxPBW3
            // 
            this.textBoxPBW3.BackColor = System.Drawing.Color.White;
            this.textBoxPBW3.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxPBW3.Location = new System.Drawing.Point(129, 22);
            this.textBoxPBW3.Name = "textBoxPBW3";
            this.textBoxPBW3.ReadOnly = true;
            this.textBoxPBW3.Size = new System.Drawing.Size(55, 52);
            this.textBoxPBW3.TabIndex = 2;
            this.textBoxPBW3.Text = "69";
            this.textBoxPBW3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxPBW4
            // 
            this.textBoxPBW4.BackColor = System.Drawing.Color.White;
            this.textBoxPBW4.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxPBW4.Location = new System.Drawing.Point(190, 22);
            this.textBoxPBW4.Name = "textBoxPBW4";
            this.textBoxPBW4.ReadOnly = true;
            this.textBoxPBW4.Size = new System.Drawing.Size(55, 52);
            this.textBoxPBW4.TabIndex = 3;
            this.textBoxPBW4.Text = "69";
            this.textBoxPBW4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxPBW5
            // 
            this.textBoxPBW5.BackColor = System.Drawing.Color.White;
            this.textBoxPBW5.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxPBW5.Location = new System.Drawing.Point(251, 22);
            this.textBoxPBW5.Name = "textBoxPBW5";
            this.textBoxPBW5.ReadOnly = true;
            this.textBoxPBW5.Size = new System.Drawing.Size(55, 52);
            this.textBoxPBW5.TabIndex = 4;
            this.textBoxPBW5.Text = "69";
            this.textBoxPBW5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxPBR1
            // 
            this.textBoxPBR1.BackColor = System.Drawing.Color.Red;
            this.textBoxPBR1.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxPBR1.Location = new System.Drawing.Point(6, 22);
            this.textBoxPBR1.Name = "textBoxPBR1";
            this.textBoxPBR1.ReadOnly = true;
            this.textBoxPBR1.Size = new System.Drawing.Size(55, 52);
            this.textBoxPBR1.TabIndex = 1;
            this.textBoxPBR1.Text = "26";
            this.textBoxPBR1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxPP1
            // 
            this.textBoxPP1.BackColor = System.Drawing.Color.Aqua;
            this.textBoxPP1.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxPP1.Location = new System.Drawing.Point(6, 22);
            this.textBoxPP1.Name = "textBoxPP1";
            this.textBoxPP1.ReadOnly = true;
            this.textBoxPP1.Size = new System.Drawing.Size(55, 52);
            this.textBoxPP1.TabIndex = 5;
            this.textBoxPP1.Text = "10";
            this.textBoxPP1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 450);
            this.Controls.Add(this.groupBoxLR);
            this.Controls.Add(this.groupBoxBR);
            this.Controls.Add(this.statusMain);
            this.Controls.Add(this.menuMain);
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
            this.groupBoxPBW.ResumeLayout(false);
            this.groupBoxPBW.PerformLayout();
            this.groupBoxPBR.ResumeLayout(false);
            this.groupBoxPBR.PerformLayout();
            this.groupBoxPP.ResumeLayout(false);
            this.groupBoxPP.PerformLayout();
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
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Powerball
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// Cost when customer want/ don`t want use Power Play
        /// </summary>
        private int costWithOutPP = 2;
        private int costWithPP = 3;
        /// <summary>
        /// Numner of maximum value for white balls
        /// </summary>
        private int maxOfWhite = 69;
        /// <summary>
        /// Numner of maximum value for red balls
        /// </summary>
        private int maxOfRed = 26;

        #region Properties for future logic (price of titcket)
        /// <summary>
        /// Cost of ticket without Power Play
        /// </summary>
        private int CostWithOutPP
        {
            get { return costWithOutPP; }
            set { costWithOutPP = value; }
        }

        /// <summary>
        /// Cost of ticket with Power Play
        /// </summary>
        private int CostWithPP
        {
            get { return costWithPP; }
            set { costWithPP = value; }
        }
        #endregion

        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Begin Game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonBG_Click(object sender, EventArgs e)
        {
            // blocked of base money data
            groupBoxBR.Enabled = false;
            // unblocked of game
            groupBoxPD.Enabled = true;
            groupBoxRT.Enabled = true;
        }

        /// <summary>
        /// Start new Game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewGameMenu_Click(object sender, EventArgs e)
        {
            // unblocked of base money data
            groupBoxBR.Enabled = true;
            // blocked of game
            groupBoxPD.Enabled = false;
            groupBoxRT.Enabled = false;
        }

        /// <summary>
        /// Chose use Power Play
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBoxPP1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPP1.Checked)
            {
                textBoxCost.Text = $"{CostWithPP}";
            }
            else
            {
                textBoxCost.Text = $"{CostWithOutPP}";
            }
        }

        /// <summary>
        /// Start draw and clear of table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonS_Click(object sender, EventArgs e)
        {
            if (buttonS.Text == "Start")
            {
                // TODO: Clear of table

                buttonS.Text = "Next";
            }
            else
            {
                // TODO: Calc winnings

                buttonS.Text = "Start";
            }
        }

        /// <summary>
        /// Checking 1-st of ComboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxPBW1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ValidateInputDataCB(comboBoxPBW1, e, maxOfWhite);
        }


        /// <summary>
        /// Checking of validate input data
        /// </summary>
        /// <param name="cb">element of form</param>
        /// <param name="e">data of keys</param>
        /// <param name="max">Limit of chousing number</param>
        private void ValidateInputDataCB(ComboBox cb, KeyPressEventArgs e, int max)
        {
            if (e.KeyChar == ((char)Keys.Enter))
            {
                
            }

        }

        private void ComboBoxPBW1_TextChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("changed");
        }

        private void comboBoxPBW1_TextUpdate(object sender, EventArgs e)
        {
            //MessageBox.Show("changed 2");
        }
    }
}

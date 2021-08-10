using GameLogic;

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
        /// Cost when customer don`t want use Power Play
        /// </summary>
        private int costWithOutPP = 2;
        /// <summary>
        /// Cost when customer want use Power Play
        /// </summary>
        private int costWithPP = 3;
        /// <summary>
        /// Numner of maximum value for white balls
        /// </summary>
        private static readonly int maxOfWhite = 69;
        /// <summary>
        /// Numner of maximum value for red balls
        /// </summary>
        private static readonly int maxOfRed = 26;
        /// <summary>
        /// Count of chose white numbers
        /// </summary>
        private static readonly int countChoseWhiteBalls = 5;
        /// <summary>
        /// Max values for power play game when we can use 10x multiplier
        /// </summary>
        private static readonly long maxMoneyForPP = 150_000_000;
        /// <summary>
        /// Min value for jackpot
        /// </summary>
        private static readonly long minJackpot = 20_000_000;
        /// <summary>
        /// value of jackpot
        /// </summary>
        private static long jackpot;
        /// <summary>
        /// random balls (white and red) for "Perform draw"
        /// </summary>
        private KeyValuePair<int, List<int>> randomBalls;

        /// <summary>
        /// Base logig of game
        /// </summary>
        private PowerBallLogic powerBall = new(maxOfWhite, maxOfRed, MaxMultiplier, countChoseWhiteBalls);


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

        /// <summary>
        /// Max value for multiplier in power play
        /// </summary>
        private static int MaxMultiplier
            => (jackpot <= maxMoneyForPP) ? 10 : 5;
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
            // lock of base money data
            //groupBoxBR.Enabled = false;
            textBoxJ.ReadOnly = true;
            textBoxM.ReadOnly = true;
            groupBoxBegin.Enabled = false;

            // unlock of game
            groupBoxPD.Enabled = true;
            groupBoxRT.Enabled = true;

            // clear textbox
            ClearTextBoxOfLotеery();
        }

        /// <summary>
        /// Clear textboxes for present wins variants of lottery
        /// </summary>
        private void ClearTextBoxOfLotеery()
        {
            // white balls
            textBoxPBW1.Text = string.Empty;
            textBoxPBW2.Text = string.Empty;
            textBoxPBW3.Text = string.Empty;
            textBoxPBW4.Text = string.Empty;
            textBoxPBW5.Text = string.Empty;

            // red ball
            textBoxPBR1.Text = string.Empty;

            // power play
            textBoxPP1.Text = string.Empty;
        }

        /// <summary>
        /// Start new Game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewGameMenu_Click(object sender, EventArgs e)
        {
            // unlock of base money data
            //groupBoxBR.Enabled = true;
            textBoxJ.ReadOnly = false;
            textBoxM.ReadOnly = false;
            groupBoxBegin.Enabled = true;

            // lock of game
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
            // white balls
            List<TextBox> textBoxes = new List<TextBox>()
                {
                    textBoxPBW1,
                    textBoxPBW2,
                    textBoxPBW3,
                    textBoxPBW4,
                    textBoxPBW5,
                };

            if (buttonS.Text == "Start")
            {
                // TODO: Clear of table

                // get random values for wins balls
                randomBalls = powerBall.GetRandomValues();

                // set values in textbox
                for (int i = 0; i < textBoxes.Count; i++)
                    textBoxes[i].Text = randomBalls.Value[i].ToString();

                // red ball
                textBoxPBR1.Text = randomBalls.Key.ToString();

                // get multiplier
                textBoxPP1.Text = powerBall.GetRandomMultiplier().ToString();

                // block ability buy ticket
                groupBoxT.Enabled = false;

                buttonS.Text = "Next";
            }
            else
            {
                // TODO: Calc winnings

                // clear values for powerball
                for (int i = 0; i < textBoxes.Count; i++)
                    textBoxes[i].Text = string.Empty;

                textBoxPBR1.Text = string.Empty;

                // clear multiplier
                textBoxPP1.Text = string.Empty;

                // unlock ability buy ticket
                groupBoxT.Enabled = true;

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

        private void ComboBoxPBW1_TextUpdate(object sender, EventArgs e)
        {
            //MessageBox.Show("changed 2");
        }

        /// <summary>
        /// Validate input data for jackpot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxJ_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateInputMoney(textBoxJ, minJackpot, e);

            // save value for jackpot
            bool correct = long.TryParse(textBoxJ.Text, out long result);
            jackpot = (correct && result >= minJackpot) ? result : minJackpot;
        }

        /// <summary>
        /// Validate input data for money of gamer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxM_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateInputMoney(textBoxM, 2, e);
        }

        /// <summary>
        /// Validate input data
        /// </summary>
        /// <param name="tb">element of form where input some money</param>
        /// <param name="money">amount of money</param>
        /// <param name="e">keys of keyboard</param>
        private void ValidateInputMoney(TextBox tb, long money, KeyPressEventArgs e)
        {
            if (e.KeyChar == ((char)Keys.Enter))
            {
                // check correct input data
                bool correct = long.TryParse(tb.Text, out long result);

                tb.Text = (correct && result >= money) ? result.ToString() : money.ToString();

                #region first variant
                /*
                        if (correct && result >= money)
                        {
                            tb.Text = result.ToString();
                        }
                        else
                        {
                            tb.Text = money.ToString();
                        }
                        */
                #endregion
            }
        }

        /// <summary>
        /// Autocomplate values for tickets
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAG_Click(object sender, EventArgs e)
        {

        }
    }
}

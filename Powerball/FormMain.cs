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
        /// Type of ball determined by color
        /// </summary>
        enum BallType
        {
            /// <summary>
            /// white color of ball
            /// </summary>
            White,
            /// <summary>
            /// red color of ball
            /// </summary>
            Red,
        }

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
        /// random balls (red and white) for "Perform draw"
        /// </summary>
        private KeyValuePair<int, List<int>> randomBalls;
        /// <summary>
        /// new name table for simple access
        /// </summary>
        private readonly DataGridView table;
        /// <summary>
        /// Registered tickets for game
        /// </summary>
        private List<Ticket> tickets = new();

        /// <summary>
        /// Base logig of game
        /// </summary>
        private PowerBallLogic powerBall =
            new(maxOfWhite, maxOfRed, MaxMultiplier,
                countChoseWhiteBalls, jackpot);

        /// <summary>
        /// Temporary ticket for future save in list buyed tickets
        /// </summary>
        private Ticket tempTicket = new(maxOfWhite, maxOfRed);

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

            // add link of table
            table = dataGridViewRT;

            // clear table
            ClearOfTable();
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

            // clear of table
            ClearOfTable();

            // clear list of registered tickets
            tickets.Clear();

            // validate input values of money
            ValidateInputMoney(textBoxJ, minJackpot);   // jackpot
            ValidateInputMoney(textBoxM, 2);            // customer money

            // save value for jackpot
            bool correct = long.TryParse(textBoxJ.Text, out long result);
            jackpot = (correct && result >= minJackpot) ? result : minJackpot;

            // corrected value of max multiplier
            powerBall = new(maxOfWhite, maxOfRed, MaxMultiplier,
                countChoseWhiteBalls, jackpot);

            // clear textbox
            ClearTextBoxOfLotеery();

            // auto-substitution values for customer ticket
            AutoGenerateTicketValues();
        }

        /// <summary>
        /// Clear all old register ticket
        /// </summary>
        private void ClearOfTable()
        {
            // clear all
            table.Columns.Clear();
            table.Rows.Clear();

            // add columns and their names
            {
                // temp value
                int i = 1;

                // white balls
                table.Columns.Add($"Column{i}", $"{i++}");
                table.Columns.Add($"Column{i}", $"{i++}");
                table.Columns.Add($"Column{i}", $"{i++}");
                table.Columns.Add($"Column{i}", $"{i++}");
                table.Columns.Add($"Column{i}", $"{i++}");
                // red ball
                table.Columns.Add($"Column{i++}", "PB");
                // power play
                table.Columns.Add(new DataGridViewCheckBoxColumn());
                table.Columns[table.Columns.Count - 1].Name = $"Column{i++}";
                table.Columns[table.Columns.Count - 1].HeaderText = "PP";
                // win
                table.Columns.Add($"Column{i}", "Win");
            }

            // formats of columns (format for BoxColumn will not affect) and readonly
            for (int i = 1; i <= table.Columns.Count; i++)
            {
                if (table.Columns[$"Column{i}"] is DataGridViewTextBoxColumn)
                {
                    table.Columns[$"Column{i}"].DefaultCellStyle.Format = "N0";
                    table.Columns[$"Column{i}"].ReadOnly = true;
                }
            }

            // remove selection of table
            table.ClearSelection();

            // some parameters
            table.AllowUserToAddRows = false;
            table.AllowUserToDeleteRows = false;
            table.AllowUserToOrderColumns = true;


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

            // clear table
            ClearOfTable();

            // clear list of registered tickets
            tickets.Clear();
        }

        /// <summary>
        /// Chose use Power Play
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBoxPP1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPP1.Checked)
                textBoxCost.Text = $"{CostWithPP}";
            else
                textBoxCost.Text = $"{CostWithOutPP}";

            // save result in tempTicket
            tempTicket.PowerPlay = checkBoxPP1.Checked;
        }

        /// <summary>
        /// Start draw and clear of table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonS_Click(object sender, EventArgs e)
        {
            // textbox for white balls
            List<TextBox> textBoxes = new()
            {
                textBoxPBW1,
                textBoxPBW2,
                textBoxPBW3,
                textBoxPBW4,
                textBoxPBW5,
            };

            if (buttonS.Text == "Start")
            {
                // block ability buy ticket
                groupBoxT.Enabled = false;

                // get random values for wins balls
                randomBalls = powerBall.GetRandomValues();

                // set values in textbox
                for (int i = 0; i < textBoxes.Count; i++)
                    textBoxes[i].Text = randomBalls.Value[i].ToString();

                // red ball
                textBoxPBR1.Text = randomBalls.Key.ToString();

                // get multiplier
                textBoxPP1.Text = powerBall.GetRandomMultiplier().ToString();

                // Analisys of registered tickets
                powerBall.CheckingTickets(tickets, randomBalls);

                // present winnings tickets
                PresentWinningsInTable();

                #region payment prizes
                // balanse of gamer and sum of prizes
                long balanse = long.Parse(textBoxM.Text),
                    sumPrizes = powerBall.WinMoneys.Sum();

                // corected balance
                balanse += sumPrizes;
                jackpot -= sumPrizes;

                // show info
                statusLabelInfo.Text = $"You won prizes ${sumPrizes}. Your balanse is ${balanse}";

                // corected balasnce and jackpot
                textBoxM.Text = balanse.ToString();
                textBoxJ.Text = jackpot.ToString();
                #endregion
                
                buttonS.Text = "Next";
            }
            else
            {
                // Calc winnings
                ClearOfTable();

                // clear list of registered tickets
                tickets.Clear();

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
        /// Validate input data for jackpot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxJ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ((char)Keys.Enter))
                ValidateInputMoney(textBoxJ, minJackpot);
        }

        /// <summary>
        /// Validate input data for money of gamer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ((char)Keys.Enter))
                ValidateInputMoney(textBoxM, 2);
        }

        /// <summary>
        /// Validate input data for entering money
        /// </summary>
        /// <param name="tb">element of form where input some money</param>
        /// <param name="money">amount of money</param>
        private static void ValidateInputMoney(TextBox tb, long money)
        {
            // check correct input data
            bool correct = long.TryParse(tb.Text, out long result);

            tb.Text = (correct && result >= money) ? result.ToString() : money.ToString();

            #region first variant
            /*
                    if (correct && result >= money)
                        tb.Text = result.ToString();
                    else
                        tb.Text = money.ToString();
                    */
            #endregion
        }

        /// <summary>
        /// Autocomplate values for tickets
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAG_Click(object sender, EventArgs e)
        {
            // auto-substitution values for customer ticket
            AutoGenerateTicketValues();
        }

        /// <summary>
        /// Auto generation random values for customer ticket
        /// </summary>
        private void AutoGenerateTicketValues()
        {
            // textbox for white balls
            List<ComboBox> comboBoxes = new()
            {
                comboBoxPBW1,
                comboBoxPBW2,
                comboBoxPBW3,
                comboBoxPBW4,
                comboBoxPBW5,
            };

            // get random values for wins balls
            randomBalls = powerBall.GetRandomValues();

            // set values in textbox
            for (int i = 0; i < comboBoxes.Count; i++)
                comboBoxes[i].Text = randomBalls.Value[i].ToString();

            // red ball
            comboBoxPBR1.Text = randomBalls.Key.ToString();

            // save data in temp variable
            tempTicket.ChangeTicket(randomBalls.Value, randomBalls.Key, checkBoxPP1.Checked);
            tempTicket.PowerPlay = checkBoxPP1.Checked;
        }

        /// <summary>
        /// Validate input data for entering value ball
        /// </summary>
        /// <param name="cb">comboBox wich changing their value</param>
        /// <param name="ball">type of ball (color)</param>
        private void ValidateInputValueBall(ComboBox cb, BallType ball)
        {
            // check correct input data
            bool correct = int.TryParse(cb.Text, out int result);

            if (correct)
            {
                // validate result
                switch (ball)
                {
                    case BallType.White:
                        // if result is within limits and absent in other checbox? then we can change value
                        if (1 <= result && result <= maxOfWhite && !tempTicket.WhiteBalls.Contains(result))
                        {
                            tempTicket.WhiteBalls[cb.TabIndex] = result;
                            cb.Text = result.ToString();
                        }
                        else
                            // get tabindex and find old value
                            cb.Text = tempTicket.WhiteBalls[cb.TabIndex].ToString();
                        break;
                    case BallType.Red:
                        if (1 <= result && result <= maxOfRed)
                        {
                            tempTicket.RedBall = result;
                            cb.Text = result.ToString();
                        }
                        else
                            cb.Text = tempTicket.RedBall.ToString();
                        break;
                }
            }
            else
            {
                // return back old value
                switch (ball)
                {
                    case BallType.White:
                        // get tabindex and find old value
                        cb.Text = tempTicket.WhiteBalls[cb.TabIndex].ToString();
                        break;
                    case BallType.Red:
                        cb.Text = tempTicket.RedBall.ToString();
                        break;
                }
            }
        }

        /// <summary>
        /// Checking red ball of ComboBox when we press Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxPBR1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ((char)Keys.Enter))
                ValidateInputValueBall(comboBoxPBR1, BallType.Red);
        }

        /// <summary>
        /// Checking red ball of ComboBox when we leave it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxPBR1_Leave(object sender, EventArgs e)
        {
            ValidateInputValueBall(comboBoxPBR1, BallType.Red);
        }

        /// <summary>
        /// Checking 1-st white ball of ComboBox when we press Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxPBW1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ((char)Keys.Enter))
                ValidateInputValueBall(comboBoxPBW1, BallType.White);
        }

        /// <summary>
        /// Checking 1-st white ball of ComboBox when we leave it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxPBW1_Leave(object sender, EventArgs e)
        {
            ValidateInputValueBall(comboBoxPBW1, BallType.White);
        }
        /// <summary>
        /// Checking 2-nd white ball of ComboBox when we press Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxPBW2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ((char)Keys.Enter))
                ValidateInputValueBall(comboBoxPBW2, BallType.White);
        }

        /// <summary>
        /// Checking 2-nd white ball of ComboBox when we leave it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxPBW2_Leave(object sender, EventArgs e)
        {
            ValidateInputValueBall(comboBoxPBW2, BallType.White);
        }

        /// <summary>
        /// Checking 3-rd white ball of ComboBox when we press Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxPBW3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ((char)Keys.Enter))
                ValidateInputValueBall(comboBoxPBW3, BallType.White);
        }

        /// <summary>
        /// Checking 3-rd white ball of ComboBox when we leave it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxPBW3_Leave(object sender, EventArgs e)
        {
            ValidateInputValueBall(comboBoxPBW3, BallType.White);
        }

        /// <summary>
        /// Checking 4-th white ball of ComboBox when we press Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxPBW4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ((char)Keys.Enter))
                ValidateInputValueBall(comboBoxPBW4, BallType.White);
        }

        /// <summary>
        /// Checking 4-th white ball of ComboBox when we leave it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxPBW4_Leave(object sender, EventArgs e)
        {
            ValidateInputValueBall(comboBoxPBW4, BallType.White);
        }

        /// <summary>
        /// Checking 5-th white ball of ComboBox when we press Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxPBW5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ((char)Keys.Enter))
                ValidateInputValueBall(comboBoxPBW5, BallType.White);
        }

        /// <summary>
        /// Checking 5-th white ball of ComboBox when we leave it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxPBW5_Leave(object sender, EventArgs e)
        {
            ValidateInputValueBall(comboBoxPBW5, BallType.White);
        }

        /// <summary>
        /// Adding complate ticket to registration lottery
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonBuy_Click(object sender, EventArgs e)
        {
            // balanse of gamer
            long balanse = long.Parse(textBoxM.Text);

            // checked balasnce of customer money
            if (balanse >= costWithPP && tempTicket.PowerPlay) // with powerplay
            {
                // payment for ticket
                balanse -= costWithPP;
                // sent to jackpot
                jackpot += costWithPP;
            }
            else if (balanse >= costWithOutPP && !tempTicket.PowerPlay)  // without powerplay
            {
                // payment for ticket
                balanse -= costWithOutPP;
                // sent to jackpot
                jackpot += costWithOutPP;
            }
            else
            {
                // show info / message
                statusLabelInfo.Text = $"You don`t have enought money. Your balanse is ${balanse}";
                return;
            }

            // sort white balls
            tempTicket.WhiteBalls.Sort();

            // adding ticket to registration
            tickets.Add(tempTicket);

            // create new tempTicket
            tempTicket = new(maxOfWhite, maxOfRed);

            // update table, add optimization, because every time update all talbe is very slowly
            if (tickets.Count <= 1)
                UpdateOfTable();
            else
                CorectedOfTable();

            // show info
            statusLabelInfo.Text = $"You bought a ticket for ${textBoxCost.Text}. Your balanse is ${balanse}";

            // corected balasnce and jackpot
            textBoxM.Text = balanse.ToString();
            textBoxJ.Text = jackpot.ToString();

            // auto-substitution values for customer ticket
            AutoGenerateTicketValues();
        }

        /// <summary>
        /// update table with registrated tickets
        /// </summary>
        private void UpdateOfTable()
        {
            // clear table (for add only header)
            ClearOfTable();

            // checking accessebility tickets
            if (tickets.Count < 1)
            {
                // show info / message
                statusLabelInfo.Text = $"You don`t have registered tickets.";
                return;
            }
            /*
            else
            {
                // show info / message
                statusLabelInfo.Text = "Info";
            }
            */

            // add rows to table
            table.Rows.Add(tickets.Count);

            // add data to table
            for (int i = 0; i < tickets.Count; i++)
            {
                // numeration of tickets
                table.Rows[i].HeaderCell.Value = $"{i + 1}";

                // write data
                {
                    int j = 1;
                    // white balls
                    foreach (int value in tickets[i].WhiteBalls)
                        table.Rows[i].Cells[$"Column{j++}"].Value = value;
                    // red ball
                    table.Rows[i].Cells[$"Column{j++}"].Value = tickets[i].RedBall;
                    // power play
                    table.Rows[i].Cells[$"Column{j++}"].Value = tickets[i].PowerPlay;
                }
            }

            // fix cells
            //table.AutoResizeColumnHeadersHeight();
            table.AutoResizeColumns();
            table.AutoResizeRows();
            table.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);

            // remove selection of table
            table.ClearSelection();

            // some parameters
            table.AllowUserToAddRows = false;
            table.AllowUserToDeleteRows = false;
            table.AllowUserToOrderColumns = true;
        }

        /// <summary>
        /// Added new rows to table
        /// </summary>
        private void CorectedOfTable()
        {
            // add row to table
            table.Rows.Add();

            // number of row
            int id = table.Rows.Count - 1;

            // numeration of tickets
            table.Rows[id].HeaderCell.Value = $"{id + 1}";

            // write data
            {
                int j = 1;
                // white balls
                foreach (int value in tickets[id].WhiteBalls)
                    table.Rows[id].Cells[$"Column{j++}"].Value = value;
                // red ball
                table.Rows[id].Cells[$"Column{j++}"].Value = tickets[id].RedBall;
                // power play
                table.Rows[id].Cells[$"Column{j++}"].Value = tickets[id].PowerPlay;
            }

            // fix cells
            //table.AutoResizeColumnHeadersHeight();
            table.AutoResizeColumns();
            table.AutoResizeRows();
            table.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);

            // remove selection of table
            table.ClearSelection();
        }

        /// <summary>
        /// Change accessed values to selecting
        /// </summary>
        /// <param name="cb">comboBox wich changing their value</param>
        /// <param name="ball">type of ball (color)</param>
        private void ChangeAccessesValuesBall(ComboBox cb, BallType ball)
        {
            // create full array for some type of base balls and selected variants
            List<int> baseBalls = new(),
                selectedBalls = new();

            // compalte list
            switch (ball)
            {
                case BallType.White:
                    baseBalls = powerBall.GetArrayWhiteBalls();
                    selectedBalls.AddRange(tempTicket.WhiteBalls);
                    break;
                case BallType.Red:
                    baseBalls = powerBall.GetArrayRedBalls();
                    selectedBalls.Add(tempTicket.RedBall);
                    break;
            }

            // delete ball in this element, because when we have value less 10 this element self add "0"
            // example, we have "6", after open their number changed on "60" and ect.
            selectedBalls.Remove(int.Parse(cb.Text));

            // delete selected balls
            foreach (var item in selectedBalls)
                baseBalls.Remove(item);

            // write not removed values in comboBox for choise
            cb.Items.Clear();
            cb.Items.AddRange(baseBalls.Select(i => i.ToString()).ToArray());
        }

        /// <summary>
        /// Changing 1-st white ball of ComboBox when we click of mouse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxPBW1_Enter(object sender, EventArgs e)
        {
            ChangeAccessesValuesBall(comboBoxPBW1, BallType.White);
        }

        /// <summary>
        /// Changing 2-nd white ball of ComboBox when we click of mouse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxPBW2_Enter(object sender, EventArgs e)
        {
            ChangeAccessesValuesBall(comboBoxPBW2, BallType.White);
        }

        /// <summary>
        /// Changing 3-rd white ball of ComboBox when we click of mouse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxPBW3_Enter(object sender, EventArgs e)
        {
            ChangeAccessesValuesBall(comboBoxPBW3, BallType.White);
        }

        /// <summary>
        /// Changing 4-th white ball of ComboBox when we click of mouse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxPBW4_Enter(object sender, EventArgs e)
        {
            ChangeAccessesValuesBall(comboBoxPBW4, BallType.White);
        }

        /// <summary>
        /// Changing 5-th white ball of ComboBox when we click of mouse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxPBW5_Enter(object sender, EventArgs e)
        {
            ChangeAccessesValuesBall(comboBoxPBW5, BallType.White);
        }

        /// <summary>
        /// Changing red ball of ComboBox when we click of mouse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxPBR1_Enter(object sender, EventArgs e)
        {
            ChangeAccessesValuesBall(comboBoxPBR1, BallType.Red);
        }

        /// <summary>
        /// Show in table result of winnings tickets
        /// </summary>
        private void PresentWinningsInTable()
        {
            // clear table (for add only header)
            ClearOfTable();

            // checking accessebility tickets
            if (tickets.Count < 1)
            {
                // show info / message
                statusLabelInfo.Text = $"You don`t have registered tickets.";
                return;
            }

            // add rows to table
            table.Rows.Add(tickets.Count);

            // add data to table
            for (int i = 0; i < tickets.Count; i++)
            {
                // numeration of tickets
                table.Rows[i].HeaderCell.Value = $"{i + 1}";

                // write data
                {
                    int j = 1;
                    // white balls
                    //foreach (int value in tickets[i].WhiteBalls)
                    //{
                    //    table.Rows[i].Cells[$"Column{j}"].Value = value;
                    //    if (powerBall.WinValues[i].Value[j - 1])
                    //        table.Rows[i].Cells[$"Column{j}"].Style.BackColor = Color.Green;
                    //}
                    for (; j <= tickets[i].WhiteBalls.Count; j++)
                    {
                        table.Rows[i].Cells[$"Column{j}"].Value = tickets[i].WhiteBalls[j - 1];
                        if (powerBall.WinValues[i].Value[j - 1])
                            table.Rows[i].Cells[$"Column{j}"].Style.BackColor = Color.LightGreen;
                    }

                    // red ball
                    table.Rows[i].Cells[$"Column{j}"].Value = tickets[i].RedBall;
                    if (powerBall.WinValues[i].Key)
                        table.Rows[i].Cells[$"Column{j}"].Style.BackColor = Color.LightGreen;

                    // power play
                    table.Rows[i].Cells[$"Column{++j}"].Value = tickets[i].PowerPlay;
                    // winning money
                    table.Rows[i].Cells[$"Column{++j}"].Value = powerBall.WinMoneys[i];
                    if (powerBall.WinMoneys[i] > 0)
                        table.Rows[i].Cells[$"Column{j}"].Style.BackColor = Color.Gold;
                }
            }

            // fix cells
            //table.AutoResizeColumnHeadersHeight();
            table.AutoResizeColumns();
            table.AutoResizeRows();
            table.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);

            // remove selection of table
            table.ClearSelection();

            // some parameters
            table.AllowUserToAddRows = false;
            table.AllowUserToDeleteRows = false;
            table.AllowUserToOrderColumns = true;
        }

    }
}

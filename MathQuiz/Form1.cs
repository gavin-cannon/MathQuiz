﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        Random randomizer = new Random();

        int addend1;
        int addend2;

        int minusend1;
        int minusend2;

        int multiplicationend1;
        int multiplicationend2;

        int divisionend1;
        int divisionend2;

        int timeLeft;
        public void StartTheQuiz()
        {
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            sum.Value = 0;

            minusend1 = randomizer.Next(1, 101);
            minusend2 = randomizer.Next(1, minusend1);
            minusLeftLabel.Text = minusend1.ToString();
            minusRightLabel.Text = minusend2.ToString();
            difference.Value = 0;

            multiplicationend1 = randomizer.Next(2, 11);
            multiplicationend2 = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicationend1.ToString();
            timesRightLabel.Text = multiplicationend2.ToString();
            product.Value = 0;

            divisionend1 = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            divisionend2 = divisionend1 * temporaryQuotient;
            dividedLeftLabel.Text = divisionend1.ToString();
            dividedRightLabel.Text = divisionend2.ToString();
            quotient.Value = 0;

            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value)
                && (minusend1 - minusend2 == difference.Value)
                && (multiplicationend1 * multiplicationend2 == product.Value)
                && (divisionend1 / divisionend2 == quotient.Value))
                return true;
            else
                return false;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timeLabel_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                timer1.Stop();
                MessageBox.Show("You got them all right! Congrats!");
                timeLabel.BackColor = SystemColors.Control;
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";
                if (timeLeft <= 5)
                {
                    timeLabel.BackColor = Color.Red;
                }
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry...");
                sum.Value = addend1 + addend2;
                difference.Value = minusend1 - minusend2;
                product.Value = multiplicationend1 * multiplicationend2;
                quotient.Value = divisionend1 / divisionend2;
                timeLabel.BackColor = SystemColors.Control;
                startButton.Enabled = true;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;
            if (answerBox != null )
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }
    }
}

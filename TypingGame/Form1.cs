using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TypingGame
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        Stats stats = new Stats();
        public Form1()
        {            
            InitializeComponent();            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Make sure enable - generate events is true
            lbGameKeys.Items.Add((Keys)random.Next(65, 90));
            if (lbGameKeys.Items.Count > 7)
            {
                lbGameKeys.Items.Clear();
                lbGameKeys.Items.Add("Game over");
                timer1.Stop();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Make sure key preview property is set to true
            if (lbGameKeys.Items.Contains(e.KeyCode))
            {
                lbGameKeys.Items.Remove(e.KeyCode);
                lbGameKeys.Refresh();
                if (timer1.Interval > 400)
                    timer1.Interval -= 10;
                else if (timer1.Interval > 250)
                    timer1.Interval -= 7;
                else
                    timer1.Interval -= 5;

                stats.Update(true);
                // pbDifficulty.Value = 800 - timer1.Interval;
                if (pbDifficulty.Value < 100)
                    pbDifficulty.Value += 1;
            }
            else
                stats.Update(false);

            lblCorrect.Text = "Correct : " + stats.Correct;
            lblMissed.Text  = "Missed : "  + stats.Missed;
            lblTotal.Text   = "Total : "   + stats.Total;
            lblAccuracy.Text = "Accuracy : " + stats.Accuracy + "%";
        }
    }

    class Stats
    {
        public int Correct { get; set; }
        public int Missed  { get; set; }
        public int Total   { get; set; }
        public int Accuracy{ get; set; }

        public void Update(bool bCorrect)
        {
            Total++;
            if (bCorrect)
                Correct++;
            else
                Missed++;
            Accuracy = 100 * Correct / (Missed + Correct);
        }
    }
}

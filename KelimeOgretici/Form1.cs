using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KelimeOgretici
{
    public partial class Form1 : Form
    {
        List<Word> word_array;
        int right_answer;
        struct Word
        {            
           public string meanofEnglish,meanofTurkish;
           public Word(string eng,string tr)
           {
                meanofTurkish = tr;
                meanofEnglish = eng;
           }
        }
        public Form1()
        {
            InitializeComponent();
        }
        void ReadFile()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            word_array = new List<Word>();
            FileStream fs = new FileStream(path+"/kelime.txt", FileMode.Open, FileAccess.Read);
            StreamReader sw = new StreamReader(fs);
            string line = sw.ReadLine();
            while (line != null)
            {                
                string[] splited = line.Split('=');
                Word word = new Word(splited[0].Trim(), splited[1].Trim());
                word_array.Add(word);
                line = sw.ReadLine();
            }
            sw.Close();
            fs.Close();
        }
        int GetRandomNumber(int condition,int condition_option2, int condition_option3)
        {
            Random rnd = new Random();
            while (true)
            {
                int number = rnd.Next(word_array.Count);
                if (number != condition && number != condition_option2 && number != condition_option3)
                    return number;
            }
        }
        void SelectRandomWord()
        {
            Random rnd = new Random();
            int word_index = rnd.Next(word_array.Count);
            lbl_kelime.Text = word_array[word_index].meanofEnglish;
            string right_option = word_array[word_index].meanofTurkish;

            int option2, option3, option4;
            option2 = GetRandomNumber(word_index,-1,-1);
            option3 = GetRandomNumber(word_index, option2, -1);
            option4 = GetRandomNumber(word_index, option2, option3);

            int right_option_location = rnd.Next(4) + 1;
            right_answer = right_option_location;

            switch (right_option_location)
            {
                case 1:
                    lbl_secenek1.Text = "✿ " + word_array[word_index].meanofTurkish;
                    lbl_secenek2.Text = "✿ " + word_array[option2].meanofTurkish;
                    lbl_secenek3.Text = "✿ " + word_array[option3].meanofTurkish;
                    lbl_secenek4.Text = "✿ " + word_array[option4].meanofTurkish;
                    break;
                case 2:
                    lbl_secenek1.Text = "✿ " + word_array[option2].meanofTurkish;
                    lbl_secenek2.Text = "✿ " + word_array[word_index].meanofTurkish;
                    lbl_secenek3.Text = "✿ " + word_array[option3].meanofTurkish;
                    lbl_secenek4.Text = "✿ " + word_array[option4].meanofTurkish;
                    break;
                case 3:                    
                    lbl_secenek1.Text = "✿ " + word_array[option2].meanofTurkish;
                    lbl_secenek2.Text = "✿ " + word_array[option3].meanofTurkish;
                    lbl_secenek3.Text = "✿ " + word_array[word_index].meanofTurkish;
                    lbl_secenek4.Text = "✿ " + word_array[option4].meanofTurkish;
                    break;
                case 4:
                    lbl_secenek1.Text = "✿ " + word_array[option2].meanofTurkish;
                    lbl_secenek2.Text = "✿ " + word_array[option3].meanofTurkish;
                    lbl_secenek3.Text = "✿ " + word_array[option4].meanofTurkish;
                    lbl_secenek4.Text = "✿ " + word_array[word_index].meanofTurkish;
                    break;
                default:
                    break;
            }
        }
        void SelectRightAnswer()
        {
            switch (right_answer)
            {
                case 1:
                    if (lbl_secenek1.ForeColor != Color.DodgerBlue)
                    {
                        lbl_secenek1.ForeColor = Color.Red;
                        lbl_secenek1.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Bold);
                    }
                    break;
                case 2:
                    if (lbl_secenek2.ForeColor != Color.DodgerBlue)
                    {
                        lbl_secenek2.ForeColor = Color.Red;
                        lbl_secenek2.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Bold);
                    }
                    break;
                case 3:
                    if (lbl_secenek3.ForeColor != Color.DodgerBlue)
                    {
                        lbl_secenek3.ForeColor = Color.Red;
                        lbl_secenek3.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Bold);
                    }
                    break;
                case 4:
                    if (lbl_secenek4.ForeColor != Color.DodgerBlue)
                    {
                        lbl_secenek4.ForeColor = Color.Red;
                        lbl_secenek4.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Bold);
                    }
                    break;
                default:
                    break;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            //this.MinimizeBox = false;

            ReadFile();
            SelectRandomWord();
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;

            panel_popup.Visible = false;
            string path = AppDomain.CurrentDomain.BaseDirectory;
            btn_popup.Image = Image.FromFile(path+"/image/popup.png");
        }

        private void lbl_secenek1_MouseMove(object sender, MouseEventArgs e)
        {
            if (lbl_secenek1.ForeColor != Color.Red && lbl_secenek1.ForeColor != Color.DodgerBlue)
            {
                lbl_secenek1.ForeColor = Color.Salmon;
                lbl_secenek1.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
            }
        }

        private void lbl_secenek1_MouseLeave(object sender, EventArgs e)
        {
            if (lbl_secenek1.ForeColor != Color.Red && lbl_secenek1.ForeColor != Color.DodgerBlue)
            {
                lbl_secenek1.ForeColor = Color.DarkGreen;
                lbl_secenek1.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            }
        }
        private void lbl_secenek2_MouseMove(object sender, MouseEventArgs e)
        {
            if (lbl_secenek2.ForeColor != Color.Red && lbl_secenek2.ForeColor != Color.DodgerBlue)
            {
                lbl_secenek2.ForeColor = Color.Salmon;
                lbl_secenek2.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
            }
        }

        private void lbl_secenek2_MouseLeave(object sender, EventArgs e)
        {
            if (lbl_secenek2.ForeColor != Color.Red && lbl_secenek2.ForeColor != Color.DodgerBlue)
            {
                lbl_secenek2.ForeColor = Color.DarkGreen;
                lbl_secenek2.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            }
        }

        private void lbl_secenek3_MouseMove(object sender, MouseEventArgs e)
        {
            if (lbl_secenek3.ForeColor != Color.Red && lbl_secenek3.ForeColor != Color.DodgerBlue)
            {
                lbl_secenek3.ForeColor = Color.Salmon;
                lbl_secenek3.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
            }
        }

        private void lbl_secenek3_MouseLeave(object sender, EventArgs e)
        {
            if (lbl_secenek3.ForeColor != Color.Red && lbl_secenek3.ForeColor != Color.DodgerBlue)
            {
                lbl_secenek3.ForeColor = Color.DarkGreen;
                lbl_secenek3.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            }
        }

        private void lbl_secenek4_MouseMove(object sender, MouseEventArgs e)
        {
            if (lbl_secenek4.ForeColor != Color.Red && lbl_secenek4.ForeColor != Color.DodgerBlue)
            {
                lbl_secenek4.ForeColor = Color.Salmon;
                lbl_secenek4.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
            }
        }

        private void lbl_secenek4_MouseLeave(object sender, EventArgs e)
        {
            if (lbl_secenek4.ForeColor != Color.Red && lbl_secenek4.ForeColor != Color.DodgerBlue)
            {
                lbl_secenek4.ForeColor = Color.DarkGreen;
                lbl_secenek4.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            }
        }

        private void lbl_secenek1_Click(object sender, EventArgs e)
        {
            if (right_answer == 1 && lbl_secenek1.ForeColor != Color.Red)
            {
                pictureBox1.Visible = true;
                lbl_secenek1.ForeColor = Color.DodgerBlue;
                lbl_secenek1.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
            }
            else
            {
                SelectRightAnswer();
            }

        }

        private void lbl_secenek2_Click(object sender, EventArgs e)
        {
            if (right_answer == 2 && lbl_secenek2.ForeColor != Color.Red)
            {
                pictureBox2.Visible = true;
                lbl_secenek2.ForeColor = Color.DodgerBlue;
                lbl_secenek2.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
            }
            else
            {
                SelectRightAnswer();
            }
        }

        private void lbl_secenek3_Click(object sender, EventArgs e)
        {
            if (right_answer == 3 && lbl_secenek3.ForeColor != Color.Red)
            {
                pictureBox3.Visible = true;
                lbl_secenek3.ForeColor = Color.DodgerBlue;
                lbl_secenek3.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
            }
            else
            {
                SelectRightAnswer();
            }
        }

        private void lbl_secenek4_Click(object sender, EventArgs e)
        {
            if (right_answer == 4 && lbl_secenek4.ForeColor != Color.Red)
            {
                pictureBox4.Visible = true;
                lbl_secenek4.ForeColor = Color.DodgerBlue;
                lbl_secenek4.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
            }
            else
            {
                SelectRightAnswer();
            }
        }

        private void btn_sonraki_Click(object sender, EventArgs e)
        {
            lbl_secenek1.ForeColor = Color.DarkGreen;
            lbl_secenek1.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Bold);
            lbl_secenek2.ForeColor = Color.DarkGreen;
            lbl_secenek2.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Bold);
            lbl_secenek3.ForeColor = Color.DarkGreen;
            lbl_secenek3.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Bold);
            lbl_secenek4.ForeColor = Color.DarkGreen;
            lbl_secenek4.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Bold);

            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;

            SelectRandomWord();
        }
        private void btn_popup_Click(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            if (panel_popup.Visible==false)
            {
                panel_popup.Visible = true;
            }                
            else{
                panel_popup.Visible = false;
            }
        }

        private void lbl_ögrendiklerim_MouseMove(object sender, MouseEventArgs e)
        {
            lbl_ögrendiklerim.ForeColor = Color.RoyalBlue;
            lbl_ögrendiklerim.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Bold);
        }

        private void lbl_ögrendiklerim_MouseLeave(object sender, EventArgs e)
        {
            lbl_ögrendiklerim.ForeColor = Color.Teal;
            lbl_ögrendiklerim.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Bold);
        }

        private void lbl_test_MouseMove(object sender, MouseEventArgs e)
        {
            lbl_test.ForeColor = Color.RoyalBlue;
            lbl_test.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Bold);
        }

        private void lbl_test_MouseLeave(object sender, EventArgs e)
        {
            lbl_test.ForeColor = Color.Teal;
            lbl_test.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Bold);
        }

        private void lbl_yenikelimeler_MouseMove(object sender, MouseEventArgs e)
        {
            lbl_yenikelimeler.ForeColor = Color.RoyalBlue;
            lbl_yenikelimeler.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Bold);
        }

        private void lbl_yenikelimeler_MouseLeave(object sender, EventArgs e)
        {
            lbl_yenikelimeler.ForeColor = Color.Teal;
            lbl_yenikelimeler.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Bold);
        }
    }
}

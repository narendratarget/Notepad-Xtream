using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Speech.Synthesis;

namespace notepad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SpeechSynthesizer syn = new SpeechSynthesizer();
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "All File|*.*";
                DialogResult re = openFileDialog1.ShowDialog();
                if (re == DialogResult.OK)
                {
                    FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate);
                    StreamReader sr = new StreamReader(fs);
                    richTextBox1.Text = sr.ReadToEnd().ToString();
                    sr.Close();
                }
                else
                {

                }
            }
            catch (Exception ee) { MessageBox.Show("Some Error Occured in Oppening the file"); }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Filter = "All File|*.*";
                saveFileDialog1.DefaultExt = ".txt";
                if (this.Text == "Untitled Document - 1")
                {
                    DialogResult re = saveFileDialog1.ShowDialog();
                    FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);
                    StreamWriter w = new StreamWriter(fs);

                    if (richTextBox1.TextLength > 0)
                    {

                        if (re == DialogResult.OK)
                        {
                            w.Write(richTextBox1.Text);
                            w.Close();
                            this.Text = saveFileDialog1.FileName;
                        }

                    }
                }
                else
                {
                    FileStream fs = new FileStream(this.Text, FileMode.Create);
                    StreamWriter w = new StreamWriter(fs);
                    w.Write("");
                    w.Write(richTextBox1.Text);
                    w.Close();
                }
            }
            catch (Exception hgh) { }
        }

        private void speakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(richTextBox1.SelectedText=="")
            syn.SpeakAsync(richTextBox1.Text);
            else
                syn.SpeakAsync(richTextBox1.SelectedText);
        }

        private void audioTextSpeakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Untitled Document - 1";
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            aToolStripMenuItem.Text = DateTime.Now.ToString();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void timeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = richTextBox1.Text +"\n"+ DateTime.Now.ToString();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
           DialogResult r= fontDialog1.ShowDialog();
           if (r == DialogResult.OK)
           {
               richTextBox1.Font = fontDialog1.Font;
           }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r = colorDialog1.ShowDialog();
            if (r == DialogResult.OK)
            {
                richTextBox1.ForeColor = colorDialog1.Color;
            }
        }
        string s = "";
        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Space)
            {
                syn.SpeakAsync(s);
                s = "";
            }
            else
            {
                if (e.KeyData == Keys.Back)
                {
                }
                else
                {
                    s = s + e.KeyData;
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gotExit();
        }
        void gotExit()
        {
            try
            {
                if (this.Text == "Untitled Document - 1")
                {
                    if (richTextBox1.TextLength > 0)
                    {
                        saveFileDialog1.Filter = "All File|*.*";
                        saveFileDialog1.DefaultExt = ".txt";
                        DialogResult re = saveFileDialog1.ShowDialog();
                        FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);
                        StreamWriter w = new StreamWriter(fs);
                        if (re == DialogResult.OK)
                        {
                            w.Write(richTextBox1.Text);
                            w.Close();
                            this.Text = saveFileDialog1.FileName;
                        }
                    }
                    else
                    {
                        Application.ExitThread();
                    }
                }
                else
                {
                    FileStream fs = new FileStream(this.Text, FileMode.Create);
                    StreamWriter w = new StreamWriter(fs);
                    w.Write("");
                    w.Write(richTextBox1.Text);
                    w.Close();
                    richTextBox1.Text = "";
                    Application.ExitThread();
                }
            }
            catch (Exception oo) { }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Text == "Untitled Document - 1")
                {
                    if (richTextBox1.TextLength > 0)
                    {
                        saveFileDialog1.Filter = "All File|*.*";
                        saveFileDialog1.DefaultExt = ".txt";
                        DialogResult re = saveFileDialog1.ShowDialog();
                        FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);
                        StreamWriter w = new StreamWriter(fs);
                        if (re == DialogResult.OK)
                        {
                            w.Write(richTextBox1.Text);
                            w.Close();
                            this.Text = saveFileDialog1.FileName;
                        }
                    }
                }
                else
                {
                    FileStream fs = new FileStream(this.Text, FileMode.Create);
                    StreamWriter w = new StreamWriter(fs);
                    w.Write("");
                    w.Write(richTextBox1.Text);
                    w.Close();
                    richTextBox1.Text = "";
                    this.Text = "Untitled Document - 1";
                }
            }
            catch (Exception jhgjg) { }
        }

        private void saveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Filter = "All File|*.*";
                saveFileDialog1.DefaultExt = ".txt";
                  
                    if (richTextBox1.TextLength > 0)
                    {
                        DialogResult re = saveFileDialog1.ShowDialog();
                        FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);
                        StreamWriter w = new StreamWriter(fs);
                        if (re == DialogResult.OK)
                        {
                            w.Write(richTextBox1.Text);
                            w.Close();
                            this.Text = saveFileDialog1.FileName;
                        }

                    }
                
            }
            catch (Exception hdghjdfjf) { }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void formatToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = richTextBox1.Text +"\n"+ DateTime.Now.ToString();
        }

        private void saveWithEncryptionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void contactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contact c = new Contact();
            c.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you really want to Exit ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                gotExit();
            }
        }

       
    }
}

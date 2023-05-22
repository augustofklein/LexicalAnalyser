using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace Analyser
{
    public partial class LexicalAnaliser : Form
    {
        public LexicalAnaliser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = this.openFileDialog.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader sr = null;

                try
                {
                    sr = File.OpenText(openFileDialog.FileName);

                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                    }
                }
                catch (IOException exception)
                {
                    Console.WriteLine("An error acurred");
                    Console.WriteLine(exception.Message);
                }
                finally
                {
                    if (sr != null) sr.Close();
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            
        }
    }
}

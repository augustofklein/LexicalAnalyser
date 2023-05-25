using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using Analyser.Code;
using System.Text.RegularExpressions;

namespace Analyser
{
    public partial class LexicalAnaliser : Form
    {
        public const string tkmain = "main";
        public const string tkint = "int";
        public const string tkvoid = "void";
        public const string tkfloat = "float";
        public const string tkstring = "string";
        public const string tkabreparenteses = "(";
        public const string tkfechaparenteses = ")";

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
            List<Token> tokens = new List<Token>();
            List<TokenScreen> tokensScreen = new List<TokenScreen>();

            DataGridTableStyle teste = new DataGridTableStyle();

            teste.MappingName = "teste";

            tokens.Add(new Token("tkmain", "main"));
            tokens.Add(new Token("tkint", "int"));
            tokens.Add(new Token("tkfloat", "float"));
            tokens.Add(new Token("tkstring", "string"));

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader sr = null;

                try
                {
                    sr = File.OpenText(openFileDialog.FileName);

                    int countLine = 0;
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        countLine++;

                        foreach (Token token in tokens)
                        {
                            // Expressão em Regex para encontrar a sentença
                            string mypattern = string.Format(@"\b{0}\b", token.Data);

                            // Procura os padrões na senteça
                            MatchCollection matches = Regex.Matches(line, mypattern);

                            // Adição do token em tela
                            if (matches.Count > 0)
                            {
                                foreach (Match match in matches)
                                {
                                    tokensScreen.Add(new TokenScreen(countLine, match.Index + 1, token.Name, token.Data));
                                    
                                }
                            }
                        }
                        dataGridView1.DataSource = tokensScreen;
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

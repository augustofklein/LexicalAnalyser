using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using Analyser.Code;
using System.Text.RegularExpressions;
using System.Linq.Expressions;

namespace Analyser
{
    public partial class LexicalAnaliser : Form
    {

        public LexicalAnaliser()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = this.openFileDialog.ShowDialog();
            List<Token> tokens = new List<Token>();
            List<TokenScreen> tokensScreen = new List<TokenScreen>();

            tokens.Add(new Token("tkmain", "main"));

            // Declrações de variáveis
            tokens.Add(new Token("tkint", "int"));
            tokens.Add(new Token("tkfloat", "float"));
            tokens.Add(new Token("tkchar", "char"));
            tokens.Add(new Token("tkdouble", "double"));
            tokens.Add(new Token("tkstruct", "struct"));

            // Declarações iterativas
            tokens.Add(new Token("tkwhile", "while"));
            tokens.Add(new Token("tkfor", "for"));
            tokens.Add(new Token("tkif", "if"));
            tokens.Add(new Token("tkelse", "else"));

            // Parenteses
            tokens.Add(new Token("tkabreparenteses", "("));
            tokens.Add(new Token("tkafechaparenteses", ")"));

            // Chaves
            tokens.Add(new Token("tkaabrechaves", "{"));
            tokens.Add(new Token("tkafechachaves", "}"));

            // Operadores compartativos
            tokens.Add(new Token("tkigual", "=="));
            tokens.Add(new Token("tkdiferente", "<>"));
            tokens.Add(new Token("tkdiferente", "!="));
            tokens.Add(new Token("tkmaiorigual", ">="));
            tokens.Add(new Token("tkmenorigual", "<="));

            // Operadores
            tokens.Add(new Token("tksoma", "+"));
            tokens.Add(new Token("tksubtracao", "-"));
            tokens.Add(new Token("tkdivisao", "/"));
            tokens.Add(new Token("tkmultiplicacao", "*"));
            tokens.Add(new Token("tkresto", "%"));

            // Operadores bitwise
            tokens.Add(new Token("tkbitwiseand", "&"));
            //tokens.Add(new Token("tkbitwiseor", "|"));
            //tokens.Add(new Token("tkbitwisexor", "^"));
            tokens.Add(new Token("tkbitwisenot", "~"));

            // Ponteiro
            tokens.Add(new Token("tkponteiro", "*"));

            // Negação
            tokens.Add(new Token("tknegacao", "!"));

            // Laços
            tokens.Add(new Token("tkdo", "do"));
            tokens.Add(new Token("tkwhile", "while"));
            tokens.Add(new Token("tkcase", "case"));
            tokens.Add(new Token("tkdefault", "default"));

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader sr = null;

                try
                {
                    sr = File.OpenText(openFileDialog.FileName);

                    int countLine = 0;
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        countLine++;

                        foreach (Token token in tokens)
                        {
                            string mypattern;
                            MatchCollection matches;

                            // Expressão em Regex para encontrar a sentença
                            if (token.Data.Length == 1)
                            {
                                mypattern = string.Format(@"[{0}]", token.Data);
                            }
                            else
                            {
                                mypattern = string.Format(@"{0}", token.Data);
                            }

                            matches = Regex.Matches(line, mypattern);

                            // Adição do token em tela
                            if (matches.Count > 0)
                            {
                                foreach (Match match in matches)
                                {
                                    tokensScreen.Add(new TokenScreen(countLine, match.Index + 1, token.Name, token.Data));

                                }
                            }
                        }
                    }
                    dataGridView1.DataSource = tokensScreen;
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

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {

        }

    }
}

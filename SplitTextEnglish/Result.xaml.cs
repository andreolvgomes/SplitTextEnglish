using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TextEnglish
{
    /// <summary>
    /// Interaction logic for Result.xaml
    /// </summary>
    public partial class Result : Window
    {
        public Result(Window owner, List<Phrase> phrases)
        {
            InitializeComponent();
            this.Owner = owner;

            this.Height = owner.Height;
            this.Width = owner.Width;

            for (int i = 0; i < phrases.Count; i++)
            {
                if (i > 0)
                    this.txtResult.Text += "\n\n";

                Phrase phrase = phrases[i];
                this.txtResult.Text += phrase.English.Replace("\r\n", " ");

                if (!string.IsNullOrEmpty(phrase.Transcricao))
                {
                    this.txtResult.Text += "\n";
                    this.txtResult.Text += phrase.Transcricao.Replace("\r\n", " ");
                }

                this.txtResult.Text += "\n";
                this.txtResult.Text += phrase.Portuguese.Replace("\r\n", " ");
            }
        }
    }
}

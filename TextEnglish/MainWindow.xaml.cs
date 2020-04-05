using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TextEnglish
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (this.Valida())
            {
                List<Phrase> phrases = this.GetPhrases(this.txtIngles.Text, this.txtPortugues.Text);
                Html h = new Html();
                string html = h.GerHtml(phrases);

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text Files | *.html";
                saveFileDialog.FileName = "Texto em partes.html";
                if (saveFileDialog.ShowDialog() == true)
                {
                    System.IO.File.WriteAllText(saveFileDialog.FileName, html);
                    MessageBox.Show("Html salvo com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.Valida())
            {
                List<Phrase> phrases = this.GetPhrases(this.txtIngles.Text, this.txtPortugues.Text);
                Result r = new Result(this, phrases);
                r.ShowDialog();
            }
        }

        private List<Phrase> GetPhrases(string english, string portuguese)
        {
            List<Phrase> list = new List<Phrase>();
            string[] split_en = english.Split('.');
            string[] split_pt = portuguese.Split('.');

            for (int i = 0; i < split_en.Length; i++)
            {
                Phrase phrase = new Phrase();
                phrase.English = split_en[i].Trim();
                phrase.Portuguese = split_pt[i].Trim();

                list.Add(phrase);
            }
            return list;
        }

        private bool Valida()
        {
            if (string.IsNullOrEmpty(this.txtIngles.Text))
            {
                MessageBox.Show("Informe o texto em inglês", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
                return this.SetText(this.txtIngles);
            }
            if (string.IsNullOrEmpty(this.txtPortugues.Text))
            {
                MessageBox.Show("Informe o texto em português", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
                return this.SetText(this.txtPortugues);
            }

            int number_en = this.NumberPhrase(this.txtIngles.Text);
            int number_pt = this.NumberPhrase(this.txtPortugues.Text);
            if (number_en != number_pt)
            {
                MessageBox.Show("Texto inglês não contém a mesma quantidade de frases que em português", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
                return this.SetText(this.txtPortugues);
            }

            return true;
        }

        private int NumberPhrase(string text)
        {
            int quantity = 0;
            foreach (string fra in text.Split('.'))
            {
                if (!string.IsNullOrEmpty(fra))
                    quantity++;
            }
            return quantity;
        }

        private bool SetText(TextBox text)
        {
            text.Focus();
            text.SelectAll();
            return false;
        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.txtIngles.Text = this.txtPortugues.Text = "";
        }
    }
}

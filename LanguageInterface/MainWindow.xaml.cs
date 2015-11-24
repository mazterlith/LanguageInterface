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
using DynamicLanguageLibrary;

namespace LanguageInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DynamicLanguageLibrary.PhoneticAlphabet IPA, IPA2;
        Language PseudoEnglish = new Language()
        {
            Name = "PseudoEnglish"
        };

        public MainWindow()
        {
            InitializeComponent();

            DynamicLanguageLibrary.Language.SaveoutIPA();
            DynamicLanguageLibrary.Language.SaveoutIPA("PhonemeAlphabets\\InternationalPhoneticAlphabet.xml");

            PseudoEnglish.SetMorphemeStats("MorphemeSets\\EnglishMorphemes.txt");
            PseudoEnglish.PhoneticAlphabet = new PhoneticAlphabet("PhonemeAlphabets\\InternationalPhoneticAlphabet.xml");

            DynamicLanguageLibrary.Language.SaveoutEnglishChars(PseudoEnglish.PhoneticAlphabet);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}

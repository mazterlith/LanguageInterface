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
using Language = DynamicLanguageLibrary.Language;

namespace LanguageInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string phonemeFile = "PhonemeAlphabets\\InternationalPhoneticAlphabet.xml";
        const string characterFile = "CharacterAlphabets\\EnglishCharacters.xml";

        private PhoneticAlphabet _IPA, _englishPA;
        private CharacterAlphabet _englishCA;
        private Language _pseudoEnglish;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _IPA = DynamicLanguageLibrary.Language.GenerateIPA();

                _englishPA = new PhoneticAlphabet()
                {
                    Name = "English Phonetic Alphabet"
                };

                PopulateEnglishPA();

                _englishCA = new CharacterAlphabet()
                {
                    Name = "PseudoEnglish Character Alphabet"
                };

                PopulateEnglishCA();

                _pseudoEnglish = new Language()
                {
                    Name = "PseudoEnglish"
                };

                _pseudoEnglish.PhoneticAlphabet = _englishPA;
                _pseudoEnglish.CharacterAlphabet = _englishCA;

                _pseudoEnglish.SetMorphemeStats("MorphemeSets\\EnglishMorphemes.txt");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PopulateEnglishPA()
        {
            #region Vowels

            VowelPhoneme vowelPhoneme;

            vowelPhoneme = _IPA.Vowels.FirstOrDefault
                (
                    x =>
                    x.Backnesses.Contains(TongueBackness.Front) &&
                    x.Heights.Contains(TongueHeight.Open) &&
                    x.Rounded.ToBool() == false
                );
            _englishPA.Vowels.Add(vowelPhoneme);

            vowelPhoneme = _IPA.Vowels.FirstOrDefault
                (
                    x =>
                    x.Backnesses.Contains(TongueBackness.Back) &&
                    x.Heights.Contains(TongueHeight.Open) &&
                    x.Rounded.ToBool() == false
                );
            _englishPA.Vowels.Add(vowelPhoneme);

            vowelPhoneme = _IPA.Vowels.FirstOrDefault
                (
                    x =>
                    x.Backnesses.Contains(TongueBackness.Front) &&
                    x.Heights.Contains(TongueHeight.NearOpen) &&
                    x.Rounded.ToBool() == false
                );
            _englishPA.Vowels.Add(vowelPhoneme);

            vowelPhoneme = _IPA.Vowels.FirstOrDefault
                (
                    x =>
                    x.Backnesses.Contains(TongueBackness.Front) &&
                    x.Heights.Contains(TongueHeight.CloseMid) &&
                    x.Rounded.ToBool() == false
                );
            _englishPA.Vowels.Add(vowelPhoneme);

            vowelPhoneme = _IPA.Vowels.FirstOrDefault
                (
                    x =>
                    x.Backnesses.Contains(TongueBackness.Front) &&
                    x.Heights.Contains(TongueHeight.OpenMid) &&
                    x.Rounded.ToBool() == false
                );
            _englishPA.Vowels.Add(vowelPhoneme);

            vowelPhoneme = _IPA.Vowels.FirstOrDefault
                (
                    x =>
                    x.Backnesses.Contains(TongueBackness.Central) &&
                    x.Heights.Contains(TongueHeight.OpenMid) &&
                    x.Rounded.ToBool() == false
                );
            _englishPA.Vowels.Add(vowelPhoneme);

            vowelPhoneme = _IPA.Vowels.FirstOrDefault
                (
                    x =>
                    x.Backnesses.Contains(TongueBackness.Central) &&
                    x.Heights.Contains(TongueHeight.Mid) &&
                    x.Rounded.ToBool() == false
                );
            _englishPA.Vowels.Add(vowelPhoneme);

            vowelPhoneme = _IPA.Vowels.FirstOrDefault
                (
                    x =>
                    x.Backnesses.Contains(TongueBackness.Front) &&
                    x.Heights.Contains(TongueHeight.Close) &&
                    x.Rounded.ToBool() == false
                );
            _englishPA.Vowels.Add(vowelPhoneme);

            vowelPhoneme = _IPA.Vowels.FirstOrDefault
                (
                    x =>
                    x.Backnesses.Contains(TongueBackness.NearFront) &&
                    x.Heights.Contains(TongueHeight.NearClose) &&
                    x.Rounded.ToBool() == false
                );
            _englishPA.Vowels.Add(vowelPhoneme);

            vowelPhoneme = _IPA.Vowels.FirstOrDefault
                (
                    x =>
                    x.Backnesses.Contains(TongueBackness.Back) &&
                    x.Heights.Contains(TongueHeight.CloseMid) &&
                    x.Rounded.ToBool() == true
                );
            _englishPA.Vowels.Add(vowelPhoneme);

            vowelPhoneme = _IPA.Vowels.FirstOrDefault
                (
                    x =>
                    x.Backnesses.Contains(TongueBackness.Back) &&
                    x.Heights.Contains(TongueHeight.OpenMid) &&
                    x.Rounded.ToBool() == true
                );
            _englishPA.Vowels.Add(vowelPhoneme);

            vowelPhoneme = _IPA.Vowels.FirstOrDefault
                (
                    x =>
                    x.Backnesses.Contains(TongueBackness.Back) &&
                    x.Heights.Contains(TongueHeight.Close) &&
                    x.Rounded.ToBool() == true
                );
            _englishPA.Vowels.Add(vowelPhoneme);

            vowelPhoneme = _IPA.Vowels.FirstOrDefault
                (
                    x =>
                    x.Backnesses.Contains(TongueBackness.Back) &&
                    x.Heights.Contains(TongueHeight.OpenMid) &&
                    x.Rounded.ToBool() == false
                );
            _englishPA.Vowels.Add(vowelPhoneme);

            vowelPhoneme = _IPA.Vowels.FirstOrDefault
                (
                    x =>
                    x.Backnesses.Contains(TongueBackness.NearBack) &&
                    x.Heights.Contains(TongueHeight.NearClose) &&
                    x.Rounded.ToBool() == true
                );
            _englishPA.Vowels.Add(vowelPhoneme);

            #endregion

            #region Consonants

            ConsonantPhoneme consonantPhoneme;

            consonantPhoneme = _IPA.Consonants.FirstOrDefault
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.Stop) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Bilabial) &&
                    x.Voiced.ToBool() == true
                );
            _englishPA.Consonants.Add(consonantPhoneme);

            consonantPhoneme = _IPA.Consonants.FirstOrDefault
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.Stop) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Alveolar) &&
                    x.Voiced.ToBool() == true
                );
            _englishPA.Consonants.Add(consonantPhoneme);

            consonantPhoneme = _IPA.Consonants.FirstOrDefault
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.NonSibilantFricative) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Labiodental) &&
                    x.Voiced.ToBool() == false
                );
            _englishPA.Consonants.Add(consonantPhoneme);

            consonantPhoneme = _IPA.Consonants.FirstOrDefault
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.Stop) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Velar) &&
                    x.Voiced.ToBool() == true
                );
            _englishPA.Consonants.Add(consonantPhoneme);

            consonantPhoneme = _IPA.Consonants.FirstOrDefault
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.NonSibilantFricative) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Glottal) &&
                    x.Voiced.ToBool() == false
                );
            _englishPA.Consonants.Add(consonantPhoneme);

            consonantPhoneme = _IPA.Consonants.FirstOrDefault
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.SibilantAffricate) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Palatoalveolar) &&
                    x.Voiced.ToBool() == true
                );
            _englishPA.Consonants.Add(consonantPhoneme);

            consonantPhoneme = _IPA.Consonants.FirstOrDefault
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.Stop) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Velar) &&
                    x.Voiced.ToBool() == false
                );
            _englishPA.Consonants.Add(consonantPhoneme);

            consonantPhoneme = _IPA.Consonants.FirstOrDefault
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.LateralApproximate) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Alveolar) &&
                    x.Voiced.ToBool() == true
                );
            _englishPA.Consonants.Add(consonantPhoneme);

            consonantPhoneme = _IPA.Consonants.FirstOrDefault
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.Nasal) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Bilabial) &&
                    x.Voiced.ToBool() == true
                );
            _englishPA.Consonants.Add(consonantPhoneme);

            consonantPhoneme = _IPA.Consonants.FirstOrDefault
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.Nasal) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Alveolar) &&
                    x.Voiced.ToBool() == true
                );
            _englishPA.Consonants.Add(consonantPhoneme);

            consonantPhoneme = _IPA.Consonants.FirstOrDefault
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.Stop) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Bilabial) &&
                    x.Voiced.ToBool() == false
                );
            _englishPA.Consonants.Add(consonantPhoneme);

            consonantPhoneme = _IPA.Consonants.FirstOrDefault
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.Approximant) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Alveolar) &&
                    x.Voiced.ToBool() == true
                );
            _englishPA.Consonants.Add(consonantPhoneme);

            consonantPhoneme = _IPA.Consonants.FirstOrDefault
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.SibilantFricative) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Alveolar) &&
                    x.Voiced.ToBool() == false
                );
            _englishPA.Consonants.Add(consonantPhoneme);

            consonantPhoneme = _IPA.Consonants.FirstOrDefault
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.Stop) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Alveolar) &&
                    x.Voiced.ToBool() == false
                );
            _englishPA.Consonants.Add(consonantPhoneme);

            consonantPhoneme = _IPA.Consonants.FirstOrDefault
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.NonSibilantFricative) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Labiodental) &&
                    x.Voiced.ToBool() == true
                );
            _englishPA.Consonants.Add(consonantPhoneme);

            consonantPhoneme = _IPA.Consonants.FirstOrDefault
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.Approximant) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Palatal) &&
                    x.Voiced.ToBool() == true
                );
            _englishPA.Consonants.Add(consonantPhoneme);

            consonantPhoneme = _IPA.Consonants.FirstOrDefault
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.SibilantFricative) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Alveolar) &&
                    x.Voiced.ToBool() == true
                );
            _englishPA.Consonants.Add(consonantPhoneme);

            consonantPhoneme = _IPA.Consonants.FirstOrDefault
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.NonSibilantFricative) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Dental) &&
                    x.Voiced.ToBool() == false
                );
            _englishPA.Consonants.Add(consonantPhoneme);

            consonantPhoneme = _IPA.Consonants.FirstOrDefault
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.NonSibilantFricative) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Dental) &&
                    x.Voiced.ToBool() == true
                );
            _englishPA.Consonants.Add(consonantPhoneme);

            consonantPhoneme = _IPA.Consonants.FirstOrDefault
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.SibilantFricative) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Palatoalveolar) &&
                    x.Voiced.ToBool() == false
                );
            _englishPA.Consonants.Add(consonantPhoneme);

            consonantPhoneme = _IPA.Consonants.FirstOrDefault
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.SibilantFricative) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Palatoalveolar) &&
                    x.Voiced.ToBool() == true
                );
            _englishPA.Consonants.Add(consonantPhoneme);

            consonantPhoneme = _IPA.Consonants.FirstOrDefault
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.SibilantAffricate) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Palatoalveolar) &&
                    x.Voiced.ToBool() == false
                );
            _englishPA.Consonants.Add(consonantPhoneme);

            consonantPhoneme = _IPA.Consonants.FirstOrDefault
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.Nasal) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Velar) &&
                    x.Voiced.ToBool() == true
                );
            _englishPA.Consonants.Add(consonantPhoneme);

            #endregion
        }

        private void PopulateEnglishCA()
        {
            List<Phoneme> phonemesForCharacter;

            phonemesForCharacter = _englishPA.Vowels.Where
                   (
                       x =>
                       x.Backnesses.Contains(TongueBackness.Front) &&
                       x.Heights.Contains(TongueHeight.Open) &&
                       x.Rounded.ToBool() == false
                   ).ToList<Phoneme>();

            _englishCA.Add(new Character("a", phonemesForCharacter));

            phonemesForCharacter = _englishPA.Consonants.Where
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.Stop) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Bilabial) &&
                    x.Voiced.ToBool() == true
                ).ToList<Phoneme>();
            _englishCA.Add(new Character("b", phonemesForCharacter));

            phonemesForCharacter = _englishPA.Consonants.Where
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.Stop) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Alveolar) &&
                    x.Voiced.ToBool() == true
                ).ToList<Phoneme>();
            _englishCA.Add(new Character("d", phonemesForCharacter));

            phonemesForCharacter = _englishPA.Vowels.Where
                (
                    x =>
                    x.Backnesses.Contains(TongueBackness.Front) &&
                    x.Heights.Contains(TongueHeight.CloseMid) &&
                    x.Rounded.ToBool() == false
                ).ToList<Phoneme>();
            _englishCA.Add(new Character("e", phonemesForCharacter));

            phonemesForCharacter = _englishPA.Consonants.Where
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.NonSibilantFricative) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Labiodental) &&
                    x.Voiced.ToBool() == false
                ).ToList<Phoneme>();
            _englishCA.Add(new Character("f", phonemesForCharacter));

            phonemesForCharacter = _englishPA.Consonants.Where
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.Stop) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Velar) &&
                    x.Voiced.ToBool() == true
                ).ToList<Phoneme>();
            _englishCA.Add(new Character("g", phonemesForCharacter));

            phonemesForCharacter = _englishPA.Consonants.Where
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.NonSibilantFricative) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Glottal) &&
                    x.Voiced.ToBool() == false
                ).ToList<Phoneme>();
            _englishCA.Add(new Character("h", phonemesForCharacter));

            phonemesForCharacter = _englishPA.Vowels.Where
                (
                    x =>
                    x.Backnesses.Contains(TongueBackness.Front) &&
                    x.Heights.Contains(TongueHeight.Close) &&
                    x.Rounded.ToBool() == false
                ).ToList<Phoneme>();
            _englishCA.Add(new Character("i", phonemesForCharacter));

            phonemesForCharacter = _englishPA.Consonants.Where
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.SibilantAffricate) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Palatoalveolar) &&
                    x.Voiced.ToBool() == true
                ).ToList<Phoneme>();
            _englishCA.Add(new Character("j", phonemesForCharacter));

            phonemesForCharacter = _englishPA.Consonants.Where
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.Stop) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Velar) &&
                    x.Voiced.ToBool() == false
                ).ToList<Phoneme>();
            _englishCA.Add(new Character("k", phonemesForCharacter));

            phonemesForCharacter = _englishPA.Consonants.Where
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.LateralApproximate) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Alveolar) &&
                    x.Voiced.ToBool() == true
                ).ToList<Phoneme>();
            _englishCA.Add(new Character("l", phonemesForCharacter));

            phonemesForCharacter = _englishPA.Consonants.Where
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.Nasal) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Bilabial) &&
                    x.Voiced.ToBool() == true
                ).ToList<Phoneme>();
            _englishCA.Add(new Character("m", phonemesForCharacter));

            phonemesForCharacter = _englishPA.Consonants.Where
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.Nasal) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Alveolar) &&
                    x.Voiced.ToBool() == true
                ).ToList<Phoneme>();
            _englishCA.Add(new Character("n", phonemesForCharacter));

            phonemesForCharacter = _englishPA.Vowels.Where
                (
                    x =>
                    x.Backnesses.Contains(TongueBackness.Back) &&
                    x.Heights.Contains(TongueHeight.CloseMid) &&
                    x.Rounded.ToBool() == true
                ).ToList<Phoneme>();
            _englishCA.Add(new Character("o", phonemesForCharacter));

            phonemesForCharacter = _englishPA.Consonants.Where
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.Stop) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Bilabial) &&
                    x.Voiced.ToBool() == false
                ).ToList<Phoneme>();
            _englishCA.Add(new Character("p", phonemesForCharacter));

            phonemesForCharacter = _englishPA.Consonants.Where
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.Approximant) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Alveolar) &&
                    x.Voiced.ToBool() == true
                ).ToList<Phoneme>();
            _englishCA.Add(new Character("r", phonemesForCharacter));

            phonemesForCharacter = _englishPA.Consonants.Where
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.SibilantFricative) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Alveolar) &&
                    x.Voiced.ToBool() == false
                ).ToList<Phoneme>();
            _englishCA.Add(new Character("s", phonemesForCharacter));

            phonemesForCharacter = _englishPA.Consonants.Where
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.Stop) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Alveolar) &&
                    x.Voiced.ToBool() == false
                ).ToList<Phoneme>();
            _englishCA.Add(new Character("t", phonemesForCharacter));

            phonemesForCharacter = _englishPA.Vowels.Where
                (
                    x =>
                    x.Backnesses.Contains(TongueBackness.Back) &&
                    x.Heights.Contains(TongueHeight.Close) &&
                    x.Rounded.ToBool() == true
                ).ToList<Phoneme>();
            _englishCA.Add(new Character("u", phonemesForCharacter));

            phonemesForCharacter = _englishPA.Consonants.Where
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.NonSibilantFricative) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Labiodental) &&
                    x.Voiced.ToBool() == true
                ).ToList<Phoneme>();
            _englishCA.Add(new Character("v", phonemesForCharacter));

            phonemesForCharacter = _englishPA.Consonants.Where
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.Approximant) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Palatal) &&
                    x.Voiced.ToBool() == true
                ).ToList<Phoneme>();
            _englishCA.Add(new Character("y", phonemesForCharacter));

            phonemesForCharacter = _englishPA.Consonants.Where
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.SibilantFricative) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Alveolar) &&
                    x.Voiced.ToBool() == true
                ).ToList<Phoneme>();
            _englishCA.Add(new Character("z", phonemesForCharacter));

            phonemesForCharacter = _englishPA.Consonants.Where
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.NonSibilantFricative) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Dental) &&
                    x.Voiced.ToBool() == false
                ).ToList<Phoneme>();
            _englishCA.Add(new Character("θ", phonemesForCharacter));

            phonemesForCharacter = _englishPA.Consonants.Where
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.SibilantFricative) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Palatoalveolar) &&
                    x.Voiced.ToBool() == false
                ).ToList<Phoneme>();
            _englishCA.Add(new Character("ʃ", phonemesForCharacter));

            phonemesForCharacter = _englishPA.Consonants.Where
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.Nasal) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Velar) &&
                    x.Voiced.ToBool() == true
                ).ToList<Phoneme>();
            _englishCA.Add(new Character("ŋ", phonemesForCharacter));
        }
    }
}

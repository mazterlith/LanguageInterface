using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DynamicLanguageLibrary
{
    public class Language
    {
        public PhoneticAlphabet PhoneticAlphabet { get; set; }
        public CharacterAlphabet CharacterAlphabet { get; set; }
        public string Name { get; set; }

        public Language(string phonemeFile = null, string characterFile = null, string morphemeFile = null)
        {
            PhoneticAlphabet = new PhoneticAlphabet(phonemeFile);

            if (characterFile != null)
                CharacterAlphabet = new CharacterAlphabet(characterFile);

            if (morphemeFile != null && characterFile != null)
                SetMorphemeStats(morphemeFile);
        }

        public void SetMorphemeStats(string filename)
        {
            StreamReader sr;
            try
            {
                sr = new StreamReader(filename);
            }
            catch (Exception e)
            {
                throw new FileLoadException("Error in SetMorphemeStats()", e);
            }

            int numWeights = 0;
            int[] lengthWeights = new int[16];

            string source = sr.ReadLine();

            while (sr.Peek() >= 0)
            {
                string phoneme = sr.ReadLine();

                lengthWeights[phoneme.Length - 1]++;
                numWeights++;

                char a = phoneme[0];
            }

        }

        public Morpheme GenerateMorpheme(int? seed = null)
        {
            Morpheme morpheme = new Morpheme();

            List<Phoneme> totalPhonemes = new List<Phoneme>(this.PhoneticAlphabet.Consonants);
            totalPhonemes.AddRange(this.PhoneticAlphabet.Vowels);

            int phonemesCount = totalPhonemes.Count;
            int consonantCount = this.PhoneticAlphabet.Consonants.Count;
            int vowelCount = this.PhoneticAlphabet.Vowels.Count;

            Random rng;

            if (seed != null)
                rng = new Random(seed.Value);
            else
                rng = new Random();

            Phoneme firstPhoneme = totalPhonemes[rng.Next(phonemesCount)];



            return morpheme;
        }

        public static void SaveoutIPA(string filename = null)
        {
            if (filename == null)
                filename = "InternationalPhoneticAlphabet.xml";

            PhoneticAlphabet IPA = new PhoneticAlphabet()
            {
                Name = "IPA"
            };

            #region CONSONANTS

            #region Nasals

            IPA.Consonants.Add(new ConsonantPhoneme("m̥", "m in prisme, French", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Bilabial },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Nasal }));

            IPA.Consonants.Add(new ConsonantPhoneme("m", "m in map, English", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Bilabial },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Nasal }));

            IPA.Consonants.Add(new ConsonantPhoneme("ɱ", "m in symphony, English", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Labiodental },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Nasal }));

            IPA.Consonants.Add(new ConsonantPhoneme("n̼̊", "unknown", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Linguolabial },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Nasal }));

            IPA.Consonants.Add(new ConsonantPhoneme("n̼", "m̼ in m̼isi, Araki", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Linguolabial },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Nasal }));

            IPA.Consonants.Add(new ConsonantPhoneme("n̥", "n in lasn, Estonian", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Dental, PlaceOfArticulation.Alveolar, PlaceOfArticulation.Palatoalveolar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Nasal }));

            IPA.Consonants.Add(new ConsonantPhoneme("n", "n in month, English", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Dental, PlaceOfArticulation.Alveolar, PlaceOfArticulation.Palatoalveolar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Nasal }));

            IPA.Consonants.Add(new ConsonantPhoneme("ɳ̊", "unknown", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Retroflex },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Nasal }));

            IPA.Consonants.Add(new ConsonantPhoneme("ɳ", "rn in garn, Norwegian", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Retroflex },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Nasal }));

            IPA.Consonants.Add(new ConsonantPhoneme("ɲ̊", "n in onki, Faroese", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Alveolopalatal, PlaceOfArticulation.Palatal },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Nasal }));

            IPA.Consonants.Add(new ConsonantPhoneme("ɲ", "gn in agneau, French", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Alveolopalatal, PlaceOfArticulation.Palatal },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Nasal }));

            IPA.Consonants.Add(new ConsonantPhoneme("ŋ̊", "n in onkur, Faroese", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Velar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Nasal }));

            IPA.Consonants.Add(new ConsonantPhoneme("ŋ", "ng in sing, English", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Velar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Nasal }));

            IPA.Consonants.Add(new ConsonantPhoneme("ɴ̥", "unknown", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Uvular },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Nasal }));

            IPA.Consonants.Add(new ConsonantPhoneme("ɴ", "n in enjuto, Spanish", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Uvular },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Nasal }));

            #endregion

            #region Stops

            IPA.Consonants.Add(new ConsonantPhoneme("p", "p in push, English", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Bilabial },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Stop }));

            IPA.Consonants.Add(new ConsonantPhoneme("b", "b in aback, English", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Bilabial },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Stop }));

            IPA.Consonants.Add(new ConsonantPhoneme("p̪", "π in σάπφειρος, Greek", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Labiodental },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Stop }));

            IPA.Consonants.Add(new ConsonantPhoneme("b̪", "unknown", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Labiodental },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Stop }));

            IPA.Consonants.Add(new ConsonantPhoneme("t̼", "unknown", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Linguolabial },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Stop }));

            IPA.Consonants.Add(new ConsonantPhoneme("d̼", "unknown", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Linguolabial },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Stop }));

            IPA.Consonants.Add(new ConsonantPhoneme("t", "t in tick, English", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Dental, PlaceOfArticulation.Alveolar, PlaceOfArticulation.Palatoalveolar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Stop }));

            IPA.Consonants.Add(new ConsonantPhoneme("d", "d in dash, English", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Dental, PlaceOfArticulation.Alveolar, PlaceOfArticulation.Palatoalveolar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Stop }));

            IPA.Consonants.Add(new ConsonantPhoneme("ʈ", "t in kort, Norwegian", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Retroflex },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Stop }));

            IPA.Consonants.Add(new ConsonantPhoneme("ɖ", "rd in varde, Norwegian", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Retroflex },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Stop }));

            IPA.Consonants.Add(new ConsonantPhoneme("c", "k in keen, English", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Alveolopalatal, PlaceOfArticulation.Palatal },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Stop }));

            IPA.Consonants.Add(new ConsonantPhoneme("ɟ", "g in gui, French", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Alveolopalatal, PlaceOfArticulation.Palatal },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Stop }));

            IPA.Consonants.Add(new ConsonantPhoneme("k", "k in kiss, English", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Velar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Stop }));

            IPA.Consonants.Add(new ConsonantPhoneme("g", "g in gaggle, English", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Velar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Stop }));

            IPA.Consonants.Add(new ConsonantPhoneme("q", "c in cut, English", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Uvular },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Stop }));

            IPA.Consonants.Add(new ConsonantPhoneme("ɢ", "q in Muqdisho, Somali", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Uvular },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Stop }));

            IPA.Consonants.Add(new ConsonantPhoneme("ʡ", "g̱ in g̱antl, Haida", AmbiguousBool.Ambiguous,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Pharyngeal },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Stop }));

            IPA.Consonants.Add(new ConsonantPhoneme("ʔ", "pause in uh-oh, English", AmbiguousBool.Ambiguous,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Glottal },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Stop }));

            #endregion

            #region Sibilant Affricatives

            IPA.Consonants.Add(new ConsonantPhoneme("t͡s", "ts in tsunami, Japanese", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Dental, PlaceOfArticulation.Alveolar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.SibilantAffricate }));

            IPA.Consonants.Add(new ConsonantPhoneme("d͡z", "dz in tsudzuku, Japanese", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Dental, PlaceOfArticulation.Alveolar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.SibilantAffricate }));

            IPA.Consonants.Add(new ConsonantPhoneme("t͡ʃ", "ch in bleach, English", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Palatoalveolar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.SibilantAffricate }));

            IPA.Consonants.Add(new ConsonantPhoneme("d͡ʒ", "j in jump, English", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Palatoalveolar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.SibilantAffricate }));

            IPA.Consonants.Add(new ConsonantPhoneme("ʈ͡ʂ", "zh in Zhōngwén, Mandarin Chinese", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Retroflex },
                new List<MannerOfArticualtion> { MannerOfArticualtion.SibilantAffricate }));

            IPA.Consonants.Add(new ConsonantPhoneme("ɖ͡ʐ", "dż in dżem, Standard Polish", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Retroflex },
                new List<MannerOfArticualtion> { MannerOfArticualtion.SibilantAffricate }));

            IPA.Consonants.Add(new ConsonantPhoneme("t͡ɕ", "tj in tjern, Norwegian", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Alveolopalatal },
                new List<MannerOfArticualtion> { MannerOfArticualtion.SibilantAffricate }));

            IPA.Consonants.Add(new ConsonantPhoneme("d͡ʑ", "dź in dźwięk, Polish", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Alveolopalatal },
                new List<MannerOfArticualtion> { MannerOfArticualtion.SibilantAffricate }));

            #endregion

            #region Non-sibilant Affricatives

            IPA.Consonants.Add(new ConsonantPhoneme("pɸ", "p in up, Scouse English", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Bilabial },
                new List<MannerOfArticualtion> { MannerOfArticualtion.NonSibilantAffricate }));

            IPA.Consonants.Add(new ConsonantPhoneme("bβ", "b in rub, Scouse English", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Bilabial },
                new List<MannerOfArticualtion> { MannerOfArticualtion.NonSibilantAffricate }));

            IPA.Consonants.Add(new ConsonantPhoneme("p̪f", "pf in Pfirsiche, Standard German", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Labiodental },
                new List<MannerOfArticualtion> { MannerOfArticualtion.NonSibilantAffricate }));

            IPA.Consonants.Add(new ConsonantPhoneme("b̪v", "v in vèès, Orsmaal-Gussenhoven Dutch", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Labiodental },
                new List<MannerOfArticualtion> { MannerOfArticualtion.NonSibilantAffricate }));

            IPA.Consonants.Add(new ConsonantPhoneme("t͡θ", "th in think, Dubliner English", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Dental },
                new List<MannerOfArticualtion> { MannerOfArticualtion.NonSibilantAffricate }));

            IPA.Consonants.Add(new ConsonantPhoneme("d͡ð", "th in they, Dubliner English", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Dental },
                new List<MannerOfArticualtion> { MannerOfArticualtion.NonSibilantAffricate }));

            IPA.Consonants.Add(new ConsonantPhoneme("t͡s", "c in co, Polish", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Alveolar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.NonSibilantAffricate }));

            IPA.Consonants.Add(new ConsonantPhoneme("d͡z", "dz in bodza, Hungarian", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Alveolar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.NonSibilantAffricate }));

            IPA.Consonants.Add(new ConsonantPhoneme("t̠ɹ̠̊˔", "tr in tree, General American English", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Palatoalveolar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.NonSibilantAffricate }));

            IPA.Consonants.Add(new ConsonantPhoneme("dʒ", "dsch in dschungel, Standard German", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Palatoalveolar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.NonSibilantAffricate }));

            IPA.Consonants.Add(new ConsonantPhoneme("c͡ç", "ty in tyúk, Hungarian", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Alveolopalatal, PlaceOfArticulation.Palatal },
                new List<MannerOfArticualtion> { MannerOfArticualtion.NonSibilantAffricate }));

            IPA.Consonants.Add(new ConsonantPhoneme("ɟ͡ʝ", "gy in gyár, Hungarian", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Alveolopalatal, PlaceOfArticulation.Palatal },
                new List<MannerOfArticualtion> { MannerOfArticualtion.NonSibilantAffricate }));

            IPA.Consonants.Add(new ConsonantPhoneme("kx", "c in cab, Scouse English", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Velar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.NonSibilantAffricate }));

            IPA.Consonants.Add(new ConsonantPhoneme("ɡɣ", "g in good, Scouse English", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Velar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.NonSibilantAffricate }));

            IPA.Consonants.Add(new ConsonantPhoneme("q͡χ", "кхъ in кхъэ, Kabardian", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Uvular },
                new List<MannerOfArticualtion> { MannerOfArticualtion.NonSibilantAffricate }));

            IPA.Consonants.Add(new ConsonantPhoneme("ʡħ", "unknown", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Pharyngeal },
                new List<MannerOfArticualtion> { MannerOfArticualtion.NonSibilantAffricate }));

            IPA.Consonants.Add(new ConsonantPhoneme("ʡʕ", "unknown", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Pharyngeal },
                new List<MannerOfArticualtion> { MannerOfArticualtion.NonSibilantAffricate }));

            IPA.Consonants.Add(new ConsonantPhoneme("ʔh", "h in hat, Received Pronunciation English", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Glottal },
                new List<MannerOfArticualtion> { MannerOfArticualtion.NonSibilantAffricate }));

            #endregion

            #region Sibilant Fricatives

            IPA.Consonants.Add(new ConsonantPhoneme("s", "s in sand, English", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Dental, PlaceOfArticulation.Alveolar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.SibilantFricative }));

            IPA.Consonants.Add(new ConsonantPhoneme("z", "z in size, English", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Dental, PlaceOfArticulation.Alveolar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.SibilantFricative }));

            IPA.Consonants.Add(new ConsonantPhoneme("ʃ", "sh in sheep, English", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Palatoalveolar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.SibilantFricative }));

            IPA.Consonants.Add(new ConsonantPhoneme("ʒ", "si in vision, English", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Palatoalveolar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.SibilantFricative }));

            IPA.Consonants.Add(new ConsonantPhoneme("ʂ", "rs in forsamling, Norwegian", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Retroflex },
                new List<MannerOfArticualtion> { MannerOfArticualtion.SibilantFricative }));

            IPA.Consonants.Add(new ConsonantPhoneme("ʐ", "ж in кожа, Russian", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Retroflex },
                new List<MannerOfArticualtion> { MannerOfArticualtion.SibilantFricative }));

            IPA.Consonants.Add(new ConsonantPhoneme("ɕ", "sj in sjel, Norwegian", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Alveolopalatal },
                new List<MannerOfArticualtion> { MannerOfArticualtion.SibilantFricative }));

            IPA.Consonants.Add(new ConsonantPhoneme("ʑ", "g in magia, Brazillian Portugese", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Alveolopalatal },
                new List<MannerOfArticualtion> { MannerOfArticualtion.SibilantFricative }));

            #endregion

            #region Non-sibilant Fricatives

            IPA.Consonants.Add(new ConsonantPhoneme("ɸ", "f in kopf, German", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Bilabial },
                new List<MannerOfArticualtion> { MannerOfArticualtion.NonSibilantFricative }));

            IPA.Consonants.Add(new ConsonantPhoneme("β", "b in alaba, Basque", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Bilabial },
                new List<MannerOfArticualtion> { MannerOfArticualtion.NonSibilantFricative, MannerOfArticualtion.Approximant }));

            IPA.Consonants.Add(new ConsonantPhoneme("f", "f in fill, English", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Labiodental },
                new List<MannerOfArticualtion> { MannerOfArticualtion.NonSibilantFricative }));

            IPA.Consonants.Add(new ConsonantPhoneme("v", "v in valve, English", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Labiodental },
                new List<MannerOfArticualtion> { MannerOfArticualtion.NonSibilantFricative }));

            IPA.Consonants.Add(new ConsonantPhoneme("θ̼", "unknown", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Linguolabial },
                new List<MannerOfArticualtion> { MannerOfArticualtion.NonSibilantFricative }));

            IPA.Consonants.Add(new ConsonantPhoneme("ð̼", "unknown", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Linguolabial },
                new List<MannerOfArticualtion> { MannerOfArticualtion.NonSibilantFricative, MannerOfArticualtion.Approximant }));

            IPA.Consonants.Add(new ConsonantPhoneme("θ", "th in thin, English", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Dental },
                new List<MannerOfArticualtion> { MannerOfArticualtion.NonSibilantFricative }));

            IPA.Consonants.Add(new ConsonantPhoneme("ð", "th in this, English", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Dental },
                new List<MannerOfArticualtion> { MannerOfArticualtion.NonSibilantFricative }));

            IPA.Consonants.Add(new ConsonantPhoneme("ɹ̠̊˔", "r in crew, Recieved Pronounciation English", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Palatoalveolar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.NonSibilantFricative }));

            IPA.Consonants.Add(new ConsonantPhoneme("ʒ", "si in vision, English", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Palatoalveolar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.NonSibilantFricative }));

            IPA.Consonants.Add(new ConsonantPhoneme("ç", "ch in nicht, German", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Alveolopalatal, PlaceOfArticulation.Palatal },
                new List<MannerOfArticualtion> { MannerOfArticualtion.NonSibilantFricative }));

            IPA.Consonants.Add(new ConsonantPhoneme("ʝ", "g in gi, Standard Eastern Norwegian", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Alveolopalatal, PlaceOfArticulation.Palatal },
                new List<MannerOfArticualtion> { MannerOfArticualtion.NonSibilantFricative }));

            IPA.Consonants.Add(new ConsonantPhoneme("x", "ch in Buch, German", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Velar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.NonSibilantFricative }));

            IPA.Consonants.Add(new ConsonantPhoneme("ɣ", "h in humoras, Lithuanian", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Velar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.NonSibilantFricative }));

            IPA.Consonants.Add(new ConsonantPhoneme("χ", "ch in carchar, Welsh", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Uvular },
                new List<MannerOfArticualtion> { MannerOfArticualtion.NonSibilantFricative }));

            IPA.Consonants.Add(new ConsonantPhoneme("ʁ", "r in rad, Dutch", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Uvular },
                new List<MannerOfArticualtion> { MannerOfArticualtion.NonSibilantFricative, MannerOfArticualtion.Approximant }));

            IPA.Consonants.Add(new ConsonantPhoneme("ħ", "x in xood, Somali", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Pharyngeal },
                new List<MannerOfArticualtion> { MannerOfArticualtion.NonSibilantFricative }));

            IPA.Consonants.Add(new ConsonantPhoneme("ʕ", "c in caadi, Somali", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Pharyngeal },
                new List<MannerOfArticualtion> { MannerOfArticualtion.NonSibilantFricative, MannerOfArticualtion.Approximant }));

            IPA.Consonants.Add(new ConsonantPhoneme("h", "h in high, English", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Glottal },
                new List<MannerOfArticualtion> { MannerOfArticualtion.NonSibilantFricative, MannerOfArticualtion.Approximant }));

            IPA.Consonants.Add(new ConsonantPhoneme("ɦ", "h in hora, Slovak", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Glottal },
                new List<MannerOfArticualtion> { MannerOfArticualtion.NonSibilantFricative, MannerOfArticualtion.Approximant }));

            #endregion

            #region Approximants

            IPA.Consonants.Add(new ConsonantPhoneme("ɸ˕", "b in web, Standard European Spanish", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Bilabial },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Approximant }));

            IPA.Consonants.Add(new ConsonantPhoneme("ʋ", "v in vauva, Finnish", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Labiodental },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Approximant }));

            IPA.Consonants.Add(new ConsonantPhoneme("θ̞", "d in sed, Standard European Spanish", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Dental },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Approximant }));

            IPA.Consonants.Add(new ConsonantPhoneme("ɹ̥", "r on okkurt, Faroese", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Alveolar, PlaceOfArticulation.Palatoalveolar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Approximant }));

            IPA.Consonants.Add(new ConsonantPhoneme("ɹ", "r in red, most American English", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Alveolar, PlaceOfArticulation.Palatoalveolar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Approximant }));

            IPA.Consonants.Add(new ConsonantPhoneme("ɻ̊", "r in bert, Faroese", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Retroflex },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Approximant }));

            IPA.Consonants.Add(new ConsonantPhoneme("ɻ", "r in rúka, Mapuche", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Retroflex },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Approximant }));

            IPA.Consonants.Add(new ConsonantPhoneme("j̊", "unknown", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Alveolopalatal, PlaceOfArticulation.Palatal },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Approximant }));

            IPA.Consonants.Add(new ConsonantPhoneme("j", "y in you, English", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Alveolopalatal, PlaceOfArticulation.Palatal },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Approximant }));

            IPA.Consonants.Add(new ConsonantPhoneme("ɰ̊", "g in Predrag, Standard European Spanish", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Velar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Approximant }));

            IPA.Consonants.Add(new ConsonantPhoneme("ɰ", "g pagar, Spanish", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Velar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Approximant }));

            #endregion

            #region Flaps

            IPA.Consonants.Add(new ConsonantPhoneme("ⱳ", "vw in vwa, Mono", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Bilabial },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Flap }));

            IPA.Consonants.Add(new ConsonantPhoneme("ⱱ", "unknown", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Labiodental },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Flap }));

            IPA.Consonants.Add(new ConsonantPhoneme("ɾ̼", "unknown", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Linguolabial },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Flap }));

            IPA.Consonants.Add(new ConsonantPhoneme("ɾ̥", "hr in hrafn, Icelandic", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Dental, PlaceOfArticulation.Alveolar, PlaceOfArticulation.Palatoalveolar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Flap }));

            IPA.Consonants.Add(new ConsonantPhoneme("ɾ", "r in three, Scottish English", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Dental, PlaceOfArticulation.Alveolar, PlaceOfArticulation.Palatoalveolar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Flap }));

            IPA.Consonants.Add(new ConsonantPhoneme("ɽ̊", "unknown", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Retroflex },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Flap }));

            IPA.Consonants.Add(new ConsonantPhoneme("ɽ", "rd in bord, Eastern and Central Norwegian", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Retroflex },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Flap }));

            IPA.Consonants.Add(new ConsonantPhoneme("ɢ̆", "r in erhe, Standard German", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Uvular },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Flap }));

            IPA.Consonants.Add(new ConsonantPhoneme("ʡ̮", "unknown", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Pharyngeal },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Flap }));

            #endregion

            #region Trills

            IPA.Consonants.Add(new ConsonantPhoneme("ʙ", "mb in simbi, Nias", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Bilabial },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Trill }));

            IPA.Consonants.Add(new ConsonantPhoneme("r̼", "blowing a raspberry", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Linguolabial },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Trill }));

            IPA.Consonants.Add(new ConsonantPhoneme("r̥", "r in krtań, Polish", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Dental, PlaceOfArticulation.Alveolar, PlaceOfArticulation.Palatoalveolar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Trill }));

            IPA.Consonants.Add(new ConsonantPhoneme("r", "rr in perro, Spanish", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Dental, PlaceOfArticulation.Alveolar, PlaceOfArticulation.Palatoalveolar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Trill }));

            IPA.Consonants.Add(new ConsonantPhoneme("ɽ͡r̥", "unknown", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Retroflex },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Trill }));

            IPA.Consonants.Add(new ConsonantPhoneme("ɽ͡r", "r in riem, North Holland Dutch", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Retroflex },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Trill }));

            IPA.Consonants.Add(new ConsonantPhoneme("ʀ̥", "r in triste, Belgian French", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Uvular },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Trill }));

            IPA.Consonants.Add(new ConsonantPhoneme("ʀ", "r in räv, Southern Swedish", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Uvular },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Trill }));

            IPA.Consonants.Add(new ConsonantPhoneme("ʜ", "x̱ in x̱ants, Haida", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Pharyngeal },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Trill }));

            IPA.Consonants.Add(new ConsonantPhoneme("ʢ", "unknown", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Pharyngeal },
                new List<MannerOfArticualtion> { MannerOfArticualtion.Trill }));

            #endregion

            #region Lateral Affricatives

            IPA.Consonants.Add(new ConsonantPhoneme("t͡ɬ", "tl in tla'únhl, Haida", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Dental, PlaceOfArticulation.Alveolar, PlaceOfArticulation.Palatoalveolar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.LateralAffricative }));

            IPA.Consonants.Add(new ConsonantPhoneme("d͡ɮ", "unknown", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Dental, PlaceOfArticulation.Alveolar, PlaceOfArticulation.Palatoalveolar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.LateralAffricative }));

            IPA.Consonants.Add(new ConsonantPhoneme("ʈɭ̊˔", "unknown", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Retroflex },
                new List<MannerOfArticualtion> { MannerOfArticualtion.LateralAffricative }));

            IPA.Consonants.Add(new ConsonantPhoneme("c͡ʎ̥˔", "tl in tlakate, Hazda", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Alveolopalatal, PlaceOfArticulation.Palatal },
                new List<MannerOfArticualtion> { MannerOfArticualtion.LateralAffricative }));

            IPA.Consonants.Add(new ConsonantPhoneme("k͡ʟ̝̊", "unknown", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Velar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.LateralAffricative }));

            IPA.Consonants.Add(new ConsonantPhoneme("ɡ͡ʟ̝", "unknown", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Velar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.LateralAffricative }));

            #endregion

            #region Lateral Fricatives

            IPA.Consonants.Add(new ConsonantPhoneme("ɬ", "ll in llall, Welsh", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Dental, PlaceOfArticulation.Alveolar, PlaceOfArticulation.Palatoalveolar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.LateralFricative }));

            IPA.Consonants.Add(new ConsonantPhoneme("ɮ", "dl in indlala, Zulu", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Dental, PlaceOfArticulation.Alveolar, PlaceOfArticulation.Palatoalveolar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.LateralFricative }));

            IPA.Consonants.Add(new ConsonantPhoneme("ɭ̊˔", "unknown", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Retroflex },
                new List<MannerOfArticualtion> { MannerOfArticualtion.LateralFricative }));

            IPA.Consonants.Add(new ConsonantPhoneme("ʎ̥˔", "unknown", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Alveolopalatal, PlaceOfArticulation.Palatal },
                new List<MannerOfArticualtion> { MannerOfArticualtion.LateralFricative }));

            IPA.Consonants.Add(new ConsonantPhoneme("ʎ̝", "unknown", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Alveolopalatal, PlaceOfArticulation.Palatal },
                new List<MannerOfArticualtion> { MannerOfArticualtion.LateralFricative }));

            IPA.Consonants.Add(new ConsonantPhoneme("ʟ̝̊", "unknown", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Velar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.LateralFricative }));

            IPA.Consonants.Add(new ConsonantPhoneme("ʟ̝", "unknown", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Velar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.LateralFricative }));

            #endregion

            #region Lateral Approximates

            IPA.Consonants.Add(new ConsonantPhoneme("l̼", "unknown", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Linguolabial },
                new List<MannerOfArticualtion> { MannerOfArticualtion.LateralApproximate }));

            IPA.Consonants.Add(new ConsonantPhoneme("l̥", "l in yol, Turkish", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Dental, PlaceOfArticulation.Alveolar, PlaceOfArticulation.Palatoalveolar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.LateralApproximate }));

            IPA.Consonants.Add(new ConsonantPhoneme("l", "l in elem, Hungarian", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Dental, PlaceOfArticulation.Alveolar, PlaceOfArticulation.Palatoalveolar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.LateralApproximate }));

            IPA.Consonants.Add(new ConsonantPhoneme("ɭ̊", "unknown", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Retroflex },
                new List<MannerOfArticualtion> { MannerOfArticualtion.LateralApproximate }));

            IPA.Consonants.Add(new ConsonantPhoneme("ɭ", "rl in sorl, Swedish", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Retroflex },
                new List<MannerOfArticualtion> { MannerOfArticualtion.LateralApproximate }));

            IPA.Consonants.Add(new ConsonantPhoneme("ʎ̥", "l in alt, Faroese", AmbiguousBool.False,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Alveolopalatal, PlaceOfArticulation.Palatal },
                new List<MannerOfArticualtion> { MannerOfArticualtion.LateralApproximate }));

            IPA.Consonants.Add(new ConsonantPhoneme("ʎ", "lli in million, General American English", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Alveolopalatal, PlaceOfArticulation.Palatal },
                new List<MannerOfArticualtion> { MannerOfArticualtion.LateralApproximate }));

            IPA.Consonants.Add(new ConsonantPhoneme("ʟ", "gl in aglagle, Mid-Wahgi", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Velar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.LateralApproximate }));

            IPA.Consonants.Add(new ConsonantPhoneme("ʟ̠", "l in wool, Some American English", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Uvular },
                new List<MannerOfArticualtion> { MannerOfArticualtion.LateralApproximate }));

            #endregion

            #region Lateral Flaps

            IPA.Consonants.Add(new ConsonantPhoneme("ɺ̼", "unknown", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Linguolabial },
                new List<MannerOfArticualtion> { MannerOfArticualtion.LateralFlap }));

            IPA.Consonants.Add(new ConsonantPhoneme("ɺ", "r in kokoro, Japanese", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Dental, PlaceOfArticulation.Alveolar, PlaceOfArticulation.Palatoalveolar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.LateralFlap }));

            IPA.Consonants.Add(new ConsonantPhoneme("ɭ̆", "unknown", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Retroflex },
                new List<MannerOfArticualtion> { MannerOfArticualtion.LateralFlap }));

            IPA.Consonants.Add(new ConsonantPhoneme("ʎ̮", "unknown", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Alveolopalatal, PlaceOfArticulation.Palatal },
                new List<MannerOfArticualtion> { MannerOfArticualtion.LateralFlap }));

            IPA.Consonants.Add(new ConsonantPhoneme("ʟ̆", "unknown", AmbiguousBool.True,
                new List<PlaceOfArticulation> { PlaceOfArticulation.Velar },
                new List<MannerOfArticualtion> { MannerOfArticualtion.LateralFlap }));

            #endregion

            #endregion

            #region VOWELS

            #region Closes

            IPA.Vowels.Add(new VowelPhoneme("i", "ee in meet, English", AmbiguousBool.False,
                new List<VowelHeight> { VowelHeight.Close },
                new List<VowelBackness> { VowelBackness.Front }));

            IPA.Vowels.Add(new VowelPhoneme("y", "u in chute, French", AmbiguousBool.True,
                new List<VowelHeight> { VowelHeight.Close },
                new List<VowelBackness> { VowelBackness.Front }));

            IPA.Vowels.Add(new VowelPhoneme("ɨ", "î in înot, Romanian", AmbiguousBool.False,
                new List<VowelHeight> { VowelHeight.Close },
                new List<VowelBackness> { VowelBackness.Central }));

            IPA.Vowels.Add(new VowelPhoneme("ʉ", "oo in choose, Southern American English", AmbiguousBool.True,
                new List<VowelHeight> { VowelHeight.Close },
                new List<VowelBackness> { VowelBackness.Central }));

            IPA.Vowels.Add(new VowelPhoneme("ɯ", "ı in sığ, Turkish", AmbiguousBool.False,
                new List<VowelHeight> { VowelHeight.Close },
                new List<VowelBackness> { VowelBackness.Back }));

            IPA.Vowels.Add(new VowelPhoneme("u", "u in Fuß, Standard German", AmbiguousBool.True,
                new List<VowelHeight> { VowelHeight.Close },
                new List<VowelBackness> { VowelBackness.Back }));

            #endregion

            #region Near-closes

            IPA.Vowels.Add(new VowelPhoneme("ɪ", "i in bit, Most English", AmbiguousBool.False,
                new List<VowelHeight> { VowelHeight.NearClose },
                new List<VowelBackness> { VowelBackness.NearFront }));

            IPA.Vowels.Add(new VowelPhoneme("ʏ", "u in lune, Quebec French", AmbiguousBool.True,
                new List<VowelHeight> { VowelHeight.NearClose },
                new List<VowelBackness> { VowelBackness.NearFront }));

            IPA.Vowels.Add(new VowelPhoneme("ɪ̈", "i in bit, South African English", AmbiguousBool.False,
                new List<VowelHeight> { VowelHeight.NearClose },
                new List<VowelBackness> { VowelBackness.Central }));

            IPA.Vowels.Add(new VowelPhoneme("ʊ̈", "u in gull, Standard Eastern Norwegian", AmbiguousBool.True,
                new List<VowelHeight> { VowelHeight.NearClose },
                new List<VowelBackness> { VowelBackness.Central }));

            IPA.Vowels.Add(new VowelPhoneme("ʊ", "oo in hook, Australian English", AmbiguousBool.True,
                new List<VowelHeight> { VowelHeight.NearClose },
                new List<VowelBackness> { VowelBackness.NearBack }));

            #endregion

            #region Close-mids

            IPA.Vowels.Add(new VowelPhoneme("e", "e in ge, Wu Chinese", AmbiguousBool.False,
                new List<VowelHeight> { VowelHeight.CloseMid },
                new List<VowelBackness> { VowelBackness.Front }));

            IPA.Vowels.Add(new VowelPhoneme("ø", "ø in øl, Faroese", AmbiguousBool.True,
                new List<VowelHeight> { VowelHeight.CloseMid },
                new List<VowelBackness> { VowelBackness.Front }));

            IPA.Vowels.Add(new VowelPhoneme("ɘ", "э in үсрэ, Mongolian", AmbiguousBool.False,
                new List<VowelHeight> { VowelHeight.CloseMid },
                new List<VowelBackness> { VowelBackness.Central }));

            IPA.Vowels.Add(new VowelPhoneme("ɵ", "o in toʻgʻri, Uzbek", AmbiguousBool.True,
                new List<VowelHeight> { VowelHeight.CloseMid },
                new List<VowelBackness> { VowelBackness.Central }));

            IPA.Vowels.Add(new VowelPhoneme("ɤ", "oi in doirbh, Scottish Gaelic", AmbiguousBool.False,
                new List<VowelHeight> { VowelHeight.CloseMid },
                new List<VowelBackness> { VowelBackness.Back }));

            IPA.Vowels.Add(new VowelPhoneme("o", "oo in kool, Standard Belgian Dutch", AmbiguousBool.True,
                new List<VowelHeight> { VowelHeight.CloseMid },
                new List<VowelBackness> { VowelBackness.Back }));

            #endregion

            #region Mids

            IPA.Vowels.Add(new VowelPhoneme("e", "e in bebé, Spanish", AmbiguousBool.False,
                new List<VowelHeight> { VowelHeight.Mid },
                new List<VowelBackness> { VowelBackness.Front }));

            IPA.Vowels.Add(new VowelPhoneme("ø̞", "eu in bleu, Romanian", AmbiguousBool.True,
                new List<VowelHeight> { VowelHeight.Mid },
                new List<VowelBackness> { VowelBackness.Front }));

            IPA.Vowels.Add(new VowelPhoneme("ə", "e in bitte, German", AmbiguousBool.False,
                new List<VowelHeight> { VowelHeight.Mid },
                new List<VowelBackness> { VowelBackness.Central }));

            IPA.Vowels.Add(new VowelPhoneme("ɵ̞", "ё in тётя, Russian", AmbiguousBool.True,
                new List<VowelHeight> { VowelHeight.Mid },
                new List<VowelBackness> { VowelBackness.Central }));

            IPA.Vowels.Add(new VowelPhoneme("ɤ", "ъ in път, Bulgarian", AmbiguousBool.False,
                new List<VowelHeight> { VowelHeight.Mid },
                new List<VowelBackness> { VowelBackness.Back }));

            IPA.Vowels.Add(new VowelPhoneme("o", "o in ko, Japanese", AmbiguousBool.True,
                new List<VowelHeight> { VowelHeight.Mid },
                new List<VowelBackness> { VowelBackness.Back }));

            #endregion

            #region Open-mids

            IPA.Vowels.Add(new VowelPhoneme("ɛ", "e in bene, Italian", AmbiguousBool.False,
                new List<VowelHeight> { VowelHeight.OpenMid },
                new List<VowelBackness> { VowelBackness.Front }));

            IPA.Vowels.Add(new VowelPhoneme("œ", "ö in shö, Lori", AmbiguousBool.True,
                new List<VowelHeight> { VowelHeight.OpenMid },
                new List<VowelBackness> { VowelBackness.Front }));

            IPA.Vowels.Add(new VowelPhoneme("ɜ", "e in bet, Norfolk English", AmbiguousBool.False,
                new List<VowelHeight> { VowelHeight.OpenMid },
                new List<VowelBackness> { VowelBackness.Central }));

            IPA.Vowels.Add(new VowelPhoneme("ɞ", "ô in ptôch, Kashubian", AmbiguousBool.True,
                new List<VowelHeight> { VowelHeight.OpenMid },
                new List<VowelBackness> { VowelBackness.Central }));

            IPA.Vowels.Add(new VowelPhoneme("ʌ", "u in gut, Scottish English", AmbiguousBool.False,
                new List<VowelHeight> { VowelHeight.OpenMid },
                new List<VowelBackness> { VowelBackness.Back }));

            IPA.Vowels.Add(new VowelPhoneme("ɔ", "oo in tool, Estonian", AmbiguousBool.True,
                new List<VowelHeight> { VowelHeight.OpenMid },
                new List<VowelBackness> { VowelBackness.Back }));

            #endregion

            #region Near-opens

            IPA.Vowels.Add(new VowelPhoneme("æ", "a in cat, American English", AmbiguousBool.False,
                new List<VowelHeight> { VowelHeight.NearOpen },
                new List<VowelBackness> { VowelBackness.Front }));

            IPA.Vowels.Add(new VowelPhoneme("ɐ", "a in Sant, Lombard", AmbiguousBool.Ambiguous,
                new List<VowelHeight> { VowelHeight.NearOpen },
                new List<VowelBackness> { VowelBackness.Central }));

            #endregion

            #region Opens

            IPA.Vowels.Add(new VowelPhoneme("a", "aa in braan, North Frisian", AmbiguousBool.False,
                new List<VowelHeight> { VowelHeight.Open },
                new List<VowelBackness> { VowelBackness.Front }));

            IPA.Vowels.Add(new VowelPhoneme("ɶ", "ø in børn, Standard Danish", AmbiguousBool.True,
                new List<VowelHeight> { VowelHeight.Open },
                new List<VowelBackness> { VowelBackness.Front }));

            IPA.Vowels.Add(new VowelPhoneme("ä", "A in Amerika, Czech", AmbiguousBool.False,
                new List<VowelHeight> { VowelHeight.Open },
                new List<VowelBackness> { VowelBackness.Central }));

            IPA.Vowels.Add(new VowelPhoneme("ɒ̈", "first a in bada, Østfold Norwegian", AmbiguousBool.True,
                new List<VowelHeight> { VowelHeight.Open },
                new List<VowelBackness> { VowelBackness.Central }));

            IPA.Vowels.Add(new VowelPhoneme("ɑ", "â in pâte, Quebec French", AmbiguousBool.False,
                new List<VowelHeight> { VowelHeight.Open },
                new List<VowelBackness> { VowelBackness.Back }));

            IPA.Vowels.Add(new VowelPhoneme("ɒ", "o in dono, Uzbek", AmbiguousBool.True,
                new List<VowelHeight> { VowelHeight.Open },
                new List<VowelBackness> { VowelBackness.Back }));

            #endregion

            #endregion

            IPA.Save(filename);
        }

        public static void SaveoutEnglishChars(PhoneticAlphabet IPA, string filename = null)
        {
            if (filename == null)
                filename = "EnglishCharacters.xml";

            CharacterAlphabet charAlphabet = new CharacterAlphabet()
            {
                Name = "EnglishCharacters"
            };

            List<Phoneme> phonemesForCharacter;

            phonemesForCharacter = IPA.Vowels.Where
                (
                    x =>
                    x.VowelBacknesses.Contains(VowelBackness.Front) &&
                    x.VowelHeights.Contains(VowelHeight.Open) &&
                    x.Rounded.ToBool() == false
                ).ToList<Phoneme>();
            charAlphabet.Set.Add(new Character("a", phonemesForCharacter));

            phonemesForCharacter = IPA.Vowels.Where
                (
                    x =>
                    x.VowelBacknesses.Contains(VowelBackness.Back) &&
                    x.VowelHeights.Contains(VowelHeight.Open) &&
                    x.Rounded.ToBool() == false
                ).ToList<Phoneme>();
            charAlphabet.Set.Add(new Character("ɑ", phonemesForCharacter));

            phonemesForCharacter = IPA.Vowels.Where
                (
                    x =>
                    x.VowelBacknesses.Contains(VowelBackness.Front) &&
                    x.VowelHeights.Contains(VowelHeight.NearOpen) &&
                    x.Rounded.ToBool() == false
                ).ToList<Phoneme>();
            charAlphabet.Set.Add(new Character("æ", phonemesForCharacter));

            phonemesForCharacter = IPA.Consonants.Where
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.Stop) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Bilabial) &&
                    x.Voiced.ToBool() == true
                ).ToList<Phoneme>();
            charAlphabet.Set.Add(new Character("b", phonemesForCharacter));

            phonemesForCharacter = IPA.Consonants.Where
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.Stop) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Alveolar) &&
                    x.Voiced.ToBool() == true
                ).ToList<Phoneme>();
            charAlphabet.Set.Add(new Character("d", phonemesForCharacter));

            phonemesForCharacter = IPA.Vowels.Where
                (
                    x =>
                    x.VowelBacknesses.Contains(VowelBackness.Front) &&
                    x.VowelHeights.Contains(VowelHeight.CloseMid) &&
                    x.Rounded.ToBool() == false
                ).ToList<Phoneme>();
            charAlphabet.Set.Add(new Character("e", phonemesForCharacter));

            phonemesForCharacter = IPA.Vowels.Where
                (
                    x =>
                    x.VowelBacknesses.Contains(VowelBackness.Front) &&
                    x.VowelHeights.Contains(VowelHeight.OpenMid) &&
                    x.Rounded.ToBool() == false
                ).ToList<Phoneme>();
            charAlphabet.Set.Add(new Character("ɛ", phonemesForCharacter));

            phonemesForCharacter = IPA.Vowels.Where
                (
                    x =>
                    x.VowelBacknesses.Contains(VowelBackness.Central) &&
                    x.VowelHeights.Contains(VowelHeight.OpenMid) &&
                    x.Rounded.ToBool() == false
                ).ToList<Phoneme>();
            charAlphabet.Set.Add(new Character("ɜ", phonemesForCharacter));

            phonemesForCharacter = IPA.Vowels.Where
                (
                    x =>
                    x.VowelBacknesses.Contains(VowelBackness.Central) &&
                    x.VowelHeights.Contains(VowelHeight.Mid) &&
                    x.Rounded.ToBool() == false
                ).ToList<Phoneme>();
            charAlphabet.Set.Add(new Character("ə", phonemesForCharacter));

            phonemesForCharacter = IPA.Consonants.Where
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.NonSibilantFricative) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Labiodental) &&
                    x.Voiced.ToBool() == false
                ).ToList<Phoneme>();
            charAlphabet.Set.Add(new Character("f", phonemesForCharacter));

            phonemesForCharacter = IPA.Consonants.Where
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.Stop) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Velar) &&
                    x.Voiced.ToBool() == true
                ).ToList<Phoneme>();
            charAlphabet.Set.Add(new Character("g", phonemesForCharacter));

            phonemesForCharacter = IPA.Consonants.Where
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.NonSibilantFricative) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Glottal) &&
                    x.Voiced.ToBool() == false
                ).ToList<Phoneme>();
            charAlphabet.Set.Add(new Character("h", phonemesForCharacter));

            phonemesForCharacter = IPA.Vowels.Where
                (
                    x =>
                    x.VowelBacknesses.Contains(VowelBackness.Front) &&
                    x.VowelHeights.Contains(VowelHeight.Close) &&
                    x.Rounded.ToBool() == false
                ).ToList<Phoneme>();
            charAlphabet.Set.Add(new Character("i", phonemesForCharacter));

            phonemesForCharacter = IPA.Vowels.Where
                (
                    x =>
                    x.VowelBacknesses.Contains(VowelBackness.NearFront) &&
                    x.VowelHeights.Contains(VowelHeight.NearClose) &&
                    x.Rounded.ToBool() == false
                ).ToList<Phoneme>();
            charAlphabet.Set.Add(new Character("I", phonemesForCharacter));

            phonemesForCharacter = IPA.Consonants.Where
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.SibilantAffricate) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Palatoalveolar) &&
                    x.Voiced.ToBool() == true
                ).ToList<Phoneme>();
            charAlphabet.Set.Add(new Character("j", phonemesForCharacter));

            phonemesForCharacter = IPA.Consonants.Where
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.Stop) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Velar) &&
                    x.Voiced.ToBool() == false
                ).ToList<Phoneme>();
            charAlphabet.Set.Add(new Character("k", phonemesForCharacter));

            phonemesForCharacter = IPA.Consonants.Where
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.LateralApproximate) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Alveolar) &&
                    x.Voiced.ToBool() == true
                ).ToList<Phoneme>();
            charAlphabet.Set.Add(new Character("l", phonemesForCharacter));

            phonemesForCharacter = IPA.Consonants.Where
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.Nasal) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Bilabial) &&
                    x.Voiced.ToBool() == true
                ).ToList<Phoneme>();
            charAlphabet.Set.Add(new Character("m", phonemesForCharacter));

            phonemesForCharacter = IPA.Consonants.Where
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.Nasal) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Alveolar) &&
                    x.Voiced.ToBool() == true
                ).ToList<Phoneme>();
            charAlphabet.Set.Add(new Character("n", phonemesForCharacter));

            phonemesForCharacter = IPA.Vowels.Where
                (
                    x =>
                    x.VowelBacknesses.Contains(VowelBackness.Back) &&
                    x.VowelHeights.Contains(VowelHeight.CloseMid) &&
                    x.Rounded.ToBool() == true
                ).ToList<Phoneme>();
            charAlphabet.Set.Add(new Character("o", phonemesForCharacter));

            phonemesForCharacter = IPA.Vowels.Where
                (
                    x =>
                    x.VowelBacknesses.Contains(VowelBackness.Back) &&
                    x.VowelHeights.Contains(VowelHeight.OpenMid) &&
                    x.Rounded.ToBool() == true
                ).ToList<Phoneme>();
            charAlphabet.Set.Add(new Character("ɔ", phonemesForCharacter));

            phonemesForCharacter = IPA.Consonants.Where
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.Stop) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Bilabial) &&
                    x.Voiced.ToBool() == false
                ).ToList<Phoneme>();
            charAlphabet.Set.Add(new Character("p", phonemesForCharacter));

            phonemesForCharacter = IPA.Consonants.Where
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.Approximant) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Alveolar) &&
                    x.Voiced.ToBool() == true
                ).ToList<Phoneme>();
            charAlphabet.Set.Add(new Character("r", phonemesForCharacter));

            phonemesForCharacter = IPA.Consonants.Where
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.SibilantFricative) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Alveolar) &&
                    x.Voiced.ToBool() == false
                ).ToList<Phoneme>();
            charAlphabet.Set.Add(new Character("s", phonemesForCharacter));

            phonemesForCharacter = IPA.Consonants.Where
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.Stop) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Alveolar) &&
                    x.Voiced.ToBool() == false
                ).ToList<Phoneme>();
            charAlphabet.Set.Add(new Character("t", phonemesForCharacter));

            phonemesForCharacter = IPA.Vowels.Where
                (
                    x =>
                    x.VowelBacknesses.Contains(VowelBackness.Back) &&
                    x.VowelHeights.Contains(VowelHeight.Close) &&
                    x.Rounded.ToBool() == true
                ).ToList<Phoneme>();
            charAlphabet.Set.Add(new Character("u", phonemesForCharacter));

            phonemesForCharacter = IPA.Vowels.Where
                (
                    x =>
                    x.VowelBacknesses.Contains(VowelBackness.Back) &&
                    x.VowelHeights.Contains(VowelHeight.OpenMid) &&
                    x.Rounded.ToBool() == false
                ).ToList<Phoneme>();
            charAlphabet.Set.Add(new Character("ʌ", phonemesForCharacter));

            phonemesForCharacter = IPA.Vowels.Where
                (
                    x =>
                    x.VowelBacknesses.Contains(VowelBackness.NearBack) &&
                    x.VowelHeights.Contains(VowelHeight.NearClose) &&
                    x.Rounded.ToBool() == true
                ).ToList<Phoneme>();
            charAlphabet.Set.Add(new Character("ʊ", phonemesForCharacter));

            phonemesForCharacter = IPA.Consonants.Where
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.NonSibilantFricative) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Labiodental) &&
                    x.Voiced.ToBool() == true
                ).ToList<Phoneme>();
            charAlphabet.Set.Add(new Character("v", phonemesForCharacter));

            phonemesForCharacter = IPA.Consonants.Where
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.Approximant) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Palatal) &&
                    x.Voiced.ToBool() == true
                ).ToList<Phoneme>();
            charAlphabet.Set.Add(new Character("y", phonemesForCharacter));

            phonemesForCharacter = IPA.Consonants.Where
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.SibilantFricative) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Alveolar) &&
                    x.Voiced.ToBool() == true
                ).ToList<Phoneme>();
            charAlphabet.Set.Add(new Character("z", phonemesForCharacter));

            phonemesForCharacter = IPA.Consonants.Where
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.NonSibilantFricative) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Dental) &&
                    x.Voiced.ToBool() == false
                ).ToList<Phoneme>();
            charAlphabet.Set.Add(new Character("θ", phonemesForCharacter));

            phonemesForCharacter = IPA.Consonants.Where
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.NonSibilantFricative) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Dental) &&
                    x.Voiced.ToBool() == true
                ).ToList<Phoneme>();
            charAlphabet.Set.Add(new Character("ð", phonemesForCharacter));

            phonemesForCharacter = IPA.Consonants.Where
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.SibilantFricative) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Palatoalveolar) &&
                    x.Voiced.ToBool() == false
                ).ToList<Phoneme>();
            charAlphabet.Set.Add(new Character("ʃ", phonemesForCharacter));

            phonemesForCharacter = IPA.Consonants.Where
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.SibilantFricative) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Palatoalveolar) &&
                    x.Voiced.ToBool() == true
                ).ToList<Phoneme>();
            charAlphabet.Set.Add(new Character("ʒ", phonemesForCharacter));

            phonemesForCharacter = IPA.Consonants.Where
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.SibilantAffricate) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Palatoalveolar) &&
                    x.Voiced.ToBool() == false
                ).ToList<Phoneme>();
            charAlphabet.Set.Add(new Character("t͡ʃ", phonemesForCharacter));

            phonemesForCharacter = IPA.Consonants.Where
                (
                    x =>
                    x.MannersOfArticulation.Contains(MannerOfArticualtion.Nasal) &&
                    x.PlacesOfArticulation.Contains(PlaceOfArticulation.Velar) &&
                    x.Voiced.ToBool() == true
                ).ToList<Phoneme>();
            charAlphabet.Set.Add(new Character("ŋ", phonemesForCharacter));

            charAlphabet.Save(filename);
        }
    }
}

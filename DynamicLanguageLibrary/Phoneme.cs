using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicLanguageLibrary
{
    #region Public Enums

    public static class Extensions
    {
        public static bool ToBool(this AmbiguousBool ambiguousBool)
        {
            return ambiguousBool == AmbiguousBool.True;
        }
    }

    public enum AmbiguousBool { False, True, Ambiguous }

    public enum PlaceOfArticulation { Bilabial, Labiodental, Linguolabial, Dental, Alveolar, Palatoalveolar, Retroflex, Alveolopalatal, Palatal, Velar, Uvular, Pharyngeal, Glottal }
    public enum MannerOfArticualtion { Nasal, Stop, SibilantAffricate, NonSibilantAffricate, SibilantFricative, NonSibilantFricative, Approximant, Flap, Trill, LateralAffricative, 
        LateralFricative, LateralApproximate, LateralFlap }

    public enum TongueHeight { Close, NearClose, CloseMid, Mid, OpenMid, NearOpen, Open }
    public enum TongueBackness { Front, NearFront, Central, NearBack, Back }

    #endregion

    #region Phoneme Classes

    public abstract class Phoneme
    {
        #region Properties

        [YAXLib.YAXAttributeForClass]
        public string Representation { get; set; }
        [YAXLib.YAXAttributeForClass]
        public string Pronounciation { get; set; }

        #endregion
    }

    public class ConsonantPhoneme : Phoneme
    {
        #region Properties

        [YAXLib.YAXCollection(YAXLib.YAXCollectionSerializationTypes.Serially, SeparateBy = ", ")]
        public List<PlaceOfArticulation> PlacesOfArticulation { get; set; }
        [YAXLib.YAXCollection(YAXLib.YAXCollectionSerializationTypes.Serially, SeparateBy = ", ")]
        public List<MannerOfArticualtion> MannersOfArticulation { get; set; }

        [YAXLib.YAXAttributeForClass]
        public AmbiguousBool Voiced { get; set; }

        #endregion

        #region Contructors

        public ConsonantPhoneme()
        {
        }

        public ConsonantPhoneme(string representation, string pronounciation, AmbiguousBool voiced,
            List<PlaceOfArticulation> placesOfArticulation, List<MannerOfArticualtion> mannersOfArticulation)
        {
            this.Representation = representation;
            this.Pronounciation = pronounciation;
            this.Voiced = voiced;
            this.PlacesOfArticulation = placesOfArticulation;
            this.MannersOfArticulation = mannersOfArticulation;
        }

        #endregion
    }

    public class VowelPhoneme : Phoneme
    {
        #region Properties

        [YAXLib.YAXCollection(YAXLib.YAXCollectionSerializationTypes.Serially, SeparateBy = ", ")]
        public List<TongueHeight> Heights { get; set; }
        [YAXLib.YAXCollection(YAXLib.YAXCollectionSerializationTypes.Serially, SeparateBy = ", ")]
        public List<TongueBackness> Backnesses { get; set; }

        [YAXLib.YAXAttributeForClass]
        public AmbiguousBool Rounded { get; set; }

        #endregion

        #region Constructors

        public VowelPhoneme()
        {
        }

        public VowelPhoneme(string representation, string pronounciation, AmbiguousBool rounded,
            List<TongueHeight> vowelHeights, List<TongueBackness> vowelBacknesses)
        {
            this.Representation = representation;
            this.Pronounciation = pronounciation;
            this.Rounded = rounded;
            this.Heights = vowelHeights;
            this.Backnesses = vowelBacknesses;
        }

        #endregion
    }

    #endregion
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicLanguageLibrary
{
    public class PhoneticAlphabet
    {
        #region Properties

        [YAXLib.YAXAttributeForClass]
        public string Name { get; set; }

        public ObservableCollection<ConsonantPhoneme> Consonants { get; private set; }
        public ObservableCollection<VowelPhoneme> Vowels { get; private set; }

        #endregion

        #region Constructors

        public PhoneticAlphabet()
        {
            this.Consonants = new ObservableCollection<ConsonantPhoneme>();
            this.Vowels = new ObservableCollection<VowelPhoneme>();
            this.Name = String.Empty;
        }

        public PhoneticAlphabet(string filename)
            : this()
        {
            try
            {
                if (filename != null)
                    this.Load(filename);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion

        #region Public Functions

        public void Save(string filename)
        {
            YAXLib.YAXSerializer serializer = new YAXLib.YAXSerializer(typeof(PhoneticAlphabet));
            try
            {
                serializer.SerializeToFile(this, filename);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Load(string filename)
        {
            YAXLib.YAXSerializer serializer = new YAXLib.YAXSerializer(typeof(PhoneticAlphabet));
            try
            {
                PhoneticAlphabet pa = serializer.DeserializeFromFile(filename) as PhoneticAlphabet;
                this.Name = pa.Name;
                foreach (ConsonantPhoneme p in pa.Consonants)
                {
                    this.Consonants.Add(p);
                }
                foreach (VowelPhoneme p in pa.Vowels)
                {
                    this.Vowels.Add(p);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion
    }
}

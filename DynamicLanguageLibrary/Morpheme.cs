using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicLanguageLibrary
{
    public class Morpheme
    {
        public ObservableCollection<Phoneme> Phonemes { get; set; }

        public Morpheme(IEnumerable<Phoneme> phonemes = null)
        {
            if (phonemes != null)
                this.Phonemes = new ObservableCollection<Phoneme>(phonemes);
            else
                this.Phonemes = new ObservableCollection<Phoneme>();
        }

        public override string ToString()
        {
            if (Phonemes == null)
                return String.Empty;

            StringBuilder sb = new StringBuilder();

            foreach (Phoneme p in Phonemes)
            {
                sb.Append(p.Representation);
            }

            return sb.ToString();
        }
    }
}

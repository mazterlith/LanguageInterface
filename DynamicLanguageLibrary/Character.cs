using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAXLib;

namespace DynamicLanguageLibrary
{
    public class Character
    {
        [YAXAttributeForClass]
        public string Glyph { get; set; }
        public List<Phoneme> Phonemes { get; set; }

        public Character()
        {
            this.Phonemes = new List<Phoneme>();
        }

        public Character(string glyph, IEnumerable<Phoneme> phonemes = null)
        {
            this.Glyph = glyph;
            this.Phonemes = new List<Phoneme>(phonemes);
        }
    }
}

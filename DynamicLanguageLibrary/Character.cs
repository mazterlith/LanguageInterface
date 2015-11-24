using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicLanguageLibrary
{
    public class Character
    {
        [YAXLib.YAXAttributeForClass]
        public string Glyph { get; set; }
        public List<Phoneme> Phonemes { get; set; }

        public Character(string glyph, IEnumerable<Phoneme> phonemes = null)
        {
            this.Glyph = glyph;
            this.Phonemes = new List<Phoneme>(phonemes);
        }
    }
}

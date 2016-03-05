using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicLanguageLibrary
{
    public class Morpheme : ObservableCollection<Character>
    {
        public virtual object Meaning { get; set; }

        public Morpheme() { }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Character c in this)
            {
                sb.Append(c.Glyph);
            }

            return sb.ToString();
        }
    }
}

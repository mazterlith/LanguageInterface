using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicLanguageLibrary
{
    public class Word
    {
        public ObservableCollection<Morpheme> Origin { get; private set; }
        public string Representation { get; set; }

        public virtual object Meaning { get; set; }
    }
}

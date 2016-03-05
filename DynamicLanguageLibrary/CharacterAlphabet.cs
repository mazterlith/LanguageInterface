using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAXLib;

namespace DynamicLanguageLibrary
{
    internal class CharacterAlphabetParser
    {
        [YAXAttributeForClass]
        public string Name { get; set; }
        public List<Character> Set { get; set; }

        public CharacterAlphabetParser() { }
    }

    public class CharacterAlphabet : ObservableCollection<Character>
    {
        public string Name { get; set; }

        public CharacterAlphabet(string filename = null)
        {
            if (filename != null)
                Load(filename);
        }

        public void Save(string filename)
        {
            try
            {
                CharacterAlphabetParser cap = new CharacterAlphabetParser()
                {
                    Name = this.Name,
                    Set = new List<Character>(this)
                };

                YAXSerializer serializer = new YAXSerializer(typeof(CharacterAlphabetParser));
                serializer.SerializeToFile(cap, filename);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Load(string filename)
        {
            YAXSerializer serializer = new YAXSerializer(typeof(CharacterAlphabetParser));
            try
            {
                CharacterAlphabetParser cap = serializer.DeserializeFromFile(filename) as CharacterAlphabetParser;
                this.Name = cap.Name;

                this.ClearItems();
                this.Concat(cap.Set);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

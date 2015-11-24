using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicLanguageLibrary
{
    public class CharacterAlphabet
    {
        [YAXLib.YAXAttributeForClass]
        public string Name { get; set; }

        public ObservableCollection<Character> Set { get; private set; }

        public CharacterAlphabet(string filename = null)
        {
            Set = new ObservableCollection<Character>();

            if (filename != null)
                Load(filename);
        }

        public void Save(string filename)
        {
            YAXLib.YAXSerializer serializer = new YAXLib.YAXSerializer(typeof(CharacterAlphabet));
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
            YAXLib.YAXSerializer serializer = new YAXLib.YAXSerializer(typeof(CharacterAlphabet));
            try
            {
                CharacterAlphabet ca = serializer.DeserializeFromFile(filename) as CharacterAlphabet;
                this.Name = ca.Name;
                foreach (Character c in ca.Set)
                {
                    this.Set.Add(c);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

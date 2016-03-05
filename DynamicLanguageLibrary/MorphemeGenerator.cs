using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using LanguageMathLibrary;

namespace DynamicLanguageLibrary
{
    public class MorphemeGenerator
    {
        #region Fields

        private enum MarkovState { SSS = 0, SSV, SSC, SVE, SVV, SVC, SCE, SCV, SCC, VVE, VVV, VVC, VCE, VCV, VCC, CVE, CVV, CVC, CCE, CCV, CCC, EEE };
        private enum State { S, V, C, E };

        private int _totTransitionStates = Enum.GetNames(typeof(MarkovState)).Length;
        private int _totEmissionStates;

        private Queue<State> _currStateQueue;
        private MarkovState _currState;
        private MarkovState _prevState;

        private PseudoMarkovChain _markovChain;
        private CharacterAlphabet _characterAlphabet;

        #endregion

        #region Properties

        public CharacterAlphabet CharacterAlphabet
        {
            get { return _characterAlphabet; }
            set
            {
                _characterAlphabet = value;
                _totEmissionStates = _characterAlphabet.Count;
            }
        }

        #endregion

        #region Constructor

        public MorphemeGenerator(CharacterAlphabet characterAlphabet)
        {
            _markovChain = new PseudoMarkovChain();

            this.CharacterAlphabet = characterAlphabet;

            _markovChain.ChainLimit = 8;
            _markovChain.StartState = Convert.ToInt32(MarkovState.SSS);
            _markovChain.EndState = Convert.ToInt32(MarkovState.EEE);

            _markovChain.TransitionMatrix = new int[_totTransitionStates, _totTransitionStates];
            _markovChain.EmissionMatrix = new int[_totTransitionStates, _totEmissionStates];

            _currStateQueue = new Queue<State>();
        }

        #endregion

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

            _currStateQueue.Enqueue(State.S);
            _currStateQueue.Enqueue(State.S);
            _currStateQueue.Enqueue(State.S);

            _currState = CurrQueueToCurrState();

            string source = sr.ReadLine();

            while (sr.Peek() >= 0)
            {
                string morpheme = sr.ReadLine();

                foreach (char glyph in morpheme)
                {
                    Character c = CharacterAlphabet.FirstOrDefault(x => x.Glyph.Contains(glyph));

                    if (c == null)
                        continue;

                    Phoneme phoneme = c.Phonemes.FirstOrDefault();

                    if (phoneme == null)
                        continue;

                    ConsonantPhoneme cp = phoneme as ConsonantPhoneme;
                    VowelPhoneme vp = phoneme as VowelPhoneme;
                    if (cp != null)
                    {
                        _currStateQueue.Dequeue();
                        _currStateQueue.Enqueue(State.C);
                    }
                    else if (vp != null)
                    {
                        _currStateQueue.Dequeue();
                        _currStateQueue.Enqueue(State.V);
                    }
                    else
                    {
                        continue;
                    }

                    _prevState = _currState;
                    _currState = CurrQueueToCurrState();

                    _markovChain.TransitionMatrix[Convert.ToInt32(_prevState), Convert.ToInt32(_currState)]++;
                }
            }
        }

        private MarkovState CurrQueueToCurrState()
        {
            string stringRep = String.Empty;
            foreach (State s in _currStateQueue)
            {
                stringRep += System.Enum.GetName(typeof(State), s);
            }

            MarkovState state;
            System.Enum.TryParse(stringRep, true, out state);

            return state;
        }
    }
}

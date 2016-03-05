using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageMathLibrary
{
    public class PseudoMarkovChain
    {
        #region Fields

        private int[] _transitionColumnSums;
        private int[] _emissionColumnSums;
        private int _transitionStates;
        private int _emissionStates;

        int[] result;

        private Random _rng;

        #endregion

        #region Properties

        public int StartState { get; set; }
        public int EndState { get; set; }
        public int ChainLimit { get; set; }

        public int[,] TransitionMatrix { get; set; }
        public int[,] EmissionMatrix { get; set; }

        #endregion

        #region Constructor

        public PseudoMarkovChain()
        {
            this.StartState = 1;
            this.ChainLimit = 8;
            this.EndState = -1;

            _rng = new Random();
        }

        #endregion

        #region Public Functions

        /// <summary>
        /// Runs the main sequence of the program. Transmission and Emission Matricies must be set first.
        /// </summary>
        /// <returns> The resultant emissions. </returns>
        public int[] Run()
        {
            if (!CheckValid())
                return null;

            PrerunPreparation();

            RunLoop();

            return result;
        }

        #endregion

        #region Private Functions

        private bool CheckValid()
        {
            if (TransitionMatrix == null || EmissionMatrix == null)
            {
                // Need them to not be null
                return false;
            }

            if (TransitionMatrix.GetLength(0) != TransitionMatrix.GetLength(1))
            {
                // Must be a square matrix
                return false;
            }

            if (TransitionMatrix.GetLength(1) != EmissionMatrix.GetLength(0))
            {
                // Must agree on number of states
                return false;
            }

            return true;
        }

        private void PrerunPreparation()
        {
            _transitionStates = TransitionMatrix.GetLength(0);
            _emissionStates = EmissionMatrix.GetLength(1);

            _transitionColumnSums = new int[_transitionStates];
            _emissionColumnSums = new int[_transitionStates];

            for (int i = 0; i < _transitionStates; i++)
            {
                _transitionColumnSums[0] = 0;

                for (int j = 0; j < _transitionStates; j++)
                {
                    _transitionColumnSums[j] += TransitionMatrix[i, j];
                }
            }

            for (int i = 0; i < _emissionStates; i++)
            {
                _emissionColumnSums[0] = 0;

                for (int j = 0; j < _transitionStates; j++)
                {
                    _emissionColumnSums[j] += EmissionMatrix[j, i];
                }
            }
        }

        private void RunLoop()
        {
            result = new int[ChainLimit];

            int statePicked = StartState;
            int statesChained = 0;
            while (statesChained < ChainLimit)
            {
                int nextPick = _rng.Next(_transitionColumnSums[statePicked]);

                for (int j = 0; j < _transitionStates; j++)
                {
                    nextPick -= TransitionMatrix[statePicked, j];

                    if (nextPick < 0)
                    {
                        statePicked = j;
                        break;
                    }
                }

                int emitPick = _rng.Next(_emissionColumnSums[statePicked]);

                for (int j = 0; j < _emissionStates; j++)
                {
                    emitPick -= EmissionMatrix[statePicked, j];

                    if (emitPick < 0)
                    {
                        result[statesChained] = j;
                        statesChained++;
                        break;
                    }
                }

                if (statePicked == this.EndState)
                    break;
            }
        }

        #endregion
    }
}

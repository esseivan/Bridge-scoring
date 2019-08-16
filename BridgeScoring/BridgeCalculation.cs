using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://app.hacknplan.com/p/100589/kanban?categoryId=0&boardId=255311

namespace BridgeScoring
{
    /// <summary>
    /// Rubber Bridge
    /// </summary>
    public class BridgeCalculation
    {
        public Team Team1 { get; set; } = null;
        public Team Team2 { get; set; } = null;

        public enum ScoreType
        {
            ALL,

            ContractPoint,
            OverTricks,
            UnderTricks,
            Doubled,
            Slam,
        }

        public void AddContract(Contract contract, Team team, int tricksMade)
        {

        }

        private void CalculateContract(Contract contract, Team team, int tricksMade)
        {
            Dictionary<ScoreType, int> scores = new Dictionary<ScoreType, int>();
            int currentscore;

            // Contract points
            currentscore = 0;
            if (tricksMade >= contract.Tricks)
            {
                currentscore = GetContractScore(Couleur, ContratLevee, false);

                if (Double == DoubleMode.Dbl)
                    currentscore *= 2;
                else if (Double == DoubleMode.ReDbl)
                    currentscore *= 4;
            }
            scores.Add(ScoreType.ContractPoint, currentscore);
            if (scores[ScoreType.ContractPoint] >= 100)
                ContractMade = true;
            else
                ContractMade = false;

            // Overtricks
            currentscore = 0;
            if (tricksMade > ContratLevee)
            {
                if (Double == DoubleMode.NonDbl)
                {
                    currentscore = GetContractScore(Couleur, tricksMade - ContratLevee, true);
                }
                else
                {
                    currentscore = (tricksMade - ContratLevee) * 100;

                    if (Double == DoubleMode.Dbl)
                        currentscore *= 2;
                    else
                        currentscore *= 4;
                    if (IsVulnerable)
                        currentscore *= 2;

                }
            }
            scores.Add(ScoreType.OverTricks, currentscore);

            // Undertricks
            currentscore = 0;
            if (tricksMade < ContratLevee)
            {
                int counter = (ContratLevee - tricksMade);
                int multiplier = 50;

                if (IsVulnerable)
                    multiplier *= 2;
                if (Double == DoubleMode.Dbl)
                    multiplier *= 2;
                else if (Double == DoubleMode.ReDbl)
                    multiplier *= 4;
                if (Double == DoubleMode.NonDbl)
                {
                    currentscore = multiplier * counter;
                }
                else
                {
                    while (counter > 0)
                    {
                        currentscore += multiplier;

                        if ((counter == 0) || (counter == 1 && !IsVulnerable))
                        {
                            if (Double == DoubleMode.Dbl)
                                multiplier += 100;
                            else
                                multiplier += 200;
                        }

                        counter--;
                    }
                }
            }
            scores.Add(ScoreType.UnderTricks, currentscore);

            // Doubled
            currentscore = 0;
            if (ContractMade)
            {
                if (Double == DoubleMode.Dbl)
                    currentscore = 50;
                else if (Double == DoubleMode.ReDbl)
                    currentscore = 100;
            }
            scores.Add(ScoreType.Doubled, currentscore);

            // Slam
            currentscore = 0;
            if (ContractMade)
            {
                if (ContratLevee == 6)
                {
                    if (IsVulnerable)
                        currentscore = 750;
                    else
                        currentscore = 500;
                }
                else if (ContratLevee == 7)
                {
                    if (IsVulnerable)
                        currentscore = 1500;
                    else
                        currentscore = 1000;
                }
            }
            scores.Add(ScoreType.Slam, currentscore);

        }

        public int GetScore(Dictionary<ScoreType, int> scores, ScoreType scoreType)
        {
            switch (scoreType)
            {
                case ScoreType.ALL:
                    return scores.Sum((kv) => kv.Value);
                case ScoreType.ContractPoint:
                case ScoreType.OverTricks:
                case ScoreType.UnderTricks:
                case ScoreType.Doubled:
                case ScoreType.Slam:
                    return scores[scoreType];
                default:
                    break;
            }

            return -1;
        }

        public int GetScore(ScoreType scoreType)
        {
            return GetScore(GetScores(), scoreType);
        }
    }

    public class Team
    {
        public int Score { get; set; } = 0;
        public bool IsVulnerable { get; set; } = false;

    }

    public class Contract
    {
        public int Tricks { get; private set; } = 1;

        public Couleurs couleur = Couleurs.Trefle;

        public Doubled doubled = Doubled.NonDbl;

        #region Enums

        public enum Couleurs
        {
            Trefle,
            Carreau,
            Coeur,
            Pique,
            SansAttout
        }

        public enum Doubled
        {
            NonDbl,
            Dbl,
            ReDbl
        }

        #endregion

        #region Constructors

        public Contract() {
        }

        public Contract(int Tricks, Couleurs couleur)
        {
            this.Tricks = Tricks;
            this.couleur = couleur;
        }

        public Contract(int Tricks, Couleurs couleur, Doubled doubled)
        {
            this.Tricks = Tricks;
            this.couleur = couleur;
            this.doubled = doubled;
        }

        #endregion

        #region getter & setter

        public void SetTricks(int Tricks)
        {
            if ((Tricks < 1) || (Tricks > 7))
            {
                throw new ArgumentException();
            }
            else
            {
                this.Tricks = Tricks;
            }
        }

        public int GetTricks()
        {
            return this.Tricks;
        }

        public void SetCouleur(Couleurs couleur)
        {
            this.couleur = couleur;
        }

        public Couleurs GetCouleur()
        {
            return this.couleur;
        }

        #endregion

    }
}

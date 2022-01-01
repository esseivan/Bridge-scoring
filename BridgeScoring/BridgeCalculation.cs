using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://app.hacknplan.com/p/100589/kanban?categoryId=0&boardId=255311

namespace BridgeScoring
{
    /// <summary>
    /// Duplicate Bridge
    /// </summary>
    public class BridgeCalculation
    {
        public bool isRubberBridgeMode { get; set; } = false;


        public enum ScoreType
        {
            All,

            Contract,

            Overtrick,
            Undertrick,
            PartGame,
            Doubled,
            Slam

        }

        public BridgeCalculation(bool isRubberBridgeMode)
        {
            this.isRubberBridgeMode = isRubberBridgeMode;
        }

        public Dictionary<ScoreType, int> CalculateContract(Contract contract, bool isVulnerable, int tricksMade)
        {
            Dictionary<ScoreType, int> scores = new Dictionary<ScoreType, int>();

            /*** Contract points ***/
            // Add contract points below the line
            scores[ScoreType.Contract] = CalculateContractPoints(contract, tricksMade);
            contract.matchWon = (scores[ScoreType.Contract] >= 100);

            /*** Game or Part-Game ***/
            // Duplicate bridge only
            if (!isRubberBridgeMode)
            {
                if (scores[ScoreType.Contract] >= 100)
                {
                    scores[ScoreType.PartGame] = (isVulnerable ? 500 : 300);
                }
                else
                {
                    scores[ScoreType.PartGame] = 50;
                }
            }
            else
                scores[ScoreType.PartGame] = 0;

            /*** Rubber bonus - Not Implemented ***/
            // Rubber bridge only

            /*** Honor points - Not Implemented ***/
            // Rubber bridge only

            /*** Overtrick points ***/
            // Add overtrick points above the line
            scores[ScoreType.Overtrick] = CalculateOverTricksPoints(contract, isVulnerable, tricksMade);

            /*** Undertrick points ***/
            // Add penality points to opponent above the line
            scores[ScoreType.Undertrick] = CalculateUnderTricksPoints(contract, isVulnerable, tricksMade);

            /*** Doubled points ***/
            scores[ScoreType.Doubled] = CalculateDoubledContractPoints(contract, tricksMade);

            /*** Slam points ***/
            scores[ScoreType.Slam] = CalculateSlamPoints(contract, isVulnerable, tricksMade);

            int total = 0;
            foreach (var item in scores)
            {
                total += item.Value;
            }
            scores[ScoreType.All] = total;

            return scores;
        }

        private int GetContractScore(Contract contract, int count, bool isFirst)
        {
            switch (contract.couleur)
            {
                case Contract.Couleurs.Trefle:
                case Contract.Couleurs.Carreau:
                    return count * 20;
                case Contract.Couleurs.Coeur:
                case Contract.Couleurs.Pique:
                    return count * 30;
                case Contract.Couleurs.SansAttout:
                    return count * 30 + (isFirst ? 10 : 0);
                default:
                    break;
            }

            return -1;
        }

        public int CalculateContractPoints(Contract contract, int tricksMade)
        {
            int currentscore = 0;
            // if enough tricks made
            if (tricksMade >= (contract.tricks + 6))
            {
                contract.contractMade = true;
                currentscore = GetContractScore(contract, contract.tricks, true);

                if (contract.doubled == Contract.Doubled.Dbl)
                    currentscore *= 2;
                else if (contract.doubled == Contract.Doubled.ReDbl)
                    currentscore *= 4;
            }
            else
                contract.contractMade = false;

            return currentscore;
        }

        public int CalculateOverTricksPoints(Contract contract, bool isVulnerable, int tricksMade)
        {
            int currentscore = 0;
            // If more tricks than contract tricks
            if (tricksMade > (contract.tricks + 6))
            {
                if (contract.doubled == Contract.Doubled.NonDbl)
                {
                    currentscore = GetContractScore(contract, tricksMade - (contract.tricks + 6), false);
                }
                else
                {
                    currentscore = (tricksMade - (contract.tricks + 6)) * 100;

                    if (contract.doubled == Contract.Doubled.Dbl)
                        currentscore *= 2;
                    else
                        currentscore *= 4;

                    if (isVulnerable)
                        currentscore *= 2;
                }
            }
            return currentscore;
        }

        public int CalculateUnderTricksPoints(Contract contract, bool isVulnerable, int tricksMade)
        {
            int currentscore = 0;
            // If tricks made below contract tricks
            if (tricksMade < (contract.tricks + 6))
            {
                int counter = ((contract.tricks + 6) - tricksMade);
                int multiplier = 50;

                if (isVulnerable)
                    multiplier *= 2;

                if (contract.doubled == Contract.Doubled.Dbl)
                    multiplier *= 2;
                else if (contract.doubled == Contract.Doubled.ReDbl)
                    multiplier *= 4;

                if (contract.doubled == Contract.Doubled.NonDbl)
                {
                    currentscore = multiplier * counter;
                }
                else
                {
                    while (counter > 0)
                    {
                        currentscore += multiplier;

                        if ((counter == 0) || (counter == 1 && !isVulnerable))
                        {
                            if (contract.doubled == Contract.Doubled.Dbl)
                                multiplier += 100;
                            else
                                multiplier += 200;
                        }

                        counter--;
                    }
                }
            }

            return currentscore;
        }

        public int CalculateDoubledContractPoints(Contract contract, int tricksMade)
        {
            int currentscore = 0;
            if (contract.contractMade)
            {
                if (contract.doubled == Contract.Doubled.Dbl)
                    currentscore = 50;
                else if (contract.doubled == Contract.Doubled.ReDbl)
                    currentscore = 100;
            }
            return currentscore;
        }

        public int CalculateSlamPoints(Contract contract, bool isVulnerable, int tricksMade)
        {
            int currentscore = 0;
            if (contract.contractMade)
            {
                if (contract.tricks == 6)
                {
                    if (isVulnerable)
                        currentscore = 750;
                    else
                        currentscore = 500;
                }
                else if (contract.tricks == 7)
                {
                    if (isVulnerable)
                        currentscore = 1500;
                    else
                        currentscore = 1000;
                }
            }
            return currentscore;
        }
    }

    public class Contract
    {
        public int tricks { get; private set; } = 1;

        public bool matchWon { get; set; } = false;

        public bool contractMade { get; set; } = false;

        public Couleurs couleur { get; set; } = Couleurs.Trefle;

        public Doubled doubled { get; set; } = Doubled.NonDbl;

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

        public Contract()
        {
        }

        public Contract(int tricks, Couleurs couleur)
        {
            this.tricks = tricks;
            this.couleur = couleur;
        }

        public Contract(int tricks, Couleurs couleur, Doubled doubled)
        {
            this.tricks = tricks;
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
                this.tricks = Tricks;
            }
        }

        public int GetTricks()
        {
            return this.tricks;
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

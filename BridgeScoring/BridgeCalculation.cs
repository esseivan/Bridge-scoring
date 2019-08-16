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
        public Team Team_NS { get; set; } = null;
        public Team Team_WE { get; set; } = null;

        public bool isRubberBridgeMode { get; set; } = false;

        public BridgeCalculation(bool isRubberBridgeMode)
        {
            this.isRubberBridgeMode = isRubberBridgeMode;
        }

        private Team GetDefendingTeam(Team declaringTeam)
        {
            if (Team_NS == declaringTeam)
                return Team_WE;
            return Team_NS;
        }


        public void NewGame()
        {
            Team_NS.Score = 0;
            Team_NS.Score_BelowTheLine = 0;
            Team_NS.IsVulnerable = false;

            Team_WE.Score = 0;
            Team_WE.Score_BelowTheLine = 0;
            Team_WE.IsVulnerable = false;
        }

        public int CalculateContract(Contract contract, Team declaringTeam, int tricksMade)
        {
            Team defendingTeam = GetDefendingTeam(declaringTeam);

            /*** Contract points ***/
            // Add contract points below the line
            int contractPoints = CalculateContractPoints(contract, declaringTeam, tricksMade);
            declaringTeam.Score_BelowTheLine += contractPoints;
            contract.matchWon = (declaringTeam.Score_BelowTheLine >= 100);

            /*** Contract made points ***/
            if (contract.matchWon)
            {
                // Below line points pass above line
                declaringTeam.Score += declaringTeam.Score_BelowTheLine;
                declaringTeam.Score_BelowTheLine = 0;
                declaringTeam.IsVulnerable = true;
            }

            /*** Game or Part-Game ***/
            // Duplicate bridge only
            if (!isRubberBridgeMode)
            {
                if (contractPoints >= 100)
                {
                    declaringTeam.Score += (declaringTeam.IsVulnerable ? 500 : 300);
                } else
                {
                    declaringTeam.Score += 50;
                }
            }

            /*** Honor points ***/
            // Rubber bridge only
            // Not implemented
            //if (isRubberBridgeMode)
            //{
                // 150 points for 5 honors (as, ..., ten)
                // 100 points for 4 honors (as, ..., ten minus 1)
            //}

            /*** Overtrick points ***/
            // Add overtrick points above the line
            declaringTeam.Score += CalculateOverTricksPoints(contract, declaringTeam, tricksMade);

            /*** Undertrick points ***/
            // Add penality points to opponent above the line
            defendingTeam.Score += CalculateUnderTricksPoints(contract, declaringTeam, tricksMade);

            /*** Doubled points ***/
            declaringTeam.Score += CalculateDoubledContractPoints(contract, declaringTeam, tricksMade);

            /*** Slam points ***/
            declaringTeam.Score += CalculateSlamPoints(contract, declaringTeam, tricksMade);

            return declaringTeam.Score_BelowTheLine;
        }

        private int GetContractScore(Contract contract, Team team, int count, bool isFirst)
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

        public int CalculateContractPoints(Contract contract, Team declaringTeam, int tricksMade)
        {
            int currentscore = 0;
            // if enough tricks made
            if (tricksMade >= contract.tricks)
            {
                contract.contractMade = true;
                currentscore = GetContractScore(contract, declaringTeam, tricksMade, true);

                if (contract.doubled == Contract.Doubled.Dbl)
                    currentscore *= 2;
                else if (contract.doubled == Contract.Doubled.ReDbl)
                    currentscore *= 4;
            }
            else
                contract.contractMade = false;

            return currentscore;
        }

        public int CalculateOverTricksPoints(Contract contract, Team declaringTeam, int tricksMade)
        {
            int currentscore = 0;
            // If more tricks than contract tricks
            if (tricksMade > contract.tricks)
            {
                if (contract.doubled == Contract.Doubled.NonDbl)
                {
                    currentscore = GetContractScore(contract, declaringTeam, tricksMade - contract.tricks, false);
                }
                else
                {
                    currentscore = (tricksMade - contract.tricks) * 100;

                    if (contract.doubled == Contract.Doubled.Dbl)
                        currentscore *= 2;
                    else
                        currentscore *= 4;

                    if (declaringTeam.IsVulnerable)
                        currentscore *= 2;
                }
            }
            return currentscore;
        }

        public int CalculateUnderTricksPoints(Contract contract, Team declaringTeam, int tricksMade)
        {
            int currentscore = 0;
            // If tricks made below contract tricks
            if (tricksMade < contract.tricks)
            {
                int counter = (contract.tricks - tricksMade);
                int multiplier = 50;

                if (declaringTeam.IsVulnerable)
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

                        if ((counter == 0) || (counter == 1 && !declaringTeam.IsVulnerable))
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

        public int CalculateDoubledContractPoints(Contract contract, Team declaringTeam, int tricksMade)
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

        public int CalculateSlamPoints(Contract contract, Team declaringTeam, int tricksMade)
        {
            int currentscore = 0;
            if (contract.contractMade)
            {
                if (contract.tricks == 6)
                {
                    if (declaringTeam.IsVulnerable)
                        currentscore = 750;
                    else
                        currentscore = 500;
                }
                else if (contract.tricks == 7)
                {
                    if (declaringTeam.IsVulnerable)
                        currentscore = 1500;
                    else
                        currentscore = 1000;
                }
            }
            return currentscore;
        }


    }

    public class Team
    {
        public int Score_BelowTheLine { get; set; } = 0;
        public int Score { get; set; } = 0;
        public bool IsVulnerable { get; set; } = false;

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

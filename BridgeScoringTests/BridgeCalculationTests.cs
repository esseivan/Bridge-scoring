using Microsoft.VisualStudio.TestTools.UnitTesting;
using BridgeScoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeScoring.Tests
{
    [TestClass()]
    public class BridgeCalculationTests
    {
        [TestMethod()]
        public void CalculateContractTest()
        {
            Dictionary<BridgeCalculation.ScoreType, int> scores = TestScore(1, Contract.Couleurs.Trefle, Contract.Doubled.NonDbl, false, 8);
            Assert.IsTrue(scores[BridgeCalculation.ScoreType.All] == 40);
        }

        private Dictionary<BridgeCalculation.ScoreType, int> TestScore(int contractTricks, Contract.Couleurs couleur, Contract.Doubled doubled, bool isVul, int tricksMade)
        {
            bool IsVulnerable = isVul;

            BridgeCalculation bc = new BridgeCalculation(true);

            Contract c1 = new Contract(contractTricks, couleur, doubled);

            Dictionary<BridgeCalculation.ScoreType, int> scores = bc.CalculateContract(c1, isVul, tricksMade);

            return scores;
        }
    }
}
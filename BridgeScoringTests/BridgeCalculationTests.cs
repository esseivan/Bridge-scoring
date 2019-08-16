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
        public void GetScoreTest()
        {
            Assert.AreEqual(TestScore(2, BridgeCalculation.Couleurs.Trefle, BridgeCalculation.DoubleMode.NonDbl, false, 2), 40);
            Assert.AreEqual(TestScore(2, BridgeCalculation.Couleurs.Trefle, BridgeCalculation.DoubleMode.Dbl, false, 2), 40);
            Assert.AreEqual(TestScore(2, BridgeCalculation.Couleurs.Trefle, BridgeCalculation.DoubleMode.Dbl, false, 2), 40);
            Assert.AreEqual(TestScore(2, BridgeCalculation.Couleurs.Trefle, BridgeCalculation.DoubleMode.Dbl, false, 2), 40);
            Assert.AreEqual(TestScore(2, BridgeCalculation.Couleurs.Trefle, BridgeCalculation.DoubleMode.Dbl, false, 2), 40);
            Assert.AreEqual(TestScore(2, BridgeCalculation.Couleurs.Trefle, BridgeCalculation.DoubleMode.Dbl, false, 2), 40);
        }

        private int TestScore(int contratLevee, BridgeCalculation.Couleurs couleur, BridgeCalculation.DoubleMode mode, bool isVul, int leveeFaites)
        {
            BridgeCalculation bc = new BridgeCalculation()
            {
                ContratLevee = contratLevee,
                Couleur = couleur,
                Double = mode,
                IsVulnerable = isVul,
                LeveeFaites = leveeFaites,
            };

            int score = bc.GetScore(BridgeCalculation.ScoreType.ContractPoint);

            return score;
        }
    }
}
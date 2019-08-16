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
            Team team = null;

            team = TestScore(2, Contract.Couleurs.Trefle, Contract.Doubled.NonDbl, false, 2);
            Assert.IsTrue((team.Score_BelowTheLine + team.Score) == 40);
        }

        private Team TestScore(int contractTricks, Contract.Couleurs couleur, Contract.Doubled doubled, bool isVul, int tricksMade)
        {
            Team ns = new Team();
            ns.IsVulnerable = isVul;

            Team we = new Team();
            BridgeCalculation bc = new BridgeCalculation(true)
            {
                Team_NS = ns,
                Team_WE = we
            };

            Contract c1 = new Contract(contractTricks, couleur, doubled);

            bc.CalculateContract(c1, ns, tricksMade);

            return ns;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EsseivaN.Utils;

namespace BridgeScoring
{
    public partial class Form1 : Form
    {
        BridgeCalculation bridgeCalculation;

        private CheckboxGrouped grp_dbl = new CheckboxGrouped()
        {
            AllowNoSelection = false,
            MultipleSelection = false,
            DefaultActiveIndex = 0,
        };

        private CheckboxGrouped grp_vul = new CheckboxGrouped()
        {
            AllowNoSelection = false,
            MultipleSelection = false,
            DefaultActiveIndex = 0,
        };

        public Form1()
        {
            InitializeComponent();

            // Group Contré (double)
            grp_dbl.Add(chbNC);
            grp_dbl.Add(chbC);
            grp_dbl.Add(chbSC);
            grp_dbl.CheckNoSelection();

            // Group Vulnerable
            grp_vul.Add(chbNV);
            grp_vul.Add(chbV);
            grp_vul.CheckNoSelection();

            // Contrat
            cboxCIndex.Items.AddRange(new object[] { 1, 2, 3, 4, 5, 6, 7 });
            cboxCIndex.SelectedIndex = 0;
            cboxCCouleur.Items.AddRange(Enum.GetNames(typeof(Contract.Couleurs)));
            cboxCCouleur.SelectedIndex = 0;

            // Levees
            cboxTIndex.Items.AddRange(new object[] { "-6 (0)", "-5 (1)", "-4 (2)", "-3 (3)", "-2 (4)", "-1 (5)", "0 (6)", "+1 (7)", "+2 (8)", "+3 (9)", "+4 (10)", "+5 (11)", "+6 (12)", "+7 (13)" });
            cboxTIndex.SelectedIndex = 0;

            bridgeCalculation = new BridgeCalculation(btnMode.Checked);
        }

        private void CheckBox_dbl_CheckedChanged(object sender, EventArgs e)
        {
            grp_dbl.Event_CheckedChanged(sender);
        }
        private void CheckBox_vul_CheckedChanged(object sender, EventArgs e)
        {
            grp_vul.Event_CheckedChanged(sender);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Contract contract = new Contract();

            // Tricks
            contract.SetTricks(cboxCIndex.SelectedIndex + 1);

            // Couleur
            contract.SetCouleur((Contract.Couleurs)Enum.Parse(typeof(Contract.Couleurs), cboxCCouleur.SelectedItem.ToString()));

            // Doubled
            contract.doubled = (Contract.Doubled)grp_dbl.GetSelectedIndex();

            Dictionary<BridgeCalculation.ScoreType, int> scores = bridgeCalculation.CalculateContract(contract, chbV.Checked, cboxTIndex.SelectedIndex);

            tbContract.Text = scores[BridgeCalculation.ScoreType.Contract].ToString();
            tbOvertrick.Text = scores[BridgeCalculation.ScoreType.Overtrick].ToString();
            tbUndertrick.Text = scores[BridgeCalculation.ScoreType.Undertrick].ToString();
            tbDoubled.Text = scores[BridgeCalculation.ScoreType.Doubled].ToString();
            tbSlam.Text = scores[BridgeCalculation.ScoreType.Slam].ToString();
            tbPartGame.Text = scores[BridgeCalculation.ScoreType.PartGame].ToString();
            tbTotalPrimes.Text = (scores[BridgeCalculation.ScoreType.All] - scores[BridgeCalculation.ScoreType.Contract]).ToString();
            tbTotal.Text = (scores[BridgeCalculation.ScoreType.All]).ToString();
        }

        private void BtnMode_CheckedChanged(object sender, EventArgs e)
        {
            btnMode.Text = "Mode : " + (btnMode.Checked ? "Rubber" : "Duplicate");
            bridgeCalculation = new BridgeCalculation(btnMode.Checked);

            tbPartGame.Enabled = !btnMode.Checked;
        }
    }
}

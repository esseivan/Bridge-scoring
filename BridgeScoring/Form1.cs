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

        private string[] couleurs = new string[] { "Trèfle", "Carreau", "Coeur", "Pique", "Sans-Atout" };

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
            cboxCCouleur.Items.AddRange(couleurs);
            cboxCCouleur.SelectedIndex = 0;

            // Levees
            cboxTIndex.Items.AddRange(new object[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 });
            cboxTIndex.SelectedIndex = 0;
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

        }
    }
}

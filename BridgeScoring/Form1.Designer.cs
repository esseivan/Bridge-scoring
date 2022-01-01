namespace BridgeScoring
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chbNC = new System.Windows.Forms.CheckBox();
            this.chbC = new System.Windows.Forms.CheckBox();
            this.chbSC = new System.Windows.Forms.CheckBox();
            this.chbV = new System.Windows.Forms.CheckBox();
            this.chbNV = new System.Windows.Forms.CheckBox();
            this.grpboxContract = new System.Windows.Forms.GroupBox();
            this.cboxCIndex = new System.Windows.Forms.ComboBox();
            this.cboxCCouleur = new System.Windows.Forms.ComboBox();
            this.grpboxTrick = new System.Windows.Forms.GroupBox();
            this.cboxTIndex = new System.Windows.Forms.ComboBox();
            this.grpboxScore = new System.Windows.Forms.GroupBox();
            this.tbTotalPrimes = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbContract = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tbSlam = new System.Windows.Forms.TextBox();
            this.tbDoubled = new System.Windows.Forms.TextBox();
            this.tbUndertrick = new System.Windows.Forms.TextBox();
            this.tbOvertrick = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbTotal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnMode = new System.Windows.Forms.CheckBox();
            this.tbPartGame = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.grpboxContract.SuspendLayout();
            this.grpboxTrick.SuspendLayout();
            this.grpboxScore.SuspendLayout();
            this.SuspendLayout();
            // 
            // chbNC
            // 
            this.chbNC.AutoSize = true;
            this.chbNC.Location = new System.Drawing.Point(18, 70);
            this.chbNC.Name = "chbNC";
            this.chbNC.Size = new System.Drawing.Size(79, 17);
            this.chbNC.TabIndex = 0;
            this.chbNC.Text = "Non contré";
            this.chbNC.UseVisualStyleBackColor = true;
            this.chbNC.CheckedChanged += new System.EventHandler(this.CheckBox_dbl_CheckedChanged);
            // 
            // chbC
            // 
            this.chbC.AutoSize = true;
            this.chbC.Location = new System.Drawing.Point(122, 70);
            this.chbC.Name = "chbC";
            this.chbC.Size = new System.Drawing.Size(57, 17);
            this.chbC.TabIndex = 1;
            this.chbC.Text = "Contré";
            this.chbC.UseVisualStyleBackColor = true;
            this.chbC.CheckedChanged += new System.EventHandler(this.CheckBox_dbl_CheckedChanged);
            // 
            // chbSC
            // 
            this.chbSC.AutoSize = true;
            this.chbSC.Location = new System.Drawing.Point(204, 70);
            this.chbSC.Name = "chbSC";
            this.chbSC.Size = new System.Drawing.Size(72, 17);
            this.chbSC.TabIndex = 2;
            this.chbSC.Text = "Surcontré";
            this.chbSC.UseVisualStyleBackColor = true;
            this.chbSC.CheckedChanged += new System.EventHandler(this.CheckBox_dbl_CheckedChanged);
            // 
            // chbV
            // 
            this.chbV.AutoSize = true;
            this.chbV.Location = new System.Drawing.Point(122, 93);
            this.chbV.Name = "chbV";
            this.chbV.Size = new System.Drawing.Size(76, 17);
            this.chbV.TabIndex = 4;
            this.chbV.Text = "Vulnérable";
            this.chbV.UseVisualStyleBackColor = true;
            this.chbV.CheckedChanged += new System.EventHandler(this.CheckBox_vul_CheckedChanged);
            // 
            // chbNV
            // 
            this.chbNV.AutoSize = true;
            this.chbNV.Location = new System.Drawing.Point(18, 93);
            this.chbNV.Name = "chbNV";
            this.chbNV.Size = new System.Drawing.Size(98, 17);
            this.chbNV.TabIndex = 3;
            this.chbNV.Text = "Non vulnérable";
            this.chbNV.UseVisualStyleBackColor = true;
            this.chbNV.CheckedChanged += new System.EventHandler(this.CheckBox_vul_CheckedChanged);
            // 
            // grpboxContract
            // 
            this.grpboxContract.Controls.Add(this.cboxCIndex);
            this.grpboxContract.Controls.Add(this.cboxCCouleur);
            this.grpboxContract.Location = new System.Drawing.Point(12, 12);
            this.grpboxContract.Name = "grpboxContract";
            this.grpboxContract.Size = new System.Drawing.Size(200, 52);
            this.grpboxContract.TabIndex = 5;
            this.grpboxContract.TabStop = false;
            this.grpboxContract.Text = "Contrat";
            // 
            // cboxCIndex
            // 
            this.cboxCIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxCIndex.FormattingEnabled = true;
            this.cboxCIndex.Location = new System.Drawing.Point(6, 19);
            this.cboxCIndex.MaxLength = 1;
            this.cboxCIndex.Name = "cboxCIndex";
            this.cboxCIndex.Size = new System.Drawing.Size(58, 21);
            this.cboxCIndex.TabIndex = 1;
            // 
            // cboxCCouleur
            // 
            this.cboxCCouleur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxCCouleur.FormattingEnabled = true;
            this.cboxCCouleur.Location = new System.Drawing.Point(73, 19);
            this.cboxCCouleur.Name = "cboxCCouleur";
            this.cboxCCouleur.Size = new System.Drawing.Size(121, 21);
            this.cboxCCouleur.TabIndex = 0;
            // 
            // grpboxTrick
            // 
            this.grpboxTrick.Controls.Add(this.cboxTIndex);
            this.grpboxTrick.Location = new System.Drawing.Point(218, 12);
            this.grpboxTrick.Name = "grpboxTrick";
            this.grpboxTrick.Size = new System.Drawing.Size(74, 52);
            this.grpboxTrick.TabIndex = 6;
            this.grpboxTrick.TabStop = false;
            this.grpboxTrick.Text = "Levées";
            // 
            // cboxTIndex
            // 
            this.cboxTIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxTIndex.FormattingEnabled = true;
            this.cboxTIndex.Location = new System.Drawing.Point(6, 19);
            this.cboxTIndex.MaxLength = 1;
            this.cboxTIndex.Name = "cboxTIndex";
            this.cboxTIndex.Size = new System.Drawing.Size(58, 21);
            this.cboxTIndex.TabIndex = 1;
            // 
            // grpboxScore
            // 
            this.grpboxScore.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpboxScore.Controls.Add(this.tbPartGame);
            this.grpboxScore.Controls.Add(this.label8);
            this.grpboxScore.Controls.Add(this.tbTotal);
            this.grpboxScore.Controls.Add(this.label7);
            this.grpboxScore.Controls.Add(this.tbTotalPrimes);
            this.grpboxScore.Controls.Add(this.label6);
            this.grpboxScore.Controls.Add(this.tbSlam);
            this.grpboxScore.Controls.Add(this.label5);
            this.grpboxScore.Controls.Add(this.tbDoubled);
            this.grpboxScore.Controls.Add(this.label4);
            this.grpboxScore.Controls.Add(this.tbUndertrick);
            this.grpboxScore.Controls.Add(this.label3);
            this.grpboxScore.Controls.Add(this.tbOvertrick);
            this.grpboxScore.Controls.Add(this.label2);
            this.grpboxScore.Controls.Add(this.tbContract);
            this.grpboxScore.Controls.Add(this.label1);
            this.grpboxScore.Location = new System.Drawing.Point(298, 12);
            this.grpboxScore.Name = "grpboxScore";
            this.grpboxScore.Size = new System.Drawing.Size(358, 304);
            this.grpboxScore.TabIndex = 7;
            this.grpboxScore.TabStop = false;
            this.grpboxScore.Text = "Score";
            // 
            // tbTotalPrimes
            // 
            this.tbTotalPrimes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTotalPrimes.Location = new System.Drawing.Point(130, 175);
            this.tbTotalPrimes.Name = "tbTotalPrimes";
            this.tbTotalPrimes.Size = new System.Drawing.Size(222, 20);
            this.tbTotalPrimes.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Total primes";
            // 
            // tbContract
            // 
            this.tbContract.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbContract.Location = new System.Drawing.Point(130, 19);
            this.tbContract.Name = "tbContract";
            this.tbContract.Size = new System.Drawing.Size(222, 20);
            this.tbContract.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Contrat";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 116);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Calculate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // tbSlam
            // 
            this.tbSlam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSlam.Location = new System.Drawing.Point(130, 123);
            this.tbSlam.Name = "tbSlam";
            this.tbSlam.Size = new System.Drawing.Size(222, 20);
            this.tbSlam.TabIndex = 9;
            // 
            // tbDoubled
            // 
            this.tbDoubled.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDoubled.Location = new System.Drawing.Point(130, 97);
            this.tbDoubled.Name = "tbDoubled";
            this.tbDoubled.Size = new System.Drawing.Size(222, 20);
            this.tbDoubled.TabIndex = 7;
            // 
            // tbUndertrick
            // 
            this.tbUndertrick.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUndertrick.Location = new System.Drawing.Point(130, 71);
            this.tbUndertrick.Name = "tbUndertrick";
            this.tbUndertrick.Size = new System.Drawing.Size(222, 20);
            this.tbUndertrick.TabIndex = 5;
            // 
            // tbOvertrick
            // 
            this.tbOvertrick.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOvertrick.Location = new System.Drawing.Point(130, 45);
            this.tbOvertrick.Name = "tbOvertrick";
            this.tbOvertrick.Size = new System.Drawing.Size(222, 20);
            this.tbOvertrick.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Undertrick";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Doubled";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Slam";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Overtrick";
            // 
            // tbTotal
            // 
            this.tbTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTotal.Location = new System.Drawing.Point(130, 201);
            this.tbTotal.Name = "tbTotal";
            this.tbTotal.Size = new System.Drawing.Size(222, 20);
            this.tbTotal.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 204);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Total";
            // 
            // btnMode
            // 
            this.btnMode.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnMode.Location = new System.Drawing.Point(12, 145);
            this.btnMode.Name = "btnMode";
            this.btnMode.Size = new System.Drawing.Size(104, 24);
            this.btnMode.TabIndex = 9;
            this.btnMode.Text = "Mode : Duplicate";
            this.btnMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnMode.UseVisualStyleBackColor = true;
            this.btnMode.CheckedChanged += new System.EventHandler(this.BtnMode_CheckedChanged);
            // 
            // tbPartGame
            // 
            this.tbPartGame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPartGame.Location = new System.Drawing.Point(130, 149);
            this.tbPartGame.Name = "tbPartGame";
            this.tbPartGame.Size = new System.Drawing.Size(222, 20);
            this.tbPartGame.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 152);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Part game";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 328);
            this.Controls.Add(this.btnMode);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grpboxScore);
            this.Controls.Add(this.grpboxTrick);
            this.Controls.Add(this.grpboxContract);
            this.Controls.Add(this.chbV);
            this.Controls.Add(this.chbNV);
            this.Controls.Add(this.chbSC);
            this.Controls.Add(this.chbC);
            this.Controls.Add(this.chbNC);
            this.Name = "Form1";
            this.Text = "Form1";
            this.grpboxContract.ResumeLayout(false);
            this.grpboxTrick.ResumeLayout(false);
            this.grpboxScore.ResumeLayout(false);
            this.grpboxScore.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chbNC;
        private System.Windows.Forms.CheckBox chbC;
        private System.Windows.Forms.CheckBox chbSC;
        private System.Windows.Forms.CheckBox chbV;
        private System.Windows.Forms.CheckBox chbNV;
        private System.Windows.Forms.GroupBox grpboxContract;
        private System.Windows.Forms.ComboBox cboxCIndex;
        private System.Windows.Forms.ComboBox cboxCCouleur;
        private System.Windows.Forms.GroupBox grpboxTrick;
        private System.Windows.Forms.ComboBox cboxTIndex;
        private System.Windows.Forms.GroupBox grpboxScore;
        private System.Windows.Forms.TextBox tbContract;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbTotalPrimes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbSlam;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbDoubled;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbUndertrick;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbOvertrick;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbTotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox btnMode;
        private System.Windows.Forms.TextBox tbPartGame;
        private System.Windows.Forms.Label label8;
    }
}


using System.Drawing;
using System.Windows.Forms;

namespace ABV_Calc
{
    partial class ABV_Calc
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ABV_Calc));
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            radioSG = new RadioButton();
            radioPlato = new RadioButton();
            inputOG = new TextBox();
            inputFG = new TextBox();
            radioAlternate = new RadioButton();
            radioStandard = new RadioButton();
            panel1 = new Panel();
            panel2 = new Panel();
            calculatedABV = new Label();
            label10 = new Label();
            panel4 = new Panel();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            label2 = new Label();
            panel5 = new Panel();
            label11 = new Label();
            richTextBox1 = new RichTextBox();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            panel3 = new Panel();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(31, 58);
            label5.Name = "label5";
            label5.Size = new Size(69, 15);
            label5.TabIndex = 4;
            label5.Text = "Gravity Unit";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(31, 106);
            label6.Name = "label6";
            label6.Size = new Size(89, 15);
            label6.TabIndex = 5;
            label6.Text = "Original Gravity";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(31, 139);
            label7.Name = "label7";
            label7.Size = new Size(72, 15);
            label7.TabIndex = 6;
            label7.Text = "Final Gravity";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(31, 172);
            label8.Name = "label8";
            label8.Size = new Size(54, 15);
            label8.TabIndex = 7;
            label8.Text = "Equation";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(31, 223);
            label9.Name = "label9";
            label9.Size = new Size(107, 15);
            label9.TabIndex = 8;
            label9.Text = "Alcohol by Volume";
            // 
            // radioSG
            // 
            radioSG.AutoSize = true;
            radioSG.Checked = true;
            radioSG.Location = new Point(15, 16);
            radioSG.Name = "radioSG";
            radioSG.Size = new Size(77, 19);
            radioSG.TabIndex = 9;
            radioSG.TabStop = true;
            radioSG.Text = "SG (1.xxx)";
            radioSG.UseVisualStyleBackColor = true;
            // 
            // radioPlato
            // 
            radioPlato.AutoSize = true;
            radioPlato.Location = new Point(15, 37);
            radioPlato.Name = "radioPlato";
            radioPlato.Size = new Size(67, 19);
            radioPlato.TabIndex = 10;
            radioPlato.Text = "Plato °P";
            radioPlato.UseVisualStyleBackColor = true;
            // 
            // inputOG
            // 
            inputOG.Location = new Point(159, 98);
            inputOG.Name = "inputOG";
            inputOG.Size = new Size(100, 23);
            inputOG.TabIndex = 11;
            // 
            // inputFG
            // 
            inputFG.Location = new Point(159, 131);
            inputFG.Name = "inputFG";
            inputFG.Size = new Size(100, 23);
            inputFG.TabIndex = 12;
            // 
            // radioAlternate
            // 
            radioAlternate.AutoSize = true;
            radioAlternate.Location = new Point(14, 24);
            radioAlternate.Name = "radioAlternate";
            radioAlternate.Size = new Size(73, 19);
            radioAlternate.TabIndex = 14;
            radioAlternate.Text = "Alternate";
            radioAlternate.UseVisualStyleBackColor = true;
            // 
            // radioStandard
            // 
            radioStandard.AutoSize = true;
            radioStandard.Checked = true;
            radioStandard.Location = new Point(14, 3);
            radioStandard.Name = "radioStandard";
            radioStandard.Size = new Size(72, 19);
            radioStandard.TabIndex = 13;
            radioStandard.TabStop = true;
            radioStandard.Text = "Standard";
            radioStandard.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(radioPlato);
            panel1.Controls.Add(radioSG);
            panel1.Location = new Point(144, 36);
            panel1.Name = "panel1";
            panel1.Size = new Size(132, 60);
            panel1.TabIndex = 15;
            // 
            // panel2
            // 
            panel2.Controls.Add(radioAlternate);
            panel2.Controls.Add(radioStandard);
            panel2.Location = new Point(145, 159);
            panel2.Name = "panel2";
            panel2.Size = new Size(129, 49);
            panel2.TabIndex = 16;
            // 
            // calculatedABV
            // 
            calculatedABV.AutoSize = true;
            calculatedABV.Font = new Font("Tahoma", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            calculatedABV.ForeColor = Color.FromArgb(0, 64, 0);
            calculatedABV.Location = new Point(163, 223);
            calculatedABV.Name = "calculatedABV";
            calculatedABV.Size = new Size(0, 23);
            calculatedABV.TabIndex = 18;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Tahoma", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label10.ForeColor = Color.FromArgb(0, 64, 0);
            label10.Location = new Point(159, 223);
            label10.Name = "label10";
            label10.Size = new Size(0, 23);
            label10.TabIndex = 19;
            // 
            // panel4
            // 
            panel4.Controls.Add(label4);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(label1);
            panel4.Controls.Add(label2);
            panel4.Location = new Point(14, 493);
            panel4.Name = "panel4";
            panel4.Size = new Size(294, 110);
            panel4.TabIndex = 23;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 83);
            label4.Name = "label4";
            label4.Size = new Size(257, 15);
            label4.TabIndex = 30;
            label4.Text = "ABV =(76.08 * (og-fg) / (1.775-og)) * (fg / 0.794)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(3, 58);
            label3.Name = "label3";
            label3.Size = new Size(164, 19);
            label3.TabIndex = 29;
            label3.Text = "Alternate Formula:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(3, 12);
            label1.Name = "label1";
            label1.Size = new Size(160, 19);
            label1.TabIndex = 27;
            label1.Text = "Standard Formula:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 37);
            label2.Name = "label2";
            label2.Size = new Size(132, 15);
            label2.TabIndex = 28;
            label2.Text = "ABV = (og – fg) * 131.25";
            // 
            // panel5
            // 
            panel5.BackColor = Color.Transparent;
            panel5.Controls.Add(label10);
            panel5.Controls.Add(calculatedABV);
            panel5.Controls.Add(panel2);
            panel5.Controls.Add(panel1);
            panel5.Controls.Add(inputFG);
            panel5.Controls.Add(inputOG);
            panel5.Controls.Add(label9);
            panel5.Controls.Add(label8);
            panel5.Controls.Add(label7);
            panel5.Controls.Add(label6);
            panel5.Controls.Add(label5);
            panel5.Location = new Point(14, 143);
            panel5.Name = "panel5";
            panel5.Size = new Size(331, 261);
            panel5.TabIndex = 24;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Tahoma", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(14, 9);
            label11.Name = "label11";
            label11.Size = new Size(418, 29);
            label11.TabIndex = 26;
            label11.Text = "Alcohol By Volume ABV Calculator";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(14, 41);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(346, 96);
            richTextBox1.TabIndex = 27;
            richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // button3
            // 
            button3.Location = new Point(112, 34);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 30;
            button3.Text = "Close";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(163, 5);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 29;
            button2.Text = "Clear";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // button1
            // 
            button1.Location = new Point(59, 5);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 28;
            button1.Text = "Calculate";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Transparent;
            panel3.Controls.Add(button3);
            panel3.Controls.Add(button2);
            panel3.Controls.Add(button1);
            panel3.Location = new Point(14, 410);
            panel3.Name = "panel3";
            panel3.Size = new Size(331, 66);
            panel3.TabIndex = 31;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(397, 143);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(548, 333);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 32;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(1086, 633);
            Controls.Add(pictureBox1);
            Controls.Add(panel3);
            Controls.Add(richTextBox1);
            Controls.Add(label11);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "ABV Calculator";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private RadioButton radioSG;
        private RadioButton radioPlato;
        private TextBox inputOG;
        private TextBox inputFG;
        private RadioButton radioAlternate;
        private RadioButton radioStandard;
        private Panel panel1;
        private Panel panel2;
        private Button button1;
        private Label calculatedABV;
        private Label label10;
        private Button button2;
        private Button button3;
        private Panel panel4;
        private Panel panel5;
        private Label label4;
        private Label label3;
        private Label label1;
        private Label label2;
        private Label label11;
        private RichTextBox richTextBox1;
        private Panel panel3;
        private PictureBox pictureBox1;
    }
}
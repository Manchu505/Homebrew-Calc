using System;
using System.Data.OleDb;
using System.Linq;
using System.Windows.Forms;

namespace Homebrew_Recipe_Calc
{
    public partial class frmRecipe : Form
    {
        double waterVol1;
        double waterVol2;
        double yeastFact;
        double tHopAB;
        double Efficiency;
        double Efficiency1 = 0.924432289701999;
        double Efficiency2 = -0.000123500565824217;
        double[] PPG = new double[9];
        double[] Lbs = new double[9];
        double[] Attn = new double[9];
        double[] points = new double[9];
        double[] grainWt = new double[9];
        double[] percent = new double[9];
        double[] ferment = new double[9];
        double[] Lov = new double[9];
        double[] contribution = new double[9];
        double[] waterAb = new double[9];
        string[] waterAbsor = new string[9];
        double[] OGCon = new double[9];
        double[] FGCon = new double[9];
        double[] hopAB = new double[9];
        double[] lblwaterAB = new double[9];
        double[] IBU = new double[9];
        string[] hoputilization = new string[9];
        double[] hopUtil = new double[9];
        double[] hopAmount = new double[9];
        OleDbConnection conn;
        OleDbCommand command;

        public frmRecipe()
        {
            InitializeComponent();
            String DBPath = Application.StartupPath + "\\Access_ingredients.accdb";
            conn = new OleDbConnection("provider = Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + DBPath);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                command = new OleDbCommand();
                command.Connection = conn;
                string query = "select * from GRAINLOOKUP";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    cboGrain1.Items.Add(reader["Grain"].ToString());
                    cboGrain2.Items.Add(reader["Grain"].ToString());
                    cboGrain3.Items.Add(reader["Grain"].ToString());
                    cboGrain4.Items.Add(reader["Grain"].ToString());
                    cboGrain5.Items.Add(reader["Grain"].ToString());
                    cboGrain6.Items.Add(reader["Grain"].ToString());
                    cboGrain7.Items.Add(reader["Grain"].ToString());
                    cboGrain8.Items.Add(reader["Grain"].ToString());
                    cboGrain9.Items.Add(reader["Grain"].ToString());
                }
                label34.Text = "Grain Connection Successful";
                conn.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("Grain Combo Box Catch");
                conn.Close();
            }
            try
            {
                conn.Open();
                command = new OleDbCommand();
                command.Connection = conn;
                string query = "select * from HOPLOOKUP";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    cboHops1.Items.Add(reader["Hop"].ToString());
                    cboHops2.Items.Add(reader["Hop"].ToString());
                    cboHops3.Items.Add(reader["Hop"].ToString());
                    cboHops4.Items.Add(reader["Hop"].ToString());
                    cboHops5.Items.Add(reader["Hop"].ToString());
                    cboHopMin1.Items.Add(reader["Minutes"].ToString());
                    cboHopMin2.Items.Add(reader["Minutes"].ToString());
                    cboHopMin3.Items.Add(reader["Minutes"].ToString());
                    cboHopMin4.Items.Add(reader["Minutes"].ToString());
                    cboHopMin5.Items.Add(reader["Minutes"].ToString());

                }
                label12.Text = "Hop Connection Successful";
                conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Hop Combo Box Catch");
                conn.Close();
            }
            try
            {
                conn.Open();
                command = new OleDbCommand();
                command.Connection = conn;
                string query = "select * from YEASTLOOKUP";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    lstYeast.Items.Add(reader["YeastStrain"].ToString());
                }
                label13.Text = "Yeast Connection Successful";
                conn.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("Yeast Combo Box Catch");
                conn.Close();
            }
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SelectNextControl(ActiveControl, true, true, true, true);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            catch { }
        }
        private void watervolume(object sender)
        {
            try
            {
                double waVolume = double.Parse(txtWaterVolume.Text);
                waterVol2 = (waVolume + hopAB.Sum()) / 1000 * .264172;
                txtWaterFinishGal.Text = waterVol2.ToString("N2");

                double waterToAddFinal = (lblwaterAB.Sum() + hopAB.Sum() + waVolume);
                txtWaterToAdd.Text = waterToAddFinal.ToString();

                waterVol1 = waterToAddFinal / 1000 * .264172;
                txtWaterToAddGal.Text = waterVol1.ToString("N2");
            }
            catch (Exception) { }
        }
        private void percentChange(object sender)
        {
            try
            {
                if (grainWt[0] > 0)
                {
                    percent[0] = grainWt[0] / grainWt.Sum();
                    lblPercent1.Text = percent[0].ToString("P2");
                }

                if (grainWt[1] > 0)
                {
                    percent[1] = grainWt[1] / grainWt.Sum();
                    lblPercent2.Text = percent[1].ToString("P2");
                }
                if (grainWt[2] > 0)
                {
                    percent[2] = grainWt[2] / grainWt.Sum();
                    lblPercent3.Text = percent[2].ToString("P2");
                }

                if (grainWt[3] > 0)
                {
                    percent[3] = grainWt[3] / grainWt.Sum();
                    lblPercent4.Text = percent[3].ToString("P2");
                }

                if (grainWt[4] > 0)
                {
                    percent[4] = grainWt[4] / grainWt.Sum();
                    lblPercent5.Text = percent[4].ToString("P2");
                }

                if (grainWt[5] > 0)
                {
                    percent[5] = grainWt[5] / grainWt.Sum();
                    lblPercent6.Text = percent[5].ToString("P2");
                }

                if (grainWt[6] > 0)
                {
                    percent[6] = grainWt[6] / grainWt.Sum();
                    lblPercent7.Text = percent[6].ToString("P2");
                }

                if (grainWt[7] > 0)
                {
                    percent[7] = grainWt[7] / grainWt.Sum();
                    lblPercent8.Text = percent[7].ToString("P2");
                }

                if (grainWt[8] > 0)
                {
                    percent[8] = grainWt[8] / grainWt.Sum();
                    lblPercent9.Text = percent[8].ToString("P2");
                }

                Efficiency = Efficiency1 + Efficiency2 * grainWt.Sum();
                txtPreEff.Text = Efficiency.ToString("P0");
            }
            catch (Exception)
            {
                MessageBox.Show("Percent Change Error");
            }
        }
        private void originalGravityChange(object sender)
        {
            try
            {
                if (grainWt[0] > 0)
                {
                    if (lblAff1.Text == "y")
                    {
                        OGCon[0] = ((points[0] * Efficiency) / waterVol2) / 1000;
                        lblOGC1.Text = OGCon[0].ToString("N3");
                    }
                    else
                    {
                        OGCon[0] = ((points[0] + Efficiency) / waterVol2) / 1000;
                        lblOGC1.Text = OGCon[0].ToString("N3");
                    }
                }
                if (grainWt[1] > 0)
                {
                    if (lblAff2.Text == "y")
                    {
                        OGCon[1] = ((points[1] * Efficiency) / waterVol2) / 1000;
                        lblOGC2.Text = OGCon[1].ToString("N3");
                    }
                    else
                    {
                        OGCon[1] = ((points[1] + Efficiency) / waterVol2) / 1000;
                        lblOGC2.Text = OGCon[1].ToString("N3");
                    }
                }
                if (grainWt[2] > 0)
                {
                    if (lblAff3.Text == "y")
                    {
                        OGCon[2] = ((points[2] * Efficiency) / waterVol2) / 1000;
                        lblOGC3.Text = OGCon[2].ToString("N3");
                    }
                    else
                    {
                        OGCon[2] = ((points[2] + Efficiency) / waterVol2) / 1000;
                        lblOGC3.Text = OGCon[2].ToString("N3");
                    }
                }
                if (grainWt[3] > 0)
                {
                    if (lblAff4.Text == "y")
                    {
                        OGCon[3] = ((points[3] * Efficiency) / waterVol2) / 1000;
                        lblOGC4.Text = OGCon[3].ToString("N3");
                    }
                    else
                    {
                        OGCon[3] = ((points[3] + Efficiency) / waterVol2) / 1000;
                        lblOGC4.Text = OGCon[3].ToString("N3");
                    }
                }
                if (grainWt[4] > 0)
                {
                    if (lblAff5.Text == "y")
                    {
                        OGCon[4] = ((points[4] * Efficiency) / waterVol2) / 1000;
                        lblOGC5.Text = OGCon[4].ToString("N3");
                    }
                    else
                    {
                        OGCon[4] = ((points[4] + Efficiency) / waterVol2) / 1000;
                        lblOGC5.Text = OGCon[4].ToString("N3");
                    }
                }
                if (grainWt[5] > 0)
                {
                    if (lblAff6.Text == "y")
                    {
                        OGCon[5] = ((points[5] * Efficiency) / waterVol2) / 1000;
                        lblOGC6.Text = OGCon[5].ToString("N3");
                    }
                    else
                    {
                        OGCon[5] = ((points[5] + Efficiency) / waterVol2) / 1000;
                        lblOGC6.Text = OGCon[5].ToString("N3");
                    }
                }
                if (grainWt[6] > 0)
                {
                    if (lblAff7.Text == "y")
                    {
                        OGCon[6] = ((points[6] * Efficiency) / waterVol2) / 1000;
                        lblOGC7.Text = OGCon[6].ToString("N3");
                    }
                    else
                    {
                        OGCon[6] = ((points[6] + Efficiency) / waterVol2) / 1000;
                        lblOGC7.Text = OGCon[6].ToString("N3");
                    }
                }
                if (grainWt[7] > 0)
                {
                    if (lblAff8.Text == "y")
                    {
                        OGCon[7] = ((points[7] * Efficiency) / waterVol2) / 1000;
                        lblOGC8.Text = OGCon[7].ToString("N3");
                    }
                    else
                    {
                        OGCon[7] = ((points[7] + Efficiency) / waterVol2) / 1000;
                        lblOGC8.Text = OGCon[7].ToString("N3");
                    }
                }
                if (grainWt[8] > 0)
                {
                    if (lblAff9.Text == "y")
                    {
                        OGCon[8] = ((points[8] * Efficiency) / waterVol2) / 1000;
                        lblOGC9.Text = OGCon[8].ToString("N3");
                    }
                    else
                    {
                        OGCon[8] = ((points[8] + Efficiency) / waterVol2) / 1000;
                        lblOGC9.Text = OGCon[8].ToString("N3");
                    }
                }
                watervolume(lblOGTotal);
            }
            catch (Exception)
            {
                MessageBox.Show("OG Change Error");
            }
        }
        private void finalGravityChange(object sender)
        {
            try
            {
                if (grainWt[0] > 0)
                {
                    if (Attn[0] == 0)
                    {
                        lblFGC1.Text = OGCon[0].ToString("N3");
                    }
                    else
                    {
                        FGCon[0] = OGCon[0] - (1 + OGCon[0] - 1) * yeastFact / 100;
                        lblFGC1.Text = FGCon[0].ToString("N3");
                    }
                }
                if (grainWt[1] > 0)
                {
                    if (Attn[1] == 0)
                    {
                        lblFGC2.Text = OGCon[1].ToString("N3");
                    }
                    else
                    {
                        FGCon[1] = OGCon[1] - (1 + OGCon[1] - 1) * yeastFact / 100;
                        lblFGC2.Text = FGCon[1].ToString("N3");
                    }
                }
                if (grainWt[2] > 0)
                {
                    if (Attn[2] == 0)
                    {
                        lblFGC3.Text = OGCon[2].ToString("N3");
                    }
                    else
                    {
                        FGCon[2] = OGCon[2] - (1 + OGCon[2] - 1) * yeastFact / 100;
                        lblFGC3.Text = FGCon[2].ToString("N3");
                    }
                }
                if (grainWt[3] > 0)
                {
                    if (Attn[3] == 0)
                    {
                        lblFGC4.Text = OGCon[3].ToString("N3");
                    }
                    else
                    {
                        FGCon[3] = OGCon[3] - (1 + OGCon[3] - 1) * yeastFact / 100;
                        lblFGC4.Text = FGCon[3].ToString("N3");
                    }
                }
                if (grainWt[4] > 0)
                {
                    if (Attn[4] == 0)
                    {
                        lblFGC5.Text = OGCon[4].ToString("N3");
                    }
                    else
                    {
                        FGCon[4] = OGCon[4] - (1 + OGCon[4] - 1) * yeastFact / 100;
                        lblFGC5.Text = FGCon[4].ToString("N3");
                    }
                }
                if (grainWt[5] > 0)
                {
                    if (Attn[5] == 0)
                    {
                        lblFGC6.Text = OGCon[5].ToString("N3");
                    }
                    else
                    {
                        FGCon[5] = OGCon[5] - (1 + OGCon[5] - 1) * yeastFact / 100;
                        lblFGC6.Text = FGCon[5].ToString("N3");
                    }
                }
                if (grainWt[6] > 0)
                {
                    if (Attn[6] == 0)
                    {
                        lblFGC7.Text = OGCon[6].ToString("N3");
                    }
                    else
                    {
                        FGCon[6] = OGCon[6] - (1 + OGCon[6] - 1) * yeastFact / 100;
                        lblFGC7.Text = FGCon[6].ToString("N3");
                    }
                }
                if (grainWt[7] > 0)
                {
                    if (Attn[7] == 0)
                    {
                        lblFGC8.Text = OGCon[7].ToString("N3");
                    }
                    else
                    {
                        FGCon[7] = OGCon[7] - (1 + OGCon[7] - 1) * yeastFact / 100;
                        lblFGC8.Text = FGCon[7].ToString("N3");
                    }
                }
                if (grainWt[8] > 0)
                {
                    if (Attn[8] == 0)
                    {
                        lblFGC9.Text = OGCon[8].ToString("N3");
                    }
                    else
                    {
                        FGCon[8] = OGCon[8] - (1 + OGCon[8] - 1) * yeastFact / 100;
                        lblFGC9.Text = FGCon[8].ToString("N3");
                    }
                }
                watervolume(lblFGTotal);
            }
            catch (Exception)
            {
                MessageBox.Show("FG Change Error");
            }
        }
        private void srmContribution(object sender)
        {
            try
            {
                if (grainWt[0] > 0)
                {
                    if (grainWt[0] >= .01)
                    {
                        Lov[0] = double.Parse(lblLov1.Text);
                        contribution[0] = 1.49 * Math.Pow((Lov[0] * Lbs[0] / waterVol1), .69);
                        lblCon1.Text = contribution[0].ToString("N1");
                    }
                    else
                    {
                        lblCon1.Text = "0.0";
                    }
                }
                if (grainWt[1] > 0)
                {
                    if (grainWt[1] >= .01)
                    {
                        Lov[1] = double.Parse(lblLov2.Text);
                        contribution[1] = 1.49 * Math.Pow((Lov[1] * Lbs[1] / waterVol1), .69);
                        lblCon2.Text = contribution[1].ToString("N1");
                    }
                    else
                    {
                        lblCon2.Text = "0.0";
                    }
                }
                if (grainWt[2] > 0)
                {
                    if (grainWt[2] >= .01)
                    {
                        Lov[2] = double.Parse(lblLov3.Text);
                        contribution[2] = 1.49 * Math.Pow((Lov[2] * Lbs[2] / waterVol1), .69);
                        lblCon3.Text = contribution[2].ToString("N1");
                    }
                    else
                    {
                        lblCon3.Text = "0.0";
                    }
                }
                if (grainWt[3] > 0)
                {
                    if (grainWt[3] >= .01)
                    {
                        Lov[3] = double.Parse(lblLov4.Text);
                        contribution[3] = 1.49 * Math.Pow((Lov[3] * Lbs[3] / waterVol1), .69);
                        lblCon4.Text = contribution[3].ToString("N1");
                    }
                    else
                    {
                        lblCon4.Text = "0.0";
                    }
                }
                if (grainWt[4] > 0)
                {
                    if (grainWt[4] >= .01)
                    {
                        Lov[4] = double.Parse(lblLov5.Text);
                        contribution[4] = 1.49 * Math.Pow((Lov[4] * Lbs[4] / waterVol1), .69);
                        lblCon5.Text = contribution[4].ToString("N1");
                    }
                    else
                    {
                        lblCon5.Text = "0.0";
                    }
                }
                if (grainWt[5] > 0)
                {
                    if (grainWt[5] >= .01)
                    {
                        Lov[5] = double.Parse(lblLov6.Text);
                        contribution[5] = 1.49 * Math.Pow((Lov[5] * Lbs[5] / waterVol1), .69);
                        lblCon6.Text = contribution[5].ToString("N1");
                    }
                    else
                    {
                        lblCon6.Text = "0.0";
                    }
                }
                if (grainWt[6] > 0)
                {
                    if (grainWt[6] >= .01)
                    {
                        Lov[6] = double.Parse(lblLov7.Text);
                        contribution[6] = 1.49 * Math.Pow((Lov[6] * Lbs[6] / waterVol1), .69);
                        lblCon7.Text = contribution[6].ToString("N1");
                    }
                    else
                    {
                        lblCon7.Text = "0.0";
                    }
                }
                if (grainWt[7] > 0)
                {
                    if (grainWt[7] >= .01)
                    {
                        Lov[7] = double.Parse(lblLov8.Text);
                        contribution[7] = 1.49 * Math.Pow((Lov[7] * Lbs[7] / waterVol1), .69);
                        lblCon8.Text = contribution[7].ToString("N1");
                    }
                    else
                    {
                        lblCon8.Text = "0.0";
                    }
                }
                if (grainWt[8] > 0)
                {
                    if (grainWt[8] >= .01)
                    {
                        Lov[8] = double.Parse(lblLov9.Text);
                        contribution[8] = 1.49 * Math.Pow((Lov[8] * Lbs[8] / waterVol1), .69);
                        lblCon9.Text = contribution[8].ToString("N1");
                    }
                    else
                    {
                        lblCon9.Text = "0.0";
                    }
                }
                watervolume(lblSRMTotal);
            }
            catch (Exception)
            {
                MessageBox.Show("SRM Change Error");
            }
        }
        private void lstYeast_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                command = new OleDbCommand();
                command.Connection = conn;
                string query = "select * from YEASTLOOKUP where YeastStrain='" + lstYeast.Text + "'";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    txtYeastFactor.Text = reader["Attenuation"].ToString();
                }
                conn.Close();
                yeastFact = double.Parse(txtYeastFactor.Text);
                grainDataChange(yeastFact);
            }
            catch (Exception)
            {
                MessageBox.Show("Yeast ComboBox Change Catch");
                conn.Close();
            }
            try
            {
                if (txtWaterVolume.Text.Length > 0)
                {
                    watervolume(txtWaterVolume);
                }
                if (txtGrainWT1.Text.Length > 0)
                {
                    grainWt0(grainWt[0]);
                }
                if (txtGrainWT2.Text.Length > 0)
                {
                    grainWt1(grainWt[1]);
                }
                if (txtGrainWT3.Text.Length > 0)
                {
                    grainWt2(grainWt[2]);
                }
                if (txtGrainWT4.Text.Length > 0)
                {
                    grainWt3(grainWt[3]);
                }
                if (txtGrainWT5.Text.Length > 0)
                {
                    grainWt4(grainWt[4]);
                }
                if (txtGrainWT6.Text.Length > 0)
                {
                    grainWt5(grainWt[5]);
                }
                if (txtGrainWT7.Text.Length > 0)
                {
                    grainWt6(grainWt[6]);
                }
                if (txtGrainWT8.Text.Length > 0)
                {
                    grainWt7(grainWt[7]);
                }
                if (txtGrainWT9.Text.Length > 0)
                {
                    grainWt8(grainWt[8]);
                }
            }
            catch (Exception) { }
        }
        private void cboGrain1_SelectedIndexChanged(object sender, EventArgs e)
        {
            grainDataChange(cboGrain1);
        }

        private void cboGrain2_SelectedIndexChanged(object sender, EventArgs e)
        {
            grainDataChange(cboGrain2);
        }
        private void cboGrain3_SelectedIndexChanged(object sender, EventArgs e)
        {
            grainDataChange(cboGrain3);
        }
        private void cboGrain4_SelectedIndexChanged(object sender, EventArgs e)
        {
            grainDataChange(cboGrain4);
        }
        private void cboGrain5_SelectedIndexChanged(object sender, EventArgs e)
        {
            grainDataChange(cboGrain5);
        }
        private void cboGrain6_SelectedIndexChanged(object sender, EventArgs e)
        {
            grainDataChange(cboGrain6);
        }

        private void cboGrain7_SelectedIndexChanged(object sender, EventArgs e)
        {
            grainDataChange(cboGrain7);
        }

        private void cboGrain8_SelectedIndexChanged(object sender, EventArgs e)
        {
            grainDataChange(cboGrain8);
        }

        private void cboGrain9_SelectedIndexChanged(object sender, EventArgs e)
        {
            grainDataChange(cboGrain9);
        }
        private void grainDataChange(object sender)
        {
            //cboGrain1_SelectedIndexChanged
            try
            {
                conn.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = conn;
                string query = "select * from GRAINLOOKUP where Grain='" + cboGrain1.Text + "'";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    lblPPG1.Text = reader["PPG"].ToString();
                    lblAttn1.Text = reader["Basic Attenuation"].ToString();
                    lblAff1.Text = reader["Attenuation Affected by Mash Cond?"].ToString();
                    lblLov1.Text = reader["Lovibond"].ToString();
                    lblDP1.Text = reader["DP"].ToString();
                    //lblWA1.Text = reader["Absorption (ml/g)"].ToString();
                    waterAbsor[0] = reader["Absorption (ml/g)"].ToString();
                }
                conn.Close();
                if (cboGrain1 == null)
                { txtGrainWT1.Text = grainWt[0].ToString("0"); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
            //cboGrain2_SelectedIndexChanged
            try
            {
                conn.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = conn;
                string query = "select * from GRAINLOOKUP where Grain='" + cboGrain2.Text + "'";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    lblPPG2.Text = reader["PPG"].ToString();
                    lblAttn2.Text = reader["Basic Attenuation"].ToString();
                    lblAff2.Text = reader["Attenuation Affected by Mash Cond?"].ToString();
                    lblLov2.Text = reader["Lovibond"].ToString();
                    lblDP2.Text = reader["DP"].ToString();
                    //lblWA2.Text = reader["Absorption (ml/g)"].ToString();
                    waterAbsor[1] = reader["Absorption (ml/g)"].ToString();
                }
                conn.Close();
                if (cboGrain2 == null)
                { txtGrainWT2.Text = grainWt[1].ToString("0"); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
            //cboGrain3_SelectedIndexChanged
            try
            {
                conn.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = conn;
                string query = "select * from GRAINLOOKUP where Grain='" + cboGrain3.Text + "'";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    lblPPG3.Text = reader["PPG"].ToString();
                    lblAttn3.Text = reader["Basic Attenuation"].ToString();
                    lblAff3.Text = reader["Attenuation Affected by Mash Cond?"].ToString();
                    lblLov3.Text = reader["Lovibond"].ToString();
                    lblDP3.Text = reader["DP"].ToString();
                    //lblWA3.Text = reader["Absorption (ml/g)"].ToString();
                    waterAbsor[2] = reader["Absorption (ml/g)"].ToString();
                }
                conn.Close();
                if (cboGrain3 == null)
                { txtGrainWT3.Text = grainWt[2].ToString(" "); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
            //cboGrain4_SelectedIndexChanged
            try
            {
                conn.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = conn;
                string query = "select * from GRAINLOOKUP where Grain='" + cboGrain4.Text + "'";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    lblPPG4.Text = reader["PPG"].ToString();
                    lblAttn4.Text = reader["Basic Attenuation"].ToString();
                    lblAff4.Text = reader["Attenuation Affected by Mash Cond?"].ToString();
                    lblLov4.Text = reader["Lovibond"].ToString();
                    lblDP4.Text = reader["DP"].ToString();
                    //lblWA4.Text = reader["Absorption (ml/g)"].ToString();
                    waterAbsor[3] = reader["Absorption (ml/g)"].ToString();
                }
                conn.Close();
                if (cboGrain4 == null)
                {
                    txtGrainWT4.Text = grainWt[3].ToString(" ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
            //cboGrain5_SelectedIndexChanged
            try
            {
                conn.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = conn;
                string query = "select * from GRAINLOOKUP where Grain='" + cboGrain5.Text + "'";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    lblPPG5.Text = reader["PPG"].ToString();
                    lblAttn5.Text = reader["Basic Attenuation"].ToString();
                    lblAff5.Text = reader["Attenuation Affected by Mash Cond?"].ToString();
                    lblLov5.Text = reader["Lovibond"].ToString();
                    lblDP5.Text = reader["DP"].ToString();
                    //lblWA5.Text = reader["Absorption (ml/g)"].ToString();
                    waterAbsor[4] = reader["Absorption (ml/g)"].ToString();
                }
                conn.Close();
                if (cboGrain5 == null)
                { txtGrainWT5.Text = grainWt[4].ToString("0"); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
            //cboGrain6_SelectedIndexChanged
            try
            {
                conn.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = conn;
                string query = "select * from GRAINLOOKUP where Grain='" + cboGrain6.Text + "'";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    lblPPG6.Text = reader["PPG"].ToString();
                    lblAttn6.Text = reader["Basic Attenuation"].ToString();
                    lblAff6.Text = reader["Attenuation Affected by Mash Cond?"].ToString();
                    lblLov6.Text = reader["Lovibond"].ToString();
                    lblDP6.Text = reader["DP"].ToString();
                    //lblWA6.Text = reader["Absorption (ml/g)"].ToString();
                    waterAbsor[5] = reader["Absorption (ml/g)"].ToString();
                }
                conn.Close();
                if (cboGrain6 == null)
                { txtGrainWT6.Text = grainWt[5].ToString("0"); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
            //cboGrain7_SelectedIndexChanged
            try
            {
                conn.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = conn;
                string query = "select * from GRAINLOOKUP where Grain='" + cboGrain7.Text + "'";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    lblPPG7.Text = reader["PPG"].ToString();
                    lblAttn7.Text = reader["Basic Attenuation"].ToString();
                    lblAff7.Text = reader["Attenuation Affected by Mash Cond?"].ToString();
                    lblLov7.Text = reader["Lovibond"].ToString();
                    lblDP7.Text = reader["DP"].ToString();
                    //lblWA7.Text = reader["Absorption (ml/g)"].ToString();
                    waterAbsor[6] = reader["Absorption (ml/g)"].ToString();
                }
                conn.Close();
                if (cboGrain7 == null)
                { txtGrainWT7.Text = grainWt[6].ToString("0"); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
            //cboGrain8_SelectedIndexChanged
            try
            {
                conn.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = conn;
                string query = "select * from GRAINLOOKUP where Grain='" + cboGrain8.Text + "'";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    lblPPG8.Text = reader["PPG"].ToString();
                    lblAttn8.Text = reader["Basic Attenuation"].ToString();
                    lblAff8.Text = reader["Attenuation Affected by Mash Cond?"].ToString();
                    lblLov8.Text = reader["Lovibond"].ToString();
                    lblDP8.Text = reader["DP"].ToString();
                   // lblWA8.Text = reader["Absorption (ml/g)"].ToString();
                    waterAbsor[7] = reader["Absorption (ml/g)"].ToString();
                }
                conn.Close();
                if (cboGrain8 == null)
                { txtGrainWT8.Text = grainWt[7].ToString("0"); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
            //cboGrain9_SelectedIndexChanged
            try
            {
                conn.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = conn;
                string query = "select * from GRAINLOOKUP where Grain='" + cboGrain9.Text + "'";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    lblPPG9.Text = reader["PPG"].ToString();
                    lblAttn9.Text = reader["Basic Attenuation"].ToString();
                    lblAff9.Text = reader["Attenuation Affected by Mash Cond?"].ToString();
                    lblLov9.Text = reader["Lovibond"].ToString();
                    lblDP9.Text = reader["DP"].ToString();
                    lblWA9.Text = reader["Absorption (ml/g)"].ToString();
                    waterAbsor[8] = reader["Absorption (ml/g)"].ToString();
                }
                conn.Close();
                if (cboGrain9 == null)
                { txtGrainWT9.Text = grainWt[8].ToString("0"); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();

            }
        }
        private void finalCalculations(object sender)
        {
            lblOGTotal.Text = (OGCon.Sum() + 1).ToString("N3");
            lblFGTotal.Text = (FGCon.Sum() + 1).ToString("N3");
            lblSRMTotal.Text = contribution.Sum().ToString("N0");
            lblABVTotal.Text = ((OGCon.Sum() - FGCon.Sum()) * 1.3125).ToString("P1");

        }
        private void grainWt0(object sender)
        {
            try
            {
                if (cboGrain1 != null)
                {
                    grainWt[0] = double.Parse(txtGrainWT1.Text);
                    if (grainWt[0] > 0)
                    {
                        percentChange(percent[0]);

                        Lbs[0] = grainWt[0] / 453.59237;
                        lblLbGrain1.Text = Lbs[0].ToString("N2");

                        if (Lbs[0] >= .01)
                        {
                            PPG[0] = double.Parse(lblPPG1.Text);
                            points[0] = PPG[0] * Lbs[0];
                            lblPoi1.Text = points[0].ToString("N1");
                        }
                        if (grainWt[0] >= .01)
                        {
                            Attn[0] = double.Parse(lblAttn1.Text);
                            ferment[0] = (Attn[0] / .83) * (points[0] / points.Sum());
                            lblFer1.Text = ferment[0].ToString("N1");
                        }
                        else
                        {
                            lblFer1.Text = "0.0";
                        }
                        if (grainWt[0] >= .01)
                        {
                            waterAb[0] = double.Parse(waterAbsor[0]);
                            lblwaterAB[0] = waterAb[0] * grainWt[0];
                            lblWA1.Text = lblwaterAB[0].ToString();
                        }
                    }
                }
                else
                {
                }
                srmContribution(cboGrain1);
                originalGravityChange(cboGrain1);
                finalGravityChange(cboGrain1);
                watervolume(cboGrain1);
                finalCalculations(cboGrain1);
            }
            catch (Exception)
            {
            }
        }
        private void grainWt1(object sender)
        {
            try
            {
                if (cboGrain2 != null)
                {
                    grainWt[1] = double.Parse(txtGrainWT2.Text);
                    if (grainWt[1] > 0.01)
                    {
                        percentChange(percent[1]);

                        Lbs[1] = grainWt[1] / 453.59237;
                        lblLbGrain2.Text = Lbs[1].ToString("N2");

                        if (Lbs[1] >= .01)
                        {
                            PPG[1] = double.Parse(lblPPG2.Text);
                            points[1] = PPG[1] * Lbs[1];
                            lblPoi2.Text = points[1].ToString("N1");
                        }
                        if (grainWt[1] >= .01)
                        {
                            Attn[1] = double.Parse(lblAttn2.Text);
                            ferment[1] = (Attn[1] / .83) * (points[1] / points.Sum());
                            lblFer2.Text = ferment[1].ToString("N1");
                        }
                        else
                        {
                            lblFer2.Text = "0.0";
                        }
                        if (grainWt[1] >= .01)
                        {
                            waterAb[1] = double.Parse(waterAbsor[1]);
                            lblwaterAB[1] = waterAb[1] * grainWt[1];
                            lblWA2.Text = lblwaterAB[1].ToString();
                        }
                    }
                }
                else
                {
                }
                srmContribution(cboGrain2);
                originalGravityChange(cboGrain2);
                finalGravityChange(cboGrain2);
                finalCalculations(cboGrain2);
            }

            catch (Exception)
            {
                MessageBox.Show("second Change Box Catch");

            }

        }
        private void grainWt2(object sender)
        {
            try
            {
                if (cboGrain2 != null)
                {
                    grainWt[2] = double.Parse(txtGrainWT3.Text);
                    if (grainWt[2] > 0.01)

                    {
                        percentChange(percent[2]);

                        Lbs[2] = grainWt[2] / 453.59237;
                        lblLbGrain3.Text = Lbs[2].ToString("N2");

                        if (Lbs[2] >= .01)
                        {
                            PPG[2] = double.Parse(lblPPG3.Text);
                            points[2] = PPG[2] * Lbs[2];
                            lblPoi3.Text = points[2].ToString("N1");
                        }
                        if (grainWt[2] >= .01)
                        {
                            Attn[2] = double.Parse(lblAttn3.Text);
                            ferment[2] = (Attn[2] / .83) * (points[2] / points.Sum());
                            lblFer3.Text = ferment[2].ToString("N1");
                        }
                        else
                        {
                            lblFer3.Text = "0.0";
                        }
                        if (grainWt[2] >= .01)
                        {
                            waterAb[2] = double.Parse(waterAbsor[2]);
                            lblwaterAB[2] = waterAb[2] * grainWt[2];
                            lblWA3.Text = lblwaterAB[2].ToString();
                        }
                        originalGravityChange(cboGrain3);
                        finalGravityChange(cboGrain3);

                    }
                }
                else
                {
                }
                srmContribution(cboGrain3);
                finalCalculations(cboGrain3);
            }
            catch (Exception)
            {
                MessageBox.Show("Third Change Box Catch");
            }
        }
        private void grainWt3(object sender)
        {
            try
            {
                if (cboGrain3 != null)
                {
                    grainWt[3] = double.Parse(txtGrainWT4.Text);
                    if (grainWt[3] > 0.01)
                    {
                        percentChange(percent[3]);

                        Lbs[3] = grainWt[3] / 453.59237;
                        lblLbGrain4.Text = Lbs[3].ToString("N2");

                        if (Lbs[3] >= .01)
                        {
                            PPG[3] = double.Parse(lblPPG4.Text);
                            points[3] = PPG[3] * Lbs[3];
                            lblPoi4.Text = points[3].ToString("N1");
                        }
                        if (grainWt[3] >= .01)
                        {
                            Attn[3] = double.Parse(lblAttn4.Text);
                            ferment[3] = (Attn[3] / .83) * (points[3] / points.Sum());
                            lblFer4.Text = ferment[3].ToString("N1");
                        }
                        else
                        {
                            lblFer4.Text = "0.0";
                        }
                        if (grainWt[3] >= .01)
                        {
                            waterAb[3] = double.Parse(waterAbsor[3]);
                            lblwaterAB[3] = waterAb[3] * grainWt[3];
                            lblWA4.Text = lblwaterAB[3].ToString();
                        }
                        originalGravityChange(cboGrain4);
                        finalGravityChange(cboGrain4);

                    }
                }
                else
                {
                }
                srmContribution(cboGrain4);
                finalCalculations(cboGrain4);
            }
            catch (Exception)
            {
                MessageBox.Show("? Change Box Catch");
            }

        }
        private void grainWt4(object sender)
        {
            try
            {
                if (cboGrain4 != null)
                {
                    grainWt[4] = double.Parse(txtGrainWT5.Text);
                    if (grainWt[4] > 0.01)
                    {
                        percentChange(percent[4]);

                        Lbs[4] = grainWt[4] / 453.59237;
                        lblLbGrain5.Text = Lbs[4].ToString("N2");

                        if (Lbs[4] >= .01)
                        {
                            PPG[4] = double.Parse(lblPPG5.Text);
                            points[4] = PPG[4] * Lbs[4];
                            lblPoi5.Text = points[4].ToString("N1");
                        }
                        if (grainWt[4] >= .01)
                        {
                            Attn[4] = double.Parse(lblAttn5.Text);
                            ferment[4] = (Attn[4] / .83) * (points[4] / points.Sum());
                            lblFer5.Text = ferment[4].ToString("N1");
                        }
                        else
                        {
                            lblFer5.Text = "0.0";
                        }
                        if (grainWt[4] >= .01)
                        {
                            waterAb[4] = double.Parse(waterAbsor[4]);
                            lblwaterAB[4] = waterAb[4] * grainWt[4];
                            lblWA5.Text = lblwaterAB[4].ToString();
                        }
                        originalGravityChange(cboGrain5);
                        finalGravityChange(cboGrain5);
                    }
                }
                else
                {
                }
                srmContribution(cboGrain5);
                finalCalculations(cboGrain5);
            }
            catch (Exception)
            {
                MessageBox.Show("Fourth-a Change Box Catch");
            }
        }
        private void grainWt5(object sender)
        {
            try
            {
                if (cboGrain5 != null)
                {
                    grainWt[5] = double.Parse(txtGrainWT6.Text);
                    if (grainWt[5] > 0.01)
                    {
                        percentChange(percent[5]);

                        Lbs[5] = grainWt[5] / 453.59237;
                        lblLbGrain6.Text = Lbs[5].ToString("N2");

                        if (Lbs[5] >= .01)
                        {
                            PPG[5] = double.Parse(lblPPG6.Text);
                            points[5] = PPG[5] * Lbs[5];
                            lblPoi6.Text = points[5].ToString("N1");
                        }
                        if (grainWt[5] >= .01)
                        {
                            Attn[5] = double.Parse(lblAttn6.Text);
                            ferment[5] = (Attn[5] / .83) * (points[5] / points.Sum());
                            lblFer6.Text = ferment[5].ToString("N1");
                        }
                        else
                        {
                            lblFer6.Text = "0.0";
                        }
                        if (grainWt[5] >= .01)
                        {
                            waterAb[5] = double.Parse(waterAbsor[5]);
                            lblwaterAB[5] = waterAb[5] * grainWt[5];
                            lblWA6.Text = lblwaterAB[5].ToString();
                        }
                        originalGravityChange(cboGrain6);
                        finalGravityChange(cboGrain6);
                    }
                }
                else
                {
                }
                srmContribution(cboGrain6);
                finalCalculations(cboGrain6);
            }
            catch (Exception)
            {
                MessageBox.Show("Fifth Change Box Catch");
            }
        }
        private void grainWt6(object sender)
        {
            try
            {
                if (cboGrain6 != null)
                {
                    grainWt[6] = double.Parse(txtGrainWT7.Text);
                    if (grainWt[6] > 0.01)
                    {
                        percentChange(percent[6]);

                        Lbs[6] = grainWt[6] / 453.59237;
                        lblLbGrain7.Text = Lbs[6].ToString("N2");

                        if (Lbs[6] >= .01)
                        {
                            PPG[6] = double.Parse(lblPPG7.Text);
                            points[6] = PPG[6] * Lbs[6];
                            lblPoi7.Text = points[6].ToString("N1");
                        }
                        if (grainWt[6] >= .01)
                        {
                            Attn[6] = double.Parse(lblAttn7.Text);
                            ferment[6] = (Attn[6] / .83) * (points[6] / points.Sum());
                            lblFer7.Text = ferment[6].ToString("N1");
                        }
                        else
                        {
                            lblFer7.Text = "0.0";
                        }
                        if (grainWt[6] >= .01)
                        {
                            waterAb[6] = double.Parse(waterAbsor[6]);
                            lblwaterAB[6] = waterAb[6] * grainWt[6];
                            lblWA7.Text = lblwaterAB[6].ToString();
                        }
                        originalGravityChange(cboGrain7);
                        finalGravityChange(cboGrain7);
                    }
                }
                else
                {
                }
                srmContribution(cboGrain7);
                finalCalculations(cboGrain7);
            }
            catch (Exception)
            {
                MessageBox.Show("Sixth Change Box Catch");
            }
        }
        private void grainWt7(object sender)
        {
            try
            {
                if (cboGrain7 != null)
                {
                    grainWt[7] = double.Parse(txtGrainWT8.Text);
                    if (grainWt[7] > 0.01)
                    {
                        percentChange(percent[7]);

                        Lbs[7] = grainWt[7] / 453.59237;
                        lblLbGrain8.Text = Lbs[7].ToString("N2");

                        if (Lbs[7] >= .01)
                        {
                            PPG[7] = double.Parse(lblPPG8.Text);
                            points[7] = PPG[7] * Lbs[7];
                            lblPoi8.Text = points[7].ToString("N1");
                        }
                        if (grainWt[7] >= .01)
                        {
                            Attn[7] = double.Parse(lblAttn8.Text);
                            ferment[7] = (Attn[7] / .83) * (points[7] / points.Sum());
                            lblFer8.Text = ferment[7].ToString("N1");
                        }
                        else
                        {
                            lblFer8.Text = "0.0";
                        }
                        if (grainWt[7] >= .01)
                        {
                            waterAb[7] = double.Parse(waterAbsor[7]);
                            lblwaterAB[7] = waterAb[7] * grainWt[7];
                            lblWA8.Text = lblwaterAB[7].ToString();
                        }
                        originalGravityChange(cboGrain8);
                        finalGravityChange(cboGrain8);
                    }
                }
                else
                {
                }
                srmContribution(cboGrain8);
                finalCalculations(cboGrain8);
            }
            catch (Exception)
            {
                MessageBox.Show("Seventh Change Box Catch");
            }

        }
        private void grainWt8(object sender)
        {
            try
            {
                if (cboGrain8 != null)
                {
                    grainWt[8] = double.Parse(txtGrainWT9.Text);
                    if (grainWt[8] > 0.01)
                    {
                        percentChange(percent[8]);

                        Lbs[8] = grainWt[8] / 453.59237;
                        lblLbGrain9.Text = Lbs[8].ToString("N2");

                        if (Lbs[8] >= .01)
                        {
                            PPG[8] = double.Parse(lblPPG9.Text);
                            points[8] = PPG[8] * Lbs[8];
                            lblPoi9.Text = points[8].ToString("N1");
                        }
                        if (grainWt[8] >= .01)
                        {
                            Attn[8] = double.Parse(lblAttn9.Text);
                            ferment[8] = (Attn[8] / .83) * (points[8] / points.Sum());
                            lblFer9.Text = ferment[8].ToString("N1");
                        }
                        else
                        {
                            lblFer9.Text = "0.0";
                        }
                        srmContribution(cboGrain9);
                        if (grainWt[8] >= .01)
                        {
                            waterAb[8] = double.Parse(waterAbsor[8]);
                            lblwaterAB[8] = waterAb[8] * grainWt[8];
                            lblWA9.Text = lblwaterAB[8].ToString();
                        }
                        originalGravityChange(cboGrain9);
                        finalGravityChange(cboGrain9);
                    }
                }
                else
                {
                }
                finalCalculations(cboGrain9);
            }
            catch (Exception)
            {
                MessageBox.Show("Eigth Change Box Catch");
            }

        }
        private void txtGrainWT1_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                grainWt0(grainWt[0]);
                if (txtWaterVolume.Text.Length > 0)
                {
                    watervolume(txtWaterVolume);
                    originalGravityChange(txtWaterVolume);
                    finalGravityChange(txtWaterVolume);
                }
            }
            catch
            {
            }
        }
        private void txtGrainWT2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                grainWt1(grainWt[1]);
                if (txtWaterVolume.Text.Length > 0)
                {
                    watervolume(txtWaterVolume); originalGravityChange(txtWaterVolume);
                    finalGravityChange(txtWaterVolume);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Second Change Box Catch");
            }
        }
        private void txtGrainWT3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                grainWt2(grainWt[2]);
                if (txtWaterVolume.Text.Length > 0)
                {
                    watervolume(txtWaterVolume); originalGravityChange(txtWaterVolume);
                    finalGravityChange(txtWaterVolume);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("First Change Box Catch");
            }
        }

        private void txtGrainWT4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                grainWt3(grainWt[3]);
                if (txtWaterVolume.Text.Length > 0)
                {
                    watervolume(txtWaterVolume); originalGravityChange(txtWaterVolume);
                    finalGravityChange(txtWaterVolume);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("First Change Box Catch");
            }
        }
        private void txtGrainWT5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                grainWt4(grainWt[4]);
                if (txtWaterVolume.Text.Length > 0)
                {
                    watervolume(txtWaterVolume); originalGravityChange(txtWaterVolume);
                    finalGravityChange(txtWaterVolume);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("First Change Box Catch");
            }
        }

        private void txtGrainWT6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                grainWt5(grainWt[5]);
                if (txtWaterVolume.Text.Length > 0)
                {
                    watervolume(txtWaterVolume); originalGravityChange(txtWaterVolume);
                    finalGravityChange(txtWaterVolume);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("First Change Box Catch");
            }
        }

        private void txtGrainWT7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                grainWt6(grainWt[6]);
                if (txtWaterVolume.Text.Length > 0)
                {
                    watervolume(txtWaterVolume); originalGravityChange(txtWaterVolume);
                    finalGravityChange(txtWaterVolume);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("First Change Box Catch");
            }
        }
        private void txtGrainWT8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                grainWt7(grainWt[7]);
                if (txtWaterVolume.Text.Length > 0)
                {
                    watervolume(txtWaterVolume); originalGravityChange(txtWaterVolume);
                    finalGravityChange(txtWaterVolume);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("First Change Box Catch");
            }
        }
        private void txtGrainWT9_TextChanged(object sender, EventArgs e)
        {
            try
            {
                grainWt8(grainWt[8]);
                if (txtWaterVolume.Text.Length > 0)
                {
                    watervolume(txtWaterVolume); originalGravityChange(txtWaterVolume);
                    finalGravityChange(txtWaterVolume);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("First Change Box Catch");
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to start a new recipe?", "Reset Form", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //Clear the current form and start over
                frmRecipe NewForm = new frmRecipe();
                NewForm.Show();
                this.Dispose(false);
            }
            else if (dialogResult == DialogResult.No)
            {
                //Return to current form
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Close Button
            //this.Close();
            Application.Exit();
        }

        private void txtYeastFactor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtWaterVolume.Text.Length > 0)
                {
                    watervolume(txtWaterVolume);
                }
                if (txtGrainWT1.Text.Length > 0)
                {
                    grainWt0(grainWt[0]);
                }
                if (txtGrainWT2.Text.Length > 0)
                {
                    grainWt1(grainWt[1]);
                }
                if (txtGrainWT3.Text.Length > 0)
                {
                    grainWt2(grainWt[2]);
                }
                if (txtGrainWT4.Text.Length > 0)
                {
                    grainWt3(grainWt[3]);
                }
                if (txtGrainWT5.Text.Length > 0)
                {
                    grainWt4(grainWt[4]);
                }
                if (txtGrainWT6.Text.Length > 0)
                {
                    grainWt5(grainWt[5]);
                }
                if (txtGrainWT7.Text.Length > 0)
                {
                    grainWt6(grainWt[6]);
                }
                if (txtGrainWT8.Text.Length > 0)
                {
                    grainWt7(grainWt[7]);
                }
                if (txtGrainWT9.Text.Length > 0)
                {
                    grainWt8(grainWt[8]);
                }
            }
            catch (Exception) { }
        }
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Close Button
            //this.Close();
            Application.Exit();
        }
        private void aBVCalculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            calcABV ABVC = new calcABV();
            ABVC.Show();
        }
        private void txtWaterVolume_Leave(object sender, EventArgs e)
        {

            try
            {
                if (txtWaterVolume.Text.Length > 0)
                {
                    watervolume(txtWaterVolume);
                    hopDataChange(txtWaterVolume);
                    ibuCalculator(txtWaterVolume);

                }
                if (txtGrainWT1.Text.Length > 0)
                {
                    grainWt0(grainWt[0]);
                }
                if (txtGrainWT2.Text.Length > 0)
                {
                    grainWt1(grainWt[1]);
                }
                if (txtGrainWT3.Text.Length > 0)
                {
                    grainWt2(grainWt[2]);
                }
                if (txtGrainWT4.Text.Length > 0)
                {
                    grainWt3(grainWt[3]);
                }
                if (txtGrainWT5.Text.Length > 0)
                {
                    grainWt4(grainWt[4]);
                }
                if (txtGrainWT6.Text.Length > 0)
                {
                    grainWt5(grainWt[5]);
                }
                if (txtGrainWT7.Text.Length > 0)
                {
                    grainWt6(grainWt[6]);
                }
                if (txtGrainWT8.Text.Length > 0)
                {
                    grainWt7(grainWt[7]);
                }
                if (txtGrainWT9.Text.Length > 0)
                {
                    grainWt8(grainWt[8]);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Water Catch");
            }
        }
        private void cboHops1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = conn;
                string query = "select * from HOPLOOKUP where Hop='" + cboHops1.Text + "'";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    lblAAE1.Text = reader["Default Alpha Acid %"].ToString();
                }
                conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Hop1 ComboBox Change Catch");
                conn.Close();
            }
        }
        private void cboHops2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = conn;
                string query = "select * from HOPLOOKUP where Hop='" + cboHops2.Text + "'";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    lblAAE2.Text = reader["Default Alpha Acid %"].ToString();
                }
                conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Hop2 ComboBox Change Catch");
                conn.Close();
            }
        }
        private void cboHops3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = conn;
                string query = "select * from HOPLOOKUP where Hop='" + cboHops3.Text + "'";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    lblAAE3.Text = reader["Default Alpha Acid %"].ToString();
                }
                conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Hop3 ComboBox Change Catch");
                conn.Close();
            }
        }
        private void cboHops4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = conn;
                string query = "select * from HOPLOOKUP where Hop='" + cboHops4.Text + "'";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    lblAAE4.Text = reader["Default Alpha Acid %"].ToString();
                }
                conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Hop4 ComboBox Change Catch");
                conn.Close();
            }
        }
        private void cboHops5_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = conn;
                string query = "select * from HOPLOOKUP where Hop='" + cboHops5.Text + "'";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    lblAAE5.Text = reader["Default Alpha Acid %"].ToString();
                }
                conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Hop5 ComboBox Change Catch");
                conn.Close();
            }
        }
        private void cboHopMin1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            hopDataChange(cboHopMin1);
        }
        private void cboHopMin2_SelectedIndexChanged(object sender, EventArgs e)
        {
            hopDataChange(cboHopMin2);
        }

        private void cboHopMin3_SelectedIndexChanged(object sender, EventArgs e)
        {
            hopDataChange(cboHopMin3);
        }

        private void cboHopMin4_SelectedIndexChanged(object sender, EventArgs e)
        {
            hopDataChange(cboHopMin4);
        }

        private void cboHopMin5_SelectedIndexChanged(object sender, EventArgs e)
        {
            hopDataChange(cboHopMin5);
        }
        public void hopDataChange(object sender)
        {
            if (cboHopMin1 != null)
            {
                try
                {
                    conn.Open();
                    command = new OleDbCommand();
                    command.Connection = conn;
                    string query = "select * from HOPLOOKUP where Minutes='" + cboHopMin1.Text + "'";
                    command.CommandText = query;

                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        hoputilization[0] = reader["HOPUTILIZATION"].ToString();
                    }
                    conn.Close();
                    if (txtWaterVolume.Text.Length > 0)
                    {
                        try
                        {
                            if (txtHopAmt1.Text.Length > 0)
                            {
                                hopUtil[0] = double.Parse(hoputilization[0]);
                                ibuCalculator(IBU[0]);
                            }
                            else
                            {
                            }
                        }
                        catch (Exception)
                        {
                            // MessageBox.Show("IBU1 Calculator");
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(txtHopAmt1.Text))
                        {
                            lblIBU1.Text = " ";
                        }
                        else
                        {
                            lblIBU1.Text = "0";
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Hop1 minutes Change Catch");
                    conn.Close();
                }
            }
            else
            {
            }
            if (cboHopMin2 != null)
            {
                try
                {
                    conn.Open();
                    command = new OleDbCommand();
                    command.Connection = conn;
                    string query = "select * from HOPLOOKUP where Minutes='" + cboHopMin2.Text + "'";
                    command.CommandText = query;

                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        hoputilization[1] = reader["HOPUTILIZATION"].ToString();
                    }
                    conn.Close();
                    if (txtWaterVolume.Text.Length > 0)
                    {
                        try
                        {
                            if (txtHopAmt2.Text.Length > 0)
                            {
                                hopUtil[1] = double.Parse(hoputilization[1]);
                                ibuCalculator(IBU[1]);
                            }
                            else
                            {
                            }
                        }
                        catch (Exception)
                        {
                            // MessageBox.Show("IBU2 Calculator");
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(txtHopAmt2.Text))
                        {
                            lblIBU2.Text = " ";
                        }
                        else
                        {
                            lblIBU2.Text = "0";
                        }

                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Hop1 minutes Change Catch");
                    conn.Close();
                }
            }

            if (cboHopMin3 != null)
            {
                try
                {
                    conn.Open();
                    command = new OleDbCommand();
                    command.Connection = conn;
                    string query = "select * from HOPLOOKUP where Minutes='" + cboHopMin3.Text + "'";
                    command.CommandText = query;

                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        hoputilization[2] = reader["HOPUTILIZATION"].ToString();
                    }
                    conn.Close();
                    if (txtWaterVolume.Text.Length > 0)
                    {
                        try
                        {
                            if (txtHopAmt3.Text.Length > 0)
                            {
                                hopUtil[2] = double.Parse(hoputilization[2]);
                                ibuCalculator(IBU[2]);
                            }
                            else
                            {
                            }
                        }
                        catch (Exception)
                        {
                            //MessageBox.Show("IBU3 Calculator");
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(txtHopAmt3.Text))
                        {
                            lblIBU3.Text = " ";
                        }
                        else
                        {
                            lblIBU3.Text = "0";
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Hop3 minutes Change Catch");
                    conn.Close();
                }

                if (cboHopMin4 != null)
                    try
                    {
                        conn.Open();
                        command = new OleDbCommand();
                        command.Connection = conn;
                        string query = "select * from HOPLOOKUP where Minutes='" + cboHopMin4.Text + "'";
                        command.CommandText = query;

                        OleDbDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            hoputilization[3] = reader["HOPUTILIZATION"].ToString();
                        }
                        conn.Close();
                        if (txtWaterVolume.Text.Length > 0)
                        {
                            try
                            {
                                if (txtHopAmt4.Text.Length > 0)
                                {
                                    hopUtil[3] = double.Parse(hoputilization[3]);
                                    ibuCalculator(IBU[3]);
                                }
                                else
                                {
                                }
                            }
                            catch (Exception)
                            {
                                //MessageBox.Show("IBU4 Calculator");
                            }
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(txtHopAmt4.Text))
                            {
                                lblIBU4.Text = " ";
                            }
                            else
                            {
                                lblIBU4.Text = "0";
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Hop4 minutes Change Catch");
                        conn.Close();
                    }
                if (cboHopMin5 != null)
                {
                    try
                    {
                        conn.Open();
                        command = new OleDbCommand();
                        command.Connection = conn;
                        string query = "select * from HOPLOOKUP where Minutes='" + cboHopMin5.Text + "'";
                        command.CommandText = query;

                        OleDbDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            hoputilization[4] = reader["HOPUTILIZATION"].ToString();
                        }
                        conn.Close();
                        if (txtWaterVolume.Text.Length > 0)
                        {
                            try
                            {
                                if (txtHopAmt5.Text.Length > 0)
                                {
                                    hopUtil[4] = double.Parse(hoputilization[4]);
                                    ibuCalculator(IBU[4]);

                                }
                                else
                                {
                                }
                            }

                            catch (Exception)
                            {
                                //MessageBox.Show("IBU5 Calculator");
                            }
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(txtHopAmt5.Text))
                            {
                                lblIBU5.Text = " ";
                            }
                            else
                            {
                                lblIBU5.Text = "0";
                            }

                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Hop5 minutes Change Catch");
                        conn.Close();
                    }
                }
                else
                {
                }
            }
        }
        private void txtHopAmt1_TextChanged(object sender, EventArgs e)
        {
            changeHopData(txtHopAmt1);
        }

        private void txtHopAmt2_TextChanged(object sender, EventArgs e)
        {
            changeHopData(txtHopAmt2);
        }
        private void txtHopAmt3_TextChanged(object sender, EventArgs e)
        {
            changeHopData(txtHopAmt3);
        }

        private void txtHopAmt4_TextChanged(object sender, EventArgs e)
        {
            changeHopData(txtHopAmt4);
        }

        private void txtHopAmt5_TextChanged(object sender, EventArgs e)
        {
            changeHopData(txtHopAmt5);
        }
        private void changeHopData(object sender)
        {
            try
            {
                if (cboHops1 != null)
                {
                    hopAmount[0] = double.Parse(txtHopAmt1.Text);
                    if (hopAmount[0] != 0)
                    {
                    }
                    if (tHopAB > 0)
                    {
                        hopAB[0] = hopAmount[0] * tHopAB;
                        lblHopWA1.Text = hopAB[0].ToString("");
                    }
                    else
                    {
                        lblHopWA1.Text = "0";
                    }
                    watervolume(txtHopAmt1);
                    ibuCalculator(txtHopAmt1);
                }
            }
            catch { }
            try
            {
                if (cboHops2 != null)

                {
                    hopAmount[1] = double.Parse(txtHopAmt2.Text);
                    if (hopAmount[1] != 0)
                    {
                    }
                    if (tHopAB > 0)
                    {
                        hopAB[1] = hopAmount[1] * tHopAB;
                        lblHopWA2.Text = hopAB[1].ToString("");
                    }
                    else
                    {
                        lblHopWA2.Text = "0";
                    }
                    watervolume(txtHopAmt2);
                    ibuCalculator(txtHopAmt2);
                }
            }
            catch { }
            try
            {
                if (cboHops3 != null)
                {
                    hopAmount[2] = double.Parse(txtHopAmt3.Text);
                    if (hopAmount[2] != 0)
                    {
                    }
                    if (tHopAB > 0)
                    {
                        hopAB[2] = hopAmount[2] * tHopAB;
                        lblHopWA3.Text = hopAB[2].ToString("");
                    }
                    else
                    {
                        lblHopWA3.Text = "0";
                    }
                    watervolume(txtHopAmt3);
                    ibuCalculator(txtHopAmt3);
                }
            }
            catch { }
            try
            {
                if (cboHops4 != null)
                {
                    hopAmount[3] = double.Parse(txtHopAmt4.Text);
                    if (hopAmount[3] != 0)
                    {
                    }
                    if (tHopAB > 0)
                    {
                        hopAB[3] = hopAmount[3] * tHopAB;
                        lblHopWA4.Text = hopAB[3].ToString("");
                    }
                    else
                    {
                        lblHopWA4.Text = "0";
                    }
                    watervolume(txtHopAmt4);
                    ibuCalculator(txtHopAmt4);
                }
            }
            catch { }
            try
            {
                if (cboHops5 != null)
                {
                    hopAmount[4] = double.Parse(txtHopAmt5.Text);
                    if (hopAmount[4] != 0)
                    {
                    }
                    if (tHopAB > 0)
                    {
                        hopAB[4] = hopAmount[4] * tHopAB;
                        lblHopWA5.Text = hopAB[4].ToString("");
                    }
                    else
                    {
                        lblHopWA5.Text = "0";
                    }
                    watervolume(txtHopAmt5);
                    ibuCalculator(txtHopAmt5);
                }
            }
            catch { }
        }

        private void ibuCalculator(object sender)
        {
            //hop IBU1
            try
            {
                if (txtHopAmt1.Text.Length > 0)
                {
                    if (string.IsNullOrEmpty(txtAAA1.Text))
                    {
                        double waVolume = double.Parse(txtWaterVolume.Text);
                        double AAE1 = double.Parse(lblAAE1.Text);
                        IBU[0] = (hopUtil[0] * (AAE1 / 100) * hopAmount[0] * 1000) / (waVolume / 1000);
                        lblIBU1.Text = IBU[0].ToString("N2");
                    }
                    else
                    {
                        double waVolume = double.Parse(txtWaterVolume.Text);
                        double AAE1 = double.Parse(lblAAE1.Text);
                        double AAA1 = double.Parse(txtAAA1.Text);
                        IBU[0] = (hopUtil[0] * (AAA1 / 100) * hopAmount[0] * 1000) / (waVolume / 1000);
                        lblIBU1.Text = IBU[0].ToString("N2");
                    }
                    lblIBUTotal.Text = IBU.Sum().ToString("N0");
                }
                else { }
            }
            catch { }
            //hop IBU2
            try
            {
                if (txtHopAmt2.Text.Length > 0)
                {
                    if (string.IsNullOrEmpty(txtAAA2.Text))
                    {
                        double waVolume = double.Parse(txtWaterVolume.Text);
                        double AAE2 = double.Parse(lblAAE2.Text);
                        IBU[1] = (hopUtil[1] * (AAE2 / 100) * hopAmount[1] * 1000) / (waVolume / 1000);
                        lblIBU2.Text = IBU[1].ToString("N2");
                    }
                    else
                    {
                        double waVolume = double.Parse(txtWaterVolume.Text);
                        double AAE2 = double.Parse(lblAAE2.Text);
                        double AAA2 = double.Parse(txtAAA1.Text);
                        IBU[1] = (hopUtil[1] * (AAA2 / 100) * hopAmount[1] * 1000) / (waVolume / 1000);
                        lblIBU2.Text = IBU[1].ToString("N2");
                    }
                    lblIBUTotal.Text = IBU.Sum().ToString("N0");
                }
                else { }
            }
            catch { }
            //hop IBU3
            try
            {
                if (txtHopAmt3.Text.Length > 0)
                {
                    if (string.IsNullOrEmpty(txtAAA3.Text))
                    {
                        double waVolume = double.Parse(txtWaterVolume.Text);
                        double AAE3 = double.Parse(lblAAE3.Text);
                        IBU[2] = (hopUtil[2] * (AAE3 / 100) * hopAmount[2] * 1000) / (waVolume / 1000);
                        lblIBU3.Text = IBU[2].ToString("N2");
                    }
                    else
                    {
                        double waVolume = double.Parse(txtWaterVolume.Text);
                        double AAE3 = double.Parse(lblAAE3.Text);
                        double AAA3 = double.Parse(txtAAA3.Text);
                        IBU[2] = (hopUtil[2] * (AAA3 / 100) * hopAmount[2] * 1000) / (waVolume / 1000);
                        lblIBU3.Text = IBU[2].ToString("N2");
                    }
                    lblIBUTotal.Text = IBU.Sum().ToString("N0");
                }
                else { }
            }
            catch { }
            //hop IBU4
            try
            {
                if (txtHopAmt4.Text.Length > 0)
                {
                    if (string.IsNullOrEmpty(txtAAA4.Text))
                    {
                        double waVolume = double.Parse(txtWaterVolume.Text);
                        double AAE4 = double.Parse(lblAAE4.Text);
                        IBU[3] = (hopUtil[3] * (AAE4 / 100) * hopAmount[3] * 1000) / (waVolume / 1000);
                        lblIBU4.Text = IBU[3].ToString("N2");
                    }
                    else
                    {
                        double waVolume = double.Parse(txtWaterVolume.Text);
                        double AAE4 = double.Parse(lblAAE4.Text);
                        double AAA4 = double.Parse(txtAAA4.Text);
                        IBU[3] = (hopUtil[3] * (AAA4 / 100) * hopAmount[3] * 1000) / (waVolume / 1000);
                        lblIBU4.Text = IBU[3].ToString("N2");
                    }
                    lblIBUTotal.Text = IBU.Sum().ToString("N0");
                }
                else { }
            }
            catch { }
            //hop IBU5
            try
            {
                if (txtHopAmt5.Text.Length > 0)
                {
                    if (string.IsNullOrEmpty(txtAAA5.Text))
                    {
                        double waVolume = double.Parse(txtWaterVolume.Text);
                        double AAE5 = double.Parse(lblAAE5.Text);
                        IBU[4] = (hopUtil[4] * (AAE5 / 100) * hopAmount[4] * 1000) / (waVolume / 1000);
                        lblIBU5.Text = IBU[4].ToString("N2");
                    }
                    else
                    {
                        double waVolume = double.Parse(txtWaterVolume.Text);
                        double AAE5 = double.Parse(lblAAE5.Text);
                        double AAA5 = double.Parse(txtAAA5.Text);
                        IBU[4] = (hopUtil[4] * (AAA5 / 100) * hopAmount[4] * 1000) / (waVolume / 1000);
                        lblIBU5.Text = IBU[4].ToString("N2");
                    }
                    lblIBUTotal.Text = IBU.Sum().ToString("N0");
                }
                else { }
            }
            catch { }
        }
        private void txtAAA1_TextChanged(object sender, EventArgs e)
        {
            ibuCalculator(txtAAA1);
        }
        private void txtAAA2_TextChanged(object sender, EventArgs e)
        {
            ibuCalculator(txtAAA2);
        }
        private void txtAAA3_TextChanged(object sender, EventArgs e)
        {
            ibuCalculator(txtAAA3);
        }
        private void txtAAA4_TextChanged(object sender, EventArgs e)
        {
            ibuCalculator(txtAAA4);
        }
        private void txtAAA5_TextChanged(object sender, EventArgs e)
        {
            ibuCalculator(txtAAA5);
        }
        private void txtHopAB_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tHopAB = double.Parse(txtHopAB.Text);
                changeHopData(txtHopAB);
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtboxLBS != null)
                {
                    double lbs = double.Parse(txtboxLBS.Text);
                    double grams = lbs * 453.59237;
                    txtboxGrams.Text = grams.ToString("F0");
                }
                else { }
            }
            catch { }   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtboxOz != null)
                {
                    double Oz = double.Parse(txtboxOz.Text);
                    double grams2 = Oz * 28.34952;
                    txtboxGrams2.Text = grams2.ToString("F0");
                }
                else { }
            }
            catch { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtboxGal != null)
                {
                    double gal = double.Parse(txtboxGal.Text);
                    double mL = gal * 3785.411784;
                    txtboxmL.Text = mL.ToString("F0");
                }
                else { }
            }
            catch { }
        }

    }
}



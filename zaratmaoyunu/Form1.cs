namespace zaratmaoyunu
{
    public partial class Form1 : Form
    {
        int sayac = 0, i = 0, j = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int zar1 = rnd.Next(0, 6);
            int zar2 = rnd.Next(0, 6);
            pictureBox1.Image = ýmageList1.Images[zar1];
            pictureBox2.Image = ýmageList1.Images[zar2];
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            txtzar1.Text = (zar1 + 1).ToString();
            txtzar2.Text = (zar2 + 1).ToString();
            sayac++;
            if (sayac == 10)
            {
                timer1.Stop();
                btnzarat.Enabled = true;
                sayac = 0;

            }
        }

        private void btnzarat_Click(object sender, EventArgs e)
        {
            btnekle.Enabled = true;
            if ((i >= 5 && radioButton1.Checked) || (j >= 5 && radioButton2.Checked))
            {
                MessageBox.Show("Bu oyuncunun hakký bitti diger oyuncuya geçiniz.");
                
                btnekle.Enabled = false;
                return;
            }
            timer1.Start();
            btnzarat.Enabled = false;
            if (radioButton1.Checked)
                i++;
            else
                j++;
            
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                txtoyuncu1.Text=(Convert.ToInt16(txtoyuncu1.Text) + Convert.ToInt16(txtzar1.Text) + Convert.ToInt16(txtzar2.Text)).ToString();
                lst1.Items.Add( txtzar1.Text + "- " + txtzar2.Text);
            }
            else
            {
                txtoyuncu2.Text = (Convert.ToInt16(txtoyuncu2.Text) + Convert.ToInt16(txtzar1.Text) + Convert.ToInt16(txtzar2.Text)).ToString();
                lst2.Items.Add(txtzar1.Text + "- " + txtzar2.Text);
            }
            if (i >= 5 && j >= 5)
            {
                MessageBox.Show("Game Over!");
                btnzarat.Enabled = false;
                if (Convert.ToInt16(txtoyuncu1.Text) > Convert.ToInt16(txtoyuncu2.Text))
                {
                    MessageBox.Show("1. Oyuncu Kazandý.Skoru: " + txtoyuncu1.Text);
                }
                else if (Convert.ToInt16(txtoyuncu1.Text) < Convert.ToInt16(txtoyuncu2.Text))
                {
                    MessageBox.Show("2. Oyuncu Kazandý.Skoru: " + txtoyuncu2.Text);
                }
                else
                {
                    MessageBox.Show("Beraberlik");
                }

            }
            btnekle.Enabled = false;
        }
    }
}

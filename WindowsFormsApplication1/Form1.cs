using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        DateTime a, b, c, d, z, y, aaa, bbb, y1, ax, ccc, hrini;
        TimeSpan a1, b1, c1, d1, z1, aabb, y1y;
        int y2 = 0, waktu;
        String bulany, hariy, tahuny, tanggal = "", datab = "data(2).xml", tnow = "Padang";
        Boolean tampil = false, tray = false, tampil1 = false,aktivasi = false;

        System.Media.SoundPlayer azan = new System.Media.SoundPlayer("azan-mecca.wav");
        //
        //REMODELLING
        //
        void model()
        {
            var pos1 = this.PointToScreen(label1.Location);
            pos1 = pictureBox1.PointToClient(pos1);
            label1.Parent = pictureBox1;
            label1.Location = pos1;
            label1.BackColor = Color.Transparent;
            var pos2 = this.PointToScreen(label2.Location);
            pos2 = pictureBox1.PointToClient(pos2);
            label2.Parent = pictureBox1;
            label2.Location = pos2;
            label2.BackColor = Color.Transparent;
            var pos3 = this.PointToScreen(label3.Location);
            pos3 = pictureBox1.PointToClient(pos3);
            label3.Parent = pictureBox1;
            label3.Location = pos3;
            label3.BackColor = Color.Transparent;
            var pos4 = this.PointToScreen(label4.Location);
            pos4 = pictureBox1.PointToClient(pos4);
            label4.Parent = pictureBox1;
            label4.Location = pos4;
            label4.BackColor = Color.Transparent;
            var pos5 = this.PointToScreen(label5.Location);
            pos5 = pictureBox1.PointToClient(pos5);
            label5.Parent = pictureBox1;
            label5.Location = pos5;
            label5.BackColor = Color.Transparent;
            var pos6 = this.PointToScreen(label6.Location);
            pos6 = pictureBox1.PointToClient(pos6);
            label6.Parent = pictureBox1;
            label6.Location = pos6;
            label6.BackColor = Color.Transparent;
            var pos7 = this.PointToScreen(label7.Location);
            pos7 = pictureBox1.PointToClient(pos7);
            label7.Parent = pictureBox1;
            label7.Location = pos7;
            label7.BackColor = Color.Transparent;
            var pos8 = this.PointToScreen(label8.Location);
            pos8 = pictureBox1.PointToClient(pos8);
            label8.Parent = pictureBox1;
            label8.Location = pos8;
            label8.BackColor = Color.Transparent;
            var pos9 = this.PointToScreen(label9.Location);
            pos9 = pictureBox1.PointToClient(pos9);
            label9.Parent = pictureBox1;
            label9.Location = pos9;
            label9.BackColor = Color.Transparent;
            var pos10 = this.PointToScreen(label10.Location);
            pos10 = pictureBox1.PointToClient(pos10);
            label10.Parent = pictureBox1;
            label10.Location = pos10;
            label10.BackColor = Color.Transparent;
            var pos11 = this.PointToScreen(checkBox1.Location);
            pos11 = pictureBox1.PointToClient(pos11);
            checkBox1.Parent = pictureBox1;
            checkBox1.Location = pos11;
            checkBox1.BackColor = Color.Transparent;
            var pos12 = this.PointToScreen(pictureBox2.Location);
            pos12 = pictureBox1.PointToClient(pos12);
            pictureBox2.Parent = pictureBox1;
            pictureBox2.Location = pos12;
            pictureBox2.BackColor = Color.Transparent;
        }
        //
        //MAIN PROGRAM
        //
        public Form1()
        {
            hrini = DateTime.Today;
            waktu = 1000;
            InitializeComponent();
            model();
            gmt();
            StartTimer(); //jam terapkan pada text box
            
        }
        //
        //MODUL TIMER
        //
        Timer tmr = null;
        private void StartTimer() //function untuk pertukaran jam tiap detik optimized
        {
            tmr = new Timer();
            tmr.Interval = waktu;
            tmr.Tick += new EventHandler(tmr_Tick);
            tmr.Enabled = true;
        }
        //
        //PROCEDURE PROGRAM
        //
        private void tmr_Tick(object sender, EventArgs e) //main process
        {
            y = DateTime.Now;
            if ((hrini.ToString("MM/dd/yyyy") != tanggal) | (comboBox2.Text != tnow))
            {
                changet();
                pro();
                boxing();
            }
            if (aktivasi)
            {
                gmt();
            }
            hitung();
            timer();
            if (!tray)
            {
                if (y.ToString("MM/dd/yyyy") != hrini.ToString("MM/dd/yyyy"))
                {
                    hrini = DateTime.Today;
                    boxing();
                }
                boxing2nd();
            }
        }
        //
        //COMBO BOX GMT
        //
        private void gmt()
        {
            if (comboBox1.Text == "+7")
            {
                def7();
                aktivasi = false;
            }
            else if (comboBox1.Text == "+8")
                def8();
            else
                def9();
        }
        //DATATABLE ACCESS
        //
        void pro() //program to access XML data
        {
            XDocument db = XDocument.Load(datab);
            int dx = -1;
            var data = db.Descendants("data");
            var year = db.Descendants("year");
            var month = db.Descendants("month");
            var day = db.Descendants("date");
            var subuh = db.Descendants("fajr");
            var zuhur = db.Descendants("dzuhr");
            var ashar = db.Descendants("ashr");
            var magrib = db.Descendants("maghrib");
            var isya = db.Descendants("isha");
            foreach (var dax in data)
            {
                dx++;
            }
            for (int i = 1; i <= dx; i++)
            {
                if (year.ElementAt(i).Value.ToString() == y.ToString("yyyy"))
                {
                    if (month.ElementAt(i).Value.ToString() == y.ToString("MM"))
                    {
                        if (day.ElementAt(i).Value.ToString() == y.ToString("dd"))
                        {
                            tahuny = year.ElementAt(i).Value.ToString();
                            bulany = month.ElementAt(i).Value.ToString();
                            hariy = day.ElementAt(i).Value.ToString();
                            a = DateTime.Parse(subuh.ElementAt(i).Value.ToString());
                            ax = DateTime.Parse(subuh.ElementAt(i + 1).Value.ToString());
                            b = DateTime.Parse(zuhur.ElementAt(i).Value.ToString());
                            c = DateTime.Parse(ashar.ElementAt(i).Value.ToString());
                            d = DateTime.Parse(magrib.ElementAt(i).Value.ToString());
                            z = DateTime.Parse(isya.ElementAt(i).Value.ToString());
                            tanggal = (bulany + "/" + hariy + "/" + tahuny);
                        }
                    }
                }
            }
        }
        //
        //TIMING 7
        //
        public void def7() //default timing +7
        {
            aaa = Convert.ToDateTime("00:00:02");
            bbb = Convert.ToDateTime("00:00:01");
            ccc = Convert.ToDateTime("23:59:59");
            aabb = aaa - bbb;
            y1 = DateTime.Parse("06/18/15 12:00:00");
        }
        //
        //TIMING 8
        //
        private void def8() //timing +8
        {
            def7();
            y = y.AddHours(1);
        }
        //
        //TIMING 9
        //
        private void def9() //timing +9
        {
            def7();
            y = y.AddHours(2);
        }
        //
        //BOXING
        //
        private void boxing() //tampil text jadwal
        {
            textBox3.Text = a.ToString("HH:mm");
            textBox4.Text = b.ToString("HH:mm");
            textBox5.Text = c.ToString("HH:mm");
            textBox6.Text = d.ToString("HH:mm");
            textBox7.Text = z.ToString("HH:mm");
        }
        //
        //CALCULATE TIMER
        //
        void hitung() //hitung
        {
            a1 = a.Subtract(y);
            b1 = b.Subtract(y);
            c1 = c.Subtract(y);
            d1 = d.Subtract(y);
            z1 = z.Subtract(y);
            y1y = y1 - y;
            y2 = Convert.ToInt32(y1y.TotalDays);
        }
        //
        //BOXING NEXT
        //
        void boxing2nd() //tampil text di next
        {
            textBox1.Text = y.ToString("HH:mm:ss"); //jam terapkan pada text box
            textBox2.Text = y.ToString("dd MMMM yyyy");
            if (a1 > aabb)
            {
                textBox8.Text = "Subuh";
                textBox9.Text = a1.ToString(@"hh\:mm\:ss");
            }
            else if (b1 > aabb)
            {
                textBox8.Text = "Zuhur";
                textBox9.Text = b1.ToString(@"hh\:mm\:ss");
            }
            else if (c1 > aabb)
            {
                textBox8.Text = "Ashar";
                textBox9.Text = c1.ToString(@"hh\:mm\:ss");
            }
            else if (d1 > aabb)
            {
                textBox8.Text = "Magrib";
                textBox9.Text = d1.ToString(@"hh\:mm\:ss");
            }
            else if (z1 > aabb)
            {
                textBox8.Text = "Isya";
                textBox9.Text = z1.ToString(@"hh\:mm\:ss");
            }
            else
            {
                textBox8.Text = "Subuh";
                textBox9.Text = ((ccc.Subtract(y)) + (ax.Subtract(bbb))).ToString(@"hh\:mm\:ss");
            }
        }
        //
        //REMINDER AZAN
        //
        private void timer()
        {
            String remind = ("Waktu shalat telah masuk. Tinggalkanlah segala aktifitas dan bersegeralah menjawab panggilan Allah SWT.");
            if (Convert.ToInt32(a1.TotalSeconds) == Convert.ToInt32(aabb.TotalSeconds))
                tampil = true;
            else if (Convert.ToInt32(b1.TotalSeconds) == Convert.ToInt32(aabb.TotalSeconds))
                tampil = true;
            else if (Convert.ToInt32(c1.TotalSeconds) == Convert.ToInt32(aabb.TotalSeconds))
                tampil = true;
            else if (Convert.ToInt32(d1.TotalSeconds) == Convert.ToInt32(aabb.TotalSeconds))
                tampil = true;
            else if (Convert.ToInt32(z1.TotalSeconds) == Convert.ToInt32(aabb.TotalSeconds))
                tampil = true;

            if (Convert.ToInt32(a1.TotalSeconds) == 300)
                tampil1 = true;
            else if (Convert.ToInt32(b1.TotalSeconds) == 300)
                tampil1 = true;
            else if (Convert.ToInt32(c1.TotalSeconds) == 300)
                tampil1 = true;
            else if (Convert.ToInt32(d1.TotalSeconds) == 300)
                tampil1 = true;
            else if (Convert.ToInt32(z1.TotalSeconds) == 300)
                tampil1 = true;

            if (tampil)
            {
                if (checkBox1.Checked)
                {
                    azan.Play();
                }
                notifyIcon1.BalloonTipText = remind;
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                notifyIcon1.BalloonTipTitle = "Reminder";
                notifyIcon1.ShowBalloonTip(3000);
                tampil = false;
            }

            if (tampil1)
            {
                if (!tray)
                {
                    notifyIcon1.BalloonTipText = "5 menit menuju waktu shalat";
                    notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                    notifyIcon1.BalloonTipTitle = "Reminder";
                    notifyIcon1.ShowBalloonTip(3000);
                }
                tampil1 = false;
            }
        }
        //
        //MODUL RAMALAN
        //
        private void ramalanJodohToolStripMenuItem_Click(object sender, EventArgs e) 
        {
            Ramalanform ramalan = new Ramalanform();
            ramalan.Show();
        }
        //
        //Stop AZAN TRAY
        //
        private void stopAdzanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            azan.Stop();
        }
        //
        //STOP AZAN BUTTTON
        //
        private void button1_Click(object sender, EventArgs e)
        {
            azan.Stop();
        }
        //
        //EXIT FROM MENU
        //
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) //menu  exit
        {
            Application.Exit();
        }
        //
        //ABOUT FORM
        //
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) //file about
        {
            AboutForm about = new AboutForm();
            about.Show();
        }
        //
        //PROGRAM TRAY DOUBLE CLICK
        //
        private void notifyIcon1_DoubleClick(object sender, EventArgs e)//notify tray doubleclick
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            tray = false;
            aktivasi = true;
        }
        //
        //COMBO BOX GMT BERUBAH
        //
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            aktivasi = true;
        }
        //
        //TRAY MENU
        //
        private void showToolStripMenuItem1_Click(object sender, EventArgs e)//menu tray
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            tray = false;
            aktivasi = true;
        }
        //
        //EXIT FROM TRAY
        //
        private void exitToolStripMenuItem2_Click(object sender, EventArgs e)//exit app dari tray
        {
            Application.Exit();
        }
        //
        //PROGRAM TO TRAY BACKGROUND PROCESS
        //
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)//program close ke tray
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                notifyIcon1.Visible = true;
                this.Hide();
                e.Cancel = true;
                notifyIcon1.BalloonTipText = "Program telah berpindah ke tray";
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                notifyIcon1.BalloonTipTitle = "Info";
                notifyIcon1.ShowBalloonTip(3000);
                tray = true;
                aktivasi = true;
            }
        }
        //
        //CREDIT WINDOW
        //
        private void changeLogToolStripMenuItem_Click(object sender, EventArgs e)//credit messagebox
        {
            String x = ("Jadwal Shalat by Al-Fatih FTI UNAND v.1.2.0.0@"
                + "@@"
                + "Shalat Schedule source by PKPU (http://jadwalsholat.pkpu.or.id/)@"
                + "Background Picture by phaselda (http://instagram.com/phaselda)@"
                + "Program & design by Al-Fatih FTI UNAND@"
                + "Time schedule valid until end of 2016@"
                + "for Change Log please open Readme first!@");
            x = x.Replace("@", "" + System.Environment.NewLine);
            MessageBox.Show(x, "Credit");
        }
        //
        //REGION CHANGE
        //
        void changet()
        {
            if (Convert.ToInt32(y.ToString("yyyy")) == 2015)
            {
                if (comboBox2.Text == "Padang")
                {
                    tnow = "Padang";
                    datab = "DB2015/padang.xml";
                }
                else if (comboBox2.Text == "Batusangkar")
                {
                    tnow = "Batusangkar";
                    datab = "DB2015/batusangkar.xml";
                }
                else if (comboBox2.Text == "Bukittinggi")
                {
                    tnow = "Bukittinggi";
                    datab = "DB2015/bukittinggi.xml";
                }
                else if (comboBox2.Text == "PadangPanjang")
                {
                    tnow = "PadangPanjang";
                    datab = "DB2015/padangpanjang.xml";
                }
                else if (comboBox2.Text == "Painan")
                {
                    tnow = "Painan";
                    datab = "DB2015/painan.xml";
                }
                else if (comboBox2.Text == "Pariaman")
                {
                    tnow = "Pariaman";
                    datab = "DB2015/pariaman.xml";
                }
                else if (comboBox2.Text == "Payakumbuh")
                {
                    tnow = "Payakumbuh";
                    datab = "DB2015/payakumbuh.xml";
                }
                else if (comboBox2.Text == "Sawahlunto")
                {
                    tnow = "Sawahlunto";
                    datab = "DB2015/sawahlunto.xml";
                }
                else if (comboBox2.Text == "Solok")
                {
                    tnow = "Solok";
                    datab = "DB2015/solok.xml";
                }
            }
            else if (Convert.ToInt32(y.ToString("yyyy")) == 2016)
            {
                if (comboBox2.Text == "Padang")
                {
                    tnow = "Padang";
                    datab = "DB2016/padang.xml";
                }
                else if (comboBox2.Text == "Batusangkar")
                {
                    tnow = "Batusangkar";
                    datab = "DB2016/batusangkar.xml";
                }
                else if (comboBox2.Text == "Bukittinggi")
                {
                    tnow = "Bukittinggi";
                    datab = "DB2016/bukittinggi.xml";
                }
                else if (comboBox2.Text == "PadangPanjang")
                {
                    tnow = "PadangPanjang";
                    datab = "DB2016/padangpanjang.xml";
                }
                else if (comboBox2.Text == "Painan")
                {
                    tnow = "Painan";
                    datab = "DB2016/painan.xml";
                }
                else if (comboBox2.Text == "Pariaman")
                {
                    tnow = "Pariaman";
                    datab = "DB2016/pariaman.xml";
                }
                else if (comboBox2.Text == "Payakumbuh")
                {
                    tnow = "Payakumbuh";
                    datab = "DB2016/payakumbuh.xml";
                }
                else if (comboBox2.Text == "Sawahlunto")
                {
                    tnow = "Sawahlunto";
                    datab = "DB2016/sawahlunto.xml";
                }
                else if (comboBox2.Text == "Solok")
                {
                    tnow = "Solok";
                    datab = "DB2016/solok.xml";
                }
            }
        }
    }
    //
    //ABOUT
    //
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            init();
        }
    }
    //
    //RAMALAN
    //
    public partial class Ramalanform : Form
    {
        public Ramalanform()
        {
            Initial();
        }

        void laki2()
        {
            this.Close();
            String x = ("Ramalan untuk  anda :"
                + "@Insya Allah anda akan menikah"
                + "@jodoh anda adalah ..... perempuan"
                + "@dan menikah pada ..... suatu hari nanti"
                + "@penghasilan anda adalah ..... sekian"
                + "@anak anda ada ..... sekian"
                + "@anda diperkirakan akan mati pada ..... suatu hari nanti"
                + "@@Insya Allah ramalan ini 100% akurat dan terpercaya oke oke oke (y) :v :v :v");
            x = x.Replace("@", "" + System.Environment.NewLine);
            MessageBox.Show(x, "Hasil Ramalan");
        }

        void perempuan()
        {
            this.Close();
            String x = ("Ramalan untuk anda :"
                + "@Insya Allah anda akan menikah"
                + "@jodoh anda adalah ..... laki-laki"
                + "@dan menikah pada ..... suatu hari nanti"
                + "@penghasilan anda adalah ..... sekian"
                + "@anak anda ada ..... sekian"
                + "@anda diperkirakan akan mati pada ..... suatu hari nanti"
                + "@@Insya Allah ramalan ini 100% akurat dan terpercaya oke oke oke (y) :v :v :v");
            x = x.Replace("@", "" + System.Environment.NewLine);
            MessageBox.Show(x, "Hasil Ramalan");
        }

        private void button199_Click(object sender, EventArgs e)
        {
            laki2();
        }

        private void button299_Click(object sender, EventArgs e)
        {
            perempuan();
        }
    }
}



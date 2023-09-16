using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgacProje
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class dugum
        {
            public dugum sol;
            public dugum sag;
            public int deger;
            
        }               
        public dugum kok = null;        
        int dugumsayi = 0;
        public void ekle(int deger2)
        {
            dugum yeni = new dugum();           
            yeni.deger = Convert.ToInt32(textBox1.Text);           
            label1.Text = Convert.ToString(yeni.deger);
            yeni.deger = deger2;
            if (kok == null)
            {
                kok = yeni;
                
            }
            else
            {
               
                dugum koktut = kok;
                dugum ebeveyn;
                while (yeni.deger == deger2)
                {

                    ebeveyn = koktut;
                    if (deger2 < koktut.deger)
                    {
                        koktut = koktut.sol;
                        
                        if (koktut == null)
                        {
                            ebeveyn.sol = yeni;                            
                            return;                            
                        }                        
                    }
                    else
                    {
                        koktut = koktut.sag;                        
                        if (koktut == null)
                        {
                            ebeveyn.sag = yeni;                           
                            return;
                        }                       
                    }                    
                }
            }
        }
        /*public void uzunluk(dugum kok)
        {
            if (kok != null)
            {
                uzunluk(kok.sol);
                uzunluk(kok.sag);
            }
        }
        public void sil(int deger2)
        {
            dugum koktut = kok;
            dugum ebevyn = kok;
            
            while (koktut.deger != deger2)
            {
                ebevyn = koktut;
                if (deger2<koktut.deger)
                {
                    
                    koktut = koktut.sag;
                    
                }
                else
                {
                   
                    koktut = koktut.sag;
                }
                if ((koktut.sol==null)&&(koktut.sag == null))
                {
                    if (koktut==kok)
                    {
                        kok = null;
                    }                   
                    else
                    {
                        ebevyn.sag = null;
                    }
                }
                else if (koktut.sag==null)
                {
                    if (koktut==kok)
                    {
                        kok = koktut.sol;
                    }
                   
                    else
                    {
                        ebevyn.sag = koktut.sag;
                    }
                }
                else if (koktut.sol == null)
                {
                    if (koktut==kok)
                    {
                        kok = koktut.sag;
                    }                   
                    else
                    {
                        ebevyn.sag = koktut.sag;
                    }
                }
            }
            
        } */
       
    public void bul(int deger2,dugum kok)
        {         
                     
            if ((deger2< kok.deger) && (kok.sol !=null))
            {
                bul(deger2, kok.sol);
            }
            
            else if ((deger2 > kok.deger) && (kok.sag != null))
            {
                bul(deger2, kok.sag);
            }
            else if(deger2 == kok.deger)
            {
                textBox4.Text = "Düğüm Bulundu : " +deger2;                
            }
            else
            {
                textBox4.Text = "Düğüm Ağaç Yapısında Bulunamadı!";
            }
        }       
        public void Inorder(dugum kok)
        {
            if (kok != null)
            {
                Inorder(kok.sol);                
                textBox6.Text += (kok.deger + " ");
                Inorder(kok.sag);
            }
        }
        public void Postorder(dugum kok)
        {
            if (kok != null)
            {
                Postorder(kok.sol);
                Postorder(kok.sag);                
                textBox7.Text += (kok.deger + " ");
            }
        }
        public void Preorder(dugum kok)
        {
            if (kok != null)
            {
                textBox5.Text += (kok.deger + " ");
                Preorder(kok.sol);
                Preorder(kok.sag);
            }
        }
        public void yazdir(dugum kok)
        {
          
            if (kok!=null)
            {
               
                textBox4.Text += kok.deger+ "\r\n";
                yazdir(kok.sol);
                yazdir(kok.sag);               
            }            
           
        }
        public void yaprakbul(int deger)
        {
            dugum yeni = new dugum();
            yeni.deger = Convert.ToInt32(textBox1.Text);
            yeni.deger = deger;
            if ((kok.sag == null) && (kok.sol == null))
                {
               
                textBox10.Text += deger;                    
                }            
        }

        private void button1_Click(object sender, EventArgs e)  //ekle buton
        {
            dugum yeni = new dugum();                      
            yeni.deger = Convert.ToInt32(textBox1.Text);
            ekle(yeni.deger);
            dugumsayi += 1;
        }
        private void button2_Click(object sender, EventArgs e)  //sil buton
        {
            dugum yeni = new dugum();
            yeni.deger = Convert.ToInt32(textBox2.Text);
            //sil(yeni.deger);
        }

        private void button3_Click(object sender, EventArgs e)  //bul buton
        {
            dugum yeni = new dugum();
            yeni.deger = Convert.ToInt32(textBox3.Text);
            bul(yeni.deger,kok);
        }

        private void button4_Click(object sender, EventArgs e)  //ağaçtaki düğümleri göster buton
        {
           
           yazdir(kok);
        }
       
        private void button5_Click(object sender, EventArgs e)  //ağaç bilgilerini göster btuon
        {
            dugum yeni = new dugum();
            yeni.deger = Convert.ToInt32(textBox1.Text);
            Preorder(kok);
            Inorder(kok);         
            Postorder(kok);
            yaprakbul(yeni.deger);
            textBox8.Text = Convert.ToString(dugumsayi);
        }
    }
}



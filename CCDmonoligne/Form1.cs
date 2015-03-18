/* {TivaUno is a freeware program to read CCD monoline camera. 
 * TivaUno can trace a spectro graphic and image.
 * It is programming whith C#.NET framework 4.0}
    Copyright (C) {mars 2015}  {Jean Brunet}

    This program is free software; you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation; either version 2 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License along
    with this program; if not, write to the Free Software Foundation, Inc.,
    51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.

mail to : johnbrunet@orange.fr*/



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;


struct Header_image
{
    // header FIT
    public string simple;
    public string bitpix;
    public string naxis;
    public string naxis1;
    public string naxis2;
    public string bzero;
    public string bscale;
    public string bin1;
    public string bin2;
    public string dateobs;
    public string dateend;
    public string exptime;
    public string swcreate;


    public string save()
    {
        // construction du header FIT
        string ret;
        ret = "SIMPLE  =" + simple + "BITPIX  =" + bitpix + "NAXIS   =" + naxis + "NAXIS1  =" + naxis1 + "NAXIS2  =" + naxis2 + "BZERO   =" + bzero;
        ret += "BSCALE  =" + bscale + "BIN1    =" + bin1 + "BIN2    =" + bin2 + "DATE-OBS=" + dateobs + "DATE-END=" + dateend + "EXPTIME =" + exptime + "SWCREATE=" + swcreate + "END" + new string(' ', 77); // + 77 espaces

        return ret;
    }
}

namespace CCDmonoligne
{
    public partial class Form1 : Form
    {
 
        int version = 1;
        String RxString="";
        String DteHeure = "";
        String DiscString="";
        UInt32[] valuememo = new UInt32[2048];
        UInt32[] valueRef = new UInt32[2048];
        UInt32[,] valueCCDi = new UInt32[20, 2048];
        UInt32[] valuelmage = new UInt32[2048];
        bool flagcom = false;
        bool seizebits = false;
        bool seizebitsref = false;
        bool flagimage = false;
        bool flagmultiple = true;
        int nbreimage = 0;
        Bitmap graduations;

        int X,Xpos1,Xpos2;    
        double A_pix;
        double rapPix;
        double rapAng;
        double memo;
        int premtr;
        string dirsave = "", diropen="";
        string repMesDocuments;
        Header_image ima = new Header_image();
        List<UInt32[]> image = new List<UInt32[]>();
        List<string> header = new List<string>();

        public enum ByteOrder : int
        {
            LittleEndian,
            BigEndian
        }
 
        public Form1()
        {
            InitializeComponent();
        }
  
        private void Bquitter_Click(object sender, EventArgs e)
        {
            // program end. save configuration
            System.IO.StreamWriter sav = new System.IO.StreamWriter(repMesDocuments +"config.ini");
            sav.WriteLine(diropen);
            sav.WriteLine(dirsave);
            sav.WriteLine(A_pix.ToString());
            sav.WriteLine(memo.ToString());
            sav.Dispose();
            this.Close();
        }

        private void Bpose_Click(object sender, EventArgs e)
        {
            // lecture des champs et envoi en hexa selon le format 8,16,16,16,8,FF en final
            string com;
            int temps;
         //   Thread c = new Thread(boucleI);
                com = "02";  
                temps = Convert.ToInt32(Ttempspose.Text);
                com = com + temps.ToString("X4") + "FF";
                Cursor.Current = Cursors.WaitCursor;                
                nbreimage = Convert.ToInt32(tmult.Text);
                image.Clear();
                header.Clear();
                flagmultiple = true;
               for(int i =0;i<nbreimage;i++)
               {
                   if (serialPort1.IsOpen)
                   {
                       flagcom = false;
                       DteHeure = returnDateTime();
                       serialPort1.WriteLine(com);
                       seizebits = false;

                       // Sauvegarde au fur et à mesure dans un list puis ouverture d'une fenêtre de sauvegarde. Message...
                      // revoir avec thread
                     // c.Start();
                       do
                       {
                           Application.DoEvents();
                           if (flagcom == true) 
                               break;
                         // attente du retour image
                       } while (true);
                    // c.Abort();
                   }
                 
              }
            
        }
  /*  public void boucleI()
    {
        while (flagcom == false)
        {                        
            // attente du retour image
        } ;
        
    }*/

   private void Print()
  {
    //  MessageBox.Show("print");
      //  lit les 2048 pixels envoyés formatés en hexa 4 bytes
       // read 2048 pixels for hexa bytes formated
      String ima = "", nbits = "", vue = "", tp = ""; 
      RxString += serialPort1.ReadExisting();

      int c1 = RxString.IndexOf( 'L',0);  // L si pose sur 12 bits. letter L if 12 bits trame
      if (c1 == -1)
      {
          c1 = RxString.IndexOf('C', 0); // C si pose sur 16 bits. letter C if 16 bits trame
      }

      int c2 = RxString.IndexOf('Z', 0);  // fin de trame. letter Z is end of trame
      
      if ((c2!=-1 && c1!=-1) && (c2 > c1))  // erreur sur le nombre d'envoi de chaque vue est trop court. tTest error
      {
          // découpe de la chaine. Chain cut
          ima = RxString.Substring(c1 + 1, c2- c1 -1);
          RxString = "";
           // découpe de la chaine par 4 octets

          if (ima.Length == 2048 * 4)  // teste si la trame a la bonne longueur. long trame test
          {
              
              if(seizebits == false)
              {
                  nbits = "12";
              }
              else
              {
                  nbits = "16";
              }

              if (nbreimage>1)
              {
                  vue = " vues en mémoire";
              }
              else
              {
                  vue = " vue en mémoire";
              }
              if (flagmultiple == false)
              {
                   image.Clear();
              }
              //-----------------
              header.Add(DteHeure + ",2048,1," + nbits + "," + Ttempspose.Text);
              int j = 0;
              for (int i = 0; i < 2048 * 4; i = i + 4) // les 2048 pixels sont lus en 16 bits
              {
                  tp = ima.Substring(i, 4);
                  if (tp != "")
                  {
                      valuelmage[j] = Convert.ToUInt32(tp, 16);
                  }
                  else
                  {
                      valuelmage[j] = 0;
                  }
                  j++;
              }
              image.Add(valuelmage);
              tracegraph(true);
 
              lvues.Text = image.Count.ToString() + vue;
              lvues.Visible = true;
              flagcom = true;
          }
          else
          {
            // MessageBox.Show("Trame erreur : " + ima.Length );
          }
      }
     Cursor.Current = Cursors.Arrow;
  }


    private void traceref()
   {
       int div;
       // récupération de l'image et tracé de la courbe de référence. reference curve track
       if (Hgraph.Image == null)
       {
           return;
        }
       int i,j=0,col, memocol;
       int basey = 532;

       System.Drawing.Graphics formGraphics;
       System.Drawing.Pen myPenGreen = new System.Drawing.Pen(System.Drawing.Color.Green);
      Bitmap graphique;
      graphique = (Bitmap)Hgraph.Image;

       formGraphics = Graphics.FromImage(graphique);  // création d'une surface de dessin
 
       if (seizebitsref == false) // réduction de la valeur maxi pour affichage sur 512 pixels
       {
           div = 8;
       }
       else
       {
           div = 128;  // pour niveau graphique 512 maxi donne 512
       }
       memocol = Convert.ToInt32(valueRef[0] / div);  // selon 10 bits ou 16 bits
       // selon sens de l'image. According sense of image
       if (checkinverse.Checked == false)
       {
           for (i = 0; i < valueRef.Length; i++)
           {
               col = Convert.ToInt32(valueRef[i] / div);
               if (col < 0)
               {
                   col = 0;
               }
               formGraphics.DrawLine(myPenGreen, 34 + i, basey - memocol - 1, 34 + i + 1, basey - col - 1); //
               memocol = col;
           }

       }
       else
       {
           // inversion gauche - droite de l'image. invert image
           for (i = valueRef.Length-1; i > -1; i--)
           {
               col = Convert.ToInt32(valueRef[i] / div);
               if (col < 0)
               {
                   col = 0;
               }
               formGraphics.DrawLine(myPenGreen, 34 + j, basey - memocol - 1, 34 + j + 1, basey - col - 1); //
               memocol = col;
               j += 1;
           }
       }

         try
       {
           Hgraph.Image = graphique;
       }
       catch
       {
           MessageBox.Show("Erreur d'affectation en Hgraph");
       }
       this.Hgraph.Refresh();
       formGraphics.Dispose();
   }

private void tracegraph(Boolean h)
{
int i;
int j = 0;
int col, coltrace, div,divtrace;
int memocol;
int basey = 532;
Bitmap graphique;
Bitmap graphpixels;
double coeff = 0;

flagimage = true;  // pour éviter des erreurs sur les contrôles si l'image n'est pas affichée

System.Drawing.Graphics formGraphics;
System.Drawing.Graphics formPixels;

  System.Drawing.Pen myPenRed = new System.Drawing.Pen(System.Drawing.Color.Red);
  System.Drawing.Pen myPenBlack = new System.Drawing.Pen(System.Drawing.Color.Black);

    // tracé des graphiques
    graphpixels = new Bitmap(2048, 20, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

    graphique = new Bitmap(graduations);
    formGraphics = Graphics.FromImage(graphique);  // création d'une surface de dessin
    formPixels = Graphics.FromImage(graphpixels);  // création d'une surface de dessin
    formPixels.Clear(SystemColors.Control);
     UInt32[] valueCCD2 = new UInt32[2048];
      image.ElementAt(image.Count - 1).CopyTo(valueCCD2, 0);
      UInt32 maximage = valueCCD2.Max();   // maximum level and mini level
      UInt32 minimage= valueCCD2.Min();

      if (checkgain.Checked == true) // affichage plein écran en hauteur. full screen height
        {
            if (minimage == maximage)
            {
                minimage = maximage - 1;
            }
            double val=0;
            if (seizebits == false)
            {
                coeff = 4000 / Convert.ToDouble(maximage - minimage);
            }
            else
            {
                coeff = 65000 / Convert.ToDouble(maximage - minimage);
            }
            
            for (i = 0; i < 2048; i++)
            {
                 val = (valueCCD2[i] - minimage) * coeff;
                 valueCCD2[i] = Convert.ToUInt32(val);
            }
        }
        lNiveaux.Text = "Niveaux max " + maximage.ToString() + " min " + minimage.ToString();

        // test selon 12 bits ou 16 bits
        if (seizebits == false)
        {
            div = 16;
            divtrace = 8;
        }
        else
        {
             div = 255;  // pour niveau graphique 255 maxi donne 255 
             divtrace = 128;
        }
   
        if (checkinverse.Checked == false)  // selon sens de l'image. according sense of image
        {
            memocol = Convert.ToInt32(valueCCD2[0] / divtrace);
            for (i = 0; i < valueCCD2.Length; i++)
            {
                col = Convert.ToInt32(valueCCD2[i] / div);
                coltrace = Convert.ToInt32(valueCCD2[i] / divtrace);

                if (col < 0)
                {
                    col = 0;
                }
                if (coltrace < 0)
                {
                    coltrace = 0;
                }
                System.Drawing.Pen couleurpixel = new System.Drawing.Pen(System.Drawing.Color.FromArgb(col, col, col));
                formPixels.DrawLine(couleurpixel, i, 0, i, 20);  // tracé de l'image
                formGraphics.DrawLine(myPenRed, 34 + i, basey - memocol - 1, 34 + i + 1, basey - coltrace - 1); //
                memocol = coltrace;
            }
        }
        else
        {
            memocol = Convert.ToInt32(valueCCD2[2047] / divtrace);
            j = 0;
            for (i = valueCCD2.Length - 1; i > -1; i--)
            {
                col = Convert.ToInt32(valueCCD2[i] / div);
                coltrace = Convert.ToInt32(valueCCD2[i] / divtrace);
                if (col < 0)
                {
                    col = 0;
                }
                if (coltrace < 0)
                {
                    coltrace = 0;
                }
                System.Drawing.Pen couleurpixel = new System.Drawing.Pen(System.Drawing.Color.FromArgb(col, col, col));
                formPixels.DrawLine(couleurpixel, j, 0, j, 20);  // tracé de l'image. Write image
                formGraphics.DrawLine(myPenRed, 34 + j, basey - memocol - 1, 34 + j + 1, basey - coltrace - 1); //
                memocol = coltrace;
                j++;
            }
        }

        Hligne.Image = graphpixels;

        if (checkdeu.Checked == true)  // image en niveaux de gris copiée dans le graphique. grayscale image is in the graphic
        {
            formGraphics.DrawImage(graphpixels, 35, 8);
        }
  
        Hgraph.Image = graphique;
        formGraphics.Dispose();
        formPixels.Dispose();
        if (checkRef.Checked == true) // tracé de la courbe de référence. reference curve
        {
            traceref();
        }
         if (h == true)
        {
            labHeure.Text = DteHeure;
        }
         this.hScrollBar1.Value = 0;
        this.DisplayScrollBars();
        this.SetScrollBarValues();
       
        this.Refresh();
}

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            // réception port USB. USB port receive
          this.Invoke(new EventHandler(delegate { Print(); }));
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
           // fin du programme. end program
            try
            {
                serialPort1.Close();
            }
            catch
            {

            }
            try
            {
                System.IO.StreamWriter sri = new System.IO.StreamWriter(repMesDocuments+"config.ini");
                sri.WriteLine(diropen);
                sri.WriteLine(dirsave);
                sri.WriteLine(A_pix.ToString());
                sri.WriteLine(memo.ToString());
                sri.Dispose();
            }
            catch
            {
                MessageBox.Show("Impossible d'enregistrer le fichier config.ini");
            }
          }
      
        private void Form1_Load(object sender, EventArgs e)
        {
            // disc repertory
            repMesDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TivaUno\\";

            String[] listport = SerialPort.GetPortNames(); // list USB port
            comboPort.Items.AddRange(listport);
            if (listport.Length > 0)
            {
                comboPort.SelectedIndex = 0;
            }
            if (Directory.Exists(repMesDocuments))
            {
                try
                {
                    System.IO.StreamReader sri = new System.IO.StreamReader(repMesDocuments + "config.ini");
                    diropen = sri.ReadLine();
                    dirsave = sri.ReadLine();
                    A_pix = Convert.ToDouble(sri.ReadLine());
                    memo = Convert.ToDouble(sri.ReadLine());
                    //   premtr = Convert.ToInt32(sri.ReadLine()); 
                    sri.Dispose();
                }
                catch
                {
                    MessageBox.Show("Impossible de trouver config.ini");
                }
            }
            else
            {
                // création du répertoire dans mes documents et copie de fichiers. create directory in my documents and file copy
                Directory.CreateDirectory(repMesDocuments);
                string fileName = "config.ini";
                string fileFond = "graduations.bmp";
                string sourcePath = Application.StartupPath;
                // copie du fichiers conf.ini dans le répertoire
                string repMesDocuments2 = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TivaUno";
                string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
                string destFile = System.IO.Path.Combine(repMesDocuments2, fileName);
                System.IO.File.Copy(sourceFile, destFile, true);
                sourceFile = System.IO.Path.Combine(sourcePath, fileFond);
                destFile = System.IO.Path.Combine(repMesDocuments2, fileFond);
                System.IO.File.Copy(sourceFile, destFile, true);
            }
   
            lpixA.Text = A_pix.ToString("F") + " Ä par pixel";  // légende
            lpixA.Visible = true;
            for (int j = 0; j < 20; j++)
            {
                for (int i = 0; i < 2048; i++)
                {
                    valueCCDi[j, i] = 0; // 
                }
            }
            this.hScrollBar1.Value = 0;
            // header FIT image
             ima.simple = "                    T                                                  ";
             ima.bitpix = "                   32                                                  ";
              ima.naxis = "                    2                                                  ";
             ima.naxis1 = "                 2048                                                  ";
             ima.naxis2 = "                   20                                                  ";
             ima.bzero =  "                    0                                                  ";
             ima.bscale = "                    1                                                  ";
               ima.bin1 = "                    1                                                  ";
               ima.bin2 = "                    1                                                  ";
            ima.swcreate= " 'TivaUno'                                                             ";
            ima.dateobs = "";
            ima.dateend = "";
            ima.exptime = "";
            // construit image avec graduations. constructed image with graduations
           graduations = (Bitmap)Bitmap.FromFile(repMesDocuments + "graduations.bmp");
           if (A_pix != 0)
           {
               tracelegende();
           }
           else
           {
               Hgraph.Image = graduations;
               Hgraph.Refresh();
           }

      }


        private void BcopierGraphique_Click(object sender, EventArgs e)
        {
            // copy graphic in clipboard
             Clipboard.SetImage(Hgraph.Image);
        }

        private void BcopierImage_Click(object sender, EventArgs e)
        {
            // copy image in clipboard
            Clipboard.SetImage(Hligne.Image);
        }

 
        string returnDateTime()
        {
            System.Globalization.CultureInfo ci = System.Globalization.CultureInfo.InvariantCulture;

            DateTime now = DateTime.Now;
            return  now.ToString("yyyy-MM-dd") +"T" +now.ToString("HH:mm:ss.fff", ci); 
        }


        private void Bcharger_Click(object sender, EventArgs e)
        {
            int a,j,i;
            string tp;
            string msg = null;
            string im = null;
            openFileDialog1.InitialDirectory = diropen;
            openFileDialog1.Filter = "Local files (*.mno) | *.mno| Local files Ref (*.ref) | *.ref";
            openFileDialog1.FilterIndex = 1;
           // openFileDialog1.RestoreDirectory = true;
       
            openFileDialog1.Multiselect = false;
            openFileDialog1.Title = "Charger les fichiers CCD";
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (openFileDialog1.FilterIndex == 1)
                {
                    header.Clear();
                    image.Clear();

                    try
                    {
                        System.IO.StreamReader sri = new System.IO.StreamReader(openFileDialog1.FileName);
                        DiscString = sri.ReadLine(); // lit header
                    }
                    catch
                    {
                        MessageBox.Show("Erreur au chargement du fichier");
                    }
                    a = DiscString.IndexOf('Z');
                    if (a != -1)
                    {
                        msg = DiscString.Substring(0, a - 1);
                        header.Add(msg);
                        im = DiscString.Substring(a + 1, DiscString.Length - a - 1);
                        string[] hd = msg.Split(',');
                        //  DHe:2011-07-01T21:18:44.210,X:2048,Y:1,Dyn:12,Tpo:100Z
                        Ttempspose.Text = hd[4];
                        labHeure.Text = hd[0];
                        if (hd[3] == "12")
                        {
                            seizebits = false;
                        }
                        else
                        {
                            seizebits = true;
                        }
                    }
                    else
                    {
                        im = DiscString;
                        seizebits = false;
                    }
                    // découpe image
                    j = 0;
                    for (i = 0; i < 2048 * 4; i = i + 4)
                    {
                        tp = im.Substring(i, 4);

                        valuelmage[j] = Convert.ToUInt32(tp, 16);
                        j ++;
                    }
                    image.Add(valuelmage);
                    tracegraph(false);
                }


                else if (openFileDialog1.FilterIndex == 2)
                {
                    try
                    {
                        System.IO.StreamReader sri = new System.IO.StreamReader(openFileDialog1.FileName);
                        DiscString = sri.ReadLine(); // lit header
                    }
                    catch
                    {
                        MessageBox.Show("Erreur au chargement du fichier");
                    }
                    a = DiscString.IndexOf('Z');
                    msg = DiscString.Substring(0, a - 1);
                    //    header.Add(msg);
                    im = DiscString.Substring(a + 1, DiscString.Length - a - 1);
                    string[] hd = msg.Split(',');
                    //  DHe:2011-07-01T21:18:44.210,X:2048,Y:1,Dyn:12,Tpo:100Z
                    if (hd[3] == "12")
                    {
                        seizebitsref = false;
                    }
                    else
                    {
                        seizebitsref = true;
                    }
                    // découpe image
                    j = 0;
                    for (i = 0; i < 2048 * 4; i = i + 4)
                    {
                        tp = im.Substring(i, 4);

                        valueRef[j] = Convert.ToUInt32(tp, 16);
                        j ++;
                    }

                     traceref();
                }
                diropen = openFileDialog1.FileName;
                a = diropen.LastIndexOf('\\');
                diropen = diropen.Substring(0, a + 1);
            }
          }
        
        private void Bsauver_Click(object sender, EventArgs e)
        {
              String saveimage ="",tp="";
              int a=0;
              int l = 0;
            // Header de fichier
            /*
             * Nom du fichier, date heure , nbre de pixels , nbre de ligne, 16 bits, temps de pose  et Z pour final
             * Nom:  ,DHe:2011-07-01T21:18:44.210,X:2048,Y:1,Dyn:12,Tpo:100Z
             * */
            // flat appelé flat mno, noir appelé noir.mno, précharge appelé précharge.mno

            // enregistrement multiple pour tous les formats

            // boucle + extraction du header + filename (nom et numéro si >0) + select case selon saveFileDialog1.FilterIndex
            // pour excel, mno et fit
            System.Globalization.CultureInfo ci = System.Globalization.CultureInfo.InvariantCulture;

            string im = "";
            string nbits ="";

            if (seizebits == false)
                nbits = "12";
            else
                nbits = "16";

            saveFileDialog1.Filter = "Excel files (*.rtf) | *.rtf |Image files (*.FIT) | *.FIT |Image Graphique (*.BMP) | *.BMP|Image caméra (*.BMP) | *.BMP| Local files (*.mno) | *.mno| Local files Ref (*.ref) | *.ref";
            saveFileDialog1.FilterIndex = 5;
            saveFileDialog1.Title = "Sauver les fichiers";
            saveFileDialog1.FileName = "";
            saveFileDialog1.InitialDirectory = dirsave;
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (saveFileDialog1.FilterIndex == 1)
                {
                    valuelmage = image.ElementAt(image.Count-1);
                    for (int j = 0; j < image.Count; j++)
                    {
                          saveimage = header.ElementAt(header.Count-1);
                        for (int i = 0; i < 2048; i = i + 4)
                        {
                            tp = valuelmage[i].ToString();
                            saveimage += tp + "\r\n";
                         }
                    }
                     try
                    {
                        System.IO.StreamWriter sri = new System.IO.StreamWriter(saveFileDialog1.FileName);
                        sri.WriteLine(saveimage);
                        sri.Close(); 
                    }
                    catch
                    {
                        MessageBox.Show("Impossible d'enregistrer le fichier sur le disque");
                    }
                }
                else if (saveFileDialog1.FilterIndex == 2)
                {
                    
                    // image FIT 2048 * 20. tracé du spectre sur 20 pixels de haut
                     for (int k = 0; k < image.Count; k++)
                    {                    
                       UInt32[] valuelmage2 = image.ElementAt(k);
                         for (int j = 0; j < 20; j++)
                        {
                            l = 0;
                            for (int i = 0; i < valuelmage2.Length; i++)
                            {                      
                               valueCCDi[j, i] = ReverseBytes((ushort)valuelmage2[l]);
                                l += 1;
                            }
                        }
                          string head = header.ElementAt(k);
                         string[] hd = head.Split(',');
                          ima.dateobs = " '" + hd[0] + "' / Date of observation start                 ";
                          string exp = (Convert.ToDouble(hd[4])/ 1000).ToString();
                         exp = exp.Replace(',', '.');
                         ima.exptime = new string(' ', 21 - exp.Length) + exp + " / [s] Total time of exposure                     ";
                         // extraction date
                         string[] hddate = hd[0].Split('T');
                         string[] hddate2 = hddate[0].Split('-');
                         string[] hdheure = hddate[1].Split(':');
                         string[] hdheurev = hdheure[2].Split('.');
                         DateTime date1 = new DateTime(Convert.ToInt32(hddate2[0]), Convert.ToInt32(hddate2[1]), Convert.ToInt32(hddate2[2]), Convert.ToInt32(hdheure[0]), Convert.ToInt32(hdheure[1]), Convert.ToInt32(hdheurev[0]));
                         DateTime dt2 = date1.AddMilliseconds(Convert.ToInt32(hdheurev[1]));
                        // extraction pose
                         DateTime dt= dt2.AddMilliseconds(Convert.ToDouble(hd[4]));
                         string dte = dt.ToString("yyyy-MM-dd") + "T" + dt.ToString("HH:mm:ss.fff", ci);
                         ima.dateend = " '" + dte + "' / Date of observation end                   ";
                  
                     string namefile = saveFileDialog1.FileName;
                    try
                    {
                      //  string namefile = saveFileDialog1.FileName;
                        namefile = namefile.Substring(0, namefile.Length - 4);
                        if (image.Count > 1)
                        {
                            namefile = namefile + k.ToString() + ".fit";
                        }
                        else
                        {
                            namefile = saveFileDialog1.FileName;
                        }
                        System.IO.StreamWriter sri = new System.IO.StreamWriter(namefile);
                        sri.Write(ima.save());
                        sri.Close();
                        using (BinaryWriter srib = new BinaryWriter(File.Open(namefile, FileMode.Append)))
                            foreach (int m in valueCCDi)
                            {
                                srib.Write(m);
                            }                      
                    }
                    catch
                    {
                        MessageBox.Show("Impossible d'enregistrer le fichier sur le disque");
                    }
                  }
                }
                else if (saveFileDialog1.FilterIndex == 3)
                {
                    // sauve image graphique
                    try
                    {
                        Hgraph.Image.Save(saveFileDialog1.FileName);
                    }
                    catch
                    {
                        MessageBox.Show("Impossible d'enregistrer le fichier sur le disque");
                    }
                }
                else if (saveFileDialog1.FilterIndex == 4)
                {
                    // sauve image CCD (ligne)
                    try
                    {
                        Hligne.Image.Save(saveFileDialog1.FileName);
                    }
                    catch
                    {
                        MessageBox.Show("Impossible d'enregistrer le fichier sur le disque");
                    }
                }

                else if (saveFileDialog1.FilterIndex == 5 || saveFileDialog1.FilterIndex == 6)
                {
                        for (int i = 0; i < image.Count; i++)
                        {
                            im = "";
                            // transformation en ascii du tableau image
                            UInt32[] valueCCD2 = image.ElementAt(i);
                            for (int j = 0; j < valueCCD2.Length; j++)
                            {
                                im += valueCCD2[j].ToString("X4"); 
                            }                        
                            try
                            {
                                string namefile = saveFileDialog1.FileName;
                                namefile = namefile.Substring(0, namefile.Length - 4);
                                if (image.Count > 1)
                                {
                                    if (saveFileDialog1.FilterIndex == 5)
                                    {
                                        namefile = namefile + i.ToString() + ".mno";
                                    }
                                    else
                                    {
                                        namefile = namefile + i.ToString() + ".ref";
                                    }
                                }
                                else
                                {
                                    namefile = saveFileDialog1.FileName;
                                }
                                System.IO.StreamWriter sri = new System.IO.StreamWriter(namefile);
                                sri.WriteLine(header.ElementAt(i) + "Z" + im);
                                sri.Close();
                              }
                            catch 
                            {
                                MessageBox.Show("Impossible d'enregistrer le fichier sur le disque");                          
                            }
                    }
                        image.Clear();
                        lvues.Visible = false;
                }
                dirsave = saveFileDialog1.FileName;
                 a = dirsave.LastIndexOf('\\');
                dirsave = dirsave.Substring(0, a + 1);
            }
        }

        public static UInt32 ReverseBytes(UInt32 value)
        {
            // to normalize sense bytes
            return (value & 0x000000FFU) << 24 | (value & 0x0000FF00U) << 8 |
                   (value & 0x00FF0000U) >> 8 | (value & 0xFF000000U) >> 24;
        }

        private void comboPort_SelectedIndexChanged(object sender, EventArgs e)
        {
             if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
            serialPort1.PortName = comboPort.SelectedItem.ToString();
                  
            try
            {
                serialPort1.Open();
                flagcom = true;                
            }
            catch
            {
                //MessageBox.Show("Impossible d'ouvrir le port");
            }

         
        }
     public void DisplayScrollBars()
        {
            // If the image is wider than the PictureBox, show the HScrollBar.
            if (Hgraph.Width > Hgraph.Image.Width)
            {
                hScrollBar1.Visible = false;
            }
            else
            {
                hScrollBar1.Visible = true;
            }
         
        }

        public void SetScrollBarValues()
        {
            // Set the Maximum, Minimum, LargeChange and SmallChange properties.
            this.hScrollBar1.Minimum = 0;

            // If the offset does not make the Maximum less than zero, set its value. 
            if ((this.Hgraph.Image.Size.Width - Hgraph.ClientSize.Width) > 0)
            {
                this.hScrollBar1.Maximum = this.Hgraph.Image.Size.Width - Hgraph.ClientSize.Width;
            }
           this.hScrollBar1.LargeChange = this.Hgraph.Width / 10;
           this.hScrollBar1.SmallChange = this.Hgraph.Width / 20;

            // Adjust the Maximum value to make the raw Maximum value 
            // attainable by user interaction.
           this.hScrollBar1.Maximum += this.hScrollBar1.LargeChange;
        }

        private void HandleScroll(Object sender, ScrollEventArgs se)
        {
            // teste si l'image existe.
            if (flagimage == true)
            {
                Bformat.BackColor = Color.AliceBlue;
                retraceimage();
            }
        }

        private void retraceimage()
        {

            Hgraph.SizeMode = PictureBoxSizeMode.Normal;
            /* Create a graphics object and draw a portion 
               of the image in the PictureBox. */
            Graphics g = Hgraph.CreateGraphics();

            if (hScrollBar1.Visible == true)
            {
                g.DrawImage(Hgraph.Image,
                   new Rectangle(0, 0, Hgraph.Right, Hgraph.Bottom - hScrollBar1.Height), new Rectangle(hScrollBar1.Value, 0,
                   Hgraph.Right, Hgraph.Bottom - hScrollBar1.Height), GraphicsUnit.Pixel);
            }

            Hgraph.Update();
        }
              

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            if (Hgraph.Image != null)
            {
                this.DisplayScrollBars();
                this.SetScrollBarValues();
                this.hScrollBar1.Value = 0;
                this.Refresh();
            }
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            if (Hgraph.Image != null)
            {
                this.DisplayScrollBars();
                this.SetScrollBarValues();
                this.Refresh();
            }
        }

        private void Bformat_Click(object sender, EventArgs e)
        {
            if (Hgraph.SizeMode == PictureBoxSizeMode.StretchImage)
            {
                Hgraph.SizeMode = PictureBoxSizeMode.Normal;
                Bformat.BackColor = Color.AliceBlue;
            }
            else
            {
                Hgraph.SizeMode = PictureBoxSizeMode.StretchImage;
                Bformat.BackColor = Color.LightGreen;
            }
        }

        private void Bnettete_Click(object sender, EventArgs e)
        {
            string com;
            int temps;
            // une trame = id sur 2 octets + temps sur 4 octets  + FF 
            // id = 01 pour netteté
                com = "01";
                temps = Convert.ToInt32(Ttempspose.Text);
                com = com + temps.ToString("X4")+"FF";
                image.Clear();
                header.Clear();
                if (serialPort1.IsOpen)
                {
                  DteHeure = returnDateTime();
                  serialPort1.WriteLine(com);
                  seizebits = false;
                  flagmultiple = false;
                  Bnettete.BackColor = Color.LightGreen;
                }
        }

        private void Bstop_Click(object sender, EventArgs e)
        {
            string com = "000000FF";
            if (serialPort1.IsOpen)
            {                
                serialPort1.WriteLine(com);
                Bnettete.BackColor = Color.AliceBlue;
            }
        }

        private void Bport_Click(object sender, EventArgs e)
        {
            String[] listport = SerialPort.GetPortNames();
            comboPort.Items.Clear();
            comboPort.Items.AddRange(listport);
            if (listport.Length > 0)
            {
                comboPort.SelectedIndex = 0;
            }
        }

 

        private void checkdeu_CheckedChanged(object sender, EventArgs e)
        {
            tracegraph(false);
        }

        private void checkinverse_CheckedChanged(object sender, EventArgs e)
        {
             tracegraph(false);
        }

        private void checkRef_CheckedChanged(object sender, EventArgs e)
        {
            tracegraph(false);
         }

        private void Bcorrection_Click(object sender, EventArgs e)
        {
            // traitement sur l'image capturée avec précharge, noir, flat
            // soustraction du noir, division par la ( plu - précharge ) et multiplication d'un facteur moyen selon la plu
            // faire une moyenne de 10 précharges
            // vérifiez que l'image est sauvegardée
            // test si images de traitement sur le disque
            // chargement images
            // correction.
        }

        private void bpause16_Click(object sender, EventArgs e)
        {
            string com;
            int temps;
          //  Thread c = new Thread(boucleI);
            // lancement de 16 poses cumulatives pour arriver à la dynamique de 16 bits
            // une trame = id sur 2 octets + temps sur 4 octets  + 00FF 
            // id = 03 pour 16 conversions pour avoir 16 bits en dynamique
            com = "03";
            temps = Convert.ToInt32(Ttempspose.Text);
            com = com + temps.ToString("X4") + "FF";
           // com = com + "FF";
            image.Clear();
            header.Clear();
            flagmultiple = true;
            Cursor.Current = Cursors.WaitCursor;
            nbreimage = Convert.ToInt32(tmult.Text);
            for (int i = 0; i < nbreimage; i++)
            {
                if (serialPort1.IsOpen)
                {
                    flagcom = false;
                    DteHeure = returnDateTime();
                    serialPort1.WriteLine(com);
                    seizebits = true;
                   // c.Start();
                    do
                    {
                        Application.DoEvents();
                        if (flagcom == true)
                            break;
                        // attente du retour image
                    } while (true);
                   // c.Abort();                   
                }          
            }
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
           hScrollBar2.Maximum = Convert.ToInt32(tmax.Text);
           Ttempspose.Text = hScrollBar2.Value.ToString();
        }

       

        private void bsup_Click(object sender, EventArgs e)
        {
                image.Clear();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
           X = Form1.MousePosition.X - (Form1.ActiveForm.Location.X + Hgraph.Location.X + 34)-8 + hScrollBar1.Value;
        }

        private void mesure1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // pointeur souris
            tMesure1.Visible = true;
            tMesure1.Text = "";
            tMesure1.Focus();
            MessageBox.Show("pix " + X);
            Xpos1 = X;          
        }

        private void mesure2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // pointeur souris
            Xpos2 = X;
            tMesure2.Visible = true;
            tMesure2.Text = "";
            tMesure2.Focus();
            MessageBox.Show("pix " + X);
        }
  
        
        private void résolutionToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
            if (tMesure1.Text != "" && tMesure2.Text != "")
            {
                // affichage du nombre d'Ä par pixels
                if (Xpos2 > Xpos1)
                {
                   rapPix = Xpos2 - Xpos1;
                   rapAng = Convert.ToDouble(tMesure2.Text) - Convert.ToDouble(tMesure1.Text);
                }
                else
                {
                    rapPix = Xpos1 - Xpos2;
                    rapAng = Convert.ToDouble(tMesure1.Text) - Convert.ToDouble(tMesure2.Text);
                }
                A_pix = rapAng / rapPix ;
                lpixA.Text = A_pix.ToString("F") + " Ä par pixel";
                lpixA.Visible = true;
                tMesure1.Visible = false;
                tMesure2.Visible = false;
            }
        }

        private void légendesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int legende=0;
            int i;
            int basey = 533;
            int Angadd=0;
            // tracé des légendes en bas d'écran
            // détermination de la première graduation entière en fonction de Xpos1 et A_pix
           double firstpixA = Convert.ToDouble(tMesure1.Text) - (Xpos1 * A_pix);  // valeur A pour pixel 0
           memo = firstpixA;
           premtr = Convert.ToInt32(firstpixA);  // valeur en A pour la première graduation

             Angadd = Convert.ToInt32(50 * A_pix);
            System.Drawing.Graphics formGraphics;
            Bitmap graphique;
            graphique = new Bitmap(graduations);
            formGraphics = Graphics.FromImage(graphique);  // création d'une surface de dessin
            System.Drawing.Pen myPenWhite = new System.Drawing.Pen(System.Drawing.Color.White);
            System.Drawing.Pen myPenBlack = new System.Drawing.Pen(System.Drawing.Color.Black);

            for (i = 0; i < 20; i++)
            {
                formGraphics.DrawLine(myPenWhite, 1, basey + i, 33 + 2048, basey + i);  // tracé de la ligne d'effacement
            }
            int poscar = basey + 5;
//            legende = premtr - Angadd;
            legende = premtr - Angadd;
            int facadd = Convert.ToInt32(50 * A_pix);
            for (i = 0; i < 2048; i= i+50)
             {
                 formGraphics.DrawLine(myPenBlack, i + 33, basey , i + 33, basey + 4);  // tracé des petites graduations
                 legende += Angadd;
                 formGraphics.DrawString(legende.ToString(), new Font(FontFamily.GenericSansSerif, 6, FontStyle.Regular),
             new SolidBrush(Color.Black), i+20,poscar);
            }
           
            Hgraph.Image = graphique;
            Hgraph.Refresh();
           // tracegraph(false);
            DialogResult result;
            result = MessageBox.Show("Voulez vous enregistrer les légendes ?", "Sauvegarder", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                 try
                {
                     System.IO.StreamWriter sav = new System.IO.StreamWriter(repMesDocuments +"config.ini");
                    sav.WriteLine(diropen);
                    sav.WriteLine(dirsave);
                    sav.WriteLine(A_pix.ToString());
                    sav.WriteLine(memo.ToString());
                    sav.Dispose();
                }
                catch
                {
                    MessageBox.Show("Impossible d'enregistrer le fichier config.ini"); 
                }

                graduations = graphique;
                formGraphics.Dispose();           
                tracegraph(false);
            }
        }

        void tracelegende()
        {
            int legende = 0;
            int i;
            int basey = 533;
            int Angadd = 0;
            // tracé des légendes en bas d'écran. Write legends
            // détermination de la première graduation entière en fonction de Xpos1 et A_pix
            double firstpixA = memo;
            premtr = Convert.ToInt32(firstpixA);  // valeur en A pour la première graduation

            Angadd = Convert.ToInt32(50 * A_pix);

            System.Drawing.Graphics formGraphics;
            Bitmap graphique;
            graphique = new Bitmap(graduations);
            formGraphics = Graphics.FromImage(graphique);  // création d'une surface de dessin
            System.Drawing.Pen myPenWhite = new System.Drawing.Pen(System.Drawing.Color.White);
            System.Drawing.Pen myPenBlack = new System.Drawing.Pen(System.Drawing.Color.Black);

            for (i = 0; i < 20; i++)
            {
                formGraphics.DrawLine(myPenWhite, 1, basey + i, 33 + 2048, basey + i);  // tracé de la ligne d'effacement
            }
            int poscar = basey + 5;
            legende = premtr - Angadd;
            for (i = 0; i < 2048; i = i + 50)
            {
                formGraphics.DrawLine(myPenBlack, i + 33, basey, i + 33, basey + 4);  // tracé des petites graduations
                legende += Angadd;
                formGraphics.DrawString(legende.ToString(), new Font(FontFamily.GenericSansSerif, 6, FontStyle.Regular),
            new SolidBrush(Color.Black), i + 20, poscar);
            }
            graduations = graphique;
            formGraphics.Dispose();
            Hgraph.Image = graphique;
            Hgraph.Refresh();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // affiche valeur en Angstrom. Write Angstrom value
           // double prem = Convert.ToDouble(tMesure1.Text) - (Xpos1 * A_pix);  // valeur A pour pixel 0

            double mes = (A_pix * X) + memo;
            lAng.Text = mes.ToString("F") + " Ä";
            MessageBox.Show("pix " + X + " " + "A " + mes);
            lAng.Visible = true;
        }

        private void checkgain_CheckedChanged(object sender, EventArgs e)
        {
            tracegraph(false);
        }
      }
    }


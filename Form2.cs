using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Diagnostics;
using System.Globalization;
using PdfSharp.Drawing.Layout;
using System.IO;

namespace Facturation
{
    public partial class Generateur : Form
    {

        public Generateur()
        {
            InitializeComponent();
        }



        
        private void numericUpDownNbJours_Validated(object sender, EventArgs e)
        {
            //Arrivée total des honoraires
            numericUpDownHonoraire.Value = numericUpDownNbJours.Value * numericUpDownPrix.Value;

            //Arrivée Total à payer
            numericUpDownPayer.Value = numericUpDownMontantTVA.Value + numericUpDownHonoraire.Value;

            //Arrivée montant TVA
            numericUpDownMontantTVA.Value = numericUpDownTVA.Value / 100 * numericUpDownHonoraire.Value;

        }


        private void numericUpDownPrix_Validated(object sender, EventArgs e)
        {
            numericUpDownHonoraire.Value = numericUpDownNbJours.Value * numericUpDownPrix.Value;
            numericUpDownPayer.Value = numericUpDownMontantTVA.Value + numericUpDownHonoraire.Value;
            numericUpDownMontantTVA.Value = numericUpDownTVA.Value / 100 * numericUpDownHonoraire.Value;


        }


    
        private void numericUpDownHonoraire_Validated(object sender, EventArgs e)
        {
            numericUpDownMontantTVA.Value = numericUpDownTVA.Value / 100 * numericUpDownHonoraire.Value;
            numericUpDownHonoraire.Value = numericUpDownNbJours.Value * numericUpDownPrix.Value;
            numericUpDownPayer.Value = numericUpDownMontantTVA.Value + numericUpDownHonoraire.Value;


        }

        private void numericUpDownTVA_Validated(object sender, EventArgs e)
        {
            numericUpDownMontantTVA.Value = numericUpDownTVA.Value / 100 * numericUpDownHonoraire.Value;
            numericUpDownHonoraire.Value = numericUpDownNbJours.Value * numericUpDownPrix.Value;
            numericUpDownPayer.Value = numericUpDownMontantTVA.Value + numericUpDownHonoraire.Value;


        }





        
        private void numericUpDownMontantTVA_Validated(object sender, EventArgs e)
        {
            numericUpDownPayer.Value = numericUpDownMontantTVA.Value + numericUpDownHonoraire.Value;
            numericUpDownMontantTVA.Value = numericUpDownTVA.Value / 100 * numericUpDownHonoraire.Value;
            numericUpDownHonoraire.Value = numericUpDownNbJours.Value * numericUpDownPrix.Value;


        }

        private void numericUpDownHonoraire_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownPayer.Value = numericUpDownMontantTVA.Value + numericUpDownHonoraire.Value;

            numericUpDownMontantTVA.Value = numericUpDownTVA.Value / 100 * numericUpDownHonoraire.Value;
            numericUpDownHonoraire.Value = numericUpDownNbJours.Value * numericUpDownPrix.Value;


        }

        private void dateTimePickerFin_Validated(object sender, EventArgs e)
        {

            //string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        }

        private void buttonPDF_Click(object sender, EventArgs e)
        {
            if (this.Controls.OfType<TextBox>().Any(t => string.IsNullOrEmpty(t.Text)))
            {
                MessageBox.Show("Attention toutes les cases ne sont pas remplies !");
            }
            else
            {
                String datefin = dateTimePickerFin.Value.ToString();
                datefin = datefin.Remove(datefin.Length - 9);
                //On récupère la date puis du picker et on retire l'année
                String datedebut = dateTimePickerDebut.Value.ToString();
                datedebut = datedebut.Remove(datedebut.Length - 9);

                //Create PDF Document
                PdfDocument document = new PdfDocument();
                //You will have to add Page in PDF Document
                PdfPage page = document.AddPage();
                //For drawing in PDF Page you will nedd XGraphics Object
                XGraphics gfx = XGraphics.FromPdfPage(page);
                //For Test you will have to define font to be used
                XFont font = new XFont("Verdana", 9, XFontStyle.Regular);
                //Format qui permet d'aligner le texte
                XTextFormatter tf = new XTextFormatter(gfx);
                tf.Alignment = XParagraphAlignment.Center;





                tf.DrawString("JB2S", new XFont("Garamond", 15, XFontStyle.Bold), XBrushes.Black, new XRect(45, 30, 80, 140), XStringFormats.TopLeft);
                tf.DrawString("Consulting", new XFont("Arial", 13, XFontStyle.BoldItalic), new XSolidBrush(XColor.FromArgb(154, 104, 53)), new XRect(110, 30, 80, 140), XStringFormats.TopLeft);
                tf.DrawString("Conseil en informatique de gestion et Organisation des systèmes d’information", new XFont("Verdana", 9, XFontStyle.Italic), XBrushes.Black, new XRect(30, 60, 200, 140), XStringFormats.TopLeft);


                gfx.DrawString(textBoxVotreVille.Text + ", le " + DateTime.Now.ToString("dd MMMM yyyy", CultureInfo.CreateSpecificCulture("fr")),
                font, XBrushes.Black, new XPoint(385, 55));



                tf.DrawString("À ", font, XBrushes.Black, new XRect(365, 80, 250, 140), XStringFormats.TopLeft);
                tf.DrawString(textBoxNomEntreprise.Text, new XFont("Verdana", 9, XFontStyle.Bold), XBrushes.Black, new XRect(365, 100, 250, 140), XStringFormats.TopLeft);
                tf.DrawString(textBoxAdresse.Text, font, XBrushes.Black, new XRect(365, 120, 250, 140), XStringFormats.TopLeft);
                tf.DrawString(textBoxCodePostale.Text + textBoxVille.Text, font, XBrushes.Black, new XRect(365, 140, 250, 140), XStringFormats.TopLeft);

                tf.DrawString("HONORAIRE N° : " + DateTime.Now.ToString("yyyy") + "/0" + DateTime.Now.ToString("MM"), new XFont("Verdana", 15, XFontStyle.Bold), XBrushes.Black, new XRect(160, 190, 250, 140), XStringFormats.TopLeft);
                tf.DrawString("Original", new XFont("Verdana", 10), XBrushes.Black, new XRect(160, 220, 250, 140), XStringFormats.TopLeft);


                tf.DrawString("Madame, Monsieur,", font, XBrushes.Black, new XRect(10, 300, 150, 140), XStringFormats.TopLeft);
                tf.DrawString("Veuillez trouver ci-joint le détail des honoraires dont est redevable la société " + textBoxNomEntreprise.Text +
                " au titre des prestations fournies à la Banque de France par la société JB2S Consulting entre le " + datedebut +
                " et le " + datefin + "."
                , font, XBrushes.Black, new XRect(20, 340, 550, 140), XStringFormats.TopLeft);


                tf.DrawString("Période de facturation", font, XBrushes.Black, new XRect(30, 400, 80, 100), XStringFormats.TopLeft);
                tf.DrawString("Prix unitaire H.T", font, XBrushes.Black, new XRect(120, 400, 80, 100), XStringFormats.TopLeft);
                tf.DrawString("Nb de jours facturés", font, XBrushes.Black, new XRect(210, 400, 80, 100), XStringFormats.TopLeft);
                tf.DrawString("Total des honoraires H.T", font, XBrushes.Black, new XRect(300, 400, 80, 100), XStringFormats.TopLeft);
                tf.DrawString("Montant TVA   (20 %)", font, XBrushes.Black, new XRect(390, 400, 80, 100), XStringFormats.TopLeft);
                tf.DrawString("Total à payer TTC", font, XBrushes.Black, new XRect(480, 400, 80, 100), XStringFormats.TopLeft);


                tf.DrawString("Du " + datedebut + " au " + datefin, font, XBrushes.Black, new XRect(30, 440, 80, 100), XStringFormats.TopLeft);
                tf.DrawString(numericUpDownPrix.Text + " €", font, XBrushes.Black, new XRect(120, 440, 80, 100), XStringFormats.TopLeft);
                tf.DrawString(numericUpDownNbJours.Text, font, XBrushes.Black, new XRect(210, 440, 80, 100), XStringFormats.TopLeft);
                tf.DrawString(numericUpDownHonoraire.Text + " €", font, XBrushes.Black, new XRect(300, 440, 80, 100), XStringFormats.TopLeft);
                tf.DrawString(numericUpDownMontantTVA.Text + " €", font, XBrushes.Black, new XRect(390, 440, 80, 100), XStringFormats.TopLeft);
                tf.DrawString(numericUpDownPayer.Text + " €", font, XBrushes.Black, new XRect(480, 440, 80, 100), XStringFormats.TopLeft);

                //Horizontale
                gfx.DrawLine(XPens.Black, 20, 390, 580, 390);
                gfx.DrawLine(XPens.Black, 20, 430, 580, 430);
                gfx.DrawLine(XPens.Black, 20, 470, 580, 470);

                //Verticale
                gfx.DrawLine(XPens.Black, 20, 390, 20, 470);
                gfx.DrawLine(XPens.Black, 115, 390, 115, 470);
                gfx.DrawLine(XPens.Black, 205, 390, 205, 470);
                gfx.DrawLine(XPens.Black, 295, 390, 295, 470);
                gfx.DrawLine(XPens.Black, 385, 390, 385, 470);
                gfx.DrawLine(XPens.Black, 475, 390, 475, 470);
                gfx.DrawLine(XPens.Black, 580, 390, 580, 470);

                tf.DrawString("Le montant de la présente facture sera à virer sur le compte :", font, XBrushes.Black, new XRect(30, 510, 290, 140), XStringFormats.TopLeft);

                //Horizontale 2eme tableau
                gfx.DrawLine(XPens.Black, 20, 540, 580, 540);
                gfx.DrawLine(XPens.Black, 20, 580, 580, 580);
                gfx.DrawLine(XPens.Black, 20, 620, 580, 620);

                //Verticale 2eme tableau
                gfx.DrawLine(XPens.Black, 20, 540, 20, 620);
                gfx.DrawLine(XPens.Black, 205, 540, 205, 620);
                gfx.DrawLine(XPens.Black, 295, 540, 295, 620);
                gfx.DrawLine(XPens.Black, 475, 540, 475, 620);
                gfx.DrawLine(XPens.Black, 580, 540, 580, 620);

                tf.DrawString("Code Établissement", font, XBrushes.Black, new XRect(65, 550, 100, 100), XStringFormats.TopLeft);
                tf.DrawString("Code guichet", font, XBrushes.Black, new XRect(200, 550, 100, 100), XStringFormats.TopLeft);
                tf.DrawString("Numéro de Compte", font, XBrushes.Black, new XRect(340, 550, 100, 100), XStringFormats.TopLeft);
                tf.DrawString("Clé RIB", font, XBrushes.Black, new XRect(480, 550, 50, 100), XStringFormats.TopLeft);


                tf.DrawString(textBoxCodeEtabli.Text, font, XBrushes.Black, new XRect(60, 590, 100, 100), XStringFormats.TopLeft);
                tf.DrawString(textBoxCodeGuichet.Text, font, XBrushes.Black, new XRect(220, 590, 60, 100), XStringFormats.TopLeft);
                tf.DrawString(textBoxNumCompte.Text, font, XBrushes.Black, new XRect(330, 590, 120, 100), XStringFormats.TopLeft);
                tf.DrawString(textBoxRIB.Text, font, XBrushes.Black, new XRect(480, 590, 30, 100), XStringFormats.TopLeft);


                tf.DrawString("Veuillez agréer l’assurance de mes salutations distinguées.", font, XBrushes.Black, new XRect(30, 650, 270, 140), XStringFormats.TopLeft);

                tf.DrawString("Monsieur José BIAOU", new XFont("Verdana", 9, XFontStyle.BoldItalic), XBrushes.Black, new XRect(450, 680, 130, 140), XStringFormats.TopLeft);
                tf.DrawString("Le Gérant", font, XBrushes.Black, new XRect(450, 690, 70, 140), XStringFormats.TopLeft);


                gfx.DrawLine(new XPen(XColors.Brown, 2), 90, 730, 490, 730);

                tf.DrawString("JB2S Consulting, " + textBoxVotreAdresse.Text + " " + textBoxVotreCodepostal.Text + " " + textBoxVotreVille.Text + " - jb2s.consulting@gmail.com",
                new XFont("Verdana", 9, XFontStyle.Italic), new XSolidBrush(XColor.FromArgb(154, 104, 53)),
                new XRect(25, 745, 550, 140), XStringFormats.TopLeft);

                tf.DrawString("Société Unipersonnelle à Responsabilité Limitée – Capital : 1500 € - RCS 507 707 164 Nanterre APE : 6202A - N° TVA intra-communautaire : FR53507707164",
                new XFont("Verdana", 9, XFontStyle.Italic), XBrushes.Blue,
                new XRect(75, 755, 450, 100), XStringFormats.TopLeft);





                string date = DateTime.Now.ToString("dd-MM-yy");
                String entrep = textBoxNomEntreprise.Text;
                //Specify file name of the PDF file
                string filename = entrep + " " + date + ".pdf";
                //Save PDF File
                document.Save(@".\Factures\" + filename);
                //Load PDF File for viewing
                Process.Start(@".\Factures\" + filename);
            }


        }
    }
}

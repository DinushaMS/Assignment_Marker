using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace PDF_Marker_New
{
    class PDF
    {
        static PdfDocument pdfDoc;
        public static readonly int iWidth = 70;
        public static readonly int iHeight = 50;
        static int fontSize = 14;
        public static Point fScoreOrigin = new Point(730, 50);
        public static void Export(string file, Pages[] pages)
        { 
            pdfDoc = new PdfDocument(new PdfReader(DATA.sourcePDFpath), new PdfWriter(file));
            // Document to add layout elements: paragraphs, images etc
            Document document = new Document(pdfDoc);

            // Load image from disk
            string imgC = "Stamps\\correct.png";
            string imgW = "Stamps\\wrong.png";
            //var image = Properties.Resources.right;
            ImageData correctSign = ImageDataFactory.Create(imgC);
            ImageData wrongSign = ImageDataFactory.Create(imgW);
            //Create layout image object and provide parameters. Page number = 1
            for (int i = 1; i <= DATA.pageCount; i++)
            {
                iText.Kernel.Geom.Rectangle mediabox = pdfDoc.GetPage(i).GetPageSize();
                int actualWidth = (int)mediabox.GetWidth();
                int actualHeight = (int)mediabox.GetHeight();
                int img_w;
                int img_h;
                int px, py;
                if (pages[i - 1].tick != null)
                {
                    img_w = (iWidth * actualWidth) / DATA.OriginalImages[i - 1].Width;
                    img_h = (iHeight * actualHeight) / DATA.OriginalImages[i - 1].Height;
                    foreach (var item in pages[i - 1].tick)
                    {
                        px = Convert.ToInt32((item.x * actualWidth) / 1000);
                        py = actualHeight - Convert.ToInt32((item.y * actualHeight) / 1000) - img_h / 2;
                        iText.Layout.Element.Image image;
                        int numLines = item.text.Split('\n').Length * 14;
                        Text scoreText = new Text($"({item.text})").SetFontColor(ColorConstants.RED).SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA)).SetFontSize(fontSize);
                        Text commentText = new Text($"{item.text}").SetFontColor(ColorConstants.RED).SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA)).SetFontSize(fontSize);
                        if (item.Type == 'C')
                            image = new iText.Layout.Element.Image(correctSign).ScaleAbsolute(img_w, img_h).SetFixedPosition(i, px, py);
                        else if (item.Type == 'I')
                            image = new iText.Layout.Element.Image(wrongSign).ScaleAbsolute(img_w, img_h).SetFixedPosition(i, px, py);
                        else
                            image = null;
                        // This adds the image to the page
                        if (image != null)
                        {
                            document.Add(image);
                            if(item.text != "")
                            {
                                Paragraph p1 = new Paragraph(scoreText).SetFixedPosition(i, px + img_w, py, 50).SetFontSize(fontSize);
                                document.Add(p1);
                            }                            
                        }
                        else
                        {
                            //px = Convert.ToInt32((item.x * actualWidth) / 1000) + 10;
                            //py = actualHeight - Convert.ToInt32(((item.y * actualHeight) / 1000) + (fontSize * item.cmtLines));
                            Paragraph p1 = new Paragraph(commentText).SetFixedPosition(i, px, py - numLines, 200).SetFontSize(fontSize);
                            p1.SetFixedLeading(Convert.ToInt32(fontSize * 1.2));
                            document.Add(p1);
                        }

                    }
                }
                if (i == 1)
                {
                    px = Convert.ToInt32((fScoreOrigin.X * actualWidth) / 1000) + 10;
                    py = actualHeight - Convert.ToInt32(((fScoreOrigin.Y * actualHeight) / 1000) + (fontSize * 2.5));

                    Text finalText = new Text($"{DATA.finalScore}\n-----\n{DATA.outOf}").SetFontColor(ColorConstants.RED).SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA));
                    Paragraph p2 = new Paragraph(finalText).SetFixedPosition(1, px, py, 50).SetFontSize(fontSize);
                    p2.SetFixedLeading(Convert.ToInt32((fontSize * 10) / 12));
                    document.Add(p2);
                }
            }

            // Don't forget to close the document.
            // When you use Document, you should close it rather than PdfDocument instance
            document.Close();
            MessageBox.Show("File saved successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FrmMain.isSaved = true;
            //pdfViewer.src = target;
            //pdfDocument.Load(target);
        }
    }
}

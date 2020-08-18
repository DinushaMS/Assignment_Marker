using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using O2S.Components.PDFRender4NET;

namespace PDF_Marker_New
{
    class PDF2IMG
    {  
        public static void ConvertPDF2Image(string pdfInputPath, string imageOutputPath,string imageName, ImageFormat imageFormat)
        {
            PDFFile pdfFile = PDFFile.Open(pdfInputPath);
            DATA.pageCount = pdfFile.PageCount;
            int startPageNum = 1;
            int endPageNum = DATA.pageCount;
            Console.WriteLine(imageOutputPath);

            if (!Directory.Exists(imageOutputPath))
            {
                Directory.CreateDirectory(imageOutputPath);
            }
            else
            {
                Directory.Delete(imageOutputPath, true);
                Directory.CreateDirectory(imageOutputPath);
            }

            // validate pageNum
            if (startPageNum <= 0)
            {
                startPageNum = 1;
            }

            if (endPageNum > pdfFile.PageCount)
            {
                endPageNum = pdfFile.PageCount;
            }

            if (startPageNum > endPageNum)
            {
                int tempPageNum = startPageNum;
                startPageNum = endPageNum;
                endPageNum = startPageNum;
            }

            DATA.OriginalImages = new List<Bitmap>();
            //DATA.AnnotatedImages = new List<Bitmap>();
            // start to convert each page
            for (int i = startPageNum; i <= endPageNum; i++)
            {
                float pageWidth = pdfFile.GetPageSize(i-1).Width / 72;
                float pageHeight = pdfFile.GetPageSize(i-1).Height / 72;
                float resolution = DATA.panelWidth / pageWidth;
                //Bitmap pageImage = pdfFile.GetPageImage(i - 1, 56 * (int)definition);
                Bitmap pageImage = pdfFile.GetPageImage(i - 1, resolution);
                if (!Directory.Exists(imageOutputPath))
                    Directory.CreateDirectory(imageOutputPath + "\\images");
                pageImage.Save(imageOutputPath + "\\" + imageName + i.ToString() + "." + imageFormat.ToString(), imageFormat);
                DATA.OriginalImages.Add(new Bitmap(imageOutputPath + "\\" + imageName + i.ToString() + "." + imageFormat.ToString()));

                pageImage.Dispose();
                Console.WriteLine($"page {i} converted, width:{DATA.OriginalImages[i-1].Width} height:{DATA.OriginalImages[i - 1].Height}");
            }
            //foreach (var item in DATA.OriginalImages)
            //{
            //    DATA.AnnotatedImages.Add(item);
            //}
            //DATA.AnnotatedImages = DATA.OriginalImages;
           
            pdfFile.Dispose();
            Console.WriteLine("Done!");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Drawing.Text;
using System.Threading;
using System.Runtime.InteropServices.ComTypes;
using System.Configuration;
using System.Threading.Tasks;
using Squirrel;
using System.Diagnostics;

namespace PDF_Marker_New
{
    public partial class FrmMain : Form
    {
        bool ctScore = false;
        int pageIndex = 0;
        int xf = 0; //fraction from 1000
        int yf = 0;
        char annotationType = 'C';
        string score = "1";      
        List<Pages> pages;
        List<Annotation> ticks = new List<Annotation>();
        //bool placingFinal = false;
        Point hover = new Point(0, 0);
        Font drawFont = new Font("Arial", 14);
        Font drawFontL = new Font("Arial", 24);
        Font textFont = new Font("Arial", 14);
        SolidBrush drawBrush = new SolidBrush(System.Drawing.Color.Red);
        SolidBrush drawBrush_selected = new SolidBrush(System.Drawing.Color.Blue);
        public static bool isSaved = true;
        System.Drawing.Image imageFile;
        public FrmMain()
        {
            InitializeComponent();
            
            DATA.pageCount = 0;

            AddVersionNumber();

            CheckForUpdate();
        }

        private void AddVersionNumber()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);

            this.Text += $" v.{versionInfo.FileVersion}"; 
        }

        private async Task CheckForUpdate()
        {
            using (var manager = new UpdateManager(@"C:\Temp\Releases"))
            {
                var updates = await manager.CheckForUpdate();
                string msg= "";
                foreach (var item in updates.ReleasesToApply)
                {
                    msg += ($"Releases:{item}\n");
                }
                MessageBox.Show(msg);
                //if (updates.ReleasesToApply.Any())
                //{
                //    MessageBox.Show("Update is available. Continue to update?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //    var lastVersion = updates.ReleasesToApply.OrderBy(x => x.Version).Last();

                //    await manager.DownloadReleases(updates.ReleasesToApply);
                //    await manager.ApplyReleases(updates);
                    
                //    //var latestExe = Path.Combine(manager.RootAppDirectory, string.Concat("app-", lastVersion.Version), "NoelPush.exe");
                //    manager.Dispose();

                //    //RestartAppEvent();
                //    //UpdateManager.RestartApp(latestExe);
                //}
                manager.Dispose();
                //res = MessageBox.Show("Update is available. Continue to update?","Update",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                //if(res == DialogResult.Yes)
                //await manager.UpdateApp();
                //Run "Squirrel --releasify PDF_Marker_New.1.0.0.nupkg" in Package Manager console to create setup files
                //Copy files to "C:\Temp\Releases"
            }
        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show($"{e.KeyValue},{e.KeyCode},{e.KeyData}");
            int n = e.KeyValue - 48;
            if(!ctScore)
            {
                score = "";
                ctScore = true;
            }                
            if (n > -1 && n < 10)
                score += n.ToString();
            if (score.Length > 2)
                score = "";
            if(e.KeyCode == Keys.Delete)
            {
                DeteleTicks();
            }
            else if (e.KeyCode == Keys.S)
            {
                annotationType = 'S';
            }
            else if (e.KeyCode == Keys.T)
            {
                annotationType = 'T';
            }
            else if (e.KeyCode == Keys.C)
            {
                annotationType = 'C';
            }
            else if (e.KeyCode == Keys.W)
            {
                annotationType = 'I';
            }
            pbPage.Refresh();
        }

        private void tbtnOpen_Click(object sender, EventArgs e)
        {
            OpenPDF();
        }

        private void OpenPDF()
        {
            if (!isSaved)
            {
                DialogResult res = MessageBox.Show("Document not saved. Ignore and continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    //ConfigurationSettings.AppSettings.Set("exitNopen","true");
                    //Application.Restart();
                    //Environment.Exit(0);
                    //imageFile = System.Drawing.Image.FromFile($".\\Stamps\\page5.Jpeg");
                    OFD();
                }
            }
            else
            {
                OFD();
            }
            
        }

        private void OFD()
        {
            isSaved = false;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PDF Files | *.pdf";
            ofd.DefaultExt = "pdf";
            DialogResult response = ofd.ShowDialog();
            DATA.fileName = Path.GetFileName(ofd.FileName);
            if (response == DialogResult.OK)
            {
                DATA.panelWidth = pnlPage.Width;
                DATA.sourcePDFpath = ofd.FileName;
                DATA.sourceImageDirpath = ".//Images";
                //this.Text = $"PDF Assignment Grader - {DATA.fileName}*";
                Console.WriteLine(ofd.FileName);
                Console.WriteLine(Path.GetDirectoryName(ofd.FileName));
                try
                {
                    PDF2IMG.ConvertPDF2Image(DATA.sourcePDFpath, DATA.sourceImageDirpath, "page", ImageFormat.Jpeg);
                }
                catch (Exception)
                {
                    //throw;
                }
                ticks = new List<Annotation>();
                pages = new List<Pages>();
                DATA.finalScore = 0;
                for (int i = 0; i < DATA.pageCount; i++)
                {
                    Pages p = new Pages();
                    pages.Add(p);
                }
                ViewPage();
            }
        }
        private void pbPage_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int numberOfTextLinesToMove = e.Delta * SystemInformation.MouseWheelScrollLines / 30;
            Console.WriteLine($"Hit{numberOfTextLinesToMove}");
            if (vScrollBar1.Value - numberOfTextLinesToMove >= 0 && vScrollBar1.Value - numberOfTextLinesToMove <= vScrollBar1.Maximum)
            {
                vScrollBar1.Value -= numberOfTextLinesToMove;
                pbPage.Location = new Point(pbPage.Location.X, -1 * vScrollBar1.Value);
                Draw();
            }
        }

        private void ViewPage()
        {
            vScrollBar1.Maximum = DATA.OriginalImages[pageIndex].Height - pnlPage.Height;
            txtPage.Text = $"{pageIndex + 1} of {DATA.pageCount}";
            pbPage.Location = new Point(0, 0);
            vScrollBar1.Value = 0;
            ticks.Clear();
            if (pages[pageIndex].tick != null)
                ticks.AddRange(pages[pageIndex].tick);
            Draw();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            pbPage.Location = new Point(pbPage.Location.X, -1 * vScrollBar1.Value);
            Draw();
        }

        private void Draw()
        {
            int x = 0, y = 0;

            if (true)//paintEnabled && DATA.OriginalImages != null)
            {
                // Create image.
                imageFile = System.Drawing.Image.FromFile($"{DATA.sourceImageDirpath}\\page{pageIndex+1}.Jpeg");//DATA.OriginalImages[pageIndex];//

                // Create graphics object for alteration.
                Graphics newGraphics = Graphics.FromImage(imageFile);
                foreach (var item in ticks)
                {
                    x = (item.x * DATA.OriginalImages[pageIndex].Width) / 1000;
                    y = (item.y * DATA.OriginalImages[pageIndex].Height) / 1000 - PDF.iHeight / 2;
                    if (!item.isSelceted)
                    {
                        if (item.Type == 'C')
                            newGraphics.DrawImage(Properties.Resources.correct, x, y, PDF.iWidth, PDF.iHeight);
                        else if (item.Type == 'I')
                            newGraphics.DrawImage(Properties.Resources.wrong, x, y, PDF.iWidth, PDF.iHeight);
                        else
                            newGraphics.DrawString(item.text, textFont, drawBrush, x, y + PDF.iHeight/2);
                        if ((item.Type == 'C' || item.Type == 'I') && item.text != "")
                            newGraphics.DrawString($"({item.text})", drawFont, drawBrush, x + PDF.iWidth, y + PDF.iHeight / 2);
                    }
                    else//if selected
                    {
                        if (item.Type == 'C')
                            newGraphics.DrawImage(Properties.Resources.correct_selected, x, y, PDF.iWidth, PDF.iHeight);
                        else if (item.Type == 'I')
                            newGraphics.DrawImage(Properties.Resources.wrong_selected, x, y, PDF.iWidth, PDF.iHeight);
                        else
                            newGraphics.DrawString(item.text, textFont, drawBrush_selected, x, y + PDF.iHeight/2);
                        if ((item.Type == 'C' || item.Type == 'I') && item.text !="")
                            newGraphics.DrawString($"({item.text})", drawFont, drawBrush_selected, x + PDF.iWidth, y + PDF.iHeight / 2);
                    }
                }

                if (pageIndex == 0)
                {
                    x = (PDF.fScoreOrigin.X * DATA.OriginalImages[pageIndex].Width) / 1000;
                    y = (PDF.fScoreOrigin.Y * DATA.OriginalImages[pageIndex].Height) / 1000;
                    newGraphics.DrawString($"{DATA.finalScore}", drawFont, drawBrush, x, y);
                    newGraphics.DrawString($"------", drawFont, drawBrush, x, y + 16);
                    newGraphics.DrawString($"{DATA.outOf}", drawFont, drawBrush, x, y + 40);
                }                
                //DATA.AnnotatedImages[pageIndex] = (Bitmap)imageFile;
                pbPage.Image = (Bitmap)imageFile;
                newGraphics.Dispose();
                //pbPage.Invalidate();
                pbPage.Refresh();
            }
        }

        private void pbPage_Paint(object sender, PaintEventArgs e)
        {
                if (annotationType == 'C')
                    e.Graphics.DrawImage(Properties.Resources.correct, hover.X, hover.Y - PDF.iHeight / 2, PDF.iWidth, PDF.iHeight);
                else if (annotationType == 'I')
                    e.Graphics.DrawImage(Properties.Resources.wrong, hover.X, hover.Y - PDF.iHeight / 2, PDF.iWidth, PDF.iHeight);
                else if(annotationType == 'M')
                {
                    e.Graphics.DrawString($"{DATA.finalScore}", drawFontL, drawBrush, hover.X, hover.Y);
                    e.Graphics.DrawString($"------", drawFontL, drawBrush, hover.X, hover.Y + 16);
                    e.Graphics.DrawString($"{DATA.outOf}", drawFontL, drawBrush, hover.X, hover.Y + 40);
                }

                if ((annotationType == 'C' || annotationType == 'I') && score != "")
                    e.Graphics.DrawString($"({score})", drawFontL, drawBrush, hover.X + PDF.iWidth, hover.Y);
        }

        private void tbtnPrev_Click(object sender, EventArgs e)
        {
            if (pageIndex - 1 >= 0)
            {
                pageIndex -= 1;
                ViewPage();
            }
                
        }

        private void tbtnNext_Click(object sender, EventArgs e)
        {
            if (pageIndex + 1 <= DATA.pageCount - 1) 
            {
                pageIndex += 1;
                ViewPage();
            }
                
        }

        private void tbtnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF Files | *.pdf";
            sfd.DefaultExt = "pdf";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                DATA.fileName = Path.GetFileName(sfd.FileName);
                PDF.Export(sfd.FileName, pages.ToArray());
                //this.Text = $"PDF Assignment Grader - {Path.GetFileName(DATA.fileName)}";
            }
        }        

        private void pbPage_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void AddTick()
        {
            Annotation tick = new Annotation();
            tick.Type = annotationType;
            if(annotationType == 'T')
                tick.text = DATA.Comment;
            else
            {
                tick.text = score;
                ctScore = false;
            }
                
            tick.x = xf;
            tick.y = yf;
            tick.isSelceted = false;
            ticks.Add(tick);
            if (pages != null)
            {
                pages[pageIndex].tick = ticks.ToArray();
            }
            DATA.finalScore = 0;
            for (int i = 1; i <= DATA.pageCount; i++)
            {
                if (pages[i - 1].tick != null)
                {
                    foreach (var item in pages[i - 1].tick)
                    {
                        if (item.text != "" && item.Type != 'T')
                        {
                            double val = 0;
                            if (Double.TryParse(item.text, out val))
                            {
                                DATA.finalScore += val;
                                txtScore.Text = DATA.finalScore.ToString();                                
                            }
                            else
                            {
                                MessageBox.Show("Marks must be a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                ticks.RemoveAt(ticks.Count - 1);
                            }

                        }
                    }
                    if (DATA.finalScore > DATA.outOf)
                        MessageBox.Show("Total score is over the maximum value!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void pbPage_MouseMove(object sender, MouseEventArgs e)
        {
            hover.X = e.X;
            hover.Y = e.Y;
            if(annotationType == 'S')
                pbPage.Cursor = Cursors.Hand;
            else if(annotationType == 'T')
                pbPage.Cursor = Cursors.IBeam;
            else if (annotationType == 'C' || annotationType == 'I')
                pbPage.Cursor = Cursors.Cross;
            else
                pbPage.Cursor = Cursors.Default;
            pbPage.Refresh();
        }

        private void tbtnCorrect_Click(object sender, EventArgs e)
        {
            annotationType = 'C';
        }

        private void tbtnWrong_Click(object sender, EventArgs e)
        {
            annotationType = 'I';
        }

        private void tbtnText_Click(object sender, EventArgs e)
        {
            annotationType = 'T';
        }

        private void tbtnDelete_Click(object sender, EventArgs e)
        {
            DeteleTicks();
        }

        private void DeteleTicks()
        {
            ticks = ticks.Where(c => !c.isSelceted).ToList<Annotation>();
            if (pages != null)
            {
                pages[pageIndex].tick = ticks.ToArray();
            }
            CalculateFinalScore();
            Draw();
        }

        private void CalculateFinalScore()
        {
            DATA.finalScore = 0;
            for (int i = 1; i <= DATA.pageCount; i++)
            {
                if (pages[i - 1].tick != null)
                {
                    foreach (var item in pages[i - 1].tick)
                    {
                        if (item.text != "" && item.Type != 'T')
                        {
                            DATA.finalScore += Convert.ToDouble(item.text);
                            txtScore.Text = DATA.finalScore.ToString();
                        }
                    }
                }
            }
        }

        private void tbtnSelect_Click(object sender, EventArgs e)
        {
            annotationType = 'S';

        }

        private void pbPage_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && DATA.OriginalImages != null)
            {
                xf = (e.X * 1000) / DATA.OriginalImages[pageIndex].Width;
                yf = (e.Y * 1000) / DATA.OriginalImages[pageIndex].Height;
                if (annotationType == 'S')
                {
                    for (int i = 0; i < ticks.Count; i++)
                    {
                        int x = (ticks[i].x * DATA.OriginalImages[pageIndex].Width) / 1000;
                        int y = (ticks[i].y * DATA.OriginalImages[pageIndex].Height) / 1000;
                        if (e.X > x && e.X < x + PDF.iHeight / 2)
                            if (e.Y > y && e.Y < y + PDF.iHeight / 2)
                            {
                                if (!ticks[i].isSelceted)
                                {
                                    ticks[i].isSelceted = true;
                                }
                                else
                                {
                                    ticks[i].isSelceted = false;
                                }
                                break;
                            }
                    }
                }
                else if (annotationType == 'T')
                {
                    //Create an instance of your dialog form
                    TextForm testDialog = new TextForm();
                    testDialog.Location = new Point(e.X, e.Y + testDialog.Height / 2);
                    testDialog.StartPosition = FormStartPosition.Manual;

                    // Show testDialog as a modal dialog and determine if DialogResult = OK.
                    if (testDialog.ShowDialog(this) == DialogResult.OK)
                    {
                        AddTick();
                    }
                }
                else if (annotationType == 'M')
                {
                    PDF.fScoreOrigin = new Point(xf, yf);                    
                }
                else
                {
                    AddTick();
                }
                Draw();
            }
            else if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(this, new Point(e.X, e.Y));
            }
        }

        private void moveFinalScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            annotationType = 'M';
        }

        private void addCorrectMarkerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            annotationType = 'C';
        }

        private void addIncorrectMarkerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            annotationType = 'I';
        }

        private void addCommentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            annotationType = 'T';
            
        }

        private void selectAnnotationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            annotationType = 'S';
        }

        private void deleteSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeteleTicks();
        }

        private void pbPage_MouseLeave(object sender, EventArgs e)
        {
            pbPage.Cursor = Cursors.Default;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenPDF();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                DATA.fileName = Path.GetFileName(sfd.FileName);
                PDF.Export(sfd.FileName, pages.ToArray());
                //this.Text = $"PDF Assignment Grader - {Path.GetFileName(DATA.fileName)}";
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtScore_TextChanged(object sender, EventArgs e)
        {
            Double value;
            if(Double.TryParse(txtScore.Text, out value))
                DATA.finalScore = value;            
        }

        private void txtFullScore_TextChanged(object sender, EventArgs e)
        {
            Int16 value;
            if (Int16.TryParse(txtFullScore.Text, out value))
                DATA.outOf = value;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isSaved)
            {
                DialogResult res = MessageBox.Show("Document not saved. Ignore and quit?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.No)
                    e.Cancel = true;
            }            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Hello");
            Console.WriteLine(ConfigurationSettings.AppSettings.Get("exitNopen"));
            if (ConfigurationSettings.AppSettings.Get("exitNopen") == "true")
                OFD();
            ConfigurationSettings.AppSettings.Set("exitNopen", "false");
        }
    }
}

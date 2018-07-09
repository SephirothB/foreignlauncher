using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;
using Ionic.Zip;

namespace Launcher
{
    public partial class Main : Form
    {
        /// <summary>
        /// Server launcher version
        /// </summary>
        private string sVersion;

        /// <summary>
        /// Client launcher version
        /// </summary>
        private string lVersion;

        /// <summary>
        /// Root to current dir
        /// </summary>
        private string Root = AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// Server Update URL
        /// </summary>
        private const string ServerUpdate = "http://127.0.0.1/foreignweb/updates/";

        /// <summary>
        /// Server XML Updates file
        /// </summary>
        XDocument serverXml = null;
  

        /// <summary>
        /// Windows form const
        /// </summary>
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        /// <summary>
        /// External dll function SendMessage for winengine
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="Msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImportAttribute("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        /// <summary>
        /// External dll function to gather wheter we unlock left mouse
        /// </summary>
        /// <returns></returns>
        [DllImportAttribute("user32.dll")]
        private static extern bool ReleaseCapture();

        /// <summary>
        /// Initializes every data,bind and validation needed
        /// </summary>
        public Main()
        {
            InitializeComponent();
            IsProcessRunning();       
            CheckIonic();
         
            this.strtGameBtn.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            this.strtGameBtn.MouseEnter += new System.EventHandler(this.button1_MouseEnter);


            backgroundWorker1.RunWorkerAsync();
            progressBar1.Value = 0;
            downloadLbl.Visible = true;
            strtGameBtn.Enabled = false;
            playHint.Visible = false;
        }


        /// <summary>
        /// Handles the form moveable delegation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        /// <summary>
        /// Does the dirty work by checking if we have updates and if we do http request the server and download,extract and delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            CheckForIllegalCrossThreadCalls = false;
            try
            {
                // Try loading the xml file
                try
                {
                    serverXml = XDocument.Load(ServerUpdate + "Updates.xml");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error retriving the list of updates from the update server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                FileStream fs = null;
                if (!File.Exists("version"))
                {
                    using (fs = File.Create("version")) { } // create file
                    using (StreamWriter sw = new StreamWriter("version"))
                    {
                        sw.Write("1.0");
                    }
                }

                string lclVersion;
                using (StreamReader reader = new StreamReader("version"))
                {
                    lclVersion = reader.ReadLine();
                    lVersion = lclVersion;

                }
                Version localVersion = new Version(lclVersion);

                foreach (XElement update in serverXml.Descendants("update"))
                {
                    string version = update.Element("version").Value;
                    string file = update.Element("file").Value;

                    //decimal serverVersion = decimal.Parse(version);
                    Version serverVersion = new Version(version);
                    string sUrlToReadFileFrom = ServerUpdate + file;
                    string sFilePathToWriteFileTo = Root + file;

                    sVersion = version;
                    

                    if (serverVersion > localVersion)
                    {
                        Uri url = new Uri(sUrlToReadFileFrom);
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        response.Close();

                        Int64 iSize = response.ContentLength;
                        Int64 iRunningByteTotal = 0;


                        using (WebClient client = new WebClient())
                        {
                            using (Stream streamRemote = client.OpenRead(new Uri(sUrlToReadFileFrom)))
                            {
                                using (Stream streamLocal = new FileStream(sFilePathToWriteFileTo, FileMode.Create, FileAccess.Write, FileShare.None))
                                {

                                    int iByteSize = 0;
                                    byte[] byteBuffer = new byte[iSize];
                                    while ((iByteSize = streamRemote.Read(byteBuffer, 0, byteBuffer.Length)) > 0)
                                    {
                                        streamLocal.Write(byteBuffer, 0, iByteSize);
                                        iRunningByteTotal += iByteSize;

                                        double dIndex = iRunningByteTotal;
                                        double dTotal = byteBuffer.Length;
                                        double dProgressPercentage = (dIndex / dTotal);
                                        int iProgressPercentage = (int)(dProgressPercentage * 100);

                                        backgroundWorker1.ReportProgress(iProgressPercentage);
                                    }
                                    streamLocal.Close();
                                }
                                streamRemote.Close();
                            }
                        }

                        
                        using (ZipFile zip = ZipFile.Read(file))
                        {
                            int totalFiles = zip.Count;
                            foreach (ZipEntry zipFiles in zip)
                            {
                                zipFiles.Extract(Root, true);
                                
                                zip.ExtractProgress += (o,args) =>
                                {
                                    var percentage = Math.Round( (double)(1.0d / args.TotalBytesToTransfer * args.BytesTransferred * 100.0d),1);
                                    if (percentage <= 0 || percentage.ToString() == "NaN")
                                        percentage = 0;
 
                                    downloadLbl.Text = $"Extracting {totalFiles} files... ({percentage}%)";
                                };
                            }
                        }

                        using (StreamWriter sw = new StreamWriter("version"))
                        {
                            sw.Write(sVersion);
                            lVersion = sVersion;
                            downloadLbl.Text = "Updating version file...";
                        }

                        deleteFile(file);
                        downloadLbl.Text = "Cleaning update files...";
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// When some work changes, we update the bar value and % text label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            dlPercentage.Text = e.ProgressPercentage + "%";

        }

        /// <summary>
        /// When the work is complete set everyback back to normal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            strtGameBtn.Image = Properties.Resources.button_play_hover;
            strtGameBtn.Enabled = true;
            strtGameBtn.Cursor = Cursors.Default;
            dlPercentage.Text = "100% ";
            downloadLbl.Visible = false;
            gameVersion.Text = "ver " + sVersion ;
            progressBar1.Value = 100;
            playHint.Visible = true;
        }

        /// <summary>
        /// Handles the start game click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void strtGameBtn_Click_1(object sender, EventArgs e)
        {
            //Dispose the streamwriter after write the version
            using (StreamWriter check = new StreamWriter("version"))
            {
                check.Write(sVersion);

            }

            if (lVersion != sVersion)
            {
                downloadLbl.Text = "You need to repair your client!";
                MessageBox.Show("Server and Client versions does not match, please delete version file and re-open launcher!","Version does not match", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }


            if (!File.Exists(Root +  @"\ForeignSword.exe"))
            {
                MessageBox.Show("Please make sure you have 'ForeignSword.exe' to be able to start the game.", "Make sure you have the game executable",MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else
            {
                //Starts the game
                Process.Start(Root + @"\ForeignSword.exe");
            }

        }


        /// <summary>
        /// Closes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeBtn_Click(object sender, EventArgs e) => Close();

        /// <summary>
        /// Deletes the files (used after extract the file)
        /// </summary>
        /// <param name="f"></param>
        /// <returns>boolean</returns>
        private static bool deleteFile(string f)
        {
            try
            {
                File.Delete(f);
                return true;
            }
            catch (IOException)
            {
                return false;
            }
        }

        /// <summary>
        /// Button1 mouse enter event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            strtGameBtn.Cursor = Cursors.Hand;
            strtGameBtn.Image = Properties.Resources.button_play_hover;
        }

        /// <summary>
        /// Handles button1 mouse leave event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void button1_MouseLeave(object sender, EventArgs e) => strtGameBtn.Image = Properties.Resources.button_play_normal;



        /// <summary>
        /// Is foreignsword process running?
        /// </summary>
        private void IsProcessRunning()
        {
            Process[] p = Process.GetProcessesByName("foreignsword");

            if (p.Length > 0)
            {
                MessageBox.Show("ForeignSword is already running! \n Close your game and run again the launcher", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);

            }
        }

        /// <summary>
        /// Make sure our zip dll is on 
        /// </summary>
        private void CheckIonic()
        {
            if (!File.Exists("Ionic.Zip.dll"))
            {
                MessageBox.Show("Ionic.Zip.dll not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
        }

        /// <summary>
        /// Prompts to close the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeLbl_Click(object sender, EventArgs e) => new Asktoclose().ShowDialog();

        /// <summary>
        /// Minimizes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void minLbl_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;

    }
}
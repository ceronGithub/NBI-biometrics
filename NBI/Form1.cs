using SourceAFIS;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.DirectoryServices.ActiveDirectory;
using System.Diagnostics.Eventing.Reader;
using static System.Net.Mime.MediaTypeNames;
using Google.Protobuf.WellKnownTypes;

namespace NBI
{
    public partial class Form1 : Form
    {
        //convertion of roman numerals
        Regex IntContaines = new Regex("^-?\\d*(\\.\\d+)?$");

        int snameNumber = 0;

        //Date
        DateTime nowDate = DateTime.Today;

        //address enter validation
        bool txtAddress = false, forEdit = false;

        // default on creating NBI folder
        string newDefaultPath = "";
        string previousDefaultPath = "";
        string defaultFilePath = @"" + Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Desktop\\NBI";

        //calling class
        QueryCRUD CRUD = new QueryCRUD();
        AutomaticFileReallocation COPYFILE = new AutomaticFileReallocation();
        RomanNumeralsConvertion romanNumeralsConvertion = new RomanNumeralsConvertion();
        RegexFieldChecker regexChecker = new RegexFieldChecker();
        CapitalizeEachFirstLetterWord UpperCaseEachFirstLetterWord = new CapitalizeEachFirstLetterWord();
        ZipcodeKeypress zipcodeLogic = new ZipcodeKeypress();

        public string newGeneralFilePath = "";
        public string sex = "";

        // File name
        public string leftHandFileName = "";
        public string rightHandFileName = "";
        public string leftThumbFileName = "";
        public string rightThumbFileName = "";
        public string leftEyeFileName = "";
        public string rightEyeFileName = "";
        public string documentFileName = "";
        public string idFileName = "";
        public string signatureFileName = "";

        // File path
        public string leftHandFilePath = "";
        public string rightHandFilePath = "";
        public string leftThumbFilePath = "";
        public string rightThumbFilePath = "";
        public string leftEyeFilePath = "";
        public string rightEyeFilePath = "";
        public string documentFilePath = "";
        public string idFilePath = "";
        public string signatureFilePath = "";

        // File Extensions
        public string leftHandExtension = "";
        public string rightHandExtension = "";
        public string leftThumbExtension = "";
        public string rightThumbExtension = "";
        public string leftEyeExtension = "";
        public string rightEyeExtension = "";
        public string documentExtension = "";
        public string idExtension = "";
        public string signatureExtension = "";

        //device path location
        public string fingerPrintScanningLocation = "";
        public string irisScanningLocation = "";
        public string documentScanningLocation = "";
        public string cameraLocation = "";
        public string signatureLocation = "";


        //registration
        int countingTime = 0, loadingTime = 0;
        bool FingerFolderCreated, IrisFolderCreate, IsDatabaseConnected;
        string LeftHand, RightHand, LeftThumb, RightThumb, LeftEye, RightEye, Document, ID, Signature, IsAccountExisting1stChecking, IsAccountExisting2ndChecking;
        string birthDate = "";
        string[] wholeAddress;
        string barangay = "", address = "", zipCode = "";

        DialogResult dialog;

        public Form1()
        {
            InitializeComponent();
            //restart the timer for registration
            if (countingTime != 0)
            {
                timerToEnableRegisterBtn.Start();
            }

            //auto create NBI folder
            if (!Directory.Exists(defaultFilePath))
            {
                // Create folder
                Directory.CreateDirectory(defaultFilePath);
            }
            else
            {
                // NBI folder is existing.
                //MessageBox.Show("NBI FOLDER ALREADY EXISTING");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //checks database connection, if connected, or not.
            IsDatabaseConnected = CRUD.testConnection();
            if (IsDatabaseConnected == true)
            {

                buttonClear.Enabled = true;
                buttonRegister.Enabled = true;
                groupBox1.Enabled = true;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
                menuToolStripMenuItem.Enabled = true;
            }
            else
            {
                MessageBox.Show("Cannot proceed because database connection is closed!.");
                buttonClear.Enabled = false;
                buttonRegister.Enabled = false;
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
                menuToolStripMenuItem.Enabled = false;
            }

            timerToEnableRegisterBtn.Start();
            buttonRegister.Enabled = false;
            groupBox3.Enabled = true;
            groupBox2.Enabled = false;

            comboBoxSex.SelectedIndex = -1;
            if (comboBoxSex.SelectedIndex == -1)
            {
                comboBoxSex.SelectedText = "Select sex";
            }
            // set the datetimepicker to today            
            DatePickerDateOrBirth.MinDate = DateTimePicker.MinimumDateTime;
            DatePickerDateOrBirth.MaxDate = nowDate;
            DatePickerDateOrBirth.Value = nowDate;
            // customize the date picker format
            DatePickerDateOrBirth.Format = DateTimePickerFormat.Custom;
            DatePickerDateOrBirth.CustomFormat = " yyyy / MM / dd ";

            textBox1.Visible = false;
            textBox2.Visible = false;

            label8.Text = DateTime.Now.ToLongTimeString();
            label9.Text = DateTime.Now.ToLongDateString();

            buttonRegister.Text = "...";

            textBoxFname.PlaceholderText = "Please Input First Name";
            textBoxMname.PlaceholderText = "Please Input Middle Name";
            textBoxLname.PlaceholderText = "Please Input Last Name";
            textBoxSname.PlaceholderText = "-";
            textBoxAddress.PlaceholderText = "Please Input Address";
            textBoxMunicipality.PlaceholderText = "Please Input City or Municipality";
            textBoxBarangay.PlaceholderText = "Please Input Barangay";
            textBoxZipcode.PlaceholderText = "Please Input Zip Code (accepts only : 6 digits)";
        }
        private void timerClock_Tick(object sender, EventArgs e)
        {
            label8.Text = DateTime.Now.ToLongTimeString();
            timerClock.Start();
        }
        private void textBoxFname_Leave(object sender, EventArgs e)
        {
            string regexResult;
            if (textBoxFname.Text != "")
            {
                regexResult = regexChecker.NameFieldChecker(textBoxFname.Text);
                if (regexResult != null && regexResult != "reset")
                {
                    textBoxFname.Text = regexResult;
                }
                else
                {
                    textBoxFname.Text = "";
                    textBoxFname.PlaceholderText = "Please Input First Name";
                }
            }
            else
            {
                textBoxFname.PlaceholderText = "Please Input First Name";
            }
        }
        private void textBoxMname_Leave(object sender, EventArgs e)
        {
            string regexResult;
            if (textBoxMname.Text != "")
            {
                regexResult = regexChecker.NameFieldChecker(textBoxMname.Text);
                if (regexResult != null && regexResult != "reset")
                {
                    textBoxMname.Text = regexResult;
                }
                else
                {
                    textBoxMname.Text = "";
                    textBoxMname.PlaceholderText = "Please Input Middle Name";
                }
            }
            else
            {
                //textBoxMname.PlaceholderText = "Please Input Middle Name";
                textBoxMname.Text = "-";
            }
        }
        private void textBoxLname_Leave(object sender, EventArgs e)
        {
            string regexResult;
            if (textBoxLname.Text != "")
            {
                regexResult = regexChecker.NameFieldChecker(textBoxLname.Text);
                if (regexResult != null && regexResult != "reset")
                {
                    textBoxLname.Text = regexResult;
                }
                else
                {
                    textBoxLname.Text = "";
                    textBoxLname.PlaceholderText = "Please Input Last Name";
                }
            }
            else
            {
                textBoxLname.PlaceholderText = "Please Input Last Name";
            }
        }
        private void textBoxSname_Leave(object sender, EventArgs e)
        {
            if (textBoxSname.Text != "")
            {
                if (textBoxSname.Text.Contains("sr") || textBoxSname.Text.Contains("jr"))
                {
                    string text = textBoxSname.Text;
                    string firstletterofeachword = UpperCaseEachFirstLetterWord.CapitalizeFirstLetterOfTheWord(textBoxSname.Text);
                    textBoxSname.Text = firstletterofeachword;
                }
                else if (IntContaines.IsMatch(textBoxSname.Text))
                {
                    try
                    {
                        snameNumber = int.Parse(textBoxSname.Text);
                        textBoxSname.Text = romanNumeralsConvertion.Convertion(snameNumber);
                    }
                    catch (Exception ex)
                    {
                        textBoxSname.PlaceholderText = "-";
                    }
                }
                else
                {
                    textBoxSname.Text = "-";
                }
            }
            else
            {
                textBoxSname.Text = "-";
            }
        }
        private void textBoxAddress_Leave(object sender, EventArgs e)
        {
            string regexResult;
            if (textBoxAddress.Text != "")
            {
                regexResult = regexChecker.AddressFieldChecker(textBoxAddress.Text);
                if (regexResult != null && regexResult != "reset")
                {
                    textBoxAddress.Text = regexResult;
                }
                else
                {
                    textBoxAddress.Text = "";
                    textBoxAddress.PlaceholderText = "Please Input Address";
                }
            }
            else
            {
                textBoxAddress.PlaceholderText = "Please Input Address";
            }
        }
        private void textBoxMunicipality_Leave(object sender, EventArgs e)
        {
            string regexResult;
            if (textBoxMunicipality.Text != "")
            {
                regexResult = regexChecker.AddressFieldChecker(textBoxMunicipality.Text);
                if (regexResult != null && regexResult != "reset")
                {
                    textBoxMunicipality.Text = regexResult;
                }
                else
                {
                    textBoxMunicipality.Text = "";
                    textBoxMunicipality.PlaceholderText = "Please Input City or Municipality";
                }
            }
            else
            {
                textBoxMunicipality.PlaceholderText = "Please Input City or Municipality";
            }
        }
        private void textBoxBarangay_Leave(object sender, EventArgs e)
        {
            string regexResult;
            if (textBoxBarangay.Text != "")
            {
                regexResult = regexChecker.AddressFieldChecker(textBoxBarangay.Text);
                if (regexResult != null && regexResult != "reset")
                {
                    textBoxBarangay.Text = regexResult;
                }
                else
                {
                    textBoxBarangay.Text = "";
                    textBoxBarangay.PlaceholderText = "Please Input Barangay";
                }
            }
            else
            {
                textBoxBarangay.PlaceholderText = "Please Input Barangay";
            }
        }
        private void textBoxZipcode_Leave(object sender, EventArgs e)
        {
            string result;
            if (textBoxZipcode.Text != "")
            {
                result = zipcodeLogic.zipcodeLogic(textBoxZipcode.Text);
                if (result != null && result != "reset")
                {
                    textBoxZipcode.Text = result;
                }
                else
                {
                    textBoxZipcode.Text = "";
                    textBoxZipcode.PlaceholderText = "Please Input Zip Code (accepts only : 6 digits)";

                }
            }
            else
            {
                textBoxZipcode.PlaceholderText = "Please Input Zip Code (accepts only : 6 digits)";
            }
        }
        //=============================== Start : limit textbox to accept certain string only ========================
        private void textBoxZipcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == (char)Keys.Enter)
            {
                string result;
                if (textBoxZipcode.Text != "")
                {
                    result = zipcodeLogic.zipcodeLogic(textBoxZipcode.Text);
                    if (result != null && result != "reset")
                    {
                        textBoxZipcode.Text = result;
                    }
                    else
                    {
                        textBoxZipcode.Text = "";
                        textBoxZipcode.PlaceholderText = "Please Input Zip Code (accepts only : 6 digits)";

                    }
                }
                else
                {
                    textBoxZipcode.PlaceholderText = "Please Input Zip Code (accepts only : 6 digits)";
                }
            }
        }
        //=============================== Start : limit textbox to accept certain string only ========================        
        private void textBoxAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAddress = true;
            }
        }
        private void listOfUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }
        private void fingerScanningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fingerPrintScanningLocation == string.Empty)
            {
                MessageBox.Show("C:\\Program Files (x86)\\Suprema\\RealScan\\SDK V1.8.5\\bin\\RealScanUICSharp.exe");
            }
            else
            {
                MessageBox.Show(fingerPrintScanningLocation);
            }
        }
        private void irisScanningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (irisScanningLocation == string.Empty)
            {
                MessageBox.Show("C:\\Program Files (x86)\\IriTech\\IriSmartEye 2000\\IriSmartEye2000.exe");
            }
            else
            {
                MessageBox.Show(irisScanningLocation);
            }
        }
        private void documentScanningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (documentScanningLocation == string.Empty)
            {
                MessageBox.Show("C:\\Users\\HtechDev\\Downloads\\eloam build\\eloam build\\eloamComDemo\\Release\\eloamComDemo.exe");
            }
            else
            {
                MessageBox.Show(documentScanningLocation);
            }
        }
        private void iDPictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cameraLocation == string.Empty)
            {
                MessageBox.Show("windows camera");
            }
            else
            {
                MessageBox.Show(cameraLocation);
            }
        }
        private void signatureToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (signatureLocation == string.Empty)
            {
                MessageBox.Show("windows paint");
            }
            else
            {
                MessageBox.Show(signatureLocation);
            }
        }
        private void currentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(defaultFilePath);
        }
        private void buttonFingerScanning_Click(object sender, EventArgs e)
        {
            try
            {
                //Process.Start("C:\\Program Files (x86)\\Suprema\\RealScan\\SDK V1.8.5\\bin\\RealScanUICSharp.exe");
                Process proc = new Process();
                if (fingerPrintScanningLocation == string.Empty)
                {
                    proc.StartInfo.FileName = @"C:\\Program Files (x86)\\Suprema\\RealScan\\SDK V1.8.5\\bin\\RealScanUICSharp.exe";
                }
                else
                {
                    proc.StartInfo.FileName = @"" + fingerPrintScanningLocation;
                }
                proc.StartInfo.UseShellExecute = true;
                proc.StartInfo.Verb = "runas";
                proc.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Application scanning is either cannot not be found nor cancel running.");
            }
        }
        private void buttonIrisScanning_Click(object sender, EventArgs e)
        {
            try
            {
                Process proc = new Process();
                if (irisScanningLocation == string.Empty)
                {
                    proc.StartInfo.FileName = @"C:\\Program Files (x86)\\IriTech\\IriSmartEye 2000\\IriSmartEye2000.exe";
                }
                else
                {
                    proc.StartInfo.FileName = @"" + irisScanningLocation;
                }
                proc.StartInfo.UseShellExecute = true;
                proc.StartInfo.Verb = "runas";
                proc.Start();
                //Process.Start("C:\\Program Files (x86)\\IriTech\\IriSmartEye 2000\\IriSmartEye2000.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Application scanning is either cannot not be found nor cancel running.");
            }
        }
        private void buttonDocumentScanning_Click(object sender, EventArgs e)
        {
            try
            {
                Process proc = new Process();
                if (documentScanningLocation == string.Empty)
                {
                    proc.StartInfo.FileName = @"C:\\Users\\HtechDev\\Downloads\\eloam build\\eloam build\\eloamComDemo\\Release\\eloamComDemo.exe";
                }
                else
                {
                    proc.StartInfo.FileName = @"" + documentScanningLocation;
                }
                proc.StartInfo.UseShellExecute = true;
                proc.StartInfo.Verb = "runas";
                proc.Start();
                //Process.Start("C:\\Users\\HtechDev\\Downloads\\eloam build\\eloam build\\eloamComDemo\\Release\\eloamComDemo.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Application scanning is either cannot not be found nor cancel running.");
            }
        }
        private void buttonCamera_Click(object sender, EventArgs e)
        {
            try
            {
                if (cameraLocation == string.Empty)
                {
                    Process.Start("start microsoft.windows.camera:");
                }
                else
                {
                    try
                    {
                        string command = @"" + cameraLocation;
                        System.Diagnostics.Process.Start(command);
                    }
                    catch (Exception ex)
                    {
                        string command = cameraLocation;
                        System.Diagnostics.Process.Start(command);
                    }
                }
                //Process.Start("microsoft.windows.camera:");
                //Process.Start("start microsoft.windows.camera:");
                //Process.Start(@"\Windows\camera.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Camera is either cannot be found nor cancel running.");
            }
        }
        private void buttonSignature_Click(object sender, EventArgs e)
        {
            try
            {
                Process proc = new Process();
                if (signatureLocation == string.Empty)
                {
                    proc.StartInfo.FileName = @"mspaint.exe";
                }
                else
                {
                    proc.StartInfo.FileName = @"" + signatureLocation;
                }
                proc.StartInfo.UseShellExecute = true;
                proc.StartInfo.Verb = "runas";
                proc.Start();
                //Process.Start("C:\\Users\\HtechDev\\Downloads\\eloam build\\eloam build\\eloamComDemo\\Release\\eloamComDemo.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Application scanning is either cannot not be found nor cancel running.");
            }
        }
        private void fileUploaderFingerLeft_Click(object sender, EventArgs e)
        {
            OpenFileDialog BrowseFile = new OpenFileDialog();
            BrowseFile.Title = "Finger Print Left File Uploader";

            if (BrowseFile.ShowDialog() == DialogResult.OK)
            {
                textBox1.Visible = false;

                // file path
                leftHandFilePath = Path.GetFullPath(BrowseFile.FileName);

                // renaming file
                leftHandFileName = textBoxFname.Text + textBoxLname.Text;

                // extension
                leftHandExtension = Path.GetExtension(BrowseFile.FileName);

                if (leftHandExtension == ".JPEG" || leftHandExtension == ".TIFF" || leftHandExtension == ".PNG" || leftHandExtension == ".GIF"
                    || leftHandExtension == ".EPS" || leftHandExtension == ".BMP" || leftHandExtension == ".PSD" || leftHandExtension == ".SVG"
                    || leftHandExtension == ".RAW" || leftHandExtension == ".APNG" || leftHandExtension == ".AI" || leftHandExtension == ".JPG"
                    ||
                    leftHandExtension == ".jpeg" || leftHandExtension == ".tiff" || leftHandExtension == ".png" || leftHandExtension == ".gif"
                    || leftHandExtension == ".eps" || leftHandExtension == ".bmp" || leftHandExtension == ".psd" || leftHandExtension == ".svg"
                    || leftHandExtension == ".raw" || leftHandExtension == ".apng" || leftHandExtension == ".ai" || leftHandExtension == ".jpg")
                {
                    pictureBox1.Image = System.Drawing.Image.FromFile(BrowseFile.FileName);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;                    
                }
                else if (!(leftHandExtension == ".JPEG" || leftHandExtension == ".TIFF" || leftHandExtension == ".PNG" || leftHandExtension == ".GIF"
                    || leftHandExtension == ".EPS" || leftHandExtension == ".BMP" || leftHandExtension == ".PSD" || leftHandExtension == ".SVG"
                    || leftHandExtension == ".RAW" || leftHandExtension == ".APNG" || leftHandExtension == ".AI" || leftHandExtension == ".JPG"
                    ||
                    leftHandExtension == ".jpeg" || leftHandExtension == ".tiff" || leftHandExtension == ".png" || leftHandExtension == ".gif"
                    || leftHandExtension == ".eps" || leftHandExtension == ".bmp" || leftHandExtension == ".psd" || leftHandExtension == ".svg"
                    || leftHandExtension == ".raw" || leftHandExtension == ".apng" || leftHandExtension == ".ai" || leftHandExtension == ".jpg"))
                {
                    pictureBox1.Image = NBI.Properties.Resources.generalDoc;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;


                    //// Extract file information
                    //string str1 = Path.GetFileName(BrowseFile.FileName);
                    //string[] strArr1 = str1.Split('.');
                    //string filePrefix = strArr1[0];

                    //string appPath = AppDomain.CurrentDomain.BaseDirectory;
                    //// Prep and call mindtct - IAFIS
                    //ProcessStartInfo startInfo_IAFIS = new ProcessStartInfo();
                    //startInfo_IAFIS.CreateNoWindow = true;
                    //startInfo_IAFIS.UseShellExecute = false;
                    //startInfo_IAFIS.FileName = appPath + "\\mindtct.exe";
                    //startInfo_IAFIS.WindowStyle = ProcessWindowStyle.Hidden;
                    ////MessageBox.Show(appPath);

                    //Stopwatch Stopwatch = Stopwatch.StartNew();
                    //String timeStamp = Stopwatch.GetTimestamp().ToString();
                    //string FpMVPath = System.IO.Path.GetTempPath() + "BIOMETRICS\\" + timeStamp + "\\";

                    //// Create FpMVPath
                    //if (!Directory.Exists(FpMVPath))
                    //{
                    //    System.IO.Directory.CreateDirectory(FpMVPath);
                    //    if (!Directory.Exists(FpMVPath))
                    //    {
                    //        MessageBox.Show("Can't create directory: " + FpMVPath, "Error Creating Directory!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        this.Close();
                    //    }
                    //}
                    //// Set the min file name
                    //string path = FpMVPath + filePrefix + "_iafis" + ".min";
                    //StreamReader file = new StreamReader(path);

                    //MessageBox.Show(file.ReadLine());
                }
            }
            else /*if (BrowseFile.ShowDialog() == DialogResult.Cancel)*/
            {
                leftHandFilePath = "";
                leftHandFileName = "";
                leftHandExtension = "";
                pictureBox1.Image = null;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        private void fileUploaderFingerRight_Click(object sender, EventArgs e)
        {
            OpenFileDialog BrowseFile = new OpenFileDialog();
            BrowseFile.Title = "Finger Print Left File Uploader";
            if (BrowseFile.ShowDialog() == DialogResult.OK)
            {
                textBox2.Visible = false;

                // file path
                rightHandFilePath = Path.GetFullPath(BrowseFile.FileName);

                // renaming file
                rightHandFileName = textBoxFname.Text + textBoxLname.Text;

                // extension
                rightHandExtension = Path.GetExtension(BrowseFile.FileName);

                if (rightHandExtension == ".JPEG" || rightHandExtension == ".TIFF" || rightHandExtension == ".PNG" || rightHandExtension == ".GIF"
                    || rightHandExtension == ".EPS" || rightHandExtension == ".BMP" || rightHandExtension == ".PSD" || rightHandExtension == ".SVG"
                    || rightHandExtension == ".RAW" || rightHandExtension == ".APNG" || rightHandExtension == ".AI" || rightHandExtension == ".JPG"
                    ||
                    rightHandExtension == ".jpeg" || rightHandExtension == ".tiff" || rightHandExtension == ".png" || rightHandExtension == ".gif"
                    || rightHandExtension == ".eps" || rightHandExtension == ".bmp" || rightHandExtension == ".psd" || rightHandExtension == ".svg"
                    || rightHandExtension == ".raw" || rightHandExtension == ".apng" || rightHandExtension == ".ai" || rightHandExtension == ".jpg")
                {
                    pictureBox2.Image = System.Drawing.Image.FromFile(BrowseFile.FileName);
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else if (!(rightHandExtension == ".JPEG" || rightHandExtension == ".TIFF" || rightHandExtension == ".PNG" || rightHandExtension == ".GIF"
                    || rightHandExtension == ".EPS" || rightHandExtension == ".BMP" || rightHandExtension == ".PSD" || rightHandExtension == ".SVG"
                    || rightHandExtension == ".RAW" || rightHandExtension == ".APNG" || rightHandExtension == ".AI" || rightHandExtension == ".JPG"
                    ||
                    rightHandExtension == ".jpeg" || rightHandExtension == ".tiff" || rightHandExtension == ".png" || rightHandExtension == ".gif"
                    || rightHandExtension == ".eps" || rightHandExtension == ".bmp" || rightHandExtension == ".psd" || rightHandExtension == ".svg"
                    || rightHandExtension == ".raw" || rightHandExtension == ".apng" || rightHandExtension == ".ai" || rightHandExtension == ".jpg"))
                {
                    pictureBox2.Image = NBI.Properties.Resources.generalDoc;
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            else /*if (BrowseFile.ShowDialog() == DialogResult.Cancel)*/
            {
                rightHandFilePath = "";
                rightHandFileName = "";
                rightHandExtension = "";
                pictureBox2.Image = null;
                //Image.FromFile(Path.GetFullPath(@"..\..\..\htect-nbi-data-capture\local-image\document.png"));
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        private void fileUploaderThumbLeft_Click(object sender, EventArgs e)
        {
            OpenFileDialog BrowseFile = new OpenFileDialog();
            BrowseFile.Title = "Finger Print Left File Uploader";
            if (BrowseFile.ShowDialog() == DialogResult.OK)
            {
                // file path
                leftThumbFilePath = Path.GetFullPath(BrowseFile.FileName);

                // renaming file
                leftThumbFileName = textBoxFname.Text + textBoxLname.Text;

                // extension
                leftThumbExtension = Path.GetExtension(BrowseFile.FileName);

                if (leftThumbExtension == ".JPEG" || leftThumbExtension == ".TIFF" || leftThumbExtension == ".PNG" || leftThumbExtension == ".GIF"
                    || leftThumbExtension == ".EPS" || leftThumbExtension == ".BMP" || leftThumbExtension == ".PSD" || leftThumbExtension == ".SVG"
                    || leftThumbExtension == ".RAW" || leftThumbExtension == ".APNG" || leftThumbExtension == ".AI" || leftThumbExtension == ".JPG"
                    ||
                    leftThumbExtension == ".jpeg" || leftThumbExtension == ".tiff" || leftThumbExtension == ".png" || leftThumbExtension == ".gif"
                    || leftThumbExtension == ".eps" || leftThumbExtension == ".bmp" || leftThumbExtension == ".psd" || leftThumbExtension == ".svg"
                    || leftThumbExtension == ".raw" || leftThumbExtension == ".apng" || leftThumbExtension == ".ai" || leftThumbExtension == ".jpg")
                {
                    pictureBox3.Image = System.Drawing.Image.FromFile(BrowseFile.FileName);
                    pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else if (!(leftThumbExtension == ".JPEG" || leftThumbExtension == ".TIFF" || leftThumbExtension == ".PNG" || leftThumbExtension == ".GIF"
                    || leftThumbExtension == ".EPS" || leftThumbExtension == ".BMP" || leftThumbExtension == ".PSD" || leftThumbExtension == ".SVG"
                    || leftThumbExtension == ".RAW" || leftThumbExtension == ".APNG" || leftThumbExtension == ".AI" || leftThumbExtension == ".JPG"
                    ||
                    leftThumbExtension == ".jpeg" || leftThumbExtension == ".tiff" || leftThumbExtension == ".png" || leftThumbExtension == ".gif"
                    || leftThumbExtension == ".eps" || leftThumbExtension == ".bmp" || leftThumbExtension == ".psd" || leftThumbExtension == ".svg"
                    || leftThumbExtension == ".raw" || leftThumbExtension == ".apng" || leftThumbExtension == ".ai" || leftThumbExtension == ".jpg"))
                {
                    pictureBox3.Image = NBI.Properties.Resources.generalDoc;
                    pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            else /*if (BrowseFile.ShowDialog() == DialogResult.Cancel)*/
            {
                leftThumbFilePath = "";
                leftThumbFileName = "";
                leftThumbExtension = "";
                pictureBox3.Image = null;
                //Image.FromFile(Path.GetFullPath(@"..\..\..\htect-nbi-data-capture\local-image\document.png"));
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        private void fileUploaderThumbRight_Click(object sender, EventArgs e)
        {
            OpenFileDialog BrowseFile = new OpenFileDialog();
            BrowseFile.Title = "Finger Print Left File Uploader";
            if (BrowseFile.ShowDialog() == DialogResult.OK)
            {
                // file path
                rightThumbFilePath = Path.GetFullPath(BrowseFile.FileName);

                // renaming file
                rightThumbFileName = textBoxFname.Text + textBoxLname.Text;

                // extension
                rightThumbExtension = Path.GetExtension(BrowseFile.FileName);

                if (rightThumbExtension == ".JPEG" || rightThumbExtension == ".TIFF" || rightThumbExtension == ".PNG" || rightThumbExtension == ".GIF"
                    || rightThumbExtension == ".EPS" || rightThumbExtension == ".BMP" || rightThumbExtension == ".PSD" || rightThumbExtension == ".SVG"
                    || rightThumbExtension == ".RAW" || rightThumbExtension == ".APNG" || rightThumbExtension == ".AI" || rightThumbExtension == ".JPG"
                    ||
                    rightThumbExtension == ".jpeg" || rightThumbExtension == ".tiff" || rightThumbExtension == ".png" || rightThumbExtension == ".gif"
                    || rightThumbExtension == ".eps" || rightThumbExtension == ".bmp" || rightThumbExtension == ".psd" || rightThumbExtension == ".svg"
                    || rightThumbExtension == ".raw" || rightThumbExtension == ".apng" || rightThumbExtension == ".ai" || rightThumbExtension == ".jpg")
                {
                    pictureBox4.Image = System.Drawing.Image.FromFile(BrowseFile.FileName);
                    pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else if (!(rightThumbExtension == ".JPEG" || rightThumbExtension == ".TIFF" || rightThumbExtension == ".PNG" || rightThumbExtension == ".GIF"
                    || rightThumbExtension == ".EPS" || rightThumbExtension == ".BMP" || rightThumbExtension == ".PSD" || rightThumbExtension == ".SVG"
                    || rightThumbExtension == ".RAW" || rightThumbExtension == ".APNG" || rightThumbExtension == ".AI" || rightThumbExtension == ".JPG"
                    ||
                    rightThumbExtension == ".jpeg" || rightThumbExtension == ".tiff" || rightThumbExtension == ".png" || rightThumbExtension == ".gif"
                    || rightThumbExtension == ".eps" || rightThumbExtension == ".bmp" || rightThumbExtension == ".psd" || rightThumbExtension == ".svg"
                    || rightThumbExtension == ".raw" || rightThumbExtension == ".apng" || rightThumbExtension == ".ai" || rightThumbExtension == ".jpg"))
                {
                    pictureBox4.Image = NBI.Properties.Resources.generalDoc;
                    pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            else /*if (BrowseFile.ShowDialog() == DialogResult.Cancel)*/
            {
                rightThumbFilePath = "";
                rightThumbFileName = "";
                rightThumbExtension = "";
                pictureBox4.Image = null;
                //Image.FromFile(Path.GetFullPath(@"..\..\..\htect-nbi-data-capture\local-image\document.png"));
                pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        private void fileUploaderIrisLeft_Click(object sender, EventArgs e)
        {
            OpenFileDialog BrowseFile = new OpenFileDialog();
            BrowseFile.Title = "Finger Print Left File Uploader";
            if (BrowseFile.ShowDialog() == DialogResult.OK)
            {
                // file path
                leftEyeFilePath = Path.GetFullPath(BrowseFile.FileName);

                // renaming file
                leftEyeFileName = textBoxFname.Text + textBoxLname.Text;

                // extension
                leftEyeExtension = Path.GetExtension(BrowseFile.FileName);

                if (leftEyeExtension == ".JPEG" || leftEyeExtension == ".TIFF" || leftEyeExtension == ".PNG" || leftEyeExtension == ".GIF"
                    || leftEyeExtension == ".EPS" || leftEyeExtension == ".BMP" || leftEyeExtension == ".PSD" || leftEyeExtension == ".SVG"
                    || leftEyeExtension == ".RAW" || leftEyeExtension == ".APNG" || leftEyeExtension == ".AI" || leftEyeExtension == ".JPG"
                    ||
                    leftEyeExtension == ".jpeg" || leftEyeExtension == ".tiff" || leftEyeExtension == ".png" || leftEyeExtension == ".gif"
                    || leftEyeExtension == ".eps" || leftEyeExtension == ".bmp" || leftEyeExtension == ".psd" || leftEyeExtension == ".svg"
                    || leftEyeExtension == ".raw" || leftEyeExtension == ".apng" || leftEyeExtension == ".ai" || leftEyeExtension == ".jpg")
                {
                    pictureBox5.Image = System.Drawing.Image.FromFile(BrowseFile.FileName);
                    pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else if (!(leftEyeExtension == ".JPEG" || leftEyeExtension == ".TIFF" || leftEyeExtension == ".PNG" || leftEyeExtension == ".GIF"
                    || leftEyeExtension == ".EPS" || leftEyeExtension == ".BMP" || leftEyeExtension == ".PSD" || leftEyeExtension == ".SVG"
                    || leftEyeExtension == ".RAW" || leftEyeExtension == ".APNG" || leftEyeExtension == ".AI" || leftEyeExtension == ".JPG"
                    ||
                    leftEyeExtension == ".jpeg" || leftEyeExtension == ".tiff" || leftEyeExtension == ".png" || leftEyeExtension == ".gif"
                    || leftEyeExtension == ".eps" || leftEyeExtension == ".bmp" || leftEyeExtension == ".psd" || leftEyeExtension == ".svg"
                    || leftEyeExtension == ".raw" || leftEyeExtension == ".apng" || leftEyeExtension == ".ai" || leftEyeExtension == ".jpg"))
                {
                    pictureBox5.Image = NBI.Properties.Resources.generalDoc;
                    pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            else /*if (BrowseFile.ShowDialog() == DialogResult.Cancel)*/
            {
                leftEyeFilePath = "";
                leftEyeFileName = "";
                leftEyeExtension = "";
                pictureBox5.Image = null;
                pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        private void fileUploaderIrisRight_Click(object sender, EventArgs e)
        {
            OpenFileDialog BrowseFile = new OpenFileDialog();
            BrowseFile.Title = "Finger Print Left File Uploader";
            if (BrowseFile.ShowDialog() == DialogResult.OK)
            {
                // file path
                rightEyeFilePath = Path.GetFullPath(BrowseFile.FileName);

                // renaming file
                rightEyeFileName = textBoxFname.Text + textBoxLname.Text;

                // extension
                rightEyeExtension = Path.GetExtension(BrowseFile.FileName);

                if (rightEyeExtension == ".JPEG" || rightEyeExtension == ".TIFF" || rightEyeExtension == ".PNG" || rightEyeExtension == ".GIF"
                    || rightEyeExtension == ".EPS" || rightEyeExtension == ".BMP" || rightEyeExtension == ".PSD" || rightEyeExtension == ".SVG"
                    || rightEyeExtension == ".RAW" || rightEyeExtension == ".APNG" || rightEyeExtension == ".AI" || rightEyeExtension == ".JPG"
                    ||
                    rightEyeExtension == ".jpeg" || rightEyeExtension == ".tiff" || rightEyeExtension == ".png" || rightEyeExtension == ".gif"
                    || rightEyeExtension == ".eps" || rightEyeExtension == ".bmp" || rightEyeExtension == ".psd" || rightEyeExtension == ".svg"
                    || rightEyeExtension == ".raw" || rightEyeExtension == ".apng" || rightEyeExtension == ".ai" || rightEyeExtension == ".jpg")
                {
                    pictureBox6.Image = System.Drawing.Image.FromFile(BrowseFile.FileName);
                    pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else if (!(rightEyeExtension == ".JPEG" || rightEyeExtension == ".TIFF" || rightEyeExtension == ".PNG" || rightEyeExtension == ".GIF"
                    || rightEyeExtension == ".EPS" || rightEyeExtension == ".BMP" || rightEyeExtension == ".PSD" || rightEyeExtension == ".SVG"
                    || rightEyeExtension == ".RAW" || rightEyeExtension == ".APNG" || rightEyeExtension == ".AI" || rightEyeExtension == ".JPG"
                    ||
                    rightEyeExtension == ".jpeg" || rightEyeExtension == ".tiff" || rightEyeExtension == ".png" || rightEyeExtension == ".gif"
                    || rightEyeExtension == ".eps" || rightEyeExtension == ".bmp" || rightEyeExtension == ".psd" || rightEyeExtension == ".svg"
                    || rightEyeExtension == ".raw" || rightEyeExtension == ".apng" || rightEyeExtension == ".ai" || rightEyeExtension == ".jpg"))
                {
                    pictureBox6.Image = NBI.Properties.Resources.generalDoc;
                    pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            else /*if (BrowseFile.ShowDialog() == DialogResult.Cancel)*/
            {
                rightEyeFilePath = "";
                rightEyeFileName = "";
                rightEyeExtension = "";
                pictureBox6.Image = null;
                pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        private void fileUploaderDocument_Click(object sender, EventArgs e)
        {
            OpenFileDialog BrowseFile = new OpenFileDialog();
            BrowseFile.Title = "Finger Print Left File Uploader";
            if (BrowseFile.ShowDialog() == DialogResult.OK)
            {
                // file path
                documentFilePath = Path.GetFullPath(BrowseFile.FileName);

                // renaming file
                documentFileName = textBoxFname.Text + textBoxLname.Text;

                // extension
                documentExtension = Path.GetExtension(BrowseFile.FileName);

                if (documentExtension == ".JPEG" || documentExtension == ".TIFF" || documentExtension == ".PNG" || documentExtension == ".GIF"
                    || documentExtension == ".EPS" || documentExtension == ".BMP" || documentExtension == ".PSD" || documentExtension == ".SVG"
                    || documentExtension == ".RAW" || documentExtension == ".APNG" || documentExtension == ".AI" || documentExtension == ".JPG"
                    ||
                    documentExtension == ".jpeg" || documentExtension == ".tiff" || documentExtension == ".png" || documentExtension == ".gif"
                    || documentExtension == ".eps" || documentExtension == ".bmp" || documentExtension == ".psd" || documentExtension == ".svg"
                    || documentExtension == ".raw" || documentExtension == ".apng" || documentExtension == ".ai" || documentExtension == ".jpg")
                {
                    pictureBox7.Image = System.Drawing.Image.FromFile(BrowseFile.FileName);
                    pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else if (!(documentExtension == ".JPEG" || documentExtension == ".TIFF" || documentExtension == ".PNG" || documentExtension == ".GIF"
                    || documentExtension == ".EPS" || documentExtension == ".BMP" || documentExtension == ".PSD" || documentExtension == ".SVG"
                    || documentExtension == ".RAW" || documentExtension == ".APNG" || documentExtension == ".AI" || documentExtension == ".JPG"
                    ||
                    documentExtension == ".jpeg" || documentExtension == ".tiff" || documentExtension == ".png" || documentExtension == ".gif"
                    || documentExtension == ".eps" || documentExtension == ".bmp" || documentExtension == ".psd" || documentExtension == ".svg"
                    || documentExtension == ".raw" || documentExtension == ".apng" || documentExtension == ".ai" || documentExtension == ".jpg"))
                {
                    pictureBox7.Image = NBI.Properties.Resources.generalDoc;
                    pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            else /*if (BrowseFile.ShowDialog() == DialogResult.Cancel)*/
            {
                documentFilePath = "";
                documentFileName = "";
                documentExtension = "";
                pictureBox7.Image = null;
                pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        private void fileUploaderIDPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog BrowseFile = new OpenFileDialog();
            BrowseFile.Title = "Finger Print Left File Uploader";
            if (BrowseFile.ShowDialog() == DialogResult.OK)
            {
                // file path
                idFilePath = Path.GetFullPath(BrowseFile.FileName);

                // renaming file
                idFileName = textBoxFname.Text + textBoxLname.Text;

                // extension
                idExtension = Path.GetExtension(BrowseFile.FileName);

                if (idExtension == ".JPEG" || idExtension == ".TIFF" || idExtension == ".PNG" || idExtension == ".GIF"
                    || idExtension == ".EPS" || idExtension == ".BMP" || idExtension == ".PSD" || idExtension == ".SVG"
                    || idExtension == ".RAW" || idExtension == ".APNG" || idExtension == ".AI" || idExtension == ".JPG"
                    ||
                    idExtension == ".jpeg" || idExtension == ".tiff" || idExtension == ".png" || idExtension == ".gif"
                    || idExtension == ".eps" || idExtension == ".bmp" || idExtension == ".psd" || idExtension == ".svg"
                    || idExtension == ".raw" || idExtension == ".apng" || idExtension == ".ai" || idExtension == ".jpg")
                {
                    pictureBox8.Image = System.Drawing.Image.FromFile(BrowseFile.FileName);
                    pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else if (!(idExtension == ".JPEG" || idExtension == ".TIFF" || idExtension == ".PNG" || idExtension == ".GIF"
                    || idExtension == ".EPS" || idExtension == ".BMP" || idExtension == ".PSD" || idExtension == ".SVG"
                    || idExtension == ".RAW" || idExtension == ".APNG" || idExtension == ".AI" || idExtension == ".JPG"
                    ||
                    idExtension == ".jpeg" || idExtension == ".tiff" || idExtension == ".png" || idExtension == ".gif"
                    || idExtension == ".eps" || idExtension == ".bmp" || idExtension == ".psd" || idExtension == ".svg"
                    || idExtension == ".raw" || idExtension == ".apng" || idExtension == ".ai" || idExtension == ".jpg"))
                {
                    pictureBox8.Image = NBI.Properties.Resources.generalDoc;
                    pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            else /*if (BrowseFile.ShowDialog() == DialogResult.Cancel)*/
            {
                idFilePath = "";
                idFileName = "";
                idExtension = "";
                pictureBox8.Image = null;
                pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        private void fileUploaderSignature_Click(object sender, EventArgs e)
        {
            OpenFileDialog BrowseFile = new OpenFileDialog();
            BrowseFile.Title = "Finger Print Left File Uploader";
            if (BrowseFile.ShowDialog() == DialogResult.OK)
            {
                // file path
                signatureFilePath = Path.GetFullPath(BrowseFile.FileName);

                // renaming file
                signatureFileName = textBoxFname.Text + textBoxLname.Text;

                // extension
                signatureExtension = Path.GetExtension(BrowseFile.FileName);

                if (signatureExtension == ".JPEG" || signatureExtension == ".TIFF" || signatureExtension == ".PNG" || signatureExtension == ".GIF"
                    || signatureExtension == ".EPS" || signatureExtension == ".BMP" || signatureExtension == ".PSD" || signatureExtension == ".SVG"
                    || signatureExtension == ".RAW" || signatureExtension == ".APNG" || signatureExtension == ".AI" || signatureExtension == ".JPG"
                    ||
                    signatureExtension == ".jpeg" || signatureExtension == ".tiff" || signatureExtension == ".png" || signatureExtension == ".gif"
                    || signatureExtension == ".eps" || signatureExtension == ".bmp" || signatureExtension == ".psd" || signatureExtension == ".svg"
                    || signatureExtension == ".raw" || signatureExtension == ".apng" || signatureExtension == ".ai" || signatureExtension == ".jpg")
                {
                    pictureBox9.Image = System.Drawing.Image.FromFile(BrowseFile.FileName);
                    pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else if (!(signatureExtension == ".JPEG" || signatureExtension == ".TIFF" || signatureExtension == ".PNG" || signatureExtension == ".GIF"
                    || signatureExtension == ".EPS" || signatureExtension == ".BMP" || signatureExtension == ".PSD" || signatureExtension == ".SVG"
                    || signatureExtension == ".RAW" || signatureExtension == ".APNG" || signatureExtension == ".AI" || signatureExtension == ".JPG"
                    ||
                    signatureExtension == ".jpeg" || signatureExtension == ".tiff" || signatureExtension == ".png" || signatureExtension == ".gif"
                    || signatureExtension == ".eps" || signatureExtension == ".bmp" || signatureExtension == ".psd" || signatureExtension == ".svg"
                    || signatureExtension == ".raw" || signatureExtension == ".apng" || signatureExtension == ".ai" || signatureExtension == ".jpg"))
                {
                    pictureBox9.Image = NBI.Properties.Resources.generalDoc;
                    pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            else /*if (BrowseFile.ShowDialog() == DialogResult.Cancel)*/
            {
                signatureFilePath = "";
                signatureFileName = "";
                signatureExtension = "";
                pictureBox9.Image = null;
                pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        private void fingerScanningToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog BrowseFile = new OpenFileDialog();
            BrowseFile.Title = "LOCATE FINGER PRINT SCANNING DEVICE";
            BrowseFile.Filter = "exe files (*.exe)|*.exe|All files (*.*)|*.*";
            BrowseFile.FilterIndex = 1;
            if (BrowseFile.ShowDialog() == DialogResult.OK)
            {
                fingerPrintScanningLocation = BrowseFile.FileName;
            }
        }
        private void irisScanningToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog BrowseFile = new OpenFileDialog();
            BrowseFile.Title = "LOCATE IRIS SCANNING DEVICE";
            BrowseFile.Filter = "exe files (*.exe)|*.exe|All files (*.*)|*.*";
            BrowseFile.FilterIndex = 1;
            if (BrowseFile.ShowDialog() == DialogResult.OK)
            {
                irisScanningLocation = BrowseFile.FileName;
            }
        }
        private void documentScanningToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog BrowseFile = new OpenFileDialog();
            BrowseFile.Title = "LOCATE DOCUMENT SCANNING DEVICE";
            BrowseFile.Filter = "exe files (*.exe)|*.exe|All files (*.*)|*.*";
            BrowseFile.FilterIndex = 1;
            if (BrowseFile.ShowDialog() == DialogResult.OK)
            {
                documentScanningLocation = BrowseFile.FileName;
            }
        }
        private void cameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog BrowseFile = new OpenFileDialog();
            BrowseFile.Title = "LOCATE CAMERA DEVICE";
            BrowseFile.Filter = "exe files (*.exe)|*.exe|All files (*.*)|*.*";
            BrowseFile.FilterIndex = 1;
            if (BrowseFile.ShowDialog() == DialogResult.OK)
            {
                cameraLocation = BrowseFile.FileName;
            }
        }
        private void signatureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog BrowseFile = new OpenFileDialog();
            BrowseFile.Title = "LOCATE CAMERA DEVICE";
            BrowseFile.Filter = "exe files (*.exe)|*.exe|All files (*.*)|*.*";
            BrowseFile.FilterIndex = 1;
            if (BrowseFile.ShowDialog() == DialogResult.OK)
            {
                signatureLocation = BrowseFile.FileName;
            }
        }
        private void comboBoxSex_SelectedIndexChanged(object sender, EventArgs e)
        {
            sex = comboBoxSex.Text;
            if (loadingTime > 1)
            {
                buttonRegister.Enabled = false;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;

                //stops the timer, para indi lagi mag check nang user validation.
                timerToEnableRegisterBtn.Stop();

                IsAccountExisting2ndChecking = CRUD.CheckIfUserIsExisting(textBoxFname.Text, textBoxMname.Text, textBoxLname.Text, textBoxSname.Text, sex, birthDate, textBoxAddress.Text, textBoxMunicipality.Text, textBoxBarangay.Text, textBoxZipcode.Text);

                if (IsAccountExisting2ndChecking == "not-existing")
                {
                    //textBoxFname.Text = textBoxFname.Text.Replace(" /User-Existing ", "");
                    if (leftHandFilePath != string.Empty && rightHandFilePath != string.Empty && leftThumbFilePath != string.Empty && rightThumbFilePath != string.Empty && leftEyeFilePath != string.Empty && rightEyeFilePath != string.Empty && documentFilePath != string.Empty && idFilePath != string.Empty && signatureFilePath != string.Empty)
                    {
                        buttonRegister.Enabled = true;
                        groupBox2.Enabled = true;
                        groupBox3.Enabled = true;
                    }
                    else
                    {
                        buttonRegister.Enabled = false;
                        groupBox2.Enabled = true;
                        groupBox3.Enabled = true;
                    }
                    IsAccountExisting2ndChecking = "";
                    timerToEnableRegisterBtn.Start();
                }
                else
                {
                    MessageBox.Show("USER IS EXISTING.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //textBoxFname.Text += "/User-Existing";
                    buttonRegister.Enabled = false;
                    groupBox2.Enabled = false;
                    groupBox3.Enabled = false;
                }
            }
        }

        // prevent user from editing the combobox
        private void comboBoxSex_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        public void ClearAllIfUserIsExisting()
        {
            timerToEnableRegisterBtn.Stop();
            MessageBox.Show("User is existing.", "WARNING!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            sex = "";

            // File name
            leftHandFileName = "";
            rightHandFileName = "";
            leftThumbFileName = "";
            rightThumbFileName = "";
            leftEyeFileName = "";
            rightEyeFileName = "";
            documentFileName = "";
            idFileName = "";
            signatureFileName = "";

            // File path
            leftHandFilePath = "";
            rightHandFilePath = "";
            leftThumbFilePath = "";
            rightThumbFilePath = "";
            leftEyeFilePath = "";
            rightEyeFilePath = "";
            documentFilePath = "";
            idFilePath = "";
            signatureFilePath = "";

            // File Extensions
            leftHandExtension = "";
            rightHandExtension = "";
            leftThumbExtension = "";
            rightThumbExtension = "";
            leftEyeExtension = "";
            rightEyeExtension = "";
            documentExtension = "";
            idExtension = "";
            signatureExtension = "";

            // show the select sex text
            comboBoxSex.SelectedIndex = -1;
            if (comboBoxSex.SelectedIndex == -1)
            {
                if (comboBoxSex.Text != "Select sex")
                {
                    comboBoxSex.SelectedText = "Select sex";
                }
            }

            // reset the images
            pictureBox1.Image = null; pictureBox2.Image = null; pictureBox3.Image = null; pictureBox4.Image = null; pictureBox5.Image = null; pictureBox6.Image = null;
            pictureBox7.Image = null; pictureBox8.Image = null; pictureBox9.Image = null;

            // features
            textBoxFname.Text = "";
            textBoxMname.Text = "";
            textBoxLname.Text = "";
            textBoxSname.Text = "";
            DatePickerDateOrBirth.MinDate = DateTimePicker.MinimumDateTime;
            DatePickerDateOrBirth.MaxDate = nowDate;
            DatePickerDateOrBirth.Value = nowDate;
            textBoxAddress.Text = "";
            textBoxMunicipality.Text = "";
            textBoxBarangay.Text = "";
            textBoxZipcode.Text = "";

            //placeholder
            textBoxFname.PlaceholderText = "Please Input First name";
            textBoxMname.PlaceholderText = "Please Input Middle Name";
            textBoxLname.PlaceholderText = "Please Input Last Name";
            textBoxSname.PlaceholderText = "-";
            textBoxAddress.PlaceholderText = "Please Input Address Name";
            textBoxMunicipality.PlaceholderText = "Please Input City or Municipality";
            textBoxBarangay.PlaceholderText = "Please Input Barangay";
            textBoxZipcode.PlaceholderText = "Please Input Zip Code (accepts only : 6 digits)";

            //restart timer
            countingTime = 0;
            loadingTime = 0;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            timerToEnableRegisterBtn.Start();
        }
        public void ClearUserFieldsIfUserIsExisting()
        {
            timerToEnableRegisterBtn.Stop();
            MessageBox.Show("User is existing.", "WARNING!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            sex = "";

            // show the select sex text
            comboBoxSex.SelectedIndex = -1;
            if (comboBoxSex.SelectedIndex == -1)
            {
                if (comboBoxSex.Text != "Select sex")
                {
                    comboBoxSex.SelectedText = "Select sex";
                }
            }

            // features
            textBoxFname.Text = "";
            textBoxMname.Text = "";
            textBoxLname.Text = "";
            textBoxSname.Text = "";
            DatePickerDateOrBirth.MinDate = DateTimePicker.MinimumDateTime;
            DatePickerDateOrBirth.MaxDate = nowDate;
            DatePickerDateOrBirth.Value = nowDate;
            textBoxAddress.Text = "";
            textBoxMunicipality.Text = "";
            textBoxBarangay.Text = "";
            textBoxZipcode.Text = "";

            //placeholder
            textBoxFname.PlaceholderText = "Please Input First name";
            textBoxMname.PlaceholderText = "Please Input Middle Name";
            textBoxLname.PlaceholderText = "Please Input Last Name";
            textBoxSname.PlaceholderText = "-";
            textBoxAddress.PlaceholderText = "Please Input Address Name";
            textBoxMunicipality.PlaceholderText = "Please Input City or Municipality";
            textBoxBarangay.PlaceholderText = "Please Input Barangay";
            textBoxZipcode.PlaceholderText = "Please Input Zip Code (accepts only : 6 digits)";

            //restart timer
            countingTime = 0;
            loadingTime = 0;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            timerToEnableRegisterBtn.Start();
        }
        public void ClearAll()
        {
            sex = "";

            // File name
            leftHandFileName = "";
            rightHandFileName = "";
            leftThumbFileName = "";
            rightThumbFileName = "";
            leftEyeFileName = "";
            rightEyeFileName = "";
            documentFileName = "";
            idFileName = "";
            signatureFileName = "";

            // File path
            leftHandFilePath = "";
            rightHandFilePath = "";
            leftThumbFilePath = "";
            rightThumbFilePath = "";
            leftEyeFilePath = "";
            rightEyeFilePath = "";
            documentFilePath = "";
            idFilePath = "";
            signatureFilePath = "";

            // File Extensions
            leftHandExtension = "";
            rightHandExtension = "";
            leftThumbExtension = "";
            rightThumbExtension = "";
            leftEyeExtension = "";
            rightEyeExtension = "";
            documentExtension = "";
            idExtension = "";
            signatureExtension = "";

            // show the select sex text
            comboBoxSex.SelectedIndex = -1;
            if (comboBoxSex.SelectedIndex == -1)
            {
                if (comboBoxSex.Text != "Select sex")
                {
                    comboBoxSex.SelectedText = "Select sex";
                }
            }

            // reset the images
            pictureBox1.Image = null; pictureBox2.Image = null; pictureBox3.Image = null; pictureBox4.Image = null; pictureBox5.Image = null; pictureBox6.Image = null;
            pictureBox7.Image = null; pictureBox8.Image = null; pictureBox9.Image = null;

            // features
            textBoxFname.Text = "";
            textBoxMname.Text = "";
            textBoxLname.Text = "";
            textBoxSname.Text = "";
            DatePickerDateOrBirth.MinDate = DateTimePicker.MinimumDateTime;
            DatePickerDateOrBirth.MaxDate = nowDate;
            DatePickerDateOrBirth.Value = nowDate;
            textBoxAddress.Text = "";
            textBoxMunicipality.Text = "";
            textBoxBarangay.Text = "";
            textBoxZipcode.Text = "";

            //placeholder
            textBoxFname.PlaceholderText = "Please Input First Name";
            textBoxMname.PlaceholderText = "Please Input Middle Name";
            textBoxLname.PlaceholderText = "Please Input Last Name";
            textBoxSname.PlaceholderText = "-";
            textBoxAddress.PlaceholderText = "Please Input Address";
            textBoxMunicipality.PlaceholderText = "Please Input City or Municipality";
            textBoxBarangay.PlaceholderText = "Please Input Barangay";
            textBoxZipcode.PlaceholderText = "Please Input Zip Code (accepts only : 6 digits)";
        }
        private void timerToEnableRegisterBtn_Tick(object sender, EventArgs e)
        {
            //every tick increases
            countingTime++;
            birthDate = DatePickerDateOrBirth.Value.ToString("yyyy/MM/dd");
            IsDatabaseConnected = CRUD.testConnection();
            if (IsDatabaseConnected == true)
            {
                if (textBoxFname.Text != string.Empty
                    && textBoxLname.Text != string.Empty
                    && (textBoxMname.Text != string.Empty || textBoxMname.Text == string.Empty)
                    && textBoxAddress.Text != string.Empty
                    && textBoxMunicipality.Text != string.Empty
                    && textBoxBarangay.Text != string.Empty
                    && (textBoxZipcode.Text != string.Empty && textBoxZipcode.Text.Length == 6)
                    && sex != string.Empty
                    && birthDate != DateTime.Now.ToString("yyyy/MM/dd"))
                {
                    //for smooth animation of loading.
                    loadingTime++;

                    // checks if user is already existing in database                    
                    IsAccountExisting1stChecking = CRUD.CheckIfUserIsExisting(textBoxFname.Text, textBoxMname.Text, textBoxLname.Text, textBoxSname.Text, sex, birthDate, textBoxAddress.Text, textBoxMunicipality.Text, textBoxBarangay.Text, textBoxZipcode.Text);

                    if (loadingTime == 1)
                    {
                        // display form4 loading screen only.
                        Form4 f4 = new Form4();
                        f4.ShowDialog();
                    }
                    else if (loadingTime > 2)
                    {
                        if (IsAccountExisting1stChecking == "not-existing")
                        {
                            groupBox1.Enabled = false;
                            groupBox2.Enabled = true;
                            groupBox3.Enabled = true;

                            buttonRegister.Text = "Finalize Information.";
                            IsAccountExisting1stChecking = "";

                            if (textBoxFname.Text != string.Empty
                                && textBoxLname.Text != string.Empty
                                && (textBoxMname.Text != string.Empty || textBoxMname.Text == string.Empty)
                                && textBoxAddress.Text != string.Empty
                                && textBoxMunicipality.Text != string.Empty
                                && textBoxBarangay.Text != string.Empty
                                && textBoxZipcode.Text != string.Empty
                                && sex != string.Empty
                                && birthDate != DateTime.Now.ToString("yyyy/MM/dd")

                                && leftHandFilePath != string.Empty
                                && rightHandFilePath != string.Empty
                                && leftThumbFilePath != string.Empty
                                && rightThumbFilePath != string.Empty
                                && leftEyeFilePath != string.Empty
                                && rightEyeFilePath != string.Empty
                                && documentFilePath != string.Empty
                                && idFilePath != string.Empty
                                && signatureFilePath != string.Empty)
                            {
                                //restart time
                                countingTime = 0;
                                loadingTime = 0;
                                timerToEnableRegisterBtn.Stop();

                                dialog = MessageBox.Show("Please double check the user information.\nDo you want to record this Data.\n\n\tYes = Going to record data.\n\n\tNo = Edit user information.", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (dialog == DialogResult.Yes)
                                {
                                    buttonRegister.Text = "Register";
                                    buttonRegister.Enabled = true;
                                    groupBox2.Enabled = false;
                                    groupBox3.Enabled = false;
                                }
                                else
                                {
                                    buttonRegister.Text = "...";
                                    countingTime = 0;
                                    loadingTime = 0;
                                    forEdit = true;
                                    groupBox1.Enabled = true;
                                    groupBox2.Enabled = false;
                                    groupBox3.Enabled = false;
                                    buttonRegister.Enabled = false;
                                    DatePickerDateOrBirth.Value = nowDate;
                                    timerToEnableRegisterBtn.Start();
                                }
                            }
                        }
                        else
                        {
                            if (forEdit == false)
                            {
                                ClearAllIfUserIsExisting();
                            }
                            else
                            {
                                ClearUserFieldsIfUserIsExisting();
                            }
                        }
                    }
                }
            }
            else
            {
                timerToEnableRegisterBtn.Stop();
                MessageBox.Show("Cannot proceed because database connection is closed!. Please contact the developer immediately");
            }
        }
        private void buttonClear_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            textBox1.Visible = false; textBox2.Visible = false;

            ClearAll();

            //restart timer
            timerToEnableRegisterBtn.Stop();
            buttonRegister.Enabled = false;
            groupBox3.Enabled = false;
            groupBox2.Enabled = false;
            countingTime = 0;
            loadingTime = 0;
            timerToEnableRegisterBtn.Start();
        }
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            birthDate = DatePickerDateOrBirth.Value.ToString("yyyy/MM/dd");
            //stops the timer
            timerToEnableRegisterBtn.Stop();
            /*
             * dito yung success na registration
             */

            // Start : Folder creation.
            // check if suffixname has value
            string createNewFolderAccordingToUserName;
            string SEX;
            if (comboBoxSex.SelectedIndex == 0)
            {
                SEX = "Sir ";
            }
            else
            {
                SEX = "Ma'am ";
            }
            // check if male of female
            if (textBoxSname.Text != "-" && textBoxSname.Text != string.Empty)
            {
                createNewFolderAccordingToUserName = defaultFilePath + "\\" + SEX + " - " + textBoxLname.Text + " - " + textBoxFname.Text + " - " + textBoxSname.Text + " - NBI";
            }
            else
            {
                createNewFolderAccordingToUserName = defaultFilePath + "\\" + SEX + " - " + textBoxLname.Text + " - " + textBoxFname.Text + " - NBI";
            }

            //check if user has an existing folder
            if (!Directory.Exists(createNewFolderAccordingToUserName))
            {
                //create a folder inside the NBI folder
                Directory.CreateDirectory(createNewFolderAccordingToUserName);
            }
            else
            {
                //MessageBox.Show(textBoxLname.Text + textBoxFname.Text + " - folder is already existing.");
            }

            //Start : create folder inside user folder
            // create finger print folder inside user folder
            string createNewFolderInsideUserFolderFingerPrint = createNewFolderAccordingToUserName + "\\FingerPrints";
            //check if folder is existing
            if (!Directory.Exists(createNewFolderInsideUserFolderFingerPrint))
            {
                //create folder 
                Directory.CreateDirectory(createNewFolderInsideUserFolderFingerPrint);
                FingerFolderCreated = true;
            }
            else
            {
                //MessageBox.Show("Folder is already existing.");
                FingerFolderCreated = false;
            }

            // create iris folder inside user folder
            string createNewFolderInsideUserFolderIris = createNewFolderAccordingToUserName + "\\Iris";
            //check if folder is existing
            if (!Directory.Exists(createNewFolderInsideUserFolderIris))
            {
                Directory.CreateDirectory(createNewFolderInsideUserFolderIris);
                IrisFolderCreate = true;
            }
            else
            {
                //MessageBox.Show("Folder is already existing.");
                IrisFolderCreate = false;
            }

            // Start : generate a copy file of the uploaded files
            LeftHand = COPYFILE.LeftFingerPrint(textBoxFname.Text, textBoxLname.Text, leftHandFilePath, createNewFolderInsideUserFolderFingerPrint, leftHandExtension);
            RightHand = COPYFILE.RightFingerPrint(textBoxFname.Text, textBoxLname.Text, rightHandFilePath, createNewFolderInsideUserFolderFingerPrint, rightHandExtension);

            LeftThumb = COPYFILE.LeftThumbPrint(textBoxFname.Text, textBoxLname.Text, leftThumbFilePath, createNewFolderInsideUserFolderFingerPrint, leftThumbExtension);
            RightThumb = COPYFILE.RightThumbPrint(textBoxFname.Text, textBoxLname.Text, rightThumbFilePath, createNewFolderInsideUserFolderFingerPrint, rightThumbExtension);

            LeftEye = COPYFILE.LeftEye(textBoxFname.Text, textBoxLname.Text, leftEyeFilePath, createNewFolderInsideUserFolderIris, leftEyeExtension);
            RightEye = COPYFILE.RightEye(textBoxFname.Text, textBoxLname.Text, rightEyeFilePath, createNewFolderInsideUserFolderIris, rightEyeExtension);

            Document = COPYFILE.Document(textBoxFname.Text, textBoxLname.Text, documentFilePath, createNewFolderAccordingToUserName, documentExtension);
            ID = COPYFILE.ID(textBoxFname.Text, textBoxLname.Text, idFilePath, createNewFolderAccordingToUserName, idExtension);
            Signature = COPYFILE.SIGNATURE(textBoxFname.Text, textBoxLname.Text, idFilePath, createNewFolderAccordingToUserName, idExtension);
            // End : generate a copy file of the uploaded files

            // Start : Crud                                         
            string CheckIfInsertNewDataIsSuccessfull = CRUD.InsertRecord(textBoxFname.Text, textBoxMname.Text, textBoxLname.Text, textBoxSname.Text, sex, birthDate, textBoxAddress.Text, textBoxMunicipality.Text, textBoxBarangay.Text, textBoxZipcode.Text, LeftHand, RightHand, LeftThumb, RightThumb, LeftEye, RightEye, Document, ID, Signature);
            // End : Crud 

            if (CheckIfInsertNewDataIsSuccessfull == "success")
            {
                // message prompt
                if (textBoxSname.Text != "-")
                {
                    MessageBox.Show("All documents has been stored to user : \n \t(" + SEX + " - " + textBoxFname.Text + " - " + textBoxLname.Text + " - " + textBoxSname.Text + ").\n Folder @ " + defaultFilePath, "REGISTRATION IS SUCCESSFULL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("All documents has been stored to user : \n \t(" + SEX + " - " + textBoxFname.Text + " - " + textBoxLname.Text + ").\n Folder @ " + defaultFilePath, "REGISTRATION IS SUCCESSFULL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                textBox1.Visible = false; textBox2.Visible = false;

                ClearAll();

                //restart the timer                
                buttonRegister.Text = "...";
                groupBox1.Enabled = true;
                buttonRegister.Enabled = false;
                countingTime = 0;
                loadingTime = 0;
                timerToEnableRegisterBtn.Start();
            }
        }
    }
}
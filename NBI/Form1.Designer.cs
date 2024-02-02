namespace NBI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            menuToolStripMenuItem = new ToolStripMenuItem();
            listOfUsersToolStripMenuItem = new ToolStripMenuItem();
            currentToolStripMenuItem = new ToolStripMenuItem();
            setNewFilePathToolStripMenuItem = new ToolStripMenuItem();
            defaultLocationOfDeviceToolStripMenuItem = new ToolStripMenuItem();
            fingerScanningToolStripMenuItem = new ToolStripMenuItem();
            irisScanningToolStripMenuItem = new ToolStripMenuItem();
            documentScanningToolStripMenuItem = new ToolStripMenuItem();
            iDPictureToolStripMenuItem = new ToolStripMenuItem();
            signatureToolStripMenuItem1 = new ToolStripMenuItem();
            setNewPathOfDeviceToolStripMenuItem = new ToolStripMenuItem();
            fingerScanningToolStripMenuItem1 = new ToolStripMenuItem();
            irisScanningToolStripMenuItem1 = new ToolStripMenuItem();
            documentScanningToolStripMenuItem1 = new ToolStripMenuItem();
            cameraToolStripMenuItem = new ToolStripMenuItem();
            signatureToolStripMenuItem = new ToolStripMenuItem();
            groupBox1 = new GroupBox();
            textBoxZipcode = new TextBox();
            label15 = new Label();
            textBoxBarangay = new TextBox();
            label14 = new Label();
            textBoxMunicipality = new TextBox();
            label13 = new Label();
            label12 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            textBoxAddress = new TextBox();
            comboBoxSex = new ComboBox();
            DatePickerDateOrBirth = new DateTimePicker();
            textBoxSname = new TextBox();
            textBoxLname = new TextBox();
            textBoxMname = new TextBox();
            textBoxFname = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            buttonSignature = new Button();
            buttonCamera = new Button();
            buttonDocumentScanning = new Button();
            buttonIrisScanning = new Button();
            buttonFingerScanning = new Button();
            buttonClear = new Button();
            buttonRegister = new Button();
            groupBox3 = new GroupBox();
            label11 = new Label();
            pictureBox9 = new PictureBox();
            fileUploaderSignature = new Button();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            fileUploaderFingerRight = new Button();
            fileUploaderThumbRight = new Button();
            fileUploaderThumbLeft = new Button();
            pictureBox8 = new PictureBox();
            pictureBox7 = new PictureBox();
            pictureBox6 = new PictureBox();
            pictureBox5 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            fileUploaderIDPicture = new Button();
            fileUploaderDocument = new Button();
            fileUploaderIrisRight = new Button();
            fileUploaderIrisLeft = new Button();
            fileUploaderFingerLeft = new Button();
            timerClock = new System.Windows.Forms.Timer(components);
            timerToEnableRegisterBtn = new System.Windows.Forms.Timer(components);
            menuStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1236, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            menuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listOfUsersToolStripMenuItem, currentToolStripMenuItem, setNewFilePathToolStripMenuItem, defaultLocationOfDeviceToolStripMenuItem, setNewPathOfDeviceToolStripMenuItem });
            menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            menuToolStripMenuItem.Size = new Size(50, 20);
            menuToolStripMenuItem.Text = "Menu";
            // 
            // listOfUsersToolStripMenuItem
            // 
            listOfUsersToolStripMenuItem.Name = "listOfUsersToolStripMenuItem";
            listOfUsersToolStripMenuItem.Size = new Size(209, 22);
            listOfUsersToolStripMenuItem.Text = "List Of Users";
            listOfUsersToolStripMenuItem.Click += listOfUsersToolStripMenuItem_Click;
            // 
            // currentToolStripMenuItem
            // 
            currentToolStripMenuItem.Name = "currentToolStripMenuItem";
            currentToolStripMenuItem.Size = new Size(209, 22);
            currentToolStripMenuItem.Text = "Current File Path";
            currentToolStripMenuItem.Click += currentToolStripMenuItem_Click;
            // 
            // setNewFilePathToolStripMenuItem
            // 
            setNewFilePathToolStripMenuItem.Name = "setNewFilePathToolStripMenuItem";
            setNewFilePathToolStripMenuItem.Size = new Size(209, 22);
            setNewFilePathToolStripMenuItem.Text = "Set New File Path";
            // 
            // defaultLocationOfDeviceToolStripMenuItem
            // 
            defaultLocationOfDeviceToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { fingerScanningToolStripMenuItem, irisScanningToolStripMenuItem, documentScanningToolStripMenuItem, iDPictureToolStripMenuItem, signatureToolStripMenuItem1 });
            defaultLocationOfDeviceToolStripMenuItem.Name = "defaultLocationOfDeviceToolStripMenuItem";
            defaultLocationOfDeviceToolStripMenuItem.Size = new Size(209, 22);
            defaultLocationOfDeviceToolStripMenuItem.Text = "Default location of device";
            // 
            // fingerScanningToolStripMenuItem
            // 
            fingerScanningToolStripMenuItem.Name = "fingerScanningToolStripMenuItem";
            fingerScanningToolStripMenuItem.Size = new Size(182, 22);
            fingerScanningToolStripMenuItem.Text = "Finger Scanning";
            fingerScanningToolStripMenuItem.Click += fingerScanningToolStripMenuItem_Click;
            // 
            // irisScanningToolStripMenuItem
            // 
            irisScanningToolStripMenuItem.Name = "irisScanningToolStripMenuItem";
            irisScanningToolStripMenuItem.Size = new Size(182, 22);
            irisScanningToolStripMenuItem.Text = "Iris Scanning";
            irisScanningToolStripMenuItem.Click += irisScanningToolStripMenuItem_Click;
            // 
            // documentScanningToolStripMenuItem
            // 
            documentScanningToolStripMenuItem.Name = "documentScanningToolStripMenuItem";
            documentScanningToolStripMenuItem.Size = new Size(182, 22);
            documentScanningToolStripMenuItem.Text = "Document Scanning";
            documentScanningToolStripMenuItem.Click += documentScanningToolStripMenuItem_Click;
            // 
            // iDPictureToolStripMenuItem
            // 
            iDPictureToolStripMenuItem.Name = "iDPictureToolStripMenuItem";
            iDPictureToolStripMenuItem.Size = new Size(182, 22);
            iDPictureToolStripMenuItem.Text = "ID picture";
            iDPictureToolStripMenuItem.Click += iDPictureToolStripMenuItem_Click;
            // 
            // signatureToolStripMenuItem1
            // 
            signatureToolStripMenuItem1.Name = "signatureToolStripMenuItem1";
            signatureToolStripMenuItem1.Size = new Size(182, 22);
            signatureToolStripMenuItem1.Text = "Signature";
            signatureToolStripMenuItem1.Click += signatureToolStripMenuItem1_Click;
            // 
            // setNewPathOfDeviceToolStripMenuItem
            // 
            setNewPathOfDeviceToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { fingerScanningToolStripMenuItem1, irisScanningToolStripMenuItem1, documentScanningToolStripMenuItem1, cameraToolStripMenuItem, signatureToolStripMenuItem });
            setNewPathOfDeviceToolStripMenuItem.Name = "setNewPathOfDeviceToolStripMenuItem";
            setNewPathOfDeviceToolStripMenuItem.Size = new Size(209, 22);
            setNewPathOfDeviceToolStripMenuItem.Text = "Set new path of device";
            // 
            // fingerScanningToolStripMenuItem1
            // 
            fingerScanningToolStripMenuItem1.Name = "fingerScanningToolStripMenuItem1";
            fingerScanningToolStripMenuItem1.Size = new Size(182, 22);
            fingerScanningToolStripMenuItem1.Text = "Finger Scanning";
            fingerScanningToolStripMenuItem1.Click += fingerScanningToolStripMenuItem1_Click;
            // 
            // irisScanningToolStripMenuItem1
            // 
            irisScanningToolStripMenuItem1.Name = "irisScanningToolStripMenuItem1";
            irisScanningToolStripMenuItem1.Size = new Size(182, 22);
            irisScanningToolStripMenuItem1.Text = "Iris Scanning";
            irisScanningToolStripMenuItem1.Click += irisScanningToolStripMenuItem1_Click;
            // 
            // documentScanningToolStripMenuItem1
            // 
            documentScanningToolStripMenuItem1.Name = "documentScanningToolStripMenuItem1";
            documentScanningToolStripMenuItem1.Size = new Size(182, 22);
            documentScanningToolStripMenuItem1.Text = "Document Scanning";
            documentScanningToolStripMenuItem1.Click += documentScanningToolStripMenuItem1_Click;
            // 
            // cameraToolStripMenuItem
            // 
            cameraToolStripMenuItem.Name = "cameraToolStripMenuItem";
            cameraToolStripMenuItem.Size = new Size(182, 22);
            cameraToolStripMenuItem.Text = "Camera";
            cameraToolStripMenuItem.Click += cameraToolStripMenuItem_Click;
            // 
            // signatureToolStripMenuItem
            // 
            signatureToolStripMenuItem.Name = "signatureToolStripMenuItem";
            signatureToolStripMenuItem.Size = new Size(182, 22);
            signatureToolStripMenuItem.Text = "Signature";
            signatureToolStripMenuItem.Click += signatureToolStripMenuItem_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBoxZipcode);
            groupBox1.Controls.Add(label15);
            groupBox1.Controls.Add(textBoxBarangay);
            groupBox1.Controls.Add(label14);
            groupBox1.Controls.Add(textBoxMunicipality);
            groupBox1.Controls.Add(label13);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(textBoxAddress);
            groupBox1.Controls.Add(comboBoxSex);
            groupBox1.Controls.Add(DatePickerDateOrBirth);
            groupBox1.Controls.Add(textBoxSname);
            groupBox1.Controls.Add(textBoxLname);
            groupBox1.Controls.Add(textBoxMname);
            groupBox1.Controls.Add(textBoxFname);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Sitka Subheading", 12F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(12, 27);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(693, 482);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Personal Information";
            // 
            // textBoxZipcode
            // 
            textBoxZipcode.Location = new Point(191, 387);
            textBoxZipcode.MaxLength = 6;
            textBoxZipcode.Name = "textBoxZipcode";
            textBoxZipcode.Size = new Size(155, 28);
            textBoxZipcode.TabIndex = 24;
            textBoxZipcode.TextAlign = HorizontalAlignment.Center;
            textBoxZipcode.KeyPress += textBoxZipcode_KeyPress;
            textBoxZipcode.Leave += textBoxZipcode_Leave;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Sitka Subheading", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label15.Location = new Point(20, 390);
            label15.Name = "label15";
            label15.Size = new Size(81, 23);
            label15.TabIndex = 23;
            label15.Text = "Zip Code :";
            // 
            // textBoxBarangay
            // 
            textBoxBarangay.Location = new Point(191, 342);
            textBoxBarangay.Name = "textBoxBarangay";
            textBoxBarangay.Size = new Size(490, 28);
            textBoxBarangay.TabIndex = 22;
            textBoxBarangay.Leave += textBoxBarangay_Leave;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Sitka Subheading", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label14.Location = new Point(20, 345);
            label14.Name = "label14";
            label14.Size = new Size(89, 23);
            label14.TabIndex = 21;
            label14.Text = "Barangay : ";
            // 
            // textBoxMunicipality
            // 
            textBoxMunicipality.Location = new Point(191, 296);
            textBoxMunicipality.Name = "textBoxMunicipality";
            textBoxMunicipality.Size = new Size(490, 28);
            textBoxMunicipality.TabIndex = 20;
            textBoxMunicipality.Leave += textBoxMunicipality_Leave;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Sitka Subheading", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label13.Location = new Point(20, 299);
            label13.Name = "label13";
            label13.Size = new Size(165, 23);
            label13.TabIndex = 19;
            label13.Text = "City or Municipality : ";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Sitka Subheading", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label12.ForeColor = Color.Red;
            label12.Location = new Point(233, 431);
            label12.Name = "label12";
            label12.Size = new Size(404, 32);
            label12.TabIndex = 18;
            label12.Text = "Note : \r\nWhen all fields are being filled. System will automatically check if user is existing.";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Sitka Subheading", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label10.ForeColor = Color.Red;
            label10.Location = new Point(157, 227);
            label10.Name = "label10";
            label10.Size = new Size(157, 16);
            label10.TabIndex = 17;
            label10.Text = "Note : date cannot equal today\r\n";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Sitka Subheading", 14.2499981F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(472, 91);
            label9.Name = "label9";
            label9.Size = new Size(22, 28);
            label9.TabIndex = 16;
            label9.Text = "..";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Sitka Subheading", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(469, 29);
            label8.Name = "label8";
            label8.Size = new Size(208, 47);
            label8.TabIndex = 15;
            label8.Text = "00:00:00 AM";
            // 
            // textBoxAddress
            // 
            textBoxAddress.Location = new Point(191, 248);
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(490, 28);
            textBoxAddress.TabIndex = 14;
            textBoxAddress.KeyDown += textBoxAddress_KeyDown;
            textBoxAddress.Leave += textBoxAddress_Leave;
            // 
            // comboBoxSex
            // 
            comboBoxSex.FormattingEnabled = true;
            comboBoxSex.Items.AddRange(new object[] { "Male", "Female" });
            comboBoxSex.Location = new Point(562, 195);
            comboBoxSex.Name = "comboBoxSex";
            comboBoxSex.Size = new Size(119, 31);
            comboBoxSex.TabIndex = 13;
            comboBoxSex.SelectedIndexChanged += comboBoxSex_SelectedIndexChanged;
            comboBoxSex.KeyPress += comboBoxSex_KeyPress;
            // 
            // DatePickerDateOrBirth
            // 
            DatePickerDateOrBirth.Location = new Point(151, 193);
            DatePickerDateOrBirth.MaxDate = new DateTime(2023, 5, 19, 0, 0, 0, 0);
            DatePickerDateOrBirth.Name = "DatePickerDateOrBirth";
            DatePickerDateOrBirth.Size = new Size(272, 28);
            DatePickerDateOrBirth.TabIndex = 12;
            DatePickerDateOrBirth.Value = new DateTime(2023, 5, 19, 0, 0, 0, 0);
            // 
            // textBoxSname
            // 
            textBoxSname.Location = new Point(562, 151);
            textBoxSname.Name = "textBoxSname";
            textBoxSname.Size = new Size(119, 28);
            textBoxSname.TabIndex = 11;
            textBoxSname.Leave += textBoxSname_Leave;
            // 
            // textBoxLname
            // 
            textBoxLname.Location = new Point(151, 146);
            textBoxLname.Name = "textBoxLname";
            textBoxLname.Size = new Size(272, 28);
            textBoxLname.TabIndex = 10;
            textBoxLname.Leave += textBoxLname_Leave;
            // 
            // textBoxMname
            // 
            textBoxMname.Location = new Point(151, 97);
            textBoxMname.Name = "textBoxMname";
            textBoxMname.Size = new Size(272, 28);
            textBoxMname.TabIndex = 9;
            textBoxMname.Leave += textBoxMname_Leave;
            // 
            // textBoxFname
            // 
            textBoxFname.Location = new Point(151, 48);
            textBoxFname.Name = "textBoxFname";
            textBoxFname.Size = new Size(272, 28);
            textBoxFname.TabIndex = 8;
            textBoxFname.Leave += textBoxFname_Leave;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Sitka Subheading", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(20, 251);
            label7.Name = "label7";
            label7.Size = new Size(122, 23);
            label7.TabIndex = 6;
            label7.Text = "Home Address :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Sitka Subheading", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(16, 193);
            label6.Name = "label6";
            label6.Size = new Size(113, 23);
            label6.TabIndex = 5;
            label6.Text = "Date Of Birth :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Sitka Subheading", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(444, 198);
            label5.Name = "label5";
            label5.Size = new Size(44, 23);
            label5.TabIndex = 4;
            label5.Text = "Sex :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Sitka Subheading", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(444, 154);
            label4.Name = "label4";
            label4.Size = new Size(106, 23);
            label4.TabIndex = 3;
            label4.Text = "Suffix Name :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sitka Subheading", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(16, 149);
            label3.Name = "label3";
            label3.Size = new Size(94, 23);
            label3.TabIndex = 2;
            label3.Text = "Last Name :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sitka Subheading", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(16, 100);
            label2.Name = "label2";
            label2.Size = new Size(114, 23);
            label2.TabIndex = 1;
            label2.Text = "Middle Name :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Subheading", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(16, 48);
            label1.Name = "label1";
            label1.Size = new Size(98, 23);
            label1.TabIndex = 0;
            label1.Text = "First Name :";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(buttonSignature);
            groupBox2.Controls.Add(buttonCamera);
            groupBox2.Controls.Add(buttonDocumentScanning);
            groupBox2.Controls.Add(buttonIrisScanning);
            groupBox2.Controls.Add(buttonFingerScanning);
            groupBox2.Font = new Font("Sitka Subheading", 12F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox2.Location = new Point(12, 515);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(494, 148);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Scanning Device";
            // 
            // buttonSignature
            // 
            buttonSignature.Location = new Point(340, 59);
            buttonSignature.Name = "buttonSignature";
            buttonSignature.Size = new Size(148, 35);
            buttonSignature.TabIndex = 4;
            buttonSignature.Text = "Capture Signature";
            buttonSignature.UseVisualStyleBackColor = true;
            buttonSignature.Click += buttonSignature_Click;
            // 
            // buttonCamera
            // 
            buttonCamera.Location = new Point(191, 78);
            buttonCamera.Name = "buttonCamera";
            buttonCamera.Size = new Size(134, 35);
            buttonCamera.TabIndex = 3;
            buttonCamera.Text = "Camera";
            buttonCamera.UseVisualStyleBackColor = true;
            buttonCamera.Click += buttonCamera_Click;
            // 
            // buttonDocumentScanning
            // 
            buttonDocumentScanning.Location = new Point(20, 78);
            buttonDocumentScanning.Name = "buttonDocumentScanning";
            buttonDocumentScanning.Size = new Size(162, 35);
            buttonDocumentScanning.TabIndex = 2;
            buttonDocumentScanning.Text = "Document Scanning";
            buttonDocumentScanning.UseVisualStyleBackColor = true;
            buttonDocumentScanning.Click += buttonDocumentScanning_Click;
            // 
            // buttonIrisScanning
            // 
            buttonIrisScanning.Location = new Point(197, 37);
            buttonIrisScanning.Name = "buttonIrisScanning";
            buttonIrisScanning.Size = new Size(123, 35);
            buttonIrisScanning.TabIndex = 1;
            buttonIrisScanning.Text = "Iris Scanning";
            buttonIrisScanning.UseVisualStyleBackColor = true;
            buttonIrisScanning.Click += buttonIrisScanning_Click;
            // 
            // buttonFingerScanning
            // 
            buttonFingerScanning.Location = new Point(34, 37);
            buttonFingerScanning.Name = "buttonFingerScanning";
            buttonFingerScanning.Size = new Size(134, 35);
            buttonFingerScanning.TabIndex = 0;
            buttonFingerScanning.Text = "Finger Scanning";
            buttonFingerScanning.UseVisualStyleBackColor = true;
            buttonFingerScanning.Click += buttonFingerScanning_Click;
            // 
            // buttonClear
            // 
            buttonClear.Font = new Font("Sitka Subheading", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonClear.Location = new Point(512, 543);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(193, 44);
            buttonClear.TabIndex = 4;
            buttonClear.Text = "Clear";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // buttonRegister
            // 
            buttonRegister.Font = new Font("Sitka Subheading", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonRegister.Location = new Point(512, 603);
            buttonRegister.Name = "buttonRegister";
            buttonRegister.Size = new Size(193, 44);
            buttonRegister.TabIndex = 5;
            buttonRegister.Text = "Register";
            buttonRegister.UseVisualStyleBackColor = true;
            buttonRegister.Click += buttonRegister_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label11);
            groupBox3.Controls.Add(pictureBox9);
            groupBox3.Controls.Add(fileUploaderSignature);
            groupBox3.Controls.Add(textBox2);
            groupBox3.Controls.Add(textBox1);
            groupBox3.Controls.Add(fileUploaderFingerRight);
            groupBox3.Controls.Add(fileUploaderThumbRight);
            groupBox3.Controls.Add(fileUploaderThumbLeft);
            groupBox3.Controls.Add(pictureBox8);
            groupBox3.Controls.Add(pictureBox7);
            groupBox3.Controls.Add(pictureBox6);
            groupBox3.Controls.Add(pictureBox5);
            groupBox3.Controls.Add(pictureBox4);
            groupBox3.Controls.Add(pictureBox3);
            groupBox3.Controls.Add(pictureBox2);
            groupBox3.Controls.Add(pictureBox1);
            groupBox3.Controls.Add(fileUploaderIDPicture);
            groupBox3.Controls.Add(fileUploaderDocument);
            groupBox3.Controls.Add(fileUploaderIrisRight);
            groupBox3.Controls.Add(fileUploaderIrisLeft);
            groupBox3.Controls.Add(fileUploaderFingerLeft);
            groupBox3.Location = new Point(711, 36);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(521, 627);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            groupBox3.Text = "File Uploader";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Sitka Subheading", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(540, 611);
            label11.Name = "label11";
            label11.Size = new Size(44, 23);
            label11.TabIndex = 18;
            label11.Text = "Sex :";
            label11.Visible = false;
            // 
            // pictureBox9
            // 
            pictureBox9.Location = new Point(189, 531);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(132, 80);
            pictureBox9.TabIndex = 33;
            pictureBox9.TabStop = false;
            // 
            // fileUploaderSignature
            // 
            fileUploaderSignature.Font = new Font("Sitka Subheading", 12F, FontStyle.Regular, GraphicsUnit.Point);
            fileUploaderSignature.Location = new Point(177, 493);
            fileUploaderSignature.Name = "fileUploaderSignature";
            fileUploaderSignature.Size = new Size(174, 32);
            fileUploaderSignature.TabIndex = 32;
            fileUploaderSignature.Text = "Signature";
            fileUploaderSignature.UseVisualStyleBackColor = true;
            fileUploaderSignature.Click += fileUploaderSignature_Click;
            // 
            // textBox2
            // 
            textBox2.Enabled = false;
            textBox2.Location = new Point(6, 336);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(171, 23);
            textBox2.TabIndex = 31;
            // 
            // textBox1
            // 
            textBox1.Enabled = false;
            textBox1.Location = new Point(6, 162);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(171, 23);
            textBox1.TabIndex = 30;
            // 
            // fileUploaderFingerRight
            // 
            fileUploaderFingerRight.Font = new Font("Sitka Subheading", 12F, FontStyle.Regular, GraphicsUnit.Point);
            fileUploaderFingerRight.Location = new Point(6, 208);
            fileUploaderFingerRight.Name = "fileUploaderFingerRight";
            fileUploaderFingerRight.Size = new Size(171, 32);
            fileUploaderFingerRight.TabIndex = 29;
            fileUploaderFingerRight.Text = "Finger-Right";
            fileUploaderFingerRight.UseVisualStyleBackColor = true;
            fileUploaderFingerRight.Click += fileUploaderFingerRight_Click;
            // 
            // fileUploaderThumbRight
            // 
            fileUploaderThumbRight.Font = new Font("Sitka Subheading", 12F, FontStyle.Regular, GraphicsUnit.Point);
            fileUploaderThumbRight.Location = new Point(189, 207);
            fileUploaderThumbRight.Name = "fileUploaderThumbRight";
            fileUploaderThumbRight.Size = new Size(171, 32);
            fileUploaderThumbRight.TabIndex = 28;
            fileUploaderThumbRight.Text = "Thumb-Right";
            fileUploaderThumbRight.UseVisualStyleBackColor = true;
            fileUploaderThumbRight.Click += fileUploaderThumbRight_Click;
            // 
            // fileUploaderThumbLeft
            // 
            fileUploaderThumbLeft.Font = new Font("Sitka Subheading", 12F, FontStyle.Regular, GraphicsUnit.Point);
            fileUploaderThumbLeft.Location = new Point(189, 38);
            fileUploaderThumbLeft.Name = "fileUploaderThumbLeft";
            fileUploaderThumbLeft.Size = new Size(171, 32);
            fileUploaderThumbLeft.TabIndex = 27;
            fileUploaderThumbLeft.Text = "Thumb-Left";
            fileUploaderThumbLeft.UseVisualStyleBackColor = true;
            fileUploaderThumbLeft.Click += fileUploaderThumbLeft_Click;
            // 
            // pictureBox8
            // 
            pictureBox8.Location = new Point(93, 407);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(132, 80);
            pictureBox8.TabIndex = 22;
            pictureBox8.TabStop = false;
            // 
            // pictureBox7
            // 
            pictureBox7.Location = new Point(306, 407);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(132, 80);
            pictureBox7.TabIndex = 21;
            pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            pictureBox6.Location = new Point(366, 246);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(132, 80);
            pictureBox6.TabIndex = 20;
            pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Location = new Point(366, 76);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(132, 80);
            pictureBox5.TabIndex = 19;
            pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Location = new Point(205, 246);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(135, 80);
            pictureBox4.TabIndex = 18;
            pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(205, 76);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(132, 80);
            pictureBox3.TabIndex = 17;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(23, 246);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(132, 80);
            pictureBox2.TabIndex = 16;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(23, 76);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(132, 80);
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // fileUploaderIDPicture
            // 
            fileUploaderIDPicture.Font = new Font("Sitka Subheading", 12F, FontStyle.Regular, GraphicsUnit.Point);
            fileUploaderIDPicture.Location = new Point(72, 370);
            fileUploaderIDPicture.Name = "fileUploaderIDPicture";
            fileUploaderIDPicture.Size = new Size(174, 31);
            fileUploaderIDPicture.TabIndex = 12;
            fileUploaderIDPicture.Text = "ID Picture";
            fileUploaderIDPicture.UseVisualStyleBackColor = true;
            fileUploaderIDPicture.Click += fileUploaderIDPicture_Click;
            // 
            // fileUploaderDocument
            // 
            fileUploaderDocument.Font = new Font("Sitka Subheading", 12F, FontStyle.Regular, GraphicsUnit.Point);
            fileUploaderDocument.Location = new Point(281, 370);
            fileUploaderDocument.Name = "fileUploaderDocument";
            fileUploaderDocument.Size = new Size(174, 31);
            fileUploaderDocument.TabIndex = 11;
            fileUploaderDocument.Text = "Document";
            fileUploaderDocument.UseVisualStyleBackColor = true;
            fileUploaderDocument.Click += fileUploaderDocument_Click;
            // 
            // fileUploaderIrisRight
            // 
            fileUploaderIrisRight.Font = new Font("Sitka Subheading", 12F, FontStyle.Regular, GraphicsUnit.Point);
            fileUploaderIrisRight.Location = new Point(374, 208);
            fileUploaderIrisRight.Name = "fileUploaderIrisRight";
            fileUploaderIrisRight.Size = new Size(120, 33);
            fileUploaderIrisRight.TabIndex = 10;
            fileUploaderIrisRight.Text = "Iris-Right";
            fileUploaderIrisRight.UseVisualStyleBackColor = true;
            fileUploaderIrisRight.Click += fileUploaderIrisRight_Click;
            // 
            // fileUploaderIrisLeft
            // 
            fileUploaderIrisLeft.Font = new Font("Sitka Subheading", 12F, FontStyle.Regular, GraphicsUnit.Point);
            fileUploaderIrisLeft.Location = new Point(375, 38);
            fileUploaderIrisLeft.Name = "fileUploaderIrisLeft";
            fileUploaderIrisLeft.Size = new Size(119, 32);
            fileUploaderIrisLeft.TabIndex = 9;
            fileUploaderIrisLeft.Text = "Iris-Left";
            fileUploaderIrisLeft.UseVisualStyleBackColor = true;
            fileUploaderIrisLeft.Click += fileUploaderIrisLeft_Click;
            // 
            // fileUploaderFingerLeft
            // 
            fileUploaderFingerLeft.Font = new Font("Sitka Subheading", 12F, FontStyle.Regular, GraphicsUnit.Point);
            fileUploaderFingerLeft.Location = new Point(6, 38);
            fileUploaderFingerLeft.Name = "fileUploaderFingerLeft";
            fileUploaderFingerLeft.Size = new Size(171, 32);
            fileUploaderFingerLeft.TabIndex = 7;
            fileUploaderFingerLeft.Text = "Finger-Left";
            fileUploaderFingerLeft.UseVisualStyleBackColor = true;
            fileUploaderFingerLeft.Click += fileUploaderFingerLeft_Click;
            // 
            // timerClock
            // 
            timerClock.Enabled = true;
            timerClock.Tick += timerClock_Tick;
            // 
            // timerToEnableRegisterBtn
            // 
            timerToEnableRegisterBtn.Interval = 1000;
            timerToEnableRegisterBtn.Tick += timerToEnableRegisterBtn_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1236, 675);
            Controls.Add(groupBox3);
            Controls.Add(buttonClear);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(menuStrip1);
            Controls.Add(buttonRegister);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NBI";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem listOfUsersToolStripMenuItem;
        private ToolStripMenuItem currentToolStripMenuItem;
        private ToolStripMenuItem setNewFilePathToolStripMenuItem;
        private ToolStripMenuItem defaultLocationOfDeviceToolStripMenuItem;
        private ToolStripMenuItem fingerScanningToolStripMenuItem;
        private ToolStripMenuItem irisScanningToolStripMenuItem;
        private ToolStripMenuItem documentScanningToolStripMenuItem;
        private ToolStripMenuItem iDPictureToolStripMenuItem;
        private GroupBox groupBox1;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private DateTimePicker DatePickerDateOrBirth;
        private TextBox textBoxSname;
        private TextBox textBoxLname;
        private TextBox textBoxMname;
        private TextBox textBoxFname;
        private TextBox textBoxAddress;
        private ComboBox comboBoxSex;
        private GroupBox groupBox2;
        private Button buttonCamera;
        private Button buttonDocumentScanning;
        private Button buttonIrisScanning;
        private Button buttonFingerScanning;
        private Button buttonClear;
        private Button buttonRegister;
        private Label label8;
        private GroupBox groupBox3;
        private Button fileUploaderIDPicture;
        private Button fileUploaderDocument;
        private Button fileUploaderIrisRight;
        private Button fileUploaderIrisLeft;
        private Button fileUploaderFingerLeft;
        private PictureBox pictureBox8;
        private PictureBox pictureBox7;
        private PictureBox pictureBox6;
        private PictureBox pictureBox5;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Button fileUploaderFingerRight;
        private Button fileUploaderThumbRight;
        private Button fileUploaderThumbLeft;
        private TextBox textBox1;
        private TextBox textBox2;
        private System.Windows.Forms.Timer timerClock;
        private Label label9;
        private ToolStripMenuItem setNewPathOfDeviceToolStripMenuItem;
        private ToolStripMenuItem fingerScanningToolStripMenuItem1;
        private ToolStripMenuItem irisScanningToolStripMenuItem1;
        private ToolStripMenuItem documentScanningToolStripMenuItem1;
        private ToolStripMenuItem cameraToolStripMenuItem;
        private Label label10;
        private Button buttonSignature;
        private PictureBox pictureBox9;
        private Button fileUploaderSignature;
        private ToolStripMenuItem signatureToolStripMenuItem;
        private ToolStripMenuItem signatureToolStripMenuItem1;
        private System.Windows.Forms.Timer timerToEnableRegisterBtn;
        private Label label11;
        private Label label12;
        private TextBox textBoxMunicipality;
        private Label label13;
        private TextBox textBoxBarangay;
        private Label label14;
        private TextBox textBoxZipcode;
        private Label label15;
    }
}
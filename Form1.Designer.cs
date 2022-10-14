namespace Face_Detection_and_Recognition_Client
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDetectFace = new System.Windows.Forms.Button();
            this.btnStopCamera = new System.Windows.Forms.Button();
            this.btnUseLBPH = new System.Windows.Forms.Button();
            this.btnUseFisherFace = new System.Windows.Forms.Button();
            this.btnUseEigenFace = new System.Windows.Forms.Button();
            this.btnOpenCamera = new System.Windows.Forms.Button();
            this.picVideoCapture = new System.Windows.Forms.PictureBox();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.txtPersonName = new System.Windows.Forms.TextBox();
            this.picSaved = new System.Windows.Forms.PictureBox();
            this.btnFPS = new System.Windows.Forms.Button();
            this.panelImages = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnUseResnetV250 = new System.Windows.Forms.Button();
            this.btnUseResnetV2101 = new System.Windows.Forms.Button();
            this.btnUseInceptionV3 = new System.Windows.Forms.Button();
            this.btnUseMobilenetV2 = new System.Windows.Forms.Button();
            this.btnInceptionV3SdcaMaximumEntropy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picVideoCapture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSaved)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDetectFace
            // 
            this.btnDetectFace.Location = new System.Drawing.Point(311, 15);
            this.btnDetectFace.Margin = new System.Windows.Forms.Padding(2);
            this.btnDetectFace.Name = "btnDetectFace";
            this.btnDetectFace.Size = new System.Drawing.Size(92, 26);
            this.btnDetectFace.TabIndex = 68;
            this.btnDetectFace.Text = "Detect Face";
            this.btnDetectFace.UseVisualStyleBackColor = true;
            this.btnDetectFace.Click += new System.EventHandler(this.btnDetectFace_Click);
            // 
            // btnStopCamera
            // 
            this.btnStopCamera.Location = new System.Drawing.Point(119, 15);
            this.btnStopCamera.Margin = new System.Windows.Forms.Padding(2);
            this.btnStopCamera.Name = "btnStopCamera";
            this.btnStopCamera.Size = new System.Drawing.Size(92, 26);
            this.btnStopCamera.TabIndex = 67;
            this.btnStopCamera.Text = "Stop Camera";
            this.btnStopCamera.UseVisualStyleBackColor = true;
            this.btnStopCamera.Click += new System.EventHandler(this.btnStopCamera_Click);
            // 
            // btnUseLBPH
            // 
            this.btnUseLBPH.Location = new System.Drawing.Point(311, 395);
            this.btnUseLBPH.Margin = new System.Windows.Forms.Padding(2);
            this.btnUseLBPH.Name = "btnUseLBPH";
            this.btnUseLBPH.Size = new System.Drawing.Size(140, 24);
            this.btnUseLBPH.TabIndex = 64;
            this.btnUseLBPH.Text = "MobilenetV2Grayscale";
            this.btnUseLBPH.UseVisualStyleBackColor = true;
            this.btnUseLBPH.Click += new System.EventHandler(this.btnUseLBPH_Click);
            // 
            // btnUseFisherFace
            // 
            this.btnUseFisherFace.Location = new System.Drawing.Point(23, 393);
            this.btnUseFisherFace.Margin = new System.Windows.Forms.Padding(2);
            this.btnUseFisherFace.Name = "btnUseFisherFace";
            this.btnUseFisherFace.Size = new System.Drawing.Size(140, 26);
            this.btnUseFisherFace.TabIndex = 63;
            this.btnUseFisherFace.Text = "ResnetV250Grayscale";
            this.btnUseFisherFace.UseVisualStyleBackColor = true;
            this.btnUseFisherFace.Click += new System.EventHandler(this.btnUseFisherFace_Click);
            // 
            // btnUseEigenFace
            // 
            this.btnUseEigenFace.Location = new System.Drawing.Point(167, 395);
            this.btnUseEigenFace.Margin = new System.Windows.Forms.Padding(2);
            this.btnUseEigenFace.Name = "btnUseEigenFace";
            this.btnUseEigenFace.Size = new System.Drawing.Size(140, 26);
            this.btnUseEigenFace.TabIndex = 62;
            this.btnUseEigenFace.Text = "ResnetV2101Grayscale";
            this.btnUseEigenFace.UseVisualStyleBackColor = true;
            this.btnUseEigenFace.Click += new System.EventHandler(this.btnUseEigenFace_Click);
            // 
            // btnOpenCamera
            // 
            this.btnOpenCamera.Location = new System.Drawing.Point(23, 15);
            this.btnOpenCamera.Margin = new System.Windows.Forms.Padding(2);
            this.btnOpenCamera.Name = "btnOpenCamera";
            this.btnOpenCamera.Size = new System.Drawing.Size(92, 26);
            this.btnOpenCamera.TabIndex = 61;
            this.btnOpenCamera.Text = "Open Camera";
            this.btnOpenCamera.UseVisualStyleBackColor = true;
            this.btnOpenCamera.Click += new System.EventHandler(this.btnOpenCamera_Click);
            // 
            // picVideoCapture
            // 
            this.picVideoCapture.Location = new System.Drawing.Point(23, 48);
            this.picVideoCapture.Margin = new System.Windows.Forms.Padding(2);
            this.picVideoCapture.Name = "picVideoCapture";
            this.picVideoCapture.Size = new System.Drawing.Size(418, 297);
            this.picVideoCapture.TabIndex = 60;
            this.picVideoCapture.TabStop = false;
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Location = new System.Drawing.Point(498, 70);
            this.btnAddPerson.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(93, 34);
            this.btnAddPerson.TabIndex = 71;
            this.btnAddPerson.Text = "Add Detected Face";
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // txtPersonName
            // 
            this.txtPersonName.Location = new System.Drawing.Point(469, 47);
            this.txtPersonName.Margin = new System.Windows.Forms.Padding(2);
            this.txtPersonName.Name = "txtPersonName";
            this.txtPersonName.Size = new System.Drawing.Size(147, 20);
            this.txtPersonName.TabIndex = 70;
            // 
            // picSaved
            // 
            this.picSaved.Location = new System.Drawing.Point(477, 129);
            this.picSaved.Margin = new System.Windows.Forms.Padding(2);
            this.picSaved.Name = "picSaved";
            this.picSaved.Size = new System.Drawing.Size(129, 153);
            this.picSaved.TabIndex = 69;
            this.picSaved.TabStop = false;
            // 
            // btnFPS
            // 
            this.btnFPS.Location = new System.Drawing.Point(215, 15);
            this.btnFPS.Margin = new System.Windows.Forms.Padding(2);
            this.btnFPS.Name = "btnFPS";
            this.btnFPS.Size = new System.Drawing.Size(92, 26);
            this.btnFPS.TabIndex = 72;
            this.btnFPS.Text = "Show FPS";
            this.btnFPS.UseVisualStyleBackColor = true;
            this.btnFPS.Click += new System.EventHandler(this.btnFPS_Click);
            // 
            // panelImages
            // 
            this.panelImages.Location = new System.Drawing.Point(638, 57);
            this.panelImages.Margin = new System.Windows.Forms.Padding(2);
            this.panelImages.Name = "panelImages";
            this.panelImages.Size = new System.Drawing.Size(322, 417);
            this.panelImages.TabIndex = 73;
            this.panelImages.Paint += new System.Windows.Forms.PaintEventHandler(this.panelImages_Paint);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(758, 10);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 26);
            this.button1.TabIndex = 74;
            this.button1.Text = "Upload Faces";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(502, 114);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 75;
            this.label1.Text = "No Image Saved";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(760, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 76;
            this.label2.Text = "No Image/s Saved";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(466, 27);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 78;
            this.label4.Text = "Enter Name:";
            // 
            // btnUseResnetV250
            // 
            this.btnUseResnetV250.Location = new System.Drawing.Point(23, 363);
            this.btnUseResnetV250.Margin = new System.Windows.Forms.Padding(2);
            this.btnUseResnetV250.Name = "btnUseResnetV250";
            this.btnUseResnetV250.Size = new System.Drawing.Size(140, 27);
            this.btnUseResnetV250.TabIndex = 79;
            this.btnUseResnetV250.Text = "ResnetV250Colored";
            this.btnUseResnetV250.UseVisualStyleBackColor = true;
            this.btnUseResnetV250.Click += new System.EventHandler(this.btnUseResnetV250_Click);
            // 
            // btnUseResnetV2101
            // 
            this.btnUseResnetV2101.Location = new System.Drawing.Point(167, 365);
            this.btnUseResnetV2101.Margin = new System.Windows.Forms.Padding(2);
            this.btnUseResnetV2101.Name = "btnUseResnetV2101";
            this.btnUseResnetV2101.Size = new System.Drawing.Size(140, 26);
            this.btnUseResnetV2101.TabIndex = 80;
            this.btnUseResnetV2101.Text = "ResnetV2101Colored";
            this.btnUseResnetV2101.UseVisualStyleBackColor = true;
            this.btnUseResnetV2101.Click += new System.EventHandler(this.btnUseResnetV2101_Click);
            // 
            // btnUseInceptionV3
            // 
            this.btnUseInceptionV3.Location = new System.Drawing.Point(23, 423);
            this.btnUseInceptionV3.Margin = new System.Windows.Forms.Padding(2);
            this.btnUseInceptionV3.Name = "btnUseInceptionV3";
            this.btnUseInceptionV3.Size = new System.Drawing.Size(140, 26);
            this.btnUseInceptionV3.TabIndex = 81;
            this.btnUseInceptionV3.Text = "InceptionV3Colored";
            this.btnUseInceptionV3.UseVisualStyleBackColor = true;
            this.btnUseInceptionV3.Click += new System.EventHandler(this.btnUseInceptionV3_Click);
            // 
            // btnUseMobilenetV2
            // 
            this.btnUseMobilenetV2.Location = new System.Drawing.Point(311, 365);
            this.btnUseMobilenetV2.Margin = new System.Windows.Forms.Padding(2);
            this.btnUseMobilenetV2.Name = "btnUseMobilenetV2";
            this.btnUseMobilenetV2.Size = new System.Drawing.Size(140, 26);
            this.btnUseMobilenetV2.TabIndex = 82;
            this.btnUseMobilenetV2.Text = "MobilenetV2Colored";
            this.btnUseMobilenetV2.UseVisualStyleBackColor = true;
            this.btnUseMobilenetV2.Click += new System.EventHandler(this.btnUseMobilenetV2_Click);
            // 
            // btnInceptionV3SdcaMaximumEntropy
            // 
            this.btnInceptionV3SdcaMaximumEntropy.Location = new System.Drawing.Point(167, 425);
            this.btnInceptionV3SdcaMaximumEntropy.Margin = new System.Windows.Forms.Padding(2);
            this.btnInceptionV3SdcaMaximumEntropy.Name = "btnInceptionV3SdcaMaximumEntropy";
            this.btnInceptionV3SdcaMaximumEntropy.Size = new System.Drawing.Size(140, 26);
            this.btnInceptionV3SdcaMaximumEntropy.TabIndex = 85;
            this.btnInceptionV3SdcaMaximumEntropy.Text = "InceptionV3Grayscale";
            this.btnInceptionV3SdcaMaximumEntropy.UseVisualStyleBackColor = true;
            this.btnInceptionV3SdcaMaximumEntropy.Click += new System.EventHandler(this.btnInceptionV3SdcaMaximumEntropy_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 483);
            this.Controls.Add(this.btnInceptionV3SdcaMaximumEntropy);
            this.Controls.Add(this.btnUseMobilenetV2);
            this.Controls.Add(this.btnUseInceptionV3);
            this.Controls.Add(this.btnUseResnetV2101);
            this.Controls.Add(this.btnUseResnetV250);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panelImages);
            this.Controls.Add(this.btnFPS);
            this.Controls.Add(this.btnAddPerson);
            this.Controls.Add(this.txtPersonName);
            this.Controls.Add(this.picSaved);
            this.Controls.Add(this.btnDetectFace);
            this.Controls.Add(this.btnStopCamera);
            this.Controls.Add(this.btnUseLBPH);
            this.Controls.Add(this.btnUseFisherFace);
            this.Controls.Add(this.btnUseEigenFace);
            this.Controls.Add(this.btnOpenCamera);
            this.Controls.Add(this.picVideoCapture);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Face Detection And Recognition Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picVideoCapture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSaved)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDetectFace;
        private System.Windows.Forms.Button btnStopCamera;
        private System.Windows.Forms.Button btnUseLBPH;
        private System.Windows.Forms.Button btnUseFisherFace;
        private System.Windows.Forms.Button btnUseEigenFace;
        private System.Windows.Forms.Button btnOpenCamera;
        private System.Windows.Forms.PictureBox picVideoCapture;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.TextBox txtPersonName;
        private System.Windows.Forms.PictureBox picSaved;
        private System.Windows.Forms.Button btnFPS;
        private System.Windows.Forms.Panel panelImages;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnUseResnetV250;
        private System.Windows.Forms.Button btnUseResnetV2101;
        private System.Windows.Forms.Button btnUseInceptionV3;
        private System.Windows.Forms.Button btnUseMobilenetV2;
        private System.Windows.Forms.Button btnInceptionV3SdcaMaximumEntropy;
    }
}


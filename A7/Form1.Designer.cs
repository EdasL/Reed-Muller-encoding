namespace A7
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
            this.binaryMessageInputText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mText = new System.Windows.Forms.TextBox();
            this.rText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.binaryInputTab = new System.Windows.Forms.TabPage();
            this.textInputTab = new System.Windows.Forms.TabPage();
            this.imageInputTab = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.binaryOutputTab = new System.Windows.Forms.TabPage();
            this.textOutputTab = new System.Windows.Forms.TabPage();
            this.imageOutputTab = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.mistakeChanceText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.encodedBinaryMessage = new System.Windows.Forms.TextBox();
            this.binaryMessageEncodeButton = new System.Windows.Forms.Button();
            this.textEncodeButton = new System.Windows.Forms.Button();
            this.encodedTextMessage = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.inputTextMessage = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.binaryDecodeButton = new System.Windows.Forms.Button();
            this.sentBinaryMessageMistakePositions = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.sentBinaryMessageText = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.decodedBinaryMessage = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.decodedTextMessage = new System.Windows.Forms.TextBox();
            this.textDecodeButton = new System.Windows.Forms.Button();
            this.textMistakePositions = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.sentTextMessageText = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.inputImage = new System.Windows.Forms.PictureBox();
            this.encodedImage = new System.Windows.Forms.PictureBox();
            this.imageEncodeButton = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.sentImage = new System.Windows.Forms.PictureBox();
            this.label19 = new System.Windows.Forms.Label();
            this.decodedImage = new System.Windows.Forms.PictureBox();
            this.label20 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.imageUploadButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.binaryInputTab.SuspendLayout();
            this.textInputTab.SuspendLayout();
            this.imageInputTab.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.binaryOutputTab.SuspendLayout();
            this.textOutputTab.SuspendLayout();
            this.imageOutputTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.encodedImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sentImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.decodedImage)).BeginInit();
            this.SuspendLayout();
            // 
            // binaryMessageInputText
            // 
            this.binaryMessageInputText.Location = new System.Drawing.Point(6, 28);
            this.binaryMessageInputText.Multiline = true;
            this.binaryMessageInputText.Name = "binaryMessageInputText";
            this.binaryMessageInputText.Size = new System.Drawing.Size(283, 52);
            this.binaryMessageInputText.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter message:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(282, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "RM message encoding/decoding";
            // 
            // mText
            // 
            this.mText.Location = new System.Drawing.Point(23, 40);
            this.mText.Name = "mText";
            this.mText.Size = new System.Drawing.Size(48, 20);
            this.mText.TabIndex = 3;
            // 
            // rText
            // 
            this.rText.Location = new System.Drawing.Point(83, 40);
            this.rText.Name = "rText";
            this.rText.Size = new System.Drawing.Size(48, 20);
            this.rText.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Enter m:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(80, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Enter r:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(750, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.binaryInputTab);
            this.tabControl1.Controls.Add(this.textInputTab);
            this.tabControl1.Controls.Add(this.imageInputTab);
            this.tabControl1.Location = new System.Drawing.Point(23, 93);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(303, 321);
            this.tabControl1.TabIndex = 8;
            // 
            // binaryInputTab
            // 
            this.binaryInputTab.Controls.Add(this.binaryMessageEncodeButton);
            this.binaryInputTab.Controls.Add(this.encodedBinaryMessage);
            this.binaryInputTab.Controls.Add(this.label8);
            this.binaryInputTab.Controls.Add(this.binaryMessageInputText);
            this.binaryInputTab.Controls.Add(this.label1);
            this.binaryInputTab.Location = new System.Drawing.Point(4, 22);
            this.binaryInputTab.Name = "binaryInputTab";
            this.binaryInputTab.Padding = new System.Windows.Forms.Padding(3);
            this.binaryInputTab.Size = new System.Drawing.Size(295, 295);
            this.binaryInputTab.TabIndex = 0;
            this.binaryInputTab.Text = "binary";
            this.binaryInputTab.UseVisualStyleBackColor = true;
            // 
            // textInputTab
            // 
            this.textInputTab.Controls.Add(this.textEncodeButton);
            this.textInputTab.Controls.Add(this.encodedTextMessage);
            this.textInputTab.Controls.Add(this.label9);
            this.textInputTab.Controls.Add(this.inputTextMessage);
            this.textInputTab.Controls.Add(this.label10);
            this.textInputTab.Location = new System.Drawing.Point(4, 22);
            this.textInputTab.Name = "textInputTab";
            this.textInputTab.Padding = new System.Windows.Forms.Padding(3);
            this.textInputTab.Size = new System.Drawing.Size(295, 295);
            this.textInputTab.TabIndex = 1;
            this.textInputTab.Text = "text";
            this.textInputTab.UseVisualStyleBackColor = true;
            // 
            // imageInputTab
            // 
            this.imageInputTab.Controls.Add(this.imageUploadButton);
            this.imageInputTab.Controls.Add(this.label18);
            this.imageInputTab.Controls.Add(this.label17);
            this.imageInputTab.Controls.Add(this.imageEncodeButton);
            this.imageInputTab.Controls.Add(this.encodedImage);
            this.imageInputTab.Controls.Add(this.inputImage);
            this.imageInputTab.Location = new System.Drawing.Point(4, 22);
            this.imageInputTab.Name = "imageInputTab";
            this.imageInputTab.Size = new System.Drawing.Size(295, 295);
            this.imageInputTab.TabIndex = 2;
            this.imageInputTab.Text = "Image";
            this.imageInputTab.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.binaryOutputTab);
            this.tabControl2.Controls.Add(this.textOutputTab);
            this.tabControl2.Controls.Add(this.imageOutputTab);
            this.tabControl2.Location = new System.Drawing.Point(332, 93);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(395, 321);
            this.tabControl2.TabIndex = 9;
            // 
            // binaryOutputTab
            // 
            this.binaryOutputTab.Controls.Add(this.label13);
            this.binaryOutputTab.Controls.Add(this.decodedBinaryMessage);
            this.binaryOutputTab.Controls.Add(this.binaryDecodeButton);
            this.binaryOutputTab.Controls.Add(this.sentBinaryMessageMistakePositions);
            this.binaryOutputTab.Controls.Add(this.label11);
            this.binaryOutputTab.Controls.Add(this.sentBinaryMessageText);
            this.binaryOutputTab.Controls.Add(this.label12);
            this.binaryOutputTab.Location = new System.Drawing.Point(4, 22);
            this.binaryOutputTab.Name = "binaryOutputTab";
            this.binaryOutputTab.Padding = new System.Windows.Forms.Padding(3);
            this.binaryOutputTab.Size = new System.Drawing.Size(387, 295);
            this.binaryOutputTab.TabIndex = 0;
            this.binaryOutputTab.Text = "binary";
            this.binaryOutputTab.UseVisualStyleBackColor = true;
            // 
            // textOutputTab
            // 
            this.textOutputTab.Controls.Add(this.label14);
            this.textOutputTab.Controls.Add(this.decodedTextMessage);
            this.textOutputTab.Controls.Add(this.textDecodeButton);
            this.textOutputTab.Controls.Add(this.textMistakePositions);
            this.textOutputTab.Controls.Add(this.label15);
            this.textOutputTab.Controls.Add(this.sentTextMessageText);
            this.textOutputTab.Controls.Add(this.label16);
            this.textOutputTab.Location = new System.Drawing.Point(4, 22);
            this.textOutputTab.Name = "textOutputTab";
            this.textOutputTab.Padding = new System.Windows.Forms.Padding(3);
            this.textOutputTab.Size = new System.Drawing.Size(387, 295);
            this.textOutputTab.TabIndex = 1;
            this.textOutputTab.Text = "text";
            this.textOutputTab.UseVisualStyleBackColor = true;
            // 
            // imageOutputTab
            // 
            this.imageOutputTab.Controls.Add(this.button1);
            this.imageOutputTab.Controls.Add(this.label20);
            this.imageOutputTab.Controls.Add(this.decodedImage);
            this.imageOutputTab.Controls.Add(this.label19);
            this.imageOutputTab.Controls.Add(this.sentImage);
            this.imageOutputTab.Location = new System.Drawing.Point(4, 22);
            this.imageOutputTab.Name = "imageOutputTab";
            this.imageOutputTab.Size = new System.Drawing.Size(387, 295);
            this.imageOutputTab.TabIndex = 2;
            this.imageOutputTab.Text = "image";
            this.imageOutputTab.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Encoding:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(329, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Channel/Decoding:";
            // 
            // mistakeChanceText
            // 
            this.mistakeChanceText.Location = new System.Drawing.Point(143, 40);
            this.mistakeChanceText.Name = "mistakeChanceText";
            this.mistakeChanceText.Size = new System.Drawing.Size(129, 20);
            this.mistakeChanceText.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(140, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Enter mistake chance:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Encoded message:";
            // 
            // encodedBinaryMessage
            // 
            this.encodedBinaryMessage.Location = new System.Drawing.Point(6, 138);
            this.encodedBinaryMessage.Multiline = true;
            this.encodedBinaryMessage.Name = "encodedBinaryMessage";
            this.encodedBinaryMessage.Size = new System.Drawing.Size(280, 53);
            this.encodedBinaryMessage.TabIndex = 3;
            // 
            // binaryMessageEncodeButton
            // 
            this.binaryMessageEncodeButton.Location = new System.Drawing.Point(69, 233);
            this.binaryMessageEncodeButton.Name = "binaryMessageEncodeButton";
            this.binaryMessageEncodeButton.Size = new System.Drawing.Size(157, 36);
            this.binaryMessageEncodeButton.TabIndex = 14;
            this.binaryMessageEncodeButton.Text = "Encode and Send";
            this.binaryMessageEncodeButton.UseVisualStyleBackColor = true;
            this.binaryMessageEncodeButton.Click += new System.EventHandler(this.binaryMessageEncodeButton_Click);
            // 
            // textEncodeButton
            // 
            this.textEncodeButton.Location = new System.Drawing.Point(69, 240);
            this.textEncodeButton.Name = "textEncodeButton";
            this.textEncodeButton.Size = new System.Drawing.Size(157, 36);
            this.textEncodeButton.TabIndex = 19;
            this.textEncodeButton.Text = "Encode and Send";
            this.textEncodeButton.UseVisualStyleBackColor = true;
            this.textEncodeButton.Click += new System.EventHandler(this.textEncodeButton_Click);
            // 
            // encodedTextMessage
            // 
            this.encodedTextMessage.Location = new System.Drawing.Point(6, 145);
            this.encodedTextMessage.Multiline = true;
            this.encodedTextMessage.Name = "encodedTextMessage";
            this.encodedTextMessage.Size = new System.Drawing.Size(280, 53);
            this.encodedTextMessage.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Encoded message:";
            // 
            // inputTextMessage
            // 
            this.inputTextMessage.Location = new System.Drawing.Point(6, 35);
            this.inputTextMessage.Multiline = true;
            this.inputTextMessage.Name = "inputTextMessage";
            this.inputTextMessage.Size = new System.Drawing.Size(283, 52);
            this.inputTextMessage.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Enter message:";
            // 
            // binaryDecodeButton
            // 
            this.binaryDecodeButton.Location = new System.Drawing.Point(69, 233);
            this.binaryDecodeButton.Name = "binaryDecodeButton";
            this.binaryDecodeButton.Size = new System.Drawing.Size(249, 36);
            this.binaryDecodeButton.TabIndex = 19;
            this.binaryDecodeButton.Text = "Decode";
            this.binaryDecodeButton.UseVisualStyleBackColor = true;
            this.binaryDecodeButton.Click += new System.EventHandler(this.binaryDecodeButton_Click);
            // 
            // sentBinaryMessageMistakePositions
            // 
            this.sentBinaryMessageMistakePositions.Location = new System.Drawing.Point(9, 99);
            this.sentBinaryMessageMistakePositions.Multiline = true;
            this.sentBinaryMessageMistakePositions.Name = "sentBinaryMessageMistakePositions";
            this.sentBinaryMessageMistakePositions.Size = new System.Drawing.Size(372, 26);
            this.sentBinaryMessageMistakePositions.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 83);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Mistake positions";
            // 
            // sentBinaryMessageText
            // 
            this.sentBinaryMessageText.Location = new System.Drawing.Point(9, 28);
            this.sentBinaryMessageText.Multiline = true;
            this.sentBinaryMessageText.Name = "sentBinaryMessageText";
            this.sentBinaryMessageText.Size = new System.Drawing.Size(375, 52);
            this.sentBinaryMessageText.TabIndex = 15;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 13);
            this.label12.TabIndex = 16;
            this.label12.Text = "Sent message:";
            // 
            // decodedBinaryMessage
            // 
            this.decodedBinaryMessage.Location = new System.Drawing.Point(9, 155);
            this.decodedBinaryMessage.Multiline = true;
            this.decodedBinaryMessage.Name = "decodedBinaryMessage";
            this.decodedBinaryMessage.Size = new System.Drawing.Size(375, 52);
            this.decodedBinaryMessage.TabIndex = 20;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 138);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 13);
            this.label13.TabIndex = 21;
            this.label13.Text = "Decoded message:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(4, 145);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(99, 13);
            this.label14.TabIndex = 28;
            this.label14.Text = "Decoded message:";
            // 
            // decodedTextMessage
            // 
            this.decodedTextMessage.Location = new System.Drawing.Point(7, 162);
            this.decodedTextMessage.Multiline = true;
            this.decodedTextMessage.Name = "decodedTextMessage";
            this.decodedTextMessage.Size = new System.Drawing.Size(375, 52);
            this.decodedTextMessage.TabIndex = 27;
            // 
            // textDecodeButton
            // 
            this.textDecodeButton.Location = new System.Drawing.Point(67, 240);
            this.textDecodeButton.Name = "textDecodeButton";
            this.textDecodeButton.Size = new System.Drawing.Size(249, 36);
            this.textDecodeButton.TabIndex = 26;
            this.textDecodeButton.Text = "Decode";
            this.textDecodeButton.UseVisualStyleBackColor = true;
            this.textDecodeButton.Click += new System.EventHandler(this.textDecodeButton_Click);
            // 
            // textMistakePositions
            // 
            this.textMistakePositions.Location = new System.Drawing.Point(7, 106);
            this.textMistakePositions.Multiline = true;
            this.textMistakePositions.Name = "textMistakePositions";
            this.textMistakePositions.Size = new System.Drawing.Size(372, 26);
            this.textMistakePositions.TabIndex = 25;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(4, 90);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(88, 13);
            this.label15.TabIndex = 24;
            this.label15.Text = "Mistake positions";
            // 
            // sentTextMessageText
            // 
            this.sentTextMessageText.Location = new System.Drawing.Point(7, 35);
            this.sentTextMessageText.Multiline = true;
            this.sentTextMessageText.Name = "sentTextMessageText";
            this.sentTextMessageText.Size = new System.Drawing.Size(375, 52);
            this.sentTextMessageText.TabIndex = 22;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(4, 19);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 13);
            this.label16.TabIndex = 23;
            this.label16.Text = "Sent message:";
            // 
            // inputImage
            // 
            this.inputImage.Location = new System.Drawing.Point(3, 13);
            this.inputImage.Name = "inputImage";
            this.inputImage.Size = new System.Drawing.Size(167, 105);
            this.inputImage.TabIndex = 0;
            this.inputImage.TabStop = false;
            // 
            // encodedImage
            // 
            this.encodedImage.Location = new System.Drawing.Point(116, 134);
            this.encodedImage.Name = "encodedImage";
            this.encodedImage.Size = new System.Drawing.Size(167, 105);
            this.encodedImage.TabIndex = 1;
            this.encodedImage.TabStop = false;
            // 
            // imageEncodeButton
            // 
            this.imageEncodeButton.Location = new System.Drawing.Point(56, 245);
            this.imageEncodeButton.Name = "imageEncodeButton";
            this.imageEncodeButton.Size = new System.Drawing.Size(157, 36);
            this.imageEncodeButton.TabIndex = 20;
            this.imageEncodeButton.Text = "Encode and Send";
            this.imageEncodeButton.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 13);
            this.label17.TabIndex = 21;
            this.label17.Text = "Input image";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(113, 121);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(81, 13);
            this.label18.TabIndex = 22;
            this.label18.Text = "Encoded image";
            // 
            // sentImage
            // 
            this.sentImage.Location = new System.Drawing.Point(17, 13);
            this.sentImage.Name = "sentImage";
            this.sentImage.Size = new System.Drawing.Size(167, 105);
            this.sentImage.TabIndex = 1;
            this.sentImage.TabStop = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(14, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(60, 13);
            this.label19.TabIndex = 22;
            this.label19.Text = "Sent image";
            // 
            // decodedImage
            // 
            this.decodedImage.Location = new System.Drawing.Point(202, 134);
            this.decodedImage.Name = "decodedImage";
            this.decodedImage.Size = new System.Drawing.Size(167, 105);
            this.decodedImage.TabIndex = 23;
            this.decodedImage.TabStop = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(199, 121);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(82, 13);
            this.label20.TabIndex = 24;
            this.label20.Text = "Decoded image";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(79, 245);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(249, 36);
            this.button1.TabIndex = 27;
            this.button1.Text = "Decode";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // imageUploadButton
            // 
            this.imageUploadButton.Location = new System.Drawing.Point(176, 55);
            this.imageUploadButton.Name = "imageUploadButton";
            this.imageUploadButton.Size = new System.Drawing.Size(100, 28);
            this.imageUploadButton.TabIndex = 23;
            this.imageUploadButton.Text = "Upload image";
            this.imageUploadButton.UseVisualStyleBackColor = true;
            this.imageUploadButton.Click += new System.EventHandler(this.imageUploadButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 455);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.mistakeChanceText);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rText);
            this.Controls.Add(this.mText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.binaryInputTab.ResumeLayout(false);
            this.binaryInputTab.PerformLayout();
            this.textInputTab.ResumeLayout(false);
            this.textInputTab.PerformLayout();
            this.imageInputTab.ResumeLayout(false);
            this.imageInputTab.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.binaryOutputTab.ResumeLayout(false);
            this.binaryOutputTab.PerformLayout();
            this.textOutputTab.ResumeLayout(false);
            this.textOutputTab.PerformLayout();
            this.imageOutputTab.ResumeLayout(false);
            this.imageOutputTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.encodedImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sentImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.decodedImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox binaryMessageInputText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox mText;
        private System.Windows.Forms.TextBox rText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage binaryInputTab;
        private System.Windows.Forms.TabPage textInputTab;
        private System.Windows.Forms.TabPage imageInputTab;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage binaryOutputTab;
        private System.Windows.Forms.TabPage textOutputTab;
        private System.Windows.Forms.TabPage imageOutputTab;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button binaryMessageEncodeButton;
        private System.Windows.Forms.TextBox encodedBinaryMessage;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button textEncodeButton;
        private System.Windows.Forms.TextBox encodedTextMessage;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox inputTextMessage;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox decodedBinaryMessage;
        private System.Windows.Forms.Button binaryDecodeButton;
        private System.Windows.Forms.TextBox sentBinaryMessageMistakePositions;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox sentBinaryMessageText;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox decodedTextMessage;
        private System.Windows.Forms.Button textDecodeButton;
        private System.Windows.Forms.TextBox textMistakePositions;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox sentTextMessageText;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox mistakeChanceText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button imageEncodeButton;
        private System.Windows.Forms.PictureBox encodedImage;
        private System.Windows.Forms.PictureBox inputImage;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.PictureBox decodedImage;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.PictureBox sentImage;
        private System.Windows.Forms.Button imageUploadButton;
    }
}


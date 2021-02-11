using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace A7
{
    public partial class Form1 : Form
    {
        byte[] imageHead;
        byte[] sentImageBytes;

        public Form1()
        {
            InitializeComponent();
        }

        private void binaryMessageEncodeButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            string  binaryMessage = binaryMessageInputText.Text;
            int m = int.Parse(mText.Text);
            int r = int.Parse(rText.Text);

            Encoder encoder = new Encoder(binaryMessage, m, r);
            encoder.Encode();

            encodedBinaryMessage.Text = encoder.encodedMessage;

            double mistakeChance;
            double.TryParse(mistakeChanceText.Text, out mistakeChance);

            Channel channel = new Channel(encoder.encodedMessageBits, mistakeChance);
            channel.Send();

            sentBinaryMessageText.Text = channel.outputMessage;
            sentBinaryMessageMistakePositions.Text = string.Join(" ", channel.mistakePositions.Select(x => x.ToString()).ToArray());
        }

        private void binaryDecodeButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            string initialMessage = binaryMessageInputText.Text;
            string gotBinaryMessage = sentBinaryMessageText.Text;

            int m = int.Parse(mText.Text);
            int r = int.Parse(rText.Text);

            Decoder decoder = new Decoder(gotBinaryMessage, m, r);
            decoder.Decode();

            string decodedMessage = decoder.decodedMessage;
            if (r != 0 && decodedMessage.Length != initialMessage.Length)
            {
                decodedMessage = decodedMessage.Remove(initialMessage.Length);
            }

            decodedBinaryMessage.Text = decodedMessage;
        }

        private void textEncodeButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            string textMessage = string.Join("", Encoding.UTF8.GetBytes(inputTextMessage.Text).Select(n => Convert.ToString(n, 2).PadLeft(8, '0')));
            List<int> originalTextMessage = textMessage.ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToList();

            int m = int.Parse(mText.Text);
            int r = int.Parse(rText.Text);

            Encoder encoder = new Encoder(textMessage, m, r);
            encoder.Encode();

            encodedTextMessage.Text = encoder.encodedMessage;

            double mistakeChance;
            double.TryParse(mistakeChanceText.Text, out mistakeChance);

            Channel channel = new Channel(encoder.encodedMessageBits, mistakeChance);
            channel.Send();

            Channel originalMessageChannel = new Channel(originalTextMessage, mistakeChance);
            originalMessageChannel.Send();

            sentTextMessageText.Text = channel.outputMessage;
            textMistakePositions.Text = string.Join(" ", channel.mistakePositions.Select(x => x.ToString()).ToArray());

            originalSentTextOutput.Text = Encoding.UTF8.GetString(GetBytesFromBinaryString(originalMessageChannel.outputMessage));
            originalTextMistakePositions.Text = string.Join(" ", originalMessageChannel.mistakePositions.Select(x => x.ToString()).ToArray());
        }

        private void textDecodeButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            string initialMessage = string.Join("", Encoding.UTF8.GetBytes(inputTextMessage.Text).Select(n => Convert.ToString(n, 2).PadLeft(8, '0')));
            string gotTextMessage = sentTextMessageText.Text;

            int m = int.Parse(mText.Text);
            int r = int.Parse(rText.Text);

            Decoder decoder = new Decoder(gotTextMessage, m, r);
            decoder.Decode();

            string decodedMessage = decoder.decodedMessage;
            if(r != 0 && decodedMessage.Length != initialMessage.Length)
            {
                decodedMessage = decodedMessage.Remove(initialMessage.Length);
            }

            decodedTextMessage.Text = Encoding.UTF8.GetString(GetBytesFromBinaryString(decodedMessage));
        }

        public Byte[] GetBytesFromBinaryString(String binary)
        {
            var list = new List<Byte>();

            for (int i = 0; i < binary.Length; i += 8)
            {
                String t = binary.Substring(i, 8);

                list.Add(Convert.ToByte(t, 2));
            }

            return list.ToArray();
        }

        private void imageUploadButton_Click(object sender, EventArgs e)
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Bitamp image|*.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                inputImage.Image = new Bitmap(open.FileName);
            }
        }

        private void imageEncodeButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            int m = int.Parse(mText.Text);
            int r = int.Parse(rText.Text);
            Image image = inputImage.Image;

            byte[] imageInBytes = ImageToByteArray(image);
            this.imageHead = new byte[54];
            for(int i = 0; i < 54; i ++)
            {
                this.imageHead[i] = imageInBytes[i];
            }
            byte[] usedImageInBytes = imageInBytes.Skip(54).ToArray();

            string imageBinaryString = string.Join("", usedImageInBytes.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')));

            Encoder encoder = new Encoder(imageBinaryString, m, r);
            encoder.Encode();

            byte[] encodedImageBytes = GetBytesFromBinaryString(encoder.encodedMessage);
            byte[] encodedImageBytesWithHead = AddImageHeadBytes(encodedImageBytes);

            using (MemoryStream ms = new MemoryStream(encodedImageBytesWithHead))
            {
                encodedImage.Image = new Bitmap(ms);
            }

            double mistakeChance;
            double.TryParse(mistakeChanceText.Text, out mistakeChance);

            Channel channel = new Channel(encoder.encodedMessageBits, mistakeChance);
            channel.Send();

            byte[] sentImageBytes = GetBytesFromBinaryString(channel.outputMessage);
            this.sentImageBytes = sentImageBytes;
            byte[] sentImageBytesWithHead = AddImageHeadBytes(sentImageBytes);

            using (MemoryStream ms = new MemoryStream(sentImageBytesWithHead))
            {
                sentImage.Image = new Bitmap(ms);
            }

            List<int> originalMessageBitList = imageBinaryString.ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToList();
            Channel originalImageChannel = new Channel(originalMessageBitList, mistakeChance);
            originalImageChannel.Send();

            byte[] originalImageBytes = GetBytesFromBinaryString(originalImageChannel.outputMessage);
            byte[] sentOriginalImageBytesWithHead = AddImageHeadBytes(originalImageBytes);

            using (MemoryStream ms = new MemoryStream(sentOriginalImageBytesWithHead))
            {
                originalImage.Image = new Bitmap(ms);
            }
        }

        public byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            Image initialImage = inputImage.Image;
            byte[] initialImageBytes = ImageToByteArray(initialImage);
            byte[] usedInitialImageInBytes = initialImageBytes.Skip(54).ToArray();
            byte[] usedGotImageBytes = this.sentImageBytes;

            int m = int.Parse(mText.Text);
            int r = int.Parse(rText.Text);

            string initialImageBinaryString = string.Join("", usedInitialImageInBytes.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')));
            string gotImageBinaryString = string.Join("", usedGotImageBytes.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')));

            Decoder decoder = new Decoder(gotImageBinaryString, m, r);
            decoder.Decode();

            string decodedMessage = decoder.decodedMessage;
            if (r != 0 && decodedMessage.Length != initialImageBinaryString.Length)
            {
                decodedMessage = decodedMessage.Remove(initialImageBinaryString.Length);
            }

            byte[] decodedImageInBytes = GetBytesFromBinaryString(decodedMessage);
            byte[] decodedImageBytesWithHead = AddImageHeadBytes(decodedImageInBytes);

            Image decodedImageBox;
            using (MemoryStream ms = new MemoryStream(decodedImageBytesWithHead))
            {
                decodedImageBox = Image.FromStream(ms);
            }


            decodedImage.Image = decodedImageBox;
        }

        public byte[] AddImageHeadBytes(byte[] source)
        {
           byte[] destination = new byte[source.Length + 54];

           for (int i = 0; i < 54; i ++ )
           {
                destination[i] = this.imageHead[i];
           }

           for (int i = 0; i < source.Length; i++)
           {
               destination[i + 54] = source[i];
           }

           return destination;
        }

        public bool ValidateInput()
        {
            try
            {
                int m = int.Parse(mText.Text);
                int r = int.Parse(rText.Text);

                if(r > m)
                {
                    MessageBox.Show("R cannot be bigger than m", "M value error",
  MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }

                return true;
            }catch
            {
                MessageBox.Show("Please provide m and r values", "M value error",
   MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }
    }
}

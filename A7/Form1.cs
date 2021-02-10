using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public Form1()
        {
            InitializeComponent();
        }

        private void binaryMessageEncodeButton_Click(object sender, EventArgs e)
        {
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
            string textMessage = string.Join("", Encoding.UTF8.GetBytes(inputTextMessage.Text).Select(n => Convert.ToString(n, 2).PadLeft(8, '0')));

            int m = int.Parse(mText.Text);
            int r = int.Parse(rText.Text);

            Encoder encoder = new Encoder(textMessage, m, r);
            encoder.Encode();

            encodedTextMessage.Text = encoder.encodedMessage;

            double mistakeChance;
            double.TryParse(mistakeChanceText.Text, out mistakeChance);

            Channel channel = new Channel(encoder.encodedMessageBits, mistakeChance);
            channel.Send();

            sentTextMessageText.Text = channel.outputMessage;
            textMistakePositions.Text = string.Join(" ", channel.mistakePositions.Select(x => x.ToString()).ToArray());
        }

        private void textDecodeButton_Click(object sender, EventArgs e)
        {
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
    }
}

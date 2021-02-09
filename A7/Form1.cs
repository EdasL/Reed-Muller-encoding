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
            string gotBinaryMessage = sentBinaryMessageText.Text;
            int m = int.Parse(mText.Text);
            int r = int.Parse(rText.Text);

            Decoder decoder = new Decoder(gotBinaryMessage, m, r);
            decoder.Decode();

            decodedBinaryMessage.Text = decoder.decodedMessage;
        }

        private void textEncodeButton_Click(object sender, EventArgs e)
        {
            string textMessage = string.Join("", Encoding.UTF8.GetBytes(inputTextMessage.Text).Select(n => Convert.ToString(n, 2)));

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
            string gotTextMessage = sentTextMessageText.Text;
            int m = int.Parse(mText.Text);
            int r = int.Parse(rText.Text);

            Decoder decoder = new Decoder(gotTextMessage, m, r);
            decoder.Decode();

            var bytesAsStrings =
                decoder.decodedMessage.Select((c, i) => new { Char = c, Index = i })
                     .GroupBy(x => x.Index / 8)
                     .Select(g => new string(g.Select(x => x.Char).ToArray()));
            byte[] bytes = bytesAsStrings.Select(s => Convert.ToByte(s, 2)).ToArray();

            decodedTextMessage.Text = Encoding.UTF8.GetString(bytes);
        }
    }
}

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
    }
}

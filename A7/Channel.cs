using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A7
{
    class Channel
    {
        public List<int> message;
        public List<int> messageWithMistakes;
        public string outputMessage;
        public double mistakeChance;

        public Channel (List<int> message, double mistakeChance)
        {
            this.message = message;
            this.mistakeChance = mistakeChance;
        }

        public void Send()
        {
            Random random = new Random();
            this.messageWithMistakes = new List<int>();

            for (int i = 0; i < this.message.Count; i++)
            {
                double randomNumber = random.NextDouble();
                int sentValue = this.message[i];

                if (randomNumber < this.mistakeChance) {
                    sentValue = this.message[i] == 1 ? 0 : 1;
                }

                this.messageWithMistakes.Add(sentValue);
            }

            this.outputMessage = string.Join("", this.messageWithMistakes.Select(x => x.ToString()).ToArray());
        }
    }
}

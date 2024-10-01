/* Author: Jonathan Benz
 * Magic Eight Ball Class
 * No known issues */
namespace PE_Magic8Ball_JRB
{
    internal class MagicEightBall
    {
        // Declaring class fields. 
        private string owner;
        private string[] responses;
        private Random rng;
        private int timesShaken;

        /// <summary>
        /// Constructor for creating instances of the MagicEightBall class. 
        /// </summary>
        /// <param name="owner"> The name of who is using the Magic Eight Ball. </param>
        public MagicEightBall(string owner)
        {
            this.owner = owner;
            responses = [
                          "It is certain.",
                          "As I see it, yes.",
                          "Concentrate and ask again.",
                          "Outlook not so good.",
                          "Very doubtful."
                        ];
            rng = new Random();
            timesShaken = 0;
        }

        /// <summary>
        /// Generates a random response. Increments the timeShaken variable. 
        /// </summary>
        /// <returns> a random string from the responses string array. </returns>
        public string ShakeBall()
        {
            int randomIndex = rng.Next(0, responses.Length);
            string answer = String.Format("  > The Magic 8 Ball says: {0}", responses[randomIndex]);
            timesShaken++;
            return answer;
        }

        /// <summary>
        /// Returns a message based on the amount of times the ball has been shaken. 
        /// </summary>
        /// <returns> a string message. </returns>
        public string Report()
        {
            string returnMessage;
            if(timesShaken < 1)
            {
                returnMessage = String.Format("  > {0} has not shaken the ball yet.", owner);
                return returnMessage;
            }
            else if(timesShaken < 4)
            {
                returnMessage = String.Format("  > {0} has shaken the ball {1} times.", owner, timesShaken);
                return returnMessage;
            }
            else
            {
                returnMessage = String.Format("  > {0} has shaken the ball {1} times. That's a lot of questions!", owner, timesShaken);
                return returnMessage;
            }
        }
    }
}

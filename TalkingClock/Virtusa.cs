using System;
using System.Linq;

namespace TalkingClock
{
    public class Virtusa
    {
        public static string TellTime(string strTime)
        {
            string humanFriendlyTime;
            string tellMinutes = string.Empty;
            string tellBetween = string.Empty;
            string tellHours = string.Empty;
            string tellAfter = string.Empty;

            DateTime timeStamp;

            try
            {
                if (string.IsNullOrEmpty(strTime))
                {
                    timeStamp = DateTime.Now;
                }
                else
                {
                    timeStamp = Convert.ToDateTime(Sanitize(strTime));
                }

                if (timeStamp != null)
                {

                    int timeHours = timeStamp.TimeOfDay.Hours;
                    int timeMinutes = timeStamp.TimeOfDay.Minutes;

                    if (timeMinutes > 0 && timeMinutes <= 30)
                    {
                        tellBetween = "past";
                    }
                    else if (timeMinutes > 30)
                    {
                        tellBetween = "to";

                        if (timeHours < 24)
                        {
                            timeHours++;
                        }
                        else
                        {
                            timeHours = 1;
                        }
                    }

                    if (timeHours > 12 && timeHours < 24)
                        timeHours -= 12;

                    tellHours = DetermineHours(timeHours);
                    tellMinutes = DetermineMinutes(timeMinutes);

                    if (timeMinutes == 0 && timeHours != 0) tellAfter = "o'clock";

                    humanFriendlyTime = $"{tellMinutes} {tellBetween} {tellHours} {tellAfter}";
                }
                else
                {
                    humanFriendlyTime = "Unknown";
                }

            }
            catch (Exception ex)
            {
                humanFriendlyTime = "Unknown";
            }

            return Capitalize(humanFriendlyTime);
        }

        private static string Capitalize(string sentence)
        {
            sentence = sentence.Trim();

            return char.ToUpper(sentence.First()) + sentence.Substring(1).ToLower();
        }

        private static string Sanitize(string strTime)
        {
            strTime = strTime.Trim().Replace(".", ":");
            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz /\\[]@#,;'*+-!£$%^&*(){}<>?|`¬~_=".ToCharArray();

            return new string(strTime.Where(c => !alpha.Contains(c)).ToArray());
        }

        private static string DetermineHours(int timeHours)
        {
            string[] hourUnits = new[] { "midnight", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve" };

            if (timeHours == 24)
                return hourUnits[0];
            else
                return
                    hourUnits[timeHours];
        }

        private static string DetermineMinutes(int timeMinutes)
        {
            string[] minuteUnits = new[] { string.Empty, "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "quarter", "sixteen", "seventeen", "eighteen", "nineteen", "twenty", "twenty-one", "twenty-two", "twenty-three", "twenty-four", "twenty-five", "twenty-six", "twenty-seven", "twenty-eight", "twenty-nine", "half" };

            if (timeMinutes <= 30)
            {
                return minuteUnits[timeMinutes];
            }
            else
            {
                timeMinutes -= 29;
                return minuteUnits[^timeMinutes];
            }
        }
    }
}

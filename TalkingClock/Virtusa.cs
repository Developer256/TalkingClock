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
            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz /\\[]@#,;'*+-!£$%^&*(){}~_=".ToCharArray();

            return new string(strTime.Where(c => !alpha.Contains(c)).ToArray());
        }

        private static string DetermineHours(int timeHours)
        {
            string tellHours = string.Empty;

            switch (timeHours)
            {
                case 0:
                    tellHours = "midnight";
                    break;
                case 1:
                    tellHours = "one";
                    break;
                case 2:
                    tellHours = "two";
                    break;
                case 3:
                    tellHours = "three";
                    break;
                case 4:
                    tellHours = "four";
                    break;
                case 5:
                    tellHours = "five";
                    break;
                case 6:
                    tellHours = "six";
                    break;
                case 7:
                    tellHours = "seven";
                    break;
                case 8:
                    tellHours = "eight";
                    break;
                case 9:
                    tellHours = "nine";
                    break;
                case 10:
                    tellHours = "ten";
                    break;
                case 11:
                    tellHours = "eleven";
                    break;
                case 12:
                    tellHours = "twelve";
                    break;
                case 24:
                    tellHours = "midnight";
                    break;
            }

            return tellHours;
        }

        private static string DetermineMinutes(int timeMinutes)
        {
            string tellMinutes = string.Empty;

            switch (timeMinutes)
            {
                case 0:
                    break;
                case 1:
                    tellMinutes = "one";
                    break;
                case 2:
                    tellMinutes = "two";
                    break;
                case 3:
                    tellMinutes = "three";
                    break;
                case 4:
                    tellMinutes = "four";
                    break;
                case 5:
                    tellMinutes = "five";
                    break;
                case 6:
                    tellMinutes = "six";
                    break;
                case 7:
                    tellMinutes = "seven";
                    break;
                case 8:
                    tellMinutes = "eight";
                    break;
                case 9:
                    tellMinutes = "nine";
                    break;
                case 10:
                    tellMinutes = "ten";
                    break;
                case 11:
                    tellMinutes = "eleven";
                    break;
                case 12:
                    tellMinutes = "twelve";
                    break;
                case 13:
                    tellMinutes = "thirteen";
                    break;
                case 14:
                    tellMinutes = "fourteen";
                    break;
                case 15:
                    tellMinutes = "quarter";
                    break;
                case 16:
                    tellMinutes = "sixteen";
                    break;
                case 17:
                    tellMinutes = "seventeen";
                    break;
                case 18:
                    tellMinutes = "eighteen";
                    break;
                case 19:
                    tellMinutes = "nineteen";
                    break;
                case 20:
                    tellMinutes = "twenty";
                    break;
                case 21:
                    tellMinutes = "twenty-one";
                    break;
                case 22:
                    tellMinutes = "twenty-two";
                    break;
                case 23:
                    tellMinutes = "twenty-three";
                    break;
                case 24:
                    tellMinutes = "twenty-four";
                    break;
                case 25:
                    tellMinutes = "twenty-five";
                    break;
                case 26:
                    tellMinutes = "twenty-six";
                    break;
                case 27:
                    tellMinutes = "twenty-seven";
                    break;
                case 28:
                    tellMinutes = "twenty-eight";
                    break;
                case 29:
                    tellMinutes = "twenty-nine";
                    break;
                case 30:
                    tellMinutes = "half";
                    break;
                case 31:
                    tellMinutes = "twenty-nine";
                    break;
                case 32:
                    tellMinutes = "twenty-eight";
                    break;
                case 33:
                    tellMinutes = "twenty-seven";
                    break;
                case 34:
                    tellMinutes = "twenty-six";
                    break;
                case 35:
                    tellMinutes = "twenty-five";
                    break;
                case 36:
                    tellMinutes = "twenty-four";
                    break;
                case 37:
                    tellMinutes = "twenty-three";
                    break;
                case 38:
                    tellMinutes = "twenty-two";
                    break;
                case 39:
                    tellMinutes = "twenty-one";
                    break;
                case 40:
                    tellMinutes = "twenty";
                    break;
                case 41:
                    tellMinutes = "nineteen";
                    break;
                case 42:
                    tellMinutes = "eighteen";
                    break;
                case 43:
                    tellMinutes = "seventeen";
                    break;
                case 44:
                    tellMinutes = "sixteen";
                    break;
                case 45:
                    tellMinutes = "quarter";
                    break;
                case 46:
                    tellMinutes = "fourteen";
                    break;
                case 47:
                    tellMinutes = "thirteen";
                    break;
                case 48:
                    tellMinutes = "twelve";
                    break;
                case 49:
                    tellMinutes = "eleven";
                    break;
                case 50:
                    tellMinutes = "ten";
                    break;
                case 51:
                    tellMinutes = "nine";
                    break;
                case 52:
                    tellMinutes = "eight";
                    break;
                case 53:
                    tellMinutes = "seven";
                    break;
                case 54:
                    tellMinutes = "six";
                    break;
                case 55:
                    tellMinutes = "five";
                    break;
                case 56:
                    tellMinutes = "four";
                    break;
                case 57:
                    tellMinutes = "three";
                    break;
                case 58:
                    tellMinutes = "two";
                    break;
                case 59:
                    tellMinutes = "one";
                    break;
            }

            return tellMinutes;
        }
    }
}

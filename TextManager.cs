using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AncientMonkey
{
    internal class TextManager
    {
        public static string ConvertNumberToText(long number)
        {
            string text = "0";
            if (number <= 999)
            {
                text = number.ToString();
            }
            if (number >= 1000)
            {
                text = MathF.Round(number / 100) / 10 + "K";
            }
            if (number >= 100000)
            {
                text = MathF.Round(number / 1000) + "K";
            }
            if (number >= 1000000)
            {
                text = MathF.Round(number / 100000) / 10 + "M";
            }
            if (number >= 100000000)
            {
                text = MathF.Round(number / 1000000) + "M";
            }
            if (number >= 1000000000)
            {
                text = MathF.Round(number / 100000000) / 10 + "B";
            }
            return text;
        }
    }
}

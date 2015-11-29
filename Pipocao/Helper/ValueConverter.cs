using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pipocao.Helper
{
    public class ValueConverter
    {
        public static String boolToYesOrNo(bool value)
        {
            return value ? "Sim" : "Não";
        }

        public static String numberToText(int number)
        {
            switch (number)
            {
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                case 10:
                    return "ten";
                default:
                    return String.Empty;
            }
        }
    }
}
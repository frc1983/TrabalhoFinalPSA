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
    }
}
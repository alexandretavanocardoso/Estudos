using System;

namespace Extension_Methods.Lib.Extesions
{
    public static class StringExtension
    {
        public static string FirtsToUpper(this String str) // padrão de criação de extension methods (this Tipo str)
        {
            string firts = str.Substring(0, 1);

            string secondary = str.Substring(1);

            return firts.ToUpper() + secondary;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;


namespace CalCli.Extensions
{
    public static class CharExtensions
    {
        public static bool IsDigitOrDigitFormatting(this char character) =>
            char.IsDigit(character) || character is '.' or ',' or 'e'
        ;
    }
}

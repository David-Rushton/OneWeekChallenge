using CalCli.Extensions;
using System;
using System.Collections.Generic;
using System.IO;


namespace CalCli
{
    public class Tokeniser
    {
        readonly List<char> _operators = new(new[] {'+', '-', '/', '%', '*', '='});

        readonly List<Token> _tokens = new();


        public List<Token> Invoke(string[] input) => Invoke(new StringReader(string.Join(' ', input)));

        public List<Token> Invoke(string input) => Invoke(new StringReader(input));

        public List<Token> Invoke(StringReader input)
        {
            var counter = 0;
            var currentCharCode = -1;
            var currentValue = string.Empty;

            while((currentCharCode = input.Read()) != -1)
            {
                var currentChar = (char)currentCharCode;
                counter ++;

                if(currentChar.IsDigitOrDigitFormatting())
                {
                    currentValue += currentChar;
                    continue;
                }

                if(currentValue.Length >0)
                {
                    _tokens.Add(new Token(TokenType.Number, currentValue));
                    currentValue = string.Empty;
                }

                if(_operators.Contains(currentChar))
                {
                    _tokens.Add(new Token(TokenType.Operator, currentChar.ToString()));
                    continue;
                }

                // Discard.
                if(char.IsWhiteSpace(currentChar))
                    continue;


                // If we reach this point the passed value is not understood.
                throw new TokenException($"Unexpected value '{currentChar}' in input, at position {counter}");
            }

            // TODO: Fix
            // Repeated from above
            // Handles case where end of input is a number
            if(currentValue.Length >0)
            {
                _tokens.Add(new Token(TokenType.Number, currentValue));
                currentValue = string.Empty;
            }


            return _tokens;
        }


        public class TokenException: Exception
        {
            public TokenException(string message)
                : base(message)
            { }
        }
    }
}

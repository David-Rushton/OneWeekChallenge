using CalCli.Extensions;
using System;
using System.Collections.Generic;
using System.IO;


namespace CalCli.CalculatorParser
{
    public class Tokeniser
    {
        readonly Dictionary<char, TokenType> _map = new ()
        {
            ['('] = TokenType.LeftParenthesis,
            [')'] = TokenType.RightParenthesis,
            ['+'] = TokenType.PlusOperator,
            ['-'] = TokenType.MinusOperator,
            ['/'] = TokenType.DivideOperator,
            ['%'] = TokenType.ModuloOperator,
            ['*'] = TokenType.MultiplyOperator,
            ['='] = TokenType.EqualsOperator
        };


        public IEnumerable<Token> Invoke(string[] input) => Invoke(new StringReader(string.Join(' ', input)));

        public IEnumerable<Token> Invoke(string input) => Invoke(new StringReader(input));

        public IEnumerable<Token> Invoke(StringReader input)
        {
            var counter = 0;
            var readCharCode = -1;

            while((readCharCode = input.Peek()) != -1)
            {
                var newToken = (char)readCharCode switch
                {
                    char c when _map.ContainsKey(c) => CreateTokenUsingMappedChar(c),
                    char c when char.IsDigit(c) => CreateTokenFromNumber(),
                    char c when char.IsWhiteSpace(c) => CreateTokenFromWhitespace(),
                    _  => new Token(TokenType.Unsupported, ((char)input.Read()).ToString())
                };

                yield return newToken;
            }


            Token CreateTokenUsingMappedChar(char mappedChar)
            {
                counter++;
                return new Token(_map[mappedChar], ((char)input.Read()).ToString());
            }

            Token CreateTokenFromNumber()
            {
                var value = ReadFromInputWhile(c => c.IsDigitOrDigitFormatting());
                return new Token(TokenType.Number, value);
            }

            Token CreateTokenFromWhitespace()
            {
                var value = ReadFromInputWhile(c => char.IsWhiteSpace(c));
                return new Token(TokenType.Whitespace, value);
            }

            String ReadFromInputWhile(Func<char, bool> exitCondition)
            {
                var readBuffer = string.Empty;

                do
                {
                    counter++;
                    readBuffer += (char)input.Read();
                }
                while((readCharCode = input.Peek()) != -1 && exitCondition((char)readCharCode));

                return readBuffer;
            }
        }


        public class TokenException: Exception
        {
            public TokenException(string message)
                : base(message)
            { }
        }
    }
}

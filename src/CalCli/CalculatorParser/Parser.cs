using System;
using System.Collections.Generic;


namespace CalCli.CalculatorParser
{
    //         tokens         AST
    // +-------+    +--------+    +-------------+
    // | Lexer |--->| Parser |--->| Interpreter |
    // +-------+    +--------+    +-------------+
    //
    public class Parser
    {


        public void Invoke(IEnumerable<Token> tokens)
        {
            var iteration = 0;
            var depth = 0;
            Token? lastToken;


            // TODO: Replace with a rules engine
            foreach(var token in tokens)
            {
                iteration++;

                if(token.Type == TokenType.Unsupported)
                    throw new ParserException($"Unexpected token {token.Value}");

                if((token.Type == TokenType.RightParenthesis) && (depth ==0))
                    throw new ParserException($"Unexpected token {token.Value}");

                if(token.Type == TokenType.LeftParenthesis)
                    depth++;

                if(token.Type == TokenType.RightParenthesis)
                    depth--;


                if(iteration == 1 && ! (token.Type is TokenType.MinusOperator or TokenType.PlusOperator or TokenType.Number))
                    throw new ParserException($"Unexpected token {token.Value}");

                lastToken = token;
            }


            // pipeline
                // lex
                // parse
                // interpret




            if(depth != 0)
                throw new ParserException("Missing closing parenthesis in statement");

        }


        public class ParserException: Exception
        {
            public ParserException(string message)
                : base($"Parser error: {message}")
            { }
        }


        public class Node
        {
            public Node(Node left, Node symbol, Node right)
            {

            }
        }
    }
}

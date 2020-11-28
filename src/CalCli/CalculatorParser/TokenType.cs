using System;


namespace CalCli.CalculatorParser
{
    // TODO: Add Parentheses
    public enum TokenType
    {
        Number,
        PlusOperator,
        MinusOperator,
        DivideOperator,
        ModuloOperator,
        MultiplyOperator,
        EqualsOperator,
        LeftParenthesis,
        RightParenthesis,
        Whitespace,
        Unsupported
    }
}

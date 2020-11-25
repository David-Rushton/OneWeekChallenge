using System;


namespace CalCli
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

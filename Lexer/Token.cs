using LexerClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    public enum TokenType
    {
        //single character tokens
        LEFT_PAREN,
        RIGHT_PAREN,
        LEFT_BRACE,
        RIGHT_BRACE,
        COMMA,
        DOT,
        MINUS,
        PLUS,
        SEMICOLON,
        SLASH,
        STAR,
        EQUAL,
        

        //double tokens
        EXCLAMATION,
        EXCLAMATION_EQUAL,
        EQUAL_EQUAL,
        GREATER,
        GREATER_EQUAL,
        LESS,
        LESS_EQUAL,

        //Literals
        IDENTIFIER,
        STRING,
        INTEGER,
        DOUBLE,

        //keywords
        AND,
        CLASS,
        ELSE,
        FALSE,
        FOR,
        IF,
        OR,
        PRINT,
        RETURN,
        SUPER,
        TRUE,
        WHILE,

        END_OF_FILE


    }
    public class TokenClass
    {
        public TokenType Type { get; }
        public string Lexeme { get; }
        public object Literal { get; }
        public int Line { get; }

        public TokenClass(TokenType type, string lexeme, object literal, int line)
        {
            Type = type;
            Lexeme = lexeme;
            Literal = literal;
            Line = line;
        }
    }



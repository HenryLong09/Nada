using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.ComponentModel;
using System.Threading;

namespace LexerClass
{
    internal class Lexer
    {
        

        public void Main()
        {
            List<TokenClass> Tokens = new List<TokenClass>();
            ReadInInput();

        }

        private void ReadInInput()
        {
            //where the file will be read and each line will be tokenized and added to the list
            string source = File.ReadAllText("Code.txt");
            TokenIdentifier(source);
        }

        static readonly Dictionary<string, TokenType> keywords = new Dictionary<string, TokenType>
        {
            { "entero", TokenType.INTEGER },
            { "doble", TokenType.DOUBLE },
            { "cadena", TokenType.STRING },
            { "si", TokenType.IF },
            { "sino", TokenType.ELSE },
            { "mientras", TokenType.WHILE },
            { "para", TokenType.FOR },
            { "imprimir", TokenType.PRINT },
            { "verdadero", TokenType.TRUE },
            { "falso", TokenType.FALSE },
            { "clase", TokenType.CLASS },
            { "retornar", TokenType.RETURN },
            { "super", TokenType.SUPER },
            { "y", TokenType.AND },
            { "o", TokenType.OR }
        };


        static void TokenIdentifier(string strings)
        {
            //where the tokens will be identified           
            List<TokenClass> Tokens = new List<TokenClass>();
            int line = 0;
            
            for (int i = 0; i < strings.Length; i++)
            {
                
                switch (strings[i])  // no colon here
                {
                    //single character tokens
                    case '(':
                        Tokens.Add(new TokenClass(TokenType.LEFT_PAREN, "(", null, line));
                        break;
                    case ')':
                        Tokens.Add(new TokenClass(TokenType.RIGHT_PAREN, ")", null, line));
                        break;
                    case '{':
                        Tokens.Add(new TokenClass(TokenType.LEFT_BRACE, "{", null, line));
                        break;
                    case '}':
                        Tokens.Add(new TokenClass(TokenType.RIGHT_BRACE, "}", null, line));
                        break;
                    case ',':
                        Tokens.Add(new TokenClass(TokenType.COMMA, ",", null, line));
                        break;
                    case '.':
                        Tokens.Add(new TokenClass(TokenType.DOT, ".", null, line));
                        break;
                    case '-':
                        Tokens.Add(new TokenClass(TokenType.MINUS, "-", null, line));
                        break;
                    case '+':
                        Tokens.Add(new TokenClass(TokenType.PLUS, "+", null, line));
                        break;
                    case ';':
                        Tokens.Add(new TokenClass(TokenType.SEMICOLON, ";", null, line));
                        break;
                    case '*':
                        Tokens.Add(new TokenClass(TokenType.STAR, "*", null, line));
                        break;                   
                    case '\n':
                        line++;
                        break;

                    //double character tokens
                    case '!':
                        if (i + 1 < strings.Length && strings[i + 1] == '=')
                        {
                            Tokens.Add(new TokenClass(TokenType.EXCLAMATION_EQUAL, "!=", null, line));
                            i++;
                        }
                        else
                        {
                            Tokens.Add(new TokenClass(TokenType.EXCLAMATION, "!", null, line));
                        }
                        break;
                    case '=':
                        if (i + 1 < strings.Length && strings[i + 1] == '=')
                        {
                            Tokens.Add(new TokenClass(TokenType.EQUAL_EQUAL, "==", null, line));
                            i++;
                        }
                        else
                        {
                            Tokens.Add(new TokenClass(TokenType.EQUAL, "=", null, line));
                        }
                        break;
                    case '<':
                        if (i + 1 < strings.Length && strings[i + 1] == '=')
                        {
                            Tokens.Add(new TokenClass(TokenType.LESS_EQUAL, "<=", null, line));
                            i++;
                        }
                        else
                        {
                            Tokens.Add(new TokenClass(TokenType.LESS, "<", null, line));
                        }
                        break;
                    case '>':
                        if (i + 1 < strings.Length && strings[i + 1] == '=')
                        {
                            Tokens.Add(new TokenClass(TokenType.GREATER_EQUAL, ">=", null, line));
                            i++;
                        }
                        else
                        {
                            Tokens.Add(new TokenClass(TokenType.GREATER, ">", null, line));
                        }
                        break;
                }
                
                if (char.IsWhiteSpace(strings[i]))
                {
                    continue;
                }

                if (char.IsLetter(strings[i]))
                {
                    
                    
                    int start = i;

                    while (i < strings.Length && (char.IsLetterOrDigit(strings[i]) || strings[i] == '_'))
                    {
                        i++;
                    }

                    string identifier = strings.Substring(start, i - start);

                    if (keywords.ContainsKey(identifier))
                    {
                        Tokens.Add(new TokenClass(keywords[identifier], identifier, null, line));
                    }
                    else
                    {
                        Tokens.Add(new TokenClass(TokenType.IDENTIFIER, identifier, null, line));
                    }
                }
                else if (char.IsDigit(strings[i]))
                {
                    int start = i;
                    bool Double = false;

                    while (i < strings.Length && (char.IsDigit(strings[i]) || strings[i] == '.'))
                    {
                        if (strings[i] == '.' && i + 1 < strings.Length && char.IsDigit(strings[i + 1]))
                        {
                            Double = true;
                        }                        
                        i++;
                    }
                    if (char.IsLetter(strings[i]))
                    {
                        Console.WriteLine($"Int or Double on line {line} contains character different to a number");
                    }
                    string number = strings.Substring(start, i - start);

                    if (Double)
                    {
                        Tokens.Add(new TokenClass(TokenType.DOUBLE, number, null, line));
                    }
                    else
                    {
                        Tokens.Add(new TokenClass(TokenType.INTEGER, number, null, line));
                    }
                }

                int open = 0;
                if (strings[i] == '"' && open %2 == 0)
                {
                    open += 1;
                    int start = i+1;
                    string Literal = "";
                    while (start<strings.Length && strings[start] != '"')
                    {
                        Literal += strings[start];
                        start ++;
                    }
                    if (start >= strings.Length)
                    {
                        Console.WriteLine($"String on line {line} not complete");
                    }
                    
                    
                    Tokens.Add(new TokenClass(TokenType.STRING, "\"" + Literal + "\"", Literal, line));
                    i = start;
                }

            }

            for (int i = 0; i < Tokens.Count; i++)
            {
                Console.Write(Tokens[i].Type);
                Console.Write(Tokens[i].Lexeme);
                Console.Write(Tokens[i].Literal);
                Console.Write(Tokens[i].Line);
                Console.WriteLine();
            }
            Console.ReadLine();

        }
     }      
}








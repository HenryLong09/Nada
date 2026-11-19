using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ParserClass
{
    abstract class ASTNode { }
    
    abstract class Expr:ASTNode
    {
    }

    class BinaryExpr : Expr
    {
        public Expr Left;
        public Expr Right;
        public TokenClass Operator;

        public BinaryExpr(Expr left, TokenClass op, Expr right)
        {
            this.Left = left;
            this.Operator = op;
            this.Right = right;
        }
    }

    class LiteralExpr : Expr
    {
        public string Value;

        public LiteralExpr(string value)
        {
            this.Value = value;
        }

    }

    class Stmt:ASTNode
    {
        
    }

    class LiteralStmt : Stmt
    {
        public string Value;

        public LiteralStmt(string value)
        {
            this.Value = value;
        }
    }



    class PrintStmt : Stmt
    {
        
        public PrintStmt(TokenType type, Stmt left) 
        { 
        
        }
    }




    // Continue the parser stages,  the class system and go back to basics for logic with returning values


    internal class Parser
    {
        private List<TokenClass> tokens;
        private List<ASTNode> List;
        int count = 0;
        bool started = false;

        public Parser(List<TokenClass> tokens)
        {
            this.tokens = tokens;
        }

        public int tokenCount = 0;
        public void Main()
        {
            Expr Henry = new LiteralExpr("Henry");
            List.Add(Henry);
            //Expr result = AdditionSubtraction();
            //WriteTree(result);

            
            

            switch (tokens[tokenCount].Lexeme)
            {
                case "PRINT":
                    {
                        PrintStmt STMTPrint = PrintStatement();

                        
                        return;                        
                    }
            }

        }

        static void WriteTree(Expr result)
        {
            if (result.GetType() == typeof(LiteralExpr))
            {
                LiteralExpr lit = (LiteralExpr)result;
                Console.Write(lit.Value);
            }
            else if (result.GetType() == typeof(BinaryExpr))
            {
                BinaryExpr bin = (BinaryExpr)result;
                Console.Write("(");
                WriteTree(bin.Left);
                Console.Write(" " + bin.Operator.Lexeme + " ");
                WriteTree(bin.Right);
                Console.Write(")");
            }
        }

        private PrintStmt PrintStatement()
        {
            TokenType type = tokens[tokenCount].Type;
            tokenCount++;
            //left bracjet
            tokenCount++;
            LiteralStmt right = new LiteralStmt(tokens[tokenCount].Lexeme);
            tokenCount++;
            //right bracket
            tokenCount++;
            //semicolon
            tokenCount++;
             
            return new PrintStmt(type,right);
        }
        private Expr AdditionSubtraction()
        {
            int temp = 0;
            Expr result;

            //gets left value
            result = MultiplicationDivision(ref temp);



            while (temp < tokens.Count && (tokens[temp].Type == TokenType.PLUS || tokens[temp].Type == TokenType.MINUS))
            {
                TokenClass Operator = tokens[temp];
                temp++;

                Expr Right = MultiplicationDivision(ref temp);

                result = new BinaryExpr(result, Operator, Right);
            }

            return result;
        }

        //4 + 10 * 4 + 10 - 5 + 10 * 2 * 3
        //4 + 10 + 4 * 10 - 5 + 10 * 2 * 3

        //4 + 10 + (4 * 10) - 5 + 10 * 2 * 3


        private Expr MultiplicationDivision(ref int temp)
        {
            //gets left value
            Expr result = new LiteralExpr(tokens[temp].Lexeme);
            temp++;

            while (temp < tokens.Count && (tokens[temp].Type == TokenType.STAR || tokens[temp].Type == TokenType.SLASH))
            {
                TokenClass Operator = tokens[temp];
                temp++;

                Expr rightSide = new LiteralExpr(tokens[temp].Lexeme);
                temp++;


                result = new BinaryExpr(result, Operator, rightSide);

            }

            return result;       
        }

        private Expr Expression()
        {

        }

    }
    
}



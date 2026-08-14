using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserClass
{
    abstract class Expr
    {
    }

    class BinaryExpr : Expr
    {
        public Expr Left;
        public Expr Right;
        public TokenClass Operator;

        public BinaryExpr(Expr left, TokenClass op, Expr right)
        {
            Left = left;
            Operator = op;
            Right = right;
        }

    }
    
          

        // Continue the parser stages,  the class system and go back to basics for logic with returning values
        

        internal class Parser
        {
            private List<TokenClass> tokens;
            int count = 0;

            public Parser(List<TokenClass> tokens)
            {
                this.tokens = tokens;
            }

            private Expr AdditionSubtraction()
            {
                int left = MultiplicationDivision();
                return;
            }
            
            4*10 * 4 + 10  5 + 10 * 2 * 3
            private Expr MultiplicationDivision()
            {
                List<TokenClass> BinaryExpression = new List<TokenClass>();
                int temp = 0;
                int StarSlashPosition;
                double DoubleReplacer;
                
            }


        }

    }
    
}



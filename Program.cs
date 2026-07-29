using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nada
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Runner();
        }
        static void Runner()
        {
            LexerClass.Lexer Lexer = new LexerClass.Lexer();
            Lexer.Main();
        }

        
    }
}

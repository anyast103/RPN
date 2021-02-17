using System;
using System.IO;
using System.Collections.Generic;


namespace RPN
{
    class GetString
    {
        private static string[] task = File.ReadAllText("input.txt").Split(new char[] { ' ' });

        public static string[] Task
        {

            get { return task; }
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            GetRPN.IteratingThroughElements();
        }
    }
    
    
}

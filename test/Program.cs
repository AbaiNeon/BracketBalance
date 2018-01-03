using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    /*Проверить, правильно ли в заданном тексте расставлены круглые скобки*/
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = "({[ ]})";
            string str2 = "({[}])";
            string str3 = "((3+2)+{6+[2-5]}*2)";

            Console.WriteLine(CheckBrackets(str1));
            Console.WriteLine(CheckBrackets(str2));
            Console.WriteLine(CheckBrackets(str3));

            Console.ReadLine();
        }

        static bool CheckBrackets(string str)
        {
            bool result = true;

            #region countOpenCloseBrackets
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '(' || str[i] == '{' || str[i] == '[')
                {
                    count++;
                }
                else if (str[i] == ')' || str[i] == '}' || str[i] == ']')
                {
                    count--;
                }

                if (count < 0)
                {
                    return false;
                }
            }

            if (count != 0)
            {
                return false;
            }
            #endregion

            Stack<char> brackets = new Stack<char>();

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '(' || str[i] == '{' || str[i] == '[')
                {
                    brackets.Push(str[i]);
                }

                if (str[i] == ')' || str[i] == '}' || str[i] == ']')
                {
                    if (str[i] == ')' && brackets.Peek() == '(')
                        brackets.Pop();
                    else if (str[i] == ')' && brackets.Peek() != '(')
                        return false;
                    
                    if (str[i] == '}' && brackets.Peek() == '{')
                        brackets.Pop();
                    else if (str[i] == '}' && brackets.Peek() != '{')
                        return false;
                 
                    if (str[i] == ']' && brackets.Peek() == '[')
                        brackets.Pop();
                    else if (str[i] == ']' && brackets.Peek() != '[')
                        return false;
                }
            }
            
            return result;
        }
    }
}


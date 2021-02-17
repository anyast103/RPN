using System;
using System.Collections.Generic;
using System.Text;

namespace RPN
{
    class GetRPN
    {
       
            private static List<string> operations = new List<string> { "+", "-", "*", "/" };
            private static Stack<string> operatoor = new Stack<string>();
            private static Queue<string> nums = new Queue<string>();
            public static void IteratingThroughElements()
            {
                List<string> Prior2 = new List<string> { "*", "/" };
                List<string> Prior1 = new List<string> { "-", "+" };
                List<string> Scob = new List<string> { "(", ")" };


                for (int i = 0; i < GetString.Task.Length; i++)
                {
                    if (operations.Contains(GetString.Task[i]) == false && Scob.Contains(GetString.Task[i]) == false)
                    {
                        nums.Enqueue(GetString.Task[i]);
                    }
                    else if (operations.Contains(GetString.Task[i]) && Scob.Contains(GetString.Task[i]) == false)
                    {
                        if (operatoor.Count == 0 || operatoor.Peek() == "(")
                        {
                            operatoor.Push(GetString.Task[i]);
                        }
                        else if (Prior2.Contains(GetString.Task[i]) && Prior1.Contains(operatoor.Peek()))
                        {
                            operatoor.Push(GetString.Task[i]);
                        }
                        else if (Prior1.Contains(GetString.Task[i]) && (Prior1.Contains(operatoor.Peek()) || Prior2.Contains(operatoor.Peek())))
                        {
                            do
                            {
                                nums.Enqueue(operatoor.Pop());

                                if (operatoor.Count == 0)
                                    break;

                            } while (Prior1.Contains(operatoor.Peek()) == false || operatoor.Peek() != "(");

                            operatoor.Push(GetString.Task[i]);
                        }



                    }
                    else if (GetString.Task[i] == ("("))
                    {
                        operatoor.Push(GetString.Task[i]);
                    }

                    else if (GetString.Task[i] == (")"))
                    {
                        do
                        {
                            nums.Enqueue(operatoor.Pop());

                        } while (operatoor.Peek() != "(");
                        if (operatoor.Peek() == "(")
                            operatoor.Pop();

                    }
                }
                nums.Enqueue(operatoor.Pop());
                foreach (var c in nums)
                {
                    Console.Write(c);
                }
            }
    }
}

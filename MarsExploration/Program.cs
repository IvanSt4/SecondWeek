using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'marsExploration' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING s as parameter.
     */

    public static int marsExploration(string s)
    {
        int counter = 0;
        int numSignals = (s.Length / 3);

        Stack<char> charStack = new Stack<char>();

        char[] charArr = s.ToCharArray();

        foreach (var item in charArr)
        {
            charStack.Push(item);
        }

        for (int i = 0; i < numSignals; i++)
        {
            
                char one = charStack.Pop();
                if (one != 'S')
                {
                    counter++;
                }

                char two = charStack.Pop();
                if (two != 'O')
                {
                    counter++;
                }

                char three = charStack.Pop();
                if (three != 'S')
                {
                    counter++;
                }
            
        }

        //string pattern = @"SOS";

        return counter;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter("../../../output.txt");

        string s = Console.ReadLine();

        int result = Result.marsExploration(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}

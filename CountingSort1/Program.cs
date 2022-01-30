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
     * Complete the 'countingSort' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static List<int> countingSort(List<int> arr)
    {
        int n = 100;
        List<int> result = new List<int>();

        for (int i = 0; i < n; i++)
        {
            int counter = CountOccurenceOfValue2(arr, i);
            result.Add(counter);
        }

        return result;
    }

    static int CountOccurenceOfValue2(List<int> list, int valueToFind)
    {
        int count = list.Where(temp => temp.Equals(valueToFind))
                    .Select(temp => temp)
                    .Count();
        return count;
    }

    //static int CountOccurenceOfValue(List<int> list, int valueToFind)
    //{
    //    return ((from temp in list where temp.Equals(valueToFind) select temp).Count());
    //}

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter("../../../output.txt");

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        List<int> result = Result.countingSort(arr);

        textWriter.WriteLine(String.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
    }
}

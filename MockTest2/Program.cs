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
     * Complete the 'flippingMatrix' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY matrix as parameter.
     */

    public static int flippingMatrix(List<List<int>> matrix)
    {
        int maxSum = 0; 

        List<List<int>> subMatrixMax = new List<List<int>>();
        subMatrixMax = CompareMirrorElements(matrix);

        List<List<int>> transponseMatrix = Transponse(subMatrixMax);

        var resultMaxMatrix = CompareMirrorElements(transponseMatrix);

        for (int i = 0; i < resultMaxMatrix.Count; i++)
        {
            foreach (var item in resultMaxMatrix[i])
            {
                maxSum += item;
            }
        }
       

        return maxSum;
    }

    private static List<List<int>> CompareMirrorElements(List<List<int>> matrix)
    {
        int a;
        int halfLengthList = (matrix[0].Count / 2);

        var abMax = new List<List<int>>();

        for (int i = 0; i < matrix.Count; i++)
        {
            List<int> ab = new List<int>();
            for (int j = 0; j < halfLengthList; j++)
            {
                if (matrix[i][j] >= matrix[i][matrix[0].Count - j - 1])
                {
                    a = matrix[i][j];
                }
                else
                {
                    a = matrix[i][matrix[0].Count - j - 1];
                }

                ab.Add(a);
            }
            abMax.Add(ab);

        }
        return abMax;
    }

    public static List<List<int>> Transponse(List<List<int>> matrix)
    {
        int cols = matrix.Count;
        int rows = matrix[0].Count;

        List<List<int>> result = new List<List<int>>();

        for (int i = 0; i < rows; i++)
        {
            List<int> a = new List<int>();
            for (int j = 0; j < cols; j++)
            {
                a.Add(matrix[j][i]);
            }
            result.Add(a);
        }
        

        return result;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter("../../../output.txt");

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            
            List<List<int>> matrix = new List<List<int>>();

            for (int i = 0; i < 2 * n; i++)
            {
                matrix.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(matrixTemp => Convert.ToInt32(matrixTemp)).ToList());
            }

            int result = Result.flippingMatrix(matrix);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}

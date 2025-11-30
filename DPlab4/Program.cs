using System;

class Program
{
    static void WhileSum(int[] first, int[] second, int[] output)
    {
        int i = 0;
        while (i < first.Length)
        {
            output[i] = first[i] + second[i];
            i++;
        }
    }

    static void ForSum(int[] first, int[] second, int[] output)
    {
        for (int i = 0; i < first.Length; i++)
        {
            output[i] = first[i] + second[i];
        }
    }


    static void PrintList(int[] numbers)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(numbers[i]);
        }
    }

    static void Main()
    {
        int[] A = { 2, 5, 7 };
        int[] B = { 4, 3, 8 };

        int[] result = new int[A.Length];

        WhileSum(A, B, result);
        Console.WriteLine("Результат (while): " + string.Join(", ", result));

        ForSum(A, B, result);
        Console.WriteLine("Результат (for): " + string.Join(", ", result));
        Console.WriteLine(A[0]);
        Console.WriteLine(A[1]);
        Console.WriteLine(A[2]);

        int[] myList = { 1, 2, 3, 4, 5 };
        PrintList(myList);

    }
}




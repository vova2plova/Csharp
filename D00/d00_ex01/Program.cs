using System.IO;
using System;

Console.WriteLine("Enter Name:");
string? name = Console.ReadLine();
string path = @"C:\Users\user\Desktop\trainingC#\Ex00\d00_ex01\us_names.txt"; /*Путь до файла*/
FindRightName(name);

/*Функция нахождения имени где дистанция Левенштейна <= 1*/

void FindRightName(string _name)
{
    if (name == null)
    {
        Console.WriteLine("Your name was not found.");
        return;
    }
    using (StreamReader sr = new StreamReader(path))
    {
        string s;
        while ((s = sr.ReadLine()) != null)
        {
            if (LevenshteinDistance(s, _name) == 0)
            {
                Console.WriteLine($"Hello {s}");
                return;
            }
            if (LevenshteinDistance(s, _name) < 2)
            {
                Console.WriteLine(LevenshteinDistance(s, _name));
                Console.WriteLine($"Did you mean “{s}”? Y/N");
                string? answ = Console.ReadLine();
                if (answ == null)
                {
                    Console.WriteLine("Something went wrong. Check your input and retry.");
                    return;
                }
                if (answ.Equals("Y"))
                {
                    Console.WriteLine($"Hello {s}");
                    return;
                }
                else if (answ.Equals("N"))
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("Something went wrong. Check your input and retry.");
                    return;
                }
            }
        }
        Console.WriteLine("Your name was not found.");
    }
}

/*Нахождения минимума среди 3х чисел*/

static int Minimum(int a, int b, int c) => (a = a < b ? a : b) < c ? a : c;

/*Дистанция Левештейна*/

static int LevenshteinDistance(string firstWord, string secondWord)
{
    var n = firstWord.Length + 1;
    var m = secondWord.Length + 1;
    var matrixD = new int[n, m];

    const int deletionCost = 1;
    const int insertionCost = 1;

    for (var i = 0; i < n; i++)
    {
        matrixD[i, 0] = i;
    }

    for (var j = 0; j < m; j++)
    {
        matrixD[0, j] = j;
    }

    for (var i = 1; i < n; i++)
    {
        for (var j = 1; j < m; j++)
        {
            var substitutionCost = firstWord[i - 1] == secondWord[j - 1] ? 0 : 1;

            matrixD[i, j] = Minimum(matrixD[i - 1, j] + deletionCost,          // удаление
                                    matrixD[i, j - 1] + insertionCost,         // вставка
                                    matrixD[i - 1, j - 1] + substitutionCost); // замена
        }
    }

    return matrixD[n - 1, m - 1];
}
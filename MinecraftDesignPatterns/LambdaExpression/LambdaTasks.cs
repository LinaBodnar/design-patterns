using System;
using System.Collections.Generic;
using System.Linq;

namespace MinecraftDesignPatterns.LambdaExpression;

public static class LambdaTasks
{
    public static List<int> FilterOddNumbers(List<int> numbers)
    {
        return numbers.Where(x => x % 2 != 0).ToList();
    }
    
    public static double FindAverage(List<double> values)
    {
        if (values == null || values.Count == 0) return 0;
        return values.Average();
    }
    
    public static List<string> SortAlphabetically(List<string> strings)
    {
        return strings.OrderBy(s => s).ToList();
    }
    
    public static int SumOfEvenNumbers(List<int> numbers)
    {
        return numbers.Where(x => x % 2 == 0).Sum();
    }
    
    public static long CalculateFactorial(int n)
    {
        if (n < 0) throw new ArgumentException("Число має бути невід'ємним.");
        if (n == 0 || n == 1) return 1;

        return Enumerable.Range(1, n).Aggregate((acc, x) => acc * x);
    }
    
    public static (long multiplication, int sum) MultiplyAndSum(List<int> numbers)
    {
        if (numbers == null || numbers.Count == 0) return (0, 0);

        int sum = numbers.Sum();
        long multiplication = numbers.Aggregate(1L, (acc, x) => acc * x);

        return (multiplication, sum);
    }
    
    public static List<int> SquareNumbers(List<int> numbers)
    {
        return numbers.Select(x => x * x).ToList();
    }
    
    public static List<string> SortByLength(List<string> strings)
    {
        return strings.OrderBy(s => s.Length).ToList();
    }
    
    public static int CountWords(string sentence)
    {
        if (string.IsNullOrWhiteSpace(sentence)) return 0;

        return sentence.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
    }
    
    public static string FindFirstNonEmptyString(List<string> strings)
    {
        return strings.FirstOrDefault(s => !string.IsNullOrEmpty(s));
    }
    
    public static bool AreAllStartingWithUpperCase(List<string> strings)
    {
        if (strings == null || strings.Count == 0) return false;

        return strings.All(s => !string.IsNullOrEmpty(s) && char.IsUpper(s[0]));
    }
    
    public static int FindSecondLargest(List<int> numbers)
    {
        if (numbers == null || numbers.Distinct().Count() < 2)
            throw new ArgumentException("Список повинен містити мінімум два унікальних числа.");

        return numbers.Distinct().OrderByDescending(x => x).Skip(1).First();
    }
    
    public static int? FindMaxEvenNumber(List<int> numbers)
    {
        var evenNumbers = numbers.Where(x => x % 2 == 0).ToList();
        if (!evenNumbers.Any()) return null;

        return evenNumbers.Max();
    }
}
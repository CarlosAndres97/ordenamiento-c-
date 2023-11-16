/*
    Estudiante: Carlos Andres Soriano Gonzalez
    Codigo: 
    Grupo: 200
    Curso: Programacion
    Programa: Ingenieria de Sistemas
    Fuente: Autoría propia
*/
using System;
using System.Runtime.InteropServices;
namespace OrdenamientoDeNumeros;
class Program
{
    static void insertNumber(int[] numbers)
    {
        Console.WriteLine("Insert 10 numbers: ");

        for (int i = 0; i < 10; i++)
        {
            int number;
            bool validNumber = false;
            do
            {
                Console.Write($"Insert a number: ");
                number = Convert.ToInt32(Console.ReadLine());
                if (Array.IndexOf(numbers, number) == -1)
                    validNumber = true;
                else
                    Console.WriteLine("Number already exists in the array. Please enter a different number.");
            } while (!validNumber);
            numbers[i] = number;
        }
    }
    static void printNumbers(int[] numbers)
    {
        Console.WriteLine("Sorted numbers:");
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write(numbers[i] + " ");
        }
    }
    static void createFile(int[] numbers)
    {
        try
        {
            StreamWriter sw = new StreamWriter("sortedNumbers.txt");
            {
                foreach (int number in numbers)
                {
                    sw.WriteLine(number);
                }
                sw.Close();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        Console.WriteLine();
    }

    static void bubbleSort(int[] numbers)
    {

        // Bubble sort algorithm
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            for (int j = 0; j < numbers.Length - i - 1; j++)
            {
                if (numbers[j] > numbers[j + 1])
                {
                    int temp = numbers[j];
                    numbers[j] = numbers[j + 1];
                    numbers[j + 1] = temp;
                }
            }
        }
    }

    static void insertionSort(int[] numbers)
    {
        for (int i = 1; i < numbers.Length; i++)
        {
            int temp = numbers[i];
            int j = i - 1;

            while (j >= 0 && numbers[j] > temp)
            {
                numbers[j + 1] = numbers[j];
                j--;
            }
            numbers[j + 1] = temp;

        }
    }
    static void selectionSort(int[] numbers)
    {
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            int min = i;
            for (int j = i + 1; j < numbers.Length; j++)
            {
                if (numbers[min] > numbers[j])
                    min = j;
            }
            int temp = numbers[i];
            numbers[i] = numbers[min];
            numbers[min] = temp;
        }
    }
    static void shellSort(int[] numbers)
    {
        int n = numbers.Length;
        for (int gap = n / 2; gap > 0; gap /= 2)
        {
            for (int i = gap; i < n; i += 1)
            {
                int temp = numbers[i];
                int j;
                for (j = i; j >= gap && numbers[j - gap] > temp; j -= gap)
                {
                    numbers[j] = numbers[j - gap];
                }
                numbers[j] = temp;
            }
        }
    }
    static void Main(string[] args)
    {
        int option;
        int[] numbers = new int[10];
        do
        {
            Console.WriteLine("Select a sorting algorithm: ");
            Console.WriteLine("1. Bubble Sort");
            Console.WriteLine("2. Insertion Sort");
            Console.WriteLine("3. Selection Sort");
            Console.WriteLine("4. Shell Sort");
            Console.WriteLine("5. Exit");
            option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    insertNumber(numbers);
                    bubbleSort(numbers);
                    printNumbers(numbers);
                    createFile(numbers);
                    break;
                case 2:
                    insertNumber(numbers);
                    insertionSort(numbers);
                    printNumbers(numbers);
                    createFile(numbers);
                    break;
                case 3:
                    insertNumber(numbers);
                    selectionSort(numbers);
                    printNumbers(numbers);
                    createFile(numbers);
                    break;
                case 4:
                    insertNumber(numbers);
                    shellSort(numbers);
                    printNumbers(numbers);
                    createFile(numbers);
                    break;
                case 5:
                    Console.WriteLine("Exiting program...");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please select a valid option.");
                    break;
            }
        } while (option != 5);
    }
}

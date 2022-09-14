using System;

public class MainClass
{
    public static void Main()
    {
        var A = new Matrix();
        A.Read();
        double n = double.Parse(Console.ReadLine());
        A.Multiply(n);
        A.Write();
    }
}
public class Matrix
{
    public double[,] data;
    public byte rows;
    public byte columns;
    ///<summary>
    ///Метод считывает с консоли двухмерный массив
    ///</summary>
    public void Read()
    {
        string[] sizeOfMatrix = Console.ReadLine().Split(" ");
        this.rows = byte.Parse(sizeOfMatrix[0]);
        this.columns = byte.Parse(sizeOfMatrix[1]);
        data = new double[rows, columns];
        for (byte i = 0; i < rows; i++)
        {
            string[] row = Console.ReadLine().Split(" ");
            for (byte j = 0; j < columns; j++)
            {
                data[i, j] = double.Parse(row[j]);
            }
        }
    }
    ///<summary>
    ///Метод выводит двухмерный массив на консоль
    ///</summary>
    public void Write()
    {
        for (byte i = 0; i < rows; i++)
        {
            for (byte j = 0; j < columns; j++)
            {
                if (j == columns - 1)
                {
                    Console.WriteLine(data[i, j]);
                    break;
                }
                Console.Write(data[i, j] + " ");
            }
        }
    }
    ///<summary>Метод выводит на консоль результат умножения матрицы на число</summary>
    public void Multiply(double n)
    {
        for (byte i = 0; i < rows; i++)
        {
            for (byte j = 0; j < columns; j++)
            {
                data[i,j] *= n;
            }
        }
    }
}
using System;

public class MainClass
{
    public static void Main()
    {
        var A = new Matrix();
        A.Read();
        var T = Matrix.MatrixTransposition(A);
        T.Write();

        //double n = double.Parse(Console.ReadLine());
        //var M = Matrix.MultiplyByNumber(n, A);
        //A.Write();

        var B = new Matrix();
        B.Read();

        //var K = Matrix.Sum(A, B);
        //A.Write();
        //var C = Matrix.MatrixMultiply(A, B);
        //C.Write();

        var R = Matrix.MatrixMultiply(Matrix.Sum(Matrix.MultiplyByNumber(5, A), Matrix.MultiplyByNumber(2, B)), A);
        R.Write();
    }
}
public class Matrix
{
    private double[,] data;
    private byte rows;
    private byte columns;
    
    //Конструкторы
    public Matrix() { }
    public Matrix(byte rows, byte columns)
    {
        this.rows = rows;
        this.columns = columns;
        this.data = new double[rows, columns];
    }
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
    static public Matrix MultiplyByNumber(double n, Matrix A)
    {
        Matrix C = new Matrix(A.rows, A.columns);
        for (byte i = 0; i < A.rows; i++)
        {
            for (byte j = 0; j < A.columns; j++)
            {
                C.data[i, j] = A.data[i, j] * n;
            }
        }
        return C;
    }
    static public Matrix Sum(Matrix A,Matrix B)
    {
        if (A.rows == B.rows && A.columns == B.columns)
        {
            Matrix C = new Matrix(A.rows, A.columns);
            for (byte i = 0; i < A.rows; i++)
            {
                for (byte j = 0; j < A.columns; j++)
                {
                    C.data[i, j] = A.data[i, j] + B.data[i, j];
                }
            }
            return C;
        }
        else
        {
            Console.WriteLine("Матрицы разного размера!");
            return null;
        }
    }
    static public Matrix MatrixMultiply(Matrix A, Matrix B)
    {
        if (A.columns == B.rows)
        {
            Matrix C = new Matrix(A.rows, B.columns);
            //C.data = new double[C.rows, C.columns];
            for (byte i = 0; i < A.rows; i++)
            {
                for(byte j = 0; j < B.columns; j++)
                {
                    for (byte k = 0; k < A.columns; k++)
                    {
                        C.data[i,j] += A.data[i,k] * B.data[k,j];
                    }
                }
            }
            return C;
        }
        else
        {
            Console.WriteLine("Для умножения матриц кол-во столбцов первой матрицы должно быть равно кол-ву строк второй матрицы!");
            return null;
        }
    }
    static public Matrix MatrixTransposition(Matrix A)
    {
        Matrix B = new Matrix(A.columns, A.rows);
        for (byte i = 0; i < A.rows; i++)
        {
            for (byte j = 0; j < A.columns; j++)
            {
                B.data[j,i] = A.data[i,j];
            }
        }
        return B;
    }
}
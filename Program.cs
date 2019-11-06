
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            double divisor = 0, multiplier = 0;

            Console.WriteLine("*******SOLUTION OF SYSTEMS OF LINEAR EQUATIONS*******\n");

        x:
            Console.Write("Enter number of equations: ");
            int row = 0, col = 0;
            double[,] matrix = null;
            try
            {
                row = Convert.ToInt32(Console.ReadLine());
                col = row + 1;
                matrix = new double[row, col];
            }
            catch (Exception)
            {
                // Console.WriteLine(ex);
                Console.WriteLine("\nInvalid Input!\nTry Again\n");
                goto x;
            }


        y:
            Console.WriteLine("\nEnter coefficients and right hand side constant of your equations\n");
            for (int i = 0; i < row; i++)
            {
                Console.WriteLine("Equation # " + (i + 1));
                for (int j = 0; j < col; j++)
                {
                z:
                    try
                    {
                        matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        goto z;
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("These must be your equations!\n");
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (j != col - 1)
                    {
                        Console.Write("{0}(x{1})", matrix[i, j], j + 1);
                        if (j < col - 2)
                        {
                            Console.Write(" + ");
                        }
                    }
                    else
                    {
                        Console.Write(" = " + matrix[i, j]);
                    }
                }
                Console.WriteLine();
            }
            Console.Write("\nEnter 'y' for confirmation or press 'Enter' to repeat: ");
            char indicator = Convert.ToChar("n");
            try
            {
                indicator = Convert.ToChar(Console.ReadLine());
            }
            catch (Exception)
            {
                goto y;
            }

            if (indicator == 'y' || indicator == 'Y')
            {
                Console.WriteLine("\nInitial Matrix:\n");

                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        Console.Write(matrix[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();

                int count = 0;
                for (int k = 0; k < 2 * row; k++)
                {
                    if (k % 2 == 0 && k > 0)
                    {
                        count++;
                    }

                    for (int i = 0; i < row; i++)
                    {
                        divisor = matrix[i, i];
                        multiplier = matrix[i, count];
                        for (int j = 0; j < col; j++)
                        {
                            if (k % 2 == 0)
                            {
                                if (i == count)
                                {
                                    matrix[i, j] /= divisor;
                                }
                            }
                            else
                            {
                                if (i != count)
                                {
                                    matrix[i, j] -= multiplier * matrix[count, j];
                                }
                            }

                        }

                    }

                    Console.WriteLine("\nIteration # {0}:\n", k + 1);

                    for (int l = 0; l < row; l++)
                    {
                        for (int m = 0; m < col; m++)
                        {
                            Console.Write(matrix[l, m].ToString("0.00") + "\t");
                        }
                        Console.WriteLine();
                    }


                }

                Console.WriteLine("\nReduced Matrix:\n");

                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        Console.Write(matrix[i, j].ToString("0.00") + "\t");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("\nAnswer:\n");
                for (int i = 0; i < row; i++)
                {
                    Console.WriteLine("x{0} = {1}", i + 1, matrix[i, row].ToString("0.00"));
                }


                Console.ReadLine();
            }
            else
            {
                goto y;
            }
        }
    }
}

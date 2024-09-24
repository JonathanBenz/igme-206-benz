/* Author: Jonathan Benz
 * PE - 2D Arrays
 * No known issues */
namespace PE_2dArrays_JRB
{
    internal class Program
    {
        /// <summary>
        /// Helper method written by Jonathan Benz. 
        /// Sequentially fills in a 2D array given a starting number. 
        /// </summary>
        /// <param name="array"> 2D array given to become filled sequentially</param>
        /// <param name="startNum"> What number we want the [0,0] element to start off as</param>
        public static void Fill2DArray(int[,] array, int startNum)
        {
            for(int r = 0; r < array.GetLength(0); r++)
            {
                for(int c = 0; c < array.GetLength(1); c++)
                {
                    array[r, c] = startNum++;
                }
            }
        }
        /// <summary>
        /// Helper written by Jonathan Benz.
        /// Prints out the 2D Array to the console. 
        /// </summary>
        /// <param name="array"> 2D array given to become printed out</param>
        public static void Print2DArray(int[,] array)
        {
            // Prints the column headers
            for(int i = 0; i < array.GetLength(1); i++)
            {
                Console.Write("\tCol {0}", i + 1);
            }

            // Prints out the row headers and data
            for (int r = 0; r < array.GetLength(0); r++)
            {
                Console.Write("\nRow {0}:", r + 1);
                for (int c = 0; c < array.GetLength(1); c++)
                {
                    Console.Write("\t{0}", array[r, c]);
                }
            }
        }
        static void Main(string[] args)
        {
            // Init a 2D array of 2 x 4 elements with sequential values
            int[,] integerArray = new int[2, 4];
            Fill2DArray(integerArray, 5);

            // Print values in the array
            Print2DArray(integerArray);
        }
    }
}

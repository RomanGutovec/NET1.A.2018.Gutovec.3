using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsLib
{
    /// <summary>
    /// Class for calculating the nth degree and
    /// for finding the next bigger number which consists 
    /// of the same digits
    /// </summary>
    public static class AlgorithmsLib
    {
        /// <summary>
        /// Find root the nth degree from number
        /// </summary>
        /// <exception cref="ArgumentException">thrown when number less than 0 and power is even
        /// and when power or accuracy have negative value
        /// </exception>
        /// <param name="number">source number</param>
        /// <param name="power">degree</param>
        /// <param name="accuracy">accuracy of calculating</param>
        /// <returns>root the nth degree</returns>
        public static double FindNthRoot(double number, int power, double accuracy)
        {
            if ((number <= 0 && power % 2 == 0) || power < 0 || accuracy <= 0)
            {
                throw new ArgumentException(nameof(number));
            }

            if (number == 0)
            {
                return 0;
            }

            double result = 1;
            double nextIteratioNumber = 1.0 / power * ((power - 1) * result + (number / Math.Pow(result, power - 1)));
            while (Math.Abs(result - nextIteratioNumber) > accuracy)
            {
                result = nextIteratioNumber;
                nextIteratioNumber = 1.0 / power * ((power - 1) * result + (number / Math.Pow(result, power - 1)));
            }

            return nextIteratioNumber;
        }

        /// <summary>
        /// Find the next number which bigger than source number 
        /// and consists of the same digits
        /// </summary>
        /// <param name="number">source number</param>
        /// <returns>the next bigger number</returns>
        public static int FindNextBigger(int number)
        {
            int[] sortedArray = DevideOnSimple(number);
            int[] res = new int[sortedArray.Length];
            Array.Sort(sortedArray);
            int[] actualArray = RemoveElementFromEndByValue(DevideOnSimple(number), sortedArray[sortedArray.Length - 1]);
            int positionMaxElement = sortedArray.Length - 1;

            int biggerNumber = -1;
            while (positionMaxElement >= 0)
            {
                int[] tempsortedArray = new int[sortedArray.Length];
                Array.Copy(sortedArray, tempsortedArray, sortedArray.Length);
                int count = 0;
                for (int i = 0; i < sortedArray.Length; i++)
                {
                    if (i < positionMaxElement)
                    {
                        res[i] = actualArray[i];
                        tempsortedArray = RemoveElementFromEndByValue(tempsortedArray, actualArray[i]);
                    }
                    else if (positionMaxElement == i)
                    {
                        res[i] = sortedArray[sortedArray.Length - 1];
                    }
                    else
                    {
                        res[i] = tempsortedArray[count++];
                    }
                }

                if (CreateNumberFromArray(res) > number)
                {
                    biggerNumber = CreateNumberFromArray(res);
                    break;
                }

                positionMaxElement--;
            }

            return biggerNumber;
        }

        private static int[] DevideOnSimple(int number)
        {
            int[] arrayNumbers = new int[number.ToString().Length];
            for (int i = number.ToString().Length - 1; i >= 0; i--)
            {
                arrayNumbers[i] = number % 10;
                number /= 10;
            }

            return arrayNumbers;
        }

        private static int CreateNumberFromArray(int[] array)
        {
            int resultNumber = array[array.Length - 1];
            int count = 1;
            for (int i = array.Length - 2; i >= 0; i--)
            {
                resultNumber += array[i] * (int)Math.Pow(10, count++);
            }

            return resultNumber;
        }

        private static int[] RemoveElementFromEndByValue(int[] array, int value)
        {
            int[] arrayWithoutValue = new int[array.Length - 1];
            int index = 0;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] == value)
                {
                    index = i;
                    break;
                }
            }

            for (int i = 0; i < arrayWithoutValue.Length; i++)
            {
                if (i < index)
                {
                    arrayWithoutValue[i] = array[i];
                }
                else
                {
                    arrayWithoutValue[i] = array[i + 1];
                }
            }

            return arrayWithoutValue;
        }
    }
}

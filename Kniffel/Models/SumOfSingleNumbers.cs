using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kniffel.Models
{
    public class SumOfSingleNumbers
    {
        /// <summary>
        /// Sucht eine bestimmte Zahl in einem int Array und addiert wenn die Zahl mehrfach enthalten ist
        /// gibt die Summe davon zurück (int[] {5,2,1,2,3} - gesucht 2 - 2x gefunden, Rückgabe = 4)
        /// </summary>
        /// <param name="value">Die Zahl die gesucht wird</param>
        /// <param name="array">Das Array das durchsucht werden soll</param>
        /// <returns></returns>
        public int SumOfSameValues(int value, int[] array)
        {
            int result = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                {
                    result += array[i];
                }
            }
            return result;
        }
    }
}

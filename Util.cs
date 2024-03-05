using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schichtplan
{
    internal class Util
    {
        /// <summary>
        /// parses a string to an int and creates an a messagebox if it fails with a given message
        /// </summary>
        /// <param name="value">the string to be parsed</param>
        /// <param name="errorMessage">the errormessage for the messagebox</param>
        /// <returns>the parsed int</returns>
        public static int parseInt(string value, string errorMessage)
        {
            try
            {
                return int.Parse(value);
            }
            catch (FormatException e)
            {
                System.Windows.Forms.MessageBox.Show(errorMessage);
            }
            return -1;
        }

        /// <summary>
        /// parses a string to an float and creates an a messagebox if it fails with a given message
        /// </summary>
        /// <param name="value">the string to be parsed</param>
        /// <param name="errorMessage">the errormessage for the messagebox</param>
        /// <returns>the parsed float</returns>
        public static float parseFloat(string value, string errorMessage)
        {
            try
            {
                return float.Parse(value);
            }
            catch (FormatException e)
            {
                System.Windows.Forms.MessageBox.Show(errorMessage);
            }
            return -1;
        }

        /// <summary>
        /// maps a given value in the scoppe of the fromMin and fromMax parameters
        /// into the scope of the toMin and toMax parameters, while preserving its relativ distances
        /// </summary>
        /// <param name="fromMin">from scope minimum</param>
        /// <param name="fromMax">from scope maximum</param>
        /// <param name="toMin">to scope mimimum</param>
        /// <param name="toMax">to scope maximum</param>
        /// <param name="value">value to be mapped</param>
        /// <returns></returns>
        public static float mapFloat(int fromMin, int fromMax, int toMin, int toMax, float value)
        {
            return (((value - fromMin) / (fromMax - fromMin)) * (toMax - toMin)) + toMin;
        }

        /// <summary>
        /// checks if a string is in a given string array
        /// </summary>
        /// <param name="array">array in which the string might be</param>
        /// <param name="value">the strin value to be checked</param>
        /// <returns>if the given value is in the given string array</returns>
        public static bool stringArrayContains(string[] array, string value)
        {
            foreach(string s in array)
            {
                if(s == value)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// clamps a float value to a given number of decimal points
        /// </summary>
        /// <param name="value">float value to be clamped</param>
        /// <param name="decimalPoints">number of decimal points to clamp to</param>
        /// <returns>the given float to the number of decimal points and returns its value</returns>
        public static float clampToDecimalpoints(float value, int decimalPoints)
        {
            int helper = (int)Math.Pow((double)10, (double)decimalPoints);

            value *= helper;
            int floored = (int)value;

            return (float)floored / (float)helper;
        }
    }
}

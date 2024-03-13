using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schichtplan.model
{
    [Serializable]
    public class Cost
    {
        public int payday { set; get; }

        public string costType { get; set; }
        public string description { get; set; }
        public string biller { get; set; }

        public float amount { set; get; }

        public Cost(int payday, string costType, string description, string biller, float amount)
        {
            this.payday = payday;
            this.costType = costType;
            this.description = description;
            this.biller = biller;
            this.amount = amount;
        }

        /// <summary>
        /// puts all the data of this cost into a string array
        /// </summary>
        /// <returns>all the data of this cost as a string array</returns>
        public string[] ToStringArray()
        {
            string[] array = new string[5];
            array[0] = payday + "";
            array[1] = costType;
            array[2] = biller;
            array[3] = description;
            array[4] = amount + "";

            return array;
        }
    }
}

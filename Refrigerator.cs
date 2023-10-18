using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refrigerator_exercise
{
    public enum ColorRefrigerator { gray, white, black }
    internal class Refrigerator
    {
        private static int numberOfRefrigerator = 0;
        private int id;
        private string model;
        private ColorRefrigerator color;
        private int numberOfShlfs;
        private int[] listOfShelfs;

        public int ID
        { 
            get { return id; }
        }
        public string Model
        {
            get { return model; }
            set
            {
                if (value == "" || value == null)
                    model = "unknowen";
                model = value;
            }
        }
        public ColorRefrigerator Color
        { 
            get { return color; } 
            set { color = value; }
        }
        public int NumberOfShrlfs
        { 
            get { return numberOfShlfs; } 
            set 
            { 
                if(value>0)
                    numberOfShlfs = value;
                numberOfShlfs = 4;
            } 
        }
        public int[] Shelfs { get { return listOfShelfs; } }

        public override string ToString()
        {
            return "The ID of the refrigerator is:{0}.\nThe model of the refrigerator is:{1}.\n" +
                "The color of the refrigerator is:{1}.\nThe numberOfShlfs of the refrigerator is:{1}.\n" +
                "The list of shelfs in the refrigerator is:{ 1}.\n";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refrigerator_exercise
{
    internal class Shelf
    {
        private static int numberOfShlfs = 0;
        private int _id;
        private int _floorNumber;
        private double _area;
        private List<Item> _items;

        public int id
        {
            get { return this._id; }
        }
        public int floorNumber
        {
            get { return this._floorNumber; }
            set 
            {
                if(value>0)
                    this._floorNumber = value;
                this._floorNumber = 1;
            }
        }
        public double area
        {
            get { return this.area; }
            set
            {
                if (value > 0)
                    this.area = value;
                this._area = 0;
            }
        }

        public string toString()
        {
            string itemsString = "";
            foreach (var item in _items)
            {
                itemsString+=" *"+ item.ToString()+"\n";
            }
            return "";
        }
    }
}

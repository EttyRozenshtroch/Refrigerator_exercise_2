using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refrigerator_exercise
{
    enum TypeItem { food , drink }
    enum Kashrut { meat, dairy, fur }
    internal class Item
    {
        private static int _numberOfItems = 0;
        private int _id;
        private string _name;
        private int _ShelfID;   //על איזה מדף הפריט?
        private TypeItem _type;
        private Kashrut _kashrut;
        private DateTime _expirationDate;
        private double _area;


        public int id
        {
            get { return _id; }
        }
        public string name
        {
            get { return name; }
            set
            {
                if (value != null)
                    this._name = value;
                this._name = "No name";
            }
        }
        public int shlefID
        {
            get { return this._ShelfID; }
            set
            {
                if (value > 0)
                    this._ShelfID = value;
                this._ShelfID = 0;
            }

        }
        public TypeItem type
        {
            get { return this._type; }
            set { this._type = value; }
        }
        public TypeItem kashrut
        {
            get { return this._type; }
            set { this._type = value; }
        }
        public DateTime expirationDate
        {
            get { return this._expirationDate; }
            set { this._expirationDate = value; }
        }
        public double area

        {
            get { return this._area; }
            set
            {
                if (value > 0)
                    this._area = value;
                this._area = 0;
            }

        }

        public string toString()
        {
            return "The ID of the item is:"+this._id+ ".\nThe name of the item is:"+ this._name + ".\nThe item is " +
                "placed on"+this._ShelfID + " shelf.\nThe type of the item is"+ this._type + ".\nThe kashrut of the " +
                "item is:"+ this._kashrut + "\n" +"The expiration date is:"+ this._expirationDate + ".\nThe area of " +
                "the item is:"+ this._area + ".";    
        }
    }
}

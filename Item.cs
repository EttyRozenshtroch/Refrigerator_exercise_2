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

        public Item() 
        {
            this._id = ++_numberOfItems;
            this._name="item"+this._id;
            this._type = 0;
            this._kashrut = 0;
            this._expirationDate = DateTime.Today.AddDays(-3);
            this._area = 5;
        }
        public Item(string name,TypeItem type,Kashrut kashrut, DateTime expirationDate,double area)
        {
            this._id = ++_numberOfItems;
            this.name = name;
            this.type = type;
            this._kashrut = kashrut;
            this._expirationDate = expirationDate;
            this._area = area;
        }
        public int id
        {
            get { return this._id; }
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
        public int shlfID
        {
            get {return this._ShelfID; }
            set
            {
                if(value>0)
                    this._ShelfID = value;
                this._ShelfID = 0;
            }

        }
        public TypeItem type
        {
            get { return this._type; }
            set { this._type = value; }
        }
        public Kashrut kashrut
        {
            get { return this._kashrut; }
            set { this._kashrut = value; }
        }
        public DateTime expirationDate
        {
            get { return this._expirationDate; }
            set
            {
                this._expirationDate = value;
            }
        }
        public double area
        {
            get { return this._area; }
            set
            {
                this._area = value;
            }
        }
        public override string ToString()
        {
            return "The ID of the item is:"+this._id+ ".\nThe name of the item is:"+ this._name + ".\nThe item is " +
                "placed on"+this._ShelfID + " shelf.\nThe type of the item is"+ this._type + ".\nThe kashrut of the " +
                "item is:"+ this._kashrut + "\n" +"The expiration date is:"+ this._expirationDate + ".\nThe area of " +
                "the item is:"+ this._area + ".";    
        }
    }
}

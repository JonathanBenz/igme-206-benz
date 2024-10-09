/* Author: Jonathan Benz
 * Crop Class
 * No known issues */
namespace HW5_TheFarmstead_JRB
{
    internal class Crop
    {
        // Declaring fields and properties
        private string name;
        private double cost;
        private int growthTime;
        private int daysLeft;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public double Cost
        {
            get { return cost; }
            set { cost = value; }
        }
        public int GrowthTime
        {
            get { return growthTime; }
            set { growthTime = value; }
        }
        public int DaysLeft
        {
            get { return daysLeft; }
            set { daysLeft = value; }
        }
        public double SellingPrice
        {
            get { return cost * growthTime; }
        }
        public bool CanHarvest
        {
            get 
            { 
                if (daysLeft > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        // Constructors
        public Crop(string name, double cost, int growthTime)
        {
            this.name = name;
            this.cost = cost;
            this.growthTime = growthTime;
            daysLeft = growthTime;
        }

        /// <summary>
        /// Initializes a new instance of the Crop class as a copy of another crop.
        /// </summary>
        /// <param name="other">The crop to copy.</param>
        public Crop(Crop other)
        // TODO: Leverage constructor chaining here to use the parameterized constructor!
            : this(other.Name, other.Cost, other.GrowthTime) {
            {
                // No code here!
            }
        }

        // Methods

        /// <summary>
        /// Decrements the days left until the crop is ready to harvest. 
        /// </summary>
        public void DayPassed()
        {
            // Prevents negative days being left.
            if(daysLeft < 0)
            {
                daysLeft = 0;
            }
            daysLeft--;
        }

        /// <summary>
        /// Prints to console if crop still has days left to harvest, or is ready to be harvested and sold. 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if(CanHarvest)
            {
                return String.Format("{0} ready to harvest for {1:C}", name, SellingPrice);
            }
            else
            {
                return String.Format("{0} has {1} days left to harvest", name, daysLeft);
            }
        }
    }
}

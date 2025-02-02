using System;

namespace GolfGamingBL
{
    public enum Arc { Draw, Straight, Fade }


    public class Golfer
    {
        public string Name { get; set; }  //change to private set, later   { get; private set; }
        public Arc Arc;
        public int MaxDriveYards { get; private set; }

        public DateTime SeasonRetiredDate { get; set; }
        public int CurrentPowerShots { get; set; }
        public int MaxPowerShots { get; private set; }  //Character limit on powershots at maximized loyalty
        public int MinPowerShots { get; private set; }  //Characters starting powershots with no loyalty
        public int GolferID { get; private set; }       //Unique identifier for any golfer

        public Golfer() 
        {
            //stub to remove after reading in real DB golfers..
        }
        public Golfer(string Name, Arc Arc, int MaxDriveYards, int MaxPowerShots, int MinPowerShots, int GolferID)
        {
            if (Name.Trim().Length == 0)
                throw new Exception("Bad Golfer Name");

            this.Name = Name;
            this.Arc = Arc;
            this.MaxDriveYards = (MaxDriveYards > 0) ? MaxDriveYards : 0;
            this.MinPowerShots = MinPowerShots;
            this.MaxPowerShots = (MaxPowerShots < MinPowerShots) ? MinPowerShots : MaxPowerShots;
            this.GolferID = GolferID;
        }
    }
}

using System;

namespace GolfGamingBL
{
    public class GolfCourse
    {
        public string Name { get; set; }  //change to private set, later { get; private set; }
        public int GolfCourseID {get; private set; }
        public DateTime SeasonClosedDate { get; set; }

        public GolfCourse()
        {
            //stub to remove after reading in real DB golfers..
        }

        public GolfCourse(string Name, int GolfCourseID)
        {
            if (Name.Trim().Length == 0)
                throw new Exception("Bad Golf Course Name");

            this.Name = Name;
            this.GolfCourseID = GolfCourseID;
        }
    
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfGamingBL
{
    public class Season
    {
        private GolfRepository _golfRepository;

        private List<Golfer> _activeGolfers;
        private List<GolfCourse> _activeGolfCourses;

        private GolfersByIndex currentGolfer;
        private GolfCoursesByIndex currentGolfCourse;

        public GolfersByIndex CurrentGolfer {
         get
          {
                // when currentGolfer == 0, is default = Phoebe
                return currentGolfer;
          }
         set
          {
                currentGolfer = value;
          }
        }

        public GolfCoursesByIndex CurrentGolfCourse
        {
            get
            {
                // when currentGolfCourse == 0, is default = Mount Sakura
                return currentGolfCourse;
            }
            set
            {
                currentGolfCourse = value;
            }
        }

        public IEnumerable<Golfer> Roster { 
         get
            {
                var activeGolferQuery = _activeGolfers.Where(g => g.SeasonRetiredDate == DateTime.MaxValue).Select(g => g);
                return activeGolferQuery.ToList();

            }
            set
            {
                Roster = value;
            }

        }

        public IEnumerable<GolfCourse> OpenCourses {
         get
            {
                var activeGolfCourseQuery = _activeGolfCourses.Where(g => g.SeasonClosedDate == DateTime.MaxValue).Select(g => g);
                return activeGolfCourseQuery.ToList();
            }

        }


        public Season()
        {
            _golfRepository = new GolfRepository();
            _activeGolfers = _golfRepository.Retrieve();
            _activeGolfCourses = _golfRepository.RetrieveCourses();
            currentGolfer = _golfRepository.RetrieveCurrentGolferID();
            currentGolfCourse = _golfRepository.RetrieveCurrentGolfCourseID();

        }

        public void AdvanceToNextCurrentGolfer()
        {
            //Avoid infinite loop - raise error if no more "Active Golfers"
            GolfersByIndex startingGolfer = currentGolfer;
            NextGolfer();
            while ((currentGolfer != startingGolfer) && (Roster.Where(g => g.Name == currentGolfer.ToString()).ToList().Count == 0))
            {
                NextGolfer();
            }
            if (currentGolfer == startingGolfer)
                throw new Exception("No active players");

            _golfRepository.SetCurrentGolferToNext(currentGolfer);
        }

        public void AdvanceToPreviousCurrentGolfer()
        {
            //Avoid infinite loop - raise error if no more "Active Golfers"
            GolfersByIndex startingGolfer = currentGolfer;
            PriorGolfer();
            while ((currentGolfer != startingGolfer) && (Roster.Where(g => g.Name == currentGolfer.ToString()).ToList().Count == 0))
            {
                PriorGolfer();
            }
            if (currentGolfer == startingGolfer)
                throw new Exception("No active players");

            _golfRepository.SetCurrentGolferToNext(currentGolfer);
        }

        private void NextGolfer()
        {
            //Abide by enum list values:
            currentGolfer++;
            if (!_golfRepository.GolfersIds.Contains(currentGolfer))
              currentGolfer = 0;
        }

        private void PriorGolfer()
        {
            //Abide by enum list values:
            currentGolfer--;
            if (!_golfRepository.GolfersIds.Contains(currentGolfer))
                currentGolfer = _golfRepository.GolfersIds.Max();
        }

        public void AdvanceToNextCurrentCourse()
        {
            //Avoid infinite loop - raise error if no more "Active Golfers"
            GolfCoursesByIndex startingCourse = currentGolfCourse;
            NextGolfCourse();
            while ((currentGolfCourse != startingCourse) && (OpenCourses.Where(g => g.Name == currentGolfCourse.ToString()).ToList().Count == 0))
            {
                NextGolfCourse();
            }
            if (currentGolfCourse == startingCourse)
                throw new Exception("No open courses");

            _golfRepository.SetCurrentGolfCourseToNext(currentGolfCourse);
        }

        public void AdvanceToPreviousCurrentCourse()
        {
            //Avoid infinite loop - raise error if no more "Active Golfers"
            GolfCoursesByIndex startingCourse = currentGolfCourse;
            PriorGolfCourse();
            while ((currentGolfCourse != startingCourse) && (OpenCourses.Where(g => g.Name == currentGolfCourse.ToString()).ToList().Count == 0))
            {
                PriorGolfCourse();
            }
            if (currentGolfCourse == startingCourse)
                throw new Exception("No open courses");

            _golfRepository.SetCurrentGolfCourseToNext(currentGolfCourse);
        }

        private void NextGolfCourse()
        {
            //Abide by enum list values:
            currentGolfCourse++;
            if (!_golfRepository.GolfCoursesIds.Contains(currentGolfCourse))
                currentGolfCourse = 0;
        }

        private void PriorGolfCourse()
        {
            //Abide by enum list values:
            currentGolfCourse--;
            if (!_golfRepository.GolfCoursesIds.Contains(currentGolfCourse))
                currentGolfCourse = _golfRepository.GolfCoursesIds.Max();
        }



    }
}

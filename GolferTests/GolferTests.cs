using GolfGamingBL;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GolfGamingBL.Tests
{
    [TestClass()]
    public class GolferTests
    {
        [TestMethod()]
        public void GivenEmptyRepository_WhereRetrieve_ThenCreatesGolferList()
        {
            //Arrange & Act:
            GolfRepository golfRepo = new GolfRepository();

            var someGolfers = golfRepo.Retrieve();
            int expectedGolfers = 4;  // Phoebe, Mike, Misaki, Allan

            //Assert
            Assert.IsNotNull(golfRepo);
            Assert.AreEqual(expectedGolfers, golfRepo.SeasonRoster.Count);
        }

        [TestMethod]
        public void GivenNewGolfer_WhereNameBlank_ThenFailCreation()
        {
            //Arrange:
            string expectedError = "Bad Golfer Name";

            //Act:
            try
            {
                expectedError = "Bad Golfer Name";
                Golfer phoebe = new Golfer(Name: "", Arc: Arc.Straight, MaxDriveYards: 228, MaxPowerShots: 17, MinPowerShots: 22, GolferID: 1);
                //Act
                //Assert
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, expectedError);
                //  Error should be raised by above line.
            }
        }

        [TestMethod]
        public void GivenNewGolfer_WhereMaxPowerShotsSmallerThanMinPowerShots_ThenMaxEqualsMin()
        {
            //Arrange & Act:
            Golfer phoebe = new Golfer(Name: "Phoebe", Arc: Arc.Straight, MaxDriveYards: 228, MaxPowerShots: 17, MinPowerShots: 22, GolferID: 1);
            //Act
            //Assert
            int ExpectedMaxMinPowerShots = 22; // Max will be overriden because 17 is smaller than the minimum
            Assert.AreEqual(ExpectedMaxMinPowerShots, phoebe.MaxPowerShots);
            Assert.AreEqual(ExpectedMaxMinPowerShots, phoebe.MinPowerShots);
        }

        [TestMethod]
        public void GivenGolfSeason_WhereFresh_ThenOnlyPhoebeMisakiAllan()
        {
            //Arrange & Act:
            Season season = new Season();
            String expectedFirstGolferName = "Phoebe";
            String expectedSecondGolferName = "Misaki";
            String expectedThirdGolferName = "Allan";
            IEnumerable<Golfer> actives = season.Roster;
            //Assert
            Assert.AreEqual(expectedFirstGolferName, (actives as List<Golfer>)[0].Name);
            Assert.AreEqual(expectedSecondGolferName, (actives as List<Golfer>)[1].Name);
            Assert.AreEqual(expectedThirdGolferName, (actives as List<Golfer>)[2].Name);
        }

        [TestMethod]
        public void GivenGolfSeason_WhereFresh_ThenCurrGolferIsPhoebe()
        {
            //Arrange:
            Season season = new Season();
            GolfRepository golfRepo = new GolfRepository();
            //repository loads the "current Golfer"... so, now, we can access "Roster" to force "currentGolfer" to flow into Season from repo:
            IEnumerable<Golfer> golfers = season.Roster;


            //Act: - Get roster forces finding Current Golfer:
            var someGolfers = golfRepo.Retrieve();

            GolfersByIndex expectedGolfer = GolfersByIndex.Phoebe;

            //Assert
            Assert.AreEqual(expectedGolfer, season.CurrentGolfer);
        }

        [TestMethod]
        public void GivenGolfSeason_WhereFresh_ThenAdvanceReturnsMisaki()
        {
            //Arrange & Act:
            Season season = new Season();
            GolfersByIndex expectedGolfer = GolfersByIndex.Misaki;

            //Act:
            season.AdvanceToNextCurrentGolfer();

            //Assert:
            Assert.AreEqual(expectedGolfer, season.CurrentGolfer);
        }

        [TestMethod]
        public void GivenGolfSeason_WherePassAllan_ThenReturnPhoebe()
        {
            //Arrange:
            Season season = new Season();
            GolfersByIndex expectedGolfer = GolfersByIndex.Phoebe;

            //Act:
            season.AdvanceToNextCurrentGolfer();
            season.AdvanceToNextCurrentGolfer();
            season.AdvanceToNextCurrentGolfer();

            //Assert:
            Assert.AreEqual(expectedGolfer, season.CurrentGolfer);

        }


    }

}

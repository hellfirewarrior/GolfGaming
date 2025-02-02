using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GolfGamingBL;

namespace ASPGolf
{
    public partial class _Default : Page
    {
 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Season currSeason = new Season();
                txtboxGolfer.Text = currSeason.CurrentGolfer.ToString();
                txtboxCourse.Text = currSeason.CurrentGolfCourse.ToString();
            }

        }

        protected void btnNext_Click(object sender, EventArgs e) //advance all
        {
            Season currSeason = new Season();
            currSeason.AdvanceToNextCurrentGolfer();
            currSeason.AdvanceToNextCurrentCourse();
            txtboxGolfer.Text = currSeason.CurrentGolfer.ToString();
            txtboxCourse.Text = currSeason.CurrentGolfCourse.ToString();

        }

        protected void btnNextGolfer_Click(object sender, EventArgs e)
        {
            Season currSeason = new Season();
            currSeason.AdvanceToNextCurrentGolfer();
            txtboxGolfer.Text = currSeason.CurrentGolfer.ToString();

        }

        protected void btnNextCourse_Click(object sender, EventArgs e)
        {
            Season currSeason = new Season();
            currSeason.AdvanceToNextCurrentCourse();
            txtboxCourse.Text = currSeason.CurrentGolfCourse.ToString();

        }


        protected void btnPriorGolfer_Click(object sender, EventArgs e)
        {
            Season currSeason = new Season();
            currSeason.AdvanceToPreviousCurrentGolfer();
            txtboxGolfer.Text = currSeason.CurrentGolfer.ToString();
 
        }

        protected void btnPriorCourse_Click(object sender, EventArgs e)
        {
            Season currSeason = new Season();
            currSeason.AdvanceToPreviousCurrentCourse();
            txtboxCourse.Text = currSeason.CurrentGolfCourse.ToString();

        }
    }
}
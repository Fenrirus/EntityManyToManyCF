using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EntityManyToManyCF
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        StudentsDbContext db = new StudentsDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            wyswietl();
        }

        private void wyswietl()
        {
            GridView1.DataSource = (from Student in db.Students
                                    from c in Student.Courses
                                    select new { stundentNames = Student.StudentName, CourseNames = c.CourseName }).ToList();
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           Course kurs = db.Courses.FirstOrDefault(x => x.CourseID == 4);
            db.Students.Include("Courses").FirstOrDefault(x => x.StudentID == 1).Courses.Add(kurs);
            db.SaveChanges();
            wyswietl();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Course kurs = db.Courses.FirstOrDefault(x => x.CourseID == 2);
            db.Students.Include("Courses").FirstOrDefault(x => x.StudentID == 2).Courses.Remove(kurs);
            db.SaveChanges();
            wyswietl();
        }
    }
}
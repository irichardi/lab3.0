using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using comp2007_lesson9_mon.Models;

namespace comp2007_lesson9_mon
{
    public partial class course : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetDepartments();

                //get the course if editing
                if (!String.IsNullOrEmpty(Request.QueryString["CourseID"]))
                {
                    GetCourse();
                }
            }
        }

        protected void GetCourse()
        {
            //populate the existing course for editing
            using (DefaultConnectionEF db = new DefaultConnectionEF())
            {
                Int32 CourseID = Convert.ToInt32(Request.QueryString["CourseID"]);

                Courses objC = (from c in db.Courses
                               where c.CourseID == CourseID
                               select c).FirstOrDefault();
                //enrollments - this code goes in the same method that populates the student form but below the existing code that's already in GetStudent()              
                var objE = (from en in db.Enrollments
                            join c in db.Courses on en.CourseID equals c.CourseID
                            join s in db.Students on en.StudentID equals s.StudentID
                            where en.CourseID == CourseID
                            select new { s.StudentID,s.LastName,s.FirstMidName });

                grdStudents.DataSource = objE.ToList();
                grdStudents.DataBind();

                //populate the form
                txtTitle.Text = objC.Title;
                txtCredits.Text = objC.Credits.ToString();
                ddlDepartment.SelectedValue = objC.DepartmentID.ToString();

                //fill departments to dropdown
                var stu = from s in db.Students
                           orderby s.FirstMidName
                           select s;

                ddlStudent.DataSource = stu.ToList();
                ddlStudent.DataBind();

            }
        }

        protected void GetDepartments()
        {
            using (DefaultConnectionEF db = new DefaultConnectionEF())
            {
                var deps = (from d in db.Departments
                            orderby d.Name
                            select d);

                ddlDepartment.DataSource = deps.ToList();
                ddlDepartment.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //do insert or update
            using (DefaultConnectionEF db = new DefaultConnectionEF())
            {
                Courses objC = new Courses();

                if (!String.IsNullOrEmpty(Request.QueryString["CourseID"]))
                {
                    Int32 CourseID = Convert.ToInt32(Request.QueryString["CourseID"]);
                    objC = (from c in db.Courses
                            where c.CourseID == CourseID
                            select c).FirstOrDefault();
                }

                //populate the course from the input form
                objC.Title = txtTitle.Text;
                objC.Credits = Convert.ToInt32(txtCredits.Text);
                objC.DepartmentID = Convert.ToInt32(ddlDepartment.SelectedValue);

                if (String.IsNullOrEmpty(Request.QueryString["CourseID"]))
                {
                    //add
                    db.Courses.Add(objC);
                }

                //save and redirect
                db.SaveChanges();
                Response.Redirect("courses.aspx");
            }
        }

        protected void grdStudents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //get the selected EnrollmentID
            Int32 StudentID = Convert.ToInt32(grdStudents.DataKeys[e.RowIndex].Values["StudentID"]);

            using (DefaultConnectionEF db = new DefaultConnectionEF())
            {
                Enrollments objE = (from en in db.Enrollments
                                    where en.StudentID == StudentID
                                    select en).FirstOrDefault();
                //process the deletion
                db.Enrollments.Remove(objE);
                db.SaveChanges();

                //repopulate the page
                GetCourse();
            }
        }


        protected void ddlStudent_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            using (DefaultConnectionEF db = new DefaultConnectionEF())
            {
                //get the values needed
                Int32 StudentID = Convert.ToInt32(ddlStudent.SelectedValue);
                Int32 CourseID = Convert.ToInt32(Request.QueryString["CourseID"]);
                //populate the new enrollment object
                Enrollments objE = new Enrollments();
                objE.StudentID = StudentID;
                objE.CourseID = CourseID;

                //save
                db.Enrollments.Add(objE);
                db.SaveChanges();

                //refresh
                GetCourse();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//reference models
using comp2007_lesson9_mon.Models;
using System.Web.ModelBinding;

namespace comp2007_lesson9_mon
{
    public partial class department : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if the page isn't posted back, check the url for an id to see know add or edit
            if ((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                    GetDepartment();
            }
        }

        protected void GetDepartment()
        {
            //connect
            using (DefaultConnectionEF conn = new DefaultConnectionEF())
            {
                //get id from url parameter and store in a variable
                Int32 DepartmentID = Convert.ToInt32(Request.QueryString["DepartmentID"]);

                var deps = (from dep in conn.Departments
                         where dep.DepartmentID == DepartmentID
                         select dep).FirstOrDefault();

                //enrollments - this code goes in the same method that populates the student form but below the existing code that's already in GetStudent()              
                var objE = (from dep in conn.Departments
                            join c in conn.Courses on dep.DepartmentID equals c.DepartmentID
                            where dep.DepartmentID == DepartmentID
                            select new { dep.DepartmentID, c.Title });

                grdCourses.DataSource = objE.ToList();
                grdCourses.DataBind();

                //populate the form from our department object
                txtName.Text = deps.Name;
                txtBudget.Text = deps.Budget.ToString();
                //show the course panel
                pnlCourses.Visible = true;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //connect
            using (DefaultConnectionEF conn = new DefaultConnectionEF())
            {
                //instantiate a new deparment object in memory
                Departments d = new Departments();

                //decide if updating or adding, then save
                if (Request.QueryString.Count > 0)
                {
                    Int32 DepartmentID = Convert.ToInt32(Request.QueryString["DepartmentID"]);

                    d = (from dep in conn.Departments
                         where dep.DepartmentID == DepartmentID
                         select dep).FirstOrDefault();
                }

                //fill the properties of our object from the form inputs
                d.Name = txtName.Text;
                d.Budget = Convert.ToDecimal(txtBudget.Text);

                if (Request.QueryString.Count == 0)
                {
                    conn.Departments.Add(d);
                }
                conn.SaveChanges();

                //redirect to updated departments page
                Response.Redirect("departments.aspx");
            }
        }

        protected void grdCourses_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {


        }



    }
}
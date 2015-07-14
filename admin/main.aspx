<%@ Page Title="" Language="C#" MasterPageFile="~/monday.Master" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="comp2007_lesson9_mon.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="well">
            <h3>
                Departments
            </h3>
            <ul class="list-group">
                <li class="list-group-item"><a href="departments.aspx">List Departments</a></li>
                <li class="list-group-item"><a href="department.aspx">Add Department</a></li>
            </ul>
        </div>
        <div class="well">
            <h3>
                Courses
            </h3>
            <ul class="list-group">
                <li class="list-group-item"><a href="courses.aspx">List courses</a></li>
                <li class="list-group-item"><a href="course.aspx">Add course</a></li>
            </ul>
        </div>
        <div class="well">
            <h3>
                Students
            </h3>
            <ul class="list-group">
                <li class="list-group-item"><a href="Students.aspx">List Students</a></li>
                <li class="list-group-item"><a href="Student.aspx">Add Student</a></li>
            </ul>
        </div>
    </div>
</asp:Content>

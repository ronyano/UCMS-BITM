using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagement.BLL;
using UniversityCourseAndResultManagement.Models.EntityModels;

namespace UniversityCourseAndResultManagement.Controllers
{
    public class HomeController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();
        CourseManager courseManager = new CourseManager();
        SemesterManager semesterManager = new SemesterManager();
        DesignationManager designationManager = new DesignationManager();
        TeacherManager teacherManager = new TeacherManager();
        StudentManager studentManager = new StudentManager();
        CourseAssignManager courseAssignManager = new CourseAssignManager();
        EnrollCourseManager enrollCourseManager = new EnrollCourseManager();
        DayManager dayManager = new DayManager();
        RoomManager roomManager = new RoomManager();
        GradeManager gradeManager = new GradeManager();
        AllocateClassroomManager allocateClassroomManager = new AllocateClassroomManager();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Department()
        {
            

            return View();
        }

        public ActionResult Course()
        {
            

            return View();
        }

        [HttpGet]
        public ActionResult SaveDepartment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveDepartment(Department department)
        {
            bool rowsAffected = departmentManager.Save(department);
            if (rowsAffected)
            {
                ViewBag.Message = "Department saved successfully" + Environment.NewLine + "Department Name : " +
                                  department.DepartmentName + Environment.NewLine + "Department Code : " +
                                  department.Code + "";
            }
            else
            {
                ViewBag.Message = "Department Name or Code You have entered is already saved";
            }
            return View();
        }

        public ActionResult ViewDepartment()
        {
            List<Department> departments = departmentManager.GetAllDepartments();
            return View(departments);
        }

        [HttpGet]
        public ActionResult SaveCourse()
        {
            List<Department> departments = departmentManager.GetAllDepartments();
            ViewBag.Departments = departments;
            List<Semester> semesters = semesterManager.GetAllSemesters();
            ViewBag.Semesters = semesters;
            return View();
        }

        [HttpPost]
        public ActionResult SaveCourse(Course course)
        {
            bool rowsAffected = courseManager.Save(course);
            if (rowsAffected)
            {
                ViewBag.Message = "Course saved" + Environment.NewLine + "Course Name: " + course.CourseName +
                                  Environment.NewLine + "Course Code : " + course.CourseCode + "";
            }
            else
            {
                ViewBag.Message = "Course save failed. Course Code or Name already exist";
            }
            List<Department> departments = departmentManager.GetAllDepartments();
            ViewBag.Departments = departments;
            List<Semester> semesters = semesterManager.GetAllSemesters();
            ViewBag.Semesters = semesters;
            return View();
        }

        public ActionResult Teacher()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SaveTeacher()
        {
            List<Designation> designations = designationManager.GetAllDesignations();
            ViewBag.Designations = designations;
            List<Department> departments = departmentManager.GetAllDepartments();
            ViewBag.Departments = departments;
            return View();
        }

        [HttpPost]
        public ActionResult SaveTeacher(Teacher teacher)
        {
            bool rowsAffected = teacherManager.Save(teacher);
            if (rowsAffected)
            {
                ViewBag.Message = "Teacher saved successfully" + Environment.NewLine + "Teacher Name : " +
                                  teacher.TeacherName + Environment.NewLine + "Email : " + teacher.Email +
                                  Environment.NewLine + "Contact No : " + teacher.ContactNo + "";
            }
            else
            {
                ViewBag.Message = "The email you have entered is already registered for another Teacher";
            }
            List<Designation> designations = designationManager.GetAllDesignations();
            ViewBag.Designations = designations;
            List<Department> departments = departmentManager.GetAllDepartments();
            ViewBag.Departments = departments;
            return View();
        }

        [HttpGet]
        public ActionResult AssignCourse()
        {
            List<Department> departments = departmentManager.GetAllDepartments();
            ViewBag.Departments = departments;
            return View();
        }

        [HttpPost]
        public ActionResult AssignCourse(CourseAssignToTeacher courseAssignToTeacher)
        {
            bool rowsAffected = courseAssignManager.Save(courseAssignToTeacher);
            if (rowsAffected)
            {
                if (teacherManager.UpdateCredit(courseAssignToTeacher.TeacherId,
                    courseManager.GetGetCreditById(courseAssignToTeacher.CourseId)))
                {
                    ViewBag.Message = "Course Assigned and credit modified";
                }

                else ViewBag.Message = "Course Assigned";
            }
            else
            {
                ViewBag.Message = "Course can not be assigned!";
            }
            List<Department> departments = departmentManager.GetAllDepartments();
            ViewBag.Departments = departments;
            return View();
        }


        public JsonResult GetTeacherByCourseId(int courseId)
        {
            int teacherId = courseAssignManager.GetTeacherIdByCourseId(courseId);
            var teacherName = teacherManager.GetAllTeachers().FirstOrDefault(c => c.Id == teacherId);
            return Json(teacherName);
        }

        public JsonResult GetTeachersByDepartmentId(int departmentId)
        {
            var teachers = teacherManager.GetAllTeachers();
            var teacherList = teachers.Where(a => a.DepartmentId == departmentId).ToList();
            return Json(teacherList);
        }

        public JsonResult GetCoursesByDepartmentId(int departmentId)
        {
            var courses = courseManager.GetAllCourses();
            var courseList = courses.Where(a => a.DepartmentId == departmentId).ToList();
            return Json(courseList);
        }



        public JsonResult GetCreditByTeacherId(int teacherId)
        {

            var creditToBeTaken = teacherManager.GetAllTeachers().FirstOrDefault(c => c.Id == teacherId);
            return Json(creditToBeTaken);
        }


        public JsonResult GetCourseInfoById(int Id)
        {

            var courseInfo = courseManager.GetAllCourses().FirstOrDefault(c => c.Id == Id);
            return Json(courseInfo);
        }

        public ActionResult Student()
        {
            return View();
        }
        [HttpGet]
        public ActionResult RegisterStudent()
        {
            List<Department> departments = departmentManager.GetAllDepartments();
            ViewBag.Departments = departments;
            return View();
        }

        [HttpPost]
        public ActionResult RegisterStudent(Student student)
        {
            bool rowsAffected = studentManager.RegisterStudent(student);
            if (rowsAffected)
            {
                ViewBag.Message = "Student Registered Successfully" + Environment.NewLine + "Student Name: " + student.StudentName +
                                  Environment.NewLine + "Student Registration Number: " + student.RegNo + "";
            }
            else
            {
                ViewBag.Message = "The email you have entered is already registered for another Student";
            }
            List<Department> departments = departmentManager.GetAllDepartments();
            ViewBag.Departments = departments;

            return View();
        }

        [HttpGet]
        public ActionResult CourseStatistics()
        {
            List<Department> departments = departmentManager.GetAllDepartments();
            ViewBag.Departments = departments;
            return View();
        }

        [HttpPost]
        public ActionResult CourseStatistics(Department department)
        {
            List<Department> departments = departmentManager.GetAllDepartments();
            ViewBag.Departments = departments;
            return View();
        }

        [HttpGet]
        public ActionResult EnrollCourse()
        {
            List<Student> students = studentManager.GetAllStudents();
            ViewBag.Students = students;
            return View();
        }
        [HttpPost]
        public ActionResult EnrollCourse(EnrollInACourse enrollInACourse)
        {
            bool rowsAffected = enrollCourseManager.Save(enrollInACourse);
            if (rowsAffected)
            {
                ViewBag.Message = "Course Enrolled";
            }
            else
            {
                ViewBag.Message = "Course can not be Enrolled!";
            }

            List<Student> students = studentManager.GetAllStudents();
            ViewBag.Students = students;
            return View();
        }

        public JsonResult GetStudentByRegno(int Id)
        {
            var student = studentManager.GetAllStudents().FirstOrDefault(c => c.Id == Id);
            var deptName = departmentManager.GetAllDepartments().FirstOrDefault(c => c.Id == student.DepartmentId);
            /*
             * var result=new { Result="Successed", ID="32"};
                return Json(result, JsonRequestBehavior.AllowGet);
             */
            var result = new
            {
                student,
                deptName
            };

            return Json(result);
        }


        [HttpGet]
        public ActionResult AllocateClassroom()
        {
            List<Department> departments = departmentManager.GetAllDepartments();
            ViewBag.Departments = departments;
            List<Room> rooms = roomManager.GetAllRooms();
            ViewBag.Rooms = rooms;
            List<Day> days = dayManager.GetAllDays();
            ViewBag.Days = days;
            return View();
        }

        [HttpPost]
        public ActionResult AllocateClassroom(AllocateClassroom allocateClassroom)
        {
            bool rowsAffected = allocateClassroomManager.Save(allocateClassroom);

            List<Department> departments = departmentManager.GetAllDepartments();
            ViewBag.Departments = departments;
            List<Room> rooms = roomManager.GetAllRooms();
            ViewBag.Rooms = rooms;
            List<Day> days = dayManager.GetAllDays();
            ViewBag.Days = days;
            return View();
        }
        public ActionResult AboutUs()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ClassScheduleRoomInformation()
        {
            List<Department> departments = departmentManager.GetAllDepartments();
            ViewBag.Departments = departments;
            return View();
        }

        [HttpPost]
        public ActionResult ClassScheduleRoomInformation(Department department)
        {
            List<Department> departments = departmentManager.GetAllDepartments();
            ViewBag.Departments = departments;
            return View();
        }

        public ActionResult ClassRoom()
        {
            return View();
        }

        public ActionResult Result()
        {
            return View();
        }
        [HttpGet]
        public ActionResult StudentResult()
        {
            List<Student> students = studentManager.GetAllStudents();
            ViewBag.Students = students;
            List<Grade> grades = gradeManager.GetAllGrades();
            ViewBag.Grades = grades;
            return View();
        }

        [HttpPost]
        public ActionResult StudentResult(Result result)
        {
            List<Student> students = studentManager.GetAllStudents();
            ViewBag.Students = students;
            List<Grade> grades = gradeManager.GetAllGrades();
            ViewBag.Grades = grades;
            return View();
        }

        [HttpGet]
        public ActionResult ViewResult()
        {
            List<Student> students = studentManager.GetAllStudents();
            ViewBag.Students = students;
            return View();
        }

        [HttpPost]
        public ActionResult ViewResult(Student student)
        {
            List<Student> students = studentManager.GetAllStudents();
            ViewBag.Students = students;
            return View();
        }

        

    }
}
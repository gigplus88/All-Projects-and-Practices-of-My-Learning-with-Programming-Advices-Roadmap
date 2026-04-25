using Microsoft.AspNetCore.Mvc; 
using StudentApi.Models;
using StudentApi.DataSimulation;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace StudentApi.Controllers 
{
    [Authorize]
    [ApiController] // Marks the class as a Web API controller with enhanced features.
  //  [Route("[controller]")] // Sets the route for this controller to "students", based on the controller name.
    [Route("api/Students")]

    public class StudentsController : ControllerBase // Declare the controller class inheriting from ControllerBase.
    {
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(ILogger<StudentsController> logger)
        {
            _logger = logger;
        }


        [Authorize(Roles = "Admin")]

        [HttpGet("All", Name ="GetAllStudents")] // Marks this method to respond to HTTP GET requests.
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<IEnumerable<Student>> GetAllStudents() // Define a method to get all students.
        {
            //StudentDataSimulation.StudentsList.Clear();

            if (StudentDataSimulation.StudentsList.Count == 0) 
            {
                return NotFound("No Students Found!");
            }
            return Ok(StudentDataSimulation.StudentsList); // Returns the list of students.
        }


        [AllowAnonymous]
        [HttpGet("Passed",Name = "GetPassedStudents")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        // Method to get all students who passed
        public ActionResult<IEnumerable<Student>> GetPassedStudents()
        {
            var passedStudents = StudentDataSimulation.StudentsList.Where(student => student.Grade >= 50).ToList();
            //passedStudents.Clear();

            if (passedStudents.Count == 0)
            {
                return NotFound("No Students Passed");
            }


            return Ok(passedStudents); // Return the list of students who passed.
        }

        [AllowAnonymous]
        [HttpGet("AverageGrade", Name = "GetAverageGrade")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<double> GetAverageGrade()
        {

         //   StudentDataSimulation.StudentsList.Clear();

            if (StudentDataSimulation.StudentsList.Count == 0)
            {
                return NotFound("No students found.");
            }

            var averageGrade = StudentDataSimulation.StudentsList.Average(student => student.Grade);
            return Ok(averageGrade);
        }



        //public ActionResult<Student> GetStudentById(int id)
        //{

        //    if (id < 1)
        //    {
        //        return BadRequest($"Not accepted ID {id}");
        //    }

        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    var Role = User.FindFirstValue(ClaimTypes.Role);

        //    int AuthenticatedStudentId = int.Parse(userId ?? "-1");

        //    bool isAdmin = Role == "Admin";

        //    if (!isAdmin && AuthenticatedStudentId != id)
        //    {
        //        return Forbid();
        //    }


        //    var student = StudentDataSimulation.StudentsList.FirstOrDefault(s => s.Id == id);
        //    if (student == null)
        //    {
        //        return NotFound($"Student with ID {id} not found.");
        //    }



        //    return Ok(student);
        //}



        // This endpoint retrieves a single student by ID.
        // It is protected by authentication at the controller level.
        // Authorization logic inside this method enforces ownership rules.

        [Authorize(Policy = "StudentOwnerOrAdmin")] // This policy will be defined in the authorization handlers to check if the user is either the owner of the student record or an admin.]
        [HttpGet("{id}", Name = "GetStudentById")]


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Student>> GetStudentById(
            int id,
            [FromServices] IAuthorizationService authorizationService)
        {
            // Validate the incoming route parameter.
            // IDs less than 1 are not valid and indicate a bad request.
            if (id < 1)
                return BadRequest("Invalid student id.");




            /* Authorization logic:*/

            // Extract the authenticated user's ID from the JWT.
            // This value was placed into the token during login
            // and validated by the JWT authentication middleware.

            /* var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);*/


            // Extract the authenticated user's role from the JWT.
            // Typical values are "Student" or "Admin".


            /*var userRole = User.FindFirstValue(ClaimTypes.Role);*/


            // Convert the authenticated user ID from string to integer.
            // This represents the identity of the caller.

            /*int authenticatedStudentId = int.Parse(userId);*/


            // Determine whether the current user is an Admin.
            // Admins are allowed to access any student record.


            /*bool isAdmin = userRole == "Admin";*/


            // Ownership check:
            // If the user is NOT an admin and is trying to access
            // a student record that does not belong to them,
            // the request is forbidden.

            /*if (!isAdmin && authenticatedStudentId != id)
                return Forbid(); // Returns HTTP 403 Forbidden*/


            // Alternatively, you can use the IAuthorizationService to evaluate a policy that encapsulates this logic.
            /*
            var authResult = await authorizationService.AuthorizeAsync(User,id,"StudentOwnerOrAdmin"); // implement handler for this requirement in the authorization handlers

            if (!authResult.Succeeded)
                return Forbid(); // 403
            */


            // Attempt to find the requested student in the data store.
            // This represents the resource the user is trying to access.
            var student = StudentDataSimulation.StudentsList
                .FirstOrDefault(s => s.Id == id);


            // If no student exists with this ID, return 404 Not Found.
            // This prevents leaking information about valid IDs.
            if (student == null)
                return NotFound("Student not found.");


          


            // If all checks pass:
            // - The user is authenticated
            // - The student exists
            // - The user is either the owner or an admin
            // Access is granted and the student record is returned.
            return Ok(student);
        }








        //for add new we use Http Post
        [Authorize(Roles = "Admin")]
        [HttpPost(Name = "AddStudent")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Student> AddStudent(Student newStudent)
        {
            //we validate the data here
            if (newStudent == null || string.IsNullOrEmpty(newStudent.Name) || newStudent.Age < 0 || newStudent.Grade < 0)
            {
                return BadRequest("Invalid student data.");
            }

            newStudent.Id = StudentDataSimulation.StudentsList.Count > 0 ? StudentDataSimulation.StudentsList.Max(s => s.Id) + 1 : 1;
            StudentDataSimulation.StudentsList.Add(newStudent);
            
            //we dont return Ok here,we return createdAtRoute: this will be status code 201 created.
            return CreatedAtRoute("GetStudentById", new { id = newStudent.Id }, newStudent); //And we return this route with GetStudentById 

        }

        //here we use HttpDelete method
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}", Name = "DeleteStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteStudent(int id)
        {
            // ✅ Capture IP once for tracing (helps investigations later)
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";

            // ✅ Identify the admin who is performing the action
            // ClaimTypes.NameIdentifier is what you put in JWT during login.
            var adminId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "unknown";

            // ===============================
            // Validation: invalid ID
            // ===============================
            if (id < 1)
            {
                // ✅ Audit attempt (invalid input) - still useful signal
                _logger.LogWarning(
                    "Admin action blocked (invalid id). AdminId={AdminId}, Action=DeleteStudent, TargetId={TargetId}, IP={IP}",
                    adminId,
                    id,
                    ip
                );

                return BadRequest($"Not accepted ID {id}");
            }


            var student = StudentDataSimulation.StudentsList.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                // ✅ Audit: admin attempted to delete a non-existing student
                _logger.LogWarning(
                    "Admin action failed (target not found). AdminId={AdminId}, Action=DeleteStudent, TargetId={TargetId}, IP={IP}",
                    adminId,
                    id,
                    ip
                );
                return NotFound($"Student with ID {id} not found.");
            }


            // ===============================
            // Audit BEFORE deleting (recommended)
            // ===============================
            // ✅ Why before?
            // If delete throws or fails later, you still have the audit record of the attempt.
            _logger.LogInformation(
                "Admin action started. AdminId={AdminId}, Action=DeleteStudent, TargetId={TargetId}, TargetEmail={TargetEmail}, IP={IP}",
                adminId,
                student.Id,
                student.Email,
                ip
            );

            StudentDataSimulation.StudentsList.Remove(student);

            // ===============================
            // Audit AFTER deleting (optional, confirms success)
            // ===============================
            _logger.LogInformation(
                "Admin Delete action succeeded. AdminId={AdminId}, Action=DeleteStudent, TargetId={TargetId}, IP={IP}",
                adminId,
                id,
                ip
            );

            return Ok($"Student with ID {id} has been deleted.");
        }

        //here we use http put method for update
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}", Name = "UpdatesStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Student> UpdateStudent(int id, Student updatedStudent)
        {
            var adminId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "unknown";
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";


            if (id < 1 || updatedStudent == null || string.IsNullOrEmpty(updatedStudent.Name) || updatedStudent.Age < 0 || updatedStudent.Grade < 0)
            {
                return BadRequest("Invalid student data.");
            }

            var student = StudentDataSimulation.StudentsList.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                // ✅ Audit: admin attempted to delete a non-existing student
                _logger.LogWarning(
                    "Admin action failed (target not found). AdminId={AdminId}, Action=UpdateStudent, TargetId={TargetId}, IP={IP}",
                    adminId,
                    id,
                    ip
                );
                return NotFound($"Student with ID {id} not found.");
            }

            student.Name = updatedStudent.Name;
            student.Age = updatedStudent.Age;
            student.Grade = updatedStudent.Grade;

            // ✅ Audit: admin attempted to delete a non-existing student
            _logger.LogWarning(
                "Admin Update action succeeded . AdminId={AdminId}, Action=UpdateStudent, TargetId={TargetId}, IP={IP}",
                adminId,
                id,
                ip
            );
            return Ok(student);
        }


    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StudentApi.DataSimulation;
using StudentApi.Model;
using StudentAPIDataAccessLayer;

namespace StudentApi.Controllers
{
    [ApiController] // Marks the class as a Web API controller with enhanced features.
                    // [Route("[controller]")] // Sets the route for this controller to "students", based on the controller name.
    [Route("api/Students")]

    public class StudentsController : ControllerBase 
    {
        [HttpGet("All", Name = "GetAllStudents")] // Marks this method to respond to HTTP GET requests.
        [ProducesResponseType(StatusCodes.Status200OK)]
      
        public ActionResult<IEnumerable<StudentDTO>> GetAllStudents() // Define a method to get all students.
        {
            //var AllStudent = Ok(StudentDataSimulation.StudentsList);
            //return AllStudent;

            List<StudentDTO> StudentsList = StudentAPIBusinessLayer.StudentBusiness.GetAllStudents();
            if (StudentsList.Count == 0)
            {
                return NotFound("No Students Found!");
            }
            return StudentsList;
        }




        [HttpGet("Passed", Name = "PassedStudents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<StudentDTO>> GetPassedStudents() 
        {
            List<StudentDTO> PassedStudentsList = StudentAPIBusinessLayer.StudentBusiness.GetPassedStudents();

            if (PassedStudentsList.Count == 0)
            {
                return NotFound("Sorry No Student Passed");
            }
            //var studentPassed =  Ok(StudentDataSimulation.StudentsList.Where( student => student.Grade >= 50 ));
            // return studentPassed;
            return PassedStudentsList;
        }





        [HttpGet("AverageGrade", Name = "GetAverageGrade")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<double> GetAverageGrade()
        {
            //StudentDataSimulation.StudentsList.Clear() ;
            double AVGStudents = StudentAPIBusinessLayer.StudentBusiness.GetAverageGrade();

            return Ok(AVGStudents);
        }




        [HttpGet("{id}", Name = "GetStudentById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<StudentDTO> GetStudentById(int id)
        {
            if (id < 1)
            {
                return BadRequest($"No accepted id:{id}" );
            }

            //var studentsId = StudentDataSimulation.StudentsList.FirstOrDefault(Student => Student.Id == id);
            StudentAPIBusinessLayer.StudentBusiness student = StudentAPIBusinessLayer.StudentBusiness.Find(id);

            if (student == null)
            {
                return NotFound($"Student with id= {id} is not found");
            }

            //here we get only the DTO object to send it back.
            StudentDTO SDTO = student.SDTO;

            //we return the DTO not the student object.
            return Ok(SDTO);
        }


        [HttpPost("AddStudent" ,Name = "AddStudent")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<StudentDTO> AddStudent(StudentDTO newStudentDTO)
        {
            //we validate the data here
            if (newStudentDTO == null || string.IsNullOrEmpty(newStudentDTO.Name) || newStudentDTO.Age < 0 || newStudentDTO.Grade < 0)
            {
                return BadRequest("Invalid student data.");
            }

            StudentAPIBusinessLayer.StudentBusiness student = new StudentAPIBusinessLayer.StudentBusiness((newStudentDTO));

            if (student.Save())
            {
                newStudentDTO.Id = student.ID;
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    new { message = "Server error To Add Student"});
            }

            //we return the DTO only not the full student object
            //we dont return Ok here,we return createdAtRoute: this will be status code 201 created.
            return CreatedAtRoute("GetStudentById", new { id = newStudentDTO.Id }, newStudentDTO);

        }


        [HttpDelete("{id}", Name = "DeleteStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult DeleteStudent(int id)
        {
            if (id < 1)
            {
                return BadRequest($"No accepted id:{id}");
            }

            //var student = StudentDataSimulation.StudentsList.FirstOrDefault(Student => Student.Id == id);
            if (StudentAPIBusinessLayer.StudentBusiness.DeleteStudent(id))

                return Ok($"Student with ID {id} has been deleted.");
            else
                return NotFound($"Student with ID {id} not found. no rows deleted!");
        }


        [HttpPut("{id}", Name = "UpdateStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult UpdateStudent(int id , StudentDTO updatedStudent)
        {
            if (id < 1 || updatedStudent == null || string.IsNullOrEmpty(updatedStudent.Name) || updatedStudent.Age < 0 || updatedStudent.Grade < 0)
            {
                return BadRequest("Invalid student data.");
            }

            //var student = StudentDataSimulation.StudentsList.FirstOrDefault(Student => Student.Id == id);
            StudentAPIBusinessLayer.StudentBusiness student = StudentAPIBusinessLayer.StudentBusiness.Find(id);

            if (student == null)
            {
                return NotFound($"Student with id= {id} is not found");
            }
         
            student.Name = updatedStudent.Name;
            student.Age = updatedStudent.Age;
            student.Grade = updatedStudent.Grade;
            if (student.Save())
            {            
                //we return the DTO not the full student object.
                return Ok(student.SDTO);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    new { message = "Server error to Update Student Info" });
            }
        }

        [HttpPost("UploadImage")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> UploadImage(IFormFile imageFile)
        {
            // Check if no file is uploaded
            if (imageFile == null || imageFile.Length == 0)
                return BadRequest("No file uploaded.");

            // Directory where files will be uploaded
            var UploadDirectory = @"C:\Pictures";
            var FileName = Guid.NewGuid().ToString() +Path.GetExtension(imageFile.FileName);
            var filePath = Path.Combine(UploadDirectory, FileName);

            // Ensure the uploads directory exists, create if it doesn't
            if (!Directory.Exists(UploadDirectory))
            {
                Directory.CreateDirectory(UploadDirectory);
            }

            // Save the file to the server
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            // Return the file path as a response
            return Ok(new { filePath });
        }

        [HttpGet("GetImage/{fileName}")]
        public IActionResult GetImage(string fileName)
        {
            // Directory where files are stored
            var uploadDirectory = @"C:\Pictures";
            var filePath = Path.Combine(uploadDirectory, fileName);

            // Check if the file exists
            if (!System.IO.File.Exists(filePath))
                return NotFound("Image not found.");

            // Open the image file for reading 
            var image = System.IO.File.OpenRead(filePath);// The image file is in memory by image variable
            var mimeType = GetMimeType(filePath); // the info for myu file

            // Return the file with the correct MIME type
            return File(image, mimeType);
        }

        // Helper method to get the MIME type based on file extension
        /*
         This code defines a  method called GetMimeType that takes a file path as a parameter 
         and returns the corresponding MIME type as a string. 
         MIME types are used to indicate the nature and format of a file, 
         especially in web contexts where you need to specify the type of content you're sending, 
         like images, text, etc.

        MIME type stands for Multipurpose Internet Mail Extensions type. 
        It's a standard way to indicate the nature and format of a file or content. 
        MIME types are used to tell browsers, email clients, and 
        other software about the type of data they're handling, so they can process it correctly.
         */
        private string GetMimeType(string filePath)
        {
            var extension = Path.GetExtension(filePath).ToLowerInvariant();
            return extension switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                _ => "application/octet-stream",
            };
        }
    }
}

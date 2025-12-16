using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq.Expressions;

namespace StudentAPIDataAccessLayer
{
    public class StudentDTO
    {
        public StudentDTO(int id, string name, int age, int grade)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.Grade = grade;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }
    }
    public class UpdateStudentDTO
    {
        public UpdateStudentDTO(string name, int age, int grade)
        {

            this.Name = name;
            this.Age = age;
            this.Grade = grade;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }
    }

    public class StudentUserDTO
    {
        public StudentUserDTO(int id, string name)
        {
            this.Id = id;
            this.Name = name;

        }
        public int Id { get; set; }
        public string Name { get; set; }

    }
    public class StudentDataAccess
    {
        static string _connectionString = "Server=localhost;Database=StudentsDB;User Id=sa;Password=sa1234;Encrypt=False;TrustServerCertificate=True;Connection Timeout=30;";
        public static List<StudentDTO> GetAllStudents()
        {
            var StudentsList = new List<StudentDTO>();

            try 
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_GetAllStudents", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                StudentsList.Add(new StudentDTO
                                (
                                    reader.GetInt32(reader.GetOrdinal("Id")),
                                    reader.GetString(reader.GetOrdinal("Name")),
                                    reader.GetInt32(reader.GetOrdinal("Age")),
                                    reader.GetInt32(reader.GetOrdinal("Grade"))
                                ));
                            }
                        }
                    }
                }

            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.ToString());
            }
            return StudentsList;

        }

        public static List<StudentDTO> GetPassedStudents()
        {
            var StudentsList = new List<StudentDTO>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_GetPassedStudents", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //All Readers Fields added to StudentDTO parameters
                                StudentsList.Add(new StudentDTO
                                (
                                    reader.GetInt32(reader.GetOrdinal("Id")),
                                    reader.GetString(reader.GetOrdinal("Name")),
                                    reader.GetInt32(reader.GetOrdinal("Age")),
                                    reader.GetInt32(reader.GetOrdinal("Grade"))
                                ));
                            }
                        }
                    }

                }
                
            }
            catch(Exception e) 
            {
               Console.WriteLine(e.Message.ToString());
            }
             return StudentsList;

        }
        public static double GetAverageGrade()
        {
            double averageGrade = 0;

            try
            {

                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_GetAverageGrade", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        conn.Open();

                        object result = cmd.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            averageGrade = Convert.ToDouble(result);
                        }
                        else
                            averageGrade = 0;

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString() );
            }

            return averageGrade;
        }
        public static StudentDTO GetStudentById(int studentId)
        {
           try
           {
                using (var connection = new SqlConnection(_connectionString))
                {
                    using (var command = new SqlCommand("SP_GetStudentById", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@StudentId", studentId);

                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new StudentDTO
                                (
                                    reader.GetInt32(reader.GetOrdinal("Id")),
                                    reader.GetString(reader.GetOrdinal("Name")),
                                    reader.GetInt32(reader.GetOrdinal("Age")),
                                    reader.GetInt32(reader.GetOrdinal("Grade"))
                                );
                            }
                           
                        }
                    }
                }
           }
            
            catch (Exception e) 
           {
                Console.WriteLine(e.Message.ToString());
           }
            return null;
        }
        public static int AddStudent(StudentDTO StudentDTO)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("SP_AddStudent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Name", StudentDTO.Name);
                    command.Parameters.AddWithValue("@Age", StudentDTO.Age);
                    command.Parameters.AddWithValue("@Grade", StudentDTO.Grade);
                    var outputIdParam = new SqlParameter("@NewStudentId", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputIdParam);

                    connection.Open();
                    command.ExecuteNonQuery();

                    return (int)outputIdParam.Value;
                }
            }
        }
        public static bool UpdateStudent(StudentDTO StudentDTO)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    using (var command = new SqlCommand("SP_UpdateStudent", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@StudentId", StudentDTO.Id);
                        command.Parameters.AddWithValue("@Name", StudentDTO.Name);
                        command.Parameters.AddWithValue("@Age", StudentDTO.Age);
                        command.Parameters.AddWithValue("@Grade", StudentDTO.Grade);

                        connection.Open();
                        command.ExecuteNonQuery();

                    }
                }

            }
            catch
            {
                return false;
            }
            return true;

        }
        public static bool DeleteStudent(int studentId)
        {

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("SP_DeleteStudent", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@StudentId", studentId);

                connection.Open();

                int rowsAffected = (int)command.ExecuteScalar();
                return (rowsAffected == 1);
            }
        }
    }
}

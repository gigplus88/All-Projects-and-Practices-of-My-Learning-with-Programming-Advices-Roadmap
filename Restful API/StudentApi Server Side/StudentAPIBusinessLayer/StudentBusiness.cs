using StudentAPIDataAccessLayer;

namespace StudentAPIBusinessLayer
{
    public class StudentBusiness
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public StudentDTO SDTO
        {
            get { return (new StudentDTO(this.ID, this.Name, this.Age, this.Grade)); }
        }
       
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }

        public StudentBusiness(StudentDTO SDTO, enMode cMode = enMode.AddNew)

        {
            this.ID = SDTO.Id;
            this.Name = SDTO.Name;
            this.Age = SDTO.Age;
            this.Grade = SDTO.Grade;

            Mode = cMode;
        }
        public static StudentBusiness Find(int ID)
        {
            StudentDTO SDTO = StudentDataAccess.GetStudentById(ID);

            if (SDTO != null)//we return new object of that student with the right data
            {
                return new StudentBusiness(SDTO, enMode.Update);
            }
            else
                return null;
        }

        // Find By StudentUserDTO
        // by Id and Name

        //public static StudentBusiness Find(int ID)
        //{
        //    StudentUserDTO SDTU = StudentDataAccess.GetStudentById(ID);

        //    if (SDTU != null)//we return new object of that student with the right data
        //    {
        //        return new StudentBusiness(SDTU, enMode.Update);
        //    }
        //    else
        //        return null;
        //}
        private bool _AddNewStudent()
        {
            //call DataAccess Layer 

            this.ID = StudentDataAccess.AddStudent(SDTO);

            return (this.ID != -1);
        }

        private bool _UpdateStudent()
        {
            return StudentDataAccess.UpdateStudent(SDTO); 
        }
        public static bool DeleteStudent(int ID)
        {
            return StudentDataAccess.DeleteStudent(ID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewStudent())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateStudent();

            }

            return false;
        }

        public static List<StudentDTO> GetAllStudents()
        {
            return StudentDataAccess.GetAllStudents();
        }
        public static List<StudentDTO> GetPassedStudents()
        {
            return StudentDataAccess.GetPassedStudents();
        }
        public static double GetAverageGrade()
        {
            return StudentDataAccess.GetAverageGrade();
        }
    }
}

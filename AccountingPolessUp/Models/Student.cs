
namespace StudentAccounting.Model.DataBaseModels
{
    public class Student
    {
        public int Id { get; set; }
        public long StudentCard { get; set; }
        public string Group { get; set; } = string.Empty;
        public int CourseNumber { get; set; }
        public string University { get; set; } = string.Empty;
        public int IndividualsId { get; set; }
        public Individuals? Individuals { get; set; }
    }
}

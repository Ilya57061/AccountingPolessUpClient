
namespace AccountingPolessUp.Models
{  public class Student
{
    public int Id { get; set; }
    public int StudentCard { get; set; }
    public string Group { get; set; } = string.Empty;
    public int CourseNumber { get; set; }
    public string University { get; set; } = string.Empty;
    public int IndivisualsId { get; set; }
    public Individuals Individuals { get; set; }
}
}

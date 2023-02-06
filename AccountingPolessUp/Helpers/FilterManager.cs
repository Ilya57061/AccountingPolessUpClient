using AccountingPolessUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace AccountingPolessUp.Helpers
{
    public static class FilterManager
    {
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<Organization> list, string name, string address, string contacts, string website, string dateFoundation)
        {
            if (!string.IsNullOrEmpty(name))
                list = list.Where(x => x.Fullname == name);
            if (!string.IsNullOrEmpty(address))
                list = list.Where(x => x.Address == address);
            if (!string.IsNullOrEmpty(contacts))
                list = list.Where(x => x.Contacts == contacts);
            if (!string.IsNullOrEmpty(website))
                list = list.Where(x => x.WebSite == website);
            if (!string.IsNullOrEmpty(dateFoundation))
                list = list.Where(x => x.FoundationDate == DateTime.Parse(dateFoundation));
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }

        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<Individuals> list, string name, string phone, string birthday, string email, string gender, string socialNetwork)
        {
            if (!string.IsNullOrEmpty(name))
                list = list.Where(x => x.FIO == name);
            if (!string.IsNullOrEmpty(phone))
                list = list.Where(x => x.Phone == phone);
            if (!string.IsNullOrEmpty(birthday))
                list = list.Where(x => x.DateOfBirth == DateTime.Parse(birthday));
            if (!string.IsNullOrEmpty(email))
                list = list.Where(x => x.Gender == gender);
            if (!string.IsNullOrEmpty(socialNetwork))
                list = list.Where(x => x.SocialNetwork == socialNetwork);
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<Participants> list, string individual, int mmr, string user, string dateEntry, string dateExit, string status, string github)
        {
            if (!string.IsNullOrEmpty(individual))
                list = list.Where(x => x.Individuals.FIO == individual);
            if (mmr != null)
                list = list.Where(x => x.Mmr == mmr);
            if (!string.IsNullOrEmpty(user))
                list = list.Where(x => x.User.Login == user);
            if (!string.IsNullOrEmpty(dateEntry))
                list = list.Where(x => x.DateEntry == DateTime.Parse(dateEntry));
            if (!string.IsNullOrEmpty(dateExit))
                list = list.Where(x => x.DateExit == DateTime.Parse(dateExit));
            if (!string.IsNullOrEmpty(status))
                list = list.Where(x => x.Status == status);
            if (!string.IsNullOrEmpty(github))
                list = list.Where(x => x.GitHub == github);
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<EducationalPortals> list, string department, string name, string description, string link)
        {
            if (!string.IsNullOrEmpty(department))
                list = list.Where(x => x.Department.FullName == department);
            if (!string.IsNullOrEmpty(name))
                list = list.Where(x => x.Name == name);
            if (!string.IsNullOrEmpty(description))
                list = list.Where(x => x.Description == description);
            if (!string.IsNullOrEmpty(link))
                list = list.Where(x => x.Link == link);
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<Department> list, string name, string description, string dateStart, string dateEnd, string status, string organization)
        {
            if (!string.IsNullOrEmpty(name))
                list = list.Where(x => x.FullName == name);
            if (!string.IsNullOrEmpty(description))
                list = list.Where(x => x.Description == description);
            if (!string.IsNullOrEmpty(dateStart))
                list = list.Where(x => x.DateStart == DateTime.Parse(dateStart));
            if (!string.IsNullOrEmpty(dateEnd))
                list = list.Where(x => x.DateEnd == DateTime.Parse(dateEnd));
            if (!string.IsNullOrEmpty(status))
                list = list.Where(x => x.Status == status);
            if (!string.IsNullOrEmpty(organization))
                list = list.Where(x => x.Organizations.Fullname == organization);
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<Customer> list, string name, string address, string contacts, string website, string description)
        {
            if (!string.IsNullOrEmpty(name))
                list = list.Where(x => x.FullName == name);
            if
            (!string.IsNullOrEmpty(address))
                list = list.Where(x => x.Address == address);
            if (!string.IsNullOrEmpty(contacts))
                list = list.Where(x => x.Contacts == contacts);
            if (!string.IsNullOrEmpty(website))
                list = list.Where(x => x.WebSite == website);
            if (!string.IsNullOrEmpty(description))
                list = list.Where(x => x.Description == description);
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<TrainingCourses> list, string name, string description, string link)
        {
            if (!string.IsNullOrEmpty(name))
                list = list.Where(x => x.Name == name);
            if (!string.IsNullOrEmpty(description))
                list = list.Where(x => x.Description == description);
            if (!string.IsNullOrEmpty(description))
                list = list.Where(x => x.Link == link);
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<Bonus> list, string bonus, string rank, string description)
        {
            if (!string.IsNullOrEmpty(bonus))
                list = list.Where(x => x.BonusName == bonus);
            if (!string.IsNullOrEmpty(rank))
                list = list.Where(x => x.Rank.RankName == rank);
            if (!string.IsNullOrEmpty(description))
                list = list.Where(x => x.BonusDescription == description);
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<ApplicationsInTheProject> list, string workStatus, string dateEntry, string participant, string vacancy)
        {
            if (!string.IsNullOrEmpty(participant))
                list = list.Where(x => x.Participants.Individuals.FIO == participant);
            if (!string.IsNullOrEmpty(vacancy))
                list = list.Where(x => x.Vacancy.Name == vacancy);
            if (!string.IsNullOrEmpty(workStatus))
                list = list.Where(x => x.WorkStatus == workStatus);
            if (!string.IsNullOrEmpty(dateEntry))
                list = list.Where(x => x.DateEntry == DateTime.Parse(dateEntry));
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<Position> list, string name, string description, string department)
        {
            if (!string.IsNullOrEmpty(name))
            {
                list = list.Where(x => x.FullName == name);
            }
            if (!string.IsNullOrEmpty(description))
            {
                list = list.Where(x => x.Description == description);
            }
            if (!string.IsNullOrEmpty(department))
            {
                list = list.Where(x => x.Department.FullName == department);
            }
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<Project> list, string customer, string status, string dateStart, 
            string dateEnd, string description, string technicalSpecification, int idLocalPM)
        {
         
            if (!string.IsNullOrEmpty(description))
            {
                list = list.Where(x => x.Description == description);
            }
            if (!string.IsNullOrEmpty(customer))
            {
                list = list.Where(x => x.Customer.FullName == customer);
            }
            if (!string.IsNullOrEmpty(status))
            {
                list = list.Where(x => x.Status== status);
            }
            if (!string.IsNullOrEmpty(technicalSpecification))
            {
                list = list.Where(x => x.TechnicalSpecification == technicalSpecification);
            }
            if (idLocalPM!=null)
            {
                list = list.Where(x => x.idLocalPM == idLocalPM);
            }
            if (!string.IsNullOrEmpty(dateStart))
            {
                list = list.Where(x => x.DateStart == DateTime.Parse(dateStart));
            }
            if (!string.IsNullOrEmpty(dateEnd))
            {
                list = list.Where(x => x.DateEnd == DateTime.Parse(dateEnd));
            }

            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<Rank> list, string name, string description, string organization, int minMmr, int maxMmr)
        {
            if (!string.IsNullOrEmpty(organization))
            {
                list = list.Where(x => x.Organizations.Fullname == organization);
            }
            if (!string.IsNullOrEmpty(description))
            {
                list = list.Where(x => x.Description == description);
            }
            if (!string.IsNullOrEmpty(name))
            {
                list = list.Where(x => x.RankName == name);
            }
            if (minMmr != null)
            {
                list = list.Where(x => x.MinMmr == minMmr);
            }
            if (maxMmr != null)
            {
                list = list.Where(x => x.MaxMmr == maxMmr);
            }
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<RegistrationForCourses> list, string dateEntry, string participant, string course)
        {
            if (!string.IsNullOrEmpty(participant))
            {
                list = list.Where(x => x.Participants.Individuals.FIO == participant);
            }
            if (!string.IsNullOrEmpty(course))
            {
                list = list.Where(x => x.TrainingCourses.Name == course);
            }
            if (!string.IsNullOrEmpty(dateEntry))
            {
                list = list.Where(x => x.DateEntry == DateTime.Parse(dateEntry));
            }
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<Regulation> list, string organization, string name, string text, string description)
        {
            if (!string.IsNullOrEmpty(organization))
            {
                list = list.Where(x => x.Organization.Fullname == organization);
            }
            if (!string.IsNullOrEmpty(description))
            {
                list = list.Where(x => x.Description == description);
            }
            if (!string.IsNullOrEmpty(name))
            {
                list = list.Where(x => x.Name == name);
            }
            if (!string.IsNullOrEmpty(text))
            {
                list = list.Where(x => x.Text == text);
            }
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<ScheduleOfСlasses> list, string description, string dateStart, string dateEnd, string link, string course)
        {
            if (!string.IsNullOrEmpty(link))
            {
                list = list.Where(x => x.WorkSpaceLink == link);
            }
            if (!string.IsNullOrEmpty(description))
            {
                list = list.Where(x => x.Description == description);
            }
            if (!string.IsNullOrEmpty(course))
            {
                list = list.Where(x => x.TrainingCourses.Name == course);
            }
            if (!string.IsNullOrEmpty(dateStart))
            {
                list = list.Where(x => x.DateStart == DateTime.Parse(dateStart));
            }
            if (!string.IsNullOrEmpty(dateEnd))
            {
                list = list.Where(x => x.DateEnd == DateTime.Parse(dateEnd));
            }
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<StagesOfProject> list, string name, string description, string dateStart, string dateEnd, string status, string project)
        {
            if (!string.IsNullOrEmpty(name))
            {
                list = list.Where(x => x.Name == name);
            }
            if (!string.IsNullOrEmpty(description))
            {
                list = list.Where(x => x.Description == description);
            }
            if (!string.IsNullOrEmpty(status))
            {
                list = list.Where(x => x.Status==status);
            }
            if (!string.IsNullOrEmpty(project))
            {
                list = list.Where(x => x.Project.Fullname == project);
            }
            if (!string.IsNullOrEmpty(dateStart))
            {
                list = list.Where(x => x.DateStart == DateTime.Parse(dateStart));
            }
            if (!string.IsNullOrEmpty(dateEnd))
            {
                list = list.Where(x => x.DateEnd == DateTime.Parse(dateEnd));
            }
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<Student> list, int studentCard, string group, string individual,int coursNumber, string university )
        {
            if (studentCard!=null)
            {
                list = list.Where(x => x.StudentCard == studentCard);
            }
            if (!string.IsNullOrEmpty(group))
            {
                list = list.Where(x => x.Group == group);
            }
            if (!string.IsNullOrEmpty(individual))
            {
                list = list.Where(x => x.Individuals.FIO == individual);
            }
            if (coursNumber!=null)
            {
                list = list.Where(x => x.CourseNumber == coursNumber);
            }
            if (!string.IsNullOrEmpty(university))
            {
                list = list.Where(x => x.University == university);
            }
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<User> list, string login, string role)
        {
            if (!string.IsNullOrEmpty(login))
            {
                list = list.Where(x => x.Login == login);
            }
            if (!string.IsNullOrEmpty(role))
            {
                list = list.Where(x => x.Role.Name == role);
            }
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }

        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<Vacancy> list, string name, string description, string responsibilities,
          string dateStart, string dateEnd, double budjet, string stagesOfProject, bool isOpened)
        {
            if (!string.IsNullOrEmpty(name))
            {
                list = list.Where(x => x.Name == name);
            }
            if (!string.IsNullOrEmpty(description))
            {
                list = list.Where(x => x.Descriptions == description);
            }
            if (!string.IsNullOrEmpty(responsibilities))
            {
                list = list.Where(x => x.Responsibilities == responsibilities);
            }
            if (!string.IsNullOrEmpty(stagesOfProject))
            {
                list = list.Where(x => x.StagesOfProject.Name == responsibilities);
            }
            if (budjet != null)
            {
                list = list.Where(x => x.Budjet == budjet);
            }
            if (isOpened != null)
            {
                list = list.Where(x => x.isOpened == isOpened);
            }
            if (!string.IsNullOrEmpty(dateStart))
            {
                list = list.Where(x => x.DateStart == DateTime.Parse(dateStart));
            }
            if (!string.IsNullOrEmpty(dateEnd))
            {
                list = list.Where(x => x.DateEnd == DateTime.Parse(dateEnd));
            }
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<Employment> employments, string dateStart, string dateEnd, string position,
            string status, string description, int mentor)
        {
            if (!string.IsNullOrEmpty(position))
            {
                employments = employments.Where(x => x.Position.FullName == position);
            }
            if (!string.IsNullOrEmpty(description))
            {
                employments = employments.Where(x => x.StatusDescription == description);
            }
            if (!string.IsNullOrEmpty(status))
            {
                employments = employments.Where(x => x.Status == status);
            }
            if (mentor!=null)
            {
                employments = employments.Where(x => x.IdMentor == mentor);
            }
            if (!string.IsNullOrEmpty(dateStart))
            {
                employments = employments.Where(x => x.DateStart == DateTime.Parse(dateStart));
            }
            if (!string.IsNullOrEmpty(dateEnd))
            {
                employments = employments.Where(x => x.DateEnd == DateTime.Parse(dateEnd));
            }
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = employments;
        }

        public static void ConfirmFilter(DataGrid dataGrid ,IEnumerable<FinalProject> finalProjects, string name, string description, string gitHub,
            string link, string dateStart, string dateEnd)
        {
            if (!string.IsNullOrEmpty(name))
            {
                finalProjects = finalProjects.Where(x=>x.Name==name);
            }
            if (!string.IsNullOrEmpty(description))
            {
                finalProjects = finalProjects.Where(x => x.Description == description);
            }
            if (!string.IsNullOrEmpty(gitHub))
            {
                finalProjects = finalProjects.Where(x => x.GitHub == gitHub);
            }
            if (!string.IsNullOrEmpty(link))
            {
                finalProjects = finalProjects.Where(x => x.Links == link);
            }
            if (!string.IsNullOrEmpty(dateStart))
            {
                finalProjects = finalProjects.Where(x => x.DateStart == DateTime.Parse(dateStart));
            }
            if (!string.IsNullOrEmpty(dateEnd))
            {
                finalProjects = finalProjects.Where(x => x.DateEnd == DateTime.Parse(dateEnd));
            }
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = finalProjects; 
        }

    }
}

using AccountingPolessUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace AccountingPolessUp.Helpers
{
    public static class FilterManager
    {
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

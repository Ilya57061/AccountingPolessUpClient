using AccountingPolessUp.Models;
using MaterialDesignThemes.Wpf.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows.Controls;

namespace AccountingPolessUp.Helpers
{
    public static class FilterManager
    {
        public static void ClearControls(Panel panel)
        {
            foreach (var control in panel.Children)
            {
                if (control is ComboBox)
                {
                    ((ComboBox)control).SelectedIndex = -1;
                }
                else if (control is DatePicker)
                {
                    ((DatePicker)control).SelectedDate = null;
                }
                else if (control is TextBox)
                {
                    ((TextBox)control).Clear();
                }
            }

        }
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<Organization> list, string name, string address, string contacts, string website, string dateFoundation)
        {
            if (!string.IsNullOrEmpty(name))
                list = list.Where(x => x.Fullname.StartsWith(name));
            if (!string.IsNullOrEmpty(address))
                list = list.Where(x => x.Address.StartsWith(address));
            if (!string.IsNullOrEmpty(contacts))
                list = list.Where(x => x.Contacts.StartsWith(contacts));
            if (!string.IsNullOrEmpty(website))
                list = list.Where(x => x.WebSite.StartsWith(website));
            if (!string.IsNullOrEmpty(dateFoundation))
                list = list.Where(x => x.FoundationDate == DateTime.Parse(dateFoundation));
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }

        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<Individuals> list, string name, string phone, string birthday, string email, string gender, string socialNetwork)
        {
            if (!string.IsNullOrEmpty(name))
                list = list.Where(x => x.FIO.StartsWith(name));
            if (!string.IsNullOrEmpty(phone))
                list = list.Where(x => x.Phone.StartsWith(phone));
            if (!string.IsNullOrEmpty(birthday))
                list = list.Where(x => x.DateOfBirth == DateTime.Parse(birthday));
            if (!string.IsNullOrEmpty(email))
                list = list.Where(x => x.Gender.StartsWith(gender));
            if (!string.IsNullOrEmpty(socialNetwork))
                list = list.Where(x => x.SocialNetwork.StartsWith(socialNetwork));
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<Participants> list, string individual, string mmr, string user, string dateEntry, string dateExit, string status, string github)
        {
            if (!string.IsNullOrEmpty(individual))
                list = list.Where(x => x.Individuals.FIO.StartsWith(individual));
            if (!string.IsNullOrEmpty(mmr))
                list = list.Where(x => x.Mmr == int.Parse(mmr));
            if (!string.IsNullOrEmpty(user))
                list = list.Where(x => x.User.Login.StartsWith(user));
            if (!string.IsNullOrEmpty(dateEntry))
                list = list.Where(x => x.DateEntry == DateTime.Parse(dateEntry));
            if (!string.IsNullOrEmpty(dateExit))
                list = list.Where(x => x.DateExit == DateTime.Parse(dateExit));
            if (!string.IsNullOrEmpty(status))
                list = list.Where(x => x.Status.StartsWith(status));
            if (!string.IsNullOrEmpty(github))
                list = list.Where(x => x.GitHub.StartsWith(github));
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<EducationalPortals> list, string department, string name, string description, string link)
        {
            if (!string.IsNullOrEmpty(department))
                list = list.Where(x => x.Department.FullName.StartsWith(department));
            if (!string.IsNullOrEmpty(name))
                list = list.Where(x => x.Name.StartsWith(name));
            if (!string.IsNullOrEmpty(description))
                list = list.Where(x => x.Description.StartsWith(description));
            if (!string.IsNullOrEmpty(link))
                list = list.Where(x => x.Link.StartsWith(link));
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<Department> list, string name, string description, string dateStart, string dateEnd, string status, string organization)
        {
            if (!string.IsNullOrEmpty(name))
                list = list.Where(x => x.FullName.StartsWith(name));
            if (!string.IsNullOrEmpty(description))
                list = list.Where(x => x.Description.StartsWith(description));
            if (!string.IsNullOrEmpty(dateStart))
                list = list.Where(x => x.DateStart == DateTime.Parse(dateStart));
            if (!string.IsNullOrEmpty(dateEnd))
                list = list.Where(x => x.DateEnd == DateTime.Parse(dateEnd));
            if (!string.IsNullOrEmpty(status))
                list = list.Where(x => x.Status.StartsWith(status));
            if (!string.IsNullOrEmpty(organization))
                list = list.Where(x => x.Organizations.Fullname.StartsWith(organization));
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<Customer> list, string name, string address, string contacts, string website, string description)
        {
            if (!string.IsNullOrEmpty(name))
                list = list.Where(x => x.FullName.StartsWith(name));
            if
            (!string.IsNullOrEmpty(address))
                list = list.Where(x => x.Address.StartsWith(address));
            if (!string.IsNullOrEmpty(contacts))
                list = list.Where(x => x.Contacts.StartsWith(contacts));
            if (!string.IsNullOrEmpty(website))
                list = list.Where(x => x.WebSite.StartsWith(website));
            if (!string.IsNullOrEmpty(description))
                list = list.Where(x => x.Description.StartsWith(description));
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<TrainingCourses> list, string name, string description, string link)
        {
            if (!string.IsNullOrEmpty(name))
                list = list.Where(x => x.Name.StartsWith(name));
            if (!string.IsNullOrEmpty(description))
                list = list.Where(x => x.Description.StartsWith(description));
            if (!string.IsNullOrEmpty(description))
                list = list.Where(x => x.Link.StartsWith(link));
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<Bonus> list, string name, string rank, string description)
        {
            if (!string.IsNullOrEmpty(name))
                list = list.Where(x => x.BonusName.StartsWith(name));
            if (!string.IsNullOrEmpty(rank))
                list = list.Where(x => x.Rank.RankName.StartsWith(rank));
            if (!string.IsNullOrEmpty(description))
                list = list.Where(x => x.BonusDescription.StartsWith(description));
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<ApplicationsInTheProject> list, string workStatus, string dateEntry, string participant, string vacancy)
        {
            if (!string.IsNullOrEmpty(participant))
                list = list.Where(x => x.Participants.Individuals.FIO.StartsWith(participant));
            if (!string.IsNullOrEmpty(vacancy))
                list = list.Where(x => x.Vacancy.Name.StartsWith(vacancy));
            if (!string.IsNullOrEmpty(workStatus))
                list = list.Where(x => x.WorkStatus.StartsWith(workStatus));
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
                list = list.Where(x => x.FullName.StartsWith(name));
            }
            if (!string.IsNullOrEmpty(description))
            {
                list = list.Where(x => x.Description.StartsWith(description));
            }
            if (!string.IsNullOrEmpty(department))
            {
                list = list.Where(x => x.Department.FullName.StartsWith(department));
            }
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<Project> list, string customer, string status, string dateStart,
            string dateEnd, string description, string technicalSpecification, string idLocalPM, string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                list = list.Where(x => x.Fullname.StartsWith(name));
            }
            if (!string.IsNullOrEmpty(description))
            {
                list = list.Where(x => x.Description.StartsWith(description));
            }
            if (!string.IsNullOrEmpty(customer))
            {
                list = list.Where(x => x.Customer.FullName.StartsWith(customer));
            }
            if (!string.IsNullOrEmpty(status))
            {
                list = list.Where(x => x.Status.StartsWith(status));
            }
            if (!string.IsNullOrEmpty(technicalSpecification))
            {
                list = list.Where(x => x.TechnicalSpecification.StartsWith(technicalSpecification));
            }
            if (!string.IsNullOrEmpty(idLocalPM))
            {
                list = list.Where(x => x.idLocalPM == int.Parse(idLocalPM));
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
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<Rank> list, string name, string description, string organization, string minMmr, string maxMmr)
        {
            if (!string.IsNullOrEmpty(organization))
            {
                list = list.Where(x => x.Organizations.Fullname.StartsWith(organization));
            }
            if (!string.IsNullOrEmpty(description))
            {
                list = list.Where(x => x.Description.StartsWith(description));
            }
            if (!string.IsNullOrEmpty(name))
            {
                list = list.Where(x => x.RankName.StartsWith(name));
            }
            if (!string.IsNullOrEmpty(minMmr))
            {
                list = list.Where(x => x.MinMmr == int.Parse(minMmr));
            }
            if (!string.IsNullOrEmpty(maxMmr))
            {
                list = list.Where(x => x.MaxMmr == int.Parse(maxMmr));
            }
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<RegistrationForCourses> list, string dateEntry, string participant, string course)
        {
            if (!string.IsNullOrEmpty(participant))
            {
                list = list.Where(x => x.Participants.Individuals.FIO.StartsWith(participant));
            }
            if (!string.IsNullOrEmpty(course))
            {
                list = list.Where(x => x.TrainingCourses.Name.StartsWith(course));
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
                list = list.Where(x => x.Organization.Fullname.StartsWith(organization));
            }
            if (!string.IsNullOrEmpty(description))
            {
                list = list.Where(x => x.Description.StartsWith(description));
            }
            if (!string.IsNullOrEmpty(name))
            {
                list = list.Where(x => x.Name.StartsWith(name));
            }
            if (!string.IsNullOrEmpty(text))
            {
                list = list.Where(x => x.Text.StartsWith(text));
            }
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<ScheduleOfСlasses> list, string description, string dateStart, string dateEnd, string link, string course)
        {
            if (!string.IsNullOrEmpty(link))
            {
                list = list.Where(x => x.WorkSpaceLink.StartsWith(link));
            }
            if (!string.IsNullOrEmpty(description))
            {
                list = list.Where(x => x.Description.StartsWith(description));
            }
            if (!string.IsNullOrEmpty(course))
            {
                list = list.Where(x => x.TrainingCourses.Name.StartsWith(course));
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
                list = list.Where(x => x.Name.StartsWith(name));
            }
            if (!string.IsNullOrEmpty(description))
            {
                list = list.Where(x => x.Description.StartsWith(description));
            }
            if (!string.IsNullOrEmpty(status))
            {
                list = list.Where(x => x.Status.StartsWith(status));
            }
            if (!string.IsNullOrEmpty(project))
            {
                list = list.Where(x => x.Project.Fullname.StartsWith(project));
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
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<Student> list, string studentCard, string group, string individual, string coursNumber, string university)
        {
            if (!string.IsNullOrEmpty(studentCard))
            {
                list = list.Where(x => x.StudentCard == int.Parse(studentCard));
            }
            if (!string.IsNullOrEmpty(group))
            {
                list = list.Where(x => x.Group.StartsWith(group));
            }
            if (!string.IsNullOrEmpty(individual))
            {
                list = list.Where(x => x.Individuals.FIO.StartsWith(individual));
            }
            if (!string.IsNullOrEmpty(coursNumber))
            {
                list = list.Where(x => x.CourseNumber == int.Parse(coursNumber));
            }
            if (!string.IsNullOrEmpty(university))
            {
                list = list.Where(x => x.University.StartsWith(university));
            }
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<User> list, string login, string role)
        {
            if (!string.IsNullOrEmpty(login))
            {
                list = list.Where(x => x.Login.StartsWith(login));
            }
            if (!string.IsNullOrEmpty(role))
            {
                list = list.Where(x => x.Role.Name.StartsWith(role));
            }
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }

        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<Vacancy> list, string name, string description, string responsibilities,
          string dateStart, string dateEnd, string budjet, string stagesOfProject, string isOpened)
        {
            if (!string.IsNullOrEmpty(name))
            {
                list = list.Where(x => x.Name.StartsWith(name));
            }
            if (!string.IsNullOrEmpty(description))
            {
                list = list.Where(x => x.Descriptions.StartsWith(description));
            }
            if (!string.IsNullOrEmpty(responsibilities))
            {
                list = list.Where(x => x.Responsibilities.StartsWith(responsibilities));
            }
            if (!string.IsNullOrEmpty(stagesOfProject))
            {
                list = list.Where(x => x.StagesOfProject.Name.StartsWith(responsibilities));
            }
            if (!string.IsNullOrEmpty(budjet))
            {
                list = list.Where(x => x.Budjet == double.Parse(budjet));
            }
            if (!string.IsNullOrEmpty(isOpened))
            {
                list = list.Where(x => x.isOpened == bool.Parse(isOpened));
            }
            if (!string.IsNullOrEmpty(dateStart))
            {
                list = list.Where(x => x.DateStart==DateTime.Parse(dateStart));
            }
            if (!string.IsNullOrEmpty(dateEnd))
            {
                list = list.Where(x => x.DateEnd==DateTime.Parse(dateEnd));
            }
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<Employment> employments, string dateStart, string dateEnd, string position,
            string status, string description, string mentor, string participant)
        {
            if (!string.IsNullOrEmpty(position))
            {
                employments = employments.Where(x => x.Position.FullName.StartsWith(position));
            }
            if (!string.IsNullOrEmpty(description))
            {
                employments = employments.Where(x => x.StatusDescription.StartsWith(description));
            }
            if (!string.IsNullOrEmpty(status))
            {
                employments = employments.Where(x => x.Status.StartsWith(status));
            }
            if (!string.IsNullOrEmpty(mentor))
            {
                employments = employments.Where(x => x.IdMentor == int.Parse(mentor));
            }
            if (!string.IsNullOrEmpty(dateStart))
            {
                employments = employments.Where(x => x.DateStart==DateTime.Parse(dateStart));
            }
            if (!string.IsNullOrEmpty(dateEnd))
            {
                employments = employments.Where(x => x.DateEnd == DateTime.Parse(dateEnd));
            }
            if (!string.IsNullOrEmpty(participant))
            {
                employments = employments.Where(x => x.Participants.Individuals.FIO.StartsWith(participant));
            }
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = employments;
        }


        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<FinalProject> finalProjects, string name, string description, string gitHub,
              string link, string dateStart, string dateEnd)
        {
            if (!string.IsNullOrEmpty(name))
            {
                finalProjects = finalProjects.Where(x => x.Name.StartsWith(name));
            }
            if (!string.IsNullOrEmpty(description))
            {
                finalProjects = finalProjects.Where(x => x.Description.StartsWith(description));
            }
            if (!string.IsNullOrEmpty(gitHub))
            {
                finalProjects = finalProjects.Where(x => x.GitHub.StartsWith(gitHub));
            }
            if (!string.IsNullOrEmpty(link))
            {
                finalProjects = finalProjects.Where(x => x.Links.StartsWith(link));
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

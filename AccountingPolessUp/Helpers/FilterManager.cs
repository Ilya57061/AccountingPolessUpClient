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
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<Organization> list, string name, string address, string contacts, string website, string dateFoundation, string bSR)
        {
            if (!string.IsNullOrEmpty(name))
                list = list.Where(x => x.Fullname.ToLower().StartsWith(name.ToLower()));
            if (!string.IsNullOrEmpty(address))
                list = list.Where(x => x.Address.ToLower().StartsWith(address.ToLower()));
            if (!string.IsNullOrEmpty(contacts))
                list = list.Where(x => x.Contacts.ToLower().StartsWith(contacts.ToLower()));
            if (!string.IsNullOrEmpty(website))
                list = list.Where(x => x.WebSite.ToLower().StartsWith(website.ToLower()));
            if (!string.IsNullOrEmpty(dateFoundation))
                list = list.Where(x => x.FoundationDate.ToString().StartsWith(DateTime.Parse(dateFoundation).ToString()));
            if (!string.IsNullOrEmpty(bSR))
                list = list.Where(x => x.BSR.ToString().StartsWith(bSR));
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }

        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<Individuals> list, string name, string phone, string birthday, string email, string gender, string socialNetwork)
        {
            if (!string.IsNullOrEmpty(name))
                list = list.Where(x => x.FIO.ToLower().StartsWith(name.ToLower()));
            if (!string.IsNullOrEmpty(phone))
                list = list.Where(x => x.Phone.ToLower().StartsWith(phone.ToLower()));
            if (!string.IsNullOrEmpty(birthday))
                list = list.Where(x => x.DateOfBirth.ToString().StartsWith(DateTime.Parse(birthday).ToString()));
            if (!string.IsNullOrEmpty(email))
                list = list.Where(x => x.Gender.ToLower().StartsWith(gender.ToLower()));
            if (!string.IsNullOrEmpty(socialNetwork))
                list = list.Where(x => x.SocialNetwork.ToLower().StartsWith(socialNetwork.ToLower()));
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<Participants> list, string individual, string mmr, string user, string dateEntry, string dateExit, string status, string github)
        {
            if (!string.IsNullOrEmpty(individual))
                list = list.Where(x => x.Individuals.FIO.ToLower().StartsWith(individual.ToLower()));
            if (!string.IsNullOrEmpty(mmr))
                list = list.Where(x => x.Mmr.ToString().ToLower().StartsWith(mmr.ToLower()));
            if (!string.IsNullOrEmpty(user))
                list = list.Where(x => x.User.Login.ToLower().StartsWith(user.ToLower()));
            if (!string.IsNullOrEmpty(dateEntry))
                list = list.Where(x => x.DateEntry.ToString().StartsWith(DateTime.Parse(dateEntry).ToString()));
            if (!string.IsNullOrEmpty(dateExit))
                list = list.Where(x => x.DateExit.ToString().StartsWith(DateTime.Parse(dateExit).ToString()));
            if (!string.IsNullOrEmpty(status))
                list = list.Where(x => x.Status.ToLower().StartsWith(status.ToLower()));
            if (!string.IsNullOrEmpty(github))
                list = list.Where(x => x.GitHub.ToLower().StartsWith(github.ToLower()));
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<EducationalPortals> list, string department, string name, string description, string link)
        {
            if (!string.IsNullOrEmpty(department))
                list = list.Where(x => x.Department.FullName.ToLower().StartsWith(department.ToLower()));
            if (!string.IsNullOrEmpty(name))
                list = list.Where(x => x.Name.ToLower().StartsWith(name.ToLower()));
            if (!string.IsNullOrEmpty(description))
                list = list.Where(x => x.Description.   StartsWith(description));
            if (!string.IsNullOrEmpty(link))
                list = list.Where(x => x.Link.ToLower().StartsWith(link.ToLower()));
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<Department> list, string name, string description, string dateStart, string dateEnd, string status, string organization, string director)
        {
            if (!string.IsNullOrEmpty(name))
                list = list.Where(x => x.FullName.ToLower().StartsWith(name.ToLower()));
            if (!string.IsNullOrEmpty(description))
                list = list.Where(x => x.Description.ToLower().StartsWith(description.ToLower()));
            if (!string.IsNullOrEmpty(dateStart))
                list = list.Where(x => x.DateStart.ToString().StartsWith(DateTime.Parse(dateStart).ToString()));
            if (!string.IsNullOrEmpty(dateEnd))
                list = list.Where(x => x.DateEnd.ToString().StartsWith(DateTime.Parse(dateEnd).ToString()));
            if (!string.IsNullOrEmpty(status))
                list = list.Where(x => x.Status.ToLower().StartsWith(status.ToLower()));
            if (!string.IsNullOrEmpty(organization))
                list = list.Where(x => x.Organizations.Fullname.ToLower().StartsWith(organization.ToLower()));
            if (!string.IsNullOrEmpty(director))
                list = list.Where(x => x.DirectorId.ToString().ToLower().StartsWith(director.ToLower()));
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<Customer> list, string name, string address, string contacts, string website, string description)
        {
            if (!string.IsNullOrEmpty(name))
                list = list.Where(x => x.FullName.ToLower().StartsWith(name.ToLower()));
            if
            (!string.IsNullOrEmpty(address))
                list = list.Where(x => x.Address.ToLower().StartsWith(address.ToLower()));
            if (!string.IsNullOrEmpty(contacts))
                list = list.Where(x => x.Contacts.ToLower().StartsWith(contacts.ToLower()));
            if (!string.IsNullOrEmpty(website))
                list = list.Where(x => x.WebSite.ToLower().StartsWith(website.ToLower()));
            if (!string.IsNullOrEmpty(description))
                list = list.Where(x => x.Description.ToLower().StartsWith(description.ToLower()));
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<TrainingCourses> list, string name, string description, string link,
            string lectorFIO, string lectorDescription, string dateStart, string dateEnd, string isActive)
        {
            if (!string.IsNullOrEmpty(name))
                list = list.Where(x => x.Name.ToLower().StartsWith(name.ToLower()));
            if (!string.IsNullOrEmpty(description))
                list = list.Where(x => x.Description.ToLower().StartsWith(description.ToLower()));
            if (!string.IsNullOrEmpty(description))
                list = list.Where(x => x.Link.ToLower().StartsWith(link.ToLower()));
            if (!string.IsNullOrEmpty(lectorFIO))
                list = list.Where(x => x.LectorFIO.ToLower().StartsWith(lectorFIO.ToLower()));
            if (!string.IsNullOrEmpty(lectorDescription))
                list = list.Where(x => x.LectorDescription.ToLower().StartsWith(lectorDescription.ToLower()));
            if (!string.IsNullOrEmpty(dateStart))
                list = list.Where(x => x.DateStart.ToString().StartsWith(DateTime.Parse(dateStart).ToString()));
            if (!string.IsNullOrEmpty(dateEnd))
                list = list.Where(x => x.DateEnd.ToString().StartsWith(DateTime.Parse(dateEnd).ToString()));
            if (!string.IsNullOrEmpty(isActive))
                list = list.Where(x => x.IsActive.ToString().ToLower().StartsWith(isActive.ToLower()));
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<Bonus> list, string name, string rank, string description)
        {
            if (!string.IsNullOrEmpty(name))
                list = list.Where(x => x.BonusName.ToLower().StartsWith(name.ToLower()));
            if (!string.IsNullOrEmpty(rank))
                list = list.Where(x => x.RankBonus.Any(rb => rb.Rank.RankName.ToLower().StartsWith(rank.ToLower())));
            if (!string.IsNullOrEmpty(description))
                list = list.Where(x => x.BonusDescription.ToLower().StartsWith(description.ToLower()));
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<ApplicationsInTheProject> list, string dateEntry, string participant, string vacancy, string isAccepted, string status, string statusDescription)
        {
            if (!string.IsNullOrEmpty(participant))
                list = list.Where(x => x.Participants.Individuals.FIO.ToLower().StartsWith(participant.ToLower()));
            if (!string.IsNullOrEmpty(vacancy))
                list = list.Where(x => x.Vacancy.Name.ToLower().StartsWith(vacancy.ToLower()));
            if (!string.IsNullOrEmpty(status))
                list = list.Where(x => x.Status.ToLower().StartsWith(status.ToLower()));
            if (!string.IsNullOrEmpty(statusDescription))
                list = list.Where(x => x.Status.ToLower().StartsWith(statusDescription.ToLower()));
            if (!string.IsNullOrEmpty(isAccepted))
            {
                list = list.Where(x=>x.IsAccepted.ToString().ToLower().StartsWith(isAccepted.ToLower()));
            }

            if (!string.IsNullOrEmpty(dateEntry))
                list = list.Where(x => x.DateEntry.ToString().StartsWith(DateTime.Parse(dateEntry).ToString()));
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<Position> list, string name, string description, string department)
        {
            if (!string.IsNullOrEmpty(name))
            {
                list = list.Where(x => x.FullName.ToLower().StartsWith(name.ToLower()));
            }
            if (!string.IsNullOrEmpty(description))
            {
                list = list.Where(x => x.Description.ToLower().StartsWith(description.ToLower()));
            }
            if (!string.IsNullOrEmpty(department))
            {
                list = list.Where(x => x.Department.FullName.ToLower().StartsWith(department.ToLower()));
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
                list = list.Where(x => x.Fullname.ToLower().StartsWith(name.ToLower()));
            }
            if (!string.IsNullOrEmpty(description))
            {
                list = list.Where(x => x.Description.ToLower().StartsWith(description.ToLower()));
            }
            if (!string.IsNullOrEmpty(customer))
            {
                list = list.Where(x => x.Customer.FullName.ToLower().StartsWith(customer.ToLower()));
            }
            if (!string.IsNullOrEmpty(status))
            {
                list = list.Where(x => x.Status.ToLower().StartsWith(status.ToLower()));
            }
            if (!string.IsNullOrEmpty(technicalSpecification))
            {
                list = list.Where(x => x.TechnicalSpecification.ToLower().StartsWith(technicalSpecification.ToLower()));
            }
            if (!string.IsNullOrEmpty(idLocalPM))
            {
                list = list.Where(x => x.idLocalPM.ToString().StartsWith(idLocalPM));
            }
            if (!string.IsNullOrEmpty(dateStart))
            {
                list = list.Where(x => x.DateStart.ToString().StartsWith(DateTime.Parse(dateStart).ToString()));
            }
            if (!string.IsNullOrEmpty(dateEnd))
            {
                list = list.Where(x => x.DateEnd.ToString().StartsWith(DateTime.Parse(dateEnd).ToString()));
            }

            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<Rank> list, string name, string description, string organization, string minMmr, string maxMmr)
        {
            if (!string.IsNullOrEmpty(organization))
            {
                list = list.Where(x => x.Organizations.Fullname.ToLower().StartsWith(organization.ToLower()));
            }
            if (!string.IsNullOrEmpty(description))
            {
                list = list.Where(x => x.Description.ToLower().StartsWith(description.ToLower()));
            }
            if (!string.IsNullOrEmpty(name))
            {
                list = list.Where(x => x.RankName.ToLower().StartsWith(name.ToLower()));
            }
            if (!string.IsNullOrEmpty(minMmr))
            {
                list = list.Where(x => x.MinMmr.ToString().StartsWith(minMmr));
            }
            if (!string.IsNullOrEmpty(maxMmr))
            {
                list = list.Where(x => x.MaxMmr.ToString().StartsWith(maxMmr));
            }
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<RegistrationForCourses> list, string dateEntry, string participant, string course)
        {
            if (!string.IsNullOrEmpty(participant))
            {
                list = list.Where(x => x.Participants.Individuals.FIO.ToLower().StartsWith(participant.ToLower()));
            }
            if (!string.IsNullOrEmpty(course))
            {
                list = list.Where(x => x.TrainingCourses.Name.ToLower().StartsWith(course.ToLower()));
            }
            if (!string.IsNullOrEmpty(dateEntry))
            {
                list = list.Where(x => x.DateEntry.ToString().StartsWith(DateTime.Parse(dateEntry).ToString()));
            }
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<Regulation> list, string organization, string name, string text, string description)
        {
            if (!string.IsNullOrEmpty(organization))
            {
                list = list.Where(x => x.Organization.Fullname.ToLower().StartsWith(organization.ToLower()));
            }
            if (!string.IsNullOrEmpty(description))
            {
                list = list.Where(x => x.Description.ToLower().StartsWith(description.ToLower()));
            }
            if (!string.IsNullOrEmpty(name))
            {
                list = list.Where(x => x.Name.ToLower().StartsWith(name.ToLower()));
            }
            if (!string.IsNullOrEmpty(text))
            {
                list = list.Where(x => x.Text.ToLower().StartsWith(text.ToLower()));
            }
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<ScheduleOfСlasses> list, string description, string dateStart, string dateEnd, string link, string course)
        {
            if (!string.IsNullOrEmpty(link))
            {
                list = list.Where(x => x.WorkSpaceLink.ToLower().StartsWith(link.ToLower()));
            }
            if (!string.IsNullOrEmpty(description))
            {
                list = list.Where(x => x.Description.ToLower().StartsWith(description.ToLower()));
            }
            if (!string.IsNullOrEmpty(course))
            {
                list = list.Where(x => x.TrainingCourses.Name.ToLower().StartsWith(course.ToLower()));
            }
            if (!string.IsNullOrEmpty(dateStart))
            {
                list = list.Where(x => x.DateStart.ToString().StartsWith(DateTime.Parse(dateStart).ToString()));
            }
            if (!string.IsNullOrEmpty(dateEnd))
            {
                list = list.Where(x => x.DateEnd.ToString().StartsWith(DateTime.Parse(dateEnd).ToString()));
            }
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<StagesOfProject> list, string name, string description, string dateStart, string dateEnd, string status, string project)
        {
            if (!string.IsNullOrEmpty(name))
            {
                list = list.Where(x => x.Name.ToLower().StartsWith(name.ToLower()));
            }
            if (!string.IsNullOrEmpty(description))
            {
                list = list.Where(x => x.Description.ToLower().StartsWith(description.ToLower()));
            }
            if (!string.IsNullOrEmpty(status))
            {
                list = list.Where(x => x.Status.ToLower().StartsWith(status.ToLower()));
            }
            if (!string.IsNullOrEmpty(project))
            {
                list = list.Where(x => x.Project.Fullname.ToLower().StartsWith(project.ToLower()));
            }
            if (!string.IsNullOrEmpty(dateStart))
            {
                list = list.Where(x => x.DateStart.ToString().StartsWith(DateTime.Parse(dateStart).ToString()));
            }
            if (!string.IsNullOrEmpty(dateEnd))
            {
                list = list.Where(x => x.DateEnd.ToString().StartsWith(DateTime.Parse(dateEnd).ToString()));
            }
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<Student> list, string studentCard, string group, string individual, string coursNumber, string university)
        {
            if (!string.IsNullOrEmpty(studentCard))
            {
                list = list.Where(x => x.StudentCard.ToString().StartsWith(studentCard));
            }
            if (!string.IsNullOrEmpty(group))
            {
                list = list.Where(x => x.Group.ToLower().StartsWith(group.ToLower()));
            }
            if (!string.IsNullOrEmpty(individual))
            {
                list = list.Where(x => x.Individuals.FIO.ToLower().StartsWith(individual.ToLower()));
            }
            if (!string.IsNullOrEmpty(coursNumber))
            {
                list = list.Where(x => x.CourseNumber.ToString().StartsWith(coursNumber));
            }
            if (!string.IsNullOrEmpty(university))
            {
                list = list.Where(x => x.University.ToLower().StartsWith(university.ToLower()));
            }
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }
        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<User> list, string login, string role)
        {
            if (!string.IsNullOrEmpty(login))
            {
                list = list.Where(x => x.Login.ToLower().StartsWith(login.ToLower()));
            }
            if (!string.IsNullOrEmpty(role))
            {
                list = list.Where(x => x.Role.Name.ToLower().StartsWith(role.ToLower()));
            }
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = list;
        }

        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<Vacancy> list, string name, string description, string responsibilities,
          string dateStart, string dateEnd,  string stagesOfProject, string isOpened, string budget, string ratingCoefficient)
        {
            if (!string.IsNullOrEmpty(name))
            {
                list = list.Where(x => x.Name.ToLower().StartsWith(name.ToLower()));
            }
            if (!string.IsNullOrEmpty(description))
            {
                list = list.Where(x => x.Descriptions.ToLower().StartsWith(description.ToLower()));
            }
            if (!string.IsNullOrEmpty(responsibilities))
            {
                list = list.Where(x => x.Responsibilities.ToLower().StartsWith(responsibilities.ToLower()));
            }
            if (!string.IsNullOrEmpty(stagesOfProject))
            {
                list = list.Where(x => x.StagesOfProject.Name.ToLower().StartsWith(responsibilities.ToLower()));
            }
            if (!string.IsNullOrEmpty(budget))
            {
                list = list.Where(x=>x.Budget.ToString().StartsWith(budget));
            }
            if (!string.IsNullOrEmpty(ratingCoefficient))
            {
                list = list.Where(x=>x.RatingCoefficient.ToString().StartsWith(ratingCoefficient));
            }
            if (!string.IsNullOrEmpty(isOpened))
            {
                list = list.Where(x => x.isOpened.ToString().ToLower().StartsWith(isOpened.ToLower()));
            }
            if (!string.IsNullOrEmpty(dateStart))
            {
                list = list.Where(x => x.DateStart.ToString().StartsWith(DateTime.Parse(dateStart).ToString()));
            }
            if (!string.IsNullOrEmpty(dateEnd))
            {
                list = list.Where(x => x.DateEnd.ToString().StartsWith(DateTime.Parse(dateEnd).ToString()));
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
                employments = employments.Where(x => x.Position.FullName.ToLower().StartsWith(position.ToLower()));
            }
            if (!string.IsNullOrEmpty(description))
            {
                employments = employments.Where(x => x.StatusDescription.ToLower().StartsWith(description.ToLower()));
            }
            if (!string.IsNullOrEmpty(status))
            {
                employments = employments.Where(x => x.Status.ToLower().StartsWith(status.ToLower()));
            }
            if (!string.IsNullOrEmpty(mentor))
            {
                employments = employments.Where(x => x.IdMentor.ToString().StartsWith(mentor));
            }
            if (!string.IsNullOrEmpty(dateStart))
            {
                employments = employments.Where(x => x.DateStart.ToString().StartsWith(DateTime.Parse(dateStart).ToString()));
            }
            if (!string.IsNullOrEmpty(dateEnd))
            {
                employments = employments.Where(x => x.DateEnd.ToString().StartsWith(DateTime.Parse(dateEnd).ToString()));
            }
            if (!string.IsNullOrEmpty(participant))
            {
                employments = employments.Where(x => x.Participants.Individuals.FIO.ToLower().StartsWith(participant.ToLower()));
            }
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = employments;
        }


        public static void ConfirmFilter(DataGrid dataGrid, IEnumerable<FinalProject> finalProjects, string name, string description, string gitHub,
              string link, string dateStart, string dateEnd, string employment)
        {
            if (!string.IsNullOrEmpty(name))
            {
                finalProjects = finalProjects.Where(x => x.Name.ToLower().StartsWith(name.ToLower()));
            }
            if (!string.IsNullOrEmpty(description))
            {
                finalProjects = finalProjects.Where(x => x.Description.ToLower().StartsWith(description.ToLower()));
            }
            if (!string.IsNullOrEmpty(gitHub))
            {
                finalProjects = finalProjects.Where(x => x.GitHub.ToLower().StartsWith(gitHub.ToLower()));
            }
            if (!string.IsNullOrEmpty(link))
            {
                finalProjects = finalProjects.Where(x => x.Links.ToLower().StartsWith(link.ToLower()));
            }
            if (!string.IsNullOrEmpty(dateStart))
            {
                finalProjects = finalProjects.Where(x => x.DateStart.ToString().StartsWith(DateTime.Parse(dateStart).ToString()));
            }
            if (!string.IsNullOrEmpty(dateEnd))
            {
                finalProjects = finalProjects.Where(x => x.DateEnd.ToString().StartsWith(DateTime.Parse(dateEnd).ToString()));
            }
            if (!string.IsNullOrEmpty(employment))
            {
                finalProjects = finalProjects.Where(x=>x.EmploymentId==int.Parse(employment));
            }
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            dataGrid.ItemsSource = finalProjects;
        }

    }
}

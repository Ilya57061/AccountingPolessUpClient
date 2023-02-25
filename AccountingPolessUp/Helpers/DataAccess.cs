using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using static System.Net.Mime.MediaTypeNames;

namespace AccountingPolessUp.Helpers
{
    public static class DataAccess
    {
        private static ApplicationsInTheProjectService _applicationService = new ApplicationsInTheProjectService();
        private static BonusService _bonusService = new BonusService();
        private static CustomerService _customerService = new CustomerService();
        private static TrainingCoursesService _coursesService = new TrainingCoursesService();
        private static DepartmentService _departmentService = new DepartmentService();
        private static EducationalPortalsService _educationalPortalsService = new EducationalPortalsService();
        private static FinalProjectService _finalProjectService = new FinalProjectService();
        private static IndividualsService _individualsService = new IndividualsService();
        private static ParticipantsService _participantsService = new ParticipantsService();
        private static OrganizationService _organizationService = new OrganizationService();
        private static PositionService _positionService = new PositionService();
        private static ProjectService _projectService = new ProjectService();
        private static RankService _rankService = new RankService();
        private static RegistrationForCoursesService _registrationForCoursesService = new RegistrationForCoursesService();
        private static RegulationService _regulationService = new RegulationService();
        private static ScheduleOfClassesService _scheduleService = new ScheduleOfClassesService();
        private static StagesOfProjectService _stagesOfProjectService = new StagesOfProjectService();
        private static StudentService _studentService = new StudentService();
        private static UserService _userService = new UserService();
        private static VacancyService _vacancyService = new VacancyService();
        private static EmploymentService _employmentService = new EmploymentService();

        private static void FrameValid(Page page)
        {
            if (FormValidator.AreAllElementsFilled(page))
                throw new Exception();
        }
        public static void Update(Page page, TrainingCourses cours)
        {
            FrameValid(page);
            _coursesService.Update(cours);
            DataGridUpdater.AdmCourses.UpdateDataGrid();
            CancelFrameChecker.UpdateData = true;
            MessageBox.Show("Объект отредактирован");
        }
        public static void Update(Page page, ApplicationsInTheProject applications)
        {
            FrameValid(page);
            _applicationService.Update(applications);
            DataGridUpdater.AdmAppInTheProject.UpdateDataGrid();
            CancelFrameChecker.UpdateData = true;
            MessageBox.Show("Объект отредактирован");
        }
        public static void Update(Page page, Bonus bonus)
        {
            FrameValid(page);
            _bonusService.Update(bonus);
            DataGridUpdater.AdmBonus.UpdateDataGrid();
            CancelFrameChecker.UpdateData = true;
            MessageBox.Show("Объект отредактирован");
        }
        public static void Update(Page page, Customer customer)
        {
            FrameValid(page);
            _customerService.Update(customer);
            DataGridUpdater.AdmCustomer.UpdateDataGrid();
            CancelFrameChecker.UpdateData = true;
            MessageBox.Show("Объект отредактирован");
        }
        public static void Update(Page page, Department department)
        {
            FrameValid(page);
            _departmentService.Update(department);
            DataGridUpdater.AdmDepartments.UpdateDataGrid();
            CancelFrameChecker.UpdateData = true;
            MessageBox.Show("Объект отредактирован");
        }
        public static void Update(Page page, EducationalPortals educationalPortals)
        {
            FrameValid(page);
            _educationalPortalsService.Update(educationalPortals);
            DataGridUpdater.AdmEducationalPortals.UpdateDataGrid();
            CancelFrameChecker.UpdateData = true;
            MessageBox.Show("Объект отредактирован");
        }
        public static void Update(Page page, FinalProject finalProject)
        {
            FrameValid(page);
            _finalProjectService.Update(finalProject);
            DataGridUpdater.AdmFinalProject.UpdateDataGrid();
            CancelFrameChecker.UpdateData = true;
            MessageBox.Show("Объект отредактирован");
        }
        public static void Update(Page page, Individuals individuals)
        {
            FrameValid(page);
            _individualsService.Update(individuals);
            DataGridUpdater.AdmNatural.UpdateDataGrid();
            CancelFrameChecker.UpdateData = true;
            MessageBox.Show("Объект отредактирован");
        }
        public static void Update(Page page, Participants participants)
        {
            FrameValid(page);
            _participantsService.Update(participants);
            DataGridUpdater.AdmMembers.UpdateDataGrid();
            CancelFrameChecker.UpdateData = true;
            MessageBox.Show("Объект отредактирован");
        }
        public static void Update(Page page, Organization organization)
        {
            FrameValid(page);
            _organizationService.Update(organization);
            DataGridUpdater.AdmOrganizations.UpdateDataGrid();
            CancelFrameChecker.UpdateData = true;
            MessageBox.Show("Объект отредактирован");
        }
        public static void Update(Page page, Position position)
        {
            FrameValid(page);
            _positionService.Update(position);
            DataGridUpdater.AdmPosition.UpdateDataGrid();
            CancelFrameChecker.UpdateData = true;
            MessageBox.Show("Объект отредактирован");
        }
        public static void Update(Page page, Project project)
        {
            FrameValid(page);
            _projectService.Update(project);
            DataGridUpdater.AdmProjects.UpdateDataGrid();
            CancelFrameChecker.UpdateData = true;
            MessageBox.Show("Объект добавлен");
        }
           public static void Update(Page page, Rank rank)
        {
            FrameValid(page);
            _rankService.Update(rank);
            DataGridUpdater.AdmRanks.UpdateDataGrid();
            CancelFrameChecker.UpdateData = true;
            MessageBox.Show("Объект добавлен");
        }






        public static void Create(Page page, TrainingCourses cours)
        {
            FrameValid(page);
            _coursesService.Create(cours);
            DataGridUpdater.AdmCourses.UpdateDataGrid();
            CancelFrameChecker.CreateData = true;
            MessageBox.Show("Объект добавлен");
        }
        public static void Create(Page page, ApplicationsInTheProject applications)
        {
            FrameValid(page);
            _applicationService.Create(applications);
            DataGridUpdater.AdmAppInTheProject.UpdateDataGrid();
            CancelFrameChecker.CreateData = true;
            MessageBox.Show("Объект добавлен");
        }
        public static void Create(Page page, Bonus bonus)
        {
            FrameValid(page);
            _bonusService.Create(bonus);
            DataGridUpdater.AdmBonus.UpdateDataGrid();
            CancelFrameChecker.CreateData = true;
            MessageBox.Show("Объект добавлен");
        }
        public static void Create(Page page, Customer customer)
        {
            FrameValid(page);
            _customerService.Create(customer);
            DataGridUpdater.AdmCustomer.UpdateDataGrid();
            CancelFrameChecker.CreateData = true;
            MessageBox.Show("Объект добавлен");
        }
        public static void Create(Page page, Department department)
        {
            FrameValid(page);
            _departmentService.Create(department);
            DataGridUpdater.AdmDepartments.UpdateDataGrid();
            CancelFrameChecker.CreateData = true;
            MessageBox.Show("Объект добавлен");
        }
        public static void Create(Page page, EducationalPortals educationalPortals)
        {
            FrameValid(page);
            _educationalPortalsService.Create(educationalPortals);
            DataGridUpdater.AdmEducationalPortals.UpdateDataGrid();
            CancelFrameChecker.CreateData = true;
            MessageBox.Show("Объект добавлен");
        }
        public static void Create(Page page, FinalProject finalProject)
        {
            FrameValid(page);
            _finalProjectService.Create(finalProject);
            DataGridUpdater.AdmFinalProject.UpdateDataGrid();
            CancelFrameChecker.CreateData = true;
            MessageBox.Show("Объект добавлен");
        }
        public static void Create(Page page, Individuals individuals)
        {
            FrameValid(page);
            _individualsService.Create(individuals);
            DataGridUpdater.AdmNatural.UpdateDataGrid();
            CancelFrameChecker.CreateData = true;
            MessageBox.Show("Объект добавлен");
        }
        public static void Create(Page page, Participants participants)
        {
            FrameValid(page);
            _participantsService.Create(participants);
            DataGridUpdater.AdmMembers.UpdateDataGrid();
            CancelFrameChecker.CreateData = true;
            MessageBox.Show("Объект добавлен");
        }
        public static void Create(Page page, Organization organization)
        {
            FrameValid(page);
            _organizationService.Create(organization);
            DataGridUpdater.AdmOrganizations.UpdateDataGrid();
            CancelFrameChecker.CreateData = true;
            MessageBox.Show("Объект добавлен");
        }
        public static void Create(Page page, Position position)
        {
            FrameValid(page);
            _positionService.Create(position);
            DataGridUpdater.AdmPosition.UpdateDataGrid();
            CancelFrameChecker.CreateData = true;
            MessageBox.Show("Объект добавлен");
        }
        public static void Create(Page page, Project project)
        {
            FrameValid(page);
            _projectService.Create(project);
            DataGridUpdater.AdmProjects.UpdateDataGrid();
            CancelFrameChecker.CreateData = true;
            MessageBox.Show("Объект добавлен");
        }

    }
}

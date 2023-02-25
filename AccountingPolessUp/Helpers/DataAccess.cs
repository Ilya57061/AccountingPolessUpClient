using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AccountingPolessUp.Helpers
{
    public static class DataAccess
    {
        private static RankService rankService = new RankService();
        private static ParticipantsService participantsService = new ParticipantsService();
        private static TrainingCoursesService _coursesService = new TrainingCoursesService();
        private static CustomerService customerService = new CustomerService();
        private static StagesOfProjectService stagesOfProjectService = new StagesOfProjectService();
        private static ProjectService projectService = new ProjectService();
        private static UserService userService = new UserService();
        private static DepartmentService departmentService = new DepartmentService();
        private static IndividualsService individualsService = new IndividualsService();
        private static RoleService roleService = new RoleService();
        private static OrganizationService organizationService = new OrganizationService();
        private static PositionService positionService = new PositionService();

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
        public static void Create(Page page, TrainingCourses cours)
        {
            FrameValid(page);
            _coursesService.Create(cours);
            DataGridUpdater.AdmCourses.UpdateDataGrid();
            CancelFrameChecker.CreateData = true;
        }
    }
}

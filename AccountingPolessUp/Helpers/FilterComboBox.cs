using AccountingPolessUp.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AccountingPolessUp.Helpers
{
    public static class FilterComboBox
    {
        
        static RankService rankService = new RankService();
        static ParticipantsService participantsService = new ParticipantsService();
        static TrainingCoursesService coursesService = new TrainingCoursesService();
        static CustomerService customerService = new CustomerService();
        static StagesOfProjectService stagesOfProjectService = new StagesOfProjectService();
        static ProjectService projectService = new ProjectService();
        static UserService userService = new UserService();
        static DepartmentService departmentService = new DepartmentService();
        static IndividualsService individualsService = new IndividualsService();
        static RoleService roleService = new RoleService();
        static OrganizationService organizationService = new OrganizationService();
        static PositionService positionService = new PositionService();

        static void SetBox(ComboBox box, object data)
        {
            box.ItemsSource = (System.Collections.IEnumerable)data;
        }
        public static void SetBoxRank(ComboBox box)
        {
            SetBox(box, rankService.Get());
        }
        public static void SetBoxParticipants(ComboBox box)
        {
            SetBox(box, participantsService.Get());
        }
        public static void SetBoxCourses(ComboBox box)
        {
            SetBox(box, coursesService.Get());
        }
        public static void SetBoxCustomers(ComboBox box)
        {
            SetBox(box, customerService.Get());
        }
        public static void SetBoxStagesProjects(ComboBox box)
        {
            SetBox(box, stagesOfProjectService.Get());
        }
        public static void SetBoxProjects(ComboBox box)
        {
            SetBox(box, projectService.Get());
        }
        public static void SetBoxUsers(ComboBox box)
        {
            SetBox(box,userService.Get());
        }
        public static void SetBoxDepartments(ComboBox box)
        {
            SetBox(box, departmentService.Get());
        }
        public static void SetBoxIndividuals(ComboBox box)
        {
            SetBox(box, individualsService.Get());
        }
        public static void SetBoxRole(ComboBox box)
        {
            SetBox(box, roleService.Get());
        }
        public static void SetBoxOrganizations(ComboBox box)
        {
            SetBox(box,organizationService.Get());
        }
        public static void SetBoxPositions(ComboBox box)
        {
            SetBox(box, positionService.Get());
        }
    }
}

using AccountingPolessUp.Implementations;
using System.Linq;
using System.Windows.Controls;

namespace AccountingPolessUp.Helpers
{
    public static class FilterComboBox
    {
        private static RankService rankService = new RankService();
        private static ParticipantsService participantsService = new ParticipantsService();
        private static TrainingCoursesService coursesService = new TrainingCoursesService();
        private static CustomerService customerService = new CustomerService();
        private static StagesOfProjectService stagesOfProjectService = new StagesOfProjectService();
        private static ProjectService projectService = new ProjectService();
        private static UserService userService = new UserService();
        private static DepartmentService departmentService = new DepartmentService();
        private static IndividualsService individualsService = new IndividualsService();
        private static RoleService roleService = new RoleService();
        private static OrganizationService organizationService = new OrganizationService();
        private static PositionService positionService = new PositionService();

        private static void SetBox(ComboBox box, object data)
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
            var users = userService.Get();
            if (RoleValidator.User.Role.Name != "Admin")
                users = users.Where(x => x.Role.Name == "User").ToList();
            SetBox(box, users);
        }
        public static void SetBoxDepartments(ComboBox box)
        {
            var departments = departmentService.Get();
            if (RoleValidator.User.Role.Name != "Admin")
                departments = departments.Where(x => RoleValidator.RoleChecker((int)x.DirectorId) == true).ToList();
            SetBox(box, departments);
        }
        public static void SetBoxIndividuals(ComboBox box)
        {
            SetBox(box, individualsService.Get());
        }
        public static void SetBoxRole(ComboBox box)
        {
            var roles = roleService.Get();
            if (RoleValidator.User.Role.Name != "Admin")
                roles = roles.Where(x => x.Name == "User").ToList();
            SetBox(box, roles);
        }
        public static void SetBoxOrganizations(ComboBox box)
        {
            SetBox(box, organizationService.Get());
        }
        public static void SetBoxPositions(ComboBox box)
        {
            var positions = positionService.Get();
            if (RoleValidator.User.Role.Name != "Admin")
            {
                positions = positions.Where(x => RoleValidator.RoleChecker((int)x.Department.DirectorId) == true).ToList();
            }
            SetBox(box, positions);
        }
    }
}

using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using AccountingPolessUp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AccountingPolessUp.Helpers
{
    public static class FilterMenu
    {
        private static Dictionary<Type, dynamic> _services = new Dictionary<Type, dynamic>
        {
            {typeof(ApplicationsInTheProjectFilter), new ApplicationsInTheProjectService()},
            {typeof(TrainingCoursesFilter), new TrainingCoursesService()},
            {typeof(DepartmentFilter), new DepartmentService()},
            {typeof(EducationalPortalsFilter), new EducationalPortalsService()},
            {typeof(PositionFilter), new PositionService()},
            {typeof(ProjectFilter), new ProjectService()},
            {typeof(RankFilter), new RankService()},
            {typeof(ScheduleOfСlassesFilter), new ScheduleOfClassesService()},
            {typeof(VacancyFilter), new VacancyService()},
            {typeof(EmploymentFilter), new EmploymentService()},
        };
        public static List<T> GetFiltered<T>(T obj) where T : class
        {
            var service = _services[typeof(T)];
            return service.GetFiltered(obj) as List<T>;
            //var filtered = FilterMenu.GetFiltered(objFilter) as List<objReturnType>;
        }
        public static List<T> Search<T>(T obj) where T : class
        {
            var service = _services[typeof(T)];
            return service.Search(obj) as List<T>;
        }
    }
}

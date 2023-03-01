using AccountingPolessUp.Implementations;
using AccountingPolessUp.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace AccountingPolessUp.Helpers
{
    public static class DataAccess
    {
        private static Dictionary<Type, dynamic> _services = new Dictionary<Type, dynamic>
        {
            {typeof(ApplicationsInTheProject), new ApplicationsInTheProjectService()},
            {typeof(Bonus), new BonusService()},
            {typeof(Customer), new CustomerService()},
            {typeof(TrainingCourses), new TrainingCoursesService()},
            {typeof(Department), new DepartmentService()},
            {typeof(EducationalPortals), new EducationalPortalsService()},
            {typeof(FinalProject), new FinalProjectService()},
            {typeof(Individuals), new IndividualsService()},
            {typeof(Participants), new ParticipantsService()},
            {typeof(Organization), new OrganizationService()},
            {typeof(Position), new PositionService()},
            {typeof(Project), new ProjectService()},
            {typeof(Rank), new RankService()},
            {typeof(RegistrationForCourses), new RegistrationForCoursesService()},
            {typeof(Regulation), new RegulationService()},
            {typeof(ScheduleOfСlasses), new ScheduleOfClassesService()},
            {typeof(StagesOfProject), new StagesOfProjectService()},
            {typeof(Student), new StudentService()},
            {typeof(User), new UserService()},
            {typeof(Vacancy), new VacancyService()},
            {typeof(Employment), new EmploymentService()},
        };

        private static void FrameValid(Page page)
        {
            if (FormValidator.AreAllElementsFilled(page))
                throw new Exception();
        }

        private static void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public static void Update<T>(Page page, T obj) where T : class
        {
            FrameValid(page);
            var service = _services[typeof(T)];
            service.Update(obj);
            CancelFrameChecker.UpdateData = true;
            GridUpdater(obj);
            ShowMessage("Объект отредактирован");
        }

        public static void Create<T>(Page page, T obj) where T : class
        {
            FrameValid(page);
            var service = _services[typeof(T)];
            service.Create(obj);
            CancelFrameChecker.CreateData = true;
            GridUpdater(obj);
            ShowMessage("Объект добавлен");
        }
        private static void GridUpdater<T>(T obj) where T : class
        {
            if (obj is ApplicationsInTheProject)
            {
                DataGridUpdater.AdmAppInTheProject.UpdateDataGrid();
            }
            else if (obj is Bonus)
            {
                DataGridUpdater.AdmBonus.UpdateDataGrid();
            }
            else if (obj is TrainingCourses)
            {
                DataGridUpdater.AdmCourses.UpdateDataGrid();
            }
            else if (obj is Customer)
            {
                DataGridUpdater.AdmCustomer.UpdateDataGrid();
            }
            else if (obj is Department)
            {
                DataGridUpdater.AdmDepartments.UpdateDataGrid();
            }
            else if (obj is EducationalPortals)
            {
                DataGridUpdater.AdmEducationalPortals.UpdateDataGrid();
            }
            else if (obj is FinalProject)
            {
                DataGridUpdater.AdmFinalProject.UpdateDataGrid();
            }
            else if (obj is Participants)
            {
                DataGridUpdater.AdmMembers.UpdateDataGrid();
            }
            else if (obj is Individuals)
            {
                DataGridUpdater.AdmNatural.UpdateDataGrid();
            }
            else if (obj is Organization)
            {
                DataGridUpdater.AdmOrganizations.UpdateDataGrid();
            }
            else if (obj is Position)
            {
                DataGridUpdater.AdmPosition.UpdateDataGrid();
            }
            else if (obj is Project)
            {
                DataGridUpdater.AdmProjects.UpdateDataGrid();
            }
            else if (obj is Rank)
            {
                DataGridUpdater.AdmRanks.UpdateDataGrid();
            }
            else if (obj is RegistrationForCourses)
            {
                DataGridUpdater.AdmRegistrationForCourses.UpdateDataGrid();
            }
            else if (obj is Regulation)
            {
                DataGridUpdater.AdmRules.UpdateDataGrid();
            }
            else if (obj is ScheduleOfСlasses)
            {
                DataGridUpdater.AdmScheduleOfClasses.UpdateDataGrid();
            }
            else if (obj is StagesOfProject)
            {
                DataGridUpdater.AdmStageOfProject.UpdateDataGrid();
            }
            else if (obj is Student)
            {
                DataGridUpdater.AdmStudents.UpdateDataGrid();
            }
            else if (obj is User)
            {
                DataGridUpdater.AdmUsers.UpdateDataGrid();
            }
            else if (obj is Vacancy)
            {
                DataGridUpdater.AdmVacancy.UpdateDataGrid();
            }
            else if (obj is Employment)
            {
                DataGridUpdater.AdmWork.UpdateDataGrid();
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions;
using System.Reflection;
using System.IO;
using SQLiteNetExtensions.Extensions;
using System.Collections.ObjectModel;

namespace Degree_Planner.Data
{
    public class TermDatabase
    {
        public readonly bool developerOverride = true;
        readonly SQLiteConnection _database;

        public TermDatabase(string databasePath)
        {

            _database = new SQLiteConnection(databasePath);

            //PopulateTestData();
            if (/*developerOverride ||*/ !CreateTables())
            {
                //PopulateTestData();
                EvaluationData();
            }
        }

        public ObservableCollection<Term> GetTerms()
        {
            return new ObservableCollection<Term>(_database.GetAllWithChildren<Term>(recursive: true));
        }

        public List<Course> GetCourses()
        {
            return _database.GetAllWithChildren<Course>();
        }

        public Term GetCurrentTerm(int termId)
        {
            return _database.GetWithChildren<Term>(termId, true);
        }

        public void SaveTerms(List<Term> terms)
        {
            foreach (var term in terms)
            {
                SaveTerm(term);
            }
        }

        public void SaveTerm(Term term)
        {
            if (term.ID != 0)
            {
                _database.InsertOrReplaceWithChildren(term);
            }
            else
            {
                _database.InsertWithChildren(term, true);
            }
        }

        public void SaveCourse(Course course)
        {
            if (course.ID != 0)
            {
                _database.InsertOrReplaceWithChildren(course);
            }
            else
            {
                _database.InsertWithChildren(course, true);
            }
        }

        public void DeleteAssessment(Assessment assessment)
        {
            _database.Delete(assessment);
        }

        public void DeleteNote(Note note)
        {
            _database.Delete(note);
        }

        public void DeleteCourse(Course course)
        {
            _database.Delete(course, true);
        }

        public void DeleteTerm(Term term)
        {
            _database.Delete(term, true);
        }

        public void UpdateTerm(Term term)
        {
            if (term.ID != 0)
            {
                _database.UpdateWithChildren(term);
            }
        }

        public bool CreateTables()
        {
            _database.CreateTable<Term>();
            _database.CreateTable<Course>();
            _database.CreateTable<Assessment>();
            _database.CreateTable<Note>();
            if(_database.GetAllWithChildren<Term>(recursive: true) != null)
            {
                return true;
            }
            return false;
        }

        public void ClearTables()
        {
            _database.DropTable<Term>();
            _database.DropTable<Course>();
            _database.DropTable<Assessment>();
            _database.DropTable<Note>();
        }

        public void ResetDatabase()
        {
            EvaluationData();
        }

        public void PopulateTestData()
        {
            ClearTables();
            CreateTables();

            Term term = new Term
            {
                Name = "Test Term",
                IsActive = true,
                Start = DateTime.Now,
                End = DateTime.Now.AddDays(10),
                Courses = new ObservableCollection<Course>
                {
                    new Course
                    {
                        Name = "Test Course",
                        Status = CourseStatus.PlanToTake,
                        Instructor = "Knight Steele",
                        Phone = "(801)-719-8224",
                        Email = "knightsteele94@gmail.com",
                        CreditHours = 6,
                        DisplayNotifications = true,
                        Start = DateTime.Now.AddDays(-1),
                        End = DateTime.Now,
                        Assessments = new ObservableCollection<Assessment>
                        {
                            new Assessment { Name = "Test Assessment", Type = AssessmentType.Objective, IsComplete = false, DisplayNotifications = true, Start = DateTime.Now.AddDays(-1), End = DateTime.Now},
                            new Assessment { Name = "Test Assessment 2", Type = AssessmentType.Performance, IsComplete = false, DisplayNotifications = false, Start = DateTime.Now, End = DateTime.Now.AddDays(10)}
                        },
                        Notes = new ObservableCollection<Note>
                        {
                            new Note { Name = "Test Note", Text = "This is a test note."},
                            new Note { Name = "Test Note 2", Text = "This is a test note 2."}
                        }
                    }
                }
            };
            Term term2 = new Term
            {
                Name = "Test Term 2",
                IsActive = false,
                Start = DateTime.Now,
                End = DateTime.Now.AddDays(10),
                Courses = new ObservableCollection<Course>
                {
                    new Course
                    {
                        Name = "Test Course 2",
                        Status = CourseStatus.Completed,
                        Instructor = "Knight Steele",
                        Phone = "(801)-719-8224",
                        Email = "knightsteele94@gmail.com",
                        CreditHours = 6,
                        DisplayNotifications = false,
                        Start = DateTime.Now,
                        End = DateTime.Now.AddDays(10),
                        Assessments = new ObservableCollection<Assessment>
                        {
                            new Assessment { Name = "Test Assessment", Type = AssessmentType.Objective, IsComplete = true, DisplayNotifications = false, Start = DateTime.Now, End = DateTime.Now.AddDays(10)},
                            new Assessment { Name = "Test Assessment 2", Type = AssessmentType.Performance, IsComplete = false, DisplayNotifications = false, Start = DateTime.Now, End = DateTime.Now.AddDays(10)}
                        },
                        Notes = new ObservableCollection<Note>
                        {
                            new Note { Name = "Test Note", Text = "This is a test note."},
                            new Note { Name = "Test Note 2", Text = "This is a test note 2."}
                        }
                    },
                    new Course
                    {
                        Name = "Test Course 3",
                        Status = CourseStatus.Completed,
                        Instructor = "Knight Steele",
                        Phone = "(801)-719-8224",
                        Email = "knightsteele94@gmail.com",
                        CreditHours = 6,
                        DisplayNotifications = false,
                        Start = DateTime.Now,
                        End = DateTime.Now.AddDays(10),
                        Assessments = new ObservableCollection<Assessment>
                        {
                            new Assessment { Name = "Test Assessment", Type = AssessmentType.Objective, IsComplete = false, DisplayNotifications = false, Start = DateTime.Now, End = DateTime.Now.AddDays(10)},
                            new Assessment { Name = "Test Assessment 2", Type = AssessmentType.Performance, IsComplete = false, DisplayNotifications = false, Start = DateTime.Now, End = DateTime.Now.AddDays(10)}
                        },
                        Notes = new ObservableCollection<Note>
                        {
                            new Note { Name = "Test Note", Text = "This is a test note."},
                            new Note { Name = "Test Note 2", Text = "This is a test note 2."}
                        }
                    },
                }
            };
            Term term3 = new Term
            {
                Name = "Test Term 3",
                IsActive = false,
                Start = DateTime.Now,
                End = DateTime.Now.AddDays(10),
                Courses = new ObservableCollection<Course>
                {
                    new Course
                    {
                        Name = "Test Course 3",
                        Status = CourseStatus.InProgress,
                        Instructor = "Knight Steele",
                        Phone = "(801)-719-8224",
                        Email = "knightsteele94@gmail.com",
                        CreditHours = 6,
                        DisplayNotifications = false,
                        Start = DateTime.Now,
                        End = DateTime.Now.AddDays(10),
                        Assessments = new ObservableCollection<Assessment>
                        {
                            new Assessment { Name = "Test Assessment", Type = AssessmentType.Objective, IsComplete = true, DisplayNotifications = false, Start = DateTime.Now, End = DateTime.Now.AddDays(10)},
                            new Assessment { Name = "Test Assessment 2", Type = AssessmentType.Performance, IsComplete = false, DisplayNotifications = false, Start = DateTime.Now, End = DateTime.Now.AddDays(10)}
                        },
                        Notes = new ObservableCollection<Note>
                        {
                            new Note { Name = "Test Note", Text = "This is a test note."},
                            new Note { Name = "Test Note 2", Text = "This is a test note 2."}
                        }
                    },
                    new Course
                    {
                        Name = "Test Course 3",
                        Status = CourseStatus.Dropped,
                        Instructor = "Knight Steele",
                        Phone = "(801)-719-8224",
                        Email = "knightsteele94@gmail.com",
                        CreditHours = 6,
                        DisplayNotifications = false,
                        Start = DateTime.Now,
                        End = DateTime.Now.AddDays(10),
                        Assessments = new ObservableCollection<Assessment>
                        {
                            new Assessment { Name = "Test Assessment", Type = AssessmentType.Objective, IsComplete = false, DisplayNotifications = false, Start = DateTime.Now, End = DateTime.Now.AddDays(10)}
                        },
                        Notes = new ObservableCollection<Note>
                        {
                            new Note { Name = "Test Note", Text = "This is a test note."},
                            new Note { Name = "Test Note 2", Text = "This is a test note 2."}
                        }
                    },
                }
            };
            SaveTerms(new List<Term>() { term, term2, term3 });
        }

        public void EvaluationData()
        {
            ClearTables();
            CreateTables();

            Term term = new Term()
            {
                Name = "Spring Term",
                IsActive = true,
                Start = DateTime.Now,
                End = DateTime.Now.AddDays(10),
                Courses = new ObservableCollection<Course>()
                {
                    new Course()
                    {
                        Name = "Mobile Application Development Using C# – C971",
                        Status = CourseStatus.InProgress,
                        Instructor = "Knight Steele",
                        Phone = "(801)-719-8224",
                        Email = "knightsteele94@gmail.com",
                        CreditHours = 3,
                        DisplayNotifications = true,
                        Start = DateTime.Now.AddDays(-1),
                        End = DateTime.Now,
                        Assessments = new ObservableCollection<Assessment>
                        {
                            new Assessment { Name = "C# Application 1", Type = AssessmentType.Objective, IsComplete = true, DisplayNotifications = true, Start = DateTime.Now.AddDays(-1), End = DateTime.Now},
                            new Assessment { Name = "C# Application 2", Type = AssessmentType.Performance, IsComplete = false, DisplayNotifications = true, Start = DateTime.Now, End = DateTime.Now.AddDays(10)}
                        },
                        Notes = new ObservableCollection<Note>
                        {
                            new Note { Name = "Finish C# Mobile", Text = "The term is almost over, so make sure you finish C# Mobile."}
                        }
                    }
                }
            };
            SaveTerms(new List<Term>() { term });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Degree_Planner
{
    [Table("Courses")]
    public class Course : INotifyPropertyChanged
    {
        private string name;
        private CourseStatus status;
        private string instructor;
        private string phone;
        private string email;
        private int creditHours;
        private bool displayNotifications;
        private DateTime start;
        private DateTime end;

        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(Term))]
        public int TermID { get; set; }
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Name"));
                    }
                }
            }
        }
        public CourseStatus Status
        {
            get { return status; }
            set
            {
                if (status != value)
                {
                    status = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Status"));
                    }
                }
            }
        }
        public string Instructor
        {
            get { return instructor; }
            set
            {
                if (instructor != value)
                {
                    instructor = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Instructor"));
                    }
                }
            }
        }
        public string Phone
        {
            get { return phone; }
            set
            {
                if (phone != value)
                {
                    phone = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Phone"));
                    }
                }
            }
        }
        public string Email
        {
            get { return email; }
            set
            {
                if (email != value)
                {
                    email = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Email"));
                    }
                }
            }
        }
        public int CreditHours
        {
            get { return creditHours; }
            set
            {
                if (creditHours != value)
                {
                    creditHours = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("CreditHours"));
                    }
                }
            }
        }

        public bool DisplayNotifications
        {
            get { return displayNotifications; }
            set
            {
                if (displayNotifications != value)
                {
                    displayNotifications = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("DisplayNotifications"));
                    }
                }
            }
        }
        public DateTime Start
        {
            get { return start; }
            set
            {
                if (start != value)
                {
                    start = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Start"));
                    }
                }
            }
        }
        public DateTime End
        {
            get { return end; }
            set
            {
                if (end != value)
                {
                    end = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("End"));
                    }
                }
            }
        }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public ObservableCollection<Assessment> Assessments { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public ObservableCollection<Note> Notes { get; set; }
        public string Date => Start.ToString("MMM dd") + " - " + End.ToString("MMM dd");

        public Course() { }

        //public Course(string name, CourseStatus status, string instructor, string phone, string email, int creditHours, DateTime startTime, DateTime endTime, List<Assessment> assessments, List<Note> notes)
        //{
        //    Name = name;
        //    Status = status;
        //    Instructor = instructor;
        //    Phone = phone;
        //    Email = email;
        //    CreditHours = creditHours;
        //    Start = startTime;
        //    End = endTime;
        //    Assessments = assessments;
        //    Notes = notes;
        //}
    }

    public enum CourseStatus
    {
        InProgress,
        Completed,
        PlanToTake,
        Dropped
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Degree_Planner
{
    [Table("Terms")]
    public class Term : INotifyPropertyChanged
    {
        private string name;
        private bool isActive;
        private DateTime start;
        private DateTime end;

        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
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
        public bool IsActive
        {
            get { return isActive; }
            set
            {
                if (isActive != value)
                {
                    isActive = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("IsActive"));
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
        public string Date => Start.ToString("MMM dd") + " - " + End.ToString("MMM dd");
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public ObservableCollection<Course> Courses { get; set; }

        public Term() { }
        //public Term(string name, bool isActive, DateTime startTime, DateTime endTime, List<Course> courses)
        //{
        //    Name = name;
        //    IsActive = isActive;
        //    Start = startTime;
        //    End = endTime;
        //    Courses = courses;
        //}
    }
}

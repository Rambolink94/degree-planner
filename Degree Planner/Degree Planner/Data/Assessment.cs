using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Degree_Planner
{
    [Table("Assessments")]
    public class Assessment : INotifyPropertyChanged
    {
        private string name;
        private AssessmentType assessmentType;
        private bool isComplete;
        private bool displayNotifications;
        private DateTime start;
        private DateTime end;

        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(Course))]
        public int CourseID { get; set; }
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
        public AssessmentType Type
        {
            get { return assessmentType; }
            set
            {
                if (assessmentType != value)
                {
                    assessmentType = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Type"));
                    }
                }
            }
        }
        public bool IsComplete
        {
            get { return isComplete; }
            set
            {
                if (isComplete != value)
                {
                    isComplete = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("IsComplete"));
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
        //public string BackgroundColor
        //{
        //    get { return IsComplete ? "#558f45" : "Gray"; }
        //    set { BackgroundColor = value; }
        //}
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
        public string TypeLetter => Type.ToString().Substring(0, 1).ToUpper();

        public Assessment() { }
        //public Assessment(string name, AssessmentType type, bool isComplete, DateTime startTime, DateTime endTime)
        //{
        //    Name = name;
        //    Type = type;
        //    IsComplete = isComplete;
        //    Start = startTime;
        //    End = endTime;
        //}
    }

    public enum AssessmentType
    {
        Objective,
        Performance
    }
}

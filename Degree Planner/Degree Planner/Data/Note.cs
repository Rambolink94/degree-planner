using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Degree_Planner
{
    [Table("Notes")]
    public class Note : INotifyPropertyChanged
    {
        private string name;
        private string text;

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
        public string Text
        {
            get { return text; }
            set
            {
                if(text != value)
                {
                    text = value;

                    if(PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Text"));
                    }
                }
            }
        }

        public Note() { }
        //public Note(string name, string note)
        //{
        //    Name = name;
        //    Text = note;
        //}
    }
}

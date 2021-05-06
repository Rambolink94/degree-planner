using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Degree_Planner
{
    public class TermGroup : ObservableCollection<Course>
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Date => Start.ToString("MMM dd") + " - " + End.ToString("MMM dd");
        public ObservableCollection<Course> Courses { get; set; }
        public ICommand EditTerm { get; private set; }

        public TermGroup(Term term) : base(term.Courses)
        {
            Name = term.Name;
            IsActive = term.IsActive;
            Start = term.Start;
            End = term.End;
            Courses = term.Courses;
            EditTerm = new Command(() =>
            {
                // Gets the currently selected term. Can be bound to.
                Pages.MainPage.CurrentTerm = term;
            });
        }

        public static ObservableCollection<TermGroup> ConvertToTermGroups(ObservableCollection<Term> terms)
        {
            ObservableCollection<TermGroup> groups = new ObservableCollection<TermGroup>();
            foreach (var term in terms)
            {
                groups.Add(ConvertToTermGroup(term));
            }
            return groups;
        }

        public static TermGroup ConvertToTermGroup(Term term)
        {
            return new TermGroup(term);

        }
    }
}

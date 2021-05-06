using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Degree_Planner.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoursePage : ContentPage
    {
        public bool IsUpdate { get; set; } = false;
        public Term CurrentTerm { get; set; }
        public Course CurrentCourse { get; set; }

        Dictionary<CourseStatus, string> courseStatuses = new Dictionary<CourseStatus, string>
        {
            { CourseStatus.InProgress, "In Progress" },
            { CourseStatus.Completed, "Completed" },
            { CourseStatus.PlanToTake, "Plan To Take" },
            { CourseStatus.Dropped, "Dropped" }
        };

        public CoursePage(Course course = null, Term term = null)
        {
            InitializeComponent();

            startDate.Date = DateTime.Now;
            endDate.Date = DateTime.Now.AddDays(10);

            CurrentTerm = term;

            if (course != null)
            {
                CurrentCourse = course;
                IsUpdate = true;
                DeleteButton.Text = "Delete";
                DeleteButton2.Text = DeleteButton.Text;
            }
            else
            {
                CurrentCourse = new Course() { Name = "", Status= CourseStatus.PlanToTake, CreditHours=0, Instructor = "", Email = "", Phone = "",
                    Start = DateTime.Now, End = DateTime.Now.AddDays(10),
                    Assessments = new ObservableCollection<Assessment> { },
                    Notes = new ObservableCollection<Note> { }
                };
                IsUpdate = false;
                DeleteButton.Text = "Cancel";
                DeleteButton2.Text = DeleteButton.Text;
            }

            foreach (var type in courseStatuses.Keys)
            {
                courseStatus.Items.Add(courseStatuses[type]);
            }
            courseStatus.SelectedItem = courseStatuses[CurrentCourse.Status];

            BindingContext = this;
        }

        protected override bool OnBackButtonPressed() => true;

        protected override void OnAppearing()
        {
            base.OnAppearing();

            assessmentsCollectionView.ItemsSource = CurrentCourse.Assessments;
            notesCollectionView.ItemsSource = CurrentCourse.Notes;
        }

        //private void StartDateSelected(object sender, EventArgs args)
        //{
        //    endDate.MinimumDate = startDate.Date;
        //}

        //private void EndDateSelected(object sender, EventArgs args)
        //{
        //    startDate.MaximumDate = endDate.Date;
        //}

        async private void NewAssessmentTapped(object sender, EventArgs args)
        {
            if (CurrentCourse.Assessments.Count >= 2)
            {
                await DisplayAlert("Max Assessments", "Each course can have a MAX of 2 Assessments.", "OK");
            }
            else
            {
                await Navigation.PushModalAsync(new AssessmentPage());
                MessagingCenter.Subscribe<Assessment>(this, "Save Assessment", (value) =>
                {
                    if (!CurrentCourse.Assessments.Contains(value))
                    {
                        CurrentCourse.Assessments.Add(value);
                    }
                });
                MessagingCenter.Subscribe<Assessment>(this, "Cancel Assessment", (value) => { });
            }
        }

        async private void NewNoteTapped(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new NotePage());
            MessagingCenter.Subscribe<Note>(this, "Save Note", (value) =>
            {
                if (!CurrentCourse.Notes.Contains(value))
                {
                    CurrentCourse.Notes.Add(value);
                }
            });
            MessagingCenter.Subscribe<Note>(this, "Cancel Note", (value) => { });
        }

        private void AssessmentSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Allows selecting same option again.
            if (assessmentsCollectionView.SelectedItem != null)
            {
                UpdateAssessmentData(e.PreviousSelection, e.CurrentSelection);
                assessmentsCollectionView.SelectedItem = null;
            }
        }

        async void UpdateAssessmentData(IEnumerable<object> previousSelectedAssessment, IEnumerable<object> currentSelectedAssessment)
        {
            var selectedAssessment = currentSelectedAssessment.FirstOrDefault() as Assessment;

            await Navigation.PushModalAsync(new AssessmentPage(selectedAssessment));
            MessagingCenter.Subscribe<Assessment>(this, "Update Assessment", (value) =>
            {
                int assessmentIndex = CurrentCourse.Assessments.IndexOf(selectedAssessment);
                int id = CurrentCourse.Assessments[assessmentIndex].ID;
                int courseId = CurrentCourse.Assessments[assessmentIndex].CourseID;
                CurrentCourse.Assessments[assessmentIndex] = value;
                CurrentCourse.Assessments[assessmentIndex].ID = id;
                CurrentCourse.Assessments[assessmentIndex].CourseID = courseId;
            });
            MessagingCenter.Subscribe<Assessment>(this, "Delete Assessment", (value) =>
            {
                CurrentCourse.Assessments.Remove(value);
                App.Database.DeleteAssessment(value);
            });
        }

        private void NoteSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Allows selecting same option again.
            if (notesCollectionView.SelectedItem != null)
            {
                UpdateNoteData(e.PreviousSelection, e.CurrentSelection);
                notesCollectionView.SelectedItem = null;
            }
        }

        async void UpdateNoteData(IEnumerable<object> previousSelectedNote, IEnumerable<object> currentSelectedNote)
        {
            var selectedNote = currentSelectedNote.FirstOrDefault() as Note;

            await Navigation.PushModalAsync(new NotePage(selectedNote));
            MessagingCenter.Subscribe<Note>(this, "Update Note", (value) =>
            {
                int noteIndex = CurrentCourse.Notes.IndexOf(selectedNote);
                CurrentCourse.Notes[noteIndex].Name = value.Name;
                CurrentCourse.Notes[noteIndex].Text = value.Text;
            });
            MessagingCenter.Subscribe<Note>(this, "Delete Note", (value) =>
            {
                CurrentCourse.Notes.Remove(value);
                App.Database.DeleteNote(value);
            });
        }

        private async void SaveButtonClicked(object sender, EventArgs args)
        {
            CurrentCourse.Status = courseStatuses.FirstOrDefault(i => i.Value == courseStatus.SelectedItem.ToString()).Key;

            if (IsValid())
            {
                if (IsUpdate)
                {
                    if (CurrentTerm != null)
                    {
                        Course position = CurrentTerm.Courses.Where(i => i.ID == CurrentCourse.ID).FirstOrDefault();
                        int index = CurrentTerm.Courses.IndexOf(position);
                        CurrentTerm.Courses[index] = CurrentCourse;

                        App.Database.SaveCourse(CurrentCourse);
                        App.Database.SaveTerm(CurrentTerm);
                    }
                    else
                    {
                        MessagingCenter.Send<Course>(CurrentCourse, "Update Course");
                    }
                }
                else
                {
                    if (CurrentTerm != null)
                    {
                        CurrentTerm.Courses.Add(CurrentCourse);

                        App.Database.SaveCourse(CurrentCourse);
                        App.Database.SaveTerm(CurrentTerm);
                    }
                    else
                    {
                        MessagingCenter.Send<Course>(CurrentCourse, "Save Course");
                    }
                }

                await Navigation.PopModalAsync();
            }
        }

        private async void DeleteButtonClicked(object sender, EventArgs args)
        {
            bool okayDelete = await DisplayAlert("Delete Course", $"Are you sure you want to delete course {CurrentCourse.Name}?", "Yes", "No");
            if (okayDelete)
            {
                if (IsUpdate)
                {
                    if (CurrentTerm != null)
                    {
                        Course position = CurrentTerm.Courses.Where(i => i.ID == CurrentCourse.ID).FirstOrDefault();
                        int index = CurrentTerm.Courses.IndexOf(position);
                        CurrentTerm.Courses.RemoveAt(index);

                        App.Database.DeleteCourse(CurrentCourse);
                        App.Database.SaveTerm(CurrentTerm);
                    }
                    else
                    {
                        MessagingCenter.Send<Course>(CurrentCourse, "Delete Course");
                    }
                }

                await Navigation.PopModalAsync();
            }
        }

        private bool IsValid()
        {
            if (courseName.Text == "")
            {
                DisplayAlert("No Name", "Courses must have a name.", "OK");
                return false;
            }
            else if (creditHours.Text == "")
            {
                DisplayAlert("No Credit Hours", "Credit Hours cannot be empty.", "OK");
                return false;
            }
            else if (startDate.Date > endDate.Date)
            {
                DisplayAlert("Incorrect Dates", "Start Date is after End Date.", "OK");
                return false;
            }
            else if (instructorName.Text == "")
            {
                DisplayAlert("No Instrutor Name", "Instructor name cannot be empty.", "OK");
                return false;
            }
            else if (phoneNumber.Text == "")
            {
                DisplayAlert("No Phone Number", "Instructor Phone # cannot be empty.", "OK");
                return false;
            }
            else if (emailAddress.Text == "")
            {
                DisplayAlert("No Email Address", "Instructor Email Address cannot be empty.", "OK");
                return false;
            }
            else if (CurrentCourse.Assessments.Count <= 0)
            {
                DisplayAlert("No Assessments", "Each course must have at least one assessment.", "OK");
                return false;
            }

            if (creditHours.Text != "")
            {
                int hours;
                try
                {
                    hours = int.Parse(creditHours.Text);
                }
                catch (FormatException)
                {
                    DisplayAlert("Invalid Credit Hours", "Credit Hours must be a number.", "OK");
                    return false;
                }

                if (hours <= 0)
                {
                    DisplayAlert("Incorrect Credit Hours", "Credit Hours must be greater than 0.", "OK");
                    return false;
                }
            }
            return true;
        }

        private void startDate_DateSelected(object sender, DateChangedEventArgs e)
        {
            endDate.MinimumDate = startDate.Date.AddDays(1);
        }

        private void endDate_DateSelected(object sender, DateChangedEventArgs e)
        {
            startDate.MaximumDate = endDate.Date.AddDays(-1);
        }
    }
}
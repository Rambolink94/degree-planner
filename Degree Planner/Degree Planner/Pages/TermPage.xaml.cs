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
    public partial class TermPage : ContentPage
    {
        public Term CurrentTerm { get; set; }
        public bool IsUpdate { get; set; }

        public TermPage(Term term = null)
        {
            InitializeComponent();

            if (term != null)
            {
                CurrentTerm = term;
                IsUpdate = true;
                DeleteButton.Text = "Delete";
                DeleteButton2.Text = DeleteButton.Text;
            }
            else
            {
                CurrentTerm = new Term()
                { Name = "New Term", IsActive = false, Start = DateTime.Now, End = DateTime.Now.AddDays(10),
                Courses = new ObservableCollection<Course>() { }
                };
                IsUpdate = false;
                DeleteButton.Text = "Cancel";
                DeleteButton2.Text = DeleteButton.Text;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (CurrentTerm != null)
            {
                coursesCollectionView.ItemsSource = CurrentTerm.Courses;
            }

            BindingContext = this;
        }

        protected override bool OnBackButtonPressed() => true;

        async private void NewCourseTapped(object sender, EventArgs args)
        {
            if (CurrentTerm.Courses.Count >= 6)
            {
                await DisplayAlert("Max Courses", "Each Term can have a MAX of 6 Courses.", "OK");
            }
            else
            {
                await Navigation.PushModalAsync(new CoursePage());
                MessagingCenter.Subscribe<Course>(this, "Save Course", (value) =>
                {
                    if (!CurrentTerm.Courses.Contains(value))
                    {
                        CurrentTerm.Courses.Add(value);
                    }
                });
            }
        }

        private void CourseSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Allows selecting same option again.
            if (coursesCollectionView.SelectedItem != null)
            {
                UpdateSelectionData(e.PreviousSelection, e.CurrentSelection);
                coursesCollectionView.SelectedItem = null;
            }
        }

        async void UpdateSelectionData(IEnumerable<object> previousSelectedContact, IEnumerable<object> currentSelectedCourse)
        {
            var selectedCourse = currentSelectedCourse.FirstOrDefault() as Course;

            await Navigation.PushModalAsync(new CoursePage(selectedCourse));
            MessagingCenter.Subscribe<Course>(this, "Update Course", (value) =>
            {
                int courseIndex = CurrentTerm.Courses.IndexOf(selectedCourse);
                int id = CurrentTerm.Courses[courseIndex].ID;
                int termId = CurrentTerm.Courses[courseIndex].TermID;
                CurrentTerm.Courses[courseIndex] = value;
                CurrentTerm.Courses[courseIndex].ID = id;
                CurrentTerm.Courses[courseIndex].TermID = termId;
                //CurrentTerm.Courses[courseIndex].Name = value.Name;
                //CurrentTerm.Courses[courseIndex].Instructor = value.Instructor;
                //CurrentTerm.Courses[courseIndex].Phone = value.Phone;
                //CurrentTerm.Courses[courseIndex].Email = value.Email;
                //CurrentTerm.Courses[courseIndex].Start = value.Start;
            });
            MessagingCenter.Subscribe<Course>(this, "Delete Course", (value) =>
            {
                CurrentTerm.Courses.Remove(value);

                App.Database.DeleteCourse(value);
                App.Database.SaveTerm(CurrentTerm);
            });
        }

        private async void SaveButtonClicked(object sender, EventArgs args)
        {
            if (IsValid())
            {
                App.Database.SaveTerm(CurrentTerm);

                await Navigation.PopModalAsync();
            }
        }

        private async void DeleteButtonClicked(object sender, EventArgs args)
        {
            bool okayDelete = await DisplayAlert("Delete Term", $"Are you sure you want to delete term {CurrentTerm.Name}?", "Yes", "No");
            if (okayDelete)
            {
                App.Database.DeleteTerm(CurrentTerm);

                await Navigation.PopModalAsync();
            }
        }

        private bool IsValid()
        {
            if(CurrentTerm.Courses.Count <= 0)
            {
                DisplayAlert("No Courses", "A term must have at least 1 course before it can be saved.", "OK");
                return false;
            }
            else if(termName.Text == "")
            {
                DisplayAlert("No Name", "A term must have a name.", "OK");
                return false;
            }
            else if(startDate.Date > endDate.Date)
            {
                DisplayAlert("Incorrect Dates", "Start Date is after End Date.", "OK");
                return false;
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
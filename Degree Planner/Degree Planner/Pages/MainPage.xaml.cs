using Plugin.LocalNotifications;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Degree_Planner.Pages
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<TermGroup> TermGroups { get; set; }
        public static Term CurrentTerm { get; set; }

        public ObservableCollection<Term> AllTerms { get; set; }

        public ICommand RefreshCommand { get; }

        bool isRefreshing;
        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set
            {
                isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        public MainPage()
        {
            InitializeComponent();

            RefreshCommand = new Command(ExecuteRefreshCommand);

            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if(!App.Database.developerOverride)
            {
                appTitle.FontSize = 30;
            }
            resetButton.IsVisible = App.Database.developerOverride;

            AllTerms = App.Database.GetTerms();
            TermGroups = new ObservableCollection<TermGroup>(TermGroup.ConvertToTermGroups(AllTerms));
            coursesCollectionView.ItemsSource = TermGroups;
            CheckNotifications();
        }

        private void CheckNotifications()
        {
            if (!App.shownNotifications)
            {
                App.shownNotifications = true;
                foreach (var term in AllTerms)
                {
                    foreach (var course in term.Courses)
                    {
                        //Check if notifications are on and course is due
                        if (course.Status != CourseStatus.Completed && course.DisplayNotifications && course.End.Date == DateTime.Now.Date)
                        {
                            CrossLocalNotifications.Current.Show("Course Due", $"{course.Name} is due today.", 0);
                        }

                        if (course.Status != CourseStatus.Completed && course.DisplayNotifications && course.Start.Date == DateTime.Now.Date)
                        {
                            CrossLocalNotifications.Current.Show("Course Start", $"{course.Name} starts today.", 0);
                        }

                        foreach (var assessment in course.Assessments)
                        {
                            //Check if notifications are on and assessment is due
                            if (!assessment.IsComplete && assessment.DisplayNotifications && assessment.End.Date == DateTime.Now.Date)
                            {
                                CrossLocalNotifications.Current.Show("Assessment Due", $"{assessment.Name} is due today.", 1);
                            }

                            if (!assessment.IsComplete && assessment.DisplayNotifications && assessment.Start.Date == DateTime.Now.Date)
                            {
                                CrossLocalNotifications.Current.Show("Assessment Starts", $"{assessment.Name} starts today.", 1);
                            }
                        }
                    }
                }
            }
        }

        async private void AddTermClicked(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new TermPage());

            ExecuteRefreshCommand();
        }

        async private void NewCourseTapped(object sender, EventArgs args)
        {
            if (CurrentTerm.Courses.Count >= 6)
            {
                await DisplayAlert("Max Courses", "Each Term can have a MAX of 6 Courses.", "OK");
            }
            else
            {
                await Navigation.PushModalAsync(new CoursePage(term: CurrentTerm));

                ExecuteRefreshCommand();
            }
        }

        async public void EditTermTapped(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new TermPage(CurrentTerm));

            ExecuteRefreshCommand();
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

        async void UpdateSelectionData(IEnumerable<object> previousSelectedContact, IEnumerable<object> currentSelectedContact)
         {
            var selectedContact = currentSelectedContact.FirstOrDefault() as Course;

            CurrentTerm = App.Database.GetCurrentTerm(selectedContact.TermID);

            await Navigation.PushModalAsync(new CoursePage(selectedContact, CurrentTerm));

            ExecuteRefreshCommand();
        }

        void ExecuteRefreshCommand()
        {
            if (IsRefreshing)
                return;

            IsRefreshing = true;

            //Refreshes items
            AllTerms.Clear();
            TermGroups.Clear();

            AllTerms = App.Database.GetTerms();
            TermGroups = new ObservableCollection<TermGroup>(TermGroup.ConvertToTermGroups(AllTerms));

            coursesCollectionView.ItemsSource = TermGroups;

            // Stop refreshing
            IsRefreshing = false;
        }

        private async void ResetDatabase_Clicked(object sender, EventArgs e)
        {
            bool okayDelete = await DisplayAlert("Reset Database", $"Are you sure you want to reset the Database?", "Yes", "No");
            if (okayDelete)
            {
                App.Database.ResetDatabase();
                App.shownNotifications = false;
                ExecuteRefreshCommand();
                CheckNotifications();
            }
        }
    }
}

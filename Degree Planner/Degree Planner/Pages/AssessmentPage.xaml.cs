using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Degree_Planner.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AssessmentPage : ContentPage
    {
        public Assessment CurrentAssessment { get; set; }
        public bool IsUpdate { get; set; }

        Dictionary<AssessmentType, string> assessmentTypes = new Dictionary<AssessmentType, string>
        {
            { AssessmentType.Objective, "Objective" },
            { AssessmentType.Performance, "Performance" }
        };

        public AssessmentPage(Assessment assessment = null)
        {
            InitializeComponent();

            if (assessment != null)
            {
                CurrentAssessment = assessment;
                IsUpdate = true;
                DeleteButton.Text = "Delete";
                DeleteButton2.Text = DeleteButton.Text;
            }
            else
            {
                CurrentAssessment = new Assessment { Name="", IsComplete=false, Type=AssessmentType.Objective, Start=DateTime.Now, End=DateTime.Now.AddDays(10) };
                IsUpdate = false;
                DeleteButton.Text = "Cancel";
                DeleteButton2.Text = DeleteButton.Text;
            }

            foreach (var type in assessmentTypes.Keys)
            {
                assessmentType.Items.Add(assessmentTypes[type]);
            }
            assessmentType.SelectedItem = assessmentTypes[CurrentAssessment.Type];
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (CurrentAssessment != null)
            {
                BindingContext = CurrentAssessment;
            }
        }

        protected override bool OnBackButtonPressed() => true;

        private async void SaveButtonClicked(object sender, EventArgs args)
        {
            CurrentAssessment.Type = assessmentTypes.FirstOrDefault(i => i.Value == assessmentType.SelectedItem.ToString()).Key;

            if (IsValid())
            {
                if (IsUpdate)
                {
                    MessagingCenter.Send<Assessment>(CurrentAssessment, "Update Assessment");
                }
                else
                {
                    MessagingCenter.Send<Assessment>(CurrentAssessment, "Save Assessment");
                }

                await Navigation.PopModalAsync();
            }
        }

        private async void DeleteButtonClicked(object sender, EventArgs args)
        {
            bool okayDelete = await DisplayAlert("Delete Assessment", $"Are you sure you want to delete assessment {CurrentAssessment.Name}?", "Yes", "No");
            if (okayDelete)
            {
                if (IsUpdate)
                {
                    MessagingCenter.Send<Assessment>(CurrentAssessment, "Delete Assessment");
                }
                else
                {
                    MessagingCenter.Send<Assessment>(CurrentAssessment, "Cancel Assessment");
                }

                await Navigation.PopModalAsync();
            }
        }

        private bool IsValid()
        {
            if (assessmentName.Text == "")
            {
                DisplayAlert("No Name", "Assessments must have a name.", "OK");
                return false;
            }
            else if (startDate.Date > endDate.Date)
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
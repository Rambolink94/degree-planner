using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace Degree_Planner.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotePage : ContentPage
    {
        public Note CurrentNote { get; set; }
        private bool IsUpdate { get; set; }
        public NotePage(Note note = null)
        {
            InitializeComponent();

            if(note != null)
            {
                CurrentNote = note;
                IsUpdate = true;
                DeleteButton.Text = "Delete";
            }
            else
            {
                CurrentNote = new Note() { Name="New Note", Text="" };
                IsUpdate = false;
                DeleteButton.Text = "Cancel";
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (CurrentNote != null)
            {
                BindingContext = CurrentNote;
            }
        }

        protected override bool OnBackButtonPressed() => true;

        private async void SaveButtonClicked(object sender, EventArgs args)
        {
            if (IsValid())
            {
                if (IsUpdate)
                {
                    MessagingCenter.Send<Note>(CurrentNote, "Update Note");
                }
                else
                {
                    MessagingCenter.Send<Note>(CurrentNote, "Save Note");
                }

                await Navigation.PopModalAsync();
            }
        }

        private async void DeleteButtonClicked(object sender, EventArgs args)
        {
            bool okayDelete = await DisplayAlert("Delete Note", $"Are you sure you want to delete note {CurrentNote.Name}?", "Yes", "No");
            if (okayDelete)
            {
                if (IsUpdate)
                {
                    MessagingCenter.Send<Note>(CurrentNote, "Delete Note");
                }
                else
                {
                    MessagingCenter.Send<Note>(CurrentNote, "Cancel Note");
                }

                await Navigation.PopModalAsync();
            }
        }

        private async void ShareButtonClicked(object sender, EventArgs e)
        {
            if (noteName.Text == "" || noteText.Text == "")
            {
                await DisplayAlert("Missing Data", "A note must have a name and note text in order to be shared.", "OK");
            }
            else
            {
                try
                {
                    await Sms.ComposeAsync(new SmsMessage
                        ($"A note was shared with you from Degree Planner.\n\n--{noteName.Text}--\n{noteText.Text}", ""));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private bool IsValid()
        {
            if (noteName.Text == "")
            {
                DisplayAlert("No Name", "Notes must have a name.", "OK");
                return false;
            }
            else if (noteText.Text == "")
            {
                DisplayAlert("No Text", "Notes must have note text.", "OK");
                return false;
            }
            return true;
        }
    }
}
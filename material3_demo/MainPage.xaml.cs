namespace material3_demo;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

		FrameworkPicker.ItemsSource = new[]
		{
			".NET 11 Preview 7",
			".NET 10",
			".NET 9"
		};
		FrameworkPicker.SelectedIndex = 0;
		ReleaseDatePicker.Date = DateTime.Today;
	}

	private void OnSearchTextChanged(object? sender, TextChangedEventArgs e)
	{
		SearchStatusLabel.Text = string.IsNullOrWhiteSpace(e.NewTextValue)
			? "Type in the SearchBar to see its clear action."
			: $"Searching for \"{e.NewTextValue}\"";
	}

	private void OnNotificationToggled(object? sender, ToggledEventArgs e)
	{
		NotificationStatusLabel.Text = e.Value
			? "Notifications are enabled."
			: "Notifications are disabled.";
	}

	private void OnVolumeChanged(object? sender, ValueChangedEventArgs e)
	{
		VolumeLabel.Text = $"{e.NewValue:F0}%";
	}

	private void OnActionButtonClicked(object? sender, EventArgs e)
	{
		var name = string.IsNullOrWhiteSpace(NameEntry.Text) ? "Profile" : NameEntry.Text.Trim();
		ActionStatusLabel.Text = $"{name} saved with Material 3.";
	}

	private async void OnImageButtonClicked(object? sender, EventArgs e)
	{
		await DisplayAlertAsync(
			"Material 3 ImageButton",
			"The Android platform view uses Material 3 shape and ripple behavior.",
			"OK");
	}
}

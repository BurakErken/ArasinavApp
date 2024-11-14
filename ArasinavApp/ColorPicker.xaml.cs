namespace ArasinavApp;

public partial class ColorPicker : ContentPage
{
    public ColorPicker()
    {
        InitializeComponent();
        UpdateColor();
    }

    private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
    {
        UpdateColor();
    }

    private void UpdateColor()
    {

        int red = (int)RedSlider.Value;
        int green = (int)GreenSlider.Value;
        int blue = (int)BlueSlider.Value;

        RedSliderValue.Text = "( " + red.ToString() + " )";
        GreenSliderValue.Text = "( " + green.ToString() + " )";
        BlueSliderValue.Text = "( " + blue.ToString() + " )";


        Color color = Color.FromRgb(red, green, blue);
        ColorPreview.BackgroundColor = color;
        HexLabel.Text = $"#{red:X2}{green:X2}{blue:X2}";
    }

    private void OnRandomButtonClicked(object sender, EventArgs e)
    {
        Random rand = new Random();
        int randomValue1 = rand.Next(0, 256);
        int randomValue2 = rand.Next(0, 256);
        int randomValue3 = rand.Next(0, 256);

        RedSlider.Value = randomValue1;
        GreenSlider.Value = randomValue2;
        BlueSlider.Value = randomValue3;

        RedSliderValue.Text = "( " + ((int)RedSlider.Value).ToString() + " )";
        GreenSliderValue.Text = "( " + ((int)GreenSlider.Value).ToString() + " )";
        BlueSliderValue.Text = "( " + ((int)BlueSlider.Value).ToString() + " )";

    }

    private async void OnButtonCopy(object sender, EventArgs e)
    {

        if (sender is Button button)
        {
            string buttonText = button.Text;
            await Clipboard.Default.SetTextAsync(buttonText);
            await DisplayAlert("Kopyalama", "Buton metni kopyalandý: " + buttonText, "Tamam");
        }


    }
}
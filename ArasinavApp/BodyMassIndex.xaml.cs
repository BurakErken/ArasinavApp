using Microsoft.Maui.Controls;

namespace ArasinavApp;

public partial class BodyMassIndex : ContentPage
{
    public BodyMassIndex()
    {
        InitializeComponent();
    }
    double height;
    double weight;
    private const double MaxBMI = 40.0;
    private void OnCalculateButtonClicked(object sender, EventArgs e)
    {
        height = Convert.ToDouble(HeightEntry.Text) / 100.0;
        weight = Convert.ToDouble(WeightEntry.Text);
        CalculateBMI(weight, height);
        frame1.IsVisible = true;
    }

    private void CalculateBMI(double weight, double height)
    {

        double bmi = weight / (height * height);
        BMIResultLabel.Text = $"BMI: {bmi:F2}";
       
        double progress = bmi / 40;  
        BMIProgressBar.Progress = Math.Clamp(progress, 0, 1);

        if (female.IsChecked)
        {
            if (bmi < 16)
            {
                BMIProgressBar.ProgressColor = Colors.LightBlue;
                BodyText.Text = "Ýleri derecede zayýf";
                ImageMass.Source = "woman1.png";
            }
            else if (16 <= bmi && bmi < 17)
            {
                BMIProgressBar.ProgressColor = Colors.Blue;
                BodyText.Text = "Orta derecede zayýf";
                ImageMass.Source = "woman1.png";
            }
            else if (17 <= bmi && bmi < 18.5)
            {
                BMIProgressBar.ProgressColor = Colors.DarkBlue;
                BodyText.Text = "Hafif derecede zayýf";
                ImageMass.Source = "woman1.png";
            }
            else if (bmi >= 18.5 && bmi < 25)
            {
                BMIProgressBar.ProgressColor = Colors.Green;
                BodyText.Text = "Normal Kilolu";
                ImageMass.Source = "woman2.png";
            }
            else if (bmi >= 25 && bmi < 30)
            {
                BMIProgressBar.ProgressColor = Colors.Yellow;
                BodyText.Text = "Hafif þiþman";
                ImageMass.Source = "woman3.png";
            }
            else if (bmi >= 30 && bmi < 35)
            {
                BMIProgressBar.ProgressColor = Colors.Orange;
                BodyText.Text = "1.derece obez";
                ImageMass.Source = "woman3.png";
            }
            else if (bmi >= 35 && bmi < 40)
            {
                BMIProgressBar.ProgressColor = Colors.Red;
                BodyText.Text = "2.derece obez";
                ImageMass.Source = "woman4.png";
            }
            else
            {
                BMIProgressBar.ProgressColor = Colors.DarkRed;
                BodyText.Text = "3.derece obez (Morbid obez)";
                ImageMass.Source = "woman5.png";
            }
        }
        if (male.IsChecked)
        {
            if (bmi < 16)
            {
                BMIProgressBar.ProgressColor = Colors.LightBlue;
                BodyText.Text = "Ýleri derecede zayýf";
                ImageMass.Source = "man1.png";

            }
            else if (16 <= bmi && bmi < 17)
            {
                BMIProgressBar.ProgressColor = Colors.Blue;
                BodyText.Text = "Orta derecede zayýf";
                ImageMass.Source = "man1.png";
            }
            else if (17 <= bmi && bmi < 18.5)
            {
                BMIProgressBar.ProgressColor = Colors.DarkBlue;
                BodyText.Text = "Hafif derecede zayýf";
                ImageMass.Source = "man1.png";
            }
            else if (bmi >= 18.5 && bmi < 25)
            {
                BMIProgressBar.ProgressColor = Colors.Green;
                BodyText.Text = "Normal Kilolu";
                ImageMass.Source = "man2.png";
            }
            else if (bmi >= 25 && bmi < 30)
            {
                BMIProgressBar.ProgressColor = Colors.Yellow;
                BodyText.Text = "Hafif þiþman";
                ImageMass.Source = "man3.png";
            }
            else if (bmi >= 30 && bmi < 35)
            {
                BMIProgressBar.ProgressColor = Colors.Orange;
                BodyText.Text = "1.derece obez";
                ImageMass.Source = "man3.png";
            }
            else if (bmi >= 35 && bmi < 40)
            {
                BMIProgressBar.ProgressColor = Colors.Red;
                BodyText.Text = "2.derece obez";
                ImageMass.Source = "man4.png";
            }
            else
            {
                BMIProgressBar.ProgressColor = Colors.DarkRed;
                BodyText.Text = "3.derece obez (Morbid obez)";
                ImageMass.Source = "man5.png";
            }
        }

    }

    private void HeightChange(object sender, ValueChangedEventArgs e)
    {
        UpdateBodyProperty();
    }

    private void WeightChange(object sender, ValueChangedEventArgs e)
    {
        UpdateBodyProperty();
    }
    private void UpdateBodyProperty()
    {
        height = (HeightSlider.Value) / 100;
        weight = WeightSlider.Value;

        WeightEntry.Text = WeightSlider.Value.ToString();
        HeightEntry.Text = HeightSlider.Value.ToString();

        CalculateBMI(weight, height);
    }
}
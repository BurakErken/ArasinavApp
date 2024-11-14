namespace ArasinavApp;

public partial class CreditCalculation : ContentPage
{
    public CreditCalculation()
    {
        InitializeComponent();
    }
    double KKDF = 0;
    double BSMV = 0;
    double krediAmount = 0;
    double faizOran = 0;
    int vade = 0;
    double ayl�kTaksit;
    double brutFaiz;
    double toplamOdeme;

    private async void OnSelectCreditTypeClicked(object sender, EventArgs e)
    {
        string selectedCredit = await DisplayActionSheet("", "�ptal", null,
                                                     "�htiya� Kredisi", "Konut Kredisi", "Ta��t Kredisi", "Ticari Kredi");

        if (selectedCredit != "�ptal")
        {
            SelectedCreditLabel.Text = selectedCredit;
            switch (selectedCredit)
            {
                case "�htiya� Kredisi":
                    KKDF = 15;
                    BSMV = 10;
                    break;
                case "Konut Kredisi":
                    KKDF = 0;
                    BSMV = 0;
                    break;
                case "Ta��t Kredisi":
                    KKDF = 15;
                    BSMV = 5;
                    break;
                case "Ticari Kredi":
                    KKDF = 0;
                    BSMV = 5;
                    break;
            }
        }
    }

    private void Calculate(object sender, EventArgs e)
    {
        krediAmount = Convert.ToDouble(KrediMiktariEntry.Text);
        faizOran = Convert.ToDouble(FaizOraniEntry.Text);
        vade = Convert.ToInt32(VadeEntry.Text);

        goCalculate(krediAmount, faizOran, vade);
    }
    private void goCalculate(double toplamKredi, double faiz, double vadeAy)
    {
        double krediAmount = toplamKredi;
        double faizOran = faiz;
        double vade = vadeAy;

        brutFaiz = (faizOran + (faizOran * BSMV) + (faizOran * KKDF)) / 100;
        ayl�kTaksit = (Math.Pow(1 + brutFaiz, vade) * brutFaiz) / ((Math.Pow(1 + brutFaiz, vade)) - 1) * krediAmount;
        toplamOdeme = ayl�kTaksit * vade;

        Ayl�kOdemeLabel.Text = ayl�kTaksit.ToString();
        ToplamOdemeLabel.Text = toplamOdeme.ToString();
        ToplamFaizLabel.Text = brutFaiz.ToString();
    }
  
    private void OnVadePickerSelected(object sender, EventArgs e)
    {
        if (VadePicker.SelectedItem != null)
        {
          
            VadeEntry.Text = VadePicker.SelectedItem.ToString();
            VadePicker.SelectedIndex = -1;
        }
    }

    private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
    {
        double sliderValue = e.NewValue;
        double krediMiktari = (sliderValue * 1000);
        double faizOrani = (sliderValue * 0.5); 
        double vade = 1+(sliderValue * 1)/2; 

        KrediMiktariEntry.Text = krediMiktari.ToString("F2");
        FaizOraniEntry.Text = faizOrani.ToString("F2");
        VadeEntry.Text = vade.ToString("F0");

        goCalculate(krediMiktari, faizOrani, vade);

    }
}
namespace Perfect_Pay
{
    public partial class MainPage : ContentPage
    {
        decimal Bill;
        int Tip;
        int noPersons = 1;

        public MainPage()
        {
            InitializeComponent();
        }

        private void txtamt_Completed(object sender, EventArgs e)
        {
            Bill = decimal.Parse(txtamt.Text);
            CalclateTotal();
        }

        private void CalclateTotal()
        {
            // Total Tip
            var totalTip = (Bill * Tip) / 100;

            // Tip By Person
            var tipbyperson = (totalTip / noPersons);
            lblTip.Text = $"{tipbyperson:C}";

            //Sub Total
            var subTotal = (Bill / noPersons);
            lblSub.Text = $"{subTotal:C}";

            // Total
            var Total = (Bill + totalTip) / noPersons;
            lblTotal.Text = $"{Total:C}";
        }

        private void sldtip_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            Tip = (int)sldtip.Value;
            txttip.Text = $"Tip :{Tip}%";
            CalclateTotal();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if(sender is Button)
            {
                Button btn = (Button)sender;
                var percentage = int.Parse(btn.Text.Replace("%",""));
                sldtip.Value = percentage;
            }
        }

        private void btnminus_Clicked(object sender, EventArgs e)
        {
            if(noPersons > 1)
            {
                noPersons--;
            }
            lblnoPersons.Text = noPersons.ToString();
            CalclateTotal();
            
        }

        private void btnplus_Clicked(object sender, EventArgs e)
        {
            noPersons++;
            lblnoPersons.Text = noPersons.ToString();
            CalclateTotal();
        }
    }
}
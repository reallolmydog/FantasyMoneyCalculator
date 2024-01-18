using Android.Text.Method;

namespace moneycalc
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private Button? button1;
        private Button? button2;
        private Button? button3;
        private Button? button4;
        private TextView TextView1;
        private TextView TextView2;

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            button1 = (Button)FindViewById(Resource.Id.button);
            button1.Click += cal;
            button2 = (Button)FindViewById(Resource.Id.RealToFake);
            button2.Click += RealToFakeChange;
            TextView1 = (TextView)FindViewById(Resource.Id.textView2);
            TextView1.MovementMethod = LinkMovementMethod.Instance;
            TextView2 = (TextView)FindViewById(Resource.Id.textView3);
            TextView2.MovementMethod = LinkMovementMethod.Instance;
        }

        private void RealToFakeChange(object? sender, EventArgs e)
        {
            SetContentView(Resource.Layout.real_to_ingame);
            button4 = (Button)FindViewById(Resource.Id.FakeToReal);
            button4.Click += FakeToRealChange;
            button3 = (Button)FindViewById(Resource.Id.RealCalc);
            button3.Click += RealCal;
            TextView1 = (TextView)FindViewById(Resource.Id.textView2);
            TextView1.MovementMethod = LinkMovementMethod.Instance;
            TextView2 = (TextView)FindViewById(Resource.Id.textView3);
            TextView2.MovementMethod = LinkMovementMethod.Instance;
        }

        private void FakeToRealChange(object? sender, EventArgs e)
        {
            SetContentView(Resource.Layout.activity_main);
            button1 = (Button)FindViewById(Resource.Id.button);
            button1.Click += cal;
            button2 = (Button)FindViewById(Resource.Id.RealToFake);
            button2.Click += RealToFakeChange;
            TextView1 = (TextView)FindViewById(Resource.Id.textView2);
            TextView1.MovementMethod = LinkMovementMethod.Instance;
            TextView2 = (TextView)FindViewById(Resource.Id.textView3);
            TextView2.MovementMethod = LinkMovementMethod.Instance;
        }

        private void RealCal(object? sender, EventArgs e)
        {
            double RealMoneyInput = 0;
            double RealBreadInput = 1;
            double RealCopperBreadInput = 2;
            EditText RealMoney = FindViewById<EditText>(Resource.Id.RealMoney);
            EditText RealBread = FindViewById<EditText>(Resource.Id.RealToGamePrice);
            EditText RealCopperBread = FindViewById<EditText>(Resource.Id.RealToGameCopperBread);
            string RealMoneyCheck = (RealMoney.Text.ToString());
            string RealBreadCheck = (RealBread.Text.ToString());
            string RealCopperBreadCheck = (RealCopperBread.Text.ToString());
            if (RealMoneyCheck != "")
            {
                RealMoneyInput = double.Parse(RealMoney.Text.ToString());
            }
            if (RealBreadCheck != "")
            {
                RealBreadInput = double.Parse(RealBread.Text.ToString());
            }
            if (RealCopperBreadCheck != "")
            {
                RealCopperBreadInput = double.Parse(RealCopperBread.Text.ToString());
            }
            double TotalCopper = RealMoneyInput / (RealBreadInput / RealCopperBreadInput);
            int TotalCopperint = (int)(TotalCopper);
            int TotalSilver = TotalCopperint / 10;
            int TotalGold = TotalSilver / 10;
            TotalCopperint = TotalCopperint % 10;
            TotalSilver = TotalSilver % 10;
            string FinalGold = TotalGold.ToString();
            string FinalSilver = TotalSilver.ToString();
            string FinalCopper = TotalCopperint.ToString();
            TextView tview1 = FindViewById<TextView>(Resource.Id.RealGold);
            TextView tview2 = FindViewById<TextView>(Resource.Id.RealSilver);
            TextView tview3 = FindViewById<TextView>(Resource.Id.RealCopper);
            string v2 = "Total gold: " + FinalGold;
            string v3 = "Total silver: " + FinalSilver;
            string v4 = "Total copper: " + FinalCopper;
            tview1.Text = v2;
            tview2.Text = v3;
            tview3.Text = v4;
        }

        private void cal(object? sender, EventArgs e)
        {
            double GoldInput = 0;
            double SilverInput = 0;
            double CopperInput = 0;
            double BreadInput = 1;
            double CopperBreadInput = 2;
            EditText Gold = FindViewById<EditText>(Resource.Id.Gold);
            EditText Silver = FindViewById<EditText>(Resource.Id.Silver);
            EditText Copper = FindViewById<EditText>(Resource.Id.Copper);
            EditText Bread = FindViewById<EditText>(Resource.Id.Price);
            EditText CopperBread = FindViewById<EditText>(Resource.Id.CopperBread);
            string GoldInputCheck = (Gold.Text.ToString());
            string SilverInputCheck = (Silver.Text.ToString());
            string CopperInputCheck = (Copper.Text.ToString());
            string BreadInputCheck = (Bread.Text.ToString());
            string CopperBreadCheck = (CopperBread.Text.ToString());
            if (GoldInputCheck != "")
            {
                GoldInput = double.Parse(Gold.Text.ToString());
            }
            if (SilverInputCheck != "")
            {
                SilverInput = double.Parse(Silver.Text.ToString());
            }
            if (CopperInputCheck != "")
            {
                CopperInput = double.Parse(Copper.Text.ToString());
            }
            if (BreadInputCheck != "")
            {
                BreadInput = double.Parse(Bread.Text.ToString());
            }
            if (CopperBreadCheck != "")
            {
                CopperBreadInput = double.Parse(CopperBread.Text.ToString());
            }
            double TotalCopper = CopperInput + SilverInput * 10 + GoldInput * 100;
            double BreadPrice = BreadInput / CopperBreadInput;
            double FinalPrice = TotalCopper * BreadPrice;
            FinalPrice = System.Math.Round(FinalPrice, 2);
            double FinalPriceCheck = System.Math.Round(FinalPrice, 1);
            double ExtraPriceCheck = System.Math.Round(FinalPrice, 0);
            string StringFinal = FinalPrice.ToString();
            if (FinalPrice == FinalPriceCheck && FinalPriceCheck != ExtraPriceCheck)
            {
                StringFinal = StringFinal + "0";
            }
            TextView tview = FindViewById<TextView>(Resource.Id.Money);
            string v1 = "total amount: $" + StringFinal;
            tview.Text = v1;
        }
    }
}  

namespace CalculatorC_Sharp
{
    public partial class CalcForm : Form
    {
        private string _firstNumber;
        private string _secondNumber;
        private char? _operator;

        public CalcForm()
        {
            InitializeComponent();
            _firstNumber = String.Empty;
            _secondNumber = String.Empty;
            _operator = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button btn = (Button)sender;
                if (_operator == null)
                {
                    _firstNumber += btn.Text;
                    UpdateDisplay(_firstNumber);
                }
                else
                {
                    _secondNumber += btn.Text;
                    UpdateDisplay(_secondNumber);
                }
            }
        }

        private void UpdateDisplay(string txt)
        {
            tbDisplay.Text = txt;
        }

        private void ClearPrompt(object sender, EventArgs e)
        {
            tbDisplay.Clear();
            _firstNumber = String.Empty;
            _secondNumber = String.Empty;
            _operator = null;
        }


        private void PickOperator(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button btn = (Button)sender;
                if (String.IsNullOrEmpty(_firstNumber)) return;
                _operator = btn.Text.ToCharArray()[0];
                UpdateDisplay(_operator.ToString());
            }
        }

        private void Calculate(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(_firstNumber) ||
                String.IsNullOrEmpty(_secondNumber)) return;

            decimal result = Calculate();
            _firstNumber = result.ToString();
            _operator = null;
            _secondNumber = String.Empty;
            UpdateDisplay(result.ToString());

        }

        private decimal Calculate()
        {
            decimal value = 0;
            switch (_operator)
            {
                case '+':
                    value = Decimal.Parse(_firstNumber) + Decimal.Parse(_secondNumber);
                break;

                case '-':
                    value = Decimal.Parse(_firstNumber) - Decimal.Parse(_secondNumber);
                break;

                case '*':
                    value = Decimal.Parse(_firstNumber) * Decimal.Parse(_secondNumber);
                break;

                case '/':
                    try
                    {
                        value = Decimal.Parse(_firstNumber) / Decimal.Parse(_secondNumber);
                    }catch(DivideByZeroException e)
                    {
                        UpdateDisplay(e.Message.ToString());
                    }
                break;
            }

            return value;
        }
    }
}
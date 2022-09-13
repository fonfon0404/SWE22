namespace ComplexCalculator
{
    public partial class Form1 : Form
    {
        double result = 0;
        string operation = "";
        bool isOperationClick = false;
        bool isRealNumCalculated = false;

        public Form1()
        {
            InitializeComponent();
            panel2.Hide();
        }
        
        /* Menu control */
        private void menuExit(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuComplexCalculator_Click(object sender, EventArgs e)
        {
            panel2.Show();
        }

        private void menuRealCalculator_Click(object sender, EventArgs e)
        {
            panel2.Hide();
        }

        /* Real Calculator Functions */
        private void button_Click(object sender, EventArgs e)
        {
            if (inputBox.Text == "0" || isOperationClick == true)
                inputBox.Clear();

            isOperationClick = false;
            Button button = (Button)sender;

            if (inputBox.Text == "" && button.Text == ".")
                inputBox.Text = "0.";
            if (inputBox.Text.Contains(".") && button.Text == ".")
                inputBox.Text = inputBox.Text;
            else
                inputBox.Text = inputBox.Text + button.Text;
        }

        private void operatorButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (operation != "")
            {
                buttonEqual.PerformClick();
                operation = button.Text;
                currentValueBox.Text += operation;
            }
            else
            {
                isOperationClick = true;
                operation = button.Text;
                result = double.Parse(inputBox.Text);
                currentValueBox.Text = result + operation;
            }
        }

        private void equalButton_Click(object sender, EventArgs e)
        {
            switch (operation)
            {
                case "+":
                    result += double.Parse(inputBox.Text);
                    currentValueBox.Text = result.ToString();
                    inputBox.Text = result.ToString();
                    break;
                case "-":
                    result -= double.Parse(inputBox.Text);
                    currentValueBox.Text = result.ToString();
                    inputBox.Text = result.ToString();
                    break;
                case "*":
                    result *= double.Parse(inputBox.Text);
                    currentValueBox.Text = result.ToString();
                    inputBox.Text = result.ToString();
                    break;
                case "/":
                    result /= double.Parse(inputBox.Text);
                    currentValueBox.Text = result.ToString();
                    inputBox.Text = result.ToString();
                    break;
                default:
                    break;
            }
            operation = "";
            isOperationClick = true;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            inputBox.Text = "0";
            currentValueBox.Clear();
            result = 0;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if(inputBox.TextLength >= 1)
                inputBox.Text = inputBox.Text.Substring(0, inputBox.TextLength - 1);
        }

        /* Complex Calculator Functions */
        private void complexNumButton_Click(object sender, EventArgs e)
        {
            if (realNumInputBox.Text == "0" || isOperationClick == true)
                realNumInputBox.Clear();
            if (imaginaryValueInputBox.Text == "0" || isOperationClick == true)
                imaginaryValueInputBox.Clear();
            Button button = (Button)sender;
            
            if(isRealNumCalculated == true)
            {
                if (imaginaryValueInputBox.Text == "" && button.Text == ".")
                    imaginaryValueInputBox.Text += "0.";
                if (imaginaryValueInputBox.Text.Contains(".") && button.Text == ".")
                    imaginaryValueInputBox.Text = imaginaryValueInputBox.Text;
                else
                    imaginaryValueInputBox.Text = imaginaryValueInputBox.Text + button.Text;
            }
            else
            {
                if (realNumInputBox.Text == "" && button.Text == ".")
                    realNumInputBox.Text = "0.";
                if (realNumInputBox.Text.Contains(".") && button.Text == ".")
                    realNumInputBox.Text = realNumInputBox.Text;
                else
                    realNumInputBox.Text = realNumInputBox.Text + button.Text;
            }
            isOperationClick = false;
        }

        private void complexOperatorButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (operation != "")
            {
                complexEqual.PerformClick();
            }
            else
            {
                isOperationClick = true;
                operation = button.Text;
                if(isRealNumCalculated == false)
                {
                result = double.Parse(realNumInputBox.Text);
                currentRealNumBox.Text = result + operation;
                }
                else
                {
                    result = double.Parse(imaginaryValueInputBox.Text);
                    currentImaginaryValueBox.Text = result + operation;
                }
            }
        }

        private void complexEqualButton_Click(object sender, EventArgs e)
        {
            if(realNumInputBox.Text != "")
            {
                switch (operation)
            {
                case "+":
                    result += double.Parse(realNumInputBox.Text);
                    currentRealNumBox.Text = result.ToString();
                    realNumInputBox.Text = result.ToString();
                    break;
                case "-":
                    result -= double.Parse(realNumInputBox.Text);
                    currentRealNumBox.Text = result.ToString();
                    realNumInputBox.Text = result.ToString();
                    break;
                case "*":
                    result *= double.Parse(realNumInputBox.Text);
                    currentRealNumBox.Text = result.ToString();
                    realNumInputBox.Text = result.ToString();
                    break;
                case "/":
                    result /= double.Parse(realNumInputBox.Text);
                    currentRealNumBox.Text = result.ToString();
                    realNumInputBox.Text = result.ToString();
                    break;
                default:
                    break;
            }
            operation = "";
            isOperationClick = true;
            isRealNumCalculated = true;
            }
            else if (imaginaryValueInputBox.Text != "" && isRealNumCalculated == true)
            {
                switch (operation)
                {
                    case "+":
                        result += double.Parse(imaginaryValueInputBox.Text);
                        currentImaginaryValueBox.Text = result.ToString();
                        imaginaryValueInputBox.Text = result.ToString();
                        break;
                    case "-":
                        result -= double.Parse(imaginaryValueInputBox.Text);
                        currentImaginaryValueBox.Text = result.ToString();
                        imaginaryValueInputBox.Text = result.ToString();
                        break;
                    case "*":
                        result *= double.Parse(imaginaryValueInputBox.Text);
                        currentImaginaryValueBox.Text = result.ToString();
                        imaginaryValueInputBox.Text = result.ToString();
                        break;
                    case "/":
                        result /= double.Parse(imaginaryValueInputBox.Text);
                        currentImaginaryValueBox.Text = result.ToString();
                        imaginaryValueInputBox.Text = result.ToString();
                        break;
                    default:
                        break;
                }
                operation = "";
                isOperationClick = true;
                isRealNumCalculated = false;
            }
        }

        private void complexClearButton_Click(object sender, EventArgs e)
        {
            realNumInputBox.Text = "0";
            imaginaryValueInputBox.Text = "0";
            currentRealNumBox.Clear();
            currentImaginaryValueBox.Clear();
            result = 0;
        }

        private void complexBackButton_Click(object sender, EventArgs e)
        {
            if (inputBox.TextLength >= 1)
                inputBox.Text = inputBox.Text.Substring(0, inputBox.TextLength - 1);
        }
    }
}
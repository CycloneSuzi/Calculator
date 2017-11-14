using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
///  Author: Suzanne Townsend 
///  Date: 27/10/2017
///  Purpose: Activity 1.6
/// </summary>
namespace Calculator
{
	public partial class GUICalc : Form
	{
		#region Variables
		//double a and b are the users input, 'a' being the first input, 'b' the second.
		double a, b, result;

		//bool will result which arithmetic calulation has been chosen.
		bool plusButtonClicked,
				minusButtonClicked,
				divideButtonClicked,
				multiplyButtonClicked = false;
		#endregion

		public GUICalc()
		{

			InitializeComponent();
			//Declare variables 
			a = 0;
			b = 0;
			result = 0;
			
		}

		//The buttons region contains a method for each button on click.
		//The methods send the character/number displayed on the button that is clicked
		//into the text box - txtDisplay
		#region Buttons 

		private void BtnZero_Click(object sender, EventArgs e)
		{
			txtDisplay.Text = txtDisplay.Text + BtnZero.Text;
		}

		private void BtnOne_Click(object sender, EventArgs e)
		{
			txtDisplay.Text = txtDisplay.Text + BtnOne.Text;
		}

		private void BtnTwo_Click(object sender, EventArgs e)
		{
			txtDisplay.Text = txtDisplay.Text + BtnTwo.Text;
		}

		private void BtnThree_Click(object sender, EventArgs e)
		{
			txtDisplay.Text = txtDisplay.Text + BtnThree.Text;
		}

		private void BtnFour_Click(object sender, EventArgs e)
		{
			txtDisplay.Text = txtDisplay.Text + BtnFour.Text;
		}

		private void BtnFive_Click(object sender, EventArgs e)
		{
			txtDisplay.Text = txtDisplay.Text + BtnFive.Text;
		}

		private void BtnSix_Click(object sender, EventArgs e)
		{
			txtDisplay.Text = txtDisplay.Text + BtnSix.Text;
		}

		private void BtnSeven_Click(object sender, EventArgs e)
		{
			txtDisplay.Text = txtDisplay.Text + BtnSeven.Text;
		}

		private void BtnEight_Click(object sender, EventArgs e)
		{
			txtDisplay.Text = txtDisplay.Text + BtnEight.Text;
		}

		private void BtnNine_Click(object sender, EventArgs e)
		{
			txtDisplay.Text = txtDisplay.Text + BtnNine.Text;
		}

		private void BtnPosNeg_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(txtDisplay.Text))
			{
				txtDisplay.Text = Convert.ToString(-Convert.ToInt32(txtDisplay.Text));
			}
			else
			{
				txtDisplay.Focus();
			}
		}

		private void BtnDecimal_Click(object sender, EventArgs e)
		{
			txtDisplay.Text = txtDisplay.Text + BtnDecimal.Text;
		}

		private void BtnClear_Click(object sender, EventArgs e)
		{
			txtDisplay.Clear();
		}

		#endregion

		//The Arithmetic Region will hold all of the arithmetic functions.
		//these Functions will use the algorithums from the BasicMaths DLL
		#region Arithmetic
		
		//The Plus, Minus, Multiply and Divide on click methods are virtually the same 
		// with only their respected calculations being the difference. 
		// they begin with an error handling if statement to assure the program does not
		// crash when the button is pressed while the text box is empty.
		// it then sets the first input to the variable 'a' and the bool determines which
		// the buttons was pressed.
		private void BtnPlus_Click(object sender, EventArgs e)
		{

			if (!string.IsNullOrEmpty(txtDisplay.Text))
			{
				a += double.Parse(txtDisplay.Text);
				txtDisplay.Clear();

				plusButtonClicked = true;
				minusButtonClicked = false;
				divideButtonClicked = false;
				multiplyButtonClicked = false;
			}
			else
			{
				txtDisplay.Focus();
			}
		}

		private void BtnMinus_Click(object sender, EventArgs e)
		{
			
			if (!string.IsNullOrEmpty(txtDisplay.Text))
			{
				a += double.Parse(txtDisplay.Text);
				txtDisplay.Clear();

				plusButtonClicked = false;
				minusButtonClicked = true;
				divideButtonClicked = false;
				multiplyButtonClicked = false;
			}
			else
			{
				txtDisplay.Focus();
			}
		}

		private void BtnMultiply_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(txtDisplay.Text))
			{
				a += double.Parse(txtDisplay.Text);
				txtDisplay.Clear();

				plusButtonClicked = false;
				minusButtonClicked = false;
				divideButtonClicked = false;
				multiplyButtonClicked = true;
			}
			else
			{
				txtDisplay.Focus();
			}
		}

		private void BtnDivide_Click(object sender, EventArgs e)
		{
			
			if (!string.IsNullOrEmpty(txtDisplay.Text))
			{
				a += double.Parse(txtDisplay.Text);
				txtDisplay.Clear();

				plusButtonClicked = false;
				minusButtonClicked = false;
				divideButtonClicked = true;
				multiplyButtonClicked = false;
			}
			else
			{
				txtDisplay.Focus();
			}
		}

		//The equals onclick method sets the second input to the variable 'b'
		//with a nested if else statement it determines which of the Arithmetic function 
		// was chosen and calculates the equation with the agorithums set in BasicMaths
		private void BtnEquals_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(txtDisplay.Text))
			{
				b += double.Parse(txtDisplay.Text);
				if (plusButtonClicked == true)
				{

					result = BasicMath.Arithmetic.Add(a, b);

				}
				else if (minusButtonClicked == true)
				{

					result = BasicMath.Arithmetic.Sub(a, b);

				}
				else if (divideButtonClicked == true)
				{

					result = BasicMath.Arithmetic.Div(a, b);

				}
				else if (multiplyButtonClicked == true)
				{

					result = BasicMath.Arithmetic.Mult(a, b);

				}
				txtDisplay.Text = result.ToString();
				//this resets the variables back to 0.
				a = 0;
				b = 0;
			}
			else
			{
				txtDisplay.Focus();
			}
		}

		#endregion

		//The Algebraic Region will hold all of the Algebraic Functions.
		//These Functions will use the algorithums from the Algebra DLL.
		#region Algebraic

		//All buttons begin with an if else statment handling empty input.
		//The square root onClick method rejects all input of number equal too or below 0
		//With an if else statement.
		private void BtnSQRT_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(txtDisplay.Text))
			{
				double num = double.Parse(txtDisplay.Text);
				if (num >= 0)
				{
					txtDisplay.Text = Algebra.Alge.SquareRoot(num).ToString();
				}
				else
				{
					txtDisplay.Text = "Invalid Input";
				}
			}
			else
			{
				txtDisplay.Focus();
			}
		}

		//The cube root onClick method
		//is error handled within the Alegebra DLL to accept negative numbers.
		private void BtnCube_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(txtDisplay.Text))
			{
				double x = double.Parse(txtDisplay.Text);
				txtDisplay.Text = Algebra.Alge.CubeRoot(x).ToString();
			}
			else
			{
				txtDisplay.Focus();
			}
		}
		
		//this is the onClick method for the Inverse button.
		private void BtnInv_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(txtDisplay.Text))
			{
				double x = double.Parse(txtDisplay.Text);
				txtDisplay.Text = Algebra.Alge.Inv(x).ToString();
			}
			else
			{
				txtDisplay.Focus();
			}
		}
		#endregion

		//The Algebraic Region will hold all of the Algebraic Functions.
		//These Functions will use the algorithums from the Algebra DLL.
		#region Trigonometry

		//Cos reads from the trigonometry DLL. The cos onClick method uses an if statements 
		//to error handle in the correct answers. 
		private void BtnCos_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(txtDisplay.Text))
			{
				int variable = -1;
				double degrees = double.Parse(txtDisplay.Text);
				if (degrees != 90 && degrees != 180 && degrees != 360)
				{
					txtDisplay.Text = Trigonometry.Trig.Cos(degrees).ToString();
				}

				if (degrees == 90)
				{
					txtDisplay.Text = 0.ToString();
				}
				if (degrees == 180)
				{
					txtDisplay.Text = variable.ToString();
				}
				if (degrees == 270)
				{
					txtDisplay.Text = 0.ToString();
				}
				if (degrees == 360)
				{
					txtDisplay.Text = 1.ToString();
				}
				
			}
			else
			{
				txtDisplay.Focus();
			}
		}

		//Tan reads from the Trigonometry DLL. The Tan onClick method uses two if else statements 
		// to error handle in correct answers

		private void BtnTan_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(txtDisplay.Text))
			{
				double angle = double.Parse(txtDisplay.Text);

				if (angle != 90 && angle != 270)
				{
					txtDisplay.Text = Trigonometry.Trig.Tan(angle).ToString();
				}
				else
				{
					txtDisplay.Text = "Undefined";
				}
				if (angle == 360 || angle == 180)
				{
					txtDisplay.Text = "0";
				}
			}

			else
			{
				txtDisplay.Focus();
			}
		}

		//Sin reads from the trigonometry DLL. The Sin onClick Method uses if statements 
		//to error handle in the correct answers.
		private void BtnSin_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(txtDisplay.Text))
			{
				int variable = -1;
				double degrees = double.Parse(txtDisplay.Text);

				if (degrees != 0 && degrees != 90 && degrees != 180 && degrees != 360)
				{
					txtDisplay.Text = Trigonometry.Trig.Sine(degrees).ToString();
				}
				if (degrees == 90)
				{
					txtDisplay.Text = 1.ToString();
				}
				if (degrees == 180)
				{
					txtDisplay.Text = 0.ToString();
				}
				if (degrees == 270)
				{
					txtDisplay.Text = variable.ToString();
				}
				if (degrees == 360)
				{
					txtDisplay.Text = 0.ToString();
				}
			}
			else
			{
				txtDisplay.Focus();
			}
		}
		#endregion


		//This region hold the functions for the tool Strip Menu Items
		#region ToolStripMenuItem 
		//clears the textbox
		private void ClearToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			txtDisplay.Clear();
		}

		//Exits the program after checking with the user.
		private void QuitToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to quit?", "Exit", MessageBoxButtons.OKCancel)
				== DialogResult.OK)
			{
				Application.Exit();
			}
		}
		#endregion





	}
}

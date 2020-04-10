using System;
using System.Collections.Generic;
using System.Text;

namespace SymbolsOverlapAndGapValidator
{
	public static class Symbols
	{
		public static string Message { get; set; }

		enum LikelihoodBands
		{
			LessThan = 1,
			LessThanOrEqualTo = 2,
			GreaterThanOrEqualTo = 3,
			GreaterThan = 4
		}

		public static string SymbolsOverlapAndGapValidator(List<CalculationMethodRules> calculationMethodRules)
		{
			Message = "";

			//GreaterThan_GreaterThanOrEqualTo(out int initialSymbol, out int finalSymbol, out decimal initialValue, out decimal finalValue);

			Console.WriteLine("Init Cases");

			int initialSymbol, finalSymbol;
			decimal initialValue, finalValue;
			Case1to2(calculationMethodRules, out initialSymbol, out initialValue, out finalSymbol, out finalValue);
			Validator(initialSymbol, finalSymbol, initialValue, finalValue, "Case1to2");

			Case2to2(calculationMethodRules, out initialSymbol, out initialValue, out finalSymbol, out finalValue);
			Validator(initialSymbol, finalSymbol, initialValue, finalValue, "Case2to2");

			Case2to3(calculationMethodRules, out initialSymbol, out initialValue, out finalSymbol, out finalValue);
			Validator(initialSymbol, finalSymbol, initialValue, finalValue, "Case2to3");

			Case3to3(calculationMethodRules, out initialSymbol, out initialValue, out finalSymbol, out finalValue);
			Validator(initialSymbol, finalSymbol, initialValue, finalValue, "Case3to3");

			Case3to4(calculationMethodRules, out initialSymbol, out initialValue, out finalSymbol, out finalValue);
			Validator(initialSymbol, finalSymbol, initialValue, finalValue, "Case3to4");

			Case4to4(calculationMethodRules, out initialSymbol, out initialValue, out finalSymbol, out finalValue);
			Validator(initialSymbol, finalSymbol, initialValue, finalValue, "Case4to4");

			Case4to5(calculationMethodRules, out initialSymbol, out initialValue, out finalSymbol, out finalValue);
			Validator(initialSymbol, finalSymbol, initialValue, finalValue, "Case4to5");

			Console.WriteLine("End Cases");
			return Message;
		}

		private static void Validator(int initialSymbol, int finalSymbol, decimal initialValue, decimal finalValue, string caseValidator)
		{
			if (initialSymbol == 0)
				Message = "Error";
			else
			{
				switch (initialSymbol)
				{
					case (int)LikelihoodBands.LessThan:
						#region -- Case - LessThan
						switch (finalSymbol)
						{
							case (int)LikelihoodBands.LessThan:
								Message = "Overlap";
								break;
							case (int)LikelihoodBands.LessThanOrEqualTo:
								Message = "Overlap";
								break;
							case (int)LikelihoodBands.GreaterThanOrEqualTo:
								if (initialValue == finalValue)
									Message = "Success";
								else if (initialValue > finalValue)
									Message = "Success";
								else
									Message = "Gap";
								break;
							case (int)LikelihoodBands.GreaterThan:
								if (initialValue > finalValue)
									Message = "Success";
								else
									Message = "Gap";
								break;
						}
						#endregion
						break;
					case (int)LikelihoodBands.LessThanOrEqualTo:
						#region -- Case - LessThanOrEqualTo
						switch (finalSymbol)
						{
							case (int)LikelihoodBands.LessThan:
								Message = "Overlap";
								break;
							case (int)LikelihoodBands.LessThanOrEqualTo:
								Message = "Overlap";
								break;
							case (int)LikelihoodBands.GreaterThanOrEqualTo:
								if (initialValue > finalValue)
									Message = "Success";
								else if (initialValue == finalValue)
									Message = "Overlap";
								else
									Message = "Gap";
								break;
							case (int)LikelihoodBands.GreaterThan:
								if (initialValue == finalValue)
									Message = "Success";
								else if (initialValue > finalValue)
									Message = "Success";
								else
									Message = "Gap";
								break;
						}
						#endregion
						break;
					case (int)LikelihoodBands.GreaterThanOrEqualTo:
						#region -- Case - GreaterThanOrEqualTo
						switch (finalSymbol)
						{
							case (int)LikelihoodBands.LessThan:
								if (initialValue == finalValue)
									Message = "Success";
								else if (initialValue > finalValue)
									Message = "Gap";
								else
									Message = "Success";
								break;
							case (int)LikelihoodBands.LessThanOrEqualTo:
								if (initialValue == finalValue)
									Message = "Overlap";
								else if (initialValue > finalValue)
									Message = "Gap";
								else
									Message = "Success";
								break;
							case (int)LikelihoodBands.GreaterThanOrEqualTo:
								Message = "Overlap";
								break;
							case (int)LikelihoodBands.GreaterThan:
								Message = "Overlap";
								break;
						}
						#endregion
						break;
					case (int)LikelihoodBands.GreaterThan:
						#region -- Case - GreaterThan
						switch (finalSymbol)
						{
							case (int)LikelihoodBands.LessThan:
								if (initialValue == finalValue)
									Message = "Gap";
								else if (initialValue > finalValue)
									Message = "Gap";
								else
									Message = "Success";
								break;
							case (int)LikelihoodBands.LessThanOrEqualTo:
								if (initialValue == finalValue)
									Message = "Success";
								else if (initialValue > finalValue)
									Message = "Gap";
								else
									Message = "Success";
								break;
							case (int)LikelihoodBands.GreaterThanOrEqualTo:
								Message = "Overlap";
								break;
							case (int)LikelihoodBands.GreaterThan:
								Message = "Overlap";
								break;
						}
						#endregion
						break;
				}
			}

			Console.WriteLine($"-- {caseValidator} - {Message}");
		}

		private static void Case1to2(List<CalculationMethodRules> calculationMethodRules, out int initialSymbol, out decimal initialValue, out int finalSymbol, out decimal finalValue)
		{
			// Case 1 - 2
			initialSymbol = calculationMethodRules[0].UpperSymbolID == null ? 0 : calculationMethodRules[0].UpperSymbolID.Value;
			initialValue = calculationMethodRules[0].UpperTestValue == null ? 0 : calculationMethodRules[0].UpperTestValue.Value;
			finalSymbol = calculationMethodRules[1].LowerSymbolID == null ? 0 : calculationMethodRules[1].LowerSymbolID.Value;
			finalValue = calculationMethodRules[1].LowerTestValue == null ? 0 : calculationMethodRules[1].LowerTestValue.Value;
		}

		private static void Case2to2(List<CalculationMethodRules> calculationMethodRules, out int initialSymbol, out decimal initialValue, out int finalSymbol, out decimal finalValue)
		{
			// Case 2 - 2
			initialSymbol = calculationMethodRules[1].LowerSymbolID == null ? 0 : calculationMethodRules[1].LowerSymbolID.Value;
			initialValue = calculationMethodRules[1].LowerTestValue == null ? 0 : calculationMethodRules[1].LowerTestValue.Value;
			finalSymbol = calculationMethodRules[1].UpperSymbolID == null ? 0 : calculationMethodRules[1].UpperSymbolID.Value;
			finalValue = calculationMethodRules[1].UpperTestValue == null ? 0 : calculationMethodRules[1].UpperTestValue.Value;
		}

		private static void Case2to3(List<CalculationMethodRules> calculationMethodRules, out int initialSymbol, out decimal initialValue, out int finalSymbol, out decimal finalValue)
		{
			// Case 2 - 3
			initialSymbol = calculationMethodRules[1].UpperSymbolID == null ? 0 : calculationMethodRules[1].UpperSymbolID.Value;
			initialValue = calculationMethodRules[1].UpperTestValue == null ? 0 : calculationMethodRules[1].UpperTestValue.Value;
			finalSymbol = calculationMethodRules[2].LowerSymbolID == null ? 0 : calculationMethodRules[2].LowerSymbolID.Value;
			finalValue = calculationMethodRules[2].LowerTestValue == null ? 0 : calculationMethodRules[2].LowerTestValue.Value;
		}

		private static void Case3to3(List<CalculationMethodRules> calculationMethodRules, out int initialSymbol, out decimal initialValue, out int finalSymbol, out decimal finalValue)
		{
			// Case 3 - 3
			initialSymbol = calculationMethodRules[2].LowerSymbolID == null ? 0 : calculationMethodRules[2].LowerSymbolID.Value;
			initialValue = calculationMethodRules[2].LowerTestValue == null ? 0 : calculationMethodRules[2].LowerTestValue.Value;
			finalSymbol = calculationMethodRules[2].UpperSymbolID == null ? 0 : calculationMethodRules[2].UpperSymbolID.Value;
			finalValue = calculationMethodRules[2].UpperTestValue == null ? 0 : calculationMethodRules[2].UpperTestValue.Value;
		}

		private static void Case3to4(List<CalculationMethodRules> calculationMethodRules, out int initialSymbol, out decimal initialValue, out int finalSymbol, out decimal finalValue)
		{
			// Case 3 - 4
			initialSymbol = calculationMethodRules[2].UpperSymbolID == null ? 0 : calculationMethodRules[2].UpperSymbolID.Value;
			initialValue = calculationMethodRules[2].UpperTestValue == null ? 0 : calculationMethodRules[2].UpperTestValue.Value;
			finalSymbol = calculationMethodRules[3].LowerSymbolID == null ? 0 : calculationMethodRules[3].LowerSymbolID.Value;
			finalValue = calculationMethodRules[3].LowerTestValue == null ? 0 : calculationMethodRules[3].LowerTestValue.Value;
		}

		private static void Case4to4(List<CalculationMethodRules> calculationMethodRules, out int initialSymbol, out decimal initialValue, out int finalSymbol, out decimal finalValue)
		{
			// Case 4 - 4
			initialSymbol = calculationMethodRules[3].LowerSymbolID == null ? 0 : calculationMethodRules[3].LowerSymbolID.Value;
			initialValue = calculationMethodRules[3].LowerTestValue == null ? 0 : calculationMethodRules[3].LowerTestValue.Value;
			finalSymbol = calculationMethodRules[3].UpperSymbolID == null ? 0 : calculationMethodRules[3].UpperSymbolID.Value;
			finalValue = calculationMethodRules[3].UpperTestValue == null ? 0 : calculationMethodRules[3].UpperTestValue.Value;
		}

		private static void Case4to5(List<CalculationMethodRules> calculationMethodRules, out int initialSymbol, out decimal initialValue, out int finalSymbol, out decimal finalValue)
		{
			// Case 4 - 5
			initialSymbol = calculationMethodRules[3].UpperSymbolID == null ? 0 : calculationMethodRules[3].UpperSymbolID.Value;
			initialValue = calculationMethodRules[3].UpperTestValue == null ? 0 : calculationMethodRules[3].UpperTestValue.Value;
			finalSymbol = calculationMethodRules[4].LowerSymbolID == null ? 0 : calculationMethodRules[4].LowerSymbolID.Value;
			finalValue = calculationMethodRules[4].LowerTestValue == null ? 0 : calculationMethodRules[4].LowerTestValue.Value;
		}

		#region *** Tests - LessThan ***
		private static void LessThan_LessThan(out int initialSymbol, out int finalSymbol, out decimal initialValue, out decimal finalValue)
		{
			initialSymbol = (int)LikelihoodBands.LessThan;
			finalSymbol = (int)LikelihoodBands.LessThan;

			// Overlap
			initialValue = 1.00M;
			finalValue = 1.00M;
		}

		private static void LessThan_LessThanOrEqualTo(out int initialSymbol, out int finalSymbol, out decimal initialValue, out decimal finalValue)
		{
			initialSymbol = (int)LikelihoodBands.LessThan;
			finalSymbol = (int)LikelihoodBands.LessThanOrEqualTo;

			// Overlap
			initialValue = 1.00M;
			finalValue = 1.00M;
		}

		private static void LessThan_GreaterThanOrEqualTo(out int initialSymbol, out int finalSymbol, out decimal initialValue, out decimal finalValue)
		{
			initialSymbol = (int)LikelihoodBands.LessThan;
			finalSymbol = (int)LikelihoodBands.GreaterThanOrEqualTo;

			// Success
			//initialValue = 1.00M;
			//inalValue = 1.00M;

			//// Gap
			//initialValue = 2.00M;
			//finalValue = 1.00M;

			// Gap
			initialValue = 1.00M;
			finalValue = 2.00M;
		}

		private static void LessThan_GreaterThan(out int initialSymbol, out int finalSymbol, out decimal initialValue, out decimal finalValue)
		{
			initialSymbol = (int)LikelihoodBands.LessThan;
			finalSymbol = (int)LikelihoodBands.GreaterThan;

			//// Gap
			//initialValue = 1.00M;
			//finalValue = 1.00M;

			//// Success
			//initialValue = 2.00M;
			//finalValue = 1.00M;

			// Gap
			initialValue = 1.00M;
			finalValue = 2.00M;
		}
		#endregion

		#region *** Tests - LessThanOrEqualTo ***
		private static void LessThanOrEqualTo_LessThan(out int initialSymbol, out int finalSymbol, out decimal initialValue, out decimal finalValue)
		{
			initialSymbol = (int)LikelihoodBands.LessThanOrEqualTo;
			finalSymbol = (int)LikelihoodBands.LessThan;

			// Overlap
			initialValue = 1.00M;
			finalValue = 1.00M;
		}

		private static void LessThanOrEqualTo_LessThanOrEqualTo(out int initialSymbol, out int finalSymbol, out decimal initialValue, out decimal finalValue)
		{
			initialSymbol = (int)LikelihoodBands.LessThanOrEqualTo;
			finalSymbol = (int)LikelihoodBands.LessThanOrEqualTo;

			// Overlap
			initialValue = 1.00M;
			finalValue = 1.00M;
		}

		private static void LessThanOrEqualTo_GreaterThanOrEqualTo(out int initialSymbol, out int finalSymbol, out decimal initialValue, out decimal finalValue)
		{
			initialSymbol = (int)LikelihoodBands.LessThanOrEqualTo;
			finalSymbol = (int)LikelihoodBands.GreaterThanOrEqualTo;

			// Overlap
			initialValue = 1.00M;
			finalValue = 1.00M;

			//// Success
			//initialValue = 2.00M;
			//finalValue = 1.00M;

			//// Gap
			//initialValue = 1.00M;
			//finalValue = 2.00M;
		}

		private static void LessThanOrEqualTo_GreaterThan(out int initialSymbol, out int finalSymbol, out decimal initialValue, out decimal finalValue)
		{
			initialSymbol = (int)LikelihoodBands.LessThanOrEqualTo;
			finalSymbol = (int)LikelihoodBands.GreaterThan;

			// Success
			initialValue = 1.00M;
			finalValue = 1.00M;

			//// Gap
			//initialValue = 2.00M;
			//finalValue = 1.00M;

			//// Gap
			//initialValue = 1.00M;
			//finalValue = 2.00M;
		}
		#endregion

		#region *** Tests - GreaterThanOrEqualTo ***
		private static void GreaterThanOrEqualTo_LessThan(out int initialSymbol, out int finalSymbol, out decimal initialValue, out decimal finalValue)
		{
			initialSymbol = (int)LikelihoodBands.GreaterThanOrEqualTo;
			finalSymbol = (int)LikelihoodBands.LessThan;

			//// Gap
			//initialValue = 1.00M;
			//finalValue = 1.00M;

			//// Gap
			//initialValue = 2.00M;
			//finalValue = 1.00M;

			// Success
			initialValue = 1.00M;
			finalValue = 2.00M;
		}

		private static void GreaterThanOrEqualTo_LessThanOrEqualTo(out int initialSymbol, out int finalSymbol, out decimal initialValue, out decimal finalValue)
		{
			initialSymbol = (int)LikelihoodBands.GreaterThanOrEqualTo;
			finalSymbol = (int)LikelihoodBands.LessThanOrEqualTo;

			//// Overlap
			//initialValue = 1.00M;
			//finalValue = 1.00M;

			//// Gap
			//initialValue = 2.00M;
			//finalValue = 1.00M;

			// Success
			initialValue = 1.00M;
			finalValue = 2.00M;
		}

		private static void GreaterThanOrEqualTo_GreaterThanOrEqualTo(out int initialSymbol, out int finalSymbol, out decimal initialValue, out decimal finalValue)
		{
			initialSymbol = (int)LikelihoodBands.GreaterThanOrEqualTo;
			finalSymbol = (int)LikelihoodBands.GreaterThanOrEqualTo;

			// Overlap
			initialValue = 1.00M;
			finalValue = 1.00M;
		}

		private static void GreaterThanOrEqualTo_GreaterThan(out int initialSymbol, out int finalSymbol, out decimal initialValue, out decimal finalValue)
		{
			initialSymbol = (int)LikelihoodBands.GreaterThanOrEqualTo;
			finalSymbol = (int)LikelihoodBands.GreaterThan;

			// Overlap
			initialValue = 1.00M;
			finalValue = 1.00M;
		}
		#endregion

		#region *** Tests - GreaterThan ***
		private static void GreaterThan_LessThan(out int initialSymbol, out int finalSymbol, out decimal initialValue, out decimal finalValue)
		{
			initialSymbol = (int)LikelihoodBands.GreaterThan;
			finalSymbol = (int)LikelihoodBands.LessThan;

			//// Gap
			//initialValue = 1.00M;
			//finalValue = 1.00M;

			//// Gap
			//initialValue = 2.00M;
			//finalValue = 1.00M;

			// Success
			initialValue = 1.00M;
			finalValue = 2.00M;
		}

		private static void GreaterThan_LessThanOrEqualTo(out int initialSymbol, out int finalSymbol, out decimal initialValue, out decimal finalValue)
		{
			initialSymbol = (int)LikelihoodBands.GreaterThan;
			finalSymbol = (int)LikelihoodBands.LessThanOrEqualTo;

			//// Overlap
			//initialValue = 1.00M;
			//finalValue = 1.00M;

			//// Gap
			//initialValue = 2.00M;
			//finalValue = 1.00M;

			// Success
			initialValue = 1.00M;
			finalValue = 2.00M;
		}

		private static void GreaterThan_GreaterThanOrEqualTo(out int initialSymbol, out int finalSymbol, out decimal initialValue, out decimal finalValue)
		{
			initialSymbol = (int)LikelihoodBands.GreaterThan;
			finalSymbol = (int)LikelihoodBands.GreaterThanOrEqualTo;

			// Overlap
			initialValue = 1.00M;
			finalValue = 1.00M;
		}

		private static void GreaterThan_GreaterThan(out int initialSymbol, out int finalSymbol, out decimal initialValue, out decimal finalValue)
		{
			initialSymbol = (int)LikelihoodBands.GreaterThan;
			finalSymbol = (int)LikelihoodBands.GreaterThan;

			// Overlap
			initialValue = 1.00M;
			finalValue = 1.00M;
		}
		#endregion
	}
}

using System;
using System.Collections.Generic;

namespace SymbolsOverlapAndGapValidator
{
	enum LikelihoodBands
	{
		One = 0,
		Two = 1,
		Three = 2,
		Four = 3,
		Five = 4
	}

	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("-- Start Validation");

			List<CalculationMethodRules> calculationMethodRules = new List<CalculationMethodRules>();

			// SUCCESS
			calculationMethodRules = GenerateCalculationMethodRulesFakeGap();
			Console.WriteLine(Symbols.SymbolsOverlapAndGapValidator(calculationMethodRules));

			//// OVERLAP
			//calculationMethodRules = GenerateCalculationMethodRulesFakeOverlap();
			//Console.WriteLine(Symbols.SymbolsOverlapAndGapValidator(calculationMethodRules));

			//// GAP
			//calculationMethodRules = GenerateCalculationMethodRulesFakeGap();
			//Console.WriteLine(Symbols.SymbolsOverlapAndGapValidator(calculationMethodRules));





			//calculationMethodRules = GenerateCalculationMethodRulesFakeExceptions();
			//Console.WriteLine(SymbolsOverlapAndGapValidator(calculationMethodRules));

			//calculationMethodRules = new List<CalculationMethodRules>();
			//calculationMethodRules = GenerateCalculationMethodRulesFakeOverlap();
			//Console.WriteLine(SymbolsOverlapAndGapValidator(calculationMethodRules));

			//calculationMethodRules = new List<CalculationMethodRules>();
			//calculationMethodRules = GenerateCalculationMethodRulesFakeGap();
			//Console.WriteLine(SymbolsOverlapAndGapValidator(calculationMethodRules));

			//const int LIKELIHOODBANDS = 5;
			//for (int i = 0; i < LIKELIHOODBANDS; i++)
			//{
			//	Console.WriteLine($"-- Case: {i+1}");
			//	calculationMethodRules.Add(GenerateCalculationMethodRules(i));
			//}

			Console.WriteLine("-- End Validation");
			Console.Read();
		}

		private static List<CalculationMethodRules> GenerateCalculationMethodRulesFakeExceptions()
		{
			List<CalculationMethodRules> list = new List<CalculationMethodRules>();
			var item = new CalculationMethodRules();
			item.UpperSymbolID = 1;
			item.UpperTestValue = 1;
			list.Add(item);

			item = new CalculationMethodRules();
			item.LowerSymbolID = 4;
			item.LowerTestValue = 1;
			item.UpperSymbolID = 1;
			item.UpperTestValue = 2;
			list.Add(item);

			item = new CalculationMethodRules();
			item.LowerSymbolID = 4;
			item.LowerTestValue = 2;
			item.UpperSymbolID = 1;
			item.UpperTestValue = 3;
			list.Add(item);

			item = new CalculationMethodRules();
			item.LowerSymbolID = 4;
			item.LowerTestValue = 3;
			item.UpperSymbolID = 1;
			item.UpperTestValue = 4;
			list.Add(item);

			item = new CalculationMethodRules();
			item.LowerSymbolID = 4;
			item.LowerTestValue = 4;
			list.Add(item);

			return list;
		}

		public Program()
		{
			Message = "";
		}

		private static string ReturnMessage(string msg)
		{
			if (Message == "" || Message == null)
				Message = msg;

			return Message;
		}

		public static string Message { get; set; }

		private static string SymbolsOverlapAndGapValidator(List<CalculationMethodRules> calculationMethodRules)
		{
			var overlapLeft = new List<int>() { 1, 2, 3 };
			var overlapRight = new List<int>() { 3, 4, 5 };

			if (calculationMethodRules.Count != 5)
			{
				Message = "Dont have 5 likelihood band!!!";
			}

			// 1 - 2
			if (overlapLeft.Contains(calculationMethodRules[0].UpperSymbolID.Value))
			{
				// Verificar se 1 esta no left (wrong side)
				if (overlapLeft.Contains(calculationMethodRules[1].LowerSymbolID.Value))
				{
					// Overlap
					return ReturnMessage("Overlap");
				}
				else
				{
					if ((calculationMethodRules[0].UpperSymbolID.Value == 1 && calculationMethodRules[1].LowerSymbolID.Value == 5) ||
						(calculationMethodRules[0].UpperSymbolID.Value == 5 && calculationMethodRules[1].LowerSymbolID.Value == 1))
					{
						if (calculationMethodRules[0].UpperTestValue.Value == calculationMethodRules[1].LowerTestValue.Value)
						{
							return ReturnMessage("Gap");							
						}
					}

					if ((calculationMethodRules[0].UpperSymbolID == 2 && calculationMethodRules[1].LowerSymbolID == 4) ||
						(calculationMethodRules[0].UpperSymbolID == 4 && calculationMethodRules[1].LowerSymbolID == 2))
					{
						if (calculationMethodRules[0].UpperTestValue == calculationMethodRules[1].LowerTestValue)
						{
							return ReturnMessage("Overlap");
						}
					}

					// Is there gap?
					if (calculationMethodRules[0].UpperTestValue.Value - calculationMethodRules[1].LowerTestValue.Value != 0)
					{
						return ReturnMessage("Gap");
					}
				}
			}
			else
			{
				// Verificar se 1 esta no right (wrong side)
				if (overlapRight.Contains(calculationMethodRules[1].LowerSymbolID.Value))
				{
					// Overlap
					return ReturnMessage("Overlap");
				}
				else
				{
					if ((calculationMethodRules[0].UpperSymbolID.Value == 1 && calculationMethodRules[1].LowerSymbolID.Value == 5) ||
						(calculationMethodRules[0].UpperSymbolID.Value == 5 && calculationMethodRules[1].LowerSymbolID.Value == 1))
					{
						if (calculationMethodRules[0].UpperTestValue.Value == calculationMethodRules[1].LowerTestValue.Value)
						{
							return ReturnMessage("Gap");
						}
					}

					if ((calculationMethodRules[0].UpperSymbolID == 2 && calculationMethodRules[1].LowerSymbolID == 4) ||
						(calculationMethodRules[0].UpperSymbolID == 4 && calculationMethodRules[1].LowerSymbolID == 2))
					{
						if (calculationMethodRules[0].UpperTestValue == calculationMethodRules[1].LowerTestValue)
						{
							return ReturnMessage("Overlap");
						}
					}

					// Is there gap?
					if (calculationMethodRules[0].UpperTestValue.Value - calculationMethodRules[1].LowerTestValue.Value != 0)
					{
						return ReturnMessage("Gap");
					}
				}
			}

			// 2 - 2
			if (overlapLeft.Contains(calculationMethodRules[1].LowerSymbolID.Value))
			{
				// Verificar se 1 esta no left (wrong side)
				if (overlapLeft.Contains(calculationMethodRules[1].UpperSymbolID.Value))
				{
					// Overlap
					return ReturnMessage("Overlap");
				}
				else
				{
					if ((calculationMethodRules[1].UpperSymbolID.Value == 1 && calculationMethodRules[1].LowerSymbolID.Value == 5) ||
						(calculationMethodRules[1].UpperSymbolID.Value == 5 && calculationMethodRules[1].LowerSymbolID.Value == 1))
					{
						if (calculationMethodRules[1].UpperTestValue.Value == calculationMethodRules[1].LowerTestValue.Value)
						{
							return ReturnMessage("Gap");
						}
					}

					if ((calculationMethodRules[1].UpperSymbolID == 2 && calculationMethodRules[1].LowerSymbolID == 4) ||
						(calculationMethodRules[1].UpperSymbolID == 4 && calculationMethodRules[1].LowerSymbolID == 2))
					{
						if (calculationMethodRules[1].UpperTestValue == calculationMethodRules[1].LowerTestValue)
						{
							return ReturnMessage("Overlap");
						}
					}

					// Is there gap?
					if (calculationMethodRules[1].UpperTestValue.Value - calculationMethodRules[1].LowerTestValue.Value != 0)
					{
						return ReturnMessage("Gap");
					}
				}
			}
			else
			{
				// Verificar se 1 esta no right (wrong side)
				if (overlapRight.Contains(calculationMethodRules[1].UpperSymbolID.Value))
				{
					// Overlap
					return ReturnMessage("Overlap");
				}
				else
				{
					if ((calculationMethodRules[1].UpperSymbolID.Value == 1 && calculationMethodRules[1].LowerSymbolID.Value == 5) ||
						(calculationMethodRules[1].UpperSymbolID.Value == 5 && calculationMethodRules[1].LowerSymbolID.Value == 1))
					{
						if (calculationMethodRules[0].UpperTestValue.Value == calculationMethodRules[1].LowerTestValue.Value)
						{
							return ReturnMessage("Gap");
						}
					}

					if ((calculationMethodRules[1].UpperSymbolID == 2 && calculationMethodRules[1].LowerSymbolID == 4) ||
						(calculationMethodRules[1].UpperSymbolID == 4 && calculationMethodRules[1].LowerSymbolID == 2))
					{
						if (calculationMethodRules[1].UpperTestValue == calculationMethodRules[1].LowerTestValue)
						{
							return ReturnMessage("Overlap");
						}
					}

					// Is there gap?
					if (calculationMethodRules[1].UpperTestValue.Value - calculationMethodRules[1].LowerTestValue.Value != 0)
					{
						return ReturnMessage("Gap");
					}
				}
			}

			// 2 - 3
			if (overlapLeft.Contains(calculationMethodRules[1].UpperSymbolID.Value))
			{
				// Verificar se 1 esta no left (wrong side)
				if (overlapLeft.Contains(calculationMethodRules[2].LowerSymbolID.Value))
				{
					// Overlap
					return ReturnMessage("Overlap");
				}
				else
				{
					if ((calculationMethodRules[1].UpperSymbolID.Value == 1 && calculationMethodRules[2].LowerSymbolID.Value == 5) ||
						(calculationMethodRules[1].UpperSymbolID.Value == 5 && calculationMethodRules[2].LowerSymbolID.Value == 1))
					{
						if (calculationMethodRules[1].UpperTestValue.Value == calculationMethodRules[2].LowerTestValue.Value)
						{
							return ReturnMessage("Gap");
						}
					}

					if ((calculationMethodRules[1].UpperSymbolID == 2 && calculationMethodRules[2].LowerSymbolID == 4) ||
						(calculationMethodRules[1].UpperSymbolID == 4 && calculationMethodRules[2].LowerSymbolID == 2))
					{
						if (calculationMethodRules[1].UpperTestValue == calculationMethodRules[2].LowerTestValue)
						{
							return ReturnMessage("Overlap");
						}
					}

					// Is there gap?
					if (calculationMethodRules[1].UpperTestValue.Value - calculationMethodRules[2].LowerTestValue.Value != 0)
					{
						return ReturnMessage("Gap");
					}
				}
			}
			else
			{
				// Verificar se 1 esta no right (wrong side)
				if (overlapRight.Contains(calculationMethodRules[2].LowerSymbolID.Value))
				{
					// Overlap
					return ReturnMessage("Overlap");
				}
				else
				{
					if ((calculationMethodRules[1].UpperSymbolID.Value == 1 && calculationMethodRules[2].LowerSymbolID.Value == 5) ||
						(calculationMethodRules[1].UpperSymbolID.Value == 5 && calculationMethodRules[2].LowerSymbolID.Value == 1))
					{
						if (calculationMethodRules[1].UpperTestValue.Value == calculationMethodRules[2].LowerTestValue.Value)
						{
							return ReturnMessage("Gap");
						}
					}

					if ((calculationMethodRules[1].UpperSymbolID == 2 && calculationMethodRules[2].LowerSymbolID == 4) ||
						(calculationMethodRules[1].UpperSymbolID == 4 && calculationMethodRules[2].LowerSymbolID == 2))
					{
						if (calculationMethodRules[1].UpperTestValue == calculationMethodRules[2].LowerTestValue)
						{
							return ReturnMessage("Overlap");
						}
					}

					// Is there gap?
					if (calculationMethodRules[1].UpperTestValue.Value - calculationMethodRules[2].LowerTestValue.Value != 0)
					{
						return ReturnMessage("Gap");
					}
				}
			}

			// 3 - 4
			if (overlapLeft.Contains(calculationMethodRules[2].UpperSymbolID.Value))
			{
				// Verificar se 1 esta no left (wrong side)
				if (overlapLeft.Contains(calculationMethodRules[3].LowerSymbolID.Value))
				{
					// Overlap
					return ReturnMessage("Overlap");
				}
				else
				{
					if ((calculationMethodRules[2].UpperSymbolID.Value == 1 && calculationMethodRules[3].LowerSymbolID.Value == 5) ||
						(calculationMethodRules[2].UpperSymbolID.Value == 5 && calculationMethodRules[3].LowerSymbolID.Value == 1))
					{
						if (calculationMethodRules[2].UpperTestValue.Value == calculationMethodRules[3].LowerTestValue.Value)
						{
							return ReturnMessage("Gap");
						}
					}

					if ((calculationMethodRules[2].UpperSymbolID == 2 && calculationMethodRules[3].LowerSymbolID == 4) ||
						(calculationMethodRules[2].UpperSymbolID == 4 && calculationMethodRules[3].LowerSymbolID == 2))
					{
						if (calculationMethodRules[2].UpperTestValue == calculationMethodRules[3].LowerTestValue)
						{
							return ReturnMessage("Overlap");
						}
					}

					// Is there gap?
					if (calculationMethodRules[2].UpperTestValue.Value - calculationMethodRules[3].LowerTestValue.Value != 0)
					{
						return ReturnMessage("Gap");
					}
				}
			}
			else
			{
				// Verificar se 1 esta no right (wrong side)
				if (overlapRight.Contains(calculationMethodRules[3].LowerSymbolID.Value))
				{
					// Overlap
					return ReturnMessage("Overlap");
				}
				else
				{
					if ((calculationMethodRules[2].UpperSymbolID.Value == 1 && calculationMethodRules[3].LowerSymbolID.Value == 5) ||
						(calculationMethodRules[2].UpperSymbolID.Value == 5 && calculationMethodRules[3].LowerSymbolID.Value == 1))
					{
						if (calculationMethodRules[2].UpperTestValue.Value == calculationMethodRules[3].LowerTestValue.Value)
						{
							return ReturnMessage("Gap");
						}
					}

					if ((calculationMethodRules[2].UpperSymbolID == 2 && calculationMethodRules[3].LowerSymbolID == 4) ||
						(calculationMethodRules[2].UpperSymbolID == 4 && calculationMethodRules[3].LowerSymbolID == 2))
					{
						if (calculationMethodRules[2].UpperTestValue == calculationMethodRules[3].LowerTestValue)
						{
							return ReturnMessage("Overlap");
						}
					}

					// Is there gap?
					if (calculationMethodRules[2].UpperTestValue.Value - calculationMethodRules[3].LowerTestValue.Value != 0)
					{
						return ReturnMessage("Gap");
					}
				}
			}

			// 4 - 5
			if (overlapLeft.Contains(calculationMethodRules[3].UpperSymbolID.Value))
			{
				// Verificar se 1 esta no left (wrong side)
				if (overlapLeft.Contains(calculationMethodRules[4].LowerSymbolID.Value))
				{
					// Overlap
					return ReturnMessage("Overlap");
				}
				else
				{
					if ((calculationMethodRules[3].UpperSymbolID.Value == 1 && calculationMethodRules[4].LowerSymbolID.Value == 5) ||
						(calculationMethodRules[3].UpperSymbolID.Value == 5 && calculationMethodRules[4].LowerSymbolID.Value == 1))
					{
						if (calculationMethodRules[3].UpperTestValue.Value == calculationMethodRules[4].LowerTestValue.Value)
						{
							return ReturnMessage("Gap");
						}
					}

					if ((calculationMethodRules[3].UpperSymbolID == 2 && calculationMethodRules[4].LowerSymbolID == 4) ||
						(calculationMethodRules[3].UpperSymbolID == 4 && calculationMethodRules[4].LowerSymbolID == 2))
					{
						if (calculationMethodRules[3].UpperTestValue == calculationMethodRules[4].LowerTestValue)
						{
							return ReturnMessage("Overlap");
						}
					}

					// Is there gap?
					if (calculationMethodRules[3].UpperTestValue.Value - calculationMethodRules[4].LowerTestValue.Value != 0)
					{
						return ReturnMessage("Gap");
					}
				}
			}
			else
			{
				// Verificar se 1 esta no right (wrong side)
				if (overlapRight.Contains(calculationMethodRules[4].LowerSymbolID.Value))
				{
					// Overlap
					return ReturnMessage("Overlap");
				}
				else
				{
					if ((calculationMethodRules[3].UpperSymbolID.Value == 1 && calculationMethodRules[4].LowerSymbolID.Value == 5) ||
						(calculationMethodRules[3].UpperSymbolID.Value == 5 && calculationMethodRules[4].LowerSymbolID.Value == 1))
					{
						if (calculationMethodRules[3].UpperTestValue.Value == calculationMethodRules[4].LowerTestValue.Value)
						{
							return ReturnMessage("Gap");
						}
					}

					if ((calculationMethodRules[3].UpperSymbolID == 2 && calculationMethodRules[4].LowerSymbolID == 4) ||
						(calculationMethodRules[3].UpperSymbolID == 4 && calculationMethodRules[4].LowerSymbolID == 2))
					{
						if (calculationMethodRules[3].UpperTestValue == calculationMethodRules[4].LowerTestValue)
						{
							return ReturnMessage("Overlap");
						}
					}


					// Is there gap?
					if (calculationMethodRules[3].UpperTestValue.Value - calculationMethodRules[4].LowerTestValue.Value != 0)
					{
						return ReturnMessage("Gap");
					}
				}
			}

			return ReturnMessage("Success!!!");
		}

		//private static string SymbolsOverlapAndGapValidator(List<CalculationMethodRules> calculationMethodRules)
		//{
		//	var overlapLeft = new List<int>() { 1, 2, 3 };
		//	var overlapRight = new List<int>() { 3, 4, 5 };

		//	string message = "";

		//	if (calculationMethodRules.Count != 5)
		//	{
		//		message = "Dont have 5 likehood band!!!";
		//	}

		//	// 1 - 2
		//	if (overlapLeft.Contains(calculationMethodRules[0].UpperSymbolID.Value))
		//	{
		//		// Verificar se 1 esta no left (wrong side)
		//		if (overlapLeft.Contains(calculationMethodRules[1].LowerSymbolID.Value))
		//		{
		//			// Overlap
		//			if(message == "") message = "Overlap";
		//		}
		//		else
		//		{
		//			// Is there gap?
		//			if (calculationMethodRules[0].UpperTestValue.Value - calculationMethodRules[1].LowerTestValue.Value != 0)
		//			{
		//				if (message == "") message = "Gap";
		//			}
		//		}
		//	}
		//	else
		//	{
		//		// Verificar se 1 esta no right (wrong side)
		//		if (overlapRight.Contains(calculationMethodRules[1].LowerSymbolID.Value))
		//		{
		//			// Overlap
		//			if (message == "") message = "Overlap";
		//		}
		//		else
		//		{
		//			// Is there gap?
		//			if (calculationMethodRules[0].UpperTestValue.Value - calculationMethodRules[1].LowerTestValue.Value != 0)
		//			{
		//				if (message == "") message = "Gap";
		//			}
		//		}
		//	}

		//	// 2 - 3
		//	if (overlapLeft.Contains(calculationMethodRules[1].UpperSymbolID.Value))
		//	{
		//		// Verificar se 1 esta no left (wrong side)
		//		if (overlapLeft.Contains(calculationMethodRules[2].LowerSymbolID.Value))
		//		{
		//			// Overlap
		//			if (message == "") message = "Overlap";
		//		}
		//		else
		//		{
		//			// Is there gap?
		//			if (calculationMethodRules[1].UpperTestValue.Value - calculationMethodRules[2].LowerTestValue.Value != 0)
		//			{
		//				if (message == "") message = "Gap";
		//			}
		//		}
		//	}
		//	else
		//	{
		//		// Verificar se 1 esta no right (wrong side)
		//		if (overlapRight.Contains(calculationMethodRules[2].LowerSymbolID.Value))
		//		{
		//			// Overlap
		//			if (message == "") message = "Overlap";
		//		}
		//		else
		//		{
		//			// Is there gap?
		//			if (calculationMethodRules[1].UpperTestValue.Value - calculationMethodRules[2].LowerTestValue.Value != 0)
		//			{
		//				if (message == "") message = "Gap";
		//			}
		//		}
		//	}

		//	// 3 - 4
		//	if (overlapLeft.Contains(calculationMethodRules[2].UpperSymbolID.Value))
		//	{
		//		// Verificar se 1 esta no left (wrong side)
		//		if (overlapLeft.Contains(calculationMethodRules[3].LowerSymbolID.Value))
		//		{
		//			// Overlap
		//			if (message == "") message = "Overlap";
		//		}
		//		else
		//		{
		//			// Is there gap?
		//			if (calculationMethodRules[2].UpperTestValue.Value - calculationMethodRules[3].LowerTestValue.Value != 0)
		//			{
		//				if (message == "") message = "Gap";
		//			}
		//		}
		//	}
		//	else
		//	{
		//		// Verificar se 1 esta no right (wrong side)
		//		if (overlapRight.Contains(calculationMethodRules[3].LowerSymbolID.Value))
		//		{
		//			// Overlap
		//			if (message == "") message = "Overlap";
		//		}
		//		else
		//		{
		//			// Is there gap?
		//			if (calculationMethodRules[2].UpperTestValue.Value - calculationMethodRules[3].LowerTestValue.Value != 0)
		//			{
		//				if (message == "") message = "Gap";
		//			}
		//		}
		//	}

		//	// 4 - 5
		//	if (overlapLeft.Contains(calculationMethodRules[3].UpperSymbolID.Value))
		//	{
		//		// Verificar se 1 esta no left (wrong side)
		//		if (overlapLeft.Contains(calculationMethodRules[4].LowerSymbolID.Value))
		//		{
		//			// Overlap
		//			if (message == "") message = "Overlap";
		//		}
		//		else
		//		{
		//			// Is there gap?
		//			if (calculationMethodRules[3].UpperTestValue.Value - calculationMethodRules[4].LowerTestValue.Value != 0)
		//			{
		//				if (message == "") message = "Gap";
		//			}
		//		}
		//	}
		//	else
		//	{
		//		// Verificar se 1 esta no right (wrong side)
		//		if (overlapRight.Contains(calculationMethodRules[4].LowerSymbolID.Value))
		//		{
		//			// Overlap
		//			if (message == "") message = "Overlap";
		//		}
		//		else
		//		{
		//			// Is there gap?
		//			if (calculationMethodRules[3].UpperTestValue.Value - calculationMethodRules[4].LowerTestValue.Value != 0)
		//			{
		//				if (message == "") message = "Gap";
		//			}
		//		}
		//	}


		//	if (message == "") message = "Success!!!";

		//	return message;
		//}

		private static List<CalculationMethodRules> GenerateCalculationMethodRulesFake()
		{
			List<CalculationMethodRules> list = new List<CalculationMethodRules>();
			var item = new CalculationMethodRules();
			item.UpperSymbolID = 1;
			item.UpperTestValue = 1;
			list.Add(item);

			item = new CalculationMethodRules();
			item.LowerSymbolID = 3;
			item.LowerTestValue = 1;
			item.UpperSymbolID = 1;
			item.UpperTestValue = 2;
			list.Add(item);

			item = new CalculationMethodRules();
			item.LowerSymbolID = 3;
			item.LowerTestValue = 2;
			item.UpperSymbolID = 1;
			item.UpperTestValue = 3;
			list.Add(item);

			item = new CalculationMethodRules();
			item.LowerSymbolID = 3;
			item.LowerTestValue = 3;
			item.UpperSymbolID = 1;
			item.UpperTestValue = 4;
			list.Add(item);

			item = new CalculationMethodRules();
			item.LowerSymbolID = 3;
			item.LowerTestValue = 4;
			list.Add(item);

			return list;
		}

		private static List<CalculationMethodRules> GenerateCalculationMethodRulesFakeOverlap()
		{
			List<CalculationMethodRules> list = new List<CalculationMethodRules>();
			var item = new CalculationMethodRules();
			item.UpperSymbolID = 1;
			item.UpperTestValue = 1;
			list.Add(item);

			item = new CalculationMethodRules();
			item.LowerSymbolID = 1;
			item.LowerTestValue = 1;
			item.UpperSymbolID = 1;
			item.UpperTestValue = 2;
			list.Add(item);

			item = new CalculationMethodRules();
			item.LowerSymbolID = 3;
			item.LowerTestValue = 2;
			item.UpperSymbolID = 1;
			item.UpperTestValue = 3;
			list.Add(item);

			item = new CalculationMethodRules();
			item.LowerSymbolID = 3;
			item.LowerTestValue = 3;
			item.UpperSymbolID = 1;
			item.UpperTestValue = 4;
			list.Add(item);

			item = new CalculationMethodRules();
			item.LowerSymbolID = 3;
			item.LowerTestValue = 4;
			list.Add(item);

			return list;
		}

		private static List<CalculationMethodRules> GenerateCalculationMethodRulesFakeGap()
		{
			List<CalculationMethodRules> list = new List<CalculationMethodRules>();
			var item = new CalculationMethodRules();
			item.UpperSymbolID = 1;
			item.UpperTestValue = 1;
			list.Add(item);

			item = new CalculationMethodRules();
			item.LowerSymbolID = 3;
			item.LowerTestValue = 2;
			item.UpperSymbolID = 1;
			item.UpperTestValue = 2;
			list.Add(item);

			item = new CalculationMethodRules();
			item.LowerSymbolID = 3;
			item.LowerTestValue = 2;
			item.UpperSymbolID = 1;
			item.UpperTestValue = 3;
			list.Add(item);

			item = new CalculationMethodRules();
			item.LowerSymbolID = 3;
			item.LowerTestValue = 3;
			item.UpperSymbolID = 1;
			item.UpperTestValue = 4;
			list.Add(item);

			item = new CalculationMethodRules();
			item.LowerSymbolID = 3;
			item.LowerTestValue = 4;
			list.Add(item);

			return list;
		}

		private static CalculationMethodRules GenerateCalculationMethodRules(int likelihoodBand)
		{
			var obj = new CalculationMethodRules();

			switch (likelihoodBand)
			{
				case (int)LikelihoodBands.One:
					Console.Write("Upper Symbol (< 1, <= 2, >= 3, > 4 ): ");
					obj.UpperSymbolID = Convert.ToInt32(Console.ReadLine());
					Console.Write("Upper Test Value: ");
					obj.UpperTestValue = Convert.ToInt32(Console.ReadLine());
					break;
				case (int)LikelihoodBands.Two:
				case (int)LikelihoodBands.Three:
				case (int)LikelihoodBands.Four:
					Console.Write("Upper Symbol (< 1, <= 2, >= 3, > 4 ): ");
					obj.UpperSymbolID = Convert.ToInt32(Console.ReadLine());
					Console.Write("Upper Test Value: ");
					obj.UpperTestValue = Convert.ToInt32(Console.ReadLine());
					Console.Write("Lower Symbol (< 1, <= 2, >= 3, > 4 ): ");
					obj.LowerSymbolID = Convert.ToInt32(Console.ReadLine());
					Console.Write("Lower Test Value: ");
					obj.LowerTestValue = Convert.ToInt32(Console.ReadLine());
					break;
				case (int)LikelihoodBands.Five:
					Console.Write("Lower Symbol (< 1, <= 2, >= 3, > 4 ): ");
					obj.LowerSymbolID = Convert.ToInt32(Console.ReadLine());
					Console.Write("Lower Test Value: ");
					obj.LowerTestValue = Convert.ToInt32(Console.ReadLine());
					break;
			}

			return obj;
		}
	}
}

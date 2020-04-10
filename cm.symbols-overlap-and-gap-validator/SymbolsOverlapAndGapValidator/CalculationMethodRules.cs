using System;
using System.Collections.Generic;
using System.Text;

namespace SymbolsOverlapAndGapValidator
{
    public class CalculationMethodRules
    {
		public int? LowerSymbolID { get; set; }
		public decimal? LowerTestValue { get; set; }
		public int? UpperSymbolID { get; set; }
		public decimal? UpperTestValue { get; set; }
	}
}

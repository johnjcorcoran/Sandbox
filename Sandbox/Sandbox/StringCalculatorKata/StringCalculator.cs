using System;
using System.Linq;
using System.Collections.Generic;

namespace Sandbox.StringCalculatorKata
{
	public class StringCalculator
	{
		private readonly int ResultIfEmptyInput = 0;
		private List<string> Delimiters = new List<string>{",", "\n"};

		public int Add (string numbers)
		{
			if (string.IsNullOrEmpty (numbers)) {
				return ResultIfEmptyInput;
			}

			if (CustomDelimiterUsed(numbers)) {
				AddCustomDelimiter(numbers);
				numbers = ExtractSecondLineFrom(numbers);
			}

			int[] integers = Parse(numbers);
			ThrowExceptionIfAnyIntegersNegative(integers);
			return integers.Sum();
		}

		private static string ExtractSecondLineFrom (string numbers)
		{
			return numbers.Substring (4);
		}

		private void AddCustomDelimiter (string numbers)
		{
			Delimiters.Add (numbers.Substring (2, 1));
		}

		private int[] Parse (string numbers)
		{
			return numbers.Split(Delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries)
						  .Select(n => Convert.ToInt32(n))
						  .ToArray();
		}

		private void ThrowExceptionIfAnyIntegersNegative (int[] integers)
		{
			if (integers.Any (x => x < 0)) {
				int[] negatives = integers.Where(x => x < 0).ToArray();
				throw new Exception(String.Format("negatives not allowed - {0}", FormatNumbers(negatives)));
			}
		}

		private string FormatNumbers (int[] negatives)
		{
			return string.Join(" ", negatives);
		}

		static bool CustomDelimiterUsed (string numbers)
		{
			return numbers.StartsWith("//");
		}
	}
}


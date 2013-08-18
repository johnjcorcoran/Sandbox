using System;
using System.Collections.Generic;
using System.Linq;

namespace Sandbox.StringCalculatorKata
{
	public class StringCalculator
	{
		private const int ResultIfInputEmpty = 0;
		private const int MaximumLegalInput = 1000;
		private const string newLineSymbol = "\n";
		private const string CustomDelimiterStart = "[";
		private const string CustomDelimiterEnd = "]";
		private const string CustomDelimiterIndicator = "//";
		private static readonly List<string> Delimiters = new List<string>{",", newLineSymbol};

		public int Add (string numbers)
		{
			if (string.IsNullOrEmpty (numbers)) {
				return ResultIfInputEmpty;
			}

			return CustomDelimiterUsed(numbers) 
				? ParseWithCustomDelimiters(numbers).Sum()
				: Parse(numbers).Sum();
		}

		private int[] ParseWithCustomDelimiters (string numbers)
		{
			ExtractCustomDelimitersFrom (FirstLineOf (numbers));
			return Parse (SecondLineOnwardsOf (numbers));
		}

		private void ExtractCustomDelimitersFrom (string numbers)
		{
			if (LongDelimiterUsed (numbers)) {
				ExtractLongCustomDelimiters (numbers);
			} else {
				AddSingleCharacterCustomDelimiter (numbers);
			}
		}

	    private int[] Parse (string numbers)
		{
			int[] integers = numbers.Split(Delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries)
						            .Select(n => Convert.ToInt32(n))
									.Where(n => n <= MaximumLegalInput)
						            .ToArray();
			ThrowExceptionIfAnyNegative(integers);
			return integers;
		}

		private void ExtractLongCustomDelimiters (string numbers)
		{
			string[] delimiters = numbers.Remove (0, 2)
				       					 .Split (CustomDelimiterEnd.ToArray (), StringSplitOptions.RemoveEmptyEntries);
			foreach (string delimiter in delimiters) {
				Delimiters.Add(delimiter.Remove (0, 1));
			}
		}

		private void ThrowExceptionIfAnyNegative (int[] integers)
		{
			if (!integers.Any (x => x < 0)) return;

			int[] negatives = integers.Where(x => x < 0).ToArray();
			throw new Exception(String.Format(
				"negatives not allowed - {0}", FormatNumbers(negatives)));
		}

		private string FormatNumbers (int[] negatives)
		{
			return string.Join (" ", negatives);
		}

		private void AddSingleCharacterCustomDelimiter (string numbers)
		{
			Delimiters.Add (numbers.Substring (2, 1));
		}

		private static bool CustomDelimiterUsed (string numbers)
		{
			return numbers.StartsWith (CustomDelimiterIndicator);
		}

		private static bool LongDelimiterUsed (string numbers)
		{
			return numbers.Contains (CustomDelimiterStart);
		}

		private static string FirstLineOf (string numbers)
		{
			return numbers.Substring(0, GetSecondLineIndex (numbers));
		}

		private static string SecondLineOnwardsOf (string numbers)
		{
			return numbers.Substring (GetSecondLineIndex (numbers)+1);
		}

		static int GetSecondLineIndex (string numbers)
		{
			return numbers.IndexOf (newLineSymbol);
		}
	}
}


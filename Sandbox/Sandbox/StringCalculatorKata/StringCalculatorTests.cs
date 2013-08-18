using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Sandbox.StringCalculatorKata
{
	[TestFixture]
	public class StringCalculatorTests
	{
		private StringCalculator _calculator;

		[SetUp]
		public void SetUp()
		{
			_calculator = new StringCalculator();
		}

		[Test]
		public void AddEmptyStringEqualsZero()
		{
			Assert.That(_calculator.Add(""), Is.EqualTo(0));
		}

		[TestCase("1", 1)]
		[TestCase("2", 2)]
		public void AddSingleNumberReturnsThatNumber (string numbers, int result)
		{
			Assert.That(_calculator.Add(numbers), Is.EqualTo(result));
		}

		[TestCase("1,2", 3)]
		[TestCase("2,3", 5)]
		[TestCase("1,2,3,4,5", 15)]
		public void AddMultipleDelimitedNumbersReturnsSumOfNumbers(string numbers, int result)
		{
			Assert.That(_calculator.Add(numbers), Is.EqualTo(result));
		}

		[TestCase("1\n2", 3)]
		[TestCase("1\n2,3", 6)]
		public void AddMultipleNewLineDelimitedNumbersReturnsSumOfNumbers(string numbers, int result)
		{
			Assert.That(_calculator.Add(numbers), Is.EqualTo(result));
		}

		[TestCase("//;\n1;2", 3)]
		[TestCase("//;\n1;2\n3", 6)]
		public void AddAllowsModificationOfDefaultDelimiter(string numbers, int result)
		{
			Assert.That(_calculator.Add(numbers), Is.EqualTo(result));
		}

		[TestCase("-1", "-1")]
		[TestCase("-1, 2, -3", "-1 -3")]
		public void AddThrowsExceptionWhenGivenNegativeNumbers(string numbers, string expected)
		{
			Assert.Throws(Is.TypeOf<Exception>().And.Message.EqualTo("negatives not allowed - " + expected), 
			              () => _calculator.Add(numbers));
		}
	}
}


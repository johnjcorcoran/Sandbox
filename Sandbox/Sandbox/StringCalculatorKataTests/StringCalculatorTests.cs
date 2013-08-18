using System;
using NUnit.Framework;
using Sandbox.StringCalculatorKata;


namespace Sandbox.StringCalculatorKataTests
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
		public void AddWithEmptyStringReturnsZero()
		{
			Assert.That(_calculator.Add(""), Is.EqualTo(0));
		}

		[TestCase("1", 1)]
		[TestCase("2", 2)]
		public void AddingSingleNumberReturnsThatNumber (string numbers, int result)
		{
			Assert.That(_calculator.Add(numbers), Is.EqualTo(result));
		}

		[TestCase("1,2", 3)]
		[TestCase("2,3", 5)]
		[TestCase("1,2,3,4,5", 15)]
		public void AddingMultipleDelimitedNumbersReturnsSumOfNumbers(string numbers, int result)
		{
			Assert.That(_calculator.Add(numbers), Is.EqualTo(result));
		}

		[TestCase("1\n2", 3)]
		[TestCase("1\n2,3", 6)]
		public void AddingMultipleNewLineDelimitedNumbersReturnsSumOfNumbers(string numbers, int result)
		{
			Assert.That(_calculator.Add(numbers), Is.EqualTo(result));
		}

		[TestCase("//;\n1;2", 3)]
		[TestCase("//;\n1;2\n3", 6)]
		public void AddAllowsCustomDelimiter(string numbers, int result)
		{
			Assert.That(_calculator.Add(numbers), Is.EqualTo(result));
		}

		[TestCase("-1", "-1")]
		[TestCase("-1, 2, -3", "-1 -3")]
		public void AddThrowsExceptionGivenNegativeNumbers(string numbers, string expected)
		{
			Assert.Throws(Is.TypeOf<Exception>().And.Message.EqualTo("negatives not allowed - " + expected), 
			              () => _calculator.Add(numbers));
		}

		[TestCase("1,1001", 1)]
		[TestCase("1,1000,1001", 1001)]
		public void AddIgnoresNumbersGreaterThan1000(string numbers, int result)
		{
			Assert.That(_calculator.Add(numbers), Is.EqualTo(result));
		}

		[TestCase("//[***]\n1***2", 3)]
		[TestCase("//[***][!!!]\n1***2!!!3", 6)]
		public void AddAllowsMultipleCustomDelimitersOfAnyLength(string numbers, int result)
		{
			Assert.That(_calculator.Add(numbers), Is.EqualTo(result));
		}
	}
}


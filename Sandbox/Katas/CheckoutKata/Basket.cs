using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Sandbox.CheckoutKata
{
	public class Basket
	{
		[Test]
		public void empty_basket_should_return_zero()
		{
			const string emptyBasket = "";
			Assert.That(Calculate(emptyBasket), Is.EqualTo(0));
		}

		[TestCase("A", 50)]
		[TestCase("B", 30)]
		[TestCase("C", 20)]
		public void basket_with_a_single_item_should_return_the_price_of_that_item(string basket, int price)
		{
			Assert.That(Calculate(basket), Is.EqualTo(price));
		}
		
		[TestCase("AA", 100)]
		[TestCase("AB", 80)]
		public void basket_with_multiple_items_should_return_the_total_price_of_the_items(string basket, int price)
		{
			Assert.That(Calculate(basket), Is.EqualTo(price));
		}

		[TestCase("BB", 45)]
		[TestCase("BBA", 95)]
		[TestCase("AAA", 130)]
		[TestCase("AAAA", 180)]
		[TestCase("AAAAAA", 260)]
		[TestCase("BBBB", 90)]
		[TestCase("BBBBB", 120)]
		[TestCase("AAABB", 175)]
		[TestCase("CC", 20)]
		public void baskets_with_discounts_should_apply_the_discounts(string basket, int price)
		{
			Assert.That(Calculate(basket), Is.EqualTo(price));
		}

		private readonly Dictionary<char, int> _prices = new Dictionary<char, int>
			{
				{'A', 50}, {'B', 30}, {'C', 20}
			};
		private readonly Discount[] _discounts =
			new[] {new Discount('A', 20, 3), new Discount('B', 15, 2), new Discount('C', 20, 2) };

		private int Calculate(string items)
		{
			return CalculateTotal(items) - CalculateDiscounts(items);
		}

		private int CalculateTotal(string items)
		{
			return items.Sum(item => _prices[item]);
		}

		private int CalculateDiscounts(string items)
		{
			return _discounts.Sum(discount => discount.Apply(items));
		}
	}

	public class Discount
	{
		public char Item { get; private set; }
		public int Amount { get; private set; }
		public int Threshold { get; private set; }

		public Discount(char item, int amount, int threshold)
		{
			Item = item;
			Amount = amount;
			Threshold = threshold;
		}

		public int Apply(string items)
		{
			return Amount * (CountItems(items, Item)/Threshold);
		}

		private static int CountItems(string items, char item)
		{
			return items.Count(c => c.Equals(item));
		}
	}
}

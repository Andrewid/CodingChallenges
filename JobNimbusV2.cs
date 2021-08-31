using System;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace JobNimbus
{
	class CodingTest
	{
		static void Main(string[] args)
		{
			args = new string[]{"}early fail}", "{early fail{{", "{}}{{late fail}", "{}}early fail{{{}", "{}early fail{}}", "{{}{{}pass{}}}", "{}{pass}"};
			foreach (string arg in args)
			{
				Console.WriteLine(arg + " - " + ValidateBrackets(arg).ToString());
			}
		}

		public static bool ValidateBrackets(string input)
		{
			// remove all non bracket chars
			var testString = input;
			if (testString.Length > 0)
			{
				testString = Regex.Replace(testString, "[^{-}]*", "");
			}

			if (testString.Length == 0)
			{
				return true;
			}
			// now that there are only "}" or "{" check edge cases
			else if (!(Regex.IsMatch(testString, "^[^}].*[^{]$") && (testString.Length % 2 == 0)))
			{
				Console.WriteLine("early fail");
				return false;
			}
			else
			{
				var removals = 0;
				while (testString.Contains("{}"))
				{
					removals++;
					testString = testString.Replace("{}", "");
				}
				Console.WriteLine(removals + " Removals");
				return (testString.Length == 0);
			}
		}
	}


	[TestCase("{}", true)]
	[TestCase("}{", false)]
	[TestCase("{{}", false)]
	[TestCase("", true)]
	[TestCase("{abc...xyz}", true)]
	public class DefaulValidateBracketsTests
	{
		public void ParseTest(string input, bool expectedResult)
		{
			var result = ValidateBrackets(input);

			Assert.NotNull(result);
			Assert.AreEqual(expectedResult, result);
		}
	}
}
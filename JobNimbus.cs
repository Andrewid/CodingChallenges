​using System;
using System.Text.RegularExpressions;

namespace JobNimbus
{
  class CodingTest
  {
    static void Main(string[] args)
    {
    args = new string [] {"{}","}{","{{}","","{abc...xyz}"};

    foreach (string arg in args)
        {
    Console.WriteLine(arg +" - " + PerformTest(arg).ToString());
        }

    }

    public static bool PerformTest(string input)
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
        else if (Regex.IsMatch(testString, "^[}].*[{]$")
            ||
!(testString.Length % 2 == 0) )
        {
        return false;
}
else
{
        while (testString.Contains("{}"))
            {
            testString = testString.Replace("{}", "");
            }

return (testString.Length == 0);

        }
        //shouldn't get here

    }

  }

}
using System;
using Xunit;
using StringCalculator;

namespace StringCalculatorTests
{
    public class StringCalculatorTests
    {
        [Fact]
        public void EmptyStringReturnsZero()
        {
            int res = StringCalculator.StringCalculator.CalculateString("");
            Assert.Equal(0, res);
        }

        [Theory]
        [InlineData("25", 25)]
        [InlineData("0", 0)]
        [InlineData("5", 5)]
        public void SingleNumberReturnsTheValue(string s, int expected)
        {
            int res = StringCalculator.StringCalculator.CalculateString(s);
            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData("3,6", 9)]
        [InlineData("10,67", 77)]
        [InlineData("1,4", 5)]
        public void TwoNumbersSeparatedByColonReturnsTheSum(string s, int expected)
        {
            int res = StringCalculator.StringCalculator.CalculateString(s);
            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData("3\n6", 9)]
        [InlineData("10\n67", 77)]
        [InlineData("1\n4", 5)]
        public void TwoNumbersSeparatedByNewLineReturnsTheSum(string s, int expected)
        {
            int res = StringCalculator.StringCalculator.CalculateString(s);
            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData("3\n6,1", 10)]
        [InlineData("10\n6\n7", 23)]
        [InlineData("1,5,2", 8)]
        [InlineData("1,5\n2", 8)]
        public void ThreeNumbersSeparatedByNewLineOrColonReturnsTheSum(string s, int expected)
        {
            int res = StringCalculator.StringCalculator.CalculateString(s);
            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData("-5")]
        [InlineData("10\n-6\n7")]
        [InlineData("-1,5,2")]
        [InlineData("1,-5")]
        public void NegativeNumberThrowsTheArgumentException(string s)
        {
            _ = Assert.Throws<ArgumentException>(
                () => StringCalculator.StringCalculator.CalculateString(s)
            );
        }

        [Theory]
        [InlineData("5000", 0)]
        [InlineData("1000\n6\n7", 1013)]
        [InlineData("1001,5,2", 7)]
        [InlineData("1,10000", 1)]
        public void NumbersGreaterThan1000AreIgnored(string s, int expected)
        {
            int res = StringCalculator.StringCalculator.CalculateString(s);
            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData("//#\n5#2,1", 8)]
        [InlineData("//t\n1000t6\n7", 1013)]
        [InlineData("//$\n1,5$2", 8)]
        [InlineData("//g\n1g100", 101)]
        public void InTheFirstLineIsDefinedNewSeparator(string s, int expected)
        {
            int res = StringCalculator.StringCalculator.CalculateString(s);
            Assert.Equal(expected, res);
        }
        [Theory]
        [InlineData("//[#t]\n5#t2,1", 8)]
        [InlineData("//[qwer]\n1000qwer6\n7", 1013)]
        [InlineData("//[fgh]\n1,5fgh2", 8)]
        [InlineData("//[**]\n1**100", 101)]
        public void NewSeparatorAsString(string s, int expected)
        {
            int res = StringCalculator.StringCalculator.CalculateString(s);
            Assert.Equal(expected, res);
        }
    }
}

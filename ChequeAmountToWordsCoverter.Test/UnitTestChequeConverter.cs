using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChequeAmountToWordsCoverter.Test
{
    [TestClass]
    public class UnitTestChequeConverter
    {
        [TestMethod]
        public void TestChequeAmount1()
        {
            var logic = new ChequeAmountToWordsConverter.Logic.ChequeConvertToWords();

            var result = logic.ChequeAmountToWords("1234.56");

            Assert.IsTrue(result.IsSuccessfull);

            Assert.IsTrue(result.NumberInEnglish == "ONE THOUSAND TWO HUNDRED THIRTY-FOUR DOLLARS AND FIFTY-SIX CENTS");
        }

        [TestMethod]
        public void TestChequeAmount2()
        {
            var logic = new ChequeAmountToWordsConverter.Logic.ChequeConvertToWords();

            var result = logic.ChequeAmountToWords("0.22");

            Assert.IsTrue(result.IsSuccessfull);

            Assert.IsTrue(result.NumberInEnglish == "TWENTY-TWO CENTS ONLY");
        }

        [TestMethod]
        public void TestChequeAmount3()
        {
            var logic = new ChequeAmountToWordsConverter.Logic.ChequeConvertToWords();

            var result = logic.ChequeAmountToWords("102.03");

            Assert.IsTrue(result.IsSuccessfull);

            Assert.IsTrue(result.NumberInEnglish == "ONE HUNDRED TWO DOLLARS AND THREE CENTS");
        }

        [TestMethod]
        public void TestChequeAmount4()
        {
            var logic = new ChequeAmountToWordsConverter.Logic.ChequeConvertToWords();

            var result = logic.ChequeAmountToWords("1.021");

            Assert.IsTrue(result.IsSuccessfull);

            Assert.IsTrue(result.NumberInEnglish == "ONE DOLLAR AND TWO CENTS");
        }

        [TestMethod]
        public void TestChequeAmount5()
        {
            var logic = new ChequeAmountToWordsConverter.Logic.ChequeConvertToWords();

            var result = logic.ChequeAmountToWords("1.23987");

            Assert.IsTrue(result.IsSuccessfull);

            Assert.IsTrue(result.NumberInEnglish == "ONE DOLLAR AND TWENTY-THREE CENTS");
        }

        [TestMethod]
        public void TestChequeAmount6()
        {
            var logic = new ChequeAmountToWordsConverter.Logic.ChequeConvertToWords();

            var result = logic.ChequeAmountToWords("00012.85");

            Assert.IsTrue(result.IsSuccessfull);

            Assert.IsTrue(result.NumberInEnglish == "TWELVE DOLLARS AND EIGHTY-FIVE CENTS");
        }

        [TestMethod]
        public void TestMinusInputValue()
        {
            var logic = new ChequeAmountToWordsConverter.Logic.ChequeConvertToWords();

            var result = logic.ChequeAmountToWords("-1234.56");

            Assert.IsTrue(!result.IsSuccessfull);

            Assert.IsTrue(result.Error == "Input cannot be a negative number");
        }

        [TestMethod]
        public void TestDollarSignInputValue()
        {
            var logic = new ChequeAmountToWordsConverter.Logic.ChequeConvertToWords();

            var result = logic.ChequeAmountToWords("$1234.56");

            Assert.IsTrue(result.IsSuccessfull);

            Assert.IsTrue(result.NumberInEnglish == "ONE THOUSAND TWO HUNDRED THIRTY-FOUR DOLLARS AND FIFTY-SIX CENTS");
        }

        [TestMethod]
        public void TestWithNonNumberInputValue()
        {
            var logic = new ChequeAmountToWordsConverter.Logic.ChequeConvertToWords();

            var result = logic.ChequeAmountToWords("1234.56W");

            Assert.IsTrue(!result.IsSuccessfull);

            Assert.IsTrue(result.Error == "Input cannot contain anything other than numbers");
        }

        [TestMethod]
        public void TestWithZeroInputValue()
        {
            var logic = new ChequeAmountToWordsConverter.Logic.ChequeConvertToWords();

            var result = logic.ChequeAmountToWords("0");

            Assert.IsTrue(!result.IsSuccessfull);

            Assert.IsTrue(result.Error == "Input cannot be Zero");
        }

        [TestMethod]
        public void TestInvalidInputValue()
        {
            var logic = new ChequeAmountToWordsConverter.Logic.ChequeConvertToWords();

            var result = logic.ChequeAmountToWords("1034.56.9");

            Assert.IsTrue(!result.IsSuccessfull);

            Assert.IsTrue(result.Error == "Not a valid input");
        }
    }
}

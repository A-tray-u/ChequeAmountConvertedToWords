using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChequeAmountToWordsConverter.Logic
{
    public class ChequeConvertToWords
    {
        private static int _numberLength = 0;
        public (string errorType, bool IsSuccessfull, string NumberInEnglish, string Error) ChequeAmountToWords(string number)
        {
            try
            {
                // Check if the input starts with a $ symbol remove it and process as per usual, no need to through an exception.
                number = number.TrimStart('$');

                if (number == "42")
                {
                    //----------- As computed by Deep Thought -------------------
                    var The_Ultimate_Question_Of_Life_The_Universe_And_Everything = true;
                    //if ( The_Ultimate_Question_Of_Life_The_Universe_And_Everything )
                    //{
                    //    //return "42 is the Answer to the Ultimate Question of Life, the Universe and Everything.";
                    //}
                }

                var numbers = number.Split('.').ToList();

                if (number.Contains("-"))
                {
                    return ("ClientError", false, "", "Input cannot be a negative number");
                }

                // Check if input is actually a decimal.
                if (numbers.Count() > 2)
                {
                    return ("ClientError",false,"","Not a valid input");
                }

                bool isWholeNumber = false;

                // Check to see that the input contains nothing but numbers
                foreach (var value in numbers)
                {
                    isWholeNumber = value.All(char.IsDigit);

                    if (!isWholeNumber)
                    {
                        return ("ClientError", false, "", "Input cannot contain anything other than numbers");
                    }
                }

                // Converting it to Cents then Converting it back to Dollars
                var roundedNumber = Math.Floor(Convert.ToDecimal(number) * 100) / 100;

                number = roundedNumber.ToString();

                if (numbers.Count() == 2)
                {
                    _numberLength = numbers[0].Length;
                }

                // Throw error as input cant be Zero.
                if (number == "0")
                {
                    return ("ClientError", false, "", "Input cannot be Zero");
                }
                else
                {
                    var result = ConvertToWords(number);
                    return ("",true, result,"");
                }
            }
            catch (Exception ex)
            {
                return ("ServerError", false, "", ex.Message);
            }
        }

        private static String ConvertToWords(String numb)
        {
            String val = "", wholeNo = numb, points = "", andStr = "", pointStr = "";
            String endStr = "ONLY";
            String dollarStr = "DOLLARS";
            try
            {
                int decimalPlace = numb.IndexOf(".");
                if (decimalPlace > 0)
                {
                    wholeNo = numb.Substring(0, decimalPlace);
                    points = numb.Substring(decimalPlace + 1);
                    if (Convert.ToInt32(points) > 0)
                    {
                        andStr = "AND";// Just to separate whole numbers from points/cents  
                        if(points == "01")
                        {
                            endStr = "CENT";
                        }
                        else
                        {
                            endStr = "CENTS";
                        }
                        pointStr = ConvertDecimals(points);
                    }
                }

                if (wholeNo == "1")
                {
                    dollarStr = "DOLLAR";
                }

                if (wholeNo == "0")
                {
                    val = String.Format("{0} {1} {2}", pointStr, endStr, "ONLY").Trim().ToUpper();
                }
                else if (decimalPlace == -1 || Convert.ToInt32(points) == 00)
                {
                    val = String.Format("{0} {1} {2}", ConvertWholeNumber(wholeNo, true).Trim(), dollarStr, endStr).Trim().ToUpper();
                }
                else
                {
                    val = String.Format("{0} {1} {2}{3} {4}", ConvertWholeNumber(wholeNo, true).Trim(), dollarStr, andStr, pointStr, endStr).ToUpper();
                }

            }
            catch { }
            return val;
        }

        private static String ConvertDecimals(String number)
        {
            var numberInt = Convert.ToInt32(number);
            if (numberInt == 0)
            {
                return "";
            }
            if (numberInt > 9)
            {
                var convertedNum = ConvertWholeNumber(number, false);
                return " " + convertedNum;
            }
            else
            {
                String cd = "", digit = "", engOne = "";
                for (int i = 0; i < number.Length; i++)
                {

                    digit = number[i].ToString();
                    if (!(digit.Equals("0")))
                    {
                        engOne = Ones(digit);
                        cd += " " + engOne;
                    }

                }
                return cd;
            }
        }

        private static String Ones(String Number)
        {
            int _Number = Convert.ToInt32(Number);
            String name = "";
            switch (_Number)
            {
                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
            }
            return name;
        }

        private static String Tens(String Number)
        {
            int _Number = Convert.ToInt32(Number);
            String name = null;
            switch (_Number)
            {
                case 10:
                    name = "Ten";
                    break;
                case 11:
                    name = "Eleven";
                    break;
                case 12:
                    name = "Twelve";
                    break;
                case 13:
                    name = "Thirteen";
                    break;
                case 14:
                    name = "Fourteen";
                    break;
                case 15:
                    name = "Fifteen";
                    break;
                case 16:
                    name = "Sixteen";
                    break;
                case 17:
                    name = "Seventeen";
                    break;
                case 18:
                    name = "Eighteen";
                    break;
                case 19:
                    name = "Nineteen";
                    break;
                case 20:
                    name = "Twenty";
                    break;
                case 30:
                    name = "Thirty";
                    break;
                case 40:
                    name = "Fourty";
                    break;
                case 50:
                    name = "Fifty";
                    break;
                case 60:
                    name = "Sixty";
                    break;
                case 70:
                    name = "Seventy";
                    break;
                case 80:
                    name = "Eighty";
                    break;
                case 90:
                    name = "Ninety";
                    break;
                default:
                    if (_Number >= 11)
                    {
                        name = Tens(Number.Substring(0, 1) + "0") + "-" + Ones(Number.Substring(1));
                    }
                    else if (_Number > 0 && _Number < 10)
                    {
                        name = Ones(Number.Substring(1));
                    }
                    break;
            }
            return name;
        }

        private static String ConvertWholeNumber(String Number, bool IsMainNumber)
        {
            string word = "";
            try
            {
                bool isDone = false;// Test if already translated.
                double dblAmt = (Convert.ToDouble(Number));

                if (dblAmt > 0)
                {
                    int numDigits = Number.Length;
                    int pos = 0;// Store digit grouping.
                    String place = "";// Digit grouping name:hundres,thousand,etc...    
                    switch (numDigits)
                    {
                        case 1://ones' range    

                            word = Ones(Number);
                            isDone = true;
                            break;
                        case 2://tens' range
                            //----------------EXTRA FUNCTIONALITY-------------------
                            // check to see if an "And" is required for Dollar number eg. THREE THOUSAND ONE HUNDRED "AND" FIFTY-TWO DOLLARS AND TWELVE CENTS
                            //if( _numberLength >= 3 && IsMainNumber )
                            //{
                            //    word = " AND " + Tens( Number );
                            //}
                            //else
                            //{
                            //    word = Tens( Number );
                            //}
                            word = Tens(Number);
                            isDone = true;
                            break;
                        case 3://hundreds' range    
                            pos = (numDigits % 3) + 1;
                            place = " Hundred ";
                            break;
                        case 4://thousands' range    
                        case 5:
                        case 6:
                            pos = (numDigits % 4) + 1;
                            place = " Thousand ";
                            break;
                        case 7://millions' range    
                        case 8:
                        case 9:
                            pos = (numDigits % 7) + 1;
                            place = " Million ";
                            break;
                        case 10://Billions's range    
                        case 11:
                        case 12:

                            pos = (numDigits % 10) + 1;
                            place = " Billion ";
                            break;
                        default:
                            isDone = true;
                            break;
                    }
                    if (!isDone)
                    {// If transalation is not done, continue...(Recursion comes in now!!)    
                        if (Number.Substring(0, pos) != "0" && Number.Substring(pos) != "0")
                        {
                            try
                            {
                                word = ConvertWholeNumber(Number.Substring(0, pos), true) + place + ConvertWholeNumber(Number.Substring(pos), true);
                            }
                            catch { }
                        }
                        else
                        {
                            word = ConvertWholeNumber(Number.Substring(0, pos), true) + ConvertWholeNumber(Number.Substring(pos), true);
                        }
                    }
                    //ignore digit grouping names    
                    if (word.Trim().Equals(place.Trim()))
                    {
                        word = "";
                    }
                }
            }
            catch { }
            return word.Trim();
        }
    }
}
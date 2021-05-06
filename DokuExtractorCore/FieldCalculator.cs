using DokuExtractorCore.Model;
using Sprache.Calc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorCore
{
    /// <summary>
    /// Allows to perform calculations with value from data fields
    /// </summary>
    public class FieldCalculator
    {
        /// <summary>
        /// Calculates the value for a given calculation field based on the supplied datafields (if datafields are part of the calculation expression)
        /// </summary>
        /// <param name="calculationField"></param>
        /// <param name="datafields"></param>
        /// <returns></returns>
        public double Calculate(CalculationFieldTemplate calculationField, List<DataFieldResult> datafields)
        {
            return Calculate(calculationField.CalculationExpression, calculationField.CalculationExpressionPrecision, datafields);
        }

        /// <summary>
        /// Calculates the value for a given calculation expression based on the supplied datafields (if datafields are part of the calculation expression)
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="precision"></param>
        /// <param name="datafields"></param>
        /// <returns></returns>
        public double Calculate(string expression, int precision, List<DataFieldResult> datafields)
        {
            var filledExpression = expression;

            if (string.IsNullOrEmpty(filledExpression) == false)
            {
                foreach (var item in datafields)
                {
                    if (item.FieldType == DataFieldType.Currency)
                        filledExpression = filledExpression.Replace("[" + item.Name + "]", MakeCurrencyTextParseableAsFloat(item.Value));
                    else
                        filledExpression = filledExpression.Replace("[" + item.Name + "]", item.Value.Replace(',', '.').Replace(" ", string.Empty).Replace("'", string.Empty));
                }

                var calculator = new XtensibleCalculator();
                var linqExpression = calculator.ParseExpression(filledExpression);
                var linqFunction = linqExpression.Compile();

                var retVal = linqFunction();
                if (precision >= 0)
                    retVal = Math.Round(retVal, precision);

                return retVal;
            }
            else
                return 0;
        }

        /// <summary>
        /// Calculates the content of a CalculationFieldTemplate based on the given datafields
        /// </summary>
        /// <param name="calculationField"></param>
        /// <param name="datafields"></param>
        /// <returns></returns>
        public CalculationFieldResult CompareExpressionResults(CalculationFieldTemplate calculationField, List<DataFieldResult> datafields)
        {
            var retVal = CompareExpressionResults(calculationField.CalculationExpression, calculationField.CalculationExpressionPrecision,
                calculationField.ValidationExpressions, calculationField.CalculationExpressionPrecision, datafields);
            retVal.Name = calculationField.Name;
            retVal.FieldType = calculationField.FieldType;
            return retVal;
        }

        /// <summary>
        /// First calculates the value for a given calculation expression and all given validation expressions based on the supplied datafields (if datafields are part of the calculation expression)
        /// Then checks if the calculation result value matches at least one validation result value.
        /// </summary>
        /// <param name="calculationExpression"></param>
        /// <param name="calculationValuePrecision"></param>
        /// <param name="validationExpressions"></param>
        /// <param name="validationValuePrecision"></param>
        /// <param name="datafields"></param>
        /// <returns></returns>
        public CalculationFieldResult CompareExpressionResults(string calculationExpression, int calculationValuePrecision, List<string> validationExpressions, int validationValuePrecision, List<DataFieldResult> datafields)
        {
            var retVal = new CalculationFieldResult();
            retVal.ValidationValues = new List<double>();
            retVal.CalculationValue = Calculate(calculationExpression, calculationValuePrecision, datafields);
            foreach (var item in validationExpressions)
            {
                retVal.ValidationValues.Add(Calculate(item, validationValuePrecision, datafields));
            }

            retVal.CalculationEqualsValidation = retVal.ValidationValues.Contains(retVal.CalculationValue);
            return retVal;
        }

        /// <summary>
        /// Preprocesses a currency type string value so that it can later be parsed as a float / double value. Helps e.g. to turn "5,000,83"/"5.000,83"/"5,000.83" to "5000.83" 
        /// </summary>
        /// <param name="inputText"></param>
        /// <returns></returns>
        public string MakeCurrencyTextParseableAsFloat(string inputText)
        {
            if (string.IsNullOrEmpty(inputText))
                return "0";

            var retVal = inputText.Replace("‚", ",").Replace(" ", string.Empty).Replace("'", string.Empty); // Replace Comma with ASCII Code Dec130 with comma with ASCII Code Dec44 to unfuck OCR results

            retVal = retVal.Replace(".", ",").TrimEnd(','); // Prepare decimal seperator magic by setting als seperators to ','...

            var tempArray = retVal.ToCharArray();

            if (tempArray.Length >= 2)                      // ...and then replacing the ',' (which is supposed to be a decimal seperator and not a seperator for thousands) based on its position. If it is the second or third last character of a number, it's assumed to be the decimal seperator.
            {
                if (tempArray[tempArray.Length - 2] == ',')
                    tempArray[tempArray.Length - 2] = '.';
            }
            if (tempArray.Length >= 3)
            {
                if (tempArray[tempArray.Length - 3] == ',')
                    tempArray[tempArray.Length - 3] = '.';
            }

            retVal = string.Concat(tempArray);

            // The input text is sanitized and ready to be parsed to double by the actual parser.
            // TODO: Stabilize function against further funny characters from OCR


            double.TryParse(retVal, System.Globalization.NumberStyles.Currency, CultureInfo.InvariantCulture.NumberFormat, out double temp);

            return temp.ToString(CultureInfo.InvariantCulture);
        }
    }
}
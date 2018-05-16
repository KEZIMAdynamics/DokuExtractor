﻿using DokuExtractorCore.Model;
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
        public double Calculate(CalculationFieldTemplate calculationField, List<DataFieldResult> datafields)
        {
            return Calculate(calculationField.CalculationExpression, calculationField.CalculationExpressionPrecision, datafields);
        }

        public double Calculate(string expression, int precision, List<DataFieldResult> datafields)
        {
            var filledExpression = expression;

            if (string.IsNullOrEmpty(filledExpression) == false)
            {
                foreach (var item in datafields)
                {
                    if (item.FieldType == DataFieldTypes.Currency)
                        filledExpression = filledExpression.Replace("[" + item.Name + "]", MakeCurrencyTextParseableAsFloat(item.Value));
                    else
                        filledExpression = filledExpression.Replace("[" + item.Name + "]", item.Value.Replace(',', '.'));
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

        public string MakeCurrencyTextParseableAsFloat(string inputText)
        {
            if (string.IsNullOrEmpty(inputText))
                return "0";

            var retVal = inputText.Replace("‚", ","); // Replce Comma with ASCII Code Dec130 with comma with ASCII Code Dec44 to unfuck OCR results
            // TODO: Stabilize function against further funny characters

            var temp = double.Parse(retVal, System.Globalization.NumberStyles.Currency);

            return temp.ToString(CultureInfo.InvariantCulture);

            //if (inputText.Contains(',') && inputText.Contains('.'))
            //{
            //    if (inputText.IndexOf(',')<inputText.IndexOf('.')
            //        retva
            //}
        }
    }
}
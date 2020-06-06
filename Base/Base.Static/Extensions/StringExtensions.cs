using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Base.Static.Enumerate;

namespace Base.Static.Extensions
{
    public static class StringExtensions
    {
        private static Regex RegexForUnsignText;

        private static readonly List<char> _standardChars = new List<char>
        {
            'a', 'b', 'c', 'd', 'd', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u',
            'v', 'w', 'x', 'y', 'z',
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
        };

        public static string ToUnsignText(this string text)
        {
            if (ReferenceEquals(RegexForUnsignText, null))
                RegexForUnsignText = new Regex("p{IsCombiningDiacriticalMarks}+");
            var temp = text.Normalize(NormalizationForm.FormD);
            return RegexForUnsignText.Replace(temp, string.Empty).Replace("đ", "d").Replace("Đ", "D");
        }

        public static string RemoveSpecialCharacters(this string text)
        {
            var result = Regex.Replace(text, "[^a-zA-Z0-9 ]", string.Empty);
            return result;
        }

        public static List<string> ToListSubstring(this string input, string separator)
        {
            if (string.IsNullOrWhiteSpace(input))
                return new List<string>();
            var elements = input.Split(separator);
            return elements.ToList();
        }

        public static List<int> ToListInteger(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return new List<int>();
            var elements = input.Split(",");
            return elements.Select(s => int.Parse(s)).ToList();
        }

        public static List<int> ToListEnumerationValue<T>(this string input, string title = null) where T : Enumeration
        {
            if (string.IsNullOrWhiteSpace(input))
                return new List<int>();
            var inputElements = input.Split(",");
            var availableNames = Enumeration.GetAll<T>().Select(s => s.Name).ToList();

            var invalidStatuses = inputElements.Where(w => !availableNames.Contains(w));
            if (invalidStatuses.Count() > 0)
                throw new Exception(string.Format("{0} must be in ({1})", title ?? "value",
                    string.Join(',', availableNames)));
            return inputElements.Select(s => Enumeration.FromDisplayName<T>(s).Id).ToList();
        }

        public static string NormalizeD(this string input)
        {
            return input.Normalize(NormalizationForm.FormD);
        }

        public static bool EqualTo(this string text1, string text2)
        {
            if (text1 == null && text2 == null)
                return true;
            if (text1 == null && text2 != null)
                return false;
            if (text1 != null && text2 == null)
                return false;
            return text1.Equals(text2);
        }

        public static bool TrimEquals(string text1, string text2)
        {
            if (!string.IsNullOrWhiteSpace(text1))
                text1 = text1.Trim();
            if (!string.IsNullOrWhiteSpace(text2))
                text2 = text2.Trim();

            if (text1 == null && text2 == null)
                return true;
            if (text1 == null && text2 != null)
                return false;
            if (text1 != null && text2 == null)
                return false;
            return text1.Equals(text2);
        }

        private static List<int> ToCharVector(this string text)
        {
            var lowerUnsignText = text.ToUnsignText().ToLower();

            var result = _standardChars.Select(s => lowerUnsignText.Count(c => c == s)).ToList();
            return result;
        }

        private static double CalculatorCosin(List<int> vector1, List<int> vector2)
        {
            double tichVoHuong = 0;
            double tichDoDai = 0;
            for (var i = 0; i < vector1.Count; i++)
                tichVoHuong += vector1[i] * vector2[i];

            var vector1Dai = Math.Sqrt(vector1.Select(s => (double) (s * s)).Sum());
            var vector2Dai = Math.Sqrt(vector2.Select(s => (double) (s * s)).Sum());

            var cos = tichVoHuong / (vector1Dai * vector2Dai);
            return Math.Round(cos, 5, MidpointRounding.AwayFromZero);
        }

        public static int GetClosestText(this string text, List<string> targets, int round)
        {
            var result = new List<int>();
            for (var i = 0; i < targets.Count; i++)
            {
                if (text.Trim() == targets[i].Trim())
                    return i;

                result.Add(i);
            }


            for (var i = 1; i <= round; i++)
            {
                var currentText = text.Substring(0, text.Length / i);
                var currentTargets = targets.Select(s => s.Substring(0, s.Length / i)).ToList();

                var textVector = currentText.ToCharVector();
                var targetVectors = currentTargets.Select(s => s.ToCharVector()).ToList();

                var cosinValues = targetVectors.Select(s => CalculatorCosin(textVector, s)).ToList();
                var maxCosinValue = cosinValues.Max();

                var currentRoundResult = new List<int>();
                for (var j = 0; j < cosinValues.Count; j++)
                    if (cosinValues[j] == maxCosinValue)
                        currentRoundResult.Add(j);
                result = result.Intersect(currentRoundResult).ToList();
            }

            if (result.Count == 1)
                return result[0];

            if (result.Count == 0)
                throw new Exception("Notfound");
            if (result.Count > 0)
                return result[0];

            throw new Exception("unknown");
        }
    }
}
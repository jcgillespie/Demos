namespace DudeDemo
{
    using System;

    public class CopyPaste
    {
        public string EnsureFixedLength(string someString, int length)
        {
            string rightLengthString;
            if (string.IsNullOrWhiteSpace(someString))
            {
                throw new ArgumentNullException("someString");
            }

            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException("length", "length must be a positive integer");
            }

            if (someString.Length < length)
            {
                rightLengthString = someString.PadRight(length);
            }
            else if (someString.Length > length)
            {
                rightLengthString = someString.Substring(0, length);
            }
            else
            {
                rightLengthString = someString;
            }

            return rightLengthString;
        }

        public string EnsureMaxLength(string someString, int maxLength)
        {
            if (string.IsNullOrWhiteSpace(someString))
            {
                throw new ArgumentNullException("someString");
            }

            if (maxLength <= 0)
            {
                throw new ArgumentOutOfRangeException("maxLength", "maxLength must be a positive integer");
            }

            return someString.Substring(0, maxLength);
        }

        public string EnsureMinLength(string someString, int minLength)
        {
            if (string.IsNullOrWhiteSpace(someString))
            {
                throw new ArgumentNullException("someString");
            }

            if (minLength <= 0)
            {
                throw new ArgumentOutOfRangeException("minLength", "minLength must be a positive integer");
            }

            return someString.PadRight(minLength);
        }
    }
}
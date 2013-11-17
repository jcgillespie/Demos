namespace MyLibrary
{
    using System;
    using System.Diagnostics.Contracts;

    public class StringLengthUtility
    {
        public string EnsureFixedLength(string someString, int length)
        {
            Contract.Requires<ArgumentNullException>(someString != null);
            Contract.Requires<ArgumentOutOfRangeException>(length >= 0);

            string rightLengthString;

            if (someString.Length < length)
            {
                rightLengthString = this.EnsureMinLength(someString, length);
            }
            else if (someString.Length > length)
            {
                rightLengthString = this.EnsureMaxLength(someString, length);
            }
            else
            {
                rightLengthString = someString;
            }

            return rightLengthString;
        }

        public string EnsureMaxLength(string someString, int maxLength)
        {
            Contract.Requires<ArgumentNullException>(someString != null);
            Contract.Requires<ArgumentOutOfRangeException>(maxLength >= 0);

            return someString.Substring(0, maxLength);
        }

        public string EnsureMinLength(string someString, int minLength)
        {
            Contract.Requires<ArgumentNullException>(someString != null);
            Contract.Requires<ArgumentOutOfRangeException>(minLength >= 0);

            return someString.PadRight(minLength);
        }
    }
}
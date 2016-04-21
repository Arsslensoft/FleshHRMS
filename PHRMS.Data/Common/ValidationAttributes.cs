using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace PHRMS.Data
{
    public abstract class RegexAttributeBase : DataTypeAttribute
    {
        protected const RegexOptions DefaultRegexOptions =
            RegexOptions.Compiled | RegexOptions.ExplicitCapture | RegexOptions.IgnoreCase;

        private readonly Regex regex;

        public RegexAttributeBase(string regex, string defaultErrorMessage, DataType dataType)
            : this(new Regex(regex, DefaultRegexOptions), defaultErrorMessage, dataType)
        {
        }

        public RegexAttributeBase(Regex regex, string defaultErrorMessage, DataType dataType)
            : base(dataType)
        {
            this.regex = regex;
            ErrorMessage = defaultErrorMessage;
        }

        public sealed override bool IsValid(object value)
        {
            if (value == null)
                return true;
            var input = value as string;
            return input != null && regex.Match(input).Length > 0;
        }
    }

    public sealed class PhoneAttribute : RegexAttributeBase
    {
        private const string Message = "The {0} field is not a valid phone number.";
        private static readonly Regex regex = new Regex(@"\+\d{1,3}\s\d\d\d\d\d\d\d\d", DefaultRegexOptions);

        public PhoneAttribute()
            : base(regex, Message, DataType.PhoneNumber)
        {
        }
    }

    public sealed class EmailAddressAttribute : RegexAttributeBase
    {
        private const string Message = "The {0} field is not a valid e-mail address.";

        private static readonly Regex regex =
            new Regex(
                @"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$",
                DefaultRegexOptions);

        public EmailAddressAttribute()
            : base(regex, Message, DataType.EmailAddress)
        {
        }
    }

    public sealed class UrlAttribute : RegexAttributeBase
    {
        private const string Message = "The {0} field is not a valid fully-qualified http, https, or ftp URL.";

        private static readonly Regex regex =
            new Regex(
                @"^(https?|ftp):\/\/(((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:)*@)?(((\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5]))|((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?)(:\d*)?)(\/((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)+(\/(([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)*)*)?)?(\?((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)|[\uE000-\uF8FF]|\/|\?)*)?(\#((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)|\/|\?)*)?$",
                DefaultRegexOptions);

        public UrlAttribute()
            : base(regex, Message, DataType.Url)
        {
        }
    }

    public sealed class ZipCodeAttribute : RegexAttributeBase
    {
        private const string Message = "The {0} field is not a valid ZIP code.";
        private static readonly Regex regex = new Regex(@"^[0-9][0-9][0-9][0-9]$", DefaultRegexOptions);

        public ZipCodeAttribute()
            : base(regex, Message, DataType.Url)
        {
        }
    }

    public sealed class CINAttribute : RegexAttributeBase
    {
        private const string Message = "The {0} field is not a valid CIN code.";

        private static readonly Regex regex = new Regex(@"^[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]$",
            DefaultRegexOptions);

        public CINAttribute()
            : base(regex, Message, DataType.Url)
        {
        }
    }

    public sealed class CreditCardAttribute : DataTypeAttribute
    {
        private const string Message = "The {0} field is not a valid credit card number.";

        public CreditCardAttribute()
            : base(DataType.Custom)
        {
            ErrorMessage = Message;
        }

        public override bool IsValid(object value)
        {
            if (value == null)
                return true;
            var stringValue = value as string;
            if (stringValue == null)
                return false;
            stringValue = stringValue.Replace("-", "").Replace(" ", "");
            var number = 0;
            var oddEvenFlag = false;
            foreach (var ch in stringValue.Reverse())
            {
                if (ch < '0' || ch > '9')
                    return false;
                var digitValue = (ch - '0')*(oddEvenFlag ? 2 : 1);
                oddEvenFlag = !oddEvenFlag;
                while (digitValue > 0)
                {
                    number += digitValue%10;
                    digitValue = digitValue/10;
                }
            }
            return number%10 == 0;
        }
    }
}
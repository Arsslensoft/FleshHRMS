using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PHRMS.Data
{
    public static class IDataErrorInfoHelper
    {
        public static string GetErrorText(object owner, string propertyName)
        {
            var path = propertyName.Split('.');
            if (path.Length > 1)
                return GetErrorText(owner, path);
            var propertyInfo = owner.GetType().GetProperty(propertyName);
            if (propertyInfo == null) return null;
            var propertyValue = propertyInfo.GetValue(owner, null);
            var validationContext = new ValidationContext(owner, null, null) {MemberName = propertyName};
            var errors = propertyInfo
                .GetCustomAttributes(false)
                .OfType<ValidationAttribute>()
                .Select(x => x.GetValidationResult(propertyValue, validationContext))
                .Where(x => x != null)
                .Select(x => x.ErrorMessage)
                .Where(x => !string.IsNullOrEmpty(x))
                .ToArray();
            return string.Join(" ", errors);
        }

        private static string GetErrorText(object owner, string[] path)
        {
            var nestedPropertyName = string.Join(".", path.Skip(1));
            var propertyName = path[0];
            var propertyInfo = owner.GetType().GetProperty(propertyName);
            if (propertyInfo == null)
                return null;
            var propertyValue = propertyInfo.GetValue(owner, null);
            var nestedDataErrorInfo = propertyValue as IDataErrorInfo;
            return nestedDataErrorInfo == null ? string.Empty : nestedDataErrorInfo[nestedPropertyName];
        }
    }
}
using System.ComponentModel.DataAnnotations;

namespace Gibe.Validation
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class WhitelistAttribute(string whitelist) : ValidationAttribute
    {
		private readonly char[] _whitelist = whitelist.ToCharArray();

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			var s = value as string;
            if (s == null)
            {
                return ValidationResult.Success;
            }

			var chars = s.ToCharArray();
			return chars.Any(c => !_whitelist.Contains(c)) 
                ? new ValidationResult(FormatErrorMessage(validationContext.DisplayName)) 
                : ValidationResult.Success;
		}
	}

    public static class Whitelists
    {
        public const string SingleText = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789 !.,;:<=>\"£'?@#=-_+~\\/()*&^%$¡¿ÄäÀàÁáÂâÃãÅåǍǎĄąĂăÆæĀāÇçĆćĈĉČčĎđĐďðÈèÉéÊêËëĚěĘęĖėĒēĜĝĢģĞğĤĥÌìÍíÎîÏïıĪīĮįĴĵĶķĹĺĻļŁłĽľÑñŃńŇňŅņÖöÒòÓóÔôÕõŐőØøŒœŔŕŘřẞßŚśŜŝŞşŠšȘșŤťŢţÞþȚțÜüÙùÚúÛûŰűŨũŲųŮůŪūŴŵÝýŸÿŶŷŹźŽžŻż";
        public const string MultiText = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789 !.,;:<=>\"£'?@#=-_+~\\/()*&^%$¡¿ÄäÀàÁáÂâÃãÅåǍǎĄąĂăÆæĀāÇçĆćĈĉČčĎđĐďðÈèÉéÊêËëĚěĘęĖėĒēĜĝĢģĞğĤĥÌìÍíÎîÏïıĪīĮįĴĵĶķĹĺĻļŁłĽľÑñŃńŇňŅņÖöÒòÓóÔôÕõŐőØøŒœŔŕŘřẞßŚśŜŝŞşŠšȘșŤťŢţÞþȚțÜüÙùÚúÛûŰűŨũŲųŮůŪūŴŵÝýŸÿŶŷŹźŽžŻż\r\n";
        public const string Title = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz -'.";
        public const string Name = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789' -¡¿ÄäÀàÁáÂâÃãÅåǍǎĄąĂăÆæĀāÇçĆćĈĉČčĎđĐďðÈèÉéÊêËëĚěĘęĖėĒēĜĝĢģĞğĤĥÌìÍíÎîÏïıĪīĮįĴĵĶķĹĺĻļŁłĽľÑñŃńŇňŅņÖöÒòÓóÔôÕõŐőØøŒœŔŕŘřẞßŚśŜŝŞşŠšȘșŤťŢţÞþȚțÜüÙùÚúÛûŰűŨũŲųŮůŪūŴŵÝýŸÿŶŷŹźŽžŻż";
        public const string Int = "0123456789";
        public const string Decimal = "0123456789.";
        public const string PhoneNumber = "+()0123456789- ";
        public const string Email = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789@-_+.#~!$&'()*+,;=: \"<>[\\]";
    }
}

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Gibe.Validation
{
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
	public class HttpPostedFileExtensionsAttribute : ValidationAttribute
	{
		private IEnumerable<string> ValidExtensions { get; }

		public HttpPostedFileExtensionsAttribute(string fileExtensions)
		{
			ValidExtensions = fileExtensions.Split(',').Select(ve=>ve.ToLower());
		}

		public override bool IsValid(object? value)
		{
			IEnumerable<IFormFile?>? files = null;

			if (value is IEnumerable<IFormFile?> enumerable)
			{
				files = enumerable;
			}
			else if (value is IFormFile file)
			{
				files = [file];
			}

			if (files == null) return true;

			var verdict = true;

			foreach (var file in files)
			{
				if (file == null) continue;

				var fileExtension = Path.GetExtension(file.FileName);

				if (string.IsNullOrEmpty(fileExtension))
				{
					verdict = false;
					break;
				}

				if (ValidExtensions.Contains(fileExtension.Substring(1).ToLower())) continue;

				verdict = false;
				break;
			}

			return verdict;
		}
	}
}
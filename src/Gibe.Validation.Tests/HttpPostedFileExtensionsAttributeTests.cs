using Microsoft.AspNetCore.Http;
using Moq;
using NUnit.Framework;

namespace Gibe.Validation.Tests
{
	[TestFixture]
	public class HttpPostedFileExtensionsAttributeTests
	{
		[Test]
		public void IsValid_Returns_True_If_No_Files_Are_Passed()
		{
			var validator = new HttpPostedFileExtensionsAttribute("jpg");

			var verdict = validator.IsValid(string.Empty);

			Assert.That(verdict, Is.True);
		}

		[Test]
		public void IsValid_Returns_True_For_Single_File_With_The_Correct_Extension()
		{
			var file = new Mock<IFormFile>();
			file.Setup(x => x.FileName).Returns("file.jpg");

			var validator = new HttpPostedFileExtensionsAttribute("jpg");

			var verdict = validator.IsValid(file.Object);

			Assert.That(verdict, Is.True);
		}

		[Test]
		public void IsValid_Returns_False_For_Single_File_With_An_Incorrect_Extension()
		{
			var file = new Mock<IFormFile>();
			file.Setup(x => x.FileName).Returns("file.pdf");

			var validator = new HttpPostedFileExtensionsAttribute("jpg");

			var verdict = validator.IsValid(file.Object);

			Assert.That(verdict, Is.False);
		}

		[Test]
		public void IsValid_Returns_True_For_Multiple_Files_With_The_Correct_Extension()
		{
			var fileOne = new Mock<IFormFile>();
			fileOne.Setup(x => x.FileName).Returns("file-one.jpg");

			var fileTwo = new Mock<IFormFile>();
			fileTwo.Setup(x => x.FileName).Returns("file-two.jpg");

			var validator = new HttpPostedFileExtensionsAttribute("jpg");

			var verdict = validator.IsValid(new[] { fileOne.Object, fileTwo.Object });

			Assert.That(verdict, Is.True);
		}

		[Test]
		public void IsValid_Returns_False_For_Multiple_Files_With_An_Incorrect_Extension()
		{
			var fileOne = new Mock<IFormFile>();
			fileOne.Setup(x => x.FileName).Returns("file-one.jpg");

			var fileTwo = new Mock<IFormFile>();
			fileTwo.Setup(x => x.FileName).Returns("file-two.png");

			var validator = new HttpPostedFileExtensionsAttribute("jpg");

			var verdict = validator.IsValid(new[] { fileOne.Object, fileTwo.Object });

			Assert.That(verdict, Is.False);
		}
	}
}

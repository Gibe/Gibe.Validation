# Gibe.Validation

Attributes for validation during model binding in ASP.NET Core MVC.

| Attribute                  | Description      | Example          |
|----------------------------|------------------|------------------|
| `[Whitelist(<whitelist>)]` | Whitelists a field to ensure only a specific set of characters are allowed in that field | `[Whitelist("abc123")]` allows only the characters 'a', 'b', 'c', '1', '2', and '3' in the field. |
| `[FileExtensions()]`       | Validates that the file extension of any uploaded files is among a specified set of allowed extensions. | `[FileExtensions("jpg,jpeg,png")]` allows only files with the extensions .jpg, .jpeg, and .png. |


## Installation

`dotnet add package Gibe.Validation`

## Usage

To use the validation attributes, simply apply them to the properties of your model classes. For example:

```csharp	
public class UserViewModel
{
	[Whitelist("abc123")]
	public string Username { get; set; }
	[FileExtensions("jpg,jpeg,png")]
	public IFormFile ProfilePicture { get; set; }
}
```

In this example, the `Username` property will only accept characters 'a', 'b', 'c', '1', '2', and '3', while the `ProfilePicture` property will only accept files with the extensions .jpg, .jpeg, and .png.

### Predefined Whitelist Sets

Gibe.Validation also provides predefined whitelist sets for common character groups. You can use these sets instead of specifying individual characters. For example:

| Predefined Set    | Description      |
|-------------------|------------------|
| SingleText        | Accepts most Latin characters, numbers, and common punctuation. Does not allow line breaks . |
| MultiText         | Accepts most Latin characters, numbers, and common punctuation. Allows line breaks. |
| Title             | Accepts most Latin characters, spaces, and common punctuation. Does not allow line breaks. |
| Name              | Accepts most Latin characters, numbers, and limited punctuation. Does not allow line breaks. |
| Int               | Accepts only integer digits. |
| Decimal           | Accepts only decimal digits and decimal points. |		
| PhoneNumber       | Accepts only numbers, plus, brackets, spaces and dashes. |
| Email             | Accepts only characters allowed in email addresses |

You can use these like so:

```
[Whitelist(Whitelists.Email)]
public string Email { get; set; }
```

## Contributing	

Contributions to Gibe.Validation are welcome! If you have an idea for a new validation attribute or an improvement to an existing one, please submit a pull request.

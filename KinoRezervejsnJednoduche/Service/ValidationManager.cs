using System.Text.RegularExpressions;

namespace KinoRezervejsnJednoduche.Service;

// Created by Vojts
// Github: https://github.com/vojtechbaudys
// v1.0
public class ValidationManager
{
	// Main Validation Function
	// subject - [string]
	// regex - [string]
	private bool Validate(string subject, string regex)
	{
		if (!Regex.IsMatch(subject, regex))
		{
			return false;
		}

		return true;
	}
	
	// Forename & Surname Validation Function
	// subject - [string]
	// regex - [string] nullable
	public bool ValidateName(string subject, string regex = "^[a-zA-ZàáâäãåąčćęèéêëėěįìíîïłńòóôöõøùúûüųūÿýżźñřçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËĚÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑŘßÇŒÆČŠŽ∂ð]{2,100}$")
	{
		return Validate(subject, regex);
	}

	// Email Validation Function
	// subject - [string]
	// regex - [string] nullable
	public bool ValidateEmail(string subject, string regex = "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,}$")
	{
		return Validate(subject, regex);
	}
}
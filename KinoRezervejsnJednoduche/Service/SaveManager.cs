using System.IO;
using Newtonsoft.Json;

namespace KinoRezervejsnJednoduche.Service;

// Created by Vojts 
// Github: https://github.com/vojtechbaudys
// v1.1
public class SaveManager
{
	// Save stats to {filePath.json} file
	// filePath - [string]
	// model - [object]
	public void Save(string filePath, object model)
	{
		FileExist(filePath);
		File.WriteAllText(filePath, JsonConvert.SerializeObject(model));
	}
	
	// Load data form {save.json} file
	// filePath - [string]
	// Return T object
	public T LoadData<T>(string filePath)
	{
		FileExist(filePath);
		return JsonConvert.DeserializeObject<T>(File.ReadAllText(filePath))!;
	}
	
	// Check {save.json} if exist
	// filePath - [string]
	// false -> create new {filePath} file
	private void FileExist(string filePath)
	{
		try
		{
			JsonConvert.DeserializeObject(File.ReadAllText(filePath));
		}
		catch
		{
			File.Create(filePath).Close();
			File.WriteAllText(filePath, "{}");
		}
	}
}
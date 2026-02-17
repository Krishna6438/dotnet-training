using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Text.Json;
using System.IO;


public class ApplicationManager
{

    private Dictionary<string, Applicant> _list = new Dictionary<string, Applicant>();
    private const string FILE_PATH = "applicants.dat";

    public ApplicationManager()
    {
        LoadFromFile();
    }


    public void AddApplicant(Applicant a)
    {
        if (string.IsNullOrWhiteSpace(a.Id) || string.IsNullOrWhiteSpace(a.Name) || string.IsNullOrWhiteSpace(a.Competency))
        {
            Console.WriteLine("All fields are mandatory");
            return;
        }

        if (a.Id.Length != 8 || !a.Id.StartsWith("CH"))
        {
            Console.WriteLine("Id is invalid");
            return;
        }
        if (a.Name.Length < 4 || a.Name.Length > 15)
        {
            Console.WriteLine("Name is invalid");
            return;
        }
        if (!_list.ContainsKey(a.Id))
        {
            _list[a.Id] = a;
            SaveToFile();
            Console.WriteLine("Applicant added successfully...");
            return;
        }
        Console.WriteLine("Either applicant already exists or Id is wrong/not available..");

    }

    public void DisplayAll()
    {
        foreach (var a in _list.Values)
        {
            Console.WriteLine($"{a.Id} | {a.Name} | {a.CurrentLocation} | " +
                            $"{a.PreferredLocation} | {a.Competency} | {a.PassingYear}");
        }
    }

    public Applicant? SearchById(string id)
    {
        if (_list.ContainsKey(id))
        {
            return _list[id];

        }
        Console.WriteLine("Applicant does not found");
        return null;
    }

    public void UpdateApplicantDetails(string id)
    {
        if (!_list.ContainsKey(id))
        {
            Console.WriteLine("Applicant not found.");
            return;
        }

        var applicant = _list[id];

        Console.Write("Enter New Name: ");
        applicant.Name = Console.ReadLine();

        Console.Write("Enter New Competency: ");
        applicant.Competency = Console.ReadLine();

        SaveToFile();
        Console.WriteLine("Applicant updated successfully.");
    }

    public void DeleteApplicant(string id)
    {
        if (_list.ContainsKey(id))
        {
            _list.Remove(id);
            return;
        }
        Console.WriteLine("Applicant does not found");
    }

    private void SaveToFile()
    {
        var json = JsonSerializer.Serialize(_list);

        File.WriteAllText(FILE_PATH, json);
    }


    // ✅ SERIALIZATION LOAD
    private void LoadFromFile()
    {
        if (!File.Exists(FILE_PATH))
            return;

        var json = File.ReadAllText(FILE_PATH);

        _list = JsonSerializer.Deserialize<Dictionary<string, Applicant>>(json)
                ?? new Dictionary<string, Applicant>();
    }

}


// Task 1: Implement Patient class with proper encapsulation
// Create a Patient class with: Id (int), Name (string), Age (int), Condition (string)
// Use a Dictionary<int, Patient> to store patients by ID
// Use a Queue<Patient> for the appointment waiting list
// Use a List<string> for each patient's medical history

public class Patient
{
    // TODO: Add properties with get/set accessors
    // TODO: Add constructor
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? Condition { get; set; }

    public List<string> MedicalHistory { get; set; }

    public Patient(int id, string name, int age, string condition)
    {
        Id = id;
        Name = name;
        Age = age;
        Condition = condition;
        MedicalHistory = new List<string>();
    }
}

// Task 2: Implement HospitalManager class
public class HospitalManager
{
    private Dictionary<int, Patient> _patients = new Dictionary<int, Patient>();
    private Queue<Patient> _appointmentQueue = new Queue<Patient>();

    // Add a new patient to the system
    public void RegisterPatient(int id, string name, int age, string condition)
    {
        // TODO: Create patient and add to dictionary
        Patient p = new Patient(id, name, age, condition);
        if (_patients.ContainsKey(id))
        {
            Console.WriteLine("Patient already exists.");
            return;
        }
        _patients[id] = p;

    }

    // Add patient to appointment queue
    public void ScheduleAppointment(int patientId)
    {
        // TODO: Find patient and add to queue
        if (_patients.ContainsKey(patientId))
        {
            _appointmentQueue.Enqueue(_patients[patientId]);
        }
        else
        {
            Console.WriteLine("Patient not found.");
        }
    }

    // Process next appointment (remove from queue)
    public Patient? ProcessNextAppointment()
    {
        // TODO: Return and remove next patient from queue
        if (_appointmentQueue.Count <= 0)
        {
            Console.WriteLine("No patient in queue..");
            return null;
        }
        return _appointmentQueue.Dequeue();
    }

    // Find patients with specific condition using LINQ
    public List<Patient> FindPatientsByCondition(string condition)
    {
        return _patients.Values.Where(p=>p.Condition == condition).ToList();
    }
}

class HospitalManagement
{
    public static void Run()
    {
        HospitalManager hm = new HospitalManager();

        // Register patients
        hm.RegisterPatient(1, "Krishna", 22, "Fever");
        hm.RegisterPatient(2, "Rahul", 25, "Cold");
        hm.RegisterPatient(3, "Amit", 30, "Fever");

        // Schedule appointments
        hm.ScheduleAppointment(1);
        hm.ScheduleAppointment(2);
        hm.ScheduleAppointment(3);

        // Process appointments
        Console.WriteLine("\nProcessing Appointments:");

        var p1 = hm.ProcessNextAppointment();
        if (p1 != null)
            Console.WriteLine($"Doctor seeing: {p1.Name}");

        var p2 = hm.ProcessNextAppointment();
        if (p2 != null)
            Console.WriteLine($"Doctor seeing: {p2.Name}");

        // Find patients by condition
        Console.WriteLine("\nPatients with Fever:");

        var feverPatients = hm.FindPatientsByCondition("Fever");

        foreach (var patient in feverPatients)
        {
            Console.WriteLine(patient.Name);
        }
    }
}

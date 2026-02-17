public enum CurrentLocation
{
    Mumbai,
    Pune,
    Chennai
}

public enum PreferredLocation
{
    Mumbai,
    Pune,
    Chennai,
    Delhi,
    Kolkata,
    Bangalore
}

[Serializable]
public class Applicant
{
    public string? Id{get; set;}
    public string? Name{get; set;}
    public CurrentLocation CurrentLocation{get; set;}
    public PreferredLocation PreferredLocation{get; set;}
    public string? Competency{get; set;}
    public int PassingYear{get; set;}

}
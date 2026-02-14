public class InvalidGPAException: Exception
{
    public InvalidGPAException(string msg) : base(msg){}
}

public class DuplicateStudentException: Exception
{
    public DuplicateStudentException(string msg) : base(msg){}
}

public class StudentNotFoundException: Exception
{
    public StudentNotFoundException(string msg) : base(msg){}
}

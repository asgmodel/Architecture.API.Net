namespace APILAHJA.Enums
{
    public enum ErrorCodes
    {
        None = 0,
        NotFound = 1,
        ValidationFailed = 2,
        DatabaseError = 3,
        Unauthorized = 4,
        Forbidden = 5,
        Conflict = 6,
        UnknownError = 7,
        EntityNotFound = 8,
        EntityValidationError = 9,
        EntityAlreadyExists = 10
    }

    public enum ExceptionTypes
    {
        None = 0,
        NullReference = 1,
        SqlException = 2,
        InvalidOperation = 3,
        ArgumentNull = 4,
        ArgumentOutOfRange = 5,
        Timeout = 6,
        GeneralException = 7
    }

    public enum EventTypes
    {
        None = 0,
        EntityCreated = 1,
        EntityUpdated = 2,
        EntityDeleted = 3,
        DataQueried = 4,
        SystemStarted = 5,
        SystemStopped = 6,
        UserLoggedIn = 7,
        UserLoggedOut = 8,
        LaunchInitiated = 9,
        ReportGenerated = 10,
        AlertTriggered = 11
    }
}

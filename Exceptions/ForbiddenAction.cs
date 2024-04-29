namespace EFCoreVezba.Exceptions;

using System;

public class ForbiddenActionException : Exception {
    public ForbiddenActionException(string message) : base(message) {}
}
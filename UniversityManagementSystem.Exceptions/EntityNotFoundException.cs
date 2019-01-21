using System;

namespace UniversityManagementSystem.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException() : base("The requested entity could not be found.")
        {
        }
    }
}
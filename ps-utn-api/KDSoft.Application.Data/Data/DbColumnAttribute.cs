using System;

namespace KDSoft.Application.Base.Data
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DbColumnAttribute : Attribute
    {
        public string Name { get; private set; }

        public DbColumnAttribute(string name)
        {
            Name = name;
        }
    }
}
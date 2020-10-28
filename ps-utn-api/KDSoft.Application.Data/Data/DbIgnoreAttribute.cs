using System;

namespace KDSoft.Application.Base.Data
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DbIgnoreAttribute : Attribute
    {
    }
}
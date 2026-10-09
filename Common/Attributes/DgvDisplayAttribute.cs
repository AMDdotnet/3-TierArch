using System;

namespace Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class DgvDisplayAttribute : Attribute
    {
        public string Title { get;}
        public bool Visible { get;}

        public DgvDisplayAttribute(string title, bool visible = true)
        {
            Title = title;
            Visible = visible;
        }
    }
}

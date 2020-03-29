using System;

namespace ApiSep.Library.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class HelpAttribute : Attribute
    {
        public readonly string Example;

        public string Topic
        { get; set; }

        public HelpAttribute(string example)
        {
            Example = example;
        }

        //[Author("Jane Programmer", Topic = 2), IsTested()]
    }
}

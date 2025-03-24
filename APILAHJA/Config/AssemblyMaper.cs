
using System;

namespace APILAHJA.Config
{




    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class MapEnabledAttribute : Attribute
    {
        public bool IsMapped { get; set; }

        // Constructor to define whether mapping is enabled or not.
        public MapEnabledAttribute(bool isMapped = true)
        {
            IsMapped = isMapped;
        }
    }




    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class IgnoreAutomateMapperAttribute : Attribute
    {
        public bool IgnoreMapping { get; set; }

        // Constructor with default value as true
        public IgnoreAutomateMapperAttribute(bool ignoreMapping = true)
        {
            IgnoreMapping = ignoreMapping;
        }
    }

}

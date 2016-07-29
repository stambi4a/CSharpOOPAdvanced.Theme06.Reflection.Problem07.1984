namespace _1984.Utilities
{
    using System;
    using System.Collections.Generic;

    public static class AliasUtility
    {
        public static Dictionary<Type, string> Aliases = new Dictionary<Type, string>()
                                                             {
            { typeof(int), "int" },
            { typeof(string), "String" }
                                                             };
    }
}

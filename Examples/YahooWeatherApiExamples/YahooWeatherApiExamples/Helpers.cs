using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Xml.Linq;

namespace YahooWeatherApiExamples
{
    public static class Helpers
    {
        ///// <summary>Writes the line.</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="items">The items.</param>
        //[DebuggerStepThrough]
        //public static void DebugWriteLines<T>(this IEnumerable<T> items)
        //{
        //    items = items ?? new T[] { }; // avoid exceptions in logging code
        //    Debug.WriteLine(string.Join(Environment.NewLine, items));
        //}

        [ExcludeFromCodeCoverage]
        public static void GenerateNamespaceCode(this XElement root)
        {
            // 5/2018 namespaces may occur anywhere in xdocument, as in Yahoo Weather Api response
            IEnumerable<string> query = from e in root.DescendantsAndSelf()
                from a in e.Attributes()
                where a.IsNamespaceDeclaration
                select $@"XNamespace {a.Name.LocalName} = ""{a.Value}"";{Environment.NewLine}";

            Debug.Write(string.Join("", query.Distinct()));
        }
    }
}

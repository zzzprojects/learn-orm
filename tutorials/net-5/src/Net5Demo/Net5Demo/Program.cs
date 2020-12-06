using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Net5Demo
{
    public class Program
    {
        public static async System.Threading.Tasks.Task Main()
        {
            //PreserveReferencesAndHandleCircularReferences.Example();
            //await HttpClientAndHttpContentExtensionMethods.Example();
            //AllowOrWriteNumbersInQuotes.Example();
            //ImmutableTypesAndRecords.Example1();
            //ImmutableTypesAndRecords.Example2();

            //NonPublicPropertyAccessors.Example1();

            //IncludeFields.Example1();
            //IncludeFields.Example2();

            //IgnoreProperties.Example1();
            //IgnoreProperties.Example2();
            //IgnoreProperties.Example3();
            //IgnoreProperties.Example4();
            //IgnoreProperties.Example5();

            //AllowCustomConvertersToHandleNull.Example1();
            //CopyJsonSerializerOptions.Example1();
            CreateJsonSerializerOptionsWithWebDefaults.Example1();
        }
    }
}

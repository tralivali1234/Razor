#pragma checksum "TestFiles/IntegrationTests/CodeGenerationIntegrationTest/CSharp7.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d287720a0df9d4595ed4f009c44479d9c7b0a800"
namespace Microsoft.AspNetCore.Razor.Language.IntegrationTests.TestFiles
{
    #line hidden
    using System;
    using System.Threading.Tasks;
    public class TestFiles_IntegrationTests_CodeGenerationIntegrationTest_CSharp7_Runtime
    {
        #pragma warning disable 1998
        public async System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<body>\r\n");
#line 2 "TestFiles/IntegrationTests/CodeGenerationIntegrationTest/CSharp7.cshtml"
      
        var nameLookup = new Dictionary<string, (string FirstName, string LastName, object Extra)>()
        {
            ["John Doe"] = ("John", "Doe", true)
        };

        

#line default
#line hidden
#line 8 "TestFiles/IntegrationTests/CodeGenerationIntegrationTest/CSharp7.cshtml"
                                                     

        int Sixteen = 0b0001_0000;
        long BillionsAndBillions = 100_000_000_000;
        double AvogadroConstant = 6.022_140_857_747_474e23;
        decimal GoldenRatio = 1.618_033_988_749_894_848_204_586_834_365_638_117_720_309_179M;
    

#line default
#line hidden
            WriteLiteral("\r\n");
#line 16 "TestFiles/IntegrationTests/CodeGenerationIntegrationTest/CSharp7.cshtml"
     if (nameLookup.TryGetValue("John Doe", out var entry))
    {
        if (entry.Extra is bool alive)
        {
            // Do Something
        }
    }

#line default
#line hidden
            WriteLiteral("    <p>\r\n        Here\'s a very unique number: ");
#line 24 "TestFiles/IntegrationTests/CodeGenerationIntegrationTest/CSharp7.cshtml"
                                 Write(1.618_033_988_749_894_848_204_586_834_365_638_117_720_309_179M);

#line default
#line hidden
            WriteLiteral("\r\n    </p>\r\n\r\n    <div>\r\n        ");
#line 28 "TestFiles/IntegrationTests/CodeGenerationIntegrationTest/CSharp7.cshtml"
    Write((First: "John", Last: "Doe").First);

#line default
#line hidden
            WriteLiteral(" ");
            WriteLiteral("\r\n    </div>\r\n\r\n");
#line 31 "TestFiles/IntegrationTests/CodeGenerationIntegrationTest/CSharp7.cshtml"
     switch (entry.Extra)
    {
        case int age:
            // Do something
            break;
        case IEnumerable<string> childrenNames:
            // Do more something
            break;
        case null:
            // Do even more of something
            break;
    }

#line default
#line hidden
            WriteLiteral("</body>");
        }
        #pragma warning restore 1998
    }
}

#pragma checksum "C:\Users\51519136897\Documents\RoletopMVC\Views\Shared\Sucesso.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "49d03b4421eed91f1a1500257d719c501e956450"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Sucesso), @"mvc.1.0.view", @"/Views/Shared/Sucesso.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Sucesso.cshtml", typeof(AspNetCore.Views_Shared_Sucesso))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\51519136897\Documents\RoletopMVC\Views\_ViewImports.cshtml"
using RoletopMVC;

#line default
#line hidden
#line 2 "C:\Users\51519136897\Documents\RoletopMVC\Views\_ViewImports.cshtml"
using RoletopMVC.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"49d03b4421eed91f1a1500257d719c501e956450", @"/Views/Shared/Sucesso.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9fcde6f443f8ee695eebee3c09673a46bc68798b", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Sucesso : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 18, true);
            WriteLiteral("<main>\r\n\r\n    <h2>");
            EndContext();
            BeginContext(19, 18, false);
#line 3 "C:\Users\51519136897\Documents\RoletopMVC\Views\Shared\Sucesso.cshtml"
   Write(ViewData["Action"]);

#line default
#line hidden
            EndContext();
            BeginContext(37, 77, true);
            WriteLiteral(" deu bom!</h2>\r\n    \r\n    <div class=\"mensagem\">\r\n\r\n        <p>\r\n            ");
            EndContext();
            BeginContext(115, 14, false);
#line 8 "C:\Users\51519136897\Documents\RoletopMVC\Views\Shared\Sucesso.cshtml"
       Write(Model.Mensagem);

#line default
#line hidden
            EndContext();
            BeginContext(129, 35, true);
            WriteLiteral("\r\n        </p>\r\n    </div>\r\n</main>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591

#pragma checksum "D:\Mijn Documenten\School\KnikkerShop\KnikkerShop\KnikkerShop\Views\WebShop\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dab9129134db020035fba726eafb252d2d08de9f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_WebShop_Index), @"mvc.1.0.view", @"/Views/WebShop/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/WebShop/Index.cshtml", typeof(AspNetCore.Views_WebShop_Index))]
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
#line 1 "D:\Mijn Documenten\School\KnikkerShop\KnikkerShop\KnikkerShop\Views\_ViewImports.cshtml"
using KnikkerShop;

#line default
#line hidden
#line 2 "D:\Mijn Documenten\School\KnikkerShop\KnikkerShop\KnikkerShop\Views\_ViewImports.cshtml"
using KnikkerShop.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dab9129134db020035fba726eafb252d2d08de9f", @"/Views/WebShop/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"416ceb92f6ac02d9511213f3cfc800bb40d73234", @"/Views/_ViewImports.cshtml")]
    public class Views_WebShop_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<KnikkerShop.Models.ProductViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(44, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\Mijn Documenten\School\KnikkerShop\KnikkerShop\KnikkerShop\Views\WebShop\Index.cshtml"
  
    ViewData["Title"] = "WebShop";

#line default
#line hidden
            BeginContext(89, 70, true);
            WriteLiteral("\r\n<h2>WebShop</h2>\r\n\r\n<div class=\"container\">\r\n    <div class=\"row\">\r\n");
            EndContext();
#line 11 "D:\Mijn Documenten\School\KnikkerShop\KnikkerShop\KnikkerShop\Views\WebShop\Index.cshtml"
         foreach (ProductDetailViewModel item in Model.ProductDetailViewModels)
        {
            if (item.Actief == true)
            {

#line default
#line hidden
            BeginContext(304, 71, true);
            WriteLiteral("                <div class=\"col-md-4 col-sm-6\">\r\n                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\'", 375, "\'", 436, 1);
#line 16 "D:\Mijn Documenten\School\KnikkerShop\KnikkerShop\KnikkerShop\Views\WebShop\Index.cshtml"
WriteAttributeValue("", 382, Url.Action("Detail", "WebShop", new { id = item.Id }), 382, 54, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(437, 159, true);
            WriteLiteral(" />\r\n                    <span class=\"thumbnail\" />\r\n                    <img src=\"http://placehold.it/500x400\" alt=\"KnikkerPlaatje\">\r\n                    <h4>");
            EndContext();
            BeginContext(597, 9, false);
#line 19 "D:\Mijn Documenten\School\KnikkerShop\KnikkerShop\KnikkerShop\Views\WebShop\Index.cshtml"
                   Write(item.Naam);

#line default
#line hidden
            EndContext();
            BeginContext(606, 30, true);
            WriteLiteral("</h4>\r\n                    <p>");
            EndContext();
            BeginContext(637, 17, false);
#line 20 "D:\Mijn Documenten\School\KnikkerShop\KnikkerShop\KnikkerShop\Views\WebShop\Index.cshtml"
                  Write(item.Beschrijving);

#line default
#line hidden
            EndContext();
            BeginContext(654, 148, true);
            WriteLiteral("</p>\r\n                    <div class=\"row\">\r\n                        <div class=\"col-md-6 col-sm-6\">\r\n                            <p class=\"price\">$");
            EndContext();
            BeginContext(803, 10, false);
#line 23 "D:\Mijn Documenten\School\KnikkerShop\KnikkerShop\KnikkerShop\Views\WebShop\Index.cshtml"
                                         Write(item.Prijs);

#line default
#line hidden
            EndContext();
            BeginContext(813, 90, true);
            WriteLiteral("</p>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
            EndContext();
#line 27 "D:\Mijn Documenten\School\KnikkerShop\KnikkerShop\KnikkerShop\Views\WebShop\Index.cshtml"
            }
        }

#line default
#line hidden
            BeginContext(929, 18, true);
            WriteLiteral("    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<KnikkerShop.Models.ProductViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591

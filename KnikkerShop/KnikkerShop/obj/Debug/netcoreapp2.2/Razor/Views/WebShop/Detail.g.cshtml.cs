#pragma checksum "D:\Mijn Documenten\School\KnikkerShop\KnikkerShop\KnikkerShop\Views\WebShop\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5d73bb13ddc11282126615b10fa8ce5c4476b7b3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_WebShop_Detail), @"mvc.1.0.view", @"/Views/WebShop/Detail.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/WebShop/Detail.cshtml", typeof(AspNetCore.Views_WebShop_Detail))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d73bb13ddc11282126615b10fa8ce5c4476b7b3", @"/Views/WebShop/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"416ceb92f6ac02d9511213f3cfc800bb40d73234", @"/Views/_ViewImports.cshtml")]
    public class Views_WebShop_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<KnikkerShop.Models.ProductDetailViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(50, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\Mijn Documenten\School\KnikkerShop\KnikkerShop\KnikkerShop\Views\WebShop\Detail.cshtml"
  
    ViewData["Title"] = "Detail";

#line default
#line hidden
            BeginContext(94, 98, true);
            WriteLiteral("\r\n<h2>Detail</h2>\r\n\r\n<div>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(193, 40, false);
#line 13 "D:\Mijn Documenten\School\KnikkerShop\KnikkerShop\KnikkerShop\Views\WebShop\Detail.cshtml"
       Write(Html.DisplayNameFor(model => model.Naam));

#line default
#line hidden
            EndContext();
            BeginContext(233, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(277, 36, false);
#line 16 "D:\Mijn Documenten\School\KnikkerShop\KnikkerShop\KnikkerShop\Views\WebShop\Detail.cshtml"
       Write(Html.DisplayFor(model => model.Naam));

#line default
#line hidden
            EndContext();
            BeginContext(313, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(357, 41, false);
#line 19 "D:\Mijn Documenten\School\KnikkerShop\KnikkerShop\KnikkerShop\Views\WebShop\Detail.cshtml"
       Write(Html.DisplayNameFor(model => model.Prijs));

#line default
#line hidden
            EndContext();
            BeginContext(398, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(442, 37, false);
#line 22 "D:\Mijn Documenten\School\KnikkerShop\KnikkerShop\KnikkerShop\Views\WebShop\Detail.cshtml"
       Write(Html.DisplayFor(model => model.Prijs));

#line default
#line hidden
            EndContext();
            BeginContext(479, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(523, 43, false);
#line 25 "D:\Mijn Documenten\School\KnikkerShop\KnikkerShop\KnikkerShop\Views\WebShop\Detail.cshtml"
       Write(Html.DisplayNameFor(model => model.Grootte));

#line default
#line hidden
            EndContext();
            BeginContext(566, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(610, 39, false);
#line 28 "D:\Mijn Documenten\School\KnikkerShop\KnikkerShop\KnikkerShop\Views\WebShop\Detail.cshtml"
       Write(Html.DisplayFor(model => model.Grootte));

#line default
#line hidden
            EndContext();
            BeginContext(649, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(693, 41, false);
#line 31 "D:\Mijn Documenten\School\KnikkerShop\KnikkerShop\KnikkerShop\Views\WebShop\Detail.cshtml"
       Write(Html.DisplayNameFor(model => model.Kleur));

#line default
#line hidden
            EndContext();
            BeginContext(734, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(778, 37, false);
#line 34 "D:\Mijn Documenten\School\KnikkerShop\KnikkerShop\KnikkerShop\Views\WebShop\Detail.cshtml"
       Write(Html.DisplayFor(model => model.Kleur));

#line default
#line hidden
            EndContext();
            BeginContext(815, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(859, 48, false);
#line 37 "D:\Mijn Documenten\School\KnikkerShop\KnikkerShop\KnikkerShop\Views\WebShop\Detail.cshtml"
       Write(Html.DisplayNameFor(model => model.Beschrijving));

#line default
#line hidden
            EndContext();
            BeginContext(907, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(951, 44, false);
#line 40 "D:\Mijn Documenten\School\KnikkerShop\KnikkerShop\KnikkerShop\Views\WebShop\Detail.cshtml"
       Write(Html.DisplayFor(model => model.Beschrijving));

#line default
#line hidden
            EndContext();
            BeginContext(995, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1039, 44, false);
#line 43 "D:\Mijn Documenten\School\KnikkerShop\KnikkerShop\KnikkerShop\Views\WebShop\Detail.cshtml"
       Write(Html.DisplayNameFor(model => model.Voorraad));

#line default
#line hidden
            EndContext();
            BeginContext(1083, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1127, 40, false);
#line 46 "D:\Mijn Documenten\School\KnikkerShop\KnikkerShop\KnikkerShop\Views\WebShop\Detail.cshtml"
       Write(Html.DisplayFor(model => model.Voorraad));

#line default
#line hidden
            EndContext();
            BeginContext(1167, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1211, 45, false);
#line 49 "D:\Mijn Documenten\School\KnikkerShop\KnikkerShop\KnikkerShop\Views\WebShop\Detail.cshtml"
       Write(Html.DisplayNameFor(model => model.Categorie));

#line default
#line hidden
            EndContext();
            BeginContext(1256, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1300, 41, false);
#line 52 "D:\Mijn Documenten\School\KnikkerShop\KnikkerShop\KnikkerShop\Views\WebShop\Detail.cshtml"
       Write(Html.DisplayFor(model => model.Categorie));

#line default
#line hidden
            EndContext();
            BeginContext(1341, 43, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n");
            EndContext();
#line 57 "D:\Mijn Documenten\School\KnikkerShop\KnikkerShop\KnikkerShop\Views\WebShop\Detail.cshtml"
     if (User.IsInRole("beheerder"))
    {
        

#line default
#line hidden
            BeginContext(1438, 64, false);
#line 59 "D:\Mijn Documenten\School\KnikkerShop\KnikkerShop\KnikkerShop\Views\WebShop\Detail.cshtml"
   Write(Html.ActionLink("Aanpassen", "Aanpassen", new { id = Model.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(1502, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(1505, 4, true);
            WriteLiteral(" |\r\n");
            EndContext();
#line 60 "D:\Mijn Documenten\School\KnikkerShop\KnikkerShop\KnikkerShop\Views\WebShop\Detail.cshtml"
    }

#line default
#line hidden
            BeginContext(1516, 4, true);
            WriteLiteral("    ");
            EndContext();
            BeginContext(1520, 43, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d73bb13ddc11282126615b10fa8ce5c4476b7b310614", async() => {
                BeginContext(1542, 17, true);
                WriteLiteral("Terug naar winkel");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1563, 8, true);
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<KnikkerShop.Models.ProductDetailViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591

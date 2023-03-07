#pragma checksum "C:\Users\Batuhan\source\repos\OnlineExamProject\Presentation\OnlineExamProject.UI\Views\ApplicationService\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9f33151d1971b8c5b95f1db5ebc77fe09707799c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ApplicationService_Index), @"mvc.1.0.view", @"/Views/ApplicationService/Index.cshtml")]
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
#nullable restore
#line 1 "C:\Users\Batuhan\source\repos\OnlineExamProject\Presentation\OnlineExamProject.UI\Views\_ViewImports.cshtml"
using OnlineExamProject.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Batuhan\source\repos\OnlineExamProject\Presentation\OnlineExamProject.UI\Views\_ViewImports.cshtml"
using OnlineExamProject.UI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Batuhan\source\repos\OnlineExamProject\Presentation\OnlineExamProject.UI\Views\ApplicationService\Index.cshtml"
using OnlineExamProject.Application.DTOs.Configuration;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9f33151d1971b8c5b95f1db5ebc77fe09707799c", @"/Views/ApplicationService/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"91114a0974bb1a67cbe8ff22c556d7ccc50870fc", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_ApplicationService_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Menu>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Admin/AuthorizationEndpoint/AssignRoletoEndpoint/"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Batuhan\source\repos\OnlineExamProject\Presentation\OnlineExamProject.UI\Views\ApplicationService\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""m-5"">
<div class=""card""> 
    <div class=""table-responsive text-nowrap"">
        <table class=""table table-bordered"">
            <thead>
                <tr>

                    <th>Controller Name</th>
                    <th>Controller Definitions</th>
                </tr>
            </thead>
            <tbody class=""table-border-bottom-0"">
");
#nullable restore
#line 20 "C:\Users\Batuhan\source\repos\OnlineExamProject\Presentation\OnlineExamProject.UI\Views\ApplicationService\Index.cshtml"
                     foreach (var name in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td><i class=\"fab fa-angular fa-lg text-danger me-3\"></i> <strong>");
#nullable restore
#line 23 "C:\Users\Batuhan\source\repos\OnlineExamProject\Presentation\OnlineExamProject.UI\Views\ApplicationService\Index.cshtml"
                                                                                         Write(name.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></td>\r\n");
#nullable restore
#line 24 "C:\Users\Batuhan\source\repos\OnlineExamProject\Presentation\OnlineExamProject.UI\Views\ApplicationService\Index.cshtml"
                             foreach (var action in name.Actions)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td><a href=\"/Admin/AuthorizationEndpoint/AssignRoletoEndpoint/\" class=\"btn btn-secondary\"   data-bs-toggle=\"modal\" data-bs-target=\"#assignRole\">");
#nullable restore
#line 26 "C:\Users\Batuhan\source\repos\OnlineExamProject\Presentation\OnlineExamProject.UI\Views\ApplicationService\Index.cshtml"
                                                                                                                                                                                Write(action.Definition);

#line default
#line hidden
#nullable disable
            WriteLiteral(" (");
#nullable restore
#line 26 "C:\Users\Batuhan\source\repos\OnlineExamProject\Presentation\OnlineExamProject.UI\Views\ApplicationService\Index.cshtml"
                                                                                                                                                                                                    Write(action.HttpType);

#line default
#line hidden
#nullable disable
            WriteLiteral(")</a></td>\r\n");
#nullable restore
#line 27 "C:\Users\Batuhan\source\repos\OnlineExamProject\Presentation\OnlineExamProject.UI\Views\ApplicationService\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tr>\r\n");
#nullable restore
#line 29 "C:\Users\Batuhan\source\repos\OnlineExamProject\Presentation\OnlineExamProject.UI\Views\ApplicationService\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </tbody>
        </table>
    </div>
</div>
</div>

            

                <div class=""modal fade"" id=""assignRole"" tabindex=""-1"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLabel1"">Rol Ekle</h5>
                <button type=""button""
                        class=""btn-close""
                        data-bs-dismiss=""modal""
                        aria-label=""Kapat""></button>
            </div>
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9f33151d1971b8c5b95f1db5ebc77fe09707799c8442", async() => {
                WriteLiteral(@"
            <div class=""modal-body"">
                <div class=""row"">
                    <div class=""col mb-3"">
                      
                    </div>
                </div>                
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-outline-secondary"" data-bs-dismiss=""modal"">
                    Kapat
                </button>
                <button type=""submit""  class=""btn btn-primary"">Ekle</button>
            </div>
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>       ");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Menu>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
#pragma checksum "C:\Users\Batuhan\source\repos\OnlineExamProject\Presentation\OnlineExamProject.UI\Areas\Admin\Views\Question\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6b22df401e9ce19523cceaa5070acf82f173ae84"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Question_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Question/Index.cshtml")]
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
#line 1 "C:\Users\Batuhan\source\repos\OnlineExamProject\Presentation\OnlineExamProject.UI\Areas\Admin\Views\Question\Index.cshtml"
using OnlineExamProject.Domain.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b22df401e9ce19523cceaa5070acf82f173ae84", @"/Areas/Admin/Views/Question/Index.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_Question_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IQueryable<Exam>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Batuhan\source\repos\OnlineExamProject\Presentation\OnlineExamProject.UI\Areas\Admin\Views\Question\Index.cshtml"
  
    ViewData["Title"] = "Sorular";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<link rel=\"stylesheet\" href=\"https://cdn.jsdelivr.net/npm/bootstrap@4.4.1/dist/css/bootstrap.min.css\" integrity=\"sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh\" crossorigin=\"anonymous\">\r\n<br />\r\n");
#nullable restore
#line 9 "C:\Users\Batuhan\source\repos\OnlineExamProject\Presentation\OnlineExamProject.UI\Areas\Admin\Views\Question\Index.cshtml"
 foreach (var item in Model)
{


#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"card m-2\">\r\n        <div class=\"card-body\">\r\n            <h5 class=\"card-title\">");
#nullable restore
#line 14 "C:\Users\Batuhan\source\repos\OnlineExamProject\Presentation\OnlineExamProject.UI\Areas\Admin\Views\Question\Index.cshtml"
                              Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n            <p class=\"card-text\">");
#nullable restore
#line 15 "C:\Users\Batuhan\source\repos\OnlineExamProject\Presentation\OnlineExamProject.UI\Areas\Admin\Views\Question\Index.cshtml"
                            Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Soruları görmek ve soru eklemek için butona tıklayın.</p>\r\n            <div class=\"float-right\" style=\"float:right; vertical-align:center\">\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 740, "\"", 786, 3);
            WriteAttributeValue("", 747, "/Admin/Question/ExamQuestions/", 747, 30, true);
#nullable restore
#line 17 "C:\Users\Batuhan\source\repos\OnlineExamProject\Presentation\OnlineExamProject.UI\Areas\Admin\Views\Question\Index.cshtml"
WriteAttributeValue("", 777, item.Id, 777, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 785, "/", 785, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn rounded-pill btn-warning\">+ Ekle</a>\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 855, "\"", 900, 2);
            WriteAttributeValue("", 862, "/Admin/Question/ExamQuestions/", 862, 30, true);
#nullable restore
#line 18 "C:\Users\Batuhan\source\repos\OnlineExamProject\Presentation\OnlineExamProject.UI\Areas\Admin\Views\Question\Index.cshtml"
WriteAttributeValue("", 892, item.Id, 892, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("  class=\"btn rounded-pill btn-primary\">Listele</a>\r\n            </div>\r\n        </div>\r\n    </div> \r\n");
#nullable restore
#line 22 "C:\Users\Batuhan\source\repos\OnlineExamProject\Presentation\OnlineExamProject.UI\Areas\Admin\Views\Question\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IQueryable<Exam>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
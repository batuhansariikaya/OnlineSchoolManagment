#pragma checksum "C:\Users\Batuhan\source\repos\OnlineExamProject\Presentation\OnlineExamProject.UI\Areas\Admin\Views\Teacher\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b1a7e0e7e9fc620e45408388aa19431ffe04d8d8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Teacher_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Teacher/Index.cshtml")]
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
#line 1 "C:\Users\Batuhan\source\repos\OnlineExamProject\Presentation\OnlineExamProject.UI\Areas\Admin\Views\Teacher\Index.cshtml"
using OnlineExamProject.Domain.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b1a7e0e7e9fc620e45408388aa19431ffe04d8d8", @"/Areas/Admin/Views/Teacher/Index.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_Teacher_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Teacher>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Batuhan\source\repos\OnlineExamProject\Presentation\OnlineExamProject.UI\Areas\Admin\Views\Teacher\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <br />

 <div class=""content-wrapper"">
<div class=""card"" style=""margin:30px;"">                
                <div class=""table-responsive text-nowrap"">
                  <table class=""table"">
                    <thead class=""table-light"">
                      <tr>
                        <th>Ad Soyad</th>
                        <th>Bölüm</th>
                        <th>Kayıt Tarihi</th>
                        <th>Durum</th>
                        <th>İşlemler</th>
                      </tr>
                    </thead>
                    <tbody class=""table-border-bottom-0"">
");
#nullable restore
#line 23 "C:\Users\Batuhan\source\repos\OnlineExamProject\Presentation\OnlineExamProject.UI\Areas\Admin\Views\Teacher\Index.cshtml"
                         foreach(var item in Model){                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                      <tr>\r\n                        <td><i class=\"fab fa-angular fa-lg texts-danger\"></i> ");
#nullable restore
#line 25 "C:\Users\Batuhan\source\repos\OnlineExamProject\Presentation\OnlineExamProject.UI\Areas\Admin\Views\Teacher\Index.cshtml"
                                                                         Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 25 "C:\Users\Batuhan\source\repos\OnlineExamProject\Presentation\OnlineExamProject.UI\Areas\Admin\Views\Teacher\Index.cshtml"
                                                                                    Write(item.Surname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>Computer Science</td>\r\n                        <td>");
#nullable restore
#line 27 "C:\Users\Batuhan\source\repos\OnlineExamProject\Presentation\OnlineExamProject.UI\Areas\Admin\Views\Teacher\Index.cshtml"
                       Write(item.CreatedDate);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                        <td><span class=""badge bg-label-success me-1"">Aktif</span></td>
                        <td><a href=""#""><i class=""bx bx-edit""></i></a>                         
                         <a href=""#""><i class=""bx bx-trash""></i></a>    
                        </td>
                      </tr>
");
#nullable restore
#line 33 "C:\Users\Batuhan\source\repos\OnlineExamProject\Presentation\OnlineExamProject.UI\Areas\Admin\Views\Teacher\Index.cshtml"
                      }                                                                

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                  </table>\r\n                </div>\r\n              </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Teacher>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

#pragma checksum "C:\Users\Batuhan\source\repos\OnlineExamProject\Presentation\OnlineExamProject.UI\Areas\Admin\Views\Exam\AddExam.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e2c0b113bc8a23f860fc476cd07987f278c14e30"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Exam_AddExam), @"mvc.1.0.view", @"/Areas/Admin/Views/Exam/AddExam.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e2c0b113bc8a23f860fc476cd07987f278c14e30", @"/Areas/Admin/Views/Exam/AddExam.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_Exam_AddExam : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OnlineExamProject.Domain.Entities.Exam>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/jquery/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/jquery-validation/dist/jquery.validate.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/jquery-validation-unobtrusive/jquery.validate.unobtrusive.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/signalr/dist/browser/signalr.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Batuhan\source\repos\OnlineExamProject\Presentation\OnlineExamProject.UI\Areas\Admin\Views\Exam\AddExam.cshtml"
  
    ViewData["Title"] = "Sınav Ekle";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e2c0b113bc8a23f860fc476cd07987f278c14e304870", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e2c0b113bc8a23f860fc476cd07987f278c14e305909", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e2c0b113bc8a23f860fc476cd07987f278c14e306948", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e2c0b113bc8a23f860fc476cd07987f278c14e307987", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<h1>AddExam</h1>\r\n<form action=\"/Admin/Exam/AddExam/\" method=\"post\" class=\"m-3\">\r\n   <div asp-validation-summary=\"ModelOnly\"></div>\r\n \r\n    ");
#nullable restore
#line 14 "C:\Users\Batuhan\source\repos\OnlineExamProject\Presentation\OnlineExamProject.UI\Areas\Admin\Views\Exam\AddExam.cshtml"
Write(Html.TextBoxFor(x=>x.Name,new{@class="form-control"} ));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 15 "C:\Users\Batuhan\source\repos\OnlineExamProject\Presentation\OnlineExamProject.UI\Areas\Admin\Views\Exam\AddExam.cshtml"
Write(Html.ValidationMessageFor(x=>x.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n  \r\n    ");
#nullable restore
#line 17 "C:\Users\Batuhan\source\repos\OnlineExamProject\Presentation\OnlineExamProject.UI\Areas\Admin\Views\Exam\AddExam.cshtml"
Write(Html.TextBoxFor(x=>x.Description,new{@class="form-control"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 18 "C:\Users\Batuhan\source\repos\OnlineExamProject\Presentation\OnlineExamProject.UI\Areas\Admin\Views\Exam\AddExam.cshtml"
Write(Html.ValidationMessageFor(x=>x.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    \r\n    ");
#nullable restore
#line 20 "C:\Users\Batuhan\source\repos\OnlineExamProject\Presentation\OnlineExamProject.UI\Areas\Admin\Views\Exam\AddExam.cshtml"
Write(Html.TextBoxFor(x=>x.Time,new{@class="form-control"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 21 "C:\Users\Batuhan\source\repos\OnlineExamProject\Presentation\OnlineExamProject.UI\Areas\Admin\Views\Exam\AddExam.cshtml"
Write(Html.ValidationMessageFor(x=>x.Time));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n   \r\n");
            WriteLiteral(@"   
    
     <input type=""text"" id=""txtMessage""> <button>Gönder</button>
   <ul id=""messages"">
</form>  



<script>
//(function setupConnection() {
//var connection = new signalR.HubConnectionBuilder().withUrl(""/exam-hub"").build();
//connection.on(""receiveExamAddedMessage"")

//connection.start().catch(err => console.error(err.toString())).then(response => console.log(""connected""));
//}) ();

//setupConnection();


(function setupConnection() {
      var connection = new signalR.HubConnectionBuilder()
         .withUrl(""https://localhost:44398/exam-hub"")
         .build();
 
     connection.start().catch(err => console.error(err.toString())).then(response => console.log(""connected""));
 
      $(""button"").click(() => {
         let message = $(""#txtMessage"").val();
         connection.invoke(""ProductAddedMessageAsync"", message)
            .catch(error => console.log(""Mesaj gönderilirken hata alınmıştır.""));
      });
 
      connection.on(""receiveExamAddedMessage"", message => ");
            WriteLiteral(@"{
         $(""#messages"").append(`${message}<br>`);
      });
 
 }) ();
setupConnection();
//const connection = new signalR.HubConnectionBuilder()
//        .withUrl(""/exam-hub"")      
//        .build();
//connection.on(""receiveExamAddedMessage"")
      
//    connection.start()
//        .then(() => console.log('connected!'))
//        .catch(console.error);
        
//   document.getElementById(""text"").value=");
#nullable restore
#line 71 "C:\Users\Batuhan\source\repos\OnlineExamProject\Presentation\OnlineExamProject.UI\Areas\Admin\Views\Exam\AddExam.cshtml"
                                      Write(ViewBag.data);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
//    });
//const connection = new signalR.HubConnectionBuilder()
//    .withUrl(""/exam-hub"")
//    .build();
 
//connection.on(""receiveExamAddedMessage"" => {
   
//    const li = document.createElement(""li"");
//    li.textContent = encodedMsg;
//    document.getElementById(""text"").appendChild(li);
//});

//connection.start().catch(err => console.error(err.toString()));

//Send the message  


</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OnlineExamProject.Domain.Entities.Exam> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
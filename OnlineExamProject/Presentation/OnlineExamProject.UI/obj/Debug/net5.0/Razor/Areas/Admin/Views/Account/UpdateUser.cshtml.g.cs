#pragma checksum "C:\Users\Batuhan\source\repos\OnlineExamProject\Presentation\OnlineExamProject.UI\Areas\Admin\Views\Account\UpdateUser.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c66cb5a59ba3943bc57d57090f66d157c0f5a12f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Account_UpdateUser), @"mvc.1.0.view", @"/Areas/Admin/Views/Account/UpdateUser.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c66cb5a59ba3943bc57d57090f66d157c0f5a12f", @"/Areas/Admin/Views/Account/UpdateUser.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_Account_UpdateUser : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OnlineExamProject.Application.DTOs.User.UserUpdateDTO>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Batuhan\source\repos\OnlineExamProject\Presentation\OnlineExamProject.UI\Areas\Admin\Views\Account\UpdateUser.cshtml"
  
    ViewData["Title"] = "Kullanıcıyı Güncelle";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""col-xxl m-5"">
                  <div class=""card mb-4"">
                    <div class=""card-header d-flex align-items-center justify-content-between"">
                      <h5 class=""mb-0"">Basic with Icons</h5>
                      <small class=""text-muted float-end"">Merged input group</small>
                    </div>
                    <div class=""card-body"">
                      <form method=""post"" action=""/Admin/Account/UpdateUser/"">
                          ");
#nullable restore
#line 16 "C:\Users\Batuhan\source\repos\OnlineExamProject\Presentation\OnlineExamProject.UI\Areas\Admin\Views\Account\UpdateUser.cshtml"
                     Write(Html.HiddenFor(x=>x.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        <div class=""row mb-3"">
                          <label class=""col-sm-2 col-form-label"" for=""basic-icon-default-fullname"">Ad</label>
                          <div class=""col-sm-10"">
                            <div class=""input-group input-group-merge"">
                              <span id=""basic-icon-default-fullname2"" class=""input-group-text""
                                ><i class=""bx bx-user""></i
                              ></span>                         
                                 ");
#nullable restore
#line 24 "C:\Users\Batuhan\source\repos\OnlineExamProject\Presentation\OnlineExamProject.UI\Areas\Admin\Views\Account\UpdateUser.cshtml"
                            Write(Html.TextBoxFor(x=>x.Name ,new{@class="form-control",@id="basic-icon-default-email"}));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </div>
                          </div>
                        </div>
                         <div class=""row mb-3"">
                          <label class=""col-sm-2 col-form-label"" for=""basic-icon-default-fullname"">Soyad</label>
                          <div class=""col-sm-10"">
                            <div class=""input-group input-group-merge"">
                              <span id=""basic-icon-default-fullname2"" class=""input-group-text""
                                ><i class=""bx bx-user""></i
                              ></span>
                              ");
#nullable restore
#line 35 "C:\Users\Batuhan\source\repos\OnlineExamProject\Presentation\OnlineExamProject.UI\Areas\Admin\Views\Account\UpdateUser.cshtml"
                         Write(Html.TextBoxFor(x=>x.Surname ,new{@class="form-control",@id="basic-icon-default-email"}));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </div>
                          </div>
                        </div>
                        <div class=""row mb-3"">
                          <label class=""col-sm-2 col-form-label"" for=""basic-icon-default-company"">Kullanıcı Adı</label>
                          <div class=""col-sm-10"">
                            <div class=""input-group input-group-merge"">
                              <span id=""basic-icon-default-company2"" class=""input-group-text""
                                ><i class=""bx bx-buildings""></i
                              ></span>                       
                                 ");
#nullable restore
#line 46 "C:\Users\Batuhan\source\repos\OnlineExamProject\Presentation\OnlineExamProject.UI\Areas\Admin\Views\Account\UpdateUser.cshtml"
                            Write(Html.TextBoxFor(x=>x.Username ,new{@class="form-control",@id="basic-icon-default-email"}));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </div>
                          </div>
                        </div>
                        <div class=""row mb-3"">
                          <label class=""col-sm-2 col-form-label"" for=""basic-icon-default-email"">Mail</label>
                          <div class=""col-sm-10"">
                            <div class=""input-group input-group-merge"">
                              <span class=""input-group-text""><i class=""bx bx-envelope""></i></span>                                                           ");
#nullable restore
#line 54 "C:\Users\Batuhan\source\repos\OnlineExamProject\Presentation\OnlineExamProject.UI\Areas\Admin\Views\Account\UpdateUser.cshtml"
                                                                                                                                                        Write(Html.TextBoxFor(x=>x.EMail ,new{@class="form-control",@id="basic-icon-default-email"}));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </div>                           
                          </div>
                        </div>
                        <div class=""row mb-3"">
                          <label class=""col-sm-2 form-label"" for=""basic-icon-default-phone"">Telefon No</label>
                          <div class=""col-sm-10"">
                            <div class=""input-group input-group-merge"">
                              <span id=""basic-icon-default-phone2"" class=""input-group-text""
                                ><i class=""bx bx-phone""></i
                              ></span>
                              <input
                                type=""text""
                                id=""basic-icon-default-phone""
                                class=""form-control phone-mask""
                                placeholder=""658 799 8941""
                                aria-label=""658 799 8941""
                                aria-describedby=""basic-icon-default-phone2""
       ");
            WriteLiteral(@"                       />
                            </div>
                          </div>
                        </div>
                        <div class=""row mb-3"">
                          <label class=""col-sm-2 form-label"" for=""basic-icon-default-message"">Rol</label>
                          <div class=""col-sm-10"">
                            <div class=""input-group input-group-merge"">
                              <span id=""basic-icon-default-message2"" class=""input-group-text""
                                ><i class=""bx bx-down-arrow-alt""></i
                              ></span>
                         ");
#nullable restore
#line 83 "C:\Users\Batuhan\source\repos\OnlineExamProject\Presentation\OnlineExamProject.UI\Areas\Admin\Views\Account\UpdateUser.cshtml"
                    Write(Html.DropDownListFor(x=>x.Role,(List<SelectListItem>)ViewBag.role,new{@class="form-control"}));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </div>
                          </div>
                        </div>                
                        <div class=""row justify-content-end"">
                          <div class=""col-sm-10"">
                            <button type=""submit"" class=""btn btn-primary"">Send</button>
                          </div>
                        </div>
                      </form>
                    </div>
                  </div>
                </div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OnlineExamProject.Application.DTOs.User.UserUpdateDTO> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

#pragma checksum "C:\Users\Veronika\Desktop\projectVirtualReality\virtualReality\Views\Home\Registration.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f778f5cf3c0134373641f676d66bdcaa05557527"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Registration), @"mvc.1.0.view", @"/Views/Home/Registration.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f778f5cf3c0134373641f676d66bdcaa05557527", @"/Views/Home/Registration.cshtml")]
    #nullable restore
    public class Views_Home_Registration : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<virtualReality.ViewModels.RegistrationVM>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Veronika\Desktop\projectVirtualReality\virtualReality\Views\Home\Registration.cshtml"
  
    Layout = "/Views/Shared/_Site.cshtml";
    ViewData["title"] = "Registration";


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"col-lg-8\" style=\"margin: 120px auto;\">\r\n    <form action=\"/Home/Registration\" method=\"post\" id=\"contact\">\r\n        <div class=\"row\">\r\n            <div class=\"label\" for=\"username\">\r\n                ");
#nullable restore
#line 12 "C:\Users\Veronika\Desktop\projectVirtualReality\virtualReality\Views\Home\Registration.cshtml"
           Write(Html.LabelFor(m => m.Username));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"input\" id=\"username\" name=\"username\" required=\"required\">\r\n                ");
#nullable restore
#line 15 "C:\Users\Veronika\Desktop\projectVirtualReality\virtualReality\Views\Home\Registration.cshtml"
           Write(Html.TextBoxFor(m => m.Username));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"input\">");
#nullable restore
#line 17 "C:\Users\Veronika\Desktop\projectVirtualReality\virtualReality\Views\Home\Registration.cshtml"
                          Write(Html.ValidationMessageFor(m => m.Username));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n        </div>\r\n        <div class=\"row\">\r\n            <div class=\"label\" for=\"password\">");
#nullable restore
#line 20 "C:\Users\Veronika\Desktop\projectVirtualReality\virtualReality\Views\Home\Registration.cshtml"
                                         Write(Html.LabelFor(m => m.Password));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n            <div class=\"input\" id=\"password\" name=\"password\" required=\"required\">\r\n                ");
#nullable restore
#line 22 "C:\Users\Veronika\Desktop\projectVirtualReality\virtualReality\Views\Home\Registration.cshtml"
           Write(Html.TextBoxFor(m => m.Password));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"input\">");
#nullable restore
#line 24 "C:\Users\Veronika\Desktop\projectVirtualReality\virtualReality\Views\Home\Registration.cshtml"
                          Write(Html.ValidationMessageFor(m => m.Password));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n        </div>\r\n        <div class=\"row\">\r\n            <div class=\"label\" for=\"phone\" id=\"labelTel\">");
#nullable restore
#line 27 "C:\Users\Veronika\Desktop\projectVirtualReality\virtualReality\Views\Home\Registration.cshtml"
                                                    Write(Html.LabelFor(m => m.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n            <div class=\"input\" id=\"phone\" name=\"telephone\" required=\"required\" pattern=\"[0-9]{3}-[0-9{3}-[0-9]{4}\">\r\n                ");
#nullable restore
#line 29 "C:\Users\Veronika\Desktop\projectVirtualReality\virtualReality\Views\Home\Registration.cshtml"
           Write(Html.TextBoxFor(m => m.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"input\">");
#nullable restore
#line 31 "C:\Users\Veronika\Desktop\projectVirtualReality\virtualReality\Views\Home\Registration.cshtml"
                          Write(Html.ValidationMessageFor(m => m.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n        </div>\r\n        <div class=\"row\">\r\n        <div class=\"label\" for=\"email\" id=\"labelEmail\">");
#nullable restore
#line 34 "C:\Users\Veronika\Desktop\projectVirtualReality\virtualReality\Views\Home\Registration.cshtml"
                                                  Write(Html.LabelFor(m => m.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div> <br>\r\n        <div class=\"input\" id=\"em\" name=\"email\" required=\"required\">\r\n            ");
#nullable restore
#line 36 "C:\Users\Veronika\Desktop\projectVirtualReality\virtualReality\Views\Home\Registration.cshtml"
       Write(Html.TextBoxFor(m => m.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"input\">\r\n            ");
#nullable restore
#line 39 "C:\Users\Veronika\Desktop\projectVirtualReality\virtualReality\Views\Home\Registration.cshtml"
       Write(Html.ValidationMessageFor(m => m.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </div>
        </div>
        <div class=""col-lg-8"">
            <div>
                <button class=""btn col-lg-6"" type=""submit"" style=""background:rgba(125,90,254,1)  25%;"">Register</button>
            </div>
        </div>
    </form>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<virtualReality.ViewModels.RegistrationVM> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
#pragma checksum "C:\Users\Veronika\Desktop\projectVirtualReality\virtualReality\Views\Home\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9812132f1e36ac89cc5f2124f4b2b17d88666c14"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Login), @"mvc.1.0.view", @"/Views/Home/Login.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9812132f1e36ac89cc5f2124f4b2b17d88666c14", @"/Views/Home/Login.cshtml")]
    public class Views_Home_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Veronika\Desktop\projectVirtualReality\virtualReality\Views\Home\Login.cshtml"
  
    Layout = "/Views/Shared/_Site.cshtml";
    ViewData["title"] = "Login";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container"">
    <form class=""form"">
        <span class=""log"">Login</span>
        <div class=""form-group"">
            <label class=""label"" for=""username"">Username</label>
            <input type=""text"" class=""input"" id=""username"" name=""username"" placeholder=""Enter your name"" required=""required"" />
        </div>
        <div class=""form-group"">
            <label class=""label"" for=""password"">Password</label>
            <input type=""password"" class=""input"" id=""password"" name=""password"" placeholder=""Enter your password"" required=""required"" />
        </div>
        <div class=""form-group"">
            <label class=""label"" for=""phone"" id=""labelTel"">Phone</label>
            <input type=""tel"" class=""input"" id=""phone"" name=""telephone"" placeholder=""Enter your phone number"" required=""required"" pattern=""[0-9]{3}-[0-9{3}-[0-9]{4}"" />
        </div>
        <div class=""form-group"">
            <label class=""label"" for=""email"" id=""labelEmail"">Email</label> <br>
            <input type=""");
            WriteLiteral(@"email"" class=""input"" id=""em"" name=""email"" placeholder=""Enter your Email"" required=""required"" />
        </div>
        <div class=""form-group"">
            <span class=""label"">Choose Gender</span>
            <div>
                <select class=""selection"" name=""gender"" id=""gender"">
                    <option value=""Female"">Female</option>
                    <option value=""Male"">Male</option>
                    <option value=""Not defined"">Gender</option>
                </select>
            </div>
            <div class=""form-group"">
                <span class=""label"">Choose City</span>
                <div>
                    <select class=""selection"" name=""town"" id=""town"">
                        <option value=""Manchester"">Plovdiv</option>
                        <option value=""London"">Leeds</option>
                        <option value=""New York"">Varna</option>
                    </select>
                </div>
            </div>
            <div>
                <button clas");
            WriteLiteral("s=\"btn\" type=\"submit\">Log in</button>\r\n            </div>\r\n        </div>\r\n    </form>\r\n</div>\r\n");
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

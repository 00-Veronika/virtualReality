#pragma checksum "C:\Users\Veronika\Desktop\projectVirtualReality\virtualReality\Views\Shared\_Site.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2fa502eb647bfe8d71305ad9cfb3e4a923dac8ac"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Site), @"mvc.1.0.view", @"/Views/Shared/_Site.cshtml")]
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
#line 1 "C:\Users\Veronika\Desktop\projectVirtualReality\virtualReality\Views\Shared\_Site.cshtml"
using virtualReality.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Veronika\Desktop\projectVirtualReality\virtualReality\Views\Shared\_Site.cshtml"
using virtualReality.Extensions;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2fa502eb647bfe8d71305ad9cfb3e4a923dac8ac", @"/Views/Shared/_Site.cshtml")]
    public class Views_Shared__Site : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Veronika\Desktop\projectVirtualReality\virtualReality\Views\Shared\_Site.cshtml"
   
    Users loggedUser = this.ViewContext.HttpContext.Session.GetObject<Users>("loggedUser");
    var controller = @ViewContext.RouteData.Values["controller"].ToString();
    var action = @ViewContext.RouteData.Values["action"].ToString();


#line default
#line hidden
#nullable disable
            WriteLiteral("<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2fa502eb647bfe8d71305ad9cfb3e4a923dac8ac3538", async() => {
                WriteLiteral(@"
    <meta charset=""utf-8"">
    <meta name=""author"" content=""templatemo"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1, shrink-to-fit=no"">

    <link href=""https://fonts.googleapis.com/css2?family=Roboto:wght@100;300;400;500;700;900&display=swap"" rel=""stylesheet"">

    <title>");
#nullable restore
#line 17 "C:\Users\Veronika\Desktop\projectVirtualReality\virtualReality\Views\Shared\_Site.cshtml"
      Write(ViewData["title"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</title>

    <!-- Bootstrap core CSS -->
    <link href=""/css/vendor/bootstrap/css/bootstrap.min.css"" rel=""stylesheet"">

    <!-- Additional CSS Files -->
    <link rel=""stylesheet"" href=""/css/assets/css/fontawesome.css"">
    <link rel=""stylesheet"" href=""/css/assets/css/templatemo-liberty-market.css"">
    <link rel=""stylesheet"" href=""/css/assets/css/owl.css"">
    <link rel=""stylesheet"" href=""/css/assets/css/animate.css"">
    <link rel=""stylesheet"" href=""https://unpkg.com/swiper@7/swiper-bundle.min.css"" />

    

");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2fa502eb647bfe8d71305ad9cfb3e4a923dac8ac5621", async() => {
                WriteLiteral(@"
    <!-- Header area start -->
    <header class=""header-area header-sticky"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-12"">
                    <nav class=""main-nav"">
                        <!-- Menu start -->
                        <ul class=""nav"">
                            <li>
                                <a href=""/Home/Index"" class=""active""> Home </a>
                            </li>
                            <li>
                                <a href=""/Home/details""> Item Details </a>
                            </li>
                           
");
#nullable restore
#line 48 "C:\Users\Veronika\Desktop\projectVirtualReality\virtualReality\Views\Shared\_Site.cshtml"
                             if (loggedUser != null )
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                <li>
                                    <a href=""/Home/Logout""> Logout </a>
                                </li>
                                <li>
                                    <a href=""/Games/AllGames"">Games</a>
                                </li>
");
#nullable restore
#line 56 "C:\Users\Veronika\Desktop\projectVirtualReality\virtualReality\Views\Shared\_Site.cshtml"
                            }
                            else
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 59 "C:\Users\Veronika\Desktop\projectVirtualReality\virtualReality\Views\Shared\_Site.cshtml"
                                 if (controller.ToLower() != "home" || action.ToLower() != "login")
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <li><a href=\"/Home/Login\">Login</a></li>\r\n");
#nullable restore
#line 62 "C:\Users\Veronika\Desktop\projectVirtualReality\virtualReality\Views\Shared\_Site.cshtml"

                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 64 "C:\Users\Veronika\Desktop\projectVirtualReality\virtualReality\Views\Shared\_Site.cshtml"
                                 if (controller.ToLower() != "home" || action.ToLower() != "register")
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <li><a href=\"/Home/Registration\">Register</a></li>\r\n");
#nullable restore
#line 67 "C:\Users\Veronika\Desktop\projectVirtualReality\virtualReality\Views\Shared\_Site.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 67 "C:\Users\Veronika\Desktop\projectVirtualReality\virtualReality\Views\Shared\_Site.cshtml"
                                 
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </ul>\r\n                        <!--  Menu end -->\r\n                    </nav>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </header>\r\n    <!-- Header area end -->\r\n\r\n    <div>\r\n        ");
#nullable restore
#line 80 "C:\Users\Veronika\Desktop\projectVirtualReality\virtualReality\Views\Shared\_Site.cshtml"
   Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
    </div>

    <!-- Footer-->
    <footer>
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-12"">
                    <p>Project_VirtualReality - Вероника Пенева - 2101681046
                </div>
            </div>
        </div>
    </footer>
    <!-- Footer end -->
    <!-- Scripts -->
    <!-- Bootstrap core JavaScript -->
    <script src=""/css/vendor/jquery/jquery.min.js""></script>
    <script src=""/css/vendor/bootstrap/js/bootstrap.min.js""></script>

    <script src=""/css/assets/js/isotope.min.js""></script>
    <script src=""/css/assets/js/owl-carousel.js""></script>

    <script src=""/css/assets/js/tabs.js""></script>
    <script src=""/css/assets/js/popup.js""></script>
    <script src=""/css/assets/js/custom.js""></script>

");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
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

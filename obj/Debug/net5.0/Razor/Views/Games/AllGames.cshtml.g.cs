#pragma checksum "C:\Users\Veronika\Desktop\projectVirtualReality\virtualReality\Views\Games\AllGames.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6c80be167c0c26689dcc9fb13671bd618a23b079"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Games_AllGames), @"mvc.1.0.view", @"/Views/Games/AllGames.cshtml")]
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
#line 1 "C:\Users\Veronika\Desktop\projectVirtualReality\virtualReality\Views\Games\AllGames.cshtml"
using virtualReality.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6c80be167c0c26689dcc9fb13671bd618a23b079", @"/Views/Games/AllGames.cshtml")]
    public class Views_Games_AllGames : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<virtualReality.ViewModels.GamesVM.AllGamesVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\Veronika\Desktop\projectVirtualReality\virtualReality\Views\Games\AllGames.cshtml"
  
    this.ViewData["title"] = "Games";
    this.Layout = "/Views/Shared/_Site.cshtml";


#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container mt-4\">\r\n    <div class=\"container mb-2\">\r\n");
#nullable restore
#line 11 "C:\Users\Veronika\Desktop\projectVirtualReality\virtualReality\Views\Games\AllGames.cshtml"
         foreach (var item in Model.Items)
        {


#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""col-lg-8"" style=""margin: 150px auto; justify-content: start;"">
                <div class=""card"" style=""width: 16rem;"">
                    <div class=""card-body"" style=""border-color: #8c52f1;"">
                        <h5 class=""card-title"" style=""color: #8c52f1;"">");
#nullable restore
#line 17 "C:\Users\Veronika\Desktop\projectVirtualReality\virtualReality\Views\Games\AllGames.cshtml"
                                                                  Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                        <h6 class=\"card-subtitle mb-2 text-muted\">Price: ");
#nullable restore
#line 18 "C:\Users\Veronika\Desktop\projectVirtualReality\virtualReality\Views\Games\AllGames.cshtml"
                                                                    Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" USD.</h6>\r\n                        <h6 class=\"card-subtitle mb-2 text-muted\">\r\n                            Genres:\r\n");
#nullable restore
#line 21 "C:\Users\Veronika\Desktop\projectVirtualReality\virtualReality\Views\Games\AllGames.cshtml"
                             if (Model.Genres != null)
                            {
                                foreach (var genre in Model.Genres)
                                {


#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <span>");
#nullable restore
#line 26 "C:\Users\Veronika\Desktop\projectVirtualReality\virtualReality\Views\Games\AllGames.cshtml"
                                     Write(genre.name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 27 "C:\Users\Veronika\Desktop\projectVirtualReality\virtualReality\Views\Games\AllGames.cshtml"
                                }
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </h6>\r\n                        <h6 class=\"card-subtitle mb-2 text-muted\">\r\n                            Manufacturer:\r\n                            ");
#nullable restore
#line 33 "C:\Users\Veronika\Desktop\projectVirtualReality\virtualReality\Views\Games\AllGames.cshtml"
                       Write(item.manufacturer);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </h6>\r\n                        <h6 class=\"card-subtitle mb-2 text-muted\">\r\n                            Year of release:\r\n                            ");
#nullable restore
#line 37 "C:\Users\Veronika\Desktop\projectVirtualReality\virtualReality\Views\Games\AllGames.cshtml"
                       Write(item.releaseDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </h6>\r\n                        <a class=\"btn\" style=\"color: #8c52f1; border-color:#8c52f1; margin:20px;\"");
            BeginWriteAttribute("href", " href=\"", 1649, "\"", 1679, 2);
            WriteAttributeValue("", 1656, "/Games/Edit?id=", 1656, 15, true);
#nullable restore
#line 39 "C:\Users\Veronika\Desktop\projectVirtualReality\virtualReality\Views\Games\AllGames.cshtml"
WriteAttributeValue("", 1671, item.Id, 1671, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 43 "C:\Users\Veronika\Desktop\projectVirtualReality\virtualReality\Views\Games\AllGames.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <a class=\"btn\" style=\"color: #8c52f1; border-color: #8c52f1; margin:20px;\" href=\"/Games/Create\">Add Games</a>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<virtualReality.ViewModels.GamesVM.AllGamesVM> Html { get; private set; }
    }
}
#pragma warning restore 1591

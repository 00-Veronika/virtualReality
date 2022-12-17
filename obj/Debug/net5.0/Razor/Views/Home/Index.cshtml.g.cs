#pragma checksum "C:\Users\Veronika\Desktop\projectVirtualReality\virtualReality\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "806d317db2aac8d7162cbf42f6cc08837c0adcb8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"806d317db2aac8d7162cbf42f6cc08837c0adcb8", @"/Views/Home/Index.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "806d317db2aac8d7162cbf42f6cc08837c0adcb82726", async() => {
                WriteLiteral(@"
    <meta charset=""utf-8"">
    <meta name=""author"" content=""templatemo"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1, shrink-to-fit=no"">

    <link href=""https://fonts.googleapis.com/css2?family=Roboto:wght@100;300;400;500;700;900&display=swap"" rel=""stylesheet"">

    <title>Project_VirtualReality</title>

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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "806d317db2aac8d7162cbf42f6cc08837c0adcb84582", async() => {
                WriteLiteral(@"
    <!-- Header area start -->
    <header class=""header-area header-sticky"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-12"">
                    <nav class=""main-nav"">
                        <!-- Menu start -->
                        <ul class=""nav"">
                            <li><a href=""index.html"" class=""active"">Home</a></li>
                            <li><a href=""explore.html"">Explore</a></li>
                            <li><a href=""details.html"">Item Details</a></li>
                            <li><a href=""author.html"">Author</a></li>
                        </ul>
                        <!--  Menu end -->
                    </nav>
                </div>
            </div>
        </div>
    </header>
    <!-- Header area end -->
    <!-- Main banner area start -->
    <div class=""main-banner"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-6 align-self-center"">
      ");
                WriteLiteral(@"              <div class=""header-text"">
                        <h2>Virtual Reality </h2>
                        <p>
                            Virtual Reality is a computer-generated environment with scenes and objects that appear to be real,
                            making the user feel they are immersed in their surroundings. This environment is perceived through
                            a device known as a Virtual Reality headset or helmet. VR allows us to immerse ourselves in video games as if
                            we were one of the characters, learn how to perform heart surgery or improve the quality of sports training to maximise performance.
                        </p>
                        <div class=""buttons"">
                            <div class=""border-button"">
                                <a>Description</a>
                            </div>
                            <div class=""main-button"">
                                <a>Watch live</a>
                ");
                WriteLiteral(@"            </div>
                        </div>
                    </div>
                </div>
                <div class=""col-lg-5 offset-lg-1"">
                    <div class=""owl-banner owl-carousel"">
                        <div class=""item"">
                            <img src=""/css/assets/images/banner-01.png""");
                BeginWriteAttribute("alt", " alt=\"", 3289, "\"", 3295, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                        </div>\r\n                        <div class=\"item\">\r\n                            <img src=\"/css/assets/images/banner-02.png\"");
                BeginWriteAttribute("alt", " alt=\"", 3446, "\"", 3452, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Main banner area end  -->
    <!--Categories -->
    <div class=""categories-collections"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-12"">
                    <div class=""categories"">
                        <div class=""row"">
                            <div class=""col-lg-12"">
                                <div class=""section-heading"">
                                    <div class=""line-dec""></div>
                                    <h2>Categories</h2>
                                </div>
                            </div>
                            <div class=""col-lg-2 col-sm-6"">
                                <div class=""item"">
                                    <div class=""icon"">
                                        <img src=""/css/assets/images/icon-01.png""");
                BeginWriteAttribute("alt", " alt=\"", 4449, "\"", 4455, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                                    </div>
                                    <h4>Blockchain</h4>
                                    <div class=""icon-button"">
                                        <a href=""#""><i class=""fa fa-angle-right""></i></a>
                                    </div>
                                </div>
                            </div>
                            <div class=""col-lg-2 col-sm-6"">
                                <div class=""item"">
                                    <div class=""icon"">
                                        <img src=""/css/assets/images/icon-02.png""");
                BeginWriteAttribute("alt", " alt=\"", 5084, "\"", 5090, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                                    </div>
                                    <h4>Digital Art</h4>
                                    <div class=""icon-button"">
                                        <a href=""#""><i class=""fa fa-angle-right""></i></a>
                                    </div>
                                </div>
                            </div>
                            <div class=""col-lg-2 col-sm-6"">
                                <div class=""item"">
                                    <div class=""icon"">
                                        <img src=""/css/assets/images/icon-03.png""");
                BeginWriteAttribute("alt", " alt=\"", 5720, "\"", 5726, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                                    </div>
                                    <h4>Music Art</h4>
                                    <div class=""icon-button"">
                                        <a href=""#""><i class=""fa fa-angle-right""></i></a>
                                    </div>
                                </div>
                            </div>
                            <div class=""col-lg-2 col-sm-6"">
                                <div class=""item"">
                                    <div class=""icon"">
                                        <img src=""/css/assets/images/icon-04.png""");
                BeginWriteAttribute("alt", " alt=\"", 6354, "\"", 6360, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                                    </div>
                                    <h4>Virtual World</h4>
                                    <div class=""icon-button"">
                                        <a href=""#""><i class=""fa fa-angle-right""></i></a>
                                    </div>
                                </div>
                            </div>
                            <div class=""col-lg-2 col-sm-6"">
                                <div class=""item"">
                                    <div class=""icon"">
                                        <img src=""/css/assets/images/icon-05.png""");
                BeginWriteAttribute("alt", " alt=\"", 6992, "\"", 6998, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                                    </div>
                                    <h4>Valuable</h4>
                                    <div class=""icon-button"">
                                        <a href=""#""><i class=""fa fa-angle-right""></i></a>
                                    </div>
                                </div>
                            </div>
                            <div class=""col-lg-2 col-sm-6"">
                                <div class=""item"">
                                    <div class=""icon"">
                                        <img src=""/css/assets/images/icon-06.png""");
                BeginWriteAttribute("alt", " alt=\"", 7625, "\"", 7631, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                                    </div>
                                    <h4> Glasses</h4>
                                    <div class=""icon-button"">
                                        <a href=""#""><i class=""fa fa-angle-right""></i></a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
    <!--Categories end -->

    <!-- info -->
    <div class=""create-nft"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-8"">
                    <div class=""section-heading"">
                        <div class=""line-dec""></div>
                        <h2>Create your virtual game and  put it on the market</h2>
                    </div>
                </div>
                <div class=""col-lg-4"">
                    <div class=""main-button"">
  ");
                WriteLiteral("                      <a");
                BeginWriteAttribute("href", " href=\"", 8680, "\"", 8687, 0);
                EndWriteAttribute();
                WriteLiteral(@">Create now</a>
                    </div>
                </div>
                <div class=""col-lg-4"">
                    <div class=""item first-item"">
                        <div class=""number"">
                            <h6>1</h6>
                        </div>
                        <div class=""icon"">
                            <img src=""/css/assets/images/icon-02.png""");
                BeginWriteAttribute("alt", " alt=\"", 9079, "\"", 9085, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                        </div>
                        <h4>Description</h4>
                        <p>
                            With avatar image-based virtual reality, people can join the virtual environment in the form of real video as well as an avatar.
                            One can participate in the 3D distributed virtual environment as form of either a conventional avatar or a real video. Users can select their own type of participation based on the system capability.
                        </p>
                    </div>
                </div>
                <div class=""col-lg-4"">
                    <div class=""item second-item"">
                        <div class=""number"">
                            <h6>2</h6>
                        </div>
                        <div class=""icon"">
                            <img src=""/css/assets/images/icon-04.png""");
                BeginWriteAttribute("alt", " alt=\"", 9988, "\"", 9994, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                        </div>
                        <h4>Health and safety</h4>
                        <p>
                            VR headsets may regularly cause eye fatigue, as does all screened technology, because people tend to blink less when watching screens, causing their eyes to become more dried out. There have been some concerns about VR headsets contributing to myopia,
                            but although VR headsets sit close to the eyes, they may not necessarily contribute to nearsightedness if the focal length of the image being displayed is sufficiently far away.
                        </p>
                    </div>
                </div>
                <div class=""col-lg-4"">
                    <div class=""item"">
                        <div class=""icon"">
                            <img src=""/css/assets/images/icon-06.png""");
                BeginWriteAttribute("alt", " alt=\"", 10874, "\"", 10880, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                        </div>
                        <h4>Privacy</h4>
                        <p>
                            The persistent tracking required by all VR systems makes the technology particularly useful for, and vulnerable to, mass surveillance. The expansion of VR will increase the potential and reduce the costs for information gathering of personal actions, movements and responses.[48] Data from eye tracking sensors, which are projected to become a standard feature in virtual reality headsets,[161][162] may indirectly reveal information about a user's ethnicity, personality traits, fears, emotions, interests, skills, and physical and mental health condition.
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- info end -->
    <!-- Items Currently In The Market -->
    <div class=""currently-market"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg");
                WriteLiteral(@"-6"">
                    <div class=""section-heading"">
                        <div class=""line-dec""></div>
                        <h2><em>Items</em> Currently In The Market.</h2>
                    </div>
                </div>
                <div class=""col-lg-6"">
                    <div class=""filters"">
                        <ul>
                            <li data-filter=""*"" class=""active"">All Items</li>
                            <li data-filter="".msc"">Music Art</li>
                            <li data-filter="".dig"">Digital Art</li>
                            <li data-filter="".blc"">Blockchain</li>
                            <li data-filter="".vtr"">Virtual</li>
                        </ul>
                    </div>
                </div>
                <div class=""col-lg-12"">
                    <div class=""row grid"">
                        <div class=""col-lg-6 currently-market-item all msc"">
                            <div class=""item"">
                                ");
                WriteLiteral("<div class=\"left-image\">\r\n                                    <img src=\"/css/assets/images/market-01.jpg\"");
                BeginWriteAttribute("alt", " alt=\"", 13034, "\"", 13040, 0);
                EndWriteAttribute();
                WriteLiteral(@" style=""border-radius: 20px; min-width: 195px;"">
                                </div>
                                <div class=""right-content"">
                                    <h4>Music Art Super Item</h4>
                                    <span class=""author"">
                                        <img src=""/css/assets/images/author.jpg""");
                BeginWriteAttribute("alt", " alt=\"", 13398, "\"", 13404, 0);
                EndWriteAttribute();
                WriteLiteral(@" style=""max-width: 50px; border-radius: 50%;"">
                                        <h6>
                                            Liberty Artist<br>
                                            <a href=""#""></a>
                                        </h6>
                                    </span>
                                    <div class=""line-dec""></div>
                                    <span class=""bid"">
                                        Current Bid<br><strong>2.03 ETH</strong><br><em>($8,240.50)</em>
                                    </span>
                                    <span class=""ends"">
                                        Ends In<br><strong>4D 08H 15M 42S</strong><br><em>(July 24th, 2022)</em>
                                    </span>
                                    <div class=""text-button"">
                                        <a href=""details.html"">View Item Details</a>
                                    </div>
                              ");
                WriteLiteral(@"  </div>
                            </div>
                        </div>
                        <div class=""col-lg-6 currently-market-item all vrt dig"">
                            <div class=""item"">
                                <div class=""left-image"">
                                    <img src=""/css/assets/images/market-01.jpg""");
                BeginWriteAttribute("alt", " alt=\"", 14774, "\"", 14780, 0);
                EndWriteAttribute();
                WriteLiteral(@" style=""border-radius: 20px; min-width: 195px;"">
                                </div>
                                <div class=""right-content"">
                                    <h4>Digital Art Item</h4>
                                    <span class=""author"">
                                        <img src=""/css/assets/images/author.jpg""");
                BeginWriteAttribute("alt", " alt=\"", 15134, "\"", 15140, 0);
                EndWriteAttribute();
                WriteLiteral(@" style=""max-width: 50px; border-radius: 50%;"">
                                        <h6>Liberty Artist<br><a href=""#""></a></h6>
                                    </span>
                                    <div class=""line-dec""></div>
                                    <span class=""bid"">
                                        Current Bid<br><strong>2.50 ETH</strong><br><em>($8,400.50)</em>
                                    </span>
                                    <span class=""ends"">
                                        Ends In<br><strong>4D 08H 32M 18S</strong><br><em>(July 16th, 2022)</em>
                                    </span>
                                    <div class=""text-button"">
                                        <a href=""details.html"">View Item Details</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class=""col-lg-6 currently-m");
                WriteLiteral("arket-item all blc\">\r\n                            <div class=\"item\">\r\n                                <div class=\"left-image\">\r\n                                    <img src=\"/css/assets/images/market-01.jpg\"");
                BeginWriteAttribute("alt", " alt=\"", 16372, "\"", 16378, 0);
                EndWriteAttribute();
                WriteLiteral(@" style=""border-radius: 20px; min-width: 195px;"">
                                </div>
                                <div class=""right-content"">
                                    <h4>Blockchain Music Design</h4>
                                    <span class=""author"">
                                        <img src=""/css/assets/images/author.jpg""");
                BeginWriteAttribute("alt", " alt=\"", 16739, "\"", 16745, 0);
                EndWriteAttribute();
                WriteLiteral(@" style=""max-width: 50px; border-radius: 50%;"">
                                        <h6>Liberty Artist<br><a href=""#""></a></h6>
                                    </span>
                                    <div class=""line-dec""></div>
                                    <span class=""bid"">
                                        Current Bid<br><strong>2.44 ETH</strong><br><em>($8,200.50)</em>
                                    </span>
                                    <span class=""ends"">
                                        Ends In<br><strong>5D 10H 22M 24S</strong><br><em>(July 18th, 2022)</em>
                                    </span>
                                    <div class=""text-button"">
                                        <a href=""details.html"">View Item Details</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class=""col-lg-6 currently-m");
                WriteLiteral("arket-item all vtr\">\r\n                            <div class=\"item\">\r\n                                <div class=\"left-image\">\r\n                                    <img src=\"/css/assets/images/market-01.jpg\"");
                BeginWriteAttribute("alt", " alt=\"", 17977, "\"", 17983, 0);
                EndWriteAttribute();
                WriteLiteral(@" style=""border-radius: 20px; min-width: 195px;"">
                                </div>
                                <div class=""right-content"">
                                    <h4>Virtual Currency Art</h4>
                                    <span class=""author"">
                                        <img src=""/css/assets/images/author.jpg""");
                BeginWriteAttribute("alt", " alt=\"", 18341, "\"", 18347, 0);
                EndWriteAttribute();
                WriteLiteral(@" style=""max-width: 50px; border-radius: 50%;"">
                                        <h6>Liberty Artist<br><a href=""#""></a></h6>
                                    </span>
                                    <div class=""line-dec""></div>
                                    <span class=""bid"">
                                        Current Bid<br><strong>2.44 ETH</strong><br><em>($8,800.50)</em>
                                    </span>
                                    <span class=""ends"">
                                        Ends In<br><strong>3D 05H 20M 58S</strong><br><em>(July 14th, 2022)</em>
                                    </span>
                                    <div class=""text-button"">
                                        <a href=""details.html"">View Item Details</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
    ");
                WriteLiteral(@"        </div>
        </div>
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
    <script src=""vendor/jquery/jquery.min.js""></script>
    <script src=""vendor/bootstrap/js/bootstrap.min.js""></script>

    <script src=""assets/js/isotope.min.js""></script>
    <script src=""assets/js/owl-carousel.js""></script>

    <script src=""assets/js/tabs.js""></script>
    <script src=""assets/js/popup.js""></script>
    <script src=""assets/js/custom.js""></script>

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
            WriteLiteral("\r\n</html>");
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

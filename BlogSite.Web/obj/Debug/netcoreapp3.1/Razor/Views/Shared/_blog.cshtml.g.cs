#pragma checksum "E:\My Projects\BlogSite.Web\BlogSite.Web\Views\Shared\_blog.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "91d5e2e522a00a294743f466b82ad18b1b1efe55"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__blog), @"mvc.1.0.view", @"/Views/Shared/_blog.cshtml")]
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
#line 1 "E:\My Projects\BlogSite.Web\BlogSite.Web\Views\_ViewImports.cshtml"
using BlogSite.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\My Projects\BlogSite.Web\BlogSite.Web\Views\_ViewImports.cshtml"
using BlogSite.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"91d5e2e522a00a294743f466b82ad18b1b1efe55", @"/Views/Shared/_blog.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fbe164874347a1acc93e8ade8bd8fe35a24e0afb", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__blog : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-img-top"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Card image cap"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("<div class=\"col-md-8\">\r\n");
#nullable restore
#line 2 "E:\My Projects\BlogSite.Web\BlogSite.Web\Views\Shared\_blog.cshtml"
     foreach (var item in ViewBag.Post)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"card mb-4\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "91d5e2e522a00a294743f466b82ad18b1b1efe554065", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 148, "~/image/", 148, 8, true);
#nullable restore
#line 5 "E:\My Projects\BlogSite.Web\BlogSite.Web\Views\Shared\_blog.cshtml"
AddHtmlAttributeValue("", 156, item.Image, 156, 11, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            <div class=\"card-body\">\r\n                <h2 class=\"card-title\">");
#nullable restore
#line 7 "E:\My Projects\BlogSite.Web\BlogSite.Web\Views\Shared\_blog.cshtml"
                                  Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                <p class=\"card-text\">\r\n                    ");
#nullable restore
#line 9 "E:\My Projects\BlogSite.Web\BlogSite.Web\Views\Shared\_blog.cshtml"
               Write(item.Text.Substring(0, 200));

#line default
#line hidden
#nullable disable
            WriteLiteral(". . .\r\n                </p>\r\n                <a href=\"#\" class=\"btn btn-primary\">Read More &rarr;</a>\r\n            </div>\r\n            <div class=\"card-footer text-muted\">\r\n                Posted on ");
#nullable restore
#line 14 "E:\My Projects\BlogSite.Web\BlogSite.Web\Views\Shared\_blog.cshtml"
                     Write(item.datetime.ToString("MM/dd/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" by\r\n                <a>Admin</a>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 18 "E:\My Projects\BlogSite.Web\BlogSite.Web\Views\Shared\_blog.cshtml"

    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>");
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

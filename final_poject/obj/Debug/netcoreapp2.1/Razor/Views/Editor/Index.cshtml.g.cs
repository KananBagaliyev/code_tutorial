#pragma checksum "C:\Users\Kanan\Desktop\final_project\final_poject\Views\Editor\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "86a856c6f9ab172b2b150648781000673d526af3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Editor_Index), @"mvc.1.0.view", @"/Views/Editor/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Editor/Index.cshtml", typeof(AspNetCore.Views_Editor_Index))]
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
#line 1 "C:\Users\Kanan\Desktop\final_project\final_poject\Views\_ViewImports.cshtml"
using final_poject.Models;

#line default
#line hidden
#line 2 "C:\Users\Kanan\Desktop\final_project\final_poject\Views\_ViewImports.cshtml"
using final_poject.ViewModels;

#line default
#line hidden
#line 3 "C:\Users\Kanan\Desktop\final_project\final_poject\Views\_ViewImports.cshtml"
using System.Globalization;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"86a856c6f9ab172b2b150648781000673d526af3", @"/Views/Editor/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"48a023bc38249f464093c9bb251a195d5e384ae0", @"/Views/_ViewImports.cshtml")]
    public class Views_Editor_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/editor/js/editor.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/editor/js/closetag.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/editor/js/javascript.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/editor/js/css.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/editor/js/xml.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
#line 1 "C:\Users\Kanan\Desktop\final_project\final_poject\Views\Editor\Index.cshtml"
   ViewData["Title"] = "Editor"; 

#line default
#line hidden
            BeginContext(35, 1362, true);
            WriteLiteral(@"

<section id=""text_editor"" class=""section-padding"">

    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-4 col-12 code_editor"">
                <div class=""editor_header"">
                    <h3>HTML</h3>
                    <a href="""" class=""code_copy""><i class=""fas fa-copy""></i></a>
                </div>
                <textarea id=""editor""></textarea>
            </div>
            <div class=""col-lg-4 col-12 code_editor"">
                <div class=""editor_header"">
                    <h3>css</h3>
                    <a href="""" class=""code_copy""><i class=""fas fa-copy""></i></a>
                </div>
                <textarea id=""css""></textarea>
            </div>
            <div class=""col-lg-4 col-12 code_editor"">
                <div class=""editor_header"">
                    <h3>js</h3>
                    <a href="""" class=""code_copy""><i class=""fas fa-copy""></i></a>
                </div>
                <textarea id=""js""></textarea>
            </div>
        </d");
            WriteLiteral(@"iv>
        <div class=""row"">
            <div class=""col-12 result_button"">
                <button class=""btn"" id=""show_result"">Nəticəni Göstər</button>
            </div>
            <div class=""col-12"">
                <iframe id=""code_result"" src="""" frameborder=""0""></iframe>
            </div>
        </div>
    </div>

</section>
");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(1414, 5, true);
                WriteLiteral("\n    ");
                EndContext();
                BeginContext(1419, 53, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2b7a770e91cc494187c3ae58c7ffd266", async() => {
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
                EndContext();
                BeginContext(1472, 5, true);
                WriteLiteral("\n    ");
                EndContext();
                BeginContext(1477, 55, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8133237a96a54f508826f14da559d84a", async() => {
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
                EndContext();
                BeginContext(1532, 5, true);
                WriteLiteral("\n    ");
                EndContext();
                BeginContext(1537, 57, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3e6e8f0ef35746bcaf1cfb6fe2740ba2", async() => {
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
                EndContext();
                BeginContext(1594, 5, true);
                WriteLiteral("\n    ");
                EndContext();
                BeginContext(1599, 50, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "af3519dc10974dc0981bb1c1e56ce1b4", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1649, 5, true);
                WriteLiteral("\n    ");
                EndContext();
                BeginContext(1654, 50, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "12ed2928ccfd4db5849836d0725ecb5e", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1704, 2271, true);
                WriteLiteral(@"
    <script>
        var html = CodeMirror.fromTextArea(document.getElementById('editor'),
            {
                mode: ""xml"",
                theme: ""material-palenight"",
                lineNumbers: true,
                autoCloseTags: true,
                value: ""salam"",
                extraKeys: {
                    ""Tab"": ""autocomplete""
                }
            })
        var css = CodeMirror.fromTextArea(document.getElementById('css'),
            {
                mode: ""css"",
                theme: ""material-palenight"",
                lineNumbers: true,
                autoCloseTags: true,
                extraKeys: {
                    ""Tab"": ""autocomplete""
                }
            })
        var js = CodeMirror.fromTextArea(document.getElementById('js'),
            {
                mode: ""javascript"",
                theme: ""material-palenight"",
                lineNumbers: true,
                autoCloseTags: true,
                extraKeys: {
                    ""Tab"": ""au");
                WriteLiteral(@"tocomplete""
                }
            })

        function copy(value) {

            const el = document.createElement('textarea');
            el.value = value;
            document.body.appendChild(el);
            el.select();
            document.execCommand('copy');
            document.body.removeChild(el);
        }
        $("".code_copy"").click(function (e) {
            e.preventDefault()
            var editor = $(this).parent().next().attr(""id"")
            var originalContent = $(this).html();
            var button = $(this)
            if (editor == ""editor"") {
                copy(html.getValue())
            }
            if (editor == ""js"") {
                copy(js.getValue())
            }
            if (editor == ""css"") {
                copy(css.getValue())
            }
            $(this).html(""kopyalandı"")
            setTimeout(function () {
                button.html(originalContent)
            }, 1000)
        })
        $(""#show_result"").click(function () {
            var ");
                WriteLiteral("customhtml = \"<style>\" + css.getValue() + \"</style>\" + html.getValue() + \"<script>\" + js.getValue() + \"<\" + \"/\" + \"script>\"\n            $(\"#code_result\").contents().find(\"body\").html(customhtml);\n        })\n    </script>\n\n\n");
                EndContext();
            }
            );
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

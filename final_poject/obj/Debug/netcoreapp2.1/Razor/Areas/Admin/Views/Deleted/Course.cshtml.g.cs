#pragma checksum "C:\Users\Kanan\Desktop\final_project\final_poject\Areas\Admin\Views\Deleted\Course.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c203db9f995bc9e31699eb5c82e0898e82a43f75"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Deleted_Course), @"mvc.1.0.view", @"/Areas/Admin/Views/Deleted/Course.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Deleted/Course.cshtml", typeof(AspNetCore.Areas_Admin_Views_Deleted_Course))]
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
#line 1 "C:\Users\Kanan\Desktop\final_project\final_poject\Areas\Admin\Views\_ViewImports.cshtml"
using final_poject.Models;

#line default
#line hidden
#line 2 "C:\Users\Kanan\Desktop\final_project\final_poject\Areas\Admin\Views\_ViewImports.cshtml"
using final_poject.ViewModels;

#line default
#line hidden
#line 3 "C:\Users\Kanan\Desktop\final_project\final_poject\Areas\Admin\Views\_ViewImports.cshtml"
using System.Globalization;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c203db9f995bc9e31699eb5c82e0898e82a43f75", @"/Areas/Admin/Views/Deleted/Course.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"48a023bc38249f464093c9bb251a195d5e384ae0", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Deleted_Course : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Course>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Deleted", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success waves-effect waves-light m-1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditCourse", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning btn-round waves-effect waves-light m-1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ActivateCourse", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success btn-round waves-effect waves-light m-1 activate_course"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(27, 254, true);
            WriteLiteral("<div class=\"container-fluid\">\n    <div class=\"row pt-2 pb-2\">\n        <div class=\"col-sm-6\">\n            <h4 class=\"page-title\">Kurslar</h4>\n        </div>\n        <div class=\"col-sm-6\">\n            <div class=\"btn-group float-sm-right\">\n                ");
            EndContext();
            BeginContext(281, 133, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6b07584a606844fcaa41722eb476c9e9", async() => {
                BeginContext(398, 12, true);
                WriteLiteral("Geriyə qayıt");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(414, 46, true);
            WriteLiteral("\n            </div>\n        </div>\n    </div>\n");
            EndContext();
#line 13 "C:\Users\Kanan\Desktop\final_project\final_poject\Areas\Admin\Views\Deleted\Course.cshtml"
      if (TempData.ContainsKey("Error"))
    {
        if(TempData["Error"].ToString() == "category") 
        {

#line default
#line hidden
            BeginContext(573, 71, true);
            WriteLiteral("            <div class=\"text-danger\">Bu kurs silinmiş bir kateqoriyaya(");
            EndContext();
            BeginContext(645, 20, false);
#line 17 "C:\Users\Kanan\Desktop\final_project\final_poject\Areas\Admin\Views\Deleted\Course.cshtml"
                                                                  Write(TempData["Category"]);

#line default
#line hidden
            EndContext();
            BeginContext(665, 96, true);
            WriteLiteral(") aiddir.Ya kateqoriyanı geri qaytarmalı ya da aid olduğu kateqoriyanı dəyiştirməlisiniz.</div>\n");
            EndContext();
#line 18 "C:\Users\Kanan\Desktop\final_project\final_poject\Areas\Admin\Views\Deleted\Course.cshtml"
        }
    }

#line default
#line hidden
            BeginContext(777, 4, true);
            WriteLiteral("    ");
            EndContext();
#line 20 "C:\Users\Kanan\Desktop\final_project\final_poject\Areas\Admin\Views\Deleted\Course.cshtml"
     if(Model.Count() == 0) 
    {

#line default
#line hidden
            BeginContext(812, 45, true);
            WriteLiteral("        <h2>Heç bir kurs silinməmişdir.</h2>\n");
            EndContext();
#line 23 "C:\Users\Kanan\Desktop\final_project\final_poject\Areas\Admin\Views\Deleted\Course.cshtml"
    }
    
    else
    {

#line default
#line hidden
            BeginContext(883, 545, true);
            WriteLiteral(@"        <div class=""table-responsive"">
            <table class=""table table-hover"">
                <thead>
                    <tr>
                        <th style=""font-size:20px"" scope=""col"">Kurslar</th>
                        <th style=""font-size:20px"" scope=""col"">Aid olduğu kateqoriya</th>
                        <th style=""font-size:20px"" scope=""col"">Silən/Silindiyi tarix</th>
                        <th style=""font-size:20px"" scope=""col"">Geri Qaytar</th>
                    </tr>
                </thead>
                <tbody>
");
            EndContext();
#line 38 "C:\Users\Kanan\Desktop\final_project\final_poject\Areas\Admin\Views\Deleted\Course.cshtml"
         foreach (Course course in Model)
        {

#line default
#line hidden
            BeginContext(1480, 60, true);
            WriteLiteral("            <tr>\n                <td style=\"font-size:20px\">");
            EndContext();
            BeginContext(1541, 11, false);
#line 41 "C:\Users\Kanan\Desktop\final_project\final_poject\Areas\Admin\Views\Deleted\Course.cshtml"
                                      Write(course.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1552, 49, true);
            WriteLiteral("</td>\n                <td style=\"font-size:20px\">");
            EndContext();
            BeginContext(1602, 20, false);
#line 42 "C:\Users\Kanan\Desktop\final_project\final_poject\Areas\Admin\Views\Deleted\Course.cshtml"
                                      Write(course.Category.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1622, 49, true);
            WriteLiteral("</td>\n                <td style=\"font-size:20px\">");
            EndContext();
            BeginContext(1672, 20, false);
#line 43 "C:\Users\Kanan\Desktop\final_project\final_poject\Areas\Admin\Views\Deleted\Course.cshtml"
                                      Write(course.User.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(1692, 3, true);
            WriteLiteral(" / ");
            EndContext();
            BeginContext(1696, 18, false);
#line 43 "C:\Users\Kanan\Desktop\final_project\final_poject\Areas\Admin\Views\Deleted\Course.cshtml"
                                                              Write(course.DeletedTime);

#line default
#line hidden
            EndContext();
            BeginContext(1714, 47, true);
            WriteLiteral("</td>\n                <td>\n                    ");
            EndContext();
            BeginContext(1761, 192, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0a2ff3eca88a4b32bfdc8f0bc109674f", async() => {
                BeginContext(1919, 30, true);
                WriteLiteral("<i class=\"zmdi zmdi-edit\"></i>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 45 "C:\Users\Kanan\Desktop\final_project\final_poject\Areas\Admin\Views\Deleted\Course.cshtml"
                                                                          WriteLiteral(course.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1953, 21, true);
            WriteLiteral("\n                    ");
            EndContext();
            BeginContext(1974, 213, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d90e3bf08a534c65bf46909fe331976f", async() => {
                BeginContext(2152, 31, true);
                WriteLiteral("<i class=\"zmdi zmdi-check\"></i>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 46 "C:\Users\Kanan\Desktop\final_project\final_poject\Areas\Admin\Views\Deleted\Course.cshtml"
                                                                                               WriteLiteral(course.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2187, 41, true);
            WriteLiteral("\n                </td>\n            </tr>\n");
            EndContext();
#line 49 "C:\Users\Kanan\Desktop\final_project\final_poject\Areas\Admin\Views\Deleted\Course.cshtml"
        }

#line default
#line hidden
            BeginContext(2238, 86, true);
            WriteLiteral("                                    \n            </tbody>\n        </table>\n    </div>\n");
            EndContext();
#line 54 "C:\Users\Kanan\Desktop\final_project\final_poject\Areas\Admin\Views\Deleted\Course.cshtml"
    }

#line default
#line hidden
            BeginContext(2330, 23, true);
            WriteLiteral("            \n\n</div>\n\n\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(2370, 34, true);
                WriteLiteral("\n    <script>\n        console.log(");
                EndContext();
                BeginContext(2405, 13, false);
#line 62 "C:\Users\Kanan\Desktop\final_project\final_poject\Areas\Admin\Views\Deleted\Course.cshtml"
               Write(ViewBag.Error);

#line default
#line hidden
                EndContext();
                BeginContext(2418, 745, true);
                WriteLiteral(@")
        $("".activate_course"").click(function (e) {
            e.preventDefault();
            swal({
                title: ""Əminsiniz?"",
                text: ""Aktiv etmək istədiyinizə əminsinizmi?"",
                icon: ""warning"",
                buttons: true,
                dangerMode: true,
            })
                .then((willDelete) => {
                    if (willDelete && $(this).val() != ""1"") {
                        swal(""Aktiv olundu"", {
                            icon: ""success"",
                        });
                        location.href = $(this).attr('href')
                    } else {
                        swal(""Aktiv olunmadı"");
                    }
                });
        })
    </script>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Course>> Html { get; private set; }
    }
}
#pragma warning restore 1591

#pragma checksum "C:\Users\Kanan\Desktop\final_project\final_poject\Areas\Admin\Views\Mail\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "81844a37b3c37dc5f466e32bff4a5b8ccb99e51c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Mail_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Mail/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Mail/Index.cshtml", typeof(AspNetCore.Areas_Admin_Views_Mail_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"81844a37b3c37dc5f466e32bff4a5b8ccb99e51c", @"/Areas/Admin/Views/Mail/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"48a023bc38249f464093c9bb251a195d5e384ae0", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Mail_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Contact>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Trash", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Mail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("list-group-item"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Read", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            DefineSection("Styles", async() => {
                BeginContext(16, 218, true);
                WriteLiteral("\r\n    <style>\r\n        .selected_mail {\r\n            background-color: rgba(0, 0, 0, .20);\r\n            color: #fff;\r\n        }\r\n        .read_mail {\r\n            background-color: #043554\r\n        }\r\n    </style>\r\n\r\n ");
                EndContext();
            }
            );
            BeginContext(237, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(268, 830, true);
            WriteLiteral(@"<div class=""container-fluid"">
    <!-- Breadcrumb-->
    <div class=""row pt-2 pb-2"">
        <div class=""col-sm-9"">
            <h4 class=""page-title"">Məktub Qutusu</h4>
        </div>
    </div>
    <!-- End Breadcrumb-->
    <div class=""row"">
        <div class=""col-lg-12"">
            <div class=""card"">
                <div class=""card-body"">

                    <div class=""row"">

                        <!-- Left sidebar -->
                        <div class=""col-lg-3 col-md-4"">
                            <div class=""card mt-3 shadow-none"">
                                <div class=""list-group shadow-none"">
                                    <a href=""javascript:void();"" style=""background-color:#33698d"" class=""list-group-item bg-light-dark""><i class=""fa fa-inbox mr-2""></i>Gələn məktublar <b>(");
            EndContext();
            BeginContext(1099, 65, false);
#line 34 "C:\Users\Kanan\Desktop\final_project\final_poject\Areas\Admin\Views\Mail\Index.cshtml"
                                                                                                                                                                                       Write(Model.Where(c=>c.isRead == false && c.isDeleted == false).Count());

#line default
#line hidden
            EndContext();
            BeginContext(1164, 47, true);
            WriteLiteral(")</b></a>\r\n                                    ");
            EndContext();
            BeginContext(1211, 191, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4d4661957c484774a22652f89e7bb61f", async() => {
                BeginContext(1296, 51, true);
                WriteLiteral("<i class=\"fa fa-trash-o mr-2\"></i>Zibil qutusu <b>(");
                EndContext();
                BeginContext(1348, 45, false);
#line 35 "C:\Users\Kanan\Desktop\final_project\final_poject\Areas\Admin\Views\Mail\Index.cshtml"
                                                                                                                                                                       Write(Model.Where(c => c.isDeleted == true).Count());

#line default
#line hidden
                EndContext();
                BeginContext(1393, 5, true);
                WriteLiteral(")</b>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
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
            BeginContext(1402, 2129, true);
            WriteLiteral(@"
                                </div>
                            </div>


                        </div>
                        <!-- End Left sidebar -->
                        <!-- Right Sidebar -->
                        <div class=""col-lg-9 col-md-8"">
                            <div class=""row"">
                                <div class=""col-lg-8"">
                                    <div class=""btn-toolbar"" role=""toolbar"">
                                        <div class=""btn-group mr-1"">
                                            <button type=""button"" class=""btn btn-light waves-effect waves-light""><input type=""checkbox"" class=""selectAll"" value="""" /></button>
                                            <button type=""button"" class=""btn btn-light waves-effect waves-light remove_selected"" style=""display:none""><i class=""fa fa-trash-o""></i></button>
                                            <button type=""button"" class=""btn btn-light waves-effect waves-light seen_selected"" style=""dis");
            WriteLiteral(@"play:none""><i class=""zmdi zmdi-eye""></i></button>
                                            

                                        </div>
                                    </div>
                                </div>

                                <div class=""col-lg-4"">
                                    <div class=""position-relative has-icon-right"">
                                        <input type=""text"" id=""searchMail"" class=""form-control"" placeholder=""məktub axtar"">
                                        <div class=""form-control-position"">
                                            <i class=""fa fa-search""></i>
                                        </div>
                                    </div>
                                </div>


                            </div> <!-- End row -->

                            <div class=""card mt-3 shadow-none"">
                                <div class=""card-body"">
                                    <div class=""table-responsi");
            WriteLiteral("ve\">\r\n                                        <table class=\"table table-hover\">\r\n");
            EndContext();
#line 73 "C:\Users\Kanan\Desktop\final_project\final_poject\Areas\Admin\Views\Mail\Index.cshtml"
                                             if (Model.Where(m => m.isDeleted == false).Count() == 0)
                                            {

#line default
#line hidden
            BeginContext(3681, 76, true);
            WriteLiteral("                                                <h3>Məktubunuz yoxdur</h3>\r\n");
            EndContext();
#line 76 "C:\Users\Kanan\Desktop\final_project\final_poject\Areas\Admin\Views\Mail\Index.cshtml"
                                             }
                                             else 
                                             {

#line default
#line hidden
            BeginContext(3905, 58, true);
            WriteLiteral("                                                 <tbody>\r\n");
            EndContext();
#line 80 "C:\Users\Kanan\Desktop\final_project\final_poject\Areas\Admin\Views\Mail\Index.cshtml"
                                                 foreach(Contact contact in Model.Where(m => m.isDeleted == false))
                                                {
                                                    if(contact.isRead == true)
                                                    {

#line default
#line hidden
            BeginContext(4266, 69, true);
            WriteLiteral("                                                        <tr data-id=\"");
            EndContext();
            BeginContext(4336, 10, false);
#line 84 "C:\Users\Kanan\Desktop\final_project\final_poject\Areas\Admin\Views\Mail\Index.cshtml"
                                                                Write(contact.Id);

#line default
#line hidden
            EndContext();
            BeginContext(4346, 585, true);
            WriteLiteral(@""" class=""table-active read_mail"">
                                                            <td>
                                                                <div class=""check-material-white my-0"">
                                                                    <input class=""checkbox"" type=""checkbox"">
                                                                </div>
                                                            </td>
                                                            <td>
                                                                ");
            EndContext();
            BeginContext(4931, 104, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8c8a9760fabc476886a3b8b9a920e9ea", async() => {
                BeginContext(5019, 12, false);
#line 91 "C:\Users\Kanan\Desktop\final_project\final_poject\Areas\Admin\Views\Mail\Index.cshtml"
                                                                                                                                                  Write(contact.Name);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 91 "C:\Users\Kanan\Desktop\final_project\final_poject\Areas\Admin\Views\Mail\Index.cshtml"
                                                                                                                              WriteLiteral(contact.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5035, 199, true);
            WriteLiteral("\r\n                                                            </td>\r\n                                                            <td>\r\n                                                                ");
            EndContext();
            BeginContext(5234, 107, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f4ebf7a305d24c06b6fe8121f26ff65a", async() => {
                BeginContext(5322, 15, false);
#line 94 "C:\Users\Kanan\Desktop\final_project\final_poject\Areas\Admin\Views\Mail\Index.cshtml"
                                                                                                                                                  Write(contact.Subject);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 94 "C:\Users\Kanan\Desktop\final_project\final_poject\Areas\Admin\Views\Mail\Index.cshtml"
                                                                                                                              WriteLiteral(contact.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5341, 218, true);
            WriteLiteral("\r\n                                                            </td>\r\n                                                            <td class=\"text-right\">\r\n                                                                ");
            EndContext();
            BeginContext(5560, 77, false);
#line 97 "C:\Users\Kanan\Desktop\final_project\final_poject\Areas\Admin\Views\Mail\Index.cshtml"
                                                           Write(contact.SendingDate.ToString("g", CultureInfo.CreateSpecificCulture("es-ES")));

#line default
#line hidden
            EndContext();
            BeginContext(5637, 132, true);
            WriteLiteral("\r\n                                                            </td>\r\n                                                        </tr>\r\n");
            EndContext();
#line 100 "C:\Users\Kanan\Desktop\final_project\final_poject\Areas\Admin\Views\Mail\Index.cshtml"
                                                    }
                                                    else 
                                                    {

#line default
#line hidden
            BeginContext(5938, 69, true);
            WriteLiteral("                                                        <tr data-id=\"");
            EndContext();
            BeginContext(6008, 10, false);
#line 103 "C:\Users\Kanan\Desktop\final_project\final_poject\Areas\Admin\Views\Mail\Index.cshtml"
                                                                Write(contact.Id);

#line default
#line hidden
            EndContext();
            BeginContext(6018, 575, true);
            WriteLiteral(@""" class=""table-active"">
                                                            <td>
                                                                <div class=""check-material-white my-0"">
                                                                    <input class=""checkbox"" type=""checkbox"">
                                                                </div>
                                                            </td>
                                                            <td>
                                                                ");
            EndContext();
            BeginContext(6593, 104, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9504bfc9044042d5a3066bdf9c6d6784", async() => {
                BeginContext(6681, 12, false);
#line 110 "C:\Users\Kanan\Desktop\final_project\final_poject\Areas\Admin\Views\Mail\Index.cshtml"
                                                                                                                                                  Write(contact.Name);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 110 "C:\Users\Kanan\Desktop\final_project\final_poject\Areas\Admin\Views\Mail\Index.cshtml"
                                                                                                                              WriteLiteral(contact.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(6697, 199, true);
            WriteLiteral("\r\n                                                            </td>\r\n                                                            <td>\r\n                                                                ");
            EndContext();
            BeginContext(6896, 150, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bb997594bf7e41a9836abe7c235a2558", async() => {
                BeginContext(6983, 43, true);
                WriteLiteral("<i class=\"fa fa-circle text-blue mr-2\"></i>");
                EndContext();
                BeginContext(7027, 15, false);
#line 113 "C:\Users\Kanan\Desktop\final_project\final_poject\Areas\Admin\Views\Mail\Index.cshtml"
                                                                                                                                                                                             Write(contact.Subject);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 113 "C:\Users\Kanan\Desktop\final_project\final_poject\Areas\Admin\Views\Mail\Index.cshtml"
                                                                                                                              WriteLiteral(contact.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(7046, 218, true);
            WriteLiteral("\r\n                                                            </td>\r\n                                                            <td class=\"text-right\">\r\n                                                                ");
            EndContext();
            BeginContext(7265, 77, false);
#line 116 "C:\Users\Kanan\Desktop\final_project\final_poject\Areas\Admin\Views\Mail\Index.cshtml"
                                                           Write(contact.SendingDate.ToString("g", CultureInfo.CreateSpecificCulture("es-ES")));

#line default
#line hidden
            EndContext();
            BeginContext(7342, 132, true);
            WriteLiteral("\r\n                                                            </td>\r\n                                                        </tr>\r\n");
            EndContext();
#line 119 "C:\Users\Kanan\Desktop\final_project\final_poject\Areas\Admin\Views\Mail\Index.cshtml"
                                                    }
                                                }

#line default
#line hidden
            BeginContext(7580, 56, true);
            WriteLiteral("\r\n                                            </tbody>\r\n");
            EndContext();
#line 123 "C:\Users\Kanan\Desktop\final_project\final_poject\Areas\Admin\Views\Mail\Index.cshtml"
                                             }

#line default
#line hidden
            BeginContext(7684, 575, true);
            WriteLiteral(@"                                            
                                        </table>
                                    </div>

                                    <hr>

                                </div> <!-- card body -->
                            </div> <!-- card -->
                        </div> <!-- end Col-9 -->

                    </div><!-- End row -->

                </div>
            </div>
        </div>
    </div><!-- End row -->
    <!--start overlay-->
    <div class=""overlay""></div>
    <!--end overlay-->
</div>

");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(8276, 4999, true);
                WriteLiteral(@"
    <script>
        $('#searchMail').keyup(function () {
            let val = $(this).val();

            if (val.length > 0) {
                $.ajax({
                    url: ""/Admin/Mail/SearchInbox?key="" + val,
                    type: ""Get"",
                    success: function (response) {
                        $('.table-hover').empty()
                        $('.table-hover').append(response)
                    }
                })
            }

        })

        let checkboxes = document.querySelectorAll("".checkbox"")
        let selectAll = document.querySelector("".selectAll"")

        window.onload = function(){
            for(var i = 0;i<checkboxes.length;++i)
            {
                checkboxes[i].checked = false;
            }
            selectAll.checked = false;
        }
        for(var i = 0;i<checkboxes.length;++i)
        {
            checkboxes[i].onclick = function(){
                if(this.checked && this.className !=""selectAll""){
    ");
                WriteLiteral(@"                this.parentElement.parentElement.parentElement.classList.add(""selected_mail"")
                }
                else{
                    this.parentElement.parentElement.parentElement.classList.remove(""selected_mail"")
                }

                if(document.querySelectorAll("".selected_mail"").length == checkboxes.length){
                    selectAll.checked =true;
                }
                else{
                    selectAll.checked =false;
                }
                if(document.querySelectorAll("".selected_mail"").length>0){
                    document.querySelector("".remove_selected"").style.display = ""block""
                    document.querySelector("".seen_selected"").style.display = ""block""
                }
                else{
                    document.querySelector("".remove_selected"").style.display = ""none""
                    document.querySelector("".seen_selected"").style.display = ""none""
                }
            }
        }

      ");
                WriteLiteral(@"  selectAll.onclick = function(){
           if(this.checked){
                for(var i = 0;i<checkboxes.length;++i)
                {
                    if (checkboxes[i].className != ""selectAll"" && checkboxes[i].parentElement.parentElement.parentElement.className != (""table-active selected_mail"") || checkboxes[i].parentElement.parentElement.parentElement.className != (""selected_mail"")){
                        checkboxes[i].checked=true
                        checkboxes[i].parentElement.parentElement.parentElement.classList.add(""selected_mail"")
                    }
                }
           }
           else{
                for(var i = 0;i<checkboxes.length;++i)
                    {
                    if (checkboxes[i].className != ""selectAll"" && checkboxes[i].parentElement.parentElement.parentElement.className != (""table-active selected_mail"") || checkboxes[i].parentElement.parentElement.parentElement.className != (""selected_mail"")){
                            checkboxes[i].checked");
                WriteLiteral(@"=false
                            checkboxes[i].parentElement.parentElement.parentElement.classList.remove(""selected_mail"")
                        }
                    }
           }
           if(document.querySelectorAll("".selected_mail"").length>0){
               document.querySelector("".remove_selected"").style.display = ""block""
               document.querySelector("".seen_selected"").style.display = ""block""
            }
            else{
               document.querySelector("".remove_selected"").style.display = ""none""
               document.querySelector("".seen_selected"").style.display = ""none""
            }

        }

        $('.remove_selected').click(function () {
            mails = []

            var selectedMails = $('.selected_mail')
            selectedMails.each(function () {
                mails.push($(this).data(""id""))
            })

            $.ajax({
                method: 'GET',
                url: '/Admin/Mail/Remove',
                data: { 'mails': ");
                WriteLiteral(@"JSON.stringify(mails) },
                contentType: ""application/json; charset=utf-8"",
                cache: false,
                success: function () {
                    location.reload();
                }
            })
            
        })

        $('.seen_selected').click(function () {
            mails = []

            var selectedMails = $('.selected_mail')
            selectedMails.each(function () {
                mails.push($(this).data(""id""))
            })

            $.ajax({
                method: 'GET',
                url: '/Admin/Mail/Seen',
                data: { 'mails': JSON.stringify(mails) },
                contentType: ""application/json; charset=utf-8"",
                cache: false,
                success: function () {
                    location.reload();
                }
            })

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Contact>> Html { get; private set; }
    }
}
#pragma warning restore 1591

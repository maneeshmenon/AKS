#pragma checksum "D:\Users\z003w9ja\Source\GitHub\Workspaces\AKS\FrontEnd\FrontendWebApp\FrontendWebApp\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d82e2062177c769949288eaad92bbec2cd1c7454"
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
#nullable restore
#line 1 "D:\Users\z003w9ja\Source\GitHub\Workspaces\AKS\FrontEnd\FrontendWebApp\FrontendWebApp\Views\_ViewImports.cshtml"
using FrontendWebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Users\z003w9ja\Source\GitHub\Workspaces\AKS\FrontEnd\FrontendWebApp\FrontendWebApp\Views\_ViewImports.cshtml"
using FrontendWebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d82e2062177c769949288eaad92bbec2cd1c7454", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4b1ea6f738ea24cc5ea0c08bf79aa39c3d115344", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\Users\z003w9ja\Source\GitHub\Workspaces\AKS\FrontEnd\FrontendWebApp\FrontendWebApp\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Display data retrieved by the containerized backend service";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h3>");
#nullable restore
#line 6 "D:\Users\z003w9ja\Source\GitHub\Workspaces\AKS\FrontEnd\FrontendWebApp\FrontendWebApp\Views\Home\Index.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
<br />
<p>Note: The Backend service supports retrival from three APIs. To choose the desired API, refer this application's ""appsettings.json""</p>
<p>Note: If the retrieved information is also saved in a mounted volume, execute the below commands to view the file:</p>
<p>$kubectl exec -it 'backend_service_pod_name' -- /bin/bash</p>
<p>$cd /mnt/azurediskdata</p>
<p>$dir</p>
<p>$cat 'file_name' </p>
<br />

<h3>");
#nullable restore
#line 16 "D:\Users\z003w9ja\Source\GitHub\Workspaces\AKS\FrontEnd\FrontendWebApp\FrontendWebApp\Views\Home\Index.cshtml"
Write(ViewData["Message"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\r\n");
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

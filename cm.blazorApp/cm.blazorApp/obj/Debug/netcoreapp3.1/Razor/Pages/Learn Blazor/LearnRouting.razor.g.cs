#pragma checksum "C:\dev\cm.blazor\cm.blazorApp\cm.blazorApp\Pages\Learn Blazor\LearnRouting.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "94268df8a518a0b5f8142741fe0d649dd6007f75"
// <auto-generated/>
#pragma warning disable 1591
namespace cm.blazorApp.Pages.Learn_Blazor
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#line 1 "C:\dev\cm.blazor\cm.blazorApp\cm.blazorApp\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#line 2 "C:\dev\cm.blazor\cm.blazorApp\cm.blazorApp\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#line 3 "C:\dev\cm.blazor\cm.blazorApp\cm.blazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#line 4 "C:\dev\cm.blazor\cm.blazorApp\cm.blazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#line 5 "C:\dev\cm.blazor\cm.blazorApp\cm.blazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#line 6 "C:\dev\cm.blazor\cm.blazorApp\cm.blazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#line 7 "C:\dev\cm.blazor\cm.blazorApp\cm.blazorApp\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#line 8 "C:\dev\cm.blazor\cm.blazorApp\cm.blazorApp\_Imports.razor"
using cm.blazorApp;

#line default
#line hidden
#line 9 "C:\dev\cm.blazor\cm.blazorApp\cm.blazorApp\_Imports.razor"
using cm.blazorApp.Shared;

#line default
#line hidden
    [Microsoft.AspNetCore.Components.RouteAttribute("/learnnewrouting/{parameter1}/{parameter2}")]
    [Microsoft.AspNetCore.Components.RouteAttribute("/learnnewrouting/{parameter1}")]
    [Microsoft.AspNetCore.Components.RouteAttribute("/learnnewrouting")]
    [Microsoft.AspNetCore.Components.RouteAttribute("/learnrouting")]
    public partial class LearnRouting : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>LearnRouting</h3>\r\n\r\n");
            __builder.OpenElement(1, "p");
            __builder.AddContent(2, "First Parameter: ");
            __builder.AddContent(3, 
#line 8 "C:\dev\cm.blazor\cm.blazorApp\cm.blazorApp\Pages\Learn Blazor\LearnRouting.razor"
                     Parameter1

#line default
#line hidden
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(4, "\r\n");
            __builder.OpenElement(5, "p");
            __builder.AddContent(6, "Second Parameter: ");
            __builder.AddContent(7, 
#line 9 "C:\dev\cm.blazor\cm.blazorApp\cm.blazorApp\Pages\Learn Blazor\LearnRouting.razor"
                      Parameter2

#line default
#line hidden
            );
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#line 11 "C:\dev\cm.blazor\cm.blazorApp\cm.blazorApp\Pages\Learn Blazor\LearnRouting.razor"
       
    [Parameter]
    public string Parameter1 {get; set;}

    [Parameter]
    public string Parameter2 {get; set;}

#line default
#line hidden
    }
}
#pragma warning restore 1591
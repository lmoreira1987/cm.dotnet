#pragma checksum "C:\dev\cm.blazor\cm.blazorApp\cm.blazorApp\Pages\Learn Blazor\LearnBlazor.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "90b04a8f9937d139bb915d146ffc5d0bb5a38d4f"
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/learnblazor")]
    public partial class LearnBlazor : LearnBlazorBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "h3");
            __builder.AddAttribute(1, "class", "text-info pb-3");
            __builder.AddContent(2, 
#line 3 "C:\dev\cm.blazor\cm.blazorApp\cm.blazorApp\Pages\Learn Blazor\LearnBlazor.razor"
                            WelcomeText

#line default
#line hidden
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(3, "\r\n\r\n");
            __builder.OpenElement(4, "p");
            __builder.AddContent(5, "On change   ");
            __builder.OpenElement(6, "input");
            __builder.AddAttribute(7, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#line 5 "C:\dev\cm.blazor\cm.blazorApp\cm.blazorApp\Pages\Learn Blazor\LearnBlazor.razor"
                                  name

#line default
#line hidden
            ));
            __builder.AddAttribute(8, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => name = __value, name));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\r\n");
            __builder.OpenElement(10, "p");
            __builder.AddContent(11, "On spontaneous   ");
            __builder.OpenElement(12, "input");
            __builder.AddAttribute(13, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#line 6 "C:\dev\cm.blazor\cm.blazorApp\cm.blazorApp\Pages\Learn Blazor\LearnBlazor.razor"
                                       name

#line default
#line hidden
            ));
            __builder.AddAttribute(14, "oninput", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => name = __value, name));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(15, "\r\n\r\n");
            __builder.OpenElement(16, "p");
            __builder.AddContent(17, "I am ");
            __builder.AddContent(18, 
#line 8 "C:\dev\cm.blazor\cm.blazorApp\cm.blazorApp\Pages\Learn Blazor\LearnBlazor.razor"
          name!=null ?name:"_____"

#line default
#line hidden
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(19, "\r\n\r\n");
            __builder.OpenElement(20, "p");
            __builder.OpenElement(21, "button");
            __builder.AddAttribute(22, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#line 10 "C:\dev\cm.blazor\cm.blazorApp\cm.blazorApp\Pages\Learn Blazor\LearnBlazor.razor"
                     getName

#line default
#line hidden
            ));
            __builder.AddContent(23, "Surprise me!");
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591

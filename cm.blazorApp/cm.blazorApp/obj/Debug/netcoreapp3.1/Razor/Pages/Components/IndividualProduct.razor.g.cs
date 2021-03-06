#pragma checksum "C:\dev\cm.blazor\cm.blazorApp\cm.blazorApp\Pages\Components\IndividualProduct.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b004f3fde9717b4ad51baa76c78e80fd553cec18"
// <auto-generated/>
#pragma warning disable 1591
namespace cm.blazorApp.Pages.Components
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
#line 1 "C:\dev\cm.blazor\cm.blazorApp\cm.blazorApp\Pages\Components\IndividualProduct.razor"
using cm.blazorApp.Data;

#line default
#line hidden
    public partial class IndividualProduct : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "col-3");
            __builder.AddMarkupContent(2, "\r\n    ");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", " card-background card mb-4");
            __builder.AddMarkupContent(5, "\r\n        ");
            __builder.OpenElement(6, "div");
            __builder.AddAttribute(7, "class", "card-header");
            __builder.AddMarkupContent(8, "\r\n            ");
            __builder.OpenElement(9, "h4");
            __builder.AddAttribute(10, "class", "my-0 font-weight-normal text-center");
            __builder.AddMarkupContent(11, "\r\n                ");
            __builder.OpenElement(12, "label");
            __builder.AddAttribute(13, "style", "font-size:23px;color:steelblue;");
            __builder.AddContent(14, 
#line 7 "C:\dev\cm.blazor\cm.blazorApp\cm.blazorApp\Pages\Components\IndividualProduct.razor"
                                                                product.Name

#line default
#line hidden
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(15, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(16, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(17, "\r\n\r\n        ");
            __builder.OpenElement(18, "img");
            __builder.AddAttribute(19, "class", "card-img-top");
            __builder.AddAttribute(20, "style", "height:100%;");
            __builder.AddAttribute(21, "src", 
#line 11 "C:\dev\cm.blazor\cm.blazorApp\cm.blazorApp\Pages\Components\IndividualProduct.razor"
                                                             convertImageToDisplay(product.Image)

#line default
#line hidden
            );
            __builder.AddAttribute(22, "alt", "Card Image");
            __builder.CloseElement();
            __builder.AddMarkupContent(23, "\r\n        ");
            __builder.OpenElement(24, "div");
            __builder.AddAttribute(25, "class", "card-body card-background");
            __builder.AddAttribute(26, "style", "background-color:#F7F7F7");
            __builder.AddMarkupContent(27, "\r\n            ");
            __builder.OpenElement(28, "div");
            __builder.AddAttribute(29, "class", "d-flex justify-content-between align-items-center");
            __builder.AddMarkupContent(30, "\r\n                ");
            __builder.OpenElement(31, "div");
            __builder.AddAttribute(32, "class", "btn-group");
            __builder.AddMarkupContent(33, "\r\n                    ");
            __builder.OpenElement(34, "label");
            __builder.AddAttribute(35, "style", "font-size:20px; color:#a51313");
            __builder.OpenElement(36, "b");
            __builder.AddContent(37, 
#line 15 "C:\dev\cm.blazor\cm.blazorApp\cm.blazorApp\Pages\Components\IndividualProduct.razor"
                                                                     product.Price

#line default
#line hidden
            );
            __builder.CloseElement();
            __builder.AddContent(38, "/sq.ft");
            __builder.CloseElement();
            __builder.AddMarkupContent(39, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(40, "\r\n                ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(41);
            __builder.AddAttribute(42, "href", 
#line 17 "C:\dev\cm.blazor\cm.blazorApp\cm.blazorApp\Pages\Components\IndividualProduct.razor"
                                 $"/details/{product.Id}"

#line default
#line hidden
            );
            __builder.AddAttribute(43, "class", "btn btn-success pull-right btn-outline-info text-white");
            __builder.AddAttribute(44, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddContent(45, "Details");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(46, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(47, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(48, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(49, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#line 23 "C:\dev\cm.blazor\cm.blazorApp\cm.blazorApp\Pages\Components\IndividualProduct.razor"
       
    [Parameter]
    public Product product { get; set; }

    string convertImageToDisplay(byte[] image)
    {
        if (image != null)
        {
            var base64 = Convert.ToBase64String(image);
            var finalStr = string.Format("data:image/jpg;base64,{0}", base64);
            return finalStr;
        }
        return "";
    }

#line default
#line hidden
    }
}
#pragma warning restore 1591

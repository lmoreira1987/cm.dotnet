#pragma checksum "C:\dev\cm.blazor\cm.blazorApp\cm.blazorApp\Pages\Components\DetailsComponent.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "75b6c4c2a5035df4f58846aee3ad6f835c1a8c9d"
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
#line 1 "C:\dev\cm.blazor\cm.blazorApp\cm.blazorApp\Pages\Components\DetailsComponent.razor"
using cm.blazorApp.Data;

#line default
#line hidden
#line 2 "C:\dev\cm.blazor\cm.blazorApp\cm.blazorApp\Pages\Components\DetailsComponent.razor"
using cm.blazorApp.Services;

#line default
#line hidden
    public partial class DetailsComponent : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "p-4 border rounded row");
            __builder.AddMarkupContent(2, "\r\n    ");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "col-8");
            __builder.AddMarkupContent(5, "\r\n        ");
            __builder.OpenElement(6, "div");
            __builder.AddAttribute(7, "class", "form-group row");
            __builder.AddMarkupContent(8, "\r\n            ");
            __builder.AddMarkupContent(9, "<div class=\"col-4\">\r\n                Name\r\n            </div>\r\n            ");
            __builder.OpenElement(10, "div");
            __builder.AddAttribute(11, "class", "col-8");
            __builder.AddMarkupContent(12, "\r\n                ");
            __builder.OpenElement(13, "input");
            __builder.AddAttribute(14, "value", 
#line 11 "C:\dev\cm.blazor\cm.blazorApp\cm.blazorApp\Pages\Components\DetailsComponent.razor"
                               appointment.Product.Name

#line default
#line hidden
            );
            __builder.AddAttribute(15, "class", "form-control");
            __builder.AddAttribute(16, "readonly", true);
            __builder.CloseElement();
            __builder.AddMarkupContent(17, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(18, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(19, "\r\n        ");
            __builder.OpenElement(20, "div");
            __builder.AddAttribute(21, "class", "form-group row");
            __builder.AddMarkupContent(22, "\r\n            ");
            __builder.AddMarkupContent(23, "<div class=\"col-4\">\r\n                Shade Color\r\n            </div>\r\n            ");
            __builder.OpenElement(24, "div");
            __builder.AddAttribute(25, "class", "col-8");
            __builder.AddMarkupContent(26, "\r\n                ");
            __builder.OpenElement(27, "input");
            __builder.AddAttribute(28, "value", 
#line 19 "C:\dev\cm.blazor\cm.blazorApp\cm.blazorApp\Pages\Components\DetailsComponent.razor"
                               appointment.Product.ShadeColor

#line default
#line hidden
            );
            __builder.AddAttribute(29, "class", "form-control");
            __builder.AddAttribute(30, "readonly", true);
            __builder.CloseElement();
            __builder.AddMarkupContent(31, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(32, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(33, "\r\n        ");
            __builder.OpenElement(34, "div");
            __builder.AddAttribute(35, "class", "form-group row");
            __builder.AddMarkupContent(36, "\r\n            ");
            __builder.AddMarkupContent(37, "<div class=\"col-4\">\r\n                Price\r\n            </div>\r\n            ");
            __builder.OpenElement(38, "div");
            __builder.AddAttribute(39, "class", "col-8");
            __builder.AddMarkupContent(40, "\r\n                ");
            __builder.OpenElement(41, "input");
            __builder.AddAttribute(42, "value", 
#line 27 "C:\dev\cm.blazor\cm.blazorApp\cm.blazorApp\Pages\Components\DetailsComponent.razor"
                               appointment.Product.Price

#line default
#line hidden
            );
            __builder.AddAttribute(43, "class", "form-control");
            __builder.AddAttribute(44, "readonly", true);
            __builder.CloseElement();
            __builder.AddMarkupContent(45, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(46, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(47, "\r\n        ");
            __builder.OpenElement(48, "div");
            __builder.AddAttribute(49, "class", "form-group row");
            __builder.AddMarkupContent(50, "\r\n            ");
            __builder.AddMarkupContent(51, "<div class=\"col-4\">\r\n                Category Name\r\n            </div>\r\n            ");
            __builder.OpenElement(52, "div");
            __builder.AddAttribute(53, "class", "col-8");
            __builder.AddMarkupContent(54, "\r\n                ");
            __builder.OpenElement(55, "input");
            __builder.AddAttribute(56, "value", 
#line 35 "C:\dev\cm.blazor\cm.blazorApp\cm.blazorApp\Pages\Components\DetailsComponent.razor"
                               appointment.Product.Category.Name

#line default
#line hidden
            );
            __builder.AddAttribute(57, "class", "form-control");
            __builder.AddAttribute(58, "readonly", true);
            __builder.CloseElement();
            __builder.AddMarkupContent(59, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(60, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(61, "\r\n        ");
            __builder.OpenElement(62, "div");
            __builder.AddAttribute(63, "class", "form-group row");
            __builder.AddMarkupContent(64, "\r\n            ");
            __builder.AddMarkupContent(65, "<div class=\"col-4\">\r\n\r\n            </div>\r\n            ");
            __builder.AddMarkupContent(66, "<div class=\"col-4\">\r\n                <a href=\"/\" class=\"btn btn-success form-control\">Back to List</a>\r\n            </div>\r\n            ");
            __builder.OpenElement(67, "div");
            __builder.AddAttribute(68, "class", "col-4");
            __builder.AddMarkupContent(69, "\r\n                ");
            __builder.OpenElement(70, "button");
            __builder.AddAttribute(71, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#line 46 "C:\dev\cm.blazor\cm.blazorApp\cm.blazorApp\Pages\Components\DetailsComponent.razor"
                                  OnClickShowAppointment

#line default
#line hidden
            ));
            __builder.AddAttribute(72, "class", "btn btn-primary form-control");
            __builder.AddMarkupContent(73, "\r\n                    Book Appointment\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(74, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(75, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(76, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(77, "\r\n    ");
            __builder.OpenElement(78, "div");
            __builder.AddAttribute(79, "class", "offset-1 col-3");
            __builder.AddMarkupContent(80, "\r\n        ");
            __builder.OpenElement(81, "img");
            __builder.AddAttribute(82, "src", 
#line 53 "C:\dev\cm.blazor\cm.blazorApp\cm.blazorApp\Pages\Components\DetailsComponent.razor"
                   convertImageToDisplay(appointment.Product.Image)

#line default
#line hidden
            );
            __builder.AddAttribute(83, "width", "100%");
            __builder.AddAttribute(84, "style", "border-radius: 5px; border:1px solid #bbb9b9");
            __builder.CloseElement();
            __builder.AddMarkupContent(85, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(86, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#line 58 "C:\dev\cm.blazor\cm.blazorApp\cm.blazorApp\Pages\Components\DetailsComponent.razor"
       
    [Parameter]
    public Appointment appointment { get; set; }

    [Parameter]
    public EventCallback OnClickShowAppointment { get; set; }

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

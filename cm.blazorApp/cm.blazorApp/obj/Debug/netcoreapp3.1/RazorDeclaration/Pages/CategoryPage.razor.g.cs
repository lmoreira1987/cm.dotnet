#pragma checksum "C:\dev\cm.blazor\cm.blazorApp\cm.blazorApp\Pages\CategoryPage.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a5a2647a51673bb0009c496b774a57605ac35ad4"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace cm.blazorApp.Pages
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
#line 2 "C:\dev\cm.blazor\cm.blazorApp\cm.blazorApp\Pages\CategoryPage.razor"
using cm.blazorApp.Data;

#line default
#line hidden
#line 3 "C:\dev\cm.blazor\cm.blazorApp\cm.blazorApp\Pages\CategoryPage.razor"
using cm.blazorApp.Services;

#line default
#line hidden
    [Microsoft.AspNetCore.Components.RouteAttribute("/category")]
    public partial class CategoryPage : OwningComponentBase<CategoriesService>
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#line 103 "C:\dev\cm.blazor\cm.blazorApp\cm.blazorApp\Pages\CategoryPage.razor"
       

    //[CascadingParameter]
    //private Task<AuthenticationState> authenticationState { get; set; }

    List<Category> categories;
    Category category = new Category();
    bool ShowPopup = false;

    protected override void OnInitialized()
    {
        //var user = (await authenticationState).User;
        //var emailOfUser = user.Identity.Name;
        categories = Service.GetCategories();
    }

    void AddNewCategory()
    {
        category = new Category();
        category.Id = 0;
        ShowPopup = true;
    }

    void EditCategory(Category category)
    {
        this.category = category;
        ShowPopup = true;
    }

    void DeleteCategory()
    {
        ShowPopup = false;
        var result = Service.DeleteCategory(category);
        categories.Clear();
        categories = Service.GetCategories();
    }

    void ClosePopup()
    {
        ShowPopup = false;
    }

    void ValidSubmit()
    {
        var result = false;
        ShowPopup = false;

        if (category.Id > 0)
        {
            result = Service.UpdateCategory(category);
        }
        else
        {
            result = Service.CreateCategory(category);
        }

        categories = Service.GetCategories();
    }

#line default
#line hidden
    }
}
#pragma warning restore 1591

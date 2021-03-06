#pragma checksum "C:\dev\cm.blazor\cm.blazorApp\cm.blazorApp\Pages\ProductPage.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "07ff267d760a20a599ffe8c37e8ec65df4bf754e"
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
#line 2 "C:\dev\cm.blazor\cm.blazorApp\cm.blazorApp\Pages\ProductPage.razor"
using cm.blazorApp.Data;

#line default
#line hidden
#line 3 "C:\dev\cm.blazor\cm.blazorApp\cm.blazorApp\Pages\ProductPage.razor"
using cm.blazorApp.Services;

#line default
#line hidden
#line 4 "C:\dev\cm.blazor\cm.blazorApp\cm.blazorApp\Pages\ProductPage.razor"
using BlazorInputFile;

#line default
#line hidden
#line 5 "C:\dev\cm.blazor\cm.blazorApp\cm.blazorApp\Pages\ProductPage.razor"
using System.IO;

#line default
#line hidden
    [Microsoft.AspNetCore.Components.RouteAttribute("/product")]
    public partial class ProductPage : OwningComponentBase<ProductService>
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#line 154 "C:\dev\cm.blazor\cm.blazorApp\cm.blazorApp\Pages\ProductPage.razor"
       
    List<Category> categories;
    List<Product> products;
    Product product = new Product();
    bool ShowPopup = false;
    public byte[] ImageUploaded { get; set; }

    protected override void OnInitialized()
    {
        products = Service.GetProducts();
    }

    void AddNewProduct()
    {
        product = new Product();
        categories = Service.GetCategoryList();
        product.CategoryId = categories.ToList()[0].Id;
        product.Id = 0;
        ShowPopup = true;
    }

    void EditProduct(Product product)
    {
        this.product = product;
        categories = Service.GetCategoryList();
        ShowPopup = true;
    }

    void DeleteProduct()
    {
        ShowPopup = false;
        var result = Service.DeleteProduct(product);
        products.Clear();
        products = Service.GetProducts();
    }

    void ClosePopup()
    {
        ShowPopup = false;
    }

    void ValidSubmit()
    {
        var result = false;
        ShowPopup = false;

        if (ImageUploaded != null)
        {
            product.Image = ImageUploaded;
            ImageUploaded = null;
        }

        if (product.Id > 0)
        {
            result = Service.UpdateProduct(product);
        }
        else
        {
            result = Service.CreateProduct(product);
        }

        products = Service.GetProducts();
    }

    async Task HandleSelection(IFileListEntry[] files)
    {
        var file = files.FirstOrDefault();
        if (file != null)
        {
            var ms = new MemoryStream();
            await file.Data.CopyToAsync(ms);
            ImageUploaded = ms.ToArray();
        }
    }

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

    void CategorySelectionChange(ChangeEventArgs e)
    {
        if (int.TryParse(e.Value.ToString(), out int id))
        {
            product.CategoryId = id;
        }
    }

#line default
#line hidden
    }
}
#pragma warning restore 1591

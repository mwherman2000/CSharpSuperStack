#pragma checksum "C:\CSSS\CSharpSuperStack\BlazorServerAppMovies4\BlazorApp4s\Pages\ClaimsPrincipalData.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6d6c73c703a58a9c9c6fcd0e8db106ce0e81b4e7"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BlazorApp4s.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\CSSS\CSharpSuperStack\BlazorServerAppMovies4\BlazorApp4s\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\CSSS\CSharpSuperStack\BlazorServerAppMovies4\BlazorApp4s\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\CSSS\CSharpSuperStack\BlazorServerAppMovies4\BlazorApp4s\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\CSSS\CSharpSuperStack\BlazorServerAppMovies4\BlazorApp4s\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\CSSS\CSharpSuperStack\BlazorServerAppMovies4\BlazorApp4s\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\CSSS\CSharpSuperStack\BlazorServerAppMovies4\BlazorApp4s\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\CSSS\CSharpSuperStack\BlazorServerAppMovies4\BlazorApp4s\_Imports.razor"
using BlazorApp4s;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\CSSS\CSharpSuperStack\BlazorServerAppMovies4\BlazorApp4s\_Imports.razor"
using BlazorApp4s.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\CSSS\CSharpSuperStack\BlazorServerAppMovies4\BlazorApp4s\Pages\ClaimsPrincipalData.razor"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\CSSS\CSharpSuperStack\BlazorServerAppMovies4\BlazorApp4s\Pages\ClaimsPrincipalData.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\CSSS\CSharpSuperStack\BlazorServerAppMovies4\BlazorApp4s\Pages\ClaimsPrincipalData.razor"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/claimsprincipaldata")]
    public partial class ClaimsPrincipalData : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 41 "C:\CSSS\CSharpSuperStack\BlazorServerAppMovies4\BlazorApp4s\Pages\ClaimsPrincipalData.razor"
       
    private string _authMessage;
    private string _surnameMessage;
    private IEnumerable<Claim> _claims = Enumerable.Empty<Claim>();
    private List<string> _roles = new List<string>();

    private async Task GetClaimsPrincipalData()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var claimsPrincipal = authState.User;

        if (claimsPrincipal.Identity.IsAuthenticated)
        {
            _authMessage = $"{claimsPrincipal.Identity.Name} is authenticated.";
            _claims = claimsPrincipal.Claims;
            _surnameMessage = $"Surname: {claimsPrincipal.FindFirst(c => c.Type == ClaimTypes.Surname)?.Value}";

            var user = await UserManager.GetUserAsync(claimsPrincipal);
            _roles = (List<string>) (await UserManager.GetRolesAsync(user));
            var isAdmin = _roles.Contains("Admin");

            claimsPrincipal.Claims.Append<Claim>(new Claim(ClaimTypes.Role, "Member")); // doesn't work
            _claims = claimsPrincipal.Claims;
        }
        else
        {
            _authMessage = "The user is NOT authenticated.";
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private UserManager<IdentityUser> UserManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private SignInManager<IdentityUser> SignInManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    }
}
#pragma warning restore 1591

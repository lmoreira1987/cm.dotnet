using Microsoft.AspNetCore.Components;

namespace cm.blazorApp.Pages.Learn_Blazor
{
    public class LearnBlazorBase : ComponentBase
    {
        protected string name = "Spark";
        protected string WelcomeText = "Time to learn Blazor!";

        protected void getName()
        {
            name = "Blazor Learner";
        }
    }
}

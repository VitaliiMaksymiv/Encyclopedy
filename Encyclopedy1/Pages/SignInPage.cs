﻿namespace Encyclopedy1.Pages
{
    using Encyclopedy1.Console;

    public class SignInPage : MenuPage
    {
        public SignInPage(Program program)
            : base(
                "Sign In Page",
                program,
                new Option("Log In", () => program.NavigateTo<LogInPage>()),
                new Option("Register", () => program.NavigateTo<RegisterPage>()))
        {
        }
    }
}

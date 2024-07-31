// <copyright file="ExceptionStepDefinitions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using Reqnroll;

namespace Corvus.HighPerformance.Specs;

[Binding]
public class ExceptionStepDefinitions
{
    public Exception? Exception { get; set; }

    [Then("the attempt should have thrown a {string}")]
    [Then("the attempt should have thrown an {string}")]
    public void ThenTheAttemptShouldHaveThrownAn(string exceptionTypeName)
    {
        Assert.IsNotNull(this.Exception, "Exception expected, but none was thrown");

        Type exceptionType = Type.GetType(exceptionTypeName) ?? throw new ArgumentException($"Test was supplied with unrecognized exception type {exceptionTypeName}");
        Assert.IsInstanceOfType(this.Exception, exceptionType);
    }

    public void AttemptInvocationThatMightThrow(Action action)
    {
        try
        {
            action();
        }
        catch (Exception ex)
        {
            this.Exception = ex;
        }
    }
}
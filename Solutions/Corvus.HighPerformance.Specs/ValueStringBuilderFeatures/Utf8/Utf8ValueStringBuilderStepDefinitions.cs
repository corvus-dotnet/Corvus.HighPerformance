// <copyright file="Utf8ValueStringBuilderStepDefinitions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using System.Text;

using Corvus.HighPerformance.Specs;

using Reqnroll;

namespace ValueStringBuilderFeatures.Utf8;

[Binding]
public class Utf8ValueStringBuilderStepDefinitions(ExceptionStepDefinitions exceptionSteps)
{
    private Utf8ValueStringBuilderTestDriver? driver;

    private Utf8ValueStringBuilderTestDriver Driver => this.driver ?? throw new InvalidOperationException("No step that initialized the driver has been executed");

    [Given("a UTF-8 ValueStringBuilder initialized with {string} of length {int}")]
    public void GivenAUtf8ValueStringBuilderInitializedWithOfLength(
        Utf8ValueStringBuilderTestDriver.InitType intType, int initialCapacity)
    {
        this.driver = new(intType, initialCapacity);
    }

    [Given("I append {string} to the UTF-8 ValueStringBuilder")]
    public void GivenIAppendToTheUtf8ValueStringBuilder(string text)
    {
        this.Driver.AddOperation(new Utf8ValueStringBuilderTestDriver.AppendOperation(Encoding.UTF8.GetBytes(text).AsMemory()));
    }

    [Given("I append the Int32 {int} to the UTF-8 ValueStringBuilder")]
    public void GivenIAppendTheIntToTheUtf8ValueStringBuilder(int v)
    {
        this.Driver.AddOperation(new Utf8ValueStringBuilderTestDriver.AppendInt32Operation(v));
    }

    [Given("I replace {string} with {string} at index {int} with count {int} in the UTF-8 ValueStringBuilder")]
    public void GivenIReplaceWithAtIndexWithCount(
        string oldValue, string newValue, int startIndex, int count)
    {
        this.Driver.AddOperation(new Utf8ValueStringBuilderTestDriver.ReplaceOperation(
            Encoding.UTF8.GetBytes(oldValue).AsMemory(), Encoding.UTF8.GetBytes(newValue).AsMemory(), startIndex, count));
    }

    [Given("I attempt to replace {string} with {string} at index {int} with count {int} in the UTF-8 ValueStringBuilder")]
    public void GivenIAttemptToReplaceWithAtIndexWithCount(
        string oldValue, string newValue, int startIndex, int count)
    {
        this.Driver.AddOperation(new Utf8ValueStringBuilderTestDriver.AttemptReplaceOperation(
            Encoding.UTF8.GetBytes(oldValue).AsMemory(), Encoding.UTF8.GetBytes(newValue).AsMemory(), startIndex, count, exceptionSteps));
        this.Driver.Execute();
    }

    [When("I get the string from the UTF-8 ValueStringBuilder via {string}")]
    public void WhenIGetTheStringFromTheUtf8ValueStringBuilderVia(Utf8ValueStringBuilderValueFrom mechanism)
    {
        this.Driver.Execute(valueFrom: mechanism);
    }

    [When("I get the string from the UTF-8 ValueStringBuilder")]
    public void WhenIGetTheStringFromTheUtf8ValueStringBuilder()
    {
        this.WhenIGetTheStringFromTheUtf8ValueStringBuilderVia(Utf8ValueStringBuilderValueFrom.CreateStringAndDispose);
    }

    [When("I get the Memory starting at {int} with length {int} from the UTF-8 ValueStringBuilder")]
    public void WhenIGetTheMemoryStartingAtWithLengthFromTheUtf8ValueStringBuilder(int start, int length)
    {
        this.Driver.Execute(Utf8ValueStringBuilderValueFrom.Memory, start, length);
    }

    [When("I get the Memory starting at {int} from the UTF-8 ValueStringBuilder")]
    public void WhenIGetTheMemoryStartingAtFromTheUtf8ValueStringBuilder(int start)
    {
        this.Driver.Execute(Utf8ValueStringBuilderValueFrom.Memory, start);
    }

    [When("I get the Memory from the UTF-8 ValueStringBuilder")]
    public void WhenIGetTheMemoryFromTheUtf8ValueStringBuilder()
    {
        this.Driver.Execute(Utf8ValueStringBuilderValueFrom.Memory);
    }

    [When("I get the Span starting at {int} with length {int} from the UTF-8 ValueStringBuilder")]
    public void WhenIGetTheSpanStartingAtWithLengthFromTheUtf8ValueStringBuilder(int start, int length)
    {
        this.Driver.Execute(Utf8ValueStringBuilderValueFrom.Span, start, length);
    }

    [When("I get the Span starting at {int} from the UTF-8 ValueStringBuilder")]
    public void WhenIGetTheSpanStartingAtFromTheUtf8ValueStringBuilder(int start)
    {
        this.Driver.Execute(Utf8ValueStringBuilderValueFrom.Span, start);
    }

    [When("I get the Span from the UTF-8 ValueStringBuilder")]
    public void WhenIGetTheSpanFromTheUtf8ValueStringBuilder()
    {
        this.Driver.Execute(Utf8ValueStringBuilderValueFrom.Span);
    }

    [Then("the UTF-8 ValueStringBuilder string should be {string}")]
    public void ThenTheUtf8ValueStringBuilderStringShouldBe(string expectedResult)
    {
        Assert.IsTrue(Encoding.UTF8.GetBytes(expectedResult).AsMemory().Span.SequenceEqual(this.Driver.Result.Span));
    }
}
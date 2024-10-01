// <copyright file="ValueStringBuilderStepDefinitions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using System.Text;

using Corvus.HighPerformance.Specs;

using Reqnroll;

namespace ValueStringBuilderFeatures;

[Binding]
public class ValueStringBuilderStepDefinitions(ExceptionStepDefinitions exceptionSteps)
{
    private ValueStringBuilderTestDriver? driver;

    private ValueStringBuilderTestDriver Driver => this.driver ?? throw new InvalidOperationException("No step that initialized the driver has been executed");

    [Given("a ValueStringBuilder initialized with {string} of length {int}")]
    public void GivenAValueStringBuilderInitializedWithOfLength(
        ValueStringBuilderTestDriver.InitType intType, int initialCapacity)
    {
        this.driver = new(intType, initialCapacity);
    }

    [Given("I append {string} to the ValueStringBuilder")]
    public void GivenIAppendToTheValueStringBuilder(string text)
    {
        this.Driver.AddOperation(new ValueStringBuilderTestDriver.AppendOperation(text));
    }

    [Given("I append the Int32 {int} to the ValueStringBuilder")]
    public void GivenIAppendTheIntToTheValueStringBuilder(int v)
    {
        this.Driver.AddOperation(new ValueStringBuilderTestDriver.AppendInt32Operation(v));
    }

#if !NETFRAMEWORK
    [Given("I append the format {string} to the ValueStringBuilder with arguments {int} and {string}")]
    public void GivenIAppendTheFormatNumberString_ToTheValueStringBuilderWithArgumentsAnd(
        string format, int arg1, string arg2)
    {
        this.Driver.AddOperation(new ValueStringBuilderTestDriver.AppendFormatOperation(
            CompositeFormat.Parse(format),
            arg1,
            arg2));
    }
#endif

    [Given("I replace {string} with {string} at index {int} with count {int}")]
    public void GivenIReplaceWithAtIndexWithCount(
        string oldValue, string newValue, int startIndex, int count)
    {
        this.Driver.AddOperation(new ValueStringBuilderTestDriver.ReplaceOperation(
            oldValue, newValue, startIndex, count));
    }

    [Given("I attempt to replace {string} with {string} at index {int} with count {int}")]
    public void GivenIAttemptToReplaceWithAtIndexWithCount(
        string oldValue, string newValue, int startIndex, int count)
    {
        this.Driver.AddOperation(new ValueStringBuilderTestDriver.AttemptReplaceOperation(
            oldValue, newValue, startIndex, count, exceptionSteps));
        this.Driver.Execute();
    }

    [When("I get the string from the ValueStringBuilder via {string}")]
    public void WhenIGetTheStringFromTheValueStringBuilderVia(string mechanism)
    {
        this.Driver.Execute(valueFromRentedBuffer: mechanism switch
        {
            "ToString" => false,
            "GetRentedBuffer" => true,
            _ => throw new ArgumentException($"Unknown mechanism {mechanism}"),
        });
    }

    [When("I get the string from the ValueStringBuilder")]
    public void WhenIGetTheStringFromTheValueStringBuilder()
    {
        this.WhenIGetTheStringFromTheValueStringBuilderVia("ToString");
    }

    [Then("the ValueStringBuilder string should be {string}")]
    public void ThenTheValueStringBuilderStringShouldBe(string expectedResult)
    {
        Assert.AreEqual(expectedResult, this.Driver.Result);
    }
}
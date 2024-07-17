// <copyright file="ValueStringBuilderStepDefinitions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using Reqnroll;

namespace ValueStringBuilderFeatures;

[Binding]
public class ValueStringBuilderStepDefinitions
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

    [Given("I replace {string} with {string} at index {int} with count {int}")]
    public void GivenIReplaceWithAtIndexWithCount(
        string oldValue, string newValue, int startIndex, int count)
    {
        this.Driver.AddOperation(new ValueStringBuilderTestDriver.ReplaceOperation(
            oldValue, newValue, startIndex, count));
    }

    [When("I get the string from the ValueStringBuilder")]
    public void WhenIGetTheStringFromTheValueStringBuilder()
    {
        this.Driver.Execute();
    }

    [Then("the ValueStringBuilder string should be {string}")]
    public void ThenTheValueStringBuilderStringShouldBe(string expectedResult)
    {
        Assert.AreEqual(expectedResult, this.Driver.Result);
    }
}
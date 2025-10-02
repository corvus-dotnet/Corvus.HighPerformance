// <copyright file="ValueStringBuilderStepDefinitions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using System.Text;

using Corvus.HighPerformance.Specs;

using Reqnroll;
using ValueStringBuilderFeatures.Utf8;

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

    [Given("I slice {int} characters from the start of the ValueStringBuilder")]
    public void GivenISliceCharactersFromTheStartOfTheUtf8ValueStringBuilder(
    int start)
    {
        this.Driver.AddOperation(new ValueStringBuilderTestDriver.AttemptSliceOperation(start, exceptionSteps));
        try
        {
            this.Driver.Execute();
        }
        catch (ArgumentOutOfRangeException)
        {
        }
    }

    [Given("I slice {int} characters from the start of the ValueStringBuilder with length {int}")]
    public void GivenISliceCharactersFromTheStartOfTheUtf8ValueStringBuilderWithLength(
        int start, int length)
    {
        this.Driver.AddOperation(new ValueStringBuilderTestDriver.AttemptSliceWithLengthOperation(start, length, exceptionSteps));
        try
        {
            this.Driver.Execute();
        }
        catch (ArgumentOutOfRangeException)
        {
        }
    }

    [When("I get the string from the ValueStringBuilder via {string}")]
    public void WhenIGetTheStringFromTheValueStringBuilderVia(ValueStringBuilderValueFrom mechanism)
    {
        this.Driver.Execute(valueFrom: mechanism);
    }

    [When("I get the string from the ValueStringBuilder")]
    public void WhenIGetTheStringFromTheValueStringBuilder()
    {
        this.WhenIGetTheStringFromTheValueStringBuilderVia(ValueStringBuilderValueFrom.CreateStringAndDispose);
    }

    [When("I get the Memory starting at {int} with length {int} from the ValueStringBuilder")]
    public void WhenIGetTheMemoryStartingAtWithLengthFromTheValueStringBuilder(int start, int length)
    {
        this.Driver.Execute(ValueStringBuilderValueFrom.Memory, start, length);
    }

    [When("I get the Memory starting at {int} from the ValueStringBuilder")]
    public void WhenIGetTheMemoryStartingAtFromTheValueStringBuilder(int start)
    {
        this.Driver.Execute(ValueStringBuilderValueFrom.Memory, start);
    }

    [When("I get the Memory from the ValueStringBuilder")]
    public void WhenIGetTheMemoryFromTheValueStringBuilder()
    {
        this.Driver.Execute(ValueStringBuilderValueFrom.Memory);
    }

    [When("I get the Span starting at {int} with length {int} from the ValueStringBuilder")]
    public void WhenIGetTheSpanStartingAtWithLengthFromTheValueStringBuilder(int start, int length)
    {
        this.Driver.Execute(ValueStringBuilderValueFrom.Span, start, length);
    }

    [When("I get the Span starting at {int} from the ValueStringBuilder")]
    public void WhenIGetTheSpanStartingAtFromTheValueStringBuilder(int start)
    {
        this.Driver.Execute(ValueStringBuilderValueFrom.Span, start);
    }

    [When("I get the Span from the ValueStringBuilder")]
    public void WhenIGetTheSpanFromTheValueStringBuilder()
    {
        this.Driver.Execute(ValueStringBuilderValueFrom.Span);
    }

    [Then("the ValueStringBuilder string should be {string}")]
    public void ThenTheValueStringBuilderStringShouldBe(string expectedResult)
    {
        Assert.AreEqual(expectedResult, this.Driver.Result);
    }
}
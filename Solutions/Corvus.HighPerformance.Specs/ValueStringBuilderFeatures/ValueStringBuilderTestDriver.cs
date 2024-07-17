// <copyright file="ValueStringBuilderTestDriver.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using Corvus.HighPerformance;

namespace ValueStringBuilderFeatures;

public class ValueStringBuilderTestDriver(
    ValueStringBuilderTestDriver.InitType initType,
    int initialCapacity)
{
    private readonly List<OperationBase> operations = [];
    private string? result;

    public enum InitType
    {
        Span,
        Capacity,
    }

    public string Result => this.result ?? throw new InvalidOperationException("Result requires Execute to have run");

    public void AddOperation(OperationBase operation)
    {
        this.operations.Add(operation);
    }

    public void Execute()
    {
        ValueStringBuilder sb = initType switch
        {
            InitType.Span => new ValueStringBuilder(stackalloc char[initialCapacity]),
            InitType.Capacity => new ValueStringBuilder(initialCapacity),
            _ => throw new InvalidOperationException(),
        };

        foreach (OperationBase op in this.operations)
        {
            op.Execute(ref sb);
        }

        this.result = sb.ToString();
    }

    public abstract class OperationBase
    {
        public abstract void Execute(ref ValueStringBuilder sb);
    }

    public class AppendOperation(string value) : OperationBase
    {
        public override void Execute(ref ValueStringBuilder sb)
        {
            sb.Append(value);
        }
    }

    public class ReplaceOperation(
            string oldValue,
            string newValue,
            int startIndex,
            int count)
        : OperationBase
    {
        public override void Execute(ref ValueStringBuilder sb)
        {
            sb.Replace(oldValue, newValue, startIndex, count);
        }
    }
}
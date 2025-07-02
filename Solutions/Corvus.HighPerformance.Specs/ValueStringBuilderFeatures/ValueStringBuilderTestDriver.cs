// <copyright file="ValueStringBuilderTestDriver.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using System.Globalization;
using System.Text;

using Corvus.HighPerformance;
using Corvus.HighPerformance.Specs;

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

    public void Execute(
        ValueStringBuilderValueFrom valueFrom = ValueStringBuilderValueFrom.CreateStringAndDispose,
        int? start = null,
        int? length = null)
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

        switch (valueFrom)
        {
            case ValueStringBuilderValueFrom.CreateStringAndDispose:
                this.result = sb.CreateStringAndDispose();
                break;

            case ValueStringBuilderValueFrom.RentedBuffer:
                (char[]? rentedBuffer, int returnedLength) = sb.GetRentedBufferAndLengthAndDispose();
                this.result = rentedBuffer.AsSpan(0, returnedLength).ToString();
                ValueStringBuilder.ReturnRentedBuffer(rentedBuffer);
                break;

            case ValueStringBuilderValueFrom.Memory:
                if (length.HasValue)
                {
                    if (!start.HasValue)
                    {
                        throw new ArgumentException("If length is specified, start must also be specified.", nameof(length));
                    }

                    this.result = sb.AsMemory(start.Value, length.Value).ToString();
                }
                else if (start.HasValue)
                {
                    this.result = sb.AsMemory(start.Value).ToString();
                }
                else
                {
                    this.result = sb.AsMemory().ToString();
                }

                break;

            case ValueStringBuilderValueFrom.Span:
                if (length.HasValue)
                {
                    if (!start.HasValue)
                    {
                        throw new ArgumentException("If length is specified, start must also be specified.", nameof(length));
                    }

                    this.result = sb.AsSpan(start.Value, length.Value).ToString();
                }
                else if (start.HasValue)
                {
                    this.result = sb.AsSpan(start.Value).ToString();
                }
                else
                {
                    this.result = sb.AsSpan().ToString();
                }

                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(valueFrom), valueFrom, null);
        }
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

    public class AppendInt32Operation(int value) : OperationBase
    {
        public override void Execute(ref ValueStringBuilder sb)
        {
            sb.Append(value);
        }
    }

#if !NETFRAMEWORK
    public class AppendFormatOperation(CompositeFormat format, int arg1, string arg2) : OperationBase
    {
        public override void Execute(ref ValueStringBuilder sb)
        {
            sb.AppendFormat(CultureInfo.InvariantCulture, format, [arg1, arg2]);
        }
    }
#endif

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

    public class AttemptReplaceOperation(
            string oldValue,
            string newValue,
            int startIndex,
            int count,
            ExceptionStepDefinitions exceptionSteps)
        : OperationBase
    {
        public override void Execute(ref ValueStringBuilder sb)
        {
            try
            {
                sb.Replace(oldValue, newValue, startIndex, count);
            }
            catch (Exception ex)
            {
                exceptionSteps.Exception = ex;
            }
        }
    }
}
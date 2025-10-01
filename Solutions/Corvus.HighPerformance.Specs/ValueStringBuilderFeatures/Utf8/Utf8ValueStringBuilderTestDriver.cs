// <copyright file="Utf8ValueStringBuilderTestDriver.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using System.Globalization;
using System.Text;

using Corvus.HighPerformance.Specs;
using Corvus.HighPerformance.Utf8;

namespace ValueStringBuilderFeatures.Utf8;

public class Utf8ValueStringBuilderTestDriver(
    Utf8ValueStringBuilderTestDriver.InitType initType,
    int initialCapacity)
{
    private readonly List<OperationBase> operations = [];
    private ReadOnlyMemory<byte>? result;

    public enum InitType
    {
        Span,
        Capacity,
    }

    public ReadOnlyMemory<byte> Result => this.result ?? throw new InvalidOperationException("Result requires Execute to have run");

    public void AddOperation(OperationBase operation)
    {
        this.operations.Add(operation);
    }

    public void Execute(
        Utf8ValueStringBuilderValueFrom valueFrom = Utf8ValueStringBuilderValueFrom.CreateStringAndDispose,
        int? start = null,
        int? length = null)
    {
        ValueStringBuilder sb = initType switch
        {
            InitType.Span => new ValueStringBuilder(stackalloc byte[initialCapacity]),
            InitType.Capacity => new ValueStringBuilder(initialCapacity),
            _ => throw new InvalidOperationException(),
        };

        foreach (OperationBase op in this.operations)
        {
            op.Execute(ref sb);
        }

        switch (valueFrom)
        {
            case Utf8ValueStringBuilderValueFrom.CreateStringAndDispose:
                this.result = sb.CreateMemoryAndDispose();
                break;

            case Utf8ValueStringBuilderValueFrom.RentedBuffer:
                (byte[]? rentedBuffer, int returnedLength) = sb.GetRentedBufferAndLengthAndDispose();
                this.result = rentedBuffer.AsSpan(0, returnedLength).ToArray();
                ValueStringBuilder.ReturnRentedBuffer(rentedBuffer);
                break;

            case Utf8ValueStringBuilderValueFrom.Memory:
                if (length.HasValue)
                {
                    if (!start.HasValue)
                    {
                        throw new ArgumentException("If length is specified, start must also be specified.", nameof(length));
                    }

                    this.result = sb.AsMemory(start.Value, length.Value);
                }
                else if (start.HasValue)
                {
                    this.result = sb.AsMemory(start.Value);
                }
                else
                {
                    this.result = sb.AsMemory();
                }

                break;

            case Utf8ValueStringBuilderValueFrom.Span:
                if (length.HasValue)
                {
                    if (!start.HasValue)
                    {
                        throw new ArgumentException("If length is specified, start must also be specified.", nameof(length));
                    }

                    this.result = sb.AsSpan(start.Value, length.Value).ToArray();
                }
                else if (start.HasValue)
                {
                    this.result = sb.AsSpan(start.Value).ToArray();
                }
                else
                {
                    this.result = sb.AsSpan().ToArray();
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

    public class AppendOperation(ReadOnlyMemory<byte> value) : OperationBase
    {
        public override void Execute(ref ValueStringBuilder sb)
        {
            sb.Append(value.Span);
        }
    }

    public class AppendInt32Operation(int value) : OperationBase
    {
        public override void Execute(ref ValueStringBuilder sb)
        {
            sb.Append(value);
        }
    }

    public class ReplaceOperation(
            ReadOnlyMemory<byte> oldValue,
            ReadOnlyMemory<byte> newValue,
            int startIndex,
            int count)
        : OperationBase
    {
        public override void Execute(ref ValueStringBuilder sb)
        {
            sb.Replace(oldValue.Span, newValue.Span, startIndex, count);
        }
    }

    public class AttemptReplaceOperation(
            ReadOnlyMemory<byte> oldValue,
            ReadOnlyMemory<byte> newValue,
            int startIndex,
            int count,
            ExceptionStepDefinitions exceptionSteps)
        : OperationBase
    {
        public override void Execute(ref ValueStringBuilder sb)
        {
            try
            {
                sb.Replace(oldValue.Span, newValue.Span, startIndex, count);
            }
            catch (Exception ex)
            {
                exceptionSteps.Exception = ex;
            }
        }
    }

    public class AttemptSliceOperation(
        int count,
        ExceptionStepDefinitions exceptionSteps)
    : OperationBase
    {
        public override void Execute(ref ValueStringBuilder sb)
        {
            try
            {
                sb.ApplySlice(count);
            }
            catch (Exception ex)
            {
                exceptionSteps.Exception = ex;
            }
        }
    }

    public class AttemptSliceWithLengthOperation(
    int count,
    int length,
    ExceptionStepDefinitions exceptionSteps)
        : OperationBase
    {
        public override void Execute(ref ValueStringBuilder sb)
        {
            try
            {
                sb.ApplySlice(count,  length);
            }
            catch (Exception ex)
            {
                exceptionSteps.Exception = ex;
            }
        }
    }
}
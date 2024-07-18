﻿// <copyright file="ValueStringBuilder.Replace.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
// <license>
// Derived from code Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See https://github.com/dotnet/runtime/blob/c1049390d5b33483203f058b0e1457d2a1f62bf4/src/libraries/Common/src/System/Text/ValueStringBuilder.cs
// </license>

#pragma warning disable // Currently this is a straight copy of the original code, so we disable warnings to avoid diagnostic problems.

#if !NET8_0_OR_GREATER
using System.Runtime.CompilerServices;
#endif

namespace Corvus.HighPerformance;

public ref partial struct ValueStringBuilder
{
#if !NET8_0_OR_GREATER
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Replace(
        string oldValue,
        string newValue,
        int startIndex,
        int count)
        => Replace(oldValue.AsSpan(), newValue.AsSpan(), startIndex, count);
#endif

    public void Replace(
        ReadOnlySpan<char> oldValue,
        ReadOnlySpan<char> newValue,
        int startIndex,
        int count)
    {
        // TODO: range must not exceed pos

        int matchIndex = _chars[startIndex..(startIndex + count)].IndexOf(oldValue);
        if (matchIndex == -1)
        {
            return;
        }

        int diff = newValue.Length - oldValue.Length;
        if (diff == 0)
        {
            return;
        }
        if (diff < 0)
        {
            // We will never need to grow the buffer, but we might need to shift characters
            // down.
            Span<char> remainingTargetBuffer = _chars[(startIndex + matchIndex)..this._pos];
            do
            {
                this._pos += diff;

                newValue.CopyTo(remainingTargetBuffer);

                Span<char> remainingSourceBuffer = remainingTargetBuffer[oldValue.Length..];
                remainingTargetBuffer = remainingTargetBuffer[newValue.Length..];

                matchIndex = remainingSourceBuffer.IndexOf(oldValue);

                int endOfChunkToRelocate = matchIndex == -1 ? remainingSourceBuffer.Length : matchIndex;
                remainingSourceBuffer[..endOfChunkToRelocate].CopyTo(remainingTargetBuffer);

                remainingTargetBuffer = remainingSourceBuffer[endOfChunkToRelocate..];
            } while (matchIndex != -1);

            return;
        }
        else
        {
            
        }
    }
}
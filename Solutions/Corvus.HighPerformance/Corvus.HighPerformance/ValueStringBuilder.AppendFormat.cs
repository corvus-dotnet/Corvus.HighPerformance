// <copyright file="ValueStringBuilder.AppendFormat.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

#if NET8_0_OR_GREATER

using System.Diagnostics;
using System.Text;

namespace Corvus.HighPerformance;

/// <summary>
/// Low-allocation alternative to <see cref="StringBuilder"/>.
/// </summary>
public ref partial struct ValueStringBuilder
{
    /// <summary>
    /// Appends the result of a composite format string with the specified arguments to the string.
    /// </summary>
    /// <param name="formatProvider">
    /// Format provider for localisability.
    /// </param>
    /// <param name="format">The <see cref="CompositeFormat"/>.</param>
    /// <param name="formatArgs">The arguments required by the <see cref="CompositeFormat"/>.</param>
    public void AppendFormat(
        IFormatProvider formatProvider,
        CompositeFormat format,
        scoped ReadOnlySpan<object?> formatArgs)
    {
        int charsWritten;
        while (!this._chars[this._pos..].TryWrite(formatProvider, format, out charsWritten, formatArgs))
        {
            // TODO: it's unclear what the correct behaviour is here.
            // We consider it to be symptomatic of a mistake if you hit this path, but we
            // tolerate it. We aren't sure whether to Debug.Assert, or just plod on silently.
            // Since we don't really understand whether there are scenarios in which the
            // caller really can't correctly pre-allocate the buffer, we are going to
            // Debug.Assert for now, but if it turns out there are really good reasons
            // to be unable to do this, we will either relax this, or provide specialized
            // overloads that enable the caller to control how to deal with reallocation.
            Debug.Assert(false, "The buffer was too small to write the formatted string.");

            // Since we don't have well-defined scenarios in which this is normal, we don't
            // have a good growth strategy, so here is a strategy.
            this.Grow(this._chars.Length - this._pos + 1);
        }

        this._pos += charsWritten;
    }
}

#endif
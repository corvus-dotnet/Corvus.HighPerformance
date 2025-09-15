// <copyright file="Utf8ValueStringBuilderValueFrom.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace ValueStringBuilderFeatures.Utf8;

public enum Utf8ValueStringBuilderValueFrom
{
    RentedBuffer,
    CreateStringAndDispose,
    Memory,
    Span,
}
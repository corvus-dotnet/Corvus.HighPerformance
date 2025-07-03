// <copyright file="ValueStringBuilderValueFrom.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace ValueStringBuilderFeatures;

public enum ValueStringBuilderValueFrom
{
    RentedBuffer,
    CreateStringAndDispose,
    Memory,
    Span,
}
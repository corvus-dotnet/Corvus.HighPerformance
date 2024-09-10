# Corvus.HighPerformance

Libraries for writing low-allocation and other high-performance .NET code. See [release notes](Documentation/ReleaseNotes/Corvus.HighPerformance.v1.md) for detailed information about recent changes.


## Supported platforms

.NET 8.0 or later and .NET Standard 2.0.


## Usage

Provides `ValueStringBuilder`, enabling low-allocation gradual creation of strings. This is a `ref struct` (because it wraps a `Span<char>`).

This is intended for high-performance scenarios. This is _not_ a drop-in replacement for `StringBuilder`. It is more complex to use, and as with all low-allocation code, it is easily misused, and you should always profile your code to find out whether this has the performance characteristics you are hoping for.

There are two ways to initialize a `ValueStringBuilder`. You can pass it an existing `Span<char>`, e.g.:

```cs
const int initialCapacity = 16;
Span<char> buffer = stackalloc char[initialCapacity];
using ValueStringBuilder sb = new(buffer);
```

Or you can specify a required capacity in which case it will rent a buffer of suitable size:

```cs
using ValueStringBuilder sb = new(initialCapacity);
```

You can then append values, or modify the text:

```cs
sb.Append("Hello!");            // Hello!
sb.Append(42);                  // Hello!42

sb.Replace("!42", "world!");    // Helloworld!
sb.Insert(5, ", ");             // Hello, world!
```

Note that if this exceeds the initial buffer capacity, this will automatically rent a new, larger buffer.

Once you are ready to use the string, and if you are passing it to something that knows how to work directly with `ReadOnlySpan<char>` you can call `AsSpan()`:

```cs
TextWriter tw = GetWriter(); // ...or anything else that knows how to use ReadOnlySpan<char>
tw.Write(sb.AsSpan());
```

Since `ValueStringBuilder` provides a `Dispose` method, then as long as you declared it with `using` (as the examples above do), then if it had to allocate a buffer, it will automatically return that buffer to the pool when disposed.

If you are using an API that requires a string, we offer `CreateStringAndDispose`:

```cs
string stringOnTheGcHeap = sb.CreateStringAndDispose();
```

This will always allocate a new `string` on the GC heap, but some APIs will require that. (`ValueStringBuilder` still offers value because it means you need only a single allocation.) This method also disposes the `ValueStringBuilder` to discourage unnecessary creation of multiple copies of the string. (`ToString` is not overridden. This differs from `StringBuilder`, and again it is to discourage multiple copies.)

There are more advanced uses in which code will want to retain the pooled buffer rather than allocating another buffer or `string` with a copy. For this we offer `GetRentedBufferAndLengthAndDispose`:

```cs
(char[]? rentedBuffer, int length) = sb.GetRentedBufferAndLengthAndDispose();
```

In cases where you passed a `Span<char>` and did not exceed the capacity, the string will have been written in place, and this will set `rentedBuffer` to `null`. However, for most scenarios in which `GetRentedBufferAndLengthAndDispose` you will probably not want to use the `Span<char>` constructor, so that you can rely on the buffer always existing.

Buffers returned this way have always been rented, but this method causes the `ValueStringBuilder` to relinquish ownership, so you should always go on to do this:

```cs
sb.ReturnRentedBuffer(rentedBuffer);
```

If you `Dispose` a `ValueStringBuilder` without having called either of the `...AndDispose()` methods, it will still own the buffer, so it will return it to the pool for you.

## Project Sponsor

This project is sponsored by [endjin](https://endjin.com), a UK based Microsoft Gold Partner for Cloud Platform, Data Platform, Data Analytics, DevOps, and a Power BI Partner.

For more information about our products and services, or for commercial support of this project, please [contact us](https://endjin.com/contact-us). 

We produce two free weekly newsletters; [Azure Weekly](https://azureweekly.info) for all things about the Microsoft Azure Platform, and [Power BI Weekly](https://powerbiweekly.info).

Keep up with everything that's going on at endjin via our [blog](https://endjin.com/blog), follow us on [Twitter](https://twitter.com/endjin), or [LinkedIn](https://www.linkedin.com/company/1671851/).

Our other Open Source projects can be found at [https://endjin.com/open-source](https://endjin.com/open-source)

## Code of conduct

This project has adopted a code of conduct adapted from the [Contributor Covenant](http://contributor-covenant.org/) to clarify expected behavior in our community. This code of conduct has been [adopted by many other projects](http://contributor-covenant.org/adopters/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [&#104;&#101;&#108;&#108;&#111;&#064;&#101;&#110;&#100;&#106;&#105;&#110;&#046;&#099;&#111;&#109;](&#109;&#097;&#105;&#108;&#116;&#111;:&#104;&#101;&#108;&#108;&#111;&#064;&#101;&#110;&#100;&#106;&#105;&#110;&#046;&#099;&#111;&#109;) with any additional questions or comments.

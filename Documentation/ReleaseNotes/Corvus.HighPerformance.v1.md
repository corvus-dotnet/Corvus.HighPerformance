# Release notes for Corvus.HighPerformance v1.

## v1.0

First non-preview release.

### Breaking changes since preview 0.2

* `GetRentedBuffer` replaced with `GetRentedBufferAndLengthAndDispose` which makes a common mistake harder to make, and clarifies what the method does
* `ToString` no longer disposes the instance
* `ToStringAndDispose` is now the approved way to get a `string` and dispose the object (instead of the less-than-obvious use of `ToString`)
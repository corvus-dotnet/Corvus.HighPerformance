Feature: Slice values from a ValueStringBuilder

Scenario Outline: Slice the ValueStringBuilder
    Given a ValueStringBuilder initialized with '<InitializationType>' of length <InitialLength>
	And I append 'Hello' to the ValueStringBuilder
	And I slice <Start> characters from the start of the ValueStringBuilder
	When I get the Span from the ValueStringBuilder
	Then the ValueStringBuilder string should be '<ExpectedValue>'
	Examples:
		| InitializationType | InitialLength | Start | ExpectedValue |
		| Span               | 10            | 0     | Hello         |
		| Capacity           | 10            | 0     | Hello         |
		| Span               | 10            | 1     | ello          |
		| Capacity           | 10            | 1     | ello          |
		| Span               | 10            | 2     | llo           |
		| Capacity           | 10            | 2     | llo           |
		| Span               | 10            | 5     |               |
		| Capacity           | 10            | 5     |               |

	Scenario Outline: Slice the ValueStringBuilder with start and length
    Given a ValueStringBuilder initialized with '<InitializationType>' of length <InitialLength>
	And I append 'Hello' to the ValueStringBuilder
	And I slice <Start> characters from the start of the ValueStringBuilder with length <Length>
	When I get the Span from the ValueStringBuilder
	Then the ValueStringBuilder string should be '<ExpectedValue>'
	Examples:
		| InitializationType | InitialLength | Start | Length | ExpectedValue |
		| Span               | 10            | 0     | 5      | Hello         |
		| Capacity           | 10            | 0     | 5      | Hello         |
		| Span               | 10            | 1     | 4      | ello          |
		| Capacity           | 10            | 1     | 4      | ello          |
		| Span               | 10            | 2     | 3      | llo           |
		| Capacity           | 10            | 2     | 3      | llo           |
		| Span               | 10            | 0     | 4      | Hell          |
		| Capacity           | 10            | 0     | 4      | Hell          |
		| Span               | 10            | 1     | 3      | ell           |
		| Capacity           | 10            | 1     | 3      | ell           |
		| Span               | 10            | 2     | 2      | ll            |
		| Capacity           | 10            | 2     | 2      | ll            |
		| Span               | 10            | 1     | 0      |               |
		| Capacity           | 10            | 1     | 0      |               |
		| Span               | 10            | 0     | 0      |               |
		| Capacity           | 10            | 0     | 0      |               |

Scenario Outline: Specified range is out of bounds (start and length)
	Given a ValueStringBuilder initialized with '<InitializationType>' of length 25
	And I append 'Hello' to the ValueStringBuilder
	And I slice <Start> characters from the start of the ValueStringBuilder with length <Length>
	Then the attempt should have thrown a 'System.ArgumentOutOfRangeException'
	Examples:
		| InitializationType | Start | Length |
		| Span               | 0     | 6      |
		| Span               | 1     | 5      |
		| Span               | 5     | 1      |
		| Span               | 6     | 0      |
		| Capacity           | 0     | 6      |
		| Capacity           | 1     | 5      |
		| Capacity           | 5     | 1      |
		| Capacity           | 6     | 0      |

	Scenario Outline: Specified range is out of bounds (start only)
	Given a ValueStringBuilder initialized with '<InitializationType>' of length 25
	And I append 'Hello' to the ValueStringBuilder
	And I slice <Start> characters from the start of the ValueStringBuilder
	Then the attempt should have thrown a 'System.ArgumentOutOfRangeException'
	Examples:
		| InitializationType | Start |
		| Span               | 6     |
		| Capacity           | 7     |

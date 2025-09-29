Feature: Slice values from a UTF-8 ValueStringBuilder

Scenario Outline: Slice the UTF-8 ValueStringBuilder
    Given a UTF-8 ValueStringBuilder initialized with '<InitializationType>' of length <InitialLength>
	And I append 'Hello' to the UTF-8 ValueStringBuilder
	And I slice <Start> characters from the start of the UTF-8 ValueStringBuilder
	When I get the Span from the UTF-8 ValueStringBuilder
	Then the UTF-8 ValueStringBuilder string should be '<ExpectedValue>'
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

	Scenario Outline: Slice the UTF-8 ValueStringBuilder with start and length
    Given a UTF-8 ValueStringBuilder initialized with '<InitializationType>' of length <InitialLength>
	And I append 'Hello' to the UTF-8 ValueStringBuilder
	And I slice <Start> characters from the start of the UTF-8 ValueStringBuilder with length <Length>
	When I get the Span from the UTF-8 ValueStringBuilder
	Then the UTF-8 ValueStringBuilder string should be '<ExpectedValue>'
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
	Given a UTF-8 ValueStringBuilder initialized with '<InitializationType>' of length 25
	And I append 'Hello' to the UTF-8 ValueStringBuilder
	And I slice <Start> characters from the start of the UTF-8 ValueStringBuilder with length <Length>
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
	Given a UTF-8 ValueStringBuilder initialized with '<InitializationType>' of length 25
	And I append 'Hello' to the UTF-8 ValueStringBuilder
	And I slice <Start> characters from the start of the UTF-8 ValueStringBuilder
	Then the attempt should have thrown a 'System.ArgumentOutOfRangeException'
	Examples:
		| InitializationType | Start |
		| Span               | 7     |
		| Capacity           | 7     |

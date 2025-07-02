Feature: Retrieve a Memory from a ValueStringBuilder

Scenario Outline: Retrieve a Memory from a ValueStringBuilder
    Given a ValueStringBuilder initialized with '<InitializationType>' of length <InitialLength>
	And I append 'Hello' to the ValueStringBuilder
	And I append 'World!' to the ValueStringBuilder
	When I get the Memory from the ValueStringBuilder
	Then the ValueStringBuilder string should be 'HelloWorld!'
	Examples:
		| InitializationType | InitialLength |
		| Span               | 10            |
		| Capacity           | 10            |
		| Span               | 11            |
		| Capacity           | 11            |
		| Span               | 20            |
		| Capacity           | 20            |

Scenario Outline: Retrieve a Memory with a start position from a ValueStringBuilder
    Given a ValueStringBuilder initialized with '<InitializationType>' of length <InitialLength>
	And I append 'Hello' to the ValueStringBuilder
	And I append 'World!' to the ValueStringBuilder
	When I get the Memory starting at <Start> from the ValueStringBuilder
	Then the ValueStringBuilder string should be '<ExpectedValue>'
	Examples:
		| InitializationType | InitialLength | Start | ExpectedValue |
		| Span               | 10            | 0     | HelloWorld!   |
		| Capacity           | 10            | 0     | HelloWorld!   |
		| Span               | 20            | 0     | HelloWorld!   |
		| Capacity           | 20            | 0     | HelloWorld!   |
		| Span               | 10            | 3     | loWorld!      |
		| Capacity           | 10            | 3     | loWorld!      |
		| Span               | 20            | 3     | loWorld!      |
		| Capacity           | 20            | 3     | loWorld!      |


Scenario Outline: Retrieve a Memory with a start position and length from a ValueStringBuilder
    Given a ValueStringBuilder initialized with '<InitializationType>' of length <InitialLength>
	And I append 'Hello' to the ValueStringBuilder
	And I append 'World!' to the ValueStringBuilder
	When I get the Memory starting at <Start> with length <Length> from the ValueStringBuilder
	Then the ValueStringBuilder string should be '<ExpectedValue>'
	Examples:
		| InitializationType | InitialLength | Start | Length | ExpectedValue |
		| Span               | 10            | 0     | 11     | HelloWorld!   |
		| Capacity           | 10            | 0     | 11     | HelloWorld!   |
		| Span               | 20            | 0     | 11     | HelloWorld!   |
		| Capacity           | 20            | 0     | 11     | HelloWorld!   |
		| Span               | 10            | 0     | 0      |               |
		| Capacity           | 10            | 0     | 0      |               |
		| Span               | 20            | 0     | 0      |               |
		| Capacity           | 20            | 0     | 0      |               |
		| Span               | 10            | 5     | 0      |               |
		| Capacity           | 10            | 5     | 0      |               |
		| Span               | 20            | 5     | 0      |               |
		| Capacity           | 20            | 5     | 0      |               |
		| Span               | 10            | 3     | 8      | loWorld!      |
		| Capacity           | 10            | 3     | 8      | loWorld!      |
		| Span               | 20            | 3     | 8      | loWorld!      |
		| Capacity           | 20            | 3     | 8      | loWorld!      |
		| Span               | 10            | 3     | 3      | loW           |
		| Capacity           | 10            | 3     | 3      | loW           |
		| Span               | 20            | 3     | 3      | loW           |
		| Capacity           | 20            | 3     | 3      | loW           |
		| Span               | 10            | 10    | 1      | !             |
		| Capacity           | 10            | 10    | 1      | !             |
		| Span               | 20            | 10    | 1      | !             |
		| Capacity           | 20            | 10    | 1      | !             |

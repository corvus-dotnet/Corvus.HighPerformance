Feature: Append content into a ValueStringBuilder

Scenario Outline: Fits in available space
    Given a ValueStringBuilder initialized with '<InitializationType>' of length <InitialLength>
	And I append '<FirstValue>' to the ValueStringBuilder
	And I append '<SecondValue>' to the ValueStringBuilder
	When I get the string from the ValueStringBuilder
	Then the ValueStringBuilder string should be '<FirstValue><SecondValue>'
	Examples:
		| InitializationType | InitialLength | FirstValue | SecondValue |
		| Span               | 11            | Hello      | World!      |
		| Capacity           | 11            | Hello      | World!      |
		| Span               | 20            | Hello      | World!      |
		| Capacity           | 20            | Hello      | World!      |

Scenario Outline: Grows
    Given a ValueStringBuilder initialized with '<InitializationType>' of length <InitialLength>
	And I append '<FirstValue>' to the ValueStringBuilder
	And I append '<SecondValue>' to the ValueStringBuilder
	When I get the string from the ValueStringBuilder
	Then the ValueStringBuilder string should be '<FirstValue><SecondValue>'
	Examples:
		| InitializationType | InitialLength | FirstValue    | SecondValue                         |
		| Span               | 11            | Hello, world! | It is mighty fine to see you today. |
		| Capacity           | 11            | Hello, world! | It is mighty fine to see you today. |

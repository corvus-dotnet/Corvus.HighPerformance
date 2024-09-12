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
	When I get the string from the ValueStringBuilder via '<GetStringMechanism>'
	Then the ValueStringBuilder string should be '<FirstValue><SecondValue>'
	Examples:
		| InitializationType | InitialLength | FirstValue    | SecondValue                         | GetStringMechanism |
		| Span               | 11            | Hello, world! | It is mighty fine to see you today. | ToString           |
		| Capacity           | 11            | Hello, world! | It is mighty fine to see you today. | ToString           |
		| Span               | 11            | Hello, world! | It is mighty fine to see you today. | GetRentedBuffer    |
		| Capacity           | 11            | Hello, world! | It is mighty fine to see you today. | GetRentedBuffer    |

Scenario Outline: Append number
    Given a ValueStringBuilder initialized with '<InitializationType>' of length <InitialLength>
	And I append '<FirstValue>' to the ValueStringBuilder
	And I append the Int32 <SecondValue> to the ValueStringBuilder
	When I get the string from the ValueStringBuilder
	Then the ValueStringBuilder string should be '<FirstValue><SecondValue>'
	Examples:
		| InitializationType | InitialLength | FirstValue    | SecondValue |
		| Span               | 13            | Hello, world! | 42          |
		| Capacity           | 13            | Hello, world! | 42          |
		| Span               | 15            | Hello, world! | 42          |
		| Capacity           | 15            | Hello, world! | 42          |
		| Span               | 13            | Hello, world! | -42         |
		| Capacity           | 13            | Hello, world! | -42         |
		| Span               | 15            | Hello, world! | -42         |
		| Capacity           | 15            | Hello, world! | -42         |

Scenario Outline: Append number then string
    Given a ValueStringBuilder initialized with '<InitializationType>' of length <InitialLength>
	And I append the Int32 <FirstValue> to the ValueStringBuilder
	And I append '<SecondValue>' to the ValueStringBuilder
	When I get the string from the ValueStringBuilder
	Then the ValueStringBuilder string should be '<FirstValue><SecondValue>'
	Examples:
		| InitializationType | InitialLength | FirstValue | SecondValue   |
		| Span               | 13            | 42         | Hello, world! |
		| Capacity           | 13            | 42         | Hello, world! |
		| Span               | 15            | 42         | Hello, world! |
		| Capacity           | 15            | 42         | Hello, world! |
		| Span               | 13            | -42        | Hello, world! |
		| Capacity           | 13            | -42        | Hello, world! |
		| Span               | 15            | -42        | Hello, world! |
		| Capacity           | 15            | -42        | Hello, world! |

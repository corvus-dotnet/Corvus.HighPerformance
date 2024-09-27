Feature: Append CompositeFormat into a ValueStringBuilder

Scenario Outline: Append composite format
    Given a ValueStringBuilder initialized with '<InitializationType>' of length <InitialLength>
	And I append the format '<CompositeFormat>' to the ValueStringBuilder with arguments <FirstValue> and '<SecondValue>'
	When I get the string from the ValueStringBuilder
	Then the ValueStringBuilder string should be '<Result>'
	Examples:
		| InitializationType | InitialLength | CompositeFormat           | FirstValue | SecondValue   | Result                             |
		| Span               | 34            | Number: {0}, string: {1}. | 42         | Hello, world! | Number: 42, string: Hello, world!. |
		| Span               | 26            | {0}, string: {1}.         | 42         | Hello, world! | 42, string: Hello, world!.         |
		| Span               | 33            | Number: {0}, string: {1}  | 42         | Hello, world! | Number: 42, string: Hello, world!  |
		| Span               | 15            | {0}{1}                    | 42         | Hello, world! | 42Hello, world!                    |
		| Span               | 15            | {1}{0}                    | 42         | Hello, world! | Hello, world!42                    |
		| Capacity           | 34            | Number: {0}, string: {1}. | 42         | Hello, world! | Number: 42, string: Hello, world!. |
		| Capacity           | 26            | {0}, string: {1}.         | 42         | Hello, world! | 42, string: Hello, world!.         |
		| Capacity           | 33            | Number: {0}, string: {1}  | 42         | Hello, world! | Number: 42, string: Hello, world!  |
		| Capacity           | 15            | {0}{1}                    | 42         | Hello, world! | 42Hello, world!                    |
		| Capacity           | 15            | {1}{0}                    | 42         | Hello, world! | Hello, world!42                    |
		| Span               | 34            | Number: {0}, string: {1}. | 42         | Hello, world! | Number: 42, string: Hello, world!. |
		| Capacity           | 34            | Number: {0}, string: {1}. | 42         | Hello, world! | Number: 42, string: Hello, world!. |
		| Span               | 35            | Number: {0}, string: {1}. | -42        | Hello, world! | Number: -42, string: Hello, world!. |
		| Capacity           | 35            | Number: {0}, string: {1}. | -42        | Hello, world! | Number: -42, string: Hello, world!. |
		| Span               | 35            | Number: {0}, string: {1}. | -42        | Hello, world! | Number: -42, string: Hello, world!. |
		| Capacity           | 35            | Number: {0}, string: {1}. | -42        | Hello, world! | Number: -42, string: Hello, world!. |

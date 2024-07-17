Feature: Replace content in a ValueStringBuilder

Scenario Outline: No change
	Given a ValueStringBuilder initialized with '<InitializationType>' of length 13
	And I append 'Hello, World!' to the ValueStringBuilder
	And I replace 'notpresent' with 'notused' at index 0 with count 13
	When I get the string from the ValueStringBuilder
	Then the ValueStringBuilder string should be 'Hello, World!'
	Examples:
		| InitializationType |
		| Span               |
		| Capacity           |

Scenario Outline: Shrinks
	Examples:
		| InitializationType |
		| Span               |
		| Capacity           |

Scenario Outline: Changes without length change
	Examples:
		| InitializationType |
		| Span               |
		| Capacity           |

Scenario Outline: Grows but fits in available space
	Examples:
		| InitializationType |
		| Span               |
		| Capacity           |

Scenario Outline: Grows and requires resize
	Examples:
		| InitializationType |
		| Span               |
		| Capacity           |

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
	Given a ValueStringBuilder initialized with '<InitializationType>' of length 13
	And I append 'Hello, World or wherever!' to the ValueStringBuilder
	And I replace '<Find>' with '<Replacement>' at index <Start> with count <Length>
	When I get the string from the ValueStringBuilder
	Then the ValueStringBuilder string should be '<Result>'
	Examples:
		| InitializationType | Find | Replacement | Start | Length | Result                    |
		| Span               | ell  | i           | 0     | 13     | Hio, World or wherever!   |
		| Capacity           | ell  | i           | 0     | 13     | Hio, World or wherever!   |
		| Span               | ell  | i           | 1     | 12     | Hio, World or wherever!   |
		| Capacity           | ell  | i           | 1     | 12     | Hio, World or wherever!   |
		| Span               | ell  | i           | 1     | 3      | Hio, World or wherever!   |
		| Capacity           | ell  | i           | 1     | 3      | Hio, World or wherever!   |
		| Span               | ell  | i           | 1     | 2      | Hello, World or wherever! |
		| Capacity           | ell  | i           | 1     | 2      | Hello, World or wherever! |
		| Span               | ell  | i           | 2     | 11     | Hello, World or wherever! |
		| Capacity           | ell  | i           | 2     | 11     | Hello, World or wherever! |
		| Span               | or   | x           | 2     | 23     | Hello, Wxld x wherever!   |
		| Capacity           | or   | x           | 2     | 23     | Hello, Wxld x wherever!   |
		| Span               | or   | x           | 2     | 10     | Hello, Wxld or wherever!  |
		| Capacity           | or   | x           | 2     | 10     | Hello, Wxld or wherever!  |
		| Span               | or   | x           | 9     | 6      | Hello, World x wherever!  |
		| Capacity           | or   | x           | 9     | 6      | Hello, World x wherever!  |

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


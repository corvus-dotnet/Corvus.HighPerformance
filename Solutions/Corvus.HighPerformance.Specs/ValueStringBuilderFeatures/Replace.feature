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
	Given a ValueStringBuilder initialized with '<InitializationType>' of length 23
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
	Given a ValueStringBuilder initialized with '<InitializationType>' of length 23
	And I append 'Hello, World or wherever!' to the ValueStringBuilder
	And I replace '<Find>' with '<Replacement>' at index <Start> with count <Length>
	When I get the string from the ValueStringBuilder
	Then the ValueStringBuilder string should be '<Result>'
	Examples:
		| InitializationType | Find | Replacement | Start | Length | Result                    |
		| Span               | ell  | ijk         | 0     | 13     | Hijko, World or wherever! |
		| Capacity           | ell  | ijk         | 0     | 13     | Hijko, World or wherever! |
		| Span               | ell  | ijk         | 1     | 12     | Hijko, World or wherever! |
		| Capacity           | ell  | ijk         | 1     | 12     | Hijko, World or wherever! |
		| Span               | ell  | ijk         | 1     | 3      | Hijko, World or wherever! |
		| Capacity           | ell  | ijk         | 1     | 3      | Hijko, World or wherever! |
		| Span               | ell  | ijk         | 1     | 2      | Hello, World or wherever! |
		| Capacity           | ell  | ijk         | 1     | 2      | Hello, World or wherever! |
		| Span               | ell  | ijk         | 2     | 11     | Hello, World or wherever! |
		| Capacity           | ell  | ijk         | 2     | 11     | Hello, World or wherever! |
		| Span               | or   | al          | 2     | 23     | Hello, Walld al wherever! |
		| Capacity           | or   | al          | 2     | 23     | Hello, Walld al wherever! |
		| Span               | or   | al          | 2     | 10     | Hello, Walld or wherever! |
		| Capacity           | or   | al          | 2     | 10     | Hello, Walld or wherever! |
		| Span               | or   | al          | 9     | 6      | Hello, World al wherever! |
		| Capacity           | or   | al          | 9     | 6      | Hello, World al wherever! |

Scenario Outline: Grows but fits in available space
	Given a ValueStringBuilder initialized with '<InitializationType>' of length 25
	And I append 'Hello, World or wherever!' to the ValueStringBuilder
	And I replace '<Find>' with '<Replacement>' at index <Start> with count <Length>
	When I get the string from the ValueStringBuilder
	Then the ValueStringBuilder string should be '<Result>'
	Examples:
		| InitializationType | Find | Replacement | Start | Length | Result                          |
		| Span               | ell  | ijkx        | 0     | 13     | Hijkxo, World or wherever!      |
		| Capacity           | ell  | ijkx        | 0     | 13     | Hijkxo, World or wherever!      |
		| Span               | ell  | ijkx        | 1     | 12     | Hijkxo, World or wherever!      |
		| Capacity           | ell  | ijkx        | 1     | 12     | Hijkxo, World or wherever!      |
		| Span               | ell  | ijkx        | 1     | 3      | Hijkxo, World or wherever!      |
		| Capacity           | ell  | ijkx        | 1     | 3      | Hijkxo, World or wherever!      |
		| Span               | ell  | ijkx        | 1     | 2      | Hello, World or wherever!       |
		| Capacity           | ell  | ijkx        | 1     | 2      | Hello, World or wherever!       |
		| Span               | ell  | ijkx        | 2     | 11     | Hello, World or wherever!       |
		| Capacity           | ell  | ijkx        | 2     | 11     | Hello, World or wherever!       |
		| Span               | or   | alz         | 2     | 23     | Hello, Walzld alz wherever!     |
		| Capacity           | or   | alz         | 2     | 23     | Hello, Walzld alz wherever!     |
		| Span               | or   | alz         | 2     | 10     | Hello, Walzld or wherever!      |
		| Capacity           | or   | alz         | 2     | 10     | Hello, Walzld or wherever!      |
		| Span               | or   | alz         | 9     | 6      | Hello, World alz wherever!      |
		| Capacity           | or   | alz         | 9     | 6      | Hello, World alz wherever!      |
		| Span               | ell  | ijkxwv      | 0     | 13     | Hijkxwvo, World or wherever!    |
		| Capacity           | ell  | ijkxwv      | 0     | 13     | Hijkxwvo, World or wherever!    |
		| Span               | ell  | ijkxwv      | 1     | 12     | Hijkxwvo, World or wherever!    |
		| Capacity           | ell  | ijkxwv      | 1     | 12     | Hijkxwvo, World or wherever!    |
		| Span               | ell  | ijkxwv      | 1     | 3      | Hijkxwvo, World or wherever!    |
		| Capacity           | ell  | ijkxwv      | 1     | 3      | Hijkxwvo, World or wherever!    |
		| Span               | ell  | ijkxwv      | 1     | 2      | Hello, World or wherever!       |
		| Capacity           | ell  | ijkxwv      | 1     | 2      | Hello, World or wherever!       |
		| Span               | ell  | ijkxwv      | 2     | 11     | Hello, World or wherever!       |
		| Capacity           | ell  | ijkxwv      | 2     | 11     | Hello, World or wherever!       |
		| Span               | or   | alzyh       | 2     | 23     | Hello, Walzyhld alzyh wherever! |
		| Capacity           | or   | alzyh       | 2     | 23     | Hello, Walzyhld alzyh wherever! |
		| Span               | or   | alzyh       | 2     | 10     | Hello, Walzyhld or wherever!    |
		| Capacity           | or   | alzyh       | 2     | 10     | Hello, Walzyhld or wherever!    |
		| Span               | or   | alzyh       | 9     | 6      | Hello, World alzyh wherever!    |
		| Capacity           | or   | alzyh       | 9     | 6      | Hello, World alzyh wherever!    |


Scenario Outline: Grows and requires resize
	Given a ValueStringBuilder initialized with '<InitializationType>' of length 32
	And I append 'Hello, World or wherever!padpadp' to the ValueStringBuilder
	And I replace '<Find>' with '<Replacement>' at index <Start> with count <Length>
	When I get the string from the ValueStringBuilder
	Then the ValueStringBuilder string should be '<Result>'
	Examples:
		| InitializationType | Find | Replacement | Start | Length | Result                                   |
		| Span               | ell  | ijkx        | 0     | 13     | Hijkxo, World or wherever!padpadp      |
		| Capacity           | ell  | ijkx        | 0     | 13     | Hijkxo, World or wherever!padpadp      |
		| Span               | ell  | ijkx        | 1     | 12     | Hijkxo, World or wherever!padpadp      |
		| Capacity           | ell  | ijkx        | 1     | 12     | Hijkxo, World or wherever!padpadp      |
		| Span               | ell  | ijkx        | 1     | 3      | Hijkxo, World or wherever!padpadp      |
		| Capacity           | ell  | ijkx        | 1     | 3      | Hijkxo, World or wherever!padpadp      |
		| Span               | ell  | ijkx        | 1     | 2      | Hello, World or wherever!padpadp       |
		| Capacity           | ell  | ijkx        | 1     | 2      | Hello, World or wherever!padpadp       |
		| Span               | ell  | ijkx        | 2     | 11     | Hello, World or wherever!padpadp       |
		| Capacity           | ell  | ijkx        | 2     | 11     | Hello, World or wherever!padpadp       |
		| Span               | or   | alz         | 2     | 23     | Hello, Walzld alz wherever!padpadp     |
		| Capacity           | or   | alz         | 2     | 23     | Hello, Walzld alz wherever!padpadp     |
		| Span               | or   | alz         | 2     | 10     | Hello, Walzld or wherever!padpadp      |
		| Capacity           | or   | alz         | 2     | 10     | Hello, Walzld or wherever!padpadp      |
		| Span               | or   | alz         | 9     | 6      | Hello, World alz wherever!padpadp      |
		| Capacity           | or   | alz         | 9     | 6      | Hello, World alz wherever!padpadp      |
		| Span               | ell  | ijkxwv      | 0     | 13     | Hijkxwvo, World or wherever!padpadp    |
		| Capacity           | ell  | ijkxwv      | 0     | 13     | Hijkxwvo, World or wherever!padpadp    |
		| Span               | ell  | ijkxwv      | 1     | 12     | Hijkxwvo, World or wherever!padpadp    |
		| Capacity           | ell  | ijkxwv      | 1     | 12     | Hijkxwvo, World or wherever!padpadp    |
		| Span               | ell  | ijkxwv      | 1     | 3      | Hijkxwvo, World or wherever!padpadp    |
		| Capacity           | ell  | ijkxwv      | 1     | 3      | Hijkxwvo, World or wherever!padpadp    |
		| Span               | ell  | ijkxwv      | 1     | 2      | Hello, World or wherever!padpadp       |
		| Capacity           | ell  | ijkxwv      | 1     | 2      | Hello, World or wherever!padpadp       |
		| Span               | ell  | ijkxwv      | 2     | 11     | Hello, World or wherever!padpadp       |
		| Capacity           | ell  | ijkxwv      | 2     | 11     | Hello, World or wherever!padpadp       |
		| Span               | or   | alzyh       | 2     | 23     | Hello, Walzyhld alzyh wherever!padpadp |
		| Capacity           | or   | alzyh       | 2     | 23     | Hello, Walzyhld alzyh wherever!padpadp |
		| Span               | or   | alzyh       | 2     | 10     | Hello, Walzyhld or wherever!padpadp    |
		| Capacity           | or   | alzyh       | 2     | 10     | Hello, Walzyhld or wherever!padpadp    |
		| Span               | or   | alzyh       | 9     | 6      | Hello, World alzyh wherever!padpadp    |
		| Capacity           | or   | alzyh       | 9     | 6      | Hello, World alzyh wherever!padpadp    |

# TODO:
# Non-changing Replace calls
# Range check exception
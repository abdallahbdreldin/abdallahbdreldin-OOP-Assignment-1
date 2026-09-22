Critique :

	1) global variables are used in the code,
		which can lead to unexpected behavior and make the code harder to maintain.
		It is generally better to pass variables as parameters to functions or use local variables.

	2) any function can modify the global variables,
	which can lead to side effects and make it difficult to track changes in the code.

	3) The code lacks encapsulation, making it harder to manage and extend in the future.

	4) The code does not follow the principle of single responsibility,
	as functions may be doing multiple tasks, making it harder to understand and test.

	5) related data is not grouped together in classes or structures, which can lead to confusion and make it harder to manage the code.
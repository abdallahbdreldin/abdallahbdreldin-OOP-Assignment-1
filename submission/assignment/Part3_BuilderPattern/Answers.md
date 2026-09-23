1 Why is a single 20-parameter constructor for this class a problem in practice? Think about call-site
readability, the risk of passing two values in the wrong order (e.g. two decimal amounts, or two strings that
are both addresses), and what happens the day someone adds one more optional property.

	- A single 20-parameter constructor can lead to several practical issues:
	-  20-parameter constructor is difficult to read and understand at the call site,
	- making it hard for developers to know what each parameter represents.
	- developers can easily pass arguments in the wrong order, especially if they are of the same type (e.g., two decimal amounts or two strings that are both addresses).
	- if new parameter added , every constructor call needs to be updated.



Is this purely a "constructor is too long" problem, or is there a deeper design issue with putting ~20 loosely
related properties on a single class in the first place?

	- no , the real problem is the class have unrelated properties which violate the Single Responsibility Principle (SRP),
	- making it harder to maintain and understand.



why is this composed version better than the single big builder from Task 3.2?

	- The composed version is better than the single big builder because putting all of them directly into single class violates the Single Responsibility Principle
	- and make the class herder to maintain and understand.	 
	- the composed version sepates the responsiblities of building differnt parts of the invoice (addressbuilder , orderbuilder, paymentbuilder)
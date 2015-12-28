# CreditCardValidator

A C# library that uses Luhn Algorithm for credit card validation.

Usage:

```
            Validator validator = new Validator();
            
	    /// Create a rule with the starting digit(s) and length(s).
            Rule amexRule = new Rule(new int[] { 34, 37 }, new int[] { 15 });
		
            /// Add rule to validator.		
            validator.addRule("AMEX", amexRule);

            long creditCard = 4111111111111111;
	    
	    /// Evaluate if credit card number is valid.
            bool valid = validator.isValid(creditCard);
```
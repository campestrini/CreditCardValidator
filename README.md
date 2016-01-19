# CreditCardValidator

A C# library that uses Luhn Algorithm for credit card validation.

Usage:

Create a validator.
```
Validator validator = new Validator();
```

Create a rule with the starting digit(s) and length(s).
```
Rule amexRule = new Rule(new int[] { 34, 37 }, new int[] { 15 });
```
Add rule to the validator.
```		
validator.addRule("AMEX", amexRule);
```
Evaluate if credit card number is valid.
```
long creditCard = 4111111111111111;
bool valid = validator.isValid(creditCard);
```

Get the credit card flag:
```
string flag = validator.evaluateFlag(creditCard);
```

To be continued...

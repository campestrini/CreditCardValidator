# CreditCardValidator

A C# library that uses Luhn Algorithm for credit card validation.

Usage:

Create a validator.
```
Validator validator = new Validator();
```

Create a rule with the starting digit(s) and length(s).
```
Rule rule = new Rule(new int[] { 34, 37 }, new int[] { 15 });
```
Add rule to the validator.
```		
validator.addRule("AMEX", rule);
```
Evaluate if credit card number is valid.
```
long creditCard = 378282246310005;
bool valid = validator.isValid(creditCard);
/// true
```

Get the credit card flag:
```
string flag = validator.evaluateFlag(creditCard);
/// AMEX
```

Or generate a output message:
```
ValidatorHelper helper = new ValidatorHelper(validator);
string message = helper.buildValidatonMessage(378282246310005)
/// Generates "AMEX: 378282246310005 (valid)."
```

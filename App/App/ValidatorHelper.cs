namespace App
{
    public class ValidatorHelper
    {
        public const string VALID_CREDIT_CARD = "Valid.";
        public const string INVALID_CREDIT_CARD = "Invalid.";

        private Validator _validator;


        public ValidatorHelper(Validator validator)
        {
            this._validator = validator;
        }

        public string buildValidatonMessage(long creditCardNumber)
        {
            string isValid = INVALID_CREDIT_CARD;

            if(_validator.isValid(creditCardNumber))
            {
                isValid = VALID_CREDIT_CARD;
            }

            string flag = _validator.evaluateFlag(creditCardNumber);
            string message = flag + ": " + creditCardNumber.ToString() + " (" + isValid + ").";

            return message;
        }

    }
}
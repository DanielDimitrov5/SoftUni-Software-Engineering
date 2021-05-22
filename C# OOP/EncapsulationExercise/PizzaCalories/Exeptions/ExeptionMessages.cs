namespace PizzaCalories.Exeptions
{
    public static class ExeptionMessages
    {
        public static string invalidTypeOfDoughExeption = "Invalid type of dough.";

        public static string doughtWeightExeption = "Dough weight should be in the range[{0}..{1}].";

        public static string invalidTypeOfToppingExeption = "Cannot place {0} on top of your pizza.";

        public static string invalidWeightExeption = "{0} weight should be in the range [{1}..{2}].";

        public static string invalidNameExeption = "Pizza name should be between 1 and 15 symbols.";

        public static string invalidNumberOfToppingsExeption = "Number of toppings should be in range [0..10].";
    }
}

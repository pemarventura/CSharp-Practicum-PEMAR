using Application.Interfaces;
using System;
using System.Runtime.CompilerServices;
using System.Text;


namespace Application.Entities
{
    public class DishManager : IDishManager
    {
        private readonly Dish _dish;
        public DishManager(Dish dish) 
        {
            _dish = dish;
        }

        private Dictionary<string, int?> AcceptsMoreThanOneOccurrence = new Dictionary<string, int?>
        {
            { "potato", null } // Null means unlimited occurrences
        };

        private Dictionary<string, string> DishesByValue = new Dictionary<string, string>
        {
            { "1", "steak" },
            { "2", "potato" },
            { "3", "wine" },
            { "4", "cake" }
        };

        public string GetDishes(string unformatedString)
        {
            //Validates the string format
            string formattedString = _dish.ValidateAndTrimDishesStringFormat(unformatedString);

            //Validates the data received with the instance data
            List<string> splitedString = ValidateSplitAndSortDishesString(formattedString); 

            //Creates the dishes objects already formatting to a string
            return CreateDishesAndReturnToString(splitedString);

        }

        private List<string> ValidateSplitAndSortDishesString(string unsplitedAndUnsortedString)
        {
            List<string> splitString = unsplitedAndUnsortedString.Split(',').ToList();

            //Verify if the number of dishes informed is greater than the possible number of dishes to ask
            if (splitString.Count > DishesByValue.Count())
            {
                throw new ArgumentException("error");
            }

            // Verify if the informed dishes are presented in the possible dishes to be asked
            else if (splitString.Any(a => !DishesByValue.Keys.Any(key => key.Equals(a))))
            {
                throw new ArgumentException("error");
            }

            //Compare the dishes informed and its number of occurrences
            else if (!EvaluateDishNumberOccurrences(splitString)) 
            {
                throw new ArgumentException("error");
            }

            return splitString;
        }

        private bool EvaluateDishNumberOccurrences(List<string> dishes) 
        {
            // Check for dishes that can appear more than once and their occurrence limit
            foreach (var dish in dishes.GroupBy(x => x))
            {
                string dishName = DishesByValue[dish.Key];

                // If the dish accepts more than one occurrence and there's a limit
                if (AcceptsMoreThanOneOccurrence.ContainsKey(dishName))
                {
                    int? maxAllowed = AcceptsMoreThanOneOccurrence[dishName];

                    if (maxAllowed.HasValue && dish.Count() > maxAllowed.Value)
                    {
                        return false;
                    }
                }
                // If a dish that does not accept multiple occurrences appears more than once
                else if (dish.Count() > 1)
                {
                    return false;
                }
            }

            return true;
        }

        private string CreateDishesAndReturnToString(List<string> dishesToCreate)
        {
            var resultBuilder = new StringBuilder();

            // Group dishes, count occurrences, and order by the integer representation
            var dishCounts = dishesToCreate.GroupBy(d => d)
                                            .OrderBy(g => int.Parse(g.Key)) // Order by the integer value
                                            .ToDictionary(g => g.Key, g => g.Count());

            foreach (var dish in dishCounts)
            {
                // Append a comma before the next dish if the resultBuilder already has content
                if (resultBuilder.Length > 0)
                {
                    resultBuilder.Append(", ");
                }

                // Generate the dish string and add it to the result
                resultBuilder.Append(_dish.GenerateDishAndConvertToString(DishesByValue[dish.Key], dish.Value));
            }

            return resultBuilder.ToString();
        }

    }
}

using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Entities
{
    public class Dish : IDish
    {
        public string DishName { get; private set; }
        public int Count { get; private set; }

        public Dish(string dishName = "", int count = 0) 
        {
            this.DishName = dishName;
            this.Count = count; 
        }

        public string ValidateAndTrimDishesStringFormat(string unparsedOrder)
        {
            // Check if the string is empty or only made up of whitespace
            if (string.IsNullOrWhiteSpace(unparsedOrder))
            {
                throw new ArgumentException("error");
            }

            // Regex to match valid patterns (numbers separated by commas, with optional spaces)
            // \s* allows for zero or more spaces, \d+ matches one or more digits, and (,\s*\d+)* matches commas followed by digits with optional spaces
            string pattern = @"^\s*\d+(\s*,\s*\d+)*\s*$";

            // Check if the unparsedOrder matches the pattern
            if (!Regex.IsMatch(unparsedOrder, pattern))
            {
                throw new ArgumentException("error");
            }

            // Remove all spaces from the string
            string cleanedOrder = unparsedOrder.Replace(" ", "");

            return cleanedOrder;
        }

        public string GenerateDishAndConvertToString(string dishName, int dishCount)
        {
            if (string.IsNullOrWhiteSpace(dishName) || dishCount <= 0) 
            {
                throw new ArgumentException("error");
            }

            return new Dish(dishName, dishCount).ToString();
        }

        public override string ToString()
        {
            if (this.Count > 1)
            {
                return $"{this.DishName}(x{this.Count})"; 
            }

            return $"{this.DishName}";
        }
    }
}

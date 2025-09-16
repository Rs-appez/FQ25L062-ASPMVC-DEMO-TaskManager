using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.RegularExpressions;

namespace TaskManager.ASPMVC.Helpers
{
    public static class CustomValidators
    {
        public static void CheckIfNumbers(this ModelStateDictionary modelState, string? value, string fieldName)
        {
            CheckIfNumbers(modelState, value, fieldName, "Le texte ne contient pas de chiffres.");
        }

        public static void CheckIfNumbers(this ModelStateDictionary modelState, string? value, string fieldName, string message)
        {
            if (value is null) return;
            if (Regex.IsMatch(value, "[0-9]+")) return;
            modelState.AddModelError(fieldName, message);
        }

        public static void CheckIfLowerChar(this ModelStateDictionary modelState, string? value, string fieldName)
        {
            CheckIfLowerChar(modelState, value, fieldName, "Le texte ne contient pas de minuscule.");
        }

        public static void CheckIfLowerChar(this ModelStateDictionary modelState, string? value, string fieldName, string message)
        {
            if (value is null) return;
            if (Regex.IsMatch(value, "[a-z]+")) return;
            modelState.AddModelError(fieldName, message);
        }


        public static void CheckIfUpperChar(this ModelStateDictionary modelState, string? value, string fieldName)
        {
            CheckIfUpperChar(modelState, value, fieldName, "Le texte ne contient pas de majuscule.");
        }

        public static void CheckIfUpperChar(this ModelStateDictionary modelState, string? value, string fieldName, string message)
        {
            if (value is null) return;
            if (Regex.IsMatch(value, "[A-Z]+")) return;
            modelState.AddModelError(fieldName, message);
        }

        public static void CheckIfSymbolChar(this ModelStateDictionary modelState, string? value, string fieldName)
        {
            CheckIfSymbolChar(modelState, value, fieldName, "Le texte ne contient pas de symbole.");
        }

        public static void CheckIfSymbolChar(this ModelStateDictionary modelState, string? value, string fieldName, string message)
        {
            if (value is null) return;
            if (Regex.IsMatch(value, "[-=+/.//$@#%]+")) return;
            modelState.AddModelError(fieldName, message);
        }
    }
}

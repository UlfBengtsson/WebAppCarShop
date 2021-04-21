using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCarShop.Models.Util
{
    public class DoubleBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var modelName = bindingContext.ModelName;

            // Try to fetch the value of the argument by name
            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

            if (valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

            string value = valueProviderResult.FirstValue;

            // Check if the argument value is null or empty
            if (string.IsNullOrEmpty(value))
            {
                return Task.CompletedTask;

            }

            double number = 0;

            try
            {
                number = Convert.ToDouble(value.Replace('.', ','));
                bindingContext.Result = ModelBindingResult.Success(number);
            }
            catch (FormatException)
            {
                bindingContext.ModelState.TryAddModelError(
                    modelName, "needs to be a decimal number.");
            }
            catch (OverflowException)
            {
                bindingContext.ModelState.TryAddModelError(
                    modelName, "decimal number was too big.");
            }

            return Task.CompletedTask;
        }
    }
}

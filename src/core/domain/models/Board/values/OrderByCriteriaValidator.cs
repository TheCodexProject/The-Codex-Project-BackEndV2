﻿using domain.exceptions.common;
using domain.exceptions.models.board.orderbycriteria;
using OperationResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.models.board.values;

public static class OrderByCriteriaValidator
{
    /// <summary>
    /// Helper method to validate the PropertyName of OrderByCriteria.
    /// </summary>
    /// <param name="propertyName">The property name to be validated.</param>
    /// <returns>A <see cref="Result"/> indicating if the property name is valid or not.</returns>
    public static Result ValidatePropertyName(string propertyName)
    {
        // ? Is the property name null or empty?
        if (string.IsNullOrWhiteSpace(propertyName))
        {
            return Result.Failure(new NotFoundException("The provided property is invalid. Property cannot be empty."));
        }

        // ? Is the property name too long?
        if (propertyName.Length > 75)
        {
            return Result.Failure(new OrderByCriteriaPropertyNameTooLongException());
        }

        // Additional checks can be added here as needed

        return Result.Success();
    }

    /// <summary>
    /// Helper method to validate the IsAscending field of OrderByCriteria.
    /// </summary>
    /// <param name="isAscending">The IsAscending value to be validated.</param>
    /// <returns>A <see cref="Result"/> indicating if the IsAscending value is valid or not.</returns>
    public static Result ValidateIsAscending(bool isAscending)
    {
        // Since IsAscending is a boolean, it does not need special validation. Always return success.
        return Result.Success();
    }
}

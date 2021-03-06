﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using MoreLinq;

namespace MineCalc.Model
{
    public class Recipe : IRecipe, IEquatable<Recipe>
    {
        public Recipe(
            ItemStack result,
            IEnumerable<ItemStack> ingredients,
            IEnumerable<ItemType> equipment)
        {
            Result = result;
            Ingredients = ingredients.ToImmutableList();
            Equipment = equipment?.ToImmutableList() ?? ImmutableList.Create<ItemType>();
        }

        public ItemStack Result { get; }

        public ImmutableList<ItemStack> Ingredients { get; }

        public ImmutableList<ItemType> Equipment { get; }

        public override string ToString() =>
            $"{Result} ({Ingredients.ToDelimitedString(", ")}) [{Equipment.ToDelimitedString(", ")}]";

        #region Equality
        public bool Equals(Recipe other) =>
            !Equals(other, null)
            && Result.Equals(other.Result)
            && Ingredients.IsEqualSet(other.Ingredients);

        public override bool Equals(object obj) =>
            Equals(obj as Recipe);

        public override int GetHashCode() =>
            Result.GetHashCode();

        public static bool operator ==(Recipe a, Recipe b) =>
            Equals(a, null)
                ? Equals(b, null)
                : a.Equals(b);

        public static bool operator !=(Recipe a, Recipe b) =>
            !(a == b);

        #endregion
    }
}

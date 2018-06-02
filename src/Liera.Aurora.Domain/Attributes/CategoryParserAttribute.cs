using System;

namespace Liera.Aurora.Domain.Attributes
{
    /// <summary>
    /// Indicates that a method is a Aurora category parsing method
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class CategoryParserMethodAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of CategoryParserMethodAttribute using the given
        /// category as target
        /// </summary>
        /// <param name="targetCategory"></param>
        public CategoryParserMethodAttribute(Enumerators.Category targetCategory)
        {
            TargetCategory = targetCategory;
        }

        /// <summary>
        /// The target category for the category parsing method
        /// </summary>
        public Enumerators.Category TargetCategory { get; private set; }
    }
}

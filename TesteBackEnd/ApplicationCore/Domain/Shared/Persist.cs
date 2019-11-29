using System;
using FluentValidation;

namespace ApplicationCore.Domain.Shared
{
    /// <summary>
    ///     Persist object
    /// </summary>
    /// <typeparam name="T">Type class</typeparam>
    /// <typeparam name="TKey">Type key</typeparam>
    public abstract class Persist<T, TKey> : ICreatedAndUpdatedProperty where T : class
    {
        public Persist()
        {
            Validator = new InlineValidator<T>();
        }

        protected InlineValidator<T> Validator { get; }

        /// <summary>
        ///     Get or set id
        /// </summary>
        public TKey Id { get; set; }

        /// <summary>
        ///     Get or set created date
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        ///     Get or set updated date
        /// </summary>
        public DateTime Updated { get; set; }

        /// <summary>
        ///     Is new object
        /// </summary>
        /// <returns></returns>
        public bool IsNew()
        {
            var id = Convert.ChangeType(Id, TypeCode.Int64);
            return id == null || (long) id <= 0;
        }

        /// <summary>
        ///     Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var compare = obj as T;

            if (compare == null) return false;

            return GetHashCode() == compare.GetHashCode();
        }

        /// <summary>
        ///     GetHashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return 29 * Id.GetHashCode();
            }
        }

        public void Validate()
        {
            Validator.ValidateAndThrow(ConfigureValidation());
        }

        protected abstract T ConfigureValidation();
    }
}
﻿using System;

namespace ApplicationCore.Domain.Shared
{
    /// <summary>
    ///     Created and updated property
    /// </summary>
    public interface ICreatedAndUpdatedProperty
    {
        /// <summary>
        ///     Get or set created date
        /// </summary>
        DateTime Created { get; set; }

        /// <summary>
        ///     Get or set updated date
        /// </summary>
        DateTime Updated { get; set; }
    }
}
// <copyright file="InjectAttribute.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>

namespace functiondi
{
    using System;
    using Microsoft.Azure.WebJobs.Description;

    /// <summary>
    /// Injection Attribute for Function
    /// </summary>
    [Binding]
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public class InjectAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InjectAttribute"/> class.
        /// </summary>
        /// <param name="type">Type to be injected</param>
        public InjectAttribute(Type type)
        {
            this.Type = type;
        }

        /// <summary>
        /// Gets injection Type
        /// </summary>
        public Type Type { get; }
    }
}
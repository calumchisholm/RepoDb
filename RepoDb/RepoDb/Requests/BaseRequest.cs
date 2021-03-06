﻿using RepoDb.Interfaces;
using System;
using System.Data;

namespace RepoDb.Requests
{
    /// <summary>
    /// A base class for all operational request.
    /// </summary>
    internal abstract class BaseRequest
    {
        /// <summary>
        /// Creates a new instance of <see cref="BaseRequest"/> object.
        /// </summary>
        /// <param name="name">The name of request.</param>
        /// <param name="connection">The connection object.</param>
        /// <param name="statementBuilder">The statement builder.</param>
        public BaseRequest(string name,
            IDbConnection connection,
            IStatementBuilder statementBuilder = null)
        {
            Name = name;
            Connection = connection;
            StatementBuilder = statementBuilder;
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        public Type Type { get; internal set; }

        /// <summary>
        /// Hash value based upon the type's name. Lazily generated by getter.
        /// </summary>
        private Int32? _typeNameHashCode = null;

        /// <summary>
        /// Get the hash code associated with the type's name and store it for future use.
        /// </summary>
        public int TypeNameHashCode
        {
            get
            {
                if (_typeNameHashCode.HasValue == false)
                {
                    _typeNameHashCode = Name.GetHashCode();
                }

                return _typeNameHashCode.Value;
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the connection object.
        /// </summary>
        public IDbConnection Connection { get; }

        /// <summary>
        /// Gets the statement builder.
        /// </summary>
        public IStatementBuilder StatementBuilder { get; }
    }
}

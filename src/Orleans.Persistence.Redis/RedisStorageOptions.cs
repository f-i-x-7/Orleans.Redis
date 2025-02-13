﻿using System;
using Newtonsoft.Json;
using Orleans.Serialization;

namespace Orleans.Persistence
{
    /// <summary>
    /// Redis grain storage options.
    /// </summary>
    public class RedisStorageOptions
    {
        /// <summary>
        /// The connection string.
        /// </summary>
        [Obsolete("Use ConnectionString")]
        public string DataConnectionString { get => this.ConnectionString; set => this.ConnectionString = value; }

        /// <summary>
        /// The connection string.
        /// </summary>
        public string ConnectionString { get; set; } = "localhost:6379";

        /// <summary>
        /// Whether or not to use JSON for serialization.
        /// </summary>
        public bool UseJson { get; set; } = true;

        /// <summary>
        /// Whether or not to delete state during a clear operation.
        /// </summary>
        public bool DeleteOnClear { get; set; }

        /// <summary>
        /// The database number.
        /// </summary>
        public int? DatabaseNumber { get; set; }

        /// <summary>
        /// Stage of silo lifecycle where storage should be initialized.  Storage must be initialized prior to use.
        /// </summary>
        public int InitStage { get; set; } = ServiceLifecycleStage.ApplicationServices;

        /// <summary>
        /// If <see cref="UseJson"/> is set to <see langword="true" /> this action can add additional configuration to the <see cref="JsonSerializerSettings"/>.
        /// This can be used to inject custom JSON converters if required by custom grain states.
        /// </summary>
        /// <remarks>The settings from <see cref="OrleansJsonSerializer"/> are used by default.</remarks>
        public Action<JsonSerializerSettings> ConfigureJsonSerializerSettings { get; set; }
    }
}
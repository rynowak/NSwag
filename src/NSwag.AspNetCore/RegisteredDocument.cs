﻿//-----------------------------------------------------------------------
// <copyright file="RegisteredDocument.cs" company="NSwag">
//     Copyright (c) Rico Suter. All rights reserved.
// </copyright>
// <license>https://github.com/NSwag/NSwag/blob/master/LICENSE.md</license>
// <author>Rico Suter, mail@rsuter.com</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using NSwag.SwaggerGeneration;
using NSwag.SwaggerGeneration.AspNetCore;
using NSwag.SwaggerGeneration.WebApi;

namespace NSwag.AspNetCore
{
    // Captures the state required to produce a document. Mediates between two supported
    // document generators.
    internal class RegisteredDocument
    {
        public static RegisteredDocument CreateAspNetCoreGeneratorDocument(
            AspNetCoreToSwaggerGeneratorSettings settings,
            SwaggerJsonSchemaGenerator schemaGenerator,
            Action<SwaggerDocument> postProcess)
        {
            return new RegisteredDocument()
            {
                PostProcess = postProcess,
                SchemaGenerator = schemaGenerator,
                Settings = settings,
            };
        }

        public static RegisteredDocument CreateWebApiGeneratorDocument(
            WebApiToSwaggerGeneratorSettings settings,
            IEnumerable<Type> controllerTypes,
            SwaggerJsonSchemaGenerator schemaGenerator,
            Action<SwaggerDocument> postProcess)
        {
            return new RegisteredDocument()
            {
                ControllerTypes = controllerTypes,
                PostProcess = postProcess,
                SchemaGenerator = schemaGenerator,
                Settings = settings,
            };
        }

        private RegisteredDocument()
        {
        }

        public IEnumerable<Type> ControllerTypes { get; private set; }

        public Action<SwaggerDocument> PostProcess { get; private set; }

        public SwaggerJsonSchemaGenerator SchemaGenerator { get; private set; }

        public SwaggerGeneratorSettings Settings { get; private set; }
    }
}

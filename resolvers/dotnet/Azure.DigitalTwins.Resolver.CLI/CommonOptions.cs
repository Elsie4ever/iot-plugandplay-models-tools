﻿using System.CommandLine;
using System.Text.Json;

namespace Azure.DigitalTwins.Resolver.CLI
{
    class CommonOptions
    {
        private const string _defaultRepository = "https://devicemodeltest.azureedge.net/";

        public static Option<string> Dtmi
        {
            get
            {
                return new Option<string>(
                "--dtmi",
                description: "Digital Twin Model Identifier. Example: dtmi:com:example:Thermostat;1")
                {
                    Argument = new Argument<string>
                    {
                        Arity = ArgumentArity.ExactlyOne,
                    },
                    IsRequired = true
                };
            }
        }

        public static Option<string> Repo
        {
            get
            {
                return new Option<string>(
                  "--repository",
                  description: "Model Repository location. Can be remote endpoint or local directory.",
                  getDefaultValue: () => _defaultRepository
                  );
            }
        }

        public static Option<string> Output
        {
            get
            {
                return new Option<string>(
                    new string[] { "--output", "-o" },
                    description: "Desired file path to write result contents.",
                    getDefaultValue: () => null
                    );
            }
        }

        public static JsonDocumentOptions DefaultJsonParseOptions
        {
            get
            {
                return new JsonDocumentOptions
                {
                    AllowTrailingCommas = true,

                };
            }
        }

        public static JsonSerializerOptions DefaultJsonSerializerOptions
        {
            get
            {
                return new JsonSerializerOptions
                {
                    AllowTrailingCommas = true,
                    WriteIndented = true,
                };
            }
        }
    }
}

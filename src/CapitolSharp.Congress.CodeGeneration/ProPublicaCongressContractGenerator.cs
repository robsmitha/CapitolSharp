using CapitolSharp.Congress.CodeGeneration.Customization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Newtonsoft.Json.Serialization;
using NJsonSchema;
using NJsonSchema.CodeGeneration.CSharp;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace CapitolSharp.CodeGeneration
{
    [Generator]
    public class ProPublicaCongressContractGenerator : IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext initContext)
        {
            IncrementalValuesProvider<AdditionalText> jsonFiles = initContext.AdditionalTextsProvider.Where(static file => file.Path.EndsWith(".json"));

            IncrementalValuesProvider<(string name, string @namespace, string content)> namesAndContents = jsonFiles.Select((file, cancellationToken) 
                => (name: Path.GetFileNameWithoutExtension(file.Path),
                @namespace: new DirectoryInfo(file.Path.Replace("\\\\", "\\")).Parent.Parent.Name, 
                content: file.GetText(cancellationToken)!.ToString()));
            
            initContext.RegisterSourceOutput(namesAndContents, (spc, args) =>
            {
                try
                {
                    var schema = JsonSchema.FromSampleJson(args.content);
                    var contractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    };
                    var generator = new CSharpGenerator(schema, new CSharpGeneratorSettings
                    {
                        Namespace = $"CapitolSharp.Congress.{args.@namespace}.{args.name}",
                        RequiredPropertiesMustBeDefined = true,
                        GenerateOptionalPropertiesAsNullable = true,
                        PropertyNameGenerator = new PascalCasePropertyNameGenerator()
                    });

                    var dto = generator.GenerateFile($"{args.name}Response");
                    spc.AddSource($"{args.name}Contract.g.cs", SourceText.From(dto, Encoding.UTF8));
                }
                catch (Exception e)
                {
                    var sb = new StringBuilder();
                    sb.AppendLine("/*");
                    sb.AppendLine(e.Message);
                    sb.AppendLine(e.StackTrace);
                    sb.AppendLine(e.InnerException?.Message);
                    sb.AppendLine(e.InnerException?.StackTrace);
                    sb.AppendLine("*/");
                    spc.AddSource($"{args.name}.g.cs", SourceText.From(sb.ToString(), Encoding.UTF8));
                }
            });
        }
    }
}

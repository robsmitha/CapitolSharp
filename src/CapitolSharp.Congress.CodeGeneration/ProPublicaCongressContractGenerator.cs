using CapitolSharp.Congress.CodeGeneration.Customization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using NJsonSchema;
using NJsonSchema.CodeGeneration.CSharp;
using System;
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

                    var generator = new CSharpGenerator(schema, new CSharpGeneratorSettings
                    {
                        Namespace = $"CapitolSharp.Congress.{args.@namespace}.{args.name}",
                        RequiredPropertiesMustBeDefined = true,
                        GenerateOptionalPropertiesAsNullable = true,
                        PropertyNameGenerator = new PascalCasePropertyNameGenerator()
                    });

                    var fileText = generator.GenerateFile($"{args.name}Response");
                    spc.AddSource($"{args.name}Contract.g.cs", SourceText.From(fileText, Encoding.UTF8));
                }
                catch (Exception e)
                {
                    var sb = new StringBuilder();
                    sb.AppendLine(e.Message);
                    sb.AppendLine(e.StackTrace);
                    spc.ReportDiagnostic(Diagnostic.Create(
                                new DiagnosticDescriptor(
                                    "CAPITOL0001",
                                    $"Unexpected error generating {args.name} contract",
                                    sb.ToString(),
                                    nameof(ProPublicaCongressContractGenerator),
                                    DiagnosticSeverity.Error,
                                    isEnabledByDefault: true),
                                Location.None));
                }
            });
        }
    }
}

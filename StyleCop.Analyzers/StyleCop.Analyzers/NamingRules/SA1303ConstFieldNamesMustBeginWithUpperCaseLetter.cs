﻿namespace StyleCop.Analyzers.NamingRules
{
    using System.Collections.Immutable;
    using System.Linq;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.Diagnostics;
    using StyleCop.Analyzers.Helpers;

    /// <summary>
    /// The name of a constant C# field must begin with an upper-case letter.
    /// </summary>
    /// <remarks>
    /// <para>A violation of this rule occurs when the name of a field marked with the <c>const</c> attribute does not
    /// begin with an upper-case letter.</para>
    ///
    /// <para>If the field or variable name is intended to match the name of an item associated with Win32 or COM, and
    /// thus needs to begin with a lower-case letter, place the field or variable within a special <c>NativeMethods</c>
    /// class. A <c>NativeMethods</c> class is any class which contains a name ending in <c>NativeMethods</c>, and is
    /// intended as a placeholder for Win32 or COM wrappers. StyleCop will ignore this violation if the item is placed
    /// within a <c>NativeMethods</c> class.</para>
    /// </remarks>
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class SA1303ConstFieldNamesMustBeginWithUpperCaseLetter : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "SA1303";
        internal const string Title = "Const field names must begin with upper-case letter";
        internal const string MessageFormat = "Const field names must begin with upper-case letter.";
        internal const string Category = "StyleCop.CSharp.NamingRules";
        internal const string Description = "The name of a constant C# field must begin with an upper-case letter.";
        internal const string HelpLink = "http://www.stylecop.com/docs/SA1303.html";

        private static readonly DiagnosticDescriptor Descriptor =
            new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Warning, true, Description, HelpLink);

        private static readonly ImmutableArray<DiagnosticDescriptor> _supportedDiagnostics =
            ImmutableArray.Create(Descriptor);

        /// <inheritdoc/>
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics
        {
            get
            {
                return _supportedDiagnostics;
            }
        }

        /// <inheritdoc/>
        public override void Initialize(AnalysisContext context)
        {
            context.RegisterSymbolAction(HandleFieldDeclaration , SymbolKind.Field);
        }

        private void HandleFieldDeclaration(SymbolAnalysisContext context)
        {
            var symbol = context.Symbol as IFieldSymbol;

            if (symbol == null || !symbol.IsConst)
            {
                return;
            }

            if(NamedTypeHelpers.IsContainedInNativeMethodsClass(symbol.ContainingType))
            {
                return;
            }

            // This code uses char.IsLower(...) instead of !char.IsUpper(...) for all of the following reasons:
            //  1. Fields starting with `_` should be reported as SA1309 instead of this diagnostic
            //  2. Foreign languages may not have upper case variants for certain characters
            //  3. This diagnostic appears targeted for "English" identifiers.
            //
            // See DotNetAnalyzers/StyleCopAnalyzers#369 for additional information:
            // https://github.com/DotNetAnalyzers/StyleCopAnalyzers/issues/369
            if (!string.IsNullOrEmpty(symbol.Name) &&
                char.IsLower(symbol.Name[0]) &&
                symbol.Locations.Any())
            {
                context.ReportDiagnostic(Diagnostic.Create(Descriptor, symbol.Locations[0]));
            }
        }
    }
}

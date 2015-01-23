﻿namespace StyleCop.Analyzers.DocumentationRules
{
    using System.Collections.Immutable;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.Diagnostics;

    /// <summary>
    /// A C# code file is missing a standard file header.
    /// </summary>
    /// <remarks>
    /// <para>A violation of this rule occurs when a C# source file is missing a file header. The file header must begin
    /// on the first line of the file, and must be formatted as a block of comments containing XML, as follows:</para>
    ///
    /// <code language="csharp">
    /// //-----------------------------------------------------------------------
    /// // &lt;copyright file="NameOfFile.cs" company="CompanyName"&gt;
    /// //     Company copyright tag.
    /// // &lt;/copyright&gt;
    /// //-----------------------------------------------------------------------
    /// </code>
    ///
    /// <para>For example, a file called Widget.cs from a fictional company called Sprocket Enterprises should contain a
    /// file header similar to the following:</para>
    ///
    /// <code language="csharp">
    /// //-----------------------------------------------------------------------
    /// // &lt;copyright file="Widget.cs" company="Sprocket Enterprises"&gt;
    /// //     Copyright (c) Sprocket Enterprises. All rights reserved.
    /// // &lt;/copyright&gt;
    /// //-----------------------------------------------------------------------
    /// </code>
    ///
    /// <para>The dashed lines at the top and bottom of the header are not strictly necessary, so the header could be
    /// written as:</para>
    ///
    /// <code language="csharp">
    /// // &lt;copyright file="Widget.cs" company="Sprocket Enterprises"&gt;
    /// //     Copyright (c) Sprocket Enterprises. All rights reserved.
    /// // &lt;/copyright&gt;
    /// </code>
    ///
    /// <para>It is possible to add additional tags, although they will not be checked or enforced by StyleCop:</para>
    ///
    /// <code language="csharp">
    /// //-----------------------------------------------------------------------
    /// // &lt;copyright file="Widget.cs" company="Sprocket Enterprises"&gt;
    /// //     Copyright (c) Sprocket Enterprises. All rights reserved.
    /// // &lt;/copyright&gt;
    /// // &lt;author&gt;John Doe&lt;/author&gt;
    /// //-----------------------------------------------------------------------
    /// </code>
    ///
    /// <para>A file that is completely auto-generated by a tool, and which should not be checked or enforced by
    /// StyleCop, can include an "auto-generated" header rather than the standard file header. This will cause StyleCop
    /// to ignore the file. This type of header should never be placed on top of a manually written code file.</para>
    ///
    /// <code language="csharp">
    /// // &lt;auto-generated /&gt;
    /// namespace Sample.Something
    /// {
    ///     // The contents of this file are completely auto-generated by a tool.
    /// }
    /// </code>
    /// </remarks>
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class SA1633FileMustHaveHeader : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "SA1633";
        internal const string Title = "File must have header";
        internal const string MessageFormat = "TODO: Message format";
        internal const string Category = "StyleCop.CSharp.DocumentationRules";
        internal const string Description = "A C# code file is missing a standard file header.";
        internal const string HelpLink = "http://www.stylecop.com/docs/SA1633.html";

        private static readonly DiagnosticDescriptor Descriptor =
            new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Warning, AnalyzerConstants.DisabledNoTests, Description, HelpLink);

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
            // TODO: Implement analysis
        }
    }
}

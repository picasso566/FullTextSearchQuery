﻿// Copyright (c) 2019-2021 Jonathan Wood (www.softcircuits.com)
// Licensed under the MIT license.
//
using System.Collections.Generic;
using System.Diagnostics;

namespace SoftCircuits.FullTextSearchQuery
{
    /// <summary>
    /// Terminal (leaf) expression node class.
    /// </summary>
    internal class TerminalNode : INode
    {
        // Interface members
        public bool Exclude { get; set; }
        public bool Grouped { get; set; }

        // Class members
        public string? Term { get; set; }
        public TermForm TermForm { get; set; }

        private static readonly Dictionary<TermForm, string> TermFormatLookup = new Dictionary<TermForm, string>
        {
            [TermForm.ForcedInflectional] = "{0}FORMSOF(INFLECTIONAL, {1})",
            [TermForm.Inflectional] = "{0}FORMSOF(INFLECTIONAL, {1})",
            [TermForm.Thesaurus] = "{0}FORMSOF(THESAURUS, {1})",
            [TermForm.Literal] = "{0}\"{1}\"",
        };

        // Convert node to string
        public override string ToString()
        {
            if (TermFormatLookup.TryGetValue(TermForm, out string? format))
                return string.Format(format, Exclude ? "NOT " : string.Empty, Term);
            Debug.Assert(false);
            return string.Empty;
        }
    }
}

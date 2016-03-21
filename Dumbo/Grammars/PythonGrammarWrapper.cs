using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dumbo.Grammars
{
    class PythonGrammarWrapper : BaseGrammarWrapper
    {
        public PythonGrammarWrapper() : base()
        {
            Context = "language python";
        }

        public override void InitCommands()
        {
            Commands = new List<string> {
                "if",
                "else",
                "enumerate",
                "return",
                "range",
                "none",
                "class",
                "func",
                "dir",
                "is",
                "as",
                "global",
                "import",
                "break",
                "continue",
                "yield",
                "with",
                "while",
                "try",
                "except",
                "finally",
                "raise",
                "print",
                "pass",
                "for",
                "from",
                "and",
                "assert",
                "in",
                "async",
                "await"
            };
        }
    }
}

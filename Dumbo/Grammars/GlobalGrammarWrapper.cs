using System;
using System.Collections.Generic;
using System.Speech.Recognition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dumbo.Grammars
{
    class GlobalGrammarWrapper : BaseGrammarWrapper
    {

        public GlobalGrammarWrapper() : base()
        {

        }

        public override void InitCommands()
        {
            Commands = new List<string>{ "until", 
                "alpha", "bravo", "charlie", "delta", "echo", "foxtrot", "golf", "hotel", "india", "juliet",
                "kilo", "lima","mike", "november", "oscar", "papa", "quebec", "romeo", "sierra", "tango", "uniform",
                "victor", "whiskey", "x-ray", "yankee", "zulu", "north", "east", "south", "west",
                "new set", "new list", "new function", "new class", "new dictionary", "otherwise", "par", "brace", "bracket",
                "late", "rye", "lace", "race", "lack", "rack",
                "dash", "eke", "plus", "bar", "star", "lang", "rang", "semicolon", "colon", "wave", "comma", "space", "percent",
                "single", "double"};
        }

        public override void InitNumberedCommands()
        {
            NumberedCommands = new List<string> { "delete", "copy", "grab", "select", "left", "right", "down", "up", "number", "next", "back", "line", "job",
                                                   };
        }

        public override void InitDictationCommands()
        {
            DictationCommands = new List<string> { "camel", "score", "dictate", "title", "word" };
        }

    }
}

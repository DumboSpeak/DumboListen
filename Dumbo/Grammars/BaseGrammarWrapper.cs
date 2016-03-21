using System;
using System.Collections.Generic;
using System.Speech.Recognition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dumbo.Grammars
{
    class BaseGrammarWrapper
    {
        public List<string> Commands { get; set; }
        public List<string> NumberedCommands { get; set; }
        public List<string> DictationCommands { get; set; }
        public string Context { get; set; }
        public List<Grammar> Grammars { get; set; }
         
        public BaseGrammarWrapper()
        {
            Grammars = new List<Grammar>();
            InitCommands();
            InitNumberedCommands();
            InitDictationCommands();
            if (Commands.Count == 0) return;
            Choices choices = new Choices(Commands.ToArray());
            GrammarBuilder gb = new GrammarBuilder(choices, 1, 99);
            Grammar grammar = new Grammar(gb);
            Grammars.Add(grammar);
        }

        public virtual void InitCommands() { Commands = new List<string>(); }
        public virtual void InitNumberedCommands() { NumberedCommands = new List<string>(); }
        public virtual void InitDictationCommands() { DictationCommands = new List<string>(); }


    }
}

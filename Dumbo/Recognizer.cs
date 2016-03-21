using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Speech.Recognition;
using Dumbo.Grammars;
using System.Threading;
using System.Text;
using System.Threading.Tasks;

namespace Dumbo
{
    class Recognizer
    {
        public List<string> AllCommands;
        Choices ChoicesPool;
        Choices NumberedChoices;
        public SpeechRecognitionEngine Engine;

        public Recognizer()
        {
            ChoicesPool = new Choices();
            NumberedChoices = new Choices();
            Engine = new SpeechRecognitionEngine();
            AllCommands = new List<string>();
            Engine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);
           // Engine.AudioSignalProblemOccurred += new EventHandler<AudioSignalProblemOccurredEventArgs>(recognizer_AudioSignalProblemOccurred);
            Engine.SetInputToDefaultAudioDevice();
            LoadCommands(new GlobalGrammarWrapper());
            LoadCommands(new PythonGrammarWrapper());
            BuildGrammar();
            Engine.RecognizeAsync(RecognizeMode.Multiple);
        }

        void LoadCommands(BaseGrammarWrapper wrapper)
        {
            AllCommands.AddRange(wrapper.Commands);
            if (wrapper.NumberedCommands.Count > 0)
            {
                var repGrammar = MakeRepeatedGrammar(wrapper.NumberedCommands.ToArray(), Enumerable.Range(0, 10).Select(i => i.ToString()).ToArray(), 99);
                //Engine.LoadGrammar(repGrammar);
            }
            if (wrapper.DictationCommands.Count > 0)
            {
                var gb = new GrammarBuilder(new Choices(wrapper.DictationCommands.ToArray()));
                gb.AppendDictation();
                Engine.LoadGrammar(new Grammar(gb));
            }
        }

        Grammar MakeRepeatedGrammar(string[] firstWords, string[] choicesArr, int choicesMax = 99)
        {
            var gb = new GrammarBuilder(new Choices(firstWords));
            var choices = new Choices(choicesArr);
            gb.Append(new GrammarBuilder(choices, 0, choicesMax));
            NumberedChoices.Add(gb);
            //ChoicesPool.Add(gb);
            return new Grammar(gb);
        }

        void BuildGrammar()
        {
            ChoicesPool.Add(AllCommands.ToArray());
            var gb1 = new GrammarBuilder(ChoicesPool);
            var gb2 = new GrammarBuilder(NumberedChoices);
            var choices = new Choices(new GrammarBuilder[] { gb1, gb2 });
            var gb = new GrammarBuilder(choices, 1, 10);
            var grammar = new Grammar(gb);
            Engine.LoadGrammar(grammar);
        }
        void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result == null || e.Result.Confidence <= .7) return;
            Console.Out.WriteLineAsync(e.Result.Text);
        }

        void recognizer_AudioSignalProblemOccurred(object sender, AudioSignalProblemOccurredEventArgs e)
        {
            Engine.RecognizeAsyncCancel();
            Console.WriteLine("foo");
        }

        public void ListenIO()
        {
            while (true) Thread.Sleep(3000);
        }

    }
}

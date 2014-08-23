using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scripts
{
    public class Engine
    {
        private static uint answer = 1;
        private static uint prompt = 1;
        private static uint terminus = 1;
        private static DialogNode GenerateNode(Random random, double probability)
        {
            double newProbability = probability * random.NextDouble() / 1.5;
            
            if (random.NextDouble() < probability)
            {
                var answers = new Dictionary<string, DialogNode>();
                for (uint i = 0; i < 3; ++i)
                {
                    answers.Add("Answer " + (answer++).ToString(), GenerateNode(random, newProbability));
                }

                return new DialogNode() { Type = DialogType.Prompt, Answers = answers, Prompt = "Prompt " + (prompt++).ToString() };
            }

            return new DialogNode() { Type = DialogType.Terminal, Prompt = "Terminal " + (terminus++).ToString() };
        }

        private static Engine testEngine;
        public static Engine GetTestEngine()
        {
            if (testEngine == null)
            {
                var random = new Random();
                var trees = new List<DialogTree>();
                for (uint i = 0; i < 10; ++i )
                {
                    trees.Add(new DialogTree() { RootNode = GenerateNode(random, 1.0) });
                }

                testEngine = new Engine(trees);
            }
            return testEngine;
        }

        public Engine(List<DialogTree> dialogs)
        {
            this.dialogs = dialogs;
        }

        public PossibleDialogs NextPossibleDialogs()
        {
            var possible = dialogs.Where(t => t.IsAvailable(context)).ToList();

            List<DialogTree> selectedDialogs = new List<DialogTree>();
            for (uint i = 0; i < dialogCount; i++)
            {
                var index = random.Next(possible.Count() - 1);
                DialogTree result = possible.ElementAt(index);

                dialogs.Remove(result);
                possible.Remove(result);

                selectedDialogs.Add(result);
            }

            return new PossibleDialogs(selectedDialogs);
        }

        public DialogEngine AcceptDialogEntry(PossibleDialogs dialogs, DialogTree tree)
        {
            return new DialogEngine(tree, context);
        }

        private const uint dialogCount = 3;
        private Context context = new Context();
        private Random random = new Random();
        private List<DialogTree> dialogs;
    }
}

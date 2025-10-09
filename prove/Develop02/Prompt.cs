using System;
using System.Collections.Generic;
//Prompt class

public class Prompt
{
        public List<string> prompts = new List<string>
        {
        "What did you do well today?", "What are you most thankful for today?","What surprised you today?",
        "What could you have done better today?", "What are you most proud of?"
        };
        public Random random = new Random();
        public string GeneratePrompt()
        {
                int index = random.Next(prompts.Count);
                return prompts[index];
        }
}
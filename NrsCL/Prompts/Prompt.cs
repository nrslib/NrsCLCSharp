namespace NrsCl.Prompts
{
    public static class Prompt
    {
        public static YesNoPrompt.Result ShowYesNoPrompt(string message, YesNoPrompt.Result? defaultValue = YesNoPrompt.Result.Yes)
        {
            var prompt = new YesNoPrompt();
            return prompt.Show(message, defaultValue);
        }

        public static (bool, string) ShowQuitable(string message)
        {
            var prompt = new TypePrompt();
            return prompt.ShowQuitable(message);
        }

        public static string Show(string message)
        {
            var prompt = new TypePrompt();
            return prompt.Show(message);
        }
    }
}

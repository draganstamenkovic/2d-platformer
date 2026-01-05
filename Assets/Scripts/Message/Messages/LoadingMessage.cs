namespace Message.Messages
{
    public class LoadingMessage
    {
        public readonly string Text;
        public LoadingMessage(string text)
        {
            Text = text;
        }
    }
}
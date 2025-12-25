namespace Message.Messages
{
    public class LoadingMessage
    {
        public string Text;
        public bool Active;
        public LoadingMessage(string text, bool active)
        {
            Text = text;
            Active = active;
        }
    }
}
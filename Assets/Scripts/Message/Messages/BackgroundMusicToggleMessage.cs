namespace Message.Messages
{
    public class BackgroundMusicToggleMessage
    {
        public bool IsOn;

        public BackgroundMusicToggleMessage(bool isOn)
        {
            IsOn = isOn;
        }
    }
}
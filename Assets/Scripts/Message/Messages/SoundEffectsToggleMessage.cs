namespace Message.Messages
{
    public class SoundEffectsToggleMessage
    {
        public bool IsOn;
        public SoundEffectsToggleMessage(bool isOn)
        {
            IsOn = isOn;
        }
    }
}
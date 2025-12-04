namespace Message.Messages
{
    public class PauseGameMessage
    {
        public bool Paused;
        public PauseGameMessage(bool paused)
        {
            Paused = paused;
        }

    }
}
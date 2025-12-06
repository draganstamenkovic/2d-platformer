namespace Message.Messages
{
    public class CollectedItemMessage
    {
        public readonly CollectedItem Item;
        public CollectedItemMessage(CollectedItem item)
        {
            Item = item;
        }
    }
    
    public enum CollectedItem
    {
        Cherry,
        Gem
    }
}
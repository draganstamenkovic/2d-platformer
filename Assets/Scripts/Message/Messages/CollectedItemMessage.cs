using Gameplay.Collectables;

namespace Message.Messages
{
    public class CollectedItemMessage
    {
        public readonly CollectedItem Item;
        public readonly CollectableItem Collectable;
        public CollectedItemMessage(CollectableItem collectableItem)
        {
            Collectable = collectableItem;
            Item = collectableItem.itemType;
        }
    }
    
    public enum CollectedItem
    {
        Cherry,
        Gem
    }
}
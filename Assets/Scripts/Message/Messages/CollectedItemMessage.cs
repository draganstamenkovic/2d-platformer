using Gameplay.Collectables;

namespace Message.Messages
{
    public class CollectedItemMessage
    {
        public readonly CollectableItem Collectable;
        public CollectedItemMessage(CollectableItem collectableItem)
        {
            Collectable = collectableItem;
        }
    }
}
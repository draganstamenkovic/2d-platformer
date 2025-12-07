using Message.Messages;

namespace Gameplay.Collectables
{
    public class Cherry : CollectableItem
    {
        private void Start()
        {
            itemType = CollectedItem.Cherry;
        }
    }
}
using Message.Messages;

namespace Gameplay.Collectables
{
    public class Gem : CollectableItem
    {
        private void Start()
        {
            itemType = CollectableType.Gem;
        }
    }
}
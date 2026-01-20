using System;
using UnityEngine;

namespace Gui.Screens.Views
{
    public class ScreenView : MonoBehaviour, IScreenView
    {
        public string ID { get; set; }
        public Action OnShow { get; set; }
        public Action OnShown { get; set; }
        public Action OnHide { get; set; }
        public Action OnHidden { get; set; }

        public virtual void Initialize()
        {
        }
    }
}
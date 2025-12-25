using System;
using Configs;
using UnityEngine;
using VContainer;

namespace Gui.Screens.Views
{
    public class LoadingScreenView : ScreenView
    {
        [SerializeField] private Transform loadingBar;
        [Inject] private GuiConfig _guiConfig;
        public override void Initialize()
        {
            ID = GuiScreenIds.LoadingScreen;
            Debug.Log("LoadingScreenView.Initialize");
        }

        private void Update()
        {
            loadingBar.Rotate(new Vector3(0, 0, 1.5f));
        }
    }
}
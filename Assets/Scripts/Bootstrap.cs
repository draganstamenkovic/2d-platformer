using Audio.Managers;
using Gameplay;
using Gui;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class Bootstrap : IStartable
{
    [Inject] private GuiManager _guiManager;
    [Inject] private IGameplayManager _gameplayManager;
    [Inject] private IAudioManager _audioManager;

    public void Start()
    {
        Prepare();
        _audioManager.Initialize();
        _gameplayManager.Initialize();
        _guiManager.Initialize();
    }
    private void Prepare()
    {
        Application.targetFrameRate = 60;
    }
}

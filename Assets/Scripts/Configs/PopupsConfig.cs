using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "PopupsConfig", menuName = "Configs/PopupsConfig")]
    public class PopupsConfig : ScriptableObject
    {
        public float showTransitionDuration = 0.35f;
        public float hideTransitionDuration = 0.15f;
        public Ease transitionEase = Ease.OutBack;
        public List<PopupPrefabData> popups = new();
    }
    
    [Serializable]
    public class PopupPrefabData
    {
        public string name;
        public RectTransform popupPrefab;
    }
}
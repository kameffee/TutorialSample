using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace TutorialSample
{
    public class TutorialDemo : MonoBehaviour
    {
        [SerializeField]
        private Button _startButton;
        
        [SerializeField]
        private TutorialPhaseSeaquancer _seaquancer;

        private void OnEnable() => _startButton.onClick.AddListener(StartTutorial);

        private void OnDisable() => _startButton.onClick.RemoveListener(StartTutorial);

        private void StartTutorial()
        {
            _seaquancer.StartTutorial();
        }
    }
}

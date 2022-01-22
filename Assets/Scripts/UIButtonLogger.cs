using System;
using UnityEngine;
using UnityEngine.UI;

namespace TutorialSample
{
    [RequireComponent(typeof(Button))]
    public class UIButtonLogger : MonoBehaviour
    {
        private Button _button;
        
        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            Debug.Log($"OnClick: {gameObject.name}");
        }
    }
}

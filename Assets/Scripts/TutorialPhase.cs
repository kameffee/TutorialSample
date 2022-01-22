using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TutorialSample
{
    public class TutorialPhase : MonoBehaviour
    {
        [SerializeField]
        private ClickableArea _button;

        public event Action OnClickEvent = null;

        private void OnEnable() => _button.OnClick.AddListener(OnClick);

        private void OnDisable() => _button.OnClick.RemoveAllListeners();

        private void OnClick(PointerEventData clickedEvent)
        {
            OnClickEvent?.Invoke();
        }

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize()
        {
            gameObject.SetActive(false);
        }

        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}

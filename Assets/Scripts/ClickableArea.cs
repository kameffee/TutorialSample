using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace TutorialSample
{
    public class ClickableArea : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
    {
        private readonly List<RaycastResult> _raycastResults = new List<RaycastResult>();
        public readonly ClickedEvent OnClick = new ClickedEvent();

        public void OnPointerDown(PointerEventData eventData)
        {
            EventSystem.current.RaycastAll(eventData, _raycastResults);

            foreach (var raycastResult in _raycastResults)
            {
                // ルートが同じなら無視
                if (raycastResult.gameObject.transform.root == transform.root)
                {
                    continue;
                }

                ExecuteEvents.Execute(raycastResult.gameObject, eventData, ExecuteEvents.pointerDownHandler);
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            EventSystem.current.RaycastAll(eventData, _raycastResults);

            foreach (var raycastResult in _raycastResults)
            {
                // ルートが同じなら無視
                if (raycastResult.gameObject.transform.root == transform.root)
                {
                    continue;
                }

                ExecuteEvents.Execute(raycastResult.gameObject, eventData, ExecuteEvents.pointerClickHandler);
            }

            OnClick?.Invoke(eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            EventSystem.current.RaycastAll(eventData, _raycastResults);

            foreach (var raycastResult in _raycastResults)
            {
                // ルートが同じなら無視
                if (raycastResult.gameObject.transform.root == transform.root)
                {
                    continue;
                }

                ExecuteEvents.Execute(raycastResult.gameObject, eventData, ExecuteEvents.pointerUpHandler);
            }
        }
    }

    public class ClickedEvent : UnityEvent<PointerEventData>
    {
    }
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace TutorialSample
{
    public class ClickableArea : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
    {

        public readonly ClickedEvent OnClick = new ClickedEvent();

        public void OnPointerDown(PointerEventData eventData)
        {
            List<RaycastResult> raycastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, raycastResults);

            Debug.Log(raycastResults);

            foreach (var raycastResult in raycastResults)
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
            List<RaycastResult> raycastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, raycastResults);

            foreach (var raycastResult in raycastResults)
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
            List<RaycastResult> raycastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, raycastResults);

            foreach (var raycastResult in raycastResults)
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

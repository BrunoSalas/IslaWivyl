using MEC;
using System.Collections.Generic;
using UnityEngine;

namespace Custom.Indicators
{
    [RequireComponent(typeof(Canvas))]
    public class OffscreenIndicator : MonoBehaviour
    {
        public Camera activeCamera;
        public List<Indicator> targetIndicators;
        public GameObject indicatorPrefab;
        public float checkTime = .1f;
        public Vector2 offset;

        private Transform _transform;

        void Start()
        {
            _transform = transform;
            InstantiateIndicators();

            Timing.RunCoroutine(UpdateIndicator().CancelWith(gameObject));
        }

        public void AddTarget(GameObject targetObject)
        {
            targetIndicators.Add(new Indicator() 
            {
                target = targetObject.transform
            });

            InstantiateIndicators();
        }

        public void InstantiateIndicators()
        {
            foreach (var targetIndicator in targetIndicators)
            {
                if (targetIndicator.indicatorUI == null)
                {
                    targetIndicator.indicatorUI = Instantiate(indicatorPrefab).transform;
                    targetIndicator.indicatorUI.SetParent(_transform);
                }

                var rectTranform = targetIndicator.indicatorUI.GetComponent<RectTransform>();
                if (rectTranform == null)
                {
                    rectTranform = targetIndicator.indicatorUI.gameObject.AddComponent<RectTransform>();
                }

                targetIndicator.rectTransform = rectTranform;
            }
        }

        private void UpdatePosition(Indicator targetIndicator)
        {
            var rect = targetIndicator.rectTransform.rect;

            var indicatorPosition = activeCamera.WorldToScreenPoint(targetIndicator.target.position);
            if (indicatorPosition.z < 0)
            {
                indicatorPosition.y = -indicatorPosition.y;
                indicatorPosition.x = -indicatorPosition.x;
            }
            var newPosition = new Vector3(indicatorPosition.x, indicatorPosition.y, indicatorPosition.z);

            indicatorPosition.x = Mathf.Clamp(indicatorPosition.x, rect.width / 2, Screen.width - rect.width / 2) + offset.x;
            indicatorPosition.y = Mathf.Clamp(indicatorPosition.y, rect.height / 2, Screen.height - rect.height / 2) + offset.y;
            indicatorPosition.z = 0;

            targetIndicator.indicatorUI.up = (newPosition - indicatorPosition).normalized;
            targetIndicator.indicatorUI.position = indicatorPosition;
        }

        private IEnumerator<float> UpdateIndicator()
        {
            while (true)
            {
                foreach (var targetIndicator in targetIndicators)
                {
                    UpdatePosition(targetIndicator);
                }
                yield return Timing.WaitForSeconds(checkTime);
            }
        }

    }

    [System.Serializable]
    public class Indicator
    {
        [Tooltip("Target object to follow.")]
        public Transform target;
        
        [Tooltip("OPTIONAL. UI for the indicator, if empty an object of type indicatorPrefab will be created for you.")]
        public Transform indicatorUI;
        
        [HideInInspector]
        public RectTransform rectTransform;
    }
}


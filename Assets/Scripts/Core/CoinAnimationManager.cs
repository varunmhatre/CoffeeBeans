using System.Collections;
using CoffeeBeans.Customers;
using UnityEngine;
using UnityEngine.UI;

namespace CoffeeBeans.Core
{
    public class CoinAnimationManager : MonoBehaviour
    {
        [Header("Coin Animation Settings")]
        public Image coinPrefab;
        public float spawnRadius = 100f;
        public float travelTime = 0.8f;
        public AnimationCurve motionCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);

        [Header("UI References")]
        public RectTransform coinTarget;
        public Canvas canvas;

        private Camera mainCamera;

        private void Awake()
        {
            mainCamera = Camera.main;
        }
        
        private void OnEnable()
        {
            EventBus.OnCustomerServed += HandleCustomerServed;
        }

        private void OnDisable()
        {
            EventBus.OnCustomerServed -= HandleCustomerServed;
        }

        private void HandleCustomerServed(int servedCount, int coinsEarned)
        {
            Customer customer = FindFirstObjectByType<Customer>();
            if (customer == null) return;

            Vector3 worldPos = customer.transform.position + Vector3.up * 1.5f;

            for (int i = 0; i < coinsEarned; i++)
            {
                Vector3 randomOffset = Random.insideUnitSphere * spawnRadius;
                Vector3 spawnWorld = worldPos + randomOffset;

                Vector3 screenPos = mainCamera.WorldToScreenPoint(spawnWorld);
                RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    canvas.transform as RectTransform,
                    screenPos,
                    canvas.worldCamera,
                    out Vector2 localPos
                );

                Image coin = Instantiate(coinPrefab, canvas.transform);
                coin.rectTransform.anchoredPosition = localPos;

                StartCoroutine(AnimateCoinToTarget(coin.rectTransform));
            }
        }

        private IEnumerator AnimateCoinToTarget(RectTransform coin)
        {
            Vector3 start = coin.position;
            Vector3 end = coinTarget.position;

            float elapsed = 0f;
            while (elapsed < travelTime)
            {
                elapsed += Time.deltaTime;
                float t = Mathf.Clamp01(elapsed / travelTime);
                coin.position = Vector3.Lerp(start, end, t);
                yield return null;
            }

            Destroy(coin.gameObject);
        }
    }
}
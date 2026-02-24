using Data.Cards;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Presentation.Views
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] private GameObject wrapper;
        [SerializeField] private SpriteRenderer cardSpriteRenderer;
        [SerializeField] private TextMeshPro topLeftText;
        [SerializeField] private TextMeshPro centerText;
        [SerializeField] private TextMeshPro bottomRightText;

        private BaseCard _card;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start()
        {
            cardSpriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnMouseEnter()
        {
            wrapper.SetActive(false);
            Vector3 pos = new(transform.position.x, -2, 0);
            CardViewHoverSystem.Instance.Show(_card, pos);
        }

        private void OnMouseExit()
        {
            CardViewHoverSystem.Instance.Hide();
            wrapper.SetActive(true);
        }

        public void Setup(BaseCard card)
        {
            _card = card;

            centerText.text = card.label;
            topLeftText.text = card.label;
            bottomRightText.text = card.label;
            cardSpriteRenderer.sprite = card.faceSprite;
        }

        public void MoveToLayout(Vector3 targetPosition, Quaternion targetRotation)
        {
            MoveTo(targetPosition, targetRotation, 0.25f, Ease.OutQuad);
        }

        public void MoveFromDeckTo(Vector3 targetPosition, Quaternion targetRotation)
        {
            MoveTo(targetPosition, targetRotation, 0.4f, Ease.OutCubic);
        }

        private void MoveTo(Vector3 targetPos, Quaternion targetRot, float duration, Ease ease)
        {
            const float arcHeight = 0.2f;

            var startPos = transform.position;
            var midPoint = (startPos + targetPos) / 2f + Vector3.up * arcHeight;

            var seq = DOTween.Sequence();

            seq.Append(transform.DOMove(midPoint, duration * 0.5f).SetEase(ease));
            seq.Append(transform.DOMove(targetPos, duration * 0.5f).SetEase(ease));

            seq.Join(transform.DORotateQuaternion(targetRot, duration)
                .SetEase(Ease.OutCubic));

            seq.Append(transform.DOScale(1.05f, 0.08f));
            seq.Append(transform.DOScale(1f, 0.08f));
        }
    }
}
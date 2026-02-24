using Data.Cards;
using Shared;
using UnityEngine;

namespace Presentation.Views
{
    public class CardViewHoverSystem : Singleton<CardViewHoverSystem>
    {
        [SerializeField] private CardView cardView;

        public void Show(BaseCard card, Vector3 position)
        {
            cardView.gameObject.SetActive(true);
            cardView.Setup(card);
            cardView.transform.position = position;
        }

        public void Hide()
        {
            cardView.gameObject.SetActive(false);
        }
    }
}
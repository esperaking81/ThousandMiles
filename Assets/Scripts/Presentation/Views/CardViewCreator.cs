using Data.Cards;
using DG.Tweening;
using Shared;
using UnityEngine;

namespace Presentation.Views
{
    public class CardViewCreator : Singleton<CardViewCreator>
    {
        [SerializeField] private CardView cardViewPrefab;
        [SerializeField] private Transform spawnPoint;

        public CardView CreateCardView(BaseCard card)
        {
            var cardView = Instantiate(cardViewPrefab, spawnPoint.position, spawnPoint.rotation);
            cardView.transform.localScale = Vector3.zero;
            cardView.transform.DOScale(Vector3.one, 0.15f);
            cardView.Setup(card);
            return cardView;
        }
    }
}
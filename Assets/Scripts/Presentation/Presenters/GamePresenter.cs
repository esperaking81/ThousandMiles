using System.Collections;
using System.Collections.Generic;
using Data.Cards;
using Domain.Models;
using Presentation.Managers;
using Presentation.Views;
using UnityEngine;

namespace Presentation.Presenters
{
    /// <summary>
    ///     This class should be responsible for orchestrating UI updates
    /// </summary>
    public class GamePresenter : MonoBehaviour
    {
        [SerializeField] private HandManager handManager;
        [SerializeField] private DeckManager deckManager;

        private readonly Dictionary<BaseCard, CardView> _cardRegistry = new();

        private readonly Queue<BaseCard> _dealQueue = new();
        private Coroutine _dealRoutine;

        public void Bind(Game game)
        {
            deckManager.OnDeckClicked += game.RequestDrawCard;

            foreach (var player in game.Players)
                if (player.IsLocalPlayer)
                    player.OnCardAdded += PlayerOnOnCardAdded;
        }

        private void PlayerOnOnCardAdded(BaseCard card)
        {
            _dealQueue.Enqueue(card);

            _dealRoutine ??= StartCoroutine(ProcessDealQueue());
        }

        private IEnumerator ProcessDealQueue()
        {
            while (_dealQueue.Count > 0)
            {
                var card = _dealQueue.Dequeue();
                var cardView = CardViewCreator.Instance.CreateCardView(card);
                _cardRegistry[card] = cardView;
                handManager.AddCard(cardView);

                yield return new WaitForSeconds(0.18f);
            }

            _dealRoutine = null;
        }

        public void UnBind(Game game)
        {
            Debug.Log("Unbind game");
            foreach (var player in game.Players)
                if (player.IsLocalPlayer)
                    player.OnCardAdded -= PlayerOnOnCardAdded;
        }
    }
}
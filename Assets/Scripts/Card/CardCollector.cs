using UnityEngine;
using UnityEngine.Events;

public class CardCollector : MonoBehaviour
{
    private Card _firstCard;
    private Card _secondCard;
    private int _countCards;
    [SerializeField] private BoolEvent _scoreAdd = new BoolEvent();
    [SerializeField] private UnityEvent _onGameEnded = new UnityEvent();

    public void FindCards() 
    {
        Card[] cards = FindObjectsOfType<Card>();
        _countCards = cards.Length;
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].SetCardCollector(this);  
        }
    }

    public void OpenCard(Card card) 
    {
        if (_firstCard == null)
        {
            _firstCard = card;
        }
        else 
        {
            _secondCard = card;
            Invoke(nameof(CompareCards), 0.7f);
        }
    }

    private void CompareCards()
    {
        if (_firstCard.Index == _secondCard.Index)
        {
            Destroy(_firstCard.gameObject);
            Destroy(_secondCard.gameObject);
            _countCards -= 2;
            _scoreAdd.Invoke(true);

            if (_countCards < 2)
            {
                _onGameEnded.Invoke();
            }
        }
        else
        {
            _secondCard.CardAnimation();
            _firstCard.CardAnimation();
            _scoreAdd.Invoke(false);

        }
        _secondCard = null;
        _firstCard = null;
    }

    public bool TwoCardClosed() {
        return _secondCard == null;
    }
}
[System.Serializable]
public class BoolEvent : UnityEvent<bool> { }

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CardGenerator : MonoBehaviour
{
    [SerializeField] private GameGrid _grid = null;
    [SerializeField] private CardPresets _cardPresets = null;
    [SerializeField] private Card _cardPrefab = null;
    [SerializeField] private UnityEvent _startCollect = new UnityEvent();

    public void Spawn()
    {
        Transform localTransform = GetComponent<Transform>();
        Card card;
        Sprite backSprite = _cardPresets.GetBackSprite();
        List<Sprite> playCardSprites = _cardPresets.GetGameSprites();

        int[] playCardsIndex = _cardPresets.GetCardIndex();
        float positionX = _grid.GetPositionX();
        float positionY = _grid.PositionY;
        int count = _grid.GetColumnsCount();

        for (int j = 0; j < playCardsIndex.Length; j++)
        {
            card = Instantiate(_cardPrefab) as Card;
            card.transform.position = new Vector3(positionX, positionY + localTransform.position.y);
            card.transform.parent = localTransform;
            card.CardSettings(backSprite, playCardSprites[playCardsIndex[j]], playCardsIndex[j]);
            positionX += _grid.OffsetX;
            count--;
            if (count < 1)
            {
                count = _grid.GetColumnsCount();
                positionY -= _grid.OffsetY;
                positionX = (_grid.GetPositionX());
            }
        }
        _startCollect.Invoke();
    }
}

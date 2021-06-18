using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CardPresets : MonoBehaviour
{
    private Sprite _backSprite = null;
    private List<Sprite> _allSprites = null;
    private readonly ResourcesLoader resourcesLoader = new ResourcesLoader();
    [SerializeField] private LevelData _levelData = null;
    [SerializeField] private UnityEvent _onThemeLoaded = new UnityEvent();
    public void GetSprites() {
        Theme theme = resourcesLoader.GetTheme(_levelData.ThemeName);
        _backSprite = theme.BaskSprite;
        _allSprites = theme.AllSprites;
        _onThemeLoaded.Invoke();
    }

    public Sprite GetBackSprite() {
        return _backSprite;
    }

    public List<Sprite> GetGameSprites() 
    {
        List<Sprite> sprites = new List<Sprite>(_allSprites);
        while (_levelData.MaxPlayCard< sprites.Count)
        {
            sprites.RemoveAt(Random.Range(0, sprites.Count));
        }
        return sprites;
    }
    public int[] GetCardIndex() {
        int[] cardIndex = new int[_levelData.MaxPlayCard * 2];
        for (int i = 0; i < cardIndex.Length; i++)
        {
            cardIndex[i] = i / 2;
        }
        for (int i = 0; i < cardIndex.Length; i++)
        {
            int temp = cardIndex[i];
            int rnd = Random.Range(0, cardIndex.Length);
            cardIndex[i] = cardIndex[rnd];
            cardIndex[rnd] = temp;
        }
        return cardIndex;
    }
}

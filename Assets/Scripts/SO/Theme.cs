using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Theme", menuName ="SO/Theme")]
public class Theme : ScriptableObject
{
    public Sprite BaskSprite;
    public List<Sprite> AllSprites;
}

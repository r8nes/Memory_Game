using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour
{
    public readonly float OffsetX = 2f;
    public readonly float PositionY = 1.5f;
    public readonly float OffsetY = 3f;
    [SerializeField] private LevelData _levelData = null;

    public int GetColumnsCount() {
        return _levelData.MaxPlayCard;
    }
    public float GetPositionX() 
    {
        float x = 1f;
        x -= GetColumnsCount() % 2;
        x -= OffsetX * (GetColumnsCount() / 2);
        return x;
    }
}

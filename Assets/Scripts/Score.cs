using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    private const int Add = 3;
    private const int Remove = -1;
    private int _value;
   [SerializeField] private IntEvent _onUpdate = new IntEvent();
    public void ResetScore() {
        _value = 0;
        _onUpdate.Invoke(_value);
    }

    public void AddRemove(bool addRemove) {
        _value += addRemove == true ? Add : Remove;
        if (_value < 0)
        {
            _value = 0;
        }
        _onUpdate.Invoke(_value); 
    }
}
[System.Serializable]
public class IntEvent : UnityEvent<int> { }

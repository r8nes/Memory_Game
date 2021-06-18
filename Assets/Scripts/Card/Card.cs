using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D))]
public class Card : MonoBehaviour, IPointerClickHandler
{
    private SpriteRenderer _spriteRenderer;
    private Sprite _backSprite; 
    private Sprite _frontSprite;

    private CardCollector _cardCollector;

    private Animation _animation;
    private BoxCollider2D _cardBoxCollider2D;
    
    private bool _isBackSide = true;
    public int Index { get; private set; }
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animation = GetComponent<Animation>();
        _cardBoxCollider2D = GetComponent<BoxCollider2D>();
    }

  
    private void EnableCardCollider() {
        _cardBoxCollider2D.enabled = true; 
    }

    private void ChangeCardSprite() {

        _spriteRenderer.sprite = _isBackSide == true ? _backSprite : _frontSprite;
    }

    public void CardAnimation()
    {
        _isBackSide = !_isBackSide;

        _animation.Play(_isBackSide ? "ToBack" : "ToFront");
    }

    public void FlipSprite()
    {
        
        if (!_isBackSide)        
            _spriteRenderer.flipX = true;      
        else     
            _spriteRenderer.flipX = false;  
    }

    public void CardSettings(Sprite back, Sprite front, int index) {
        _spriteRenderer.sprite = _backSprite = back;
        _frontSprite = front;
        Index = index;
    }

    public void SetCardCollector(CardCollector cardCollector) 
    {
        _cardCollector = cardCollector;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_cardCollector.TwoCardClosed())
        {
            _cardBoxCollider2D.enabled = false;
            CardAnimation();
            _cardCollector.OpenCard(this);
        }
    }
}

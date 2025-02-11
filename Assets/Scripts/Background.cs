using UnityEngine;

public class Background : MonoBehaviour
{
    SpriteRenderer _spriteRenderer;
    float _offset;
    float _speed = 0.1f;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        _offset += Time.deltaTime * _speed;
        _spriteRenderer.material.mainTextureOffset = new Vector2(_offset, 0);
    }
}

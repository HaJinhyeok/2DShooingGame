using UnityEngine;
using UnityEngine.Events;

public class Background : MonoBehaviour
{
    public static UnityAction RestartBg;

    SpriteRenderer _spriteRenderer;
    float _offset;
    float _speed = 0.1f;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        RestartBg += Restart;
    }

    void Update()
    {
        _offset += Time.deltaTime * _speed;
        _spriteRenderer.material.mainTextureOffset = new Vector2(_offset, 0);
    }

    void Restart()
    {
        _offset = 0;
    }
}

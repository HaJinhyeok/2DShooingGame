using UnityEngine;

public class Shot : MonoBehaviour
{
    float _speed = 20f;

    private void Start()
    {
        Destroy(gameObject, 5.0f);
    }

    private void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * _speed);
    }
}

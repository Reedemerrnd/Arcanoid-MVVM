using UnityEngine;

namespace Arcanoid.Views
{
    public abstract class BaseTile : MonoBehaviour
    {
        private SpriteRenderer _renderer;

        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
        }

        public virtual void SetScale(float x, float y)
        {
            transform.localScale.Set(x, y, 1f);
        }

        public virtual void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public virtual void SetColor(Color color)
        {
            _renderer.material.color = color;
        }

        public virtual void Enable(bool enable)
        {
            gameObject.SetActive(enable);
        }

    }
}

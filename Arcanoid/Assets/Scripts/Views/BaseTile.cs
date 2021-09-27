using UnityEngine;

namespace Arcanoid.Views
{
    public abstract class BaseTile : MonoBehaviour
    {
        private Color _color;

        private void Awake()
        {
            _color = GetComponent<SpriteRenderer>().material.color;
        }

        public virtual void SetScale(float x, float y)
        {
            transform.localScale.Set(x, y, 0.1f);
        }

        public virtual void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public virtual void SetColor(Color color)
        {
            _color = color;
        }

        public virtual void Enable(bool enable)
        {
            gameObject.SetActive(enable);
        }

    }
}

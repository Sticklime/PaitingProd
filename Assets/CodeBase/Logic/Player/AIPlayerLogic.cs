using System.Collections;
using UnityEngine;

namespace CodeBase.Logic.Player
{
    public class AIPlayerLogic : PlayerLogic
    {
        [SerializeField] private float speed;
        
        private Vector2 _direction;
        
        private IEnumerator Start()
        {
            while (true)
            {
            
                _direction = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));

                if (_direction.x == 0 && _direction.y == 0) 
                    _direction = new Vector2(0, 1);

                yield return new WaitForSeconds(Random.Range(1f, 2f));
            }
        }
        
       private void Update() => 
           transform.Translate(_direction * speed * Time.deltaTime);

       private void OnCollisionEnter2D(Collision2D collision) => 
            _direction = new Vector2(_direction.x * -1, _direction.y * -1);
    }
}
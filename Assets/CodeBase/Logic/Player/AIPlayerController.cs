using System.Collections;
using UnityEngine;

namespace CodeBase.Logic.Player
{
    public class AIPlayerController : Controller
    {
        private IEnumerator Start()
        {
            while (true)
            {
                Direction = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));

                if (Direction.x == 0 && Direction.y == 0)
                    Direction = new Vector2(0, 1);

                yield return new WaitForSeconds(1);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision) =>
            Direction = new Vector2(Direction.x * -1, Direction.y * -1);
    }
}
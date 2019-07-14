using Entitas;
using UnityEngine;

public class EnemyMoveSystem : Feature
{
    
    readonly IGroup<GameEntity> _enemies;
    readonly IGroup<GameEntity> _players;
     const float _speed = 0.5f;

 public EnemyMoveSystem(Contexts contexts)
    {
                _enemies = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Enemy));
                _players = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player));
    }

    public override void Execute()
    {
        Vector2 targetPosition = Vector2.zero;
        foreach (GameEntity tempE in _players.GetEntities()) {
            if (tempE.isPlayer) {
                 targetPosition = tempE.position.value;
                 break;
            }
        }
        
        
        foreach (GameEntity e in _enemies.GetEntities())
        {

              Vector2 dir = targetPosition - e.position.value;
            Vector2 newPosition = e.position.value + dir.normalized * _speed * Time.deltaTime;
            e.ReplacePosition(newPosition);

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            e.ReplaceDirection(angle);

            float dist = dir.magnitude;
           
        }
    }
}
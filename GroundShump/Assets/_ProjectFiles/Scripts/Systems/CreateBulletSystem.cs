using System.Collections.Generic;
using Entitas;
using UnityEngine;


public class CreateBulletSystem : ReactiveSystem<InputEntity>
{
    readonly BulletsContext _bulletsContext;
    readonly GameContext _gameContext;
    Vector3 playerPosition;

    public CreateBulletSystem(Contexts contexts) : base(contexts.input)
    {
        _bulletsContext = contexts.bullets;
        _gameContext = contexts.game;

    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.RightMouse, InputMatcher.MouseDown));
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasMouseDown;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        Vector2 bulletDirection = Vector2.up;

        foreach (var e in _gameContext.GetEntities())
        {
            if (e.isPlayer)
            {
                playerPosition = new Vector3(e.position.value.x, e.position.value.y, 0f);
                if (e.direction.value==90f) {
                    bulletDirection = Vector2.up;
                } else if (e.direction.value==0f) {
                    bulletDirection = Vector2.right;
                } else if (e.direction.value==-90f) {
                    bulletDirection = Vector2.down;
                } else if (e.direction.value==180f) {
                    bulletDirection = Vector2.left;
                }
                break;
            }
        }

        foreach (InputEntity e in entities)
        {
            var gameObject = Assets.Instantiate<GameObject>(Res.Bullet);
            BulletsEntity mover=_bulletsContext.CreateEntity();
            gameObject.Link(mover);
             mover.AddView(gameObject);
            mover.AddPosition(playerPosition);
            Debug.Log("speed=" + gameObject.GetComponent<SpeedScript>().mySpeed);
            mover.AddVelocity(bulletDirection * gameObject.GetComponent<SpeedScript>().mySpeed);

        }
    }
}

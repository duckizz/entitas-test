using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class CreateEnemySystem : IInitializeSystem
{
    readonly GameContext _gameContext;

    public CreateEnemySystem(Contexts contexts)
    {
        _gameContext = contexts.game;
    }
    /*     public CreateMoverSystem(Contexts contexts) : base(contexts.input)
        {
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
            foreach (InputEntity e in entities)
            {
                GameEntity mover = _gameContext.CreateEntity();
                mover.isMover = true;
                mover.AddPosition(e.mouseDown.position);
                mover.AddDirection(Random.Range(0,360));
                mover.AddSprite("SMUP_1x1_J2Battlewagon_vertical_000");
            }
        }
    */
    public void Initialize()
    {
        for (int i = 0; i < 5; i++)
        {
            GameEntity mover = _gameContext.CreateEntity();
            var gameObject = Assets.Instantiate<GameObject>(Res.Enemy);

            mover.AddPosition(new Vector3(Random.Range(-5f, 5f), Random.Range(2f, 4f), 0f));
            // mover.AddDirection(90);
            mover.isEnemy = true;
            mover.AddView(gameObject);
            gameObject.Link(mover);

        }
    }


}

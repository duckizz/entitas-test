using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class CreateEnemySystem : Feature, IInitializeSystem
{
    readonly GameContext _gameContext;

    public CreateEnemySystem(Contexts contexts)
    {
        _gameContext = contexts.game;
    }

    public override void Initialize()
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

     public override void Execute()
    {
        int enemiesLeft=0;
       foreach (GameEntity e in _gameContext.GetEntities()) {
           if (e.isEnemy)
            enemiesLeft++;

       }
       if (enemiesLeft==0)
            Initialize();
    }



}

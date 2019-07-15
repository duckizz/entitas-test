using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class CreateEnemySystem : Feature, IInitializeSystem
{
    readonly GameContext _gameContext;
    int SpawnLevel = 0;

    public CreateEnemySystem(Contexts contexts)
    {
        _gameContext = contexts.game;
    }

    public override void Initialize()
    {
  
    }

    float GetRandomDistance() {
        if (Random.Range(0,2)==0) {
            return Random.Range(-2.5f,-5f);
        }
        return Random.Range(2.5f,5f);
    }
    void CreateEnemies() {
        SpawnLevel++;
        int numOfEnemies = 4 + SpawnLevel;
        Vector3 playerPos = Vector3.zero;
        foreach (GameEntity e in _gameContext.GetEntities()) {
            if (e.isPlayer) {
                playerPos = e.position.value;
                break;
            }
        }
      for (int i = 0; i < numOfEnemies; i++)
        {
            GameEntity mover = _gameContext.CreateEntity();
            var gameObject = Assets.Instantiate<GameObject>(Res.Enemy);
            Vector3 enemyPos = new Vector3(playerPos.x + GetRandomDistance(), playerPos.y + GetRandomDistance(),0f);
            mover.AddPosition(enemyPos);
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
            CreateEnemies();
    }



}

using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class KeyboardMoveSystem : MultiReactiveSystem<InputEntity, Contexts>
{
    readonly GameContext _gameContext;
    readonly IGroup<GameEntity> _movers;

    public KeyboardMoveSystem(Contexts contexts) : base(contexts)
    {
        _movers = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Mover).NoneOf(GameMatcher.Move));
    }


    protected override ICollector[] GetTrigger(Contexts contexts)
    {
        return new ICollector[] {
            contexts.input.CreateCollector(InputMatcher.KeyboardA),
            contexts.input.CreateCollector(InputMatcher.KeyboardS),
            contexts.input.CreateCollector(InputMatcher.KeyboardW),
            contexts.input.CreateCollector(InputMatcher.KeyboardD),
            contexts.input.CreateCollector(InputMatcher.KeyboardInput)
        };
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasKeyboardInput;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (InputEntity e in entities)
        {
            GameEntity[] movers = _movers.GetEntities();
            if (movers.Length <= 0) return;
            for (int i = 0; i < movers.Length; i++)
            {
                movers[i].ReplaceMove(movers[i].position.value + e.keyboardInput.adjustPosition);
            }
            // movers[Random.Range(0, movers.Length)].ReplaceMove(e.mouseDown.position);
        }
    }
}
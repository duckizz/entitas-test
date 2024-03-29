﻿using System.Collections.Generic;
using Entitas;

public class RenderPositionSystem : ReactiveSystem<GameEntity>
{
    public RenderPositionSystem(Contexts contexts) : base(contexts.game)
    {
    }
    

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Position);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasPosition && entity.hasView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity e in entities)
        {
            if (e.view.gameObject!=null)
             e.view.gameObject.transform.position = e.position.value;
        }
    }
}
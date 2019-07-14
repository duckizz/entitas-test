using System.Collections.Generic;
using Entitas;

public class RenderScaleSystem : ReactiveSystem<GameEntity>
{
    public RenderScaleSystem(Contexts contexts) : base(contexts.game)
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
            if (e.hasScale)
            {
                e.view.gameObject.transform.localScale = new UnityEngine.Vector3(e.scale.value, e.scale.value, e.scale.value);
            }
        }
    }
}

using System.Collections.Generic;
using Entitas;

public class RenderBulletPositionSystem : ReactiveSystem<BulletsEntity>
{
    public RenderBulletPositionSystem(Contexts contexts) : base(contexts.bullets)
    {
    }
    

    protected override ICollector<BulletsEntity> GetTrigger(IContext<BulletsEntity> context)
    {
        return context.CreateCollector(BulletsMatcher.Position);
    }

    protected override bool Filter(BulletsEntity entity)
    {
        return entity.hasPosition && entity.hasView;
    }

    protected override void Execute(List<BulletsEntity> entities)
    {
        foreach (BulletsEntity e in entities)
        {
            if (e.view.gameObject!=null)
             e.view.gameObject.transform.position = e.position.value;
        }
    }
}
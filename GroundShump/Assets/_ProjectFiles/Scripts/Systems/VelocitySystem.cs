using Entitas;
using UnityEngine;

public class VelocitySystem : Feature
{
    
    readonly IGroup<BulletsEntity> _bullets;

 public VelocitySystem(Contexts contexts)
    {
                _bullets = contexts.bullets.GetGroup(BulletsMatcher.AllOf(BulletsMatcher.Velocity));


    }

    public override void Execute()
    {
        foreach (BulletsEntity e in _bullets.GetEntities())
        {
                 var pos  = e.position.value;
                if (e.position.value.x>7 || e.position.value.x<-7 || e.position.value.y>7 || e.position.value.y<-7) {
                    //destroy?

                    UnityEngine.GameObject.Destroy(e.view.gameObject);
                    e.view.gameObject.Unlink();
                    e.Destroy();
                } else
                e.ReplacePosition(pos+e.velocity.value);
        }
    }
}

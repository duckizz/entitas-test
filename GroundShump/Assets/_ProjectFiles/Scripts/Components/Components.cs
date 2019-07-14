using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Bullets]
public class PositionComponent : IComponent
{
    public Vector2 value;
}

[Game, Bullets]
public class DirectionComponent : IComponent
{
    public float value;
}
[Game, Bullets]
public class ViewComponent : IComponent
{
    public GameObject gameObject;
}

[Game]
public class SpriteComponent : IComponent
{
    public string name;
}
[Game]
public class MoverComponent : IComponent
{
}

[Game]
public class PlayerComponent: IComponent {

}

[Game]
public class MoveComponent : IComponent
{
    public Vector2 target;
}

[Game]
public class MoveCompleteComponent : IComponent
{
}
[Input, Unique]
public class LeftMouseComponent : IComponent
{
}

[Input, Unique]
public class KeyboardAComponent: IComponent {

}
[Input, Unique]
public class KeyboardDComponent: IComponent {

}

[Input, Unique]
public class KeyboardSComponent: IComponent {

}

[Game]
public class ScaleComponent:IComponent {
    public float value;
}

[Input, Unique]
public class KeyboardWComponent: IComponent {

}

[Input, Unique]
public class RightMouseComponent : IComponent
{
}

[Input]
public class KeyboardInputComponent: IComponent {
    public Vector2 adjustPosition;
}

[Input]
public class MouseDownComponent : IComponent
{
    public Vector2 position;
}

[Input]
public class MousePositionComponent : IComponent
{
    public Vector2 position;
}

[Input]
public class MouseUpComponent : IComponent
{
    public Vector2 position;
}
[Game, Bullets]
public class VelocityComponent: IComponent {
    public Vector2 value;
}

[Game]
public class EnemyComponent: IComponent {

}

[Bullets]
public class BulletComponent:IComponent {

}
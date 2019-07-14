//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputContext {

    public InputEntity rightMouseEntity { get { return GetGroup(InputMatcher.RightMouse).GetSingleEntity(); } }

    public bool isRightMouse {
        get { return rightMouseEntity != null; }
        set {
            var entity = rightMouseEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().isRightMouse = true;
                } else {
                    entity.Destroy();
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    static readonly RightMouseComponent rightMouseComponent = new RightMouseComponent();

    public bool isRightMouse {
        get { return HasComponent(InputComponentsLookup.RightMouse); }
        set {
            if (value != isRightMouse) {
                var index = InputComponentsLookup.RightMouse;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : rightMouseComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherRightMouse;

    public static Entitas.IMatcher<InputEntity> RightMouse {
        get {
            if (_matcherRightMouse == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.RightMouse);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherRightMouse = matcher;
            }

            return _matcherRightMouse;
        }
    }
}

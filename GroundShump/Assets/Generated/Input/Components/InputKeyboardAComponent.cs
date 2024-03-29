//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputContext {

    public InputEntity keyboardAEntity { get { return GetGroup(InputMatcher.KeyboardA).GetSingleEntity(); } }

    public bool isKeyboardA {
        get { return keyboardAEntity != null; }
        set {
            var entity = keyboardAEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().isKeyboardA = true;
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

    static readonly KeyboardAComponent keyboardAComponent = new KeyboardAComponent();

    public bool isKeyboardA {
        get { return HasComponent(InputComponentsLookup.KeyboardA); }
        set {
            if (value != isKeyboardA) {
                var index = InputComponentsLookup.KeyboardA;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : keyboardAComponent;

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

    static Entitas.IMatcher<InputEntity> _matcherKeyboardA;

    public static Entitas.IMatcher<InputEntity> KeyboardA {
        get {
            if (_matcherKeyboardA == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.KeyboardA);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherKeyboardA = matcher;
            }

            return _matcherKeyboardA;
        }
    }
}

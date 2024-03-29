//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public KeyboardInputComponent keyboardInput { get { return (KeyboardInputComponent)GetComponent(InputComponentsLookup.KeyboardInput); } }
    public bool hasKeyboardInput { get { return HasComponent(InputComponentsLookup.KeyboardInput); } }

    public void AddKeyboardInput(UnityEngine.Vector2 newAdjustPosition) {
        var index = InputComponentsLookup.KeyboardInput;
        var component = (KeyboardInputComponent)CreateComponent(index, typeof(KeyboardInputComponent));
        component.adjustPosition = newAdjustPosition;
        AddComponent(index, component);
    }

    public void ReplaceKeyboardInput(UnityEngine.Vector2 newAdjustPosition) {
        var index = InputComponentsLookup.KeyboardInput;
        var component = (KeyboardInputComponent)CreateComponent(index, typeof(KeyboardInputComponent));
        component.adjustPosition = newAdjustPosition;
        ReplaceComponent(index, component);
    }

    public void RemoveKeyboardInput() {
        RemoveComponent(InputComponentsLookup.KeyboardInput);
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

    static Entitas.IMatcher<InputEntity> _matcherKeyboardInput;

    public static Entitas.IMatcher<InputEntity> KeyboardInput {
        get {
            if (_matcherKeyboardInput == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.KeyboardInput);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherKeyboardInput = matcher;
            }

            return _matcherKeyboardInput;
        }
    }
}

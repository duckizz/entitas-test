using Entitas;
using UnityEngine;

public class EmitInputSystem : IInitializeSystem, IExecuteSystem
{
    readonly InputContext _context;
    private InputEntity _leftMouseEntity;
    private InputEntity _rightMouseEntity;
    private InputEntity _keyboardAEntity;
    private InputEntity _keyboardSEntity;
    private InputEntity _keyboardDEntity;
    private InputEntity _keyboardWEntity;

    public EmitInputSystem(Contexts contexts)
    {
        _context = contexts.input;
    }

    public void Initialize()
    {
        // initialize the unique entities that will hold the mouse button data
        _context.isLeftMouse = true;
        _leftMouseEntity = _context.leftMouseEntity;

        _context.isRightMouse = true;
        _rightMouseEntity = _context.rightMouseEntity;

        _context.isKeyboardA = true;
        _keyboardAEntity = _context.keyboardAEntity;

        _context.isKeyboardD = true;
        _keyboardDEntity = _context.keyboardDEntity;

        _context.isKeyboardS = true;
        _keyboardSEntity = _context.keyboardSEntity;

        _context.isKeyboardW = true;
        _keyboardWEntity = _context.keyboardWEntity;
        
    }

    public void Execute()
    {
        // mouse position
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // left mouse button
        if (Input.GetMouseButtonDown(0))
            _leftMouseEntity.ReplaceMouseDown(mousePosition);
        
        if (Input.GetMouseButton(0))
            _leftMouseEntity.ReplaceMousePosition(mousePosition);
        
        if (Input.GetMouseButtonUp(0))
            _leftMouseEntity.ReplaceMouseUp(mousePosition);
        

        // right mouse button
        if (Input.GetMouseButtonDown(1))
            _rightMouseEntity.ReplaceMouseDown(mousePosition);
        
        if (Input.GetMouseButton(1))
            _rightMouseEntity.ReplaceMousePosition(mousePosition);
        
        if (Input.GetMouseButtonUp(1))
            _rightMouseEntity.ReplaceMouseUp(mousePosition);

        if (Input.GetKey(KeyCode.A))
            _keyboardAEntity.ReplaceKeyboardInput(new Vector2(-1f,0f));
        
        if (Input.GetKey(KeyCode.W))
            _keyboardWEntity.ReplaceKeyboardInput(new Vector2(0f,1f));

        if (Input.GetKey(KeyCode.S))
            _keyboardSEntity.ReplaceKeyboardInput(new Vector2(0f,-1f));
        
        if (Input.GetKey(KeyCode.D))
            _keyboardDEntity.ReplaceKeyboardInput(new Vector2(1f,0f));
        
    }
}
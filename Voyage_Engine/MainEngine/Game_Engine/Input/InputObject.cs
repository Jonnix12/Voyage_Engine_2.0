using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Voyage_Engine.Game_Engine.ComponentSystem;
using Voyage_Engine.Game_Engine.GameObjectSystem;

namespace Voyage_Engine.Game_Engine.InputSystem;

public class InputObject : Component
{
    private MouseState _currentMouseState;
    private bool _isClicked;

    private bool _isHovering;
    private MouseState _previousMouse;


    public Rectangle Rectangle => new Rectangle((int) Transform.Position.X, (int) Transform.Position.Y,
        (int) Transform.Scale.X, (int) Transform.Scale.Y);

    public event Action<GameObject> Click;

    public override void UpdateComponent()
    {
        _previousMouse = _currentMouseState;
        _currentMouseState = Mouse.GetState();

        var mouseRectangle = new Rectangle(_currentMouseState.X, _currentMouseState.Y, 1, 1);

        if (mouseRectangle.Intersects(Rectangle))
        {
            if (!_isHovering) OnTriggerEnter();

            if (_currentMouseState.LeftButton == ButtonState.Released &&
                _previousMouse.LeftButton == ButtonState.Pressed && !_isClicked)
            {
                Click?.Invoke(GameObject);
                _isClicked = true;
            }
        }
        else
        {
            if (_isHovering) OnTriggerExit();
        }
    }

    private void OnTriggerEnter()
    {
        _isClicked = false;
        _isHovering = true;
    }

    private void OnTriggerExit()
    {
        _isHovering = false;
    }
}
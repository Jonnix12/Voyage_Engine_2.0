﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using Voyage_Engine.Game_Engine.ComponentSystem;
using Voyage_Engine.Game_Engine.ComponentSystem.Components;

namespace Voyage_Engine.Game_Engine.InputSystem
{
    public class Button : Component, IDisposable
    {
        private MouseState _currentMouseState;
        private MouseState _previousMouse;


        private bool _isHovering;
        private SpriteRenderer _spriteRenderer;

        public event Action Click;

        public Rectangle Rectangle
        {
            get
            {
                Vector2 offset = new Vector2(_spriteRenderer.Texture2D.Width, _spriteRenderer.Texture2D.Height);
                return new Rectangle((int)Transform.Position.X - (int)offset.X,
                    (int)Transform.Position.Y - (int)offset.Y,
                   _spriteRenderer.Texture2D.Width, _spriteRenderer.Texture2D.Height);
            }
        }

        public Button(SpriteRenderer spriteRenderer)
        {
            _spriteRenderer = spriteRenderer;
        }

        public override void UpdateComponent()
        {
            _previousMouse = _currentMouseState;
            _currentMouseState = Mouse.GetState();

            Rectangle mouseRectangle = new Rectangle(_currentMouseState.X, _currentMouseState.Y, 1, 1);

            if (mouseRectangle.Intersects(Rectangle))
            {
                if (!_isHovering)
                {
                    OnTriggerEnter();
                }

                if (_currentMouseState.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
                {
                    Click?.Invoke();
                }
            }
            else
            {
                if (_isHovering)
                {
                    OnTriggerExit();
                }
            }
        }

        private void OnTriggerEnter()
        {
            _isHovering = true;
        }

        private void OnTriggerExit()
        {
            _isHovering = false;
        }
    }
}
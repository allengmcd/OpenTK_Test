﻿using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Input;
using OpenTK_Test.Common;

namespace OpenTK_Test
{
    public class Window : GameWindow
    {
        private readonly float[] _vertices =
        {
            -0.5f, -0.5f, 0.0f, // Bottom-left vertex
             0.5f, -0.5f, 0.0f, // Bottom-right vertex
             0.0f,  0.5f, 0.0f  // Top vertex
        };

        Level CurrentLevel;

        private int _vertexBufferObject;
        private int _vertexArrayObject;

        private Shader _shader;


        public Window(int width, int height, string title) : base(width, height, GraphicsMode.Default, title) { }


        protected override void OnLoad(EventArgs e)
        {
            CurrentLevel = new Level(1);

            //GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            //_vertexBufferObject = GL.GenBuffer();
            //GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            //GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);
            //_shader = new Shader("Shaders/shader.vert", "Shaders/shader.frag");
            //_shader.Use();
            //_vertexArrayObject = GL.GenVertexArray();
            //GL.BindVertexArray(_vertexArrayObject);
            //GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            //GL.EnableVertexAttribArray(0);
            //GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            base.OnLoad(e);
        }


        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            CurrentLevel.RenderLevel();

            //_shader.Use();
            //GL.BindVertexArray(_vertexArrayObject);
            //GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
            SwapBuffers();
            base.OnRenderFrame(e);
        }


        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            var input = Keyboard.GetState();

            if (input.IsKeyDown(Key.Escape))
            {
                Exit();
            }

            if (input.IsKeyDown(Key.A))
                CurrentLevel.XBase--;
            if (input.IsKeyDown(Key.D))
                CurrentLevel.XBase++;


            base.OnUpdateFrame(e);
        }


        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            base.OnResize(e);
        }



        protected override void OnUnload(EventArgs e)
        {
            CurrentLevel.Unload();
            //GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            //GL.BindVertexArray(0);
            //GL.UseProgram(0);
            //GL.DeleteBuffer(_vertexBufferObject);
            //GL.DeleteVertexArray(_vertexArrayObject);
            //GL.DeleteProgram(_shader.Handle);
            base.OnUnload(e);
        }
    }
}

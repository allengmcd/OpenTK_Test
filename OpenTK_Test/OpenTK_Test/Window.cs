using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Input;
using OpenTK_Test.Common;

namespace OpenTK_Test
{
    public class Window : GameWindow
    {
        Level CurrentLevel;
        Character CurrentCharacter;

        public Window(int width, int height, string title) : base(width, height, GraphicsMode.Default, title) { }


        protected override void OnLoad(EventArgs e)
        {
            CurrentLevel = new Level(20);
            CurrentCharacter = new Character(0.0f, 0.0f);

            base.OnLoad(e);
        }


        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            CurrentLevel.RenderLevel();
            CurrentCharacter.RenderCharacter();
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
            {
                //int temp = CurrentLevel.XBase - 1;
                //CurrentLevel.Unload();
                //base.OnUnload(e);
                CurrentCharacter.LocationX -= 0.005f;
                //CurrentLevel = new Level(temp);
            }
            if (input.IsKeyDown(Key.D))
            {
                //int temp = CurrentLevel.XBase+1;
                //CurrentLevel.Unload();
                //base.OnUnload(e);
                CurrentCharacter.LocationX += 0.005f;
                //CurrentLevel = new Level(temp);
            }
            if (input.IsKeyDown(Key.S))
            {
                //int temp = CurrentLevel.XBase - 1;
                //CurrentLevel.Unload();
                //base.OnUnload(e);
                CurrentCharacter.LocationY -= 0.005f;
               // CurrentLevel = new Level(temp);
            }
            if (input.IsKeyDown(Key.W))
            {
                //int temp = CurrentLevel.XBase + 1;
                //CurrentLevel.Unload();
                //base.OnUnload(e);
                CurrentCharacter.LocationY += 0.005f;
                //CurrentLevel = new Level(temp);
            }


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

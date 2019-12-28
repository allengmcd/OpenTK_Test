using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Input;
using OpenTK_Test.Common;

namespace OpenTK_Test
{
    public class Level
    {
        private readonly float[] _vertices =
        {
            -0.5f, -0.5f, 0.0f, // Bottom-left vertex
             0.5f, -0.5f, 0.0f, // Bottom-right vertex
             0.0f,  0.5f, 0.0f  // Top vertex
        };

        private int counter;

        private int _vertexBufferObject;
        private int _vertexArrayObject;


        private int[] _vertexBufferObjects = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private int[] _vertexArrayObjects = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        private readonly float[] _vertices1 =
        {
            -1.0f, 1f, 0.0f, // Bottom-left vertex
             1.0f, 0.9f, 0.0f, // Bottom-right vertex
             1.0f,  1.0f, 0.0f  // Top vertex
        };
        private readonly float[] _vertices2 =
        {
            -1.0f, 1f, 0.0f, // Bottom-left vertex
             1.0f, 0.9f, 0.0f, // Bottom-right vertex
             -1.0f,  0.9f, 0.0f  // Top vertex
        };
        private readonly float[] _vertices3 =
        {
            -0.5f, -0.5f, 0.0f, // Bottom-left vertex
             0.5f, -0.5f, 0.0f, // Bottom-right vertex
             0.0f,  0.5f, 0.0f  // Top vertex
        };
        private readonly float[] _vertices4 =
        {
            -0.5f, -0.5f, 0.0f, // Bottom-left vertex
             0.5f, -0.5f, 0.0f, // Bottom-right vertex
             0.0f,  0.5f, 0.0f  // Top vertex
        };
        private readonly float[] _vertices5 =
        {
            -0.5f, -0.5f, 0.0f, // Bottom-left vertex
             0.5f, -0.5f, 0.0f, // Bottom-right vertex
             0.0f,  0.5f, 0.0f  // Top vertex
        };
        private readonly float[] _vertices6 =
        {
            -0.5f, -0.5f, 0.0f, // Bottom-left vertex
             0.5f, -0.5f, 0.0f, // Bottom-right vertex
             0.0f,  0.5f, 0.0f  // Top vertex
        };
        private readonly float[] _vertices7 =
        {
            -0.5f, -0.5f, 0.0f, // Bottom-left vertex
             0.5f, -0.5f, 0.0f, // Bottom-right vertex
             0.0f,  0.5f, 0.0f  // Top vertex
        };
        private readonly float[] _vertices8 =
        {
            -0.5f, -0.5f, 0.0f, // Bottom-left vertex
             0.5f, -0.5f, 0.0f, // Bottom-right vertex
             0.0f,  0.5f, 0.0f  // Top vertex
        };

        private Shader _shader;

        public Level(int levelNumber)
        {
            counter = 0;
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

            //for(int i = 0; i < 10; i++)
            //{
            //    float[] tempVertices =
            //    {
            //        -0.1f + (float)(i*0.1f), -0.1f + (float)Math.Sin((double)(counter * 0.01f) + (double)(i)), 0.0f, // Bottom-left vertex
            //         0.1f + (float)(i*0.1f), -0.1f + (float)Math.Sin((double)(counter * 0.01f) + (double)(i)), 0.0f, // Bottom-right vertex
            //         0.0f + (float)(i*0.1f),  0.1f + (float)Math.Sin((double)(counter * 0.01f) + (double)(i)), 0.0f  // Top vertex
            //    };

            //    DrawFrag(ref _vertexBufferObjects[i], ref _vertexArrayObjects[0], tempVertices);
            //}

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
        }

        public void test()
        {
            char[] level = { '*' };

            foreach(char item in level)
            {
                switch(item)
                {
                    case '*':

                        break;

                    default:
                        break;
                }
            }
        }

        void DrawRectangle(float[] topLeft, float[] topRight, float[] botLeft, float[] botRight)
        {
            float[] triangle1 =
            {
                topLeft[0], topLeft[1], 0.0f, // Bottom-left vertex
                botLeft[0], botLeft[1], 0.0f, // Bottom-right vertex
                topRight[0], topRight[1], 0.0f  // Top vertex
            };
            float[] triangle2 =
            {
                topRight[0], topRight[1], 0.0f, // Bottom-left vertex
                botRight[0], botRight[1], 0.0f, // Bottom-right vertex
                botLeft[0],  botLeft[1], 0.0f  // Top vertex
            };

            int a = 0, b = 0;

            DrawFrag(ref a, ref b, triangle1);
            DrawFrag(ref a, ref b, triangle2);

            //  VBO = GL.GenBuffer();
            //    GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            //    GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);
            //    _shader = new Shader("Shaders/shader.vert", "Shaders/shader.frag");
            //    _shader.Use();
            //    VAO = GL.GenVertexArray();
            //    GL.BindVertexArray(VAO);
            //    GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            //    GL.EnableVertexAttribArray(0);
            //    GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            //    GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
        }

        public void DrawFrag(ref int VBO, ref int VAO, float[] vertices)
        {
            VBO = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);
            _shader = new Shader("Shaders/shader.vert", "Shaders/shader.frag");
            _shader.Use();
            VAO = GL.GenVertexArray();
            GL.BindVertexArray(VAO);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
        }

        public void RenderLevel()
        {
            counter++;
            //for (int i = 0; i < 10; i++)
            //{
            //    float[] tempVertices =
            //    {
            //        -0.1f + (float)((i-5)*0.1f), -0.1f + (float)Math.Sin((double)(counter * 0.01f) + (double)(i)), 0.0f, // Bottom-left vertex
            //         0.1f + (float)((i-5)*0.1f), -0.1f + (float)Math.Sin((double)(counter * 0.01f) + (double)(i)), 0.0f, // Bottom-right vertex
            //         0.0f + (float)((i-5)*0.1f),  0.1f + (float)Math.Sin((double)(counter * 0.01f) + (double)(i)), 0.0f  // Top vertex
            //    };

            //    DrawFrag(ref _vertexBufferObjects[i], ref _vertexArrayObjects[0], tempVertices);
            //    //_shader.Use();
            //    //GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObjects[i]);
            //    //GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
            //}
            //GL.BindVertexArray(_vertexArrayObject);
            //GL.DrawArrays(PrimitiveType.Triangles, 0, 3);

            //DrawFrag(ref _vertexBufferObjects[0], ref _vertexArrayObjects[0], _vertices1);
            //DrawFrag(ref _vertexBufferObjects[1], ref _vertexArrayObjects[1], _vertices2);

            //int a = 0, b = 0;

            //DrawFrag(ref a, ref b, _vertices1);
            //DrawFrag(ref a, ref b, _vertices2);
            DrawRectangle(new float[] { -1.0f, 1.0f }, new float[] { 1.0f, 1.0f }, new float[] { -1.0f, 0.9f }, new float[] { 1.0f, 0.9f });
            DrawRectangle(new float[] { -1.0f, 0.9f }, new float[] { -0.9f, 0.9f }, new float[] { -1.0f, -0.9f }, new float[] { -0.9f, -0.9f });
            DrawRectangle(new float[] { 1.0f, 1.0f }, new float[] { 1.0f, 1.0f }, new float[] { 1.0f, 1.0f }, new float[] { 1.0f, 1.0f });
            DrawRectangle(new float[] { 1.0f, 1.0f }, new float[] { 1.0f, 1.0f }, new float[] { 1.0f, 1.0f }, new float[] { 1.0f, 1.0f });
            DrawRectangle(new float[] { 1.0f, 1.0f }, new float[] { 1.0f, 1.0f }, new float[] { 1.0f, 1.0f }, new float[] { 1.0f, 1.0f });
        }

        public void Unload()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
            GL.UseProgram(0);
            GL.DeleteBuffer(_vertexBufferObject);
            GL.DeleteVertexArray(_vertexArrayObject);
            GL.DeleteProgram(_shader.Handle);
        }
    }
}

using OpenTK_Test.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;

namespace OpenTK_Test
{
    public class Character
    {
        public float LocationX { get; set; }
        public float LocationY { get; set; }
        private float width { get; set; }


        private readonly float[] _vertices =
        {
            -0.5f, -0.5f, 0.0f, // Bottom-left vertex
             0.5f, -0.5f, 0.0f, // Bottom-right vertex
             0.0f,  0.5f, 0.0f  // Top vertex
        };


        private int[] _vertexBufferObjects;

        private Shader _shader;


        public Character(float x, float y)
        {
            LocationX = x;
            LocationY = y;
            width = 0.2f;

            _shader = new Shader("Shaders/shader_Character.vert", "Shaders/shader_Character.frag");
            _shader.Use();

            float xUnit = LocationX;
            float yUnit = LocationY;
            float topLeftX = xUnit;
            float topLeftY = yUnit;
            float topRightX = topLeftX + 0.1f;
            float topRightY = topLeftY;
            float botLeftX = topLeftX;
            float botLeftY = topLeftY - 0.1f;
            float botRightX = topLeftX + 0.1f;
            float botRightY = topLeftY - 0.1f;


            float[] triangle1 =
            {
                topLeftX, topLeftY, 0.0f, // Bottom-left vertex
                botLeftX, botLeftY, 0.0f, // Bottom-right vertex
                topRightX, topRightY, 0.0f  // Top vertex
            };
            float[] triangle2 =
            {
                topRightX, topRightY, 0.0f, // Bottom-left vertex
                botRightX, botRightY, 0.0f, // Bottom-right vertex
                botLeftX, botLeftY, 0.0f  // Top vertex
            };

            _vertexBufferObjects = new int[2];

            _vertexBufferObjects[0] = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObjects[0]);
            GL.BufferData(BufferTarget.ArrayBuffer, triangle1.Length * sizeof(float), triangle1, BufferUsageHint.StaticDraw);

            _vertexBufferObjects[1] = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObjects[1]);
            GL.BufferData(BufferTarget.ArrayBuffer, triangle2.Length * sizeof(float), triangle2, BufferUsageHint.StaticDraw);

        }

        public bool checkCollision(Level level)
        {

            return false;
        }

        public void DrawFrag(ref int VBO, float[] vertices)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);
            GL.EnableVertexAttribArray(0);
            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }


        void DrawRectangle(float[] topLeft, float[] topRight, float[] botLeft, float[] botRight, int[] VBO)
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

            DrawFrag(ref VBO[0], triangle1);
            DrawFrag(ref VBO[1], triangle2);
        }

        public void RenderCharacter()
        {
            float xUnit = LocationX;
            float yUnit = LocationY;
            float topLeftX = xUnit;
            float topLeftY = yUnit;
            float topRightX = topLeftX + 0.1f;
            float topRightY = topLeftY;
            float botLeftX = topLeftX;
            float botLeftY = topLeftY - 0.1f;
            float botRightX = topLeftX + 0.1f;
            float botRightY = topLeftY - 0.1f;

            DrawRectangle(new float[] { topLeftX, topLeftY }, new float[] { topRightX, topRightY }, new float[] { botLeftX, botLeftY }, new float[] { botRightX, botRightY }, _vertexBufferObjects);
        }
    }
}

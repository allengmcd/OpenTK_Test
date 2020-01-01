using System;
using System.IO;
using System.Windows.Forms;
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

        private readonly char[][] obstacles;

        private int counter;

        private int[][][] _vertexBufferObjects;
        //private int[][][] _vertexArrayObjects;

        private Shader _shader;

        public int XBase;
        public int XMin;
        public int XMax;

        public Level(int levelNumber)
        {
            XBase = levelNumber;
            XMin = 0;
            counter = 0;
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            _shader = new Shader("Shaders/shader_Level.vert", "Shaders/shader_Level.frag");
            _shader.Use();
            string[] lines = System.IO.File.ReadAllLines($"{System.IO.Path.GetDirectoryName(Application.ExecutablePath)}/Levels/Level1.txt");
            
            obstacles = new char[lines.Length][];
            _vertexBufferObjects = new int[lines.Length][][];

            int lineCounter = 0;
            foreach (string line in lines)
            {
                obstacles[lineCounter] = new char[line.Length];
                obstacles[lineCounter] = line.ToCharArray();

                _vertexBufferObjects[lineCounter] = new int[line.Length][];

                lineCounter++;
            }

            XMax = obstacles[0].Length - 20;

            XBase = XBase < XMin ? 0 : XBase;
            XBase = XBase > XMax ? XMax : XBase;


            Console.WriteLine($"Creating objects at XBase: {XBase}");

            for (int i = 0; i < obstacles.Length; i++)
            {
                for (int j = XBase; j < XBase+20; j++)
                {
                    _vertexBufferObjects[i][j] = new int[2];

                    switch (obstacles[i][j])
                    {
                        case '*':
                            float xUnit = (float)((float)(j - XBase) / 10.0f) - 1;
                            float yUnit = (float)(-((float)i) / 10.0f) + 1;
                            float topLeftX = xUnit;
                            float topLeftY = yUnit;
                            float topRightX = topLeftX + 0.1f;
                            float topRightY = topLeftY;
                            float botLeftX = topLeftX;
                            float botLeftY = topLeftY - 0.1f;
                            float botRightX = topLeftX + 0.1f;
                            float botRightY = topLeftY - 0.1f;


                            int a = 0, b = 0;

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

                            _vertexBufferObjects[i][j][0] = GL.GenBuffer();
                            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObjects[i][j][0]);
                            GL.BufferData(BufferTarget.ArrayBuffer, triangle1.Length * sizeof(float), triangle1, BufferUsageHint.StaticDraw);

                            _vertexBufferObjects[i][j][1] = GL.GenBuffer();
                            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObjects[i][j][1]);
                           GL.BufferData(BufferTarget.ArrayBuffer, triangle2.Length * sizeof(float), triangle2, BufferUsageHint.StaticDraw);

                            break;

                        default:
                            break;
                    }

                }
            }
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

        public void DrawFrag(ref int VBO, float[] vertices)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

        public void RenderLevel()
        {
            counter++;
            for(int i = 0; i < obstacles.Length; i++)
            {
                for(int j = XBase; j < XBase+20; j++)
                {
                    switch (obstacles[i][j])
                    {
                        case '*':
                            float xUnit = (float)((float)(j-XBase) / 10.0f) - 1;
                            float yUnit = (float)(-((float)i) / 10.0f) + 1;
                            float topLeftX = xUnit;
                            float topLeftY = yUnit;
                            float topRightX = topLeftX + 0.1f;
                            float topRightY = topLeftY;
                            float botLeftX = topLeftX;
                            float botLeftY = topLeftY - 0.1f;
                            float botRightX = topLeftX + 0.1f;
                            float botRightY = topLeftY - 0.1f;

                            DrawRectangle(new float[] { topLeftX, topLeftY }, new float[] { topRightX, topRightY }, new float[] { botLeftX, botLeftY }, new float[] { botRightX, botRightY }, _vertexBufferObjects[i][j]);
                            break;

                        default:
                            break;
                    }
                    
                }
            }
        }

        public void Unload()
        {
            Console.WriteLine($"Deleting objects at XBase: {XBase}\n\n\n");
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
            GL.UseProgram(0);
            GL.DeleteProgram(_shader.Handle);

            for (int i = 0; i < obstacles.Length; i++)
            {
                for (int j = XBase; j < XBase + 20; j++)
                {
                    switch (obstacles[i][j])
                    {
                        case '*':
                            GL.DeleteBuffers(2, _vertexBufferObjects[i][j]);
                            //GL.DeleteVertexArrays(2, _vertexArrayObjects[i][j]);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}

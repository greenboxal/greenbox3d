﻿// Shader.cs
// 
// Copyright (c) 2013 The GreenBox Development LLC, all rights reserved
// 
// This file is a proprietary part of GreenBox3D, disclosing the content
// of this file without the owner consent may lead to legal actions
#if DESKTOP

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenBox3D.Graphics;
using GreenBox3D.Graphics.Detail;
using OpenTK.Graphics.OpenGL;

namespace GreenBox3D.Graphics
{
    public class Shader : GraphicsResource
    {
        private readonly ShaderInput[] _input;
        private readonly string _name;
        private readonly ShaderParameterCollection _parameters;
        private readonly int _pixel;
        private readonly int _program;
        private readonly int _vertex;

        public Shader(GraphicsDevice graphicsDevice, CompiledShader shader)
            : base(graphicsDevice)
        {
            int status;

            _name = shader.Name;

            _program = GL.CreateProgram();
            if (_program == -1)
                throw new OpenGLException();

            _vertex = GL.CreateShader(ShaderType.VertexShader);
            if (_vertex == -1)
                throw new OpenGLException();

            GL.ShaderSource(_vertex, shader.GlslVertexCode);
            GL.CompileShader(_vertex);

            GL.GetShader(_vertex, OpenTK.Graphics.OpenGL.ShaderParameter.CompileStatus, out status);
            if (status == 0)
                throw new Exception(GL.GetShaderInfoLog(_vertex));

            _pixel = GL.CreateShader(ShaderType.FragmentShader);
            if (_pixel == -1)
                throw new OpenGLException();

            GL.ShaderSource(_pixel, shader.GlslPixelCode);
            GL.CompileShader(_pixel);

            GL.GetShader(_pixel, OpenTK.Graphics.OpenGL.ShaderParameter.CompileStatus, out status);
            if (status == 0)
                throw new Exception(GL.GetShaderInfoLog(_pixel));

            GL.AttachShader(_program, _vertex);
            GL.AttachShader(_program, _pixel);
            GL.LinkProgram(_program);

            GL.GetProgram(_program, ProgramParameter.LinkStatus, out status);
            if (status == 0)
                throw new Exception(GL.GetProgramInfoLog(_program));

            GL.GetProgram(_program, ProgramParameter.ActiveUniforms, out status);
            ShaderParameter[] parameters = new ShaderParameter[status];

            for (int i = 0; i < status; i++)
                parameters[i] = new ShaderParameter(this, _program, i);

            _input = new ShaderInput[shader.Input.Count];
            for (int i = 0; i < _input.Length; i++)
                _input[i] = new ShaderInput(_program, shader.Input[i]);

            _parameters = new ShaderParameterCollection(parameters);
        }

        internal ShaderInput[] Input
        {
            get { return _input; }
        }

        public string Name
        {
            get { return _name; }
        }

        public ShaderParameterCollection Parameters
        {
            get { return _parameters; }
        }

        public void Apply()
        {
            if (GraphicsDevice.State.ActiveShader == this)
                return;

            GL.UseProgram(_program);
            GraphicsDevice.State.ActiveShader = this;
        }
    }
}

#endif

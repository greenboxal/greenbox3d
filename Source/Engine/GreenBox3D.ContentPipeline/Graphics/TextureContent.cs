﻿// TextureContent.cs
// 
// Copyright (c) 2013 The GreenBox Development LLC, all rights reserved
// 
// This file is a proprietary part of GreenBox3D, disclosing the content
// of this file without the owner consent may lead to legal actions
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenBox3D.Graphics;

namespace GreenBox3D.ContentPipeline.Graphics
{
    public abstract class TextureContent
    {
        protected TextureContent()
        {
            Faces = new TextureFaceCollection();
        }

        public TextureFaceCollection Faces { get; private set; }
        public SurfaceFormat Format { get; set; }
    }
}

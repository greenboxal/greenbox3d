﻿// IContentTypeWriter.cs
// 
// Copyright (c) 2013 The GreenBox Development LLC, all rights reserved
// 
// This file is a proprietary part of GreenBox3D, disclosing the content
// of this file without the owner consent may lead to legal actions
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenBox3D.ContentPipeline.CompilerServices;
using GreenBox3D.ContentPipeline.Writers;

namespace GreenBox3D.ContentPipeline
{
    public interface IContentTypeWriter
    {
        #region Public Methods and Operators

        void Write(BuildCoordinator coordinator, Stream stream, object input);

        #endregion
    }
}

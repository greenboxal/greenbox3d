﻿// BuildCacheEntry.cs
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

namespace GreenBox3D.ContentPipeline.CompilerServices
{
    public class BuildCacheEntry
    {
        public BuildCacheEntry(string filename)
        {
            Filename = filename;
            Dependencies = new List<string>();
            OutputFiles = new List<string>();
            LastBuilt = true;
        }

        public string Filename { get; private set; }
        public DateTime Timestamp { get; set; }
        public List<string> Dependencies { get; private set; }
        public List<string> OutputFiles { get; private set; }
        public bool LastBuilt { get; set; }
    }
}

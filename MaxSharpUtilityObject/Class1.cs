//
// Copyright 2012 Autodesk, Inc.  All rights reserved.
//
// Use of this software is subject to the terms of the Autodesk license
// agreement provided at the time of installation or download, or which
// otherwise accompanies this software in either electronic or hard copy form.  
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Autodesk.Max;

namespace MaxSharpUtilityObj
{
    public class DotNetUtility : Autodesk.Max.Plugins.UtilityObj
    {
        public override void BeginEditParams(IInterface ip, IIUtil iu)
        {
            ip.PushPrompt("Hello Dot Net!");
        }
        public override void EndEditParams(IInterface ip, IIUtil iu)
        {
            ip.PopPrompt();
        }
    }

    public class Descriptor : Autodesk.Max.Plugins.ClassDesc2
    {
        public override string Category
        {
            get { return "MaxSharp Utilities"; }
        }

        public override IClass_ID ClassID
        {
            get { return Loader.Global.Class_ID.Create(0x3990388b, 0x696868d0);  }
        }

        public override string ClassName
        {
            get { return "Silly MaxSharp Utility"; }
        }

        public override object Create(bool loading)
        {
            return new DotNetUtility();
        }

        public override bool IsPublic
        {
            get { return true;  }
        }

        public override SClass_ID SuperClassID
        {
            get { return SClass_ID.Utility; }
        }
    }
    
    public static class Loader
    {
        public static IGlobal Global;
        public static IInterface14 Core;

        public static void AssemblyMain()
        {
            Global = Autodesk.Max.GlobalInterface.Instance;
            Core = Global.COREInterface14;
            Core.AddClass(new Descriptor()); 
        }
    }
}

//
// Copyright 2012 Autodesk, Inc.  All rights reserved.
//
// Use of this software is subject to the terms of the Autodesk license
// agreement provided at the time of installation or download, or which
// otherwise accompanies this software in either electronic or hard copy form.  
//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MaxSharp;
using MaxCustomControls;

namespace MaxSharpDemo
{
    public partial class FormWithEditor : MaxForm
    {
        public FormWithEditor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void WriteLine(string s)
        {
            richTextBox1.AppendText(s + "\n");
        }

        private void PrintNode(Node n, string indent = "")
        {
            WriteLine(indent + n.Name);
            foreach (var c in n.Children)
                PrintNode(c, indent + "  ");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WriteLine("Scene nodes");
            PrintNode(Kernel.Scene.RootNode);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var teapot = Primitives.Teapot.Create(); 
            teapot["radius"] = 20.0; 
            teapot.Node.Move(new Point3(20, 10, 5)); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var cylinder = Primitives.Cylinder.Create();
            cylinder["radius"] = 20.0f;
            cylinder["height"] = 40.0f;
            cylinder["height segments"] = 10;
            var bend = Primitives.Bend.Create();
            cylinder.AddModifier(bend);
            bend["bendangle"] = 30.0f;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            WriteLine("Plug-ins");
            foreach (var p in PluginMgr.Plugins)
                WriteLine(p.ClassName);
        }
    }
}

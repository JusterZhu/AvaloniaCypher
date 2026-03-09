using System;
using System.Drawing;
using System.Linq;
using System.Numerics;
using Aura3D.Avalonia;
using Aura3D.Core;
using Aura3D.Core.Geometries;
using Aura3D.Core.Nodes;
using Aura3D.Core.Resources;
using Aura3D.Model;
using Avalonia.Controls;

namespace LearnAura3D_2;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private Node? node = null;
    private void Aura3DView_OnSceneInitialized(object? sender, InitializedRoutedEventArgs e)
    {
        /*
        var mesh = new Mesh()
        {
            Geometry = new BoxGeometry(),
            Material = new Material()
            {
                BaseColor = Texture.CreateFromColor(Color.Red)
            }
        };

        mesh.Position = e.Scene.MainCamera.Position + e.Scene.MainCamera.Forward * 2;

        node = mesh;
        
        e.Scene.AddNode(mesh);
        

        var (model, animations) = ModelLoader.LoadGlbModelAndAnimations("C:\\Users\\cesun\\Desktop\\新建文件夹\\Soldier.glb");

        model.AnimationSampler = new AnimationSampler(animations[1]);
        
        model.Position = e.Scene.MainCamera.Position + e.Scene.MainCamera.Forward * 2;
        
        model.Scale = Vector3.One * 2;
        
        e.Scene.MainCamera.FitToBoundingBox(model.BoundingBox);
        

        node = model;
        
        e.Scene.AddNode(model);
        */

        var model = AssimpLoader.Load("C:\\Users\\cesun\\Desktop\\新建文件夹\\horse_head_1k.fbx");
        
        
        node = model;
        
        e.Scene.MainCamera.FitToBoundingBox(model.BoundingBox);
        
        e.Scene.AddNode(model);
        
        var dl = new DirectionalLight();
        
        dl.LightColor = Color.AntiqueWhite;

        dl.RotationDegrees = new Vector3(10, -45, 0);
        
        e.Scene.AddNode(dl);
    }

    private void Aura3DView_OnSceneUpdated(object? sender, UpdateRoutedEventArgs e)
    {
        if (node != null)
        {
            node.RotationDegrees = new Vector3(node.RotationDegrees.X, (float)(node.RotationDegrees.Y + 10 * e.DeltaTime), node.RotationDegrees.Z);
        }
    }
}
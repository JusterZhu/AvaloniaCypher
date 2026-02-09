using System.Drawing;
using System.Numerics;
using Aura3D.Avalonia;
using Aura3D.Core.Geometries;
using Aura3D.Core.Nodes;
using Aura3D.Core.Resources;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace LearnAura3D_1;

public partial class MainWindow : Window
{
    private Mesh? _mesh = null;
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Aura3DView_OnSceneInitialized(object? sender, RoutedEventArgs e)
    {
        if (sender is not Aura3DView view)
            return;
        var mesh = new Mesh()
        {
            Geometry = new BoxGeometry(),
            Material = new Material()
            {
                Channels = [
                    new Channel()
                    {
                        Name = "BaseColor",
                        Color = Color.Crimson
                    }
                ]
            }
        };


        var camera = view.MainCamera;

        mesh.Position = camera.Position + camera.Forward * 5;
        
        view.AddNode(mesh);

        var dl = new DirectionalLight();

        dl.RotationDegrees = new Vector3(-30, -30, 0);
        
        view.AddNode(dl);

        _mesh = mesh;

        var mesh2 = new Mesh();

        mesh2.Geometry = new SphereGeometry();

        mesh2.Material = new Material()
        {
            Channels =
            [
                new Channel()
                {
                    Name = "BaseColor",
                    Color = Color.Blue
                }
            ]
        };
        
        mesh.AddChild(mesh2, AttachToParentRule.KeepLocal);

        mesh2.Position = new Vector3(2, 0, 0);
    }

    private void Aura3DView_OnSceneUpdated(object? sender, UpdateRoutedEventArgs e)
    {
        if (_mesh == null)
            return;
        _mesh.RotationDegrees = _mesh.RotationDegrees with { Y = (float)(_mesh.RotationDegrees.Y + (10 * e.DeltaTime)) };
        // throw new System.NotImplementedException();
    }
}
using HarfBuzzSharp;
using Mapsui;
using Mapsui.Layers;
using Mapsui.Projections;
using Mapsui.Styles;
using Mapsui.Tiling;
using Mapsui.UI.Wpf;
using Mapsui.Widgets;
using Mapsui.Widgets.InfoWidgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace Hackathon
{
    /// <summary>
    /// Interaktionslogik für MainWindowMap.xaml
    /// </summary>
    public partial class MainWindowMap : Window
    {
        public MainWindowMap()
        {
            InitializeComponent();

            LoggingWidget.ShowLoggingInMap = ActiveMode.No;           
            MapInitializen();
            mapControl.Map.Widgets.Clear();
        }

        public void MapInitializen()
        {
            Map map = new Map();
            map.Layers.Add(OpenStreetMap.CreateTileLayer());

            mapControl.Map = map;
            var position = SphericalMercator.FromLonLat(9.7415, 47.4125);
            mapControl.Map.Navigator.OverrideZoomBounds = new MMinMax(10, 1000);
            mapControl.Map.Navigator.CenterOn(position.x, position.y);
            mapControl.Map.Navigator.ZoomTo(10);
            var features = new List<IFeature>();

            MapPunkte mapPunkte1 = new MapPunkte(9.7415, 47.4125);
            MapPunkte mapPunkte2 = new MapPunkte(9.2415, 47.0125);
            MapPunkte mapPunkte3 = new MapPunkte(10.415, 48.4125);
            features.Add(mapPunkte1.PunktErstellen());
            features.Add(mapPunkte2.PunktErstellen());
            features.Add(mapPunkte3.PunktErstellen());


            foreach (var f in features)
            {
                f.Styles.Add(new SymbolStyle
                {
                    SymbolScale = 0.3,
                    Fill = new Mapsui.Styles.Brush(new Mapsui.Styles.Color(255, 0, 0))
                });
            }

            var layer = new MemoryLayer
            {
                Features = features,
                Style = null
            };
            mapControl.Map.Layers.Add(layer);
        }
    }
}

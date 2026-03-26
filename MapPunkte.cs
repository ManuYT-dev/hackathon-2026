using Mapsui.Layers;
using Mapsui.Projections;
using Mapsui.Styles;
using Mapsui.UI.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon
{
    public class MapPunkte
    {
        public double lon = 9.7415;
        public double lat = 47.4125;

        public MapPunkte() {}
        public MapPunkte(double lon, double lat) 
        {
            this.lon = lon;
            this.lat = lat;
        }

        public PointFeature PunktErstellen()
        {
            var point = SphericalMercator.FromLonLat(lon, lat);
            PointFeature feature = new PointFeature(point);
            feature.Styles.Add(new SymbolStyle { SymbolType = SymbolType.Ellipse, Fill = new Mapsui.Styles.Brush(new Mapsui.Styles.Color(255, 0, 0)), SymbolScale = 0.3, Outline = new Mapsui.Styles.Pen { Color = new Mapsui.Styles.Color(255, 255, 255, 0), Width = 0 } });
            return feature;
        }

    }
}

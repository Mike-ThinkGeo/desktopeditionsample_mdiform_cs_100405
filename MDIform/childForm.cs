using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThinkGeo.MapSuite.Core;
using ThinkGeo.MapSuite.DesktopEdition;


namespace MDIform
{
    public partial class childForm : Form
    {
        public childForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WinformsMap winformsMap1 = (WinformsMap)this.Parent;
            LayerOverlay layerOverlay = (LayerOverlay)winformsMap1.Overlays["PointOverlay"];
            InMemoryFeatureLayer inMemoryFeatureLayer = (InMemoryFeatureLayer)layerOverlay.Layers[0];

            inMemoryFeatureLayer.Open();
            inMemoryFeatureLayer.EditTools.BeginTransaction();
           
            PointShape pointShape = new PointShape(Convert.ToDouble(txtX.Text),Convert.ToDouble(txtY.Text));
            inMemoryFeatureLayer.EditTools.Add(new Feature(pointShape));
            inMemoryFeatureLayer.EditTools.CommitTransaction();
            inMemoryFeatureLayer.Close();


            winformsMap1.Refresh(layerOverlay);
        }
    }
}

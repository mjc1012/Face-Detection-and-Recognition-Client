using Microsoft.ML.Transforms.Image;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Face_Detection_and_Recognition_Client.Helper_Classes
{

    public class ModelInput
    {
        public byte[] Image { get; set; }

        public UInt32 LabelAsKey { get; set; }

        public string ImagePath { get; set; }

        public string Label { get; set; }
    }

    public class ModelInputTwo
    {
        [ImageType(512, 512)]
        public Bitmap Image { get; set; }

        public string ImagePath { get; set; }

        public string Label { get; set; }

        public UInt32 LabelAsKey { get; set; }
    }

    public class ModelOutput
    {
        public string ImagePath { get; set; }

        public string Label { get; set; }

        public string PredictedLabel { get; set; }

        public float[] Score { get; set; }
    }
}

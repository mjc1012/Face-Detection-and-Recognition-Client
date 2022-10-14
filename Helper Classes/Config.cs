using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Face_Detection_and_Recognition_Client.Helper_Classes
{
    public static class Config
    {
        public static string FacePhotosPath = @"C:\Users\tsg\Documents\Face Recongition Thesis\thesis version 2\Face Dataset\";
        public static string ImageFileExtension = ".jpg";
        public static string projectDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../"));
        public static string configFile = Path.Combine(projectDirectory, @"Face Detection Model\deploy.prototxt.txt"); 
        public static string faceModel = Path.Combine(projectDirectory, @"Face Detection Model\res10_300x300_ssd_iter_140000_fp16.caffemodel");
        
        
        public static string resnetV250ColoredPredictionEnginePath = Path.Combine(projectDirectory, @"Face Recognition Models\ResnetV250Colored.zip");
        public static string resnetV2101ColoredPredictionEnginePath = Path.Combine(projectDirectory, @"Face Recognition Models\ResnetV2101Colored.zip");
        public static string inceptionV3ColoredPredictionEnginePath = Path.Combine(projectDirectory, @"Face Recognition Models\InceptionV3Colored.zip");
        public static string mobilenetV2ColoredPredictionEnginePath = Path.Combine(projectDirectory, @"Face Recognition Models\MobilenetV2Colored.zip");
        
        public static string resnetV250GrayscalePredictionEnginePath = Path.Combine(projectDirectory, @"Face Recognition Models\ResnetV250Grayscale.zip");
        public static string resnetV2101GrayscalePredictionEnginePath = Path.Combine(projectDirectory, @"Face Recognition Models\ResnetV2101Grayscale.zip");
        public static string inceptionV3GrayscalePredictionEnginePath = Path.Combine(projectDirectory, @"Face Recognition Models\InceptionV3Grayscale.zip");
        public static string mobilenetV2GrayscalePredictionEnginePath = Path.Combine(projectDirectory, @"Face Recognition Models\MobilenetV2Grayscale.zip");

    }
}


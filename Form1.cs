using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Face;
using OpenCvSharp.Dnn;
using OpenCvSharp.Extensions;
using Point = OpenCvSharp.Point;
using Size = OpenCvSharp.Size;
using Microsoft.ML.Data;
using Microsoft.ML.Vision;
using Microsoft.ML;
using Face_Detection_and_Recognition_Client.Helper_Classes;
using Microsoft.ML.Transforms.Image;
using AForge.Imaging.Filters;

namespace Face_Detection_and_Recognition_Client
{
    

    public partial class Form1 : Form
    {
        VideoCapture videoCapture;
        Mat image;
        Mat imageToSave = new Mat();
        Thread cameraThread;
        Net faceNet;
        bool fps = false;
        bool EnableSaveImage = false;
        bool runCamera = false;
        bool doFaceDetection = false;

        
        bool useResnetV250Colored = false;
        bool useResnetV2101Colored = false;
        bool useInceptionV3Colored = false;
        bool useMobilenetV2Colored = false;
        
        bool useResnetV250Grayscale = false;
        bool useResnetV2101Grayscale = false;
        bool useInceptionV3Grayscale = false;
        bool useMobilenetV2Grayscale = false;
        
        MLContext mlContext = new MLContext();
        private static PredictionEngine<ModelInput, ModelOutput> resnetV250ColoredPredictionEngine;
        private static PredictionEngine<ModelInput, ModelOutput> resnetV2101ColoredPredictionEngine;
        private static PredictionEngine<ModelInput, ModelOutput> inceptionV3ColoredPredictionEngine;
        private static PredictionEngine<ModelInput, ModelOutput> mobilenetV2ColoredPredictionEngine;

        private static PredictionEngine<ModelInput, ModelOutput> resnetV250GrayscalePredictionEngine;
        private static PredictionEngine<ModelInput, ModelOutput> resnetV2101GrayscalePredictionEngine;
        private static PredictionEngine<ModelInput, ModelOutput> inceptionV3GrayscalePredictionEngine;
        private static PredictionEngine<ModelInput, ModelOutput> mobilenetV2GrayscalePredictionEngine;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            faceNet = CvDnn.ReadNetFromCaffe(Config.configFile, Config.faceModel);
            
            DataViewSchema[] modelSchema = new DataViewSchema[12];
            //resnetV250ColoredPredictionEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlContext.Model.Load(Config.resnetV250ColoredPredictionEnginePath, out modelSchema[0]));
            //resnetV2101ColoredPredictionEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlContext.Model.Load(Config.resnetV2101ColoredPredictionEnginePath, out modelSchema[1]));
            //inceptionV3ColoredPredictionEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlContext.Model.Load(Config.inceptionV3ColoredPredictionEnginePath, out modelSchema[2]));
            //mobilenetV2ColoredPredictionEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlContext.Model.Load(Config.mobilenetV2ColoredPredictionEnginePath, out modelSchema[3]));
            
            //resnetV250GrayscalePredictionEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlContext.Model.Load(Config.resnetV250GrayscalePredictionEnginePath, out modelSchema[0]));
            //resnetV2101GrayscalePredictionEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlContext.Model.Load(Config.resnetV2101GrayscalePredictionEnginePath, out modelSchema[1]));
            //inceptionV3GrayscalePredictionEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlContext.Model.Load(Config.inceptionV3GrayscalePredictionEnginePath, out modelSchema[2]));
            mobilenetV2GrayscalePredictionEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlContext.Model.Load(Config.mobilenetV2GrayscalePredictionEnginePath, out modelSchema[3]));
        }

        private static ModelOutput ClassifyUploadededImage(Mat image, PredictionEngine<ModelInput, ModelOutput> predictionEngine)
        {
            ModelInput faceData = new ModelInput()
            {
                Image = image.ToBytes(),
            };

            ModelOutput prediction = predictionEngine.Predict(faceData);
            return prediction;
        }

        private static ModelOutput ClassifyUploadededImageTwo(Mat image, PredictionEngine<ModelInputTwo, ModelOutput> predictionEngine)
        {
            ModelInputTwo faceData = new ModelInputTwo()
            {
                Image = image.ToBitmap(),
            };

            ModelOutput prediction = predictionEngine.Predict(faceData);
            return prediction;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(cameraThread != null) cameraThread.Interrupt();
            if (videoCapture != null && !videoCapture.IsDisposed) videoCapture.Dispose();
        }

        private void btnOpenCamera_Click(object sender, EventArgs e)
        {
            if (videoCapture != null) videoCapture.Dispose();
            videoCapture = new VideoCapture(0);
            image = new Mat();
            cameraThread = new Thread(new ThreadStart(CaptureCameraCallback));
            cameraThread.Start();
            runCamera = true;
        }

        private void CaptureCameraCallback()
        {
            while (runCamera && videoCapture != null && !videoCapture.IsDisposed)
            {
                var startTime = DateTime.Now;

                videoCapture.Read(image);
                if (image.Empty()) return;
                var newImage = new Mat();
                Cv2.Resize(image, newImage, new Size(320, 240));
                if (doFaceDetection)
                {
                    int frameHeight = newImage.Rows;
                    int frameWidth = newImage.Cols;

                    var blob = CvDnn.BlobFromImage(newImage, 1.0, new Size(300, 300),
                        new Scalar(104, 117, 123), false, false);
                    faceNet.SetInput(blob, "data");

                    var detection = faceNet.Forward("detection_out");
                    var detectionMat = new Mat(detection.Size(2), detection.Size(3), MatType.CV_32F,
                        detection.Ptr(0));
                    for (int i = 0; i < detectionMat.Rows; i++)
                    {
                        float detectionConfidence = detectionMat.At<float>(i, 2);

                        if (detectionConfidence > 0.7)
                        {
                            int x1 = (int)(detectionMat.At<float>(i, 3) * frameWidth);
                            int y1 = (int)(detectionMat.At<float>(i, 4) * frameHeight);
                            int x2 = (int)(detectionMat.At<float>(i, 5) * frameWidth);
                            int y2 = (int)(detectionMat.At<float>(i, 6) * frameHeight);

                            Rect roi = new Rect(x1, y1, x2 - x1, y2 - y1);
                            //Assign the face to the picture Box face pictureBox1
                            if (0 <= x1 && 0 <= x2 - x1 && x1 + (x2 - x1) <= frameWidth && 0 <= y1 && 0 <= y2 - y1 && y1 + (y2 - y1) <= frameHeight)
                            {
                                
                                var detectedFace = newImage.Clone(roi);
                                Cv2.Rectangle(newImage, new Point(x1, y1), new Point(x2, y2), Scalar.Green, 2);
                                Cv2.Resize(detectedFace, detectedFace, new Size(224, 224));

                                if (EnableSaveImage)
                                {
                                    if (detectedFace == null)
                                    {
                                        MessageBox.Show("No face detected.");
                                        return;
                                    }

                                    if (!Directory.Exists(Config.FacePhotosPath + txtPersonName.Text)) System.IO.Directory.CreateDirectory(Config.FacePhotosPath + txtPersonName.Text);

                                    int count = 0;
                                    if (Directory.EnumerateFileSystemEntries(Config.FacePhotosPath + txtPersonName.Text).Any())
                                    {
                                        var directory = new DirectoryInfo(Config.FacePhotosPath + txtPersonName.Text);
                                        var latestFile = directory.GetFiles().OrderByDescending(f => f.LastWriteTime).First();
                                        var filename = latestFile.Name;
                                        count = Int32.Parse(filename.Split('.')[0]) + 1;
                                    }

                                    //Save detected face
                                    Cv2.Resize(detectedFace, imageToSave, new Size(224, 224));
                                    imageToSave.SaveImage(Config.FacePhotosPath + txtPersonName.Text + "\\" + count + Config.ImageFileExtension);
                                    picSaved.Image = imageToSave.ToBitmap();
                                    picSaved.SizeMode = PictureBoxSizeMode.StretchImage;
                                    label1.Invoke((MethodInvoker)(() => label1.Text = "Save Image"));
                                }
                                EnableSaveImage = false;

                                ModelOutput prediction = null;

                                detectedFace = sharpenImage(detectedFace.ToBitmap());
                                if (useResnetV250Colored)
                                {
                                    detectedFace = histogramEqualizationColored(detectedFace.ToBitmap());
                                    prediction = ClassifyUploadededImage(detectedFace, resnetV250ColoredPredictionEngine);
                                }
                                else if (useResnetV2101Colored)
                                {
                                    detectedFace = histogramEqualizationColored(detectedFace.ToBitmap());
                                    prediction = ClassifyUploadededImage(detectedFace, resnetV2101ColoredPredictionEngine);
                                }
                                else if (useInceptionV3Colored)
                                {
                                    detectedFace = histogramEqualizationColored(detectedFace.ToBitmap());
                                    prediction = ClassifyUploadededImage(detectedFace, inceptionV3ColoredPredictionEngine);
                                }
                                else if (useMobilenetV2Colored)
                                {
                                    detectedFace = histogramEqualizationColored(detectedFace.ToBitmap());
                                    prediction = ClassifyUploadededImage(detectedFace, mobilenetV2ColoredPredictionEngine);
                                }
                                else if (useResnetV250Grayscale)
                                {
                                    detectedFace = toGrayscale(detectedFace.ToBitmap());
                                    detectedFace = histogramEqualizationGrayscale(detectedFace);
                                    prediction = ClassifyUploadededImage(detectedFace, resnetV250GrayscalePredictionEngine);
                                }
                                else if (useResnetV2101Grayscale)
                                {
                                    detectedFace = toGrayscale(detectedFace.ToBitmap());
                                    detectedFace = histogramEqualizationGrayscale(detectedFace);
                                    prediction = ClassifyUploadededImage(detectedFace, resnetV2101GrayscalePredictionEngine);
                                }
                                else if (useInceptionV3Grayscale)
                                {
                                    detectedFace = toGrayscale(detectedFace.ToBitmap());
                                    detectedFace = histogramEqualizationGrayscale(detectedFace);
                                    prediction = ClassifyUploadededImage(detectedFace, inceptionV3GrayscalePredictionEngine);
                                }
                                else if (useMobilenetV2Grayscale)
                                {
                                    detectedFace = toGrayscale(detectedFace.ToBitmap());
                                    detectedFace = histogramEqualizationGrayscale(detectedFace);
                                    prediction = ClassifyUploadededImage(detectedFace, mobilenetV2GrayscalePredictionEngine);
                                }

                                
                                if ((useResnetV250Colored || useResnetV2101Colored || useInceptionV3Colored || useMobilenetV2Colored ||
                                    useResnetV250Grayscale || useResnetV2101Grayscale || useInceptionV3Grayscale || useMobilenetV2Grayscale)  && prediction.Score.Max() > 0.7)
                                {
                                    Cv2.PutText(newImage, prediction.PredictedLabel + " " + String.Format("{0:0.00}%", prediction.Score.Max() * 100), new Point(x1 - 40, y2 + 20),
                                        HersheyFonts.HersheyComplexSmall, 1, Scalar.Orange, 2);
                                }
                                else
                                {
                                    Cv2.PutText(newImage, "Face Detected: " + String.Format("{0:0.00}%", detectionConfidence * 100), new Point(x1 - 60, y2 + 20),
                                  HersheyFonts.HersheyComplexSmall, 1, Scalar.Green, 2);
                                }
                            }
                        }
                    }

                }

                if (fps)
                {
                    var diff = DateTime.Now - startTime;
                    var fpsInfo = $"FPS: Nan";
                    if (diff.Milliseconds > 0)
                    {
                        var fpsVal = 1.0 / diff.Milliseconds * 1000;
                        fpsInfo = $"FPS: {fpsVal:00}";
                    }
                    Cv2.PutText(newImage, fpsInfo, new Point(10, 20), HersheyFonts.HersheyComplexSmall, 1, Scalar.Orange);
                }

                var bmpEffect = BitmapConverter.ToBitmap(newImage);

                picVideoCapture.Image = bmpEffect;
            }
        }

        private void btnStopCamera_Click(object sender, EventArgs e)
        {
            runCamera = false;
            cameraThread.Interrupt();
            videoCapture.Release();
        }

        private void btnDetectFace_Click(object sender, EventArgs e)
        {
            doFaceDetection = !doFaceDetection;
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            EnableSaveImage = true;
        }

        private void btnFPS_Click(object sender, EventArgs e)
        {
            fps = !fps;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelImages.Controls.Clear();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "JPG|*.jpg|JPEG|*.jpeg|PNG|*.png";
            DialogResult dr = ofd.ShowDialog();
            if(dr == DialogResult.OK)
            {
                string[] files = ofd.FileNames;
                int x = 1;
                int y = 1;
                int maxHeight = -1;
                foreach(string file in files)
                {
                    Mat newImage = new Mat(file);
                    int frameHeight = newImage.Rows;
                    int frameWidth = newImage.Cols;

                    var blob = CvDnn.BlobFromImage(newImage, 1.0, new Size(300, 300),
                        new Scalar(104, 117, 123), false, false);

                    faceNet.SetInput(blob, "data");

                    var detection = faceNet.Forward("detection_out");
                    var detectionMat = new Mat(detection.Size(2), detection.Size(3), MatType.CV_32F,
                        detection.Ptr(0));
                    for (int i = 0; i < detectionMat.Rows; i++)
                    {
                        float confidence = detectionMat.At<float>(i, 2);

                        if (confidence > 0.7)
                        {
                            int x1 = (int)(detectionMat.At<float>(i, 3) * frameWidth);
                            int y1 = (int)(detectionMat.At<float>(i, 4) * frameHeight);
                            int x2 = (int)(detectionMat.At<float>(i, 5) * frameWidth);
                            int y2 = (int)(detectionMat.At<float>(i, 6) * frameHeight);

                            Rect roi = new Rect(x1, y1, x2 - x1, y2 - y1);
                            //Assign the face to the picture Box face pictureBox1
                            if (0 <= x1 && 0 <= x2 - x1 && x1 + (x2 - x1) <= frameWidth && 0 <= y1 && 0 <= y2 - y1 && y1 + (y2 - y1) <= frameHeight)
                            {
                                var detectedFace = newImage.Clone(roi);

                                if(!Directory.Exists(Config.FacePhotosPath + txtPersonName.Text)) System.IO.Directory.CreateDirectory(Config.FacePhotosPath + txtPersonName.Text);

                                int count = 0;
                                if (Directory.EnumerateFileSystemEntries(Config.FacePhotosPath + txtPersonName.Text).Any())
                                {
                                    var directory = new DirectoryInfo(Config.FacePhotosPath + txtPersonName.Text);
                                    var latestFile = directory.GetFiles().OrderByDescending(f => f.LastWriteTime).First();
                                    var filename = latestFile.Name;
                                    count = Int32.Parse(filename.Split('.')[0]) + 1;
                                }

                                //Save detected face
                                Cv2.Resize(detectedFace, imageToSave, new Size(224, 224));
                                imageToSave.SaveImage(Config.FacePhotosPath + txtPersonName.Text + "\\" + count + Config.ImageFileExtension);
                            }
                        }
                    }


                    PictureBox pic = new PictureBox();
                    pic.Image = imageToSave.ToBitmap();
                    pic.Size = new System.Drawing.Size(100, 100);
                    pic.Location = new System.Drawing.Point(x, y);
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    x += pic.Width + 5;
                    maxHeight = Math.Max(pic.Height, maxHeight);
                    if (x > this.panelImages.Width - pic.Width)
                    {
                        x = 1;
                        y += maxHeight + 5;
                    }
                    this.panelImages.Controls.Add(pic);
                }
                label2.Text = "Image/s Saved";
            }
        }

        public static Mat toGrayscale(Bitmap image)
        {
            Grayscale filter = new Grayscale(0.2125, 0.7154, 0.0721);
            return filter.Apply(image).ToMat();
        }

        public static Mat histogramEqualizationGrayscale(Mat image)
        {
            Cv2.EqualizeHist(image, image);
            return image;
        }

        public static Mat histogramEqualizationColored(Bitmap image)
        {
            HistogramEqualization filter = new HistogramEqualization();
            filter.ApplyInPlace(image);
            return image.ToMat();
        }

        public static Mat sharpenImage(Bitmap image)
        {
            GaussianSharpen filter = new GaussianSharpen(4, 11);
            return filter.Apply(image).ToMat();
        }


        private void btnUseEigenFace_Click(object sender, EventArgs e)
        {
            useResnetV250Colored = false;
            useResnetV2101Colored = false;
            useInceptionV3Colored = false;
            useMobilenetV2Colored = false;
            useResnetV250Grayscale = false;
            useResnetV2101Grayscale = !useResnetV2101Grayscale;
            useInceptionV3Grayscale = false;
            useMobilenetV2Grayscale = false;
        }

        private void btnUseFisherFace_Click(object sender, EventArgs e)
        {
            useResnetV250Colored = false;
            useResnetV2101Colored = false;
            useInceptionV3Colored = false;
            useMobilenetV2Colored = false;
            useResnetV250Grayscale = !useResnetV250Grayscale;
            useResnetV2101Grayscale = false;
            useInceptionV3Grayscale = false;
            useMobilenetV2Grayscale = false;
        }

        private void btnUseLBPH_Click(object sender, EventArgs e)
        {
            useResnetV250Colored = false;
            useResnetV2101Colored = false;
            useInceptionV3Colored = false;
            useMobilenetV2Colored = false;
            useResnetV250Grayscale = false;
            useResnetV2101Grayscale = false;
            useInceptionV3Grayscale = false;
            useMobilenetV2Grayscale = !useMobilenetV2Grayscale;
        }

        private void btnUseResnetV250_Click(object sender, EventArgs e)
        {
            
            useResnetV250Colored = !useResnetV250Colored;
            useResnetV2101Colored = false;
            useInceptionV3Colored = false;
            useMobilenetV2Colored = false;
            useResnetV250Grayscale =  false;
            useResnetV2101Grayscale = false;
            useInceptionV3Grayscale = false;
            useMobilenetV2Grayscale = false;
        }

        private void btnUseResnetV2101_Click(object sender, EventArgs e)
        {
            useResnetV250Colored = false;
            useResnetV2101Colored = !useResnetV2101Colored;
            useInceptionV3Colored = false;
            useMobilenetV2Colored = false;
            useResnetV250Grayscale = false;
            useResnetV2101Grayscale = false;
            useInceptionV3Grayscale = false;
            useMobilenetV2Grayscale = false;
        }

        private void btnUseInceptionV3_Click(object sender, EventArgs e)
        {
            useResnetV250Colored = false;
            useResnetV2101Colored = false;
            useInceptionV3Colored = !useInceptionV3Colored;
            useMobilenetV2Colored = false;
            useResnetV250Grayscale = false;
            useResnetV2101Grayscale = false;
            useInceptionV3Grayscale = false ;
            useMobilenetV2Grayscale = false;
        }

        private void btnUseMobilenetV2_Click(object sender, EventArgs e)
        {
            useResnetV250Colored = false;
            useResnetV2101Colored = false;
            useInceptionV3Colored = false;
            useMobilenetV2Colored = !useMobilenetV2Colored;
            useResnetV250Grayscale = false;
            useResnetV2101Grayscale = false;
            useInceptionV3Grayscale = false;
            useMobilenetV2Grayscale = false;
        }

        private void btnInceptionV3LbfgsMaximumEntropy_Click(object sender, EventArgs e)
        {
            
        }

        private void btnResNet18LbfgsMaximumEntropy_Click(object sender, EventArgs e)
        {
            
        }

        private void btnInceptionV3SdcaMaximumEntropy_Click(object sender, EventArgs e)
        {
            useResnetV250Colored = false;
            useResnetV2101Colored = false;
            useInceptionV3Colored = false;
            useMobilenetV2Colored = false;
            useResnetV250Grayscale = false;
            useResnetV2101Grayscale = false;
            useInceptionV3Grayscale = !useInceptionV3Grayscale;
            useMobilenetV2Grayscale = false;
        }

        private void btnResNet18SdcaMaximumEntropy_Click(object sender, EventArgs e)
        {
           
        }

        private void btnInceptionV3SdcaNonCalibrated_Click(object sender, EventArgs e)
        {
            
        }

        private void btnResNet18SdcaNonCalibrated_Click(object sender, EventArgs e)
        {
            
        }

        private void btnInceptionV3LightGbmTrainer_Click(object sender, EventArgs e)
        {
           
        }

        private void btnResNet18LightGbmTrainer_Click(object sender, EventArgs e)
        {
          
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panelImages_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

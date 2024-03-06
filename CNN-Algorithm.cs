using System;
using System.Drawing;
using TensorFlow;
using TensorFlow.Image;
using TensorFlow.NN;
using TensorFlow.NN.Functions;
using TensorFlow.NN.Layers;
using TensorFlow.NN.Pooling;
using TensorFlow.NN.Activation;
using TensorFlow.NN.Convolution;
using TensorFlow.NN.DataTypes;
using TensorFlow.NN.IO;
class Program
{
    static void Main()
    {
        var kernel = new TFTensor(new float[,,] {
{ { -1, -1, -1 },
{ -1, 8, -1 },
{ -1, -1, -1 } }});
        var imageBytes = System.IO.File.ReadAllBytes("RealTime.jpg");
        var image = TFImage.DecodeJpeg(imageBytes, 1);
        image = TFImage.Resize(image, new int[] { 300, 300 });
        var img = image.ToArray<float>();
        var imageFloat = TF.Cast(image, TFDataType.Float);
        imageFloat = TF.ExpandDims(imageFloat, 0);
        kernel = TF.Reshape(kernel, new
        TFShape(kernel.Shape.Dimensions.Append(1).Append(1)));
        kernel = TF.Cast(kernel, TFDataType.Float);
        var imageFilter = TF.Conv2D(
        input: imageFloat,
        filter: kernel,
        strides: new int[] { 1, 1 },
        padding: "SAME");
        var imageDetect = TF.Relu(imageFilter);
        var imageCondense = TF.Pool(
        input: imageDetect,
        windowShape: new int[] { 2, 2 },
        poolingType: PoolingType.Max,
        strides: new int[] { 2, 2 },
        padding: "SAME");
// Display images or further processing here}}
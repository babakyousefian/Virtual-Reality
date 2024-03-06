using System;
using System.Drawing;
using Accord.Imaging;
using Accord.Imaging.Filters;
// Assuming 'Real_Time.jpeg' is in the project directory or specify the full path
string imagePath = "RealTime.jpeg";
Bitmap image = new Bitmap(imagePath);
// Resize the image
ResizeBilinear resizeFilter = new ResizeBilinear(128, 64);
Bitmap resizedImage = resizeFilter.Apply(image);
// Extract HOG features
HistogramsOfOrientedGradients hog = new HistogramsOfOrientedGradients()
{
    NumberOfBins = 9,
    CellSize = new Size(8, 8),
    BlockSize = new Size(2, 2),
    Normalize = true,
};
double[] features = hog.Compute(resizedImage);
Console.WriteLine("\n\nShape of Image Features\n\n");
Console.WriteLine(features.Length);
// Displaying the images and HOG visualization is not as straightforward in C#.
// Typically, you would use a Windows Forms or WPF application to display images.
// For console applications, consider saving the images to disk or using an external
library for visualization.
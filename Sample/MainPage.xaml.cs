using System.ComponentModel;
using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms.ImagePicker;
using System.Drawing;
using System.Text;

namespace Sample
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        IImagePickerService _imagePickerService;
        private object carName;
        public IList<Cars> Cars { get; private set; }

        public MainPage()
        {
            _imagePickerService = DependencyService.Get<IImagePickerService>();
            InitializeComponent();

            // Cars
            Cars = new List<Cars>();
            Cars.Add(new Cars
            {
                //Id = 0,
                Name = "Chevrolet Corvette C8",
                Location = "U.S.A",
                ImageUrl = "Chevrolet Corvette C8.jpg"

            }); ;

            Cars.Add(new Cars
            {
                //Id = 1,
                Name = "Audi Q8",
                Location = "NA",
                ImageUrl = "Audi Q8.jpg"
            });

            Cars.Add(new Cars
            {
                //Id = 2,
                Name = "Toyota Supra",
                Location = "NA",
                ImageUrl = "Toyota Supra.jpg"
            });

            Cars.Add(new Cars
            {
                //Id = 3,
                Name = "Tesla Model 3 Performance",
                Location = "U.S.A",
                ImageUrl = "Tesla Model 3 Performance.jpg"
            });

            //Cars.Add(new Cars
            //{

            //    Name = "Image added 1",
            //    Location = "NA",
            //    ImageUrl = "Tesla Model 3 Performance.jpg"
            //});

            //Cars.Add(new Cars
            //{

            //    Name = "Image added 2",
            //    Location = "NA",
            //    ImageUrl = "Tesla Model 3 Performance.jpg"
            //});


            BindingContext = this;
        }

        int count = 0;
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            count++;
            ((Button)sender).Text = $"You clicked {count} times.";
        }

        async void OnNextPageButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MyPage(Cars));
            //await Navigation.PushAsync(new Details(Cars[i].Name, Cars[i].Location, Cars[i].ImageUrl, i));
        }

        //async void ButtonClicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new Details());
        //}


        // Image picker
        //async void Button_Clicked(object sender, System.EventArgs e)
        //{
        //    var imageSource = await _imagePickerService.PickImageAsync();

        //    if (imageSource != null) // it will be null when user cancel
        //    {
        //        Console.WriteLine(imageSource);
        //        //image.Source = imageSource;
        //    }
        //}


            // good 5
        public int numberOfImages = 5;
        async void OnPickPhotoButtonClicked(object sender, EventArgs e)
        {
            (sender as Button).IsEnabled = false;

            Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();

            Stream displayStream = stream;
            
            byte[] result;
       
            using (var streamReader = new MemoryStream())
            {
                displayStream.CopyTo(streamReader);
                result = streamReader.ToArray();
            }
            Console.WriteLine("RESULT");
            Console.WriteLine(result);
            //Console.ReadLine("RESULT");

        
        
            string photoname = "Foo" + numberOfImages + ".txt";
            //string photoname = "Foo3.txt";
            File.WriteAllBytes(photoname, result);


            string name = "Ulises";
            //string converted = Encoding.UTF8.GetString(result, 0, result.Length);
            string filex = string.Format("{0},{1}", name, photoname);


            Application.Current.Properties[name] = photoname;
            await Application.Current.SavePropertiesAsync();
            

            var bytos = File.ReadAllBytes(photoname);
            Stream streamx = new MemoryStream(bytos);


            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var filename = Path.Combine(documents, "myImage.txt");
            File.WriteAllText(filename, filex);


            //Cars.Add(new Cars
            //{
            //    //Id = 3,
            //    Name = "cool car",
            //    Location = "somewhere",
            //    ImageUrl = ImageSource.FromStream(() => streamx)
            //});

            ////adding Others!////////
            // Retrieve information
            var documentx = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var filenamex = Path.Combine(documentx, "myImage.txt");
            var texteo = File.ReadAllText(filenamex);
            string[] line = texteo.Split(',');

            // Gets file name with photo bytes
            var number = "Foo" + (numberOfImages).ToString() + ".txt";
            var answer = Application.Current.Properties["Ulises"];


            // Decodes byte into a stream
            var bytox = File.ReadAllBytes("Foo" + (numberOfImages).ToString() + ".txt");
            Stream streamy = new MemoryStream(bytox);

            Cars.Add(new Cars
            {
                //Id = 3,
                Name = line[0],
                Location = line[1],
                ImageUrl = ImageSource.FromStream(() => streamy)
            });



            Console.WriteLine(Cars);


            if (stream != null)
            {


                image.Source = ImageSource.FromStream(() => streamx);

                // Storing image!!
                //var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                //documentsPath = Path.Combine(documentsPath, "Orders", "Resources");
                //Directory.CreateDirectory(documentsPath);

                //string filePath = Path.Combine(documentsPath, "photo.jpg");

                //byte[] bArray = new byte[stream.Length];
                //using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
                //{
                //    using (stream)
                //    {
                //        stream.Read(bArray, 0, (int)stream.Length);
                //    }
                //    int length = bArray.Length;
                //    fs.Write(bArray, 0, length);
                //}

            }
            numberOfImages= numberOfImages + 1;
            (sender as Button).IsEnabled = true;
        }





        public static byte[] ReadToEnd(System.IO.Stream stream)
        {
            long originalPosition = 0;

            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try
            {
                byte[] readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            byte[] temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
        }

    }
}

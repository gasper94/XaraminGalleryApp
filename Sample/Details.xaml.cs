using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace Sample
{
    public partial class Details : ContentPage
    {
        private string name;
        private string location;
        private string imageUrl;
        private int idx;

        public Details(string name, string location,ImageSource image, int id)
        {
            
            InitializeComponent();

            //string helll = "hellos";
       
            //// Retrieve information
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var filename = Path.Combine(documents, "myImage.txt");
            var texteo = File.ReadAllText(filename);
            string[] line = texteo.Split(',');

            //Console.WriteLine(line[0]);
            //Console.WriteLine(line[1]);

            //byte[] bytes = Encoding.ASCII.GetBytes(line[0]);
            //Stream streamx = new MemoryStream(bytes);


            //for (int i = 0; i < Cars.Count; i++) // Loop through List with for
            //{
            //    //Console.WriteLine(Cars[i].ImageUrl);
            //    var image = new Image { Source = Cars[i].ImageUrl };
            //}


            if (id < 4)
            {
                title.Text = name;
                title2.Text = location;

                // Display image using stream
                photo.Source = image;

            }
            else
            {
               

                // Gets file name with photo bytes
                var number = "Foo" + (id + 5).ToString() + ".txt";
                var answer = Application.Current.Properties["Ulises"];


                // Decodes byte into a stream
                var bytos = File.ReadAllBytes("Foo" + (id + 1).ToString() + ".txt");
                Stream streamx = new MemoryStream(bytos);

                title.Text = number;
                title2.Text = line[1];

                // Display image using stream
                photo.Source = ImageSource.FromStream(() => streamx);
            }

        }
    }
}

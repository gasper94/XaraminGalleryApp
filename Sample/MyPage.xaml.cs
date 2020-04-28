using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;

namespace Sample
{
    public partial class MyPage : ContentPage
    {
        private object carName;
        public IList<Cars> Cars { get; private set; }

        public MyPage(IList<Cars> Cars2)
        {
            InitializeComponent();

            // Cars 2
            Cars = Cars2;

            //Cars
            //Cars = new List<Cars>();

            //Cars.Add(new Cars
            //{
            //    //Id = 0,
            //    Name = "Chevrolet Corvette C8",
            //    Location = "U.S.A",
            //    ImageUrl = "Chevrolet Corvette C8.jpg"

            //}); ;

            //Cars.Add(new Cars
            //{
            //    //Id = 1,
            //    Name = "Audi Q8",
            //    Location = "NA",
            //    ImageUrl = "Audi Q8.jpg"
            //});

            //Cars.Add(new Cars
            //{
            //    //Id = 2,
            //    Name = "Toyota Supra",
            //    Location = "NA",
            //    ImageUrl = "Toyota Supra.jpg"
            //});

            //Cars.Add(new Cars
            //{
            //    //Id = 3,
            //    Name = "Tesla Model 3 Performance",
            //    Location = "U.S.A",
            //    ImageUrl = "Tesla Model 3 Performance.jpg"
            //});

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



            //////adding Others!////////
            //// Retrieve information
            //var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //var filename = Path.Combine(documents, "myImage.txt");
            //var texteo = File.ReadAllText(filename);
            //string[] line = texteo.Split(',');

            //// Gets file name with photo bytes
            //var number = "Foo" + (0 + 5).ToString() + ".txt";
            //var answer = Application.Current.Properties["Ulises"];


            //// Decodes byte into a stream
            //var bytos = File.ReadAllBytes("Foo" + (0 + 5).ToString() + ".txt");
            //Stream streamx = new MemoryStream(bytos);

            //Cars.Add(new Cars
            //{
            //    //Id = 3,
            //    Name = line[0],
            //    Location = line[1],
            //    ImageUrl = ImageSource.FromStream(() => streamx)
            //});






            BindingContext = this;

            //for (int i = 0; i < Cars.Count; i++) // Loop through List with for
            //{
            //    //Console.WriteLine(Cars[i].ImageUrl);
            //    var image = new Image { Source = Cars[i].ImageUrl };
            //}
        }

      

        //async void ImageClicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new Details(YourLabelName));
        //}

        async void ItemTapped(object sender, SelectionChangedEventArgs e)
        {
            //Console.WriteLine("hello");
            //Console.WriteLine(e.CurrentSelection);

            string currentCarSelection = e.CurrentSelection.ToString();
            Console.WriteLine(currentCarSelection);

            for (int i = 0; i < Cars.Count; i++) // Loop through List with for
            {
                if (Cars[i].Name == e.CurrentSelection.ToString())
                {
                    Console.WriteLine(Cars[i].Name);
                    Console.WriteLine(Cars[i].Location);
                    //Console.WriteLine(Cars[i].ImageUrl);
                    await Navigation.PushAsync(new Details(Cars[i].Name, Cars[i].Location, Cars[i].ImageUrl,i));
                }
               
            }


        
        }

    }
}

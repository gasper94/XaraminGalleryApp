using System;
using Xamarin.Forms;

public class Cars
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    //public string ImageUrl { get; set; }
    public ImageSource ImageUrl { get; set; }

    public string CreateDopCar()
    {
        return Name;
    }

    public override string ToString()
    {
        return Name;
    }
}

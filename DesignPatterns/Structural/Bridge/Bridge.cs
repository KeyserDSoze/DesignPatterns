using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Bridge
{
    public class Bridge : DesignPattern, IDesignPattern
    {
        public static Bridge Instance
        {
            get
            {
                VideoResource videoResource = new VideoResource();
                ImageResource imageResource = new ImageResource();
                BigView bigView = new BigView(videoResource);
                Console.WriteLine("Big View of Video: " + bigView.Show());
                bigView = new BigView(imageResource);
                Console.WriteLine("Big View of Image: " + bigView.Show());
                LittleView littleView = new LittleView(videoResource);
                Console.WriteLine("Little View of Video: " + littleView.Show());
                littleView = new LittleView(imageResource);
                Console.WriteLine("Little View of Image: " + littleView.Show());
                return null;
            }
        }
    }
    //abstraction
    public abstract class View
    {
        public IResource resource;
        public View(IResource resource)
        {
            this.resource = resource;
        }
        public abstract string Show();
    }
    //refined abstraction
    public class BigView : View
    {
        public BigView(IResource resource) : base(resource)
        {

        }
        public override string Show()
        {
            return this.resource.Title() + " - " + this.resource.Description() + " - " + this.resource.Image() + " - " + this.resource.Link();
        }
    }
    //second refined abstraction
    public class LittleView : View
    {
        public LittleView(IResource resource) : base(resource)
        {

        }
        public override string Show()
        {
            return this.resource.Title() + " - " + this.resource.Link();
        }
    }
    //implementor
    public interface IResource
    {
        string Title();
        string Image();
        string Description();
        string Link();
    }
    //concrete implementor
    public class VideoResource : IResource
    {
        private Video video;
        public VideoResource()
        {
            this.video = new Video() { Title = "Usual Suspect", Description = "A big movie", Thumbnail = "image.jpg", ContentUrl = "video.mpeg" };
        }
        public string Description()
        {
            return this.video.Description;
        }

        public string Image()
        {
            return this.video.Thumbnail;
        }

        public string Link()
        {
            return this.video.ContentUrl;
        }

        public string Title()
        {
            return this.video.Title;
        }
    }
    //class for concrete implementor, usually to get data from DB
    public class Video
    {
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        public string Description { get; set; }
        public string ContentUrl { get; set; }
    }
    //second concrete implementor
    public class ImageResource : IResource
    {
        private Image image;
        public ImageResource()
        {
            this.image = new Image() { Title = "Usual Suspect Background", Thumbnail = "image.jpg", ContentUrl = "image.png" };
        }
        public string Description()
        {
            return "";
        }

        public string Image()
        {
            return this.image.Thumbnail;
        }

        public string Link()
        {
            return this.image.ContentUrl;
        }

        public string Title()
        {
            return this.image.Title;
        }
    }
    //class for concrete implementor, usually to get data from DB
    public class Image
    {
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        public string ContentUrl { get; set; }
    }
}

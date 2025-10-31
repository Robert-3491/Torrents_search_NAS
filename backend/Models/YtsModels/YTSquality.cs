namespace Backend.Models.YtsModels;

public class YTSquality
{
    //Quality: 1080p or 2160p
    public string Quality { get; set; }
    //QualityType: WEB or BluRay
    public string QualityType { get; set; }
    public string Size { get; set; }
    public string MagnetURL { get; set; }

}
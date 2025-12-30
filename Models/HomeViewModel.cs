namespace ChessWebsite.Models
{
    public class HomeViewModel
    {
        public string PageTitle { get; set; }
        public string HeroTitle { get; set; }
        public string HeroSubtitle { get; set; }
        public List<Feature> Features { get; set; }
    }

    public class Feature
    {
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
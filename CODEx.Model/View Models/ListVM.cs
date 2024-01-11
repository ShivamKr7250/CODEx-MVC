namespace CODEx.Model.View_Models

{
    public class ListVM
    {
        public IEnumerable<Faculty> Faculty { get; set; }
        public IEnumerable<Events> Events { get; set; }
        public IEnumerable<Coordinator> Coordinators { get; set; }
    }
}

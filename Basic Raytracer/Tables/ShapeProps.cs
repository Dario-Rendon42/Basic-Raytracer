namespace Basic_Raytracer.Tables
{
    public class ShapeProps
    {
        public int ID { get; set; }
        public int ShapeID { get; set; }
        public Shape ParentShape { get; set; }
        public string PropertyName { get; set; }
        public double ProperyValue { get; set; }
    }
}
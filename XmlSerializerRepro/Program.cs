var serializer = new System.Xml.Serialization.XmlSerializer(typeof(MyClass));

public class MyClass
{
    public int Value;

    public AccessibleRole Role { get; set; }
}

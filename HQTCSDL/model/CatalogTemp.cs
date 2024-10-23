public class Catalog
{
    public int IdCategory { get; set; }
    public string NameCategory { get; set; }

    public override string ToString()
    {
        return NameCategory; // Hiển thị tên danh mục trong ComboBox
    }
}

namespace CustomControlHotReload;

public class MyTemplatedControl : VisualElement
{
    public static readonly BindableProperty ItemTemplateProperty =
        BindableProperty.Create(nameof(ItemTemplate), typeof(DataTemplate), typeof(MyTemplatedControl), null, propertyChanged: OnItemTemplateChanged);

    public DataTemplate ItemTemplate {
        get { return (DataTemplate)GetValue(ItemTemplateProperty); }
        set { SetValue(ItemTemplateProperty, value); }
    }

    public VisualElement Item { get; set; }

    static void OnItemTemplateChanged(BindableObject bindable, object oldValue, object newValue) {
        Console.WriteLine($"ItemTemplate changed from {oldValue} to {newValue}!");
    }
}

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();

        this.listView.ItemsSource = new List<string>() {
            "Item1",
        };
    }

    void Grid_PropertyChanged(System.Object sender, System.ComponentModel.PropertyChangedEventArgs e) {
        Console.WriteLine($"Property {e.PropertyName} changed!");
    }

    void Button_Clicked(System.Object sender, System.EventArgs e) {
        ChangeMyItemBackgroundColor(this.myTemplatedControl.Item);
    }

    void ChangeMyItemBackgroundColor(VisualElement visualElement) {
        if (visualElement == null)
            return;

        visualElement.BackgroundColor = visualElement.BackgroundColor == Colors.BlueViolet ?
                                        Colors.Red : Colors.BlueViolet;
    }
}


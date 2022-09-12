#if ANDROID
using CustomControlHotReload.Platforms.Android;
#endif

namespace CustomControlHotReload;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                }).ConfigureMauiHandlers(handlers => {
#if ANDROID
                    handlers.AddHandler(typeof(MyTemplatedControl), typeof(MyTemplatedControlHandler));
#endif
                });

		return builder.Build();
	}
}

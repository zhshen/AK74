using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MCS.Library.Core.Test.Configurations
{
    public class ConfigTest
    {
        [Fact]
        public void InMemoryConfigTest()
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();

            builder.AddInMemoryCollection(
                new Dictionary<string, string>()
                {
                    { "appSettings:mainWindow:height", "400" },
                    { "appSettings:mainWindow:width", "640" },
                    { "appSettings:MainWindow:top" , "0"},
                    { "appSettings:mainWindow:left", "0"},
                    { "appSettings:mainWindow:windowState", "Maximize"}
                });

            IConfiguration config = builder.Build();

            ConsoleWindow window = new ConsoleWindow();

            config.GetSection("appSettings:mainWindow").Bind(window);

            Assert.Equal(400, window.Height);
            Assert.Equal(640, window.Width);
            Assert.Equal(WindowStateeMode.Maximize, window.WindowState);
        }

        [Fact]
        public void JsonConfigTest()
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();

            builder.AddJsonFile("appSettings.json");

            IConfiguration config = builder.Build();

            ConsoleWindow window = new ConsoleWindow();

            config.GetSection("appSettings:mainWindow").Bind(window);

            Assert.Equal(400, window.Height);
            Assert.Equal(640, window.Width);
            Assert.Equal(WindowStateeMode.Maximize, window.WindowState);
        }

        [Fact]
        public void MergeConfigTest()
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();

            builder.AddJsonFile("appSettings.json");

            builder.AddInMemoryCollection(
                new Dictionary<string, string>()
                {
                    { "appSettings:mainWindow:height", "300" },
                    { "appSettings:windows:mainWindow:height", "400" },
                    { "appSettings:windows:mainWindow:width", "640" },
                    { "appSettings:windows:mainWindow:top" , "0"},
                    { "appSettings:windows:mainWindow:left", "0"},
                    { "appSettings:windows:mainWindow:windowState", "Maximize"},
                    { "appSettings:windows:childWindow:height", "600" },
                    { "appSettings:windows:childWindow:width", "800" },
                    { "appSettings:windows:childWindow:top" , "0"},
                    { "appSettings:windows:childWindow:left", "0"},
                    { "appSettings:windows:childWindow:windowState", "Maximize"}
                });

            IConfiguration config = builder.Build();

            Dictionary<string, ConsoleWindow> windows = new Dictionary<string, ConsoleWindow>();

            config.GetSection("appSettings:windows").Bind(windows);

            Assert.Equal(3, windows.Count);

            //后面的盖住前面的
            Assert.Equal(400, windows["mainWindow"].Height);
            Assert.Equal(640, windows["mainWindow"].Width);

            Assert.Equal(600, windows["childWindow"].Height);
            Assert.Equal(800, windows["childWindow"].Width);

            Assert.Equal(768, windows["largeWindow"].Height);
            Assert.Equal(1024, windows["largeWindow"].Width);
        }
    }
}

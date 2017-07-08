using System;
using System.Collections.Generic;
using System.Linq;

namespace Modules
{
    // посмотреть как сделаны на HSS вертикальные слои, WCF?
    // todo: из фронта надо вызвать бэк и тд
    public class Program
    {
        public static void Main(string[] args)
        {
            var settings = new ApplicationSettings
            {
                Hosts = new List<HostSettings>
                {
                    new HostSettings
                    {
                        Name = "Frontend1",
                        Modules = new List<ModuleSettings>
                        {
                            new ModuleSettings
                            {
                                Type = ModuleType.Frontend
                            }
                        }
                    },
                    new HostSettings
                    {
                        Name = "Frontend2",
                        Modules = new List<ModuleSettings>
                        {
                            new ModuleSettings
                            {
                                Type = ModuleType.Frontend
                            }
                        }
                    },
                    new HostSettings
                    {
                        Name = "Backend1",
                        Modules = new List<ModuleSettings>
                        {
                            new ModuleSettings
                            {
                                Type = ModuleType.Backend
                            }
                        }
                    },
                    new HostSettings
                    {
                        Name = "Database1",
                        Modules = new List<ModuleSettings>
                        {
                            new ModuleSettings
                            {
                                Type = ModuleType.Database
                            },
                            new ModuleSettings
                            {
                                Type = ModuleType.FileStorage
                            }
                        }
                    },
                    new HostSettings
                    {
                        Name = "Database2",
                        Modules = new List<ModuleSettings>
                        {
                            new ModuleSettings
                            {
                                Type = ModuleType.Database
                            }
                        }
                    },
                }
            };

            var application = new Application(settings);
            application.Start();

            foreach (var requestNumber in Enumerable.Range(1, 10))
            {
                var request = new HttpRequest
                {
                    Number = requestNumber
                };

                var response = application.Process(request);
                Console.WriteLine(response.Result);
            }
        }
    }
}
